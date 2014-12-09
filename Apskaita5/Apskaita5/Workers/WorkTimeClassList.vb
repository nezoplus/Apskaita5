Namespace Workers

    <Serializable()> _
    Public Class WorkTimeClassList
        Inherits BusinessListBase(Of WorkTimeClassList, WorkTimeClass)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                Return IsDirty
            End Get
        End Property


        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As WorkTimeClass = WorkTimeClass.NewWorkTimeClass
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


        Public Sub AddWithTypicalCodes()

            If Me.Count > 0 Then Throw New Exception( _
                "Klaida. Tipinę darbo laiko nomenklatūrą galima įkrauti tik tuščiam sąrašui.")

            Dim lines As String() = IO.File.ReadAllLines(IO.Path.Combine( _
                AppPath, WORKTIMECLASSES_FILE), New System.Text.UnicodeEncoding)

            RaiseListChangedEvents = False

            For Each s As String In lines
                If Not s Is Nothing AndAlso Not String.IsNullOrEmpty(s.Trim) _
                    AndAlso s.Split(New Char() {}, StringSplitOptions.RemoveEmptyEntries).Length > 6 Then _
                    Add(WorkTimeClass.NewWorkTimeClass(s.Split(New Char() {Chr(9)}, _
                        StringSplitOptions.RemoveEmptyEntries)))
            Next

            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub


        Public Overrides Function Save() As WorkTimeClassList

            If Not Me.Count > 0 AndAlso Not Me.DeletedList.Count > 0 Then _
                Throw New Exception("Klaida. Neįkrauta nė viena eilutė.")

            If Not Me.IsValid Then Throw New Exception("Įvestuose duomenyse yra klaidų: " _
                & GetAllBrokenRules())

            Dim result As WorkTimeClassList = MyBase.Save()
            WorkTimeClassInfoList.InvalidateCache()
            Return result

        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.WorkTimeClassList1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return False
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.WorkTimeClassList3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return False
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of WorkTimeClass) = Nothing

        Public Shared Function GetWorkTimeClassList() As WorkTimeClassList
            Return DataPortal.Fetch(Of WorkTimeClassList)(New Criteria())
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of WorkTimeClass)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of WorkTimeClass)(Me)
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

            Dim myComm As New SQLCommand("FetchWorkTimeClassList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False

                For Each dr As DataRow In myData.Rows
                    Add(WorkTimeClass.GetWorkTimeClass(dr))
                Next

                RaiseListChangedEvents = True

            End Using

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai operacijai.")

            For Each item As WorkTimeClass In DeletedList
                If Not item.IsNew Then item.UpdateIsInUse(True)
            Next
            For Each item As WorkTimeClass In Me
                If Not item.IsNew AndAlso item.IsDirty Then
                    item.UpdateIsInUse(False)
                End If
            Next

            DatabaseAccess.TransactionBegin()

            RaiseListChangedEvents = False

            For Each item As WorkTimeClass In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As WorkTimeClass In Me
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