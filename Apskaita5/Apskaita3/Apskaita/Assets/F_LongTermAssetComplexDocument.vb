Imports ApskaitaObjects.Assets
Imports ApskaitaObjects.HelperLists
Public Class F_LongTermAssetComplexDocument
    Implements ISupportsPrinting

    Private Obj As LongTermAssetComplexDocument
    Private OperationID As Integer = -1
    Private Loading As Boolean = True

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal nOperationID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        OperationID = nOperationID

    End Sub

    Public ReadOnly Property CurrentID() As Integer
        Get
            If Obj Is Nothing OrElse Obj.IsNew Then Return -1
            Return Obj.ID
        End Get
    End Property

    Private Sub F_LongTermAssetComplexDocument_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_LongTermAssetComplexDocument_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not Obj Is Nothing AndAlso TypeOf Obj Is IIsDirtyEnough AndAlso _
            DirectCast(Obj, IIsDirtyEnough).IsDirtyEnough Then
            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))
            If answ <> "Taip" AndAlso answ <> "Ne" Then
                e.Cancel = True
                Exit Sub
            End If
            If answ = "Taip" Then
                If Not SaveObj() Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If

        If Not Obj Is Nothing AndAlso Obj.IsDirty Then CancelObj()

        GetDataGridViewLayOut(ChildListDataGridView)
        GetFormLayout(Me)

    End Sub

    Private Sub F_LongTermAssetComplexDocument_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not LongTermAssetComplexDocument.CanGetObject AndAlso OperationID > 0 Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        ElseIf Not LongTermAssetComplexDocument.CanAddObject AndAlso Not OperationID > 0 Then
            MsgBox("Klaida. Jūsų teisių nepakanka ilgalaikio turto duomenims tvarkyti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        Try
            If OperationID > 0 Then
                Obj = LoadObject(Of LongTermAssetComplexDocument)(Nothing, _
                    "GetLongTermAssetComplexDocument", True, OperationID)
            Else
                Dim customGroup As LongTermAssetCustomGroupInfo = Nothing
                Obj = LoadObject(Of LongTermAssetComplexDocument)(Nothing, _
                    "NewLongTermAssetComplexDocument", True, customGroup)
            End If
        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Exit Sub
        End Try

        LongTermAssetComplexDocumentBindingSource.DataSource = Obj

        ConfigureButtons()

        AddDGVColumnSelector(ChildListDataGridView)

        SetDataGridViewLayOut(ChildListDataGridView)
        SetFormLayout(Me)

    End Sub


    Private Sub TypeHumanReadableComboBox_SelectedIndexChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles TypeHumanReadableComboBox.SelectedIndexChanged

        If Loading OrElse TypeHumanReadableComboBox.SelectedIndex < 0 Then Exit Sub

        Using busy As New StatusBusy
            Obj.Type = ConvertEnumHumanReadable(Of LtaOperationType) _
                (TypeHumanReadableComboBox.SelectedItem.ToString)

            ConfigureButtons()
            JournalEntryInfoComboBox.SelectedIndex = -1
        End Using

    End Sub

    Private Sub RefreshJournalEntryInfoButton_Click(ByVal sender As System.Object, _
       ByVal e As System.EventArgs) Handles RefreshJournalEntryInfoButton.Click

        Dim JEList As ActiveReports.JournalEntryInfoList

        Try
            JEList = LoadObject(Of ActiveReports.JournalEntryInfoList)(Nothing, "GetList", True, _
                Obj.Date, Obj.Date, "", -1, -1, DocumentType.None, False, "", "")
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        JournalEntryInfoComboBox.DataSource = JEList

    End Sub

    Private Sub AttachJournalEntryInfoButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AttachJournalEntryInfoButton.Click

        If JournalEntryInfoComboBox.SelectedItem Is Nothing Then Exit Sub

        Using busy As New StatusBusy
            Try
                Obj.SetAttachedJournalEntry(CType(JournalEntryInfoComboBox.SelectedItem, _
                    ActiveReports.JournalEntryInfo))
            Catch ex As Exception
                ShowError(ex)
            End Try
        End Using

    End Sub

    Private Sub CalculateAmortizationButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CalculateAmortizationButton.Click

        If Obj Is Nothing OrElse Obj.Type <> LtaOperationType.Amortization Then Exit Sub

        If Not YesOrNo("Gauti amotizacijos apskaičiavimą operacijos datai?") Then Exit Sub

        Dim nAssetID, nOperationID As Integer()

        Try
            Obj.GetItemsIdsForAmortizationCalculationList(nAssetID, nOperationID)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        Dim AmortizationCalculation As LongTermAssetAmortizationCalculationList

        Try
            AmortizationCalculation = LoadObject(Of LongTermAssetAmortizationCalculationList) _
                (Nothing, "GetList", True, nAssetID, nOperationID, Obj.Date)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        Using busy As New StatusBusy
            Obj.SetAmortizationCalculation(AmortizationCalculation)
        End Using

    End Sub

    Private Sub ChildListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles ChildListDataGridView.CellDoubleClick

        If e.RowIndex < 0 OrElse Obj Is Nothing OrElse _
            Not Obj.Type = LtaOperationType.Amortization Then Exit Sub

        Dim SelectedItem As LongTermAssetOperationChild = Nothing
        Try
            SelectedItem = CType(ChildListDataGridView.Rows(e.RowIndex).DataBoundItem, _
                LongTermAssetOperationChild)
        Catch ex As Exception
        End Try
        If SelectedItem Is Nothing Then Exit Sub

        Using frm As New F_TextFieldEditor("Amortizacijos apskaičiavimas", _
            SelectedItem.AmortizationCalculations, False)
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then _
                SelectedItem.AmortizationCalculations = frm.TextField
        End Using

    End Sub


    Private Sub OkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OkButton.Click
        If SaveObj() Then Me.Close()
    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButton.Click
        If SaveObj() Then ConfigureButtons()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CancelButton.Click

        If Not Obj Is Nothing AndAlso Not Obj.IsNew Then
            CancelObj()
            ConfigureButtons()
        End If

    End Sub


    Private Sub NewItemButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewItemButton.Click

        If Not Obj Is Nothing AndAlso TypeOf Obj Is IIsDirtyEnough AndAlso _
            DirectCast(Obj, IIsDirtyEnough).IsDirtyEnough Then
            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))
            If answ <> "Taip" AndAlso answ <> "Ne" Then Exit Sub
            If answ = "Taip" Then
                If Not SaveObj() Then Exit Sub
            End If
        End If

        Dim CustomGroupFilter As LongTermAssetCustomGroupInfo = Nothing
        If Not LongTermAssetCustomGroupInfoComboBox.SelectedItem Is Nothing _
            AndAlso Not CType(LongTermAssetCustomGroupInfoComboBox.SelectedItem, _
            LongTermAssetCustomGroupInfo).ID < 0 Then CustomGroupFilter = _
            CType(LongTermAssetCustomGroupInfoComboBox.SelectedItem, LongTermAssetCustomGroupInfo)

        Using bm As New BindingsManager(LongTermAssetComplexDocumentBindingSource, _
            ChildListBindingSource, Nothing, True, True)

            Try
                Obj = LoadObject(Of LongTermAssetComplexDocument)(Nothing, _
                    "NewLongTermAssetComplexDocument", True, CustomGroupFilter)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        ConfigureButtons()

    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click

        If Obj Is Nothing OrElse Not Obj.JournalEntryID > 0 Then Exit Sub

        MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, _
            Obj.JournalEntryID, Obj.JournalEntryID)

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



    Private Function SaveObj() As Boolean

        If Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.GetAllBrokenRules, MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        Question = Obj.GetAllWarnings
        If Not String.IsNullOrEmpty(Question.Trim) Then Question = _
            "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf & Question
        If Obj.IsNew Then
            Question = Question & "Ar tikrai norite įtraukti naujus duomenis?"
            Answer = "Nauji duomenys sėkmingai įtraukti."
        Else
            Question = Question & "Ar tikrai norite pakeisti duomenis?"
            Answer = "Duomenys sėkmingai pakeisti."
        End If

        If Not YesOrNo(Question) Then Return False

        Using busy As New StatusBusy

            Using bm As New BindingsManager(LongTermAssetComplexDocumentBindingSource, _
                ChildListBindingSource, Nothing, True, False)

                Try
                    Obj = LoadObject(Of LongTermAssetComplexDocument)(Obj, "Save", False)
                Catch ex As Exception
                    ShowError(ex)
                    Return False
                End Try

                bm.SetNewDataSource(Obj)

            End Using

        End Using

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        NotifyLongTermAssetOperationListParent()

        ConfigureButtons()

        Return True

    End Function

    Private Sub CancelObj()
        Using bm As New BindingsManager(LongTermAssetComplexDocumentBindingSource, _
            ChildListBindingSource, Nothing, True, True)
        End Using
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(LongTermAssetCustomGroupInfoList), _
            GetType(HelperLists.AccountInfoList)) Then Exit Function

        Dim SupportedOperationTypes As New List(Of String)
        SupportedOperationTypes.Add(ConvertEnumHumanReadable(LtaOperationType.Amortization))
        SupportedOperationTypes.Add(ConvertEnumHumanReadable(LtaOperationType.Discard))
        SupportedOperationTypes.Add(ConvertEnumHumanReadable(LtaOperationType.ValueChange))
        SupportedOperationTypes.Add(ConvertEnumHumanReadable(LtaOperationType.UsingStart))
        SupportedOperationTypes.Add(ConvertEnumHumanReadable(LtaOperationType.UsingEnd))

        Try
            LoadAssetCustomGroupInfoListToCombo(LongTermAssetCustomGroupInfoComboBox, True)
            TypeHumanReadableComboBox.DataSource = SupportedOperationTypes
            LoadAccountInfoListToGridCombo(AccountCorrespondingAccGridComboBox, True, 1, 2, 6)
        Catch ex As Exception
            ShowError(ex)
            Return False
        End Try

        Return True

    End Function

    Private Sub ConfigureButtons()

        TypeHumanReadableComboBox.Enabled = Obj.IsNew

        AccountCorrespondingAccGridComboBox.Enabled = ((Obj.Type = LtaOperationType.AccountChange AndAlso Obj.IsNew) _
            OrElse Obj.Type = LtaOperationType.Amortization OrElse Obj.Type = LtaOperationType.Discard)
        ActNumberAccTextBox.ReadOnly = Not (Obj.Type = LtaOperationType.Discard OrElse _
            Obj.Type = LtaOperationType.UsingEnd OrElse Obj.Type = LtaOperationType.UsingStart)
        CalculateAmortizationButton.Enabled = (Obj.Type = LtaOperationType.Amortization)

        DataGridViewChangeUnitValueColumn.ReadOnly = Not (Obj.Type = LtaOperationType.AcquisitionValueIncrease _
            OrElse Obj.Type = LtaOperationType.Amortization _
            OrElse Obj.Type = LtaOperationType.ValueChange)
        DataGridViewAfterUnitValueColumn.ReadOnly = Not ( _
            Obj.Type = LtaOperationType.AcquisitionValueIncrease _
            OrElse Obj.Type = LtaOperationType.Amortization _
            OrElse Obj.Type = LtaOperationType.ValueChange)
        DataGridViewChangeValueColumn.ReadOnly = (Obj.Type = LtaOperationType.AccountChange _
            OrElse Obj.Type = LtaOperationType.AmortizationPeriod _
            OrElse Obj.Type = LtaOperationType.UsingEnd _
            OrElse Obj.Type = LtaOperationType.UsingStart)
        DataGridViewAfterValueColumn.ReadOnly = (Obj.Type = LtaOperationType.AccountChange _
            OrElse Obj.Type = LtaOperationType.AmortizationPeriod _
            OrElse Obj.Type = LtaOperationType.UsingEnd _
            OrElse Obj.Type = LtaOperationType.UsingStart)
        DataGridViewChangeRevaluedPortionUnitValueColumn.ReadOnly = Not (Obj.Type = LtaOperationType.Amortization _
            OrElse Obj.Type = LtaOperationType.ValueChange)
        DataGridViewAfterRevaluedPortionValueColumn.ReadOnly = Not ( _
            Obj.Type = LtaOperationType.Amortization _
            OrElse Obj.Type = LtaOperationType.ValueChange)
        DataGridViewChangeRevaluedPortionValueColumn.ReadOnly = Not (Obj.Type = LtaOperationType.Amortization _
            OrElse Obj.Type = LtaOperationType.Discard _
            OrElse Obj.Type = LtaOperationType.Transfer _
            OrElse Obj.Type = LtaOperationType.ValueChange)
        DataGridViewAfterRevaluedPortionUnitValueColumn.ReadOnly = Not ( _
            Obj.Type = LtaOperationType.Amortization _
            OrElse Obj.Type = LtaOperationType.Discard _
            OrElse Obj.Type = LtaOperationType.Transfer _
            OrElse Obj.Type = LtaOperationType.ValueChange)
        DataGridViewChangeAmmountColumn.ReadOnly = Not (Obj.Type = LtaOperationType.Discard _
            OrElse Obj.Type = LtaOperationType.Transfer)

        AttachJournalEntryInfoButton.Enabled = (Obj.Type = LtaOperationType.AcquisitionValueIncrease _
            OrElse Obj.Type = LtaOperationType.Transfer _
            OrElse Obj.Type = LtaOperationType.ValueChange)
        RefreshJournalEntryInfoButton.Enabled = (Obj.Type = LtaOperationType.AcquisitionValueIncrease _
            OrElse Obj.Type = LtaOperationType.Transfer _
            OrElse Obj.Type = LtaOperationType.ValueChange)
        JournalEntryInfoComboBox.Enabled = (Obj.Type = LtaOperationType.AcquisitionValueIncrease _
            OrElse Obj.Type = LtaOperationType.Transfer _
            OrElse Obj.Type = LtaOperationType.ValueChange)
        If Not JournalEntryInfoComboBox.Enabled Then JournalEntryInfoComboBox.SelectedIndex = -1

        EditedBaner.Visible = Not Obj.IsNew
        CancelButton.Enabled = Not Obj.IsNew

        ViewJournalEntryButton.Visible = Not Obj Is Nothing

    End Sub

    Private Sub NotifyLongTermAssetOperationListParent()
        For Each frm As Form In MDIParent1.MdiChildren
            If TypeOf frm Is F_LongTermAssetOperationInfoListParent Then
                For Each item As LongTermAssetOperationChild In Obj.ChildList
                    CType(frm, F_LongTermAssetOperationInfoListParent). _
                        NotifyAboutOperationListChanges(item.AssetID)
                Next
            End If
        Next
    End Sub

End Class