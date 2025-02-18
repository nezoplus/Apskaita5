﻿Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.Documents.InvoiceAdapters
Imports ApskaitaObjects.Attributes

Namespace Documents

    ''' <summary>
    ''' Represents an invoice made (issued) by the company.
    ''' </summary>
    ''' <remarks>Encapsulates a <see cref="General.JournalEntry">JournalEntry</see> of type <see cref="DocumentType.InvoiceMade">DocumentType.InvoiceMade</see>.
    ''' Values are stored in the database table invoicesmade.</remarks>
    <Serializable()> _
    Public NotInheritable Class InvoiceMade
        Inherits BusinessBase(Of InvoiceMade)
        Implements IIsDirtyEnough, IClientEmailProvider, IValidationMessageProvider, ISyncable

#Region " Business Methods "

        Private _ID As Integer = -1
        Private _ChronologyValidator As ComplexChronologicValidator
        Private _Payer As PersonInfo = Nothing
        Private _AccountPayer As Long = 0
        Private _Date As Date = Today
        Private _Serial As String = ""
        Private _Number As Integer = 0
        Private _Content As String = ""
        Private _Type As InvoiceType = InvoiceType.Normal
        Private WithEvents _InvoiceItems As InvoiceMadeItemList
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency
        Private _CurrencyRate As Double = 1
        Private _LanguageCode As String = LanguageCodeLith.Trim.ToUpper
        Private _LanguageName As String = GetLanguageName(LanguageCodeLith, False)
        Private _CustomInfo As String = ""
        Private _CustomInfoAltLng As String = ""
        Private _VatExemptInfo As String = ""
        Private _VatExemptInfoAltLng As String = ""
        Private _CommentsInternal As String = ""
        Private _SumLTL As Double = 0
        Private _SumVatLTL As Double = 0
        Private _SumTotalLTL As Double = 0
        Private _Sum As Double = 0
        Private _SumVat As Double = 0
        Private _SumTotal As Double = 0
        Private _SumDiscount As Double = 0
        Private _SumDiscountVat As Double = 0
        Private _SumDiscountLTL As Double = 0
        Private _SumDiscountVatLTL As Double = 0
        Private _ExternalID As String = ""
        Private _FullNumber As String = ""
        Private _AddDateToNumberOptionWasUsed As Boolean = False
        Private _NumbersInInvoice As Integer = 0
        Private _IsDoomyInvoice As Boolean = False
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _SortedList As SortedBindingList(Of InvoiceMadeItem) = Nothing


        ''' <summary>
        ''' Gets <see cref="General.JournalEntry.ID">an ID of the journal entry</see> that is created by the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Whether it is a doomy invoice (created as an example, not ment for saving to the database).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsDoomyInvoice() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsDoomyInvoice
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the invoice data was inserted into the database.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.InsertDate.</remarks>
        Public ReadOnly Property InsertDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the invoice data was last updated.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.UpdateDate.</remarks>
        Public ReadOnly Property UpdateDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="IChronologicValidator">IChronologicValidator</see> object that contains business restraints on updating the invoice.
        ''' </summary>
        ''' <remarks>A <see cref="ComplexChronologicValidator">ComplexChronologicValidator</see> is used to validate a till order chronological business rules.
        ''' It aggregates a <see cref="SimpleChronologicValidator">SimpleChronologicValidator</see>
        ''' and <see cref="IChronologicValidator">IChronologicValidator</see> instances
        ''' owned by the <see cref="InvoiceAdapters.IInvoiceAdapter">attached operations</see>.</remarks>
        Public ReadOnly Property ChronologyValidator() As ComplexChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChronologyValidator
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a <see cref="General.Person">person</see> whom the invoice is issued to.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.PersonInfoList">PersonInfoList</see> as a datasource.
        ''' Value is handled by the encapsulated <see cref="General.JournalEntry.Person">journal entry Person property</see>.</remarks>
        <PersonFieldAttribute(ValueRequiredLevel.Mandatory)> _
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

                    If Not _Payer Is Nothing AndAlso Not _Payer.IsEmpty Then

                        LanguageCode = _Payer.LanguageCode

                        If Not AccountPayerIsReadOnly Then
                            AccountPayer = _Payer.AccountAgainstBankBuyer
                        End If

                        If Not CurrencyCodeIsReadOnly Then
                            CurrencyCode = _Payer.CurrencyCode
                        End If

                    End If

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="General.Account.ID">account</see> that is debited
        ''' by the total sum receivable from the <see cref="Payer">Payer</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.AccountPayer.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 2, 4)> _
        Public Property AccountPayer() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountPayer
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountPayerIsReadOnly Then Exit Property
                If _AccountPayer <> value Then
                    _AccountPayer = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the date of the invoice.
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
                    UpdateFullNumber(True)
                    _InvoiceItems.UpdateDate(_Date)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the serial (code) of the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.InvoiceSerial.</remarks>
        <DocumentSerialField(ValueRequiredLevel.Mandatory, ApskaitaObjects.Settings.DocumentSerialType.Invoice)> _
        Public Property Serial() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Serial.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Serial.Trim.ToUpper <> value.Trim.ToUpper Then
                    _Serial = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the the running number of the invoice. 
        ''' Used to generate full number according to the company rules, 
        ''' see <see cref="FullNumber">FullNumber</see> property for details.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.InvoiceNumber.</remarks>
        <IntegerField(ValueRequiredLevel.Mandatory, False)> _
        Public Property Number() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Number
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _Number <> value Then
                    _Number = value
                    PropertyHasChanged()
                    UpdateFullNumber(True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a full formated number of the invoice (excluding serial code) as specified by the company rules.
        ''' </summary>
        ''' <remarks>Options for formating an invoice number are as follows:
        ''' a) plain <see cref="Number">running number</see>, e.g. 123
        ''' (if <see cref="General.Company.AddDateToInvoiceNumber">Company.AddDateToInvoiceNumber</see> 
        ''' is set to false and <see cref="General.Company.NumbersInInvoice">Company.NumbersInInvoice</see> 
        ''' is set to zero);
        ''' b) <see cref="Date">Date</see> concetanated with the <see cref="Number">running number</see>, e.g. 20151010-123
        ''' (if <see cref="General.Company.AddDateToInvoiceNumber">Company.AddDateToInvoiceNumber</see> is set to true);
        ''' c) the <see cref="Number">running number</see> prefixed with '0', e.g. 00015 
        ''' (if <see cref="General.Company.AddDateToInvoiceNumber">Company.AddDateToInvoiceNumber</see> 
        ''' is set to false and <see cref="General.Company.NumbersInInvoice">Company.NumbersInInvoice</see> 
        ''' is set to a positive number).
        ''' Invoice formating rule is initialized from the company's settings, when a new invoice instance 
        ''' is created, and cannot be changed afterwards.
        ''' Invoice formating rule is defined by the properties <see cref="AddDateToNumberOptionWasUsed">AddDateToNumberOptionWasUsed</see>
        ''' and <see cref="NumbersInInvoice">NumbersInInvoice</see>.
        ''' Formating is done by the method <see cref="UpdateFullNumber">UpdateFullNumber</see>.
        ''' Value is not persisted. Value can be derived from the encapsulated 
        ''' <see cref="General.JournalEntry.DocNumber">journal entry DocNumber property</see>
        ''' by removing serial code part from the begining.</remarks>
        Public ReadOnly Property FullNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FullNumber.Trim
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="Date">invoice date</see> should be used when formating 
        ''' the <see cref="FullNumber">invoice full number</see>.
        ''' </summary>
        ''' <remarks>Value is initialized, when a new invoice instance is created,
        ''' using <see cref="General.Company.AddDateToInvoiceNumber">Company.AddDateToInvoiceNumber</see> 
        ''' property value.
        ''' Value is stored in the database field invoicesmade.AddDateToNumberOptionWasUsed.</remarks>
        Public ReadOnly Property AddDateToNumberOptionWasUsed() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AddDateToNumberOptionWasUsed
            End Get
        End Property

        ''' <summary>
        ''' Gets a minimum length of the <see cref="FullNumber">invoice full number</see>
        ''' (the lacking space is filled with '0' chars, e.g. 00015).
        ''' </summary>
        ''' <remarks>Value is initialized, when a new invoice instance is created,
        ''' using <see cref="General.Company.NumbersInInvoice">Company.NumbersInInvoice</see> property value.
        ''' Value is stored in the database field invoicesmade.NumbersInInvoice.</remarks>
        Public ReadOnly Property NumbersInInvoice() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NumbersInInvoice
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a content (description) of the invoice.
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
        ''' Gets or sets a type of the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.InvoiceType.</remarks>
        Public Property [Type]() As InvoiceType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As InvoiceType)
                CanWriteProperty(True)
                If _Type <> value Then
                    _Type = value
                    PropertyHasChanged()
                    PropertyHasChanged("TypeHumanReadable")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a type of the invoice as a human readable string.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.InvoiceType.</remarks>
        <LocalizedEnumField(GetType(InvoiceType), False, "")> _
        Public Property TypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Utilities.ConvertLocalizedName(_Type)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                Dim newValue As InvoiceType = InvoiceType.Normal
                Try
                    newValue = Utilities.ConvertLocalizedName(Of InvoiceType)(value)
                Catch ex As Exception
                End Try
                If newValue <> _Type Then
                    _Type = newValue
                    PropertyHasChanged()
                    PropertyHasChanged("Type")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the invoice lines (items) collection.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property InvoiceItems() As InvoiceMadeItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InvoiceItems
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable view of the invoice lines (items) collection.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property InvoiceItemsSorted() As SortedBindingList(Of InvoiceMadeItem)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _SortedList Is Nothing Then _SortedList = _
                    New SortedBindingList(Of InvoiceMadeItem)(_InvoiceItems)
                Return _SortedList
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a currency of the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.CurrencyCode.</remarks>
        <CurrencyFieldAttribute(ValueRequiredLevel.Mandatory)> _
        Public Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If CurrencyCodeIsReadOnly Then Exit Property

                If value Is Nothing Then value = ""

                If _CurrencyCode.Trim <> value.Trim Then

                    _CurrencyCode = value.Trim
                    PropertyHasChanged()

                    If Not CurrencyRateIsReadOnly Then

                        Dim newRate As Double
                        If IsBaseCurrency(_CurrencyCode, GetCurrentCompany.BaseCurrency) Then
                            newRate = 1
                        Else
                            newRate = 0
                        End If

                        If CRound(_CurrencyRate, ROUNDCURRENCYRATE) <> _
                            CRound(newRate, ROUNDCURRENCYRATE) Then

                            _CurrencyRate = CRound(newRate, ROUNDCURRENCYRATE)
                            PropertyHasChanged("CurrencyRate")

                        End If

                    End If

                    If CRound(_CurrencyRate, ROUNDCURRENCYRATE) > 0 Then
                        _InvoiceItems.UpdateCurrencyRate(_CurrencyRate, _CurrencyCode)
                    End If

                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a currency rate for the invoice currency.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.CurrencyRate.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDCURRENCYRATE)> _
        Public Property CurrencyRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRate, ROUNDCURRENCYRATE)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CurrencyRateIsReadOnly Then Exit Property
                If CRound(_CurrencyRate, ROUNDCURRENCYRATE) <> CRound(value, ROUNDCURRENCYRATE) Then
                    _CurrencyRate = CRound(value, ROUNDCURRENCYRATE)
                    PropertyHasChanged()
                    If CRound(_CurrencyRate, ROUNDCURRENCYRATE) > 0 Then
                        _InvoiceItems.UpdateCurrencyRate(_CurrencyRate, _CurrencyCode)
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an invoice language code.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.LanguageCode.</remarks>
        <LanguageCodeField(ValueRequiredLevel.Mandatory, True)> _
        Public Property LanguageCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)

                CanWriteProperty(True)

                If value Is Nothing Then value = ""

                If _LanguageCode.Trim.ToUpper <> value.Trim.ToUpper Then

                    _LanguageName = GetLanguageName(value.Trim, False)

                    If String.IsNullOrEmpty(_LanguageName.Trim) Then
                        _LanguageCode = ""
                    Else
                        _LanguageCode = value.Trim.ToUpper
                    End If

                    PropertyHasChanged()
                    PropertyHasChanged("LanguageName")

                    _InvoiceItems.UpdateLanguage(_LanguageCode)

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an invoice language name.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.LanguageCode.</remarks>
        <LanguageNameFieldAttribute(ValueRequiredLevel.Mandatory, True)> _
        Public Property LanguageName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageName
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)

                CanWriteProperty(True)

                If value Is Nothing Then value = ""

                If _LanguageName.Trim.ToUpper <> value.Trim.ToUpper Then
                    _LanguageCode = GetLanguageCode(value.Trim, False)
                    If String.IsNullOrEmpty(_LanguageCode.Trim) Then
                        _LanguageName = ""
                    Else
                        _LanguageName = value.Trim.ToUpper
                    End If
                    PropertyHasChanged()
                    PropertyHasChanged("LanguageCode")
                    _InvoiceItems.UpdateLanguage(_LanguageCode)
                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets custom invoice info, that is ment for the client (payer), in base language.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.CustomInfo.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property CustomInfo() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CustomInfo.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CustomInfo.Trim <> value.Trim Then
                    _CustomInfo = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets custom invoice info, that is ment for the client (payer), in 
        ''' <see cref="LanguageCode">invoice language</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.CustomInfoAltLng.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property CustomInfoAltLng() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CustomInfoAltLng.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CustomInfoAltLng.Trim <> value.Trim Then
                    _CustomInfoAltLng = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets VAT exempt info, that is ment for the client (payer), in base language.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.VatExemptions.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property VatExemptInfo() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _VatExemptInfo.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _VatExemptInfo.Trim <> value.Trim Then
                    _VatExemptInfo = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets VAT exempt info, that is ment for the client (payer), in 
        ''' <see cref="LanguageCode">invoice language</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.VatExemptionsAltLng.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property VatExemptInfoAltLng() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _VatExemptInfoAltLng.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _VatExemptInfoAltLng.Trim <> value.Trim Then
                    _VatExemptInfoAltLng = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets internal comments for the invoice (accountant comments of different kinds).
        ''' </summary>
        ''' <remarks>Value is stored in the database field invoicesmade.CommentsInternal.</remarks>
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
        ''' Gets an external invoice ID (when the invoice data is imported from an external data source).
        ''' </summary>
        ''' <remarks>Should be unique or empty. If using multiple data sources (systems, applications),
        ''' each datasource should have unique prefix.
        ''' Value is stored in the database field invoicesmade.ExternalID.</remarks>
        Public ReadOnly Property ExternalID() As String _
            Implements ISyncable.ExternalID
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ExternalID.Trim
            End Get
        End Property


        ''' <summary>
        ''' Gets the total value of the goods/services sold (excluding VAT and discount) in the base currency.
        ''' </summary>
        ''' <remarks>Sum over <see cref="InvoiceMadeItem.SumLTL">the items' SumLTL property</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total VAT value (excluding discount part) in the base currency.
        ''' </summary>
        ''' <remarks>Sum over <see cref="InvoiceMadeItem.SumVatLTL">the items' SumVatLTL property</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumVatLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVatLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total value of the goods/services sold (including VAT, excluding discount) 
        ''' in the base currency.
        ''' </summary>
        ''' <remarks>Sum over <see cref="InvoiceMadeItem.SumTotalLTL">the items' SumTotalLTL property</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumTotalLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotalLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total value of the goods/services sold (excluding VAT and discount)
        ''' in <see cref="CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Sum over <see cref="InvoiceMadeItem.Sum">the items' Sum property</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total VAT value (excluding discount part) in <see cref="CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Sum over <see cref="InvoiceMadeItem.SumVat">the items' SumVat property</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumVat() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVat)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total value of the goods/services sold (including VAT, excluding discount)
        ''' in <see cref="CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Sum over <see cref="InvoiceMadeItem.SumTotal">the items' SumTotal property</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotal)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total discount value (excluding VAT) in <see cref="CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Sum over <see cref="InvoiceMadeItem.Discount">the items' Discount property</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumDiscount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumDiscount)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total discount VAT value in <see cref="CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Sum over <see cref="InvoiceMadeItem.DiscountVat">the items' DiscountVat property</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumDiscountVat() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumDiscountVat)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total discount value (excluding VAT) in the base currency.
        ''' </summary>
        ''' <remarks>Sum over <see cref="InvoiceMadeItem.DiscountLTL">the items' DiscountLTL property</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumDiscountLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumDiscountLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total discount VAT value in the base currency.
        ''' </summary>
        ''' <remarks>Sum over <see cref="InvoiceMadeItem.DiscountVatLTL">the items' DiscountVatLTL property</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumDiscountVatLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumDiscountVatLTL)
            End Get
        End Property


        ''' <summary>
        ''' Whether <see cref="AccountPayer">AccountPayer</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountPayerIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologyValidator.FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Whether <see cref="CurrencyCode">CurrencyCode</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrencyCodeIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologyValidator.FinancialDataCanChange _
                    OrElse Not _ChronologyValidator.ChildrenFinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Whether <see cref="CurrencyRate">CurrencyRate</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrencyRateIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologyValidator.FinancialDataCanChange _
                    OrElse Not _ChronologyValidator.ChildrenFinancialDataCanChange
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (_InvoiceItems.Count > 0 _
                    OrElse Not StringIsNullOrEmpty(_Content) _
                    OrElse Not StringIsNullOrEmpty(_CustomInfo) _
                    OrElse Not StringIsNullOrEmpty(_CustomInfoAltLng) _
                    OrElse Not StringIsNullOrEmpty(_CommentsInternal))
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _InvoiceItems.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid AndAlso _InvoiceItems.IsValid
            End Get
        End Property



        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            End If
            If Not _InvoiceItems.IsValid Then
                result = AddWithNewLine(result, _InvoiceItems.GetAllBrokenRules, False)
            End If
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            End If
            If _InvoiceItems.HasWarnings() Then
                result = AddWithNewLine(result, _InvoiceItems.GetAllWarnings, False)
            End If
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return (MyBase.BrokenRulesCollection.WarningCount > 0 _
                OrElse _InvoiceItems.HasWarnings())
        End Function


        Public Overrides Function Save() As InvoiceMade

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Return MyBase.Save

        End Function


        ''' <summary>
        ''' Adds a new <see cref="InvoiceMadeItem">InvoiceMadeItem</see> with 
        ''' an <see cref="InvoiceAdapters.IInvoiceAdapter">attached operation</see>.
        ''' </summary>
        ''' <param name="newAttachedObject">An attached operation.</param>
        ''' <param name="regionalizedDictionary">A <see cref="RegionalInfoDictionary">RegionalInfoDictionary</see> 
        ''' instance to be used for setting regional names and prices.</param>
        ''' <param name="addVatExemptions">Whether VAT exempt info should be added 
        ''' to the <see cref="VatExemptInfo">VatExemptInfo</see> and 
        ''' <see cref="VatExemptInfoAltLng">VatExemptInfoAltLng</see> properties 
        ''' using regionalizedDictionary provided.</param>
        ''' <returns>The <see cref="InvoiceMadeItem">InvoiceMadeItem</see> instance that was added to the invoice.</returns>
        ''' <remarks></remarks>
        Public Function AttachNewObject(ByVal newAttachedObject As IInvoiceAdapter, _
            Optional ByVal regionalizedDictionary As RegionalInfoDictionary = Nothing, _
            Optional ByVal addVatExemptions As Boolean = False) As InvoiceMadeItem

            If newAttachedObject Is Nothing Then
                Throw New Exception(My.Resources.Documents_InvoiceMade_NewAttachedOperationIsNull)
            End If

            If Not _ChronologyValidator.BaseValidator.FinancialDataCanChange Then
                Throw New Exception(String.Format(My.Resources.Documents_InvoiceMade_FinancialDataCannotChangeFull, _
                    vbCrLf, _ChronologyValidator.BaseValidator.FinancialDataCanChangeExplanation))
            End If

            _InvoiceItems.CheckIfNewAdapterCompatibleWithTheExistingAdapters(newAttachedObject)

            newAttachedObject.SetInvoiceDate(_Date)

            Dim item As InvoiceMadeItem = InvoiceMadeItem.NewInvoiceMadeItem(newAttachedObject)

            _InvoiceItems.Add(item)

            RegionalizeNewInvoiceMadeItem(item, regionalizedDictionary, addVatExemptions)

            _ChronologyValidator.MergeNewValidationItem(newAttachedObject.ChronologyValidator)

            Return item

        End Function

        Private Sub RegionalizeNewInvoiceMadeItem(ByRef item As InvoiceMadeItem, _
            ByVal regionalizedDictionary As RegionalInfoDictionary, ByVal addVatExemptions As Boolean)

            If regionalizedDictionary Is Nothing Then Exit Sub

            Dim asRegionalizable As IRegionalDataObject = Nothing
            Try
                asRegionalizable = DirectCast(item.AttachedObjectValue, IRegionalDataObject)
            Catch ex As Exception
                Exit Sub
            End Try
            If asRegionalizable Is Nothing Then Exit Sub

            item.SetRegionalContents(regionalizedDictionary, True)

            regionalizedDictionary.GetSalePrice(asRegionalizable.RegionalObjectType, _
                asRegionalizable.RegionalObjectID, _CurrencyCode, item.UnitValue)

            If addVatExemptions Then

                Dim exemption As String = ""
                Dim exemptionLT As String = ""

                If regionalizedDictionary.GetVatExempts(asRegionalizable.RegionalObjectType, _
                    asRegionalizable.RegionalObjectID, _LanguageCode, exemptionLT, exemption) Then

                    _VatExemptInfo = AddWithNewLine(_VatExemptInfo, exemptionLT, False)
                    _VatExemptInfoAltLng = AddWithNewLine(_VatExemptInfoAltLng, exemption, False)

                    PropertyHasChanged("VatExemptInfo")
                    PropertyHasChanged("VatExemptInfoAltLng")

                End If

            End If

        End Sub


        ''' <summary>
        ''' Gets an email address that should be used when sending the invoice to the client.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetClientEmail() As String _
            Implements IClientEmailProvider.GetClientEmail
            If _Payer Is Nothing OrElse _Payer.IsEmpty Then Return ""
            Return _Payer.Email
        End Function

        ''' <summary>
        ''' Gets an addressee (Payer) name that should be used when sending the invoice to the client.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetClientName() As String Implements IClientEmailProvider.GetClientName
            If _Payer Is Nothing OrElse _Payer.IsEmpty Then Return ""
            Return _Payer.Name
        End Function


        Private Sub UpdateFullNumber(ByVal raisePropertyHasChanged As Boolean)

            Dim newNumber As String = ""

            If _AddDateToNumberOptionWasUsed Then
                newNumber = String.Format("{0}-{1}", _Date.ToString("yyyyMMdd"), _Number)
            Else
                If _NumbersInInvoice < 1 Then
                    newNumber = _Number.ToString
                Else
                    newNumber = GetMinLengthString(_Number.ToString, _NumbersInInvoice, "0"c)
                End If
            End If

            If newNumber.Trim <> _FullNumber.Trim Then
                _FullNumber = newNumber.Trim
                If raisePropertyHasChanged Then PropertyHasChanged("FullNumber")
            End If

        End Sub


        Private Sub InvoiceMadeItems_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) _
            Handles _InvoiceItems.ListChanged

            CalculateSubTotals(True)

            If e.ListChangedType = ComponentModel.ListChangedType.ItemDeleted Then
                _ChronologyValidator = ComplexChronologicValidator.GetComplexChronologicValidator( _
                    _ChronologyValidator, _InvoiceItems.GetChronologyValidators())
            End If

        End Sub

        Private Sub CalculateSubTotals(ByVal raisePropertChangedEvents As Boolean)

            _SumLTL = 0
            _SumVatLTL = 0
            _Sum = 0
            _SumVat = 0
            _SumDiscount = 0
            _SumDiscountVat = 0
            _SumDiscountLTL = 0
            _SumDiscountVatLTL = 0

            For Each i As InvoiceMadeItem In _InvoiceItems
                _SumLTL = CRound(_SumLTL + i.SumLTL - i.DiscountLTL)
                _SumVatLTL = CRound(_SumVatLTL + i.SumVatLTL - i.DiscountVatLTL)
                _Sum = CRound(_Sum + i.Sum - i.Discount)
                _SumVat = CRound(_SumVat + i.SumVat - i.DiscountVat)
                _SumDiscount = CRound(_SumDiscount + i.Discount)
                _SumDiscountVat = CRound(_SumDiscountVat + i.DiscountVat)
                _SumDiscountLTL = CRound(_SumDiscountLTL + i.DiscountLTL)
                _SumDiscountVatLTL = CRound(_SumDiscountVatLTL + i.DiscountVatLTL)
            Next

            _SumTotalLTL = CRound(_SumLTL + _SumVatLTL)
            _SumTotal = CRound(_Sum + _SumVat)

            If raisePropertChangedEvents Then
                PropertyHasChanged("SumLTL")
                PropertyHasChanged("SumVatLTL")
                PropertyHasChanged("Sum")
                PropertyHasChanged("SumVat")
                PropertyHasChanged("SumDiscount")
                PropertyHasChanged("SumDiscountVat")
                PropertyHasChanged("SumDiscountLTL")
                PropertyHasChanged("SumDiscountVatLTL")
                PropertyHasChanged("SumTotalLTL")
                PropertyHasChanged("SumTotal")
            End If

        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As InvoiceMade = DirectCast(MyBase.GetClone(), InvoiceMade)
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
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Friend Sub RestoreChildListsHandles()
            Try
                RemoveHandler _InvoiceItems.ListChanged, AddressOf InvoiceMadeItems_Changed
            Catch ex As Exception
            End Try
            AddHandler _InvoiceItems.ListChanged, AddressOf InvoiceMadeItems_Changed
        End Sub


        ''' <summary>
        ''' Gets a human friendly file name to be used when saving an invoice as a document (e.g. pdf fo email).
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetFileName() As String
            Return String.Format("Invoice_{0}_No_{1}{2}", _Date.ToString("yyyy_MM_dd"), _
                _Serial, _FullNumber)
        End Function


        ''' <summary>
        ''' Gets invoice data as a data transfer object.
        ''' </summary>
        ''' <param name="systemGuid">An ID of the system that generates the data transfer object.
        ''' Used to distinguish data transfer within and outside a system (an application instance).
        ''' Use <see cref="System.Guid">Guid.ToString</see> to generate an application instance Guid.</param>
        ''' <remarks>Used to implement data exchange with other applications.</remarks>
        Public Function GetInvoiceInfo(ByVal systemGuid As String) As InvoiceInfo.InvoiceInfo

            Dim result As New InvoiceInfo.InvoiceInfo

            result.AddDateToNumberOptionWasUsed = Me.AddDateToNumberOptionWasUsed
            result.CommentsInternal = Me._CommentsInternal
            result.Content = Me._Content
            result.CurrencyCode = Me._CurrencyCode
            result.CurrencyRate = Me._CurrencyRate
            result.CustomInfo = Me._CustomInfo
            result.CustomInfoAltLng = Me._CustomInfoAltLng
            result.Date = Me._Date
            result.Discount = Me._SumDiscount
            result.DiscountLTL = Me._SumDiscountLTL
            result.DiscountVat = Me._SumDiscountVat
            result.DiscountVatLTL = Me._SumDiscountVatLTL
            result.ExternalID = Me._ExternalID
            result.FullNumber = Me._FullNumber
            result.ID = Me._ID.ToString
            result.LanguageCode = Me._LanguageCode
            result.Number = Me._Number
            result.NumbersInInvoice = Me._NumbersInInvoice
            result.ProjectCode = ""
            result.Serial = Me._Serial
            result.SystemGuid = systemGuid
            result.Sum = Me._Sum
            result.SumLTL = Me._SumLTL
            result.SumReceived = 0
            result.SumTotal = Me._SumTotal
            result.SumTotalLTL = Me._SumTotalLTL
            result.SumVat = Me._SumVat
            result.SumVatLTL = Me._SumVatLTL
            result.UpdateDate = Me._UpdateDate
            result.VatExemptions = Me._VatExemptInfo
            result.VatExemptionsAltLng = Me._VatExemptInfoAltLng

            If Not _Payer Is Nothing AndAlso Not _Payer.IsEmpty Then
                result.Payer.Address = _Payer.Address
                result.Payer.BalanceAtBegining = 0
                result.Payer.BreedCode = _Payer.InternalCode
                result.Payer.Code = _Payer.Code
                result.Payer.CodeVAT = _Payer.CodeVAT
                result.Payer.Contacts = _Payer.ContactInfo
                result.Payer.CurrencyCode = _Payer.CurrencyCode
                result.Payer.Email = _Payer.Email
                result.Payer.ExternalID = ""
                result.Payer.ID = _Payer.ID.ToString
                result.Payer.IsClient = _Payer.IsClient
                result.Payer.IsCodeLocal = False
                result.Payer.IsNaturalPerson = _Payer.IsNaturalPerson
                result.Payer.IsObsolete = _Payer.IsObsolete
                result.Payer.IsSupplier = _Payer.IsSupplier
                result.Payer.IsWorker = _Payer.IsWorker
                result.Payer.LanguageCode = _Payer.LanguageCode
                result.Payer.Name = _Payer.Name
                result.Payer.VatExemption = ""
                result.Payer.VatExemptionAltLng = ""
            End If

            result.InvoiceItems = Me._InvoiceItems.GetInvoiceItemInfoList

            Return result

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Documents_InvoiceMade_ToString, _
                _Date.ToString("yyyy-MM-dd"), _Serial, _FullNumber, _ID.ToString(), _Content)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("Content"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("Serial"))
            ValidationRules.AddRule(AddressOf CommonValidation.IntegerFieldValidation, _
                New Validation.RuleArgs("Number"))
            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyFieldValidation, _
                New Validation.RuleArgs("CurrencyCode"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Validation.RuleArgs("CurrencyRate"))
            ValidationRules.AddRule(AddressOf CommonValidation.LanguageNameValidation, _
                New Validation.RuleArgs("LanguageName"))
            ValidationRules.AddRule(AddressOf CommonValidation.PersonFieldValidation, _
                New Validation.RuleArgs("Payer"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("CustomInfo"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("CustomInfoAltLng"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("VatExemptInfo"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("VatExemptInfoAltLng"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("CommentsInternal"))
            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "ChronologyValidator"))

            ValidationRules.AddRule(AddressOf SumValidation, "Sum")
            ValidationRules.AddRule(AddressOf SumDiscountValidation, "SumDiscount")
            ValidationRules.AddRule(AddressOf AccountPayerValidation, "AccountPayer")

            ValidationRules.AddDependantProperty("Type", "Sum", False)
            ValidationRules.AddDependantProperty("Type", "SumDiscount", False)
            ValidationRules.AddDependantProperty("Payer", "AccountPayer", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that any items exist.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMade = DirectCast(target, InvoiceMade)

            If Not valObj._InvoiceItems.Count > 0 Then

                e.Description = My.Resources.Documents_InvoiceMade_NoItems
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf valObj._Type = InvoiceType.Credit AndAlso Not CRound(valObj._Sum) < 0 Then

                e.Description = My.Resources.Documents_InvoiceMade_SumInvalidForCreditInvoice
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf valObj._Type <> InvoiceType.Credit AndAlso Not CRound(valObj._Sum) > 0 Then

                e.Description = My.Resources.Documents_InvoiceMade_SumInvalidForDebitInvoice
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that discount is possible.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumDiscountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMade = DirectCast(target, InvoiceMade)

            If valObj._Type <> InvoiceType.Normal AndAlso CRound(valObj._SumDiscount) <> 0 Then

                e.Description = My.Resources.Documents_InvoiceMade_DiscountInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf CRound(valObj._SumDiscount, 2) < 0 Then

                e.Description = My.Resources.Documents_InvoiceMade_DiscountSumInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that AccountPayer is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountPayerValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMade = DirectCast(target, InvoiceMade)

            If valObj._Payer Is Nothing OrElse valObj._Payer.IsEmpty OrElse _
                Not valObj._Payer.AccountAgainstBankBuyer > 0 Then
                Return CommonValidation.AccountFieldValidation(target, e)
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Documents.InvoiceMade2")
        End Sub

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.InvoiceMade2")
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.InvoiceMade1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.InvoiceMade3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.InvoiceMade3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new instance of InvoiceMade.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function NewInvoiceMade() As InvoiceMade
            Return New InvoiceMade(False)
        End Function

        ''' <summary>
        ''' Gets a doomy instance of InvoiceMade (to be used as sample data, e.g. for invoice form preview).
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function DoomyInvoiceMade() As InvoiceMade
            Return New InvoiceMade(True)
        End Function

        ''' <summary>
        ''' Gets a new InvoiceMade instance using data transfer object.
        ''' </summary>
        ''' <param name="info">A data transfer object that contains invoice data.</param>
        ''' <param name="systemGuid">An ID of the system that requests the creation of the invoice 
        ''' using the data transfer object. Used to distinguish data transfer within and outside a system (an application instance).
        ''' Use <see cref="System.Guid">Guid.ToString</see> to generate an application instance Guid.</param>
        ''' <param name="useImportedObjectExternalID">Whether to use the data transfer object ExternalID
        ''' property when setting <see cref="ExternalID">invoice ExternalID property</see>
        ''' (otherwise the ID property of the data transfer object is used).</param>
        ''' <param name="clientList">Lookup list for person data.</param>
        ''' <param name="accountList">a list of company accounts to validate incomming data account id's</param>
        ''' <param name="vatSchemaList">a list of company VAT declaration schemas to set a schema by schema ID</param>
        ''' <param name="unknownPerson">Output param. Is set to data transfer object person data,
        ''' if the person is not identified with any person in the company database.
        ''' Used for further data import (new person data).</param>
        ''' <remarks></remarks>
        Public Shared Function NewInvoiceMade(ByVal info As InvoiceInfo.InvoiceInfo, _
            ByVal systemGuid As String, ByVal useImportedObjectExternalID As Boolean, _
            ByVal clientList As PersonInfoList, ByVal accountList As AccountInfoList, _
            ByVal vatSchemaList As VatDeclarationSchemaInfoList, serviceList As ServiceInfoList, _
            ByRef unknownPerson As InvoiceInfo.ClientInfo) As InvoiceMade

            Dim result As New InvoiceMade(info, systemGuid, useImportedObjectExternalID, _
                clientList, accountList, vatSchemaList, serviceList)

            If (result.Payer Is Nothing OrElse result.Payer.IsEmpty) AndAlso _
                Not info.Payer Is Nothing AndAlso Not StringIsNullOrEmpty(info.Payer.Code) Then
                unknownPerson = info.Payer
            Else
                unknownPerson = Nothing
            End If

            Return result

        End Function

        ''' <summary>
        ''' Gets a new InvoiceMade instance using proforma invoice data as template.
        ''' </summary>
        ''' <param name="proformaInvoiceId">an ID of the proforma invoice to use as a template</param>
        ''' <remarks></remarks>
        Public Shared Function NewInvoiceMade(ByVal proformaInvoiceId As Integer) As InvoiceMade
            Return DataPortal.Create(Of InvoiceMade)(New Criteria(proformaInvoiceId))
        End Function


        ''' <summary>
        ''' Gets an existing instance of InvoiceMade from a database.
        ''' </summary>
        ''' <param name="nID">An ID of the InvoiceMade to get.</param>
        ''' <remarks></remarks>
        Public Shared Function GetInvoiceMade(ByVal nID As Integer) As InvoiceMade
            Return DataPortal.Fetch(Of InvoiceMade)(New Criteria(nID))
        End Function


        Friend Shared Function GetOrCreateInvoiceMadeChild(ByVal info As InvoiceInfo.InvoiceInfo, _
            ByVal useImportedObjectExternalID As Boolean, ByVal clientList As PersonInfoList, _
            ByVal accountList As AccountInfoList, ByVal vatSchemaList As VatDeclarationSchemaInfoList, _
            serviceList As ServiceInfoList, ByRef unknownPerson As InvoiceInfo.ClientInfo) As InvoiceMade

            If useImportedObjectExternalID AndAlso StringIsNullOrEmpty(info.ExternalID) Then
                Throw New Exception("ExternalID is not specified.")
            ElseIf Not useImportedObjectExternalID AndAlso StringIsNullOrEmpty(info.ID) Then
                Throw New Exception("ID is not specified.")
            End If

            Dim myComm As New SQLCommand("FetchInvoiceMadeIDByExternalID")
            If useImportedObjectExternalID Then
                myComm.AddParam("?MN", info.ExternalID.Trim)
            Else
                myComm.AddParam("?MN", info.ID.Trim)
            End If

            Dim result As New InvoiceMade
            result.MarkAsChild()

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 Then
                    result.DoFetch(CIntSafe(myData.Rows(0).Item(0), 0))
                End If

            End Using

            result.Create(info, "123456", useImportedObjectExternalID, clientList, accountList, _
                vatSchemaList, serviceList)

            If result.Payer = PersonInfo.Empty AndAlso Not info.Payer Is Nothing Then
                unknownPerson = info.Payer
            Else
                unknownPerson = Nothing
            End If

            Return result

        End Function


        ''' <summary>
        ''' Deletes an existing instance of InvoiceMade from a database.
        ''' </summary>
        ''' <param name="id">An ID of the InvoiceMade to delete.</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteInvoiceMade(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
        End Sub


        Public Function GetInvoiceMadeCopy() As InvoiceMade

            Dim result As InvoiceMade = Me.Clone
            result._ID = -1
            result._Number = 0
            result._Date = Today
            result._FullNumber = ""
            result._InvoiceItems.MarkAsCopy()

            Dim baseValidator As SimpleChronologicValidator = _
                SimpleChronologicValidator.NewSimpleChronologicValidator( _
                Utilities.ConvertLocalizedName(DocumentType.InvoiceMade), Nothing)

            result._ChronologyValidator = ComplexChronologicValidator. _
                NewComplexChronologicValidator(baseValidator.CurrentOperationName, _
                baseValidator, Nothing, result._InvoiceItems.GetChronologyValidators())

            result.MarkNew()

            result.ValidationRules.CheckRules()

            Return result

        End Function


        ''' <summary>
        ''' Gets an existing InvoiceMade instance from a database bypassing DataPortal.
        ''' </summary>
        ''' <param name="id">an ID of the invoice to get</param>
        ''' <remarks>Should only be used on server side.
        ''' Required by the <see cref="BusinessObjectCollection(of T)">BusinessObjectCollection</see>
        ''' in order to fetch multiple invoices by a single request.</remarks>
        Friend Shared Function GetInvoiceMadeChild(ByVal id As Integer) As InvoiceMade
            Return New InvoiceMade(id)
        End Function


        Private Sub New()
            ' require use of factory methods

        End Sub

        Private Sub New(ByVal doomyInstance As Boolean)
            Create(doomyInstance)
        End Sub

        Private Sub New(ByVal info As InvoiceInfo.InvoiceInfo, ByVal systemGuid As String, _
            ByVal useImportedObjectExternalID As Boolean, ByVal clientList As PersonInfoList, _
            ByVal accountList As AccountInfoList, ByVal vatSchemaList As VatDeclarationSchemaInfoList, _
            serviceList As ServiceInfoList)
            Create(info, systemGuid, useImportedObjectExternalID, clientList, accountList, _
            vatSchemaList, serviceList)
        End Sub

        Private Sub New(ByVal nID As Integer)
            MarkAsChild()
            DoFetch(nID)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer
            Private _DefaultVatRate As Double
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public ReadOnly Property DefaultVatRate() As Double
                Get
                    Return _DefaultVatRate
                End Get
            End Property
            Public Sub New(ByVal nID As Integer, ByVal nDefaultVatRate As Double)
                _ID = nID
                _DefaultVatRate = nDefaultVatRate
            End Sub
            Public Sub New(ByVal nID As Integer)
                _ID = nID
                _DefaultVatRate = 0
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Dim cc As ApskaitaObjects.Settings.CompanyInfo = GetCurrentCompany()

            _AddDateToNumberOptionWasUsed = cc.AddDateToInvoiceNumber
            _NumbersInInvoice = cc.NumbersInInvoice
            _Content = cc.DefaultInvoiceMadeContent

            Dim baseValidator As SimpleChronologicValidator = SimpleChronologicValidator. _
                NewSimpleChronologicValidator(Utilities.ConvertLocalizedName(DocumentType.InvoiceMade), Nothing)

            Dim proforma As ProformaInvoiceMade = ProformaInvoiceMade.GetProformaInvoiceMadeChild(criteria.ID)

            _CommentsInternal = proforma.CommentsInternal
            _Content = cc.DefaultInvoiceMadeContent
            _CurrencyCode = proforma.CurrencyCode
            _LanguageCode = proforma.LanguageCode
            _LanguageName = proforma.LanguageName
            _Payer = proforma.Payer
            _AccountPayer = proforma.Payer.AccountAgainstBankBuyer
            _Type = InvoiceType.Normal

            _InvoiceItems = InvoiceMadeItemList.NewInvoiceMadeItemList(proforma.InvoiceItems, Me, baseValidator)

            CalculateSubTotals(False)

            _ChronologyValidator = ComplexChronologicValidator.GetComplexChronologicValidator( _
                _ID, _Date, baseValidator.CurrentOperationName, baseValidator, _
                Nothing, _InvoiceItems.GetChronologyValidators())

            MarkNew()
            ValidationRules.CheckRules()

        End Sub

        Private Sub Create(ByVal doomyInstance As Boolean)

            If doomyInstance Then
                InitializeDoomyInstance()
            Else
                InitializeNewInstance()
            End If

        End Sub

        Private Sub InitializeNewInstance()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Dim cc As ApskaitaObjects.Settings.CompanyInfo = GetCurrentCompany()

            _AddDateToNumberOptionWasUsed = cc.AddDateToInvoiceNumber
            _NumbersInInvoice = cc.NumbersInInvoice
            _Content = cc.DefaultInvoiceMadeContent

            Dim baseValidator As SimpleChronologicValidator = SimpleChronologicValidator. _
                NewSimpleChronologicValidator(Utilities.ConvertLocalizedName(DocumentType.InvoiceMade), Nothing)
            _ChronologyValidator = ComplexChronologicValidator.NewComplexChronologicValidator( _
                baseValidator.CurrentOperationName, baseValidator, Nothing, Nothing)

            _InvoiceItems = InvoiceMadeItemList.NewInvoiceMadeItemList(Me)

            ValidationRules.CheckRules()

        End Sub

        Private Sub InitializeDoomyInstance()

            Dim r As New Random

            _IsDoomyInvoice = True

            Dim cc As ApskaitaObjects.Settings.CompanyInfo = GetCurrentCompany()

            _AddDateToNumberOptionWasUsed = cc.AddDateToInvoiceNumber
            _NumbersInInvoice = cc.NumbersInInvoice

            _CommentsInternal = My.Resources.Documents_InvoiceMade_DoomyCommentsInternal
            _Content = My.Resources.Documents_InvoiceMade_DoomyContent
            _CurrencyCode = My.Resources.Documents_InvoiceMade_DoomyInvoiceCurrency
            _CurrencyRate = (r.NextDouble() + 0.1) * 3 ' somewhere within range 0.3 - 3.3
            _CustomInfo = My.Resources.Documents_InvoiceMade_DoomyCustomInfo
            _CustomInfoAltLng = My.Resources.Documents_InvoiceMade_DoomyCustomInfoAltLng
            _Date = Today
            _LanguageCode = My.Resources.Documents_InvoiceMade_DoomyInvoiceLanguage
            _Number = 123
            _Payer = PersonInfo.DoomyPersonInfo
            _Serial = My.Resources.Documents_InvoiceMade_DoomySerial

            UpdateFullNumber(False)

            _InvoiceItems = InvoiceMadeItemList.DoomyInvoiceMadeItemList(r, Me)

            CalculateSubTotals(False)

            Dim baseValidator As SimpleChronologicValidator = SimpleChronologicValidator. _
                NewSimpleChronologicValidator(Utilities.ConvertLocalizedName(DocumentType.InvoiceMade), Nothing)

            _ChronologyValidator = ComplexChronologicValidator. _
                NewComplexChronologicValidator(baseValidator.CurrentOperationName, _
                baseValidator, Nothing, Nothing)

        End Sub

        Private Sub Create(ByVal info As InvoiceInfo.InvoiceInfo, _
            ByVal systemGuid As String, ByVal useImportedObjectExternalID As Boolean, _
            ByVal clientList As PersonInfoList, ByVal accountList As AccountInfoList, _
            ByVal vatSchemaList As VatDeclarationSchemaInfoList, serviceList As ServiceInfoList)

            ' data transfer within the same system (an application instance)
            If info.SystemGuid.Trim = systemGuid.Trim Then

                _Number = 0
                _ExternalID = ""

            Else

                _Number = info.Number

                If useImportedObjectExternalID Then
                    Me._ExternalID = info.ExternalID
                Else
                    Me._ExternalID = info.ID
                End If

            End If

            Me._AddDateToNumberOptionWasUsed = info.AddDateToNumberOptionWasUsed
            Me._CommentsInternal = info.CommentsInternal
            Me._Content = info.Content
            If StringIsNullOrEmpty(Me._Content) Then _
                Me._Content = GetCurrentCompany().DefaultInvoiceMadeContent
            If Not StringIsNullOrEmpty(info.ProjectCode.Trim) Then _
                _Content = _Content & " (projektas - " & info.ProjectCode.Trim & ")"
            Me._CurrencyCode = info.CurrencyCode
            Me._CurrencyRate = CRound(info.CurrencyRate, ROUNDCURRENCYRATE)
            Me._CustomInfo = info.CustomInfo
            Me._CustomInfoAltLng = info.CustomInfoAltLng
            Me._Date = info.Date
            Me._LanguageCode = info.LanguageCode
            If StringIsNullOrEmpty(Me._LanguageCode) Then Me._LanguageCode = Constants.LanguageCodeLith
            Me._Number = info.Number
            Me._NumbersInInvoice = info.NumbersInInvoice
            Me._Serial = info.Serial
            Me._VatExemptInfo = info.VatExemptions
            Me._VatExemptInfoAltLng = info.VatExemptions

            UpdateFullNumber(False)

            If Not info.Payer Is Nothing AndAlso Not StringIsNullOrEmpty(info.Payer.Code) Then
                Me._Payer = clientList.GetPersonInfo(info.Payer.Code)
                If Not Me._Payer Is Nothing Then
                    Me._AccountPayer = Me._Payer.AccountAgainstBankBuyer
                End If
            End If

            If IsNew Then
                _InvoiceItems = InvoiceMadeItemList.NewInvoiceMadeItemList(info, _
                    Me, accountList, vatSchemaList, serviceList)
            Else
                _InvoiceItems.AddWithNewItems(info, Me, accountList, vatSchemaList, serviceList)
            End If

            CalculateSubTotals(False)

            If _Sum < 0 Then _Type = InvoiceType.Credit

            Dim baseValidator As SimpleChronologicValidator = SimpleChronologicValidator. _
                NewSimpleChronologicValidator(Utilities.ConvertLocalizedName(DocumentType.InvoiceMade), Nothing)

            _ChronologyValidator = ComplexChronologicValidator.NewComplexChronologicValidator( _
                baseValidator.CurrentOperationName, baseValidator, Nothing, Nothing)

            ValidationRules.CheckRules()

        End Sub

        Friend Sub SetImportedPayer(ByVal importedPayer As PersonInfo)
            Me._Payer = importedPayer
            Me._AccountPayer = importedPayer.AccountAgainstBankBuyer
        End Sub


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            DoFetch(criteria.ID)

        End Sub

        Private Sub DoFetch(ByVal invoiceID As Integer)

            Dim myComm As New SQLCommand("FetchInvoiceMade")
            myComm.AddParam("?MD", invoiceID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.Common_ObjectNotFound, My.Resources.Documents_InvoiceMade_TypeName, _
                    invoiceID.ToString()))

                DoFetch(invoiceID, myData.Rows(0))

            End Using

        End Sub

        Private Sub DoFetch(ByVal invoiceID As Integer, ByVal dr As DataRow)

            _ID = invoiceID

            _Date = CDateSafe(dr.Item(0), Today)
            _Serial = CStrSafe(dr.Item(1)).Trim
            _Number = CIntSafe(dr.Item(2), 0)
            _FullNumber = CStrSafe(dr.Item(3)).Trim
            _Content = CStrSafe(dr.Item(4)).Trim
            _CurrencyCode = CStrSafe(dr.Item(5)).Trim
            _CurrencyRate = CDblSafe(dr.Item(6), ROUNDCURRENCYRATE, 0)
            _LanguageCode = CStrSafe(dr.Item(7)).Trim
            _LanguageName = GetLanguageName(_LanguageCode, False)
            _AddDateToNumberOptionWasUsed = ConvertDbBoolean(CIntSafe(dr.Item(8), 0))
            _NumbersInInvoice = CIntSafe(dr.Item(9), 0)
            _CustomInfo = CStrSafe(dr.Item(10)).Trim
            _CustomInfoAltLng = CStrSafe(dr.Item(11)).Trim
            _CommentsInternal = CStrSafe(dr.Item(12)).Trim
            _VatExemptInfo = CStrSafe(dr.Item(13)).Trim
            _VatExemptInfoAltLng = CStrSafe(dr.Item(14)).Trim
            _AccountPayer = CLongSafe(dr.Item(15), 0)
            _Type = Utilities.ConvertDatabaseID(Of InvoiceType)(CIntSafe(dr.Item(16), 0))
            _InsertDate = CTimeStampSafe(dr.Item(17))
            _UpdateDate = CTimeStampSafe(dr.Item(18))
            _ExternalID = CStrSafe(dr.Item(19)).Trim
            ' _DocumentState = CStrSafe(dr.Item(20))
            _Payer = PersonInfo.GetPersonInfo(dr, 21)

            Dim baseValidator As SimpleChronologicValidator = _
                SimpleChronologicValidator.GetSimpleChronologicValidator( _
                _ID, _Date, Utilities.ConvertLocalizedName(DocumentType.InvoiceMade), Nothing)

            _InvoiceItems = InvoiceMadeItemList.GetInvoiceMadeItemList(Me, baseValidator)

            CalculateSubTotals(False)
            UpdateFullNumber(False)

            _ChronologyValidator = ComplexChronologicValidator.GetComplexChronologicValidator( _
                _ID, _Date, baseValidator.CurrentOperationName, baseValidator, _
                Nothing, _InvoiceItems.GetChronologyValidators())

            MarkOld()
            ValidationRules.CheckRules()

        End Sub


        Friend Sub SaveChild()
            If IsNew Then
                DoInsert()
            Else
                DoUpdate()
            End If
        End Sub

        Protected Overrides Sub DataPortal_Insert()

            If _IsDoomyInvoice Then
                Throw New InvalidOperationException(My.Resources.Documents_InvoiceMade_InvalidSaveForDoomy)
            End If

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            DoInsert()

        End Sub

        Private Sub DoInsert()

            _InvoiceItems.CheckIfCanUpdate(Me)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            CheckIfExternalIdUnique()

            CheckIfNumberUnique()

            Dim entry As General.JournalEntry = GetJournalEntry(False)

            Using transaction As New SqlTransaction

                Try

                    entry = entry.SaveChild()

                    _ID = entry.ID

                    Dim myComm As New SQLCommand("InsertInvoiceMade")
                    AddParamsGeneral(myComm)
                    AddParamsFinancial(myComm)

                    myComm.Execute()

                    _InvoiceItems.Update(Me)

                    For Each i As InvoiceMadeItem In _InvoiceItems
                        If Not i.AttachedObjectValue Is Nothing AndAlso _
                            i.AttachedObjectValue.Type = InvoiceAdapterType.GoodsTransfer Then

                            entry = GetJournalEntry(True)
                            entry = entry.SaveChild()

                            Exit For

                        End If
                    Next

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

            DoUpdate()

        End Sub

        Private Sub DoUpdate()

            UpdateFullNumber(False)

            _InvoiceItems.CheckIfCanUpdate(Me)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            CheckIfExternalIdUnique()

            CheckIfNumberUnique()

            Dim entry As General.JournalEntry = GetJournalEntry(False)

            CheckIfUpdateDateChanged()

            Dim myComm As SQLCommand
            If _ChronologyValidator.FinancialDataCanChange Then
                myComm = New SQLCommand("UpdateInvoiceMade")
                AddParamsFinancial(myComm)
            Else
                myComm = New SQLCommand("UpdateInvoiceMadeGeneral")
            End If
            AddParamsGeneral(myComm)

            Using transaction As New SqlTransaction

                Try

                    entry = entry.SaveChild()

                    myComm.Execute()

                    _InvoiceItems.Update(Me)

                    For Each i As InvoiceMadeItem In _InvoiceItems
                        If Not i.AttachedObjectValue Is Nothing AndAlso _
                            i.AttachedObjectValue.Type = InvoiceAdapterType.GoodsTransfer Then

                            entry = GetJournalEntry(True)
                            entry = entry.SaveChild()

                            Exit For

                        End If
                    Next

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub

        Private Sub AddParamsGeneral(ByRef myComm As SQLCommand)

            myComm.AddParam("?AA", _ID)
            myComm.AddParam("?AB", _Serial.Trim)
            myComm.AddParam("?AC", _Number)
            myComm.AddParam("?AF", _LanguageCode.Trim)
            myComm.AddParam("?AG", _VatExemptInfo.Trim)
            myComm.AddParam("?AH", _VatExemptInfoAltLng.Trim)
            myComm.AddParam("?AI", _CustomInfo.Trim)
            myComm.AddParam("?AJ", _CustomInfoAltLng.Trim)
            myComm.AddParam("?AK", _CommentsInternal.Trim)
            myComm.AddParam("?AL", ConvertDbBoolean(_AddDateToNumberOptionWasUsed))
            myComm.AddParam("?AM", _NumbersInInvoice)
            myComm.AddParam("?AO", Utilities.ConvertDatabaseID(_Type))
            myComm.AddParam("?AQ", _ExternalID.Trim)
            myComm.AddParam("?AR", "") ' DocumentState

            _UpdateDate = GetCurrentTimeStamp()
            If Me.IsNew Then _InsertDate = _UpdateDate
            myComm.AddParam("?AP", _UpdateDate.ToUniversalTime)

        End Sub

        Private Sub AddParamsFinancial(ByRef myComm As SQLCommand)

            myComm.AddParam("?AD", _CurrencyCode.Trim)
            myComm.AddParam("?AE", CRound(_CurrencyRate, ROUNDCURRENCYRATE))
            myComm.AddParam("?AN", _AccountPayer)

        End Sub


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            DoDelete(DirectCast(criteria, Criteria).ID)

        End Sub

        Friend Shared Sub DeleteInvoiceByExternalID(ByVal externalIdToDelete As String)

            Dim myComm As New SQLCommand("FetchInvoiceMadeIDByExternalID")
            myComm.AddParam("?MN", externalIdToDelete.Trim)

            Dim idToDelete As Integer

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then
                    If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                        My.Resources.Common_ObjectNotFound, My.Resources.Documents_InvoiceMade_TypeName, _
                        externalIdToDelete.ToString()))
                End If

                idToDelete = CIntSafe(myData.Rows(0).Item(0), 0)

            End Using

            DoDelete(idToDelete)

        End Sub

        Private Shared Sub DoDelete(ByVal id As Integer)

            Dim cInvoice As New InvoiceMade
            cInvoice.DoFetch(id)

            For Each item As InvoiceMadeItem In cInvoice._InvoiceItems
                item.CheckIfCanDelete(cInvoice._ChronologyValidator.BaseValidator)
            Next

            IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted(id, DocumentType.InvoiceMade)

            Dim myComm As New SQLCommand("DeleteInvoiceMade")
            myComm.AddParam("?MD", id)

            Using transaction As New SqlTransaction

                Try

                    General.JournalEntry.DeleteJournalEntryChild(id)

                    myComm.Execute()

                    For Each item As InvoiceMadeItem In cInvoice._InvoiceItems
                        item.DeleteSelf()
                    Next

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

        End Sub


        Private Function GetJournalEntry(ByVal forceOld As Boolean) As General.JournalEntry

            Dim result As General.JournalEntry
            If IsNew AndAlso Not forceOld Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.InvoiceMade)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_ID, DocumentType.InvoiceMade)
            End If

            result.Content = _Content
            result.Date = _Date
            result.DocNumber = _Serial & _FullNumber
            result.Person = _Payer

            If IsNew OrElse _ChronologyValidator.FinancialDataCanChange Then

                Dim fullBookEntryList As BookEntryInternalList = BookEntryInternalList. _
                    NewBookEntryInternalList(BookEntryType.Debetas)

                Dim applicableAccountPayer As Long = _AccountPayer
                If Not applicableAccountPayer > 0 Then
                    applicableAccountPayer = _Payer.AccountAgainstBankBuyer
                End If

                For Each i As InvoiceMadeItem In _InvoiceItems
                    fullBookEntryList.AddRange(i.GetBookEntryInternalList(applicableAccountPayer))
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

        Private Sub CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("CheckIfInvoiceMadeUpdateDateChanged")
            myComm.AddParam("?SD", _ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 OrElse CDateTimeSafe(myData.Rows(0).Item(0), _
                    Date.MinValue) = Date.MinValue Then

                    Throw New Exception(String.Format(My.Resources.Common_ObjectNotFound, _
                        My.Resources.Documents_InvoiceMade_TypeName, _ID.ToString))

                End If

                If CTimeStampSafe(myData.Rows(0).Item(0)) <> _UpdateDate Then

                    Throw New Exception(My.Resources.Common_UpdateDateHasChanged)

                End If

            End Using

        End Sub

        Private Sub CheckIfExternalIdUnique()

            If StringIsNullOrEmpty(_ExternalID) Then Exit Sub

            Dim myComm As New SQLCommand("FetchInvoiceMadeIdByExternalID")
            myComm.AddParam("?MN", _ExternalID.Trim)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 _
                    AndAlso CIntSafe(myData.Rows(0).Item(0), 0) <> _ID Then _
                    Throw New Exception(String.Format(My.Resources.Documents_InvoiceMade_ExternalIdNotUnique, _
                        _ExternalID.Trim))
            End Using

        End Sub

        Private Sub CheckIfNumberUnique()

            Dim myComm As SQLCommand
            If _AddDateToNumberOptionWasUsed Then
                myComm = New SQLCommand("CheckIfInvoiceNumberUniqueWithDate")
                myComm.AddParam("?ND", _Date)
            Else
                myComm = New SQLCommand("CheckIfInvoiceNumberUnique")
            End If
            myComm.AddParam("?SR", _Serial.Trim.ToUpper)
            myComm.AddParam("?NM", _Number)
            myComm.AddParam("?IN", _ID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 Then Throw New Exception( _
                    My.Resources.Documents_InvoiceMade_SerialNumberNotUnique)
            End Using

        End Sub

#End Region

    End Class

End Namespace