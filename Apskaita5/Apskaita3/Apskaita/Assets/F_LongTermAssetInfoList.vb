Imports ApskaitaObjects.Assets
Imports ApskaitaObjects.HelperLists
Public Class F_LongTermAssetInfoList
    Implements ISupportsPrinting

    Private Obj As LongTermAssetInfoList

    Private Sub F_LongTermAssetInfoList_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_LongTermAssetInfoList_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetDataGridViewLayOut(LongTermAssetInfoListDataGridView)
        GetFormLayout(Me)
    End Sub

    Private Sub F_LongTermAssetInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        AddDGVColumnSelector(LongTermAssetInfoListDataGridView)

        SetDataGridViewLayOut(LongTermAssetInfoListDataGridView)
        SetFormLayout(Me)

    End Sub

    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Dim CustomGroupFilter As LongTermAssetCustomGroupInfo = Nothing
        If Not LongTermAssetCustomGroupInfoComboBox.SelectedItem Is Nothing _
            AndAlso CType(LongTermAssetCustomGroupInfoComboBox.SelectedItem, _
            LongTermAssetCustomGroupInfo).ID > 0 Then CustomGroupFilter = _
            CType(LongTermAssetCustomGroupInfoComboBox.SelectedItem, LongTermAssetCustomGroupInfo)

        Using bm As New BindingsManager(LongTermAssetInfoListBindingSource, _
            Nothing, Nothing, False, True)

            Try
                Obj = LoadObject(Of LongTermAssetInfoList)(Nothing, "GetLongTermAssetInfoList", True, _
                    DateFromDateTimePicker.Value, DateToDateTimePicker.Value, CustomGroupFilter)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj.GetSortedList)

        End Using

    End Sub

    Private Sub LongTermAssetInfoListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles LongTermAssetInfoListDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        Dim SelectedItem As LongTermAssetInfo = Nothing
        Try
            SelectedItem = CType(LongTermAssetInfoListDataGridView.Rows(e.RowIndex).DataBoundItem, _
                LongTermAssetInfo)
        Catch ex As Exception
            MsgBox("Klaida. Nepavyko identifikuoti įrašo.", MsgBoxStyle.Exclamation, "Klaida")
        End Try
        If SelectedItem Is Nothing Then Exit Sub

        Dim ats As String = Ask("", _
            New ButtonStructure("Bendrus", "Atidaryti bendrų IT duomenų formą."), _
            New ButtonStructure("Detalius", "Atidaryti detalių IT duomenų formą."), _
            New ButtonStructure("Pašalinti", "Pašalinti IT duomenis iš apskaitos."), _
            New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        If ats.Trim <> "Bendrus" AndAlso ats.Trim <> "Detalius" _
            AndAlso ats.Trim <> "Pašalinti" Then Exit Sub

        If ats.Trim = "Bendrus" Then

            MDIParent1.LaunchForm(GetType(F_LongTermAsset), False, False, SelectedItem.ID, SelectedItem.ID)

        ElseIf ats.Trim = "Detalius" Then

            MDIParent1.LaunchForm(GetType(F_LongTermAssetOperationInfoListParent), _
                False, False, SelectedItem.ID, SelectedItem.ID)

        ElseIf ats.Trim = "Pašalinti" Then

            For Each frm As Form In MDIParent1.MdiChildren
                If TypeOf frm Is F_LongTermAsset AndAlso _
                    CType(frm, F_LongTermAsset).ObjectID = SelectedItem.ID Then
                    MsgBox("Klaida. Šie duomenys dabar redaguojami,", MsgBoxStyle.Exclamation, "Klaida.")
                    frm.Activate()
                    frm.BringToFront()
                    Exit Sub
                End If
            Next
            For Each frm As Form In MDIParent1.MdiChildren
                If TypeOf frm Is F_LongTermAssetOperationInfoListParent AndAlso _
                    CType(frm, F_LongTermAssetOperationInfoListParent).ObjectID = SelectedItem.ID Then
                    MsgBox("Klaida. Šie duomenys dabar redaguojami,", MsgBoxStyle.Exclamation, "Klaida.")
                    frm.Activate()
                    frm.BringToFront()
                    Exit Sub
                End If
            Next

            If Not YesOrNo("Ar tikrai norite pašalinti pasirinkto IT duomenis iš apskaitos?") Then Exit Sub

            Using busy As New StatusBusy
                Try
                    LongTermAsset.DeleteLongTermAsset(SelectedItem.ID)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try
            End Using

            If Not YesOrNo("Ilgalaikio turto duomenys sėkmingai pašalinti iš apskaitos. " _
                & "Atnaujinti sąrašą?") Then Exit Sub

            Using bm As New BindingsManager(LongTermAssetInfoListBindingSource, _
                Nothing, Nothing, False, True)

                Try
                    Obj = LoadObject(Of LongTermAssetInfoList)(Nothing, "GetList", True, _
                        Obj.DateFrom, Obj.DateTo, Nothing)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try

                bm.SetNewDataSource(Obj.GetSortedList)

            End Using

        End If

    End Sub

    Public Function GetMailDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetMailDropDownItems
        Return Nothing
    End Function

    Public Function GetPrintDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintDropDownItems
        Return Nothing
    End Function

    Public Function GetPrintPreviewDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintPreviewDropDownItems
        Return Nothing
    End Function

    Public Sub OnMailClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnMailClick
        If Obj Is Nothing Then Exit Sub

        Using frm As New F_SendObjToEmail(Obj, 0)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, False, 0)
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, True, 0)
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function


    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(LongTermAssetCustomGroupInfoList)) Then Return False

        Try
            LoadAssetCustomGroupInfoListToCombo(LongTermAssetCustomGroupInfoComboBox, True)
        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

End Class