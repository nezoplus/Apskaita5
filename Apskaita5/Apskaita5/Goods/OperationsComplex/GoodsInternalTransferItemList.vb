Namespace Goods

    <Serializable()> _
    Public Class GoodsInternalTransferItemList
        Inherits BusinessListBase(Of GoodsInternalTransferItemList, GoodsInternalTransferItem)

#Region " Business Methods "

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
            For Each i As GoodsInternalTransferItem In Me
                If i.GoodsInfo.ID = GoodsID Then Return True
            Next
            For Each i As GoodsInternalTransferItem In Me.DeletedList
                If Not i.IsNew AndAlso i.GoodsInfo.ID = GoodsID Then Return True
            Next
            Return False
        End Function

        Friend Function RequiresJournalEntry() As Boolean
            For Each i As GoodsInternalTransferItem In Me
                If i.RequiresJournalEntry Then Return True
            Next
            Return False
        End Function


        Friend Sub SetDate(ByVal value As Date)
            RaiseListChangedEvents = False
            For Each i As GoodsInternalTransferItem In Me
                i.SetDate(value)
            Next
            RaiseListChangedEvents = True
        End Sub

        Friend Sub SetWarehouseFrom(ByVal value As WarehouseInfo)
            RaiseListChangedEvents = False
            For Each i As GoodsInternalTransferItem In Me
                i.SetWarehouseFrom(value)
            Next
            RaiseListChangedEvents = True
        End Sub

        Friend Sub SetWarehouseTo(ByVal value As WarehouseInfo)
            RaiseListChangedEvents = False
            For Each i As GoodsInternalTransferItem In Me
                i.SetWarehouseTo(value)
            Next
            RaiseListChangedEvents = True
        End Sub

        Friend Sub SetValues(ByVal parent As GoodsComplexOperationInternalTransfer)
            RaiseListChangedEvents = False
            For Each i As GoodsInternalTransferItem In Me
                i.SetDate(parent.Date)
                i.SetWarehouseFrom(parent.WarehouseFrom)
                i.SetWarehouseTo(parent.WarehouseTo)
                i.SetDescription(parent.Content)
            Next
            RaiseListChangedEvents = True
        End Sub


        Friend Sub ReloadCostInfo(ByVal list As GoodsCostItemList)

            RaiseListChangedEvents = False
            For Each c As GoodsCostItem In list
                For Each i As GoodsInternalTransferItem In Me
                    If c.GoodsID = i.GoodsInfo.ID Then
                        i.ReloadCostInfo(c)
                        Exit For
                    End If
                Next
            Next
            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub


        Friend Function GetLimitations(ByVal ForAcquisitions As Boolean) As OperationalLimitList()
            Dim result As New List(Of OperationalLimitList)
            For Each i As GoodsInternalTransferItem In Me
                If ForAcquisitions Then
                    result.Add(i.Acquisition.OperationLimitations)
                Else
                    result.Add(i.Transfer.OperationLimitations)
                End If
            Next
            Return result.ToArray
        End Function

        Friend Sub ReloadLimitations(ByVal LimitationsDataSource As DataTable, _
            ByVal nFinancialDataCanChange As Boolean)
            RaiseListChangedEvents = False
            For Each i As GoodsInternalTransferItem In Me
                If Not i.IsNew Then
                    i.Acquisition.ReloadLimitations(LimitationsDataSource)
                    i.Transfer.ReloadLimitations(LimitationsDataSource)
                    i.SetFinancialDataCanChange(nFinancialDataCanChange)
                End If
            Next
            For Each i As GoodsInternalTransferItem In Me.DeletedList
                If Not i.IsNew Then
                    i.Acquisition.ReloadLimitations(LimitationsDataSource)
                    i.Transfer.ReloadLimitations(LimitationsDataSource)
                    i.SetFinancialDataCanChange(nFinancialDataCanChange)
                End If
            Next
            RaiseListChangedEvents = True
        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewGoodsInternalTransferItemList() As GoodsInternalTransferItemList
            Return New GoodsInternalTransferItemList
        End Function

        Friend Shared Function GetGoodsInternalTransferItemList( _
            ByVal objList As List(Of OperationPersistenceObject), _
            ByVal LimitationsDataSource As DataTable, ByVal nFinancialDataCanChange As Boolean) As GoodsInternalTransferItemList
            Return New GoodsInternalTransferItemList(objList, LimitationsDataSource, nFinancialDataCanChange)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal objList As List(Of OperationPersistenceObject), _
            ByVal LimitationsDataSource As DataTable, ByVal nFinancialDataCanChange As Boolean)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
            Fetch(objList, LimitationsDataSource, nFinancialDataCanChange)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal objList As List(Of OperationPersistenceObject), _
            ByVal LimitationsDataSource As DataTable, ByVal nFinancialDataCanChange As Boolean)

            RaiseListChangedEvents = False

            For Each obj As OperationPersistenceObject In objList
                If obj.OperationType <> GoodsOperationType.Transfer AndAlso _
                    obj.OperationType <> GoodsOperationType.Acquisition Then _
                    Throw New Exception("Klaida. Sugadinti duomenys. Vidinio judėjimo kompleksinei " _
                    & "operacijai priskirta prekių operacija, kurios tipas " _
                    & ConvertEnumHumanReadable(obj.OperationType) & ".")
                If Not Me.ContainsGood(obj.GoodsID) Then MyBase.Add( _
                    GoodsInternalTransferItem.GetGoodsInternalTransferItem( _
                    obj, objList, LimitationsDataSource, nFinancialDataCanChange))
            Next

            RaiseListChangedEvents = True

        End Sub

        Friend Sub Update(ByVal parent As GoodsComplexOperationInternalTransfer)

            RaiseListChangedEvents = False

            For Each item As GoodsInternalTransferItem In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As GoodsInternalTransferItem In Me
                If item.IsNew OrElse item.IsDirty Then
                    item.Update(parent)
                End If
            Next

            RaiseListChangedEvents = True

        End Sub


        Friend Function CheckIfCanUpdate(ByVal LimitationsDataSource As DataTable, _
            ByVal ThrowOnInvalid As Boolean) As String

            Dim result As String = ""

            For Each i As GoodsInternalTransferItem In Me
                result = AddWithNewLine(result, i.CheckIfCanUpdate(LimitationsDataSource, ThrowOnInvalid), False)
            Next

            For Each i As GoodsInternalTransferItem In Me.DeletedList
                If Not i.IsNew Then result = AddWithNewLine(result, _
                    i.CheckIfCanDelete(LimitationsDataSource, ThrowOnInvalid), False)
            Next

            Return result

        End Function

        Friend Sub PrepareOperationConsignments()
            RaiseListChangedEvents = False
            For Each i As GoodsInternalTransferItem In Me
                i.PrepareConsignements()
            Next
            RaiseListChangedEvents = True
        End Sub

#End Region

    End Class

End Namespace