Imports ApskaitaObjects.ActiveReports
Imports ApskaitaObjects.Workers
Public Class F_LabourContractInfoList
    Implements ISupportsPrinting

    Private Obj As ContractInfoList
    Private Loading As Boolean = True

    Private Sub F_LabourContractInfoList_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

    End Sub

    Private Sub F_LabourContractInfoList_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetDataGridViewLayOut(ContractInfoListDataGridView)
        GetDataGridViewLayOut(UpdatesListDataGridView)
        GetFormLayout(Me)
    End Sub

    Private Sub F_LabourContractInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        AddDGVColumnSelector(ContractInfoListDataGridView)
        AddDGVColumnSelector(UpdatesListDataGridView)

        SetDataGridViewLayOut(ContractInfoListDataGridView)
        SetDataGridViewLayOut(UpdatesListDataGridView)
        SetFormLayout(Me)

    End Sub


    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Using bm As New BindingsManager(ContractInfoListBindingSource, _
            UpdatesListBindingSource, Nothing, False, True)

            Try
                Obj = LoadObject(Of ContractInfoList)(Nothing, "GetContractInfoList", True, _
                    Not NotOriginalDataCheckBox.Checked, AtDateCheckBox.Checked, _
                    AtDateDateTimePicker.Value, AddWorkersWithoutContractCheckBox.Checked)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        ContractInfoListDataGridView.Select()

    End Sub

    Private Sub ContractInfoListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles ContractInfoListDataGridView.CellDoubleClick

        If Obj Is Nothing OrElse e.RowIndex < 0 Then Exit Sub

        Dim SelectedObj As ContractInfo
        Try
            SelectedObj = CType(ContractInfoListDataGridView.Rows(e.RowIndex).DataBoundItem, ContractInfo)
        Catch ex As Exception
            Exit Sub
        End Try
        If SelectedObj Is Nothing OrElse Not SelectedObj.PersonID > 0 Then Exit Sub

        Dim Answ As String = ""

        If Not Integer.TryParse(SelectedObj.ID, New Integer) OrElse Not CInt(SelectedObj.ID) > 0 Then

            Answ = Ask("", New ButtonStructure("Nauja Sutartis", "Įtraukti naujos darbo sutarties duomenis į duomenų bazę."), _
                New ButtonStructure("Bendri Duomenys", "Keisti bendrus darbuotojo duomenis."), _
                New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        Else

            Answ = Ask("", New ButtonStructure("Keisti", "Keisti darbo sutarties pirminius duomenis."), _
                New ButtonStructure("Ištrinti", "Pašalinti sutarties duomenis iš duomenų bazės."), _
                New ButtonStructure("Naujas Pakeitimas", "Pašalinti sutarties duomenis iš duomenų bazės."), _
                New ButtonStructure("Nauja Sutartis", "Įtraukti naujos darbo sutarties duomenis į duomenų bazę."), _
                New ButtonStructure("Bendri Duomenys", "Keisti bendrus darbuotojo duomenis."), _
                New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        End If

        If Answ <> "Keisti" AndAlso Answ <> "Ištrinti" AndAlso Answ <> "Naujas Pakeitimas" _
            AndAlso Answ <> "Nauja Sutartis" AndAlso Answ <> "Bendri Duomenys" Then Exit Sub

        If Answ = "Keisti" Then

            For Each frm As Form In MDIParent1.MdiChildren
                If TypeOf frm Is F_LabourContract AndAlso DirectCast(frm, F_LabourContract).ObjectID _
                    = CInt(SelectedObj.ID) Then
                    frm.Activate()
                    Exit Sub
                End If
            Next

            MDIParent1.LaunchForm(GetType(F_LabourContract), False, False, _
                CInt(SelectedObj.ID), CInt(SelectedObj.ID), False)

        ElseIf Answ = "Ištrinti" Then

            For Each frm As Form In MDIParent1.MdiChildren
                If TypeOf frm Is F_LabourContract AndAlso DirectCast(frm, F_LabourContract).ObjectID _
                    = CInt(SelectedObj.ID) Then
                    frm.Activate()
                    Exit Sub
                End If
            Next

            If Not YesOrNo("Ar tikrai norite pašalinti pasirinktos darbo sutarties " & _
                "duomenis iš duomenų bazės?") Then Exit Sub

            Using busy As New StatusBusy
                Try
                    Contract.DeleteContract(CInt(SelectedObj.ID))
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try
            End Using

            MsgBox("Darbo sutarties duomenys sėkmingai pašalinti iš duomenų bazės.", _
                MsgBoxStyle.Information, "Info")

            RefreshButton_Click(Me, New EventArgs)

        ElseIf Answ = "Nauja Sutartis" Then

            MDIParent1.LaunchForm(GetType(F_LabourContract), False, False, _
                SelectedObj.PersonID, SelectedObj.PersonID, True)

        ElseIf Answ = "Bendri Duomenys" Then

            For Each frm As Form In MDIParent1.MdiChildren
                If TypeOf frm Is F_Person AndAlso DirectCast(frm, F_Person).ObjectID = SelectedObj.PersonID Then
                    frm.Activate()
                    Exit Sub
                End If
            Next

            MDIParent1.LaunchForm(GetType(F_Person), False, False, SelectedObj.PersonID, _
                SelectedObj.PersonID)

        Else

            MDIParent1.LaunchForm(GetType(F_LabourContractUpdate), False, False, 0, _
                SelectedObj.Serial, CInt(SelectedObj.Number))

        End If

    End Sub

    Private Sub UpdatesListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles UpdatesListDataGridView.CellDoubleClick

        If Obj Is Nothing OrElse e.RowIndex < 0 Then Exit Sub

        Dim SelectedObj As LabourContractUpdateInfo
        Try
            SelectedObj = CType(UpdatesListDataGridView.Rows(e.RowIndex).DataBoundItem, LabourContractUpdateInfo)
        Catch ex As Exception
            Exit Sub
        End Try
        If SelectedObj Is Nothing OrElse Not SelectedObj.ID > 0 Then Exit Sub

        For Each frm As Form In MDIParent1.MdiChildren
            If TypeOf frm Is F_Service AndAlso DirectCast(frm, F_Service).ObjectID = SelectedObj.ID Then
                frm.Activate()
                Exit Sub
            End If
        Next

        Dim Answ As String = Ask("", New ButtonStructure("Keisti", "Keisti sutarties pakeitimo duomenis."), _
            New ButtonStructure("Ištrinti", "Pašalinti sutarties pakeitimo duomenis iš duomenų bazės."), _
            New ButtonStructure("Atšaukti", "Nieko nedaryti."))

        If Answ <> "Keisti" AndAlso Answ <> "Ištrinti" Then Exit Sub

        If Answ = "Keisti" Then

            MDIParent1.LaunchForm(GetType(F_LabourContractUpdate), False, False, SelectedObj.ID, SelectedObj.ID)

        Else

            If Not YesOrNo("Ar tikrai norite pašalinti pasirinkto sutarties pakeitimo " & _
                "duomenis iš duomenų bazės?") Then Exit Sub

            Using busy As New StatusBusy
                Try
                    ContractUpdate.DeleteContractUpdate(SelectedObj.ID)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try
            End Using

            MsgBox("Darbo sutarties pakeitimo duomenys sėkmingai pašalinti iš duomenų bazės.", _
                MsgBoxStyle.Information, "Info")

            RefreshButton_Click(Me, New EventArgs)

        End If

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