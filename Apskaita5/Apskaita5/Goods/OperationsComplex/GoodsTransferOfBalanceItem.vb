Namespace Goods

    <Serializable()> _
Public Class GoodsTransferOfBalanceItem
        Inherits BusinessBase(Of GoodsTransferOfBalanceItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _GoodsInfo As GoodsSummary = Nothing
        Private _OperationLimitations As OperationalLimitList = Nothing
        Private _OldDate As Date = Today
        Private _Date As Date = Today
        Private _Ammount As Double = 0
        Private _AmountInWarehouse As Double = 0
        Private _UnitCost As Double = 0
        Private _TotalValue As Double = 0
        Private _TotalValueInWarehouse As Double = 0
        Private _SalesNetCosts As Double = 0
        Private _Discounts As Double = 0
        Private _PriceCut As Double = 0
        Private _Warehouse As WarehouseInfo = Nothing


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

        Public ReadOnly Property GoodsAccountingMethodHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethodHumanReadable
            End Get
        End Property

        Public ReadOnly Property GoodsValuationMethodHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.ValuationMethodHumanReadable
            End Get
        End Property

        Public ReadOnly Property PurchasesAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent Then _
                    Return _Warehouse.WarehouseAccount
                Return _GoodsInfo.AccountPurchases
            End Get
        End Property

        Public ReadOnly Property SalesNetCostsAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent Then Return 0
                Return _GoodsInfo.AccountSalesNetCosts
            End Get
        End Property

        Public ReadOnly Property DiscountsAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent Then Return 0
                Return _GoodsInfo.AccountDiscounts
            End Get
        End Property

        Public ReadOnly Property PriceCutCostsAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountValueReduction
            End Get
        End Property

        Public ReadOnly Property Warehouse() As WarehouseInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Warehouse
            End Get
        End Property

        Public ReadOnly Property WarehouseName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Warehouse.Name
            End Get
        End Property

        Public ReadOnly Property WarehouseAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Warehouse.WarehouseAccount
            End Get
        End Property

        Public ReadOnly Property OperationLimitations() As OperationalLimitList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationLimitations
            End Get
        End Property

        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        Public ReadOnly Property OldDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OldDate
            End Get
        End Property


        Public Property Ammount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Ammount, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If AmmountIsReadOnly Then Exit Property
                If CRound(_Ammount, 6) <> CRound(value, 6) Then
                    _Ammount = CRound(value, 6)
                    PropertyHasChanged()
                    If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent Then
                        _AmountInWarehouse = _Ammount
                        PropertyHasChanged("AmountInWarehouse")
                    End If
                    SetTotalCostByUnitCostAndAmmount()
                End If
            End Set
        End Property

        Public Property AmountInWarehouse() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountInWarehouse, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If AmountInWarehouseIsReadOnly Then Exit Property
                If CRound(_AmountInWarehouse, 6) <> CRound(value, 6) Then
                    _AmountInWarehouse = CRound(value, 6)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property UnitCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitCost, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If UnitCostIsReadOnly Then Exit Property
                If CRound(_UnitCost, 6) <> CRound(value, 6) Then
                    _UnitCost = CRound(value, 6)
                    PropertyHasChanged()
                    SetTotalCostByUnitCostAndAmmount()
                End If
            End Set
        End Property

        Public Property TotalValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValue)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If TotalValueIsReadOnly Then Exit Property
                If CRound(_TotalValue) <> CRound(value) Then
                    _TotalValue = CRound(value)
                    PropertyHasChanged()
                    If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent Then
                        _TotalValueInWarehouse = _TotalValue
                        PropertyHasChanged("TotalValueInWarehouse")
                    End If
                End If
            End Set
        End Property

        Public Property TotalValueInWarehouse() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueInWarehouse)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If TotalValueInWarehouseIsReadOnly Then Exit Property
                If CRound(_TotalValueInWarehouse) <> CRound(value) Then
                    _TotalValueInWarehouse = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property SalesNetCosts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SalesNetCosts)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If SalesNetCostsIsReadOnly Then Exit Property
                If CRound(_SalesNetCosts) <> CRound(value) Then
                    _SalesNetCosts = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Discounts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Discounts)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If DiscountsIsReadOnly Then Exit Property
                If CRound(_Discounts) <> CRound(value) Then
                    _Discounts = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property PriceCut() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PriceCut)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If PriceCutIsReadOnly Then Exit Property
                If CRound(_PriceCut) <> CRound(value) Then
                    _PriceCut = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property


        Public ReadOnly Property AmmountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property AmountInWarehouseIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent OrElse _
                    Not _OperationLimitations.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property UnitCostIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property TotalValueIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property TotalValueInWarehouseIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent OrElse _
                    Not _OperationLimitations.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property SalesNetCostsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent OrElse _
                    Not _OperationLimitations.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property DiscountsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent OrElse _
                    Not _OperationLimitations.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property PriceCutIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange
            End Get
        End Property



        Public Sub SetTotalCostByUnitCostAndAmmount()
            TotalValue = CRound(_UnitCost * _Ammount)
        End Sub


        Friend Sub SetDate(ByVal value As Date)
            If _Date.Date <> value.Date Then
                _Date = value.Date
                PropertyHasChanged("Date")
            End If
        End Sub


        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & _GoodsInfo.Name & "', '" & _Warehouse.Name & "': " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & _GoodsInfo.Name & "', '" & _Warehouse.Name & "' gali būti klaida: " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "OperationLimitations"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("UnitCost", "vieneto vertė"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("TotalValue", "bendra perkeliamų prekių vertė"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("Ammount", "bendras pekeliamas kiekis"))

            ValidationRules.AddRule(AddressOf AmountInWarehouseValidation, _
                New Validation.RuleArgs("AmountInWarehouseValidation"))
            ValidationRules.AddRule(AddressOf TotalValueInWarehouseValidation, _
                New Validation.RuleArgs("TotalValueInWarehouseValidation"))

            ValidationRules.AddDependantProperty("Ammount", "AmountInWarehouseValidation", False)
            ValidationRules.AddDependantProperty("TotalValue", "TotalValueInWarehouse", False)
            ValidationRules.AddDependantProperty("AmountInWarehouseValidation", "TotalValueInWarehouse", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that AmountInWarehouse is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AmountInWarehouseValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As GoodsTransferOfBalanceItem = DirectCast(target, GoodsTransferOfBalanceItem)

            If ValObj._GoodsInfo.AccountingMethod <> GoodsAccountingMethod.Persistent AndAlso _
                CRound(ValObj._AmountInWarehouse, 6) > CRound(ValObj._Ammount, 6) Then
                e.Description = "Kiekis sandėlyje negali būti didesnis už bendrą kiekį."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that TotalValueInWarehouse is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function TotalValueInWarehouseValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As GoodsTransferOfBalanceItem = DirectCast(target, GoodsTransferOfBalanceItem)

            If ValObj._GoodsInfo.AccountingMethod <> GoodsAccountingMethod.Persistent Then

                If CRound(ValObj._TotalValueInWarehouse) > CRound(ValObj._TotalValue) Then
                    e.Description = "Vertė sandėlyje negali būti didesnė už bendrą vertę."
                    e.Severity = Validation.RuleSeverity.Error
                    Return False
                ElseIf CRound(ValObj._AmountInWarehouse, 6) > 0 AndAlso _
                    Not CRound(ValObj._TotalValueInWarehouse) > 0 Then
                    e.Description = "Nenurodyta vertė sandėlyje."
                    e.Severity = Validation.RuleSeverity.Error
                    Return False
                ElseIf Not CRound(ValObj._AmountInWarehouse, 6) > 0 AndAlso _
                    CRound(ValObj._TotalValueInWarehouse) > 0 Then
                    e.Description = "Nurodyta vertė sandėlyje, o kiekis sandėlyje nenurodytas."
                    e.Severity = Validation.RuleSeverity.Error
                    Return False
                End If

            End If

            Return True

        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewGoodsTransferOfBalanceItem(ByVal nGoodsID As Integer, _
            ByVal nWarehouse As WarehouseInfo) As GoodsTransferOfBalanceItem
            Return DataPortal.Create(Of GoodsTransferOfBalanceItem)(New Criteria(nGoodsID, nWarehouse))
        End Function

        Friend Shared Function GetGoodsTransferOfBalanceItem( _
            ByVal obj As OperationPersistenceObject, ByVal LimitationsDataSource As DataTable) _
            As GoodsTransferOfBalanceItem
            Return New GoodsTransferOfBalanceItem(obj, LimitationsDataSource)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal obj As OperationPersistenceObject, ByVal LimitationsDataSource As DataTable)
            ' require use of factory methods
            MarkAsChild()
            Fetch(obj, LimitationsDataSource)
        End Sub

#End Region

#Region " Data Access "

        <NonSerialized(), NotUndoable()> _
        Private _Consignment As ConsignmentPersistenceObject = Nothing


        <Serializable()> _
        Private Class Criteria
            Private _GoodsID As Integer
            Private _Warehouse As WarehouseInfo
            Public ReadOnly Property GoodsID() As Integer
                Get
                    Return _GoodsID
                End Get
            End Property
            Public ReadOnly Property Warehouse() As WarehouseInfo
                Get
                    Return _Warehouse
                End Get
            End Property
            Public Sub New(ByVal nGoodsID As Integer, ByVal nWarehouse As WarehouseInfo)
                _GoodsID = nGoodsID
                _Warehouse = nWarehouse
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)
            Create(criteria.GoodsID, criteria.Warehouse)
        End Sub

        Private Sub Create(ByVal nGoodsID As Integer, ByVal nWarehouse As WarehouseInfo)

            If Not GoodsComplexOperationTransferOfBalance.CanAddObject Then _
                Throw New System.Security.SecurityException("Klaida. Jūsų teisių nepakanka duomenims įvesti.")
            If Not nGoodsID > 0 Then Throw New Exception("Klaida. Nenurodyta prekės ID.")
            If nWarehouse Is Nothing OrElse Not nWarehouse.ID > 0 Then _
                Throw New Exception("Klaida. Nenurodytas sandėlys.")

            _GoodsInfo = GoodsSummary.GetGoodsSummary(nGoodsID)
            _Warehouse = nWarehouse
            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(nGoodsID, _
                0, GoodsOperationType.TransferOfBalance, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, Today, _Warehouse.ID, Nothing)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub


        Private Sub Fetch(ByVal obj As OperationPersistenceObject, ByVal LimitationsDataSource As DataTable)

            If obj.OperationType <> GoodsOperationType.TransferOfBalance Then Throw New Exception( _
                "Operacijos, kurios ID=" & obj.ID.ToString & " tipas yra ne " & _
                "likučių perkėlimas, o " & ConvertEnumHumanReadable(obj.OperationType) & ".")

            _ID = obj.ID
            _GoodsInfo = obj.GoodsInfo
            _Date = obj.OperationDate
            _OldDate = _Date
            _Ammount = CRound(obj.AmountInWarehouse + obj.AmountInPurchases, 6)
            _AmountInWarehouse = obj.AmountInWarehouse
            _UnitCost = obj.UnitValue
            _TotalValue = obj.AccountGeneral + obj.AccountPurchases
            _TotalValueInWarehouse = obj.AccountGeneral
            _SalesNetCosts = obj.AccountSalesNetCosts
            _Discounts = -obj.AccountDiscounts
            _PriceCut = -obj.AccountPriceCut
            _Warehouse = obj.Warehouse

            If LimitationsDataSource Is Nothing Then
                _OperationLimitations = OperationalLimitList.GetOperationalLimitList(obj.GoodsID, _
                    obj.ID, GoodsOperationType.TransferOfBalance, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, obj.OperationDate, obj.WarehouseID, Nothing)
            Else
                _OperationLimitations = OperationalLimitList.GetOperationalLimitList(obj.GoodsID, _
                    obj.ID, GoodsOperationType.TransferOfBalance, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, obj.OperationDate, _
                    obj.WarehouseID, Nothing, LimitationsDataSource)
            End If

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Friend Sub Insert(ByVal ParentJournalEntryID As Integer, _
            ByVal ParentComplexOperationID As Integer, ByVal ParentDocNo As String, _
            ByVal ParentDescription As String)

            If _OperationLimitations.FinancialDataCanChange AndAlso _
                _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent AndAlso _
                _Consignment Is Nothing Then Throw New InvalidOperationException( _
                "Klaida. Prieš išsaugant GoodsTransferOfBalanceItem būtina iškviesti GetConsignment metodą.")

            Dim obj As OperationPersistenceObject = GetPersistenceObj(ParentJournalEntryID, _
                ParentComplexOperationID, ParentDocNo, ParentDescription)

            Dim TransactionExisted As Boolean = DatabaseAccess.TransactionExists
            If Not TransactionExisted Then DatabaseAccess.TransactionBegin()

            _ID = obj.Save(_OperationLimitations.FinancialDataCanChange)

            _Consignment.Amount = _Ammount
            _Consignment.TotalValue = _TotalValue
            _Consignment.UnitValue = _UnitCost
            _Consignment.Insert(_ID, _Warehouse.ID)

            If Not TransactionExisted Then DatabaseAccess.TransactionCommit()

            _OldDate = _Date

            MarkOld()

        End Sub

        Friend Sub Update(ByVal ParentJournalEntryID As Integer, _
            ByVal ParentComplexOperationID As Integer, ByVal ParentDocNo As String, _
            ByVal ParentDescription As String)

            If _OperationLimitations.FinancialDataCanChange AndAlso _
                _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent AndAlso _
                _Consignment Is Nothing Then Throw New InvalidOperationException( _
                "Klaida. Prieš išsaugant GoodsTransferOfBalanceItem būtina iškviesti GetConsignment metodą.")

            Dim obj As OperationPersistenceObject = GetPersistenceObj(ParentJournalEntryID, _
                ParentComplexOperationID, ParentDocNo, ParentDescription)

            Dim TransactionExisted As Boolean = DatabaseAccess.TransactionExists
            If Not TransactionExisted Then DatabaseAccess.TransactionBegin()

            obj.Save(_OperationLimitations.FinancialDataCanChange)

            _Consignment.Amount = _Ammount
            _Consignment.TotalValue = _TotalValue
            _Consignment.UnitValue = _UnitCost
            _Consignment.Update(_Warehouse.ID)

            If Not TransactionExisted Then DatabaseAccess.TransactionCommit()

            _OldDate = _Date

            MarkOld()

        End Sub

        Private Function GetPersistenceObj(ByVal ParentJournalEntryID As Integer, _
            ByVal ParentComplexOperationID As Integer, ByVal ParentDocNo As String, _
            ByVal ParentDescription As String) As OperationPersistenceObject

            Dim obj As OperationPersistenceObject
            If IsNew Then
                obj = OperationPersistenceObject.NewOperationPersistenceObject
            Else
                obj = OperationPersistenceObject.GetOperationPersistenceObject(_ID, False)
            End If

            If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic Then

                obj.Amount = CRound(_Ammount - _AmountInWarehouse, 6)
                obj.AmountInPurchases = CRound(_Ammount - _AmountInWarehouse, 6)
                obj.AmountInWarehouse = _AmountInWarehouse
                obj.AccountDiscounts = -_Discounts
                obj.AccountGeneral = _TotalValueInWarehouse
                obj.AccountPriceCut = -_PriceCut
                obj.AccountPurchases = CRound(_TotalValue - _TotalValueInWarehouse)
                obj.AccountSalesNetCosts = _SalesNetCosts
                obj.TotalValue = CRound(_TotalValue - _TotalValueInWarehouse)
                obj.UnitValue = _UnitCost

            Else

                obj.Amount = _Ammount
                obj.AmountInPurchases = 0
                obj.AmountInWarehouse = _Ammount
                obj.AccountDiscounts = 0
                obj.AccountGeneral = _TotalValue
                obj.AccountPriceCut = -_PriceCut
                obj.AccountPurchases = 0
                obj.AccountSalesNetCosts = 0
                obj.TotalValue = _TotalValue
                obj.UnitValue = _UnitCost

            End If

            obj.Content = ParentDescription
            obj.DocNo = ParentDocNo
            obj.GoodsID = _GoodsInfo.ID
            obj.JournalEntryID = ParentJournalEntryID
            obj.OperationDate = _Date
            obj.OperationType = GoodsOperationType.TransferOfBalance
            obj.WarehouseID = _Warehouse.ID
            obj.Warehouse = _Warehouse
            obj.ComplexOperationID = ParentComplexOperationID

            Return obj

        End Function


        Friend Sub DeleteSelf()

            Dim TransactionExisted As Boolean = DatabaseAccess.TransactionExists
            If Not TransactionExisted Then DatabaseAccess.TransactionBegin()

            OperationPersistenceObject.DeleteConsignments(_ID)

            OperationPersistenceObject.Delete(_ID)

            If Not TransactionExisted Then DatabaseAccess.TransactionCommit()

            MarkNew()

        End Sub


        Friend Function CheckIfCanDelete(ByVal LimitationsDataSource As DataTable, _
            ByVal ThrowOnInvalid As Boolean) As String

            If IsNew Then Return ""

            If LimitationsDataSource Is Nothing Then
                _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                    _ID, GoodsOperationType.Acquisition, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _Warehouse.ID, Nothing)
            Else
                _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                    _ID, GoodsOperationType.Acquisition, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _Warehouse.ID, _
                    Nothing, LimitationsDataSource)
            End If

            If Not _OperationLimitations.FinancialDataCanChange Then
                If ThrowOnInvalid Then
                    Throw New Exception("Klaida. Prekių '" & _OperationLimitations.CurrentGoodsName _
                        & "' likučių perkėlimo operacijos pašalinti negalima:" & vbCrLf _
                        & _OperationLimitations.FinancialDataCanChangeExplanation)
                Else
                    Return "Klaida. Prekių '" & _OperationLimitations.CurrentGoodsName _
                        & "' likučių perkėlimo operacijos pašalinti negalima:" & vbCrLf _
                        & _OperationLimitations.FinancialDataCanChangeExplanation
                End If
            End If

            Return ""

        End Function

        Friend Function CheckIfCanUpdate(ByVal LimitationsDataSource As DataTable, _
            ByVal ThrowOnInvalid As Boolean) As String

            If IsNew Then

                _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                    _ID, GoodsOperationType.TransferOfBalance, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _Date, _Warehouse.ID, Nothing)

            Else

                If LimitationsDataSource Is Nothing Then

                    _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                        _ID, GoodsOperationType.TransferOfBalance, _GoodsInfo.ValuationMethod, _
                        _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _Warehouse.ID, Nothing)

                Else

                    _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                        _ID, GoodsOperationType.TransferOfBalance, _GoodsInfo.ValuationMethod, _
                        _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _Warehouse.ID, _
                        Nothing, LimitationsDataSource)

                End If

            End If

            ValidationRules.CheckRules()
            If Not IsValid Then
                If ThrowOnInvalid Then
                    Throw New Exception("Prekių '" & _GoodsInfo.Name & "' likučių perkėlimo operacijoje yra klaidų: " _
                        & BrokenRulesCollection.ToString)
                Else
                    Return "Prekių '" & _GoodsInfo.Name & "' likučių perkėlimo operacijoje yra klaidų: " _
                        & BrokenRulesCollection.ToString
                End If
            End If

            Return ""

        End Function

        Friend Sub ReloadLimitations(ByVal LimitationsDataSource As DataTable)

            If LimitationsDataSource Is Nothing Then Throw New ArgumentNullException( _
                "Klaida. Metodui GoodsTransferOfBalanceItem.ReloadLimitations " _
                & "nenurodytas LimitationsDataSource parametras.")
            If IsNew Then Throw New InvalidOperationException("Klaida. " _
                & "Metodas GoodsTransferOfBalanceItem.ReloadLimitations gali " _
                & "būti taikomas tik Old objektams.")

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                _ID, GoodsOperationType.TransferOfBalance, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _Warehouse.ID, _
                Nothing, LimitationsDataSource)

            ValidationRules.CheckRules()

        End Sub

        Friend Sub GetConsignment()

            If IsNew Then
                _Consignment = ConsignmentPersistenceObject.NewConsignmentPersistenceObject()
            Else
                Dim list As ConsignmentPersistenceObjectList = ConsignmentPersistenceObjectList. _
                    GetConsignmentPersistenceObjectList(_ID)
                If list.Count < 1 Then Throw New Exception("Klaida. Nerastas partijos įrašas " _
                    & "prekės '" & _GoodsInfo.Name & "' likučių perkėlimo operacijai.")
                If list.Count > 1 Then Throw New Exception("Klaida. Yra daugiau ne vienas partijos įrašas " _
                    & "prekės '" & _GoodsInfo.Name & "' likučių perkėlimo operacijai. Tikėtina, sugadinta duombazė.")
                _Consignment = list(0)
            End If

            _Consignment.Amount = _Ammount
            _Consignment.TotalValue = _TotalValue
            _Consignment.UnitValue = _UnitCost

        End Sub

#End Region

    End Class

End Namespace