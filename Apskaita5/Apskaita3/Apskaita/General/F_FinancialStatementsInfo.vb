Imports ApskaitaObjects.ActiveReports
Public Class F_FinancialStatementsInfo
    Implements ISupportsPrinting

    Private Obj As ActiveReports.FinancialStatementsInfo
    Private Loading As Boolean = True


    Private Sub F_FinancialStatementsInfo_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_FinancialStatementsInfo_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        GetDataGridViewLayOut(AccountTurnoverListDataGridView)
        GetDataGridViewLayOut(BalanceSheetDataGridView)
        GetDataGridViewLayOut(IncomeStatementDataGridView)
        GetFormLayout(Me)

    End Sub

    Private Sub F_FinancialStatementsInfo_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        DateFirstPeriodStartDateTimePicker.Value = New Date(Today.Year - 1, 1, 1)
        DateSecondPeriodStartDateTimePicker.Value = New Date(Today.Year, 1, 1)
        ClosingSummaryAccountAccGridComboBox.SelectedValue = _
            GetCurrentCompany.GetDefaultAccount(General.DefaultAccountType.ClosingSummary)

        If Not SetDataSources() Then Exit Sub

        AddDGVColumnSelector(AccountTurnoverListDataGridView)
        AddDGVColumnSelector(BalanceSheetDataGridView)
        AddDGVColumnSelector(IncomeStatementDataGridView)

        SetDataGridViewLayOut(AccountTurnoverListDataGridView)
        SetDataGridViewLayOut(BalanceSheetDataGridView)
        SetDataGridViewLayOut(IncomeStatementDataGridView)
        SetFormLayout(Me)

    End Sub


    Private Sub AccountTurnoverListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles AccountTurnoverListDataGridView.CellDoubleClick

        If e.RowIndex < 0 OrElse Obj Is Nothing Then Exit Sub

        Dim tmp As AccountTurnoverInfo = Nothing
        Try
            tmp = CType(AccountTurnoverListDataGridView.Rows(e.RowIndex).DataBoundItem, AccountTurnoverInfo)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try
        If tmp Is Nothing Then
            MsgBox("Klaida. Nepavyko nustatyti pasirinktos apskaitos sąskaitos.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        MDIParent1.LaunchForm(GetType(F_AccountTurnoverInfo), False, False, tmp.ID, _
            tmp.ID, Obj.FirstPeriodDateStart, Obj.SecondPeriodDateEnd, 0)

    End Sub

    Private Sub BalanceSheetDataGridView_RowPrePaint(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) _
        Handles BalanceSheetDataGridView.RowPrePaint

        Dim tmp As BalanceSheetInfo = Nothing
        Try
            tmp = CType(BalanceSheetDataGridView.Rows(e.RowIndex).DataBoundItem, BalanceSheetInfo)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try
        If tmp Is Nothing Then Exit Sub

        Dim nPadding As New Padding((tmp.Level - 2) * 10, 0, 0, 0)
        BalanceSheetDataGridView.Rows(e.RowIndex).Cells( _
            DataGridViewTextBoxColumn20.Index).Style.Padding = nPadding

        If tmp.Level = 2 Then
            BalanceSheetDataGridView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightSlateGray
            BalanceSheetDataGridView.Rows(e.RowIndex).DefaultCellStyle.Font = _
                New Font(BalanceSheetDataGridView.DefaultCellStyle.Font, FontStyle.Bold)
            BalanceSheetDataGridView.Rows(e.RowIndex).DividerHeight = 5
        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is AccountTurnOverInfoListTabPage Then
            AccountTurnoverListDataGridView.Select()
        ElseIf TabControl1.SelectedTab Is BalanceSheetTabPage Then
            BalanceSheetDataGridView.Select()
        ElseIf TabControl1.SelectedTab Is IncomeStatementTabPage Then
            IncomeStatementDataGridView.Select()
        End If
    End Sub

    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Dim nAccount As Long = 0
        Try
            nAccount = Convert.ToInt64(ClosingSummaryAccountAccGridComboBox.SelectedValue)
        Catch ex As Exception
        End Try
        If Not nAccount > 0 Then
            MsgBox("Klaida. Nenurodyta uždarymo suvestinė sąskaita.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        FinancialStatementsInfoBindingSource.RaiseListChangedEvents = False
        AccountTurnoverListBindingSource.RaiseListChangedEvents = False
        BalanceSheetBindingSource.RaiseListChangedEvents = False
        IncomeStatementBindingSource.RaiseListChangedEvents = False

        Try
            Obj = LoadObject(Of FinancialStatementsInfo)(Nothing, _
                "GetFinancialStatementsInfo", True, DateFirstPeriodStartDateTimePicker.Value.Date, _
                DateSecondPeriodStartDateTimePicker.Value.Date, _
                DateSecondPeriodEndDateTimePicker.Value.Date, nAccount)
        Catch ex As Exception
            FinancialStatementsInfoBindingSource.RaiseListChangedEvents = True
            AccountTurnoverListBindingSource.RaiseListChangedEvents = True
            BalanceSheetBindingSource.RaiseListChangedEvents = True
            IncomeStatementBindingSource.RaiseListChangedEvents = True
            ShowError(ex)
            Exit Sub
        End Try

        FinancialStatementsInfoBindingSource.DataSource = Nothing
        AccountTurnoverListBindingSource.DataSource = FinancialStatementsInfoBindingSource
        BalanceSheetBindingSource.DataSource = FinancialStatementsInfoBindingSource
        IncomeStatementBindingSource.DataSource = FinancialStatementsInfoBindingSource
        FinancialStatementsInfoBindingSource.DataSource = Obj

        FinancialStatementsInfoBindingSource.RaiseListChangedEvents = True
        AccountTurnoverListBindingSource.RaiseListChangedEvents = True
        BalanceSheetBindingSource.RaiseListChangedEvents = True
        IncomeStatementBindingSource.RaiseListChangedEvents = True

        AccountTurnoverListBindingSource.ResetBindings(False)
        BalanceSheetBindingSource.ResetBindings(False)
        IncomeStatementBindingSource.ResetBindings(False)
        FinancialStatementsInfoBindingSource.ResetBindings(False)

        If TabControl1.SelectedTab Is AccountTurnOverInfoListTabPage Then
            AccountTurnoverListDataGridView.Select()
        ElseIf TabControl1.SelectedTab Is BalanceSheetTabPage Then
            BalanceSheetDataGridView.Select()
        ElseIf TabControl1.SelectedTab Is IncomeStatementTabPage Then
            IncomeStatementDataGridView.Select()
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

        Using frm As New F_SendObjToEmail(Obj, TabControl1.SelectedIndex)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, False, TabControl1.SelectedIndex)
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, True, TabControl1.SelectedIndex)
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function


    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Return False

        Try
            LoadAccountInfoListToGridCombo(ClosingSummaryAccountAccGridComboBox, True)
        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

End Class