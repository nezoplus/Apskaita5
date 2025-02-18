﻿Imports ApskaitaObjects.Documents
Imports ApskaitaObjects.Settings
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.Printing
Imports AccDataBindingsWinForms.CachedInfoLists
Imports AccControlsWinForms.WebControls

Friend Class F_TillIncomeOrder
    Implements ISupportsPrinting, IObjectEditForm, ISupportsChronologicValidator

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.DocumentSerialInfoList), GetType(HelperLists.PersonInfoList), _
        GetType(HelperLists.AccountInfoList), GetType(HelperLists.CashAccountInfoList)}

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of TillIncomeOrder)
    Private _ListViewManager As DataListViewEditControlManager(Of General.BookEntry)
    Private _QueryManager As CslaActionExtenderQueryObject

    Private _DocumentToEdit As TillIncomeOrder = Nothing


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If _FormManager Is Nothing OrElse _FormManager.DataSource Is Nothing Then
                If _DocumentToEdit Is Nothing OrElse _DocumentToEdit.IsNew Then
                    Return Integer.MinValue
                Else
                    Return _DocumentToEdit.ID
                End If
            End If
            Return _FormManager.DataSource.ID
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(TillIncomeOrder)
        End Get
    End Property


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal documentToEdit As TillIncomeOrder)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _DocumentToEdit = documentToEdit

    End Sub


    Private Sub F_TillIncomeOrder_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        If _DocumentToEdit Is Nothing Then
            _DocumentToEdit = TillIncomeOrder.NewTillIncomeOrder()
        End If

        Try

            _FormManager = New CslaActionExtenderEditForm(Of TillIncomeOrder) _
                (Me, TillIncomeOrderBindingSource, _DocumentToEdit, _
                _RequiredCachedLists, IOkButton, IApplyButton, ICancelButton, _
                Nothing, ProgressFiller1)

            _FormManager.ManageDataListViewStates(BookEntryItemsDataListView)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        ConfigureButtons()

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            _ListViewManager = New DataListViewEditControlManager(Of General.BookEntry) _
                (BookEntryItemsDataListView, Nothing, AddressOf OnItemsDelete, _
                 AddressOf OnItemAdd, Nothing, _DocumentToEdit)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            SetupDefaultControls(Of TillIncomeOrder)(Me, _
                TillIncomeOrderBindingSource, _DocumentToEdit)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function


    Private Sub OnItemsDelete(ByVal items As General.BookEntry())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Keisti dokumento finansinių duomenų negalima, įskaitant kontavimų pridėjimą ar ištrynimą:{0}{1}", vbCrLf, _
                _FormManager.DataSource.ChronologicValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        If _FormManager.DataSource.BookEntryItemsIsReadOnly Then Exit Sub
        For Each item As General.BookEntry In items
            _FormManager.DataSource.BookEntryItems.Remove(item)
        Next
    End Sub

    Private Sub OnItemAdd()
        If _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Keisti dokumento finansinių duomenų negalima, įskaitant kontavimų pridėjimą ar ištrynimą:{0}{1}", vbCrLf, _
                _FormManager.DataSource.ChronologicValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        If _FormManager.DataSource.BookEntryItemsIsReadOnly Then Exit Sub
        _FormManager.DataSource.BookEntryItems.AddNew()
    End Sub

    Private Sub AddJournalEntryInfoButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AddAdvanceReportInfoButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Using dlg As New F_AdvanceReportInfoList(_FormManager.DataSource.Date.AddMonths(-1), _
            _FormManager.DataSource.Date, True)

            If dlg.ShowDialog() <> DialogResult.OK OrElse dlg.SelectedEntries Is Nothing _
                OrElse dlg.SelectedEntries.Count < 1 Then Exit Sub

            Try
                _FormManager.DataSource.LoadAdvanceReport(dlg.SelectedEntries(0), _
                    HelperLists.PersonInfoList.GetList())
            Catch ex As Exception
                ShowError(ex, New Object() {_FormManager.DataSource, dlg.SelectedEntries})
                Exit Sub
            End Try

        End Using

    End Sub

    Private Sub RemoveJournalEntryInfoButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RemoveAdvanceReportInfoButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Try
            _FormManager.DataSource.ClearAdvanceReport()
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
            Exit Sub
        End Try

    End Sub

    Private Sub GetCurrencyRatesButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles GetCurrencyRatesButton.Click

        If _FormManager.DataSource Is Nothing OrElse IsBaseCurrency(_FormManager.DataSource.AccountCurrency, _
            GetCurrentCompany.BaseCurrency) Then Exit Sub

        If Not YesOrNo("Gauti valiutos kursą?") Then Exit Sub

        Dim factory As CurrencyRateFactoryBase = Nothing
        Dim result As CurrencyRate = Nothing
        Try
            factory = WebControls.GetCurrencyRateFactory(GetCurrentCompany.BaseCurrency)
            result = WebControls.GetCurrencyRateWithProgress(_FormManager.DataSource.AccountCurrency.Trim.ToUpper, _
                _FormManager.DataSource.Date, factory)
        Catch ex As Exception
            ShowError(ex, Nothing)
            Exit Sub
        End Try

        If Not result Is Nothing Then
            _FormManager.DataSource.CurrencyRateInAccount = result.Rate
        End If

    End Sub

    Private Sub RefreshNumberButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshNumberButton.Click

        If _FormManager.DataSource Is Nothing OrElse StringIsNullOrEmpty(_FormManager.DataSource.DocumentSerial) Then Exit Sub

        If Not _FormManager.DataSource.IsNew Then
            If Not YesOrNo("DĖMESIO. Jūs redaguojate jau įtrauktą į duomenų bazę dokumentą. " _
                & "Ar tikrai norite suteikti jam naują numerį?") Then Exit Sub
        End If

        FetchOrderNumber()

    End Sub

    Private Sub FetchOrderNumber()
        'CommandLastDocumentNumber.TheCommand(DocumentSerialType.TillIncomeOrder, _
        '    _FormManager.DataSource.DocumentSerial.Trim, _FormManager.DataSource.Date, _
        '    _FormManager.DataSource.AddDateToNumberOptionWasUsed)
        _QueryManager.InvokeQuery(Of CommandLastDocumentNumber)(Nothing, "TheCommand", True, _
            AddressOf OnOrderNumberFetched, DocumentSerialType.TillIncomeOrder, _
            _FormManager.DataSource.DocumentSerial.Trim, _FormManager.DataSource.Date, _
            _FormManager.DataSource.AddDateToNumberOptionWasUsed)
    End Sub

    Private Sub OnOrderNumberFetched(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If result Is Nothing Then Exit Sub

        _FormManager.DataSource.DocumentNumber = DirectCast(result, Integer) + 1

    End Sub

    Private Sub DateDateTimePicker_CloseUp(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles DateAccDatePicker.OnValueChanged

        If _FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.IsNew OrElse _
            Not MyCustomSettings.AutoReloadData OrElse Not _FormManager.DataSource.AddDateToNumberOptionWasUsed _
            OrElse StringIsNullOrEmpty(_FormManager.DataSource.DocumentSerial) Then Exit Sub

        _FormManager.DataSource.Date = DateAccDatePicker.Value

        FetchOrderNumber()

    End Sub

    Private Sub DocumentSerialComboBox_DropDownClosed(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles DocumentSerialComboBox.DropDownClosed

        If _FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.IsNew OrElse _
            Not MyCustomSettings.AutoReloadData Then Exit Sub

        If DocumentSerialComboBox.SelectedItem Is Nothing OrElse _
            StringIsNullOrEmpty(DocumentSerialComboBox.SelectedItem.ToString) Then
            Exit Sub
        Else
            _FormManager.DataSource.DocumentSerial = DocumentSerialComboBox.SelectedItem.ToString.Trim
        End If

        FetchOrderNumber()

    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click
        If _FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.IsNew Then Exit Sub
        OpenJournalEntryEditForm(_QueryManager, _FormManager.DataSource.ID)
    End Sub

    Private Sub OpenAdvanceReportButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OpenAdvanceReportButton.Click
        If _FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.AdvanceReportID > 0 Then Exit Sub
        'AdvanceReport.GetAdvanceReport(_FormManager.DataSource.AdvanceReportID)
        _QueryManager.InvokeQuery(Of AdvanceReport)(Nothing, "GetAdvanceReport", True, _
            AddressOf OpenObjectEditForm, _FormManager.DataSource.AdvanceReportID)
    End Sub

    Private Sub AccountAccGridComboBox_SelectedIndexChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AccountAccGridComboBox.Validated
        ConfigureButtons()
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
        If _FormManager.DataSource Is Nothing Then Exit Sub

        Using frm As New F_SendObjToEmail(_FormManager.DataSource, 0)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, False, 0, "KPO", Me, "")
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, True, 0, "KPO", Me, "")
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function


    Public Function ChronologicContent() As String _
        Implements ISupportsChronologicValidator.ChronologicContent
        If _FormManager.DataSource Is Nothing Then Return ""
        Return _FormManager.DataSource.ChronologicValidator.LimitsExplanation
    End Function

    Public Function HasChronologicContent() As Boolean _
        Implements ISupportsChronologicValidator.HasChronologicContent

        Return Not _FormManager.DataSource Is Nothing AndAlso _
            Not StringIsNullOrEmpty(_FormManager.DataSource.ChronologicValidator.LimitsExplanation)

    End Function


    Private Sub _FormManager_DataSourceStateHasChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles _FormManager.DataSourceStateHasChanged
        ConfigureButtons()
    End Sub

    Private Sub ConfigureButtons()

        If _FormManager.DataSource Is Nothing Then Exit Sub

        AccountAccGridComboBox.Enabled = Not _FormManager.DataSource.AccountIsReadOnly
        SumAccTextBox.ReadOnly = _FormManager.DataSource.SumIsReadOnly
        CurrencyRateInAccountAccTextBox.ReadOnly = _FormManager.DataSource.CurrencyRateInAccountIsReadOnly
        AccountCurrencyRateChangeImpactAccGridComboBox.Enabled = Not _FormManager.DataSource.AccountCurrencyRateChangeImpactIsReadOnly
        CurrencyRateChangeImpactAccTextBox.ReadOnly = _FormManager.DataSource.CurrencyRateChangeImpactIsReadOnly
        GetCurrencyRatesButton.Enabled = Not _FormManager.DataSource.CurrencyRateInAccountIsReadOnly
        _ListViewManager.IsReadOnly = _FormManager.DataSource.BookEntryItemsIsReadOnly

    End Sub

End Class