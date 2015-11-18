Imports ApskaitaObjects.ActiveReports

Public Class F_AccountTurnoverInfo
    Implements ISupportsPrinting

    Private Obj As ActiveReports.BookEntryInfoListParent
    Private Loading As Boolean = True
    Private _DateFrom, _DateTo As Date
    Private _AccountNumber As Long = 0
    Private _PersonID As Integer = 0


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal nAccountNumber As Long, ByVal nDateFrom As Date, _
        ByVal nDateTo As Date, Optional ByVal nPersonID As Integer = 0)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _AccountNumber = nAccountNumber
        _DateFrom = nDateFrom
        _DateTo = nDateTo
        _PersonID = nPersonID

    End Sub


    Private Sub F_AccountTurnoverInfo_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList), _
            GetType(HelperLists.PersonInfoList), GetType(HelperLists.PersonGroupInfoList)) Then Exit Sub

    End Sub

    Private Sub F_AccountTurnoverInfo_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetDataGridViewLayOut(ItemsDataGridView)
        GetFormLayout(Me)
    End Sub

    Private Sub F_AccountTurnoverInfo_Load(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        DateFromDateTimePicker.Value = Today.AddMonths(-1)

        AddDGVColumnSelector(ItemsDataGridView)

        SetDataGridViewLayOut(ItemsDataGridView)
        SetFormLayout(Me)

        Me.EditToolStripMenuItem.Text = GeneralLedger_EditLabel
        Me.EditToolStripMenuItem.ToolTipText = GeneralLedger_EditTooltipLabel
        Me.DeleteToolStripMenuItem.Text = GeneralLedger_DeleteLabel
        Me.DeleteToolStripMenuItem.ToolTipText = GeneralLedger_DeleteTooltipLabel
        Me.CorrespondationsToolStripMenuItem.Text = GeneralLedger_CorrespondencesLabel
        Me.CorrespondationsToolStripMenuItem.ToolTipText = GeneralLedger_CorrespondencesTooltipLabel
        Me.RelationsToolStripMenuItem.Text = GeneralLedger_RelationsLabel
        Me.RelationsToolStripMenuItem.ToolTipText = GeneralLedger_RelationsTooltipLabel
        Me.CancelToolStripMenuItem.Text = GeneralLedger_CancelLabel
        Me.CancelToolStripMenuItem.ToolTipText = GeneralLedger_CancelTooltipLabel

        If _AccountNumber > 0 Then
            AccountAccGridComboBox.SelectedValue = _AccountNumber
            DateFromDateTimePicker.Value = _DateFrom
            DateToDateTimePicker.Value = _DateTo
            If _PersonID > 0 Then
                For Each p As HelperLists.PersonInfo In HelperLists.PersonInfoList.GetList
                    If p.ID = _PersonID Then
                        PersonAccGridComboBox.SelectedValue = p
                        Exit For
                    End If
                Next
            End If
            RefreshButton.PerformClick()
        End If

    End Sub


    Private Sub ItemsDataGridView_CellMouseClick(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) _
        Handles ItemsDataGridView.CellMouseClick

        If e.Button <> Windows.Forms.MouseButtons.Right OrElse e.RowIndex < 0 Then Exit Sub

        Dim currentItem As BookEntryInfo = Nothing
        Try
            currentItem = CType(ItemsDataGridView.Rows(e.RowIndex).DataBoundItem, _
                BookEntryInfo)
        Catch ex As Exception
        End Try
        If currentItem Is Nothing Then Exit Sub

        ItemsDataGridView.ClearSelection()
        ItemsDataGridView.Rows(e.RowIndex).Selected = True

        Me.ContextMenuStrip1.Tag = currentItem
        Me.CorrespondationsToolStripMenuItem.Visible = (currentItem.DocType <> DocumentType.None)
        Me.EditToolStripMenuItem.Visible = (currentItem.DocType <> DocumentType.ClosingEntries)
        Me.DeleteToolStripMenuItem.Visible = (currentItem.DocType = DocumentType.None OrElse _
            currentItem.DocType = DocumentType.TransferOfBalance OrElse _
            currentItem.DocType = DocumentType.ClosingEntries OrElse _
            currentItem.DocType = DocumentType.Offset OrElse _
            currentItem.DocType = DocumentType.AccumulatedCosts)

        Me.ContextMenuStrip1.Show(ItemsDataGridView, ItemsDataGridView.PointToClient(Cursor.Position))

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click, _
        DeleteToolStripMenuItem.Click, CorrespondationsToolStripMenuItem.Click, _
        RelationsToolStripMenuItem.Click

        Dim currentItem As BookEntryInfo = Nothing
        Try
            currentItem = DirectCast(Me.ContextMenuStrip1.Tag, BookEntryInfo)
        Catch ex As Exception
        End Try

        If currentItem Is Nothing Then
            MsgBox("Klaida. Nepavyko nustatyti pasirinktos eilutės.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Select Case DirectCast(sender, ToolStripMenuItem).Text.Trim
            Case GeneralLedger_EditLabel.Trim
                OpenDocumentInEditForm(currentItem.JournalEntryID, currentItem.DocType)
            Case GeneralLedger_DeleteLabel.Trim
                DeleteEntry(currentItem)
            Case GeneralLedger_CorrespondencesLabel.Trim
                MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, _
                    currentItem.JournalEntryID, currentItem.JournalEntryID)
            Case GeneralLedger_RelationsLabel.Trim
                MDIParent1.LaunchForm(GetType(F_IndirectRelationInfoList), False, False, _
                    currentItem.JournalEntryID, currentItem.JournalEntryID)
            Case Else
                MsgBox("Klaida. Neimplementuotas operacijos tipas '" & _
                    DirectCast(sender, ToolStripMenuItem).Text.Trim & "'.", _
                    MsgBoxStyle.Exclamation, "Klaida")
        End Select

    End Sub

    Private Sub ItemsDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles ItemsDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        ' get the selected book entry
        Dim currentItem As BookEntryInfo = Nothing
        Try
            currentItem = CType(ItemsDataGridView.Rows(e.RowIndex).DataBoundItem, BookEntryInfo)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        If currentItem Is Nothing Then
            MsgBox("Klaida. Nepavyko nustatyti pasirinkto bendrojo žurnalo įrašo.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Dim buttonList As New List(Of ButtonStructure)
        If currentItem.DocType <> DocumentType.ClosingEntries Then buttonList.Add( _
            New ButtonStructure(GeneralLedger_EditLabel, GeneralLedger_EditTooltipLabel))
        If currentItem.DocType = DocumentType.None OrElse _
            currentItem.DocType = DocumentType.TransferOfBalance OrElse _
            currentItem.DocType = DocumentType.ClosingEntries OrElse _
            currentItem.DocType = DocumentType.Offset OrElse _
            currentItem.DocType = DocumentType.AccumulatedCosts OrElse _
            currentItem.DocType = DocumentType.HolidayReserve Then buttonList.Add( _
            New ButtonStructure(GeneralLedger_DeleteLabel, GeneralLedger_DeleteTooltipLabel))
        If currentItem.DocType <> DocumentType.None Then buttonList.Add( _
            New ButtonStructure(GeneralLedger_CorrespondencesLabel, GeneralLedger_CorrespondencesTooltipLabel))
        buttonList.Add(New ButtonStructure(GeneralLedger_RelationsLabel, GeneralLedger_RelationsTooltipLabel))
        buttonList.Add(New ButtonStructure(GeneralLedger_CancelLabel, GeneralLedger_CancelTooltipLabel))

        ' ask what to do
        Dim ats As String = Ask("", buttonList.ToArray)

        If ats <> GeneralLedger_EditLabel AndAlso ats <> GeneralLedger_DeleteLabel _
            AndAlso ats <> GeneralLedger_CorrespondencesLabel AndAlso _
            ats <> GeneralLedger_RelationsLabel Then Exit Sub

        If ats = GeneralLedger_EditLabel Then

            OpenDocumentInEditForm(currentItem.JournalEntryID, currentItem.DocType)

        ElseIf ats = GeneralLedger_CorrespondencesLabel Then

            MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, _
                currentItem.JournalEntryID, currentItem.JournalEntryID)

        ElseIf ats = GeneralLedger_RelationsLabel Then

            MDIParent1.LaunchForm(GetType(F_IndirectRelationInfoList), False, False, _
                currentItem.JournalEntryID, currentItem.JournalEntryID)

        Else

            DeleteEntry(currentItem)

        End If

    End Sub

    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Dim nPerson As HelperLists.PersonInfo = Nothing
        If PersonAccGridComboBox.SelectedValue IsNot Nothing Then _
            nPerson = CType(PersonAccGridComboBox.SelectedValue, HelperLists.PersonInfo)
        Dim nGroup As HelperLists.PersonGroupInfo = Nothing
        If PersonGroupComboBox.SelectedItem IsNot Nothing Then _
            nGroup = CType(PersonGroupComboBox.SelectedItem, HelperLists.PersonGroupInfo)
        Dim nAccount As Long = 0
        Try
            nAccount = Convert.ToInt64(AccountAccGridComboBox.SelectedValue)
        Catch ex As Exception
        End Try

        Using bm As New BindingsManager(BookEntryInfoListParentBindingSource, _
            ItemsBindingSource, Nothing, False, True)

            Try
                Obj = LoadObject(Of BookEntryInfoListParent)(Nothing, _
                    "GetBookEntryInfoListParent", True, DateFromDateTimePicker.Value.Date, _
                    DateToDateTimePicker.Value.Date, nAccount, nPerson, nGroup, _
                    IncludeSubAccountsCheckBox.Checked)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        ItemsDataGridView.Select()

    End Sub

    Private Sub ClearButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ClearButton.Click
        DateFromDateTimePicker.Value = Today
        DateToDateTimePicker.Value = Today
        AccountAccGridComboBox.SelectedValue = Nothing
        PersonAccGridComboBox.SelectedValue = Nothing
        PersonGroupComboBox.SelectedIndex = -1
        IncludeSubAccountsCheckBox.Checked = False
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

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList), _
            GetType(HelperLists.PersonInfoList), GetType(HelperLists.PersonGroupInfoList)) Then Return False

        Try
            LoadPersonGroupInfoListToCombo(PersonGroupComboBox)
            LoadAccountInfoListToGridCombo(AccountAccGridComboBox, True)
            LoadPersonInfoListToGridCombo(PersonAccGridComboBox, True, True, True, True)
        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Private Sub DeleteEntry(ByVal currentItem As BookEntryInfo)

        If currentItem Is Nothing Then
            MsgBox("Klaida. Nenustatyta operacija.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        If currentItem.DocType = DocumentType.ClosingEntries Then
            If Not YesOrNo("Ar tikrai norite pašalinti 5/6 klasių uždarymo duomenis iš duomenų bazės?") Then Exit Sub
        ElseIf currentItem.DocType = DocumentType.None Then
            If Not YesOrNo("Ar tikrai norite pašalinti bendrojo žurnalo įrašo duomenis iš duomenų bazės?") Then Exit Sub
        Else
            If Not YesOrNo("Ar tikrai norite pašalinti dokumento duomenis iš duomenų bazės?") Then Exit Sub
        End If

        Try
            Using busy As New StatusBusy
                If currentItem.DocType = DocumentType.Offset Then
                    Documents.Offset.DeleteOffset(currentItem.JournalEntryID)
                ElseIf currentItem.DocType = DocumentType.AccumulatedCosts Then
                    Documents.AccumulativeCosts.DeleteAccumulativeCosts(currentItem.JournalEntryID)
                ElseIf currentItem.DocType = DocumentType.TransferOfBalance Then
                    General.TransferOfBalance.DeleteTransferOfBalance()
                ElseIf currentItem.DocType = DocumentType.HolidayReserve Then
                    Workers.HolidayPayReserve.DeleteHolidayPayReserve(currentItem.JournalEntryID)
                Else
                    General.JournalEntry.DeleteJournalEntry(currentItem.JournalEntryID)
                End If
            End Using
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        Dim SuccessMessage As String = "Dokumento duomenys sėkmingai pašalinti iš įmonės duomenų bazės."
        If currentItem.DocType = DocumentType.ClosingEntries Then
            SuccessMessage = "5/6 klasių uždarymo duomenys sėkmingai pašalinti iš įmonės duomenų bazės."
        ElseIf currentItem.DocType = DocumentType.None Then
            SuccessMessage = "Bendojo žurnalo įrašo duomenys sėkmingai pašalinti iš įmonės duomenų bazės."
        End If

        If Not YesOrNo(SuccessMessage & vbCrLf & "Atnaujinti ataskaitos duomenis?") Then Exit Sub

        Me.RefreshButton_Click(Me, New EventArgs)

    End Sub

End Class



