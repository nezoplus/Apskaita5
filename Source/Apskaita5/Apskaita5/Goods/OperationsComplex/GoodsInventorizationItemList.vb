﻿Namespace Goods

    ''' <summary>
    ''' Represents a collection of goods inventory operations
    ''' that belong to a complex goods inventorization document.
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="GoodsComplexOperationInventorization">GoodsComplexOperationInventorization</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsInventorizationItemList
        Inherits BusinessListBase(Of GoodsInventorizationItemList, GoodsInventorizationItem)

#Region " Business Methods "

        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            Return result
        End Function

        Public Function HasWarnings() As Boolean
            For Each i As GoodsInventorizationItem In Me
                If i.HasWarnings() Then Return True
            Next
            Return False
        End Function


        ''' <summary>
        ''' Returns whether the list contains an item for the goods specified.
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' to look for</param>
        ''' <remarks></remarks>
        Public Function ContainsGood(ByVal goodsID As Integer) As Boolean
            For Each i As GoodsInventorizationItem In Me
                If i.GoodsInfo.ID = goodsID Then Return True
            Next
            For Each i As GoodsInventorizationItem In Me.DeletedList
                If Not i.IsNew AndAlso i.GoodsInfo.ID = goodsID Then Return True
            Next
            Return False
        End Function


        Friend Function GetLimitations() As OperationalLimitList()
            Dim result As New List(Of OperationalLimitList)
            For Each i As GoodsInventorizationItem In Me
                result.Add(i.OperationLimitations)
            Next
            Return result.ToArray
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function NewGoodsInventorizationItemList(ByVal myData As DataTable, _
            ByVal consignmentDictionary As Dictionary(Of Integer, ConsignmentPersistenceObjectList), _
            ByVal limitationsDataSource As DataTable, ByVal operationDate As Date, _
            ByVal operationWarehouseID As Integer) As GoodsInventorizationItemList
            Return New GoodsInventorizationItemList(myData, consignmentDictionary, _
                limitationsDataSource, operationDate, operationWarehouseID, True)
        End Function

        Friend Shared Function GetGoodsInventorizationItemList(ByVal myData As DataTable, _
            ByVal consignmentDictionary As Dictionary(Of Integer, ConsignmentPersistenceObjectList), _
            ByVal limitationsDataSource As DataTable, ByVal operationDate As Date, _
            ByVal operationWarehouseID As Integer) As GoodsInventorizationItemList
            Return New GoodsInventorizationItemList(myData, consignmentDictionary, _
                limitationsDataSource, operationDate, operationWarehouseID, False)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = False
        End Sub

        Private Sub New(ByVal myData As DataTable, ByVal consignmentDictionary As Dictionary(Of Integer,  _
            ConsignmentPersistenceObjectList), ByVal limitationsDataSource As DataTable, _
            ByVal operationDate As Date, ByVal operationWarehouseID As Integer, ByVal createNew As Boolean)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = False
            Fetch(myData, consignmentDictionary, limitationsDataSource, operationDate, _
                operationWarehouseID, createNew)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal myData As DataTable, ByVal consignmentDictionary As Dictionary(Of Integer,  _
            ConsignmentPersistenceObjectList), ByVal limitationsDataSource As DataTable, _
            ByVal operationDate As Date, ByVal operationWarehouseID As Integer, ByVal createNew As Boolean)

            RaiseListChangedEvents = False

            If createNew Then
                For Each dr As DataRow In myData.Rows
                    Add(GoodsInventorizationItem.NewGoodsInventorizationItem(dr, consignmentDictionary, _
                        limitationsDataSource, operationDate, operationWarehouseID))
                Next
            Else
                For Each dr As DataRow In myData.Rows
                    Add(GoodsInventorizationItem.GetGoodsInventorizationItem(dr, consignmentDictionary, _
                        limitationsDataSource, operationDate, operationWarehouseID))
                Next
            End If

            RaiseListChangedEvents = True

        End Sub

        Friend Sub Update(ByVal parent As GoodsComplexOperationInventorization)

            RaiseListChangedEvents = False

            For Each item As GoodsInventorizationItem In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As GoodsInventorizationItem In Me
                If item.IsNew OrElse item.IsDirty Then item.Update(parent)
            Next

            RaiseListChangedEvents = True

        End Sub


        Friend Sub CheckIfCanUpdate(ByVal limitationsDataSource As DataTable)

            For Each i As GoodsInventorizationItem In Me
                i.CheckIfCanUpdate(limitationsDataSource)
            Next

            For Each i As GoodsInventorizationItem In Me.DeletedList
                i.CheckIfCanDelete(limitationsDataSource)
            Next

        End Sub

        Friend Sub PrepareOperationConsignments(ByVal parent As GoodsComplexOperationInventorization)
            RaiseListChangedEvents = False
            For Each i As GoodsInventorizationItem In Me
                i.PrepareConsignments(parent)
            Next
            RaiseListChangedEvents = True
        End Sub

        Friend Function GetTotalBookEntryList(ByVal parent As GoodsComplexOperationInventorization) As BookEntryInternalList

            Dim result As BookEntryInternalList = BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

            For Each o As GoodsInventorizationItem In Me
                result.AddRange(o.GetTotalBookEntryList(parent))
            Next

            Return result

        End Function

#End Region

    End Class

End Namespace