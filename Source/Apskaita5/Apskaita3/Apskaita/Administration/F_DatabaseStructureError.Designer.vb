﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_DatabaseStructureError
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_DatabaseStructureError))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RepairErrorsButton = New System.Windows.Forms.Button
        Me.FetchErrorsButton = New System.Windows.Forms.Button
        Me.DatabaseListComboBox = New System.Windows.Forms.ComboBox
        Me.DatabaseStructureErrorListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DatabaseStructureErrorListDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LocalFilePasswordTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.DatabaseStructureErrorListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatabaseStructureErrorListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LocalFilePasswordTextBox)
        Me.Panel1.Controls.Add(Me.RepairErrorsButton)
        Me.Panel1.Controls.Add(Me.FetchErrorsButton)
        Me.Panel1.Controls.Add(Me.DatabaseListComboBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Panel1.Size = New System.Drawing.Size(678, 63)
        Me.Panel1.TabIndex = 0
        '
        'RepairErrorsButton
        '
        Me.RepairErrorsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RepairErrorsButton.Enabled = False
        Me.RepairErrorsButton.Location = New System.Drawing.Point(586, 8)
        Me.RepairErrorsButton.Name = "RepairErrorsButton"
        Me.RepairErrorsButton.Size = New System.Drawing.Size(80, 23)
        Me.RepairErrorsButton.TabIndex = 2
        Me.RepairErrorsButton.Text = "Taisyti"
        Me.RepairErrorsButton.UseVisualStyleBackColor = True
        '
        'FetchErrorsButton
        '
        Me.FetchErrorsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FetchErrorsButton.Enabled = False
        Me.FetchErrorsButton.Location = New System.Drawing.Point(495, 8)
        Me.FetchErrorsButton.Name = "FetchErrorsButton"
        Me.FetchErrorsButton.Size = New System.Drawing.Size(76, 23)
        Me.FetchErrorsButton.TabIndex = 1
        Me.FetchErrorsButton.Text = "Tikrinti"
        Me.FetchErrorsButton.UseVisualStyleBackColor = True
        '
        'DatabaseListComboBox
        '
        Me.DatabaseListComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DatabaseListComboBox.FormattingEnabled = True
        Me.DatabaseListComboBox.Location = New System.Drawing.Point(12, 10)
        Me.DatabaseListComboBox.Name = "DatabaseListComboBox"
        Me.DatabaseListComboBox.Size = New System.Drawing.Size(460, 21)
        Me.DatabaseListComboBox.TabIndex = 0
        '
        'DatabaseStructureErrorListBindingSource
        '
        Me.DatabaseStructureErrorListBindingSource.DataSource = GetType(AccDataAccessLayer.DatabaseAccess.DatabaseStructure.DatabaseStructureError)
        '
        'DatabaseStructureErrorListDataGridView
        '
        Me.DatabaseStructureErrorListDataGridView.AllowUserToAddRows = False
        Me.DatabaseStructureErrorListDataGridView.AllowUserToDeleteRows = False
        Me.DatabaseStructureErrorListDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DatabaseStructureErrorListDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DatabaseStructureErrorListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DatabaseStructureErrorListDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewCheckBoxColumn3, Me.DataGridViewTextBoxColumn5})
        Me.DatabaseStructureErrorListDataGridView.DataSource = Me.DatabaseStructureErrorListBindingSource
        Me.DatabaseStructureErrorListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DatabaseStructureErrorListDataGridView.Location = New System.Drawing.Point(0, 63)
        Me.DatabaseStructureErrorListDataGridView.Name = "DatabaseStructureErrorListDataGridView"
        Me.DatabaseStructureErrorListDataGridView.RowHeadersVisible = False
        Me.DatabaseStructureErrorListDataGridView.Size = New System.Drawing.Size(678, 455)
        Me.DatabaseStructureErrorListDataGridView.TabIndex = 1
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "IsChecked"
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Description"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Klaidos aprašymas"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Table"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Lentelė"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Field"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Laukas"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "SqlStatementsToCorrect"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Alter statements"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "CanBeFixedAutomatically"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Gali būti automatiškai ištaisyta"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.ReadOnly = True
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "IsComplexError"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "Kompleksinė"
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ComplexErrorCode"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Kompleksinės klaidos kodas"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'LocalFilePasswordTextBox
        '
        Me.LocalFilePasswordTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LocalFilePasswordTextBox.Location = New System.Drawing.Point(79, 37)
        Me.LocalFilePasswordTextBox.MaxLength = 255
        Me.LocalFilePasswordTextBox.Name = "LocalFilePasswordTextBox"
        Me.LocalFilePasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.LocalFilePasswordTextBox.Size = New System.Drawing.Size(393, 20)
        Me.LocalFilePasswordTextBox.TabIndex = 3
        Me.LocalFilePasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Slaptažodis:"
        '
        'F_DatabaseStructureError
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 518)
        Me.Controls.Add(Me.DatabaseStructureErrorListDataGridView)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_DatabaseStructureError"
        Me.Text = "Duomenų bazės struktūros klaidos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DatabaseStructureErrorListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatabaseStructureErrorListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RepairErrorsButton As System.Windows.Forms.Button
    Friend WithEvents FetchErrorsButton As System.Windows.Forms.Button
    Friend WithEvents DatabaseListComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents DatabaseStructureErrorListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DatabaseStructureErrorListDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LocalFilePasswordTextBox As System.Windows.Forms.TextBox
End Class
