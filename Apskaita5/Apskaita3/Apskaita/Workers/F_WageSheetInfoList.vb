Imports ApskaitaObjects.Workers
Imports ApskaitaObjects.ActiveReports
Public Class F_WageSheetInfoList
    Implements ISupportsPrinting

    Private Obj As WageSheetInfoList

    Private Sub F_WageSheetInfoList_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_WageSheetInfoList_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetDataGridViewLayOut(WageSheetInfoListDataGridView)
        GetFormLayout(Me)
    End Sub

    Private Sub F_WageSheetInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        RefreshButton.Enabled = WageSheetInfoList.CanGetObject
        NewButton.Enabled = WageSheet.CanAddObject

        DateFromDateTimePicker.Value = Today.Subtract(New TimeSpan(90, 0, 0, 0))

        AddDGVColumnSelector(WageSheetInfoListDataGridView)
        SetDataGridViewLayOut(WageSheetInfoListDataGridView)
        SetFormLayout(Me)

    End Sub


    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Using bm As New BindingsManager(WageSheetInfoListBindingSource, _
            Nothing, Nothing, False, True)

            Try
                Obj = LoadObject(Of WageSheetInfoList)(Nothing, "GetWageSheetInfoList", _
                    True, DateFromDateTimePicker.Value.Date, DateToDateTimePicker.Value.Date)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            Obj.ApplyFilter(ShowPayedOutCheckBox.Checked)

            bm.SetNewDataSource(Obj.GetFilteredList())

            TotalSumAfterDeductionsAccBox.DecimalValue = Obj.TotalSumAfterDeductions
            TotalSumPayedOutAccBox.DecimalValue = Obj.TotalSumPayedOut

        End Using

        WageSheetInfoListDataGridView.Select()

    End Sub

    Private Sub ShowPayedOutCheckBox_CheckedChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ShowPayedOutCheckBox.CheckedChanged
        If Obj Is Nothing Then Exit Sub
        Obj.ApplyFilter(ShowPayedOutCheckBox.Checked)
    End Sub

    Private Sub WageSheetInfoListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles WageSheetInfoListDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        Dim tmp As WageSheetInfo = Nothing
        Try
            tmp = CType(WageSheetInfoListDataGridView.Rows(e.RowIndex).DataBoundItem, _
                WageSheetInfo)
        Catch ex As Exception
        End Try
        If tmp Is Nothing Then
            MsgBox("Klaida. Nepavyko nustatyti pasirinkto žiniaraščio.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        For Each frm As Form In MDIParent1.MdiChildren
            If TypeOf frm Is F_WageSheet AndAlso DirectCast(frm, F_WageSheet).ObjectID = tmp.ID Then
                frm.Activate()
                Exit Sub
            End If
        Next

        Dim ats As String = Ask("", New ButtonStructure("Taisyti", "Taisyti žiniaraščio duomenis."), _
            New ButtonStructure("Pašalinti", "Ištrinti žiniaraščio duomenis."), _
            New ButtonStructure("Išmokėjimai", "Tvarkyti išmokėjimo duomenis (datas)."), _
            New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        If ats <> "Taisyti" AndAlso ats <> "Pašalinti" AndAlso ats <> "Išmokėjimai" Then Exit Sub

        If ats = "Taisyti" Then

            MDIParent1.LaunchForm(GetType(F_WageSheet), False, False, tmp.ID, tmp.ID)

        ElseIf ats = "Pašalinti" Then

            If Not YesOrNo("Ar tikrai norite pašalinti darbo užmokesčio žiniaraščio duomenis?") Then Exit Sub

            Using busy As New StatusBusy
                Try
                    WageSheet.DeleteWageSheet(tmp.ID)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try
            End Using

            If Not YesOrNo("Darbo užmokesčio žiniaraščio duomenys sėkmingai pašalinti. Atnaujinti sąrašą?") Then Exit Sub

            Using bm As New BindingsManager(WageSheetInfoListBindingSource, _
                Nothing, Nothing, False, True)

                Try
                    Obj = LoadObject(Of WageSheetInfoList)(Nothing, "GetWageSheetInfoList", _
                        True, Obj.DateFrom, Obj.DateTo)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try

                Obj.ApplyFilter(ShowPayedOutCheckBox.Checked)

                bm.SetNewDataSource(Obj.GetFilteredList())

                TotalSumAfterDeductionsAccBox.DecimalValue = Obj.TotalSumAfterDeductions
                TotalSumPayedOutAccBox.DecimalValue = Obj.TotalSumPayedOut

            End Using


        ElseIf ats = "Išmokėjimai" Then

            MDIParent1.LaunchForm(GetType(F_WagePayOut), False, False, tmp.ID, tmp.ID)

        End If

    End Sub

    Private Sub NewButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewButton.Click
        MDIParent1.LaunchForm(GetType(F_WageSheet), False, False, 0)
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