<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Templates
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_Templates))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.NewTemplateButton = New System.Windows.Forms.Button
        Me.TemplateJournalEntryListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TemplateJournalEntryListDataGridView = New System.Windows.Forms.DataGridView
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CorespondationListStringDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.TemplateJournalEntryListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TemplateJournalEntryListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.NewTemplateButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 389)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(499, 34)
        Me.Panel1.TabIndex = 1
        '
        'NewTemplateButton
        '
        Me.NewTemplateButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewTemplateButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewTemplateButton.Location = New System.Drawing.Point(396, 6)
        Me.NewTemplateButton.Name = "NewTemplateButton"
        Me.NewTemplateButton.Size = New System.Drawing.Size(91, 25)
        Me.NewTemplateButton.TabIndex = 2
        Me.NewTemplateButton.Text = "Nauja"
        Me.NewTemplateButton.UseVisualStyleBackColor = True
        '
        'TemplateJournalEntryListBindingSource
        '
        Me.TemplateJournalEntryListBindingSource.DataSource = GetType(ApskaitaObjects.HelperLists.TemplateJournalEntryInfo)
        '
        'TemplateJournalEntryListDataGridView
        '
        Me.TemplateJournalEntryListDataGridView.AllowUserToAddRows = False
        Me.TemplateJournalEntryListDataGridView.AllowUserToDeleteRows = False
        Me.TemplateJournalEntryListDataGridView.AutoGenerateColumns = False
        Me.TemplateJournalEntryListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.TemplateJournalEntryListDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TemplateJournalEntryListDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.TemplateJournalEntryListDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.ContentDataGridViewTextBoxColumn, Me.CorespondationListStringDataGridViewTextBoxColumn})
        Me.TemplateJournalEntryListDataGridView.DataSource = Me.TemplateJournalEntryListBindingSource
        Me.TemplateJournalEntryListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TemplateJournalEntryListDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.TemplateJournalEntryListDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.TemplateJournalEntryListDataGridView.MultiSelect = False
        Me.TemplateJournalEntryListDataGridView.Name = "TemplateJournalEntryListDataGridView"
        Me.TemplateJournalEntryListDataGridView.ReadOnly = True
        Me.TemplateJournalEntryListDataGridView.RowHeadersVisible = False
        Me.TemplateJournalEntryListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TemplateJournalEntryListDataGridView.Size = New System.Drawing.Size(499, 389)
        Me.TemplateJournalEntryListDataGridView.TabIndex = 2
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn.Visible = False
        Me.IDDataGridViewTextBoxColumn.Width = 45
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Pavadinimas"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.ReadOnly = True
        Me.NameDataGridViewTextBoxColumn.Width = 103
        '
        'ContentDataGridViewTextBoxColumn
        '
        Me.ContentDataGridViewTextBoxColumn.DataPropertyName = "Content"
        Me.ContentDataGridViewTextBoxColumn.HeaderText = "Operacijos turinys"
        Me.ContentDataGridViewTextBoxColumn.Name = "ContentDataGridViewTextBoxColumn"
        Me.ContentDataGridViewTextBoxColumn.ReadOnly = True
        Me.ContentDataGridViewTextBoxColumn.Width = 133
        '
        'CorespondationListStringDataGridViewTextBoxColumn
        '
        Me.CorespondationListStringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CorespondationListStringDataGridViewTextBoxColumn.DataPropertyName = "CorespondationListString"
        Me.CorespondationListStringDataGridViewTextBoxColumn.HeaderText = "Korespondencijos"
        Me.CorespondationListStringDataGridViewTextBoxColumn.Name = "CorespondationListStringDataGridViewTextBoxColumn"
        Me.CorespondationListStringDataGridViewTextBoxColumn.ReadOnly = True
        '
        'F_Templates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 423)
        Me.Controls.Add(Me.TemplateJournalEntryListDataGridView)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_Templates"
        Me.Text = "Tipinių operacijų sąrašas"
        Me.Panel1.ResumeLayout(False)
        CType(Me.TemplateJournalEntryListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TemplateJournalEntryListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents NewTemplateButton As System.Windows.Forms.Button
    Friend WithEvents TemplateJournalEntryListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TemplateJournalEntryListDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CorespondationListStringDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
