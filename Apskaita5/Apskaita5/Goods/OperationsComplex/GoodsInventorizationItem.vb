Namespace Goods

    <Serializable()> _
    Public Class GoodsInventorizationItem
        Inherits BusinessBase(Of GoodsInventorizationItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
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


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property GoodsInfo() As GoodsSummary
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo
            End Get
        End Property

        Public ReadOnly Property GoodsName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.Name
            End Get
        End Property

        Public ReadOnly Property GoodsMeasureUnit() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.MeasureUnit
            End Get
        End Property

        Public ReadOnly Property GoodsAccountingMethod() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethodHumanReadable
            End Get
        End Property

        Public ReadOnly Property GoodsValuationMethod() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.ValuationMethodHumanReadable
            End Get
        End Property

        Public ReadOnly Property OperationLimitations() As OperationalLimitList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationLimitations
            End Get
        End Property

        Public ReadOnly Property AmountLastInventorization() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountLastInventorization, 6)
            End Get
        End Property

        Public ReadOnly Property UnitValueLastInventorization() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitValueLastInventorization, 6)
            End Get
        End Property

        Public ReadOnly Property TotalValueLastInventorization() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueLastInventorization)
            End Get
        End Property

        Public ReadOnly Property AmountAcquisitions() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountAcquisitions, 6)
            End Get
        End Property

        Public ReadOnly Property TotalValueAcquisitions() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueAcquisitions)
            End Get
        End Property

        Public ReadOnly Property AmountDisposed() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountDisposed, 6)
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



        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & _GoodsInfo.Name & "': " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
        Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & _GoodsInfo.Name & "' gali būti klaida: " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
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
            Return _GoodsInfo.Name
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

            Dim ValObj As GoodsInventorizationItem = DirectCast(target, GoodsInventorizationItem)

            If CRound(ValObj._AmountAfterInventorization, 6) < 0 Then
                e.Description = "Kiekis po inventorizacijos negali būti neigiamas - prekė " _
                    & ValObj._GoodsInfo.Name & "."
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

            Dim ValObj As GoodsInventorizationItem = DirectCast(target, GoodsInventorizationItem)

            If ValObj._GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Persistent AndAlso _
                CRound(ValObj._AmountChange, 6) <> 0 AndAlso Not ValObj._AccountCorresponding > 0 Then
                e.Description = "Nenurodyta koresponduojanti (pajamų/sąnaudų) sąskaita prekei " _
                    & ValObj._GoodsInfo.Name & "."
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

        Friend Shared Function NewGoodsInventorizationItem(ByVal dr As DataRow, _
            ByVal consignmentDictionary As Dictionary(Of Integer, ConsignmentPersistenceObjectList), _
            ByVal LimitationsDataSource As DataTable, ByVal OperationDate As Date, _
            ByVal OperationWarehouseID As Integer) As GoodsInventorizationItem
            Return New GoodsInventorizationItem(dr, consignmentDictionary, _
                LimitationsDataSource, OperationDate, OperationWarehouseID, True)
        End Function

        Friend Shared Function GetGoodsInventorizationItem(ByVal dr As DataRow, _
            ByVal consignmentDictionary As Dictionary(Of Integer, ConsignmentPersistenceObjectList), _
            ByVal LimitationsDataSource As DataTable, ByVal OperationDate As Date, _
            ByVal OperationWarehouseID As Integer) As GoodsInventorizationItem
            Return New GoodsInventorizationItem(dr, consignmentDictionary, _
                LimitationsDataSource, OperationDate, OperationWarehouseID, False)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal consignmentDictionary As Dictionary(Of Integer, _
            ConsignmentPersistenceObjectList), ByVal LimitationsDataSource As DataTable, _
            ByVal OperationDate As Date, ByVal OperationWarehouseID As Integer, ByVal CreateNew As Boolean)
            MarkAsChild()
            If CreateNew Then
                Create(dr, consignmentDictionary, LimitationsDataSource, OperationDate, OperationWarehouseID)
            Else
                Fetch(dr, consignmentDictionary, LimitationsDataSource, OperationDate, OperationWarehouseID)
            End If
        End Sub

#End Region

#Region " Data Access "

        <NonSerialized(), NotUndoable()> _
        Private _Consignment As ConsignmentPersistenceObject = Nothing
        <NonSerialized(), NotUndoable()> _
        Private _DiscardList As ConsignmentDiscardPersistenceObjectList = Nothing


        Private Sub Create(ByVal dr As DataRow, ByVal consignmentDictionary As _
            Dictionary(Of Integer, ConsignmentPersistenceObjectList), _
            ByVal LimitationsDataSource As DataTable, ByVal OperationDate As Date, _
            ByVal OperationWarehouseID As Integer)

            _AmountLastInventorization = CDblSafe(dr.Item(1), 6, 0)
            _TotalValueLastInventorization = CDblSafe(dr.Item(2), 2, 0)
            If CRound(_AmountLastInventorization, 6) > 0 Then
                _UnitValueLastInventorization = CRound(_TotalValueLastInventorization / _AmountLastInventorization, 6)
            Else
                _UnitValueLastInventorization = 0
            End If
            _AmountAcquisitions = CDblSafe(dr.Item(3), 6, 0)
            _TotalValueAcquisitions = CDblSafe(dr.Item(4), 2, 0)
            _AmountDisposed = -CDblSafe(dr.Item(5), 6, 0)
            _TotalValueDisposed = -CDblSafe(dr.Item(6), 2, 0)
            _AmountTransfered = -CDblSafe(dr.Item(7), 6, 0)
            _TotalValueTransfered = -CDblSafe(dr.Item(8), 2, 0)
            _TotalValueAdditionalCosts = CDblSafe(dr.Item(9), 2, 0)
            _TotalValueDiscount = -CDblSafe(dr.Item(10), 2, 0)

            _GoodsInfo = GoodsSummary.GetGoodsSummary(CIntSafe(dr.Item(0), 0))

            CalculateValues(consignmentDictionary)

            _AmountChange = 0
            Recalculate(False)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                0, GoodsOperationType.Inventorization, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, OperationDate, _
                OperationWarehouseID, Nothing, LimitationsDataSource)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As DataRow, ByVal consignmentDictionary As _
            Dictionary(Of Integer, ConsignmentPersistenceObjectList), _
            ByVal LimitationsDataSource As DataTable, ByVal OperationDate As Date, _
            ByVal OperationWarehouseID As Integer)

            _GoodsInfo = GoodsSummary.GetGoodsSummary(CIntSafe(dr.Item(0), 0))

            _AmountLastInventorization = CDblSafe(dr.Item(1), 6, 0)
            _TotalValueLastInventorization = CDblSafe(dr.Item(2), 2, 0)
            If CRound(_AmountLastInventorization, 6) > 0 Then
                _UnitValueLastInventorization = CRound(_TotalValueLastInventorization / _AmountLastInventorization, 6)
            Else
                _UnitValueLastInventorization = 0
            End If
            _AmountAcquisitions = CDblSafe(dr.Item(3), 6, 0)
            _TotalValueAcquisitions = CDblSafe(dr.Item(4), 2, 0)
            _AmountDisposed = -CDblSafe(dr.Item(5), 6, 0)
            _TotalValueDisposed = -CDblSafe(dr.Item(6), 2, 0)
            _AmountTransfered = -CDblSafe(dr.Item(7), 6, 0)
            _TotalValueTransfered = -CDblSafe(dr.Item(8), 2, 0)
            _TotalValueAdditionalCosts = CDblSafe(dr.Item(9), 2, 0)
            _TotalValueDiscount = -CDblSafe(dr.Item(10), 2, 0)
            _ID = CIntSafe(dr.Item(11), 0)
            _AmountChange = CDblSafe(dr.Item(12), 6, 0)
            _AccountCorresponding = CLongSafe(dr.Item(13), 0)

            If CStrSafe(dr.Item(14)).Split(New String() {"<#>"}, StringSplitOptions.RemoveEmptyEntries).Length > 1 Then _
                _Remarks = CStrSafe(dr.Item(14)).Split(New String() {"<#>"}, StringSplitOptions.RemoveEmptyEntries)(1)

            CalculateValues(consignmentDictionary)

            Recalculate(False)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                _ID, GoodsOperationType.Inventorization, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, OperationDate, _
                OperationWarehouseID, Nothing, LimitationsDataSource)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Private Sub CalculateValues(ByVal consignmentDictionary As _
            Dictionary(Of Integer, ConsignmentPersistenceObjectList))

            _AmountCalculated = CRound(_AmountLastInventorization + _AmountAcquisitions - _AmountDisposed, 6)

            Dim TotalAcquisitions As Double = CRound(_TotalValueLastInventorization + _
                _TotalValueAcquisitions + _TotalValueAdditionalCosts - _TotalValueDiscount)

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then

                If _GoodsInfo.ValuationMethod = Goods.GoodsValuationMethod.Average Then

                    If CRound(_AmountLastInventorization + _AmountAcquisitions - _AmountTransfered, 6) > 0 Then
                        _UnitValueCalculated = CRound(CRound(TotalAcquisitions - _TotalValueTransfered, 2) / _
                            CRound(_AmountLastInventorization + _AmountAcquisitions - _AmountTransfered, 6), 6)
                    ElseIf CRound(_AmountLastInventorization + _AmountAcquisitions, 6) > 0 Then
                        _UnitValueCalculated = CRound(CRound(TotalAcquisitions, 2) / _
                            CRound(_AmountLastInventorization + _AmountAcquisitions, 6), 6)
                    Else
                        _UnitValueCalculated = 0
                    End If

                    _TotalValueDisposed = CRound(CRound(_AmountDisposed - _AmountTransfered, 6) _
                        * _UnitValueCalculated)

                    _TotalValueCalculated = CRound(TotalAcquisitions - _TotalValueTransfered _
                        - _TotalValueDisposed, 2)

                Else

                    If consignmentDictionary.ContainsKey(_GoodsInfo.ID) Then

                        Dim list As ConsignmentPersistenceObjectList = consignmentDictionary(_GoodsInfo.ID)

                        If _GoodsInfo.ValuationMethod = Goods.GoodsValuationMethod.LIFO Then _
                            list = list.GetInvertedList

                        _TotalValueDisposed = ConsignmentPersistenceObjectList. _
                            GetConsignmentPersistenceObjectList(list, _AmountDisposed _
                            - _AmountTransfered).GetTotalValue

                        _TotalValueCalculated = CRound(TotalAcquisitions - _TotalValueTransfered _
                            - _TotalValueDisposed)

                        If CRound(_AmountCalculated, 6) > 0 Then
                            _UnitValueCalculated = CRound(_TotalValueCalculated / _AmountCalculated, 6)
                        ElseIf CRound(_AmountDisposed - _AmountTransfered, 6) > 0 Then
                            _UnitValueCalculated = CRound(_TotalValueDisposed / _
                                CRound(_AmountDisposed - _AmountTransfered, 6), 6)
                        ElseIf CRound(_AmountLastInventorization + _AmountAcquisitions, 6) > 0 Then
                            _UnitValueCalculated = CRound(CRound(TotalAcquisitions, 2) / _
                                CRound(_AmountLastInventorization + _AmountAcquisitions, 6), 6)
                        Else
                            _UnitValueCalculated = 0
                        End If

                    Else

                        _TotalValueCalculated = 0
                        _UnitValueCalculated = 0

                    End If

                End If

            Else

                _TotalValueCalculated = CRound(TotalAcquisitions - _TotalValueDisposed)

                If CRound(_AmountCalculated, 6) > 0 Then
                    _UnitValueCalculated = CRound(_TotalValueCalculated / _AmountCalculated, 6)
                ElseIf CRound(_AmountLastInventorization + _AmountAcquisitions, 6) > 0 Then
                    _UnitValueCalculated = CRound(TotalAcquisitions / _
                        CRound(_AmountLastInventorization + _AmountAcquisitions, 6), 6)
                Else
                    _UnitValueCalculated = 0
                End If

            End If

        End Sub


        Friend Sub Update(ByVal parent As GoodsComplexOperationInventorization)

            Dim obj As OperationPersistenceObject = GetPersistenceObj(parent)

            If IsNew Then
                _ID = obj.Save(_OperationLimitations.FinancialDataCanChange)
            Else
                obj.Save(_OperationLimitations.FinancialDataCanChange)
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
                obj = OperationPersistenceObject.NewOperationPersistenceObject
            Else
                obj = OperationPersistenceObject.GetOperationPersistenceObject(_ID, False)
            End If

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then

                obj.AccountGeneral = _TotalValueAfterInventorization - _TotalValueLastInventorization
                obj.AccountDiscounts = _TotalValueDiscount
                obj.AccountPurchases = -_TotalValueAcquisitions - _TotalValueAdditionalCosts
                obj.AccountSalesNetCosts = _TotalValueLastInventorization - _TotalValueAfterInventorization _
                    + _TotalValueAcquisitions + _TotalValueAdditionalCosts - _TotalValueDiscount
                obj.Amount = _AmountChange
                obj.AmountInWarehouse = _AmountAcquisitions + _AmountChange - _AmountDisposed
                obj.AmountInPurchases = -_AmountAcquisitions

            Else

                obj.AccountGeneral = CRound(_AmountChange * _UnitValueCalculated)
                obj.AccountOperationValue = -CRound(_AmountChange * _UnitValueCalculated)
                If obj.AccountGeneral <> 0 Then obj.AccountOperation = _AccountCorresponding
                obj.Amount = _AmountChange
                obj.AmountInWarehouse = _AmountChange

            End If

            If Not String.IsNullOrEmpty(_Remarks.Trim) Then
                obj.Content = parent.Content & "<#>" & _Remarks
            Else
                obj.Content = parent.Content
            End If
            obj.DocNo = parent.DocumentNumber
            obj.GoodsID = _GoodsInfo.ID
            obj.JournalEntryID = parent.JournalEntryID
            obj.OperationDate = parent.Date
            obj.OperationType = GoodsOperationType.Inventorization
            obj.TotalValue = CRound(_AmountChange * _UnitValueCalculated)
            obj.UnitValue = _UnitValueCalculated
            obj.WarehouseID = parent.WarehouseID
            obj.ComplexOperationID = parent.ID

            Return obj

        End Function


        Friend Sub DeleteSelf()
            OperationPersistenceObject.DeleteConsignmentDiscards(_ID)
            OperationPersistenceObject.DeleteConsignments(_ID)
            OperationPersistenceObject.Delete(_ID)
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
                    ConsignmentPersistenceObjectList.GetConsignmentPersistenceObjectList( _
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
                        GetConsignmentPersistenceObjectList(_GoodsInfo.ID, parent.WarehouseID, _
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

        Friend Function CheckIfCanUpdate(ByVal LimitationsDataSource As DataTable, _
            ByVal OperationDate As Date, ByVal WarehouseID As Integer, ByVal ThrowOnInvalid As Boolean) As String

            If IsNew Then

                _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                    _ID, GoodsOperationType.Inventorization, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, OperationDate, WarehouseID, Nothing)

            Else

                If LimitationsDataSource Is Nothing Then
                    _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                        _ID, GoodsOperationType.Inventorization, _GoodsInfo.ValuationMethod, _
                        _GoodsInfo.AccountingMethod, _GoodsInfo.Name, OperationDate, WarehouseID, Nothing)
                Else
                    _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                        _ID, GoodsOperationType.Inventorization, _GoodsInfo.ValuationMethod, _
                        _GoodsInfo.AccountingMethod, _GoodsInfo.Name, OperationDate, WarehouseID, _
                        Nothing, LimitationsDataSource)
                End If

            End If

            ValidationRules.CheckRules()
            If Not IsValid Then
                If ThrowOnInvalid Then
                    Throw New Exception("Prekių '" & _GoodsInfo.Name _
                    & "' inventorizacijos operacijoje yra klaidų: " & BrokenRulesCollection.ToString)
                Else
                    Return "Prekių '" & _GoodsInfo.Name _
                        & "' inventorizacijos operacijoje yra klaidų: " & BrokenRulesCollection.ToString
                End If
            End If

            Return ""

        End Function

        Friend Function CheckIfCanDelete(ByVal LimitationsDataSource As DataTable, _
            ByVal OperationDate As Date, ByVal WarehouseID As Integer, ByVal ThrowOnInvalid As Boolean) As String

            If IsNew Then Return ""

            If LimitationsDataSource Is Nothing Then
                _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                    _ID, GoodsOperationType.Inventorization, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, OperationDate, WarehouseID, Nothing)
            Else
                _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                    _ID, GoodsOperationType.Inventorization, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, OperationDate, WarehouseID, _
                    Nothing, LimitationsDataSource)
            End If

            If Not _OperationLimitations.FinancialDataCanChange Then
                If ThrowOnInvalid Then
                    Throw New Exception("Klaida. Negalima ištrinti prekių '" & _
                        _OperationLimitations.CurrentGoodsName & "' inventorizacijos operacijos:" _
                        & vbCrLf & _OperationLimitations.FinancialDataCanChangeExplanation)
                Else
                    Return "Klaida. Negalima ištrinti prekių '" & _
                        _OperationLimitations.CurrentGoodsName & "' inventorizacijos operacijos:" _
                        & vbCrLf & _OperationLimitations.FinancialDataCanChangeExplanation
                End If
            End If

            Return ""

        End Function

        Friend Function GetTotalBookEntryList(ByVal parent As GoodsComplexOperationInventorization) As BookEntryInternalList

            Dim result As BookEntryInternalList = _
               BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then

                If CRound(_TotalValueAfterInventorization - _TotalValueLastInventorization) > 0 Then

                    Dim GeneralAccountBookEntry As BookEntryInternal = _
                        BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas)
                    GeneralAccountBookEntry.Account = parent.WarehouseAccount
                    GeneralAccountBookEntry.Ammount = _TotalValueAfterInventorization _
                        - _TotalValueLastInventorization

                    result.Add(GeneralAccountBookEntry)

                Else

                    Dim GeneralAccountBookEntry As BookEntryInternal = _
                        BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas)
                    GeneralAccountBookEntry.Account = parent.WarehouseAccount
                    GeneralAccountBookEntry.Ammount = -_TotalValueAfterInventorization _
                        + _TotalValueLastInventorization

                    result.Add(GeneralAccountBookEntry)

                End If

                If CRound(_TotalValueDiscount, 2) > 0 Then

                    Dim DiscountAccountBookEntry As BookEntryInternal = _
                        BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas)
                    DiscountAccountBookEntry.Account = _GoodsInfo.AccountDiscounts
                    DiscountAccountBookEntry.Ammount = _TotalValueDiscount

                    result.Add(DiscountAccountBookEntry)

                End If

                If CRound(_TotalValueAcquisitions - _TotalValueTransfered + _TotalValueAdditionalCosts, 2) > 0 Then

                    Dim PurchasesAccountBookEntry As BookEntryInternal = _
                        BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas)
                    PurchasesAccountBookEntry.Account = _GoodsInfo.AccountPurchases
                    PurchasesAccountBookEntry.Ammount = CRound(_TotalValueAcquisitions - _
                        _TotalValueTransfered + _TotalValueAdditionalCosts, 2)

                    result.Add(PurchasesAccountBookEntry)

                End If

                If CRound(_TotalValueLastInventorization - _TotalValueAfterInventorization _
                    + _TotalValueAcquisitions + _TotalValueAdditionalCosts _
                    - _TotalValueDiscount - _TotalValueTransfered) > 0 Then

                    Dim SalesNetCostsAccountBookEntry As BookEntryInternal = _
                        BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas)
                    SalesNetCostsAccountBookEntry.Account = _GoodsInfo.AccountSalesNetCosts
                    SalesNetCostsAccountBookEntry.Ammount = _TotalValueLastInventorization _
                        - _TotalValueAfterInventorization + _TotalValueAcquisitions _
                        + _TotalValueAdditionalCosts - _TotalValueDiscount - _TotalValueTransfered

                    result.Add(SalesNetCostsAccountBookEntry)

                Else

                    Dim SalesNetCostsAccountBookEntry As BookEntryInternal = _
                        BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas)
                    SalesNetCostsAccountBookEntry.Account = _GoodsInfo.AccountSalesNetCosts
                    SalesNetCostsAccountBookEntry.Ammount = -(_TotalValueLastInventorization _
                        - _TotalValueAfterInventorization + _TotalValueAcquisitions _
                        + _TotalValueAdditionalCosts - _TotalValueDiscount - _TotalValueTransfered)

                    result.Add(SalesNetCostsAccountBookEntry)

                End If

            Else

                If CRound(_AmountChange, 6) > 0 Then

                    Dim GoodsAccountBookEntry As BookEntryInternal = _
                        BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas)
                    GoodsAccountBookEntry.Account = parent.WarehouseAccount
                    GoodsAccountBookEntry.Ammount = CRound(_UnitValueCalculated * _AmountChange)

                    result.Add(GoodsAccountBookEntry)

                    Dim CostsAccountBookEntry As BookEntryInternal = _
                        BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas)
                    CostsAccountBookEntry.Account = _AccountCorresponding
                    CostsAccountBookEntry.Ammount = CRound(_UnitValueCalculated * _AmountChange)

                    result.Add(CostsAccountBookEntry)

                Else

                    Dim GoodsAccountBookEntry As BookEntryInternal = _
                        BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas)
                    GoodsAccountBookEntry.Account = parent.WarehouseAccount
                    GoodsAccountBookEntry.Ammount = CRound(-_UnitValueCalculated * _AmountChange)

                    result.Add(GoodsAccountBookEntry)

                    Dim CostsAccountBookEntry As BookEntryInternal = _
                        BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas)
                    CostsAccountBookEntry.Account = _AccountCorresponding
                    CostsAccountBookEntry.Ammount = CRound(-_UnitValueCalculated * _AmountChange)

                    result.Add(CostsAccountBookEntry)

                End If

            End If

            Return result

        End Function

        Friend Sub ReloadLimitations(ByVal LimitationsDataSource As DataTable, _
            ByVal OperationDate As Date, ByVal WarehouseID As Integer)

            If LimitationsDataSource Is Nothing Then Throw New ArgumentNullException( _
                "Klaida. Metodui GoodsInventorizationItem.ReloadLimitations " _
                & "nenurodytas LimitationsDataSource parametras.")
            If IsNew Then Throw New InvalidOperationException("Klaida. " _
                & "Metodas GoodsInventorizationItem.ReloadLimitations gali " _
                & "būti taikomas tik Old objektams.")

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                _ID, GoodsOperationType.Inventorization, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, OperationDate, WarehouseID, _
                Nothing, LimitationsDataSource)

            ValidationRules.CheckRules()

        End Sub

#End Region

    End Class

End Namespace