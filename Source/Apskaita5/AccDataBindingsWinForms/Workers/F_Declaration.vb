﻿Imports AccControlsWinForms
Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.ActiveReports
Imports AccDataBindingsWinForms.Printing
Imports AccDataBindingsWinForms.CachedInfoLists
Imports ApskaitaObjects.Attributes
Imports ApskaitaObjects.Settings
Imports System.Runtime.Serialization.Formatters.Binary

Friend Class F_Declaration

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(AccountInfoList), GetType(CodeInfoList), GetType(NameInfoList)}

    Private _CurrentDeclaration As Declaration = Nothing
    Private _QueryManager As CslaActionExtenderQueryObject = Nothing
    Private _Loading As Boolean = True

    Private _ReportDataSet As ReportData = Nothing
    Private _TblGeneral As BindingSource = Nothing
    Private _Tbl1 As BindingSource = Nothing
    Private _Tbl2 As BindingSource = Nothing
    Private _Tbl3 As BindingSource = Nothing
    Private _Tbl4 As BindingSource = Nothing
    Private _TblCompany As BindingSource = Nothing
    Private _NumberOfTablesInUse As Integer
    Private _ReportFileName As String = ""


    Private Sub F_Declarations_Activated(ByVal sender As Object,
        ByVal e As System.EventArgs) Handles Me.Activated



        If _Loading Then
            _Loading = False
            Exit Sub
        End If

        PrepareCache(Me, _RequiredCachedLists)

    End Sub

    Private Sub F_Declarations_FormClosed(ByVal sender As Object,
        ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Not _ReportDataSet Is Nothing Then _ReportDataSet.Dispose()
        If Not _TblGeneral Is Nothing Then _TblGeneral.Dispose()
        If Not _Tbl1 Is Nothing Then _Tbl1.Dispose()
        If Not _Tbl2 Is Nothing Then _Tbl2.Dispose()
        If Not _Tbl3 Is Nothing Then _Tbl3.Dispose()
        If Not _Tbl4 Is Nothing Then _Tbl4.Dispose()
        If Not _TblCompany Is Nothing Then _TblCompany.Dispose()
        MyCustomSettings.GetFormLayout(Me)
    End Sub


    Private Sub F_Declarations_Load(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub


    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            PrepareControl(SODRAAccountAccGridComboBox,
                New AccountFieldAttribute(ValueRequiredLevel.Optional, False, 4))
            PrepareControl(SODRAAccountAccGridComboBox2,
                New AccountFieldAttribute(ValueRequiredLevel.Optional, False, 4))
            PrepareControl(MunicipalitiesAccGridComboBox,
                New CodeFieldAttribute(ValueRequiredLevel.Optional,
                CodeType.VmiMunicipality))
            PrepareControl(SODRADepartmentComboBox,
                New NameFieldAttribute(ValueRequiredLevel.Optional,
                NameType.SodraBranch))

            YearComboBox.Items.Clear()
            For i As Integer = 1 To 10
                YearComboBox.Items.Add((Today.Year - i + 1).ToString)
            Next

            DeclarationTypeComboBox.DataSource = GetAvailableIDeclarationList()

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller1)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        MyCustomSettings.SetFormLayout(Me)

        Return True

    End Function


    Private Sub RefreshButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Dim declaration As ActiveReports.IDeclaration = Nothing
        Try
            declaration = DirectCast(DeclarationTypeComboBox.SelectedItem, IDeclaration)
        Catch ex As Exception
            MsgBox("Klaida. Nepasirinktas deklaracijos tipas.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End Try

        Dim year As Integer = 0
        Dim month As Integer = MonthComboBox.SelectedIndex + 1
        Dim quarter As Byte = Convert.ToByte(QuarterComboBox.SelectedIndex + 1)
        Dim sodraAccount As Long = 0
        Dim sodraAccount2 As Long = 0
        Dim sodraRate As Double = 0
        Dim sodraDepartment As String = ""
        Dim municipalityCode As String = ""

        Try
            sodraAccount = DirectCast(SODRAAccountAccGridComboBox.SelectedValue, Long)
        Catch ex As Exception
        End Try
        Try
            sodraAccount2 = DirectCast(SODRAAccountAccGridComboBox2.SelectedValue, Long)
        Catch ex As Exception
        End Try
        Try
            sodraRate = CDbl(SodraRateComboBox.SelectedItem)
        Catch ex As Exception
        End Try
        Try
            year = Integer.Parse(YearComboBox.SelectedItem.ToString)
        Catch ex As Exception
        End Try
        If Not SODRADepartmentComboBox.SelectedItem Is Nothing Then
            sodraDepartment = SODRADepartmentComboBox.SelectedItem.ToString()
        End If
        If Not MunicipalitiesAccGridComboBox.SelectedValue Is Nothing Then
            municipalityCode = MunicipalitiesAccGridComboBox.SelectedValue.ToString.Trim
        End If

        Dim criteria As DeclarationCriteria = DeclarationCriteria.NewDeclarationCriteria(
            DateAccDatePicker.Value.Date, DateFromAccDatePicker.Value.Date,
            DateToAccDatePicker.Value.Date, declaration, year, CInt(quarter),
            month, municipalityCode, sodraDepartment, sodraAccount, sodraAccount2, sodraRate)

        If Not criteria.IsValid() Then
            MsgBox(String.Format("Klaida. Nenurodyti visi reikalingi deklaracijos parametrai:{0}{1}",
                vbCrLf, criteria.GetAllErrors()), MsgBoxStyle.Critical, "Klaida")
            Exit Sub
        End If

        If criteria.HasWarnings() Then
            If Not YesOrNo(String.Format("DĖMESIO. Deklaracijos parametruose gali būti klaidų:{0}{1}{2}Ar tikrai norite tęsti?",
                vbCrLf, criteria.GetAllWarnings(), vbCrLf)) Then Exit Sub
        End If

        _QueryManager.InvokeQuery(Of Declaration)(Nothing, "GetDeclaration", True,
            AddressOf OnDeclarationFetched, criteria)

    End Sub

    Private Sub OnDeclarationFetched(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If result Is Nothing Then Exit Sub

        _CurrentDeclaration = DirectCast(result, Declaration)

        If Not StringIsNullOrEmpty(_CurrentDeclaration.Warning) Then
            MsgBox(_CurrentDeclaration.Warning.Trim, MsgBoxStyle.Information, "Info")
        End If

        Try
            Using busy As New StatusBusy
                RefreshReportViewer()
                GetFFdataButton.Enabled = True
            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
        End Try

        DeclarationReportViewer.Select()
        DeclarationReportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
        DeclarationReportViewer.ZoomPercent = 75

    End Sub

    Private Sub RefreshReportViewer()

        DeclarationReportViewer.LocalReport.DataSources.Clear()
        DeclarationReportViewer.Reset()

        If _CurrentDeclaration Is Nothing Then Exit Sub

        _ReportDataSet = MapObjToReport(_CurrentDeclaration, _ReportFileName,
            _NumberOfTablesInUse, 1, "", Nothing)

        If _NumberOfTablesInUse < 0 Then _NumberOfTablesInUse = 0
        If _NumberOfTablesInUse > 4 Then _NumberOfTablesInUse = 4
        InitializeBindingSources(_NumberOfTablesInUse)

        Dim newSourceGeneral As New Microsoft.Reporting.WinForms.ReportDataSource
        newSourceGeneral.Value = _TblGeneral
        newSourceGeneral.Name = "ReportData_TableGeneral"
        DeclarationReportViewer.LocalReport.DataSources.Add(newSourceGeneral)

        Dim newSourceCompany As New Microsoft.Reporting.WinForms.ReportDataSource
        newSourceCompany.Value = _TblCompany
        newSourceCompany.Name = "ReportData_TableCompany"
        DeclarationReportViewer.LocalReport.DataSources.Add(newSourceCompany)


        For i As Integer = 1 To _NumberOfTablesInUse

            Dim newSource As New Microsoft.Reporting.WinForms.ReportDataSource

            If i = 1 Then
                newSource.Value = _Tbl1
                newSource.Name = "ReportData_Table1"
            ElseIf i = 2 Then
                newSource.Value = _Tbl2
                newSource.Name = "ReportData_Table2"
            ElseIf i = 3 Then
                newSource.Value = _Tbl3
                newSource.Name = "ReportData_Table3"
            Else
                newSource.Value = _Tbl4
                newSource.Name = "ReportData_Table4"
            End If

            DeclarationReportViewer.LocalReport.DataSources.Add(newSource)

        Next

        DeclarationReportViewer.LocalReport.ReportPath = IO.Path.Combine(IO.Path.Combine(
            AppPath(), RDLC_FOLDER), _ReportFileName)

        DeclarationReportViewer.RefreshReport()

    End Sub

    Private Sub InitializeBindingSources(ByVal numberOfTablesInUse As Integer)
        _TblGeneral = New BindingSource(_ReportDataSet, "TableGeneral")
        _TblCompany = New BindingSource(_ReportDataSet, "TableCompany")
        If numberOfTablesInUse < 1 Then Exit Sub
        If numberOfTablesInUse >= 1 Then _Tbl1 = New BindingSource(_ReportDataSet, "Table1")
        If numberOfTablesInUse >= 2 Then _Tbl2 = New BindingSource(_ReportDataSet, "Table2")
        If numberOfTablesInUse >= 3 Then _Tbl3 = New BindingSource(_ReportDataSet, "Table3")
        If numberOfTablesInUse >= 4 Then _Tbl4 = New BindingSource(_ReportDataSet, "Table4")
    End Sub

    Private Sub OnRenderingComplete(ByVal sender As Object,
            ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) _
            Handles DeclarationReportViewer.RenderingComplete
        DeclarationReportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        DeclarationReportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
        DeclarationReportViewer.ZoomPercent = 75
    End Sub


    Private Sub GetFFdataButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles GetFFdataButton.Click

        'Using ms As New IO.MemoryStream(Convert.FromBase64String(Clipboard.GetText()))
        '    Dim formater As New BinaryFormatter()
        '    Dim result As Declaration = formater.Deserialize(ms)
        '    Dim i As Integer = 123
        '    result.SaveToFFData("C:\Users\Niemand\Desktop\test.ffdata", "Jonas")
        'End Using

        If _CurrentDeclaration Is Nothing Then Exit Sub

        Dim fileName As String = ""

        Using sfd As New SaveFileDialog
            sfd.Filter = "FFData failai|*.ffdata|Visi failai|*.*"
            sfd.CheckFileExists = False
            sfd.AddExtension = True
            sfd.DefaultExt = ".ffdata"
            If sfd.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
            fileName = sfd.FileName
        End Using

        If StringIsNullOrEmpty(fileName) Then Exit Sub

        Try

            Using busy As New StatusBusy
                _CurrentDeclaration.SaveToFFData(fileName, MyCustomSettings.UserName)
            End Using

        Catch ex As Exception
            ShowError(ex, _CurrentDeclaration)
            Exit Sub
        End Try

        If _CurrentDeclaration.Criteria.DeclarationType.ValidTo < Today Then

            MsgBox("DĖMESIO!!! Ši deklaracija ar jos versija yra nebenaudojama. " & _
                   "Atidarant suformuotą ffdata failą ABBYY eFormFiller programa, " & _
                   "jums gali būti pasiūlyta atnaujinti formą. Šito daryti GRIEŽTAI " & _
                   "NEGALIMA, nes sugadinsite programos saugomą senos formos šabloną.", _
                   MsgBoxStyle.Exclamation, "Info")

        End If

        If YesOrNo("Failas sėkmingai išsaugotas. Atidaryti?") Then
            System.Diagnostics.Process.Start(fileName)
        End If

    End Sub


    Private Sub RefreshSodraRateButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshSodraRateButton.Click

        If DeclarationTypeComboBox.SelectedIndex < 0 Then Exit Sub

        Dim year As Integer = 0
        Dim month As Integer = MonthComboBox.SelectedIndex + 1
        Try
            year = Integer.Parse(YearComboBox.SelectedItem.ToString)
        Catch ex As Exception
            MsgBox("Klaida.Nepasirinkti metai.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End Try

        _QueryManager.InvokeQuery(Of SodraRateInfo)(Nothing, "GetSodraRateInfo", True, _
            AddressOf OnAvailableSodraRatesFetched, year, month)

    End Sub

    Private Sub OnAvailableSodraRatesFetched(ByVal result As Object, _
        ByVal exceptionHandled As Boolean)

        If result Is Nothing Then Exit Sub

        SodraRateComboBox.DataSource = DirectCast(result, SodraRateInfo).Rates

        If DirectCast(result, SodraRateInfo).Rates.Count > 0 Then
            SodraRateComboBox.SelectedIndex = 0
        End If

    End Sub

End Class