<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_AccountTurnoverInfo
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
        Dim CreditBalanceEndLabel As System.Windows.Forms.Label
        Dim CreditBalanceStartLabel As System.Windows.Forms.Label
        Dim CreditTurnoverLabel As System.Windows.Forms.Label
        Dim DebetBalanceEndLabel As System.Windows.Forms.Label
        Dim DebetBalanceStartLabel As System.Windows.Forms.Label
        Dim DebetTurnoverLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_AccountTurnoverInfo))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.PersonAccGridComboBox = New AccControls.AccGridComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.PersonGroupComboBox = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.AccountAccGridComboBox = New AccControls.AccGridComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.IncludeSubAccountsCheckBox = New System.Windows.Forms.CheckBox
        Me.DateFromDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.DateToDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.ClearButton = New System.Windows.Forms.Button
        Me.RefreshButton = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.ItemsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BookEntriesString = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BookEntryInfoListParentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.CreditBalanceEndAccBox = New AccControls.AccTextBox
        Me.CreditTurnoverAccBox = New AccControls.AccTextBox
        Me.DebetBalanceEndAccBox = New AccControls.AccTextBox
        Me.DebetTurnoverAccBox = New AccControls.AccTextBox
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.CreditBalanceStartAccBox = New AccControls.AccTextBox
        Me.DebetBalanceStartAccBox = New AccControls.AccTextBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.CorrespondationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RelationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CreditBalanceEndLabel = New System.Windows.Forms.Label
        CreditBalanceStartLabel = New System.Windows.Forms.Label
        CreditTurnoverLabel = New System.Windows.Forms.Label
        DebetBalanceEndLabel = New System.Windows.Forms.Label
        DebetBalanceStartLabel = New System.Windows.Forms.Label
        DebetTurnoverLabel = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.ItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BookEntryInfoListParentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CreditBalanceEndLabel
        '
        CreditBalanceEndLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        CreditBalanceEndLabel.AutoSize = True
        CreditBalanceEndLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CreditBalanceEndLabel.Location = New System.Drawing.Point(351, 32)
        CreditBalanceEndLabel.Name = "CreditBalanceEndLabel"
        CreditBalanceEndLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        CreditBalanceEndLabel.Size = New System.Drawing.Size(147, 18)
        CreditBalanceEndLabel.TabIndex = 2
        CreditBalanceEndLabel.Text = "Kredito likutis pabaigoje:"
        '
        'CreditBalanceStartLabel
        '
        CreditBalanceStartLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        CreditBalanceStartLabel.AutoSize = True
        CreditBalanceStartLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CreditBalanceStartLabel.Location = New System.Drawing.Point(353, 3)
        CreditBalanceStartLabel.Name = "CreditBalanceStartLabel"
        CreditBalanceStartLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        CreditBalanceStartLabel.Size = New System.Drawing.Size(143, 18)
        CreditBalanceStartLabel.TabIndex = 4
        CreditBalanceStartLabel.Text = "Kredito likutis pradžioje:"
        '
        'CreditTurnoverLabel
        '
        CreditTurnoverLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        CreditTurnoverLabel.AutoSize = True
        CreditTurnoverLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CreditTurnoverLabel.Location = New System.Drawing.Point(394, 3)
        CreditTurnoverLabel.Name = "CreditTurnoverLabel"
        CreditTurnoverLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        CreditTurnoverLabel.Size = New System.Drawing.Size(104, 18)
        CreditTurnoverLabel.TabIndex = 6
        CreditTurnoverLabel.Text = "Kredito apyvarta:"
        '
        'DebetBalanceEndLabel
        '
        DebetBalanceEndLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DebetBalanceEndLabel.AutoSize = True
        DebetBalanceEndLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DebetBalanceEndLabel.Location = New System.Drawing.Point(6, 32)
        DebetBalanceEndLabel.Name = "DebetBalanceEndLabel"
        DebetBalanceEndLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        DebetBalanceEndLabel.Size = New System.Drawing.Size(148, 18)
        DebetBalanceEndLabel.TabIndex = 12
        DebetBalanceEndLabel.Text = "Debeto likutis pabaigoje:"
        '
        'DebetBalanceStartLabel
        '
        DebetBalanceStartLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DebetBalanceStartLabel.AutoSize = True
        DebetBalanceStartLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DebetBalanceStartLabel.Location = New System.Drawing.Point(6, 3)
        DebetBalanceStartLabel.Name = "DebetBalanceStartLabel"
        DebetBalanceStartLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        DebetBalanceStartLabel.Size = New System.Drawing.Size(144, 18)
        DebetBalanceStartLabel.TabIndex = 14
        DebetBalanceStartLabel.Text = "Debeto likutis pradžioje:"
        '
        'DebetTurnoverLabel
        '
        DebetTurnoverLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DebetTurnoverLabel.AutoSize = True
        DebetTurnoverLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DebetTurnoverLabel.Location = New System.Drawing.Point(49, 3)
        DebetTurnoverLabel.Name = "DebetTurnoverLabel"
        DebetTurnoverLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        DebetTurnoverLabel.Size = New System.Drawing.Size(105, 18)
        DebetTurnoverLabel.TabIndex = 16
        DebetTurnoverLabel.Text = "Debeto apyvarta:"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.ClearButton)
        Me.Panel1.Controls.Add(Me.RefreshButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(771, 178)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(747, 130)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro kriterijai"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.PersonAccGridComboBox, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.PersonGroupComboBox, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 70)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(741, 57)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'PersonAccGridComboBox
        '
        Me.PersonAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonAccGridComboBox.EmptyValueString = ""
        Me.PersonAccGridComboBox.FilterPropertyName = ""
        Me.PersonAccGridComboBox.FormattingEnabled = True
        Me.PersonAccGridComboBox.InstantBinding = True
        Me.PersonAccGridComboBox.Location = New System.Drawing.Point(108, 31)
        Me.PersonAccGridComboBox.Name = "PersonAccGridComboBox"
        Me.PersonAccGridComboBox.Size = New System.Drawing.Size(630, 21)
        Me.PersonAccGridComboBox.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(99, 29)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Asmuo:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label6.Size = New System.Drawing.Size(99, 28)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "Asm. grupė:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PersonGroupComboBox
        '
        Me.PersonGroupComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonGroupComboBox.FormattingEnabled = True
        Me.PersonGroupComboBox.Location = New System.Drawing.Point(108, 3)
        Me.PersonGroupComboBox.Name = "PersonGroupComboBox"
        Me.PersonGroupComboBox.Size = New System.Drawing.Size(630, 21)
        Me.PersonGroupComboBox.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.AccountAccGridComboBox, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.IncludeSubAccountsCheckBox, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DateFromDateTimePicker, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DateToDateTimePicker, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(741, 54)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(99, 27)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Data nuo:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AccountAccGridComboBox
        '
        Me.AccountAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountAccGridComboBox.EmptyValueString = ""
        Me.AccountAccGridComboBox.FilterPropertyName = ""
        Me.AccountAccGridComboBox.FormattingEnabled = True
        Me.AccountAccGridComboBox.InstantBinding = True
        Me.AccountAccGridComboBox.Location = New System.Drawing.Point(551, 3)
        Me.AccountAccGridComboBox.Name = "AccountAccGridComboBox"
        Me.AccountAccGridComboBox.Size = New System.Drawing.Size(187, 21)
        Me.AccountAccGridComboBox.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(251, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label13.Size = New System.Drawing.Size(72, 27)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "Data iki:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(472, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(73, 27)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Sąskaita:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'IncludeSubAccountsCheckBox
        '
        Me.IncludeSubAccountsCheckBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IncludeSubAccountsCheckBox.AutoSize = True
        Me.IncludeSubAccountsCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IncludeSubAccountsCheckBox.Location = New System.Drawing.Point(551, 30)
        Me.IncludeSubAccountsCheckBox.Name = "IncludeSubAccountsCheckBox"
        Me.IncludeSubAccountsCheckBox.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.IncludeSubAccountsCheckBox.Size = New System.Drawing.Size(187, 20)
        Me.IncludeSubAccountsCheckBox.TabIndex = 3
        Me.IncludeSubAccountsCheckBox.Text = "Įtraukti subsąskaitas"
        Me.IncludeSubAccountsCheckBox.UseVisualStyleBackColor = True
        '
        'DateFromDateTimePicker
        '
        Me.DateFromDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFromDateTimePicker.Location = New System.Drawing.Point(108, 3)
        Me.DateFromDateTimePicker.Name = "DateFromDateTimePicker"
        Me.DateFromDateTimePicker.Size = New System.Drawing.Size(137, 20)
        Me.DateFromDateTimePicker.TabIndex = 0
        '
        'DateToDateTimePicker
        '
        Me.DateToDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateToDateTimePicker.Location = New System.Drawing.Point(329, 3)
        Me.DateToDateTimePicker.Name = "DateToDateTimePicker"
        Me.DateToDateTimePicker.Size = New System.Drawing.Size(137, 20)
        Me.DateToDateTimePicker.TabIndex = 1
        '
        'ClearButton
        '
        Me.ClearButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClearButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearButton.Location = New System.Drawing.Point(624, 145)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(68, 26)
        Me.ClearButton.TabIndex = 1
        Me.ClearButton.Text = "Išvalyti"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'RefreshButton
        '
        Me.RefreshButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RefreshButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Button_Reload_icon_24p
        Me.RefreshButton.Location = New System.Drawing.Point(717, 142)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(33, 33)
        Me.RefreshButton.TabIndex = 2
        Me.RefreshButton.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ItemsDataGridView)
        Me.Panel3.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel3.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 178)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(771, 388)
        Me.Panel3.TabIndex = 1
        '
        'ItemsDataGridView
        '
        Me.ItemsDataGridView.AllowUserToAddRows = False
        Me.ItemsDataGridView.AllowUserToDeleteRows = False
        Me.ItemsDataGridView.AllowUserToOrderColumns = True
        Me.ItemsDataGridView.AutoGenerateColumns = False
        Me.ItemsDataGridView.CausesValidation = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ItemsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ItemsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.BookEntriesString})
        Me.ItemsDataGridView.DataSource = Me.ItemsBindingSource
        Me.ItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.ItemsDataGridView.Location = New System.Drawing.Point(0, 30)
        Me.ItemsDataGridView.Name = "ItemsDataGridView"
        Me.ItemsDataGridView.ReadOnly = True
        Me.ItemsDataGridView.RowHeadersVisible = False
        Me.ItemsDataGridView.ShowCellErrors = False
        Me.ItemsDataGridView.ShowCellToolTips = False
        Me.ItemsDataGridView.ShowEditingIcon = False
        Me.ItemsDataGridView.ShowRowErrors = False
        Me.ItemsDataGridView.Size = New System.Drawing.Size(771, 292)
        Me.ItemsDataGridView.TabIndex = 2
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "JournalEntryID"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn2.HeaderText = "BŽ ID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 65
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "JournalEntryDate"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn3.HeaderText = "Data"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 59
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "DocTypeHumanReadable"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn5.HeaderText = "Dok. tipas"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 90
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "DocNumber"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn6.HeaderText = "Dok. Nr."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 80
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Content"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn7.HeaderText = "Operacijos turinys"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 133
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "DebetTurnover"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Format = "##,0.00"
        DataGridViewCellStyle7.NullValue = "0.00"
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn8.HeaderText = "Debetas"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 106
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "CreditTurnover"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Format = "##,0.00"
        DataGridViewCellStyle8.NullValue = "0.00"
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn9.HeaderText = "Kreditas"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 105
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Person"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn10.HeaderText = "Susietas asmuo"
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 70
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 120
        '
        'BookEntriesString
        '
        Me.BookEntriesString.DataPropertyName = "BookEntriesString"
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BookEntriesString.DefaultCellStyle = DataGridViewCellStyle10
        Me.BookEntriesString.HeaderText = "Korespondencijos"
        Me.BookEntriesString.Name = "BookEntriesString"
        Me.BookEntriesString.ReadOnly = True
        Me.BookEntriesString.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BookEntriesString.Width = 10
        '
        'ItemsBindingSource
        '
        Me.ItemsBindingSource.DataMember = "ItemsSortable"
        Me.ItemsBindingSource.DataSource = Me.BookEntryInfoListParentBindingSource
        '
        'BookEntryInfoListParentBindingSource
        '
        Me.BookEntryInfoListParentBindingSource.DataSource = GetType(ApskaitaObjects.ActiveReports.BookEntryInfoListParent)
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel4.ColumnCount = 5
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.CreditBalanceEndAccBox, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(CreditBalanceEndLabel, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.CreditTurnoverAccBox, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(DebetTurnoverLabel, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(DebetBalanceEndLabel, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(CreditTurnoverLabel, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.DebetBalanceEndAccBox, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.DebetTurnoverAccBox, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 322)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(771, 61)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'CreditBalanceEndAccBox
        '
        Me.CreditBalanceEndAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BookEntryInfoListParentBindingSource, "CreditBalanceEnd", True))
        Me.CreditBalanceEndAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CreditBalanceEndAccBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreditBalanceEndAccBox.KeepBackColorWhenReadOnly = False
        Me.CreditBalanceEndAccBox.Location = New System.Drawing.Point(507, 35)
        Me.CreditBalanceEndAccBox.Name = "CreditBalanceEndAccBox"
        Me.CreditBalanceEndAccBox.NegativeValue = False
        Me.CreditBalanceEndAccBox.ReadOnly = True
        Me.CreditBalanceEndAccBox.Size = New System.Drawing.Size(179, 20)
        Me.CreditBalanceEndAccBox.TabIndex = 3
        Me.CreditBalanceEndAccBox.TabStop = False
        Me.CreditBalanceEndAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CreditTurnoverAccBox
        '
        Me.CreditTurnoverAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BookEntryInfoListParentBindingSource, "CreditTurnover", True))
        Me.CreditTurnoverAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CreditTurnoverAccBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreditTurnoverAccBox.KeepBackColorWhenReadOnly = False
        Me.CreditTurnoverAccBox.Location = New System.Drawing.Point(507, 6)
        Me.CreditTurnoverAccBox.Name = "CreditTurnoverAccBox"
        Me.CreditTurnoverAccBox.NegativeValue = False
        Me.CreditTurnoverAccBox.ReadOnly = True
        Me.CreditTurnoverAccBox.Size = New System.Drawing.Size(179, 20)
        Me.CreditTurnoverAccBox.TabIndex = 7
        Me.CreditTurnoverAccBox.TabStop = False
        Me.CreditTurnoverAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DebetBalanceEndAccBox
        '
        Me.DebetBalanceEndAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BookEntryInfoListParentBindingSource, "DebetBalanceEnd", True))
        Me.DebetBalanceEndAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DebetBalanceEndAccBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebetBalanceEndAccBox.KeepBackColorWhenReadOnly = False
        Me.DebetBalanceEndAccBox.Location = New System.Drawing.Point(163, 35)
        Me.DebetBalanceEndAccBox.Name = "DebetBalanceEndAccBox"
        Me.DebetBalanceEndAccBox.NegativeValue = False
        Me.DebetBalanceEndAccBox.ReadOnly = True
        Me.DebetBalanceEndAccBox.Size = New System.Drawing.Size(179, 20)
        Me.DebetBalanceEndAccBox.TabIndex = 13
        Me.DebetBalanceEndAccBox.TabStop = False
        Me.DebetBalanceEndAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DebetTurnoverAccBox
        '
        Me.DebetTurnoverAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BookEntryInfoListParentBindingSource, "DebetTurnover", True))
        Me.DebetTurnoverAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DebetTurnoverAccBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebetTurnoverAccBox.KeepBackColorWhenReadOnly = False
        Me.DebetTurnoverAccBox.Location = New System.Drawing.Point(163, 6)
        Me.DebetTurnoverAccBox.Name = "DebetTurnoverAccBox"
        Me.DebetTurnoverAccBox.NegativeValue = False
        Me.DebetTurnoverAccBox.ReadOnly = True
        Me.DebetTurnoverAccBox.Size = New System.Drawing.Size(179, 20)
        Me.DebetTurnoverAccBox.TabIndex = 17
        Me.DebetTurnoverAccBox.TabStop = False
        Me.DebetTurnoverAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.CreditBalanceStartAccBox, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(CreditBalanceStartLabel, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(DebetBalanceStartLabel, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.DebetBalanceStartAccBox, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(771, 30)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'CreditBalanceStartAccBox
        '
        Me.CreditBalanceStartAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BookEntryInfoListParentBindingSource, "CreditBalanceStart", True))
        Me.CreditBalanceStartAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CreditBalanceStartAccBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreditBalanceStartAccBox.KeepBackColorWhenReadOnly = False
        Me.CreditBalanceStartAccBox.Location = New System.Drawing.Point(505, 6)
        Me.CreditBalanceStartAccBox.Name = "CreditBalanceStartAccBox"
        Me.CreditBalanceStartAccBox.NegativeValue = False
        Me.CreditBalanceStartAccBox.ReadOnly = True
        Me.CreditBalanceStartAccBox.Size = New System.Drawing.Size(185, 20)
        Me.CreditBalanceStartAccBox.TabIndex = 5
        Me.CreditBalanceStartAccBox.TabStop = False
        Me.CreditBalanceStartAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DebetBalanceStartAccBox
        '
        Me.DebetBalanceStartAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BookEntryInfoListParentBindingSource, "DebetBalanceStart", True))
        Me.DebetBalanceStartAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DebetBalanceStartAccBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebetBalanceStartAccBox.KeepBackColorWhenReadOnly = False
        Me.DebetBalanceStartAccBox.Location = New System.Drawing.Point(159, 6)
        Me.DebetBalanceStartAccBox.Name = "DebetBalanceStartAccBox"
        Me.DebetBalanceStartAccBox.NegativeValue = False
        Me.DebetBalanceStartAccBox.ReadOnly = True
        Me.DebetBalanceStartAccBox.Size = New System.Drawing.Size(185, 20)
        Me.DebetBalanceStartAccBox.TabIndex = 15
        Me.DebetBalanceStartAccBox.TabStop = False
        Me.DebetBalanceStartAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel5
        '
        Me.Panel5.AutoSize = True
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 383)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.Panel5.Size = New System.Drawing.Size(771, 5)
        Me.Panel5.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripSeparator1, Me.CorrespondationsToolStripMenuItem, Me.RelationsToolStripMenuItem, Me.ToolStripSeparator2, Me.CancelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(169, 126)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.AutoToolTip = True
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.EditToolStripMenuItem.Text = "Keisti"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.AutoToolTip = True
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DeleteToolStripMenuItem.Text = "Ištrinti"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(165, 6)
        '
        'CorrespondationsToolStripMenuItem
        '
        Me.CorrespondationsToolStripMenuItem.AutoToolTip = True
        Me.CorrespondationsToolStripMenuItem.Name = "CorrespondationsToolStripMenuItem"
        Me.CorrespondationsToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.CorrespondationsToolStripMenuItem.Text = "Korespondencijos"
        '
        'RelationsToolStripMenuItem
        '
        Me.RelationsToolStripMenuItem.AutoToolTip = True
        Me.RelationsToolStripMenuItem.Name = "RelationsToolStripMenuItem"
        Me.RelationsToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.RelationsToolStripMenuItem.Text = "Ryšiai"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(165, 6)
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.AutoToolTip = True
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.CancelToolStripMenuItem.Text = "Atšaukti"
        '
        'F_AccountTurnoverInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 566)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_AccountTurnoverInfo"
        Me.Text = "Sąskaitos apyvartos žiniaraštis"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.ItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BookEntryInfoListParentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DateToDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateFromDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents IncludeSubAccountsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ClearButton As System.Windows.Forms.Button
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CreditBalanceEndAccBox As AccControls.AccTextBox
    Friend WithEvents BookEntryInfoListParentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CreditBalanceStartAccBox As AccControls.AccTextBox
    Friend WithEvents CreditTurnoverAccBox As AccControls.AccTextBox
    Friend WithEvents DebetBalanceEndAccBox As AccControls.AccTextBox
    Friend WithEvents DebetBalanceStartAccBox As AccControls.AccTextBox
    Friend WithEvents DebetTurnoverAccBox As AccControls.AccTextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents ItemsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ItemsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AccountAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents PersonAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents PersonGroupComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CorrespondationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RelationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CancelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BookEntriesString As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
