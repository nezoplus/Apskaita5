Namespace Goods

    <Serializable()> _
    Public Class GoodsProductionCostItem
        Inherits BusinessBase(Of GoodsProductionCostItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _Account As Long = 0
        Private _CostPerProductionUnit As Double = 0
        Private _TotalCost As Double = 0
        Private _FinancialDataCanChange As Boolean = True


        Public ReadOnly Property FinancialDataCanChange() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        Public Property Account() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _Account <> value Then
                    _Account = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property CostPerProductionUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CostPerProductionUnit, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)

                If Not _FinancialDataCanChange Then Exit Property

                If CRound(_CostPerProductionUnit, 6) <> CRound(value, 6) Then

                    Dim ammountCalculated As Double = 0
                    If CRound(_CostPerProductionUnit, 6) > 0 Then ammountCalculated = _
                        CRound(_TotalCost / _CostPerProductionUnit, 6)

                    _CostPerProductionUnit = CRound(value, 6)
                    PropertyHasChanged()

                    If CRound(ammountCalculated, 6) > 0 Then TotalCost = _
                        CRound(_CostPerProductionUnit * ammountCalculated)

                End If

            End Set
        End Property

        Public Property TotalCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalCost)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)

                If Not _FinancialDataCanChange Then Exit Property

                If CRound(_TotalCost) <> CRound(value) Then
                    _TotalCost = CRound(value)
                    PropertyHasChanged()
                End If

            End Set
        End Property



        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & _Account.ToString & "': " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & _Account.ToString & "' gali būti klaida: " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
        End Function


        Friend Sub RecalculateForProductionAmount(ByVal AmmountInProduction As Double)
            TotalCost = CRound(_CostPerProductionUnit * AmmountInProduction)
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return _Account.ToString
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("Account", "sąnaudų sąskaita"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("TotalCost", _
                "sąnaudų, perkeliamų į gaminio savikainą, suma"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("CostPerProductionUnit", _
                "sąnaudų, tenkančių gaminio vienetui, suma"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewGoodsProductionCostItem() As GoodsProductionCostItem
            Dim result As New GoodsProductionCostItem
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function NewGoodsProductionCostItem(ByVal calculationCost _
            As ProductionCostItem, ByVal productionAmount As Double) As GoodsProductionCostItem
            Return New GoodsProductionCostItem(calculationCost, productionAmount)
        End Function

        Friend Shared Function GetGoodsProductionCostItem(ByVal dr As BookEntryInternal, _
            ByVal productionAmount As Double, ByVal nFinancialDataCanChange As Boolean) As GoodsProductionCostItem
            Return New GoodsProductionCostItem(dr, productionAmount, nFinancialDataCanChange)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal calculationCost As ProductionCostItem, ByVal productionAmount As Double)
            ' require use of factory methods
            MarkAsChild()
            Create(calculationCost, productionAmount)
        End Sub

        Private Sub New(ByVal dr As BookEntryInternal, ByVal productionAmount As Double, ByVal nFinancialDataCanChange As Boolean)
            MarkAsChild()
            Fetch(dr, productionAmount, nFinancialDataCanChange)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal calculationCost As ProductionCostItem, ByVal productionAmount As Double)

            If Not CRound(productionAmount, 6) > 0 Then productionAmount = 1

            _CostPerProductionUnit = CRound(calculationCost.Amount / productionAmount, 6)
            _TotalCost = calculationCost.Amount
            _Account = calculationCost.Account

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As BookEntryInternal, ByVal productionAmount As Double, _
            ByVal nFinancialDataCanChange As Boolean)

            _Account = dr.Account
            _TotalCost = dr.Ammount
            If CRound(productionAmount, 6) > 0 Then _CostPerProductionUnit = _
                CRound(_TotalCost / productionAmount, 6)
            _FinancialDataCanChange = nFinancialDataCanChange

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Friend Function GetBookEntryInternal() As BookEntryInternal

            Dim result As BookEntryInternal = BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas)
            result.Ammount = _TotalCost
            result.Account = _Account
            
            Return result

        End Function

#End Region

    End Class


End Namespace