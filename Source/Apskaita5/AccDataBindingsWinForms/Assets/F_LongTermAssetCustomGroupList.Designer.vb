﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_LongTermAssetCustomGroupList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_LongTermAssetCustomGroupList))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.nCancelButton = New System.Windows.Forms.Button
        Me.ApplyButton = New System.Windows.Forms.Button
        Me.nOkButton = New System.Windows.Forms.Button
        Me.LongTermAssetCustomGroupListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LongTermAssetCustomGroupListDataListView = New BrightIdeasSoftware.DataListView
        Me.OlvColumn2 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn1 = New BrightIdeasSoftware.OLVColumn
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        Me.Panel2.SuspendLayout()
        CType(Me.LongTermAssetCustomGroupListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LongTermAssetCustomGroupListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.nCancelButton)
        Me.Panel2.Controls.Add(Me.ApplyButton)
        Me.Panel2.Controls.Add(Me.nOkButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 362)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Panel2.Size = New System.Drawing.Size(415, 42)
        Me.Panel2.TabIndex = 3
        '
        'nCancelButton
        '
        Me.nCancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.nCancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nCancelButton.Location = New System.Drawing.Point(328, 12)
        Me.nCancelButton.Name = "nCancelButton"
        Me.nCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.nCancelButton.TabIndex = 2
        Me.nCancelButton.Text = "Atšaukti"
        Me.nCancelButton.UseVisualStyleBackColor = True
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyButton.Location = New System.Drawing.Point(247, 12)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(75, 23)
        Me.ApplyButton.TabIndex = 1
        Me.ApplyButton.Text = "Taikyti"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'nOkButton
        '
        Me.nOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nOkButton.Location = New System.Drawing.Point(166, 12)
        Me.nOkButton.Name = "nOkButton"
        Me.nOkButton.Size = New System.Drawing.Size(75, 23)
        Me.nOkButton.TabIndex = 0
        Me.nOkButton.Text = "OK"
        Me.nOkButton.UseVisualStyleBackColor = True
        '
        'LongTermAssetCustomGroupListBindingSource
        '
        Me.LongTermAssetCustomGroupListBindingSource.DataSource = GetType(ApskaitaObjects.Assets.LongTermAssetCustomGroup)
        '
        'LongTermAssetCustomGroupListDataListView
        '
        Me.LongTermAssetCustomGroupListDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.LongTermAssetCustomGroupListDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.LongTermAssetCustomGroupListDataListView.AllowColumnReorder = True
        Me.LongTermAssetCustomGroupListDataListView.AutoGenerateColumns = False
        Me.LongTermAssetCustomGroupListDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.LongTermAssetCustomGroupListDataListView.CellEditEnterChangesRows = True
        Me.LongTermAssetCustomGroupListDataListView.CellEditTabChangesRows = True
        Me.LongTermAssetCustomGroupListDataListView.CellEditUseWholeCell = False
        Me.LongTermAssetCustomGroupListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2})
        Me.LongTermAssetCustomGroupListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.LongTermAssetCustomGroupListDataListView.DataSource = Me.LongTermAssetCustomGroupListBindingSource
        Me.LongTermAssetCustomGroupListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LongTermAssetCustomGroupListDataListView.FullRowSelect = True
        Me.LongTermAssetCustomGroupListDataListView.HasCollapsibleGroups = False
        Me.LongTermAssetCustomGroupListDataListView.HeaderWordWrap = True
        Me.LongTermAssetCustomGroupListDataListView.HideSelection = False
        Me.LongTermAssetCustomGroupListDataListView.IncludeColumnHeadersInCopy = True
        Me.LongTermAssetCustomGroupListDataListView.Location = New System.Drawing.Point(0, 0)
        Me.LongTermAssetCustomGroupListDataListView.Name = "LongTermAssetCustomGroupListDataListView"
        Me.LongTermAssetCustomGroupListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.LongTermAssetCustomGroupListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.LongTermAssetCustomGroupListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.LongTermAssetCustomGroupListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.LongTermAssetCustomGroupListDataListView.ShowCommandMenuOnRightClick = True
        Me.LongTermAssetCustomGroupListDataListView.ShowGroups = False
        Me.LongTermAssetCustomGroupListDataListView.ShowImagesOnSubItems = True
        Me.LongTermAssetCustomGroupListDataListView.ShowItemCountOnGroups = True
        Me.LongTermAssetCustomGroupListDataListView.ShowItemToolTips = True
        Me.LongTermAssetCustomGroupListDataListView.Size = New System.Drawing.Size(415, 362)
        Me.LongTermAssetCustomGroupListDataListView.TabIndex = 4
        Me.LongTermAssetCustomGroupListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.LongTermAssetCustomGroupListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.LongTermAssetCustomGroupListDataListView.UseCellFormatEvents = True
        Me.LongTermAssetCustomGroupListDataListView.UseCompatibleStateImageBehavior = False
        Me.LongTermAssetCustomGroupListDataListView.UseFilterIndicator = True
        Me.LongTermAssetCustomGroupListDataListView.UseFiltering = True
        Me.LongTermAssetCustomGroupListDataListView.UseHotItem = True
        Me.LongTermAssetCustomGroupListDataListView.UseNotifyPropertyChanged = True
        Me.LongTermAssetCustomGroupListDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "Name"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.FillsFreeSpace = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.Text = "Grupės pavadinimas"
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 100
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "ID"
        Me.OlvColumn1.CellEditUseWholeCell = True
        Me.OlvColumn1.DisplayIndex = 1
        Me.OlvColumn1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn1.IsEditable = False
        Me.OlvColumn1.IsVisible = False
        Me.OlvColumn1.Text = "ID"
        Me.OlvColumn1.ToolTipText = ""
        Me.OlvColumn1.Width = 100
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(147, 18)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(120, 46)
        Me.ProgressFiller1.TabIndex = 5
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(146, 77)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(146, 49)
        Me.ProgressFiller2.TabIndex = 6
        Me.ProgressFiller2.Visible = False
        '
        'F_LongTermAssetCustomGroupList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 404)
        Me.Controls.Add(Me.LongTermAssetCustomGroupListDataListView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_LongTermAssetCustomGroupList"
        Me.ShowInTaskbar = False
        Me.Text = "Ilgalaikio turto grupės"
        Me.Panel2.ResumeLayout(False)
        CType(Me.LongTermAssetCustomGroupListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LongTermAssetCustomGroupListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents nCancelButton As System.Windows.Forms.Button
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents nOkButton As System.Windows.Forms.Button
    Friend WithEvents LongTermAssetCustomGroupListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LongTermAssetCustomGroupListDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
End Class
