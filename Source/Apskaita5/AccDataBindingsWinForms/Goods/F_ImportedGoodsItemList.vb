﻿Imports ApskaitaObjects.Goods
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists

Public Class F_ImportedGoodsItemList
    Implements ISingleInstanceForm

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of ImportedGoodsItemList)
    Private _ListViewManager As DataListViewEditControlManager(Of ImportedGoodsItem)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_ImportedGoodsItemList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        Try

            _FormManager = New CslaActionExtenderEditForm(Of ImportedGoodsItemList) _
                (Me, ImportedGoodsItemListBindingSource, ImportedGoodsItemList.NewImportedGoodsItemList(), _
                 Nothing, nOkButton, ApplyButton, Nothing, Nothing, ProgressFiller1)

            _FormManager.ManageDataListViewStates(ImportedGoodsItemListDataListView)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

    End Sub

    Private Function SetDataSources() As Boolean

        'If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            _ListViewManager = New DataListViewEditControlManager(Of ImportedGoodsItem) _
                (ImportedGoodsItemListDataListView, Nothing, _
                 AddressOf OnItemsDelete, Nothing, Nothing, Nothing)

           _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        'Dim cm As New ContextMenu()
        'Dim cmItem As New MenuItem("Informacija apie formatą", AddressOf PasteAccButton_Click)
        'cm.MenuItems.Add(cmItem)
        'PasteAccButton.ContextMenu = cm

        Return True

    End Function


    Private Sub OnItemsDelete(ByVal items As ImportedGoodsItem())

        If _FormManager.DataSource Is Nothing OrElse items Is Nothing OrElse items.Length < 1 Then Exit Sub

        For Each item As ImportedGoodsItem In items
            _FormManager.DataSource.Remove(item)
        Next

    End Sub

    Private Sub PasteButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles PasteButton.Click

        Dim data As DataTable = F_DataImport.GetImportedData(ImportedGoodsItem.GetDataTableSpecification)
        If data Is Nothing Then Exit Sub

        'ImportedGoodsItemList.GetImportedGoodsItemList(data)
        _QueryManager.InvokeQuery(Of ImportedGoodsItemList)(Nothing, "GetImportedGoodsItemList", True,
            AddressOf OnDataLoaded, data)
    End Sub

    Private Sub OpenFileButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OpenFileButton.Click

        Dim fileName As String

        Using ofd As New OpenFileDialog
            ofd.Multiselect = False
            If ofd.ShowDialog(Me) <> System.Windows.Forms.DialogResult.OK Then Exit Sub
            fileName = ofd.FileName
        End Using
        If StringIsNullOrEmpty(fileName) OrElse Not IO.File.Exists(fileName) Then Exit Sub

        Dim data As DataTable = F_DataImport.GetImportedData(ImportedGoodsItem.GetDataTableSpecification, fileName)
        If data Is Nothing Then Exit Sub

        'ImportedGoodsItemList.GetImportedGoodsItemList(data)
        _QueryManager.InvokeQuery(Of ImportedGoodsItemList)(Nothing, "GetImportedGoodsItemList", True,
            AddressOf OnDataLoaded, data)

    End Sub

    Private Sub OnDataLoaded(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If result Is Nothing Then Exit Sub

        Dim newItems As ImportedGoodsItemList = DirectCast(result, ImportedGoodsItemList)

        _FormManager.AddNewDataSource(newItems)

        If Not StringIsNullOrEmpty(newItems.ImportWarnings) Then
            MsgBox(newItems.ImportWarnings, MsgBoxStyle.Exclamation, "Įspėjimas")
        End If

    End Sub

    Private Sub HelpButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs)

        MsgBox("Importuojami duomenys, nepriklausomai nuo šaltinio, turi atitikti šiuos reikalavimus:" _
            & vbCrLf & "Duomenų eilutės turi būti atskirtos naudojant cr lf simbolius." _
            & vbCrLf & "Duomenų stulpeliai turi būti atskirti naudojant tab simbolį." _
            & vbCrLf & "Duomenyse negali būti simbolių, naudojamų kaip skirtukai, t.y. cr lf arba tab." _
            & ImportedGoodsItem.GetPasteStringColumnsDescription(), MsgBoxStyle.Information, "Info")
        Clipboard.SetText(String.Join(vbTab, ImportedGoodsItem.GetPasteStringColumns()), TextDataFormat.UnicodeText)

    End Sub

End Class