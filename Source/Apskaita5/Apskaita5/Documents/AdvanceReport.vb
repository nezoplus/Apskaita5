﻿Imports ApskaitaObjects.Attributes
Imports ApskaitaObjects.My.Resources

Namespace Documents

    ''' <summary>
    ''' Represents an advance report document.
    ''' Is used when the accountable person needs to report money spent or received on behalf of the company.
    ''' </summary>
    ''' <remarks>Encapsulates a <see cref="General.JournalEntry">JournalEntry</see> of type <see cref="DocumentType.AdvanceReport">DocumentType.AdvanceReport</see>.
    ''' Values are stored in the database table advancereports.</remarks>
    <Serializable()> _
    Public NotInheritable Class AdvanceReport
        Inherits BusinessBase(Of AdvanceReport)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _ChronologicValidator As SimpleChronologicValidator
        Private _Date As Date = Today
        Private _DocumentNumber As String = ""
        Private _Content As String = ""
        Private _Person As PersonInfo = Nothing
        Private _Account As Long = 0
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency
        Private _CurrencyRate As Double = 1
        Private _Comments As String = ""
        Private _CommentsInternal As String = ""
        Private _Sum As Double = 0
        Private _SumVat As Double = 0
        Private _SumTotal As Double = 0
        Private _SumLTL As Double = 0
        Private _SumVatLTL As Double = 0
        Private _SumTotalLTL As Double = 0
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private _FetchWarnings As String = ""
        Private WithEvents _ReportItems As AdvanceReportItemList


        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _ReportItemsSortedList As Csla.SortedBindingList(Of AdvanceReportItem) = Nothing


        ''' <summary>
        ''' Gets <see cref="General.JournalEntry.ID">an ID of the journal entry</see> that is created by the advance report.
        ''' </summary>
        ''' <remarks>Value is stored in the database table advancereports.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="IChronologicValidator">IChronologicValidator</see> object that contains business restraints on updating the sheet.
        ''' </summary>
        ''' <remarks>A <see cref="SimpleChronologicValidator">SimpleChronologicValidator</see> is used to validate an advance report chronological business rules.</remarks>
        Public ReadOnly Property ChronologicValidator() As SimpleChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChronologicValidator
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the advance report was inserted into the database.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.InsertDate">journal entry InsertDate property</see>.</remarks>
        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the advance report was last updated.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.UpdateDate">journal entry UpdateDate property</see>.</remarks>
        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets warnings generated on data fetch (information about data discrepancies in a database).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property FetchWarnings() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FetchWarnings
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the date of the advance report.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.Date">journal entry Date property</see>.</remarks>
        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                CanWriteProperty(True)
                If _Date.Date <> value.Date Then
                    _Date = value.Date
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the number of the advance report.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.DocNumber">journal entry DocNumber property</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 30)> _
        Public Property DocumentNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _DocumentNumber.Trim <> value.Trim Then
                    _DocumentNumber = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the content (description) of the advance report.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.Content">journal entry Content property</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Content.Trim <> value.Trim Then
                    _Content = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the accountable person of the advance report.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.Person">journal entry Person property</see>.</remarks>
        <PersonFieldAttribute(ValueRequiredLevel.Mandatory, False, False, True, True)> _
        Public Property Person() As PersonInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Person
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As PersonInfo)
                CanWriteProperty(True)
                If Not (_Person Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Person Is Nothing AndAlso Not value Is Nothing AndAlso _Person = value) Then
                    _Person = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an <see cref="General.Account.ID">account</see> for the accountable person.
        ''' </summary>
        ''' <remarks>Value is stored in the database table advancereports.Account.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, True, 2, 4)> _
        Public Property Account() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If Not _ChronologicValidator.FinancialDataCanChange Then Exit Property
                If _Account <> value Then
                    _Account = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a currency of the advance report.
        ''' </summary>
        ''' <remarks>Value is stored in the database table advancereports.CurrencyCode.</remarks>
        <CurrencyFieldAttribute(ValueRequiredLevel.Mandatory)> _
        Public Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)

                CanWriteProperty(True)
                If value Is Nothing Then value = ""

                If Not _ChronologicValidator.FinancialDataCanChange Then Exit Property

                If Not CurrenciesEquals(_CurrencyCode, value, GetCurrentCompany.BaseCurrency) Then

                    _CurrencyCode = value.Trim
                    PropertyHasChanged()

                    Dim modifiedCurrencyRate As Double = 0.0
                    If IsBaseCurrency(_CurrencyCode, GetCurrentCompany().BaseCurrency) Then
                        modifiedCurrencyRate = 1.0
                    End If
                    If CRound(_CurrencyRate, ROUNDCURRENCYRATE) <> CRound(modifiedCurrencyRate, ROUNDCURRENCYRATE) Then
                        _CurrencyRate = modifiedCurrencyRate
                        PropertyHasChanged("CurrencyRate")
                    End If

                    _ReportItems.UpdateCurrency(_CurrencyCode, _CurrencyRate)

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a currency rate of the advance report.
        ''' </summary>
        ''' <remarks>Value is stored in the database table advancereports.CurrencyRate.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDCURRENCYRATE)> _
        Public Property CurrencyRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRate, ROUNDCURRENCYRATE)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _ChronologicValidator.FinancialDataCanChange Then Exit Property
                If CRound(_CurrencyRate, ROUNDCURRENCYRATE) <> CRound(value, ROUNDCURRENCYRATE) Then
                    _CurrencyRate = CRound(value, ROUNDCURRENCYRATE)
                    PropertyHasChanged()
                    _ReportItems.UpdateCurrency(_CurrencyCode, _CurrencyRate)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a user comments for the advance report that are shown in the document.
        ''' </summary>
        ''' <remarks>Value is stored in the database table advancereports.Comments.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property Comments() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Comments.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Comments.Trim <> value.Trim Then
                    _Comments = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a user comments for the advance report that are only ment for the accountant.
        ''' </summary>
        ''' <remarks>Value is stored in the database table advancereports.CommentsInternal.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property CommentsInternal() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CommentsInternal.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CommentsInternal.Trim <> value.Trim Then
                    _CommentsInternal = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the total sum (excluding VAT) of all the items in the advance report in the advance report currency.
        ''' </summary>
        ''' <remarks>Money spent by the accountable person are considered as positive number.
        ''' Money received by the accountable person are considered as negative number.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total VAT sum of all the items in the advance report in the advance report currency.
        ''' </summary>
        ''' <remarks>Money spent by the accountable person are considered as positive number.
        ''' Money received by the accountable person are considered as negative number.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumVat() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVat)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total sum (including VAT) of all the items in the advance report in the advance report currency.
        ''' </summary>
        ''' <remarks>Money spent by the accountable person are considered as positive number.
        ''' Money received by the accountable person are considered as negative number.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotal)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total sum (excluding VAT) of all the items in the advance report in the company base currency.
        ''' </summary>
        ''' <remarks>Money spent by the accountable person are considered as positive number.
        ''' Money received by the accountable person are considered as negative number.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total VAT sum of all the items in the advance report in the company base currency.
        ''' </summary>
        ''' <remarks>Money spent by the accountable person are considered as positive number.
        ''' Money received by the accountable person are considered as negative number.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumVatLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVatLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total sum (including VAT) of all the items in the advance report in the company base currency.
        ''' </summary>
        ''' <remarks>Money spent by the accountable person are considered as positive number.
        ''' Money received by the accountable person are considered as negative number.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumTotalLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotalLTL)
            End Get
        End Property


        ''' <summary>
        ''' Gets the advance report items: documents confirming that the accountable person has spent or received money on behalf of the company.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ReportItems() As AdvanceReportItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ReportItems
            End Get
        End Property

        ''' <summary>
        ''' Gets the sortable view of the advance report items: documents confirming that the accountable person has spent or received money on behalf of the company.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in a datagridview.</remarks>
        Public ReadOnly Property ReportItemsSorted() As Csla.SortedBindingList(Of AdvanceReportItem)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _ReportItemsSortedList Is Nothing Then _ReportItemsSortedList = _
                    New Csla.SortedBindingList(Of AdvanceReportItem)(_ReportItems)
                Return _ReportItemsSortedList
            End Get
        End Property


        ''' <summary>
        ''' Returnes TRUE if the object is new and contains some user provided data 
        ''' OR
        ''' object is not new and was changed by the user.
        ''' </summary>
        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_DocumentNumber.Trim) _
                    OrElse Not String.IsNullOrEmpty(_Content.Trim) _
                    OrElse _ReportItems.Count > 0)
            End Get
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _ReportItems.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid AndAlso _ReportItems.IsValid
            End Get
        End Property


        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error), False)
            If Not _ReportItems.IsValid Then result = AddWithNewLine(result, _
                _ReportItems.GetAllBrokenRules, False)
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If Not MyBase.BrokenRulesCollection.WarningCount > 0 Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning), False)
            If _ReportItems.HasWarnings Then result = AddWithNewLine(result, _ReportItems.GetAllWarnings, False)
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return (MyBase.BrokenRulesCollection.WarningCount > 0 OrElse _ReportItems.HasWarnings())
        End Function


        Public Overrides Function Save() As AdvanceReport

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Return MyBase.Save

        End Function


        ''' <summary>
        ''' Gets a book entry list of the requested <see cref="BookEntryType">type</see> 
        ''' that is created by the advance report.
        ''' </summary>
        ''' <param name="bookEntryListType">Type of the book entry list to get.</param>
        ''' <remarks></remarks>
        Public Function GetBookEntryList(ByVal bookEntryListType As BookEntryType) As General.BookEntryList
            Dim result As General.BookEntryList = General.BookEntryList.NewBookEntryList(bookEntryListType)
            Dim fullBookEntryList As BookEntryInternalList = _ReportItems.GetFullBookEntryList(_Account)
            result.LoadBookEntryListFromInternalList(fullBookEntryList, False, False)
            Return result
        End Function

        ''' <summary>
        ''' Adds a new AdvanceReportItem instance with an invoice attached.
        ''' </summary>
        ''' <param name="invoiceToAdd">Invoice data.</param>
        ''' <param name="invoicePersonInfo">PersonInfo value object for the invoice 
        ''' (ActiveReports.InvoiceInfoItem does not contain such an object).</param>
        ''' <remarks></remarks>
        Public Sub AddAdvanceReportItemWithInvoice(ByVal invoiceToAdd As ActiveReports.InvoiceInfoItem, _
            ByVal invoicePersonInfo As PersonInfo)

            If Not _ChronologicValidator.FinancialDataCanChange Then Throw New Exception( _
                String.Format(My.Resources.Common_CannotUpdateFinancialData, vbCrLf, _
                _ChronologicValidator.FinancialDataCanChangeExplanation))

            Dim newItem As AdvanceReportItem = AdvanceReportItem.NewAdvanceReportItem( _
                invoiceToAdd, invoicePersonInfo, _CurrencyCode, _CurrencyRate)
            _ReportItems.Add(newItem)

        End Sub

        ''' <summary>
        ''' Adds new AdvanceReportItem instances with the invoices attached.
        ''' </summary>
        ''' <param name="invoicesToAdd">invoices to add new items for</param>
        ''' <remarks></remarks>
        Public Sub AddAdvanceReportItemWithInvoices(ByVal invoicesToAdd As List(Of ActiveReports.InvoiceInfoItem))

            If Not _ChronologicValidator.FinancialDataCanChange Then Throw New Exception( _
                String.Format(My.Resources.Common_CannotUpdateFinancialData, vbCrLf, _
                _ChronologicValidator.FinancialDataCanChangeExplanation))

            If invoicesToAdd Is Nothing OrElse invoicesToAdd.Count < 1 Then
                Throw New Exception(Documents_AdvanceReport_InvoiceListNull)
            End If

            For Each info As ActiveReports.InvoiceInfoItem In invoicesToAdd
                If info.Type <> ActiveReports.InvoiceInfoType.InvoiceMade AndAlso _
                    info.Type <> ActiveReports.InvoiceInfoType.InvoiceReceived Then
                    Throw New Exception(String.Format(Documents_AdvanceReport_InvalidInvoiceType, _
                        ConvertLocalizedName(info.Type), info.ToString()))
                End If
            Next

            _ReportItems.AddNewRange(invoicesToAdd)

        End Sub


        Private Sub ReportItems_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _ReportItems.ListChanged
            CalculateSubTotals(True)
        End Sub

        Private Sub CalculateSubTotals(ByVal raisePropertChangedEvents As Boolean)

            _SumLTL = 0
            _SumVatLTL = 0
            _Sum = 0
            _SumVat = 0

            For Each i As AdvanceReportItem In _ReportItems
                If i.Expenses Then
                    _SumLTL = CRound(_SumLTL + i.SumLTL)
                    _SumVatLTL = CRound(_SumVatLTL + i.SumVatLTL)
                    _Sum = CRound(_Sum + i.Sum)
                    _SumVat = CRound(_SumVat + i.SumVat)
                Else
                    _SumLTL = CRound(_SumLTL - i.SumLTL)
                    _SumVatLTL = CRound(_SumVatLTL - i.SumVatLTL)
                    _Sum = CRound(_Sum - i.Sum)
                    _SumVat = CRound(_SumVat - i.SumVat)
                End If
            Next

            _SumTotalLTL = CRound(_SumLTL + _SumVatLTL)
            _SumTotal = CRound(_Sum + _SumVat)

            If raisePropertChangedEvents Then
                PropertyHasChanged("SumLTL")
                PropertyHasChanged("SumVatLTL")
                PropertyHasChanged("Sum")
                PropertyHasChanged("SumVat")
                PropertyHasChanged("SumTotalLTL")
                PropertyHasChanged("SumTotal")
            End If

        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As AdvanceReport = DirectCast(MyBase.GetClone(), AdvanceReport)
            result.RestoreChildListsHandles()
            Return result
        End Function

        Protected Overrides Sub OnDeserialized(ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            RestoreChildListsHandles()
        End Sub

        Protected Overrides Sub UndoChangesComplete()
            MyBase.UndoChangesComplete()
            RestoreChildListsHandles()
        End Sub

        ''' <summary>
        ''' Helper method. Takes care of ReportItems loosing its handler. See GetClone method.
        ''' </summary>
        Friend Sub RestoreChildListsHandles()
            Try
                RemoveHandler _ReportItems.ListChanged, AddressOf ReportItems_Changed
            Catch ex As Exception
            End Try
            AddHandler _ReportItems.ListChanged, AddressOf ReportItems_Changed
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Documents_AdvanceReport_ToString, _
                _Date.ToString("yyyy-MM-dd"), _DocumentNumber, _ID.ToString())
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("DocumentNumber"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Content"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("CurrencyRate"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Sum"))
            ValidationRules.AddRule(AddressOf CommonValidation.PersonFieldValidation, _
                New Csla.Validation.RuleArgs("Person"))
            ValidationRules.AddRule(AddressOf CommonValidation.AccountFieldValidation, _
                New Csla.Validation.RuleArgs("Account"))
            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyFieldValidation, _
                New Csla.Validation.RuleArgs("CurrencyCode"))

            ValidationRules.AddRule(AddressOf DateValidation, New Validation.RuleArgs("Date"))

            ValidationRules.AddDependantProperty("Sum", "Date", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property Date is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DateValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As AdvanceReport = DirectCast(target, AdvanceReport)

            If Not valObj.ChronologicValidator.ValidateOperationDate(valObj._Date, e.Description, e.Severity) Then
                Return False
            ElseIf valObj._Date.Date < valObj._ReportItems.GetMaxDate.Date Then
                e.Description = String.Format(My.Resources.Documents_AdvanceReport_DateInvalid, _
                    valObj._ReportItems.GetMaxDate.ToString("yyyy-MM-dd"))
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Documents.AdvanceReport2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.AdvanceReport1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.AdvanceReport2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.AdvanceReport3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.AdvanceReport3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new instance of AdvanceReport.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function NewAdvanceReport() As AdvanceReport

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Dim result As New AdvanceReport
            result._ReportItems = AdvanceReportItemList.NewAdvanceReportItemList
            result._ChronologicValidator = SimpleChronologicValidator.NewSimpleChronologicValidator( _
                My.Resources.Documents_AdvanceReport_TypeName, Nothing)
            result.ValidationRules.CheckRules()
            Return result

        End Function

        ''' <summary>
        ''' Gets an existing instance of AdvanceReport from a database.
        ''' </summary>
        ''' <param name="nID">An ID of the AdvanceReport to get.</param>
        ''' <remarks></remarks>
        Public Shared Function GetAdvanceReport(ByVal nID As Integer) As AdvanceReport
            Return DataPortal.Fetch(Of AdvanceReport)(New Criteria(nID))
        End Function

        ''' <summary>
        ''' Deletes an existing instance of AdvanceReport from a database.
        ''' </summary>
        ''' <param name="id">An ID of the AdvanceReport to delete.</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteAdvanceReport(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public Sub New(ByVal nID As Integer)
                _ID = nID
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchAdvanceReport")
            myComm.AddParam("?CD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.Common_ObjectNotFound, My.Resources.Documents_AdvanceReport_TypeName, _
                    criteria.ID.ToString()))

                Dim dr As DataRow = myData.Rows(0)

                _ID = criteria.ID
                _Date = CDateSafe(dr.Item(0), Today)
                _DocumentNumber = CStrSafe(dr.Item(1)).Trim
                _Content = CStrSafe(dr.Item(2)).Trim
                _CurrencyCode = CStrSafe(dr.Item(3)).Trim
                _CurrencyRate = CDblSafe(dr.Item(4), ROUNDCURRENCYRATE, 0)
                _Account = CLongSafe(dr.Item(5), 0)
                _Comments = CStrSafe(dr.Item(6)).Trim
                _CommentsInternal = CStrSafe(dr.Item(7)).Trim
                ' DocumentState = CStrSafe(dr.Item(8))
                _InsertDate = CTimeStampSafe(dr.Item(9))
                _UpdateDate = CTimeStampSafe(dr.Item(10))
                _Person = PersonInfo.GetPersonInfo(dr, 11)

            End Using

            _ChronologicValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                _ID, _Date, My.Resources.Documents_AdvanceReport_TypeName, Nothing)

            myComm = New SQLCommand("FetchAdvanceReportItemList")
            myComm.AddParam("?CD", criteria.ID)

            Using myData As DataTable = myComm.Fetch
                _ReportItems = AdvanceReportItemList.GetAdvanceReportItemList(myData, _
                    _CurrencyRate, _CurrencyCode, _ChronologicValidator.FinancialDataCanChange, _FetchWarnings)
            End Using

            CalculateSubTotals(False)

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim entry As General.JournalEntry = GetJournalEntry()

            Using transaction As New SqlTransaction

                Try

                    entry = entry.SaveChild()

                    _ID = entry.ID
                    _InsertDate = entry.InsertDate
                    _UpdateDate = entry.UpdateDate

                    Dim myComm As New SQLCommand("InsertAdvanceReport")
                    AddWithParamsGeneral(myComm)
                    AddWithParamsFinancial(myComm)

                    myComm.Execute()

                    ReportItems.Update(Me)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            _ChronologicValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                _ID, _ChronologicValidator.CurrentOperationDate, _
                My.Resources.Documents_AdvanceReport_TypeName, Nothing)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim entry As General.JournalEntry = GetJournalEntry()

            Dim myComm As SQLCommand
            If _ChronologicValidator.FinancialDataCanChange Then
                myComm = New SQLCommand("UpdateAdvanceReport")
                AddWithParamsFinancial(myComm)
            Else
                myComm = New SQLCommand("UpdateAdvanceReportNonFinancial")
            End If
            AddWithParamsGeneral(myComm)

            Using transaction As New SqlTransaction

                Try

                    entry = entry.SaveChild()

                    _UpdateDate = entry.UpdateDate

                    myComm.Execute()

                    ReportItems.Update(Me)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted(DirectCast(criteria, Criteria).ID, _
                DocumentType.AdvanceReport)

            Dim myComm As New SQLCommand("DeleteAdvanceReport")
            myComm.AddParam("?CD", DirectCast(criteria, Criteria).ID)

            Using transaction As New SqlTransaction

                Try

                    General.JournalEntry.DeleteJournalEntryChild(DirectCast(criteria, Criteria).ID)

                    myComm.Execute()

                    myComm = New SQLCommand("DeleteAllAdvanceReportItems")
                    myComm.AddParam("?CD", DirectCast(criteria, Criteria).ID)
                    myComm.Execute()

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkNew()

        End Sub


        Private Sub AddWithParamsGeneral(ByRef myComm As SQLCommand)
            myComm.AddParam("?AA", _ID)
            myComm.AddParam("?AE", _Comments.Trim)
            myComm.AddParam("?AF", _CommentsInternal.Trim)
            myComm.AddParam("?AG", "") ' DocumentState
        End Sub

        Private Sub AddWithParamsFinancial(ByRef myComm As SQLCommand)
            myComm.AddParam("?AB", _CurrencyCode.Trim)
            myComm.AddParam("?AC", CRound(_CurrencyRate, ROUNDCURRENCYRATE))
            myComm.AddParam("?AD", _Account)
        End Sub

        Private Function GetJournalEntry() As General.JournalEntry

            Dim result As General.JournalEntry
            If IsNew Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.AdvanceReport)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_ID, DocumentType.AdvanceReport)
                If result.UpdateDate <> _UpdateDate Then Throw New Exception( _
                    My.Resources.Common_UpdateDateHasChanged)
            End If

            result.Content = _Content
            result.Date = _Date
            result.DocNumber = _DocumentNumber
            result.Person = _Person

            If _ChronologicValidator.FinancialDataCanChange Then

                Dim fullBookEntryList As BookEntryInternalList = _ReportItems.GetFullBookEntryList(_Account)

                result.DebetList.Clear()
                result.CreditList.Clear()

                result.DebetList.LoadBookEntryListFromInternalList(fullBookEntryList, False, False)
                result.CreditList.LoadBookEntryListFromInternalList(fullBookEntryList, False, False)

            End If

            If Not result.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_FailedToCreateJournalEntry, _
                    vbCrLf, result.ToString, vbCrLf, result.GetAllBrokenRules))
            End If

            Return result

        End Function

#End Region

    End Class

End Namespace