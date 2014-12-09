Public Class F_PersonGroups

    Private Obj As General.PersonGroupList
    Private ObjIsRebinding As Boolean = True

    Private Sub F_PersonGroupsClosing(ByVal sender As Object, _
            ByVal e As FormClosingEventArgs) Handles Me.FormClosing

        If Not Obj Is Nothing AndAlso Obj.IsDirtyEnough Then
            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))
            If answ <> "Taip" AndAlso answ <> "Ne" Then
                e.Cancel = True
                Exit Sub
            End If
            If answ = "Taip" Then
                If Not SaveObj() Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If

        GetFormLayout(Me)

    End Sub

    Private Sub F_Persons_Activated(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_PersonGroups_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Obj = LoadObject(Of General.PersonGroupList)(Nothing, "GetPersonGroupList", True)
        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Exit Sub
        End Try

        Obj.BeginEdit()

        PersonGroupListBindingSource.DataSource = Obj

        IOkButton.Enabled = General.PersonGroupList.CanEditObject
        IApplyButton.Enabled = General.PersonGroupList.CanEditObject

        SetFormLayout(Me)

        ObjIsRebinding = False

    End Sub


    Private Sub OkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IOkButton.Click
        If Not SaveObj() Then Exit Sub
        Me.Hide()
        Me.Close()
    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IApplyButton.Click
        SaveObj()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ICancelButton.Click
        CancelObj()
    End Sub


    Private Sub PersonGroupListDataGridView_UserDeletingRow(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) _
        Handles PersonGroupListDataGridView.UserDeletingRow

        Dim SelectedItem As General.PersonGroup = Nothing
        Try
            SelectedItem = DirectCast(e.Row.DataBoundItem, General.PersonGroup)
        Catch ex As Exception
        End Try
        If SelectedItem Is Nothing Then Exit Sub

        If  SelectedItem.IsInUse Then
            MsgBox("Klaida. Šiai kontrahentų grupei yra priskirta asmenų, jos pašalinti neleidžiama.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            e.Cancel = True
        End If

    End Sub

    Private Sub DataGridView_RowLeave(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles PersonGroupListDataGridView.RowLeave

        Dim CurrentGrid As DataGridView
        Try
            CurrentGrid = DirectCast(sender, DataGridView)
        Catch ex As Exception
        End Try
        If CurrentGrid Is Nothing Then Exit Sub

        If CurrentGrid.Rows(e.RowIndex).IsNewRow AndAlso _
            e.RowIndex = CurrentGrid.Rows.Count - 1 Then CurrentGrid.CancelEdit()

    End Sub

    Private Sub DataGridView_DataError(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) _
        Handles PersonGroupListDataGridView.DataError

        e.ThrowException = False
        e.Cancel = True

    End Sub


    Private Function SaveObj() As Boolean

        If Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.GetAllBrokenRules, _
                MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        If Not String.IsNullOrEmpty(Obj.GetAllWarnings.Trim) Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf _
                & Obj.GetAllWarnings.Trim & vbCrLf
        Else
            Question = ""
        End If
        Question = Question & "Ar tikrai norite pakeisti duomenis?"
        Answer = "Duomenys sėkmingai pakeisti."

        If Not YesOrNo(Question) Then Return False

        Using bm As New BindingsManager(PersonGroupListBindingSource, Nothing, Nothing, True, False)

            Obj.ApplyEdit()

            Try
                Obj = LoadObject(Of General.PersonGroupList)(Obj, "Save", False)
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try

            Obj.BeginEdit()

            bm.SetNewDataSource(Obj)

        End Using

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        If Not PrepareCache(Me, GetType(HelperLists.PersonGroupInfoList)) Then Exit Function
        For Each frm As Form In MDIParent1.MdiChildren
            If TypeOf frm Is F_Person Then DirectCast(frm, F_Person).RefreshPersonGroupList()
        Next

        Return True

    End Function

    Private Sub CancelObj()
        If Obj Is Nothing Then Exit Sub
        Using bm As New BindingsManager(PersonGroupListBindingSource, Nothing, Nothing, True, True)
            Obj.CancelEdit()
            Obj.BeginEdit()
        End Using
    End Sub

End Class