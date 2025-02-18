﻿<Serializable()> _
Public Class InvoiceItemInfo

    Private _ID As String = ""
    Private _NameInvoice As String = ""
    Private _NameInvoiceAltLng As String = ""
    Private _MeasureUnit As String = ""
    Private _MeasureUnitAltLng As String = ""
    Private _Ammount As Double = 0
    Private _UnitValueLTL As Double = 0
    Private _UnitValueLTLCorrection As Integer = 0
    Private _SumLTL As Double = 0
    Private _SumLTLCorrection As Integer = 0
    Private _VatRate As Double = 0
    Private _VatIsVirtual As Boolean = False
    Private _VatDDeclarationSchemaID As String = ""
    Private _SumVatLTL As Double = 0
    Private _SumVatLTLCorrection As Integer = 0
    Private _SumTotalLTL As Double = 0
    Private _UnitValue As Double = 0
    Private _UnitValueCorrection As Integer = 0
    Private _Sum As Double = 0
    Private _SumCorrection As Integer = 0
    Private _SumVat As Double = 0
    Private _SumVatCorrection As Integer = 0
    Private _SumTotal As Double = 0
    Private _DiscountLTL As Double = 0
    Private _DiscountLTLCorrection As Integer = 0
    Private _Discount As Double = 0
    Private _DiscountCorrection As Integer = 0
    Private _DiscountVatLTL As Double = 0
    Private _DiscountVatLTLCorrection As Integer = 0
    Private _DiscountVat As Double = 0
    Private _DiscountVatCorrection As Integer = 0
    Private _ProjectCode As String = ""
    Private _Comments As String = ""
    Private _SumReceived As Double = 0
    Private _AccountVat As Long = 0
    Private _AccountIncome As Long = 0


    Public Property ID() As String
        Get
            Return _ID.Trim
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then value = ""
            If _ID.Trim <> value.Trim Then
                _ID = value.Trim
            End If
        End Set
    End Property

    Public Property NameInvoice() As String
        Get
            Return _NameInvoice.Trim
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then value = ""
            If _NameInvoice.Trim <> value.Trim Then
                _NameInvoice = value.Trim
            End If
        End Set
    End Property

    Public Property NameInvoiceAltLng() As String
        Get
            Return _NameInvoiceAltLng.Trim
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then value = ""
            If _NameInvoiceAltLng.Trim <> value.Trim Then
                _NameInvoiceAltLng = value.Trim
            End If
        End Set
    End Property

    Public Property MeasureUnit() As String
        Get
            Return _MeasureUnit.Trim
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then value = ""
            If _MeasureUnit.Trim <> value.Trim Then
                _MeasureUnit = value.Trim
            End If
        End Set
    End Property

    Public Property MeasureUnitAltLng() As String
        Get
            Return _MeasureUnitAltLng.Trim
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then value = ""
            If _MeasureUnitAltLng.Trim <> value.Trim Then
                _MeasureUnitAltLng = value.Trim
            End If
        End Set
    End Property

    Public Property Ammount() As Double
        Get
            Return _Ammount
        End Get
        Set(ByVal value As Double)
            If _Ammount <> value Then
                _Ammount = value
            End If
        End Set
    End Property

    Public Property UnitValueLTL() As Double
        Get
            Return _UnitValueLTL
        End Get
        Set(ByVal value As Double)
            If _UnitValueLTL <> value Then
                _UnitValueLTL = value
            End If
        End Set
    End Property

    Public Property UnitValueLTLCorrection() As Integer
        Get
            Return _UnitValueLTLCorrection
        End Get
        Set(ByVal value As Integer)
            If _UnitValueLTLCorrection <> value Then
                _UnitValueLTLCorrection = value
            End If
        End Set
    End Property

    Public Property SumLTL() As Double
        Get
            Return _SumLTL
        End Get
        Set(ByVal value As Double)
            If _SumLTL <> value Then
                _SumLTL = value
            End If
        End Set
    End Property

    Public Property SumLTLCorrection() As Integer
        Get
            Return _SumLTLCorrection
        End Get
        Set(ByVal value As Integer)
            If _SumLTLCorrection <> value Then
                _SumLTLCorrection = value
            End If
        End Set
    End Property

    Public Property VatRate() As Double
        Get
            Return _VatRate
        End Get
        Set(ByVal value As Double)
            If _VatRate <> value Then
                _VatRate = value
            End If
        End Set
    End Property

    Public Property VatIsVirtual() As Boolean
        Get
            Return _VatIsVirtual
        End Get
        Set(ByVal value As Boolean)
            If _VatIsVirtual <> value Then
                _VatIsVirtual = value
            End If
        End Set
    End Property

    Public Property VatDDeclarationSchemaID() As String
        Get
            Return _VatDDeclarationSchemaID
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then value = ""
            If _VatDDeclarationSchemaID <> value Then
                _VatDDeclarationSchemaID = value
            End If
        End Set
    End Property

    Public Property SumVatLTL() As Double
        Get
            Return _SumVatLTL
        End Get
        Set(ByVal value As Double)
            If _SumVatLTL <> value Then
                _SumVatLTL = value
            End If
        End Set
    End Property

    Public Property SumVatLTLCorrection() As Integer
        Get
            Return _SumVatLTLCorrection
        End Get
        Set(ByVal value As Integer)
            If _SumVatLTLCorrection <> value Then
                _SumVatLTLCorrection = value
            End If
        End Set
    End Property

    Public Property SumTotalLTL() As Double
        Get
            Return _SumTotalLTL
        End Get
        Set(ByVal value As Double)
            If _SumTotalLTL <> value Then
                _SumTotalLTL = value
            End If
        End Set
    End Property

    Public Property UnitValue() As Double
        Get
            Return _UnitValue
        End Get
        Set(ByVal value As Double)
            If _UnitValue <> value Then
                _UnitValue = value
            End If
        End Set
    End Property

    Public Property UnitValueCorrection() As Integer
        Get
            Return _UnitValueCorrection
        End Get
        Set(ByVal value As Integer)
            If _UnitValueCorrection <> value Then
                _UnitValueCorrection = value
            End If
        End Set
    End Property

    Public Property Sum() As Double
        Get
            Return _Sum
        End Get
        Set(ByVal value As Double)
            If _Sum <> value Then
                _Sum = value
            End If
        End Set
    End Property

    Public Property SumCorrection() As Integer
        Get
            Return _SumCorrection
        End Get
        Set(ByVal value As Integer)
            If _SumCorrection <> value Then
                _SumCorrection = value
            End If
        End Set
    End Property

    Public Property SumVat() As Double
        Get
            Return _SumVat
        End Get
        Set(ByVal value As Double)
            If _SumVat <> value Then
                _SumVat = value
            End If
        End Set
    End Property

    Public Property SumVatCorrection() As Integer
        Get
            Return _SumVatCorrection
        End Get
        Set(ByVal value As Integer)
            If _SumVatCorrection <> value Then
                _SumVatCorrection = value
            End If
        End Set
    End Property

    Public Property SumTotal() As Double
        Get
            Return _SumTotal
        End Get
        Set(ByVal value As Double)
            If _SumTotal <> value Then
                _SumTotal = value
            End If
        End Set
    End Property

    Public Property DiscountLTL() As Double
        Get
            Return _DiscountLTL
        End Get
        Set(ByVal value As Double)
            If _DiscountLTL <> value Then
                _DiscountLTL = value
            End If
        End Set
    End Property

    Public Property DiscountLTLCorrection() As Integer
        Get
            Return _DiscountLTLCorrection
        End Get
        Set(ByVal value As Integer)
            If _DiscountLTLCorrection <> value Then
                _DiscountLTLCorrection = value
            End If
        End Set
    End Property

    Public Property Discount() As Double
        Get
            Return _Discount
        End Get
        Set(ByVal value As Double)
            If _Discount <> value Then
                _Discount = value
            End If
        End Set
    End Property

    Public Property DiscountCorrection() As Integer
        Get
            Return _DiscountCorrection
        End Get
        Set(ByVal value As Integer)
            If _DiscountCorrection <> value Then
                _DiscountCorrection = value
            End If
        End Set
    End Property

    Public Property DiscountVatLTL() As Double
        Get
            Return _DiscountVatLTL
        End Get
        Set(ByVal value As Double)
            If _DiscountVatLTL <> value Then
                _DiscountVatLTL = value
            End If
        End Set
    End Property

    Public Property DiscountVatLTLCorrection() As Integer
        Get
            Return _DiscountVatLTLCorrection
        End Get
        Set(ByVal value As Integer)
            If _DiscountVatLTLCorrection <> value Then
                _DiscountVatLTLCorrection = value
            End If
        End Set
    End Property

    Public Property DiscountVat() As Double
        Get
            Return _DiscountVat
        End Get
        Set(ByVal value As Double)
            If _DiscountVat <> value Then
                _DiscountVat = value
            End If
        End Set
    End Property

    Public Property DiscountVatCorrection() As Integer
        Get
            Return _DiscountVatCorrection
        End Get
        Set(ByVal value As Integer)
            If _DiscountVatCorrection <> value Then
                _DiscountVatCorrection = value
            End If
        End Set
    End Property

    Public Property ProjectCode() As String
        Get
            Return _ProjectCode.Trim
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then value = ""
            If _ProjectCode.Trim <> value.Trim Then
                _ProjectCode = value.Trim
            End If
        End Set
    End Property

    Public Property Comments() As String
        Get
            Return _Comments.Trim
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then value = ""
            If _Comments.Trim <> value.Trim Then
                _Comments = value.Trim
            End If
        End Set
    End Property

    Public Property SumReceived() As Double
        Get
            Return _SumReceived
        End Get
        Set(ByVal value As Double)
            If _SumReceived <> value Then
                _SumReceived = value
            End If
        End Set
    End Property

    Public Property AccountVat() As Long
        Get
            Return _AccountVat
        End Get
        Set(ByVal value As Long)
            If _AccountVat <> value Then
                _AccountVat = value
            End If
        End Set
    End Property

    Public Property AccountIncome() As Long
        Get
            Return _AccountIncome
        End Get
        Set(ByVal value As Long)
            If _AccountIncome <> value Then
                _AccountIncome = value
            End If
        End Set
    End Property


    Public Sub New()

    End Sub

End Class