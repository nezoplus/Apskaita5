﻿Imports ApskaitaObjects.Goods
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.Printing
Imports AccDataBindingsWinForms.CachedInfoLists
Imports ApskaitaObjects.Attributes

Friend Class F_GoodsComplexOperationPriceCut
    Implements IObjectEditForm, ISupportsPrinting, ISupportsChronologicValidator

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.GoodsInfoList), GetType(HelperLists.AccountInfoList)}

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of GoodsComplexOperationPriceCut)
    Private _ListViewManager As DataListViewEditControlManager(Of GoodsOperationPriceCut)
    Private _QueryManager As CslaActionExtenderQueryObject

    Private _DocumentToEdit As GoodsComplexOperationPriceCut = Nothing


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If _FormManager Is Nothing OrElse _FormManager.DataSource Is Nothing Then
                If _DocumentToEdit Is Nothing OrElse _DocumentToEdit.IsNew Then
                    Return Integer.MinValue
                Else
                    Return _DocumentToEdit.ID
                End If
            End If
            Return _FormManager.DataSource.ID
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(GoodsComplexOperationPriceCut)
        End Get
    End Property


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal goodsID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal documentToEdit As GoodsComplexOperationPriceCut)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _DocumentToEdit = documentToEdit

    End Sub


    Private Sub F_GoodsComplexOperationPriceCut_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If _DocumentToEdit Is Nothing Then
            Try
                _DocumentToEdit = GoodsComplexOperationPriceCut.NewGoodsComplexOperationPriceCut
            Catch ex As Exception
                ShowError(ex, Nothing)
                DisableAllControls(Me)
                Exit Sub
            End Try
        End If

        If Not SetDataSources() Then Exit Sub

        Try

            _FormManager = New CslaActionExtenderEditForm(Of GoodsComplexOperationPriceCut) _
                (Me, GoodsComplexOperationPriceCutBindingSource, _DocumentToEdit, _
                _RequiredCachedLists, nOkButton, ApplyButton, nCancelButton, _
                Nothing, ProgressFiller1)

            _FormManager.ManageDataListViewStates(ItemsDataListView)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        ConfigureButtons()

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            _ListViewManager = New DataListViewEditControlManager(Of GoodsOperationPriceCut) _
                (ItemsDataListView, Nothing, AddressOf OnItemsDelete, _
                 Nothing, Nothing, _DocumentToEdit)

            _ListViewManager.AddCancelButton = False
            _ListViewManager.AddButtonHandler("Rodyti apribojimus", _
                "Rodyti apribojimus eilutei.", AddressOf OnItemClicked)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            SetupDefaultControls(Of GoodsComplexOperationDiscard)(Me, _
                GoodsComplexOperationPriceCutBindingSource, _DocumentToEdit)

            PrepareControl(CommonCostsAccountAccGridComboBox, _
                New AccountFieldAttribute(ValueRequiredLevel.Optional, False, 5, 6))

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function


    Private Sub OnItemsDelete(ByVal items As GoodsOperationPriceCut())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.OperationalLimit.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Eilučių pašalinti neleidžiama:{0}{1}", vbCrLf, _
                _FormManager.DataSource.OperationalLimit.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        For Each item As GoodsOperationPriceCut In items
            If Not item.OperationLimitations.FinancialDataCanChange Then
                MsgBox(String.Format("Klaida. Eilutės {0} pašalinti neleidžiama:{1}{2}", _
                item.GoodsName, vbCrLf, item.OperationLimitations.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
                Exit Sub
            End If
        Next
        For Each item As GoodsOperationPriceCut In items
            _FormManager.DataSource.Items.Remove(item)
        Next
    End Sub

    Private Sub OnItemClicked(ByVal item As GoodsOperationPriceCut)
        If item Is Nothing Then Exit Sub

        Dim limitations As String = item.OperationLimitations.FinancialDataCanChangeExplanation

        If String.IsNullOrEmpty(limitations.Trim) Then
            MsgBox("Jokie ribojimai šiai eilutei netaikomi.", MsgBoxStyle.Information, "Info")
        Else
            MsgBox("Taikomi ribojimai:" & vbCrLf & limitations.Trim, MsgBoxStyle.Information, "Info")
        End If

    End Sub

    Private Sub AddNewItemButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AddNewItemButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Dim ids As Integer() = GoodsOperationManager.RequestUserToChooseGoods()

        If ids Is Nothing OrElse ids.Length < 1 Then Exit Sub

        'GoodsPriceCutItemList.NewGoodsPriceCutItemList(ids, _FormManager.DataSource.OperationalLimit.BaseValidator)
        _QueryManager.InvokeQuery(Of GoodsPriceCutItemList)(Nothing, "NewGoodsPriceCutItemList", True, _
            AddressOf OnNewItemsFetched, ids, _FormManager.DataSource.OperationalLimit.BaseValidator)

    End Sub

    Private Sub OnNewItemsFetched(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If result Is Nothing Then Exit Sub

        Try
            _FormManager.DataSource.AddRange(DirectCast(result, GoodsPriceCutItemList))
        Catch ex As Exception
            ShowError(ex, New Object() {_FormManager.DataSource, result})
        End Try

    End Sub

    Private Sub RefreshCostsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshCostsButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        If _FormManager.DataSource.Items.Count < 1 Then
            MsgBox("Klaida. Nesuformuota nė viena eilutė.", MsgBoxStyle.Exclamation, "Klaida")
        End If

        'GoodsPriceInWarehouseItemList.GetGoodsPriceInWarehouseItemList(_FormManager.DataSource.Date, _
        '    _FormManager.DataSource.GetGoodsPriceInWarehouseParams())
        _QueryManager.InvokeQuery(Of GoodsPriceInWarehouseItemList)(Nothing, _
            "GetGoodsPriceInWarehouseItemList", True, AddressOf OnValueItemsFetched, _FormManager.DataSource.Date, _
            _FormManager.DataSource.GetGoodsPriceInWarehouseParams())

    End Sub

    Private Sub OnValueItemsFetched(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If result Is Nothing Then Exit Sub

        Dim warning As String = ""

        Try
            _FormManager.DataSource.RefreshValuesInWarehouse(DirectCast(result, GoodsPriceInWarehouseItemList), warning)
        Catch ex As Exception
            ShowError(ex, New Object() {_FormManager.DataSource, result})
            Exit Sub
        End Try

        If Not StringIsNullOrEmpty(warning) Then
            MsgBox(warning, MsgBoxStyle.Exclamation, "Įspėjimas")
        End If

    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click
        If _FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.JournalEntryID > 0 Then Exit Sub
        OpenJournalEntryEditForm(_QueryManager, _FormManager.DataSource.JournalEntryID)
    End Sub

    Private Sub SetCommonAccountCostsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles SetCommonAccountCostsButton.Click

        If _FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.Items.Count < 1 Then Exit Sub

        Dim selectedAccount As Long = 0
        Try
            selectedAccount = DirectCast(CommonCostsAccountAccGridComboBox.SelectedValue, Long)
        Catch ex As Exception
        End Try

        If Not selectedAccount > 0 Then Exit Sub

        Try
            _FormManager.DataSource.SetCommonAccountPriceCutCosts(selectedAccount)
        Catch ex As Exception
            ShowError(ex, New Object() {_FormManager.DataSource, selectedAccount})
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
        If _FormManager.DataSource Is Nothing Then Exit Sub

        Using frm As New F_SendObjToEmail(_FormManager.DataSource, 0)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, False, 0, "PrekiuNukainojimas", Me, "")
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, True, 0, "PrekiuNukainojimas", Me, "")
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function


    Public Function ChronologicContent() As String _
        Implements ISupportsChronologicValidator.ChronologicContent
        If _FormManager.DataSource Is Nothing Then Return ""
        Return _FormManager.DataSource.OperationalLimit.LimitsExplanation
    End Function

    Public Function HasChronologicContent() As Boolean _
        Implements ISupportsChronologicValidator.HasChronologicContent

        Return Not _FormManager.DataSource Is Nothing AndAlso _
            Not StringIsNullOrEmpty(_FormManager.DataSource.OperationalLimit.LimitsExplanation)

    End Function


    Private Sub _FormManager_DataSourceStateHasChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles _FormManager.DataSourceStateHasChanged
        ConfigureButtons()
    End Sub

    Private Sub ConfigureButtons()

        If _FormManager.DataSource Is Nothing Then Exit Sub

        AddNewItemButton.Enabled = Not _FormManager.DataSource Is Nothing AndAlso _FormManager.DataSource.OperationalLimit.FinancialDataCanChange
        RefreshCostsButton.Enabled = Not _FormManager.DataSource Is Nothing AndAlso _FormManager.DataSource.OperationalLimit.FinancialDataCanChange
        _ListViewManager.SetColumnReadOnly("AccountPriceCutCosts", (_FormManager.DataSource Is Nothing _
            OrElse Not _FormManager.DataSource.OperationalLimit.FinancialDataCanChange))
        _ListViewManager.SetColumnReadOnly("TotalValuePriceCut", (_FormManager.DataSource Is Nothing _
            OrElse Not _FormManager.DataSource.OperationalLimit.FinancialDataCanChange))

        nCancelButton.Enabled = Not _FormManager.DataSource Is Nothing AndAlso Not _FormManager.DataSource.IsNew
        nOkButton.Enabled = Not _FormManager.DataSource Is Nothing
        ApplyButton.Enabled = Not _FormManager.DataSource Is Nothing

        EditedBaner.Visible = Not _FormManager.DataSource Is Nothing AndAlso Not _FormManager.DataSource.IsNew

    End Sub

End Class