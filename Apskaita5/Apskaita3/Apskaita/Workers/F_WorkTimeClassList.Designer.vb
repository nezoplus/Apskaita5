<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_WorkTimeClassList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_WorkTimeClassList))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.WorkTimeClassListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WorkTimeClassListDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TypeHumanReadableDataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn6 = New AccControls.DataGridViewAccTextBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.FetchTypicalWorkTimeClassListButton = New System.Windows.Forms.Button
        Me.Panel2.SuspendLayout()
        CType(Me.WorkTimeClassListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WorkTimeClassListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.FetchTypicalWorkTimeClassListButton)
        Me.Panel2.Controls.Add(Me.ICancelButton)
        Me.Panel2.Controls.Add(Me.IOkButton)
        Me.Panel2.Controls.Add(Me.IApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 374)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(862, 32)
        Me.Panel2.TabIndex = 54
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(761, 6)
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
        Me.IOkButton.Location = New System.Drawing.Point(555, 6)
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
        Me.IApplyButton.Location = New System.Drawing.Point(659, 6)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(89, 23)
        Me.IApplyButton.TabIndex = 12
        Me.IApplyButton.Text = "Išsaugoti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'WorkTimeClassListBindingSource
        '
        Me.WorkTimeClassListBindingSource.DataSource = GetType(ApskaitaObjects.Workers.WorkTimeClass)
        '
        'WorkTimeClassListDataGridView
        '
        Me.WorkTimeClassListDataGridView.AllowUserToOrderColumns = True
        Me.WorkTimeClassListDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkTimeClassListDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.WorkTimeClassListDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.TypeHumanReadableDataGridViewComboBoxColumn, Me.DataGridViewTextBoxColumn6, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn7, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewCheckBoxColumn3, Me.DataGridViewCheckBoxColumn4})
        Me.WorkTimeClassListDataGridView.DataSource = Me.WorkTimeClassListBindingSource
        Me.WorkTimeClassListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkTimeClassListDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.WorkTimeClassListDataGridView.Name = "WorkTimeClassListDataGridView"
        Me.WorkTimeClassListDataGridView.RowHeadersWidth = 20
        Me.WorkTimeClassListDataGridView.Size = New System.Drawing.Size(862, 374)
        Me.WorkTimeClassListDataGridView.TabIndex = 55
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Code"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Kodas"
        Me.DataGridViewTextBoxColumn2.MaxInputLength = 5
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Name"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Pavadinimas"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 255
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'TypeHumanReadableDataGridViewComboBoxColumn
        '
        Me.TypeHumanReadableDataGridViewComboBoxColumn.DataPropertyName = "TypeHumanReadable"
        Me.TypeHumanReadableDataGridViewComboBoxColumn.HeaderText = "Tipas"
        Me.TypeHumanReadableDataGridViewComboBoxColumn.Name = "TypeHumanReadableDataGridViewComboBoxColumn"
        Me.TypeHumanReadableDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TypeHumanReadableDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AllowNegative = False
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "InclusionPercentage"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn6.HeaderText = "Įskaitymo %"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "SpecialWageShemaApplicable"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Spec. Apm."
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ToolTipText = "Speciali apmokėjimo schema"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "SpecialWageShema"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Spec. Apm. formulė"
        Me.DataGridViewTextBoxColumn7.MaxInputLength = 255
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "WithoutWorkHours"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Be Val."
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "AlreadyIncludedInGeneralTime"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "Jau Įsk."
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.ToolTipText = "Jau įskaičiuota į bazinę eilutę"
        '
        'DataGridViewCheckBoxColumn4
        '
        Me.DataGridViewCheckBoxColumn4.DataPropertyName = "IsInUse"
        Me.DataGridViewCheckBoxColumn4.HeaderText = "Naudojama"
        Me.DataGridViewCheckBoxColumn4.Name = "DataGridViewCheckBoxColumn4"
        Me.DataGridViewCheckBoxColumn4.ReadOnly = True
        '
        'FetchTypicalWorkTimeClassListButton
        '
        Me.FetchTypicalWorkTimeClassListButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FetchTypicalWorkTimeClassListButton.Location = New System.Drawing.Point(12, 6)
        Me.FetchTypicalWorkTimeClassListButton.Name = "FetchTypicalWorkTimeClassListButton"
        Me.FetchTypicalWorkTimeClassListButton.Size = New System.Drawing.Size(89, 23)
        Me.FetchTypicalWorkTimeClassListButton.TabIndex = 15
        Me.FetchTypicalWorkTimeClassListButton.Text = "Tipinis"
        Me.FetchTypicalWorkTimeClassListButton.UseVisualStyleBackColor = True
        '
        'F_WorkTimeClassList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 406)
        Me.Controls.Add(Me.WorkTimeClassListDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_WorkTimeClassList"
        Me.ShowInTaskbar = False
        Me.Text = "Darbo laiko rūšys"
        Me.Panel2.ResumeLayout(False)
        CType(Me.WorkTimeClassListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WorkTimeClassListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents WorkTimeClassListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents WorkTimeClassListDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeHumanReadableDataGridViewComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FetchTypicalWorkTimeClassListButton As System.Windows.Forms.Button
End Class
