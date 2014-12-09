Imports ApskaitaObjects.ActiveReports
Public Class F_WorkTimeSheetInfoList
    Implements ISupportsPrinting

    Private Obj As WorkTimeSheetInfoList


    Private Sub F_WorkTimeSheetInfoList_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_WorkTimeSheetInfoList_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetDataGridViewLayOut(WorkTimeSheetInfoListDataGridView)
        GetFormLayout(Me)
    End Sub

    Private Sub F_WorkTimeSheetInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        RefreshButton.Enabled = WorkTimeSheetInfoList.CanGetObject
        NewButton.Enabled = Workers.WorkTimeSheet.CanAddObject

        DateFromDateTimePicker.Value = Today.Subtract(New TimeSpan(90, 0, 0, 0))

        AddDGVColumnSelector(WorkTimeSheetInfoListDataGridView)
        SetDataGridViewLayOut(WorkTimeSheetInfoListDataGridView)
        SetFormLayout(Me)

    End Sub


    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Using bm As New BindingsManager(WorkTimeSheetInfoListBindingSource, _
            Nothing, Nothing, False, True)

            Try
                Obj = LoadObject(Of WorkTimeSheetInfoList)(Nothing, "GetWorkTimeSheetInfoList", _
                    True, DateFromDateTimePicker.Value.Date, DateToDateTimePicker.Value.Date)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj.GetSortedList)

        End Using

        WorkTimeSheetInfoListDataGridView.Select()

    End Sub

    Private Sub WorkTimeSheetInfoListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
       ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
       Handles WorkTimeSheetInfoListDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        Dim tmp As WorkTimeSheetInfo = Nothing
        Try
            tmp = CType(WorkTimeSheetInfoListDataGridView.Rows(e.RowIndex).DataBoundItem, _
                WorkTimeSheetInfo)
        Catch ex As Exception
        End Try
        If tmp Is Nothing Then
            MsgBox("Klaida. Nepavyko nustatyti pasirinkto žiniaraščio.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        For Each frm As Form In MDIParent1.MdiChildren
            If TypeOf frm Is F_WorkTimeSheet AndAlso DirectCast(frm, F_WorkTimeSheet).ObjectID = tmp.ID Then
                frm.Activate()
                Exit Sub
            End If
        Next

        Dim ats As String = Ask("", New ButtonStructure("Taisyti", "Taisyti žiniaraščio duomenis."), _
            New ButtonStructure("Pašalinti", "Ištrinti žiniaraščio duomenis."), _
            New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        If ats <> "Taisyti" AndAlso ats <> "Pašalinti" Then Exit Sub

        If ats = "Taisyti" Then

            MDIParent1.LaunchForm(GetType(F_WorkTimeSheet), False, False, tmp.ID, tmp.ID)

        ElseIf ats = "Pašalinti" Then

            If Not YesOrNo("Ar tikrai norite pašalinti darbo laiko žiniaraščio duomenis?") Then Exit Sub

            Try
                Using busy As New StatusBusy
                    Workers.WorkTimeSheet.DeleteWorkTimeSheet(tmp.ID)
                End Using
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            If Not YesOrNo("Darbo laiko žiniaraščio duomenys sėkmingai pašalinti. Atnaujinti sąrašą?") Then Exit Sub

            Using bm As New BindingsManager(WorkTimeSheetInfoListBindingSource, _
                Nothing, Nothing, False, True)

                Try
                    Obj = LoadObject(Of WorkTimeSheetInfoList)(Nothing, "GetWorkTimeSheetInfoList", _
                        True, Obj.DateFrom, Obj.DateTo)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try

                bm.SetNewDataSource(Obj.GetSortedList())

            End Using

            WorkTimeSheetInfoListDataGridView.Select()

        End If

    End Sub

    Private Sub NewButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewButton.Click
        MDIParent1.LaunchForm(GetType(F_WorkTimeSheet), False, False, 0)
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