<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_ImprestSheet
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
        Dim Label3 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim YearLabel As System.Windows.Forms.Label
        Dim MonthLabel As System.Windows.Forms.Label
        Dim NumberLabel As System.Windows.Forms.Label
        Dim TotalSumLabel As System.Windows.Forms.Label
        Dim InsertDateLabel As System.Windows.Forms.Label
        Dim UpdateDateLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_ImprestSheet))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RefreshButton = New System.Windows.Forms.Button
        Me.MonthComboBox = New System.Windows.Forms.ComboBox
        Me.YearComboBox = New System.Windows.Forms.ComboBox
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LimitationsButton = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button
        Me.UpdateDateTextBox = New System.Windows.Forms.TextBox
        Me.ImprestSheetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.InsertDateTextBox = New System.Windows.Forms.TextBox
        Me.YearTextBox = New System.Windows.Forms.TextBox
        Me.MonthTextBox = New System.Windows.Forms.TextBox
        Me.TotalSumAccTextBox = New AccControls.AccTextBox
        Me.NumberAccTextBox = New AccControls.AccTextBox
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker
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
        Me.DataGridViewTextBoxColumn8 = New AccControls.DataGridViewAccTextBoxColumn
        Me.PayedOutDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ReadWriteAuthorization1 = New Csla.Windows.ReadWriteAuthorization(Me.components)
        Label3 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        DateLabel = New System.Windows.Forms.Label
        IDLabel = New System.Windows.Forms.Label
        YearLabel = New System.Windows.Forms.Label
        MonthLabel = New System.Windows.Forms.Label
        NumberLabel = New System.Windows.Forms.Label
        TotalSumLabel = New System.Windows.Forms.Label
        InsertDateLabel = New System.Windows.Forms.Label
        UpdateDateLabel = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ImprestSheetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Label3, False)
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(93, 10)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(20, 13)
        Label3.TabIndex = 72
        Label3.Text = "m."
        '
        'Label1
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Label1, False)
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(174, 10)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(34, 13)
        Label1.TabIndex = 2
        Label1.Text = "mėn."
        '
        'DateLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(DateLabel, False)
        DateLabel.AutoSize = True
        DateLabel.Dock = System.Windows.Forms.DockStyle.Fill
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(217, 60)
        DateLabel.Name = "DateLabel"
        DateLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        DateLabel.Size = New System.Drawing.Size(55, 30)
        DateLabel.TabIndex = 0
        DateLabel.Text = "Data:"
        DateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'IDLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(IDLabel, False)
        IDLabel.AutoSize = True
        IDLabel.Dock = System.Windows.Forms.DockStyle.Fill
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(3, 0)
        IDLabel.Name = "IDLabel"
        IDLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        IDLabel.Size = New System.Drawing.Size(42, 30)
        IDLabel.TabIndex = 2
        IDLabel.Text = "ID:"
        IDLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'YearLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(YearLabel, False)
        YearLabel.AutoSize = True
        YearLabel.Dock = System.Windows.Forms.DockStyle.Fill
        YearLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        YearLabel.Location = New System.Drawing.Point(3, 30)
        YearLabel.Name = "YearLabel"
        YearLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        YearLabel.Size = New System.Drawing.Size(42, 30)
        YearLabel.TabIndex = 4
        YearLabel.Text = "Metai:"
        YearLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MonthLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(MonthLabel, False)
        MonthLabel.AutoSize = True
        MonthLabel.Dock = System.Windows.Forms.DockStyle.Fill
        MonthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        MonthLabel.Location = New System.Drawing.Point(217, 30)
        MonthLabel.Name = "MonthLabel"
        MonthLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        MonthLabel.Size = New System.Drawing.Size(55, 30)
        MonthLabel.TabIndex = 6
        MonthLabel.Text = "Mėnuo:"
        MonthLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'NumberLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(NumberLabel, False)
        NumberLabel.AutoSize = True
        NumberLabel.Dock = System.Windows.Forms.DockStyle.Fill
        NumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NumberLabel.Location = New System.Drawing.Point(464, 60)
        NumberLabel.Name = "NumberLabel"
        NumberLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        NumberLabel.Size = New System.Drawing.Size(60, 30)
        NumberLabel.TabIndex = 8
        NumberLabel.Text = "Nr.:"
        NumberLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TotalSumLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(TotalSumLabel, False)
        TotalSumLabel.AutoSize = True
        TotalSumLabel.Dock = System.Windows.Forms.DockStyle.Fill
        TotalSumLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TotalSumLabel.Location = New System.Drawing.Point(464, 30)
        TotalSumLabel.Name = "TotalSumLabel"
        TotalSumLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        TotalSumLabel.Size = New System.Drawing.Size(60, 30)
        TotalSumLabel.TabIndex = 14
        TotalSumLabel.Text = "Suma:"
        TotalSumLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'InsertDateLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(InsertDateLabel, False)
        InsertDateLabel.AutoSize = True
        InsertDateLabel.Dock = System.Windows.Forms.DockStyle.Fill
        InsertDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        InsertDateLabel.Location = New System.Drawing.Point(217, 0)
        InsertDateLabel.Name = "InsertDateLabel"
        InsertDateLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        InsertDateLabel.Size = New System.Drawing.Size(55, 30)
        InsertDateLabel.TabIndex = 55
        InsertDateLabel.Text = "Įtraukta:"
        '
        'UpdateDateLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(UpdateDateLabel, False)
        UpdateDateLabel.AutoSize = True
        UpdateDateLabel.Dock = System.Windows.Forms.DockStyle.Fill
        UpdateDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UpdateDateLabel.Location = New System.Drawing.Point(464, 0)
        UpdateDateLabel.Name = "UpdateDateLabel"
        UpdateDateLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        UpdateDateLabel.Size = New System.Drawing.Size(60, 30)
        UpdateDateLabel.TabIndex = 56
        UpdateDateLabel.Text = "Pakeista:"
        '
        'Panel1
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.Panel1, False)
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.RefreshButton)
        Me.Panel1.Controls.Add(Label1)
        Me.Panel1.Controls.Add(Me.MonthComboBox)
        Me.Panel1.Controls.Add(Label3)
        Me.Panel1.Controls.Add(Me.YearComboBox)
        Me.Panel1.Controls.Add(Me.ICancelButton)
        Me.Panel1.Controls.Add(Me.IApplyButton)
        Me.Panel1.Controls.Add(Me.IOkButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 387)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(797, 34)
        Me.Panel1.TabIndex = 2
        '
        'RefreshButton
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.RefreshButton, False)
        Me.RefreshButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Action_file_new_icon_16p
        Me.RefreshButton.Location = New System.Drawing.Point(214, 6)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(24, 24)
        Me.RefreshButton.TabIndex = 3
        Me.RefreshButton.UseVisualStyleBackColor = True
        '
        'MonthComboBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.MonthComboBox, False)
        Me.MonthComboBox.FormattingEnabled = True
        Me.MonthComboBox.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.MonthComboBox.Location = New System.Drawing.Point(119, 7)
        Me.MonthComboBox.Name = "MonthComboBox"
        Me.MonthComboBox.Size = New System.Drawing.Size(49, 21)
        Me.MonthComboBox.TabIndex = 1
        '
        'YearComboBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.YearComboBox, False)
        Me.YearComboBox.FormattingEnabled = True
        Me.YearComboBox.Location = New System.Drawing.Point(6, 7)
        Me.YearComboBox.Name = "YearComboBox"
        Me.YearComboBox.Size = New System.Drawing.Size(81, 21)
        Me.YearComboBox.TabIndex = 0
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.ICancelButton, False)
        Me.ICancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(710, 8)
        Me.ICancelButton.Name = "ICancelButton"
        Me.ICancelButton.Size = New System.Drawing.Size(75, 23)
        Me.ICancelButton.TabIndex = 6
        Me.ICancelButton.Text = "Atšaukti"
        Me.ICancelButton.UseVisualStyleBackColor = True
        '
        'IApplyButton
        '
        Me.IApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.IApplyButton, False)
        Me.IApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IApplyButton.Location = New System.Drawing.Point(629, 8)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(75, 23)
        Me.IApplyButton.TabIndex = 5
        Me.IApplyButton.Text = "Taikyti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'IOkButton
        '
        Me.IOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.IOkButton, False)
        Me.IOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IOkButton.Location = New System.Drawing.Point(548, 8)
        Me.IOkButton.Name = "IOkButton"
        Me.IOkButton.Size = New System.Drawing.Size(75, 23)
        Me.IOkButton.TabIndex = 4
        Me.IOkButton.Text = "OK"
        Me.IOkButton.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.Panel2, False)
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.LimitationsButton)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(797, 117)
        Me.Panel2.TabIndex = 0
        '
        'LimitationsButton
        '
        Me.LimitationsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.LimitationsButton, False)
        Me.LimitationsButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Action_lock_icon_32p
        Me.LimitationsButton.Location = New System.Drawing.Point(735, 24)
        Me.LimitationsButton.Name = "LimitationsButton"
        Me.LimitationsButton.Size = New System.Drawing.Size(50, 40)
        Me.LimitationsButton.TabIndex = 1
        Me.LimitationsButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.GroupBox1, False)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(723, 106)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Bendri duomenys"
        '
        'TableLayoutPanel1
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.TableLayoutPanel1, False)
        Me.TableLayoutPanel1.ColumnCount = 9
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ViewJournalEntryButton, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.UpdateDateTextBox, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(UpdateDateLabel, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.IDTextBox, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.InsertDateTextBox, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(InsertDateLabel, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(YearLabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.YearTextBox, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(MonthLabel, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.MonthTextBox, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(TotalSumLabel, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TotalSumAccTextBox, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.NumberAccTextBox, 7, 2)
        Me.TableLayoutPanel1.Controls.Add(NumberLabel, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DateDateTimePicker, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(DateLabel, 3, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(717, 87)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.ViewJournalEntryButton, False)
        Me.ViewJournalEntryButton.Image = Global.ApskaitaWUI.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(190, 0)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 90
        Me.ViewJournalEntryButton.TabStop = False
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = True
        '
        'UpdateDateTextBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.UpdateDateTextBox, False)
        Me.UpdateDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImprestSheetBindingSource, "UpdateDate", True))
        Me.UpdateDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UpdateDateTextBox.Location = New System.Drawing.Point(530, 3)
        Me.UpdateDateTextBox.Name = "UpdateDateTextBox"
        Me.UpdateDateTextBox.ReadOnly = True
        Me.UpdateDateTextBox.Size = New System.Drawing.Size(160, 20)
        Me.UpdateDateTextBox.TabIndex = 57
        Me.UpdateDateTextBox.TabStop = False
        Me.UpdateDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ImprestSheetBindingSource
        '
        Me.ImprestSheetBindingSource.DataSource = GetType(ApskaitaObjects.Workers.ImprestSheet)
        '
        'IDTextBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.IDTextBox, False)
        Me.IDTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImprestSheetBindingSource, "ID", True))
        Me.IDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IDTextBox.Location = New System.Drawing.Point(51, 3)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(136, 20)
        Me.IDTextBox.TabIndex = 3
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'InsertDateTextBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.InsertDateTextBox, False)
        Me.InsertDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImprestSheetBindingSource, "InsertDate", True))
        Me.InsertDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InsertDateTextBox.Location = New System.Drawing.Point(278, 3)
        Me.InsertDateTextBox.Name = "InsertDateTextBox"
        Me.InsertDateTextBox.ReadOnly = True
        Me.InsertDateTextBox.Size = New System.Drawing.Size(160, 20)
        Me.InsertDateTextBox.TabIndex = 56
        Me.InsertDateTextBox.TabStop = False
        Me.InsertDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'YearTextBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.YearTextBox, False)
        Me.YearTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.YearTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImprestSheetBindingSource, "Year", True))
        Me.YearTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.YearTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.YearTextBox.Location = New System.Drawing.Point(51, 33)
        Me.YearTextBox.Name = "YearTextBox"
        Me.YearTextBox.ReadOnly = True
        Me.YearTextBox.Size = New System.Drawing.Size(136, 20)
        Me.YearTextBox.TabIndex = 5
        Me.YearTextBox.TabStop = False
        Me.YearTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MonthTextBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.MonthTextBox, False)
        Me.MonthTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.MonthTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImprestSheetBindingSource, "Month", True))
        Me.MonthTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MonthTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MonthTextBox.Location = New System.Drawing.Point(278, 33)
        Me.MonthTextBox.Name = "MonthTextBox"
        Me.MonthTextBox.ReadOnly = True
        Me.MonthTextBox.Size = New System.Drawing.Size(160, 20)
        Me.MonthTextBox.TabIndex = 7
        Me.MonthTextBox.TabStop = False
        Me.MonthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TotalSumAccTextBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.TotalSumAccTextBox, False)
        Me.TotalSumAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.ImprestSheetBindingSource, "TotalSum", True))
        Me.TotalSumAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TotalSumAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalSumAccTextBox.KeepBackColorWhenReadOnly = False
        Me.TotalSumAccTextBox.Location = New System.Drawing.Point(530, 33)
        Me.TotalSumAccTextBox.Name = "TotalSumAccTextBox"
        Me.TotalSumAccTextBox.ReadOnly = True
        Me.TotalSumAccTextBox.Size = New System.Drawing.Size(160, 20)
        Me.TotalSumAccTextBox.TabIndex = 18
        Me.TotalSumAccTextBox.TabStop = False
        Me.TotalSumAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumberAccTextBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.NumberAccTextBox, False)
        Me.NumberAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.ImprestSheetBindingSource, "Number", True))
        Me.NumberAccTextBox.DecimalLength = 0
        Me.NumberAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NumberAccTextBox.Location = New System.Drawing.Point(530, 63)
        Me.NumberAccTextBox.Name = "NumberAccTextBox"
        Me.NumberAccTextBox.NegativeValue = False
        Me.NumberAccTextBox.Size = New System.Drawing.Size(160, 20)
        Me.NumberAccTextBox.SupressFormating = True
        Me.NumberAccTextBox.TabIndex = 1
        Me.NumberAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateDateTimePicker
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.DateDateTimePicker, True)
        Me.DateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.ImprestSheetBindingSource, "Date", True))
        Me.DateDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDateTimePicker.Location = New System.Drawing.Point(278, 63)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(160, 20)
        Me.DateDateTimePicker.TabIndex = 0
        '
        'ItemsBindingSource
        '
        Me.ItemsBindingSource.DataMember = "Items"
        Me.ItemsBindingSource.DataSource = Me.ImprestSheetBindingSource
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
        Me.ItemsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.PayedOutDate})
        Me.ItemsDataGridView.DataSource = Me.ItemsBindingSource
        Me.ItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemsDataGridView.Location = New System.Drawing.Point(0, 117)
        Me.ItemsDataGridView.MultiSelect = False
        Me.ItemsDataGridView.Name = "ItemsDataGridView"
        Me.ItemsDataGridView.RowHeadersVisible = False
        Me.ItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.ItemsDataGridView.Size = New System.Drawing.Size(797, 270)
        Me.ItemsDataGridView.TabIndex = 1
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
        Me.DataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "IsChecked"
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.MinimumWidth = 25
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewCheckBoxColumn1.Width = 25
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "PersonID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "PersonID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 84
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PersonName"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Vardas, Pavardė"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "PersonCode"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Asm. kodas"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 97
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "PersonCodeSodra"
        Me.DataGridViewTextBoxColumn5.HeaderText = "SODROS kodas"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 122
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ContractSerial"
        Me.DataGridViewTextBoxColumn6.HeaderText = "DS Ser."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 76
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "ContractNumber"
        Me.DataGridViewTextBoxColumn7.HeaderText = "DS Nr."
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 70
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AllowNegative = False
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "PayOffSumTotal"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "##,0.00"
        DataGridViewCellStyle2.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn8.HeaderText = "Suma"
        Me.DataGridViewTextBoxColumn8.MaxInputLength = 10
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'PayedOutDate
        '
        Me.PayedOutDate.DataPropertyName = "PayedOutDate"
        Me.PayedOutDate.HeaderText = "Išmokėta"
        Me.PayedOutDate.Name = "PayedOutDate"
        Me.PayedOutDate.ReadOnly = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.DataSource = Me.ImprestSheetBindingSource
        '
        'F_ImprestSheet
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me, False)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 421)
        Me.Controls.Add(Me.ItemsDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_ImprestSheet"
        Me.ShowInTaskbar = False
        Me.Text = "Avanso žiniaraštis"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.ImprestSheetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents MonthComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents YearComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ImprestSheetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents YearTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MonthTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ItemsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ReadWriteAuthorization1 As Csla.Windows.ReadWriteAuthorization
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents NumberAccTextBox As AccControls.AccTextBox
    Friend WithEvents TotalSumAccTextBox As AccControls.AccTextBox
    Friend WithEvents LimitationsButton As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents PayedOutDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InsertDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
End Class
