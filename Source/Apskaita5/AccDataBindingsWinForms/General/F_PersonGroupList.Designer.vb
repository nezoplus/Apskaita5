﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_PersonGroupList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_PersonGroupList))
        Me.PersonGroupListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.PersonGroupListDataListView = New BrightIdeasSoftware.DataListView
        Me.OlvColumn1 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn2 = New BrightIdeasSoftware.OLVColumn
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        CType(Me.PersonGroupListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PersonGroupListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PersonGroupListBindingSource
        '
        Me.PersonGroupListBindingSource.DataSource = GetType(ApskaitaObjects.General.PersonGroupList)
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.ICancelButton)
        Me.Panel2.Controls.Add(Me.IOkButton)
        Me.Panel2.Controls.Add(Me.IApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 292)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(454, 32)
        Me.Panel2.TabIndex = 53
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(353, 6)
        Me.ICancelButton.Name = "ICancelButton"
        Me.ICancelButton.Size = New System.Drawing.Size(89, 23)
        Me.ICancelButton.TabIndex = 14
        Me.ICancelButton.Text = "Atšaukti"
        Me.ICancelButton.UseVisualStyleBackColor = True
        '
        'IOkButton
        '
        Me.IOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IOkButton.Location = New System.Drawing.Point(147, 6)
        Me.IOkButton.Name = "IOkButton"
        Me.IOkButton.Size = New System.Drawing.Size(89, 23)
        Me.IOkButton.TabIndex = 13
        Me.IOkButton.Text = "Ok"
        Me.IOkButton.UseVisualStyleBackColor = True
        '
        'IApplyButton
        '
        Me.IApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IApplyButton.Location = New System.Drawing.Point(251, 6)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(89, 23)
        Me.IApplyButton.TabIndex = 12
        Me.IApplyButton.Text = "Išsaugoti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'PersonGroupListDataListView
        '
        Me.PersonGroupListDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.PersonGroupListDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.PersonGroupListDataListView.AllowColumnReorder = True
        Me.PersonGroupListDataListView.AutoGenerateColumns = False
        Me.PersonGroupListDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.PersonGroupListDataListView.CellEditEnterChangesRows = True
        Me.PersonGroupListDataListView.CellEditTabChangesRows = True
        Me.PersonGroupListDataListView.CellEditUseWholeCell = False
        Me.PersonGroupListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn1, Me.OlvColumn2})
        Me.PersonGroupListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.PersonGroupListDataListView.DataSource = Me.PersonGroupListBindingSource
        Me.PersonGroupListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonGroupListDataListView.FullRowSelect = True
        Me.PersonGroupListDataListView.HasCollapsibleGroups = False
        Me.PersonGroupListDataListView.HeaderWordWrap = True
        Me.PersonGroupListDataListView.HideSelection = False
        Me.PersonGroupListDataListView.IncludeColumnHeadersInCopy = True
        Me.PersonGroupListDataListView.Location = New System.Drawing.Point(0, 0)
        Me.PersonGroupListDataListView.Name = "PersonGroupListDataListView"
        Me.PersonGroupListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.PersonGroupListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.PersonGroupListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.PersonGroupListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.PersonGroupListDataListView.ShowCommandMenuOnRightClick = True
        Me.PersonGroupListDataListView.ShowGroups = False
        Me.PersonGroupListDataListView.ShowImagesOnSubItems = True
        Me.PersonGroupListDataListView.ShowItemCountOnGroups = True
        Me.PersonGroupListDataListView.ShowItemToolTips = True
        Me.PersonGroupListDataListView.Size = New System.Drawing.Size(454, 292)
        Me.PersonGroupListDataListView.TabIndex = 54
        Me.PersonGroupListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.PersonGroupListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.PersonGroupListDataListView.UseCellFormatEvents = True
        Me.PersonGroupListDataListView.UseCompatibleStateImageBehavior = False
        Me.PersonGroupListDataListView.UseFilterIndicator = True
        Me.PersonGroupListDataListView.UseFiltering = True
        Me.PersonGroupListDataListView.UseHotItem = True
        Me.PersonGroupListDataListView.UseNotifyPropertyChanged = True
        Me.PersonGroupListDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "Name"
        Me.OlvColumn1.CellEditUseWholeCell = True
        Me.OlvColumn1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn1.Text = "Grupės pavadinimas"
        Me.OlvColumn1.ToolTipText = ""
        Me.OlvColumn1.Width = 356
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "IsInUse"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.CheckBoxes = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.IsEditable = False
        Me.OlvColumn2.Text = "Naudojama"
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 76
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(12, 12)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(90, 47)
        Me.ProgressFiller1.TabIndex = 55
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(189, 10)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(113, 61)
        Me.ProgressFiller2.TabIndex = 56
        Me.ProgressFiller2.Visible = False
        '
        'F_PersonGroupList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 324)
        Me.Controls.Add(Me.PersonGroupListDataListView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_PersonGroupList"
        Me.ShowInTaskbar = False
        Me.Text = "Kontrahentų grupės"
        CType(Me.PersonGroupListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PersonGroupListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PersonGroupListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents PersonGroupListDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
End Class
