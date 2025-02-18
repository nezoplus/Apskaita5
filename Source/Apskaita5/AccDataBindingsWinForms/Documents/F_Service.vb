﻿Imports ApskaitaObjects.Documents
Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.Settings
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists

Friend Class F_Service
    Implements IObjectEditForm

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(AccountInfoList), GetType(CompanyRegionalInfoList), GetType(TaxRateInfoList), _
         GetType(VatDeclarationSchemaInfoList)}

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of Service)
    Private _PricesListViewManager As DataListViewEditControlManager(Of RegionalPrice)
    Private _ContentsListViewManager As DataListViewEditControlManager(Of RegionalContent)

    Private _DocumentToEdit As Service = Nothing


    Public Sub New(ByVal documentToEdit As Service)
        InitializeComponent()
        _DocumentToEdit = documentToEdit
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub


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
            Return GetType(Service)
        End Get
    End Property


    Private Sub F_Service_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        If _DocumentToEdit Is Nothing Then
            _DocumentToEdit = Service.NewService()
        End If

        Try


            _FormManager = New CslaActionExtenderEditForm(Of Service)(Me, ServiceBindingSource, _
                _DocumentToEdit, _RequiredCachedLists, IOkButton, IApplyButton, ICancelButton, _
                Nothing, ProgressFiller1)

            _FormManager.ManageDataListViewStates(RegionalPricesDataListView, RegionalContentsDataListView)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
        End Try

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            _ContentsListViewManager = New DataListViewEditControlManager(Of RegionalContent) _
                (RegionalContentsDataListView, Nothing, AddressOf OnContentItemsDelete, _
                 AddressOf OnContentItemAdd, Nothing, _DocumentToEdit)

            _PricesListViewManager = New DataListViewEditControlManager(Of RegionalPrice) _
                (RegionalPricesDataListView, Nothing, AddressOf OnPriceItemsDelete, _
                 AddressOf OnPriceItemAdd, Nothing, _DocumentToEdit)

            SetupDefaultControls(Of Service)(Me, ServiceBindingSource, _DocumentToEdit)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function


    Private Sub OnContentItemsDelete(ByVal items As RegionalContent())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        For Each item As RegionalContent In items
            _FormManager.DataSource.RegionalContents.Remove(item)
        Next
    End Sub

    Private Sub OnContentItemAdd()
        If _FormManager.DataSource Is Nothing Then Exit Sub
        _FormManager.DataSource.RegionalContents.AddNew()
    End Sub

    Private Sub OnPriceItemsDelete(ByVal items As RegionalPrice())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        For Each item As RegionalPrice In items
            _FormManager.DataSource.RegionalPrices.Remove(item)
        Next
    End Sub

    Private Sub OnPriceItemAdd()
        If _FormManager.DataSource Is Nothing Then Exit Sub
        _FormManager.DataSource.RegionalPrices.AddNew()
    End Sub

End Class