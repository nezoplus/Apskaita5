Imports ApskaitaObjects.Workers
Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.ActiveReports
Public Class F_PayOutNaturalPersonList
    Implements ISupportsPrinting

    Private Obj As PayOutNaturalPersonInfoList = Nothing
    Private Loading As Boolean = True


    Private Sub F_PayOutNaturalPersonList_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

    End Sub

    Private Sub F_PayOutNaturalPersonList_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        GetDataGridViewLayOut(PayOutNaturalPersonItemListDataGridView)
        GetFormLayout(Me)

    End Sub

    Private Sub F_PayOutNaturalPersonList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        NewItemButton.Enabled = PayOutNaturalPerson.CanAddObject
        RefreshButton.Enabled = PayOutNaturalPersonInfoList.CanGetObject

        AddDGVColumnSelector(PayOutNaturalPersonItemListDataGridView)
        SetDataGridViewLayOut(PayOutNaturalPersonItemListDataGridView)
        SetFormLayout(Me)

    End Sub

    Private Sub PayOutNaturalPersonItemListDataGridView_CellDoubleClick( _
        ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles PayOutNaturalPersonItemListDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        If Not PayOutNaturalPerson.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka išmokų duomenų koregavimui.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        ' get the selected user
        Dim tmp As PayOutNaturalPersonInfo = Nothing
        Try
            tmp = CType(PayOutNaturalPersonItemListDataGridView.Rows(e.RowIndex).DataBoundItem, _
                PayOutNaturalPersonInfo)
        Catch ex As Exception
        End Try
        If tmp Is Nothing Then
            MsgBox("Klaida. Nepavyko nustatyti pasirinktos išmokos.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        For Each frm As Form In MDIParent1.MdiChildren
            If TypeOf frm Is F_PayOutNaturalPerson AndAlso _
                DirectCast(frm, F_PayOutNaturalPerson).ObjectID = tmp.ID Then
                frm.Activate()
                Exit Sub
            End If
        Next

        ' ask what to do
        Dim ats As String = Ask("", New ButtonStructure("Taisyti", "Keisti išmokos duomenis."), _
            New ButtonStructure("Ištrinti", "Pašalinti išmokos duomenis iš duomenų bazės."), _
            New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        If ats <> "Taisyti" AndAlso ats <> "Ištrinti" Then Exit Sub

        If ats = "Taisyti" Then

            MDIParent1.LaunchForm(GetType(F_PayOutNaturalPerson), False, False, tmp.ID, tmp.ID)

        Else ' remove WorkerStatus

            If Not YesOrNo("Ar tikrai norite pašalinti išmokos duomenis iš duomenų bazės?") Then Exit Sub

            Using busy As New StatusBusy
                Try
                    PayOutNaturalPerson.DeletePayOutNaturalPerson(tmp.ID)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try
            End Using

            If Not YesOrNo("Išmokos duomenys sėkmingai pašalinti iš duomenų bazės. Atnaujinti sąrašą?") Then Exit Sub

            Using bm As New BindingsManager(PayOutNaturalPersonItemListBindingSource, Nothing, Nothing, False, True)
                Try
                    Obj = LoadObject(Of PayOutNaturalPersonInfoList)(Nothing, _
                        "GetPayOutNaturalPersonInfoList", False, obj.DateFrom, obj.DateTo)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try
                bm.SetNewDataSource(Obj.GetSortedList)
            End Using

        End If

    End Sub

    Private Sub NewItemButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewItemButton.Click
        MDIParent1.LaunchForm(GetType(F_PayOutNaturalPerson), False, False, 0)
    End Sub

    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Using bm As New BindingsManager(PayOutNaturalPersonItemListBindingSource, _
            Nothing, Nothing, False, True)

            Try
                Obj = LoadObject(Of PayOutNaturalPersonInfoList)(Nothing, _
                    "GetPayOutNaturalPersonInfoList", True, DateFromDateTimePicker.Value, _
                    DateToDateTimePicker.Value)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj.GetSortedList)

        End Using

        PayOutNaturalPersonItemListDataGridView.Select()

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