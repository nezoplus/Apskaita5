Namespace Goods

    <Serializable()> _
    Friend Class ConsignmentDiscardPersistenceObjectList
        Inherits BusinessListBase(Of ConsignmentDiscardPersistenceObjectList, ConsignmentDiscardPersistenceObject)

#Region " Business Methods "

        Friend Sub MergeChangedList(ByVal FinalListView As ConsignmentDiscardPersistenceObjectList)

            Dim IsFound As Boolean = False

            For i As Integer = Me.Count - 1 To 0 Step -1
                IsFound = False
                For Each d As ConsignmentDiscardPersistenceObject In FinalListView
                    If Item(i).ConsignmentID = d.ConsignmentID Then
                        IsFound = True
                        Exit For
                    End If
                Next
                If Not IsFound Then Me.RemoveAt(i)
            Next

            For Each d As ConsignmentDiscardPersistenceObject In FinalListView
                IsFound = False
                For Each c As ConsignmentDiscardPersistenceObject In Me
                    If c.ConsignmentID = d.ConsignmentID Then
                        IsFound = True
                        c.Amount = d.Amount
                        c.TotalValue = d.TotalValue
                        Exit For
                    End If
                Next
                If Not IsFound Then Me.Add(d.Clone)
            Next

        End Sub

        Public Function GetTotalValue() As Double
            Dim result As Double = 0
            For Each entry As ConsignmentDiscardPersistenceObject In Me
                result = CRound(result + entry.TotalValue)
            Next
            Return result
        End Function

        Public Function GetTotalAmount() As Double
            Dim result As Double = 0
            For Each entry As ConsignmentDiscardPersistenceObject In Me
                result = CRound(result + entry.Amount, 6)
            Next
            Return result
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function NewConsignmentDiscardPersistenceObjectList( _
            ByVal AvailableConsignments As ConsignmentPersistenceObjectList, _
            ByVal AmountRequired As Double, ByVal GoodsName As String) As ConsignmentDiscardPersistenceObjectList
            Return New ConsignmentDiscardPersistenceObjectList(AvailableConsignments, AmountRequired, GoodsName)
        End Function

        Friend Shared Function GetConsignmentDiscardPersistenceObjectList( _
            ByVal ParentID As Integer) As ConsignmentDiscardPersistenceObjectList
            Return New ConsignmentDiscardPersistenceObjectList(ParentID)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal ParentID As Integer)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Fetch(ParentID)
        End Sub

        Private Sub New(ByVal AvailableConsignments As ConsignmentPersistenceObjectList, _
            ByVal AmountRequired As Double, ByVal GoodsName As String)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Fetch(AvailableConsignments, AmountRequired, GoodsName)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal ParentID As Integer)

            Dim myComm As New SQLCommand("FetchConsignmentDiscardPersistenceObjectList")
            myComm.AddParam("?CD", ParentID)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False

                For Each dr As DataRow In myData.Rows
                    Add(ConsignmentDiscardPersistenceObject.GetConsignmentDiscardPersistenceObject(dr))
                Next

                RaiseListChangedEvents = True

            End Using

        End Sub

        Private Sub Fetch(ByVal AvailableConsignments As ConsignmentPersistenceObjectList, _
            ByVal AmountRequired As Double, ByVal GoodsName As String)

            RaiseListChangedEvents = False

            For Each c As ConsignmentPersistenceObject In AvailableConsignments

                Add(ConsignmentDiscardPersistenceObject. _
                    NewConsignmentDiscardPersistenceObject(c, AmountRequired))

                If Not CRound(AmountRequired, 6) > 0 Then Exit For

            Next

            If CRound(AmountRequired, 6) > 0 Then Throw New Exception( _
                "Klaida. Nepakanka prekių '" & GoodsName & "' likučio sandėlyje.")

            RaiseListChangedEvents = True

        End Sub

        Friend Sub Update(ByVal parentID As Integer)

            RaiseListChangedEvents = False

            For Each item As ConsignmentDiscardPersistenceObject In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As ConsignmentDiscardPersistenceObject In Me
                If item.IsNew Then
                    item.Insert(parentID)
                ElseIf item.IsDirty Then
                    item.Update()
                End If
            Next

            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace