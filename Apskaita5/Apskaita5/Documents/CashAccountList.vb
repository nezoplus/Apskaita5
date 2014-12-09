Namespace Documents

    <Serializable()> _
    Public Class CashAccountList
        Inherits BusinessListBase(Of CashAccountList, CashAccount)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                Return IsDirty
            End Get
        End Property


        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As CashAccount = CashAccount.NewCashAccount
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


        Protected Overrides Sub RemoveItem(ByVal index As Integer)
            If Me.Item(index).IsInUse Then Throw New Exception( _
                "Klaida. Šioje sąskaitoje yra operacijų, jos pašalinti negalima.")
            MyBase.RemoveItem(index)
        End Sub


        Public Overrides Function Save() As CashAccountList

            If Not Me.Count > 0 AndAlso Not Me.DeletedList.Count > 0 Then _
                Throw New Exception("Klaida. Neįvesta nė viena eilutė.")

            If Not Me.IsValid Then Throw New Exception("Įvestuose duomenyse yra klaidų: " _
             & GetAllBrokenRules())

            Dim result As CashAccountList = MyBase.Save()
            HelperLists.CashAccountInfoList.InvalidateCache()
            Return MyBase.Save()

        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.CashAccountList1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.CashAccountList3")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.CashAccountList3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.CashAccountList3")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of CashAccount) = Nothing

        Public Shared Function GetCashAccountList() As CashAccountList
            Return DataPortal.Fetch(Of CashAccountList)(New Criteria())
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of CashAccount)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of CashAccount)(Me)
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

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As New SQLCommand("FetchCashAccountList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False

                For Each dr As DataRow In myData.Rows
                    Add(CashAccount.GetCashAccount(dr))
                Next

                RaiseListChangedEvents = True

            End Using

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai operacijai.")

            For Each item As CashAccount In DeletedList
                If Not item.IsNew Then
                    item.CheckIfInUse()
                    If item.IsInUse Then Throw New Exception("Klaida. Sąskaitos '" _
                        & item.Name & "' duomenys yra naudojami piniginėse operacijose, " _
                        & "jos duomenų pašalinti negalima.")
                End If
            Next

            DatabaseAccess.TransactionBegin()

            RaiseListChangedEvents = False

            For Each item As CashAccount In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As CashAccount In Me
                If item.IsNew Then
                    item.Insert(Me)
                ElseIf item.IsDirty Then
                    item.Update(Me)
                End If
            Next

            RaiseListChangedEvents = True

            DatabaseAccess.TransactionCommit()

        End Sub

#End Region

    End Class

End Namespace