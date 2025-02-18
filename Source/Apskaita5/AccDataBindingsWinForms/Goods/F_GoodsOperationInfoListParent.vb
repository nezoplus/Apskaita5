﻿Imports ApskaitaObjects.ActiveReports
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists
Imports AccDataBindingsWinForms.Printing
Imports ApskaitaObjects.Attributes
Imports ApskaitaObjects.Documents

Friend Class F_GoodsOperationInfoListParent
    Implements ISupportsPrinting

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.GoodsInfoList), GetType(HelperLists.WarehouseInfoList)}

    Private _FormManager As CslaActionExtenderReportForm(Of GoodsOperationInfoListParent)
    Private _ListViewManager As DataListViewEditControlManager(Of GoodsOperationInfo)
    Private _QueryManager As CslaActionExtenderQueryObject

    Private _DateFrom As Date = Today
    Private _DateTo As Date = Today
    Private _GoodsID As Integer = 0
    Private _WarehouseID As Integer = 0


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal goodsID As Integer, _
        ByVal warehouseID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _DateFrom = dateFrom
        _DateTo = dateTo
        _GoodsID = goodsID
        _WarehouseID = warehouseID

    End Sub


    Private Sub F_GoodsOperationInfoListParent_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not PrepareCache(Me, _RequiredCachedLists) Then Exit Sub

        Try

            _ListViewManager = New DataListViewEditControlManager(Of GoodsOperationInfo) _
                (ItemsDataListView, ContextMenuStrip1, Nothing, Nothing, Nothing, Nothing)

            _ListViewManager.AddCancelButton = True
            _ListViewManager.AddButtonHandler("Keisti", "Keisti avanso apyskaitos duomenis.", _
                AddressOf ChangeItem)
            _ListViewManager.AddButtonHandler("Ištrinti", "Pašalinti avanso apyskaitos duomenis iš duomenų bazės.", _
                AddressOf DeleteItem)


            _ListViewManager.AddMenuItemHandler(ChangeItem_MenuItem, AddressOf ChangeItem)
            _ListViewManager.AddMenuItemHandler(DeleteItem_MenuItem, AddressOf DeleteItem)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            ' GoodsOperationInfoListParent.GetGoodsTurnoverInfoListParent(dateFrom, dateTo, goodsID, WarehouseInfo)
            _FormManager = New CslaActionExtenderReportForm(Of GoodsOperationInfoListParent) _
                (Me, GoodsOperationInfoListParentBindingSource, Nothing, _RequiredCachedLists, _
                 RefreshButton, ProgressFiller1, "GetGoodsTurnoverInfoListParent", AddressOf GetReportParams)

            _FormManager.ManageDataListViewStates(ItemsDataListView)

            PrepareControl(GoodsInfoAccGridComboBox, New GoodsFieldAttribute( _
                ValueRequiredLevel.Optional, TradedItemType.All))
            PrepareControl(WarehouseInfoAccGridComboBox, New WarehouseFieldAttribute( _
                ValueRequiredLevel.Optional))

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        DateFromAccDatePicker.Value = Today.Subtract(New TimeSpan(30, 0, 0, 0))

        If _GoodsID > 0 Then

            Dim goodsitem As HelperLists.GoodsInfo = HelperLists.GoodsInfoList.GetList.GetItem(_GoodsID)
            If goodsitem Is Nothing Then Exit Sub

            GoodsInfoAccGridComboBox.SelectedValue = goodsitem
            DateFromAccDatePicker.Value = _DateFrom
            DateToAccDatePicker.Value = _DateTo

            Dim warehouseitem As HelperLists.WarehouseInfo = HelperLists.WarehouseInfoList.GetList.GetItem(_WarehouseID)
            If Not warehouseitem Is Nothing Then WarehouseInfoAccGridComboBox.SelectedValue = warehouseitem

            RefreshButton.PerformClick()

        End If

    End Sub


    Private Function GetReportParams() As Object()

        Dim warehouse As HelperLists.WarehouseInfo = Nothing
        Try
            warehouse = DirectCast(WarehouseInfoAccGridComboBox.SelectedValue, HelperLists.WarehouseInfo)
        Catch ex As Exception
        End Try
        Dim goodsitemID As Integer = 0
        Try
            goodsitemID = DirectCast(GoodsInfoAccGridComboBox.SelectedValue, HelperLists.GoodsInfo).ID
        Catch ex As Exception
        End Try

        'GoodsOperationInfoListParent.GetGoodsTurnoverInfoListParent(DateFromDateTimePicker.Value.Date, _
        '    DateToDateTimePicker.Value.Date, goodsitemID, warehouse)
        Return New Object() {DateFromAccDatePicker.Value.Date, _
            DateToAccDatePicker.Value.Date, goodsitemID, warehouse}

    End Function

    Private Sub ChangeItem(ByVal item As GoodsOperationInfo)

        If item Is Nothing Then Exit Sub

        If ConvertLocalizedName(Of Goods.GoodsOperationType)(item.Type) = Goods.GoodsOperationType.TransferOfBalance Then
            OpenNewForm(Of Goods.GoodsComplexOperationTransferOfBalance)()
        Else
            'GoodsOperationManager.GetGoodsOperation(item)
            _QueryManager.InvokeQuery(Of GoodsOperationManager)(Nothing, "GetGoodsOperation", True, _
                AddressOf OpenObjectEditForm, item)
        End If

    End Sub

    Private Sub DeleteItem(ByVal item As GoodsOperationInfo)

        If item Is Nothing Then Exit Sub

        If item.ComplexOperationID > 0 Then
            If GoodsOperationManager.CheckIfGoodsOperationEditFormOpen(item.ComplexOperationID, _
                Utilities.ConvertLocalizedName(Of Goods.GoodsOperationType)(item.Type), True, _
                Utilities.ConvertLocalizedName(Of Goods.GoodsComplexOperationType)(item.ComplexType), _
                True, True) Then Exit Sub
        Else
            If GoodsOperationManager.CheckIfGoodsOperationEditFormOpen(item.ID, _
                Utilities.ConvertLocalizedName(Of Goods.GoodsOperationType)(item.Type), False, _
                Goods.GoodsComplexOperationType.BulkDiscard, True, True) Then Exit Sub
        End If

        If item.ComplexOperationID > 0 Then
            If Not YesOrNo("DĖMESIO. Pasirinkta operacija yra kompleksinė, sudaryta iš keleto paprastų operacijų, įskaitant bet neapsiribojant pasirinkta. Ištrynus šią operaciją kartu bus ištrinta ir kitos jai priklausančios operacijos. Ar tikrai norite pašalinti pasirinktos operacijos duomenis iš duomenų bazės?") Then Exit Sub
        Else
            If Not YesOrNo("Ar tikrai norite pašalinti pasirinktos operacijos duomenis iš duomenų bazės?") Then Exit Sub
        End If

        ' GoodsOperationManager.DeleteGoodsOperation(item)
        _QueryManager.InvokeQuery(Of GoodsOperationManager)(Nothing, "DeleteGoodsOperation", False, _
            AddressOf OnOperationDeleted, item)

    End Sub

    Private Sub OnOperationDeleted(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If exceptionHandled Then Exit Sub

        If Not YesOrNo("Operacijos duomenys sėkmingai pašalinti iš duomenų bazės." _
            & vbCrLf & "Atnaujinti ataskaitą?") Then Exit Sub

        RefreshButton.PerformClick()

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

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Using frm As New F_SendObjToEmail(_FormManager.DataSource, 0)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, False, 0, "PrekiuOperacijos", Me, _
                _ListViewManager.GetCurrentFilterDescription(), _
                _ListViewManager.GetDisplayOrderIndexes())
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, True, 0, "PrekiuOperacijos", Me, _
                _ListViewManager.GetCurrentFilterDescription(), _
                _ListViewManager.GetDisplayOrderIndexes())
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function

End Class