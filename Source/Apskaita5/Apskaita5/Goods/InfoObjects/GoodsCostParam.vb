﻿Namespace Goods

    ''' <summary>
    ''' Represents a collection of parameters that are used to calculate goods 
    ''' value for a certain amount of the goods (to be discarded).
    ''' </summary>
    ''' <remarks>Used to pass parameters in <see cref="GoodsCostItem">GoodsCostItem</see>
    ''' and <see cref="GoodsCostItemList">GoodsCostItemList</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsCostParam
        Inherits ReadOnlyBase(Of GoodsCostParam)

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid()
        Private ReadOnly _GoodsID As Integer = 0
        Private ReadOnly _WarehouseID As Integer = 0
        Private ReadOnly _Amount As Double = 0
        Private ReadOnly _ConsignmentParentID As Integer = 0
        Private ReadOnly _DiscardParentID As Integer = 0
        Private ReadOnly _ValuationMethod As GoodsValuationMethod = GoodsValuationMethod.FIFO
        Private ReadOnly _CalculationDate As Date = Date.MaxValue


        ''' <summary>
        ''' an <see cref="GoodsItem.ID">ID of the goods</see> which value should be calculated.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property GoodsID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsID
            End Get
        End Property

        ''' <summary>
        ''' an <see cref="Warehouse.ID">ID of the warehouse</see> of the goods 
        ''' which value should be calculated.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property WarehouseID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WarehouseID
            End Get
        End Property

        ''' <summary>
        ''' an amount of the goods to calculate the value for. 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount, ROUNDAMOUNTGOODS)
            End Get
        End Property

        ''' <summary>
        ''' an <see cref="OperationPersistenceObject.ID">ID of the parent goods operation</see>
        ''' that is also a parent of <see cref="ConsignmentPersistenceObject.ParentID">
        ''' goods consignements</see>. (in order to ignore consignments that are part 
        ''' of the parent operation) 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ConsignmentParentID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ConsignmentParentID
            End Get
        End Property

        ''' <summary>
        ''' an <see cref="OperationPersistenceObject.ID">ID of the parent goods operation</see>
        ''' that is also a parent of <see cref="ConsignmentDiscardPersistenceObject.ParentID">
        ''' goods consignements discard</see>. (in order to ignore consignments discards 
        ''' that are part of the parent operation) 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DiscardParentID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DiscardParentID
            End Get
        End Property

        ''' <summary>
        ''' a valuation method of the goods to apply. 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ValuationMethod() As GoodsValuationMethod
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ValuationMethod
            End Get
        End Property

        ''' <summary>
        ''' a date at which the calculatios should be done, i.e. only to take
        ''' into account the goods consignments that are acquired before the calculation date. 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CalculationDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CalculationDate
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Goods_GoodsCostParam_ToString, _
                _CalculationDate.ToString("yyyy-MM-dd"), _GoodsID.ToString, _
                _WarehouseID.ToString, DblParser(_Amount, ROUNDAMOUNTGOODS), _
                Utilities.ConvertLocalizedName(_ValuationMethod))
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new instance of GoodsCostParam.
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see> 
        ''' which value should be calculated</param>
        ''' <param name="warehouseID">an <see cref="Warehouse.ID">ID of the warehouse</see> 
        ''' of the goods which value should be calculated</param>
        ''' <param name="amount">an amount of the goods to calculate the value for</param>
        ''' <param name="discardParentID">an <see cref="OperationPersistenceObject.ID">
        ''' ID of the parent goods operation</see> that is also a parent of 
        ''' <see cref="ConsignmentDiscardPersistenceObject.ParentID">
        ''' goods consignements discard</see>. (in order to ignore consignments discards 
        ''' that are part of the parent operation)</param>
        ''' <param name="consignmentParentID">an <see cref="OperationPersistenceObject.ID">
        ''' ID of the parent goods operation</see> that is also a parent of 
        ''' <see cref="ConsignmentPersistenceObject.ParentID">goods consignements</see>. 
        ''' (in order to ignore consignments that are part of the parent operation)</param>
        ''' <param name="valuationMethod">a valuation method of the goods to apply</param>
        ''' <param name="calculationDate">a date at which the calculatios should be done, 
        ''' i.e. only to take into account the goods consignments that are acquired 
        ''' before the calculation date</param>
        ''' <remarks></remarks>
        Public Shared Function NewGoodsCostParam(ByVal goodsID As Integer, _
            ByVal warehouseID As Integer, ByVal amount As Double, ByVal discardParentID As Integer, _
            ByVal consignmentParentID As Integer, ByVal valuationMethod As GoodsValuationMethod, _
            ByVal calculationDate As Date) As GoodsCostParam
            Return New GoodsCostParam(goodsID, warehouseID, amount, discardParentID, _
                consignmentParentID, valuationMethod, calculationDate)
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