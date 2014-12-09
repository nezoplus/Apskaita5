Namespace Settings

    <Serializable()> _
    Public Class DocumentSerialList
        Inherits BusinessListBase(Of DocumentSerialList, DocumentSerial)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                Return IsDirty
            End Get
        End Property

        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As DocumentSerial = DocumentSerial.NewDocumentSerial
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

        Public Overrides Function Save() As DocumentSerialList

            If Not Me.Count > 0 AndAlso Not Me.DeletedList.Count > 0 Then Throw New Exception( _
                "Klaida. Neįvesta nė viena serija.")

            If Not Me.IsValid Then Throw New Exception("Įvestuose duomenyse yra klaidų: " _
                & GetAllBrokenRules())


            Dim result As DocumentSerialList = MyBase.Save()
            HelperLists.DocumentSerialInfoList.InvalidateCache()
            Return result

        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.DocumentSerialList1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return False
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.DocumentSerialList3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return False
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of DocumentSerial) = Nothing

        Public Shared Function GetDocumentSerialList() As DocumentSerialList
            Return DataPortal.Fetch(Of DocumentSerialList)(New Criteria())
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of DocumentSerial)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of DocumentSerial)(Me)
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

            Dim myComm As New SQLCommand("FetchDocumentSerials")
            myComm.AddParam("?KI", ConvertEnumDatabaseStringCode(DocumentSerialType.TillSpendingsOrder))
            myComm.AddParam("?KP", ConvertEnumDatabaseStringCode(DocumentSerialType.TillIncomeOrder))
            myComm.AddParam("?SF", ConvertEnumDatabaseStringCode(DocumentSerialType.Invoice))
            myComm.AddParam("?DS", ConvertEnumDatabaseStringCode(DocumentSerialType.LabourContract))

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False

                For Each dr As DataRow In myData.Rows
                    Add(DocumentSerial.GetDocumentSerial(dr))
                Next

                RaiseListChangedEvents = True

            End Using

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai operacijai.")

            For Each item As DocumentSerial In Me
                If Not item.IsNew AndAlso item.Serial <> item.SerialOld _
                    OrElse item.DocumentType <> item.DocumentTypeOld Then item.CheckIfSerialWasUsed(True)
            Next
            For Each item As DocumentSerial In DeletedList
                If Not item.IsNew Then item.CheckIfSerialWasUsed(True)
            Next

            DatabaseAccess.TransactionBegin()

            RaiseListChangedEvents = False

            For Each item As DocumentSerial In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As DocumentSerial In Me
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