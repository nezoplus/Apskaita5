Imports AccDataAccessLayer.DatabaseAccess.DatabaseStructure
Imports AccDataAccessLayer
Public Class F_DatabaseStructureEditor

    Private Obj As DatabaseStructure

    Private Sub F_DatabaseStructureError_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
           Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_DatabaseStructureEditor_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Using busy As New StatusBusy

            Dim TypeList As New List(Of DatabaseFieldType)
            For Each r As DatabaseFieldType In [Enum].GetValues(GetType(DatabaseFieldType))
                TypeList.Add(r)
            Next
            TypeDataGridViewComboBoxColumn.DataSource = TypeList

            Obj = DatabaseStructure.NewDatabaseStructure
            Rebind(Obj)

            Try
                Dim DbList As AccDataAccessLayer.Security.DatabaseInfoList = _
                    AccDataAccessLayer.Security.DatabaseInfoList.GetDatabaseList()
                DatabaseListComboBox.DataSource = DbList
                LoadDbSchemaButton.Enabled = (DbList.Count > 0)
                LocalFilePasswordTextBox.ReadOnly = Not GetCurrentIdentity.IsLocalUser
            Catch ex As Exception
                ShowError(ex)
                LoadDbSchemaButton.Enabled = False
            End Try

        End Using

    End Sub

    Private Sub TableListBindingSource_CurrentChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles TableListBindingSource.CurrentChanged
        FieldListBindingSource.EndEdit()
    End Sub

    Private Sub LoadDbSchemaButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LoadDbSchemaButton.Click

        If DatabaseListComboBox.SelectedItem Is Nothing OrElse _
            Not TypeOf DatabaseListComboBox.SelectedItem Is _
            AccDataAccessLayer.Security.DatabaseInfo Then Exit Sub

        Dim result As MsgBoxResult = SaveIfDirty()
        If result = MsgBoxResult.Cancel Then Exit Sub

        If result <> MsgBoxResult.Yes Then CancelEdit()

        Using busy As New StatusBusy
            Try
                Obj = DatabaseStructure.GetDatabaseStructure(CType(DatabaseListComboBox.SelectedItem, _
                    AccDataAccessLayer.Security.DatabaseInfo).DatabaseName, LocalFilePasswordTextBox.Text)
            Catch ex As Exception
                ShowError(ex)
            End Try
        End Using

        Rebind(Obj)

    End Sub

    Private Sub LoadGaugeButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LoadGaugeButton.Click

        Dim result As MsgBoxResult = SaveIfDirty()
        If result = MsgBoxResult.Cancel Then Exit Sub

        If result <> MsgBoxResult.Yes Then CancelEdit()

        Using busy As New StatusBusy
            Try
                Obj = DatabaseStructure.GetDatabaseStructure()
            Catch ex As Exception
                ShowError(ex)
            End Try
        End Using

        Rebind(Obj)

    End Sub

    Private Sub OpenFileButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OpenFileButton.Click

        Dim FilePath As String = ""
        Using ofd As New OpenFileDialog
            ofd.Multiselect = False
            If ofd.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
            FilePath = ofd.FileName
            If FilePath Is Nothing OrElse String.IsNullOrEmpty(FilePath.Trim) OrElse _
                Not IO.File.Exists(FilePath) Then Exit Sub
        End Using

        Dim result As MsgBoxResult = SaveIfDirty()
        If result = MsgBoxResult.Cancel Then Exit Sub

        If result <> MsgBoxResult.Yes Then CancelEdit()

        Using busy As New StatusBusy
            Try
                Obj = DatabaseStructure.GetDatabaseStructureFromFile(FilePath)
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
                ShowError(ex)
            End Try
        End Using

        Rebind(Obj)

    End Sub

    Private Sub SaveFileAsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles SaveFileAsButton.Click

        Dim FilePath As String = ""
        Using sfd As New SaveFileDialog
            If sfd.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
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

    Private Sub GetCreateSqlButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles GetCreateSqlButton.Click

        If Obj Is Nothing Then Exit Sub

        Try
            Clipboard.SetText(Obj.GetCreateSql(SqlServerType.MySQL))
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        MsgBox("CREATE DATABASE SQL Script has been copied to the clipboard.", MsgBoxStyle.Information, "")

    End Sub


    Private Function SaveIfDirty() As MsgBoxResult

        If (Not Obj.IsNew AndAlso Obj.IsDirty) OrElse (Obj.IsNew AndAlso _
            (Obj.StoredProcedureList.Count > 0 OrElse Obj.TableList.Count > 0)) Then

            Dim result As String = Ask("Išsaugoti esamą struktūrą prieš įkeliant naują?", _
                New ButtonStructure("Taip", "Išsaugoti ir įkelti naują."), _
                New ButtonStructure("Ne", "Neišsaugoti ir įkelti naują."), _
                New ButtonStructure("Atšaukti", "Tęsti esamos struktūros redagavimą."))

            If result <> "Taip" AndAlso result <> "Ne" Then Return MsgBoxResult.Cancel

            If result = "Taip" Then

                Dim FilePath As String = ""
                If Obj.FilePath Is Nothing OrElse String.IsNullOrEmpty(Obj.FilePath.Trim) Then
                    Using sfd As New SaveFileDialog
                        If sfd.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return MsgBoxResult.Cancel
                        FilePath = sfd.FileName
                    End Using

                    If FilePath Is Nothing OrElse String.IsNullOrEmpty(FilePath.Trim) Then _
                        Return MsgBoxResult.Cancel
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

        FieldListBindingSource.RaiseListChangedEvents = False
        TableListBindingSource.RaiseListChangedEvents = False
        StoredProcedureListBindingSource.RaiseListChangedEvents = False
        DatabaseStructureBindingSource.RaiseListChangedEvents = False

        UnbindBindingSource(FieldListBindingSource, True)
        UnbindBindingSource(TableListBindingSource, True)
        UnbindBindingSource(StoredProcedureListBindingSource, True)
        UnbindBindingSource(DatabaseStructureBindingSource, True)
        FieldListBindingSource.EndEdit()
        TableListBindingSource.EndEdit()
        StoredProcedureListBindingSource.EndEdit()
        DatabaseStructureBindingSource.EndEdit()

        Obj.ApplyEdit()

    End Sub

    Private Sub CancelEdit()

        FieldListBindingSource.EndEdit()

        FieldListBindingSource.RaiseListChangedEvents = False
        TableListBindingSource.RaiseListChangedEvents = False
        StoredProcedureListBindingSource.RaiseListChangedEvents = False
        DatabaseStructureBindingSource.RaiseListChangedEvents = False

        UnbindBindingSource(FieldListBindingSource, False)
        UnbindBindingSource(TableListBindingSource, False)
        UnbindBindingSource(StoredProcedureListBindingSource, False)
        UnbindBindingSource(DatabaseStructureBindingSource, False)

        Obj.CancelEdit()

    End Sub

    Private Sub Rebind(ByVal DbsObj As DatabaseStructure)

        DbsObj.BeginEdit()

        DatabaseStructureBindingSource.DataSource = DbsObj
        FieldListBindingSource.RaiseListChangedEvents = True
        TableListBindingSource.RaiseListChangedEvents = True
        StoredProcedureListBindingSource.RaiseListChangedEvents = True
        DatabaseStructureBindingSource.RaiseListChangedEvents = True

        FieldListBindingSource.ResetBindings(False)
        TableListBindingSource.ResetBindings(False)
        StoredProcedureListBindingSource.ResetBindings(False)
        DatabaseStructureBindingSource.ResetBindings(False)

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