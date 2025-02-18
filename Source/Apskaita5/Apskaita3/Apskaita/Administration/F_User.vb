﻿Imports System.Windows.Forms
Imports System.Drawing
Imports AccDataAccessLayer.Security.UserAdministration
Imports AccDataAccessLayer.Security
Public Class F_User

    Private ObjList As UserInfoList
    Private Obj As User


    Private Sub F_User_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_User_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If SaveIfDirty() = MsgBoxResult.Cancel Then e.Cancel = True

    End Sub

    Private Sub F_User_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not UserInfoList.CanGetObject OrElse Not User.CanAddObject Then
            MsgBox("Klaida. Jusu teisiu nepakanka vartotoju administravimui.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        Dim dbList As DatabaseInfoList = DatabaseInfoList.GetDatabaseList
        If dbList.Count < 1 Then
            MsgBox("Klaida. Nėra duomenų bazių (-ės), kurių vartotojus būtų galima administruoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        Try
            Using busy As New StatusBusy
                ObjList = UserInfoList.GetList()
            End Using
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti vartotoju sarašo.", ex), Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try
        Try
            Using busy As New StatusBusy
                Obj = User.NewUser()
            End Using
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti naujo vartotojo šablono.", ex), Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        Using busy As New StatusBusy
            UserInfoListBindingSource.DataSource = ObjList
            Rebind(Obj)
        End Using

        HostTextBox.Enabled = (GetCurrentIdentity.ConnectionType = AccDataAccessLayer.ConnectionType.Local)

    End Sub


    Private Sub OkButtonI_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OkButtonI.Click

        If Not SaveObj(True, False) Then Exit Sub

        Try
            Using busy As New StatusBusy
                Obj = User.NewUser()
            End Using
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti naujo vartotojo šablono.", ex), Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        Rebind(Obj)
        EditedBaner.Visible = Not Obj.IsNew

    End Sub

    Private Sub ApplyButtonI_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButtonI.Click

        If Not SaveObj(True, True) Then Exit Sub

        EditedBaner.Visible = True

    End Sub

    Private Sub CancelButtonI_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CancelButtonI.Click
        CancelObj()
    End Sub


    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        UserInfoListBindingSource.RaiseListChangedEvents = False

        Try
            Using busy As New StatusBusy
                ObjList = UserInfoList.GetList
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "")
            UserInfoListBindingSource.RaiseListChangedEvents = True
            Exit Sub
        End Try

        UserInfoListBindingSource.DataSource = Nothing
        UserInfoListBindingSource.DataSource = ObjList

        UserInfoListBindingSource.RaiseListChangedEvents = True
        UserInfoListBindingSource.ResetBindings(False)

    End Sub

    Private Sub UserInfoListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles UserInfoListDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        Dim selectedUserName As String
        Dim selectedUserID As Integer
        Try
            selectedUserName = CType(UserInfoListDataGridView.Rows(e.RowIndex). _
                DataBoundItem, UserInfo).Name
            selectedUserID = CType(UserInfoListDataGridView.Rows(e.RowIndex). _
                DataBoundItem, UserInfo).ID
        Catch ex As Exception
            ShowError(ex, Nothing)
            Exit Sub
        End Try
        If StringIsNullOrEmpty(selectedUserName) OrElse Not selectedUserID > 0 Then
            MsgBox("Klaida. Nepavyko nustatyti pasirinkto vartotojo.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        If Not Obj Is Nothing AndAlso Obj.ID = selectedUserID Then
            MsgBox("Klaida. Šis vartotojas dabar yra redaguojamas.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Dim ats As String = Ask("", New ButtonStructure("Taisyti", "Keisti vartotojo duomenis ar teises."), _
            New ButtonStructure("Ištrinti", "Pašalinti vartotoja iš duomenu bazes."), _
            New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        If ats <> "Taisyti" AndAlso ats <> "Ištrinti" Then Exit Sub

        If ats = "Ištrinti" Then

            If Not YesOrNo("Ar tikrai norite pašalinti vartotoją?") Then Exit Sub


            Try

                Using busy As New StatusBusy
                    User.DeleteUser(selectedUserName)
                End Using

                UserInfoListBindingSource.RaiseListChangedEvents = False

                ObjList.RemoveItemByID(selectedUserID)

                UserInfoListBindingSource.DataSource = Nothing
                UserInfoListBindingSource.DataSource = ObjList

                UserInfoListBindingSource.RaiseListChangedEvents = True
                UserInfoListBindingSource.ResetBindings(False)

            Catch ex As Exception
                ShowError(ex, Nothing)
                Exit Sub
            End Try

            MsgBox(String.Format("Vartotojas '{0}' buvo sėkmingai pašalintas.", selectedUserName), _
                MsgBoxStyle.Information, "Info")

        Else

            If SaveIfDirty() = MsgBoxResult.Cancel Then Exit Sub

            CancelEdit()

            Try
                Using busy As New StatusBusy
                    Obj = User.GetUser(selectedUserName)
                End Using
            Catch ex As Exception
                ShowError(New Exception("Klaida. Nepavyko gauti vartotojo duomenų." _
                    & vbCrLf & ex.Message, ex), Nothing)
            End Try

            Rebind(Obj)

            EditedBaner.Visible = Not Obj Is Nothing AndAlso Not Obj.IsNew

        End If

    End Sub

    Private Sub OpenImageButton_Click(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles OpenImageButton.Click

        Using opf As New OpenFileDialog

            opf.Multiselect = False

            If opf.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then Exit Sub
            If StringIsNullOrEmpty(opf.FileName) OrElse Not IO.File.Exists(opf.FileName) Then Exit Sub

            Try
                Obj.Signature = DirectCast(Bitmap.FromFile(opf.FileName).Clone, Image)
            Catch ex As Exception
                MsgBox("Klaida. Neatpažintas paveikslėlio formatas: " & ex.Message, MsgBoxStyle.Exclamation)
            End Try

        End Using

    End Sub

    Private Sub ClearImageButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ClearImageButton.Click
        Obj.Signature = Nothing
    End Sub

    Private Sub IsAdminCheckBox_CheckedChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IsAdminCheckBox.CheckedChanged
        RolesDataGridView.Enabled = Not IsAdminCheckBox.Checked
        RoleListDataGridView.Enabled = Not IsAdminCheckBox.Checked
    End Sub

    Private Sub RolesBindingSource_CurrentChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles RolesBindingSource.CurrentChanged
        RoleListBindingSource.EndEdit()
    End Sub


    Private Function SaveIfDirty() As MsgBoxResult

        If Obj Is Nothing OrElse Not Obj.IsDirtyEnough Then Return MsgBoxResult.No

        Dim questionString As String
        If Obj.IsNew Then
            questionString = "Sukurti naują vartotoją (išsaugoti įvestus duomenis) prieš įkraunant naujus duomenis?"
        Else
            questionString = "Išsaugoti įvestus vartotojo duomenis prieš įkraunant naujus duomenis?"
        End If
        Dim result As MsgBoxResult = MsgBox(questionString, MsgBoxStyle.YesNoCancel, "")

        If result = MsgBoxResult.Yes Then
            If Not SaveObj(False, True) Then Return MsgBoxResult.Cancel
            Return MsgBoxResult.Yes
        Else
            Return MsgBoxResult.No
        End If

    End Function

    Private Function SaveObj(ByVal askConfirmation As Boolean, ByVal rebindObj As Boolean) As Boolean

        If Obj Is Nothing Then Return False

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidu:" & vbCrLf & Obj.BrokenRulesCollection.ToString, _
                MsgBoxStyle.Exclamation, "")
            Return False
        End If

        If Not Obj.IsNew AndAlso Not Obj.IsDirty Then Return True

        If askConfirmation Then
            If Obj.IsNew Then
                If Not YesOrNo("Ar tikrai norite sukurti nauja vartotoja?") Then Exit Function
            Else
                If Not YesOrNo("Ar tikrai norite pakeisti vartotojo duomenis?") Then Exit Function
            End If
        End If

        Dim wasNewUser As Boolean = Obj.IsNew

        ApplyEdit()


        Try
            Using busy As New StatusBusy
                Obj = Obj.Clone.Save
            End Using
        Catch ex As Exception
            ShowError(ex, Obj)
            Rebind(Obj)
            Return False
        End Try

        If rebindObj Then Rebind(Obj)

        If wasNewUser Then
            MsgBox("Vartotojas sekmingai sukurtas ir jo teises nustatytos.", _
                MsgBoxStyle.Information, "Info")
        Else
            MsgBox("Vartotojo ir jo teisiu duomenys sekmingai nustatyti.", _
                MsgBoxStyle.Information, "Info")
        End If

        Return True

    End Function

    Private Sub CancelObj()

        If Obj Is Nothing Then Exit Sub

        CancelEdit()
        Rebind(Obj)

    End Sub

    Private Sub ApplyEdit()

        RoleListBindingSource.RaiseListChangedEvents = False
        RolesBindingSource.RaiseListChangedEvents = False
        UserBindingSource.RaiseListChangedEvents = False

        UnbindBindingSource(RoleListBindingSource, True)
        UnbindBindingSource(RolesBindingSource, True)
        UnbindBindingSource(UserBindingSource, True)

        RoleListBindingSource.EndEdit()
        RolesBindingSource.EndEdit()
        UserBindingSource.EndEdit()

        Obj.ApplyEdit()

    End Sub

    Private Sub CancelEdit()

        RoleListBindingSource.EndEdit()

        RoleListBindingSource.RaiseListChangedEvents = False
        RolesBindingSource.RaiseListChangedEvents = False
        UserBindingSource.RaiseListChangedEvents = False

        UnbindBindingSource(RoleListBindingSource, False)
        UnbindBindingSource(RolesBindingSource, False)
        UnbindBindingSource(UserBindingSource, False)

        Obj.CancelEdit()

    End Sub

    Private Sub Rebind(ByVal dataSource As User)

        dataSource.BeginEdit()

        UserBindingSource.DataSource = dataSource

        RoleListBindingSource.RaiseListChangedEvents = True
        RolesBindingSource.RaiseListChangedEvents = True
        UserBindingSource.RaiseListChangedEvents = True

        RoleListBindingSource.ResetBindings(False)
        RolesBindingSource.ResetBindings(False)
        UserBindingSource.ResetBindings(False)

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