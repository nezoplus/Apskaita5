<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_WorkerInfoCard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_WorkerInfoCard))
        Me.RefreshButton = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.WageSheetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label9 = New System.Windows.Forms.Label
        Me.WorkerAccGridComboBox = New AccControls.AccGridComboBox
        Me.RefreshLabourContractsButton = New System.Windows.Forms.Button
        Me.IsConsolidatedCheckBox = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabourContractComboBox = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateToDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.DateFromDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.WorkerInfoDataGridView = New System.Windows.Forms.DataGridView
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.Label8 = New System.Windows.Forms.Label
        Me.DebtAtEndAccTextBox = New AccControls.AccTextBox
        Me.DebtAtTheStartAccTextBox = New AccControls.AccTextBox
        Me.UnusedHolidaysAtEndAccTextBox = New AccControls.AccTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.UnusedHolidaysAtStartAccTextBox = New AccControls.AccTextBox
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        CType(Me.WageSheetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WorkerInfoDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'RefreshButton
        '
        Me.RefreshButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Button_Reload_icon_24p
        Me.RefreshButton.Location = New System.Drawing.Point(792, 30)
        Me.RefreshButton.Margin = New System.Windows.Forms.Padding(0)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(33, 33)
        Me.RefreshButton.TabIndex = 3
        Me.RefreshButton.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1, 31)
        Me.Label10.Margin = New System.Windows.Forms.Padding(1, 3, 1, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(204, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Darbo užmokesčio skola pradžioje:"
        '
        'WageSheetBindingSource
        '
        Me.WageSheetBindingSource.DataSource = GetType(ApskaitaObjects.ActiveReports.WorkerWageInfoReport)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1, 3)
        Me.Label9.Margin = New System.Windows.Forms.Padding(1, 3, 1, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(195, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Nepanaudotų atostogų pradžioje:"
        '
        'WorkerAccGridComboBox
        '
        Me.WorkerAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkerAccGridComboBox.FilterPropertyName = ""
        Me.WorkerAccGridComboBox.FormattingEnabled = True
        Me.WorkerAccGridComboBox.InstantBinding = True
        Me.WorkerAccGridComboBox.Location = New System.Drawing.Point(2, 0)
        Me.WorkerAccGridComboBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.WorkerAccGridComboBox.Name = "WorkerAccGridComboBox"
        Me.WorkerAccGridComboBox.Size = New System.Drawing.Size(382, 21)
        Me.WorkerAccGridComboBox.TabIndex = 0
        '
        'RefreshLabourContractsButton
        '
        Me.RefreshLabourContractsButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Button_Reload_icon_16p
        Me.RefreshLabourContractsButton.Location = New System.Drawing.Point(500, 0)
        Me.RefreshLabourContractsButton.Margin = New System.Windows.Forms.Padding(0)
        Me.RefreshLabourContractsButton.Name = "RefreshLabourContractsButton"
        Me.RefreshLabourContractsButton.Size = New System.Drawing.Size(24, 24)
        Me.RefreshLabourContractsButton.TabIndex = 1
        Me.RefreshLabourContractsButton.UseVisualStyleBackColor = True
        '
        'IsConsolidatedCheckBox
        '
        Me.IsConsolidatedCheckBox.AutoSize = True
        Me.IsConsolidatedCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsConsolidatedCheckBox.Location = New System.Drawing.Point(582, 3)
        Me.IsConsolidatedCheckBox.Name = "IsConsolidatedCheckBox"
        Me.IsConsolidatedCheckBox.Size = New System.Drawing.Size(105, 17)
        Me.IsConsolidatedCheckBox.TabIndex = 2
        Me.IsConsolidatedCheckBox.Text = "Konsoliduotas"
        Me.IsConsolidatedCheckBox.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1, 6, 1, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Darbuotojas:"
        '
        'LabourContractComboBox
        '
        Me.LabourContractComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabourContractComboBox.FormattingEnabled = True
        Me.LabourContractComboBox.Location = New System.Drawing.Point(526, 0)
        Me.LabourContractComboBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabourContractComboBox.Name = "LabourContractComboBox"
        Me.LabourContractComboBox.Size = New System.Drawing.Size(161, 21)
        Me.LabourContractComboBox.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(407, 3)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1, 3, 1, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Darbo Sutartis:"
        '
        'DateToDateTimePicker
        '
        Me.DateToDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateToDateTimePicker.Location = New System.Drawing.Point(306, 3)
        Me.DateToDateTimePicker.Name = "DateToDateTimePicker"
        Me.DateToDateTimePicker.Size = New System.Drawing.Size(250, 20)
        Me.DateToDateTimePicker.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(277, 3)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1, 3, 1, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Iki:"
        '
        'DateFromDateTimePicker
        '
        Me.DateFromDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFromDateTimePicker.Location = New System.Drawing.Point(3, 3)
        Me.DateFromDateTimePicker.Name = "DateFromDateTimePicker"
        Me.DateFromDateTimePicker.Size = New System.Drawing.Size(250, 20)
        Me.DateFromDateTimePicker.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(46, 36)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1, 6, 1, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Nuo:"
        '
        'WorkerInfoDataGridView
        '
        Me.WorkerInfoDataGridView.AllowUserToAddRows = False
        Me.WorkerInfoDataGridView.AllowUserToDeleteRows = False
        Me.WorkerInfoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.WorkerInfoDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.WorkerInfoDataGridView.CausesValidation = False
        Me.WorkerInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.WorkerInfoDataGridView.ColumnHeadersVisible = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkerInfoDataGridView.DefaultCellStyle = DataGridViewCellStyle1
        Me.WorkerInfoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkerInfoDataGridView.Location = New System.Drawing.Point(0, 127)
        Me.WorkerInfoDataGridView.MultiSelect = False
        Me.WorkerInfoDataGridView.Name = "WorkerInfoDataGridView"
        Me.WorkerInfoDataGridView.ReadOnly = True
        Me.WorkerInfoDataGridView.RowHeadersVisible = False
        Me.WorkerInfoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkerInfoDataGridView.ShowCellErrors = False
        Me.WorkerInfoDataGridView.ShowCellToolTips = False
        Me.WorkerInfoDataGridView.ShowEditingIcon = False
        Me.WorkerInfoDataGridView.ShowRowErrors = False
        Me.WorkerInfoDataGridView.Size = New System.Drawing.Size(825, 422)
        Me.WorkerInfoDataGridView.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.RefreshButton, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(825, 127)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.SystemColors.Info
        Me.TableLayoutPanel4.ColumnCount = 6
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label8, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.DebtAtEndAccTextBox, 4, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label10, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label9, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.DebtAtTheStartAccTextBox, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.UnusedHolidaysAtEndAccTextBox, 4, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label7, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.UnusedHolidaysAtStartAccTextBox, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(81, 68)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(711, 56)
        Me.TableLayoutPanel4.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(425, 31)
        Me.Label8.Margin = New System.Windows.Forms.Padding(1, 3, 1, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Pabaigoje:"
        '
        'DebtAtEndAccTextBox
        '
        Me.DebtAtEndAccTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.DebtAtEndAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "DebtAtEnd", True))
        Me.DebtAtEndAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DebtAtEndAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebtAtEndAccTextBox.KeepBackColorWhenReadOnly = False
        Me.DebtAtEndAccTextBox.Location = New System.Drawing.Point(496, 31)
        Me.DebtAtEndAccTextBox.Name = "DebtAtEndAccTextBox"
        Me.DebtAtEndAccTextBox.ReadOnly = True
        Me.DebtAtEndAccTextBox.Size = New System.Drawing.Size(192, 20)
        Me.DebtAtEndAccTextBox.TabIndex = 3
        Me.DebtAtEndAccTextBox.TabStop = False
        Me.DebtAtEndAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DebtAtTheStartAccTextBox
        '
        Me.DebtAtTheStartAccTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.DebtAtTheStartAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "DebtAtTheStart", True))
        Me.DebtAtTheStartAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DebtAtTheStartAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebtAtTheStartAccTextBox.KeepBackColorWhenReadOnly = False
        Me.DebtAtTheStartAccTextBox.Location = New System.Drawing.Point(209, 31)
        Me.DebtAtTheStartAccTextBox.Name = "DebtAtTheStartAccTextBox"
        Me.DebtAtTheStartAccTextBox.ReadOnly = True
        Me.DebtAtTheStartAccTextBox.Size = New System.Drawing.Size(192, 20)
        Me.DebtAtTheStartAccTextBox.TabIndex = 2
        Me.DebtAtTheStartAccTextBox.TabStop = False
        Me.DebtAtTheStartAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'UnusedHolidaysAtEndAccTextBox
        '
        Me.UnusedHolidaysAtEndAccTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.UnusedHolidaysAtEndAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "UnusedHolidaysAtEnd", True))
        Me.UnusedHolidaysAtEndAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UnusedHolidaysAtEndAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnusedHolidaysAtEndAccTextBox.KeepBackColorWhenReadOnly = False
        Me.UnusedHolidaysAtEndAccTextBox.Location = New System.Drawing.Point(496, 3)
        Me.UnusedHolidaysAtEndAccTextBox.Name = "UnusedHolidaysAtEndAccTextBox"
        Me.UnusedHolidaysAtEndAccTextBox.ReadOnly = True
        Me.UnusedHolidaysAtEndAccTextBox.Size = New System.Drawing.Size(192, 20)
        Me.UnusedHolidaysAtEndAccTextBox.TabIndex = 1
        Me.UnusedHolidaysAtEndAccTextBox.TabStop = False
        Me.UnusedHolidaysAtEndAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(425, 3)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1, 3, 1, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Pabaigoje:"
        '
        'UnusedHolidaysAtStartAccTextBox
        '
        Me.UnusedHolidaysAtStartAccTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.UnusedHolidaysAtStartAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "UnusedHolidaysAtStart", True))
        Me.UnusedHolidaysAtStartAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UnusedHolidaysAtStartAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnusedHolidaysAtStartAccTextBox.KeepBackColorWhenReadOnly = False
        Me.UnusedHolidaysAtStartAccTextBox.Location = New System.Drawing.Point(209, 3)
        Me.UnusedHolidaysAtStartAccTextBox.Name = "UnusedHolidaysAtStartAccTextBox"
        Me.UnusedHolidaysAtStartAccTextBox.ReadOnly = True
        Me.UnusedHolidaysAtStartAccTextBox.Size = New System.Drawing.Size(192, 20)
        Me.UnusedHolidaysAtStartAccTextBox.TabIndex = 0
        Me.UnusedHolidaysAtStartAccTextBox.TabStop = False
        Me.UnusedHolidaysAtStartAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 7
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.IsConsolidatedCheckBox, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label4, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.DateFromDateTimePicker, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.DateToDateTimePicker, 3, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(81, 33)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(711, 29)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.WorkerAccGridComboBox, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabourContractComboBox, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.RefreshLabourContractsButton, 4, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(81, 3)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(711, 24)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'F_WorkerInfoCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 549)
        Me.Controls.Add(Me.WorkerInfoDataGridView)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_WorkerInfoCard"
        Me.ShowInTaskbar = False
        Me.Text = "Darbuotojo kortelė"
        CType(Me.WageSheetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WorkerInfoDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents IsConsolidatedCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents DateToDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateFromDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabourContractComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RefreshLabourContractsButton As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents WageSheetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents WorkerInfoDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents WorkerAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DebtAtEndAccTextBox As AccControls.AccTextBox
    Friend WithEvents DebtAtTheStartAccTextBox As AccControls.AccTextBox
    Friend WithEvents UnusedHolidaysAtEndAccTextBox As AccControls.AccTextBox
    Friend WithEvents UnusedHolidaysAtStartAccTextBox As AccControls.AccTextBox
End Class
