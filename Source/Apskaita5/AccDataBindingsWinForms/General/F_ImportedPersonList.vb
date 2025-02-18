﻿Imports AccControlsWinForms
Imports ApskaitaObjects.General

Friend Class F_ImportedPersonList
    Implements ISingleInstanceForm

    Private _FormManager As CslaActionExtenderEditForm(Of ImportedPersonList)
    Private _ListViewManager As DataListViewEditControlManager(Of ImportedPerson)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_ImportedPersonList_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        MyCustomSettings.GetListViewLayOut(ImportedPersonListDataListView)
        MyCustomSettings.GetFormLayout(Me)

    End Sub

    Private Sub F_ImportedPersonList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            _FormManager = New CslaActionExtenderEditForm(Of ImportedPersonList) _
                (Me, ImportedPersonListBindingSource, Nothing, Nothing, _
                ApplyButton, Nothing, Nothing, Nothing, ProgressFiller1)

            _FormManager.ManageDataListViewStates(ImportedPersonListDataListView)

            _ListViewManager = New DataListViewEditControlManager(Of ImportedPerson) _
                (ImportedPersonListDataListView, Nothing, Nothing, Nothing, Nothing, Nothing)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
        End Try

    End Sub


    Private Sub PasteButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles PasteButton.Click
        Dim data As DataTable = F_DataImport.GetImportedData(ImportedPerson.GetDataTableSpecification)
        If data Is Nothing Then Exit Sub
        _QueryManager.InvokeQuery(Of ImportedPersonList)(Nothing, "GetImportedPersonList",
            False, AddressOf OnDataLoaded, data)
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

        Dim data As DataTable = F_DataImport.GetImportedData(ImportedPerson.GetDataTableSpecification, fileName)
        If data Is Nothing Then Exit Sub

        _QueryManager.InvokeQuery(Of ImportedPersonList)(Nothing, "GetImportedPersonList",
            False, AddressOf OnDataLoaded, data)

    End Sub


    Private Sub OnDataLoaded(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If result Is Nothing Then Exit Sub

        _FormManager.AddNewDataSource(DirectCast(result, ImportedPersonList))

    End Sub

End Class