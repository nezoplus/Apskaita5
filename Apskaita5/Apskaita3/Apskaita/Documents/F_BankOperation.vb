Imports ApskaitaObjects.Documents
Public Class F_BankOperation
    Implements ISupportsPrinting, IObjectEditForm

    Private Obj As BankOperation
    Private BankOperationID As Integer = -1
    Private ImportedBankOperation As BankOperationItem = Nothing
    Private ImportedBankOperationAccount As HelperLists.CashAccountInfo = Nothing
    Private Loading As Boolean = True

    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If Not Obj Is Nothing Then Return Obj.ID
            Return 0
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(BankOperation)
        End Get
    End Property

    Public ReadOnly Property ImportedObject() As BankOperationItem
        Get
            Return ImportedBankOperation
        End Get
    End Property


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal nBankOperationID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        BankOperationID = nBankOperationID

    End Sub

    Public Sub New(ByVal nImportedBankOperation As BankOperationItem, _
        ByVal nImportedBankOperationAccount As HelperLists.CashAccountInfo)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ImportedBankOperation = nImportedBankOperation
        ImportedBankOperationAccount = nImportedBankOperationAccount
        If Not nImportedBankOperation Is Nothing AndAlso _
            nImportedBankOperation.OperationDatabaseID > 0 Then _
            BankOperationID = nImportedBankOperation.OperationDatabaseID

    End Sub


    Private Sub F_BankOperation_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList), _
            GetType(HelperLists.AccountInfoList), GetType(HelperLists.CashAccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_BankOperation_FormClosing(ByVal sender As Object, _
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

        GetDataGridViewLayOut(BookEntryItemsDataGridView)
        GetFormLayout(Me)

    End Sub

    Private Sub F_BankOperation_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If BankOperationID > 0 AndAlso Not Documents.BankOperation.CanGetObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        ElseIf Not BankOperationID > 0 AndAlso Not Documents.BankOperation.CanAddObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka naujam dokumentui įvesti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        If BankOperationID > 0 Then

            Try
                Obj = LoadObject(Of BankOperation)(Nothing, "GetBankOperation", _
                    True, BankOperationID)
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

        ElseIf Not ImportedBankOperation Is Nothing Then

            Try
                Obj = BankOperation.NewBankOperation(ImportedBankOperation, _
                    ImportedBankOperationAccount, False)
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

        Else

            Obj = BankOperation.NewBankOperation

        End If

        BankOperationBindingSource.DataSource = Obj

        SetDataGridViewLayOut(BookEntryItemsDataGridView)
        SetFormLayout(Me)

        If Not Obj.IsNew AndAlso Not Documents.BankOperation.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka duomenims redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            BookEntryItemsDataGridView.Enabled = True
            BookEntryItemsDataGridView.ReadOnly = True
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
        If Not Obj.IsNew AndAlso Not BankOperation.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka duomenims redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
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

        paramList.Add(Obj.Date, Obj.CurrencyCode)
        paramList.Add(Obj.Date, Obj.AccountCurrency)

        If paramList.Count < 1 Then Exit Sub

        If Not YesOrNo("Gauti valiutos kursą?") Then Exit Sub

        Using frm As New AccWebCrawler.F_LaunchWebCrawler(paramList, GetCurrentCompany.BaseCurrency)

            If frm.ShowDialog <> Windows.Forms.DialogResult.OK OrElse frm.result Is Nothing _
                OrElse Not TypeOf frm.result Is AccWebCrawler.CurrencyRateList _
                OrElse DirectCast(frm.result, AccWebCrawler.CurrencyRateList).Count < 1 Then Exit Sub

            If Not Obj.CurrencyRateIsReadOnly Then Obj.CurrencyRate = _
                DirectCast(frm.result, AccWebCrawler.CurrencyRateList). _
                GetCurrencyRate(Obj.Date, Obj.CurrencyCode)
            If Not Obj.CurrencyRateInAccountIsReadOnly Then Obj.CurrencyRateInAccount = _
                DirectCast(frm.result, AccWebCrawler.CurrencyRateList). _
                GetCurrencyRate(Obj.Date, Obj.AccountCurrency)

        End Using

    End Sub

    Private Sub IsTransferBetweenAccountsCheckBox_CheckedChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IsTransferBetweenAccountsCheckBox.CheckedChanged
        If Obj Is Nothing OrElse Loading Then Exit Sub
        Obj.IsTransferBetweenAccounts = IsTransferBetweenAccountsCheckBox.Checked
        ConfigureButtons()
    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click
        If Obj Is Nothing OrElse Not Obj.JournalEntryID > 0 Then Exit Sub
        MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, _
            Obj.JournalEntryID, Obj.JournalEntryID)
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

        Using bm As New BindingsManager(BankOperationBindingSource, _
            BookEntryItemsSortedBindingSource, Nothing, True, False)

            Try
                Obj = LoadObject(Of BankOperation)(Obj, "Save", False)
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        ConfigureButtons()

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        If Not ImportedBankOperation Is Nothing Then
            For Each frm As Form In MDIParent1.MdiChildren
                If TypeOf frm Is F_BankOperationItemList Then DirectCast(frm, _
                    F_BankOperationItemList).MarkAsExistingInDatabase(ImportedBankOperation, Obj.ID)
            Next
        End If

        Return True

    End Function

    Private Sub CancelObj()
        If Obj Is Nothing OrElse Obj.IsNew OrElse Not Obj.IsDirty Then Exit Sub
        Using bm As New BindingsManager(BankOperationBindingSource, _
            BookEntryItemsSortedBindingSource, Nothing, True, True)
        End Using
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.DocumentSerialInfoList), _
            GetType(HelperLists.PersonInfoList), GetType(HelperLists.AccountInfoList), _
            GetType(HelperLists.CashAccountInfoList)) Then Return False

        Try

            LoadCurrencyCodeListToComboBox(CurrencyCodeComboBox, False)

            LoadCashAccountInfoListToGridCombo(AccountAccGridComboBox, True)
            LoadCashAccountInfoListToGridCombo(CreditCashAccountAccGridComboBox, True)
            LoadPersonInfoListToGridCombo(PersonAccGridComboBox, True, True, True, True)
            LoadPersonInfoListToGridCombo(DataGridViewTextBoxColumn4, True, True, True, True)
            LoadAccountInfoListToGridCombo(AccountCurrencyRateChangeImpactAccGridComboBox, True, 5, 6)
            LoadAccountInfoListToGridCombo(AccountBankCurrencyConversionCostsAccGridComboBox, True, 6)
            LoadAccountInfoListToGridCombo(DataGridViewTextBoxColumn2, True, 2, 3, 4, 5, 6)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Private Sub ConfigureButtons()

        If Obj Is Nothing Then Exit Sub

        AccountAccGridComboBox.Enabled = Not Obj.AccountIsReadOnly
        PersonAccGridComboBox.Enabled = Not Obj.PersonIsReadOnly
        IsTransferBetweenAccountsCheckBox.Enabled = Not Obj.IsTransferBetweenAccountsIsReadOnly
        CreditCashAccountAccGridComboBox.Enabled = Not Obj.CreditCashAccountIsReadOnly
        UniqueCodeInCreditAccountTextBox.ReadOnly = Obj.UniqueCodeInCreditAccountIsReadOnly
        IsDebitRadioButton.Enabled = Not Obj.IsDebitIsReadOnly
        IsCreditRadioButton.Enabled = Not Obj.IsCreditIsReadOnly
        SumAccTextBox.ReadOnly = Obj.SumIsReadOnly
        CurrencyCodeComboBox.Enabled = Not Obj.CurrencyCodeIsReadOnly
        CurrencyRateAccTextBox.ReadOnly = Obj.CurrencyRateIsReadOnly
        CurrencyRateChangeImpactAccTextBox.ReadOnly = Obj.CurrencyRateChangeImpactIsReadOnly
        AccountCurrencyRateChangeImpactAccGridComboBox.Enabled = Not Obj.AccountCurrencyRateChangeImpactIsReadOnly
        CurrencyRateInAccountAccTextBox.ReadOnly = Obj.CurrencyRateInAccountIsReadOnly
        BankCurrencyConversionCostsAccTextBox.ReadOnly = Obj.BankCurrencyConversionCostsIsReadOnly
        AccountBankCurrencyConversionCostsAccGridComboBox.Enabled = Not Obj.AccountBankCurrencyConversionCostsIsReadOnly

        GetCurrencyRatesButton.Enabled = Not Obj.CurrencyRateIsReadOnly OrElse Not Obj.CurrencyRateInAccountIsReadOnly

        BookEntryItemsDataGridView.AllowUserToAddRows = Not Obj.BookEntryItemsIsReadOnly
        BookEntryItemsDataGridView.AllowUserToDeleteRows = Not Obj.BookEntryItemsIsReadOnly
        BookEntryItemsDataGridView.ReadOnly = Obj.BookEntryItemsIsReadOnly

        LimitationsButton.Visible = Not String.IsNullOrEmpty(Obj.ChronologicValidator.LimitsExplanation.Trim)

    End Sub

End Class