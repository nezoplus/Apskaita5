Imports ApskaitaObjects.HelperLists
Namespace Documents

    <Serializable()> _
    Public Class InvoiceMadeItem
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
        Private _IncludeVatInObject As Boolean = False
        Private _AttachedObject As InvoiceAttachedObject = Nothing


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property FinancialDataCanChange() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If Not _AttachedObject Is Nothing AndAlso Not _AttachedObject. _
                    ChronologyValidator.FinancialDataCanChange Then Return False
                Return _FinancialDataCanChange
            End Get
        End Property

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
                    SetAttachedObjectData()
                End If
            End Set
        End Property

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
                    CalculateSum(0)
                    SetAttachedObjectData()
                End If
            End Set
        End Property

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
                    CalculateSum(0)
                    SetAttachedObjectData()
                End If
            End Set
        End Property

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
                    SetAttachedObjectData()
                End If
            End Set
        End Property

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
                    PropertyHasChanged()
                    CalculateSum(0)
                    SetAttachedObjectData()
                End If
            End Set
        End Property

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
                    SetAttachedObjectData()
                End If
            End Set
        End Property

        Public ReadOnly Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
        End Property

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
                    PropertyHasChanged()
                    CalculateSum(0)
                    SetAttachedObjectData()
                End If
            End Set
        End Property

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
                    PropertyHasChanged()
                    CalculateSumVat()
                    CalculateSumVatLTL(0)
                    CalculateDiscountVat(0)
                    CalculateDiscountVatLTL(0)
                    SetAttachedObjectData()
                End If
            End Set
        End Property

        Public ReadOnly Property SumVat() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVat)
            End Get
        End Property

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
                    PropertyHasChanged()
                    CalculateSumVat()
                    CalculateSumVatLTL(0)
                    SetAttachedObjectData()
                End If
            End Set
        End Property

        Public ReadOnly Property SumTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotal)
            End Get
        End Property

        Public ReadOnly Property UnitValueLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitValueLTL, ROUNDUNITINVOICEMADE)
            End Get
        End Property

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
                    SetAttachedObjectData()
                End If
            End Set
        End Property

        Public ReadOnly Property SumLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTL)
            End Get
        End Property

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
                    PropertyHasChanged()
                    CalculateSumLTL(0)
                    SetAttachedObjectData()
                End If
            End Set
        End Property

        Public ReadOnly Property SumVatLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVatLTL)
            End Get
        End Property

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
                    PropertyHasChanged()
                    CalculateSumVatLTL(0)
                    SetAttachedObjectData()
                End If
            End Set
        End Property

        Public ReadOnly Property SumTotalLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotalLTL)
            End Get
        End Property

        Public Property AccountDiscount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountDiscount
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountDiscountIsReadOnly Then Exit Property
                If _AccountIncome <> value Then
                    _AccountDiscount = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

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
                    PropertyHasChanged()
                    CalculateDiscountVat(0)
                    CalculateDiscountLTL(0)
                    SetAttachedObjectData()
                End If
            End Set
        End Property

        Public ReadOnly Property DiscountLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DiscountLTL)
            End Get
        End Property

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
                    PropertyHasChanged()
                    CalculateDiscountLTL(0)
                    SetAttachedObjectData()
                End If
            End Set
        End Property

        Public ReadOnly Property DiscountVat() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DiscountVat)
            End Get
        End Property

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
                    PropertyHasChanged()
                    CalculateDiscountVatLTL(0)
                    SetAttachedObjectData()
                End If
            End Set
        End Property

        Public ReadOnly Property DiscountVatLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DiscountVatLTL)
            End Get
        End Property

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
                    PropertyHasChanged()
                    CalculateDiscountVat(0)
                    CalculateDiscountVatLTL(0)
                    SetAttachedObjectData()
                End If
            End Set
        End Property

        Public ReadOnly Property LanguageCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If Parent Is Nothing Then Return LanguageCodeLith.Trim.ToUpper
                Return DirectCast(Parent, InvoiceMadeItemList).LanguageCode
            End Get
        End Property

        Public ReadOnly Property AttachedObject() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _AttachedObject Is Nothing Then Return ""
                Return _AttachedObject.ToString
            End Get
        End Property

        Public Property IncludeVatInObject() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IncludeVatInObject
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _IncludeVatInObject <> value AndAlso Not _AttachedObject Is Nothing AndAlso _
                    _AttachedObject.VatIsHandledOnRequest AndAlso FinancialDataCanChange() Then
                    _IncludeVatInObject = value
                    PropertyHasChanged()
                    SetAttachedObjectData()
                End If
            End Set
        End Property

        Public ReadOnly Property AttachedObjectValue() As InvoiceAttachedObject
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AttachedObject
            End Get
        End Property


        Public ReadOnly Property AccountIncomeIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange OrElse (Not _AttachedObject Is Nothing AndAlso _
                    _AttachedObject.Type = InvoiceAttachedObjectType.LongTermAssetAcquisitionValueChange)
            End Get
        End Property

        Public ReadOnly Property AccountVatIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property AmmountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property UnitValueIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property SumCorrectionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property VatRateIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property SumVatCorrectionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property UnitValueLTLCorrectionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property SumCorrectionLTLIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property SumVatCorrectionLTLIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property AccountDiscountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property DiscountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property DiscountCorrectionLTLIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property DiscountVatLTLCorrectionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property DiscountVatCorrectionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property IncludeVatInObjectIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not FinancialDataCanChange OrElse _AttachedObject Is Nothing _
                    OrElse Not _AttachedObject.VatIsHandledOnRequest
            End Get
        End Property



        Private Sub CalculateSumVatLTL(ByVal pCurrencyRate As Double)
            _SumVatLTL = CRound(CRound(_SumVat * GetCurrencyRate(pCurrencyRate)) + _SumVatCorrectionLTL / 100)
            _SumTotalLTL = CRound(_SumLTL + _SumVatLTL)
            PropertyHasChanged("SumVatLTL")
            PropertyHasChanged("SumTotalLTL")
        End Sub

        Friend Sub CalculateSumLTL(ByVal pCurrencyRate As Double)
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

        Friend Sub CalculateDiscountLTL(ByVal pCurrencyRate As Double)
            _DiscountLTL = CRound(CRound(_Discount * GetCurrencyRate(pCurrencyRate)) _
                + _DiscountCorrectionLTL / 100)
            PropertyHasChanged("DiscountLTL")
            CalculateDiscountVatLTL(pCurrencyRate)
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
        End Sub

        Friend Function GetCurrencyRate(ByVal pCurrencyRate As Double) As Double
            If CRound(pCurrencyRate, 6) > 0 Then Return pCurrencyRate
            If Parent Is Nothing Then Return 1
            If DirectCast(Parent, InvoiceMadeItemList).CurrencyRate > 0 Then _
                Return DirectCast(Parent, InvoiceMadeItemList).CurrencyRate
            Return 1
        End Function


        Friend Sub UpdateLanguage()
            UpdateServiceInfoNames()
            PropertyHasChanged("LanguageCode")
        End Sub

        Friend Sub UpdateCurrencyRate(ByVal nCurrencyRate As Double)
            If Not _AttachedObject Is Nothing AndAlso Not _AttachedObject.ChronologyValidator. _
                FinancialDataCanChange Then
                Throw New Exception("Eilutės """ & _NameInvoice & """ finansiniai duomenys " _
                    & "negali būti keičiami: " & _AttachedObject.ChronologyValidator. _
                    FinancialDataCanChangeExplanation)
            ElseIf Not _FinancialDataCanChange Then
                Throw New Exception("Jokie sąskaitos faktūros finansiniai duomenys negali būti " _
                    & "keičiami, žr. dokumentui taikomus ribojimus.")
            End If
            UpdateServiceInfoFinancial(False)
            CalculateSum(nCurrencyRate)
            SetAttachedObjectData()
        End Sub


        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & _NameInvoice & "': " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & _NameInvoice & "' gali būti klaida: " & _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
        End Function


        Friend Sub SetAttachedObjectData()
            If _AttachedObject Is Nothing Then Exit Sub
            _AttachedObject.FillWithItemData(Me)
            PropertyHasChanged("AttachedObject")
        End Sub

        Friend Sub SetAttachedObjectInvoiceDate(ByVal InvoiceDate As Date)
            If _AttachedObject Is Nothing Then Exit Sub
            _AttachedObject.FillWithInvoiceDate(InvoiceDate)
            PropertyHasChanged("AttachedObject")
        End Sub

        Public Sub AttachedObjectChanged()
            If _AttachedObject Is Nothing Then Exit Sub
            _AttachedObject.UpdateItemData(Me, AddressOf OnAttachedObjectDataChanged)
            PropertyHasChanged("AttachedObject")
        End Sub

        Private Sub OnAttachedObjectDataChanged(ByVal InvoiceItemContent As String, _
            ByVal UpdateInvoiceItemContent As Boolean, ByVal InvoiceItemMeasureUnit As String, _
            ByVal UpdateInvoiceItemMeasureUnit As Boolean, ByVal InvoiceItemAccount As Long, _
            ByVal UpdateInvoiceItemAccount As Boolean, ByVal InvoiceItemAmount As Double, _
            ByVal UpdateInvoiceItemAmount As Boolean, ByVal InvoiceItemUnitValue As Double, _
            ByVal InvoiceItemSumCorrection As Integer, ByVal InvoiceItemSumVatCorrection As Integer, _
            ByVal InvoiceItemUnitValueLTLCorrection As Integer, ByVal InvoiceItemSumLTLCorrection As Integer, _
            ByVal InvoiceItemSumVatLTLCorrection As Integer, ByVal UpdateInvoiceItemUnitValue As Boolean)

            If UpdateInvoiceItemContent AndAlso _NameInvoice.Trim <> InvoiceItemContent.Trim Then
                _NameInvoice = InvoiceItemContent.Trim
                PropertyHasChanged("NameInvoice")
            End If

            If UpdateInvoiceItemMeasureUnit AndAlso _MeasureUnit.Trim <> InvoiceItemMeasureUnit.Trim Then
                _MeasureUnit = InvoiceItemMeasureUnit.Trim
                PropertyHasChanged("MeasureUnit")
            End If

            If Not FinancialDataCanChange() Then Exit Sub

            If UpdateInvoiceItemAccount AndAlso _AccountIncome <> InvoiceItemAccount Then
                _AccountIncome = InvoiceItemAccount
                PropertyHasChanged("AccountIncome")
            End If

            If UpdateInvoiceItemAmount AndAlso CRound(_Ammount, ROUNDAMOUNTINVOICEMADE) _
                <> CRound(InvoiceItemAmount, ROUNDAMOUNTINVOICEMADE) Then
                _Ammount = InvoiceItemAccount
                PropertyHasChanged("Ammount")
            End If

            If UpdateInvoiceItemUnitValue Then

                _UnitValue = CRound(InvoiceItemUnitValue, ROUNDUNITINVOICEMADE)
                _SumCorrection = InvoiceItemSumCorrection
                _SumVatCorrection = InvoiceItemSumVatCorrection
                _UnitValueCorrectionLTL = InvoiceItemUnitValueLTLCorrection
                _SumCorrectionLTL = InvoiceItemSumLTLCorrection
                _SumVatCorrectionLTL = InvoiceItemSumVatLTLCorrection

                CalculateSum(0)

                PropertyHasChanged("UnitValue")
                PropertyHasChanged("UnitValueCorrectionLTL")
                PropertyHasChanged("SumCorrection")
                PropertyHasChanged("SumCorrectionLTL")
                PropertyHasChanged("SumVatCorrectionLTL")
                PropertyHasChanged("SumVatCorrection")

            End If

        End Sub

        Friend Sub UpdateServiceInfoFinancial(ByVal DoRecalculation As Boolean)

            If _AttachedObject Is Nothing OrElse _AttachedObject.Type _
                <> InvoiceAttachedObjectType.Service OrElse Not Me.FinancialDataCanChange _
                OrElse Me.Parent Is Nothing Then Exit Sub

            Dim s As ServiceInfo = DirectCast(_AttachedObject.ValueObject, ServiceInfo)

            _UnitValue = CRound(s.RegionalPrices.GetRegionalPrice(DirectCast(Me.Parent, _
                InvoiceMadeItemList).CurrencyCode, False), ROUNDUNITINVOICEMADE)
            _VatRate = s.RateVatSales
            PropertyHasChanged("UnitValue")
            PropertyHasChanged("VatRate")
            If Not CRound(_Ammount, ROUNDAMOUNTINVOICEMADE) > 0 Then
                _Ammount = CRound(s.Amount, ROUNDAMOUNTINVOICEMADE)
                PropertyHasChanged("Ammount")
            End If

            If DoRecalculation Then CalculateSum(0)

        End Sub

        Friend Sub UpdateServiceInfoNames()

            If _AttachedObject Is Nothing OrElse _AttachedObject.Type _
                <> InvoiceAttachedObjectType.Service OrElse Me.Parent Is Nothing Then Exit Sub

            Dim s As ServiceInfo = DirectCast(_AttachedObject.ValueObject, ServiceInfo)

            If _NameInvoice Is Nothing OrElse String.IsNullOrEmpty(_NameInvoice) Then
                _NameInvoice = s.RegionalContents.GetRegionalContent(LanguageCodeLith.Trim.ToUpper)
                PropertyHasChanged("NameInvoice")
            End If
            If _MeasureUnit Is Nothing OrElse String.IsNullOrEmpty(_MeasureUnit) Then
                _MeasureUnit = s.RegionalContents.GetRegionalMeasureUnit(LanguageCodeLith.Trim.ToUpper)
                PropertyHasChanged("MeasureUnit")
            End If
            If Me.LanguageCode Is Nothing OrElse String.IsNullOrEmpty(Me.LanguageCode.Trim) _
                OrElse Me.LanguageCode.Trim.ToUpper = LanguageCodeLith.Trim.ToUpper Then
                _NameInvoiceAltLng = ""
                _MeasureUnitAltLng = ""
            Else
                _NameInvoiceAltLng = s.RegionalContents.GetRegionalContent(Me.LanguageCode)
                _MeasureUnitAltLng = s.RegionalContents.GetRegionalMeasureUnit(Me.LanguageCode)
            End If

            PropertyHasChanged("NameInvoiceAltLng")
            PropertyHasChanged("MeasureUnitAltLng")

        End Sub


        Friend Function CanBeCopied() As Boolean
            Return (_AttachedObject Is Nothing OrElse _AttachedObject.Type = _
                InvoiceAttachedObjectType.Service)
        End Function

        Friend Sub MarkAsCopy()
            _ID = -1
            _Guid = Guid.NewGuid
            _FinancialDataCanChange = True
            MarkNew()
        End Sub


        Friend Function GetInvoiceItemInfo() As InvoiceInfo.InvoiceItemInfo

            Dim result As New InvoiceInfo.InvoiceItemInfo

            result.Ammount = Me._Ammount
            result.Comments = ""
            result.Discount = Me._Discount
            result.DiscountCorrection = 0
            result.DiscountLTL = Me._DiscountLTL
            result.DiscountLTLCorrection = Me._DiscountCorrectionLTL
            result.DiscountVat = Me._DiscountVat
            result.DiscountVatCorrection = Me._DiscountVatCorrection
            result.DiscountVatLTL = Me._DiscountVatLTL
            result.DiscountVatLTLCorrection = Me._DiscountVatLTLCorrection
            result.ID = Me._ID.ToString
            result.MeasureUnit = Me._MeasureUnit
            result.MeasureUnitAltLng = Me._MeasureUnitAltLng
            result.NameInvoice = Me._NameInvoice
            result.NameInvoiceAltLng = Me._NameInvoiceAltLng
            result.ProjectCode = ""
            result.Sum = Me._Sum
            result.SumCorrection = Me._SumCorrection
            result.SumLTL = Me._SumLTL
            result.SumLTLCorrection = Me._SumCorrectionLTL
            result.SumReceived = 0
            result.SumTotal = Me._SumTotal
            result.SumTotalLTL = Me._SumTotalLTL
            result.SumVat = Me._SumVat
            result.SumVatCorrection = Me._SumVatCorrection
            result.SumVatLTL = Me._SumVatLTL
            result.SumVatLTLCorrection = Me._SumVatCorrectionLTL
            result.UnitValue = Me._UnitValue
            result.UnitValueCorrection = 0
            result.UnitValueLTL = Me._UnitValueLTL
            result.UnitValueLTLCorrection = Me._UnitValueCorrectionLTL
            result.VatRate = Me._VatRate

            Return result

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            If Not _ID > 0 Then Return ""
            Return _NameInvoice
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("NameInvoice", "eilutės turinys"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("MeasureUnit", "mato vienetas"))
            ValidationRules.AddRule(AddressOf CommonValidation.AltLanguageValidation, _
                New CommonValidation.ReferencePropertyRuleArgs("NameInvoiceAltLng", _
                "eilutės turinys", "LanguageCode", ""))
            ValidationRules.AddRule(AddressOf CommonValidation.AltLanguageValidation, _
                New CommonValidation.ReferencePropertyRuleArgs("MeasureUnitAltLng", _
                "mato vienetas", "LanguageCode", ""))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("AccountIncome", "koresponduojanti (pajamų) sąskaita"))

            ValidationRules.AddRule(AddressOf DiscountValidation, "Discount")
            ValidationRules.AddRule(AddressOf DiscountValidation, "DiscountLTL")
            ValidationRules.AddRule(AddressOf DiscountValidation, "DiscountVat")
            ValidationRules.AddRule(AddressOf DiscountValidation, "DiscountVatLTL")
            ValidationRules.AddRule(AddressOf AmountAndUnitValueValidation, "Ammount")
            ValidationRules.AddRule(AddressOf AmountAndUnitValueValidation, "UnitValue")
            ValidationRules.AddRule(AddressOf AccountVatValidation, "AccountVat")
            ValidationRules.AddRule(AddressOf AttachedObjectValidation, "AttachedObject")

            ValidationRules.AddDependantProperty("LanguageCode", "NameInvoiceAltLng", False)
            ValidationRules.AddDependantProperty("Sum", "Discount", False)
            ValidationRules.AddDependantProperty("SumLTL", "DiscountLTL", False)
            ValidationRules.AddDependantProperty("SumVat", "DiscountVat", False)
            ValidationRules.AddDependantProperty("SumVatLTL", "DiscountVatLTL", False)
            ValidationRules.AddDependantProperty("VatRate", "AccountVat", False)
            ValidationRules.AddDependantProperty("IncludeVatInObject", "AccountVat", False)
            ValidationRules.AddDependantProperty("Ammount", "UnitValue", True)

        End Sub

        ''' <summary>
        ''' Rule ensuring that Discounts are valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DiscountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If CRound(ValObj._Discount) > 0 AndAlso CRound(ValObj._Sum) < 0 Then

                e.Description = "Kreditinėse eilutėse negali būti nuolaidos."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf Not ValObj._AttachedObject Is Nothing AndAlso Not ValObj._AttachedObject.DiscountIsAllowed _
                AndAlso CRound(ValObj._Discount) > 0 Then

                e.Description = "Eilutės objektas nepalaiko nuolaidos."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            If CRound(ValObj._Sum) < 0 Then Return True

            If e.PropertyName = "Discount" AndAlso CRound(ValObj._Discount) > CRound(ValObj._Sum) Then

                e.Description = "Nuolaida negali būti didesnė už sumą."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf e.PropertyName = "DiscountLTL" AndAlso CRound(ValObj._DiscountLTL) > CRound(ValObj._SumLTL) Then

                e.Description = "Nuolaida litais negali būti didesnė už sumą litais."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf e.PropertyName = "DiscountVat" AndAlso CRound(ValObj._DiscountVat) > CRound(ValObj._SumVat) Then

                e.Description = "Nuolaidos PVM negali būti didesnis už PVM sumą."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf e.PropertyName = "DiscountVatLTL" AndAlso CRound(ValObj._DiscountVatLTL) > CRound(ValObj._SumVatLTL) Then

                e.Description = "Nuolaidos PVM litais negali būti didesnis už PVM sumą litais."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that Amount and UnitValue are valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AmountAndUnitValueValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If CRound(ValObj._Ammount, ROUNDAMOUNTINVOICEMADE) = 0 AndAlso e.PropertyName = "Ammount" Then

                e.Description = "Nenurodyta kiekis."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf CRound(ValObj._UnitValue, ROUNDUNITINVOICEMADE) = 0 _
                AndAlso e.PropertyName = "UnitValue" Then

                e.Description = "Nenurodyta vieneto kaina."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf CRound(ValObj._UnitValue, ROUNDUNITINVOICEMADE) < 0 _
                AndAlso CRound(ValObj._Ammount, ROUNDAMOUNTINVOICEMADE) < 0 Then

                e.Description = "Kiekis ir vieneto kaina negali abu būti neigiami."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf Not ValObj._AttachedObject Is Nothing Then

                Return ValObj._AttachedObject.ValidateAmountAndUnitValue(ValObj, e.Description, e.Severity)

            End If

            Return True

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

            Dim ValObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If CRound(ValObj._VatRate) <> 0 AndAlso Not ValObj._AccountVat > 0 AndAlso _
                (Not ValObj._IncludeVatInObject OrElse ValObj._AttachedObject Is Nothing _
                OrElse Not ValObj._AttachedObject.VatIsHandledOnRequest) Then

                e.Description = "Nenurodyta PVM koresponduojanti sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

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

            Dim ValObj As InvoiceMadeItem = DirectCast(target, InvoiceMadeItem)

            If Not ValObj._AttachedObject Is Nothing AndAlso Not ValObj._AttachedObject.IsValid Then

                e.Description = ValObj._AttachedObject.BrokenRulesCollection.ToString( _
                    Validation.RuleSeverity.Error)
                e.Severity = Validation.RuleSeverity.Error
                Return False

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

        Friend Shared Function NewInvoiceMadeItem(ByVal nAttachedObject As InvoiceAttachedObject) As InvoiceMadeItem
            Return New InvoiceMadeItem(nAttachedObject)
        End Function

        Friend Shared Function NewInvoiceMadeItem(ByVal info As InvoiceInfo.InvoiceItemInfo, _
            ByVal pCurrencyRate As Double) As InvoiceMadeItem
            Return New InvoiceMadeItem(info, pCurrencyRate)
        End Function


        Friend Shared Function GetInvoiceMadeItem(ByVal dr As DataRow, ByVal pCurrencyRate As Double, _
            ByVal baseChronologyValidator As SimpleChronologicValidator) As InvoiceMadeItem
            Return New InvoiceMadeItem(dr, pCurrencyRate, baseChronologyValidator)
        End Function


        Friend Shared Function DoomyInvoiceMadeItem(ByVal r As Random) As InvoiceMadeItem

            Dim result As New InvoiceMadeItem

            result._Ammount = CRound(r.Next(1, 1000000) / 10000, ROUNDAMOUNTINVOICEMADE)
            result._NameInvoice = "Kažkokios paslaugos" & r.Next(1, 1000).ToString
            result._NameInvoiceAltLng = "Some services " & r.Next(1, 1000).ToString & " in alternative language"
            result._UnitValue = CRound(r.Next(1, 1000000) / 10000, ROUNDUNITINVOICEMADE)
            result._VatRate = Convert.ToDouble(IIf(r.Next(1, 31) > 20, 0, 21))
            result._MeasureUnit = "vnt."
            result._MeasureUnitAltLng = "unit"

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

        Private Sub New(ByVal nAttachedObject As InvoiceAttachedObject)
            MarkAsChild()
            Create(nAttachedObject)
        End Sub

        Private Sub New(ByVal info As InvoiceInfo.InvoiceItemInfo, ByVal pCurrencyRate As Double)
            MarkAsChild()
            Create(info, pCurrencyRate)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal pCurrencyRate As Double, _
            ByVal baseChronologyValidator As SimpleChronologicValidator)
            MarkAsChild()
            Fetch(dr, pCurrencyRate, baseChronologyValidator)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal nAttachedObject As InvoiceAttachedObject)

            _VatRate = GetCurrentCompany.GetDefaultRate(General.DefaultRateType.Vat)
            _MeasureUnit = GetCurrentCompany.MeasureUnitInvoiceMade
            _AccountVat = GetCurrentCompany.Accounts.GetAccount(General.DefaultAccountType.VatPayable)

            _AttachedObject = nAttachedObject

            If Not nAttachedObject Is Nothing Then

                If nAttachedObject.Type = InvoiceAttachedObjectType.Service Then
                    _AccountIncome = DirectCast(nAttachedObject.ValueObject, ServiceInfo).AccountSales
                    _AccountVat = DirectCast(nAttachedObject.ValueObject, ServiceInfo).AccountVatSales
                    _NameInvoice = DirectCast(nAttachedObject.ValueObject, ServiceInfo). _
                        RegionalContents.GetRegionalContent("LT")
                ElseIf nAttachedObject.Type = InvoiceAttachedObjectType.GoodsAcquisition Then
                    _AccountIncome = DirectCast(nAttachedObject.ValueObject, _
                        Goods.GoodsOperationAcquisition).AcquisitionAccount
                    _NameInvoice = DirectCast(nAttachedObject.ValueObject, _
                        Goods.GoodsOperationAcquisition).GoodsInfo.Name
                    _MeasureUnit = DirectCast(nAttachedObject.ValueObject, _
                        Goods.GoodsOperationAcquisition).GoodsInfo.MeasureUnit
                ElseIf nAttachedObject.Type = InvoiceAttachedObjectType.GoodsTransfer Then
                    _NameInvoice = DirectCast(nAttachedObject.ValueObject, _
                        Goods.GoodsOperationTransfer).GoodsInfo.Name
                    _MeasureUnit = DirectCast(nAttachedObject.ValueObject, _
                        Goods.GoodsOperationTransfer).GoodsInfo.MeasureUnit
                ElseIf nAttachedObject.Type = InvoiceAttachedObjectType.GoodsConsignmentDiscount Then
                    _AccountIncome = DirectCast(nAttachedObject.ValueObject, _
                        Goods.GoodsOperationDiscount).AccountGoodsNetCosts
                    _NameInvoice = "Nuolaida - " & DirectCast(nAttachedObject.ValueObject, _
                        Goods.GoodsOperationDiscount).GoodsInfo.Name
                ElseIf nAttachedObject.Type = InvoiceAttachedObjectType.LongTermAssetSale Then
                    _NameInvoice = DirectCast(nAttachedObject.ValueObject, _
                        Assets.LongTermAssetOperation).AssetName
                    _MeasureUnit = DirectCast(nAttachedObject.ValueObject, _
                        Assets.LongTermAssetOperation).AssetMeasureUnit
                End If

            End If

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Create(ByVal info As InvoiceInfo.InvoiceItemInfo, ByVal pCurrencyRate As Double)

            Me._Ammount = info.Ammount
            Me._Discount = info.Discount
            Me._DiscountLTL = info.DiscountLTL
            Me._DiscountVat = info.DiscountVat
            Me._DiscountVatLTL = info.DiscountVatLTL
            Me._MeasureUnit = info.MeasureUnit
            Me._MeasureUnitAltLng = info.MeasureUnitAltLng
            Me._NameInvoice = info.NameInvoice
            Me._NameInvoiceAltLng = info.NameInvoiceAltLng
            Me._Sum = info.Sum
            Me._SumLTL = info.SumLTL
            Me._SumTotal = info.SumTotal
            Me._SumTotalLTL = info.SumTotalLTL
            Me._SumVat = info.SumVat
            Me._SumVatLTL = info.SumVatLTL
            Me._UnitValue = info.UnitValue
            Me._UnitValueLTL = info.UnitValueLTL
            Me._VatRate = info.VatRate

            CalculateCorrections(pCurrencyRate)

            ValidationRules.CheckRules()

        End Sub


        Private Sub Fetch(ByVal dr As DataRow, ByVal pCurrencyRate As Double, _
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

            CalculateCorrections(pCurrencyRate)

            _SumTotal = CRound(_Sum + _SumVat)
            _SumTotalLTL = CRound(_SumLTL + _SumVatLTL)

            If CIntSafe(dr.Item(15), 0) > 0 AndAlso CIntSafe(dr.Item(16), 0) > 0 Then
                _AttachedObject = InvoiceAttachedObject.GetInvoiceAttachedObject( _
                    ConvertEnumDatabaseCode(Of InvoiceAttachedObjectType) _
                    (CIntSafe(dr.Item(15), 0)), CIntSafe(dr.Item(16), 0), baseChronologyValidator)
            End If

            MarkOld()
            ValidationRules.CheckRules()

        End Sub

        Private Sub CalculateCorrections(ByVal pCurrencyRate As Double)

            ' _Sum = CRound(CRound(_UnitValue * _Ammount) + _SumCorrection / 100)
            _SumCorrection = Convert.ToInt32(Math.Floor(CRound(_Sum - CRound(_UnitValue * _Ammount)) * 100))
            ' _SumVat = CRound(CRound(_Sum * _VatRate / 100) + _SumVatCorrection / 100)
            _SumVatCorrection = Convert.ToInt32(Math.Floor(CRound(_SumVat - CRound(_Sum * _VatRate / 100)) * 100))
            ' _UnitValueLTL = CRound(CRound(_UnitValue * GetCurrencyRate(pCurrencyRate), 4) _
            '    + _UnitValueCorrectionLTL / 100, 4)
            _UnitValueCorrectionLTL = Convert.ToInt32(Math.Floor(CRound(_UnitValueLTL - _
                CRound(_UnitValue * pCurrencyRate, ROUNDUNITINVOICEMADE)) * 100))
            ' _SumLTL = CRound(CRound(_Sum * GetCurrencyRate(pCurrencyRate)) + _SumCorrectionLTL / 100)
            _SumCorrectionLTL = Convert.ToInt32(Math.Floor(CRound(_SumLTL - CRound(_Sum * pCurrencyRate)) * 100))
            ' _SumVatLTL = CRound(CRound(_SumVat * GetCurrencyRate(pCurrencyRate)) + _SumVatCorrectionLTL / 100)
            _SumVatCorrectionLTL = Convert.ToInt32(Math.Floor(CRound(_SumVatLTL - CRound(_SumVat * pCurrencyRate)) * 100))
            '_DiscountLTL = CRound(CRound(_Discount * GetCurrencyRate(pCurrencyRate)) _
            '    + _DiscountCorrectionLTL / 100)
            _DiscountCorrectionLTL = Convert.ToInt32(Math.Floor(CRound(_DiscountLTL - CRound(_Discount * pCurrencyRate)) * 100))
            '_DiscountVat = CRound(CRound(_VatRate * _Discount / 100) _
            '    + _DiscountVatCorrection / 100)
            _DiscountVatCorrection = Convert.ToInt32(Math.Floor(CRound(_DiscountVat _
                - CRound(_VatRate * _Discount / 100)) * 100))
            '_DiscountVatLTL = CRound(CRound(_DiscountVat * GetCurrencyRate(pCurrencyRate)) _
            '    + _DiscountVatLTLCorrection / 100)
            _DiscountVatLTLCorrection = Convert.ToInt32(Math.Floor(CRound(_DiscountVatLTL - _
                CRound(_DiscountVat * pCurrencyRate)) * 100))

        End Sub


        Friend Sub Insert(ByVal parent As InvoiceMade)

            If Not _AttachedObject Is Nothing Then _AttachedObject.Update(parent.ID, _
                parent.Date, parent.Content, parent.Serial & parent.FullNumber, False)

            Dim myComm As New SQLCommand("InsertInvoiceMadeItem")
            myComm.AddParam("?AB", parent.ID)
            If Not _AttachedObject Is Nothing Then
                myComm.AddParam("?AC", ConvertEnumDatabaseCode(_AttachedObject.Type))
                myComm.AddParam("?AD", _AttachedObject.ID)
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

        Friend Sub Update(ByVal parent As InvoiceMade)

            If Not _AttachedObject Is Nothing Then _AttachedObject.Update(parent.ID, _
                parent.Date, parent.Content, parent.Serial & parent.FullNumber, Not FinancialDataCanChange())

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

        End Sub


        Friend Sub DeleteSelf()

            If Not _AttachedObject Is Nothing Then _AttachedObject.DeleteSelf()

            Dim myComm As New SQLCommand("DeleteInvoiceMadeItem")
            myComm.AddParam("?MD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub


        Friend Sub CheckIfCanUpdate(ByVal FinancialDataReadOnly As Boolean, _
            ByVal parentChronologyValidator As IChronologicValidator)
            If Not _AttachedObject Is Nothing Then
                _AttachedObject.CheckDataSync(Me)
                _AttachedObject.CheckIfCanUpdate(FinancialDataReadOnly, parentChronologyValidator)
            End If
        End Sub

        Friend Sub CheckIfCanDelete(ByVal parentChronologyValidator As IChronologicValidator)
            If Not parentChronologyValidator.FinancialDataCanChange Then Throw New Exception( _
                "Klaida. Sąskaitos faktūros eilučių pašalinti neleidžiama:" & vbCrLf _
                & parentChronologyValidator.FinancialDataCanChangeExplanation)
            If Not _AttachedObject Is Nothing Then _AttachedObject.CheckIfCanDelete(parentChronologyValidator)
        End Sub


        Friend Function GetBookEntryInternalList(ByVal AccountBuyer As Long) As BookEntryInternalList

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

                    If CRound(_SumVatLTL - _DiscountVatLTL) > 0 Then result.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, _AccountVat, CRound(_SumVatLTL - _DiscountVatLTL), Nothing))

                    ' with delegation to attached object
                Else

                    ' Discount is accounted by separate bookentry
                    If _AccountDiscount > 0 Then

                        result.AddRange(_AttachedObject.GetBookEntryList(CRound(_SumLTL), _AccountIncome, True))

                        If CRound(_DiscountLTL) > 0 Then result.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Debetas, _AccountDiscount, _DiscountLTL, Nothing))

                        ' Discount is accounted without a separate bookentry
                    Else

                        result.AddRange(_AttachedObject.GetBookEntryList(CRound(_SumLTL - _DiscountLTL), _
                            _AccountIncome, True))

                    End If

                    If (Not _AttachedObject.VatIsHandledOnRequest OrElse _
                        Not _IncludeVatInObject) AndAlso CRound(_SumVatLTL - _DiscountVatLTL) > 0 Then _
                        result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                        _AccountVat, CRound(_SumVatLTL - _DiscountVatLTL), Nothing))

                End If

                result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                    AccountBuyer, CRound(_SumTotalLTL - _DiscountLTL - _DiscountVatLTL), Nothing))

                ' Credit invoice (discounts are not applicable)
            Else

                ' without attached object
                If _AttachedObject Is Nothing Then

                    result.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, _AccountIncome, CRound(-_SumLTL), Nothing))

                    If CRound(-_SumVatLTL) > 0 Then result.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, _AccountVat, CRound(-_SumVatLTL), Nothing))

                    ' with delegation to attached object
                Else

                    result.AddRange(_AttachedObject.GetBookEntryList(-_SumLTL, _AccountIncome, False))

                    If (Not _AttachedObject.VatIsHandledOnRequest OrElse _
                        Not _IncludeVatInObject) AndAlso CRound(-_SumVatLTL) > 0 Then _
                        result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                        _AccountVat, CRound(-_SumVatLTL), Nothing))

                End If

                result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                    AccountBuyer, CRound(-_SumTotalLTL), Nothing))

            End If

            Return result

        End Function

        Friend Sub ResetBindings()
            Me.OnUnknownPropertyChanged()
        End Sub

#End Region

    End Class

End Namespace