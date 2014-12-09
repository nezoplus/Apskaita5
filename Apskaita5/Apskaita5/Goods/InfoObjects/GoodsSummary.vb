Namespace Goods

    <Serializable()> _
    Public Class GoodsSummary
        Inherits ReadOnlyBase(Of GoodsSummary)

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _Name As String = ""
        Private _MeasureUnit As String = ""
        Private _GroupName As String = ""
        Private _DefaultWarehouse As WarehouseInfo
        Private _DefaultWarehouseName As String = ""
        Private _AccountGeneral As Long = 0
        Private _AccountSalesNetCosts As Long = 0
        Private _AccountPurchases As Long = 0
        Private _AccountDiscounts As Long = 0
        Private _AccountValueReduction As Long = 0
        Private _PriceSale As Double = 0
        Private _PricePurchase As Double = 0
        Private _DefaultVatRateSales As Double = 0
        Private _DefaultVatRatePurchase As Double = 0
        Private _AccountingMethod As GoodsAccountingMethod = GoodsAccountingMethod.Persistent
        Private _ValuationMethod As GoodsValuationMethod = GoodsValuationMethod.FIFO
        Private _AccountingMethodHumanReadable As String = ConvertEnumHumanReadable(GoodsAccountingMethod.Persistent)
        Private _ValuationMethodHumanReadable As String = ConvertEnumHumanReadable(GoodsValuationMethod.FIFO)


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
        End Property

        Public ReadOnly Property MeasureUnit() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MeasureUnit.Trim
            End Get
        End Property

        Public ReadOnly Property GroupName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GroupName.Trim
            End Get
        End Property

        Public ReadOnly Property DefaultWarehouse() As WarehouseInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DefaultWarehouse
            End Get
        End Property

        Public ReadOnly Property DefaultWarehouseName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DefaultWarehouseName
            End Get
        End Property

        Public ReadOnly Property AccountGeneral() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountGeneral
            End Get
        End Property

        Public ReadOnly Property AccountSalesNetCosts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountSalesNetCosts
            End Get
        End Property

        Public ReadOnly Property AccountPurchases() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountPurchases
            End Get
        End Property

        Public ReadOnly Property AccountDiscounts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountDiscounts
            End Get
        End Property

        Public ReadOnly Property AccountValueReduction() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountValueReduction
            End Get
        End Property

        Public ReadOnly Property PriceSale() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PriceSale)
            End Get
        End Property

        Public ReadOnly Property PricePurchase() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PricePurchase)
            End Get
        End Property

        Public ReadOnly Property DefaultVatRateSales() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DefaultVatRateSales)
            End Get
        End Property

        Public ReadOnly Property DefaultVatRatePurchase() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DefaultVatRatePurchase)
            End Get
        End Property

        Public ReadOnly Property AccountingMethod() As GoodsAccountingMethod
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountingMethod
            End Get
        End Property

        Public ReadOnly Property ValuationMethod() As GoodsValuationMethod
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ValuationMethod
            End Get
        End Property

        Public ReadOnly Property AccountingMethodHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountingMethodHumanReadable.Trim
            End Get
        End Property

        Public ReadOnly Property ValuationMethodHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ValuationMethodHumanReadable.Trim
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return _Name
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function GetGoodsSummary(ByVal GoodsID As Integer) As GoodsSummary
            Return New GoodsSummary(GoodsID)
        End Function

        Friend Shared Function GetGoodsSummary(ByVal dr As DataRow, ByVal offset As Integer) As GoodsSummary
            Return New GoodsSummary(dr, offset)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal GoodsID As Integer)
            Fetch(GoodsID)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal offset As Integer)
            Fetch(dr, offset)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal GoodsID As Integer)

            Dim myComm As New SQLCommand("FetchGoodsSummary")
            myComm.AddParam("?GD", GoodsID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception("Prekė, kurios ID=" _
                    & GoodsID.ToString & " nerasta.")

                Fetch(myData.Rows(0), 0)

            End Using

        End Sub

        Private Sub Fetch(ByVal dr As DataRow, ByVal offset As Integer)

            _ID = CIntSafe(dr.Item(0 + offset), 0)
            _Name = CStrSafe(dr.Item(1 + offset)).Trim
            _MeasureUnit = CStrSafe(dr.Item(2 + offset)).Trim
            _AccountSalesNetCosts = CLongSafe(dr.Item(3 + offset), 0)
            _AccountPurchases = CLongSafe(dr.Item(4 + offset), 0)
            _AccountDiscounts = CLongSafe(dr.Item(5 + offset), 0)
            _AccountValueReduction = CLongSafe(dr.Item(6 + offset), 0)
            _PriceSale = CDblSafe(dr.Item(7 + offset), 2, 0)
            _PricePurchase = CDblSafe(dr.Item(8 + offset), 2, 0)
            _DefaultVatRateSales = CDblSafe(dr.Item(9 + offset), 2, 0)
            _DefaultVatRatePurchase = CDblSafe(dr.Item(10 + offset), 2, 0)
            _GroupName = CStrSafe(dr.Item(11 + offset)).Trim
            _AccountingMethod = ConvertEnumDatabaseCode(Of GoodsAccountingMethod) _
                (CIntSafe(dr.Item(12 + offset), 0))
            _ValuationMethod = ConvertEnumDatabaseCode(Of GoodsValuationMethod) _
                (CIntSafe(dr.Item(13 + offset), 0))
            _AccountingMethodHumanReadable = ConvertEnumHumanReadable(_AccountingMethod)
            _ValuationMethodHumanReadable = ConvertEnumHumanReadable(_ValuationMethod)
            _DefaultWarehouse = WarehouseInfo.GetWarehouseInfo(dr, 14 + offset)
            _DefaultWarehouseName = _DefaultWarehouse.ToString
            _AccountGeneral = _DefaultWarehouse.WarehouseAccount

        End Sub

#End Region

    End Class

End Namespace