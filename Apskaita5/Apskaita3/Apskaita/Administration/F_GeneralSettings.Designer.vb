<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_GeneralSettings
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
        Dim CodeWageGPMLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_GeneralSettings))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CancelButton = New System.Windows.Forms.Button
        Me.ApplyButton = New System.Windows.Forms.Button
        Me.OkButton = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.CodeWageGPMTextBox = New System.Windows.Forms.TextBox
        Me.CommonSettingsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TaxRatesDataGridView = New System.Windows.Forms.DataGridView
        Me.TaxRatesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReadWriteAuthorization1 = New Csla.Windows.ReadWriteAuthorization(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TaxTokenDataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn3 = New AccControls.DataGridViewAccTextBoxColumn
        CodeWageGPMLabel = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.CommonSettingsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.TaxRatesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TaxRatesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CodeWageGPMLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(CodeWageGPMLabel, False)
        CodeWageGPMLabel.AutoSize = True
        CodeWageGPMLabel.Location = New System.Drawing.Point(8, 17)
        CodeWageGPMLabel.Name = "CodeWageGPMLabel"
        CodeWageGPMLabel.Size = New System.Drawing.Size(215, 13)
        CodeWageGPMLabel.TabIndex = 0
        CodeWageGPMLabel.Text = "Darbo užmok. kodas GPM deklarac.:"
        '
        'Panel1
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.Panel1, False)
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.CancelButton)
        Me.Panel1.Controls.Add(Me.ApplyButton)
        Me.Panel1.Controls.Add(Me.OkButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 344)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Panel1.Size = New System.Drawing.Size(363, 39)
        Me.Panel1.TabIndex = 0
        '
        'CancelButton
        '
        Me.CancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.CancelButton, False)
        Me.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelButton.Location = New System.Drawing.Point(277, 9)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton.TabIndex = 2
        Me.CancelButton.Text = "Atšaukti"
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.ApplyButton, False)
        Me.ApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyButton.Location = New System.Drawing.Point(196, 9)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(75, 23)
        Me.ApplyButton.TabIndex = 1
        Me.ApplyButton.Text = "Taikyti"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.OkButton, False)
        Me.OkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.Location = New System.Drawing.Point(115, 9)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "OK"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.TabControl1, False)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(363, 344)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.TabPage1, False)
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(CodeWageGPMLabel)
        Me.TabPage1.Controls.Add(Me.CodeWageGPMTextBox)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(355, 318)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Mokesčiai darbo sant."
        '
        'CodeWageGPMTextBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.CodeWageGPMTextBox, False)
        Me.CodeWageGPMTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CommonSettingsBindingSource, "CodeWageGPM", True))
        Me.CodeWageGPMTextBox.Location = New System.Drawing.Point(229, 14)
        Me.CodeWageGPMTextBox.MaxLength = 15
        Me.CodeWageGPMTextBox.Name = "CodeWageGPMTextBox"
        Me.CodeWageGPMTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CodeWageGPMTextBox.TabIndex = 1
        Me.CodeWageGPMTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CommonSettingsBindingSource
        '
        Me.CommonSettingsBindingSource.DataSource = GetType(ApskaitaObjects.Settings.CommonSettings)
        '
        'TabPage2
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.TabPage2, False)
        Me.TabPage2.AutoScroll = True
        Me.TabPage2.Controls.Add(Me.TaxRatesDataGridView)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(355, 318)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Kitų mokesčių tarifai"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TaxRatesDataGridView
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.TaxRatesDataGridView, True)
        Me.TaxRatesDataGridView.AutoGenerateColumns = False
        Me.TaxRatesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.TaxRatesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.TaxRatesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TaxTokenDataGridViewComboBoxColumn, Me.DataGridViewTextBoxColumn3})
        Me.TaxRatesDataGridView.DataSource = Me.TaxRatesBindingSource
        Me.TaxRatesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TaxRatesDataGridView.Location = New System.Drawing.Point(3, 3)
        Me.TaxRatesDataGridView.MultiSelect = False
        Me.TaxRatesDataGridView.Name = "TaxRatesDataGridView"
        Me.TaxRatesDataGridView.Size = New System.Drawing.Size(349, 312)
        Me.TaxRatesDataGridView.TabIndex = 0
        '
        'TaxRatesBindingSource
        '
        Me.TaxRatesBindingSource.AllowNew = True
        Me.TaxRatesBindingSource.DataMember = "TaxRates"
        Me.TaxRatesBindingSource.DataSource = Me.CommonSettingsBindingSource
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.DataSource = Me.CommonSettingsBindingSource
        '
        'TaxTokenDataGridViewComboBoxColumn
        '
        Me.TaxTokenDataGridViewComboBoxColumn.DataPropertyName = "TaxTypeHumanReadable"
        Me.TaxTokenDataGridViewComboBoxColumn.HeaderText = "Tipas"
        Me.TaxTokenDataGridViewComboBoxColumn.Name = "TaxTokenDataGridViewComboBoxColumn"
        Me.TaxTokenDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TaxTokenDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.TaxTokenDataGridViewComboBoxColumn.Width = 63
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AllowNegative = False
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "TaxRate"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn3.HeaderText = "Mokesčio tarifas (%)"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'F_GeneralSettings
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me, False)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 383)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_GeneralSettings"
        Me.Text = "Bendri serverio pusės nustatymai"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.CommonSettingsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.TaxRatesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TaxRatesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents CommonSettingsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TaxRatesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TaxRatesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CancelButton As System.Windows.Forms.Button
    Friend WithEvents ReadWriteAuthorization1 As Csla.Windows.ReadWriteAuthorization
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents CodeWageGPMTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TaxTokenDataGridViewComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As AccControls.DataGridViewAccTextBoxColumn
End Class
