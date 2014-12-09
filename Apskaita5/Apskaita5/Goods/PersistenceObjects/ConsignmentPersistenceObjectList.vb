Namespace Goods

    <Serializable()> _
    Friend Class ConsignmentPersistenceObjectList
        Inherits BusinessListBase(Of ConsignmentPersistenceObjectList, ConsignmentPersistenceObject)

#Region " Business Methods "

        Friend Sub MergeChangedList(ByVal FinalListView As ConsignmentPersistenceObjectList)

            Dim IsFound As Boolean = False

            For i As Integer = Me.Count - 1 To 0 Step -1
                IsFound = False
                For Each d As ConsignmentPersistenceObject In FinalListView
                    If Item(i).AcquisitionID = d.AcquisitionID Then
                        IsFound = True
                        Exit For
                    End If
                Next
                If Not IsFound Then Me.RemoveAt(i)
            Next

            For Each d As ConsignmentPersistenceObject In FinalListView
                IsFound = False
                For Each c As ConsignmentPersistenceObject In Me
                    If c.AcquisitionID = d.AcquisitionID Then
                        IsFound = True
                        c.Amount = d.Amount
                        c.TotalValue = d.TotalValue
                        c.UnitValue = d.UnitValue
                        Exit For
                    End If
                Next
                If Not IsFound Then Me.Add(d.Clone)
            Next

        End Sub

        Public Function GetTotalValue() As Double
            Dim result As Double = 0
            For Each entry As ConsignmentPersistenceObject In Me
                result = CRound(result + entry.TotalValue)
            Next
            Return result
        End Function

        Friend Sub RemoveLateEntries(ByVal DateLimit As Date)

            If DateLimit = Date.MinValue OrElse DateLimit = Date.MaxValue OrElse Me.Count < 1 Then Exit Sub

            RaiseListChangedEvents = False

            For i As Integer = Me.Count - 1 To 0 Step -1
                If Item(i).AcquisitionDate.Date > DateLimit.Date Then RemoveAt(i)
            Next

            RaiseListChangedEvents = True

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewConsignmentPersistenceObjectList() As ConsignmentPersistenceObjectList
            Return New ConsignmentPersistenceObjectList
        End Function

        Friend Shared Function GetConsignmentPersistenceObjectList(ByVal parentID As Integer) _
            As ConsignmentPersistenceObjectList
            Return New ConsignmentPersistenceObjectList(parentID)
        End Function

        Friend Shared Function GetConsignmentPersistenceObjectList(ByVal warehouseID As Integer, _
            ByVal parentID As Integer) As Dictionary(Of Integer, ConsignmentPersistenceObjectList)

            If Not parentID > 0 Then parentID = -1

            Dim myComm As New SQLCommand("FetchConsignmentPersistenceObjectListForWarehouse")
            myComm.AddParam("?WD", warehouseID)
            myComm.AddParam("?CD", parentID)

            Dim result As Dictionary(Of Integer, ConsignmentPersistenceObjectList)

            Using myData As DataTable = myComm.Fetch

                result = New Dictionary(Of Integer, ConsignmentPersistenceObjectList)

                For Each dr As DataRow In myData.Rows

                    If CIntSafe(dr.Item(10), 0) > 0 AndAlso Not result.ContainsKey(CIntSafe(dr.Item(10), 0)) Then
                        result.Add(CIntSafe(dr.Item(10), 0), New ConsignmentPersistenceObjectList(myData, _
                            CIntSafe(dr.Item(10), 0)))
                    End If

                Next

            End Using

            Return result

        End Function

        Friend Shared Function GetConsignmentPersistenceObjectList(ByVal GoodsID As Integer, _
            ByVal WarehouseID As Integer, ByVal DiscardParentID As Integer, _
            ByVal ConsignmentParentID As Integer, ByVal OrderDesc As Boolean) As ConsignmentPersistenceObjectList
            Return New ConsignmentPersistenceObjectList(GoodsID, WarehouseID, _
                DiscardParentID, ConsignmentParentID, OrderDesc)
        End Function

        Friend Shared Function GetConsignmentPersistenceObjectList( _
            ByVal AvailableConsignments As ConsignmentPersistenceObjectList, _
            ByVal AmountRequired As Double) As ConsignmentPersistenceObjectList
            Return New ConsignmentPersistenceObjectList(AvailableConsignments, AmountRequired)
        End Function

        Friend Function GetInvertedList() As ConsignmentPersistenceObjectList

            Dim result As New ConsignmentPersistenceObjectList

            result.RaiseListChangedEvents = False

            For i As Integer = Me.Count - 1 To 0 Step -1
                result.Add(Me.Item(i - 1).Clone)
            Next

            result.RaiseListChangedEvents = True

            Return result

        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal parentID As Integer)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Fetch(parentID)
        End Sub

        Private Sub New(ByVal GoodsID As Integer, ByVal WarehouseID As Integer, _
            ByVal DiscardParentID As Integer, ByVal ConsignmentParentID As Integer, _
            ByVal OrderDesc As Boolean)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Fetch(GoodsID, WarehouseID, DiscardParentID, ConsignmentParentID, OrderDesc)
        End Sub

        Private Sub New(ByVal AvailableConsignments As ConsignmentPersistenceObjectList, _
            ByVal AmountRequired As Double)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Fetch(AvailableConsignments, AmountRequired)
        End Sub

        Private Sub New(ByVal myData As DataTable, ByVal goodsID As Integer)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            DoFetch(myData, goodsID)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal parentID As Integer)

            If Not parentID > 0 Then parentID = -1

            Dim myComm As New SQLCommand("FetchConsignmentPersistenceObjectListForParent")
            myComm.AddParam("?CD", parentID)

            DoFetch(myComm, False, True)

        End Sub

        Private Sub Fetch(ByVal GoodsID As Integer, ByVal WarehouseID As Integer, _
            ByVal DiscardParentID As Integer, ByVal ConsignmentParentID As Integer, _
            ByVal OrderDesc As Boolean)

            If Not DiscardParentID > 0 Then DiscardParentID = -1
            If Not ConsignmentParentID > 0 Then ConsignmentParentID = -1

            Dim myComm As New SQLCommand("FetchConsignmentPersistenceObjectList")
            myComm.AddParam("?GD", GoodsID)
            myComm.AddParam("?WD", WarehouseID)
            myComm.AddParam("?OD", DiscardParentID)
            myComm.AddParam("?PD", ConsignmentParentID)

            DoFetch(myComm, OrderDesc, False)

        End Sub

        Private Sub Fetch(ByVal AvailableConsignments As ConsignmentPersistenceObjectList, _
            ByVal AmountRequired As Double)

            RaiseListChangedEvents = False

            For Each c As ConsignmentPersistenceObject In AvailableConsignments

                Add(ConsignmentPersistenceObject.NewConsignmentPersistenceObject(c, AmountRequired))

                If Not CRound(AmountRequired, 6) > 0 Then Exit For

            Next

            If CRound(AmountRequired, 6) > 0 Then Throw New Exception( _
                "Klaida. Nepakanka prekių likučio sandėlyje.")

            RaiseListChangedEvents = True

        End Sub

        Private Sub DoFetch(ByVal myComm As SQLCommand, ByVal OrderDesc As Boolean, ByVal IsForUpdate As Boolean)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Exit Sub

                RaiseListChangedEvents = False

                If OrderDesc Then

                    For i As Integer = myData.Rows.Count - 1 To 0 Step -1
                        Add(ConsignmentPersistenceObject.GetConsignmentPersistenceObject(myData.Rows(i), IsForUpdate))
                    Next

                Else

                    For Each dr As DataRow In myData.Rows
                        Add(ConsignmentPersistenceObject.GetConsignmentPersistenceObject(dr, IsForUpdate))
                    Next

                End If

                RaiseListChangedEvents = True

            End Using

        End Sub

        Private Sub DoFetch(ByVal myData As DataTable, ByVal GoodsID As Integer)

            RaiseListChangedEvents = False

            For Each dr As DataRow In myData.Rows
                If CIntSafe(dr.Item(10), 0) = GoodsID Then _
                    Add(ConsignmentPersistenceObject.GetConsignmentPersistenceObject(dr, False))
            Next

            RaiseListChangedEvents = True

        End Sub


        Friend Sub Update(ByVal parentID As Integer, ByVal parentWarehouseID As Integer)

            RaiseListChangedEvents = False

            For Each item As ConsignmentPersistenceObject In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As ConsignmentPersistenceObject In Me
                If item.IsNew Then
                    item.Insert(parentID, parentWarehouseID)
                ElseIf item.IsDirty Then
                    item.Update(parentID)
                End If
            Next

            RaiseListChangedEvents = True

        End Sub

        Friend Shared Sub UpdateWarehouse(ByVal parentID As Integer, _
            ByVal parentWarehouseID As Integer)

            Dim myComm As New SQLCommand("UpdateConsignmentDiscardPersistenceObjectWarehouse")
            myComm.AddParam("?PD", parentID)
            myComm.AddParam("?WD", parentWarehouseID)

            myComm.Execute()

        End Sub

#End Region

    End Class

End Namespace