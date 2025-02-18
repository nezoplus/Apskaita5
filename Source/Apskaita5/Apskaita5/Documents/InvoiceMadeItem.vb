﻿Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.Documents.InvoiceAdapters
Imports ApskaitaObjects.Attributes
Imports Csla.Validation

Namespace Documents

    ''' <summary>
    ''' Represents a line (item) within an <see cref="InvoiceMade">invoice made</see>.
    ''' </summary>
    ''' <remarks>Should only be used as a child of a <see cref="InvoiceMadeItemList">InvoiceMadeItemList</see>.
    ''' Values are stored in the database table sfd.</remarks>
    <Serializable()> _
    Public NotInheritable Class InvoiceMadeItem
        Inherits BusinessBase(Of InvoiceMadeItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = -1
        Private _FinancialDataCanChange As Boolean = True
        Private _NameInvoice As String = ""
        Private _NameInvoiceAltLng As String = ""
        Private _AccountIncome As Long = 0
        Private _AccountVat As Long = 0
        Private _MeasureUnit As String = ""
        Private _MeasureUnitAltLng As String = ""
        Private _Ammount As Double = 0
        Private _UnitValueLTL As Double = 0
        Private _SumLTL As Double = 0
        Private _SumCorrectionLTL As Integer = 0
        Private _VatRate As Double = 0
        Private _SumVatLTL As Double = 0
        Private _SumVatCorrectionLTL As Integer = 0
        Private _SumTotalLTL As Double = 0
        Private _UnitValue As Double = 0
        Private _UnitValueCorrectionLTL As Integer = 0
        Private _Sum As Double = 0
        Private _SumCorrection As Integer = 0
        Private _SumVat As Double = 0
        Private _SumVatCorrection As Integer = 0
        Private _SumTotal As Double = 0
        Private _AccountDiscount As Long = 0
        Private _DiscountLTL As Double = 0
        Private _Discount As Double = 0
        Private _DiscountCorrectionLTL As Integer = 0
        Private _DiscountVatLTL As Double = 0
        Private _DiscountVatLTLCorrection As Integer = 0
        Private _DiscountVat As Double = 0
        Private _DiscountVatCorrection As Integer = 0
        Private _VatIsVirtual As Boolean = False
        Private _IncludeVatInObject As Boolean = False
        Private _DeclarationSchema As VatDeclarationSchemaInfo = Nothing
        Private WithEvents _AttachedObject As IInvoiceAdapter = Nothing

        Private suspendChildChanged As Boolean = False


        ''' <summary>
        ''' Technical property to enable language related validation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property LanguageCode() As String
            Get
                Return GetLanguageCode()
            End Get
        End Property


        ''' <summary>
        ''' Gets an ID of the item that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database table sfd.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Returnes TRUE if the parent invoice allows financial changes due to business restrains.
        ''' </summary>
        ''' <remarks></remarks>
        Private ReadOnly Property FinancialDataCanChange() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a content (description) of the item in the base language as printed in the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database table sfd.Preke.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property NameInvoice() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NameInvoice.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _NameInvoice.Trim <> value.Trim Then
                    _NameInvoice = value.Trim
                    PropertyHasChanged()
                    If Not _AttachedObject Is Nothing AndAlso _AttachedObject.HandlesNameInvoice Then
                        suspendChildChanged = True
                        _AttachedObject.NameInvoice = value
                        suspendChildChanged = False
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a content (description) of the item in the alternative language 
        ''' (<see cref="InvoiceMade.LanguageCode">original language of the invoice</see>) 
        ''' as printed in the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database table sfd.NameAltLng.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property NameInvoiceAltLng() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NameInvoiceAltLng.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _NameInvoiceAltLng.Trim <> value.Trim Then
                    _NameInvoiceAltLng = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the income <see cref="General.Account.ID">account</see>,
        ''' that is credited by the <see cref="SumLTL">SumLTL</see> amount 
        ''' (unless overriden by the attached operation).
        ''' </summary>
        ''' <remarks>Value is stored in the database table sfd.P_Sas.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 1, 2, 3, 4, 5, 6)> _
        Public Property AccountIncome() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountIncome
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountIncomeIsReadOnly Then Exit Property
                If _AccountIncome <> value Then
                    _AccountIncome = value
                    PropertyHasChanged()
                    If Not _AttachedObject Is Nothing AndAlso _AttachedObject.HandlesAccount Then
                        suspendChildChanged = True
                        _AttachedObject.Account = value
                        suspendChildChanged = False
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the VAT payable <see cref="General.Account.ID">account</see>,
        ''' that is credited by the <see cref="SumVatLTL">SumVatLTL</see> amount.
        ''' </summary>
        ''' <remarks>Value is stored in the database table sfd.A_Sas.</remarks>
        <AccountField(ValueRequiredLevel.Optional, False, 2, 4)> _
        Public Property AccountVat() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountVat
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountVatIsReadOnly Then Exit Property
                If _AccountVat <> value Then
                    _AccountVat = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a measure unit of the item in the base language as printed in the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database table sfd.Vnt.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 50)> _
        Public Property MeasureUnit() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MeasureUnit.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _MeasureUnit.Trim <> value.Trim Then
                    _MeasureUnit = value.Trim
                    PropertyHasChanged()
                    If Not _AttachedObject Is Nothing AndAlso _AttachedObject.HandlesMeasureUnit Then
                        suspendChildChanged = True
                        _AttachedObject.MeasureUnit = value
                        suspendChildChanged = False
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a measure unit of the item in the alternative language 
        ''' (<see cref="InvoiceMade.LanguageCode">original language of the invoice</see>) 
        ''' as printed in the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database table sfd.MeasureUnitAltLng.</remarks>
        <StringField(ValueRequiredLevel.Optional, 50)> _
        Public Property MeasureUnitAltLng() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MeasureUnitAltLng.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _MeasureUnitAltLng.Trim <> value.Trim Then
                    _MeasureUnitAltLng = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the amount of the goods/services sold.
        ''' </summary>
        ''' <remarks>Value round order is <see cref="ROUNDAMOUNTINVOICEMADE">ROUNDAMOUNTINVOICEMADE</see>.
        ''' Value is stored in the database table sfd.Kiekis.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, True, ROUNDAMOUNTINVOICEMADE)> _
        Public Property Ammount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Ammount, ROUNDAMOUNTINVOICEMADE)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If AmmountIsReadOnly Then Exit Property
                If CRound(_Ammount, ROUNDAMOUNTINVOICEMADE) <> CRound(value, ROUNDAMOUNTINVOICEMADE) Then
                    _Ammount = CRound(value, ROUNDAMOUNTINVOICEMADE)
                    CalculateSum(0)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the value of the goods/services sold per unit 
        ''' in <see cref="InvoiceMade.CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Value round order is <see cref="ROUNDUNITINVOICEMADE">ROUNDUNITINVOICEMADE</see>.
        ''' Value is stored in the database table sfd.Kaina.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, True, ROUNDUNITINVOICEMADE)> _
        Public Property UnitValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitValue, ROUNDUNITINVOICEMADE)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If UnitValueIsReadOnly Then Exit Property
                If CRound(_UnitValue, ROUNDUNITINVOICEMADE) <> CRound(value, ROUNDUNITINVOICEMADE) Then
                    _UnitValue = CRound(value, ROUNDUNITINVOICEMADE)
                    CalculateSum(0)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the total value of the goods/services sold (excluding VAT)
        ''' in <see cref="InvoiceMade.CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Equals <see cref="Ammount">Ammount</see> multiplied by 
        ''' <see cref="UnitValue">UnitValue</see>
        ''' plus <see cref="SumCorrection">SumCorrection</see> divided by 100.
        ''' Value is stored in the database table sfd.SumOriginal.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, True, 2)> _
        Public ReadOnly Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a correction of <see cref="Sum">Sum</see> in cents (1/100 of the currency unit).
        ''' </summary>
        ''' <remarks>Value is calculated (not persisted) as the difference between 
        ''' <see cref="Ammount">Ammount</see> multiplied by  <see cref="UnitValue">UnitValue</see>
        ''' and <see cref="Sum">Sum</see>.</remarks>
        <CorrectionField()> _
        Public Property SumCorrection() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SumCorrection
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If SumCorrectionIsReadOnly Then Exit Property
                If _SumCorrection <> value Then
                    _SumCorrection = value
                    CalculateSum(0)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the applicable VAT rate in percents for the goods/services sold (21 = 21%).
        ''' </summary>
        ''' <remarks>Value is stored in the database table sfd.Tar.</remarks>
        <TaxRateField(ValueRequiredLevel.Optional, ApskaitaObjects.Settings.TaxRateType.Vat)> _
        Public Property VatRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_VatRate)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If VatRateIsReadOnly Then Exit Property
                If CRound(_VatRate) <> CRound(value) Then
                    _VatRate = CRound(value)
                    CalculateDiscountVat(0)
                    CalculateSumVat()
                    CalculateSumVatLTL(0)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the applicable VAT declaration schema for the goods/services sold.
        ''' </summary>
        ''' <remarks>Value is stored in the database table sfd.DeclarationSchemaID.</remarks>
        <VatDeclarationSchemaFieldAttribute(ValueRequiredLevel.Mandatory, TradedItemType.All)> _
        Public Property DeclarationSchema() As VatDeclarationSchemaInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DeclarationSchema
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As VatDeclarationSchemaInfo)
                CanWriteProperty(True)
                If DeclarationSchemaIsReadOnly Then Exit Property
                If Not (_DeclarationSchema Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _DeclarationSchema Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _DeclarationSchema = value) Then
                    _DeclarationSchema = value
                    If Not _DeclarationSchema Is Nothing AndAlso Not _DeclarationSchema.IsEmpty _
                        AndAlso Not VatRateIsReadOnly Then
                        VatRate = _DeclarationSchema.VatRate
                    End If
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the VAT value in <see cref="InvoiceMade.CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Equals <see cref="Sum">Sum</see> multiplied by 
        ''' <see cref="VatRate">VatRate</see> and divided by 100
        ''' plus <see cref="SumVatCorrection">SumVatCorrection</see> divided by 100.
        ''' Value is stored in the database table sfd.SumVatOriginal.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumVat() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVat)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a correction of <see cref="SumVat">SumVat</see> in cents (1/100 of the currency unit).
        ''' </summary>
        ''' <remarks>Value is calculated (not persisted) as the difference between 
        ''' <see cref="Sum">Sum</see> multiplied by <see cref="VatRate">VatRate</see>, divided by 100
        ''' and <see cref="SumVat">SumVat</see>.</remarks>
        <CorrectionField()> _
        Public Property SumVatCorrection() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SumVatCorrection
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If SumVatCorrectionIsReadOnly Then Exit Property
                If _SumVatCorrection <> value Then
                    _SumVatCorrection = value
                    CalculateSumVat()
                    CalculateSumVatLTL(0)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the total value of the goods/services sold (including VAT)
        ''' in <see cref="InvoiceMade.CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Equals <see cref="Sum">Sum</see> plus <see cref="SumVat">SumVat</see>.
        ''' Value is not stored in the database.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, True, 2)> _
        Public ReadOnly Property SumTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotal)
            End Get
        End Property

        ''' <summary>
        ''' Gets the value of the goods/services sold per unit in the base currency.
        ''' </summary>
        ''' <remarks>Value equals <see cref="UnitValue">UnitValue</see> multiplied by
        ''' <see cref="InvoiceMade.CurrencyRate">the invoice currency rate</see>
        ''' plus <see cref="UnitValueLTLCorrection">UnitValueLTLCorrection</see> divided by 100.
        ''' Value round order is <see cref="ROUNDUNITINVOICEMADE">ROUNDUNITINVOICEMADE</see>.
        ''' Value is stored in the database table sfd.UnitValueLTL.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, True, ROUNDUNITINVOICEMADE)> _
        Public ReadOnly Property UnitValueLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitValueLTL, ROUNDUNITINVOICEMADE)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a correction of <see cref="UnitValueLTL">UnitValueLTL</see> in cents (1/100 of the currency unit).
        ''' </summary>
        ''' <remarks>Value is calculated (not persisted) as the difference between 
        ''' <see cref="UnitValue">UnitValue</see> multiplied by
        ''' <see cref="InvoiceMade.CurrencyRate">the invoice currency rate</see>
        ''' and <see cref="UnitValueLTL">UnitValueLTL</see>.</remarks>
        <CorrectionField()> _
        Public Property UnitValueLTLCorrection() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UnitValueCorrectionLTL
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If UnitValueLTLCorrectionIsReadOnly Then Exit Property
                If _UnitValueCorrectionLTL <> value Then
                    _UnitValueCorrectionLTL = value
                    PropertyHasChanged()
                    CalculateSumLTL(0)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the total value of the goods/services sold (excluding VAT) in the base currency.
        ''' </summary>
        ''' <remarks>Value equals <see cref="Sum">Sum</see> multiplied by
        ''' <see cref="InvoiceMade.CurrencyRate">the invoice currency rate</see>
        ''' plus <see cref="SumCorrectionLTL">SumCorrectionLTL</see> divided by 100.
        ''' Value is stored in the database table sfd.SumLTL.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, True, 2)> _
        Public ReadOnly Property SumLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a correction of <see cref="SumLTL">SumLTL</see> in cents (1/100 of the currency unit).
        ''' </summary>
        ''' <remarks>Value is calculated (not persisted) as the difference between 
        ''' <see cref="Sum">Sum</see> multiplied by
        ''' <see cref="InvoiceMade.CurrencyRate">the invoice currency rate</see>
        ''' and <see cref="SumLTL">SumLTL</see>.</remarks>
        <CorrectionField()> _
        Public Property SumCorrectionLTL() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SumCorrectionLTL
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If SumCorrectionLTLIsReadOnly Then Exit Property
                If _SumCorrectionLTL <> value Then
                    _SumCorrectionLTL = value
                    CalculateSumLTL(0)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the VAT value in the base currency.
        ''' </summary>
        ''' <remarks>Value equals <see cref="SumVat">SumVat</see> multiplied by
        ''' <see cref="InvoiceMade.CurrencyRate">the invoice currency rate</see>
        ''' plus <see cref="SumVatCorrectionLTL">SumVatCorrectionLTL</see> divided by 100.
        ''' Value is stored in the database table sfd.SumVatLTL.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumVatLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVatLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a correction of <see cref="SumVatLTL">SumVatLTL</see> in cents (1/100 of the currency unit).
        ''' </summary>
        ''' <remarks>Value is calculated (not persisted) as the difference between 
        ''' <see cref="SumVat">SumVat</see> multiplied by
        ''' <see cref="InvoiceMade.CurrencyRate">the invoice currency rate</see>
        ''' and <see cref="SumVatLTL">SumVatLTL</see>.</remarks>
        <CorrectionField()> _
        Public Property SumVatCorrectionLTL() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SumVatCorrectionLTL
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If SumVatCorrectionLTLIsReadOnly Then Exit Property
                If _SumVatCorrectionLTL <> value Then
                    _SumVatCorrectionLTL = value
                    CalculateSumVatLTL(0)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the total value of the goods/services sold (including VAT) in the base currency.
        ''' </summary>
        ''' <remarks>Equals <see cref="SumLTL">SumLTL</see> plus <see cref="SumVatLTL">SumVatLTL</see>.
        ''' Value is not stored in the database.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, True, 2)> _
        Public ReadOnly Property SumTotalLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotalLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the discount <see cref="General.Account.ID">account</see>,
        ''' that is debited by the <see cref="DiscountLTL">DiscountLTL</see> amount.
        ''' If the <see cref="DiscountLTL">DiscountLTL</see> value is not null and 
        ''' the account is not specified then the <see cref="AccountIncome">AccountIncome</see>
        ''' is credited by the difference between <see cref="SumLTL">SumLTL</see>
        ''' and <see cref="DiscountLTL">DiscountLTL</see>, i.e. discount value does not
        ''' produce a separate book entry.
        ''' </summary>
        ''' <remarks>Value is stored in the database table sfd.AccountDiscount.</remarks>
        <AccountField(ValueRequiredLevel.Optional, False, 1, 2, 3, 4, 5, 6)> _
        Public Property AccountDiscount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountDiscount
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountDiscountIsReadOnly Then Exit Property
                If _AccountDiscount <> value Then
                    _AccountDiscount = value
                    SetAttachedObjectFinancialData()
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a discount value in <see cref="InvoiceMade.CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database table sfd.Discount.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property Discount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Discount)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If DiscountIsReadOnly Then Exit Property
                If CRound(_Discount) <> CRound(value) Then
                    _Discount = CRound(value)
                    CalculateDiscountLTL(0)
                    CalculateDiscountVat(0)
                    SetAttachedObjectFinancialData()
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a discount value in the base currency.
        ''' </summary>
        ''' <remarks>Value equals <see cref="Discount">Discount</see> multiplied by
        ''' <see cref="InvoiceMade.CurrencyRate">the invoice currency rate</see>
        ''' plus <see cref="DiscountCorrectionLTL">DiscountCorrectionLTL</see> divided by 100.
        ''' Value is stored in the database table sfd.DiscountLTL.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property DiscountLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DiscountLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a correction of <see cref="DiscountLTL">DiscountLTL</see> in cents (1/100 of the currency unit).
        ''' </summary>
        ''' <remarks>Value is calculated (not persisted) as the difference between 
        ''' <see cref="Discount">Discount</see> multiplied by
        ''' <see cref="InvoiceMade.CurrencyRate">the invoice currency rate</see>
        ''' and <see cref="DiscountLTL">DiscountLTL</see>.</remarks>
        <CorrectionField()> _
        Public Property DiscountCorrectionLTL() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DiscountCorrectionLTL
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If DiscountCorrectionLTLIsReadOnly Then Exit Property
                If _DiscountCorrectionLTL <> value Then
                    _DiscountCorrectionLTL = value
                    CalculateDiscountLTL(0)
                    SetAttachedObjectFinancialData()
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the discount VAT value in <see cref="InvoiceMade.CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Equals <see cref="Discount">Discount</see> multiplied by 
        ''' <see cref="VatRate">VatRate</see> and divided by 100
        ''' plus <see cref="DiscountVatCorrection">DiscountVatCorrection</see> divided by 100.
        ''' Value is stored in the database table sfd.DiscountVat.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property DiscountVat() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DiscountVat)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a correction of <see cref="DiscountVat">DiscountVat</see> in cents (1/100 of the currency unit).
        ''' </summary>
        ''' <remarks>Value is calculated (not persisted) as the difference between 
        ''' <see cref="Discount">Discount</see> multiplied by <see cref="VatRate">VatRate</see>, divided by 100
        ''' and <see cref="DiscountVat">DiscountVat</see>.</remarks>
        <CorrectionField()> _
        Public Property DiscountVatCorrection() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DiscountVatCorrection
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If DiscountVatCorrectionIsReadOnly Then Exit Property
                If _DiscountVatCorrection <> value Then
                    _DiscountVatCorrection = value
                    CalculateDiscountVat(0)
                    SetAttachedObjectFinancialData()
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the discount VAT value in the base currency.
        ''' </summary>
        ''' <remarks>Value equals <see cref="DiscountVat">DiscountVat</see> multiplied by
        ''' <see cref="InvoiceMade.CurrencyRate">the invoice currency rate</see>
        ''' plus <see cref="DiscountVatLTLCorrection">DiscountVatLTLCorrection</see> divided by 100.
        ''' Value is stored in the database table sfd.DiscountVatLTL.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property DiscountVatLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DiscountVatLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a correction of <see cref="DiscountVatLTL">DiscountVatLTL</see> in cents (1/100 of the currency unit).
        ''' </summary>
        ''' <remarks>Value is calculated (not persisted) as the difference between 
        ''' <see cref="DiscountVat">DiscountVat</see> multiplied by
        ''' <see cref="InvoiceMade.CurrencyRate">the invoice currency rate</see>
        ''' and <see cref="DiscountVatLTL">DiscountVatLTL</see>.</remarks>
        <CorrectionField()> _
        Public Property DiscountVatLTLCorrection() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DiscountVatLTLCorrection
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If DiscountVatLTLCorrectionIsReadOnly Then Exit Property
                If _DiscountVatLTLCorrection <> value Then
                    _DiscountVatLTLCorrection = value
                    CalculateDiscountVatLTL(0)
                    SetAttachedObjectFinancialData()
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a description of the attached operation. 
        ''' Returns empty string if the item does not have an attached operation.
        ''' </summary>
        ''' <remarks>Uses ToString method to get the value.
        ''' Value is stored in the database fields sfd.Rusis and sfd.P_ID
        ''' where sfd.Rusis represents the type of the operation
        ''' and sfd.P_ID represents an ID of the operation.</remarks>
        Public ReadOnly Property AttachedObject() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _AttachedObject Is Nothing Then Return ""
                Return _AttachedObject.ToString
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets whether VAT is virtual, i.e. is only meant for display
        ''' within the invoice, not for financial accounting.
        ''' </summary>
        ''' <remarks>Value is stored in the database table sfd.VatIsVirtual.</remarks>
        Public Property VatIsVirtual() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _VatIsVirtual
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If VatIsVirtualIsReadOnly Then Exit Property
                If _VatIsVirtual <> value Then
                    _VatIsVirtual = value
                    SetAttachedObjectFinancialData()
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether VAT should be handled by the attached operation, 
        ''' e.g. included into the acquisition costs of a long term asset.
        ''' Can only be used if the attached operation 
        ''' <see cref="IInvoiceAdapter.SumVatIsHandledOnRequest">
        ''' supports VAT handling</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database table sfd.IncludeVatInObject.</remarks>
        Public Property IncludeVatInObject() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IncludeVatInObject
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If IncludeVatInObjectIsReadOnly Then Exit Property
                If _IncludeVatInObject <> value Then
                    _IncludeVatInObject = value
                    SetAttachedObjectFinancialData()
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets (exposes) an attached operation by the common <see cref="InvoiceAdapters.IInvoiceAdapter">IInvoiceAdapter</see> interface.
        ''' </summary>
        ''' <remarks>Value is stored in the database fields sfd.Rusis and sfd.P_ID
        ''' where sfd.Rusis represents the type of the operation
        ''' and sfd.P_ID represents an ID of the operation.</remarks>
        Public ReadOnly Property AttachedObjectValue() As IInvoiceAdapter
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AttachedObject
            End Get
        End Property


        ''' <summary>
        ''' Whether the <see cref="AccountIncome">AccountIncome</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountIncomeIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange OrElse (Not _AttachedObject Is Nothing _
                    AndAlso _AttachedObject.HandlesAccount AndAlso _
                    Not _AttachedObject.ChronologyValidator.FinancialDataCanChange)
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="AccountVat">AccountVat</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountVatIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="Ammount">Ammount</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AmmountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange OrElse (Not _AttachedObject Is Nothing AndAlso _
                    Not _AttachedObject.ChronologyValidator.FinancialDataCanChange)
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="UnitValue">UnitValue</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property UnitValueIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange OrElse (Not _AttachedObject Is Nothing AndAlso _
                    Not _AttachedObject.ChronologyValidator.FinancialDataCanChange)
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="SumCorrection">SumCorrection</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SumCorrectionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange OrElse (Not _AttachedObject Is Nothing AndAlso _
                    Not _AttachedObject.ChronologyValidator.FinancialDataCanChange)
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="VatRate">VatRate</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property VatRateIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get

                If Not FinancialDataCanChange Then Return True

                If Not _AttachedObject Is Nothing AndAlso _
                    Not _AttachedObject.ChronologyValidator.FinancialDataCanChange Then

                    If _AttachedObject.HandlesVatRate OrElse _
                        (_AttachedObject.SumVatIsHandledOnRequest AndAlso _
                        _IncludeVatInObject) Then
                        Return True
                    End If

                End If

                Return False

            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="DeclarationSchema">DeclarationSchema</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DeclarationSchemaIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="SumVatCorrection">SumVatCorrection</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SumVatCorrectionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get

                If Not FinancialDataCanChange Then Return True

                If Not _AttachedObject Is Nothing AndAlso _
                    Not _AttachedObject.ChronologyValidator.FinancialDataCanChange Then

                    If _AttachedObject.HandlesVatRate OrElse _
                        (_AttachedObject.SumVatIsHandledOnRequest AndAlso _
                        _IncludeVatInObject) Then
                        Return True
                    End If

                End If

                Return False

            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="UnitValueLTLCorrection">UnitValueLTLCorrection</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property UnitValueLTLCorrectionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange OrElse ParentCurrencyIsBaseCurrency()
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="SumCorrectionLTL">SumCorrectionLTL</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SumCorrectionLTLIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange OrElse ParentCurrencyIsBaseCurrency() OrElse _
                    (Not _AttachedObject Is Nothing AndAlso _
                    Not _AttachedObject.ChronologyValidator.FinancialDataCanChange)
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="SumVatCorrectionLTL">SumVatCorrectionLTL</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SumVatCorrectionLTLIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get

                If Not FinancialDataCanChange OrElse ParentCurrencyIsBaseCurrency() Then
                    Return True
                End If

                If Not _AttachedObject Is Nothing AndAlso _
                    Not _AttachedObject.ChronologyValidator.FinancialDataCanChange Then

                    If _AttachedObject.HandlesVatRate OrElse _
                        (_AttachedObject.SumVatIsHandledOnRequest AndAlso _IncludeVatInObject) Then
                        Return True
                    End If

                End If

                Return False

            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="AccountDiscount">AccountDiscount</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountDiscountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get

                If Not FinancialDataCanChange Then Return True

                If Not _AttachedObject Is Nothing Then

                    If Not _AttachedObject.DiscountIsAllowed OrElse _
                        Not _AttachedObject.ChronologyValidator.FinancialDataCanChange Then

                        Return True

                    End If

                End If

                Return False

            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="Discount">Discount</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DiscountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get

                If Not FinancialDataCanChange Then Return True

                If Not _AttachedObject Is Nothing Then

                    If Not _AttachedObject.DiscountIsAllowed OrElse _
                        Not _AttachedObject.ChronologyValidator.FinancialDataCanChange Then

                        Return True

                    End If

                End If

                Return False

            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="DiscountCorrectionLTL">DiscountCorrectionLTL</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DiscountCorrectionLTLIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get

                If Not FinancialDataCanChange OrElse ParentCurrencyIsBaseCurrency() Then
                    Return True
                End If

                If Not _AttachedObject Is Nothing Then

                    If Not _AttachedObject.DiscountIsAllowed OrElse _
                        Not _AttachedObject.ChronologyValidator.FinancialDataCanChange Then

                        Return True

                    End If

                End If

                Return False

            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="DiscountVatLTLCorrection">DiscountVatLTLCorrection</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DiscountVatLTLCorrectionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get

                If Not FinancialDataCanChange OrElse ParentCurrencyIsBaseCurrency() Then
                    Return True
                End If

                If Not _AttachedObject Is Nothing Then

                    If Not _AttachedObject.DiscountIsAllowed Then

                        Return True

                    End If

                    If Not _AttachedObject.ChronologyValidator.FinancialDataCanChange Then

                        If _AttachedObject.HandlesVatRate OrElse _
                            (_AttachedObject.SumVatIsHandledOnRequest AndAlso _
                             _IncludeVatInObject) Then

                            Return True

                        End If

                    End If

                End If

                Return False

            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="DiscountVatCorrection">DiscountVatCorrection</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DiscountVatCorrectionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get

                If Not FinancialDataCanChange Then
                    Return True
                End If

                If Not _AttachedObject Is Nothing Then

                    If Not _AttachedObject.DiscountIsAllowed Then

                        Return True

                    End If

                    If Not _AttachedObject.ChronologyValidator.FinancialDataCanChange Then

                        If _AttachedObject.HandlesVatRate OrElse _
                            (_AttachedObject.SumVatIsHandledOnRequest AndAlso _
                             _IncludeVatInObject) Then

                            Return True

                        End If

                    End If

                End If

                Return False

            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="IncludeVatInObject">IncludeVatInObject</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IncludeVatInObjectIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get

                If Not FinancialDataCanChange OrElse _AttachedObject Is Nothing Then
                    Return True
                End If

                If Not _AttachedObject.SumVatIsHandledOnRequest OrElse _
                    Not _AttachedObject.ChronologyValidator.FinancialDataCanChange Then

                    Return True

                End If

                Return False

            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="IncludeVatInObject">VatIsVirtual</see> property is readonly
        ''' (due to chronological or other business rules).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property VatIsVirtualIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get

                If Not FinancialDataCanChange Then
                    Return True
                End If

                If Not _AttachedObject Is Nothing AndAlso _
                    Not _AttachedObject.ChronologyValidator.FinancialDataCanChange Then

                    If _AttachedObject.HandlesVatRate OrElse _
                        (_AttachedObject.SumVatIsHandledOnRequest AndAlso _
                        _IncludeVatInObject) Then

                        Return True

                    End If

                End If

                Return False

            End Get
        End Property


        ''' <summary>
        ''' Whether the item can be copied. If not - the item is skiped.
        ''' </summary>
        ''' <remarks>Checks if there is an attached operation. If exists, checks 
        ''' <see cref="IInvoiceAdapter.ImplementsCopy">IInvoiceAdapter.ImplementsCopy</see> property.</remarks>
        Public ReadOnly Property CanBeCopied() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (_AttachedObject Is Nothing OrElse _AttachedObject.ImplementsCopy)
            End Get
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse (Not _AttachedObject Is Nothing _
                    AndAlso _AttachedObject.ValueObjectIsDirty)
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso (_AttachedObject Is Nothing _
                    OrElse Not _AttachedObject.ValueObjectHasErrors)
            End Get
        End Property



        Private Sub CalculateSumVatLTL(ByVal pCurrencyRate As Double)
            _SumVatLTL = CRound(CRound(_SumVat * GetCurrencyRate(pCurrencyRate)) _
                + _SumVatCorrectionLTL / 100)
            _SumTotalLTL = CRound(_SumLTL + _SumVatLTL)
            SetAttachedObjectFinancialData()
            PropertyHasChanged("SumVatLTL")
            PropertyHasChanged("SumTotalLTL")
        End Sub

        Private Sub CalculateSumLTL(ByVal pCurrencyRate As Double)
            _UnitValueLTL = CRound(CRound(_UnitValue * GetCurrencyRate(pCurrencyRate), ROUNDUNITINVOICEMADE) _
                + _UnitValueCorrectionLTL / 100, ROUNDUNITINVOICEMADE)
            _SumLTL = CRound(CRound(_Sum * GetCurrencyRate(pCurrencyRate)) + _SumCorrectionLTL / 100)
            PropertyHasChanged("UnitValueLTL")
            PropertyHasChanged("SumLTL")
            CalculateSumVatLTL(pCurrencyRate)
        End Sub

        Private Sub CalculateSum(ByVal pCurrencyRate As Double)
            _Sum = CRound(CRound(_UnitValue * _Ammount) + _SumCorrection / 100)
            PropertyHasChanged("Sum")
            CalculateSumVat()
            CalculateSumLTL(pCurrencyRate)
        End Sub

        Private Sub CalculateSumVat()
            _SumVat = CRound(CRound(_Sum * _VatRate / 100) + _SumVatCorrection / 100)
            _SumTotal = CRound(_Sum + _SumVat)
            PropertyHasChanged("SumVat")
            PropertyHasChanged("SumTotal")
        End Sub

        Private Sub CalculateDiscountLTL(ByVal pCurrencyRate As Double)
            _DiscountLTL = CRound(CRound(_Discount * GetCurrencyRate(pCurrencyRate)) _
                + _DiscountCorrectionLTL / 100)
            PropertyHasChanged("DiscountLTL")
        End Sub

        Private Sub CalculateDiscountVatLTL(ByVal pCurrencyRate As Double)
            _DiscountVatLTL = CRound(CRound(_DiscountVat * GetCurrencyRate(pCurrencyRate)) _
                + _DiscountVatLTLCorrection / 100)
            PropertyHasChanged("DiscountVatLTL")
        End Sub

        Private Sub CalculateDiscountVat(ByVal pCurrencyRate As Double)
            _DiscountVat = CRound(CRound(_VatRate * _Discount / 100) _
                + _DiscountVatCorrection / 100)
            PropertyHasChanged("DiscountVat")
            CalculateDiscountVatLTL(pCurrencyRate)
        End Sub


        Friend Function GetCurrencyRate(ByVal invoiceCurrencyRate As Double) As Double

            If CRound(invoiceCurrencyRate, ROUNDCURRENCYRATE) > 0 Then

                Return invoiceCurrencyRate

            ElseIf Parent Is Nothing Then

                Return 1

            ElseIf IsBaseCurrency(DirectCast(Parent, InvoiceMadeItemList).CurrencyCode, _
                GetCurrentCompany().BaseCurrency) Then

                Return 1

            ElseIf DirectCast(Parent, InvoiceMadeItemList).CurrencyRate > 0 Then

                Return DirectCast(Parent, InvoiceMadeItemList).CurrencyRate

            Else

                Return 1

            End If

        End Function

        Private Function GetCurrencyCode() As String

            Dim result As String = GetCurrentCompany().BaseCurrency

            If Not Parent Is Nothing AndAlso Not IsBaseCurrency( _
                DirectCast(Parent, InvoiceMadeItemList).CurrencyCode, result) Then

                result = DirectCast(Parent, InvoiceMadeItemList).CurrencyCode

            End If

            Return result.Trim.ToUpper()

        End Function

        Private Function ParentCurrencyIsBaseCurrency() As Boolean
            Return Parent Is Nothing OrElse IsBaseCurrency( _
                DirectCast(Parent, InvoiceMadeItemList).CurrencyCode, GetCurrentCompany.BaseCurrency)
        End Function


        Friend Sub UpdateLanguage()
            PropertyHasChanged("LanguageCode")
        End Sub

        Friend Sub UpdateCurrencyRate(ByVal newCurrencyRate As Double, ByVal newCurrencyCode As String)

            If Not _AttachedObject Is Nothing AndAlso Not _AttachedObject.ChronologyValidator. _
                FinancialDataCanChange Then

                Throw New Exception(String.Format(My.Resources.Documents_InvoiceMadeItem_InvalidItemUpdate, _
                    Me.ToString(), _AttachedObject.ChronologyValidator.FinancialDataCanChangeExplanation))

            ElseIf Not _FinancialDataCanChange Then

                Throw New Exception(My.Resources.Documents_InvoiceMadeItem_InvalidDocumentUpdate)

            End If

            If IsBaseCurrency(newCurrencyCode, GetCurrentCompany.BaseCurrency) Then

                newCurrencyRate = 1

                _UnitValueCorrectionLTL = 0
                _SumCorrectionLTL = 0
                _SumVatCorrectionLTL = 0
                _DiscountCorrectionLTL = 0
                _DiscountVatLTLCorrection = 0

                PropertyHasChanged("UnitValueCorrectionLTL")
                PropertyHasChanged("SumCorrectionLTL")
                PropertyHasChanged("SumVatCorrectionLTL")
                PropertyHasChanged("DiscountCorrectionLTL")
                PropertyHasChanged("DiscountVatLTLCorrection")

            End If

            CalculateDiscountLTL(newCurrencyRate)
            CalculateDiscountVatLTL(newCurrencyRate)
            CalculateSumLTL(newCurrencyRate)

        End Sub

        Public Sub SetRegionalContents(ByVal regionalDictionary As RegionalInfoDictionary, _
            ByVal setBaseLanguageProperties As Boolean)

            If Parent Is Nothing OrElse _AttachedObject Is Nothing Then Exit Sub

            Dim asRegionalizable As IRegionalDataObject = Nothing
            Try
                asRegionalizable = DirectCast(_AttachedObject, IRegionalDataObject)
            Catch ex As Exception
                Exit Sub
            End Try
            If asRegionalizable Is Nothing Then Exit Sub

            Dim result As RegionalContentEntry = regionalDictionary.ContentDictionary.GetRegionalContentEntry( _
                asRegionalizable.RegionalObjectType, asRegionalizable.RegionalObjectID, GetLanguageCode)

            If LanguagesEquals(result.LanguageCode, LanguageCodeLith, LanguageCodeLith) Then

                If Not setBaseLanguageProperties OrElse Not result.ObjectID > 0 Then Exit Sub

                _MeasureUnit = result.MeasureUnit
                _NameInvoice = result.ContentInvoice

                PropertyHasChanged("MeasureUnit")
                PropertyHasChanged("NameInvoice")

            Else

                _MeasureUnitAltLng = result.MeasureUnit
                _NameInvoiceAltLng = result.ContentInvoice

                PropertyHasChanged("MeasureUnitAltLng")
                PropertyHasChanged("NameInvoiceAltLng")

                If setBaseLanguageProperties Then

                    result = regionalDictionary.ContentDictionary.GetRegionalContentEntry( _
                        asRegionalizable.RegionalObjectType, asRegionalizable.RegionalObjectID, _
                        LanguageCodeLith)

                    If result.ObjectID > 0 Then
                        _MeasureUnit = result.MeasureUnit
                        _NameInvoice = result.ContentInvoice
                        PropertyHasChanged("MeasureUnit")
                        PropertyHasChanged("NameInvoice")
                    End If

                End If

            End If

        End Sub

        Private Function GetLanguageCode() As String

            If Parent Is Nothing OrElse Not TypeOf Parent Is InvoiceMadeItemList Then

                Return LanguageCodeLith.Trim.ToUpper

            ElseIf LanguagesEquals(DirectCast(Parent, InvoiceMadeItemList).LanguageCode, _
                LanguageCodeLith, LanguageCodeLith) Then

                Return LanguageCodeLith.Trim.ToUpper

            Else

                Return DirectCast(Parent, InvoiceMadeItemList).LanguageCode

            End If

        End Function


        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString

            If IsValid Then Return ""

            Dim result As String = ""
            result = AddWithNewLine(result, Me.BrokenRulesCollection.ToString( _
                RuleSeverity.Error), False)
            If Not _AttachedObject Is Nothing Then
                result = AddWithNewLine(result, _AttachedObject.GetAllErrors(), False)
            End If

            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, vbCrLf, result)

        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString

            If Not HasWarnings() Then Return ""

            Dim result As String = ""
            result = AddWithNewLine(result, Me.BrokenRulesCollection.ToString( _
                RuleSeverity.Warning), False)
            If Not _AttachedObject Is Nothing Then
                result = AddWithNewLine(result, _AttachedObject.GetAllWarnings(), False)
            End If

            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, vbCrLf, result)

        End Function

        Public Function HasWarnings() As Boolean
            Return BrokenRulesCollection.WarningCount > 0 OrElse _
               (Not _AttachedObject Is Nothing AndAlso _AttachedObject.ValueObjectHasWarnings)
        End Function


        Private Sub SetAttachedObjectFinancialData()
            If _AttachedObject Is Nothing OrElse suspendChildChanged Then Exit Sub
            suspendChildChanged = True
            _AttachedObject.SetInvoiceFinancialData(Me)
            suspendChildChanged = False
        End Sub

        Friend Sub SetAttachedObjectInvoiceDate(ByVal invoiceDate As Date)
            If _AttachedObject Is Nothing Then Exit Sub
            suspendChildChanged = True
            _AttachedObject.SetInvoiceDate(invoiceDate)
            suspendChildChanged = False
        End Sub

        ''' <summary>
        ''' Gets a total sum for an invoice adapter taking into account
        ''' the adapter's ability to handle VAT, discounts and the invoice item state
        ''' (<see cref="IncludeVatInObject">IncludeVatInObject</see>, 
        ''' <see cref="VatIsVirtual">VatIsVirtual</see> and discount properties).
        ''' </summary>
        ''' <remarks></remarks>
        Friend Function GetTotalSumForInvoiceAdapter() As Double

            Dim result As Double = 0
            Dim applicableDiscount As Double = _DiscountLTL

            If _AttachedObject Is Nothing Then Return result

            If _AttachedObject.SumVatIsHandledOnRequest AndAlso _IncludeVatInObject Then

                If _VatIsVirtual Then
                    result = _SumLTL
                Else
                    result = _SumTotalLTL
                    applicableDiscount = CRound(_DiscountLTL + _DiscountVatLTL, 2)
                End If

            Else

                result = _SumLTL

            End If

            If _AttachedObject.DiscountIsAllowed Then

                result = CRound(result - applicableDiscount, 2)

            End If

            Return CRound(result, 2)

        End Function


        Private Sub AttachedObject_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.PropertyChangedEventArgs)

            If _AttachedObject Is Nothing OrElse suspendChildChanged Then
                PropertyHasChanged("AttachedObject")
                Exit Sub
            End If

            If _AttachedObject.HandlesMeasureUnit AndAlso StringIsNullOrEmpty(_MeasureUnit) Then
                _MeasureUnit = _AttachedObject.MeasureUnit
                PropertyHasChanged("MeasureUnit")
            End If

            If _AttachedObject.HandlesNameInvoice AndAlso StringIsNullOrEmpty(_NameInvoice) Then
                _NameInvoice = _AttachedObject.NameInvoice
                PropertyHasChanged("NameInvoice")
            End If

            If _AttachedObject.HandlesAccount AndAlso _AccountIncome _
                <> _AttachedObject.Account Then
                _AccountIncome = _AttachedObject.Account
                PropertyHasChanged("AccountIncome")
            End If

            Dim needsRecalculation As Boolean = False

            If _AttachedObject.HandlesAmount AndAlso CRound(_Ammount, ROUNDAMOUNTINVOICEMADE) _
                <> CRound(_AttachedObject.Amount, ROUNDAMOUNTINVOICEMADE) Then
                _Ammount = CRound(_AttachedObject.Amount, ROUNDAMOUNTINVOICEMADE)
                PropertyHasChanged("Ammount")
                needsRecalculation = True
            End If

            If _AttachedObject.HandlesVatRate AndAlso CRound(_AttachedObject.VatRate, 2) <> _
                CRound(_VatRate, 2) Then
                _VatRate = CRound(_AttachedObject.VatRate, 2)
                PropertyHasChanged("VatRate")
                needsRecalculation = True
            End If

            If needsRecalculation Then
                suspendChildChanged = True
                CalculateSum(0)
                suspendChildChanged = False
            End If

            PropertyHasChanged("AttachedObject")

        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child objects loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As InvoiceMadeItem = DirectCast(MyBase.GetClone(), InvoiceMadeItem)
            result.RestoreChildHandles()
            Return result
        End Function

        Protected Overrides Sub OnDeserialized(ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            RestoreChildHandles()
        End Sub

        Protected Overrides Sub UndoChangesComplete()
            MyBase.UndoChangesComplete()
            RestoreChildHandles()
        End Sub

        ''' <summary>
        ''' Helper method. Takes care of InvoiceAdpter loosing its handler. See GetClone method.
        ''' </summary>
        Private Sub RestoreChildHandles()
            If _AttachedObject Is Nothing Then Exit Sub
            Try
                RemoveHandler DirectCast(_AttachedObject, Csla.Core.BusinessBase). _
                    PropertyChanged, AddressOf AttachedObject_Changed
            Catch ex As Exception
            End Try
            AddHandler DirectCast(_AttachedObject, Csla.Core.BusinessBase). _
                PropertyChanged, AddressOf AttachedObject_Changed
        End Sub


        Friend Sub MarkAsCopy()

            _ID = -1
            _Guid = Guid.NewGuid
            _FinancialDataCanChange = True

            If Not _AttachedObject Is Nothing Then

                Try
                    RemoveHandler DirectCast(_AttachedObject, Csla.Core.BusinessBase). _
                        PropertyChanged, AddressOf AttachedObject_Changed
                Catch ex As Exception
                End Try

                If _AttachedObject.ImplementsCopy Then
                    _AttachedObject = _AttachedObject.GetCopy()
                    AddHandler DirectCast(_AttachedObject, Csla.Core.BusinessBase). _
                        PropertyChanged, AddressOf AttachedObject_Changed
                Else
                    _AttachedObject = Nothing
                End If

            End If

            MarkNew()

        End Sub

        ''' <summary>
        ''' Gets item data as a data transfer object.
        ''' </summary>
        ''' <remarks>Used to implement data exchange with other applications.</remarks>
        Friend Function GetInvoiceItemInfo() As InvoiceInfo.InvoiceItemInfo

            Dim result As New InvoiceInfo.InvoiceItemInfo

            result.Ammount = Me._Ammount
            result.AccountIncome = Me._AccountIncome
            result.AccountVat = Me._AccountVat
            result.Comments = ""
            result.Discount = Me._Discount
            result.DiscountLTL = Me._DiscountLTL
            result.DiscountVat = Me._DiscountVat
            result.DiscountVatLTL = Me._DiscountVatLTL
            result.ID = Me._ID.ToString
            result.MeasureUnit = Me._MeasureUnit
            result.MeasureUnitAltLng = Me._MeasureUnitAltLng
            result.NameInvoice = Me._NameInvoice
            result.NameInvoiceAltLng = Me._NameInvoiceAltLng
            result.ProjectCode = ""
            result.Sum = Me._Sum
            result.SumLTL = Me._SumLTL
            result.SumReceived = 0
            result.SumTotal = Me._SumTotal
            result.SumTotalLTL = Me._SumTotalLTL
            result.SumVat = Me._SumVat
            result.SumVatLTL = Me._SumVatLTL
            result.UnitValue = Me._UnitValue
            result.UnitValueLTL = Me._UnitValueLTL
            If Not Me._DeclarationSchema Is Nothing AndAlso Not Me._DeclarationSchema.IsEmpty Then
                result.VatDDeclarationSchemaID = Me._DeclarationSchema.ExternalCode
            End If
            result.VatRate = Me._VatRate
            result.VatIsVirtual = Me._VatIsVirtual

            Dim serviceAdapter As ServiceInvoiceAdapter = TryCast(_AttachedObject, ServiceInvoiceAdapter)
            If Not serviceAdapter Is Nothing Then
                result.ServiceCode = serviceAdapter.ServiceCode
            End If


            Return result

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Documents_InvoiceMadeItem_ToString, _
                _NameInvoice, DblParser(_Ammount, ROUNDAMOUNTINVOICEMADE), _MeasureUnit, _
                DblParser(_UnitValue, ROUNDUNITINVOICEMADE), GetCurrencyCode())
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("NameInvoice"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("MeasureUnit"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Validation.RuleArgs("UnitValue"))
            ValidationRules.AddRule(AddressOf CommonValidation.IntegerFieldValidation, _
                New Validation.RuleArgs("SumCorrection"))
            ValidationRules.AddRule(AddressOf CommonValidation.VatDeclarationSchemaFieldValidation, _
                New CommonValidation.VatDeclarationSchemaFieldRuleArgs("DeclarationSchema", _
                "VatRate"))

            ValidationRules.AddRule(AddressOf CommonValidation.AltLanguageValidation, _
                New CommonValidation.ReferencePropertyRuleArgs("NameInvoiceAltLng", _
                "LanguageCode"))
            ValidationRules.AddRule(AddressOf CommonValidation.AltLanguageValidation, _
                New CommonValidation.ReferencePropertyRuleArgs("MeasureUnitAltLng", _
                "LanguageCode"))

            ValidationRules.AddRule(AddressOf DiscountValidation, "Discount")
            ValidationRules.AddRule(AddressOf DiscountLTLValidation, "DiscountLTL")
            ValidationRules.AddRule(AddressOf DiscountVatValidation, "DiscountVat")
            ValidationRules.AddRule(AddressOf DiscountVatLTLValidation, "DiscountVatLTL")
            ValidationRules.AddRule(AddressOf AccountIncomeValidation, "AccountIncome")
            ValidationRules.AddRule(AddressOf AccountVatValidation, "AccountVat")
            ValidationRules.AddRule(AddressOf AmountValidation, "Ammount")
            ValidationRules.AddRule(AddressOf SumVatCorrectionValidation, "SumVatCorrection")
            ValidationRules.AddRule(AddressOf UnitValueCorrectionLTLValidation, "UnitValueLTLCorrection")
            ValidationRules.AddRule(AddressOf SumCorrectionLTLValidation, "SumCorrectionLTL")
            ValidationRules.AddRule(AddressOf SumVatCorrectionLTLValidation, "SumVatCorrectionLTL")
            ValidationRules.AddRule(AddressOf SumLTLValidation, "SumLTL")
            ValidationRules.AddRule(AddressOf SumTotalLTLValidation, "SumTotalLTL")
            ValidationRules.AddRule(AddressOf DiscountCorrectionLTLValidation, "DiscountCorrectionLTL")
            ValidationRules.AddRule(AddressOf DiscountVatLTLCorrectionValidation, "DiscountVatLTLCorrection")
            ValidationRules.AddRule(AddressOf DiscountVatCorrectionValidation, "DiscountVatCorrection")
            ValidationRules.AddRule(AddressOf AttachedObjectValidation, "AttachedObject")

            ValidationRules.AddDependantProperty("LanguageCode", "NameInvoiceAltLng", False)
            ValidationRules.AddDependantProperty("LanguageCode", "MeasureUnitAltLng", False)

            ValidationRules.AddDependantProperty("DiscountVatLTL", "SumTotalLTL", True)
            ValidationRules.AddDependantProperty("Sum", "Discount", False)
            ValidationRules.AddDependantProperty("SumLTL", "DiscountLTL", True)
            ValidationRules.AddDependantProperty("SumVat", "DiscountVat", False)
            ValidationRules.AddDependantProperty("SumVatLTL", "DiscountVatLTL", False)
            ValidationRules.AddDependantProperty("VatRate", "AccountVat", False)
            ValidationRules.AddDependantProperty("IncludeVatInObject", "AccountVat", False)
            ValidationRules.AddDependantProperty("VatIsVirtual", "AccountVat", False)
            ValidationRules.AddDependantProperty("UnitValue", "Ammount", False)
            ValidationRules.AddDependantProperty("VatRate", "SumVatCorrection", False)
            ValidationRules.AddDependantProperty("VatRate", "SumVatCorrectionLTL", False)
            ValidationRules.AddDependantProperty("Discount", "DiscountCorrectionLTL", False)
            ValidationRules.AddDependantProperty("DiscountVat", "DiscountVatLTLCorrection", False)
            ValidationRules.AddDependantProperty("VatRate", "DiscountVatCorrection", False)
            ValidationRules.AddDependantProperty("AttachedObject", "AccountIncome", False)
            ValidationRules.AddDependantProperty("AttachedObject", "Ammount", False)
            ValidationRules.AddDependantProperty("AttachedObject", "SumLTL", False)
            ValidationRules.AddDependantProperty("AttachedObject", "SumTotalLTL", False)
            ValidationRules.AddDependantProperty("VatRate", "DeclarationSchema", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that Discount is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DiscountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            Return DiscountValidationInt(valObj._Discount, valObj._Sum, _
                (valObj._AttachedObject Is Nothing OrElse _
                 valObj._AttachedObject.DiscountIsAllowed), _
                 My.Resources.Documents_InvoiceMadeItem_Discount, _
                 My.Resources.Documents_InvoiceMadeItem_Sum, _
                 e)

        End Function

        ''' <summary>
        ''' Rule ensuring that DiscountVat is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DiscountVatValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            Return DiscountValidationInt(valObj._DiscountVat, valObj._SumVat, _
                (valObj._AttachedObject Is Nothing OrElse _
                 valObj._AttachedObject.DiscountIsAllowed), _
                 My.Resources.Documents_InvoiceMadeItem_DiscountVat, _
                 My.Resources.Documents_InvoiceMadeItem_SumVat, _
                 e)

        End Function

        ''' <summary>
        ''' Rule ensuring that DiscountLTL is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DiscountLTLValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            Return DiscountValidationInt(valObj._DiscountLTL, valObj._SumLTL, _
                (valObj._AttachedObject Is Nothing OrElse _
                 valObj._AttachedObject.DiscountIsAllowed), _
                 My.Resources.Documents_InvoiceMadeItem_DiscountLTL, _
                 My.Resources.Documents_InvoiceMadeItem_SumLTL, _
                 e)

        End Function

        ''' <summary>
        ''' Rule ensuring that Discounts are valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DiscountVatLTLValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            Return DiscountValidationInt(valObj._DiscountVatLTL, valObj._SumVatLTL, _
                (valObj._AttachedObject Is Nothing OrElse _
                 valObj._AttachedObject.DiscountIsAllowed), _
                 My.Resources.Documents_InvoiceMadeItem_DiscountVatLTL, _
                 My.Resources.Documents_InvoiceMadeItem_SumVatLTL, _
                 e)

        End Function

        Private Shared Function DiscountValidationInt(ByVal discountValue As Double, _
            ByVal propertyValue As Double, ByVal discountIsAllowed As Boolean, _
            ByVal discountName As String, ByVal propertyName As String, _
            ByVal e As Validation.RuleArgs) As Boolean

            If CRound(discountValue) < 0 Then

                e.Description = My.Resources.Documents_InvoiceMadeItem_DiscountNegative
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf CRound(discountValue) > 0 AndAlso CRound(propertyValue) < 0 Then

                e.Description = My.Resources.Documents_InvoiceMadeItem_DiscountInCreditItem
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf Not discountIsAllowed AndAlso CRound(discountValue) > 0 Then

                e.Description = My.Resources.Documents_InvoiceMadeItem_DiscountNotSupported
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf CRound(propertyValue) > 0 AndAlso CRound(discountValue) _
                > CRound(propertyValue) Then

                e.Description = String.Format(My.Resources.Documents_InvoiceMadeItem_ValueExceedsLimits, _
                    discountName, propertyName)
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that AccountIncome is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountIncomeValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If Not valObj._AttachedObject Is Nothing AndAlso _
                valObj._AttachedObject.HandlesAccount Then

                Return valObj._AttachedObject.ValidateAccount(valObj, e)

            End If

            Return CommonValidation.CommonValidation.AccountFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that AccountVat is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountVatValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If CRound(valObj._VatRate) > 0 AndAlso Not valObj._VatIsVirtual AndAlso _
                (Not valObj._IncludeVatInObject OrElse valObj._AttachedObject Is Nothing _
                OrElse Not valObj._AttachedObject.SumVatIsHandledOnRequest) Then

                Return CommonValidation.CommonValidation.AccountFieldValidation(target, e)

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that Amount is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AmountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            If Not CommonValidation.CommonValidation.DoubleFieldValidation(target, e) Then Return False

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If CRound(valObj._UnitValue, ROUNDUNITINVOICEMADE) < 0 _
                AndAlso CRound(valObj._Ammount, ROUNDAMOUNTINVOICEMADE) < 0 Then

                e.Description = My.Resources.Documents_InvoiceMadeItem_UnitValueAndAmountBothNegative
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf Not valObj._AttachedObject Is Nothing AndAlso _
                valObj._AttachedObject.HandlesAmount Then

                Return valObj._AttachedObject.ValidateAmount(valObj, e)

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that SumVatCorrection is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumVatCorrectionValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If Not CRound(valObj._VatRate, 2) > 0 AndAlso _
                valObj._SumVatCorrection <> 0 Then

                e.Description = My.Resources.Documents_InvoiceMadeItem_SumVatCorrectionInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return CommonValidation.CommonValidation.IntegerFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that UnitValueCorrectionLTL is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function UnitValueCorrectionLTLValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If valObj.ParentCurrencyIsBaseCurrency() AndAlso _
                valObj._UnitValueCorrectionLTL <> 0 Then

                e.Description = My.Resources.Documents_InvoiceMadeItem_BaseCurrencyCorrectionInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return CommonValidation.CommonValidation.IntegerFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that SumCorrectionLTL is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumCorrectionLTLValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If valObj.ParentCurrencyIsBaseCurrency() AndAlso _
                valObj._SumCorrectionLTL <> 0 Then

                e.Description = My.Resources.Documents_InvoiceMadeItem_BaseCurrencyCorrectionInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return CommonValidation.CommonValidation.IntegerFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that SumVatCorrectionLTL is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumVatCorrectionLTLValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If valObj.ParentCurrencyIsBaseCurrency() AndAlso _
                valObj._SumVatCorrectionLTL <> 0 Then

                e.Description = My.Resources.Documents_InvoiceMadeItem_BaseCurrencyCorrectionInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf Not CRound(valObj._VatRate, 2) > 0 AndAlso _
                valObj._SumVatCorrectionLTL <> 0 Then

                e.Description = My.Resources.Documents_InvoiceMadeItem_SumVatCorrectionInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return CommonValidation.CommonValidation.IntegerFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that SumLTL is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumLTLValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If Not valObj._AttachedObject Is Nothing AndAlso _
                valObj._AttachedObject.HandlesSum Then
                Return valObj._AttachedObject.ValidateSum(valObj, e)
            End If

            Return CommonValidation.CommonValidation.DoubleFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that SumTotalLTL is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumTotalLTLValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If Not valObj._AttachedObject Is Nothing AndAlso _
                valObj._AttachedObject.HandlesSum Then
                Return valObj._AttachedObject.ValidateTotalSum(valObj, e)
            End If

            Return CommonValidation.CommonValidation.DoubleFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that DiscountCorrectionLTL is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DiscountCorrectionLTLValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If valObj.ParentCurrencyIsBaseCurrency() AndAlso _
                valObj._DiscountCorrectionLTL <> 0 Then

                e.Description = My.Resources.Documents_InvoiceMadeItem_BaseCurrencyCorrectionInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf Not CRound(valObj._Discount, 2) > 0 AndAlso _
                valObj._DiscountCorrectionLTL <> 0 Then

                e.Description = My.Resources.Documents_InvoiceMadeItem_DiscountCorrectionInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return CommonValidation.CommonValidation.IntegerFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that DiscountVatLTLCorrection is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DiscountVatLTLCorrectionValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If valObj.ParentCurrencyIsBaseCurrency() AndAlso _
                valObj._DiscountVatLTLCorrection <> 0 Then

                e.Description = My.Resources.Documents_InvoiceMadeItem_BaseCurrencyCorrectionInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf Not CRound(valObj._DiscountVat, 2) > 0 AndAlso _
                valObj._DiscountVatLTLCorrection <> 0 Then

                e.Description = My.Resources.Documents_InvoiceMadeItem_DiscountVatCorrectionInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return CommonValidation.CommonValidation.IntegerFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that DiscountVatCorrection is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DiscountVatCorrectionValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If Not CRound(valObj._VatRate, 2) > 0 AndAlso _
                valObj._SumVatCorrection <> 0 Then

                e.Description = My.Resources.Documents_InvoiceMadeItem_SumVatCorrectionInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return CommonValidation.CommonValidation.IntegerFieldValidation(target, e)

        End Function


        ''' <summary>
        ''' Rule ensuring AttachedObject is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AttachedObjectValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If Not valObj._AttachedObject Is Nothing Then

                If valObj._AttachedObject.ValueObjectHasErrors Then

                    e.Description = valObj._AttachedObject.GetAllErrors()
                    e.Severity = Validation.RuleSeverity.Error
                    Return False

                ElseIf valObj._AttachedObject.ValueObjectHasWarnings Then

                    e.Description = valObj._AttachedObject.GetAllWarnings()
                    e.Severity = Validation.RuleSeverity.Warning
                    Return False

                End If

            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewInvoiceMadeItem() As InvoiceMadeItem
            Return New InvoiceMadeItem(Nothing)
        End Function

        Friend Shared Function NewInvoiceMadeItem(ByVal newAttachedObject As IInvoiceAdapter) As InvoiceMadeItem
            Return New InvoiceMadeItem(newAttachedObject)
        End Function

        Friend Shared Function NewInvoiceMadeItem(ByVal info As InvoiceInfo.InvoiceItemInfo, _
            ByVal invoiceCurrencyRate As Double, ByVal accountList As AccountInfoList, _
            ByVal vatSchemaList As VatDeclarationSchemaInfoList, serviceList As ServiceInfoList) As InvoiceMadeItem

            Dim service As ServiceInfo = serviceList.GetServiceInfo(info.ServiceCode)
            
            If service = ServiceInfo.Empty Then _
                Return New InvoiceMadeItem(info, invoiceCurrencyRate, accountList, vatSchemaList)

            Return New InvoiceMadeItem(info, invoiceCurrencyRate, service, accountList, vatSchemaList)
        End Function

        Friend Shared Function NewInvoiceMadeItem(ByVal proformaItem As ProformaInvoiceMadeItem, _
            ByVal baseChronologyValidator As SimpleChronologicValidator, _
            ByVal isBaseCurrency As Boolean) As InvoiceMadeItem
            Return New InvoiceMadeItem(proformaItem, baseChronologyValidator, isBaseCurrency)
        End Function


        Friend Shared Function GetInvoiceMadeItem(ByVal dr As DataRow, _
            ByVal invoiceCurrencyRate As Double, _
            ByVal baseChronologyValidator As SimpleChronologicValidator) As InvoiceMadeItem
            Return New InvoiceMadeItem(dr, invoiceCurrencyRate, baseChronologyValidator)
        End Function


        Friend Shared Function DoomyInvoiceMadeItem(ByVal r As Random) As InvoiceMadeItem

            Dim result As New InvoiceMadeItem

            result._Ammount = CRound(r.Next(1, 1000000) / 10000, ROUNDAMOUNTINVOICEMADE)
            result._NameInvoice = String.Format(My.Resources.Documents_InvoiceMadeItem_DoomyNameInvoice, r.Next(1, 1000).ToString)
            result._NameInvoiceAltLng = String.Format(My.Resources.Documents_InvoiceMadeItem_DoomyNameInvoice, r.Next(1, 1000).ToString)
            result._UnitValue = CRound(r.Next(1, 1000000) / 10000, ROUNDUNITINVOICEMADE)
            result._VatRate = Convert.ToDouble(IIf(r.Next(1, 31) > 20, 0, 21))
            result._MeasureUnit = My.Resources.Documents_InvoiceMadeItem_DoomyMeasureUnit
            result._MeasureUnitAltLng = My.Resources.Documents_InvoiceMadeItem_DoomyMeasureUnitAltLng

            result.CalculateSum(2.34267)

            result._Discount = Convert.ToDouble(IIf(r.Next(1, 31) > 20, _
                CRound(result._SumLTL * r.Next(3, 20) / 100), 0))

            result.CalculateDiscountVat(2.34267)
            result.CalculateDiscountLTL(2.34267)

            Return result

        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal newAttachedObject As IInvoiceAdapter)
            MarkAsChild()
            Create(newAttachedObject)
        End Sub

        Private Sub New(ByVal info As InvoiceInfo.InvoiceItemInfo, ByVal invoiceCurrencyRate As Double, _
            ByVal accountList As AccountInfoList, ByVal vatSchemaList As VatDeclarationSchemaInfoList)
            MarkAsChild()
            Create(info, invoiceCurrencyRate, accountList, vatSchemaList)
        End Sub

        Private Sub New(ByVal info As InvoiceInfo.InvoiceItemInfo, ByVal invoiceCurrencyRate As Double, _
            service As ServiceInfo, ByVal accountList As AccountInfoList, _
            ByVal vatSchemaList As VatDeclarationSchemaInfoList)
            MarkAsChild()
            Create(info, invoiceCurrencyRate, service, accountList, vatSchemaList)
        End Sub

        Private Sub New(ByVal proformaItem As ProformaInvoiceMadeItem, _
            ByVal baseChronologyValidator As SimpleChronologicValidator, ByVal isBaseCurrency As Boolean)
            MarkAsChild()
            Create(proformaItem, baseChronologyValidator, isBaseCurrency)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal invoiceCurrencyRate As Double, _
            ByVal baseChronologyValidator As SimpleChronologicValidator)
            MarkAsChild()
            Fetch(dr, invoiceCurrencyRate, baseChronologyValidator)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create()

            _MeasureUnit = GetCurrentCompany.MeasureUnitInvoiceMade
            _AccountVat = GetCurrentCompany.Accounts.GetAccount(General.DefaultAccountType.VatPayable)

            If GetCurrentCompany.UseVatDeclarationSchemas AndAlso GetCurrentCompany.DeclarationSchemaSales _
                <> VatDeclarationSchemaInfo.Empty Then
                _DeclarationSchema = GetCurrentCompany.DeclarationSchemaSales
                _VatRate = GetCurrentCompany.DeclarationSchemaSales.VatRate
            Else
                _VatRate = GetCurrentCompany.GetDefaultRate(General.DefaultRateType.Vat)
            End If

        End Sub

        Private Sub Create(ByVal newAttachedObject As IInvoiceAdapter)

            Create()

            If newAttachedObject Is Nothing Then
                ValidationRules.CheckRules()
                Exit Sub
            End If

            If Not newAttachedObject.IsForInvoiceMade Then
                Throw New InvalidOperationException(My.Resources.Documents_InvoiceMadeItem_InvalidInvoiceAdapter)
            End If

            _AttachedObject = newAttachedObject

            If newAttachedObject.ProvidesDefaultVatRate Then
                If GetCurrentCompany.UseVatDeclarationSchemas Then
                    _DeclarationSchema = newAttachedObject.DefaultDeclarationSchema
                    If _DeclarationSchema <> VatDeclarationSchemaInfo.Empty Then
                        _VatRate = _DeclarationSchema.VatRate
                    End If
                Else
                    _VatRate = newAttachedObject.DefaultVatRate
                End If
            End If

            If newAttachedObject.ProvidesDefaultAccount Then
                _AccountIncome = newAttachedObject.DefaultAccount
            End If

            If newAttachedObject.ProvidesDefaultMeasureUnit Then
                _MeasureUnit = newAttachedObject.DefaultMeasureUnit
            End If

            If newAttachedObject.ProvidesDefaultNameInvoice Then
                _NameInvoice = newAttachedObject.DefaultNameInvoice
            End If

            If newAttachedObject.ProvidesDefaultVatAccount Then
                _AccountVat = newAttachedObject.DefaultVatAccount
            End If

            RestoreChildHandles()

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Create(ByVal info As InvoiceInfo.InvoiceItemInfo, ByVal pCurrencyRate As Double, _
            ByVal accountList As AccountInfoList, ByVal vatSchemaList As VatDeclarationSchemaInfoList)

            Me._Ammount = CRound(info.Ammount, ROUNDAMOUNTINVOICEMADE)
            Me._Discount = CRound(info.Discount)
            Me._DiscountVat = CRound(info.DiscountVat)
            Me._MeasureUnit = info.MeasureUnit
            Me._MeasureUnitAltLng = info.MeasureUnitAltLng
            Me._NameInvoice = info.NameInvoice
            Me._NameInvoiceAltLng = info.NameInvoiceAltLng
            Me._Sum = CRound(info.Sum)
            Me._SumTotal = CRound(info.SumTotal)
            Me._SumVat = CRound(info.SumVat)
            Me._UnitValue = CRound(info.UnitValue, ROUNDUNITINVOICEMADE)
            Me._VatRate = CRound(info.VatRate)
            If _UnitValue < 0.0 AndAlso _Ammount < 0.0 Then _Ammount = - _Ammount
            If _UnitValue < 0.0 AndAlso _Sum > 0.0 Then _Sum = - _Sum
            If _UnitValue < 0.0 AndAlso _SumTotal > 0.0 Then _SumTotal = - _SumTotal
            If _UnitValue < 0.0 AndAlso _SumVat > 0.0 Then _SumVat = - _SumVat

            If pCurrencyRate = 1.0 OrElse pCurrencyRate = 0.0 Then
                Me._DiscountLTL = _Discount
                Me._DiscountVatLTL = _DiscountVat
                Me._SumLTL = _Sum
                Me._SumTotalLTL = _SumTotal
                Me._SumVatLTL = _SumVat
                Me._UnitValueLTL = _UnitValue
            Else
                Me._DiscountLTL = CRound(info.DiscountLTL)
                Me._DiscountVatLTL = CRound(info.DiscountVatLTL)
                Me._SumLTL = CRound(info.SumLTL)
                Me._SumTotalLTL = CRound(info.SumTotalLTL)
                Me._SumVatLTL = CRound(info.SumVatLTL)
                Me._UnitValueLTL = CRound(info.UnitValueLTL, ROUNDUNITINVOICEMADE)
                If _UnitValue < 0.0 AndAlso _SumLTL > 0.0 Then _SumLTL = - _SumLTL
                If _UnitValue < 0.0 AndAlso _SumTotalLTL > 0.0 Then _SumTotalLTL = - _SumTotalLTL
                If _UnitValue < 0.0 AndAlso _SumVatLTL > 0.0 Then _SumVatLTL = - _SumVatLTL
            End If

            If Not accountList.GetAccountByID(info.AccountIncome) Is Nothing Then
                Me._AccountIncome = info.AccountIncome
            End If
            If Not info.AccountVat > 0 Then
                Me._AccountVat = GetCurrentCompany.Accounts.GetAccount(General.DefaultAccountType.VatPayable)
            ElseIf Not accountList.GetAccountByID(info.AccountVat) Is Nothing Then
                Me._AccountVat = info.AccountVat
            End If

            If Not StringIsNullOrEmpty(info.VatDDeclarationSchemaID) Then
                Me._DeclarationSchema = vatSchemaList.GetItem(info.VatDDeclarationSchemaID)
                If _DeclarationSchema <> VatDeclarationSchemaInfo.Empty() Then
                    _VatIsVirtual = _DeclarationSchema.VatIsVirtual
                End If
            End If

            CalculateCorrections(pCurrencyRate)

            ValidationRules.CheckRules()

        End Sub

        Private Sub Create(ByVal info As InvoiceInfo.InvoiceItemInfo, ByVal pCurrencyRate As Double, _
            service As ServiceInfo, ByVal accountList As AccountInfoList, _
            ByVal vatSchemaList As VatDeclarationSchemaInfoList)

            _AttachedObject = ServiceInvoiceAdapter.NewServiceInvoiceAdapter(service, _
                Nothing, true)

            Me._Ammount = CRound(info.Ammount, ROUNDAMOUNTINVOICEMADE)
            Me._Discount = CRound(info.Discount)
            Me._DiscountVat = CRound(info.DiscountVat)
            Me._MeasureUnit = IIf(StringIsNullOrEmpty(info.MeasureUnit), _
                service.MeasureUnit, info.MeasureUnit) 
            Me._MeasureUnitAltLng = info.MeasureUnitAltLng
            Me._NameInvoice = IIf(StringIsNullOrEmpty(info.NameInvoice), _
                service.NameInvoice, info.NameInvoice)
            Me._NameInvoiceAltLng = info.NameInvoiceAltLng
            Me._Sum = CRound(info.Sum)
            Me._SumTotal = CRound(info.SumTotal)
            Me._SumVat = CRound(info.SumVat)
            Me._UnitValue = CRound(info.UnitValue, ROUNDUNITINVOICEMADE)
            Me._VatRate = CRound(info.VatRate)
            If _UnitValue < 0.0 AndAlso _Ammount < 0.0 Then _Ammount = - _Ammount
            If _UnitValue < 0.0 AndAlso _Sum > 0.0 Then _Sum = - _Sum
            If _UnitValue < 0.0 AndAlso _SumTotal > 0.0 Then _SumTotal = - _SumTotal
            If _UnitValue < 0.0 AndAlso _SumVat > 0.0 Then _SumVat = - _SumVat

            If pCurrencyRate = 1.0 OrElse pCurrencyRate = 0.0 Then
                Me._DiscountLTL = _Discount
                Me._DiscountVatLTL = _DiscountVat
                Me._SumLTL = _Sum
                Me._SumTotalLTL = _SumTotal
                Me._SumVatLTL = _SumVat
                Me._UnitValueLTL = _UnitValue
            Else
                Me._DiscountLTL = CRound(info.DiscountLTL)
                Me._DiscountVatLTL = CRound(info.DiscountVatLTL)
                Me._SumLTL = CRound(info.SumLTL)
                Me._SumTotalLTL = CRound(info.SumTotalLTL)
                Me._SumVatLTL = CRound(info.SumVatLTL)
                Me._UnitValueLTL = CRound(info.UnitValueLTL, ROUNDUNITINVOICEMADE)
                If _UnitValue < 0.0 AndAlso _SumLTL > 0.0 Then _SumLTL = - _SumLTL
                If _UnitValue < 0.0 AndAlso _SumTotalLTL > 0.0 Then _SumTotalLTL = - _SumTotalLTL
                If _UnitValue < 0.0 AndAlso _SumVatLTL > 0.0 Then _SumVatLTL = - _SumVatLTL
            End If

            If Not accountList.GetAccountByID(info.AccountIncome) Is Nothing Then
                Me._AccountIncome = info.AccountIncome
            Else 
                _AccountIncome = service.AccountSales
            End If

            If Not info.AccountVat > 0 Then
                _AccountVat = service.AccountVatSales
                If Not _AccountVat > 0 Then _AccountVat = GetCurrentCompany() _
                    .GetDefaultAccount(General.DefaultAccountType.VatPayable)
            ElseIf Not accountList.GetAccountByID(info.AccountVat) Is Nothing Then
                Me._AccountVat = info.AccountVat
            End If

            If GetCurrentCompany().UseVatDeclarationSchemas Then

                If Not StringIsNullOrEmpty(info.VatDDeclarationSchemaID) Then
                    Me._DeclarationSchema = vatSchemaList.GetItem(info.VatDDeclarationSchemaID)
                Else
                    Me._DeclarationSchema = service.DeclarationSchemaSales
                End If
                If _DeclarationSchema <> VatDeclarationSchemaInfo.Empty() Then
                    _VatIsVirtual = _DeclarationSchema.VatIsVirtual
                End If

            End If

            CalculateCorrections(pCurrencyRate)

            RestoreChildHandles()

            ValidationRules.CheckRules()

        End Sub


        Private Sub Create(ByVal proformaItem As ProformaInvoiceMadeItem, _
            ByVal baseChronologyValidator As SimpleChronologicValidator, ByVal isBaseCurrency As Boolean)

            If Not proformaItem.TradedItem Is Nothing AndAlso TypeOf proformaItem.TradedItem Is ServiceInfo Then

                Create(ServiceInvoiceAdapter.NewServiceInvoiceAdapter( _
                    DirectCast(proformaItem.TradedItem, ServiceInfo), baseChronologyValidator, True))

            ElseIf Not proformaItem.TradedItem Is Nothing AndAlso TypeOf proformaItem.TradedItem Is GoodsInfo Then

                Create(GoodsSaleInvoiceAdapter.NewGoodsSaleInvoiceAdapterOnServer(proformaItem.TradedItem.ID, _
                    0, baseChronologyValidator, True))
                _Ammount = proformaItem.Amount
                _AttachedObject.SetInvoiceFinancialData(Me)

            Else

                If GetCurrentCompany.UseVatDeclarationSchemas AndAlso GetCurrentCompany.DeclarationSchemaSales _
                <> VatDeclarationSchemaInfo.Empty Then
                    _DeclarationSchema = GetCurrentCompany.DeclarationSchemaSales
                End If

            End If

            _AccountVat = GetCurrentCompany.Accounts.GetAccount(General.DefaultAccountType.VatPayable)

            _Ammount = proformaItem.Amount
            _Discount = proformaItem.Discount
            _DiscountVat = proformaItem.DiscountVat
            _DiscountVatCorrection = proformaItem.DiscountVatCorrection
            _MeasureUnit = proformaItem.MeasureUnit
            _MeasureUnitAltLng = proformaItem.MeasureUnitAltLng
            _NameInvoice = proformaItem.NameInvoice
            _NameInvoiceAltLng = proformaItem.NameInvoiceAltLng
            _Sum = proformaItem.Sum
            _SumCorrection = proformaItem.SumCorrection
            _SumTotal = proformaItem.SumTotal
            _SumVat = proformaItem.SumVat
            _SumVatCorrection = proformaItem.SumVatCorrection
            _UnitValue = proformaItem.UnitValue
            _VatRate = proformaItem.VatRate
            If isBaseCurrency Then
                _UnitValueLTL = _UnitValue
                _SumLTL = _Sum
                _SumVatLTL = _SumVat
                _SumTotalLTL = _SumTotal
            End If

            MarkNew()

            ValidationRules.CheckRules()

        End Sub


        Private Sub Fetch(ByVal dr As DataRow, ByVal invoiceCurrencyRate As Double, _
            ByVal baseChronologyValidator As SimpleChronologicValidator)

            _ID = CIntSafe(dr.Item(0), 0)
            _NameInvoice = CStrSafe(dr.Item(1)).Trim
            _NameInvoiceAltLng = CStrSafe(dr.Item(2)).Trim
            _Ammount = CDblSafe(dr.Item(3), ROUNDAMOUNTINVOICEMADE, 0)
            _UnitValue = CDblSafe(dr.Item(4), ROUNDUNITINVOICEMADE, 0)
            _Sum = CDblSafe(dr.Item(5), 2, 0)
            _VatRate = CDblSafe(dr.Item(6), 2, 0)
            _SumVat = CDblSafe(dr.Item(7), 2, 0)
            _UnitValueLTL = CDblSafe(dr.Item(8), ROUNDUNITINVOICEMADE, 0)
            _SumLTL = CDblSafe(dr.Item(9), 2, 0)
            _SumVatLTL = CDblSafe(dr.Item(10), 2, 0)
            _Discount = CDblSafe(dr.Item(11), 2, 0)
            _DiscountLTL = CDblSafe(dr.Item(12), 2, 0)
            _DiscountVat = CDblSafe(dr.Item(13), 2, 0)
            _DiscountVatLTL = CDblSafe(dr.Item(14), 2, 0)
            _MeasureUnit = CStrSafe(dr.Item(17)).Trim
            _MeasureUnitAltLng = CStrSafe(dr.Item(18)).Trim
            _AccountIncome = CLongSafe(dr.Item(19), 0)
            _AccountVat = CLongSafe(dr.Item(20), 0)
            _AccountDiscount = CLongSafe(dr.Item(21), 0)
            _IncludeVatInObject = ConvertDbBoolean(CIntSafe(dr.Item(22), 0))
            _VatIsVirtual = ConvertDbBoolean(CIntSafe(dr.Item(23), 0))
            _DeclarationSchema = VatDeclarationSchemaInfo.GetVatDeclarationSchemaInfo(dr, 24)

            CalculateCorrections(invoiceCurrencyRate)

            _SumTotal = CRound(_Sum + _SumVat)
            _SumTotalLTL = CRound(_SumLTL + _SumVatLTL)

            If CIntSafe(dr.Item(15), 0) > 0 AndAlso CIntSafe(dr.Item(16), 0) > 0 Then
                _AttachedObject = InvoiceAdapterFactory.GetInvoiceAdapter( _
                    Utilities.ConvertDatabaseID(Of InvoiceAdapterType) _
                    (CIntSafe(dr.Item(15), 0)), CIntSafe(dr.Item(16), 0), _
                    baseChronologyValidator, True)
                RestoreChildHandles()
            End If

            _FinancialDataCanChange = baseChronologyValidator.FinancialDataCanChange

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Private Sub CalculateCorrections(ByVal invoiceCurrencyRate As Double)

            ' _Sum = CRound(CRound(_UnitValue * _Ammount) + _SumCorrection / 100)
            _SumCorrection = Convert.ToInt32(Math.Floor(CRound(_Sum - CRound(_UnitValue * _Ammount)) * 100))
            ' _SumVat = CRound(CRound(_Sum * _VatRate / 100) + _SumVatCorrection / 100)
            _SumVatCorrection = Convert.ToInt32(Math.Floor(CRound(_SumVat - CRound(_Sum * _VatRate / 100)) * 100))
            ' _UnitValueLTL = CRound(CRound(_UnitValue * GetCurrencyRate(pCurrencyRate), 4) _
            '    + _UnitValueCorrectionLTL / 100, 4)
            _UnitValueCorrectionLTL = Convert.ToInt32(Math.Floor(CRound(_UnitValueLTL - _
                CRound(_UnitValue * invoiceCurrencyRate, ROUNDUNITINVOICEMADE)) * 100))
            ' _SumLTL = CRound(CRound(_Sum * GetCurrencyRate(pCurrencyRate)) + _SumCorrectionLTL / 100)
            _SumCorrectionLTL = Convert.ToInt32(Math.Floor(CRound(_SumLTL - CRound(_Sum * invoiceCurrencyRate)) * 100))
            ' _SumVatLTL = CRound(CRound(_SumVat * GetCurrencyRate(pCurrencyRate)) + _SumVatCorrectionLTL / 100)
            _SumVatCorrectionLTL = Convert.ToInt32(Math.Floor(CRound(_SumVatLTL - CRound(_SumVat * invoiceCurrencyRate)) * 100))
            '_DiscountLTL = CRound(CRound(_Discount * GetCurrencyRate(pCurrencyRate)) _
            '    + _DiscountCorrectionLTL / 100)
            _DiscountCorrectionLTL = Convert.ToInt32(Math.Floor(CRound(_DiscountLTL - CRound(_Discount * invoiceCurrencyRate)) * 100))
            '_DiscountVat = CRound(CRound(_VatRate * _Discount / 100) _
            '    + _DiscountVatCorrection / 100)
            _DiscountVatCorrection = Convert.ToInt32(Math.Floor(CRound(_DiscountVat _
                - CRound(_VatRate * _Discount / 100)) * 100))
            '_DiscountVatLTL = CRound(CRound(_DiscountVat * GetCurrencyRate(pCurrencyRate)) _
            '    + _DiscountVatLTLCorrection / 100)
            _DiscountVatLTLCorrection = Convert.ToInt32(Math.Floor(CRound(_DiscountVatLTL - _
                CRound(_DiscountVat * invoiceCurrencyRate)) * 100))

        End Sub


        Friend Sub Insert(ByVal parentInvoice As InvoiceMade)

            If Not _AttachedObject Is Nothing Then
                _AttachedObject.Update(parentInvoice)
            End If

            Dim myComm As New SQLCommand("InsertInvoiceMadeItem")
            myComm.AddParam("?AB", parentInvoice.ID)
            If Not _AttachedObject Is Nothing Then
                myComm.AddParam("?AC", Utilities.ConvertDatabaseID(_AttachedObject.Type))
                myComm.AddParam("?AD", _AttachedObject.Id)
            Else
                myComm.AddParam("?AC", 0)
                myComm.AddParam("?AD", 0)
            End If

            AddWithParamsGeneral(myComm)
            AddWithParamsFinancial(myComm)

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parentInvoice As InvoiceMade)

            If Not _AttachedObject Is Nothing Then
                _AttachedObject.Update(parentInvoice)
            End If

            Dim myComm As SQLCommand
            If FinancialDataCanChange() Then
                myComm = New SQLCommand("UpdateInvoiceMadeItem")
                AddWithParamsFinancial(myComm)
            Else
                myComm = New SQLCommand("UpdateInvoiceMadeItemGeneral")
            End If
            myComm.AddParam("?MD", _ID)
            AddWithParamsGeneral(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Private Sub AddWithParamsGeneral(ByRef myComm As SQLCommand)

            myComm.AddParam("?AE", _NameInvoice.Trim)
            myComm.AddParam("?AF", _NameInvoiceAltLng.Trim)
            myComm.AddParam("?AT", _MeasureUnit.Trim)
            myComm.AddParam("?AU", _MeasureUnitAltLng.Trim)

        End Sub

        Private Sub AddWithParamsFinancial(ByRef myComm As SQLCommand)

            myComm.AddParam("?AG", CRound(_Ammount, ROUNDAMOUNTINVOICEMADE))
            myComm.AddParam("?AH", CRound(_UnitValue, ROUNDUNITINVOICEMADE))
            myComm.AddParam("?AI", CRound(_Sum))
            myComm.AddParam("?AJ", CRound(_VatRate))
            myComm.AddParam("?AK", CRound(_SumVat))
            myComm.AddParam("?AL", CRound(_UnitValueLTL, ROUNDUNITINVOICEMADE))
            myComm.AddParam("?AM", CRound(_SumLTL))
            myComm.AddParam("?AN", CRound(_SumVatLTL))
            myComm.AddParam("?AO", CRound(_Discount))
            myComm.AddParam("?AQ", CRound(_DiscountLTL))
            myComm.AddParam("?AP", CRound(_DiscountVat))
            myComm.AddParam("?AR", CRound(_DiscountVatLTL))
            myComm.AddParam("?AV", _AccountIncome)
            myComm.AddParam("?AW", _AccountVat)
            myComm.AddParam("?BA", _AccountDiscount)
            myComm.AddParam("?BB", ConvertDbBoolean(_IncludeVatInObject))
            myComm.AddParam("?BC", ConvertDbBoolean(_VatIsVirtual))
            If _DeclarationSchema Is Nothing OrElse _DeclarationSchema.IsEmpty Then
                myComm.AddParam("?BD", 0)
            Else
                myComm.AddParam("?BD", _DeclarationSchema.ID)
            End If

        End Sub


        Friend Sub DeleteSelf()

            If Not _AttachedObject Is Nothing Then
                _AttachedObject.DeleteSelf()
            End If

            Dim myComm As New SQLCommand("DeleteInvoiceMadeItem")
            myComm.AddParam("?MD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub


        Friend Sub SetParentData(ByVal parentInvoice As InvoiceMade)
            If Not _AttachedObject Is Nothing Then
                suspendChildChanged = True
                _AttachedObject.SetInvoiceDate(parentInvoice.Date)
                _AttachedObject.SetParentData(parentInvoice)
                suspendChildChanged = False
            End If
        End Sub

        Friend Sub CheckIfCanUpdate(ByVal parentChronologyValidator As IChronologicValidator)
            If Not _AttachedObject Is Nothing Then
                _AttachedObject.CheckIfCanUpdate(parentChronologyValidator)
            End If
        End Sub

        Friend Sub CheckIfCanDelete(ByVal parentChronologyValidator As IChronologicValidator)

            If Not parentChronologyValidator.FinancialDataCanChange Then
                Throw New Exception(String.Format(My.Resources.Documents_InvoiceMadeItem_InvalidItemDelete, _
                    Me.ToString(), vbCrLf, parentChronologyValidator.FinancialDataCanChangeExplanation))
            End If

            If Not _AttachedObject Is Nothing Then
                _AttachedObject.CheckIfCanDelete(parentChronologyValidator)
            End If

        End Sub


        Friend Function GetBookEntryInternalList(ByVal accountBuyer As Long) As BookEntryInternalList

            Dim result As BookEntryInternalList = BookEntryInternalList. _
                NewBookEntryInternalList(BookEntryType.Debetas)

            ' Normal or Debit invoice
            If CRound(_SumLTL) > 0 Then

                ' without attached object
                If _AttachedObject Is Nothing Then

                    ' Discount is accounted by separate bookentry
                    If _AccountDiscount > 0 Then

                        result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                            _AccountIncome, CRound(_SumLTL), Nothing))

                        If CRound(_DiscountLTL) > 0 Then result.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Debetas, _AccountDiscount, _DiscountLTL, Nothing))

                        ' Discount is accounted without a separate bookentry
                    ElseIf CRound(_SumLTL - _DiscountLTL) > 0 Then

                        result.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Kreditas, _AccountIncome, CRound(_SumLTL - _DiscountLTL), Nothing))

                    End If

                    If Not _VatIsVirtual AndAlso CRound(_SumVatLTL - _DiscountVatLTL) > 0 Then
                        result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                            _AccountVat, CRound(_SumVatLTL - _DiscountVatLTL), Nothing))
                    End If

                    ' with delegation to attached object
                Else

                    result.AddRange(_AttachedObject.GetBookEntryList(Me))

                    ' Discount is accounted by separate bookentry
                    If _AccountDiscount > 0 AndAlso CRound(_DiscountLTL) > 0 Then
                        result.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Debetas, _AccountDiscount, _DiscountLTL, Nothing))
                    End If

                    If (Not _AttachedObject.SumVatIsHandledOnRequest OrElse _
                        Not _IncludeVatInObject) AndAlso Not _VatIsVirtual AndAlso _
                        CRound(_SumVatLTL - _DiscountVatLTL) > 0 Then

                        result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                            _AccountVat, CRound(_SumVatLTL - _DiscountVatLTL), Nothing))

                    End If

                End If

                If _VatIsVirtual Then

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                        accountBuyer, CRound(_SumLTL - _DiscountLTL, 2), Nothing))

                Else

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                        accountBuyer, CRound(_SumTotalLTL - _DiscountLTL - _DiscountVatLTL, 2), Nothing))

                End If

                ' Credit invoice (discounts are not applicable)
            Else

                ' without attached object
                If _AttachedObject Is Nothing Then

                    result.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, _AccountIncome, CRound(-_SumLTL), Nothing))

                    If Not _VatIsVirtual AndAlso CRound(-_SumVatLTL) > 0 Then
                        result.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Debetas, _AccountVat, CRound(-_SumVatLTL), Nothing))
                    End If

                    ' with delegation to attached object
                Else

                    result.AddRange(_AttachedObject.GetBookEntryList(Me))

                    If (Not _AttachedObject.SumVatIsHandledOnRequest OrElse _
                        Not _IncludeVatInObject) AndAlso Not _VatIsVirtual AndAlso _
                        CRound(-_SumVatLTL) > 0 Then

                        result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                            _AccountVat, CRound(-_SumVatLTL), Nothing))

                    End If

                End If

                If _VatIsVirtual Then

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                        accountBuyer, CRound(-_SumLTL), Nothing))

                Else

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                        accountBuyer, CRound(-_SumTotalLTL), Nothing))

                End If

            End If

            Return result

        End Function

#End Region

    End Class

End Namespace