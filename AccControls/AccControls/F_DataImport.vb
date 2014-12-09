Public Class F_DataImport

    Private Const ParseErrorMessage As String = "Cannot parse '{0}' as {1}."
    Private _ModelDataTable As DataTable
    Private _Result As DataTable = Nothing
    Private _IsRawData As Boolean = True


    Public ReadOnly Property Result() As DataTable
        Get
            Return _Result
        End Get
    End Property


    Public Sub New(ByVal modelDataTable As DataTable)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _ModelDataTable = modelDataTable

    End Sub


    Private Sub F_DataImport_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        DelimiterTextBox.Text = CsvReader.CsvReader.DefaultDelimiter
        QuoteTextBox.Text = CsvReader.CsvReader.DefaultQuote
        EscapeTextBox.Text = CsvReader.CsvReader.DefaultEscape
        CommentTextBox.Text = CsvReader.CsvReader.DefaultComment

    End Sub


    Private Sub OpenFileButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OpenFileButton.Click

        Dim FileName As String

        Using OFD As New OpenFileDialog
            OFD.Multiselect = False
            OFD.Filter = "CSV files|*.csv|Visi failai|*.*"
            If OFD.ShowDialog(Me) <> System.Windows.Forms.DialogResult.OK Then Exit Sub
            FileName = OFD.FileName
        End Using
        If FileName Is Nothing OrElse String.IsNullOrEmpty(FileName.Trim) _
            OrElse Not IO.File.Exists(FileName) Then Exit Sub

        Try
            Using stream As New IO.StreamReader(FileName)
                LoadSourceData(stream, DelimiterTextBox.Text)
            End Using
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko atidaryti failo: " & ex.Message, ex))
        End Try

    End Sub

    Private Sub PasteButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles PasteButton.Click

        Try

            Dim stringBytes As Byte() = System.Text.Encoding.Unicode.GetBytes(Clipboard.GetText)
            Using stream As New System.IO.MemoryStream(stringBytes)
                Using reader As New IO.StreamReader(stream)
                    LoadSourceData(reader, vbTab)
                End Using
            End Using

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti duomenų iš clipboard'o: " & ex.Message, ex))
        End Try

    End Sub

    Private Sub ApplyTypesButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyTypesButton.Click
        CreateTypedDataTable()
    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButton.Click

        If DataGridView1.DataSource Is Nothing OrElse DataGridView1.Rows.Count < 1 Then
            If Not YesOrNo("Jokie duomenys nebuvo importuoti. Ar tikrai norite uždaryti formą?") Then Exit Sub
            _Result = Nothing
        ElseIf _Result Is Nothing Then
            If YesOrNo("Klaida. Nesutikrinti duomenų tipai, jokie duomenys nebus importuoti. Ar tikrai norite uždaryti formą?") Then Exit Sub
        End If

        Me.Hide()
        Me.Close()

    End Sub


    Private Sub DataGridView1_ColumnDisplayIndexChanged(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) _
        Handles DataGridView1.ColumnDisplayIndexChanged
        If _Result Is Nothing Then SetDataGridViewHeaders()
    End Sub


    Private Sub LoadSourceData(ByVal reader As IO.StreamReader, ByVal delimiter As Char)

        Using csv As New CsvReader.CsvReader(reader, HasHeadersCheckBox.Checked, _
            delimiter, QuoteTextBox.Text, EscapeTextBox.Text, CommentTextBox.Text, _
            CsvReader.ValueTrimmingOptions.All)

            Dim fieldCount As Integer = csv.FieldCount

            Dim result As New DataTable

            For i As Integer = 1 To Math.Max(fieldCount, _ModelDataTable.Columns.Count)
                result.Columns.Add()
                If _ModelDataTable.Columns.Count < i Then
                    result.Columns(i - 1).ColumnName = "RedundantColumn" & i.ToString
                Else
                    result.Columns(i - 1).ColumnName = _ModelDataTable.Columns(i - 1).ColumnName
                End If
                result.Columns(i - 1).Caption = GetHeaderText(i - 1)
            Next

            While csv.ReadNextRecord
                result.Rows.Add()
                For i As Integer = 1 To fieldCount
                    result.Rows(result.Rows.Count - 1).Item(i - 1) = csv(i - 1)
                Next
            End While

            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = result

            SetDataGridViewHeaders()

            If Not result Is Nothing Then
                _Result.Dispose()
                _Result = Nothing
            End If

            DataGridView1.AllowUserToOrderColumns = True

        End Using

    End Sub

    Private Function GetHeaderText(ByVal index As Integer)
        If _ModelDataTable.Columns.Count < index + 1 Then
            Return "Redundant Column " & (index + 1).ToString
        ElseIf String.IsNullOrEmpty(_ModelDataTable.Columns(index).Caption.Trim) Then
            Return _ModelDataTable.Columns(index).ColumnName
        Else
            Return _ModelDataTable.Columns(index).Caption
        End If
    End Function

    Private Sub SetDataGridViewHeaders()
        If DataGridView1.DataSource Is Nothing Then Exit Sub
        For Each col As DataGridViewColumn In DataGridView1.Columns
            col.HeaderText = GetHeaderText(col.DisplayIndex)
        Next
    End Sub

    Private Sub CreateTypedDataTable()

        If DataGridView1.DataSource Is Nothing OrElse DataGridView1.Rows.Count < 1 Then
            MsgBox("Neįkrauti jokie duomenys.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        ElseIf Not _Result Is Nothing Then
            MsgBox("Duomenų tipai jau konvertuoti.", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        _Result = New DataTable

        Try
            For i As Integer = 1 To _ModelDataTable.Columns.Count
                Result.Columns.Add(_ModelDataTable.Columns(i - 1).ColumnName, _
                    _ModelDataTable.Columns(i - 1).DataType)
            Next

            Dim j As Integer
            Dim errorDescription As String = ""
            Dim displayIndex As Integer
            For i As Integer = 1 To DataGridView1.Rows.Count
                _Result.Rows.Add()
                For j = 1 To DataGridView1.Columns.Count
                    displayIndex = DataGridView1.Columns(j - 1).DisplayIndex
                    If displayIndex < _ModelDataTable.Columns.Count Then
                        _Result.Rows(i - 1).Item(displayIndex) = ConvertToType(DataGridView1.Item(j - 1, i - 1).Value, _
                            _ModelDataTable.Columns(displayIndex).DataType, errorDescription)
                        If Not String.IsNullOrEmpty(errorDescription.Trim) Then _
                            _Result.Rows(i - 1).SetColumnError(displayIndex, errorDescription)
                    End If
                Next
            Next
        Catch ex As Exception
            ShowError(ex)
            _Result.Dispose()
            _Result = Nothing
            Exit Sub
        End Try

        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = Result

        SetDataGridViewHeaders()

        DataGridView1.AllowUserToOrderColumns = False

    End Sub

    Private Function ConvertToType(ByVal value As String, ByVal expectedType As Type, _
        ByRef errorDescription As String) As Object

        errorDescription = ""
        If value Is Nothing Then value = ""
        value = value.Trim

        If expectedType Is GetType(String) Then
            Return value
        ElseIf expectedType Is GetType(Byte) Then
            Dim result As Byte
            If String.IsNullOrEmpty(value.Trim) Then
                result = 0
                Return result
            End If
            If Not Byte.TryParse(value, Globalization.NumberStyles.Any, _
                System.Globalization.CultureInfo.InvariantCulture, result) Then _
                errorDescription = String.Format(ParseErrorMessage, value, expectedType.Name)
            Return result
        ElseIf expectedType Is GetType(Short) Then
            Dim result As Short
            If String.IsNullOrEmpty(value.Trim) Then
                result = 0
                Return result
            End If
            If Not Short.TryParse(value, Globalization.NumberStyles.Any, _
                System.Globalization.CultureInfo.InvariantCulture, result) Then _
                errorDescription = String.Format(ParseErrorMessage, value, expectedType.Name)
            Return result
        ElseIf expectedType Is GetType(Integer) Then
            Dim result As Integer
            If String.IsNullOrEmpty(value.Trim) Then
                result = 0
                Return result
            End If
            If Not Integer.TryParse(value, Globalization.NumberStyles.Any, _
                System.Globalization.CultureInfo.InvariantCulture, result) Then _
                errorDescription = String.Format(ParseErrorMessage, value, expectedType.Name)
            Return result
        ElseIf expectedType Is GetType(Long) Then
            Dim result As Long
            If String.IsNullOrEmpty(value.Trim) Then
                result = 0
                Return result
            End If
            If Not Long.TryParse(value, Globalization.NumberStyles.Any, _
                System.Globalization.CultureInfo.InvariantCulture, result) Then _
                errorDescription = String.Format(ParseErrorMessage, value, expectedType.Name)
            Return result
        ElseIf expectedType Is GetType(Double) Then
            Dim result As Double
            If String.IsNullOrEmpty(value.Trim) Then
                result = 0
                Return result
            End If
            If Not Double.TryParse(value, Globalization.NumberStyles.Any, _
                System.Globalization.CultureInfo.InvariantCulture, result) Then _
                errorDescription = String.Format(ParseErrorMessage, value, expectedType.Name)
            Return result
        ElseIf expectedType Is GetType(Decimal) Then
            Dim result As Decimal
            If String.IsNullOrEmpty(value.Trim) Then
                result = 0
                Return result
            End If
            If Not Decimal.TryParse(value, Globalization.NumberStyles.Any, _
                System.Globalization.CultureInfo.InvariantCulture, result) Then _
                errorDescription = String.Format(ParseErrorMessage, value, expectedType.Name)
            Return result
        ElseIf expectedType Is GetType(Single) Then
            Dim result As Single
            If String.IsNullOrEmpty(value.Trim) Then
                result = 0
                Return result
            End If
            If Not Single.TryParse(value, Globalization.NumberStyles.Any, _
                System.Globalization.CultureInfo.InvariantCulture, result) Then _
                errorDescription = String.Format(ParseErrorMessage, value, expectedType.Name)
            Return result
        ElseIf expectedType Is GetType(DateTime) Then
            Dim result As DateTime
            If Not DateTime.TryParse(value, System.Globalization.CultureInfo.InvariantCulture, _
                Globalization.DateTimeStyles.None, result) Then errorDescription = _
                String.Format(ParseErrorMessage, value, expectedType.Name)
            Return result
        ElseIf expectedType Is GetType(Date) Then
            Dim result As DateTime
            If Not Date.TryParse(value, System.Globalization.CultureInfo.InvariantCulture, _
                Globalization.DateTimeStyles.None, result) Then errorDescription = _
                String.Format(ParseErrorMessage, value, expectedType.Name)
            Return result
        ElseIf expectedType Is GetType(Boolean) Then
            Dim result As Boolean
            If value.Trim.ToUpper = "TRUE" OrElse value.Trim.ToUpper = "FALSE" Then
                result = value.Trim.ToUpper = "TRUE"
            Else
                Dim resultInt As Integer
                If Not Integer.TryParse(value, Globalization.NumberStyles.Any, _
                    System.Globalization.CultureInfo.InvariantCulture, resultInt) Then _
                    errorDescription = String.Format(ParseErrorMessage, value, expectedType.Name)
                result = (resultInt > 0)
            End If
            Return result
        Else
            errorDescription = String.Format(ParseErrorMessage, value, expectedType.Name)
            Return Nothing
        End If

        Dim c As New System.Globalization.CultureInfo("", True)

        c.DateTimeFormat.DateSeparator = "-"
        c.DateTimeFormat.FullDateTimePattern = "yyyy-MM-dd HH:mm:ss"
        c.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        c.DateTimeFormat.ShortTimePattern = "HH:mm:ss"
        c.DateTimeFormat.TimeSeparator = ":"
        c.NumberFormat.CurrencyDecimalSeparator = ","
        c.NumberFormat.CurrencyGroupSeparator = "."
        c.NumberFormat.CurrencyNegativePattern = 0
        c.NumberFormat.CurrencySymbol = ""
        c.NumberFormat.CurrencyPositivePattern = 0
        c.NumberFormat.NegativeSign = ""
        c.NumberFormat.PositiveSign = ""

        System.Threading.Thread.CurrentThread.CurrentCulture = c

    End Function

End Class