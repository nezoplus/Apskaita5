﻿Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.Attributes

Namespace Documents

    ''' <summary>
    ''' Represents a till income order - a document that is composed when cash is fetched into the till.
    ''' </summary>
    ''' <remarks>Encapsulates a <see cref="General.JournalEntry">JournalEntry</see> of type <see cref="DocumentType.AdvanceReport">DocumentType.AdvanceReport</see>.
    ''' Values are stored in the database table kpo.</remarks>
    <Serializable()> _
    Public NotInheritable Class TillIncomeOrder
        Inherits BusinessBase(Of TillIncomeOrder)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _ChronologicValidator As SimpleChronologicValidator
        Private _Account As CashAccountInfo = Nothing
        Private _Date As Date = Today
        Private _DocumentSerial As String = ""
        Private _DocumentNumber As Integer = 0
        Private _AddDateToNumberOptionWasUsed As Boolean = False
        Private _FullDocumentNumber As String = ""
        Private _Payer As PersonInfo = Nothing
        Private _IsUnderPayRoll As Boolean = False
        Private _Content As String = ""
        Private _CurrencyRateInAccount As Double = 1
        Private _Sum As Double = 0
        Private _SumLTL As Double = 0
        Private _SumCorespondences As Double = 0
        Private _AccountCurrencyRateChangeImpact As Long = 0
        Private _CurrencyRateChangeImpact As Double = 0
        Private _PayersRepresentative As String = ""
        Private _AttachmentsDescription As String = ""
        Private _AdditionalContent As String = ""
        Private _AdvanceReportID As Integer = 0
        Private _AdvanceReportDescription As String = ""
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private WithEvents _BookEntryItems As General.BookEntryList

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _BookEntryItemsSortedList As Csla.SortedBindingList(Of General.BookEntry) = Nothing


        ''' <summary>
        ''' Gets <see cref="General.JournalEntry.ID">an ID of the journal entry</see> that is created by the order.
        ''' </summary>
        ''' <remarks>Value is stored in the database field kpo.BZ_ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="IChronologicValidator">IChronologicValidator</see> object that contains business restraints on updating the order.
        ''' </summary>
        ''' <remarks>A <see cref="SimpleChronologicValidator">SimpleChronologicValidator</see> is used to validate a till order chronological business rules.</remarks>
        Public ReadOnly Property ChronologicValidator() As SimpleChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChronologicValidator
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the order was inserted into the database.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.InsertDate">journal entry InsertDate property</see>.</remarks>
        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the order was last updated.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.UpdateDate">journal entry UpdateDate property</see>.</remarks>
        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a <see cref="CashAccount">cash (till) account</see> that the cash is fetched in.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.CashAccountInfoList">CashAccountInfoList</see> as a datasource.
        ''' Value is stored in the database field kpo.CashAccountID.</remarks>
        <CashAccountFieldAttribute(ValueRequiredLevel.Mandatory, True, CashAccountType.Till)> _
        Public Property Account() As HelperLists.CashAccountInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As CashAccountInfo)

                CanWriteProperty(True)

                If AccountIsReadOnly Then Exit Property

                If Not (_Account Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Account Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _Account = value) Then

                    Dim oldCurrencyCode As String = ""
                    If Not _Account Is Nothing AndAlso Not _Account.IsEmpty Then
                        oldCurrencyCode = _Account.CurrencyCode
                    End If

                    _Account = value
                    PropertyHasChanged()

                    If Not CurrenciesEquals(oldCurrencyCode, _Account.CurrencyCode, GetCurrentCompany.BaseCurrency) Then

                        PropertyHasChanged("AccountCurrency")

                        Dim newRate As Double = 0
                        If IsBaseCurrency(_Account.CurrencyCode, GetCurrentCompany.BaseCurrency) Then
                            newRate = 1
                        End If

                        If CRound(_CurrencyRateInAccount, ROUNDCURRENCYRATE) <> CRound(newRate, ROUNDCURRENCYRATE) Then
                            _CurrencyRateInAccount = newRate
                            PropertyHasChanged("CurrencyRateInAccount")
                            Recalculate(True)
                        End If

                    End If

                    PropertyHasChanged("CurrencyRateInAccountIsReadOnly")
                    PropertyHasChanged("SumIsReadOnly")

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets a currency for the selected <see cref="Account">Account</see>.
        ''' Returns BaseCurrency in case <see cref="Account">Account</see> is null or empty.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="CashAccount.CurrencyCode">CashAccount.CurrencyCode</see>.
        ''' Provides a proxy in case <see cref="Account">Account</see> is null or empty.</remarks>
        <CurrencyField(ValueRequiredLevel.Mandatory)> _
        Public ReadOnly Property AccountCurrency() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If Not _Account Is Nothing AndAlso Not _Account.IsEmpty Then Return _Account.CurrencyCode
                Return GetCurrentCompany.BaseCurrency
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the date of the order.
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

                    If _AddDateToNumberOptionWasUsed AndAlso _DocumentNumber > 0 Then
                        _FullDocumentNumber = GetFullDocumentNumber()
                        PropertyHasChanged("FullDocumentNumber")
                    End If

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a <see cref="ApskaitaObjects.Settings.DocumentSerial">serial</see> of the order.
        ''' </summary>
        ''' <remarks> Use <see cref="HelperLists.DocumentSerialInfoList">DocumentSerialInfoList</see> for a datasource.
        ''' Value is stored in the database field kpo.Serija.</remarks>
        <DocumentSerialField(ValueRequiredLevel.Mandatory, ApskaitaObjects.Settings.DocumentSerialType.TillIncomeOrder)> _
        Public Property DocumentSerial() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentSerial.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _DocumentSerial.Trim.ToUpper <> value.Trim.ToUpper Then
                    _DocumentSerial = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a running number of the order.
        ''' </summary>
        ''' <remarks>Value is stored in the database field kpo.Nr.</remarks>
        <IntegerField(ValueRequiredLevel.Mandatory, False)> _
        Public Property DocumentNumber() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If _DocumentNumber <> value Then
                    _DocumentNumber = value
                    PropertyHasChanged()
                    _FullDocumentNumber = GetFullDocumentNumber()
                    PropertyHasChanged("FullDocumentNumber")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets whether the order was created with a <see cref="General.Company.AddDateToTillIncomeOrderNumber">Company.AddDateToTillIncomeOrderNumber</see> option on.
        ''' </summary>
        ''' <remarks>Defines a format of the <see cref="FullDocumentNumber">FullDocumentNumber</see>.
        ''' Cannot be changed after the order is first inserted.
        ''' Value is stored in the database field kpo.AddDateToNumberOptionWasUsed.</remarks>
        Public ReadOnly Property AddDateToNumberOptionWasUsed() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AddDateToNumberOptionWasUsed
            End Get
        End Property

        ''' <summary>
        ''' Gets a full (formated) number of the order.
        ''' </summary>
        ''' <remarks>Format is defined by the <see cref="General.Company.AddDateToTillIncomeOrderNumber">Company.AddDateToTillIncomeOrderNumber</see> option.
        ''' Cannot be changed after the order is first inserted.</remarks>
        Public ReadOnly Property FullDocumentNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FullDocumentNumber.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a <see cref="General.Person">person</see> who fetched the cash in.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.PersonInfoList">PersonInfoList</see> as a datasource.
        ''' Value is handled by the encapsulated <see cref="General.JournalEntry.Person">journal entry Person property</see>.</remarks>
        <PersonField(ValueRequiredLevel.Mandatory)> _
        Public Property Payer() As PersonInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Payer
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As PersonInfo)
                CanWriteProperty(True)

                If Not (_Payer Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Payer Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _Payer = value) Then

                    _Payer = value
                    PropertyHasChanged()

                    If Not _Payer Is Nothing AndAlso Not _Payer.IsEmpty AndAlso Not _IsUnderPayRoll _
                        AndAlso _Payer.AccountAgainstBankBuyer > 0 AndAlso _BookEntryItems.Count < 1 Then
                        Dim be As General.BookEntry = General.BookEntry.NewBookEntry()
                        be.Account = _Payer.AccountAgainstBankBuyer
                        _BookEntryItems.Add(be)
                    End If

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the cash was fetched in by multiple persons indicated 
        ''' in some additional document (e.g. fee collection sheet).
        ''' </summary>
        ''' <remarks>Value is stored in the database field kpo.IsUnderPayRoll.</remarks>
        Public Property IsUnderPayRoll() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsUnderPayRoll
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _IsUnderPayRoll <> value Then
                    _IsUnderPayRoll = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the content (description) of the order.
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
        ''' Gets or sets a currency rate for the <see cref="AccountCurrency">AccountCurrency</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field kpo.CurrencyRateInAccount.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDCURRENCYRATE)> _
        Public Property CurrencyRateInAccount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateInAccount, ROUNDCURRENCYRATE)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)

                If CurrencyRateInAccountIsReadOnly Then Exit Property

                If CRound(_CurrencyRateInAccount, ROUNDCURRENCYRATE) <> CRound(value, ROUNDCURRENCYRATE) Then

                    _CurrencyRateInAccount = CRound(value, ROUNDCURRENCYRATE)
                    PropertyHasChanged()

                    Recalculate(True)

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the total sum of the order in the <see cref="AccountCurrency">AccountCurrency</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field kpo.SumOriginal.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If SumIsReadOnly Then Exit Property
                If CRound(_Sum) <> CRound(value) Then
                    _Sum = CRound(value)
                    PropertyHasChanged()
                    Recalculate(True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the total sum of the order in the base currency.
        ''' </summary>
        ''' <remarks>Value is stored in the database field kpo.SumLTL.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property SumLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total sum of book entries in the <see cref="BookEntryItems">BookEntryItems</see>.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property SumCorespondences() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumCorespondences)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="General.Account.ID">account</see> for the currency rate change effect.
        ''' </summary>
        ''' <remarks>Value is stored in the database field kpo.AccountCurrencyRateChangeImpact.</remarks>
        <AccountField(ValueRequiredLevel.Optional, True, 5, 6)> _
        Public Property AccountCurrencyRateChangeImpact() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountCurrencyRateChangeImpact
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountCurrencyRateChangeImpactIsReadOnly Then Exit Property
                If _AccountCurrencyRateChangeImpact <> value Then
                    _AccountCurrencyRateChangeImpact = value
                    PropertyHasChanged()
                    Recalculate(True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the sum of the currency rate change effect. 
        ''' Positive value is treated as revenue, negative value is treated as costs.
        ''' </summary>
        ''' <remarks>Value is stored in the database field kpo.CurrencyRateChangeImpact.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public Property CurrencyRateChangeImpact() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateChangeImpact)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CurrencyRateChangeImpactIsReadOnly Then Exit Property
                If CRound(_CurrencyRateChangeImpact) <> CRound(value) Then
                    _CurrencyRateChangeImpact = CRound(value)
                    PropertyHasChanged()
                    Recalculate(True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="Payer">payer's</see> representative if any. 
        ''' E. g. some company represented by a manager. 
        ''' </summary>
        ''' <remarks>Value is stored in the database field kpo.Asmuo.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property PayersRepresentative() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PayersRepresentative.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _PayersRepresentative.Trim <> value.Trim Then
                    _PayersRepresentative = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a description of the documents that are attached to the order (if any). 
        ''' </summary>
        ''' <remarks>Value is stored in the database field kpo.Priedas.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property AttachmentsDescription() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AttachmentsDescription.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _AttachmentsDescription.Trim <> value.Trim Then
                    _AttachmentsDescription = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a supplementary description of the the order (if any). 
        ''' </summary>
        ''' <remarks>Value is stored in the database field kpo.Aprasas.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property AdditionalContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AdditionalContent.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _AdditionalContent.Trim <> value.Trim Then
                    _AdditionalContent = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets an <see cref="AdvanceReport.ID">ID of the advance report</see> that is attached to the order (if any). 
        ''' </summary>
        ''' <remarks>Use <see cref="LoadAdvanceReport">LoadAdvanceReport</see> method to attach an advance report.
        ''' Value is stored in the database field kpo.Apysk.</remarks>
        Public ReadOnly Property AdvanceReportID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AdvanceReportID
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="ActiveReports.AdvanceReportInfo.ToString">description of the advance report</see> 
        ''' that is attached to the order (if any). 
        ''' </summary>
        ''' <remarks>Use <see cref="LoadAdvanceReport">LoadAdvanceReport</see> method to attach an advance report.
        ''' Value is stored in the database table kpo.Apysk.</remarks>
        Public ReadOnly Property AdvanceReportDescription() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AdvanceReportDescription.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a list of credit <see cref="General.BookEntry">book entries</see> that a user needs to make by the order. 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property BookEntryItems() As General.BookEntryList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BookEntryItems
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable list of credit <see cref="General.BookEntry">book entries</see> 
        ''' that a user needs to make by the order. 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property BookEntryItemsSorted() As Csla.SortedBindingList(Of General.BookEntry)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _BookEntryItemsSortedList Is Nothing Then _BookEntryItemsSortedList = _
                    New Csla.SortedBindingList(Of General.BookEntry)(_BookEntryItems)
                Return _BookEntryItemsSortedList
            End Get
        End Property


        ''' <summary>
        ''' Gets whether the <see cref="Account">Account</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="CurrencyRateInAccount">CurrencyRateInAccount</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrencyRateInAccountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (Not _ChronologicValidator.FinancialDataCanChange OrElse _
                    IsBaseCurrency(Me.AccountCurrency, GetCurrentCompany.BaseCurrency))
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="Sum">Sum</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SumIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (Not _ChronologicValidator.FinancialDataCanChange OrElse _
                    IsBaseCurrency(Me.AccountCurrency, GetCurrentCompany.BaseCurrency))
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="AccountCurrencyRateChangeImpact">AccountCurrencyRateChangeImpact</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountCurrencyRateChangeImpactIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="CurrencyRateChangeImpact">CurrencyRateChangeImpact</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrencyRateChangeImpactIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="BookEntryItems">BookEntryItems</see> is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property BookEntryItemsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange
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
                Return (Not StringIsNullOrEmpty(_DocumentSerial) _
                    OrElse Not StringIsNullOrEmpty(_FullDocumentNumber) _
                    OrElse Not StringIsNullOrEmpty(_Content) _
                    OrElse CRound(_Sum) > 0 OrElse _BookEntryItems.Count > 0)
            End Get
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _BookEntryItems.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid AndAlso _BookEntryItems.IsValid
            End Get
        End Property



        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            If Not _BookEntryItems.IsValid Then result = AddWithNewLine(result, _
                _BookEntryItems.GetAllBrokenRules, False)
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then _
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            If _BookEntryItems.HasWarnings() Then _
                result = AddWithNewLine(result, _BookEntryItems.GetAllWarnings, False)
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return (MyBase.BrokenRulesCollection.WarningCount > 0 OrElse _BookEntryItems.HasWarnings())
        End Function


        Public Overrides Function Save() As TillIncomeOrder

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Return MyBase.Save

        End Function


        Private Sub BookEntryItems_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _BookEntryItems.ListChanged

            _SumCorespondences = _BookEntryItems.GetSum
            PropertyHasChanged("SumCorespondences")

            Recalculate(True)

        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As TillIncomeOrder = DirectCast(MyBase.GetClone(), TillIncomeOrder)
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
        ''' Helper method. Takes care of BookEntryItems loosing its handler. See GetClone method.
        ''' </summary>
        Friend Sub RestoreChildListsHandles()
            Try
                RemoveHandler _BookEntryItems.ListChanged, AddressOf BookEntryItems_Changed
            Catch ex As Exception
            End Try
            AddHandler _BookEntryItems.ListChanged, AddressOf BookEntryItems_Changed
        End Sub


        Private Sub Recalculate(ByVal raisePropertyChangedEvents As Boolean)

            If IsBaseCurrency(Me.AccountCurrency, GetCurrentCompany.BaseCurrency) Then

                _Sum = CRound(_SumCorespondences + _CurrencyRateChangeImpact)
                _SumLTL = CRound(_SumCorespondences + _CurrencyRateChangeImpact)

                If raisePropertyChangedEvents Then
                    PropertyHasChanged("Sum")
                    PropertyHasChanged("SumLTL")
                End If

            Else

                _SumLTL = CRound(_Sum * _CurrencyRateInAccount)

                If raisePropertyChangedEvents Then
                    PropertyHasChanged("SumLTL")
                End If

            End If

        End Sub

        Private Function GetFullDocumentNumber() As String
            If _AddDateToNumberOptionWasUsed AndAlso _DocumentNumber > 0 Then
                Return String.Format(TILLINCOMEORDERFULLNUMBERFORMATWITHDATE, _
                    _Date.ToString(TILLINCOMEORDERDATEFORMATINNUMBER), _DocumentNumber.ToString())
            ElseIf _DocumentNumber > 0 Then
                Return _DocumentNumber.ToString
            Else
                Return ""
            End If
        End Function


        ''' <summary>
        ''' Attaches an advance report to the order.
        ''' </summary>
        ''' <param name="nAdvanceReportInfo">An advance report to attach.</param>
        ''' <remarks>Use <see cref="ActiveReports.AdvanceReportInfoList">ActiveReports.AdvanceReportInfoList</see> for a datasource.</remarks>
        Public Sub LoadAdvanceReport(ByVal nAdvanceReportInfo As ActiveReports.AdvanceReportInfo, _
            ByVal personList As PersonInfoList)

            If nAdvanceReportInfo Is Nothing OrElse Not nAdvanceReportInfo.ID > 0 Then
                Throw New ArgumentNullException("nAdvanceReportInfo", _
                    My.Resources.Documents_TillIncomeOrder_AdvanceReportNull)
            End If

            If Not CRound(nAdvanceReportInfo.IncomeSumTotal - nAdvanceReportInfo.ExpensesSumTotal) > 0 Then
                Throw New Exception(My.Resources.Documents_TillIncomeOrder_AdvanceReportInvalid)
            End If

            If _IsUnderPayRoll Then
                Throw New Exception(My.Resources.Documents_TillIncomeOrder_CannotAttachAdvanceReport)
            End If

            _AdvanceReportID = nAdvanceReportInfo.ID
            _AdvanceReportDescription = nAdvanceReportInfo.ToString

            PropertyHasChanged("AdvanceReportID")
            PropertyHasChanged("AdvanceReportDescription")

            If StringIsNullOrEmpty(_Content) Then
                _Content = String.Format(My.Resources.Documents_TillIncomeOrder_ContentForAdvanceReport, _
                    nAdvanceReportInfo.Date.ToString("yyyy-MM-dd"), nAdvanceReportInfo.DocumentNumber)
                PropertyHasChanged("Content")
            End If

            If StringIsNullOrEmpty(_AttachmentsDescription) Then
                _AttachmentsDescription = String.Format(My.Resources.Documents_TillIncomeOrder_AttachmentForAdvanceReport, _
                    nAdvanceReportInfo.Date.ToString("yyyy-MM-dd"), nAdvanceReportInfo.DocumentNumber)
                PropertyHasChanged("AttachmentsDescription")
            End If

            If Not personList Is Nothing AndAlso (_Payer Is Nothing OrElse _Payer.IsEmpty) Then
                For Each p As PersonInfo In personList
                    If p.ID = nAdvanceReportInfo.PersonID Then
                        _Payer = p
                        PropertyHasChanged("Payer")
                        Exit For
                    End If
                Next
            End If

            If _ChronologicValidator.FinancialDataCanChange Then

                Dim baseCurrency As String = GetCurrentCompany.BaseCurrency

                If _BookEntryItems.Count < 1 AndAlso CRound(nAdvanceReportInfo.IncomeSumTotalLTL _
                        - nAdvanceReportInfo.ExpensesSumTotalLTL) > 0.0 Then
                    Dim newEntry As General.BookEntry = General.BookEntry.NewBookEntry()
                    newEntry.Account = nAdvanceReportInfo.Account
                    newEntry.Amount = CRound(nAdvanceReportInfo.IncomeSumTotalLTL _
                        - nAdvanceReportInfo.ExpensesSumTotalLTL)
                    _BookEntryItems.Add(newEntry)
                End If

                If IsBaseCurrency(Me.AccountCurrency, baseCurrency) Then
                    ' do nothing, Recalculate method is sufficient
                ElseIf CurrenciesEquals(Me.AccountCurrency, nAdvanceReportInfo.CurrencyCode, baseCurrency) Then
                    _Sum = CRound(nAdvanceReportInfo.IncomeSumTotal - nAdvanceReportInfo.ExpensesSumTotal)
                Else
                    _Sum = CRound(CRound(nAdvanceReportInfo.IncomeSumTotalLTL _
                        - nAdvanceReportInfo.ExpensesSumTotalLTL) * _CurrencyRateInAccount)
                End If

                PropertyHasChanged("Sum")
                Recalculate(True)

            End If

        End Sub

        ''' <summary>
        ''' Removes an advance report from the order.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ClearAdvanceReport()
            _AdvanceReportID = 0
            _AdvanceReportDescription = ""
            PropertyHasChanged("AdvanceReportID")
            PropertyHasChanged("AdvanceReportDescription")
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Documents_TillIncomeOrder_ToString, _
                _Date.ToString("yyyy-MM-dd"), _DocumentSerial, _DocumentNumber.ToString(), _ID.ToString())
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("DocumentSerial"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("Content"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("PayersRepresentative"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("AttachmentsDescription"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("AdditionalContent"))
            ValidationRules.AddRule(AddressOf CommonValidation.IntegerFieldValidation, _
                New Validation.RuleArgs("DocumentNumber"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Validation.RuleArgs("Sum"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Validation.RuleArgs("CurrencyRateInAccount"))
            ValidationRules.AddRule(AddressOf CommonValidation.CashAccountFieldValidation, _
                New Validation.RuleArgs("Account"))

            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "ChronologicValidator"))


            ValidationRules.AddRule(AddressOf AccountValidation, New Validation.RuleArgs("Account"))
            ValidationRules.AddRule(AddressOf PayerValidation, New Validation.RuleArgs("Payer"))
            ValidationRules.AddRule(AddressOf SumLTLValidation, New Validation.RuleArgs("SumLTL"))
            ValidationRules.AddRule(AddressOf AccountCurrencyRateChangeImpactValidation, _
                New Validation.RuleArgs("AccountCurrencyRateChangeImpact"))
            ValidationRules.AddRule(AddressOf AdvanceReportDescriptionValidation, _
                New Validation.RuleArgs("AdvanceReportDescription"))

            ValidationRules.AddDependantProperty("IsUnderPayRoll", "Payer", False)
            ValidationRules.AddDependantProperty("CurrencyRateChangeImpact", "SumLTL", False)
            ValidationRules.AddDependantProperty("SumCorespondences", "SumLTL", False)
            ValidationRules.AddDependantProperty("CurrencyRateChangeImpact", "AccountCurrencyRateChangeImpact", False)
            ValidationRules.AddDependantProperty("IsUnderPayRoll", "AdvanceReportDescription", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that a valid account is set.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As TillIncomeOrder = DirectCast(target, TillIncomeOrder)

            If Not valObj._Account Is Nothing AndAlso Not valObj._Account.IsEmpty _
                AndAlso valObj._Account.Type <> CashAccountType.Till Then

                e.Description = My.Resources.Documents_TillIncomeOrder_AccountInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that a Payer is set unless a pay roll is attached.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function PayerValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As TillIncomeOrder = DirectCast(target, TillIncomeOrder)

            If Not valObj._IsUnderPayRoll Then

                Return CommonValidation.PersonFieldValidation(target, e)

            ElseIf valObj._IsUnderPayRoll AndAlso valObj._Payer <> PersonInfo.Empty Then

                e.Description = My.Resources.Documents_TillIncomeOrder_PayerInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that a sum of order is provided.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumLTLValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As TillIncomeOrder = DirectCast(target, TillIncomeOrder)

            If Not CommonValidation.CommonValidation.DoubleFieldValidation(target, e) Then Return False

            If CRound(valObj._SumLTL) <> CRound(valObj._SumCorespondences + _
                valObj._CurrencyRateChangeImpact) Then

                e.Description = My.Resources.Documents_TillIncomeOrder_SumLTLInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that a valid currency rate change impact account is set when necessary.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountCurrencyRateChangeImpactValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As TillIncomeOrder = DirectCast(target, TillIncomeOrder)

            If CRound(valObj._CurrencyRateChangeImpact) = 0.0 Then Return True

            Return CommonValidation.CommonValidation.AccountFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that a pay roll based order wouldn't have an advance reports attached.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AdvanceReportDescriptionValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As TillIncomeOrder = DirectCast(target, TillIncomeOrder)

            If valObj._IsUnderPayRoll AndAlso valObj._AdvanceReportID > 0 Then

                e.Description = My.Resources.Documents_TillIncomeOrder_CannotAttachAdvanceReport
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Documents.TillIncomeOrder2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.TillIncomeOrder1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.TillIncomeOrder2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.TillIncomeOrder3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.TillIncomeOrder3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new TillIncomeOrder instance.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function NewTillIncomeOrder() As TillIncomeOrder

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Dim result As New TillIncomeOrder

            result._BookEntryItems = General.BookEntryList.NewBookEntryList(BookEntryType.Kreditas)
            result._AddDateToNumberOptionWasUsed = GetCurrentCompany.AddDateToTillIncomeOrderNumber
            result._ChronologicValidator = SimpleChronologicValidator.NewSimpleChronologicValidator( _
                My.Resources.Documents_TillIncomeOrder_TypeName, Nothing)

            result.ValidationRules.CheckRules()

            Return result

        End Function

        ''' <summary>
        ''' Gets an existing TillIncomeOrder instance from a database.
        ''' </summary>
        ''' <param name="nID">An ID of the TillIncomeOrder instance to get.</param>
        ''' <remarks></remarks>
        Public Shared Function GetTillIncomeOrder(ByVal nID As Integer) As TillIncomeOrder
            Return DataPortal.Fetch(Of TillIncomeOrder)(New Criteria(nID))
        End Function

        ''' <summary>
        ''' Deletes an existing TillIncomeOrder instance from a database.
        ''' </summary>
        ''' <param name="id">An ID of the TillIncomeOrder instance to delete.</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteTillIncomeOrder(ByVal id As Integer)
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

            Dim myComm As New SQLCommand("FetchTillIncomeOrder")
            myComm.AddParam("?BD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.Common_ObjectNotFound, My.Resources.Documents_TillIncomeOrder_TypeName, _
                    criteria.ID.ToString()))

                _ID = criteria.ID

                Dim dr As DataRow = myData.Rows(0)

                _Date = CDateSafe(dr.Item(0), Today)
                ' _FullDocumentNumber = CStrSafe(dr.Item(1)).Trim
                _Content = CStrSafe(dr.Item(2)).Trim
                _DocumentSerial = CStrSafe(dr.Item(3)).Trim
                _DocumentNumber = CIntSafe(dr.Item(4), 0)
                _AddDateToNumberOptionWasUsed = ConvertDbBoolean(CIntSafe(dr.Item(5), 0))
                _FullDocumentNumber = GetFullDocumentNumber()
                _CurrencyRateInAccount = CDblSafe(dr.Item(6), ROUNDCURRENCYRATE, 0)
                _Sum = CDblSafe(dr.Item(7), 2, 0)
                _SumLTL = CDblSafe(dr.Item(8), 2, 0)
                _IsUnderPayRoll = ConvertDbBoolean(CIntSafe(dr.Item(9), 0))
                _AccountCurrencyRateChangeImpact = CLongSafe(dr.Item(10), 0)
                _CurrencyRateChangeImpact = CDblSafe(dr.Item(11), 2, 0)
                _PayersRepresentative = CStrSafe(dr.Item(12)).Trim
                _AdditionalContent = CStrSafe(dr.Item(13)).Trim
                _AttachmentsDescription = CStrSafe(dr.Item(14)).Trim
                ' _DocumentState = CStrSafe(dr.Item(15)).Trim
                _InsertDate = CTimeStampSafe(dr.Item(16))
                _UpdateDate = CTimeStampSafe(dr.Item(17))
                _AdvanceReportID = CIntSafe(dr.Item(18), 0)
                _AdvanceReportDescription = String.Format("{0} Nr. {1} : {2}", _
                    CStrSafe(dr.Item(19)), CStrSafe(dr.Item(20)), _
                    GetLimitedLengthString(CStrSafe(dr.Item(21)).Trim, 100))
                _Account = CashAccountInfo.GetCashAccountInfo(dr, 22)
                _Payer = PersonInfo.GetPersonInfo(dr, 36)

            End Using

            _ChronologicValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                _ID, _Date, My.Resources.Documents_TillIncomeOrder_TypeName, Nothing)

            _BookEntryItems = General.BookEntryList.GetBookEntryList(_ID, _
                BookEntryType.Kreditas, _ChronologicValidator, _AccountCurrencyRateChangeImpact)

            _SumCorespondences = _BookEntryItems.GetSum

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            CheckIfNumberUnique()

            Dim entry As General.JournalEntry = GetJournalEntry()

            Using transaction As New SqlTransaction

                Try

                    entry = entry.SaveChild()

                    _ID = entry.ID
                    _InsertDate = entry.InsertDate
                    _UpdateDate = entry.UpdateDate

                    Dim myComm As New SQLCommand("InsertTillIncomeOrder")
                    AddWithParamsGeneral(myComm)
                    AddWithParamsFinancial(myComm)
                    myComm.AddParam("?AB", ConvertDbBoolean(_AddDateToNumberOptionWasUsed))

                    myComm.Execute()

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
                My.Resources.Documents_TillIncomeOrder_TypeName, Nothing)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            CheckIfNumberUnique()

            Dim entry As General.JournalEntry = GetJournalEntry()

            Dim myComm As SQLCommand
            If _ChronologicValidator.FinancialDataCanChange Then
                myComm = New SQLCommand("UpdateTillIncomeOrder")
                AddWithParamsFinancial(myComm)
            Else
                myComm = New SQLCommand("UpdateTillIncomeOrderNonFinancial")
            End If
            AddWithParamsGeneral(myComm)

            Using transaction As New SqlTransaction

                Try

                    entry = entry.SaveChild()
                    _UpdateDate = entry.UpdateDate

                    myComm.Execute()

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
                DocumentType.TillIncomeOrder)

            Dim myComm As New SQLCommand("DeleteTillIncomeOrder")
            myComm.AddParam("?BD", DirectCast(criteria, Criteria).ID)

            Using transaction As New SqlTransaction

                Try

                    General.JournalEntry.DeleteJournalEntryChild(DirectCast(criteria, Criteria).ID)

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
            myComm.AddParam("?AD", _DocumentNumber)
            myComm.AddParam("?AE", _DocumentSerial.Trim)
            myComm.AddParam("?AF", _PayersRepresentative.Trim)
            myComm.AddParam("?AG", _AttachmentsDescription.Trim)
            myComm.AddParam("?AH", _AdditionalContent.Trim)
            If Not _IsUnderPayRoll AndAlso _AdvanceReportID > 0 Then
                myComm.AddParam("?AI", _AdvanceReportID)
            Else
                myComm.AddParam("?AI", 0)
            End If
            myComm.AddParam("?AM", ConvertDbBoolean(_IsUnderPayRoll))
            myComm.AddParam("?AQ", "") ' DocumentState

        End Sub

        Private Sub AddWithParamsFinancial(ByRef myComm As SQLCommand)
            myComm.AddParam("?AC", _Account.ID)
            myComm.AddParam("?AJ", CRound(_CurrencyRateInAccount, ROUNDCURRENCYRATE))
            myComm.AddParam("?AK", CRound(_Sum))
            myComm.AddParam("?AL", CRound(_SumLTL))
            If _AccountCurrencyRateChangeImpact > 0 AndAlso CRound(_CurrencyRateChangeImpact) <> 0 Then
                myComm.AddParam("?AN", _AccountCurrencyRateChangeImpact)
                myComm.AddParam("?AO", CRound(_CurrencyRateChangeImpact))
            Else
                myComm.AddParam("?AN", 0)
                myComm.AddParam("?AO", 0)
            End If
        End Sub

        Private Function GetJournalEntry() As General.JournalEntry

            Dim result As General.JournalEntry
            If IsNew Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.TillIncomeOrder)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_ID, DocumentType.TillIncomeOrder)
                If result.UpdateDate <> _UpdateDate Then Throw New Exception( _
                    My.Resources.Common_UpdateDateHasChanged)
            End If

            result.Content = _Content
            result.Date = _Date
            result.DocNumber = _DocumentSerial & _FullDocumentNumber
            If _IsUnderPayRoll Then
                result.Person = Nothing
            Else
                result.Person = _Payer
            End If

            If _ChronologicValidator.FinancialDataCanChange Then

                If _AccountCurrencyRateChangeImpact > 0 Then

                    ' if the user for some inconceivable reason manualy enters account, 
                    ' that is ment for the currency rate change impact, into the BookEntryItems,
                    ' then the value of such an entry should be transfered to CurrencyRateChangeImpact
                    ' and the book entry should be removed.

                    Dim userSumInReservedAccount As Double = _BookEntryItems.GetSumInAccount( _
                        _AccountCurrencyRateChangeImpact)
                    If CRound(userSumInReservedAccount) > 0 Then
                        _CurrencyRateChangeImpact = CRound(_CurrencyRateChangeImpact _
                            + userSumInReservedAccount)
                    End If
                    _BookEntryItems.RemoveReservedAccounts(_AccountCurrencyRateChangeImpact)

                End If

                Dim fullBookEntryList As BookEntryInternalList = BookEntryInternalList. _
                NewBookEntryInternalList(BookEntryType.Debetas)

                fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                    BookEntryType.Debetas, _Account.Account, CRound(_SumLTL), Nothing))

                If CRound(_CurrencyRateChangeImpact) > 0 AndAlso _AccountCurrencyRateChangeImpact > 0 Then
                    fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, _AccountCurrencyRateChangeImpact, _
                        CRound(_CurrencyRateChangeImpact), Nothing))
                ElseIf CRound(_CurrencyRateChangeImpact) < 0 AndAlso _AccountCurrencyRateChangeImpact > 0 Then
                    fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, _AccountCurrencyRateChangeImpact, _
                        CRound(-_CurrencyRateChangeImpact), Nothing))
                Else
                    _AccountCurrencyRateChangeImpact = 0
                End If

                For Each i As General.BookEntry In _BookEntryItems

                    If i.Account <> _AccountCurrencyRateChangeImpact Then _
                        fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, i.Account, i.Amount, i.Person))

                Next

                fullBookEntryList.Aggregate()

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

        Private Sub CheckIfNumberUnique()

            Dim myComm As SQLCommand
            If _AddDateToNumberOptionWasUsed Then
                myComm = New SQLCommand("CheckIfTillIncomeOrderNumberUniqueWithDate")
                myComm.AddParam("?ND", _Date)
            Else
                myComm = New SQLCommand("CheckIfTillIncomeOrderNumberUnique")
            End If
            myComm.AddParam("?SR", _DocumentSerial.Trim.ToUpper)
            myComm.AddParam("?NM", _DocumentNumber)
            myComm.AddParam("?IN", _ID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 Then
                    Throw New Exception(My.Resources.Documents_TillIncomeOrder_SerialNumberNotUnique)
                End If
            End Using

        End Sub

#End Region

    End Class

End Namespace