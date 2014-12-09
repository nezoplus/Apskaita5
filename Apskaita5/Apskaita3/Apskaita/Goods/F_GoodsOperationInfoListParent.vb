Imports ApskaitaObjects.Goods
Imports ApskaitaObjects.ActiveReports
Imports ApskaitaObjects.HelperLists
Public Class F_GoodsOperationInfoListParent
    Implements ISupportsPrinting

    Private Obj As GoodsOperationInfoListParent
    Private Loading As Boolean = True
    Private _DateFrom As Date = Today
    Private _DateTo As Date = Today
    Private _GoodsID As Integer = 0
    Private _WarehouseID As Integer = 0


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal nDateFrom As Date, ByVal nDateTo As Date, ByVal nGoodsID As Integer, _
        ByVal nWarehouseID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _DateFrom = nDateFrom
        _DateTo = nDateTo
        _GoodsID = nGoodsID
        _WarehouseID = nWarehouseID

    End Sub


    Private Sub F_GoodsOperationInfoListParent_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.GoodsInfoList), _
            GetType(HelperLists.WarehouseInfoList)) Then Exit Sub

    End Sub

    Private Sub F_GoodsOperationInfoListParent_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetDataGridViewLayOut(ItemsDataGridView)
        GetFormLayout(Me)
    End Sub

    Private Sub F_GoodsOperationInfoListParent_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        DateFromDateTimePicker.Value = Today.Subtract(New TimeSpan(30, 0, 0, 0))

        AddDGVColumnSelector(ItemsDataGridView)

        SetDataGridViewLayOut(ItemsDataGridView)
        SetFormLayout(Me)

        If _GoodsID > 0 Then

            Dim goodsitem As HelperLists.GoodsInfo = HelperLists.GoodsInfoList.GetList.GetItem(_GoodsID)
            If goodsitem Is Nothing Then Exit Sub

            GoodsInfoAccGridComboBox.SelectedValue = goodsitem
            DateFromDateTimePicker.Value = _DateFrom
            DateToDateTimePicker.Value = _DateTo

            Dim warehouseitem As WarehouseInfo = WarehouseInfoList.GetList.GetItem(_WarehouseID)
            If Not warehouseitem Is Nothing Then WarehouseInfoAccGridComboBox.SelectedValue = warehouseitem

            DoRefresh(_DateFrom, _DateTo, goodsitem.ID, warehouseitem)

        End If

    End Sub


    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Dim warehouse As WarehouseInfo = Nothing
        Try
            warehouse = DirectCast(WarehouseInfoAccGridComboBox.SelectedValue, WarehouseInfo)
        Catch ex As Exception
        End Try
        Dim goodsitemID As Integer = 0
        Try
            goodsitemID = DirectCast(GoodsInfoAccGridComboBox.SelectedValue, GoodsInfo).ID
        Catch ex As Exception
        End Try

        DoRefresh(DateFromDateTimePicker.Value.Date, DateToDateTimePicker.Value.Date, goodsitemID, warehouse)

    End Sub

    Private Sub ItemsDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles ItemsDataGridView.CellDoubleClick

        If e.RowIndex < 0 OrElse Obj Is Nothing Then Exit Sub

        Dim tmp As GoodsOperationInfo = Nothing
        Try
            tmp = CType(ItemsDataGridView.Rows(e.RowIndex).DataBoundItem, GoodsOperationInfo)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try
        If tmp Is Nothing Then
            MsgBox("Klaida. Nepavyko nustatyti pasirinktos operacijos su preke.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If


        Dim ats As String = Ask("", New ButtonStructure("Keisti", "Keisti operacijos duomenis."), _
            New ButtonStructure("Ištrinti", "Ištrinti operacijos duomenis iš duomenų bazės."), _
            New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        If ats <> "Keisti" AndAlso ats <> "Ištrinti" Then Exit Sub

        If ats = "Keisti" Then

            If tmp.ComplexOperationID > 0 Then

                Select Case ConvertEnumHumanReadable(Of GoodsComplexOperationType)(tmp.ComplexType)

                    Case GoodsComplexOperationType.BulkDiscard
                        MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationDiscard), False, False, _
                            tmp.ComplexOperationID, tmp.ComplexOperationID)
                    Case GoodsComplexOperationType.BulkPriceCut
                        MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationPriceCut), False, False, _
                            tmp.ComplexOperationID, tmp.ComplexOperationID)
                    Case GoodsComplexOperationType.InternalTransfer
                        MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationInternalTransfer), False, False, _
                            tmp.ComplexOperationID, tmp.ComplexOperationID)
                    Case GoodsComplexOperationType.Inventorization
                        MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationInventorization), False, False, _
                            tmp.ComplexOperationID, tmp.ComplexOperationID)
                    Case GoodsComplexOperationType.Production
                        MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationProduction), False, False, _
                            tmp.ComplexOperationID, tmp.ComplexOperationID)
                    Case GoodsComplexOperationType.TransferOfBalance
                        MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationTransferOfBalance), True, False, 0)

                End Select

            Else

                Select Case ConvertEnumHumanReadable(Of GoodsOperationType)(tmp.Type)
                    Case GoodsOperationType.Acquisition
                        If ConvertEnumHumanReadable(Of DocumentType)(tmp.JournalEntryType) _
                            = DocumentType.InvoiceMade Then
                            MDIParent1.LaunchForm(GetType(F_InvoiceMade), False, False, _
                                tmp.JournalEntryID, tmp.JournalEntryID)
                        ElseIf ConvertEnumHumanReadable(Of DocumentType)(tmp.JournalEntryType) _
                            = DocumentType.InvoiceReceived Then
                            MDIParent1.LaunchForm(GetType(F_InvoiceReceived), False, False, _
                                tmp.JournalEntryID, tmp.JournalEntryID)
                        Else
                            MDIParent1.LaunchForm(GetType(F_GoodsOperationAcquisition), _
                                False, False, tmp.ID, tmp.ID)
                        End If
                    Case GoodsOperationType.ConsignmentAdditionalCosts
                        If ConvertEnumHumanReadable(Of DocumentType)(tmp.JournalEntryType) _
                            = DocumentType.InvoiceMade Then
                            MDIParent1.LaunchForm(GetType(F_InvoiceMade), False, False, _
                                tmp.JournalEntryID, tmp.JournalEntryID)
                        ElseIf ConvertEnumHumanReadable(Of DocumentType)(tmp.JournalEntryType) _
                            = DocumentType.InvoiceReceived Then
                            MDIParent1.LaunchForm(GetType(F_InvoiceReceived), False, False, _
                                tmp.JournalEntryID, tmp.JournalEntryID)
                        Else
                            MDIParent1.LaunchForm(GetType(F_GoodsOperationAdditionalCosts), _
                                False, False, tmp.ID, tmp.ID)
                        End If
                    Case GoodsOperationType.ConsignmentDiscount
                        If ConvertEnumHumanReadable(Of DocumentType)(tmp.JournalEntryType) _
                            = DocumentType.InvoiceMade Then
                            MDIParent1.LaunchForm(GetType(F_InvoiceMade), False, False, _
                                tmp.JournalEntryID, tmp.JournalEntryID)
                        ElseIf ConvertEnumHumanReadable(Of DocumentType)(tmp.JournalEntryType) _
                            = DocumentType.InvoiceReceived Then
                            MDIParent1.LaunchForm(GetType(F_InvoiceReceived), False, False, _
                                tmp.JournalEntryID, tmp.JournalEntryID)
                        Else
                            MDIParent1.LaunchForm(GetType(F_GoodsOperationDiscount), _
                                False, False, tmp.ID, tmp.ID)
                        End If
                    Case GoodsOperationType.Discard
                        MDIParent1.LaunchForm(GetType(F_GoodsOperationDiscard), _
                            False, False, tmp.ID, tmp.ID)
                    Case GoodsOperationType.PriceCut
                        MDIParent1.LaunchForm(GetType(F_GoodsOperationPriceCut), _
                            False, False, tmp.ID, tmp.ID, False)
                    Case GoodsOperationType.Transfer
                        If ConvertEnumHumanReadable(Of DocumentType)(tmp.JournalEntryType) _
                            = DocumentType.InvoiceMade Then
                            MDIParent1.LaunchForm(GetType(F_InvoiceMade), False, False, _
                                tmp.JournalEntryID, tmp.JournalEntryID)
                        ElseIf ConvertEnumHumanReadable(Of DocumentType)(tmp.JournalEntryType) _
                            = DocumentType.InvoiceReceived Then
                            MDIParent1.LaunchForm(GetType(F_InvoiceReceived), False, False, _
                                tmp.JournalEntryID, tmp.JournalEntryID)
                        Else
                            MDIParent1.LaunchForm(GetType(F_GoodsOperationTransfer), _
                                False, False, tmp.ID, tmp.ID)
                        End If
                    Case GoodsOperationType.ValuationMethodChange
                        MDIParent1.LaunchForm(GetType(F_GoodsOperationValuationMethod), _
                            False, False, tmp.ID, tmp.ID, False)
                    Case GoodsOperationType.AccountDiscountsChange, _
                        GoodsOperationType.AccountPurchasesChange, _
                        GoodsOperationType.AccountSalesNetCostsChange, _
                        GoodsOperationType.AccountValueReductionChange
                        MDIParent1.LaunchForm(GetType(F_GoodsOperationAccountChange), _
                            False, False, tmp.ID, tmp.ID)
                End Select

            End If

        Else

            If Not YesOrNo("Ar tikrai norite pašalinti pasirinktos operacijos duomenis iš duomenų bazės?") Then Exit Sub

            Try
                Using busy As New StatusBusy

                    If tmp.ComplexOperationID > 0 Then

                        Select Case ConvertEnumHumanReadable(Of GoodsComplexOperationType) _
                            (tmp.ComplexType)

                            Case GoodsComplexOperationType.BulkDiscard

                                Goods.GoodsComplexOperationDiscard. _
                                    DeleteGoodsComplexOperationDiscard(tmp.ComplexOperationID)

                            Case GoodsComplexOperationType.BulkPriceCut

                                Goods.GoodsComplexOperationPriceCut. _
                                    DeleteGoodsComplexOperationPriceCut(tmp.ComplexOperationID)

                            Case GoodsComplexOperationType.InternalTransfer

                                Goods.GoodsComplexOperationInternalTransfer. _
                                    DeleteGoodsComplexOperationInternalTransfer(tmp.ComplexOperationID)

                            Case GoodsComplexOperationType.Inventorization

                                Goods.GoodsComplexOperationInventorization. _
                                    DeleteGoodsComplexOperationInventorization(tmp.ComplexOperationID)

                            Case GoodsComplexOperationType.Production

                                Goods.GoodsComplexOperationProduction. _
                                    DeleteGoodsComplexOperationProduction(tmp.ComplexOperationID)

                            Case GoodsComplexOperationType.TransferOfBalance

                                Goods.GoodsComplexOperationTransferOfBalance. _
                                    DeleteGoodsComplexOperationTransferOfBalance()

                        End Select

                    Else

                        Select Case ConvertEnumHumanReadable(Of GoodsOperationType)(tmp.Type)

                            Case GoodsOperationType.Acquisition

                                Goods.GoodsOperationAcquisition.DeleteGoodsOperationAcquisition(tmp.ID)

                            Case GoodsOperationType.ConsignmentAdditionalCosts

                                Goods.GoodsOperationAdditionalCosts.DeleteGoodsOperationAdditionalCosts(tmp.ID)

                            Case GoodsOperationType.ConsignmentDiscount

                                Goods.GoodsOperationDiscount.DeleteGoodsOperationDiscount(tmp.ID)

                            Case GoodsOperationType.Discard

                                Goods.GoodsOperationDiscard.DeleteGoodsOperationDiscard(tmp.ID)

                            Case GoodsOperationType.PriceCut

                                Goods.GoodsOperationPriceCut.DeleteGoodsOperationPriceCut(tmp.ID)

                            Case GoodsOperationType.Transfer

                                Goods.GoodsOperationTransfer.DeleteGoodsOperationTransfer(tmp.ID)

                            Case GoodsOperationType.ValuationMethodChange

                                Goods.GoodsOperationValuationMethod.DeleteGoodsOperationValuationMethod(tmp.ID)

                            Case GoodsOperationType.AccountDiscountsChange, _
                                GoodsOperationType.AccountPurchasesChange, _
                                GoodsOperationType.AccountSalesNetCostsChange, _
                                GoodsOperationType.AccountValueReductionChange

                                Goods.GoodsOperationAccountChange.DeleteGoodsOperationAccountChange(tmp.ID)

                        End Select

                    End If

                End Using
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            If Not YesOrNo("Operacijos duomenys sėkmingai pašalinti iš duomenų bazės." _
                & vbCrLf & "Atnaujinti ataskaitą?") Then Exit Sub

            DoRefresh(Obj.DateFrom, Obj.DateTo, Obj.GoodsTurnoverInfo.ID, Obj.Warehouse)

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


    Private Sub DoRefresh(ByVal nDateFrom As Date, ByVal nDateTo As Date, _
        ByVal nGoodsID As Integer, ByVal nWarehouse As WarehouseInfo)

        Using bm As New BindingsManager(GoodsOperationInfoListParentBindingSource, _
            ItemsBindingSource, Nothing, False, True)

            Try
                Obj = LoadObject(Of ActiveReports.GoodsOperationInfoListParent)(Nothing, _
                    "GetGoodsTurnoverInfoListParent", True, nDateFrom, nDateTo, nGoodsID, nWarehouse)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        ItemsDataGridView.Select()

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.GoodsInfoList), _
            GetType(HelperLists.WarehouseInfoList)) Then Exit Function

        Try

            LoadGoodsInfoListToGridCombo(GoodsInfoAccGridComboBox, True, Documents.TradedItemType.All)
            LoadWarehouseInfoListToGridCombo(WarehouseInfoAccGridComboBox, True)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

End Class