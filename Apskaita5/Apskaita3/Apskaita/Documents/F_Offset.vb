Imports ApskaitaObjects.Documents
Imports ApskaitaObjects.HelperLists
Public Class F_Offset
    Implements IObjectEditForm, ISupportsPrinting

    Private Obj As Offset
    Private OffsetID As Integer = -1
    Private Loading As Boolean = True


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If Not Obj Is Nothing Then Return Obj.ID
            Return 0
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(Offset)
        End Get
    End Property


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal nOffsetID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        OffsetID = nOffsetID

    End Sub


    Private Sub F_Offset_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList), _
            GetType(HelperLists.AccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_Offset_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not Obj Is Nothing AndAlso TypeOf Obj Is IIsDirtyEnough AndAlso _
            DirectCast(Obj, IIsDirtyEnough).IsDirtyEnough Then
            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))
            If answ <> "Taip" AndAlso answ <> "Ne" Then
                e.Cancel = True
                Exit Sub
            End If
            If answ = "Taip" Then
                If Not SaveObj() Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If

        GetFormLayout(Me)
        GetDataGridViewLayOut(ItemListDataGridView)

    End Sub

    Private Sub F_Offset_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If OffsetID > 0 AndAlso Not Documents.Offset.CanGetObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        ElseIf Not OffsetID > 0 AndAlso Not Documents.Offset.CanAddObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka naujam dokumentui įvesti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        If OffsetID > 0 Then

            Try
                Obj = LoadObject(Of Offset)(Nothing, "GetOffset", True, OffsetID)
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

        Else

            Obj = Offset.NewOffset

        End If

        OffsetBindingSource.DataSource = Obj

        AddDGVColumnSelector(ItemListDataGridView)

        SetDataGridViewLayOut(ItemListDataGridView)
        SetFormLayout(Me)

        If Not Obj.IsNew AndAlso Not Documents.Offset.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka duomenims redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            ItemListDataGridView.Enabled = True
            ItemListDataGridView.ReadOnly = True
            Exit Sub
        End If

        ConfigureButtons()

    End Sub


    Private Sub OkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IOkButton.Click

        If Not SaveObj() Then Exit Sub
        Me.Hide()
        Me.Close()

    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IApplyButton.Click
        If Not SaveObj() Then Exit Sub
        If Not Obj.IsNew AndAlso Not Offset.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka duomenims redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            ItemListDataGridView.Enabled = True
            ItemListDataGridView.ReadOnly = True
            Exit Sub
        End If
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ICancelButton.Click
        CancelObj()
    End Sub


    Private Sub GetCurrencyRatesButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles GetCurrencyRatesButton.Click

        If Obj Is Nothing Then Exit Sub

        Dim paramList As New AccWebCrawler.CurrencyRateList

        For Each b As OffsetItem In Obj.ItemList
            paramList.Add(Obj.Date, b.CurrencyCode)
        Next

        If paramList.Count < 1 Then Exit Sub

        If Not YesOrNo("Gauti valiutos kursą?") Then Exit Sub

        Using frm As New AccWebCrawler.F_LaunchWebCrawler(paramList, GetCurrentCompany.BaseCurrency)

            If frm.ShowDialog <> Windows.Forms.DialogResult.OK OrElse frm.result Is Nothing _
                OrElse Not TypeOf frm.result Is AccWebCrawler.CurrencyRateList _
                OrElse DirectCast(frm.result, AccWebCrawler.CurrencyRateList).Count < 1 Then Exit Sub

            For Each b As OffsetItem In Obj.ItemList
                b.CurrencyRate = DirectCast(frm.result, AccWebCrawler.CurrencyRateList). _
                    GetCurrencyRate(Obj.Date, b.CurrencyCode)
            Next

        End Using

    End Sub

    Private Sub BalanceButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles BalanceButton.Click

        If Obj Is Nothing Then Exit Sub

        If Obj.SumDebit > Obj.SumCredit Then
            Obj.BalanceSum = Obj.BalanceSum + (Obj.SumDebit - Obj.SumCredit)
        ElseIf Obj.SumDebit < Obj.SumCredit Then
            Obj.BalanceSum = Obj.BalanceSum - (Obj.SumCredit - Obj.SumDebit)
        End If

    End Sub

    Private Sub LimitationsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LimitationsButton.Click
        If Obj Is Nothing Then Exit Sub
        MsgBox(Obj.ChronologicValidator.LimitsExplanation, MsgBoxStyle.Information, "")
    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click
        If Obj Is Nothing OrElse Not Obj.ID > 0 Then Exit Sub
        MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, Obj.ID, Obj.ID)
    End Sub


    Public Function GetMailDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetMailDropDownItems
        Return Nothing
    End Function

    Public Function GetPrintDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintDropDownItems
        Return Nothing
    End Function

    Public Function GetPrintPreviewDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintPreviewDropDownItems
        Return Nothing
    End Function

    Public Sub OnMailClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnMailClick

        If Obj Is Nothing Then Exit Sub

        Using frm As New F_SendObjToEmail(Obj, 0)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick

        If Obj Is Nothing Then Exit Sub

        Try
            PrintObject(Obj, False, 0)
        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick

        If Obj Is Nothing Then Exit Sub

        Try
            PrintObject(Obj, True, 0)
        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function


    Private Function SaveObj() As Boolean

        If Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.GetAllBrokenRules, _
                MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        If Not String.IsNullOrEmpty(Obj.GetAllWarnings.Trim) Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf _
                & Obj.GetAllWarnings & vbCrLf
        Else
            Question = ""
        End If
        If Obj.IsNew Then
            Question = Question & "Ar tikrai norite įtraukti naujus duomenis?"
            Answer = "Nauji duomenys sėkmingai įtraukti."
        Else
            Question = Question & "Ar tikrai norite pakeisti duomenis?"
            Answer = "Duomenys sėkmingai pakeisti."
        End If

        If Not YesOrNo(Question) Then Return False

        Using bm As New BindingsManager(OffsetBindingSource, _
            ItemListSortedBindingSource, Nothing, True, False)

            Try
                Obj = LoadObject(Of Offset)(Obj, "Save", False)
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        ConfigureButtons()

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj()
        If Obj Is Nothing OrElse Obj.IsNew OrElse Not Obj.IsDirty Then Exit Sub
        Using bm As New BindingsManager(OffsetBindingSource, _
            ItemListSortedBindingSource, Nothing, True, True)
        End Using
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList), _
            GetType(HelperLists.AccountInfoList)) Then Return False

        Try

            LoadEnumHumanReadableListToComboBox(DataGridViewTextBoxColumn3, GetType(BookEntryType), False)
            LoadCurrencyCodeListToComboBox(DataGridViewTextBoxColumn7, False)

            LoadPersonInfoListToGridCombo(DataGridViewTextBoxColumn4, True, True, True, True)
            LoadAccountInfoListToGridCombo(DataGridViewTextBoxColumn5, True, 1, 2, 3, 4)
            LoadAccountInfoListToGridCombo(DataGridViewTextBoxColumn11, True, 5, 6)
            LoadAccountInfoListToGridCombo(BalanceAccountAccGridComboBox, True, 5, 6)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Private Sub ConfigureButtons()

        If Obj Is Nothing Then Exit Sub

        BalanceSumAccTextBox.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        BalanceAccountAccGridComboBox.Enabled = Obj.ChronologicValidator.FinancialDataCanChange
        BalanceButton.Enabled = Obj.ChronologicValidator.FinancialDataCanChange
        GetCurrencyRatesButton.Enabled = Obj.ChronologicValidator.FinancialDataCanChange

        ItemListDataGridView.AllowUserToAddRows = Obj.ChronologicValidator.FinancialDataCanChange
        ItemListDataGridView.AllowUserToDeleteRows = Obj.ChronologicValidator.FinancialDataCanChange

        DataGridViewTextBoxColumn3.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewTextBoxColumn4.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewTextBoxColumn5.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewTextBoxColumn6.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewTextBoxColumn7.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewTextBoxColumn8.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewTextBoxColumn10.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewTextBoxColumn11.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange

        ICancelButton.Enabled = Not Obj.IsNew

        LimitationsButton.Visible = Not String.IsNullOrEmpty(Obj.ChronologicValidator.LimitsExplanation.Trim)

    End Sub

End Class