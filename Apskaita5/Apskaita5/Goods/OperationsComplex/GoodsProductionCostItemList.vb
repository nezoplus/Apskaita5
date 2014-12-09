Namespace Goods

    <Serializable()> _
    Public Class GoodsProductionCostItemList
        Inherits BusinessListBase(Of GoodsProductionCostItemList, GoodsProductionCostItem)

#Region " Business Methods "

        Private _IsLoading As Boolean = False


        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As GoodsProductionCostItem = GoodsProductionCostItem.NewGoodsProductionCostItem
            Me.Add(NewItem)
            Return NewItem
        End Function


        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function


        Friend Sub RecalculateForProductionAmount(ByVal AmmountInProduction As Double)
            Me.RaiseListChangedEvents = False
            For Each c As GoodsProductionCostItem In Me
                c.RecalculateForProductionAmount(AmmountInProduction)
            Next
            Me.RaiseListChangedEvents = True
            Me.ResetBindings()
        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewGoodsProductionCostItemList() As GoodsProductionCostItemList
            Return New GoodsProductionCostItemList
        End Function

        Friend Shared Function NewGoodsProductionCostItemList(ByVal calculationCosts _
            As ProductionCostItemList, ByVal productionAmount As Double) As GoodsProductionCostItemList
            Return New GoodsProductionCostItemList(calculationCosts, productionAmount)
        End Function

        Friend Shared Function GetGoodsProductionCostItemList(ByVal costEntryList As BookEntryInternalList, _
            ByVal productionAmount As Double, ByVal nFinancialDataCanChange As Boolean) As GoodsProductionCostItemList
            Return New GoodsProductionCostItemList(costEntryList, productionAmount, nFinancialDataCanChange)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal calculationCosts As ProductionCostItemList, ByVal productionAmount As Double)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Create(calculationCosts, productionAmount)
        End Sub

        Private Sub New(ByVal costEntryList As BookEntryInternalList, _
            ByVal productionAmount As Double, ByVal nFinancialDataCanChange As Boolean)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = nFinancialDataCanChange
            Me.AllowNew = nFinancialDataCanChange
            Me.AllowRemove = nFinancialDataCanChange
            Fetch(costEntryList, productionAmount, nFinancialDataCanChange)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal calculationCosts As ProductionCostItemList, ByVal productionAmount As Double)

            RaiseListChangedEvents = False

            For Each dr As ProductionCostItem In calculationCosts
                Add(GoodsProductionCostItem.NewGoodsProductionCostItem(dr, productionAmount))
            Next

            RaiseListChangedEvents = True

        End Sub

        Private Sub Fetch(ByVal costEntryList As BookEntryInternalList, _
            ByVal productionAmount As Double, ByVal nFinancialDataCanChange As Boolean)

            RaiseListChangedEvents = False

            For Each b As BookEntryInternal In costEntryList
                Add(GoodsProductionCostItem.GetGoodsProductionCostItem(b, _
                    productionAmount, nFinancialDataCanChange))
            Next

            RaiseListChangedEvents = True

        End Sub

        Friend Function GetBookEntryInternalList() As BookEntryInternalList

            Dim result As BookEntryInternalList = _
               BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Kreditas)

            RaiseListChangedEvents = False

            DeletedList.Clear()

            For Each item As GoodsProductionCostItem In Me
                result.Add(item.GetBookEntryInternal)
            Next

            RaiseListChangedEvents = True

            Return result

        End Function

#End Region

    End Class

End Namespace