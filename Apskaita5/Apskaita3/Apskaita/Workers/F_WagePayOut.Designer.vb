<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_WagePayOut
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
        Dim DateLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim MonthLabel As System.Windows.Forms.Label
        Dim NumberLabel As System.Windows.Forms.Label
        Dim TypeHumanReadableLabel As System.Windows.Forms.Label
        Dim YearLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_WagePayOut))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.MonthTextBox = New System.Windows.Forms.TextBox
        Me.WagePayOutDocumentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.YearTextBox = New System.Windows.Forms.TextBox
        Me.NumberTextBox = New System.Windows.Forms.TextBox
        Me.TypeHumanReadableTextBox = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.CancelButton = New System.Windows.Forms.Button
        Me.ApplyButton = New System.Windows.Forms.Button
        Me.OkButton = New System.Windows.Forms.Button
        Me.ApplyCommonDateButton = New System.Windows.Forms.Button
        Me.CommonDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.ItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ReadWriteAuthorization1 = New Csla.Windows.ReadWriteAuthorization(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.DateTextBox = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        DateLabel = New System.Windows.Forms.Label
        IDLabel = New System.Windows.Forms.Label
        MonthLabel = New System.Windows.Forms.Label
        NumberLabel = New System.Windows.Forms.Label
        TypeHumanReadableLabel = New System.Windows.Forms.Label
        YearLabel = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        CType(Me.WagePayOutDocumentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DateLabel
        '
        DateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(DateLabel, False)
        DateLabel.AutoSize = True
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(1, 35)
        DateLabel.Margin = New System.Windows.Forms.Padding(1, 6, 1, 0)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(38, 13)
        DateLabel.TabIndex = 2
        DateLabel.Text = "Data:"
        '
        'IDLabel
        '
        IDLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(IDLabel, False)
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(15, 6)
        IDLabel.Margin = New System.Windows.Forms.Padding(1, 6, 1, 0)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(24, 13)
        IDLabel.TabIndex = 4
        IDLabel.Text = "ID:"
        '
        'MonthLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(MonthLabel, False)
        MonthLabel.AutoSize = True
        MonthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        MonthLabel.Location = New System.Drawing.Point(407, 3)
        MonthLabel.Margin = New System.Windows.Forms.Padding(1, 3, 1, 0)
        MonthLabel.Name = "MonthLabel"
        MonthLabel.Size = New System.Drawing.Size(49, 13)
        MonthLabel.TabIndex = 6
        MonthLabel.Text = "Mėnuo:"
        '
        'NumberLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(NumberLabel, False)
        NumberLabel.AutoSize = True
        NumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NumberLabel.Location = New System.Drawing.Point(123, 3)
        NumberLabel.Margin = New System.Windows.Forms.Padding(1, 3, 1, 0)
        NumberLabel.Name = "NumberLabel"
        NumberLabel.Size = New System.Drawing.Size(28, 13)
        NumberLabel.TabIndex = 8
        NumberLabel.Text = "Nr.:"
        '
        'TypeHumanReadableLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(TypeHumanReadableLabel, False)
        TypeHumanReadableLabel.AutoSize = True
        TypeHumanReadableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TypeHumanReadableLabel.Location = New System.Drawing.Point(140, 3)
        TypeHumanReadableLabel.Margin = New System.Windows.Forms.Padding(1, 3, 1, 0)
        TypeHumanReadableLabel.Name = "TypeHumanReadableLabel"
        TypeHumanReadableLabel.Size = New System.Drawing.Size(104, 13)
        TypeHumanReadableLabel.TabIndex = 12
        TypeHumanReadableLabel.Text = "Žiniaraščio tipas:"
        '
        'YearLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(YearLabel, False)
        YearLabel.AutoSize = True
        YearLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        YearLabel.Location = New System.Drawing.Point(275, 3)
        YearLabel.Margin = New System.Windows.Forms.Padding(1, 3, 1, 0)
        YearLabel.Name = "YearLabel"
        YearLabel.Size = New System.Drawing.Size(42, 13)
        YearLabel.TabIndex = 14
        YearLabel.Text = "Metai:"
        '
        'Label1
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Label1, False)
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(4, 22)
        Label1.Margin = New System.Windows.Forms.Padding(1, 6, 1, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(38, 13)
        Label1.TabIndex = 5
        Label1.Text = "Data:"
        '
        'Panel1
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.Panel1, False)
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Panel1.Size = New System.Drawing.Size(591, 3)
        Me.Panel1.TabIndex = 0
        '
        'MonthTextBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.MonthTextBox, False)
        Me.MonthTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.MonthTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.WagePayOutDocumentBindingSource, "Month", True))
        Me.MonthTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MonthTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MonthTextBox.Location = New System.Drawing.Point(459, 0)
        Me.MonthTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MonthTextBox.Name = "MonthTextBox"
        Me.MonthTextBox.ReadOnly = True
        Me.MonthTextBox.Size = New System.Drawing.Size(64, 20)
        Me.MonthTextBox.TabIndex = 7
        Me.MonthTextBox.TabStop = False
        Me.MonthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'WagePayOutDocumentBindingSource
        '
        Me.WagePayOutDocumentBindingSource.DataSource = GetType(ApskaitaObjects.Workers.WagePayOutDocument)
        '
        'IDTextBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.IDTextBox, False)
        Me.IDTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.WagePayOutDocumentBindingSource, "ID", True))
        Me.IDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IDTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IDTextBox.Location = New System.Drawing.Point(2, 0)
        Me.IDTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(115, 20)
        Me.IDTextBox.TabIndex = 5
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'YearTextBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.YearTextBox, False)
        Me.YearTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.YearTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.WagePayOutDocumentBindingSource, "Year", True))
        Me.YearTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.YearTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.YearTextBox.Location = New System.Drawing.Point(320, 0)
        Me.YearTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.YearTextBox.Name = "YearTextBox"
        Me.YearTextBox.ReadOnly = True
        Me.YearTextBox.Size = New System.Drawing.Size(64, 20)
        Me.YearTextBox.TabIndex = 15
        Me.YearTextBox.TabStop = False
        Me.YearTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumberTextBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.NumberTextBox, False)
        Me.NumberTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.NumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.WagePayOutDocumentBindingSource, "Number", True))
        Me.NumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NumberTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberTextBox.Location = New System.Drawing.Point(154, 0)
        Me.NumberTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.NumberTextBox.Name = "NumberTextBox"
        Me.NumberTextBox.ReadOnly = True
        Me.NumberTextBox.Size = New System.Drawing.Size(98, 20)
        Me.NumberTextBox.TabIndex = 9
        Me.NumberTextBox.TabStop = False
        Me.NumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TypeHumanReadableTextBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.TypeHumanReadableTextBox, False)
        Me.TypeHumanReadableTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.TypeHumanReadableTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.WagePayOutDocumentBindingSource, "TypeHumanReadable", True))
        Me.TypeHumanReadableTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TypeHumanReadableTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TypeHumanReadableTextBox.Location = New System.Drawing.Point(247, 0)
        Me.TypeHumanReadableTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TypeHumanReadableTextBox.Name = "TypeHumanReadableTextBox"
        Me.TypeHumanReadableTextBox.ReadOnly = True
        Me.TypeHumanReadableTextBox.Size = New System.Drawing.Size(274, 20)
        Me.TypeHumanReadableTextBox.TabIndex = 13
        Me.TypeHumanReadableTextBox.TabStop = False
        Me.TypeHumanReadableTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.Panel2, False)
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.CancelButton)
        Me.Panel2.Controls.Add(Me.ApplyButton)
        Me.Panel2.Controls.Add(Me.OkButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 485)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Panel2.Size = New System.Drawing.Size(591, 37)
        Me.Panel2.TabIndex = 3
        '
        'CancelButton
        '
        Me.CancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.CancelButton, False)
        Me.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelButton.Location = New System.Drawing.Point(508, 8)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton.TabIndex = 4
        Me.CancelButton.Text = "Atšaukti"
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.ApplyButton, False)
        Me.ApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyButton.Location = New System.Drawing.Point(427, 8)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(75, 23)
        Me.ApplyButton.TabIndex = 3
        Me.ApplyButton.Text = "Taikyti"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.OkButton, False)
        Me.OkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.Location = New System.Drawing.Point(346, 8)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 2
        Me.OkButton.Text = "OK"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'ApplyCommonDateButton
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.ApplyCommonDateButton, False)
        Me.ApplyCommonDateButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyCommonDateButton.Location = New System.Drawing.Point(177, 17)
        Me.ApplyCommonDateButton.Name = "ApplyCommonDateButton"
        Me.ApplyCommonDateButton.Size = New System.Drawing.Size(76, 23)
        Me.ApplyCommonDateButton.TabIndex = 1
        Me.ApplyCommonDateButton.Text = "Taikyti"
        Me.ApplyCommonDateButton.UseVisualStyleBackColor = True
        '
        'CommonDateTimePicker
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.CommonDateTimePicker, False)
        Me.CommonDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CommonDateTimePicker.Location = New System.Drawing.Point(45, 18)
        Me.CommonDateTimePicker.Name = "CommonDateTimePicker"
        Me.CommonDateTimePicker.Size = New System.Drawing.Size(126, 20)
        Me.CommonDateTimePicker.TabIndex = 0
        '
        'ItemsBindingSource
        '
        Me.ItemsBindingSource.DataMember = "Items"
        Me.ItemsBindingSource.DataSource = Me.WagePayOutDocumentBindingSource
        '
        'ItemsDataGridView
        '
        Me.ItemsDataGridView.AllowUserToAddRows = False
        Me.ItemsDataGridView.AllowUserToDeleteRows = False
        Me.ItemsDataGridView.AllowUserToOrderColumns = True
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.ItemsDataGridView, True)
        Me.ItemsDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ItemsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ItemsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.ItemsDataGridView.DataSource = Me.ItemsBindingSource
        Me.ItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemsDataGridView.Location = New System.Drawing.Point(0, 128)
        Me.ItemsDataGridView.MultiSelect = False
        Me.ItemsDataGridView.Name = "ItemsDataGridView"
        Me.ItemsDataGridView.RowHeadersVisible = False
        Me.ItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.ItemsDataGridView.Size = New System.Drawing.Size(591, 357)
        Me.ItemsDataGridView.TabIndex = 2
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 45
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "IsChecked"
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.MinimumWidth = 25
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 25
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "PersonID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Asmens ID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 92
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PersonName"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Vardas, Pavardė"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 134
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "PersonCode"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Asmens kodas"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 113
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ContractSerial"
        Me.DataGridViewTextBoxColumn5.HeaderText = "DS Serija"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 85
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ContractNumber"
        Me.DataGridViewTextBoxColumn6.HeaderText = "DS Nr."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 70
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "PayOffSum"
        DataGridViewCellStyle2.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn7.HeaderText = "Suma išmokėjimui:"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 40
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 40
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "PayOffDate"
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = "''"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn8.HeaderText = "Išmok. data"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 98
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.DataSource = Me.WagePayOutDocumentBindingSource
        '
        'TableLayoutPanel1
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.TableLayoutPanel1, False)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(DateLabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(585, 59)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.TableLayoutPanel3, False)
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TypeHumanReadableTextBox, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.IDTextBox, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(TypeHumanReadableLabel, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(40, 3)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(545, 23)
        Me.TableLayoutPanel3.TabIndex = 3
        '
        'TableLayoutPanel2
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.TableLayoutPanel2, False)
        Me.TableLayoutPanel2.ColumnCount = 11
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.DateTextBox, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.MonthTextBox, 9, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.NumberTextBox, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(NumberLabel, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(MonthLabel, 8, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.YearTextBox, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(YearLabel, 5, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(40, 32)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(545, 24)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'DateTextBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.DateTextBox, False)
        Me.DateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.WagePayOutDocumentBindingSource, "Date", True))
        Me.DateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTextBox.Location = New System.Drawing.Point(2, 0)
        Me.DateTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.DateTextBox.Name = "DateTextBox"
        Me.DateTextBox.ReadOnly = True
        Me.DateTextBox.Size = New System.Drawing.Size(98, 20)
        Me.DateTextBox.TabIndex = 6
        Me.DateTextBox.TabStop = False
        Me.DateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.GroupBox1, False)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(591, 78)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Žiniaraščio Bendra Informacija"
        '
        'GroupBox2
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.GroupBox2, False)
        Me.GroupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox2.Controls.Add(Me.ApplyCommonDateButton)
        Me.GroupBox2.Controls.Add(Label1)
        Me.GroupBox2.Controls.Add(Me.CommonDateTimePicker)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 81)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(591, 47)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Taikyti Datą Visiems Išmokėjimams"
        '
        'F_WagePayOut
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me, False)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 522)
        Me.Controls.Add(Me.ItemsDataGridView)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_WagePayOut"
        Me.ShowInTaskbar = False
        Me.Text = "Išmokėjimai darbuotojams pagal žiniaraštį"
        CType(Me.WagePayOutDocumentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents WagePayOutDocumentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MonthTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TypeHumanReadableTextBox As System.Windows.Forms.TextBox
    Friend WithEvents YearTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CancelButton As System.Windows.Forms.Button
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents ItemsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ReadWriteAuthorization1 As Csla.Windows.ReadWriteAuthorization
    Friend WithEvents CommonDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ApplyCommonDateButton As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
