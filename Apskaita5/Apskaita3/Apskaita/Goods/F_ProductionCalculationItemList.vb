Imports ApskaitaObjects.ActiveReports
Public Class F_ProductionCalculationItemList

    Private Obj As ProductionCalculationItemList
    Private Loading As Boolean = True


    Private Sub F_ProductionCalculationItemList_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

    End Sub

    Private Sub F_ProductionCalculationItemList_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetDataGridViewLayOut(ProductionCalculationItemListDataGridView)
        GetFormLayout(Me)
    End Sub

    Private Sub F_ProductionCalculationItemList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        AddDGVColumnSelector(ProductionCalculationItemListDataGridView)

        SetDataGridViewLayOut(ProductionCalculationItemListDataGridView)
        SetFormLayout(Me)

    End Sub


    Private Sub ProductionCalculationItemListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles ProductionCalculationItemListDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        ' get the selected book entry
        Dim tmp As ProductionCalculationItem = Nothing
        Try
            tmp = CType(ProductionCalculationItemListDataGridView.Rows(e.RowIndex).DataBoundItem, ProductionCalculationItem)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        If tmp Is Nothing Then
            MsgBox("Klaida. Nepavyko nustatyti pasirinktos kalkuliacijos.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        For Each frm As Form In MDIParent1.MdiChildren
            If frm.GetType Is GetType(F_ProductionCalculation) AndAlso _
                DirectCast(frm, IObjectEditForm).ObjectID = tmp.ID Then
                frm.Activate()
                Exit Sub
            End If
        Next

        ' ask what to do
        Dim ats As String
        ats = Ask("", New ButtonStructure("Taisyti", "Keisti kalkuliacijos duomenis."), _
            New ButtonStructure("Ištrinti", "Pašalinti kalkuliacijos duomenis iš duomenų bazės."), _
            New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        If ats <> "Taisyti" AndAlso ats <> "Ištrinti" Then Exit Sub

        If ats = "Ištrinti" Then

            If Not YesOrNo("Ar tikrai norite pašalinti kalkuliacijos duomenis iš duomenų bazės?") Then Exit Sub

            Using busy As New StatusBusy
                Try
                    Goods.ProductionCalculation.DeleteProductionCalculation(tmp.ID)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try
            End Using

            If Not YesOrNo("Kalkuliacijos duomenys sėkmingai pašalinti iš įmonės duomenų bazės. " _
                & "Atnaujinti sąrašą?") Then Exit Sub

            DoRefresh()

        Else

            MDIParent1.LaunchForm(GetType(F_ProductionCalculation), False, False, tmp.ID, tmp.ID)

        End If

    End Sub

    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click
        DoRefresh()
    End Sub



    Private Sub DoRefresh()

        Using bm As New BindingsManager(ProductionCalculationItemListBindingSource, _
                Nothing, Nothing, False, True)

            Try
                Obj = LoadObject(Of ProductionCalculationItemList)(Nothing, _
                    "GetProductionCalculationItemList", True)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj.GetSortedList)

        End Using

        ProductionCalculationItemListDataGridView.Select()

    End Sub

End Class