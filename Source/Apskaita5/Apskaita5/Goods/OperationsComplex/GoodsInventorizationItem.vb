﻿Imports ApskaitaObjects.My.Resources

Namespace Goods

    ''' <summary>
    ''' Represents a goods inventory operation item for a particular goods in 
    ''' <see cref="GoodsComplexOperationInventorization.WarehouseName">
    ''' a particular warehouse</see>.
    ''' </summary>
    ''' <remarks>Values are persisted using a <see cref="OperationPersistenceObject">
    ''' OperationPersistenceObject</see>.
    ''' Should only be used as a child of <see cref="GoodsInventorizationItemList">GoodsInventorizationItemList</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsInventorizationItem
        Inherits BusinessBase(Of GoodsInventorizationItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _GoodsInfo As GoodsSummary = Nothing
        Private _OperationLimitations As OperationalLimitList = Nothing
        Private _AmountLastInventorization As Double = 0
        Private _UnitValueLastInventorization As Double = 0
        Private _TotalValueLastInventorization As Double = 0
        Private _AmountAcquisitions As Double = 0
        Private _TotalValueAcquisitions As Double = 0
        Private _AmountDisposed As Double = 0
        Private _TotalValueDisposed As Double = 0
        Private _AmountTransfered As Double = 0
        Private _TotalValueTransfered As Double = 0
        Private _TotalValueAdditionalCosts As Double = 0
        Private _TotalValueDiscount As Double = 0
        Private _AmountCalculated As Double = 0
        Private _UnitValueCalculated As Double = 0
        Private _TotalValueCalculated As Double = 0
        Private _AmountChange As Double = 0
        Private _AmountAfterInventorization As Double = 0
        Private _TotalValueAfterInventorization As Double = 0
        Private _AccountCorresponding As Long = 0
        Private _Remarks As String = ""


        ''' <summary>
        ''' Gets an ID of the operation that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.ID">OperationPersistenceObject.ID</see>.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="GoodsSummary">general information about the goods</see> 
        ''' that are inventoried by the operation.
        ''' </summary>
        ''' <remarks>Is set when creating a new operation and cannot be changed afterwards.
        ''' Corresponds to <see cref="OperationPersistenceObject.GoodsInfo">OperationPersistenceObject.GoodsInfo</see>.</remarks>
        Public ReadOnly Property GoodsInfo() As GoodsSummary
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsItem.Name">name of the goods</see> 
        ''' that are inventoried by the operation.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsInfo">GoodsInfo</see> field
        ''' to enable databinding in a datagridview.</remarks>
        Public ReadOnly Property GoodsName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.Name
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsItem.MeasureUnit">measure unit of the goods</see> 
        ''' that are inventoried by the operation.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsInfo">GoodsInfo</see> field
        ''' to enable databinding in a datagridview.</remarks>
        Public ReadOnly Property GoodsMeasureUnit() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.MeasureUnit
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="GoodsItem.AccountingMethod">accounting method for the goods</see> 
        ''' that are inventoried by the operation as a localized human readable string.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsInfo">GoodsInfo</see> field
        ''' to enable databinding in a datagridview.</remarks>
        Public ReadOnly Property GoodsAccountingMethod() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethodHumanReadable
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsItem.DefaultValuationMethod">current valuation method 
        ''' for the goods</see> that are inventoried by the operation as a localized 
        ''' human readable string.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsInfo">GoodsInfo</see> field
        ''' to enable databinding in a datagridview.</remarks>
        Public ReadOnly Property GoodsValuationMethod() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.ValuationMethodHumanReadable
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="IChronologicValidator">IChronologicValidator</see> object 
        ''' that contains business restraints on updating the operation data.
        ''' </summary>
        ''' <remarks>A <see cref="OperationalLimitList">OperationalLimitList</see> 
        ''' is used to validate a goods operation chronological business rules.</remarks>
        Public ReadOnly Property OperationLimitations() As OperationalLimitList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationLimitations
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="AmountAfterInventorization">amount of 
        ''' the goods</see> at the date of the previous inventory (or
        ''' <see cref="GoodsTransferOfBalanceItem.AmountInWarehouse">transfer of goods balance</see>).
        ''' </summary>
        ''' <remarks>Value is fetched by a subquery.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDAMOUNTGOODS)> _
        Public ReadOnly Property AmountLastInventorization() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountLastInventorization, ROUNDAMOUNTGOODS)
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="UnitValueCalculated">unit value of 
        ''' the goods</see> at the date of the previous inventory (or
        ''' <see cref="GoodsTransferOfBalanceItem.UnitCost">transfer of goods balance</see>).
        ''' </summary>
        ''' <remarks>Value is fetched by a subquery.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDUNITGOODS)> _
        Public ReadOnly Property UnitValueLastInventorization() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitValueLastInventorization, ROUNDUNITGOODS)
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="TotalValueAfterInventorization">total value of 
        ''' the goods</see> at the date of the previous inventory (or
        ''' <see cref="GoodsTransferOfBalanceItem.TotalValueInWarehouse">transfer of goods balance</see>).
        ''' </summary>
        ''' <remarks>Value is fetched by a subquery.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property TotalValueLastInventorization() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueLastInventorization)
            End Get
        End Property

        ''' <summary>
        ''' Gets an amount of the goods that were acquired between the date of 
        ''' the previous inventory (or <see cref="GoodsComplexOperationTransferOfBalance">
        ''' transfer of goods balance</see>) and the current inventory date.
        ''' </summary>
        ''' <remarks>Value is fetched by a subquery.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDAMOUNTGOODS)> _
        Public ReadOnly Property AmountAcquisitions() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountAcquisitions, ROUNDAMOUNTGOODS)
            End Get
        End Property

        ''' <summary>
        ''' Gets a total value of the goods that were acquired between the date of 
        ''' the previous inventory (or <see cref="GoodsComplexOperationTransferOfBalance">
        ''' transfer of goods balance</see>) and the current inventory date.
        ''' </summary>
        ''' <remarks>Value is fetched by a subquery.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property TotalValueAcquisitions() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueAcquisitions)
            End Get
        End Property

        Public ReadOnly Property AmountDisposed() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountDisposed, ROUNDAMOUNTGOODS)
            End Get
        End Property

        Public ReadOnly Property TotalValueDisposed() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueDisposed)
            End Get
        End Property

        Public ReadOnly Property AmountTransfered() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountTransfered, 6)
            End Get
        End Property

        Public ReadOnly Property TotalValueTransfered() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueTransfered)
            End Get
        End Property

        Public ReadOnly Property TotalValueAdditionalCosts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueAdditionalCosts)
            End Get
        End Property

        Public ReadOnly Property TotalValueDiscount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueDiscount)
            End Get
        End Property

        Public ReadOnly Property AmountCalculated() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountCalculated, 6)
            End Get
        End Property

        Public ReadOnly Property UnitValueCalculated() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitValueCalculated, 6)
            End Get
        End Property

        Public ReadOnly Property TotalValueCalculated() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueCalculated)
            End Get
        End Property

        Public Property AmountChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountChange, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _OperationLimitations.FinancialDataCanChange Then
                    PropertyHasChanged()
                    Exit Property
                End If
                If CRound(_AmountChange, 6) <> CRound(value, 6) Then
                    _AmountChange = CRound(value, 6)
                    PropertyHasChanged()
                    Recalculate(True)
                End If
            End Set
        End Property

        Public ReadOnly Property AmountAfterInventorization() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountAfterInventorization, 6)
            End Get
        End Property

        Public ReadOnly Property TotalValueAfterInventorization() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueAfterInventorization)
            End Get
        End Property

        Public Property AccountCorresponding() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountCorresponding
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic _
                    OrElse Not _OperationLimitations.FinancialDataCanChange Then
                    PropertyHasChanged()
                    Exit Property
                End If
                If _AccountCorresponding <> value Then
                    _AccountCorresponding = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets user remarks (content, description, etc) regarding the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.Content">OperationPersistenceObject.Content</see>.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property Remarks() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Remarks.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Remarks.Trim <> value.Trim Then
                    _Remarks = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property



        Public Function HasWarnings() As Boolean
            Return MyBase.BrokenRulesCollection.WarningCount > 0
        End Function

        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If Not MyBase.IsValid Then
                Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                    vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
            End If
            Return ""
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If Not HasWarnings() Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning))
        End Function


        Private Sub Recalculate(ByVal RaisePropertyChanged As Boolean)

            _AmountAfterInventorization = CRound(_AmountCalculated + _AmountChange)
            _TotalValueAfterInventorization = CRound(_TotalValueCalculated + _
                CRound(_AmountChange * _UnitValueCalculated))

            If RaisePropertyChanged Then
                PropertyHasChanged("AmountAfterInventorization")
                PropertyHasChanged("TotalValueAfterInventorization")
            End If

        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Goods_GoodsInventorizationItem_ToString, _
                _GoodsInfo.Name)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf AccountValidation, New Validation.RuleArgs("AccountCorresponding"))
            ValidationRules.AddRule(AddressOf AmountValidation, New Validation.RuleArgs("AmountAfterInventorization"))

            ValidationRules.AddDependantProperty("AmountChange", "AccountCorresponding", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property AmountAfterInventorization is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AmountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As GoodsInventorizationItem = DirectCast(target, GoodsInventorizationItem)

            If CRound(valObj._AmountAfterInventorization, 6) < 0 Then
                e.Description = "Kiekis po inventorizacijos negali būti neigiamas - prekė " _
                    & valObj._GoodsInfo.Name & "."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountCorresponding is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As GoodsInventorizationItem = DirectCast(target, GoodsInventorizationItem)

            If valObj._GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Persistent AndAlso _
                CRound(valObj._AmountChange, ROUNDAMOUNTGOODS) <> 0 Then
                Return CommonValidation.AccountFieldValidation(target, e)
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewGoodsInventorizationItem(ByVal dr As DataRow, _
            ByVal consignmentDictionary As Dictionary(Of Integer, ConsignmentPersistenceObjectList), _
            ByVal limitationsDataSource As DataTable, ByVal operationDate As Date, _
            ByVal operationWarehouseID As Integer) As GoodsInventorizationItem
            Return New GoodsInventorizationItem(dr, consignmentDictionary, _
                limitationsDataSource, operationDate, operationWarehouseID, True)
        End Function

        Friend Shared Function GetGoodsInventorizationItem(ByVal dr As DataRow, _
            ByVal consignmentDictionary As Dictionary(Of Integer, ConsignmentPersistenceObjectList), _
            ByVal limitationsDataSource As DataTable, ByVal operationDate As Date, _
            ByVal operationWarehouseID As Integer) As GoodsInventorizationItem
            Return New GoodsInventorizationItem(dr, consignmentDictionary, _
                limitationsDataSource, operationDate, operationWarehouseID, False)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal consignmentDictionary As Dictionary(Of Integer,  _
            ConsignmentPersistenceObjectList), ByVal limitationsDataSource As DataTable, _
            ByVal operationDate As Date, ByVal operationWarehouseID As Integer, ByVal createNew As Boolean)
            MarkAsChild()
            If createNew Then
                Create(dr, consignmentDictionary, limitationsDataSource, operationDate, operationWarehouseID)
            Else
                Fetch(dr, consignmentDictionary, limitationsDataSource, operationDate, operationWarehouseID)
            End If
        End Sub

#End Region

#Region " Data Access "

        <NonSerialized(), NotUndoable()> _
        Private _Consignment As ConsignmentPersistenceObject = Nothing
        <NonSerialized(), NotUndoable()> _
        Private _DiscardList As ConsignmentDiscardPersistenceObjectList = Nothing


        Private Sub Create(ByVal dr As DataRow, ByVal consignmentDictionary As  _
            Dictionary(Of Integer, ConsignmentPersistenceObjectList), _
            ByVal limitationsDataSource As DataTable, ByVal operationDate As Date, _
            ByVal operationWarehouseID As Integer)

            _AmountLastInventorization = CDblSafe(dr.Item(1), ROUNDAMOUNTGOODS, 0)
            _TotalValueLastInventorization = CDblSafe(dr.Item(2), 2, 0)
            If CRound(_AmountLastInventorization, ROUNDAMOUNTGOODS) > 0 Then
                _UnitValueLastInventorization = CRound(_TotalValueLastInventorization _
                    / _AmountLastInventorization, ROUNDUNITGOODS)
            Else
                _UnitValueLastInventorization = 0
            End If
            _AmountAcquisitions = CDblSafe(dr.Item(3), ROUNDAMOUNTGOODS, 0)
            _TotalValueAcquisitions = CDblSafe(dr.Item(4), 2, 0)
            _AmountDisposed = -CDblSafe(dr.Item(5), ROUNDAMOUNTGOODS, 0)
            _TotalValueDisposed = -CDblSafe(dr.Item(6), 2, 0)
            _AmountTransfered = -CDblSafe(dr.Item(7), ROUNDAMOUNTGOODS, 0)
            _TotalValueTransfered = -CDblSafe(dr.Item(8), 2, 0)
            _TotalValueAdditionalCosts = CDblSafe(dr.Item(9), 2, 0)
            _TotalValueDiscount = -CDblSafe(dr.Item(10), 2, 0)

            _GoodsInfo = GoodsSummary.NewGoodsSummary(CIntSafe(dr.Item(0), 0))

            CalculateValues(consignmentDictionary)

            _AmountChange = 0
            Recalculate(False)

            _OperationLimitations = OperationalLimitList.NewOperationalLimitList( _
                _GoodsInfo, GoodsOperationType.Inventorization, operationWarehouseID, _
                Nothing)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As DataRow, ByVal consignmentDictionary As  _
            Dictionary(Of Integer, ConsignmentPersistenceObjectList), _
            ByVal limitationsDataSource As DataTable, ByVal operationDate As Date, _
            ByVal operationWarehouseID As Integer)

            _GoodsInfo = GoodsSummary.NewGoodsSummary(CIntSafe(dr.Item(0), 0))

            _AmountLastInventorization = CDblSafe(dr.Item(1), 6, 0)
            _TotalValueLastInventorization = CDblSafe(dr.Item(2), 2, 0)
            If CRound(_AmountLastInventorization, ROUNDAMOUNTGOODS) > 0 Then
                _UnitValueLastInventorization = CRound(_TotalValueLastInventorization _
                    / _AmountLastInventorization, ROUNDUNITGOODS)
            Else
                _UnitValueLastInventorization = 0
            End If
            _AmountAcquisitions = CDblSafe(dr.Item(3), ROUNDAMOUNTGOODS, 0)
            _TotalValueAcquisitions = CDblSafe(dr.Item(4), 2, 0)
            _AmountDisposed = -CDblSafe(dr.Item(5), ROUNDAMOUNTGOODS, 0)
            _TotalValueDisposed = -CDblSafe(dr.Item(6), 2, 0)
            _AmountTransfered = -CDblSafe(dr.Item(7), ROUNDAMOUNTGOODS, 0)
            _TotalValueTransfered = -CDblSafe(dr.Item(8), 2, 0)
            _TotalValueAdditionalCosts = CDblSafe(dr.Item(9), 2, 0)
            _TotalValueDiscount = -CDblSafe(dr.Item(10), 2, 0)
            _ID = CIntSafe(dr.Item(11), 0)
            _AmountChange = CDblSafe(dr.Item(12), ROUNDAMOUNTGOODS, 0)
            _AccountCorresponding = CLongSafe(dr.Item(13), 0)
            _Remarks = CStrSafe(dr.Item(14))

            CalculateValues(consignmentDictionary)

            Recalculate(False)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo, GoodsOperationType.Inventorization, _ID, operationDate, _
                operationWarehouseID, Nothing, limitationsDataSource)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Private Sub CalculateValues(ByVal consignmentDictionary As  _
            Dictionary(Of Integer, ConsignmentPersistenceObjectList))

            _AmountCalculated = CRound(_AmountLastInventorization + _AmountAcquisitions _
                - _AmountDisposed, ROUNDAMOUNTGOODS)

            Dim totalAcquisitions As Double = CRound(_TotalValueLastInventorization + _
                _TotalValueAcquisitions + _TotalValueAdditionalCosts - _TotalValueDiscount)

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then

                If _GoodsInfo.ValuationMethod = Goods.GoodsValuationMethod.Average Then

                    If CRound(_AmountLastInventorization + _AmountAcquisitions _
                        - _AmountTransfered, ROUNDAMOUNTGOODS) > 0 Then
                        _UnitValueCalculated = CRound(CRound(totalAcquisitions _
                            - _TotalValueTransfered, 2) / CRound(_AmountLastInventorization _
                            + _AmountAcquisitions - _AmountTransfered, ROUNDAMOUNTGOODS), ROUNDUNITGOODS)
                    ElseIf CRound(_AmountLastInventorization + _AmountAcquisitions, ROUNDAMOUNTGOODS) > 0 Then
                        _UnitValueCalculated = CRound(CRound(totalAcquisitions, 2) / _
                            CRound(_AmountLastInventorization + _AmountAcquisitions, _
                            ROUNDAMOUNTGOODS), ROUNDUNITGOODS)
                    Else
                        _UnitValueCalculated = 0
                    End If

                    _TotalValueDisposed = CRound(CRound(_AmountDisposed _
                        - _AmountTransfered, ROUNDAMOUNTGOODS) * _UnitValueCalculated)

                    _TotalValueCalculated = CRound(totalAcquisitions - _TotalValueTransfered _
                        - _TotalValueDisposed, 2)

                Else

                    If consignmentDictionary.ContainsKey(_GoodsInfo.ID) Then

                        Dim list As ConsignmentPersistenceObjectList = consignmentDictionary(_GoodsInfo.ID)

                        If _GoodsInfo.ValuationMethod = Goods.GoodsValuationMethod.LIFO Then _
                            list = list.GetInvertedList

                        _TotalValueDisposed = ConsignmentPersistenceObjectList. _
                            GetConsignmentPersistenceObjectList(list, _AmountDisposed _
                            - _AmountTransfered).GetTotalValue

                        _TotalValueCalculated = CRound(totalAcquisitions - _TotalValueTransfered _
                            - _TotalValueDisposed)

                        If CRound(_AmountCalculated, ROUNDAMOUNTGOODS) > 0 Then
                            _UnitValueCalculated = CRound(_TotalValueCalculated _
                                / _AmountCalculated, ROUNDUNITGOODS)
                        ElseIf CRound(_AmountDisposed - _AmountTransfered, ROUNDAMOUNTGOODS) > 0 Then
                            _UnitValueCalculated = CRound(_TotalValueDisposed / _
                                CRound(_AmountDisposed - _AmountTransfered, ROUNDAMOUNTGOODS), ROUNDUNITGOODS)
                        ElseIf CRound(_AmountLastInventorization + _AmountAcquisitions, ROUNDAMOUNTGOODS) > 0 Then
                            _UnitValueCalculated = CRound(CRound(totalAcquisitions, 2) / _
                                CRound(_AmountLastInventorization + _AmountAcquisitions, ROUNDAMOUNTGOODS), ROUNDUNITGOODS)
                        Else
                            _UnitValueCalculated = 0
                        End If

                    Else

                        _TotalValueCalculated = 0
                        _UnitValueCalculated = 0

                    End If

                End If

            Else

                _TotalValueCalculated = CRound(totalAcquisitions - _TotalValueDisposed)

                If CRound(_AmountCalculated, ROUNDUNITGOODS) > 0 Then
                    _UnitValueCalculated = CRound(_TotalValueCalculated _
                        / _AmountCalculated, ROUNDUNITGOODS)
                ElseIf CRound(_AmountLastInventorization + _AmountAcquisitions, ROUNDAMOUNTGOODS) > 0 Then
                    _UnitValueCalculated = CRound(totalAcquisitions / _
                        CRound(_AmountLastInventorization + _AmountAcquisitions, ROUNDAMOUNTGOODS), ROUNDUNITGOODS)
                Else
                    _UnitValueCalculated = 0
                End If

            End If

        End Sub


        Friend Sub Update(ByVal parent As GoodsComplexOperationInventorization)

            Dim obj As OperationPersistenceObject = GetPersistenceObj(parent)

            obj = obj.Save(_OperationLimitations.FinancialDataCanChange, False)

            If IsNew Then
                _ID = obj.ID
            End If

            If _OperationLimitations.FinancialDataCanChange Then

                If Not IsNew Then

                    If _Consignment Is Nothing OrElse Not _Consignment.Amount > 0 Then _
                        OperationPersistenceObject.DeleteConsignments(_ID)
                    If _DiscardList Is Nothing OrElse _DiscardList.Count < 1 Then _
                        OperationPersistenceObject.DeleteConsignmentDiscards(_ID)

                End If

                If Not _Consignment Is Nothing AndAlso _Consignment.Amount > 0 Then
                    If IsNew Then
                        _Consignment.Insert(_ID, parent.WarehouseID)
                    Else
                        _Consignment.Update(parent.WarehouseID)
                    End If
                End If

                If Not _DiscardList Is Nothing AndAlso _DiscardList.Count > 0 Then _
                    _DiscardList.Update(_ID)

            End If

            MarkOld()

        End Sub

        Private Function GetPersistenceObj(ByVal parent As GoodsComplexOperationInventorization) As OperationPersistenceObject

            Dim obj As OperationPersistenceObject
            If IsNew Then
                obj = OperationPersistenceObject.NewOperationPersistenceObject( _
                    GoodsOperationType.Inventorization, _GoodsInfo.ID)
            Else
                obj = OperationPersistenceObject.GetOperationPersistenceObjectForSave( _
                    _ID, GoodsOperationType.Inventorization, Now, True)
            End If

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then

                obj.AccountGeneral = _TotalValueAfterInventorization - _TotalValueLastInventorization
                obj.AccountDiscounts = _TotalValueDiscount
                obj.AccountPurchases = -_TotalValueAcquisitions - _TotalValueAdditionalCosts
                obj.AccountSalesNetCosts = _TotalValueLastInventorization _
                    - _TotalValueAfterInventorization + _TotalValueAcquisitions _
                    + _TotalValueAdditionalCosts - _TotalValueDiscount
                obj.Amount = _AmountChange
                obj.AmountInWarehouse = _AmountAcquisitions + _AmountChange - _AmountDisposed
                obj.AmountInPurchases = -_AmountAcquisitions

            Else

                obj.AccountGeneral = CRound(_AmountChange * _UnitValueCalculated)
                obj.AccountOperationValue = -CRound(_AmountChange * _UnitValueCalculated)
                If obj.AccountGeneral <> 0 Then
                    obj.AccountOperation = _AccountCorresponding
                End If
                obj.Amount = _AmountChange
                obj.AmountInWarehouse = _AmountChange

            End If

            obj.Content = _Remarks
            obj.DocNo = parent.DocumentNumber
            obj.JournalEntryID = parent.JournalEntryID
            obj.OperationDate = parent.Date
            obj.TotalValue = CRound(_AmountChange * _UnitValueCalculated)
            obj.UnitValue = _UnitValueCalculated
            obj.WarehouseID = parent.WarehouseID
            obj.ComplexOperationID = parent.ID

            Return obj

        End Function


        Friend Sub DeleteSelf()
            OperationPersistenceObject.Delete(_ID, True, True)
        End Sub


        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AA", CRound(_AmountLastInventorization))
            myComm.AddParam("?AB", CRound(_UnitValueLastInventorization))
            myComm.AddParam("?AC", CRound(_TotalValueLastInventorization))
            myComm.AddParam("?AD", CRound(_AmountAcquisitions))
            myComm.AddParam("?AE", CRound(_TotalValueAcquisitions))
            myComm.AddParam("?AF", CRound(_AmountDisposed))
            myComm.AddParam("?AG", CRound(_TotalValueDisposed))
            myComm.AddParam("?AH", CRound(_TotalValueAdditionalCosts))
            myComm.AddParam("?AI", CRound(_TotalValueDiscount))
            myComm.AddParam("?AJ", CRound(_AmountCalculated))
            myComm.AddParam("?AK", CRound(_UnitValueCalculated))
            myComm.AddParam("?AL", CRound(_TotalValueCalculated))
            myComm.AddParam("?AM", CRound(_AmountChange))
            myComm.AddParam("?AN", CRound(_AmountAfterInventorization))
            myComm.AddParam("?AO", CRound(_TotalValueAfterInventorization))

        End Sub


        Friend Sub PrepareConsignments(ByVal parent As GoodsComplexOperationInventorization)

            _Consignment = Nothing
            _DiscardList = Nothing

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then

                If _ID > 0 AndAlso CRound(_TotalValueAfterInventorization) > 0 Then

                    Dim cons As ConsignmentPersistenceObjectList = _
                        ConsignmentPersistenceObjectList.GetConsignmentPersistenceObjectList(_ID)
                    If cons.Count < 1 Then
                        _Consignment = ConsignmentPersistenceObject.NewConsignmentPersistenceObject
                    ElseIf cons.Count = 1 Then
                        _Consignment = cons(0)
                    Else
                        Throw New Exception("Klaida. Prekės '" & _GoodsInfo.Name _
                            & "' inventorizacijai priskirta daugiau nei viena partija. " _
                            & "Tikėtina, sugadinta duombazės struktūra.")
                    End If

                ElseIf CRound(_TotalValueAfterInventorization) > 0 Then

                    _Consignment = ConsignmentPersistenceObject.NewConsignmentPersistenceObject

                End If

                If Not _Consignment Is Nothing Then

                    _Consignment.Amount = _AmountAfterInventorization
                    _Consignment.TotalValue = _TotalValueAfterInventorization
                    _Consignment.UnitValue = _UnitValueCalculated

                End If

                Dim AvailableConsignments As ConsignmentPersistenceObjectList = _
                    ConsignmentPersistenceObjectList.NewConsignmentPersistenceObjectList( _
                    _GoodsInfo.ID, parent.WarehouseID, _ID, _ID, _
                    (_GoodsInfo.ValuationMethod = Goods.GoodsValuationMethod.LIFO))
                AvailableConsignments.RemoveLateEntries(parent.Date)

                If _ID > 0 Then

                    _DiscardList = ConsignmentDiscardPersistenceObjectList. _
                        GetConsignmentDiscardPersistenceObjectList(_ID)
                    _DiscardList.MergeChangedList(ConsignmentDiscardPersistenceObjectList. _
                        NewConsignmentDiscardPersistenceObjectList(AvailableConsignments, _
                        CRound(_AmountLastInventorization + _AmountAcquisitions - _AmountTransfered, 6), _
                        _GoodsInfo.Name))

                Else

                    _DiscardList = ConsignmentDiscardPersistenceObjectList. _
                        NewConsignmentDiscardPersistenceObjectList(AvailableConsignments, _
                        CRound(_AmountLastInventorization + _AmountAcquisitions - _AmountTransfered, 6), _
                        _GoodsInfo.Name)

                End If

            Else

                If _ID > 0 AndAlso CRound(_AmountChange, 6) > 0 Then

                    Dim cons As ConsignmentPersistenceObjectList = _
                        ConsignmentPersistenceObjectList.GetConsignmentPersistenceObjectList(_ID)
                    If cons.Count < 1 Then
                        _Consignment = ConsignmentPersistenceObject.NewConsignmentPersistenceObject
                    ElseIf cons.Count = 1 Then
                        _Consignment = cons(0)
                    Else
                        Throw New Exception("Klaida. Prekės '" & _GoodsInfo.Name _
                            & "' inventorizacijai priskirta daugiau nei viena partija. " _
                            & "Tikėtina, sugadinta duombazės struktūra.")
                    End If

                ElseIf CRound(_AmountChange, 6) > 0 Then

                    _Consignment = ConsignmentPersistenceObject.NewConsignmentPersistenceObject

                End If

                If Not _Consignment Is Nothing Then

                    _Consignment.Amount = _AmountChange
                    _Consignment.TotalValue = CRound(_AmountChange * _UnitValueCalculated)
                    _Consignment.UnitValue = _UnitValueCalculated

                End If

                Dim AvailableConsignments As ConsignmentPersistenceObjectList = Nothing
                If CRound(_AmountChange, 6) < 0 Then
                    AvailableConsignments = ConsignmentPersistenceObjectList. _
                        NewConsignmentPersistenceObjectList(_GoodsInfo.ID, parent.WarehouseID, _
                        _ID, _ID, (_GoodsInfo.ValuationMethod = Goods.GoodsValuationMethod.LIFO))
                    AvailableConsignments.RemoveLateEntries(parent.Date)
                End If

                If _ID > 0 AndAlso CRound(_AmountChange, 6) < 0 Then

                    _DiscardList = ConsignmentDiscardPersistenceObjectList. _
                        GetConsignmentDiscardPersistenceObjectList(_ID)
                    _DiscardList.MergeChangedList(ConsignmentDiscardPersistenceObjectList. _
                        NewConsignmentDiscardPersistenceObjectList(AvailableConsignments, _
                        CRound(-_AmountChange, 6), _GoodsInfo.Name))

                ElseIf CRound(_AmountChange, 6) < 0 Then

                    _DiscardList = ConsignmentDiscardPersistenceObjectList. _
                        NewConsignmentDiscardPersistenceObjectList(AvailableConsignments, _
                        CRound(-_AmountChange, 6), _GoodsInfo.Name)

                End If

            End If

        End Sub

        Friend Sub CheckIfCanUpdate(ByVal limitationsDataSource As DataTable)

            _OperationLimitations = OperationalLimitList.GetUpdatedOperationalLimitList( _
                _OperationLimitations, Nothing, limitationsDataSource)

            ValidationRules.CheckRules()
            If Not IsValid Then
                Throw New Exception(Me.GetErrorString())
            End If

        End Sub

        Friend Sub CheckIfCanDelete(ByVal limitationsDataSource As DataTable)

            If IsNew Then Exit Sub

            _OperationLimitations = OperationalLimitList.GetUpdatedOperationalLimitList( _
                _OperationLimitations, Nothing, limitationsDataSource)

            If Not _OperationLimitations.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsInventorizationItem_DeleteInvalid, _
                    _GoodsInfo.Name, vbCrLf, _OperationLimitations.FinancialDataCanChangeExplanation))
            End If

        End Sub

        Friend Function GetTotalBookEntryList(ByVal parent As GoodsComplexOperationInventorization) As BookEntryInternalList

            Dim result As BookEntryInternalList = _
               BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then

                If CRound(_TotalValueAfterInventorization - _TotalValueLastInventorization) > 0 Then

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                        parent.WarehouseAccount, _TotalValueAfterInventorization _
                        - _TotalValueLastInventorization))

                Else

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                        parent.WarehouseAccount, -_TotalValueAfterInventorization _
                        + _TotalValueLastInventorization))

                End If

                If CRound(_TotalValueDiscount, 2) > 0 Then

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                        _GoodsInfo.AccountDiscounts, _TotalValueDiscount))

                End If

                If CRound(_TotalValueAcquisitions - _TotalValueTransfered + _TotalValueAdditionalCosts, 2) > 0 Then

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                        _GoodsInfo.AccountPurchases, CRound(_TotalValueAcquisitions - _
                        _TotalValueTransfered + _TotalValueAdditionalCosts, 2)))

                End If

                If CRound(_TotalValueLastInventorization - _TotalValueAfterInventorization _
                    + _TotalValueAcquisitions + _TotalValueAdditionalCosts _
                    - _TotalValueDiscount - _TotalValueTransfered) > 0 Then

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                        _GoodsInfo.AccountSalesNetCosts, CRound(_TotalValueLastInventorization _
                        - _TotalValueAfterInventorization + _TotalValueAcquisitions _
                        + _TotalValueAdditionalCosts - _TotalValueDiscount - _
                        _TotalValueTransfered, 2)))

                Else

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                        _GoodsInfo.AccountSalesNetCosts, CRound(-(_TotalValueLastInventorization _
                        - _TotalValueAfterInventorization + _TotalValueAcquisitions _
                        + _TotalValueAdditionalCosts - _TotalValueDiscount _
                        - _TotalValueTransfered), 2)))

                End If

            Else

                If CRound(_AmountChange, ROUNDAMOUNTGOODS) > 0 Then

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                        parent.WarehouseAccount, CRound(_UnitValueCalculated * _AmountChange)))

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                        _AccountCorresponding, CRound(_UnitValueCalculated * _AmountChange)))

                Else

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                        parent.WarehouseAccount, CRound(-_UnitValueCalculated * _AmountChange)))

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                        _AccountCorresponding, CRound(-_UnitValueCalculated * _AmountChange)))

                End If

            End If

            Return result

        End Function

#End Region

    End Class

End Namespace