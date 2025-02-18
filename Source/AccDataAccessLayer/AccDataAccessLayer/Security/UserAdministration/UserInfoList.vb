﻿Imports AccDataAccessLayer.DatabaseAccess
Namespace Security.UserAdministration

    <Serializable()> _
Public Class UserInfoList
        Inherits ReadOnlyListBase(Of UserInfoList, UserInfo)

        ''' <summary>
        ''' Removes UserInfo from the list (presumably after deletion) by the UserInfo ID property.
        ''' </summary>
        ''' <param name="ID">UserInfo ID property.</param>
        Public Sub RemoveItemByID(ByVal ID As Integer)
            For i As Integer = 1 To Me.Count
                If Me.Item(i - 1).ID = ID Then
                    RaiseListChangedEvents = False
                    IsReadOnly = False
                    MyBase.RemoveItem(i - 1)
                    RaiseListChangedEvents = True
                    IsReadOnly = True
                    Exit For
                End If
            Next
        End Sub

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Admin")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetList() As UserInfoList
            If Not CanGetObject() Then Throw New Exception( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")
            Return DataPortal.Fetch(Of UserInfoList)(New Criteria())
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public Sub New()

            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            Dim CurrentIdentity As AccIdentity = GetCurrentIdentity()
            If CurrentIdentity.IsLocalUser Then Exit Sub
            Dim cSqlGenerator As SqlServerSpecificMethods.ISqlGenerator = GetSqlGenerator()

            Dim myComm As New SQLCommand("RawSQL", cSqlGenerator.GetFetchUserInfoListStatement(False))

            Using ChangedDb As New ChangedDatabase(CurrentIdentity.SecurityDatabase)

                Using myData As DataTable = myComm.Fetch

                    RaiseListChangedEvents = False
                    IsReadOnly = False

                    For Each dr As DataRow In myData.Rows
                        If dr.Item(1).ToString.Trim.ToLower <> CurrentIdentity.Name.Trim.ToLower Then _
                            Add(UserInfo.GetUserInfo(dr))
                    Next

                    IsReadOnly = True
                    RaiseListChangedEvents = True

                End Using

            End Using

        End Sub

        ''' <summary>
        ''' Gets a list of users that have access to the current database.
        ''' Should only be called on server side.
        ''' </summary>
        ''' <returns>Datatable, where item(0) is ID, item(1) is UserName and item (2) is RealName.</returns>
        Public Shared Function GetUserListForDatabase() As DataTable

            Dim CurrentIdentity As AccIdentity = GetCurrentIdentity()

            If CurrentIdentity.IsLocalUser Then Throw New NotSupportedException( _
                "User administration is not supported in local mode.")

            If CurrentIdentity.Database Is Nothing OrElse _
                String.IsNullOrEmpty(CurrentIdentity.Database.Trim) Then _
                Throw New Exception("Klaida. Neprisijungta prie jokios duomenų bazės.")

            Dim cSqlGenerator As SqlServerSpecificMethods.ISqlGenerator = GetSqlGenerator()

            Dim myComm As New SQLCommand("RawSQL", cSqlGenerator.GetFetchUserInfoListStatement(True))

            Dim result As DataTable = Nothing

            Using ChangedDb As New ChangedDatabase(CurrentIdentity.SecurityDatabase)
                result = myComm.Fetch
            End Using

            Return result

        End Function

#End Region

    End Class

End Namespace