Imports System.ComponentModel
Imports System.Windows.Forms
Imports AccDataAccessLayer.Security.DatabaseTableAccess
Public Class F_DatabaseTableAccessRoleList

    Private Obj As DatabaseTableAccessRoleList


    Private Sub F_DatabaseTableAccessRoleList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Obj = DatabaseTableAccessRoleList.NewRoleDatabaseAccessList

        Rebind(Obj)

        Using busy As New StatusBusy
            Dim DbStructure As AccDataAccessLayer.DatabaseAccess.DatabaseStructure.DatabaseStructure
            Try
                DbStructure = AccDataAccessLayer.DatabaseAccess.DatabaseStructure.DatabaseStructure.GetDatabaseStructure()
            Catch ex As Exception
                ShowError(New Exception("Nepavyko gauti duomenų bazės struktūros šablono: " _
                    & ex.Message, ex))
                DisableAllControls(Me)
                Exit Sub
            End Try
        End Using

    End Sub


    Private Sub LoadGaugeButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LoadGaugeButton.Click

        Dim result As MsgBoxResult = SaveIfDirty()
        If result = MsgBoxResult.Cancel Then Exit Sub

        If result <> MsgBoxResult.Yes Then CancelEdit()

        Using busy As New StatusBusy
            Try
                Obj = DatabaseTableAccessRoleList.GetRoleDatabaseAccessList()
            Catch ex As Exception
                ShowError(ex)
            End Try
        End Using

        Rebind(Obj)

    End Sub

    Private Sub OpenFileButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OpenFileButton.Click

        Dim result As MsgBoxResult = SaveIfDirty()
        If result = MsgBoxResult.Cancel Then Exit Sub

        Dim FilePath As String = ""
        Using ofd As New OpenFileDialog
            ofd.Multiselect = False
            ofd.ShowDialog()
            FilePath = ofd.FileName
        End Using

        If FilePath Is Nothing OrElse String.IsNullOrEmpty(FilePath.Trim) OrElse _
            Not IO.File.Exists(FilePath) Then
            If result = MsgBoxResult.Yes Then Rebind(Obj)
            Exit Sub
        End If

        If result <> MsgBoxResult.Yes Then CancelEdit()

        Using busy As New StatusBusy
            Try
                Obj = DatabaseTableAccessRoleList.GetRoleDatabaseAccessList(FilePath)
            Catch ex As Exception
                ShowError(ex)
            End Try
        End Using

        Rebind(Obj)

    End Sub

    Private Sub SaveFileButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles SaveFileButton.Click

        If Obj.FilePath Is Nothing OrElse String.IsNullOrEmpty(Obj.FilePath) Then
            SaveFileAsButton_Click(sender, e)
            Exit Sub
        End If

        If Not YesOrNo("Išsaugoti failą?") Then Exit Sub

        ApplyEdit()

        Using busy As New StatusBusy
            Try
                Obj = Obj.Clone.Save
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Using

        Rebind(Obj)

    End Sub

    Private Sub SaveFileAsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles SaveFileAsButton.Click

        Dim FilePath As String = ""
        Using sfd As New SaveFileDialog
            sfd.ShowDialog()
            FilePath = sfd.FileName
        End Using

        If FilePath Is Nothing OrElse String.IsNullOrEmpty(FilePath.Trim) Then Exit Sub

        If Not YesOrNo("Išsaugoti failą?") Then Exit Sub

        ApplyEdit()

        Using busy As New StatusBusy
            Try
                Obj = Obj.Clone.SaveAs(FilePath)
            Catch ex As Exception
                ShowError(ex)
            End Try
        End Using

        Rebind(Obj)

    End Sub

    Private Sub PasteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles PasteButton.Click
        If Obj Is Nothing Then Exit Sub

        Dim Answ As String = Ask("Overwrite content?", New ButtonStructure("Overwrite", "Overwrite with paste results"), _
            New ButtonStructure("Append", "Append with paste results"), New ButtonStructure("Cancel", "Do nothing"))

        If Answ <> "Overwrite" AndAlso Answ <> "Append" Then Exit Sub

        Try
            Obj.Paste(Clipboard.GetText, (Answ = "Overwrite"))
        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub


    Private Function SaveIfDirty() As MsgBoxResult

        If (Not Obj.IsNew AndAlso Obj.IsDirty) OrElse (Obj.IsNew AndAlso Obj.Count > 0) Then

            Dim result As String = Ask("Išsaugoti esamus duomenis prieš įkraunant naujus?", _
                New ButtonStructure("Taip", "Išsaugoti esamus ir įkrauti naujus duomenis."), _
                New ButtonStructure("Ne", "Neišsaugoti esamų ir įkrauti naujus duomenis."), _
                New ButtonStructure("Atšaukti", "Neįkrauti naujų duomenų."))

            If result <> "Taip" AndAlso result <> "Ne" Then Return MsgBoxResult.Cancel

            If result = "Taip" Then

                Dim FilePath As String = ""
                If Obj.FilePath Is Nothing OrElse String.IsNullOrEmpty(Obj.FilePath) Then
                    Using sfd As New SaveFileDialog
                        sfd.ShowDialog()
                        FilePath = sfd.FileName
                    End Using

                    If FilePath Is Nothing OrElse String.IsNullOrEmpty(FilePath.Trim) OrElse _
                        Not IO.File.Exists(FilePath) Then Return MsgBoxResult.Cancel
                End If

                ApplyEdit()

                Using busy As New StatusBusy
                    Try
                        If String.IsNullOrEmpty(FilePath.Trim) Then
                            Obj = Obj.Clone.Save
                        Else
                            Obj = Obj.Clone.SaveAs(FilePath)
                        End If
                    Catch ex As Exception
                        ShowError(ex)
                        Rebind(Obj)
                        Return MsgBoxResult.Cancel
                    End Try
                End Using

                Return MsgBoxResult.Yes

            End If

        End If

        Return MsgBoxResult.No

    End Function

    Private Sub ApplyEdit()

        DatabaseTableAccessRoleListBindingSource.RaiseListChangedEvents = False

        UnbindBindingSource(DatabaseTableAccessRoleListBindingSource, True)

        DatabaseTableAccessRoleListBindingSource.EndEdit()

        Obj.ApplyEdit()

    End Sub

    Private Sub CancelEdit()

        DatabaseTableAccessRoleListBindingSource.RaiseListChangedEvents = False

        UnbindBindingSource(DatabaseTableAccessRoleListBindingSource, False)

        Obj.CancelEdit()

    End Sub

    Private Sub Rebind(ByVal DbsObj As DatabaseTableAccessRoleList)

        DbsObj.BeginEdit()

        'DatabaseTableAccessRoleListBindingSource.DataSource = Nothing
        'TableAccessListBindingSource.DataSource = DatabaseTableAccessRoleListBindingSource

        DatabaseTableAccessRoleListBindingSource.DataSource = DbsObj

        DatabaseTableAccessRoleListBindingSource.RaiseListChangedEvents = True

        DatabaseTableAccessRoleListBindingSource.ResetBindings(False)

    End Sub

    Private Sub UnbindBindingSource(ByVal source As BindingSource, ByVal apply As Boolean)

        Dim current As System.ComponentModel.IEditableObject = CType(source.Current, _
            System.ComponentModel.IEditableObject)

        If Not TypeOf source.DataSource Is BindingSource Then source.DataSource = Nothing

        If Not current Is Nothing Then
            If apply Then
                current.EndEdit()
            Else
                current.CancelEdit()
            End If
        End If

    End Sub

End Class