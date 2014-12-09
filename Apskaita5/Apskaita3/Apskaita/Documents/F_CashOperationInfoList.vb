Imports ApskaitaObjects.ActiveReports
Imports ApskaitaObjects.HelperLists
Public Class F_CashOperationInfoList
    Implements ISupportsPrinting

    Private Obj As CashOperationInfoList
    Private Loading As Boolean = True
    Private PrintDropDown As Windows.Forms.ToolStripDropDown = Nothing
    Private PrintPreviewDropDown As Windows.Forms.ToolStripDropDown = Nothing
    Private EmailDropDown As Windows.Forms.ToolStripDropDown = Nothing


    Private Sub F_CashOperationInfoList_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList), _
            GetType(HelperLists.CashAccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_CashOperationInfoList_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        GetFormLayout(Me)
        GetDataGridViewLayOut(CashOperationInfoListDataGridView)

    End Sub

    Private Sub F_CashOperationInfoList_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Load

        If Not CashOperationInfoList.CanGetObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        DateFromDateTimePicker.Value = Today.Subtract(New TimeSpan(30, 0, 0, 0))

        If Not SetDataSources() Then Exit Sub

        AddDGVColumnSelector(CashOperationInfoListDataGridView)
        SetFormLayout(Me)
        SetDataGridViewLayOut(CashOperationInfoListDataGridView)

    End Sub


    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Using bm As New BindingsManager(CashOperationInfoListBindingSource, _
            Nothing, Nothing, False, False)

            Try
                Obj = LoadObject(Of CashOperationInfoList)(Nothing, "GetCashOperationInfoList", _
                    True, LoadObjectFromCombo(Of CashAccountInfo)(AccountAccGridComboBox, ""), _
                    DateFromDateTimePicker.Value.Date, DateToDateTimePicker.Value.Date, _
                    LoadObjectFromCombo(Of PersonInfo)(PersonAccGridComboBox, ""))
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj.GetSortedList)

        End Using

        BalanceStartAccTextBox.DecimalValue = Obj.BalanceStart
        BalanceBookEntriesStartAccTextBox.DecimalValue = Obj.BalanceBookEntryStart
        BalanceLTLStartAccTextBox.DecimalValue = Obj.BalanceLTLStart
        TurnoverDebitAccTextBox.DecimalValue = Obj.TurnoverDebit
        TurnoverCreditAccTextBox.DecimalValue = Obj.TurnoverCredit
        TurnoverBookEntriesDebitAccTextBox.DecimalValue = Obj.TurnoverBookEntryDebit
        TurnoverBookEntriesCreditAccTextBox.DecimalValue = Obj.TurnoverBookEntryCredit
        TurnoverLTLDebitAccTextBox.DecimalValue = Obj.TurnoverLTLDebit
        TurnoverLTLCreditAccTextBox.DecimalValue = Obj.TurnoverLTLCredit
        TurnoverInListLTLDebitAccTextBox.DecimalValue = Obj.TurnOverInListLTLDebit
        TurnoverInListLTLCreditAccTextBox.DecimalValue = Obj.TurnoverInListLTLCredit
        BalanceEndAccTextBox.DecimalValue = Obj.BalanceEnd
        BalanceBookEntriesEndAccTextBox.DecimalValue = Obj.BalanceBookEntryEnd
        BalanceLTLEndAccTextBox.DecimalValue = Obj.BalanceLTLEnd

        CashOperationInfoListDataGridView.Select()

    End Sub

    Private Sub CashOperationInfoListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles CashOperationInfoListDataGridView.CellDoubleClick

        If Obj Is Nothing OrElse e.RowIndex < 0 Then Exit Sub

        ' get the selected book entry
        Dim tmp As CashOperationInfo = Nothing
        Try
            tmp = CType(CashOperationInfoListDataGridView.Rows(e.RowIndex).DataBoundItem, CashOperationInfo)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try
        If tmp Is Nothing Then
            MsgBox("Klaida. Nepavyko nustatyti pasirinktos operacijos.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Dim EditFormType As Type
        If tmp.OperationType = DocumentType.BankOperation Then
            EditFormType = GetType(F_BankOperation)
        ElseIf tmp.OperationType = DocumentType.TillIncomeOrder Then
            EditFormType = GetType(F_TillIncomeOrder)
        ElseIf tmp.OperationType = DocumentType.TillSpendingOrder Then
            EditFormType = GetType(F_TillSpendingsOrder)
        Else
            MsgBox("Klaida. Lėšų operacijos tipas '" & tmp.OperationTypeHumanReadable _
                & "' neimplementuotas.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        For Each frm As Form In MDIParent1.MdiChildren
            If TypeOf frm Is IObjectEditForm AndAlso frm.GetType Is EditFormType AndAlso _
                DirectCast(frm, IObjectEditForm).ObjectID = tmp.ID Then
                frm.Activate()
                Exit Sub
            End If
        Next

        ' ask what to do
        Dim ats As String
        ats = Ask("", New ButtonStructure("Taisyti", "Keisti mokėjimo dokumento duomenis."), _
            New ButtonStructure("Ištrinti", "Pašalinti mokėjimo dokumento duomenis iš duomenų bazės."), _
            New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        If ats <> "Taisyti" AndAlso ats <> "Ištrinti" Then Exit Sub

        If ats = "Ištrinti" Then

            If Not YesOrNo("Ar tikrai norite pašalinti dokumento duomenis iš duomenų bazės?") Then Exit Sub

            Using busy As New StatusBusy
                Try
                    If tmp.OperationType = DocumentType.BankOperation Then
                        Documents.BankOperation.DeleteBankOperation(tmp.ID)
                    ElseIf tmp.OperationType = DocumentType.TillIncomeOrder Then
                        Documents.TillIncomeOrder.DeleteTillIncomeOrder(tmp.ID)
                    ElseIf tmp.OperationType = DocumentType.TillSpendingOrder Then
                        Documents.TillSpendingsOrder.DeleteTillSpendingsOrder(tmp.ID)
                    Else
                        MsgBox("Klaida. Lėšų operacijos tipas '" & tmp.OperationTypeHumanReadable _
                            & "' neimplementuotas.", MsgBoxStyle.Exclamation, "Klaida")
                        Exit Sub
                    End If
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try
            End Using

            If Not YesOrNo("Dokumento duomenys sėkmingai pašalinti iš įmonės duomenų bazės. " _
                & "Atnaujinti sąrašą?") Then Exit Sub

            Using bm As New BindingsManager(CashOperationInfoListBindingSource, _
                Nothing, Nothing, False, False)

                Try
                    Obj = LoadObject(Of CashOperationInfoList)(Nothing, "GetCashOperationInfoList", _
                        True, Obj.Account, Obj.DateFrom, Obj.DateTo, Obj.Person)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try

                bm.SetNewDataSource(Obj.GetSortedList)

            End Using

            BalanceStartAccTextBox.DecimalValue = Obj.BalanceStart
            BalanceBookEntriesStartAccTextBox.DecimalValue = Obj.BalanceBookEntryStart
            BalanceLTLStartAccTextBox.DecimalValue = Obj.BalanceLTLStart
            TurnoverDebitAccTextBox.DecimalValue = Obj.TurnoverDebit
            TurnoverCreditAccTextBox.DecimalValue = Obj.TurnoverCredit
            TurnoverBookEntriesDebitAccTextBox.DecimalValue = Obj.TurnoverBookEntryDebit
            TurnoverBookEntriesCreditAccTextBox.DecimalValue = Obj.TurnoverBookEntryCredit
            TurnoverLTLDebitAccTextBox.DecimalValue = Obj.TurnoverLTLDebit
            TurnoverLTLCreditAccTextBox.DecimalValue = Obj.TurnoverLTLCredit
            TurnoverInListLTLDebitAccTextBox.DecimalValue = Obj.TurnOverInListLTLDebit
            TurnoverInListLTLCreditAccTextBox.DecimalValue = Obj.TurnoverInListLTLCredit
            BalanceEndAccTextBox.DecimalValue = Obj.BalanceEnd
            BalanceBookEntriesEndAccTextBox.DecimalValue = Obj.BalanceBookEntryEnd
            BalanceLTLEndAccTextBox.DecimalValue = Obj.BalanceLTLEnd

            CashOperationInfoListDataGridView.Select()

        Else ' edit object

            MDIParent1.LaunchForm(EditFormType, False, False, tmp.ID, tmp.ID)

        End If

    End Sub


    Public Function GetMailDropDownItems() As System.Windows.Forms.ToolStripDropDown _
       Implements ISupportsPrinting.GetMailDropDownItems

        If EmailDropDown Is Nothing Then
            EmailDropDown = New ToolStripDropDown
            EmailDropDown.Items.Add("Siųsti kasos knygą", Nothing, AddressOf OnMailClick)
        End If

        Return EmailDropDown

    End Function

    Public Function GetPrintDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintDropDownItems

        If PrintDropDown Is Nothing Then
            PrintDropDown = New ToolStripDropDown
            PrintDropDown.Items.Add("Spausdinti kasos knygą", Nothing, AddressOf OnPrintClick)
        End If

        Return PrintDropDown

    End Function

    Public Function GetPrintPreviewDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintPreviewDropDownItems

        If PrintPreviewDropDown Is Nothing Then
            PrintPreviewDropDown = New ToolStripDropDown
            PrintPreviewDropDown.Items.Add("Spausdinti kasos knygą", Nothing, AddressOf OnPrintPreviewClick)
        End If

        Return PrintPreviewDropDown

    End Function

    Public Sub OnMailClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnMailClick
        If Obj Is Nothing Then Exit Sub

        Using frm As New F_SendObjToEmail(Obj, _
            IIf(sender.Text.ToString.ToLower.Contains("kasos knygą"), 1, 0))
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, False, IIf(sender.Text.ToString.ToLower.Contains("kasos knygą"), 1, 0))
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, True, IIf(sender.Text.ToString.ToLower.Contains("kasos knygą"), 1, 0))
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function


    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList), _
            GetType(HelperLists.CashAccountInfoList)) Then Exit Function

        Try

            LoadCashAccountInfoListToGridCombo(AccountAccGridComboBox, True)
            LoadPersonInfoListToGridCombo(PersonAccGridComboBox, True, True, True, True)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

End Class