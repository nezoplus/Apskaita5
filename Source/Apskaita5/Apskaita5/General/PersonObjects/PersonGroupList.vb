﻿Namespace General

    ''' <summary>
    ''' Represents a list of person's groups specific to the company.
    ''' </summary>
    ''' <remarks>Exists a single instance per company.
    ''' Corresponding helper list (value object list) is <see cref="HelperLists.PersonGroupInfoList">HelperLists.PersonGroupInfoList</see>.
    ''' Values are stored in the database table persons_group.</remarks>
    <Serializable()> _
    Public NotInheritable Class PersonGroupList
        Inherits BusinessListBase(Of PersonGroupList, PersonGroup)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid
            End Get
        End Property

        ''' <summary>
        ''' Returns true if the list is dirty, i.e. changed after beeing fetched.
        ''' </summary>
        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                Return IsDirty
            End Get
        End Property


        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As PersonGroup = PersonGroup.NewPersonGroup
            Me.Add(NewItem)
            Return NewItem
        End Function


        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            For Each p As PersonGroup In Me
                If p.BrokenRulesCollection.WarningCount > 0 Then Return True
            Next
            Return False
        End Function

        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = GetAllBrokenRulesForList(Me)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = GetAllWarningsForList(Me)
            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function


        Public Function GetPersonGroupByName(ByVal groupName As String) As PersonGroup
            For Each i As PersonGroup In Me
                If i.Name.Trim.ToLower = groupName.Trim.ToLower Then Return i
            Next
            Return Nothing
        End Function


        Public Overrides Function Save() As PersonGroupList

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim result As PersonGroupList = MyBase.Save()
            PersonGroupInfoList.InvalidateCache()
            Return result

        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanAddObject() As Boolean
            Return False
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.PersonGroup1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.PersonGroup3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return False
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of PersonGroup) = Nothing

        ''' <summary>
        ''' Gets a current persons' group list from database.
        ''' </summary>
        Public Shared Function GetPersonGroupList() As PersonGroupList
            Return DataPortal.Fetch(Of PersonGroupList)(New Criteria())
        End Function

        ''' <summary>
        ''' Gets a sorted view of the PersonGroupList.
        ''' </summary>
        Public Function GetSortedList() As Csla.SortedBindingList(Of PersonGroup)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of PersonGroup)(Me)
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

            Dim myComm As New SQLCommand("GetPersonsGroups")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False

                For Each dr As DataRow In myData.Rows
                    Add(PersonGroup.GetPersonGroup(dr))
                Next

                RaiseListChangedEvents = True

            End Using

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            For Each item As PersonGroup In DeletedList
                If Not item.IsNew Then item.CheckIfCanDelete()
            Next

            Using transaction As New SqlTransaction

                Try

                    RaiseListChangedEvents = False

                    For Each item As PersonGroup In DeletedList
                        If Not item.IsNew Then item.DeleteSelf()
                    Next
                    DeletedList.Clear()

                    For Each item As PersonGroup In Me
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