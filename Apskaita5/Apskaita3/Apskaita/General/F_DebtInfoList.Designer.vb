<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_DebtInfoList
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_DebtInfoList))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.IsBuyerRadioButton = New System.Windows.Forms.RadioButton
        Me.IsSupplierRadioButton = New System.Windows.Forms.RadioButton
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.AccountAccGridComboBox = New AccControls.AccGridComboBox
        Me.DateFromDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.DateToDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PersonGroupComboBox = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.RefreshButton = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ShowZeroDebtsCheckBox = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DebtInfoListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DebtInfoListDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DebtInfoListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DebtInfoListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.PersonGroupComboBox, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(780, 91)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.Controls.Add(Me.IsBuyerRadioButton, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.IsSupplierRadioButton, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(107, 33)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(670, 24)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'IsBuyerRadioButton
        '
        Me.IsBuyerRadioButton.AutoSize = True
        Me.IsBuyerRadioButton.Checked = True
        Me.IsBuyerRadioButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IsBuyerRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsBuyerRadioButton.Location = New System.Drawing.Point(603, 3)
        Me.IsBuyerRadioButton.Name = "IsBuyerRadioButton"
        Me.IsBuyerRadioButton.Size = New System.Drawing.Size(64, 18)
        Me.IsBuyerRadioButton.TabIndex = 1
        Me.IsBuyerRadioButton.TabStop = True
        Me.IsBuyerRadioButton.Text = "Pirkėjų"
        Me.IsBuyerRadioButton.UseVisualStyleBackColor = True
        '
        'IsSupplierRadioButton
        '
        Me.IsSupplierRadioButton.AutoSize = True
        Me.IsSupplierRadioButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IsSupplierRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsSupplierRadioButton.Location = New System.Drawing.Point(530, 3)
        Me.IsSupplierRadioButton.Name = "IsSupplierRadioButton"
        Me.IsSupplierRadioButton.Size = New System.Drawing.Size(67, 18)
        Me.IsSupplierRadioButton.TabIndex = 0
        Me.IsSupplierRadioButton.Text = "Tiekėjų"
        Me.IsSupplierRadioButton.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Controls.Add(Me.AccountAccGridComboBox, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DateFromDateTimePicker, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DateToDateTimePicker, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(107, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(670, 24)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'AccountAccGridComboBox
        '
        Me.AccountAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountAccGridComboBox.FilterPropertyName = ""
        Me.AccountAccGridComboBox.FormattingEnabled = True
        Me.AccountAccGridComboBox.InstantBinding = True
        Me.AccountAccGridComboBox.Location = New System.Drawing.Point(481, 3)
        Me.AccountAccGridComboBox.Name = "AccountAccGridComboBox"
        Me.AccountAccGridComboBox.Size = New System.Drawing.Size(186, 21)
        Me.AccountAccGridComboBox.TabIndex = 2
        '
        'DateFromDateTimePicker
        '
        Me.DateFromDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFromDateTimePicker.Location = New System.Drawing.Point(3, 3)
        Me.DateFromDateTimePicker.Name = "DateFromDateTimePicker"
        Me.DateFromDateTimePicker.Size = New System.Drawing.Size(185, 20)
        Me.DateFromDateTimePicker.TabIndex = 0
        '
        'DateToDateTimePicker
        '
        Me.DateToDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateToDateTimePicker.Location = New System.Drawing.Point(224, 3)
        Me.DateToDateTimePicker.Name = "DateToDateTimePicker"
        Me.DateToDateTimePicker.Size = New System.Drawing.Size(185, 20)
        Me.DateToDateTimePicker.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(415, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label3.Size = New System.Drawing.Size(60, 24)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Sąskaita:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(194, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(24, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "iki:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(98, 30)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Laikotarpis nuo:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(98, 31)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Asmenų grupė:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PersonGroupComboBox
        '
        Me.PersonGroupComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonGroupComboBox.FormattingEnabled = True
        Me.PersonGroupComboBox.Location = New System.Drawing.Point(107, 63)
        Me.PersonGroupComboBox.Name = "PersonGroupComboBox"
        Me.PersonGroupComboBox.Size = New System.Drawing.Size(670, 21)
        Me.PersonGroupComboBox.TabIndex = 3
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.Controls.Add(Me.RefreshButton, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(825, 97)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'RefreshButton
        '
        Me.RefreshButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Button_Reload_icon_24p
        Me.RefreshButton.Location = New System.Drawing.Point(789, 3)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(33, 34)
        Me.RefreshButton.TabIndex = 0
        Me.RefreshButton.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.ShowZeroDebtsCheckBox)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(831, 142)
        Me.Panel1.TabIndex = 0
        '
        'ShowZeroDebtsCheckBox
        '
        Me.ShowZeroDebtsCheckBox.AutoSize = True
        Me.ShowZeroDebtsCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowZeroDebtsCheckBox.Location = New System.Drawing.Point(113, 122)
        Me.ShowZeroDebtsCheckBox.Name = "ShowZeroDebtsCheckBox"
        Me.ShowZeroDebtsCheckBox.Size = New System.Drawing.Size(137, 17)
        Me.ShowZeroDebtsCheckBox.TabIndex = 1
        Me.ShowZeroDebtsCheckBox.Text = "Rodyti ne skolingus"
        Me.ShowZeroDebtsCheckBox.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(831, 116)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Gauti duomenis iš duomenų bazės"
        '
        'DebtInfoListBindingSource
        '
        Me.DebtInfoListBindingSource.DataSource = GetType(ApskaitaObjects.ActiveReports.DebtInfo)
        '
        'DebtInfoListDataGridView
        '
        Me.DebtInfoListDataGridView.AllowUserToAddRows = False
        Me.DebtInfoListDataGridView.AllowUserToDeleteRows = False
        Me.DebtInfoListDataGridView.AllowUserToOrderColumns = True
        Me.DebtInfoListDataGridView.AutoGenerateColumns = False
        Me.DebtInfoListDataGridView.CausesValidation = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DebtInfoListDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DebtInfoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DebtInfoListDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10})
        Me.DebtInfoListDataGridView.DataSource = Me.DebtInfoListBindingSource
        Me.DebtInfoListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DebtInfoListDataGridView.Location = New System.Drawing.Point(0, 142)
        Me.DebtInfoListDataGridView.Name = "DebtInfoListDataGridView"
        Me.DebtInfoListDataGridView.ReadOnly = True
        Me.DebtInfoListDataGridView.RowHeadersVisible = False
        Me.DebtInfoListDataGridView.Size = New System.Drawing.Size(831, 396)
        Me.DebtInfoListDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "PersonID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "PersonName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Pavadinimas (Vardas, Pavardė)"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PersonCode"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Kodas"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "PersonVatCode"
        Me.DataGridViewTextBoxColumn4.HeaderText = "PVM kodas"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "PersonAddress"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Adresas"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "PersonGroup"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Grupės"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "DebtBegin"
        DataGridViewCellStyle2.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn7.HeaderText = "Skola pradžioje"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "TurnoverDebet"
        DataGridViewCellStyle3.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn8.HeaderText = "Apyvarta debetas"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "TurnoverCredit"
        DataGridViewCellStyle4.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn9.HeaderText = "Apyvarta kreditas"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "DebtEnd"
        DataGridViewCellStyle5.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn10.HeaderText = "Skola pabaigoje"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'F_DebtInfoList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 538)
        Me.Controls.Add(Me.DebtInfoListDataGridView)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_DebtInfoList"
        Me.ShowInTaskbar = False
        Me.Text = "Skolų žiniaraštis"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DebtInfoListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DebtInfoListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents AccountAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents DateFromDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateToDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents IsSupplierRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents IsBuyerRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ShowZeroDebtsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DebtInfoListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DebtInfoListDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersonGroupComboBox As System.Windows.Forms.ComboBox
End Class
