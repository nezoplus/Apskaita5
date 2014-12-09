Imports ApskaitaObjects.Assets
Public Class F_LongTermAssetComplexDocumentInfoList
    Implements ISupportsPrinting

    Private Obj As LongTermAssetComplexDocumentInfoList

    Private Sub F_LongTermAssetComplexDocumentInfoList_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

    End Sub

    Private Sub F_LongTermAssetComplexDocumentInfoList_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetDataGridViewLayOut(LongTermAssetComplexDocumentInfoListDataGridView)
        GetFormLayout(Me)
    End Sub

    Private Sub F_LongTermAssetComplexDocumentInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        AddDGVColumnSelector(LongTermAssetComplexDocumentInfoListDataGridView)

        SetDataGridViewLayOut(LongTermAssetComplexDocumentInfoListDataGridView)
        SetFormLayout(Me)

    End Sub

    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Using bm As New BindingsManager(LongTermAssetComplexDocumentInfoListBindingSource, _
            Nothing, Nothing, False, True)

            Try
                Obj = LoadObject(Of LongTermAssetComplexDocumentInfoList)(Nothing, _
                    "GetLongTermAssetComplexDocumentInfoList", True, DateFromDateTimePicker.Value, _
                    DateToDateTimePicker.Value)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj.GetSortedList)

        End Using

    End Sub

    Private Sub LongTermAssetComplexDocumentInfoListDataGridView_CellDoubleClick( _
        ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles LongTermAssetComplexDocumentInfoListDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        Dim SelectedItem As LongTermAssetComplexDocumentInfo = Nothing
        Try
            SelectedItem = CType(LongTermAssetComplexDocumentInfoListDataGridView. _
                Rows(e.RowIndex).DataBoundItem, LongTermAssetComplexDocumentInfo)
        Catch ex As Exception
            MsgBox("Klaida. Nepavyko identifikuoti įrašo.", MsgBoxStyle.Exclamation, "Klaida")
        End Try
        If SelectedItem Is Nothing Then Exit Sub

        For Each frm As Form In MDIParent1.MdiChildren
            If TypeOf frm Is F_LongTermAssetComplexDocument AndAlso _
                CType(frm, F_LongTermAssetComplexDocument).CurrentID = SelectedItem.ID Then
                frm.Activate()
                frm.BringToFront()
                Exit Sub
            End If
        Next

        Dim ats As String = Ask("", _
            New ButtonStructure("Taisyti", "Atidaryti IT dokumento duomenų formą."), _
            New ButtonStructure("Pašalinti", "Pašalinti IT dokumento duomenis iš apskaitos."), _
            New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        If ats.Trim <> "Taisyti" AndAlso ats.Trim <> "Pašalinti" Then Exit Sub

        If ats.Trim = "Taisyti" Then

            MDIParent1.LaunchForm(GetType(F_LongTermAssetComplexDocument), _
                False, False, SelectedItem.ID, SelectedItem.ID)

        ElseIf ats.Trim = "Pašalinti" Then

            If Not YesOrNo("Ar tikrai norite pašalinti pasirinkto IT " _
                & "operacijų dokumento duomenis iš apskaitos?") Then Exit Sub

            Using busy As New StatusBusy
                Try
                    LongTermAssetComplexDocument.DeleteLongTermAssetComplexDocument(SelectedItem.ID)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try
            End Using

            If Not YesOrNo("Ilgalaikio turto operacijų dokumento duomenys sėkmingai " _
                & "pašalinti iš apskaitos. Atnaujinti sąrašą?") Then Exit Sub

            Using bm As New BindingsManager(LongTermAssetComplexDocumentInfoListBindingSource, _
                Nothing, Nothing, False, True)

                Try
                    Obj = LoadObject(Of LongTermAssetComplexDocumentInfoList)(Nothing, _
                        "GetLongTermAssetComplexDocumentInfoList", True, DateFromDateTimePicker.Value, _
                        DateToDateTimePicker.Value)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try

                bm.SetNewDataSource(Obj.GetSortedList)

            End Using

        End If

    End Sub

    Private Sub NewOperationButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewOperationButton.Click
        MDIParent1.LaunchForm(GetType(F_LongTermAssetComplexDocument), False, False, 0, 0)
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

End Class