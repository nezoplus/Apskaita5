Imports ApskaitaObjects.Workers
Imports ApskaitaObjects.ActiveReports
Public Class F_ImprestSheetInfoList
    Implements ISupportsPrinting

    Private Obj As ImprestSheetInfoList

    Private Sub F_ImprestSheetInfoList_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_ImprestSheetInfoList_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetDataGridViewLayOut(ImprestSheetInfoListDataGridView)
        GetFormLayout(Me)
    End Sub

    Private Sub F_ImprestSheetInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        RefreshButton.Enabled = ImprestSheetInfoList.CanGetObject

        DateFromDateTimePicker.Value = Today.Subtract(New TimeSpan(90, 0, 0, 0))

        AddDGVColumnSelector(ImprestSheetInfoListDataGridView)
        SetDataGridViewLayOut(ImprestSheetInfoListDataGridView)
        SetFormLayout(Me)

    End Sub


    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Using bm As New BindingsManager(ImprestSheetInfoListBindingSource, _
            Nothing, Nothing, False, True)

            Try
                Obj = LoadObject(Of ImprestSheetInfoList)(Nothing, "GetImprestSheetInfoList", _
                    True, DateFromDateTimePicker.Value.Date, DateToDateTimePicker.Value.Date)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            Obj.ApplyFilter(ShowPayedOutCheckBox.Checked)
            bm.SetNewDataSource(Obj.GetFilteredList)

        End Using

        ImprestSheetInfoListDataGridView.Select()

    End Sub

    Private Sub ShowNonEmplyedCheckBox_CheckedChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ShowPayedOutCheckBox.CheckedChanged

        If Obj Is Nothing Then Exit Sub
        Obj.ApplyFilter(ShowPayedOutCheckBox.Checked)

    End Sub

    Private Sub ImprestSheetInfoListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles ImprestSheetInfoListDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        ' get the selected journal entry
        Dim tmp As ImprestSheetInfo = Nothing
        Try
            tmp = CType(ImprestSheetInfoListDataGridView.Rows(e.RowIndex).DataBoundItem, _
                ImprestSheetInfo)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        If tmp Is Nothing Then
            MsgBox("Klaida. Nepavyko nustatyti pasirinkto žiniaraščio.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Dim ats As String = Ask("", New ButtonStructure("Taisyti", "Taisyti žiniaraščio duomenis."), _
            New ButtonStructure("Pašalinti", "Ištrinti žiniaraščio duomenis."), _
            New ButtonStructure("Išmokėjimai", "Tvarkyti išmokėjimo duomenis (datas)."), _
            New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        If ats <> "Taisyti" AndAlso ats <> "Pašalinti" AndAlso ats <> "Išmokėjimai" Then Exit Sub

        If ats = "Taisyti" Then

            MDIParent1.LaunchForm(GetType(F_ImprestSheet), False, False, tmp.ID, tmp.ID)

        ElseIf ats = "Pašalinti" Then

            If Not YesOrNo("Ar tikrai norite pašalinti avanso žiniaraščio duomenis?") Then Exit Sub

            Using bm As New BindingsManager(ImprestSheetInfoListBindingSource, _
                Nothing, Nothing, False, True)

                Try
                    ImprestSheet.DeleteImprestSheet(tmp.ID)
                    Obj = LoadObject(Of ImprestSheetInfoList)(Nothing, "GetImprestSheetInfoList", _
                        False, Obj.DateFrom, Obj.DateTo)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try

                Obj.ApplyFilter(ShowPayedOutCheckBox.Checked)
                bm.SetNewDataSource(Obj.GetFilteredList)

            End Using

            MsgBox("Avanso žiniaraščio duomenys sėkmingai pašalinti.", MsgBoxStyle.Information, "Info")

        ElseIf ats = "Išmokėjimai" Then

            MDIParent1.LaunchForm(GetType(F_WagePayOut), False, False, tmp.ID, tmp.ID)

        End If

    End Sub

    Private Sub NewButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewButton.Click
        MDIParent1.NewImprestSheetMenuItem_Click(New Object, New EventArgs)
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