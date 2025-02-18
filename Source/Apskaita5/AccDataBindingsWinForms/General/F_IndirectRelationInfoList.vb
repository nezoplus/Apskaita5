﻿Imports ApskaitaObjects.HelperLists
Imports AccControlsWinForms

Friend Class F_IndirectRelationInfoList
    Implements IObjectEditForm

    Private source As IndirectRelationInfoList = Nothing
    Private _FormManager As CslaActionExtenderReportForm(Of IndirectRelationInfoList)
    Private _ListViewManager As DataListViewEditControlManager(Of IndirectRelationInfo)
    Private _QueryManager As CslaActionExtenderQueryObject


    Public ReadOnly Property ObjectID() As Integer _
        Implements IObjectEditForm.ObjectID
        Get
            If _FormManager Is Nothing OrElse _FormManager.DataSource Is Nothing Then
                If source Is Nothing Then
                    Return Integer.MinValue
                Else
                    Return source.ID
                End If
            End If
            Return _FormManager.DataSource.ID
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type _
        Implements IObjectEditForm.ObjectType
        Get
            Return GetType(IndirectRelationInfoList)
        End Get
    End Property


    Public Sub New(ByVal nSource As IndirectRelationInfoList)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        source = nSource

    End Sub


    Private Sub F_IndirectRelationInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            _ListViewManager = New DataListViewEditControlManager(Of IndirectRelationInfo) _
                (IndirectRelationInfoListDataListView, Nothing, Nothing, _
                 Nothing, Nothing, Nothing)

            _ListViewManager.AddCancelButton = False
            _ListViewManager.AddButtonHandler(My.Resources.F_JournalEntryInfoList_EditLabel, _
                My.Resources.F_JournalEntryInfoList_EditTooltipLabel, AddressOf EditItem)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            _FormManager = New CslaActionExtenderReportForm(Of IndirectRelationInfoList) _
                (Me, IndirectRelationInfoListBindingSource, source, Nothing, _
                 RefreshButton, ProgressFiller1, "GetIndirectRelationInfoList", _
                 AddressOf GetReportParams)

            _FormManager.ManageDataListViewStates(IndirectRelationInfoListDataListView)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        If Not source Is Nothing Then

            ContentTextBox.Text = source.Content
            CorrespondingAccountsTextBox.Text = source.CorrespondingAccounts
            DateTextBox.Text = source.Date.ToString("yyyy-MM-dd")
            DocNumberTextBox.Text = source.DocNumber
            DocTypeHumanReadableTextBox.Text = source.DocTypeHumanReadable
            IDTextBox.Text = source.ID.ToString
            InsertDateTextBox.Text = source.InsertDate.ToString("yyyy-MM-dd HH:mm:ss")
            PersonCodeTextBox.Text = source.PersonCode
            PersonNameTextBox.Text = source.PersonName
            SumAccTextBox.DecimalValue = source.Sum
            UpdateDateTextBox.Text = source.UpdateDate.ToString("yyyy-MM-dd HH:mm:ss")

        End If

    End Sub


    Private Function GetReportParams() As Object()
        Throw New Exception("") ' just to indicate not to procede
    End Function

    Private Sub EditItem(ByVal item As IndirectRelationInfo)

        If item Is Nothing Then Exit Sub

        If item.Type = IndirectRelationType.PayoutToResident Then

            Dim frm = New F_PayOutNaturalPersonWithTaxesList(item)
            frm.MdiParent = Me.MdiParent
            frm.Show()

        ElseIf item.Type = IndirectRelationType.PayoutToResidentWithoutTaxes Then

            Dim frm = New F_PayOutNaturalPersonWithoutTaxesList(item)
            frm.MdiParent = Me.MdiParent
            frm.Show()

        ElseIf item.Type = IndirectRelationType.LongTermAssetsPurchase Then

            'Assets.LongTermAsset.GetLongTermAsset(item.ID)
            _QueryManager.InvokeQuery(Of Assets.LongTermAsset)(Nothing, "GetLongTermAsset", True, _
                AddressOf OpenObjectEditForm, item.ID)

        ElseIf item.Type = IndirectRelationType.LongTermAssetsOperation Then

            'AssetOperationManager.GetAssetOperation(item.ID, item.AssetOperationType, False, _
            '    _FormManager.DataSource.ID, _FormManager.DataSource.DocType)
            _QueryManager.InvokeQuery(Of AssetOperationManager)(Nothing, "GetAssetOperation", True, _
                AddressOf OpenObjectEditForm, item.ID, item.AssetOperationType, False, _
                _FormManager.DataSource.ID, _FormManager.DataSource.DocType)

        ElseIf item.Type = IndirectRelationType.GoodsOperation Then

            'GoodsOperationManager.GetGoodsOperation(item.ID, item.GoodsOperationType, False, _
            '    Goods.GoodsComplexOperationType.BulkDiscard, _FormManager.DataSource.ID, _
            '    _FormManager.DataSource.DocType)
            _QueryManager.InvokeQuery(Of GoodsOperationManager)(Nothing, "GetGoodsOperation", True, _
                AddressOf OpenObjectEditForm, item.ID, item.GoodsOperationType, False, _
                Goods.GoodsComplexOperationType.BulkDiscard, _FormManager.DataSource.ID, _
                _FormManager.DataSource.DocType)

        End If

    End Sub

    Private Sub IOkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IOkButton.Click
        Me.Close()
    End Sub

End Class