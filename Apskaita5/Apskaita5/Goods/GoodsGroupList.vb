Namespace Goods

    <Serializable()> _
    Public Class GoodsGroupList
        Inherits BusinessListBase(Of GoodsGroupList, GoodsGroup)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Me.IsDirty
            End Get
        End Property


        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As GoodsGroup = GoodsGroup.NewGoodsGroup
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


        Public Overrides Function Save() As GoodsGroupList

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai operacijai.")

            If Not Me.Count > 0 AndAlso Not Me.DeletedList.Count > 0 Then _
                Throw New Exception("Klaida. Neįkrauta nė viena eilutė.")

            If Not Me.IsValid Then Throw New Exception("Įvestuose duomenyse yra klaidų: " _
                & GetAllBrokenRules())

            Dim result As GoodsGroupList = MyBase.Save()
            HelperLists.GoodsGroupInfoList.InvalidateCache()
            Return result

        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsGroupList1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsGroupList2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsGroupList3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsGroupList3")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of GoodsGroup) = Nothing

        Public Shared Function GetGoodsGroupList() As GoodsGroupList
            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")
            Dim result As GoodsGroupList = DataPortal.Fetch(Of GoodsGroupList)(New Criteria())
            Return result
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of GoodsGroup)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of GoodsGroup)(Me)
            Return _SortedList
        End Function

        Private Sub New()
            ' require use of factory methods
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public Sub New()
            End Sub
        End Class


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            Dim myComm As New SQLCommand("FetchGoodsGroupList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False

                For Each dr As DataRow In myData.Rows
                    Add(GoodsGroup.GetGoodsGroup(dr))
                Next

                RaiseListChangedEvents = True

            End Using

        End Sub

        Protected Overrides Sub DataPortal_Update()

            CheckIfCanDelete()

            Using transaction As New SqlTransaction

                Try

                    RaiseListChangedEvents = False

                    For Each item As GoodsGroup In DeletedList
                        If Not item.IsNew Then item.DeleteSelf()
                    Next
                    DeletedList.Clear()

                    For Each item As GoodsGroup In Me
                        If item.IsNew Then
                            item.Insert()
                        ElseIf item.IsDirty Then
                            item.Update()
                        End If
                    Next

                    RaiseListChangedEvents = True

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

        End Sub


        Private Sub CheckIfCanDelete()

            Dim myComm As New SQLCommand("CheckIfCanDeleteGoodsInfoList")

            Dim list As New List(Of Integer)

            Using myData As DataTable = myComm.Fetch

                For Each dr As DataRow In myData.Rows
                    If CIntSafe(dr.Item(0), 0) > 0 Then list.Add(CIntSafe(dr.Item(0), 0))
                Next

            End Using

            For Each item As GoodsGroup In DeletedList
                If Not item.IsNew AndAlso list.Contains(item.ID) Then Throw New Exception( _
                    "Klaida. Prekių grupės '" & item.Name & "' ištrinti negalima, yra jai priskirtų prekių.")
            Next

        End Sub

#End Region

    End Class

End Namespace