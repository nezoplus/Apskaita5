Imports ApskaitaObjects.Settings
Public Class F_DocumentSerialList

    Private Obj As DocumentSerialList
    Private Loading As Boolean = True

    Private Sub F_DocumentSerialList_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

    End Sub

    Private Sub F_DocumentSerialList_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not Obj Is Nothing AndAlso TypeOf Obj Is IIsDirtyEnough AndAlso _
            DirectCast(Obj, IIsDirtyEnough).IsDirtyEnough Then
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

        GetDataGridViewLayOut(DocumentSerialListDataGridView)
        GetFormLayout(Me)

    End Sub

    Private Sub F_DocumentSerialList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        DataGridViewTextBoxColumn6.DataSource = GetEnumValuesHumanReadableList( _
            GetType(DocumentSerialType), False)

        Try
            Obj = LoadObject(Of DocumentSerialList)(Nothing, "GetDocumentSerialList", False)
        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Exit Sub
        End Try

        Obj.BeginEdit()
        DocumentSerialListBindingSource.DataSource = Obj

        IOkButton.Enabled = Obj.CanEditObject
        IApplyButton.Enabled = Obj.CanEditObject

        SetDataGridViewLayOut(DocumentSerialListDataGridView)
        SetFormLayout(Me)

    End Sub


    Private Sub IOkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IOkButton.Click
        If SaveObj() Then
            Me.Hide()
            Me.Close()
        End If
    End Sub

    Private Sub IApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IApplyButton.Click
        SaveObj()
    End Sub

    Private Sub ICancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ICancelButton.Click
        CancelObj()
    End Sub


    Private Sub DocumentSerialListDataGridView_CellBeginEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) _
        Handles DocumentSerialListDataGridView.CellBeginEdit

        Dim SelectedItem As DocumentSerial
        Try
            SelectedItem = DirectCast(DocumentSerialListDataGridView.Rows(e.RowIndex).DataBoundItem, DocumentSerial)
        Catch ex As Exception
        End Try

        If SelectedItem Is Nothing OrElse SelectedItem.IsNew OrElse Not SelectedItem.WasUsed Then Exit Sub
        e.Cancel = True

    End Sub

    Private Sub DocumentSerialListDataGridView_UserDeletingRow(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) _
        Handles DocumentSerialListDataGridView.UserDeletingRow

        Dim SelectedItem As DocumentSerial
        Try
            SelectedItem = DirectCast(e.Row.DataBoundItem, DocumentSerial)
        Catch ex As Exception
        End Try

        If SelectedItem Is Nothing OrElse SelectedItem.IsNew OrElse Not SelectedItem.WasUsed Then Exit Sub

        MsgBox("Klaida. Ši dokumento serija buvo naudojama registruojant dokumentus. " _
            & "Jos pašalinti neleidžiama.", MsgBoxStyle.Exclamation, "Klaida")

        e.Cancel = True

    End Sub

    Private Sub DocumentSerialListDataGridView_RowLeave(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles DocumentSerialListDataGridView.RowLeave
        If DocumentSerialListDataGridView.Rows(e.RowIndex).IsNewRow AndAlso _
            e.RowIndex = DocumentSerialListDataGridView.Rows.Count - 1 Then _
            DocumentSerialListDataGridView.CancelEdit()
    End Sub



    Private Function SaveObj() As Boolean

        If Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.GetAllBrokenRules, _
                MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        If Not String.IsNullOrEmpty(Obj.GetAllWarnings) Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf _
                & Obj.GetAllWarnings & vbCrLf
        Else
            Question = ""
        End If
        Question = Question & "Ar tikrai norite pakeisti duomenis?"
        Answer = "Duomenys sėkmingai pakeisti."

        If Not YesOrNo(Question) Then Return False

        Using busy As New StatusBusy

            Using bm As New BindingsManager(DocumentSerialListBindingSource, Nothing, Nothing, True, False)

                Obj.ApplyEdit()

                Try
                    Obj = LoadObject(Of DocumentSerialList)(Obj, "Save", False)
                Catch ex As Exception
                    ShowError(ex)
                    Return False
                End Try

                bm.SetNewDataSource(Obj)

            End Using

        End Using

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj()
        Using bm As New BindingsManager(DocumentSerialListBindingSource, Nothing, Nothing, True, True)
            Obj.CancelEdit()
            Obj.BeginEdit()
        End Using
    End Sub

End Class