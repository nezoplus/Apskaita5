Namespace Assets

    <Serializable()> _
Public Class LongTermAssetCustomGroupList
        Inherits BusinessListBase(Of LongTermAssetCustomGroupList, LongTermAssetCustomGroup)

#Region " Business Methods "

        Public Overrides Function Save() As LongTermAssetCustomGroupList

            If Not IsValid Then Throw New Exception("Turto grupių duomenyse yra klaidų: " _
                & vbCrLf & GetAllBrokenRules())

            DublicateNamesValidation()

            Dim result As LongTermAssetCustomGroupList = MyBase.Save
            LongTermAssetCustomGroupInfoList.InvalidateCache()
            Return result

        End Function

        Public Function GetAllBrokenRules() As String

            If IsValid Then Return ""

            Dim result As String = ""

            For Each gitem As LongTermAssetCustomGroup In Me
                If Not gitem.IsValid Then
                    If String.IsNullOrEmpty(result.Trim) Then
                        result = gitem.BrokenRulesCollection.ToString
                    Else
                        result = result & vbCrLf & gitem.BrokenRulesCollection.ToString
                    End If
                End If
            Next

            Return result
        End Function

        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As LongTermAssetCustomGroup = LongTermAssetCustomGroup.NewLongTermAssetCustomGroup
            Me.Add(NewItem)
            Return NewItem
        End Function

        Private Sub DublicateNamesValidation()
            Dim i, j As Integer
            For i = 1 To Count - 1
                For j = i + 1 To Count
                    If Not String.IsNullOrEmpty(Item(i - 1).Name.Trim) AndAlso _
                        Not Not String.IsNullOrEmpty(Item(j - 1).Name.Trim) AndAlso _
                        Item(i - 1).Name.Trim.ToLower = Item(j - 1).Name.Trim.ToLower Then _
                        Throw New Exception("Klaida. Dvi grupės turi vienodą pavadinimą '" _
                        & Item(i - 1).Name.Trim & "'.")
                Next
            Next
        End Sub

#End Region

#Region " Authorization Rules "

        Public Shared Function CanAddObject() As Boolean
            Return False
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Assets.LongTermAssetCustomGroupList1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Assets.LongTermAssetCustomGroupList3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return False
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetLongTermAssetCustomGroupList() As LongTermAssetCustomGroupList
            Return DataPortal.Fetch(Of LongTermAssetCustomGroupList)(New Criteria())
        End Function

        Private Sub New()
            ' require use of factory methods
            AllowNew = True
            AllowRemove = True
            AllowEdit = True
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public Sub New()
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai informacijai gauti.")

            Dim myComm As New SQLCommand("FetchLongTermAssetCustomGroupList")

            Using myData As DataTable = myComm.Fetch
                RaiseListChangedEvents = False
                For Each dr As DataRow In myData.Rows
                    Add(LongTermAssetCustomGroup.GetLongTermAssetCustomGroup(dr))
                Next
                RaiseListChangedEvents = True
            End Using

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka turto grupėms redaguoti.")

            For Each item As LongTermAssetCustomGroup In DeletedList
                item.CheckIfItemCanBeDeleted()
            Next

            DatabaseAccess.TransactionBegin()

            RaiseListChangedEvents = False
            For Each item As LongTermAssetCustomGroup In DeletedList
                item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As LongTermAssetCustomGroup In Me
                If item.IsNew Then
                    item.Insert(Me)
                Else
                    item.Update(Me)
                End If
            Next
            RaiseListChangedEvents = True

            DatabaseAccess.TransactionCommit()

        End Sub

#End Region

    End Class

End Namespace