Imports ApskaitaObjects.Goods
Imports ApskaitaObjects.HelperLists
Public Class F_GoodsComplexOperationProduction
    Implements IObjectEditForm, ISupportsPrinting

    Private Obj As GoodsComplexOperationProduction = Nothing
    Private Loading As Boolean = True
    Private OperationID As Integer = 0
    Private GoodsID As Integer = 0
    Private CalculationID As Integer = 0


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If Not Obj Is Nothing Then Return Obj.ID
            Return 0
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(GoodsComplexOperationProduction)
        End Get
    End Property


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

    Public Sub New(ByVal nGoodsID As Integer, ByVal nCalculationID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GoodsID = nGoodsID
        CalculationID = nCalculationID

    End Sub



    Private Sub F_GoodsComplexOperationProduction_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.GoodsInfoList), _
            GetType(HelperLists.WarehouseInfoList), GetType(HelperLists.AccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_GoodsComplexOperationProduction_FormClosing(ByVal sender As Object, _
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

        GetFormLayout(Me)
        GetDataGridViewLayOut(ComponentItemsDataGridView)
        GetDataGridViewLayOut(CostsItemsDataGridView)

    End Sub

    Private Sub F_GoodsComplexOperationProduction_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not GoodsComplexOperationProduction.CanGetObject AndAlso OperationID > 0 Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        ElseIf Not GoodsComplexOperationProduction.CanAddObject AndAlso Not OperationID > 0 Then
            MsgBox("Klaida. Jūsų teisių nepakanka prekių duomenims tvarkyti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        If OperationID > 0 Then

            Try
                Obj = LoadObject(Of GoodsComplexOperationProduction)(Nothing, _
                    "GetGoodsComplexOperationProduction", True, OperationID)
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

        ElseIf CalculationID > 0 Then

            Try
                Obj = LoadObject(Of GoodsComplexOperationProduction)(Nothing, _
                    "NewGoodsComplexOperationProduction", True, GoodsID, CalculationID)
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

        Else

            Try
                Obj = LoadObject(Of GoodsComplexOperationProduction)(Nothing, _
                    "NewGoodsComplexOperationProduction", True, GoodsID)
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

        End If

        GoodsComplexOperationProductionBindingSource.DataSource = Obj

        AddDGVColumnSelector(ComponentItemsDataGridView)
        AddDGVColumnSelector(CostsItemsDataGridView)

        SetDataGridViewLayOut(ComponentItemsDataGridView)
        SetDataGridViewLayOut(CostsItemsDataGridView)
        SetFormLayout(Me)

        ConfigureLimitationButton(Obj)
        ConfigureButtons()

        Dim h As New EditableDataGridViewHelper(ComponentItemsDataGridView)
        Dim g As New EditableDataGridViewHelper(CostsItemsDataGridView)

    End Sub


    Private Sub OkButton_Click(ByVal sender As System.Object, _
       ByVal e As System.EventArgs) Handles nOkButton.Click
        If Obj Is Nothing Then Exit Sub
        If SaveObj() Then Me.Close()
    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButton.Click
        If Obj Is Nothing Then Exit Sub
        If SaveObj() Then ConfigureButtons()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles nCancelButton.Click
        If Obj Is Nothing Then Exit Sub
        CancelObj()
    End Sub


    Private Sub AddNewItemButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AddNewItemButton.Click

        If Obj Is Nothing Then Exit Sub

        Dim newGoodsInfo As HelperLists.GoodsInfo = Nothing
        Try
            newGoodsInfo = DirectCast(GoodsInfoListAccGridComboBox.SelectedValue, HelperLists.GoodsInfo)
        Catch ex As Exception
        End Try

        If newGoodsInfo Is Nothing OrElse Not newGoodsInfo.ID > 0 Then
            MsgBox("Klaida. Nepasirinkta prekė.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Try
            Dim newItem As GoodsComponentItem = LoadObject(Of GoodsComponentItem) _
                (Nothing, "NewGoodsComponentItem", True, newGoodsInfo.ID, _
                Obj.ChronologyValidatorDiscard.BaseValidator)
            Obj.AddNewComponentItem(newItem)
        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Private Sub RefreshCostsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshCostsButton.Click

        If Obj Is Nothing Then Exit Sub

        If Obj.WarehouseForComponents Is Nothing OrElse Not Obj.WarehouseForComponents.ID > 0 Then
            MsgBox("Klaida. Nepasirinktas sandėlis.", MsgBoxStyle.Exclamation, "Klaida")
        ElseIf Obj.ComponentItems.Count < 1 Then
            MsgBox("Klaida. Nesuformuota nė viena eilutė.", MsgBoxStyle.Exclamation, "Klaida")
        End If

        Try
            Dim CostItemList As GoodsCostItemList = LoadObject(Of GoodsCostItemList) _
                (Nothing, "GetGoodsCostItemList", True, New Object() {Obj.GetCostsParams()})
            Obj.ReloadCostInfo(CostItemList)
        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Private Sub LimitationsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LimitationsButton.Click

        If Obj Is Nothing Then Exit Sub

        MsgBox(Obj.ChronologyValidatorDiscard.LimitsExplanation & vbCrLf & vbCrLf & _
            Obj.ChronologyValidatorAcquisition.LimitsExplanation, MsgBoxStyle.Information, "")

    End Sub


    Private Sub ComponentItemsDataGridView_CellBeginEdit(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) _
        Handles ComponentItemsDataGridView.CellBeginEdit

        Dim curItem As GoodsComponentItem = Nothing
        Try
            curItem = DirectCast(ComponentItemsDataGridView.Rows(e.RowIndex).DataBoundItem, GoodsComponentItem)
        Catch ex As Exception
        End Try

        If curItem Is Nothing OrElse (ComponentItemsDataGridView.Columns(e.ColumnIndex) _
            Is AmountPerProductionUnit AndAlso curItem.AmountPerProductionUnitIsReadOnly) OrElse _
            (ComponentItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn9 _
            AndAlso curItem.AmountIsReadOnly) OrElse _
            (ComponentItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn10 _
            AndAlso curItem.NormativeUnitCostIsReadOnly) OrElse _
            (ComponentItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn13 _
            AndAlso curItem.AccountContraryIsReadOnly) Then
            e.Cancel = True
            Exit Sub
        End If

    End Sub

    Private Sub ComponentItemsDataGridView_UserDeletingRow(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) _
        Handles ComponentItemsDataGridView.UserDeletingRow

        Dim curItem As GoodsComponentItem = Nothing
        Try
            curItem = DirectCast(e.Row.DataBoundItem, GoodsComponentItem)
        Catch ex As Exception
        End Try

        If curItem Is Nothing Then
            MsgBox("Klaida. Neidentifikuota norima ištrinti eilutė.", MsgBoxStyle.Exclamation, "Klaida")
            e.Cancel = True
            Exit Sub
        End If

        If Not curItem.IsNew AndAlso Not curItem.GetChronologyValidator.FinancialDataCanChange Then
            MsgBox("Klaida. Šios eilutės duomenų pašalinti negalima:" & vbCrLf _
                & curItem.GetChronologyValidator.FinancialDataCanChangeExplanation, MsgBoxStyle.Exclamation, "Klaida")
            e.Cancel = True
            Exit Sub
        End If

    End Sub

    Private Sub CostsItemsDataGridView_CellBeginEdit(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) _
        Handles CostsItemsDataGridView.CellBeginEdit

        If Not Obj.ChronologyValidatorDiscard.FinancialDataCanChange Then
            e.Cancel = True
            Exit Sub
        End If

    End Sub

    Private Sub CostsItemsDataGridView_UserDeletingRow(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) _
        Handles CostsItemsDataGridView.UserDeletingRow

        If Not Obj.ChronologyValidatorDiscard.FinancialDataCanChange Then
            MsgBox("Klaida. Trinti ar keisti sąnaudų eilučių neleidžiama: " & vbCrLf _
                & Obj.ChronologyValidatorDiscard.FinancialDataCanChangeExplanation, _
                MsgBoxStyle.Exclamation, "Klaida")
            e.Cancel = True
            Exit Sub
        End If

    End Sub


    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click
        If Obj Is Nothing OrElse Not Obj.JournalEntryID > 0 Then Exit Sub
        MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, _
            Obj.JournalEntryID, Obj.JournalEntryID)
    End Sub

    Private Sub RecalculateForProductionAmountButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RecalculateForProductionAmountButton.Click

        If Obj Is Nothing Then Exit Sub

        Try
            Obj.RecalculateForProductionAmount()
        Catch ex As Exception
            ShowError(ex)
        End Try

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

        If Obj Is Nothing OrElse Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.GetAllBrokenRules, _
                MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        If Not String.IsNullOrEmpty(Obj.GetAllWarnings.Trim) Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf & Obj.GetAllWarnings & vbCrLf
        Else
            Question = ""
        End If
        If Obj.IsNew Then
            Question = Question & "Ar tikrai norite įtraukti naujus duomenis?"
            Answer = "Nauji duomenys sėkmingai įtraukti."
        Else
            Question = Question & "Ar tikrai norite pakeisti duomenis?"
            Answer = "Duomenys sėkmingai pakeisti."
        End If

        If Not YesOrNo(Question) Then Return False

        Using bm As New BindingsManager(GoodsComplexOperationProductionBindingSource, _
            ComponentItemsBindingSource, CostsItemsBindingSource, True, False)

            Try
                Obj = LoadObject(Of GoodsComplexOperationProduction)(Obj, "Save", False)
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj()
        If Obj Is Nothing OrElse Obj.IsNew Then Exit Sub
        Using bm As New BindingsManager(GoodsComplexOperationProductionBindingSource, _
            ComponentItemsBindingSource, CostsItemsBindingSource, True, True)
        End Using
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.GoodsInfoList), _
            GetType(HelperLists.WarehouseInfoList), GetType(HelperLists.AccountInfoList)) Then Return False

        Try

            LoadGoodsInfoListToGridCombo(GoodsInfoListAccGridComboBox, True, Documents.TradedItemType.All)
            LoadAccountInfoListToGridCombo(DataGridViewTextBoxColumn13, True, 2, 6)
            LoadAccountInfoListToGridCombo(DataGridViewTextBoxColumn1, True, 6)
            LoadWarehouseInfoListToGridCombo(WarehouseForProductionAccGridComboBox, False)
            LoadWarehouseInfoListToGridCombo(WarehouseForComponentsAccGridComboBox, False)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Private Sub ConfigureButtons()

        If Obj Is Nothing Then Exit Sub

        WarehouseForComponentsAccGridComboBox.Enabled = Not Obj Is Nothing AndAlso _
            Not Obj.WarehouseForComponentsIsReadOnly
        WarehouseForProductionAccGridComboBox.Enabled = Not Obj Is Nothing AndAlso _
            Not Obj.WarehouseForProductionIsReadOnly
        AmountAccTextBox.ReadOnly = Obj Is Nothing OrElse Obj.AmountIsReadOnly

        CostsItemsDataGridView.ReadOnly = Obj Is Nothing OrElse _
            Not Obj.ChronologyValidatorDiscard.FinancialDataCanChange

        nCancelButton.Enabled = Not Obj Is Nothing AndAlso Not Obj.IsNew
        nOkButton.Enabled = Not Obj Is Nothing
        ApplyButton.Enabled = Not Obj Is Nothing

        EditedBaner.Visible = Not Obj Is Nothing AndAlso Not Obj.IsNew

    End Sub

    Private Sub ConfigureLimitationButton(ByVal asset As GoodsComplexOperationProduction)

        If Not asset.ChronologyValidatorAcquisition.FinancialDataCanChange OrElse _
            asset.ChronologyValidatorAcquisition.MaxDateApplicable OrElse _
            asset.ChronologyValidatorAcquisition.MinDateApplicable OrElse _
            Not asset.ChronologyValidatorDiscard.FinancialDataCanChange OrElse _
            asset.ChronologyValidatorDiscard.MaxDateApplicable OrElse _
            asset.ChronologyValidatorDiscard.MinDateApplicable Then
            LimitationsButton.Visible = True
            LimitationsButton.Image = My.Resources.Action_lock_icon_32p
        Else
            LimitationsButton.Visible = False
        End If

    End Sub

End Class