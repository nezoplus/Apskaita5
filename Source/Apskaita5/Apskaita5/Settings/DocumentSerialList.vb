﻿Namespace Settings

    ''' <summary>
    ''' Represents a list of serials that are used in the company.
    ''' </summary>
    ''' <remarks>Exists only one instance per company.
    ''' Values are stored in the database table serijos.</remarks>
    <Serializable()> _
    Public NotInheritable Class DocumentSerialList
        Inherits BusinessListBase(Of DocumentSerialList, DocumentSerial)
        Implements IIsDirtyEnough

#Region " Business Methods "

        ''' <summary>
        ''' Returnes TRUE if the object was changed by the user.
        ''' </summary>
        ''' <remarks>In this case it's the same as <see cref="DocumentSerialList.IsDirty">IsDirty</see>
        ''' because the list is for all the company and is never new.</remarks>
        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                Return IsDirty
            End Get
        End Property


        Protected Overrides Function AddNewCore() As Object
            Dim newItem As DocumentSerial = DocumentSerial.NewDocumentSerial
            Me.Add(newItem)
            Return newItem
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

        Public Function HasWarnings() As Boolean
            For Each i As DocumentSerial In Me
                If i.BrokenRulesCollection.WarningCount > 0 Then Return True
            Next
            Return False
        End Function


        Public Overrides Function Save() As DocumentSerialList

            If Not Me.Count > 0 AndAlso Not Me.DeletedList.Count > 0 Then _
                Throw New Exception(My.Resources.Settings_DocumentSerialList_ListEmpty)

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

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

        ''' <summary>
        ''' Gets a document serial list for the company from a database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function GetDocumentSerialList() As DocumentSerialList
            Return DataPortal.Fetch(Of DocumentSerialList)(New Criteria())
        End Function

        ''' <summary>
        ''' Gets a sortable view of the list.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in a datagridview.</remarks>
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
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchDocumentSerials")
            myComm.AddParam("?KI", Utilities.ConvertDatabaseCharID(DocumentSerialType.TillSpendingsOrder))
            myComm.AddParam("?KP", Utilities.ConvertDatabaseCharID(DocumentSerialType.TillIncomeOrder))
            myComm.AddParam("?SF", Utilities.ConvertDatabaseCharID(DocumentSerialType.Invoice))
            myComm.AddParam("?DS", Utilities.ConvertDatabaseCharID(DocumentSerialType.LabourContract))

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
                My.Resources.Common_SecurityUpdateDenied)

            If Not Me.Count > 0 AndAlso Not Me.DeletedList.Count > 0 Then _
                Throw New Exception(My.Resources.Settings_DocumentSerialList_ListEmpty)

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            For Each item As DocumentSerial In Me
                If Not item.IsNew AndAlso item.IsDirty Then item.CheckIfCanUpdateOrDelete()
            Next
            For Each item As DocumentSerial In DeletedList
                If Not item.IsNew Then item.CheckIfCanUpdateOrDelete()
            Next

            Using transaction As New SqlTransaction

                Try

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

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

        End Sub

#End Region

    End Class

End Namespace