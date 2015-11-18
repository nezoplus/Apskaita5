Imports ApskaitaObjects.ActiveReports
Imports ApskaitaObjects.Documents
Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.Documents.InvoiceAdapters

Public Class F_AttachedObjectChooser

    Private Loading As Boolean = True
    Private _ForInvoiceReceived As Boolean = False
    Private _ParentChronologyValidator As IChronologicValidator = Nothing
    Private _Value As IInvoiceAdapter = Nothing


    Public ReadOnly Property Value() As IInvoiceAdapter
        Get
            Return _Value
        End Get
    End Property


    Public Sub New(ByVal forInvoiceReceived As Boolean, ByVal parentChronologyValidator As IChronologicValidator)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _ForInvoiceReceived = forInvoiceReceived
        _ParentChronologyValidator = parentChronologyValidator

    End Sub


    Private Sub F_AttachedObjectChooser_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized Then Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.ServiceInfoList), _
            GetType(HelperLists.GoodsInfoList), GetType(HelperLists.WarehouseInfoList)) Then Exit Sub

    End Sub

    Private Sub F_AttachedObjectChooser_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetFormLayout(Me)
        If _Value Is Nothing Then
            Me.DialogResult = DialogResult.Cancel
        Else
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub F_AttachedObjectChooser_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        SetFormLayout(Me)

        If _ForInvoiceReceived AndAlso MyCustomSettings.DefaultInvoiceReceivedItemIsGoods Then
            GoodsAcquisitionRadioButton.Checked = True
            BarCodeTextBox.Focus()
        ElseIf Not _ForInvoiceReceived AndAlso MyCustomSettings.DefaultInvoiceMadeItemIsGoods Then
            GoodsTransferRadioButton.Checked = True
            BarCodeTextBox.Focus()
        End If

    End Sub


    Private Sub IOkButton_Click(ByVal sender As System.Object, _
       ByVal e As System.EventArgs) Handles IOkButton.Click

        Try

            If LongTermAssetAcquisitionRadioButton.Checked Then

                _Value = LoadObject(Of AssetAcquisitionInvoiceAdapter)(Nothing, _
                    "NewAssetAcquisitionInvoiceAdapter", True, _
                    _ParentChronologyValidator, Not _ForInvoiceReceived)

            ElseIf LongTermAssetTransferRadioButton.Checked Then

                _Value = LoadObject(Of AssetSaleInvoiceAdapter)(Nothing, _
                    "NewAssetSaleInvoiceAdapter", True, GetSelectedAsset.ID, _
                    _ParentChronologyValidator, Not _ForInvoiceReceived)

            ElseIf LongTermAssetAcquisitionValueChangeRadioButton.Checked Then

                _Value = LoadObject(Of AssetAcquisitionValueIncreaseInvoiceAdapter)(Nothing, _
                    "NewAssetAcquisitionValueIncreaseInvoiceAdapter", True, GetSelectedAsset.ID, _
                    _ParentChronologyValidator, Not _ForInvoiceReceived)

            ElseIf ServicesRadioButton.Checked Then

                _Value = LoadObject(Of ServiceInvoiceAdapter)(Nothing, _
                    "NewServiceInvoiceAdapter", True, GetSelectedService, _
                    _ParentChronologyValidator, Not _ForInvoiceReceived)

            ElseIf GoodsAcquisitionRadioButton.Checked Then

                _Value = LoadObject(Of GoodsAcquisitionInvoiceAdapter)(Nothing, _
                    "NewGoodsAcquisitionInvoiceAdapter", True, GetSelectedGoods.ID, _
                    _ParentChronologyValidator, Not _ForInvoiceReceived)

            ElseIf GoodsAdditionalCostsRadioButton.Checked Then

                _Value = LoadObject(Of GoodsAddedCostsInvoiceAdapter)(Nothing, _
                    "NewGoodsAddedCostsInvoiceAdapter", True, GetSelectedGoods.ID, _
                    GetSelectedWarehouse.ID, _ParentChronologyValidator, Not _ForInvoiceReceived)

            ElseIf GoodsDiscountRadioButton.Checked Then

                _Value = LoadObject(Of GoodsDiscountInvoiceAdapter)(Nothing, _
                    "NewGoodsDiscountInvoiceAdapter", True, GetSelectedGoods.ID, _
                    GetSelectedWarehouse.ID, _ParentChronologyValidator, Not _ForInvoiceReceived)

            ElseIf GoodsTransferRadioButton.Checked Then

                _Value = LoadObject(Of GoodsSaleInvoiceAdapter)(Nothing, _
                    "NewGoodsSaleInvoiceAdapter", True, GetSelectedGoods.ID, _
                    GetSelectedWarehouse.ID, _ParentChronologyValidator, Not _ForInvoiceReceived)

            Else

                Throw New Exception("Klaida. Nepasirinktas nė vienas operacijos tipas.")

            End If

            Me.Hide()
            Me.Close()

        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Private Sub ICancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ICancelButton.Click

        Me.Hide()
        Me.Close()

    End Sub


    Private Sub RefreshLongTermAssetInfoListButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshLongTermAssetInfoListButton.Click

        Dim assetList As LongTermAssetInfoList = Nothing

        Try
            Using busy As New StatusBusy
                assetList = LongTermAssetInfoList.GetLongTermAssetInfoList( _
                    LongTermAssetAcquisitionDateTimePicker.Value, _
                    LongTermAssetAcquisitionDateTimePicker.Value, Nothing)
            End Using
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        LongTermAssetAccGridComboBox.AttachedGrid.DataSource = assetList

    End Sub

    Private Sub SelectGoodsInfoButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles SelectGoodsInfoButton.Click
        GoodsInfoListAccGridComboBox.SelectedValue = GoodsInfoList.GetList. _
            GetItemByBarCode(Me.BarCodeTextBox.Text.Trim)
    End Sub

    Private Sub BarCodeTextBox_TextChanged(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.KeyEventArgs) Handles BarCodeTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SelectGoodsInfoButton_Click(sender, New EventArgs)
        End If
    End Sub


    Private CheckedAreChanging As Boolean = False

    Private Sub AttachedObjectTypeRadioButton_CheckedChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LongTermAssetAcquisitionRadioButton.CheckedChanged, _
        LongTermAssetTransferRadioButton.CheckedChanged, ServicesRadioButton.CheckedChanged, _
        LongTermAssetAcquisitionValueChangeRadioButton.CheckedChanged, _
        GoodsAcquisitionRadioButton.CheckedChanged, GoodsAdditionalCostsRadioButton.CheckedChanged, _
        GoodsDiscountRadioButton.CheckedChanged, GoodsTransferRadioButton.CheckedChanged

        If CheckedAreChanging OrElse sender Is Nothing OrElse _
            Not TypeOf sender Is RadioButton Then Exit Sub

        Dim isChecked As Boolean = DirectCast(sender, RadioButton).Checked

        If Not isChecked Then Exit Sub

        CheckedAreChanging = True

        If sender Is LongTermAssetTransferRadioButton Then
            LongTermAssetAcquisitionRadioButton.Checked = False
            LongTermAssetAcquisitionValueChangeRadioButton.Checked = False
            ServicesRadioButton.Checked = False
            GoodsAcquisitionRadioButton.Checked = False
            GoodsAdditionalCostsRadioButton.Checked = False
            GoodsDiscountRadioButton.Checked = False
            GoodsTransferRadioButton.Checked = False
            LongTermAssetAcquisitionDateTimePicker.Focus()

        ElseIf sender Is LongTermAssetAcquisitionRadioButton Then
            LongTermAssetTransferRadioButton.Checked = False
            LongTermAssetAcquisitionValueChangeRadioButton.Checked = False
            ServicesRadioButton.Checked = False
            GoodsAcquisitionRadioButton.Checked = False
            GoodsAdditionalCostsRadioButton.Checked = False
            GoodsDiscountRadioButton.Checked = False
            GoodsTransferRadioButton.Checked = False
        ElseIf sender Is ServicesRadioButton AndAlso isChecked Then
            LongTermAssetTransferRadioButton.Checked = False
            LongTermAssetAcquisitionValueChangeRadioButton.Checked = False
            LongTermAssetAcquisitionRadioButton.Checked = False
            GoodsAcquisitionRadioButton.Checked = False
            GoodsAdditionalCostsRadioButton.Checked = False
            GoodsDiscountRadioButton.Checked = False
            GoodsTransferRadioButton.Checked = False
            ServicesAccGridComboBox.Focus()
        ElseIf sender Is LongTermAssetAcquisitionValueChangeRadioButton Then
            LongTermAssetAcquisitionRadioButton.Checked = False
            ServicesRadioButton.Checked = False
            LongTermAssetTransferRadioButton.Checked = False
            GoodsAcquisitionRadioButton.Checked = False
            GoodsAdditionalCostsRadioButton.Checked = False
            GoodsDiscountRadioButton.Checked = False
            GoodsTransferRadioButton.Checked = False
            BarCodeTextBox.Focus()
        ElseIf sender Is GoodsAcquisitionRadioButton Then
            GoodsAdditionalCostsRadioButton.Checked = False
            GoodsDiscountRadioButton.Checked = False
            GoodsTransferRadioButton.Checked = False
            LongTermAssetAcquisitionRadioButton.Checked = False
            ServicesRadioButton.Checked = False
            LongTermAssetTransferRadioButton.Checked = False
            LongTermAssetAcquisitionValueChangeRadioButton.Checked = False
            SetWarehouse()
            BarCodeTextBox.Focus()
        ElseIf sender Is GoodsAdditionalCostsRadioButton Then
            GoodsAcquisitionRadioButton.Checked = False
            GoodsDiscountRadioButton.Checked = False
            GoodsTransferRadioButton.Checked = False
            LongTermAssetAcquisitionRadioButton.Checked = False
            ServicesRadioButton.Checked = False
            LongTermAssetTransferRadioButton.Checked = False
            LongTermAssetAcquisitionValueChangeRadioButton.Checked = False
            SetWarehouse()
            BarCodeTextBox.Focus()
        ElseIf sender Is GoodsDiscountRadioButton Then
            GoodsAcquisitionRadioButton.Checked = False
            GoodsAdditionalCostsRadioButton.Checked = False
            GoodsTransferRadioButton.Checked = False
            LongTermAssetAcquisitionRadioButton.Checked = False
            ServicesRadioButton.Checked = False
            LongTermAssetTransferRadioButton.Checked = False
            LongTermAssetAcquisitionValueChangeRadioButton.Checked = False
            SetWarehouse()
            BarCodeTextBox.Focus()
        ElseIf sender Is GoodsTransferRadioButton Then
            GoodsAcquisitionRadioButton.Checked = False
            GoodsAdditionalCostsRadioButton.Checked = False
            GoodsDiscountRadioButton.Checked = False
            LongTermAssetAcquisitionRadioButton.Checked = False
            ServicesRadioButton.Checked = False
            LongTermAssetTransferRadioButton.Checked = False
            LongTermAssetAcquisitionValueChangeRadioButton.Checked = False
            SetWarehouse()
            BarCodeTextBox.Focus()
        End If

        LongTermAssetAcquisitionDateTimePicker.Enabled = LongTermAssetTransferRadioButton.Checked _
            OrElse LongTermAssetAcquisitionValueChangeRadioButton.Checked
        RefreshLongTermAssetInfoListButton.Enabled = LongTermAssetTransferRadioButton.Checked _
            OrElse LongTermAssetAcquisitionValueChangeRadioButton.Checked
        LongTermAssetAccGridComboBox.Enabled = LongTermAssetTransferRadioButton.Checked _
            OrElse LongTermAssetAcquisitionValueChangeRadioButton.Checked
        ServicesAccGridComboBox.Enabled = ServicesRadioButton.Checked
        GoodsInfoListAccGridComboBox.Enabled = GoodsAcquisitionRadioButton.Checked OrElse _
            GoodsAdditionalCostsRadioButton.Checked OrElse GoodsDiscountRadioButton.Checked _
            OrElse GoodsTransferRadioButton.Checked
        SelectGoodsInfoButton.Enabled = GoodsInfoListAccGridComboBox.Enabled
        BarCodeTextBox.Enabled = GoodsInfoListAccGridComboBox.Enabled
        WarehouseInfoListAccGridComboBox.Enabled = GoodsAcquisitionRadioButton.Checked OrElse _
            GoodsAdditionalCostsRadioButton.Checked OrElse GoodsDiscountRadioButton.Checked _
            OrElse GoodsTransferRadioButton.Checked

        CheckedAreChanging = False

    End Sub


    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.ServiceInfoList), _
            GetType(HelperLists.GoodsInfoList), GetType(HelperLists.WarehouseInfoList)) Then Return False

        Try

            LoadLongTermAssetInfoListToGridCombo(LongTermAssetAccGridComboBox)
            LoadServiceInfoListToGridCombo(ServicesAccGridComboBox, True, True, True)
            LoadGoodsInfoListToGridCombo(GoodsInfoListAccGridComboBox, True, TradedItemType.All)
            LoadWarehouseInfoListToGridCombo(WarehouseInfoListAccGridComboBox, True)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Private Sub SetWarehouse()

        Try
            If WarehouseInfoList.GetList.Count = 1 Then
                WarehouseInfoListAccGridComboBox.SelectedValue = WarehouseInfoList.GetList.Item(0)
            ElseIf WarehouseInfoList.GetList.Count = 2 Then
                WarehouseInfoListAccGridComboBox.SelectedValue = WarehouseInfoList.GetList.Item(1)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Function GetSelectedAsset() As LongTermAssetInfo

        Dim result As LongTermAssetInfo = Nothing

        If Not LongTermAssetAccGridComboBox.SelectedValue Is Nothing AndAlso _
           TypeOf LongTermAssetAccGridComboBox.SelectedValue Is LongTermAssetInfo AndAlso _
           DirectCast(LongTermAssetAccGridComboBox.SelectedValue, LongTermAssetInfo).ID > 0 Then

            result = DirectCast(LongTermAssetAccGridComboBox.SelectedValue, LongTermAssetInfo)

        End If

        If result Is Nothing Then
            Throw New Exception("Klaida. Nepasirinktas ilgalaikis turtas.")
        End If

        Return result

    End Function

    Private Function GetSelectedWarehouse() As WarehouseInfo

        Dim result As WarehouseInfo = Nothing

        If Not WarehouseInfoListAccGridComboBox.SelectedValue Is Nothing AndAlso _
           TypeOf WarehouseInfoListAccGridComboBox.SelectedValue Is WarehouseInfo AndAlso _
           DirectCast(WarehouseInfoListAccGridComboBox.SelectedValue, WarehouseInfo).ID > 0 Then

            result = DirectCast(WarehouseInfoListAccGridComboBox.SelectedValue, WarehouseInfo)

        End If

        If result Is Nothing Then
            Throw New Exception("Klaida. Nepasirinktas sandėlis.")
        End If

        Return result

    End Function

    Private Function GetSelectedGoods() As GoodsInfo

        Dim result As GoodsInfo = Nothing

        If Not GoodsInfoListAccGridComboBox.SelectedValue Is Nothing AndAlso _
           TypeOf GoodsInfoListAccGridComboBox.SelectedValue Is GoodsInfo AndAlso _
           DirectCast(GoodsInfoListAccGridComboBox.SelectedValue, GoodsInfo).ID > 0 Then

            result = DirectCast(GoodsInfoListAccGridComboBox.SelectedValue, GoodsInfo)

        End If

        If result Is Nothing Then
            Throw New Exception("Klaida. Nepasirinktos prekės.")
        End If

        Return result

    End Function

    Private Function GetSelectedService() As ServiceInfo

        Dim result As ServiceInfo = Nothing

        If Not ServicesAccGridComboBox.SelectedValue Is Nothing AndAlso _
           TypeOf ServicesAccGridComboBox.SelectedValue Is ServiceInfo AndAlso _
           DirectCast(ServicesAccGridComboBox.SelectedValue, ServiceInfo).ID > 0 Then

            result = DirectCast(ServicesAccGridComboBox.SelectedValue, ServiceInfo)

        End If

        If result Is Nothing Then
            Throw New Exception("Klaida. Nepasirinkta paslauga.")
        End If

        Return result

    End Function

End Class