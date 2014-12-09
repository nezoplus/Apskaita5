Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.Documents
Public Class F_ServiceInfoList
    Implements ISupportsPrinting

    Private Obj As ServiceInfoList
    Private Loading As Boolean = True


    Private Sub F_ServiceInfoList_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.ServiceInfoList)) Then Exit Sub

        ReloadObjList()

    End Sub

    Private Sub F_ServiceInfoList_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetDataGridViewLayOut(ServiceInfoListDataGridView)
        GetFormLayout(Me)
    End Sub

    Private Sub F_ServiceInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not PrepareCache(Me, GetType(HelperLists.ServiceInfoList)) Then Exit Sub

        Using busy As New StatusBusy
            Try
                Obj = HelperLists.ServiceInfoList.GetList()
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try
        End Using

        ServiceInfoListBindingSource.DataSource = Obj.GetFilteredList

        AddDGVColumnSelector(ServiceInfoListDataGridView)

        SetDataGridViewLayOut(ServiceInfoListDataGridView)
        SetFormLayout(Me)

        NewObjectButton.Enabled = Service.CanAddObject

    End Sub


    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click
        ServiceInfoList.InvalidateCache()
        If Not PrepareCache(Me, GetType(ServiceInfoList)) Then Exit Sub
        ReloadObjList()
    End Sub

    Private Sub ShowSalesCheckBox_CheckedChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ShowSalesCheckBox.CheckedChanged, _
        ShowPurchasesCheckBox.CheckedChanged, ShowObsoleteCheckBox.CheckedChanged
        If Obj Is Nothing Then Exit Sub
        Obj.ApplyFilter(ShowSalesCheckBox.Checked, ShowPurchasesCheckBox.Checked, _
            ShowObsoleteCheckBox.Checked)
    End Sub

    Private Sub NewObjectButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewObjectButton.Click
        MDIParent1.LaunchForm(GetType(F_Service), False, False, 0)
    End Sub

    Private Sub ServiceInfoListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles ServiceInfoListDataGridView.CellDoubleClick

        If Obj Is Nothing OrElse e.RowIndex < 0 OrElse Not Service.CanEditObject Then Exit Sub

        Dim SelectedObj As ServiceInfo
        Try
            SelectedObj = CType(ServiceInfoListDataGridView.Rows(e.RowIndex).DataBoundItem, ServiceInfo)
        Catch ex As Exception
            Exit Sub
        End Try
        If SelectedObj Is Nothing OrElse Not SelectedObj.ID > 0 Then Exit Sub

        For Each frm As Form In MDIParent1.MdiChildren
            If TypeOf frm Is F_Service AndAlso DirectCast(frm, F_Service).ObjectID = SelectedObj.ID Then
                frm.Activate()
                Exit Sub
            End If
        Next

        Dim Answ As String = Ask("", New ButtonStructure("Keisti", "Keisti paslaugos duomenis."), _
            New ButtonStructure("Ištrinti", "Pašalinti paslaugos duomenis iš duomenų bazės."), _
            New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        If Answ <> "Keisti" AndAlso Answ <> "Ištrinti" Then Exit Sub

        If Answ = "Keisti" Then

            MDIParent1.LaunchForm(GetType(F_Service), False, False, SelectedObj.ID, SelectedObj.ID)

        Else

            If Not YesOrNo("Ar tikrai norite pašalinti pasirinktos paslaugos " & _
                "duomenis iš duomenų bazės?") Then Exit Sub

            Using busy As New StatusBusy
                Try
                    Service.DeleteService(SelectedObj.ID)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try
            End Using

            MsgBox("Paslaugos duomenys sėkmingai pašalinti iš duomenų bazės.", _
                MsgBoxStyle.Information, "Info")

            ReloadObjList()

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


    Private Sub ReloadObjList()

        Using bm As New BindingsManager(ServiceInfoListBindingSource, Nothing, Nothing, False, True)

            Obj = ServiceInfoList.GetList
            Obj.ApplyFilter(ShowSalesCheckBox.Checked, ShowPurchasesCheckBox.Checked, _
                ShowObsoleteCheckBox.Checked)

            bm.SetNewDataSource(Obj.GetFilteredList)

        End Using

    End Sub

End Class