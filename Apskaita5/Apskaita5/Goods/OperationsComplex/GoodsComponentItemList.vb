Namespace Goods

    <Serializable()> _
    Public Class GoodsComponentItemList
        Inherits BusinessListBase(Of GoodsComponentItemList, GoodsComponentItem)

#Region " Business Methods "

        Private _IsLoading As Boolean = False


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


        Public Function ContainsGood(ByVal GoodsID As Integer) As Boolean
            For Each i As GoodsComponentItem In Me
                If i.GoodsInfo.ID = GoodsID Then Return True
            Next
            For Each i As GoodsComponentItem In Me.DeletedList
                If Not i.IsNew AndAlso i.GoodsInfo.ID = GoodsID Then Return True
            Next
            Return False
        End Function

        Public Function ContainsCalculatedAtRuntimeValueGoods() As Boolean
            For Each c As GoodsComponentItem In Me
                If c.GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent Then Return True
            Next
        End Function


        Protected Overrides Sub RemoveItem(ByVal index As Integer)
            If Not _IsLoading Then
                If index < 0 OrElse index >= Me.Count Then Throw New IndexOutOfRangeException( _
                    "Index out of range in GoodsComponentItemList.RemoveItem. Index=" & index.ToString _
                    & "; Count=" & Me.Count.ToString & ".")
                If Not Items(index).Discard.OperationLimitations.FinancialDataCanChange Then _
                    Throw New Exception("Klaida. Eilutė """ & Items(index).GoodsName _
                    & """ negali būti pašalinta: " & Items(index).Discard.OperationLimitations. _
                    FinancialDataCanChangeExplanation)
            End If
            MyBase.RemoveItem(index)
        End Sub

        Friend Sub RecalculateForProductionAmount(ByVal AmmountInProduction As Double)
            Me.RaiseListChangedEvents = False
            For Each c As GoodsComponentItem In Me
                c.RecalculateForProductionAmount(AmmountInProduction)
            Next
            Me.RaiseListChangedEvents = True
            Me.ResetBindings()
        End Sub


        Friend Sub SetDate(ByVal value As Date)
            RaiseListChangedEvents = False
            For Each i As GoodsComponentItem In Me
                i.SetDate(value)
            Next
            RaiseListChangedEvents = True
        End Sub

        Friend Sub SetWarehouse(ByVal value As WarehouseInfo)
            For Each i As GoodsComponentItem In Me
                If Not i.Discard.OperationLimitations.FinancialDataCanChange Then Throw New Exception( _
                    "Jokie gamybos akto finansiniai duomenys negali būti keičiami dėl ribojimo " _
                    & "eilutei """ & i.GoodsName & """:" & vbCrLf & i.Discard.OperationLimitations. _
                    FinancialDataCanChangeExplanation)
            Next
            RaiseListChangedEvents = False
            For Each i As GoodsComponentItem In Me
                i.SetWarehouse(value)
            Next
            RaiseListChangedEvents = True
        End Sub

        Friend Sub SetValues(ByVal parent As GoodsComplexOperationProduction)
            RaiseListChangedEvents = False
            For Each i As GoodsComponentItem In Me
                i.SetValues(parent)
            Next
            RaiseListChangedEvents = True
        End Sub

        Friend Sub ReloadCostInfo(ByVal list As GoodsCostItemList)

            For Each i As GoodsComponentItem In Me
                If Not i.Discard.OperationLimitations.FinancialDataCanChange Then Throw New Exception( _
                    "Jokie gamybos akto finansiniai duomenys negali būti keičiami dėl ribojimo " _
                    & "eilutei """ & i.GoodsName & """:" & vbCrLf & i.Discard.OperationLimitations. _
                    FinancialDataCanChangeExplanation)
            Next

            RaiseListChangedEvents = False
            For Each c As GoodsCostItem In list
                For Each i As GoodsComponentItem In Me
                    If c.GoodsID = i.GoodsInfo.ID Then
                        i.ReloadCostInfo(c)
                        Exit For
                    End If
                Next
            Next
            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub


        Friend Function GetLimitations() As OperationalLimitList()
            Dim result As New List(Of OperationalLimitList)
            For Each i As GoodsComponentItem In Me
                result.Add(i.Discard.OperationLimitations)
            Next
            Return result.ToArray
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function NewGoodsComponentItemList() As GoodsComponentItemList
            Return New GoodsComponentItemList
        End Function

        Friend Shared Function NewGoodsComponentItemList(ByVal calculationComponents _
            As ProductionComponentItemList, ByVal productionAmount As Double, _
            ByVal parentValidator As IChronologicValidator) As GoodsComponentItemList
            Return New GoodsComponentItemList(calculationComponents, productionAmount, parentValidator)
        End Function

        Friend Shared Function GetGoodsComponentItemList(ByVal objList As List(Of OperationPersistenceObject), _
            ByVal parentValidator As IChronologicValidator, ByVal LimitationsDataSource As DataTable) As GoodsComponentItemList
            Return New GoodsComponentItemList(objList, parentValidator, LimitationsDataSource)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal calculationComponents As ProductionComponentItemList, _
            ByVal productionAmount As Double, ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
            Create(calculationComponents, productionAmount, parentValidator)
        End Sub

        Private Sub New(ByVal objList As List(Of OperationPersistenceObject), _
            ByVal parentValidator As IChronologicValidator, ByVal LimitationsDataSource As DataTable)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = parentValidator.FinancialDataCanChange
            Fetch(objList, parentValidator, LimitationsDataSource)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal calculationComponents As ProductionComponentItemList, _
            ByVal productionAmount As Double, ByVal parentValidator As IChronologicValidator)

            RaiseListChangedEvents = False
            _IsLoading = True

            Dim acquisitionCount As Integer = 0
            For Each obj As ProductionComponentItem In calculationComponents
                Add(GoodsComponentItem.NewGoodsComponentItem(obj, productionAmount, parentValidator))
            Next

            _IsLoading = False
            RaiseListChangedEvents = True

        End Sub

        Private Sub Fetch(ByVal objList As List(Of OperationPersistenceObject), _
            ByVal parentValidator As IChronologicValidator, ByVal LimitationsDataSource As DataTable)

            RaiseListChangedEvents = False
            _IsLoading = True

            Dim productionAmount As Double = 0
            Dim acquisitionMissing As Boolean = True
            For Each obj As OperationPersistenceObject In objList
                If obj.OperationType = GoodsOperationType.Acquisition Then
                    productionAmount = obj.Amount
                    acquisitionMissing = False
                    Exit For
                End If
            Next

            If acquisitionMissing Then Throw New Exception("Klaida. Nerastas operacijos " _
                & "pagamintų prekių pajamavimo įrašas.")

            For Each obj As OperationPersistenceObject In objList
                If obj.OperationType = GoodsOperationType.Discard Then _
                    Add(GoodsComponentItem.GetGoodsComponentItem(obj, productionAmount, _
                        parentValidator, LimitationsDataSource))
            Next

            _IsLoading = False
            RaiseListChangedEvents = True

        End Sub

        Friend Sub Update(ByVal parent As GoodsComplexOperationProduction)

            RaiseListChangedEvents = False
            _IsLoading = True

            For Each item As GoodsComponentItem In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As GoodsComponentItem In Me
                If item.IsNew OrElse item.IsDirty Then
                    item.Update(parent)
                End If
            Next

            _IsLoading = False
            RaiseListChangedEvents = True

        End Sub


        Friend Function GetBookEntryInternalList(ByVal invert As Boolean) As BookEntryInternalList

            Dim result As BookEntryInternalList = BookEntryInternalList. _
                NewBookEntryInternalList(BookEntryType.Kreditas)

            For Each c As GoodsComponentItem In Me
                result.Add(c.GetBookEntryInternal(invert))
            Next

            Return result

        End Function

        Friend Sub ReloadLimitations(ByVal LimitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator)
            RaiseListChangedEvents = False
            For Each i As GoodsComponentItem In Me
                If Not i.IsNew Then i.Discard.ReloadLimitations(LimitationsDataSource, parentValidator)
            Next
            RaiseListChangedEvents = True
        End Sub

        Friend Function CheckIfCanUpdate(ByVal LimitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator, ByVal ThrowOnInvalid As Boolean) As String

            Dim result As String = ""

            For Each i As GoodsComponentItem In Me
                result = AddWithNewLine(result, i.CheckIfCanUpdate(LimitationsDataSource, _
                    parentValidator, ThrowOnInvalid), False)
            Next

            For Each i As GoodsComponentItem In Me.DeletedList
                result = AddWithNewLine(result, i.CheckIfCanDelete(LimitationsDataSource, _
                    parentValidator, ThrowOnInvalid), False)
            Next

            Return result

        End Function

        Friend Sub PrepareOperationConsignments()
            RaiseListChangedEvents = False
            For Each i As GoodsComponentItem In Me
                i.PrepareConsignements()
            Next
            RaiseListChangedEvents = True
        End Sub

#End Region

    End Class

End Namespace