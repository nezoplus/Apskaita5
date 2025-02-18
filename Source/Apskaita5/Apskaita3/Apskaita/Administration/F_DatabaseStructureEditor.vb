﻿Imports AccControlsWinForms
Imports AccDataAccessLayer.DatabaseAccess.DatabaseStructure
Imports AccDataAccessLayer

Public Class F_DatabaseStructureEditor

    Private Obj As DatabaseStructure

    Private Sub F_DatabaseStructureError_Activated(ByVal sender As Object,
        ByVal e As System.EventArgs) Handles Me.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
           Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_DatabaseStructureEditor_Load(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles MyBase.Load

        Dim typeList As New List(Of DatabaseFieldType)
        For Each r As DatabaseFieldType In [Enum].GetValues(GetType(DatabaseFieldType))
            typeList.Add(r)
        Next
        TypeDataGridViewComboBoxColumn.DataSource = typeList

        Obj = DatabaseStructure.NewDatabaseStructure
        Rebind(Obj)

        Try
            Using busy As New StatusBusy
                Dim dbList As AccDataAccessLayer.Security.DatabaseInfoList =
                    AccDataAccessLayer.Security.DatabaseInfoList.GetDatabaseList()
                DatabaseListComboBox.DataSource = dbList
                LoadDbSchemaButton.Enabled = (dbList.Count > 0)
            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
            LoadDbSchemaButton.Enabled = False
        End Try

        LocalFilePasswordTextBox.ReadOnly = Not GetCurrentIdentity.IsLocalUser

    End Sub

    Private Sub TableListBindingSource_CurrentChanged(ByVal sender As Object,
        ByVal e As System.EventArgs) Handles TableListBindingSource.CurrentChanged
        FieldListBindingSource.EndEdit()
    End Sub

    Private Sub LoadDbSchemaButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles LoadDbSchemaButton.Click

        If DatabaseListComboBox.SelectedItem Is Nothing OrElse
            Not TypeOf DatabaseListComboBox.SelectedItem Is
            AccDataAccessLayer.Security.DatabaseInfo Then Exit Sub

        Dim result As MsgBoxResult = SaveIfDirty()
        If result = MsgBoxResult.Cancel Then Exit Sub

        If result <> MsgBoxResult.Yes Then CancelEdit()


        Try
            Using busy As New StatusBusy
                Obj = DatabaseStructure.GetDatabaseStructure(CType(DatabaseListComboBox.SelectedItem,
                    AccDataAccessLayer.Security.DatabaseInfo).DatabaseName, LocalFilePasswordTextBox.Text)
            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
        End Try

        Rebind(Obj)

    End Sub

    Private Sub LoadGaugeButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles LoadGaugeButton.Click

        Dim result As MsgBoxResult = SaveIfDirty()
        If result = MsgBoxResult.Cancel Then Exit Sub

        If result <> MsgBoxResult.Yes Then CancelEdit()


        Try
            Using busy As New StatusBusy
                Obj = DatabaseStructure.GetDatabaseStructure()
            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
        End Try

        Rebind(Obj)

    End Sub

    Private Sub OpenFileButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles OpenFileButton.Click

        Dim filePath As String = ""
        Using ofd As New OpenFileDialog
            ofd.Multiselect = False
            If ofd.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = ofd.FileName
            If StringIsNullOrEmpty(filePath) OrElse Not IO.File.Exists(filePath) Then Exit Sub
        End Using

        Dim result As MsgBoxResult = SaveIfDirty()
        If result = MsgBoxResult.Cancel Then Exit Sub

        If result <> MsgBoxResult.Yes Then CancelEdit()


        Try
            Using busy As New StatusBusy
                Obj = DatabaseStructure.GetDatabaseStructureFromFile(filePath)
            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
        End Try

        Rebind(Obj)

    End Sub

    Private Sub SaveFileButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles SaveFileButton.Click

        If StringIsNullOrEmpty(Obj.FilePath) Then
            SaveFileAsButton_Click(sender, e)
            Exit Sub
        End If

        If Not YesOrNo("Išsaugoti failą?") Then Exit Sub

        ApplyEdit()

        Try
            Using busy As New StatusBusy
                Obj = Obj.Clone.Save
            End Using
        Catch ex As Exception
            ShowError(ex, Obj)
        End Try

        Rebind(Obj)

    End Sub

    Private Sub SaveFileAsButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles SaveFileAsButton.Click

        Dim filePath As String = ""
        Using sfd As New SaveFileDialog
            If sfd.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = sfd.FileName
        End Using

        If StringIsNullOrEmpty(filePath) Then Exit Sub

        If Not YesOrNo("Išsaugoti failą?") Then Exit Sub

        ApplyEdit()

        Try
            Using busy As New StatusBusy
                Obj = Obj.Clone.SaveAs(filePath)
            End Using
        Catch ex As Exception
            ShowError(ex, Obj)
        End Try

        Rebind(Obj)

    End Sub

    Private Sub GetCreateSqlButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles GetCreateSqlButton.Click

        If Obj Is Nothing Then Exit Sub

        Try
            Clipboard.SetText(Obj.GetCreateSql(SqlServerType.MySQL))
        Catch ex As Exception
            ShowError(ex, Obj)
            Exit Sub
        End Try

        MsgBox("CREATE DATABASE SQL Script has been copied to the clipboard.", MsgBoxStyle.Information, "")

    End Sub

    Private Sub CopyDocumentationToClipboardButton_Click(sender As Object, e As EventArgs) _
        Handles CopyDocumentationToClipboardButton.Click

        If Obj Is Nothing Then Exit Sub

        Dim s As New System.Text.StringBuilder

        For Each tbl As DatabaseTable In Obj.TableList

            s.Append(tbl.Name)
            s.Append(vbTab)
            s.Append(tbl.Description)
            s.Append(vbTab)
            s.Append(tbl.CharsetName)
            s.Append(vbTab)
            s.Append(tbl.EngineName)

            s.AppendLine()
            s.AppendLine()
            s.AppendLine(String.Format("Name{0}Description{0}Type{0}NotNull{0}Unsigned{0}Unique{0}PrimaryKey{0}Autoincrement{0}Indexed{0}IndexName", vbTab))

            For Each col As DatabaseField In tbl.FieldList

                s.Append(col.Name)
                s.Append(vbTab)
                s.Append(col.Description)
                s.Append(vbTab)
                If col.Type = DatabaseFieldType.Char OrElse col.Type = DatabaseFieldType.VarChar Then
                    s.Append(col.Type.ToString)
                    s.Append("(")
                    s.Append(col.Length)
                    s.Append(")")
                ElseIf col.Type = DatabaseFieldType.Enum Then
                    s.Append(col.Type.ToString)
                    s.Append("(")
                    s.Append(col.EnumValues)
                    s.Append(")")
                Else
                    s.Append(col.Type.ToString)
                End If
                s.Append(vbTab)
                s.Append(col.NotNull)
                s.Append(vbTab)
                s.Append(col.Unsigned)
                s.Append(vbTab)
                s.Append(col.Unique)
                s.Append(vbTab)
                s.Append(col.PrimaryKey)
                s.Append(vbTab)
                s.Append(col.Autoincrement)
                s.Append(vbTab)
                s.Append(col.Indexed)
                s.Append(vbTab)
                s.Append(col.IndexName)

                s.AppendLine()

            Next

            s.AppendLine()
            s.AppendLine()
            s.AppendLine()

        Next

        Clipboard.SetText(s.ToString)

    End Sub


    Private Function SaveIfDirty() As MsgBoxResult

        If (Not Obj.IsNew AndAlso Obj.IsDirty) OrElse (Obj.IsNew AndAlso
            (Obj.StoredProcedureList.Count > 0 OrElse Obj.TableList.Count > 0)) Then

            Dim result As String = Ask("Išsaugoti esamą struktūrą prieš įkeliant naują?",
                New ButtonStructure("Taip", "Išsaugoti ir įkelti naują."),
                New ButtonStructure("Ne", "Neišsaugoti ir įkelti naują."),
                New ButtonStructure("Atšaukti", "Tęsti esamos struktūros redagavimą."))

            If result <> "Taip" AndAlso result <> "Ne" Then Return MsgBoxResult.Cancel

            If result = "Taip" Then

                Dim filePath As String = ""
                If StringIsNullOrEmpty(Obj.FilePath) Then
                    Using sfd As New SaveFileDialog
                        If sfd.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return MsgBoxResult.Cancel
                        filePath = sfd.FileName
                    End Using

                    If StringIsNullOrEmpty(filePath) Then Return MsgBoxResult.Cancel
                End If

                ApplyEdit()

                Try
                    Using busy As New StatusBusy
                        If StringIsNullOrEmpty(filePath) Then
                            Obj = Obj.Clone.Save
                        Else
                            Obj = Obj.Clone.SaveAs(filePath)
                        End If
                    End Using
                Catch ex As Exception
                    ShowError(ex, Obj)
                    Rebind(Obj)
                    Return MsgBoxResult.Cancel
                End Try

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

    Private Sub Rebind(ByVal dataSource As DatabaseStructure)

        dataSource.BeginEdit()

        DatabaseStructureBindingSource.DataSource = dataSource
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

        Dim current As System.ComponentModel.IEditableObject = CType(source.Current,
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