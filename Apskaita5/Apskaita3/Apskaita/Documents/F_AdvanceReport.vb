Imports ApskaitaObjects.Documents
Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.ActiveReports
Public Class F_AdvanceReport
    Implements ISupportsPrinting, IObjectEditForm

    Private Obj As AdvanceReport
    Private AdvanceReportID As Integer = -1
    Private Loading As Boolean = True


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If Not Obj Is Nothing Then Return Obj.ID
            Return 0
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(AdvanceReport)
        End Get
    End Property


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal nAdvanceReportID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        AdvanceReportID = nAdvanceReportID

    End Sub


    Private Sub F_AdvanceReport_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList), _
            GetType(HelperLists.AccountInfoList), _
            GetType(Settings.CommonSettings)) Then Exit Sub

    End Sub

    Private Sub F_AdvanceReport_FormClosing(ByVal sender As Object, _
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
        GetDataGridViewLayOut(ReportItemsDataGridView)

    End Sub

    Private Sub F_AdvanceReport_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If AdvanceReportID > 0 AndAlso Not Documents.AdvanceReport.CanGetObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        ElseIf Not AdvanceReportID > 0 AndAlso Not Documents.AdvanceReport.CanAddObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka naujam dokumentui įvesti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        If AdvanceReportID > 0 Then

            Try
                Obj = LoadObject(Of AdvanceReport)(Nothing, "GetAdvanceReport", _
                    True, AdvanceReportID)
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

        Else

            Obj = AdvanceReport.NewAdvanceReport

        End If

        Obj.BeginEdit()

        AdvanceReportBindingSource.DataSource = Obj

        AddDGVColumnSelector(ReportItemsDataGridView)

        SetFormLayout(Me)
        SetDataGridViewLayOut(ReportItemsDataGridView)

        If Not Obj.IsNew AndAlso Not Documents.AdvanceReport.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka duomenims redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            ReportItemsDataGridView.Enabled = True
            ReportItemsDataGridView.ReadOnly = True
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
        If Not Obj.IsNew AndAlso Not AdvanceReport.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka duomenims redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            ReportItemsDataGridView.Enabled = True
            ReportItemsDataGridView.ReadOnly = True
            Exit Sub
        End If
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ICancelButton.Click
        CancelObj()
    End Sub


    Private Sub RefreshInvoiceInfoListButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshInvoiceInfoListButton.Click

        Dim InvoiceInfoList As ActiveReports.InvoiceInfoItemList

        Try
            Dim ntype As ActiveReports.InvoiceInfoType = InvoiceInfoType.InvoiceReceived
            If InvoicesMadeCheckBox.Checked Then ntype = InvoiceInfoType.InvoiceMade
            InvoiceInfoList = LoadObject(Of ActiveReports.InvoiceInfoItemList)(Nothing, "GetList", _
                True, ntype, DateFromDateTimePicker.Value.Date, DateToDateTimePicker.Value.Date, _
                LoadObjectFromCombo(Of PersonInfo)(PersonInfoAccGridComboBox, "ID"))
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        InvoiceInfoListComboBox.DataSource = InvoiceInfoList

    End Sub

    Private Sub AddAdvanceReportItemButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AddAdvanceReportItemButton.Click

        Dim selectedInvoice As InvoiceInfoItem = Nothing
        Try
            selectedInvoice = DirectCast(InvoiceInfoListComboBox.SelectedItem, InvoiceInfoItem)
        Catch ex As Exception
        End Try
        If selectedInvoice Is Nothing OrElse Not selectedInvoice.ID > 0 Then Exit Sub

        Dim invoiceClient As PersonInfo = PersonInfoList.GetList.GetPersonInfo(selectedInvoice.PersonID)
        If invoiceClient Is Nothing Then
            MsgBox("Nepavyko nustatyti sąskaitos faktūros kontrahento.", MsgBoxStyle.Critical, "Klaida")
            Exit Sub
        End If

        Try
            Obj.AddAdvanceReportItemWithInvoice(selectedInvoice, invoiceClient)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

    End Sub

    Private Sub GetCurrencyRatesButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles GetCurrencyRatesButton.Click

        If Obj Is Nothing OrElse Obj.CurrencyCode Is Nothing _
            OrElse String.IsNullOrEmpty(Obj.CurrencyCode.Trim) _
            OrElse Obj.CurrencyCode.Trim.ToUpper = GetCurrentCompany.BaseCurrency Then Exit Sub

        If Not YesOrNo("Gauti valiutos kursą?") Then Exit Sub

        Dim result As AccWebCrawler.CurrencyRateList = _
            FetchCurrencyRate(Obj.CurrencyCode.Trim.ToUpper, Obj.Date)
        If Not result Is Nothing Then Obj.CurrencyRate = _
            result.GetCurrencyRate(Obj.Date, Obj.CurrencyCode.Trim.ToUpper)

    End Sub

    Private Sub LimitationsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LimitationsButton.Click
        If Obj Is Nothing OrElse String.IsNullOrEmpty(Obj.ChronologicValidator.LimitsExplanation.Trim) Then Exit Sub
        MsgBox(Obj.ChronologicValidator.LimitsExplanation & vbCrLf & vbCrLf & _
            Obj.ChronologicValidator.BackgroundExplanation, MsgBoxStyle.Information, "")
    End Sub

    Private Sub ReportItemsDataGridView_CellBeginEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) _
        Handles ReportItemsDataGridView.CellBeginEdit

        If Obj Is Nothing OrElse e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Dim selectedItem As AdvanceReportItem = Nothing
        Try
            selectedItem = DirectCast(ReportItemsDataGridView.Rows(e.RowIndex).DataBoundItem, AdvanceReportItem)
        Catch ex As Exception
        End Try
        If selectedItem Is Nothing Then Exit Sub

        If (ReportItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn1 _
            AndAlso selectedItem.IncomeIsReadOnly) OrElse _
            (ReportItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn2 _
            AndAlso selectedItem.ExpensesIsReadOnly) OrElse _
            (ReportItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn6 _
            AndAlso selectedItem.AccountIsReadOnly) OrElse _
            (ReportItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn7 _
            AndAlso selectedItem.AccountVatIsReadOnly) OrElse _
            (ReportItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn8 _
            AndAlso selectedItem.SumIsReadOnly) OrElse _
            (ReportItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn9 _
            AndAlso selectedItem.VatRateIsReadOnly) OrElse _
            (ReportItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn11 _
            AndAlso selectedItem.SumVatCorrectionIsReadOnly) OrElse _
            (ReportItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn14 _
            AndAlso selectedItem.SumCorrectionLTLIsReadOnly) OrElse _
            (ReportItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn16 _
            AndAlso selectedItem.SumVatCorrectionLTLIsReadOnly) OrElse _
            (ReportItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn4 _
            AndAlso selectedItem.PersonIsReadOnly) OrElse _
            (ReportItemsDataGridView.Columns(e.ColumnIndex) Is CurrencyRateChangeEffect _
            AndAlso selectedItem.CurrencyRateChangeEffectIsReadOnly) OrElse _
            (ReportItemsDataGridView.Columns(e.ColumnIndex) Is AccountCurrencyRateChangeEffectDataGridViewColumn _
            AndAlso selectedItem.AccountCurrencyRateChangeEffectIsReadOnly) Then
            e.Cancel = True
        End If

    End Sub

    Private Sub ReportItemsDataGridView_CellDoubleClick(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ReportItemsDataGridView.CellDoubleClick

        If Obj Is Nothing OrElse e.RowIndex < 0 OrElse e.ColumnIndex < 0 OrElse _
            Not ReportItemsDataGridView.Columns(e.ColumnIndex).ReadOnly Then Exit Sub

        Dim selectedItem As AdvanceReportItem = Nothing
        Try
            selectedItem = DirectCast(ReportItemsDataGridView.Rows(e.RowIndex).DataBoundItem, AdvanceReportItem)
        Catch ex As Exception
        End Try
        If selectedItem Is Nothing Then Exit Sub

        If selectedItem.InvoiceID > 0 Then
            If selectedItem.InvoiceIsMade Then
                MDIParent1.LaunchForm(GetType(F_InvoiceMade), False, False, _
                    selectedItem.InvoiceID, selectedItem.InvoiceID)
            Else
                MDIParent1.LaunchForm(GetType(F_InvoiceReceived), False, False, _
                    selectedItem.InvoiceID, selectedItem.InvoiceID)
            End If
        End If

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
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.BrokenRulesCollection.ToString( _
                Csla.Validation.RuleSeverity.Error), MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        If Obj.BrokenRulesCollection.WarningCount > 0 Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf _
                & Obj.BrokenRulesCollection.ToString(Csla.Validation.RuleSeverity.Warning) & vbCrLf
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

        Using bm As New BindingsManager(AdvanceReportBindingSource, _
            ReportItemsSortedBindingSource, Nothing, True, False)

            Obj.ApplyEdit()

            Try
                Obj = LoadObject(Of AdvanceReport)(Obj, "Save", False)
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try

            Obj.BeginEdit()

            bm.SetNewDataSource(Obj)

        End Using

        ConfigureButtons()

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj()
        If Obj Is Nothing OrElse Obj.IsNew OrElse Not Obj.IsDirty Then Exit Sub
        Using bm As New BindingsManager(AdvanceReportBindingSource, _
            ReportItemsSortedBindingSource, Nothing, True, True)
        End Using
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList), _
            GetType(HelperLists.AccountInfoList), _
            GetType(Settings.CommonSettings)) Then Return False

        Try

            LoadCurrencyCodeListToComboBox(CurrencyCodeComboBox, True)

            LoadPersonInfoListToGridCombo(PersonAccGridComboBox, True, False, False, True)
            LoadPersonInfoListToGridCombo(DataGridViewTextBoxColumn4, True, True, True, False)
            LoadPersonInfoListToGridCombo(PersonInfoAccGridComboBox, True, True, True, False)

            LoadTaxRateListToCombo(DataGridViewTextBoxColumn9, TaxTarifType.Vat)

            LoadAccountInfoListToGridCombo(AccountAccGridComboBox, True, 2, 4)
            LoadAccountInfoListToGridCombo(DataGridViewTextBoxColumn6, True)
            LoadAccountInfoListToGridCombo(DataGridViewTextBoxColumn7, True, 2, 4, 6)
            LoadAccountInfoListToGridCombo(AccountCurrencyRateChangeEffectDataGridViewColumn, True, 5, 6)


        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Private Sub ConfigureButtons()

        If Obj Is Nothing Then Exit Sub

        AccountAccGridComboBox.Enabled = Obj.ChronologicValidator.FinancialDataCanChange
        CurrencyCodeComboBox.Enabled = Obj.ChronologicValidator.FinancialDataCanChange
        CurrencyRateAccTextBox.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        GetCurrencyRatesButton.Enabled = Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewCheckBoxColumn1.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewCheckBoxColumn2.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewTextBoxColumn6.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewTextBoxColumn7.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewTextBoxColumn8.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewTextBoxColumn9.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewTextBoxColumn11.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewTextBoxColumn14.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        DataGridViewTextBoxColumn16.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        CurrencyRateChangeEffect.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange
        AccountCurrencyRateChangeEffectDataGridViewColumn.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange

        ReportItemsDataGridView.AllowUserToAddRows = Obj.ChronologicValidator.FinancialDataCanChange
        ReportItemsDataGridView.AllowUserToDeleteRows = Obj.ChronologicValidator.FinancialDataCanChange

        RefreshInvoiceInfoListButton.Enabled = Obj.ChronologicValidator.FinancialDataCanChange
        AddAdvanceReportItemButton.Enabled = Obj.ChronologicValidator.FinancialDataCanChange
        DateFromDateTimePicker.Enabled = Obj.ChronologicValidator.FinancialDataCanChange
        DateToDateTimePicker.Enabled = Obj.ChronologicValidator.FinancialDataCanChange
        PersonInfoAccGridComboBox.Enabled = Obj.ChronologicValidator.FinancialDataCanChange
        InvoiceInfoListComboBox.Enabled = Obj.ChronologicValidator.FinancialDataCanChange
        InvoicesMadeCheckBox.Enabled = Obj.ChronologicValidator.FinancialDataCanChange

        LimitationsButton.Visible = (Not String.IsNullOrEmpty(Obj.ChronologicValidator.LimitsExplanation.Trim))

    End Sub



    Private Sub ReportItemsDataGridView_DataError(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles ReportItemsDataGridView.DataError
        e.Cancel = True
        e.ThrowException = False
    End Sub

End Class