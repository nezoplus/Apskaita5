Namespace Goods

    <Serializable()> _
    Public Class GoodsCostParam
        Inherits ReadOnlyBase(Of GoodsCostParam)

#Region " Business Methods "

        Private _GoodsID As Integer = 0
        Private _WarehouseID As Integer = 0
        Private _Amount As Double = 0
        Private _ConsignmentParentID As Integer = 0
        Private _DiscardParentID As Integer = 0
        Private _ValuationMethod As GoodsValuationMethod = GoodsValuationMethod.FIFO
        Private _CalculationDate As Date = Date.MaxValue
        

        Public ReadOnly Property GoodsID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsID
            End Get
        End Property

        Public ReadOnly Property WarehouseID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WarehouseID
            End Get
        End Property

        Public ReadOnly Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount, 6)
            End Get
        End Property

        Public ReadOnly Property ConsignmentParentID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ConsignmentParentID
            End Get
        End Property

        Public ReadOnly Property DiscardParentID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DiscardParentID
            End Get
        End Property

        Public ReadOnly Property ValuationMethod() As GoodsValuationMethod
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ValuationMethod
            End Get
        End Property

        Public ReadOnly Property CalculationDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CalculationDate
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _GoodsID.ToString & "-" & _WarehouseID.ToString
        End Function

        Public Overrides Function ToString() As String
            Return _GoodsID.ToString & "-" & _WarehouseID.ToString
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetGoodsCostParam(ByVal nGoodsID As Integer, _
            ByVal nWarehouseID As Integer, ByVal nAmount As Double, ByVal nDiscardParentID As Integer, _
            ByVal nConsignmentParentID As Integer, ByVal nValuationMethod As GoodsValuationMethod, _
            ByVal nCalculationDate As Date) As GoodsCostParam
            Return New GoodsCostParam(nGoodsID, nWarehouseID, nAmount, nDiscardParentID, _
                nConsignmentParentID, nValuationMethod, nCalculationDate)
        End Function

        Private Sub New(ByVal nGoodsID As Integer, ByVal nWarehouseID As Integer, _
            ByVal nAmount As Double, ByVal nDiscardParentID As Integer, _
            ByVal nConsignmentParentID As Integer, ByVal nValuationMethod As GoodsValuationMethod, _
            ByVal nCalculationDate As Date)
            ' require use of factory methods
            _GoodsID = nGoodsID
            _WarehouseID = nWarehouseID
            _Amount = nAmount
            _DiscardParentID = nDiscardParentID
            _ConsignmentParentID = nConsignmentParentID
            _ValuationMethod = nValuationMethod
            _CalculationDate = nCalculationDate
        End Sub

#End Region

    End Class

End Namespace