<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_GoodsComplexOperationInternalTransfer
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
        Dim IDLabel As System.Windows.Forms.Label
        Dim InsertDateLabel As System.Windows.Forms.Label
        Dim UpdateDateLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim DocumentNumberLabel As System.Windows.Forms.Label
        Dim JournalEntryIDLabel As System.Windows.Forms.Label
        Dim WarehouseFromLabel As System.Windows.Forms.Label
        Dim WarehouseToLabel As System.Windows.Forms.Label
        Dim ContentLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_GoodsComplexOperationInternalTransfer))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GoodsInfoListAccGridComboBox = New AccControls.AccGridComboBox
        Me.AddNewItemButton = New System.Windows.Forms.Button
        Me.LimitationsButton = New System.Windows.Forms.Button
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel
        Me.ContentTextBox = New System.Windows.Forms.TextBox
        Me.GoodsComplexOperationInternalTransferBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel
        Me.WarehouseToAccGridComboBox = New AccControls.AccGridComboBox
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.JournalEntryIDTextBox = New System.Windows.Forms.TextBox
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.DocumentNumberTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.WarehouseFromAccGridComboBox = New AccControls.AccGridComboBox
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button
        Me.UpdateDateTextBox = New System.Windows.Forms.TextBox
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.InsertDateTextBox = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RefreshCostsButton = New System.Windows.Forms.Button
        Me.EditedBaner = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.CancelButton = New System.Windows.Forms.Button
        Me.ApplyButton = New System.Windows.Forms.Button
        Me.OkButton = New System.Windows.Forms.Button
        Me.ItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New AccControls.DataGridViewAccTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AmountCanChange = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        IDLabel = New System.Windows.Forms.Label
        InsertDateLabel = New System.Windows.Forms.Label
        UpdateDateLabel = New System.Windows.Forms.Label
        DateLabel = New System.Windows.Forms.Label
        DocumentNumberLabel = New System.Windows.Forms.Label
        JournalEntryIDLabel = New System.Windows.Forms.Label
        WarehouseFromLabel = New System.Windows.Forms.Label
        WarehouseToLabel = New System.Windows.Forms.Label
        ContentLabel = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        CType(Me.GoodsComplexOperationInternalTransferBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.EditedBaner.SuspendLayout()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IDLabel
        '
        IDLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(53, 6)
        IDLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(24, 13)
        IDLabel.TabIndex = 5
        IDLabel.Text = "ID:"
        '
        'InsertDateLabel
        '
        InsertDateLabel.AutoSize = True
        InsertDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        InsertDateLabel.Location = New System.Drawing.Point(166, 3)
        InsertDateLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        InsertDateLabel.Name = "InsertDateLabel"
        InsertDateLabel.Size = New System.Drawing.Size(55, 13)
        InsertDateLabel.TabIndex = 6
        InsertDateLabel.Text = "Įtraukta:"
        '
        'UpdateDateLabel
        '
        UpdateDateLabel.AutoSize = True
        UpdateDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UpdateDateLabel.Location = New System.Drawing.Point(409, 3)
        UpdateDateLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        UpdateDateLabel.Name = "UpdateDateLabel"
        UpdateDateLabel.Size = New System.Drawing.Size(60, 13)
        UpdateDateLabel.TabIndex = 8
        UpdateDateLabel.Text = "Pakeista:"
        '
        'DateLabel
        '
        DateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DateLabel.AutoSize = True
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(39, 36)
        DateLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(38, 13)
        DateLabel.TabIndex = 4
        DateLabel.Text = "Data:"
        '
        'DocumentNumberLabel
        '
        DocumentNumberLabel.AutoSize = True
        DocumentNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DocumentNumberLabel.Location = New System.Drawing.Point(191, 3)
        DocumentNumberLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        DocumentNumberLabel.Name = "DocumentNumberLabel"
        DocumentNumberLabel.Size = New System.Drawing.Size(59, 13)
        DocumentNumberLabel.TabIndex = 6
        DocumentNumberLabel.Text = "Dok. Nr.:"
        '
        'JournalEntryIDLabel
        '
        JournalEntryIDLabel.AutoSize = True
        JournalEntryIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        JournalEntryIDLabel.Location = New System.Drawing.Point(444, 3)
        JournalEntryIDLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        JournalEntryIDLabel.Name = "JournalEntryIDLabel"
        JournalEntryIDLabel.Size = New System.Drawing.Size(44, 13)
        JournalEntryIDLabel.TabIndex = 8
        JournalEntryIDLabel.Text = "BŽ ID:"
        '
        'WarehouseFromLabel
        '
        WarehouseFromLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        WarehouseFromLabel.AutoSize = True
        WarehouseFromLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        WarehouseFromLabel.Location = New System.Drawing.Point(3, 66)
        WarehouseFromLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        WarehouseFromLabel.Name = "WarehouseFromLabel"
        WarehouseFromLabel.Size = New System.Drawing.Size(74, 13)
        WarehouseFromLabel.TabIndex = 5
        WarehouseFromLabel.Text = "Iš Sandėlio:"
        '
        'WarehouseToLabel
        '
        WarehouseToLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        WarehouseToLabel.AutoSize = True
        WarehouseToLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        WarehouseToLabel.Location = New System.Drawing.Point(16, 96)
        WarehouseToLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        WarehouseToLabel.Name = "WarehouseToLabel"
        WarehouseToLabel.Size = New System.Drawing.Size(61, 13)
        WarehouseToLabel.TabIndex = 7
        WarehouseToLabel.Text = "Į Sandėlį:"
        '
        'ContentLabel
        '
        ContentLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ContentLabel.AutoSize = True
        ContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContentLabel.Location = New System.Drawing.Point(6, 126)
        ContentLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        ContentLabel.Name = "ContentLabel"
        ContentLabel.Size = New System.Drawing.Size(71, 13)
        ContentLabel.TabIndex = 9
        ContentLabel.Text = "Aprašymas:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LimitationsButton, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel7, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(ContentLabel, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel6, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(WarehouseToLabel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(DateLabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(WarehouseFromLabel, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(735, 199)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GoodsInfoListAccGridComboBox)
        Me.GroupBox1.Controls.Add(Me.AddNewItemButton)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(83, 153)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(649, 40)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pridėti naują prekę"
        '
        'GoodsInfoListAccGridComboBox
        '
        Me.GoodsInfoListAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GoodsInfoListAccGridComboBox.FilterPropertyName = ""
        Me.GoodsInfoListAccGridComboBox.FormattingEnabled = True
        Me.GoodsInfoListAccGridComboBox.InstantBinding = True
        Me.GoodsInfoListAccGridComboBox.Location = New System.Drawing.Point(6, 17)
        Me.GoodsInfoListAccGridComboBox.Name = "GoodsInfoListAccGridComboBox"
        Me.GoodsInfoListAccGridComboBox.Size = New System.Drawing.Size(550, 21)
        Me.GoodsInfoListAccGridComboBox.TabIndex = 0
        '
        'AddNewItemButton
        '
        Me.AddNewItemButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddNewItemButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddNewItemButton.Location = New System.Drawing.Point(573, 15)
        Me.AddNewItemButton.Name = "AddNewItemButton"
        Me.AddNewItemButton.Size = New System.Drawing.Size(70, 23)
        Me.AddNewItemButton.TabIndex = 1
        Me.AddNewItemButton.Text = "Pridėti"
        Me.AddNewItemButton.UseVisualStyleBackColor = True
        '
        'LimitationsButton
        '
        Me.LimitationsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LimitationsButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Action_lock_icon_32p
        Me.LimitationsButton.Location = New System.Drawing.Point(27, 153)
        Me.LimitationsButton.Name = "LimitationsButton"
        Me.LimitationsButton.Size = New System.Drawing.Size(50, 40)
        Me.LimitationsButton.TabIndex = 6
        Me.LimitationsButton.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.ContentTextBox, 0, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(80, 123)
        Me.TableLayoutPanel7.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(655, 24)
        Me.TableLayoutPanel7.TabIndex = 4
        '
        'ContentTextBox
        '
        Me.ContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsComplexOperationInternalTransferBindingSource, "Content", True))
        Me.ContentTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentTextBox.Location = New System.Drawing.Point(2, 1)
        Me.ContentTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.ContentTextBox.MaxLength = 255
        Me.ContentTextBox.Name = "ContentTextBox"
        Me.ContentTextBox.Size = New System.Drawing.Size(631, 20)
        Me.ContentTextBox.TabIndex = 0
        '
        'GoodsComplexOperationInternalTransferBindingSource
        '
        Me.GoodsComplexOperationInternalTransferBindingSource.DataSource = GetType(ApskaitaObjects.Goods.GoodsComplexOperationInternalTransfer)
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.WarehouseToAccGridComboBox, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(80, 93)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(655, 24)
        Me.TableLayoutPanel6.TabIndex = 3
        '
        'WarehouseToAccGridComboBox
        '
        Me.WarehouseToAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.GoodsComplexOperationInternalTransferBindingSource, "WarehouseTo", True))
        Me.WarehouseToAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WarehouseToAccGridComboBox.FilterPropertyName = ""
        Me.WarehouseToAccGridComboBox.FormattingEnabled = True
        Me.WarehouseToAccGridComboBox.InstantBinding = True
        Me.WarehouseToAccGridComboBox.Location = New System.Drawing.Point(2, 1)
        Me.WarehouseToAccGridComboBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.WarehouseToAccGridComboBox.Name = "WarehouseToAccGridComboBox"
        Me.WarehouseToAccGridComboBox.Size = New System.Drawing.Size(631, 21)
        Me.WarehouseToAccGridComboBox.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 8
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.JournalEntryIDTextBox, 6, 0)
        Me.TableLayoutPanel4.Controls.Add(JournalEntryIDLabel, 5, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.DateDateTimePicker, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(DocumentNumberLabel, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.DocumentNumberTextBox, 3, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(80, 33)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(655, 24)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'JournalEntryIDTextBox
        '
        Me.JournalEntryIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsComplexOperationInternalTransferBindingSource, "JournalEntryID", True))
        Me.JournalEntryIDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JournalEntryIDTextBox.Location = New System.Drawing.Point(493, 1)
        Me.JournalEntryIDTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.JournalEntryIDTextBox.Name = "JournalEntryIDTextBox"
        Me.JournalEntryIDTextBox.ReadOnly = True
        Me.JournalEntryIDTextBox.Size = New System.Drawing.Size(140, 20)
        Me.JournalEntryIDTextBox.TabIndex = 9
        Me.JournalEntryIDTextBox.TabStop = False
        Me.JournalEntryIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateDateTimePicker
        '
        Me.DateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.GoodsComplexOperationInternalTransferBindingSource, "Date", True))
        Me.DateDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDateTimePicker.Location = New System.Drawing.Point(2, 1)
        Me.DateDateTimePicker.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(164, 20)
        Me.DateDateTimePicker.TabIndex = 0
        '
        'DocumentNumberTextBox
        '
        Me.DocumentNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsComplexOperationInternalTransferBindingSource, "DocumentNumber", True))
        Me.DocumentNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentNumberTextBox.Location = New System.Drawing.Point(255, 1)
        Me.DocumentNumberTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.DocumentNumberTextBox.MaxLength = 50
        Me.DocumentNumberTextBox.Name = "DocumentNumberTextBox"
        Me.DocumentNumberTextBox.Size = New System.Drawing.Size(164, 20)
        Me.DocumentNumberTextBox.TabIndex = 1
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.WarehouseFromAccGridComboBox, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(80, 63)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(655, 24)
        Me.TableLayoutPanel5.TabIndex = 2
        '
        'WarehouseFromAccGridComboBox
        '
        Me.WarehouseFromAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.GoodsComplexOperationInternalTransferBindingSource, "WarehouseFrom", True))
        Me.WarehouseFromAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WarehouseFromAccGridComboBox.FilterPropertyName = ""
        Me.WarehouseFromAccGridComboBox.FormattingEnabled = True
        Me.WarehouseFromAccGridComboBox.InstantBinding = True
        Me.WarehouseFromAccGridComboBox.Location = New System.Drawing.Point(2, 1)
        Me.WarehouseFromAccGridComboBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.WarehouseFromAccGridComboBox.Name = "WarehouseFromAccGridComboBox"
        Me.WarehouseFromAccGridComboBox.Size = New System.Drawing.Size(631, 21)
        Me.WarehouseFromAccGridComboBox.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 8
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.ViewJournalEntryButton, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.UpdateDateTextBox, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(UpdateDateLabel, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.IDTextBox, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(InsertDateLabel, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.InsertDateTextBox, 3, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(80, 3)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(655, 24)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.ApskaitaWUI.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(139, 0)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 91
        Me.ViewJournalEntryButton.TabStop = False
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = True
        '
        'UpdateDateTextBox
        '
        Me.UpdateDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsComplexOperationInternalTransferBindingSource, "UpdateDate", True))
        Me.UpdateDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UpdateDateTextBox.Location = New System.Drawing.Point(474, 1)
        Me.UpdateDateTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.UpdateDateTextBox.Name = "UpdateDateTextBox"
        Me.UpdateDateTextBox.ReadOnly = True
        Me.UpdateDateTextBox.Size = New System.Drawing.Size(158, 20)
        Me.UpdateDateTextBox.TabIndex = 9
        Me.UpdateDateTextBox.TabStop = False
        Me.UpdateDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IDTextBox
        '
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsComplexOperationInternalTransferBindingSource, "ID", True))
        Me.IDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IDTextBox.Location = New System.Drawing.Point(2, 1)
        Me.IDTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(135, 20)
        Me.IDTextBox.TabIndex = 6
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'InsertDateTextBox
        '
        Me.InsertDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsComplexOperationInternalTransferBindingSource, "InsertDate", True))
        Me.InsertDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InsertDateTextBox.Location = New System.Drawing.Point(226, 1)
        Me.InsertDateTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.InsertDateTextBox.Name = "InsertDateTextBox"
        Me.InsertDateTextBox.ReadOnly = True
        Me.InsertDateTextBox.Size = New System.Drawing.Size(158, 20)
        Me.InsertDateTextBox.TabIndex = 7
        Me.InsertDateTextBox.TabStop = False
        Me.InsertDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.RefreshCostsButton)
        Me.Panel2.Controls.Add(Me.EditedBaner)
        Me.Panel2.Controls.Add(Me.CancelButton)
        Me.Panel2.Controls.Add(Me.ApplyButton)
        Me.Panel2.Controls.Add(Me.OkButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 521)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Panel2.Size = New System.Drawing.Size(735, 37)
        Me.Panel2.TabIndex = 2
        '
        'RefreshCostsButton
        '
        Me.RefreshCostsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefreshCostsButton.Location = New System.Drawing.Point(6, 7)
        Me.RefreshCostsButton.Name = "RefreshCostsButton"
        Me.RefreshCostsButton.Size = New System.Drawing.Size(108, 23)
        Me.RefreshCostsButton.TabIndex = 0
        Me.RefreshCostsButton.Text = "Gauti Savik."
        Me.RefreshCostsButton.UseVisualStyleBackColor = True
        '
        'EditedBaner
        '
        Me.EditedBaner.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditedBaner.BackColor = System.Drawing.Color.Red
        Me.EditedBaner.Controls.Add(Me.Label4)
        Me.EditedBaner.Location = New System.Drawing.Point(384, 5)
        Me.EditedBaner.Name = "EditedBaner"
        Me.EditedBaner.Size = New System.Drawing.Size(83, 25)
        Me.EditedBaner.TabIndex = 51
        Me.EditedBaner.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "TAISOMA"
        '
        'CancelButton
        '
        Me.CancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelButton.Location = New System.Drawing.Point(648, 7)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton.TabIndex = 3
        Me.CancelButton.Text = "Atšaukti"
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyButton.Location = New System.Drawing.Point(567, 7)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(75, 23)
        Me.ApplyButton.TabIndex = 2
        Me.ApplyButton.Text = "Taikyti"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.Location = New System.Drawing.Point(486, 7)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 1
        Me.OkButton.Text = "OK"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'ItemsBindingSource
        '
        Me.ItemsBindingSource.DataMember = "Items"
        Me.ItemsBindingSource.DataSource = Me.GoodsComplexOperationInternalTransferBindingSource
        '
        'ItemsDataGridView
        '
        Me.ItemsDataGridView.AllowUserToAddRows = False
        Me.ItemsDataGridView.AllowUserToOrderColumns = True
        Me.ItemsDataGridView.AutoGenerateColumns = False
        Me.ItemsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ItemsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ItemsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn9, Me.AmountCanChange})
        Me.ItemsDataGridView.DataSource = Me.ItemsBindingSource
        Me.ItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemsDataGridView.Location = New System.Drawing.Point(0, 199)
        Me.ItemsDataGridView.Name = "ItemsDataGridView"
        Me.ItemsDataGridView.RowHeadersWidth = 20
        Me.ItemsDataGridView.Size = New System.Drawing.Size(735, 322)
        Me.ItemsDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn4.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "GoodsName"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Prekė"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "GoodsMeasureUnit"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Mato Vnt."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "GoodsAccountingMethod"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Apskaitos Metodas"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "GoodsValuationMethod"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Vertinimo Metodas"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AllowNegative = False
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Amount"
        Me.DataGridViewTextBoxColumn10.DecimalLength = 6
        DataGridViewCellStyle2.Format = "##,0.000000"
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn10.HeaderText = "Kiekis"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "UnitCost"
        DataGridViewCellStyle3.Format = "##,0.000000"
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn11.HeaderText = "Vnt. Savikaina"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "TotalCost"
        DataGridViewCellStyle4.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn12.HeaderText = "Viso Savikaina"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Remarks"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Pastabos"
        Me.DataGridViewTextBoxColumn9.MaxInputLength = 255
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'AmountCanChange
        '
        Me.AmountCanChange.DataPropertyName = "AmountCanChange"
        Me.AmountCanChange.HeaderText = "Neribota"
        Me.AmountCanChange.Name = "AmountCanChange"
        Me.AmountCanChange.ReadOnly = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.DataSource = Me.GoodsComplexOperationInternalTransferBindingSource
        '
        'F_GoodsComplexOperationInternalTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 558)
        Me.Controls.Add(Me.ItemsDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_GoodsComplexOperationInternalTransfer"
        Me.ShowInTaskbar = False
        Me.Text = "Vidinis Prekių Judėjimas"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        CType(Me.GoodsComplexOperationInternalTransferBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.EditedBaner.ResumeLayout(False)
        Me.EditedBaner.PerformLayout()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UpdateDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GoodsComplexOperationInternalTransferBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InsertDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents DocumentNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents JournalEntryIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents WarehouseToAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents WarehouseFromAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents LimitationsButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents AddNewItemButton As System.Windows.Forms.Button
    Friend WithEvents GoodsInfoListAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents EditedBaner As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CancelButton As System.Windows.Forms.Button
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents ItemsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents RefreshCostsButton As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmountCanChange As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
End Class
