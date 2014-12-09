Imports ApskaitaObjects.Assets
Public Class F_LongTermAssetOperationInfoListParent
    Implements ISupportsPrinting, IObjectEditForm

    Private Obj As LongTermAssetOperationInfoListParent
    Private Loading As Boolean = True
    Private LongTermAssetID As Integer = -1
    Private nOperationListChanged As Boolean = False


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If Not Obj Is Nothing Then Return Obj.ID
            Return 0
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(LongTermAssetOperationInfoListParent)
        End Get
    End Property


    Public Sub New(ByVal nLongTermAssetID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LongTermAssetID = nLongTermAssetID

    End Sub


    Public Sub NotifyAboutOperationListChanges(ByVal nAssetID As Integer)
        If nAssetID = Obj.ID Then nOperationListChanged = True
    End Sub


    Private Sub F_LongTermAssetOperationInfoListParent_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
        If nOperationListChanged Then
            nOperationListChanged = False
            If Not YesOrNo("Pasikeitė operacijų su šiuo turtu duomenys. Atnaujinti sąrašą?") Then Exit Sub
            RefreshButton.PerformClick()
        End If
    End Sub

    Private Sub F_LongTermAssetOperationInfoListParent_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetDataGridViewLayOut(OperationListDataGridView)
        GetFormLayout(Me)
    End Sub

    Private Sub F_LongTermAssetOperationInfoListParent_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not LongTermAssetOperationInfoListParent.CanGetObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        Try
            Obj = LoadObject(Of LongTermAssetOperationInfoListParent)(Nothing, _
                "GetLongTermAssetOperationInfoListParent", True, LongTermAssetID)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        LongTermAssetOperationInfoListParentBindingSource.DataSource = Obj

        AddDGVColumnSelector(OperationListDataGridView)

        SetDataGridViewLayOut(OperationListDataGridView)
        SetFormLayout(Me)

    End Sub

    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Using bm As New BindingsManager(LongTermAssetOperationInfoListParentBindingSource, _
            OperationListBindingSource, Nothing, False, True)

            Try
                Obj = LoadObject(Of LongTermAssetOperationInfoListParent)(Nothing, _
                    "GetLongTermAssetOperationInfoListParent", True, LongTermAssetID)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj)

        End Using

    End Sub

    Private Sub OperationListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles OperationListDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        Dim SelectedItem As LongTermAssetOperationInfo = Nothing
        Try
            SelectedItem = CType(OperationListDataGridView.Rows(e.RowIndex).DataBoundItem, _
                LongTermAssetOperationInfo)
        Catch ex As Exception
            MsgBox("Klaida. Nepavyko identifikuoti įrašo.", MsgBoxStyle.Exclamation, "Klaida")
        End Try
        If SelectedItem Is Nothing Then Exit Sub

        Dim ats As String = Ask("", _
            New ButtonStructure("Taisyti", "Atidaryti IT operacijos formą."), _
            New ButtonStructure("Pašalinti", "Pašalinti IT operacijos duomenis iš apskaitos."), _
            New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        If ats.Trim <> "Taisyti" AndAlso ats.Trim <> "Pašalinti" Then Exit Sub

        If ats.Trim = "Taisyti" Then

            For Each frm As Form In MDIParent1.MdiChildren
                If TypeOf frm Is F_LongTermAssetOperation AndAlso _
                    CType(frm, F_LongTermAssetOperation).ObjectID = SelectedItem.ID Then
                    frm.Activate()
                    frm.BringToFront()
                    Exit Sub
                End If
            Next

            Dim frml As New F_LongTermAssetOperation(SelectedItem.ID, False, False)
            frml.MdiParent = MDIParent1
            frml.Show()

        ElseIf ats.Trim = "Pašalinti" Then

            If Not YesOrNo("Ar tikrai norite pašalinti pasirinktos IT operacijos " _
                & "duomenis iš apskaitos?") Then Exit Sub

            Try
                LongTermAssetOperation.DeleteLongTermAssetOperation(SelectedItem.ID)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            MsgBox("Ilgalaikio turto operacijos duomenys sėkmingai pašalinti iš apskaitos.", _
                MsgBoxStyle.Information, "Info")

            RefreshButton.PerformClick()

        End If

    End Sub

    Private Sub NewOperationButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewOperationButton.Click

        Dim frml As New F_LongTermAssetOperation(Obj.ID, True, False)
        frml.MdiParent = MDIParent1
        frml.Show()

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

End Class