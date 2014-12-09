Imports AccDataAccessLayer.Security
Public Class F_DeleteDatabase

    Private Sub F_Del_DB_Activated(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_Del_DB_Load(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles MyBase.Load

        Dim DBlist As DatabaseInfoList
        Using busy As New StatusBusy
            Try
                DBlist = DatabaseInfoList.GetDatabaseList
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try
        End Using

        DatabaseInfoListBindingSource.DataSource = DBlist

    End Sub

    Private Sub DatabaseInfoListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
            ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles DatabaseInfoListDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        Dim SelectedDatabaseInfo As DatabaseInfo
        Try
            SelectedDatabaseInfo = CType(DatabaseInfoListDataGridView.Rows(e.RowIndex).DataBoundItem, _
                DatabaseInfo)
        Catch ex As Exception
            Exit Sub
        End Try

        MsgBox("DĖMESIO. ĮMONĖS DUOMENŲ BAZĖS IŠTRYNIMAS YRA NEGRĮŽTAMAS. " _
        & "SUNAIKINTŲ DUOMENŲ ATKURTI NEBUS ĮMANOMA.", MsgBoxStyle.Critical)

        If Not YesOrNo("Ar tikrai suprantate, kad įmonės duomenų nebus įmanoma atkurti?") Then Exit Sub

        MsgBox("DĖMESIO. ĮMONĖS DUOMENŲ BAZĖS IŠTRYNIMAS YRA NEGRĮŽTAMAS. " _
        & "SUNAIKINTŲ DUOMENŲ ATKURTI NEBUS ĮMANOMA.", MsgBoxStyle.Critical)

        If Not YesOrNo("Ar tikrai norite sunaikinti pasirinktos įmonės duomenis?") Then Exit Sub
        If Not YesOrNo("PASKUTINĮ KARTĄ KLAUSIU. Ar tikrai tikrai norite sunaikinti pasirinktos įmonės duomenis?") Then Exit Sub

        Using busy As New StatusBusy
            Try
                CommandDropDatabase.TheCommand(SelectedDatabaseInfo.DatabaseName)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try
        End Using

        MsgBox("Įmonės duomenys sėkmingai pašalinti.")

        Dim DBlist As DatabaseInfoList
        Using busy As New StatusBusy
            Try
                DatabaseInfoList.InvalidateCache()
                DBlist = DatabaseInfoList.GetDatabaseList
                BOMapper.DatabasesToMenu()
            Catch ex As Exception
                ShowError(New Exception("Klaida. Nepavyko atnaujinti įmonių sąrašo." & ex.Message, ex))
                DisableAllControls(Me)
                Exit Sub
            End Try
        End Using

        DatabaseInfoListBindingSource.RaiseListChangedEvents = False
        DatabaseInfoListBindingSource.DataSource = Nothing
        DatabaseInfoListBindingSource.DataSource = DBlist
        DatabaseInfoListBindingSource.RaiseListChangedEvents = True
        DatabaseInfoListBindingSource.ResetBindings(False)

    End Sub

End Class