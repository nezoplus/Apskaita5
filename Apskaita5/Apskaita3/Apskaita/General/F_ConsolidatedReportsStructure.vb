Imports ApskaitaObjects.General

Public Class F_ConsolidatedReportsStructure

    Private Obj As ConsolidatedReport

    Private Sub F_ConsolidatedReportsStructure_Activated(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_ConsolidatedReportsStructure_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetFormLayout(Me)
    End Sub

    Private Sub F_ConsolidatedReportsStructure_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        ToolTip1.SetToolTip(Me.SaveAsFileButton, "Išsaugoti duomenis faile.")
        ToolTip1.SetToolTip(Me.SaveInDatabaseButton, "Išsaugoti duomenis įmonės duomenų bazėje.")
        ToolTip1.SetToolTip(Me.FetchFromDatabaseButton, "Gauti duomenis iš įmonės duomenų bazės.")
        ToolTip1.SetToolTip(Me.GetNewFormButton, "Nauja atskaitomybės struktūra.")
        ToolTip1.SetToolTip(Me.OpenFileButton, "Atidaryti failą su duomenimis.")
        ToolTip1.SetToolTip(Me.AddItemButton, "Pridėti dukterinį struktūros elementą (naują eilutę).")
        ToolTip1.SetToolTip(Me.RemoveItemButton, "Pašalinti struktūros elementą (eilutę).")
        ToolTip1.SetToolTip(Me.ItemUpButton, "Pakelti struktūros elementą (eilutę) aukštyn sąraše.")
        ToolTip1.SetToolTip(Me.ItemDownButton, "Nuleisti struktūros elementą (eilutę) žemyn sąraše.")

        SaveInDatabaseButton.Enabled = ConsolidatedReport.CanEditObject
        FetchFromDatabaseButton.Enabled = ConsolidatedReport.CanGetObject

        SetFormLayout(Me)

    End Sub

    Private Sub FetchFromDatabaseButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles FetchFromDatabaseButton.Click

        Try
            Obj = LoadObject(Of ConsolidatedReport)(Nothing, "GetConsolidatedReport", True)
            ConsolidatedReport.GetConsolidatedReport()
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        Using busy As New StatusBusy
            Try
                ConsolidatedReportToTree()
            Catch ex As Exception
                ShowError(ex)
            End Try
        End Using

        ReportView.Select()

    End Sub

    Private Sub GetNewFormButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles GetNewFormButton.Click

        Obj = ConsolidatedReport.GetNewConsolidatedReport
        ConsolidatedReportToTree()
        ReportView.Select()

    End Sub

    Private Sub OpenFileButton_Click(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles OpenFileButton.Click

        Dim FileName As String = ""

        Using OpenFile As New OpenFileDialog
            OpenFile.InitialDirectory = AppPath()
            OpenFile.Filter = "Ataskaitos forma|*.str|Visi failai|*.*"
            OpenFile.Multiselect = False
            If OpenFile.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
            FileName = OpenFile.FileName
        End Using

        If FileName Is Nothing OrElse String.IsNullOrEmpty(FileName.Trim) Then Exit Sub

        If Not IO.File.Exists(FileName) Then
            MsgBox("Klaida. Failas '" & FileName & "' neegzistuoja.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Using busy As New StatusBusy
            Try
                Obj = ConsolidatedReport.GetConsolidatedReportFromFile(FileName)
                ConsolidatedReportToTree()
            Catch ex As Exception
                ShowError(ex)
            End Try
        End Using

        ReportView.Select()

    End Sub

    Private Sub SaveAsFileButton_Click(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles SaveAsFileButton.Click

        If Obj Is Nothing Then Exit Sub

        If Not Obj.IsValid Then
            MsgBox("Ataskaitos formoje yra klaidų: " & Obj.GetAllBrokenRules, _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Dim FileName As String

        Using SaveFile As New SaveFileDialog
            SaveFile.InitialDirectory = AppPath()
            SaveFile.Filter = "Ataskaitos forma|*.str|Visi failai|*.*"
            SaveFile.AddExtension = True
            SaveFile.DefaultExt = ".str"
            If SaveFile.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
            FileName = SaveFile.FileName
        End Using

        If FileName Is Nothing OrElse String.IsNullOrEmpty(FileName.Trim) Then Exit Sub

        Using busy As New StatusBusy
            Try
                Obj.SaveToFile(FileName)
                MsgBox("Ataskaitos formos duomenys sėkmingai išsaugoti faile.", _
                    MsgBoxStyle.Information, "Info")
            Catch ex As Exception
                ShowError(ex)
            End Try
        End Using

        ReportView.Select()

    End Sub

    Private Sub SaveInDatabaseButton_Click(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles SaveInDatabaseButton.Click

        If Obj Is Nothing OrElse Not Obj.IsDirty Then Exit Sub

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų: " & Obj.GetAllBrokenRules, MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        If Obj.IsNew Then
            If Not YesOrNo("DĖMESIO. Jūs ketinate įkrauti visiškai naują finansinių ataskaitų " _
                & "rinkinio struktūrą. Po įkrovimo visos sąskaitos įmonės sąskaitų plane praras " _
                & "susiejimą su finansinių ataskaitų eilutėmis ir šį priskyrimą reikės iš naujo " _
                & "nustatyti sąskaitų plano formoje. Ar tikrai norite tęsti?") Then Exit Sub
        Else
            If Not YesOrNo("Ar tikrai norite išsaugoti ataskaitų formas įmonės duomenų bazėje?") Then Exit Sub
        End If

        Try
            Obj = LoadObject(Of ConsolidatedReport)(Obj, "Save", False)
            MsgBox("Ataskaitų formos duomenys sėkmingai išsaugoti duomenų bazėje.", _
                MsgBoxStyle.Information, "Info")
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        ReportView.Select()

    End Sub


    Private Sub AddItemButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AddItemButton.Click

        If ReportView.SelectedNode Is Nothing OrElse ReportView.SelectedNode.Tag Is Nothing Then Exit Sub

        If DirectCast(ReportView.SelectedNode.Tag, ConsolidatedReportItem).HasAccountsAssigned Then
            If Not YesOrNo("DĖMESIO. Šiai eilutei yra priskirtų apskaitos sąskaitų. " _
                & "Pridėjus subeilutę reikės pakeisti atitinkamų sąskaitų priskyrimą " _
                & "sąskaitų plane. Ar tikrai norite tęsti?") Then Exit Sub
        End If

        Dim NewChildItem As ConsolidatedReportItem = Nothing

        Try
            NewChildItem = DirectCast(ReportView.SelectedNode.Tag, ConsolidatedReportItem).AddChild()
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        If NewChildItem Is Nothing Then
            MsgBox("Klaida. Dėl neaiškių priežasčių nepavyko pridėti naujos eilutės.", _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Dim NewNode As New TreeNode("")
        NewNode.Tag = NewChildItem
        ReportView.SelectedNode.Nodes.Add(NewNode)
        ReportView.SelectedNode = NewNode
        NewNode.BeginEdit()

    End Sub

    Private Sub RemoveItemButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RemoveItemButton.Click

        If ReportView.SelectedNode Is Nothing OrElse ReportView.SelectedNode.Parent Is Nothing _
            OrElse ReportView.SelectedNode.Tag Is Nothing OrElse _
            ReportView.SelectedNode.Parent.Tag Is Nothing Then Exit Sub

        If DirectCast(ReportView.SelectedNode.Tag, ConsolidatedReportItem).HasAccountsAssigned Then
            If Not YesOrNo("DĖMESIO. Šiai eilutei yra priskirtų apskaitos sąskaitų. " _
                & "Ištrynus šią eilutę reikės pakeisti atitinkamų sąskaitų priskyrimą " _
                & "sąskaitų plane. Ar tikrai norite tęsti?") Then Exit Sub
        Else
            If Not YesOrNo("Ar tikrai norite pašalinti pasirinktą ataskaitos elementą?") Then Exit Sub
        End If

        Try
            DirectCast(ReportView.SelectedNode.Parent.Tag, ConsolidatedReportItem). _
                RemoveChild(DirectCast(ReportView.SelectedNode.Tag, ConsolidatedReportItem))
            ReportView.SelectedNode.Remove()
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

    End Sub

    Private Sub ItemUpButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ItemUpButton.Click

        If ReportView.SelectedNode Is Nothing OrElse ReportView.SelectedNode.Parent Is Nothing _
            OrElse ReportView.SelectedNode.Tag Is Nothing OrElse _
            ReportView.SelectedNode.Parent.Tag Is Nothing OrElse _
            ReportView.SelectedNode.Index = 0 Then Exit Sub

        Dim tmp As TreeNode = ReportView.SelectedNode.Clone

        Dim IndexToInsert As Integer = ReportView.SelectedNode.Index - 1
        Dim ParentNodes As TreeNodeCollection = ReportView.SelectedNode.Parent.Nodes
        Dim ParentItem As ConsolidatedReportItem = _
            DirectCast(ReportView.SelectedNode.Parent.Tag, ConsolidatedReportItem)

        Try
            DirectCast(ReportView.SelectedNode.Parent.Tag, ConsolidatedReportItem). _
                MoveChildUp(DirectCast(ReportView.SelectedNode.Tag, ConsolidatedReportItem))
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        ParentNodes.RemoveAt(ReportView.SelectedNode.Index)
        ParentNodes.Insert(IndexToInsert, tmp)
        ParentNodes.Item(IndexToInsert).Tag = ParentItem.Children(IndexToInsert)
        ParentNodes.Item(IndexToInsert + 1).Tag = ParentItem.Children(IndexToInsert + 1)

        ReportView.SelectedNode = tmp

    End Sub

    Private Sub ItemDownButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ItemDownButton.Click

        If ReportView.SelectedNode Is Nothing OrElse ReportView.SelectedNode.Parent Is Nothing _
            OrElse ReportView.SelectedNode.Tag Is Nothing OrElse _
            ReportView.SelectedNode.Parent.Tag Is Nothing OrElse _
            ReportView.SelectedNode.Index = ReportView.SelectedNode.Parent.Nodes.Count - 1 Then Exit Sub

        Dim tmp As TreeNode = ReportView.SelectedNode.Clone
        Dim IndexToInsert As Integer = ReportView.SelectedNode.Index + 1
        Dim ParentNodes As TreeNodeCollection = ReportView.SelectedNode.Parent.Nodes

        Try
            DirectCast(ReportView.SelectedNode.Parent.Tag, ConsolidatedReportItem). _
                MoveChildDown(DirectCast(ReportView.SelectedNode.Tag, ConsolidatedReportItem))
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        ParentNodes.RemoveAt(ReportView.SelectedNode.Index)
        ParentNodes.Insert(IndexToInsert, tmp)
        ParentNodes.Item(IndexToInsert).Tag = DirectCast(ReportView.SelectedNode.Parent.Tag, _
            ConsolidatedReportItem).Children(IndexToInsert)
        ParentNodes.Item(IndexToInsert - 1).Tag = DirectCast(ReportView.SelectedNode.Parent.Tag, _
            ConsolidatedReportItem).Children(IndexToInsert - 1)

        ReportView.SelectedNode = tmp

    End Sub

    Private Sub ReportView_BeforeCheck(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles ReportView.BeforeCheck
        If e.Node Is Nothing OrElse e.Node.Tag Is Nothing OrElse e.Node.Level < 2 Then _
            e.Cancel = True
    End Sub

    Private Sub ReportView_BeforeLabelEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles ReportView.BeforeLabelEdit
        If e.Node Is Nothing OrElse e.Node.Tag Is Nothing OrElse e.Node.Level < 2 Then _
            e.CancelEdit = True
    End Sub

    Private Sub ReportView_AfterLabelEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles ReportView.AfterLabelEdit
        If e.Node Is Nothing OrElse e.Node.Tag Is Nothing OrElse e.Node.Level < 2 Then
            e.CancelEdit = True
        Else
            DirectCast(e.Node.Tag, ConsolidatedReportItem).Name = e.Label
        End If
    End Sub

    Private Sub ReportView_AfterCheck(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles ReportView.AfterCheck
        If Not e.Node Is Nothing AndAlso Not e.Node.Tag Is Nothing AndAlso e.Node.Level > 1 Then _
            DirectCast(e.Node.Tag, ConsolidatedReportItem).IsCredit = e.Node.Checked
    End Sub

    Private Sub ReportView_AfterSelect(ByVal sender As System.Object, _
            ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles ReportView.AfterSelect
        ' enables/disables buttons depending on the selected node position

        ' no selected node, no editing buttons
        If ReportView.SelectedNode Is Nothing Then
            AddItemButton.Enabled = False
            RemoveItemButton.Enabled = False
            ItemUpButton.Enabled = False
            ItemDownButton.Enabled = False
            Exit Sub
        End If

        ' can only remove nodes, if they are not of the top level
        RemoveItemButton.Enabled = (ReportView.SelectedNode.Level > 2)
        ' can always add new nodes to the existing one
        AddItemButton.Enabled = (ReportView.SelectedNode.Level > 1)
        ' node can only be moved up if it's not the first node.
        ItemUpButton.Enabled = (ReportView.SelectedNode.Level > 2 AndAlso ReportView.SelectedNode.Index > 0)
        ' node can only be moved down if it's not the last node.
        Dim parentNodesCount As Integer
        If ReportView.SelectedNode.Parent Is Nothing Then
            parentNodesCount = ReportView.Nodes.Count
        Else
            parentNodesCount = ReportView.SelectedNode.Parent.Nodes.Count
        End If
        ItemDownButton.Enabled = (ReportView.SelectedNode.Level > 2 AndAlso _
            ReportView.SelectedNode.Index < (parentNodesCount - 1))

    End Sub


    ''' <summary>
    ''' Maps the ConsolidatedReport object to the TreeView control.
    ''' </summary>
    Private Sub ConsolidatedReportToTree()

        Using busy As New StatusBusy
            ReportView.Nodes.Clear()
            ConsolidatedReportItemListToNode(Obj.Children, ReportView.Nodes)
            ReportView.ExpandAll()
            ReportView_AfterSelect(Me, New TreeViewEventArgs(ReportView.SelectedNode))
        End Using

        For Each n As TreeNode In ReportView.Nodes
            n.ForeColor = Color.DarkBlue
            For Each n2 As TreeNode In n.Nodes
                n2.ForeColor = Color.DarkBlue
            Next
        Next

    End Sub

    ''' <summary>
    ''' Helper method. Recursevely maps the ConsolidatedReport object to the TreeView control.
    ''' </summary>
    Private Sub ConsolidatedReportItemListToNode(ByVal ChildList As ConsolidatedReportItem, _
        ByRef CurrentNode As TreeNodeCollection)

        Dim NewNode As New TreeNode(ChildList.Name)
        NewNode.Checked = ChildList.IsCredit
        NewNode.Tag = ChildList
        For Each c As ConsolidatedReportItem In ChildList.Children
            ConsolidatedReportItemListToNode(c, NewNode.Nodes)
        Next
        CurrentNode.Add(NewNode)

    End Sub

End Class