<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Service
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
        Dim AccountPurchaseLabel As System.Windows.Forms.Label
        Dim AccountSalesLabel As System.Windows.Forms.Label
        Dim AmountLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim NameShortLabel As System.Windows.Forms.Label
        Dim TypeHumanReadableLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim ServiceCodeLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_Service))
        Me.AccountPurchaseAccGridComboBox = New AccControls.AccGridComboBox
        Me.ServiceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AccountSalesAccGridComboBox = New AccControls.AccGridComboBox
        Me.AccountVatPurchaseAccGridComboBox = New AccControls.AccGridComboBox
        Me.AccountVatSalesAccGridComboBox = New AccControls.AccGridComboBox
        Me.AmountAccTextBox = New AccControls.AccTextBox
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.IsObsoleteCheckBox = New System.Windows.Forms.CheckBox
        Me.NameShortTextBox = New System.Windows.Forms.TextBox
        Me.RateVatPurchaseComboBox = New System.Windows.Forms.ComboBox
        Me.RateVatSalesComboBox = New System.Windows.Forms.ComboBox
        Me.TypeHumanReadableComboBox = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.RegionalPricesDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn3 = New AccControls.DataGridViewAccTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New AccControls.DataGridViewAccTextBoxColumn
        Me.RegionalPricesSortedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ServiceCodeTextBox = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.RegionalContentsSortedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RegionalContentsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        AccountPurchaseLabel = New System.Windows.Forms.Label
        AccountSalesLabel = New System.Windows.Forms.Label
        AmountLabel = New System.Windows.Forms.Label
        IDLabel = New System.Windows.Forms.Label
        NameShortLabel = New System.Windows.Forms.Label
        TypeHumanReadableLabel = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        ServiceCodeLabel = New System.Windows.Forms.Label
        CType(Me.ServiceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.RegionalPricesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RegionalPricesSortedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.RegionalContentsSortedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RegionalContentsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AccountPurchaseLabel
        '
        AccountPurchaseLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        AccountPurchaseLabel.AutoSize = True
        AccountPurchaseLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountPurchaseLabel.Location = New System.Drawing.Point(68, 36)
        AccountPurchaseLabel.Name = "AccountPurchaseLabel"
        AccountPurchaseLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        AccountPurchaseLabel.Size = New System.Drawing.Size(72, 19)
        AccountPurchaseLabel.TabIndex = 0
        AccountPurchaseLabel.Text = "ĮSIGIJIMAI:"
        '
        'AccountSalesLabel
        '
        AccountSalesLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        AccountSalesLabel.AutoSize = True
        AccountSalesLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountSalesLabel.Location = New System.Drawing.Point(53, 65)
        AccountSalesLabel.Name = "AccountSalesLabel"
        AccountSalesLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        AccountSalesLabel.Size = New System.Drawing.Size(87, 19)
        AccountSalesLabel.TabIndex = 2
        AccountSalesLabel.Text = "PARDAVIMAI:"
        '
        'AmountLabel
        '
        AmountLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        AmountLabel.AutoSize = True
        AmountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AmountLabel.Location = New System.Drawing.Point(95, 94)
        AmountLabel.Name = "AmountLabel"
        AmountLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        AmountLabel.Size = New System.Drawing.Size(45, 19)
        AmountLabel.TabIndex = 8
        AmountLabel.Text = "Kiekis:"
        '
        'IDLabel
        '
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(117, 9)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(24, 13)
        IDLabel.TabIndex = 10
        IDLabel.Text = "ID:"
        '
        'NameShortLabel
        '
        NameShortLabel.AutoSize = True
        NameShortLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameShortLabel.Location = New System.Drawing.Point(8, 35)
        NameShortLabel.Name = "NameShortLabel"
        NameShortLabel.Size = New System.Drawing.Size(133, 13)
        NameShortLabel.TabIndex = 14
        NameShortLabel.Text = "Trumpas pavadinimas:"
        '
        'TypeHumanReadableLabel
        '
        TypeHumanReadableLabel.AutoSize = True
        TypeHumanReadableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TypeHumanReadableLabel.Location = New System.Drawing.Point(274, 9)
        TypeHumanReadableLabel.Name = "TypeHumanReadableLabel"
        TypeHumanReadableLabel.Size = New System.Drawing.Size(42, 13)
        TypeHumanReadableLabel.TabIndex = 20
        TypeHumanReadableLabel.Text = "Tipas:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(146, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(125, 26)
        Label1.TabIndex = 20
        Label1.Text = "Apskaitos sąskaita"
        Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(292, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(125, 26)
        Label2.TabIndex = 24
        Label2.Text = "PVM tarifas"
        Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(438, 0)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(125, 26)
        Label3.TabIndex = 24
        Label3.Text = "PVM apskaitos sąskaita"
        Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label4.Location = New System.Drawing.Point(3, 0)
        Label4.Name = "Label4"
        Label4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Label4.Size = New System.Drawing.Size(320, 25)
        Label4.TabIndex = 15
        Label4.Text = "Paslaugos vnt. kainos"
        Label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ServiceCodeLabel
        '
        ServiceCodeLabel.AutoSize = True
        ServiceCodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ServiceCodeLabel.Location = New System.Drawing.Point(30, 61)
        ServiceCodeLabel.Name = "ServiceCodeLabel"
        ServiceCodeLabel.Size = New System.Drawing.Size(111, 13)
        ServiceCodeLabel.TabIndex = 23
        ServiceCodeLabel.Text = "Paslaugos kodas::"
        '
        'AccountPurchaseAccGridComboBox
        '
        Me.AccountPurchaseAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ServiceBindingSource, "AccountPurchase", True))
        Me.AccountPurchaseAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountPurchaseAccGridComboBox.FilterPropertyName = ""
        Me.AccountPurchaseAccGridComboBox.FormattingEnabled = True
        Me.AccountPurchaseAccGridComboBox.InstantBinding = True
        Me.AccountPurchaseAccGridComboBox.Location = New System.Drawing.Point(146, 39)
        Me.AccountPurchaseAccGridComboBox.Name = "AccountPurchaseAccGridComboBox"
        Me.AccountPurchaseAccGridComboBox.Size = New System.Drawing.Size(125, 21)
        Me.AccountPurchaseAccGridComboBox.TabIndex = 0
        '
        'ServiceBindingSource
        '
        Me.ServiceBindingSource.DataSource = GetType(ApskaitaObjects.Documents.Service)
        '
        'AccountSalesAccGridComboBox
        '
        Me.AccountSalesAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ServiceBindingSource, "AccountSales", True))
        Me.AccountSalesAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountSalesAccGridComboBox.FilterPropertyName = ""
        Me.AccountSalesAccGridComboBox.FormattingEnabled = True
        Me.AccountSalesAccGridComboBox.InstantBinding = True
        Me.AccountSalesAccGridComboBox.Location = New System.Drawing.Point(146, 68)
        Me.AccountSalesAccGridComboBox.Name = "AccountSalesAccGridComboBox"
        Me.AccountSalesAccGridComboBox.Size = New System.Drawing.Size(125, 21)
        Me.AccountSalesAccGridComboBox.TabIndex = 3
        '
        'AccountVatPurchaseAccGridComboBox
        '
        Me.AccountVatPurchaseAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ServiceBindingSource, "AccountVatPurchase", True))
        Me.AccountVatPurchaseAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountVatPurchaseAccGridComboBox.FilterPropertyName = ""
        Me.AccountVatPurchaseAccGridComboBox.FormattingEnabled = True
        Me.AccountVatPurchaseAccGridComboBox.InstantBinding = True
        Me.AccountVatPurchaseAccGridComboBox.Location = New System.Drawing.Point(438, 39)
        Me.AccountVatPurchaseAccGridComboBox.Name = "AccountVatPurchaseAccGridComboBox"
        Me.AccountVatPurchaseAccGridComboBox.Size = New System.Drawing.Size(125, 21)
        Me.AccountVatPurchaseAccGridComboBox.TabIndex = 2
        '
        'AccountVatSalesAccGridComboBox
        '
        Me.AccountVatSalesAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ServiceBindingSource, "AccountVatSales", True))
        Me.AccountVatSalesAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountVatSalesAccGridComboBox.FilterPropertyName = ""
        Me.AccountVatSalesAccGridComboBox.FormattingEnabled = True
        Me.AccountVatSalesAccGridComboBox.InstantBinding = True
        Me.AccountVatSalesAccGridComboBox.Location = New System.Drawing.Point(438, 68)
        Me.AccountVatSalesAccGridComboBox.Name = "AccountVatSalesAccGridComboBox"
        Me.AccountVatSalesAccGridComboBox.Size = New System.Drawing.Size(125, 21)
        Me.AccountVatSalesAccGridComboBox.TabIndex = 5
        '
        'AmountAccTextBox
        '
        Me.AmountAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.ServiceBindingSource, "Amount", True))
        Me.AmountAccTextBox.DecimalLength = 4
        Me.AmountAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AmountAccTextBox.Location = New System.Drawing.Point(146, 97)
        Me.AmountAccTextBox.Name = "AmountAccTextBox"
        Me.AmountAccTextBox.Size = New System.Drawing.Size(125, 20)
        Me.AmountAccTextBox.TabIndex = 6
        Me.AmountAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IDTextBox
        '
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServiceBindingSource, "ID", True))
        Me.IDTextBox.Location = New System.Drawing.Point(147, 6)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(121, 20)
        Me.IDTextBox.TabIndex = 11
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IsObsoleteCheckBox
        '
        Me.IsObsoleteCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IsObsoleteCheckBox.AutoSize = True
        Me.IsObsoleteCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.ServiceBindingSource, "IsObsolete", True))
        Me.IsObsoleteCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsObsoleteCheckBox.Location = New System.Drawing.Point(444, 60)
        Me.IsObsoleteCheckBox.Name = "IsObsoleteCheckBox"
        Me.IsObsoleteCheckBox.Size = New System.Drawing.Size(117, 17)
        Me.IsObsoleteCheckBox.TabIndex = 3
        Me.IsObsoleteCheckBox.Text = "Nebenaudojama"
        '
        'NameShortTextBox
        '
        Me.NameShortTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NameShortTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServiceBindingSource, "NameShort", True))
        Me.NameShortTextBox.Location = New System.Drawing.Point(147, 32)
        Me.NameShortTextBox.Name = "NameShortTextBox"
        Me.NameShortTextBox.Size = New System.Drawing.Size(417, 20)
        Me.NameShortTextBox.TabIndex = 1
        '
        'RateVatPurchaseComboBox
        '
        Me.RateVatPurchaseComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServiceBindingSource, "RateVatPurchase", True))
        Me.RateVatPurchaseComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RateVatPurchaseComboBox.FormattingEnabled = True
        Me.RateVatPurchaseComboBox.Location = New System.Drawing.Point(292, 39)
        Me.RateVatPurchaseComboBox.Name = "RateVatPurchaseComboBox"
        Me.RateVatPurchaseComboBox.Size = New System.Drawing.Size(125, 21)
        Me.RateVatPurchaseComboBox.TabIndex = 1
        '
        'RateVatSalesComboBox
        '
        Me.RateVatSalesComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServiceBindingSource, "RateVatSales", True))
        Me.RateVatSalesComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RateVatSalesComboBox.FormattingEnabled = True
        Me.RateVatSalesComboBox.Location = New System.Drawing.Point(292, 68)
        Me.RateVatSalesComboBox.Name = "RateVatSalesComboBox"
        Me.RateVatSalesComboBox.Size = New System.Drawing.Size(125, 21)
        Me.RateVatSalesComboBox.TabIndex = 4
        '
        'TypeHumanReadableComboBox
        '
        Me.TypeHumanReadableComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TypeHumanReadableComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServiceBindingSource, "TypeHumanReadable", True))
        Me.TypeHumanReadableComboBox.FormattingEnabled = True
        Me.TypeHumanReadableComboBox.Location = New System.Drawing.Point(322, 5)
        Me.TypeHumanReadableComboBox.Name = "TypeHumanReadableComboBox"
        Me.TypeHumanReadableComboBox.Size = New System.Drawing.Size(242, 21)
        Me.TypeHumanReadableComboBox.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TableLayoutPanel1.Controls.Add(Label1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Label2, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Label3, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.AmountAccTextBox, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(AmountLabel, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(AccountSalesLabel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.AccountSalesAccGridComboBox, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(AccountPurchaseLabel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.AccountPurchaseAccGridComboBox, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.RateVatSalesComboBox, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.RateVatPurchaseComboBox, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.AccountVatSalesAccGridComboBox, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.AccountVatPurchaseAccGridComboBox, 5, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 85)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33444!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33445!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33112!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(583, 125)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Label4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.RegionalPricesDataGridView, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(584, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(326, 213)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'RegionalPricesDataGridView
        '
        Me.RegionalPricesDataGridView.AllowUserToOrderColumns = True
        Me.RegionalPricesDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RegionalPricesDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.RegionalPricesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RegionalPricesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.RegionalPricesDataGridView.DataSource = Me.RegionalPricesSortedBindingSource
        Me.RegionalPricesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RegionalPricesDataGridView.Location = New System.Drawing.Point(3, 28)
        Me.RegionalPricesDataGridView.Name = "RegionalPricesDataGridView"
        Me.RegionalPricesDataGridView.RowHeadersWidth = 15
        Me.RegionalPricesDataGridView.Size = New System.Drawing.Size(320, 182)
        Me.RegionalPricesDataGridView.TabIndex = 0
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
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CurrencyCode"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Valiuta"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AllowNegative = False
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "ValuePerUnitSales"
        Me.DataGridViewTextBoxColumn3.DecimalLength = 4
        DataGridViewCellStyle2.Format = "##,0.0000"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn3.HeaderText = "Pardavimo"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AllowNegative = False
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ValuePerUnitPurchases"
        Me.DataGridViewTextBoxColumn4.DecimalLength = 4
        DataGridViewCellStyle3.Format = "##,0.0000"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn4.HeaderText = "Pirkimo"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'RegionalPricesSortedBindingSource
        '
        Me.RegionalPricesSortedBindingSource.DataMember = "RegionalPricesSorted"
        Me.RegionalPricesSortedBindingSource.DataSource = Me.ServiceBindingSource
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(ServiceCodeLabel)
        Me.Panel1.Controls.Add(Me.ServiceCodeTextBox)
        Me.Panel1.Controls.Add(IDLabel)
        Me.Panel1.Controls.Add(Me.IsObsoleteCheckBox)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Controls.Add(NameShortLabel)
        Me.Panel1.Controls.Add(Me.NameShortTextBox)
        Me.Panel1.Controls.Add(Me.TypeHumanReadableComboBox)
        Me.Panel1.Controls.Add(Me.IDTextBox)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(TypeHumanReadableLabel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Panel1.Size = New System.Drawing.Size(910, 216)
        Me.Panel1.TabIndex = 0
        '
        'ServiceCodeTextBox
        '
        Me.ServiceCodeTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ServiceCodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServiceBindingSource, "ServiceCode", True))
        Me.ServiceCodeTextBox.Location = New System.Drawing.Point(147, 58)
        Me.ServiceCodeTextBox.MaxLength = 15
        Me.ServiceCodeTextBox.Name = "ServiceCodeTextBox"
        Me.ServiceCodeTextBox.Size = New System.Drawing.Size(276, 20)
        Me.ServiceCodeTextBox.TabIndex = 2
        Me.ServiceCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.ICancelButton)
        Me.Panel2.Controls.Add(Me.IOkButton)
        Me.Panel2.Controls.Add(Me.IApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 465)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(910, 32)
        Me.Panel2.TabIndex = 2
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(809, 6)
        Me.ICancelButton.Name = "ICancelButton"
        Me.ICancelButton.Size = New System.Drawing.Size(89, 23)
        Me.ICancelButton.TabIndex = 2
        Me.ICancelButton.Text = "Atšaukti"
        Me.ICancelButton.UseVisualStyleBackColor = True
        '
        'IOkButton
        '
        Me.IOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IOkButton.Location = New System.Drawing.Point(603, 6)
        Me.IOkButton.Name = "IOkButton"
        Me.IOkButton.Size = New System.Drawing.Size(89, 23)
        Me.IOkButton.TabIndex = 0
        Me.IOkButton.Text = "Ok"
        Me.IOkButton.UseVisualStyleBackColor = True
        '
        'IApplyButton
        '
        Me.IApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IApplyButton.Location = New System.Drawing.Point(707, 6)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(89, 23)
        Me.IApplyButton.TabIndex = 1
        Me.IApplyButton.Text = "Išsaugoti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'RegionalContentsSortedBindingSource
        '
        Me.RegionalContentsSortedBindingSource.DataMember = "RegionalContentsSorted"
        Me.RegionalContentsSortedBindingSource.DataSource = Me.ServiceBindingSource
        '
        'RegionalContentsDataGridView
        '
        Me.RegionalContentsDataGridView.AllowUserToOrderColumns = True
        Me.RegionalContentsDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RegionalContentsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.RegionalContentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RegionalContentsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10})
        Me.RegionalContentsDataGridView.DataSource = Me.RegionalContentsSortedBindingSource
        Me.RegionalContentsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RegionalContentsDataGridView.Location = New System.Drawing.Point(0, 216)
        Me.RegionalContentsDataGridView.Name = "RegionalContentsDataGridView"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RegionalContentsDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.RegionalContentsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RegionalContentsDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.RegionalContentsDataGridView.Size = New System.Drawing.Size(910, 249)
        Me.RegionalContentsDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn5.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "LanguageName"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Regiono kalba"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "ContentInvoice"
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn8.HeaderText = "Turinys sąskaitoje faktūroje"
        Me.DataGridViewTextBoxColumn8.MaxInputLength = 255
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "MeasureUnit"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Mato vnt."
        Me.DataGridViewTextBoxColumn9.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "VatExempt"
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn10.HeaderText = "PVM išimties paaiškinimas"
        Me.DataGridViewTextBoxColumn10.MaxInputLength = 255
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.DataSource = Me.ServiceBindingSource
        '
        'F_Service
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 497)
        Me.Controls.Add(Me.RegionalContentsDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_Service"
        Me.ShowInTaskbar = False
        Me.Text = "Paslaugos duomenys"
        CType(Me.ServiceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.RegionalPricesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RegionalPricesSortedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.RegionalContentsSortedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RegionalContentsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AccountPurchaseAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents ServiceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AccountSalesAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents AccountVatPurchaseAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents AccountVatSalesAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents AmountAccTextBox As AccControls.AccTextBox
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IsObsoleteCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents NameShortTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RateVatPurchaseComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RateVatSalesComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TypeHumanReadableComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RegionalPricesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents RegionalPricesSortedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents RegionalContentsSortedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RegionalContentsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
