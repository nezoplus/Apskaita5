Imports MySql.Data.MySqlClient
Imports ApskaitaWUI.Aprasai

Public Class F_Templates
    Public Obj As HelperLists.TemplateJournalEntryInfoList
    Public loading As Boolean = True

    Private Sub F_Templates_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If loading Then
            loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.TemplateJournalEntryInfoList)) Then Exit Sub

        ReloadObjList()

    End Sub

    Private Sub F_Templates_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetFormLayout(Me)
    End Sub

    Private Sub F_Templates_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not PrepareCache(Me, GetType(HelperLists.TemplateJournalEntryInfoList)) Then Exit Sub

        Using busy As New StatusBusy
            Try
                Obj = HelperLists.TemplateJournalEntryInfoList.GetList
                TemplateJournalEntryListBindingSource.DataSource = Obj.GetFilteredList
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
            End Try
        End Using

        TemplateJournalEntryListDataGridView.Select()

        SetFormLayout(Me)

    End Sub

    Private Sub TemplateJournalEntryListDataGridView_CellDoubleClick( _
        ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles TemplateJournalEntryListDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        ' get the selected journal entry template
        Dim tmp As HelperLists.TemplateJournalEntryInfo = Nothing
        Try
            tmp = CType(TemplateJournalEntryListDataGridView.Rows(e.RowIndex).DataBoundItem, _
                HelperLists.TemplateJournalEntryInfo)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        If tmp Is Nothing Then
            MsgBox("Klaida. Nepavyko nustatyti pasirinkto bendrojo žurnalo šablono.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        ' ask what to do
        Dim ats As String = Ask("", New ButtonStructure("Taisyti", "Keisti bendrojo žurnalo šabloną."), _
            New ButtonStructure("Ištrinti", "Pašalinti bendrojo žurnalo šabloną iš duomenų bazės."), _
            New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        If ats <> "Taisyti" AndAlso ats <> "Ištrinti" Then Exit Sub

        If ats = "Taisyti" Then

            Dim frm As New F_Template(tmp)
            frm.MdiParent = MDIParent1
            frm.Show()

        Else

            If Not YesOrNo("Ar tikrai norite pašalinti bendrojo žurnalo šabloną iš duomenų bazės?") Then Exit Sub

            Using busy As New StatusBusy

                Using bm As New BindingsManager(TemplateJournalEntryListBindingSource, _
                    Nothing, Nothing, False, True)
                    Try
                        General.TemplateJournalEntry.DeleteTemplateJournalEntry(tmp.ID)
                        Obj.Remove(tmp)
                    Catch ex As Exception
                        ShowError(ex)
                        Exit Sub
                    End Try
                End Using

            End Using

            MsgBox("Bendojo žurnalo šablonas sėkmingai pašalintas iš įmonės duomenų bazės.", _
                MsgBoxStyle.Information, "Info")

        End If

    End Sub

    Private Sub Nauja_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewTemplateButton.Click

        Dim frm As New F_Template()
        frm.MdiParent = MDIParent1
        frm.Show()

    End Sub

    Private Sub ReloadObjList()

        Using busy As New StatusBusy
            Using bm As New BindingsManager(TemplateJournalEntryListBindingSource, Nothing, Nothing, False, True)

                Try
                    Obj = HelperLists.TemplateJournalEntryInfoList.GetList
                Catch ex As Exception
                    ShowError(ex)
                    DisableAllControls(Me)
                End Try

                bm.SetNewDataSource(Obj.GetFilteredList)

            End Using
        End Using

    End Sub
    
End Class