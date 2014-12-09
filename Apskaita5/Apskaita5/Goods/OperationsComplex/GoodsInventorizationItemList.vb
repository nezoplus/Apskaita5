Namespace Goods

    <Serializable()> _
    Public Class GoodsInventorizationItemList
        Inherits BusinessListBase(Of GoodsInventorizationItemList, GoodsInventorizationItem)

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
            For Each i As GoodsInventorizationItem In Me
                If i.GoodsInfo.ID = GoodsID Then Return True
            Next
            For Each i As GoodsInventorizationItem In Me.DeletedList
                If Not i.IsNew AndAlso i.GoodsInfo.ID = GoodsID Then Return True
            Next
            Return False
        End Function

        Friend Sub ReloadLimitations(ByVal LimitationsDataSource As DataTable, _
            ByVal OperationDate As Date, ByVal WarehouseID As Integer)
            RaiseListChangedEvents = False
            For Each i As GoodsInventorizationItem In Me
                If Not i.IsNew Then i.ReloadLimitations(LimitationsDataSource, OperationDate, WarehouseID)
            Next
            RaiseListChangedEvents = True
        End Sub

        Friend Function CheckIfCanUpdate(ByVal LimitationsDataSource As DataTable, _
            ByVal OperationDate As Date, ByVal WarehouseID As Integer, ByVal ThrowOnInvalid As Boolean) As String

            Dim result As String = ""

            For Each i As GoodsInventorizationItem In Me
                result = AddWithNewLine(result, i.CheckIfCanUpdate(LimitationsDataSource, _
                    OperationDate, WarehouseID, ThrowOnInvalid), False)
            Next

            For Each i As GoodsInventorizationItem In Me.DeletedList
                result = AddWithNewLine(result, i.CheckIfCanDelete(LimitationsDataSource, _
                    OperationDate, WarehouseID, ThrowOnInvalid), False)
            Next

            Return result

        End Function

        Friend Function GetLimitations() As OperationalLimitList()
            Dim result As New List(Of OperationalLimitList)
            For Each i As GoodsInventorizationItem In Me
                result.Add(i.OperationLimitations)
            Next
            Return result.ToArray
        End Function

        Friend Sub PrepareOperationConsignments(ByVal parent As GoodsComplexOperationInventorization)
            RaiseListChangedEvents = False
            For Each i As GoodsInventorizationItem In Me
                i.PrepareConsignments(parent)
            Next
            RaiseListChangedEvents = True
        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewGoodsInventorizationItemList(ByVal myData As DataTable, _
            ByVal consignmentDictionary As Dictionary(Of Integer, ConsignmentPersistenceObjectList), _
            ByVal LimitationsDataSource As DataTable, ByVal OperationDate As Date, _
            ByVal OperationWarehouseID As Integer) As GoodsInventorizationItemList
            Return New GoodsInventorizationItemList(myData, consignmentDictionary, _
                LimitationsDataSource, OperationDate, OperationWarehouseID, True)
        End Function

        Friend Shared Function GetGoodsInventorizationItemList(ByVal myData As DataTable, _
            ByVal consignmentDictionary As Dictionary(Of Integer, ConsignmentPersistenceObjectList), _
            ByVal LimitationsDataSource As DataTable, ByVal OperationDate As Date, _
            ByVal OperationWarehouseID As Integer) As GoodsInventorizationItemList
            Return New GoodsInventorizationItemList(myData, consignmentDictionary, _
                LimitationsDataSource, OperationDate, OperationWarehouseID, False)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = False
        End Sub

        Private Sub New(ByVal myData As DataTable, ByVal consignmentDictionary As Dictionary(Of Integer, _
            ConsignmentPersistenceObjectList), ByVal LimitationsDataSource As DataTable, _
            ByVal OperationDate As Date, ByVal OperationWarehouseID As Integer, ByVal CreateNew As Boolean)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = False
            Fetch(myData, consignmentDictionary, LimitationsDataSource, OperationDate, _
                OperationWarehouseID, CreateNew)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal myData As DataTable, ByVal consignmentDictionary As Dictionary(Of Integer, _
            ConsignmentPersistenceObjectList), ByVal LimitationsDataSource As DataTable, _
            ByVal OperationDate As Date, ByVal OperationWarehouseID As Integer, ByVal CreateNew As Boolean)

            RaiseListChangedEvents = False

            If CreateNew Then
                For Each dr As DataRow In myData.Rows
                    Add(GoodsInventorizationItem.NewGoodsInventorizationItem(dr, consignmentDictionary, _
                        LimitationsDataSource, OperationDate, OperationWarehouseID))
                Next
            Else
                For Each dr As DataRow In myData.Rows
                    Add(GoodsInventorizationItem.GetGoodsInventorizationItem(dr, consignmentDictionary, _
                        LimitationsDataSource, OperationDate, OperationWarehouseID))
                Next
            End If

            RaiseListChangedEvents = True

        End Sub

        Friend Sub Update(ByVal parent As GoodsComplexOperationInventorization)

            RaiseListChangedEvents = False

            DeletedList.Clear()

            For Each item As GoodsInventorizationItem In Me
                If item.IsNew OrElse item.IsDirty Then item.Update(parent)
            Next

            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace