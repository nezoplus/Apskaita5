<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_InvoiceReceived
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
        Dim AccountSupplierLabel As System.Windows.Forms.Label
        Dim CommentsInternalLabel As System.Windows.Forms.Label
        Dim ContentLabel As System.Windows.Forms.Label
        Dim CurrencyCodeLabel As System.Windows.Forms.Label
        Dim CurrencyRateLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim NumberLabel As System.Windows.Forms.Label
        Dim SumLabel As System.Windows.Forms.Label
        Dim SumLTLLabel As System.Windows.Forms.Label
        Dim SumTotalLabel As System.Windows.Forms.Label
        Dim SumTotalLTLLabel As System.Windows.Forms.Label
        Dim SumVatLabel As System.Windows.Forms.Label
        Dim SumVatLTLLabel As System.Windows.Forms.Label
        Dim SupplierLabel As System.Windows.Forms.Label
        Dim TypeHumanReadableLabel As System.Windows.Forms.Label
        Dim UpdateDateLabel As System.Windows.Forms.Label
        Dim InsertDateLabel As System.Windows.Forms.Label
        Dim ActualDateLabel As System.Windows.Forms.Label
        Dim IndirectVatAccountLabel As System.Windows.Forms.Label
        Dim IndirectVatCostsAccountLabel As System.Windows.Forms.Label
        Dim IndirectVatSumLabel As System.Windows.Forms.Label
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_InvoiceReceived))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.CalculateIndirectVatButton = New System.Windows.Forms.Button
        Me.IndirectVatCostsAccountAccGridComboBox = New AccControls.AccGridComboBox
        Me.InvoiceReceivedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IndirectVatAccountAccGridComboBox = New AccControls.AccGridComboBox
        Me.IndirectVatSumAccTextBox = New AccControls.AccTextBox
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel
        Me.SumTotalAccTextBox = New AccControls.AccTextBox
        Me.SumVatAccTextBox = New AccControls.AccTextBox
        Me.SumAccTextBox = New AccControls.AccTextBox
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel
        Me.CommentsInternalTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel
        Me.SumLTLAccTextBox = New AccControls.AccTextBox
        Me.SumTotalLTLAccTextBox = New AccControls.AccTextBox
        Me.SumVatLTLAccTextBox = New AccControls.AccTextBox
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.AccountSupplierAccGridComboBox = New AccControls.AccGridComboBox
        Me.ActualDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.ActualDateIsApplicableCheckBox = New System.Windows.Forms.CheckBox
        Me.NumberTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel
        Me.ContentTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.GetCurrencyRatesButton = New System.Windows.Forms.Button
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.CurrencyCodeComboBox = New System.Windows.Forms.ComboBox
        Me.CurrencyRateAccTextBox = New AccControls.AccTextBox
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel
        Me.SupplierAccGridComboBox = New AccControls.AccGridComboBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.UpdateDateTextBox = New System.Windows.Forms.TextBox
        Me.InsertDateTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel
        Me.TypeHumanReadableComboBox = New System.Windows.Forms.ComboBox
        Me.AddAttachedObjectButton = New System.Windows.Forms.Button
        Me.CopyInvoiceButton = New System.Windows.Forms.Button
        Me.PasteInvoiceButton = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LimitationsButton = New System.Windows.Forms.Button
        Me.NewButton = New System.Windows.Forms.Button
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.InvoiceItemsSortedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InvoiceItemsSortedDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccountCostsDataGridViewTextBoxColumn = New AccControls.DataGridViewAccGridComboBoxColumn
        Me.AccountVatDataGridViewTextBoxColumn = New AccControls.DataGridViewAccGridComboBoxColumn
        Me.DataGridViewTextBoxColumn6 = New AccControls.DataGridViewAccTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New AccControls.DataGridViewAccTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New AccControls.DataGridViewNumericUpDownColumn
        Me.VatRateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New AccControls.DataGridViewNumericUpDownColumn
        Me.IncludeVatInObject = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New AccControls.DataGridViewNumericUpDownColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn17 = New AccControls.DataGridViewNumericUpDownColumn
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn19 = New AccControls.DataGridViewNumericUpDownColumn
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        AccountSupplierLabel = New System.Windows.Forms.Label
        CommentsInternalLabel = New System.Windows.Forms.Label
        ContentLabel = New System.Windows.Forms.Label
        CurrencyCodeLabel = New System.Windows.Forms.Label
        CurrencyRateLabel = New System.Windows.Forms.Label
        DateLabel = New System.Windows.Forms.Label
        IDLabel = New System.Windows.Forms.Label
        NumberLabel = New System.Windows.Forms.Label
        SumLabel = New System.Windows.Forms.Label
        SumLTLLabel = New System.Windows.Forms.Label
        SumTotalLabel = New System.Windows.Forms.Label
        SumTotalLTLLabel = New System.Windows.Forms.Label
        SumVatLabel = New System.Windows.Forms.Label
        SumVatLTLLabel = New System.Windows.Forms.Label
        SupplierLabel = New System.Windows.Forms.Label
        TypeHumanReadableLabel = New System.Windows.Forms.Label
        UpdateDateLabel = New System.Windows.Forms.Label
        InsertDateLabel = New System.Windows.Forms.Label
        ActualDateLabel = New System.Windows.Forms.Label
        IndirectVatAccountLabel = New System.Windows.Forms.Label
        IndirectVatCostsAccountLabel = New System.Windows.Forms.Label
        IndirectVatSumLabel = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.InvoiceReceivedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel11.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.InvoiceItemsSortedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceItemsSortedDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AccountSupplierLabel
        '
        AccountSupplierLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        AccountSupplierLabel.AutoSize = True
        AccountSupplierLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountSupplierLabel.Location = New System.Drawing.Point(534, 3)
        AccountSupplierLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        AccountSupplierLabel.Name = "AccountSupplierLabel"
        AccountSupplierLabel.Size = New System.Drawing.Size(87, 13)
        AccountSupplierLabel.TabIndex = 2
        AccountSupplierLabel.Text = "Tiekėjo sąsk.:"
        '
        'CommentsInternalLabel
        '
        CommentsInternalLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        CommentsInternalLabel.AutoSize = True
        CommentsInternalLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CommentsInternalLabel.Location = New System.Drawing.Point(24, 171)
        CommentsInternalLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        CommentsInternalLabel.Name = "CommentsInternalLabel"
        CommentsInternalLabel.Size = New System.Drawing.Size(74, 13)
        CommentsInternalLabel.TabIndex = 4
        CommentsInternalLabel.Text = "Komentarai:"
        '
        'ContentLabel
        '
        ContentLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ContentLabel.AutoSize = True
        ContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContentLabel.Location = New System.Drawing.Point(46, 138)
        ContentLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        ContentLabel.Name = "ContentLabel"
        ContentLabel.Size = New System.Drawing.Size(52, 13)
        ContentLabel.TabIndex = 6
        ContentLabel.Text = "Turinys:"
        '
        'CurrencyCodeLabel
        '
        CurrencyCodeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        CurrencyCodeLabel.AutoSize = True
        CurrencyCodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyCodeLabel.Location = New System.Drawing.Point(222, 3)
        CurrencyCodeLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        CurrencyCodeLabel.Name = "CurrencyCodeLabel"
        CurrencyCodeLabel.Size = New System.Drawing.Size(50, 13)
        CurrencyCodeLabel.TabIndex = 8
        CurrencyCodeLabel.Text = "Valiuta:"
        '
        'CurrencyRateLabel
        '
        CurrencyRateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        CurrencyRateLabel.AutoSize = True
        CurrencyRateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyRateLabel.Location = New System.Drawing.Point(494, 3)
        CurrencyRateLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        CurrencyRateLabel.Name = "CurrencyRateLabel"
        CurrencyRateLabel.Size = New System.Drawing.Size(49, 13)
        CurrencyRateLabel.TabIndex = 10
        CurrencyRateLabel.Text = "Kursas:"
        '
        'DateLabel
        '
        DateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DateLabel.AutoSize = True
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(60, 39)
        DateLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(38, 13)
        DateLabel.TabIndex = 12
        DateLabel.Text = "Data:"
        '
        'IDLabel
        '
        IDLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(74, 6)
        IDLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(24, 13)
        IDLabel.TabIndex = 14
        IDLabel.Text = "ID:"
        '
        'NumberLabel
        '
        NumberLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        NumberLabel.AutoSize = True
        NumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NumberLabel.Location = New System.Drawing.Point(210, 3)
        NumberLabel.Margin = New System.Windows.Forms.Padding(5, 3, 0, 0)
        NumberLabel.Name = "NumberLabel"
        NumberLabel.Size = New System.Drawing.Size(56, 13)
        NumberLabel.TabIndex = 16
        NumberLabel.Text = "Numeris:"
        '
        'SumLabel
        '
        SumLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SumLabel.AutoSize = True
        SumLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumLabel.Location = New System.Drawing.Point(56, 237)
        SumLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        SumLabel.Name = "SumLabel"
        SumLabel.Size = New System.Drawing.Size(42, 13)
        SumLabel.TabIndex = 18
        SumLabel.Text = "Suma:"
        '
        'SumLTLLabel
        '
        SumLTLLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SumLTLLabel.AutoSize = True
        SumLTLLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumLTLLabel.Location = New System.Drawing.Point(30, 204)
        SumLTLLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        SumLTLLabel.Name = "SumLTLLabel"
        SumLTLLabel.Size = New System.Drawing.Size(68, 13)
        SumLTLLabel.TabIndex = 20
        SumLTLLabel.Text = "Suma LTL:"
        '
        'SumTotalLabel
        '
        SumTotalLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SumTotalLabel.AutoSize = True
        SumTotalLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumTotalLabel.Location = New System.Drawing.Point(529, 3)
        SumTotalLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        SumTotalLabel.Name = "SumTotalLabel"
        SumTotalLabel.Size = New System.Drawing.Size(70, 13)
        SumTotalLabel.TabIndex = 22
        SumTotalLabel.Text = "Suma Viso:"
        '
        'SumTotalLTLLabel
        '
        SumTotalLTLLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SumTotalLTLLabel.AutoSize = True
        SumTotalLTLLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumTotalLTLLabel.Location = New System.Drawing.Point(520, 3)
        SumTotalLTLLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        SumTotalLTLLabel.Name = "SumTotalLTLLabel"
        SumTotalLTLLabel.Size = New System.Drawing.Size(96, 13)
        SumTotalLTLLabel.TabIndex = 24
        SumTotalLTLLabel.Text = "Suma Viso LTL:"
        '
        'SumVatLabel
        '
        SumVatLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SumVatLabel.AutoSize = True
        SumVatLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumVatLabel.Location = New System.Drawing.Point(228, 3)
        SumVatLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        SumVatLabel.Name = "SumVatLabel"
        SumVatLabel.Size = New System.Drawing.Size(72, 13)
        SumVatLabel.TabIndex = 26
        SumVatLabel.Text = "Suma PVM:"
        '
        'SumVatLTLLabel
        '
        SumVatLTLLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SumVatLTLLabel.AutoSize = True
        SumVatLTLLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumVatLTLLabel.Location = New System.Drawing.Point(211, 3)
        SumVatLTLLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        SumVatLTLLabel.Name = "SumVatLTLLabel"
        SumVatLTLLabel.Size = New System.Drawing.Size(98, 13)
        SumVatLTLLabel.TabIndex = 28
        SumVatLTLLabel.Text = "Suma PVM LTL:"
        '
        'SupplierLabel
        '
        SupplierLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SupplierLabel.AutoSize = True
        SupplierLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SupplierLabel.Location = New System.Drawing.Point(39, 105)
        SupplierLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        SupplierLabel.Name = "SupplierLabel"
        SupplierLabel.Size = New System.Drawing.Size(59, 13)
        SupplierLabel.TabIndex = 30
        SupplierLabel.Text = "Tiekėjas:"
        '
        'TypeHumanReadableLabel
        '
        TypeHumanReadableLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        TypeHumanReadableLabel.AutoSize = True
        TypeHumanReadableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TypeHumanReadableLabel.Location = New System.Drawing.Point(56, 303)
        TypeHumanReadableLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        TypeHumanReadableLabel.Name = "TypeHumanReadableLabel"
        TypeHumanReadableLabel.Size = New System.Drawing.Size(42, 13)
        TypeHumanReadableLabel.TabIndex = 56
        TypeHumanReadableLabel.Text = "Tipas:"
        '
        'UpdateDateLabel
        '
        UpdateDateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        UpdateDateLabel.AutoSize = True
        UpdateDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UpdateDateLabel.Location = New System.Drawing.Point(527, 3)
        UpdateDateLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        UpdateDateLabel.Name = "UpdateDateLabel"
        UpdateDateLabel.Size = New System.Drawing.Size(60, 13)
        UpdateDateLabel.TabIndex = 57
        UpdateDateLabel.Text = "Pakeista:"
        '
        'InsertDateLabel
        '
        InsertDateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        InsertDateLabel.AutoSize = True
        InsertDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        InsertDateLabel.Location = New System.Drawing.Point(232, 3)
        InsertDateLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        InsertDateLabel.Name = "InsertDateLabel"
        InsertDateLabel.Size = New System.Drawing.Size(55, 13)
        InsertDateLabel.TabIndex = 58
        InsertDateLabel.Text = "Įtraukta:"
        '
        'ActualDateLabel
        '
        ActualDateLabel.AutoSize = True
        ActualDateLabel.Dock = System.Windows.Forms.DockStyle.Fill
        ActualDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ActualDateLabel.Location = New System.Drawing.Point(0, 72)
        ActualDateLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        ActualDateLabel.Name = "ActualDateLabel"
        ActualDateLabel.Size = New System.Drawing.Size(98, 27)
        ActualDateLabel.TabIndex = 4
        ActualDateLabel.Text = "Reali Data:"
        ActualDateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'IndirectVatAccountLabel
        '
        IndirectVatAccountLabel.AutoSize = True
        IndirectVatAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IndirectVatAccountLabel.Location = New System.Drawing.Point(226, 3)
        IndirectVatAccountLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        IndirectVatAccountLabel.Name = "IndirectVatAccountLabel"
        IndirectVatAccountLabel.Size = New System.Drawing.Size(73, 13)
        IndirectVatAccountLabel.TabIndex = 5
        IndirectVatAccountLabel.Text = "PVM Sąsk.:"
        '
        'IndirectVatCostsAccountLabel
        '
        IndirectVatCostsAccountLabel.AutoSize = True
        IndirectVatCostsAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IndirectVatCostsAccountLabel.Location = New System.Drawing.Point(500, 3)
        IndirectVatCostsAccountLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        IndirectVatCostsAccountLabel.Name = "IndirectVatCostsAccountLabel"
        IndirectVatCostsAccountLabel.Size = New System.Drawing.Size(127, 13)
        IndirectVatCostsAccountLabel.TabIndex = 9
        IndirectVatCostsAccountLabel.Text = "PVM Sąnaudų Sąsk.:"
        '
        'IndirectVatSumLabel
        '
        IndirectVatSumLabel.AutoSize = True
        IndirectVatSumLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IndirectVatSumLabel.Location = New System.Drawing.Point(0, 270)
        IndirectVatSumLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        IndirectVatSumLabel.Name = "IndirectVatSumLabel"
        IndirectVatSumLabel.Size = New System.Drawing.Size(98, 13)
        IndirectVatSumLabel.TabIndex = 11
        IndirectVatSumLabel.Text = "Netiesiog. PVM:"
        IndirectVatSumLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(IndirectVatSumLabel, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel10, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(ActualDateLabel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel8, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel9, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel7, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(SumLabel, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel6, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(ContentLabel, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(CommentsInternalLabel, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(DateLabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(SupplierLabel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(SumLTLLabel, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel11, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(TypeHumanReadableLabel, 0, 9)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(927, 333)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 9
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.CalculateIndirectVatButton, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.IndirectVatCostsAccountAccGridComboBox, 7, 0)
        Me.TableLayoutPanel3.Controls.Add(IndirectVatCostsAccountLabel, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.IndirectVatAccountAccGridComboBox, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(IndirectVatAccountLabel, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.IndirectVatSumAccTextBox, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(98, 267)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(829, 27)
        Me.TableLayoutPanel3.TabIndex = 8
        '
        'CalculateIndirectVatButton
        '
        Me.CalculateIndirectVatButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalculateIndirectVatButton.Image = Global.ApskaitaWUI.My.Resources.Resources.calculator_16
        Me.CalculateIndirectVatButton.Location = New System.Drawing.Point(0, 0)
        Me.CalculateIndirectVatButton.Margin = New System.Windows.Forms.Padding(0)
        Me.CalculateIndirectVatButton.Name = "CalculateIndirectVatButton"
        Me.CalculateIndirectVatButton.Size = New System.Drawing.Size(25, 25)
        Me.CalculateIndirectVatButton.TabIndex = 0
        Me.CalculateIndirectVatButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CalculateIndirectVatButton.UseVisualStyleBackColor = True
        '
        'IndirectVatCostsAccountAccGridComboBox
        '
        Me.IndirectVatCostsAccountAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.InvoiceReceivedBindingSource, "IndirectVatCostsAccount", True))
        Me.IndirectVatCostsAccountAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IndirectVatCostsAccountAccGridComboBox.FilterPropertyName = ""
        Me.IndirectVatCostsAccountAccGridComboBox.FormattingEnabled = True
        Me.IndirectVatCostsAccountAccGridComboBox.InstantBinding = True
        Me.IndirectVatCostsAccountAccGridComboBox.Location = New System.Drawing.Point(629, 0)
        Me.IndirectVatCostsAccountAccGridComboBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.IndirectVatCostsAccountAccGridComboBox.Name = "IndirectVatCostsAccountAccGridComboBox"
        Me.IndirectVatCostsAccountAccGridComboBox.Size = New System.Drawing.Size(177, 21)
        Me.IndirectVatCostsAccountAccGridComboBox.TabIndex = 3
        '
        'InvoiceReceivedBindingSource
        '
        Me.InvoiceReceivedBindingSource.DataSource = GetType(ApskaitaObjects.Documents.InvoiceReceived)
        '
        'IndirectVatAccountAccGridComboBox
        '
        Me.IndirectVatAccountAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.InvoiceReceivedBindingSource, "IndirectVatAccount", True))
        Me.IndirectVatAccountAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IndirectVatAccountAccGridComboBox.FilterPropertyName = ""
        Me.IndirectVatAccountAccGridComboBox.FormattingEnabled = True
        Me.IndirectVatAccountAccGridComboBox.InstantBinding = True
        Me.IndirectVatAccountAccGridComboBox.Location = New System.Drawing.Point(301, 0)
        Me.IndirectVatAccountAccGridComboBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.IndirectVatAccountAccGridComboBox.Name = "IndirectVatAccountAccGridComboBox"
        Me.IndirectVatAccountAccGridComboBox.Size = New System.Drawing.Size(177, 21)
        Me.IndirectVatAccountAccGridComboBox.TabIndex = 2
        '
        'IndirectVatSumAccTextBox
        '
        Me.IndirectVatSumAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceReceivedBindingSource, "IndirectVatSum", True))
        Me.IndirectVatSumAccTextBox.KeepBackColorWhenReadOnly = False
        Me.IndirectVatSumAccTextBox.Location = New System.Drawing.Point(27, 0)
        Me.IndirectVatSumAccTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.IndirectVatSumAccTextBox.Name = "IndirectVatSumAccTextBox"
        Me.IndirectVatSumAccTextBox.NegativeValue = False
        Me.IndirectVatSumAccTextBox.Size = New System.Drawing.Size(177, 20)
        Me.IndirectVatSumAccTextBox.TabIndex = 1
        Me.IndirectVatSumAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.ColumnCount = 8
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.SumTotalAccTextBox, 6, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.SumVatAccTextBox, 3, 0)
        Me.TableLayoutPanel10.Controls.Add(SumVatLabel, 2, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.SumAccTextBox, 0, 0)
        Me.TableLayoutPanel10.Controls.Add(SumTotalLabel, 5, 0)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(98, 234)
        Me.TableLayoutPanel10.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 1
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(829, 27)
        Me.TableLayoutPanel10.TabIndex = 7
        '
        'SumTotalAccTextBox
        '
        Me.SumTotalAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceReceivedBindingSource, "SumTotal", True))
        Me.SumTotalAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumTotalAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumTotalAccTextBox.Location = New System.Drawing.Point(601, 0)
        Me.SumTotalAccTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.SumTotalAccTextBox.Name = "SumTotalAccTextBox"
        Me.SumTotalAccTextBox.ReadOnly = True
        Me.SumTotalAccTextBox.Size = New System.Drawing.Size(205, 20)
        Me.SumTotalAccTextBox.TabIndex = 23
        Me.SumTotalAccTextBox.TabStop = False
        Me.SumTotalAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumVatAccTextBox
        '
        Me.SumVatAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceReceivedBindingSource, "SumVat", True))
        Me.SumVatAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumVatAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumVatAccTextBox.Location = New System.Drawing.Point(302, 0)
        Me.SumVatAccTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.SumVatAccTextBox.Name = "SumVatAccTextBox"
        Me.SumVatAccTextBox.ReadOnly = True
        Me.SumVatAccTextBox.Size = New System.Drawing.Size(205, 20)
        Me.SumVatAccTextBox.TabIndex = 27
        Me.SumVatAccTextBox.TabStop = False
        Me.SumVatAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumAccTextBox
        '
        Me.SumAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceReceivedBindingSource, "Sum", True))
        Me.SumAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumAccTextBox.Location = New System.Drawing.Point(2, 0)
        Me.SumAccTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.SumAccTextBox.Name = "SumAccTextBox"
        Me.SumAccTextBox.ReadOnly = True
        Me.SumAccTextBox.Size = New System.Drawing.Size(204, 20)
        Me.SumAccTextBox.TabIndex = 19
        Me.SumAccTextBox.TabStop = False
        Me.SumAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.CommentsInternalTextBox, 0, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(98, 168)
        Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(829, 27)
        Me.TableLayoutPanel8.TabIndex = 5
        '
        'CommentsInternalTextBox
        '
        Me.CommentsInternalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceReceivedBindingSource, "CommentsInternal", True))
        Me.CommentsInternalTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CommentsInternalTextBox.Location = New System.Drawing.Point(2, 0)
        Me.CommentsInternalTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.CommentsInternalTextBox.MaxLength = 255
        Me.CommentsInternalTextBox.Name = "CommentsInternalTextBox"
        Me.CommentsInternalTextBox.Size = New System.Drawing.Size(805, 20)
        Me.CommentsInternalTextBox.TabIndex = 0
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 8
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.SumLTLAccTextBox, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(SumTotalLTLLabel, 5, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.SumTotalLTLAccTextBox, 6, 0)
        Me.TableLayoutPanel9.Controls.Add(SumVatLTLLabel, 2, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.SumVatLTLAccTextBox, 3, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(98, 201)
        Me.TableLayoutPanel9.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(829, 27)
        Me.TableLayoutPanel9.TabIndex = 6
        '
        'SumLTLAccTextBox
        '
        Me.SumLTLAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceReceivedBindingSource, "SumLTL", True))
        Me.SumLTLAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumLTLAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumLTLAccTextBox.Location = New System.Drawing.Point(2, 0)
        Me.SumLTLAccTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.SumLTLAccTextBox.Name = "SumLTLAccTextBox"
        Me.SumLTLAccTextBox.ReadOnly = True
        Me.SumLTLAccTextBox.Size = New System.Drawing.Size(187, 20)
        Me.SumLTLAccTextBox.TabIndex = 21
        Me.SumLTLAccTextBox.TabStop = False
        Me.SumLTLAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumTotalLTLAccTextBox
        '
        Me.SumTotalLTLAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceReceivedBindingSource, "SumTotalLTL", True))
        Me.SumTotalLTLAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumTotalLTLAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumTotalLTLAccTextBox.Location = New System.Drawing.Point(618, 0)
        Me.SumTotalLTLAccTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.SumTotalLTLAccTextBox.Name = "SumTotalLTLAccTextBox"
        Me.SumTotalLTLAccTextBox.ReadOnly = True
        Me.SumTotalLTLAccTextBox.Size = New System.Drawing.Size(187, 20)
        Me.SumTotalLTLAccTextBox.TabIndex = 25
        Me.SumTotalLTLAccTextBox.TabStop = False
        Me.SumTotalLTLAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumVatLTLAccTextBox
        '
        Me.SumVatLTLAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceReceivedBindingSource, "SumVatLTL", True))
        Me.SumVatLTLAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumVatLTLAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumVatLTLAccTextBox.Location = New System.Drawing.Point(311, 0)
        Me.SumVatLTLAccTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.SumVatLTLAccTextBox.Name = "SumVatLTLAccTextBox"
        Me.SumVatLTLAccTextBox.ReadOnly = True
        Me.SumVatLTLAccTextBox.Size = New System.Drawing.Size(187, 20)
        Me.SumVatLTLAccTextBox.TabIndex = 29
        Me.SumVatLTLAccTextBox.TabStop = False
        Me.SumVatLTLAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 8
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.AccountSupplierAccGridComboBox, 6, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.ActualDateDateTimePicker, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(AccountSupplierLabel, 5, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.ActualDateIsApplicableCheckBox, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.NumberTextBox, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(NumberLabel, 2, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(98, 69)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(829, 27)
        Me.TableLayoutPanel5.TabIndex = 2
        '
        'AccountSupplierAccGridComboBox
        '
        Me.AccountSupplierAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.InvoiceReceivedBindingSource, "AccountSupplier", True))
        Me.AccountSupplierAccGridComboBox.FilterPropertyName = ""
        Me.AccountSupplierAccGridComboBox.FormattingEnabled = True
        Me.AccountSupplierAccGridComboBox.InstantBinding = True
        Me.AccountSupplierAccGridComboBox.Location = New System.Drawing.Point(623, 0)
        Me.AccountSupplierAccGridComboBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.AccountSupplierAccGridComboBox.Name = "AccountSupplierAccGridComboBox"
        Me.AccountSupplierAccGridComboBox.Size = New System.Drawing.Size(182, 21)
        Me.AccountSupplierAccGridComboBox.TabIndex = 3
        '
        'ActualDateDateTimePicker
        '
        Me.ActualDateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.InvoiceReceivedBindingSource, "ActualDate", True))
        Me.ActualDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ActualDateDateTimePicker.Location = New System.Drawing.Point(21, 0)
        Me.ActualDateDateTimePicker.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.ActualDateDateTimePicker.Name = "ActualDateDateTimePicker"
        Me.ActualDateDateTimePicker.Size = New System.Drawing.Size(182, 20)
        Me.ActualDateDateTimePicker.TabIndex = 1
        '
        'ActualDateIsApplicableCheckBox
        '
        Me.ActualDateIsApplicableCheckBox.AutoSize = True
        Me.ActualDateIsApplicableCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.InvoiceReceivedBindingSource, "ActualDateIsApplicable", True))
        Me.ActualDateIsApplicableCheckBox.Location = New System.Drawing.Point(2, 3)
        Me.ActualDateIsApplicableCheckBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 0)
        Me.ActualDateIsApplicableCheckBox.Name = "ActualDateIsApplicableCheckBox"
        Me.ActualDateIsApplicableCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.ActualDateIsApplicableCheckBox.TabIndex = 0
        '
        'NumberTextBox
        '
        Me.NumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceReceivedBindingSource, "Number", True))
        Me.NumberTextBox.Location = New System.Drawing.Point(268, 0)
        Me.NumberTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.NumberTextBox.MaxLength = 50
        Me.NumberTextBox.Name = "NumberTextBox"
        Me.NumberTextBox.Size = New System.Drawing.Size(244, 20)
        Me.NumberTextBox.TabIndex = 2
        Me.NumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.ContentTextBox, 0, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(98, 135)
        Me.TableLayoutPanel7.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(829, 27)
        Me.TableLayoutPanel7.TabIndex = 4
        '
        'ContentTextBox
        '
        Me.ContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceReceivedBindingSource, "Content", True))
        Me.ContentTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentTextBox.Location = New System.Drawing.Point(2, 0)
        Me.ContentTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.ContentTextBox.MaxLength = 255
        Me.ContentTextBox.Name = "ContentTextBox"
        Me.ContentTextBox.Size = New System.Drawing.Size(805, 20)
        Me.ContentTextBox.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 9
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33444!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33445!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33111!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.GetCurrencyRatesButton, 6, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.DateDateTimePicker, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(CurrencyCodeLabel, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.CurrencyCodeComboBox, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(CurrencyRateLabel, 5, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.CurrencyRateAccTextBox, 7, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(98, 36)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(829, 27)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'GetCurrencyRatesButton
        '
        Me.GetCurrencyRatesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetCurrencyRatesButton.Location = New System.Drawing.Point(543, 0)
        Me.GetCurrencyRatesButton.Margin = New System.Windows.Forms.Padding(0)
        Me.GetCurrencyRatesButton.Name = "GetCurrencyRatesButton"
        Me.GetCurrencyRatesButton.Size = New System.Drawing.Size(63, 23)
        Me.GetCurrencyRatesButton.TabIndex = 2
        Me.GetCurrencyRatesButton.Text = "$->LTL"
        Me.GetCurrencyRatesButton.UseVisualStyleBackColor = True
        '
        'DateDateTimePicker
        '
        Me.DateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.InvoiceReceivedBindingSource, "Date", True))
        Me.DateDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDateTimePicker.Location = New System.Drawing.Point(2, 0)
        Me.DateDateTimePicker.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(198, 20)
        Me.DateDateTimePicker.TabIndex = 0
        '
        'CurrencyCodeComboBox
        '
        Me.CurrencyCodeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceReceivedBindingSource, "CurrencyCode", True))
        Me.CurrencyCodeComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyCodeComboBox.FormattingEnabled = True
        Me.CurrencyCodeComboBox.Location = New System.Drawing.Point(274, 0)
        Me.CurrencyCodeComboBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.CurrencyCodeComboBox.Name = "CurrencyCodeComboBox"
        Me.CurrencyCodeComboBox.Size = New System.Drawing.Size(198, 21)
        Me.CurrencyCodeComboBox.TabIndex = 1
        '
        'CurrencyRateAccTextBox
        '
        Me.CurrencyRateAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceReceivedBindingSource, "CurrencyRate", True))
        Me.CurrencyRateAccTextBox.DecimalLength = 6
        Me.CurrencyRateAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyRateAccTextBox.KeepBackColorWhenReadOnly = False
        Me.CurrencyRateAccTextBox.Location = New System.Drawing.Point(608, 0)
        Me.CurrencyRateAccTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.CurrencyRateAccTextBox.Name = "CurrencyRateAccTextBox"
        Me.CurrencyRateAccTextBox.NegativeValue = False
        Me.CurrencyRateAccTextBox.Size = New System.Drawing.Size(198, 20)
        Me.CurrencyRateAccTextBox.TabIndex = 3
        Me.CurrencyRateAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.SupplierAccGridComboBox, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(98, 102)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(829, 27)
        Me.TableLayoutPanel6.TabIndex = 3
        '
        'SupplierAccGridComboBox
        '
        Me.SupplierAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.InvoiceReceivedBindingSource, "Supplier", True))
        Me.SupplierAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SupplierAccGridComboBox.FilterPropertyName = ""
        Me.SupplierAccGridComboBox.FormattingEnabled = True
        Me.SupplierAccGridComboBox.InstantBinding = True
        Me.SupplierAccGridComboBox.Location = New System.Drawing.Point(2, 0)
        Me.SupplierAccGridComboBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.SupplierAccGridComboBox.Name = "SupplierAccGridComboBox"
        Me.SupplierAccGridComboBox.Size = New System.Drawing.Size(805, 21)
        Me.SupplierAccGridComboBox.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 9
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ViewJournalEntryButton, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.IDTextBox, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.UpdateDateTextBox, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(UpdateDateLabel, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.InsertDateTextBox, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(InsertDateLabel, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(98, 3)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(829, 27)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.ApskaitaWUI.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(208, 0)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 90
        Me.ViewJournalEntryButton.TabStop = False
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = True
        '
        'IDTextBox
        '
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceReceivedBindingSource, "ID", True))
        Me.IDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IDTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IDTextBox.Location = New System.Drawing.Point(2, 0)
        Me.IDTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(184, 20)
        Me.IDTextBox.TabIndex = 15
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'UpdateDateTextBox
        '
        Me.UpdateDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceReceivedBindingSource, "UpdateDate", True))
        Me.UpdateDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UpdateDateTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdateDateTextBox.Location = New System.Drawing.Point(589, 0)
        Me.UpdateDateTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.UpdateDateTextBox.Name = "UpdateDateTextBox"
        Me.UpdateDateTextBox.ReadOnly = True
        Me.UpdateDateTextBox.Size = New System.Drawing.Size(216, 20)
        Me.UpdateDateTextBox.TabIndex = 58
        Me.UpdateDateTextBox.TabStop = False
        Me.UpdateDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'InsertDateTextBox
        '
        Me.InsertDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceReceivedBindingSource, "InsertDate", True))
        Me.InsertDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InsertDateTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsertDateTextBox.Location = New System.Drawing.Point(289, 0)
        Me.InsertDateTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.InsertDateTextBox.Name = "InsertDateTextBox"
        Me.InsertDateTextBox.ReadOnly = True
        Me.InsertDateTextBox.Size = New System.Drawing.Size(216, 20)
        Me.InsertDateTextBox.TabIndex = 59
        Me.InsertDateTextBox.TabStop = False
        Me.InsertDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel11
        '
        Me.TableLayoutPanel11.ColumnCount = 9
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel11.Controls.Add(Me.TypeHumanReadableComboBox, 0, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.AddAttachedObjectButton, 7, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.CopyInvoiceButton, 3, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.PasteInvoiceButton, 5, 0)
        Me.TableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel11.Location = New System.Drawing.Point(98, 300)
        Me.TableLayoutPanel11.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel11.Name = "TableLayoutPanel11"
        Me.TableLayoutPanel11.RowCount = 1
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel11.Size = New System.Drawing.Size(829, 30)
        Me.TableLayoutPanel11.TabIndex = 9
        '
        'TypeHumanReadableComboBox
        '
        Me.TypeHumanReadableComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceReceivedBindingSource, "TypeHumanReadable", True))
        Me.TypeHumanReadableComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TypeHumanReadableComboBox.FormattingEnabled = True
        Me.TypeHumanReadableComboBox.Location = New System.Drawing.Point(2, 0)
        Me.TypeHumanReadableComboBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TypeHumanReadableComboBox.Name = "TypeHumanReadableComboBox"
        Me.TypeHumanReadableComboBox.Size = New System.Drawing.Size(262, 21)
        Me.TypeHumanReadableComboBox.TabIndex = 0
        '
        'AddAttachedObjectButton
        '
        Me.AddAttachedObjectButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddAttachedObjectButton.Location = New System.Drawing.Point(775, 0)
        Me.AddAttachedObjectButton.Margin = New System.Windows.Forms.Padding(0)
        Me.AddAttachedObjectButton.Name = "AddAttachedObjectButton"
        Me.AddAttachedObjectButton.Size = New System.Drawing.Size(30, 29)
        Me.AddAttachedObjectButton.TabIndex = 3
        Me.AddAttachedObjectButton.Text = "+"
        Me.AddAttachedObjectButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.AddAttachedObjectButton.UseVisualStyleBackColor = True
        '
        'CopyInvoiceButton
        '
        Me.CopyInvoiceButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyInvoiceButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Actions_edit_copy_icon_16p
        Me.CopyInvoiceButton.Location = New System.Drawing.Point(685, 0)
        Me.CopyInvoiceButton.Margin = New System.Windows.Forms.Padding(0)
        Me.CopyInvoiceButton.Name = "CopyInvoiceButton"
        Me.CopyInvoiceButton.Size = New System.Drawing.Size(30, 29)
        Me.CopyInvoiceButton.TabIndex = 1
        Me.CopyInvoiceButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CopyInvoiceButton.UseVisualStyleBackColor = True
        '
        'PasteInvoiceButton
        '
        Me.PasteInvoiceButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasteInvoiceButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Paste_icon_16p
        Me.PasteInvoiceButton.Location = New System.Drawing.Point(730, 0)
        Me.PasteInvoiceButton.Margin = New System.Windows.Forms.Padding(0)
        Me.PasteInvoiceButton.Name = "PasteInvoiceButton"
        Me.PasteInvoiceButton.Size = New System.Drawing.Size(30, 29)
        Me.PasteInvoiceButton.TabIndex = 2
        Me.PasteInvoiceButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.PasteInvoiceButton.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.LimitationsButton)
        Me.Panel2.Controls.Add(Me.NewButton)
        Me.Panel2.Controls.Add(Me.ICancelButton)
        Me.Panel2.Controls.Add(Me.IOkButton)
        Me.Panel2.Controls.Add(Me.IApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 520)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(927, 32)
        Me.Panel2.TabIndex = 2
        '
        'LimitationsButton
        '
        Me.LimitationsButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Action_lock_icon_24p
        Me.LimitationsButton.Location = New System.Drawing.Point(12, 5)
        Me.LimitationsButton.Name = "LimitationsButton"
        Me.LimitationsButton.Size = New System.Drawing.Size(32, 24)
        Me.LimitationsButton.TabIndex = 0
        Me.LimitationsButton.UseVisualStyleBackColor = True
        '
        'NewButton
        '
        Me.NewButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewButton.Location = New System.Drawing.Point(829, 6)
        Me.NewButton.Name = "NewButton"
        Me.NewButton.Size = New System.Drawing.Size(89, 23)
        Me.NewButton.TabIndex = 4
        Me.NewButton.Text = "Nauja"
        Me.NewButton.UseVisualStyleBackColor = True
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(723, 6)
        Me.ICancelButton.Name = "ICancelButton"
        Me.ICancelButton.Size = New System.Drawing.Size(89, 23)
        Me.ICancelButton.TabIndex = 3
        Me.ICancelButton.Text = "Atšaukti"
        Me.ICancelButton.UseVisualStyleBackColor = True
        '
        'IOkButton
        '
        Me.IOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IOkButton.Location = New System.Drawing.Point(517, 6)
        Me.IOkButton.Name = "IOkButton"
        Me.IOkButton.Size = New System.Drawing.Size(89, 23)
        Me.IOkButton.TabIndex = 1
        Me.IOkButton.Text = "Ok"
        Me.IOkButton.UseVisualStyleBackColor = True
        '
        'IApplyButton
        '
        Me.IApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IApplyButton.Location = New System.Drawing.Point(621, 6)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(89, 23)
        Me.IApplyButton.TabIndex = 2
        Me.IApplyButton.Text = "Išsaugoti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'InvoiceItemsSortedBindingSource
        '
        Me.InvoiceItemsSortedBindingSource.DataMember = "InvoiceItemsSorted"
        Me.InvoiceItemsSortedBindingSource.DataSource = Me.InvoiceReceivedBindingSource
        '
        'InvoiceItemsSortedDataGridView
        '
        Me.InvoiceItemsSortedDataGridView.AllowUserToOrderColumns = True
        Me.InvoiceItemsSortedDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.InvoiceItemsSortedDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.InvoiceItemsSortedDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.AccountCostsDataGridViewTextBoxColumn, Me.AccountVatDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.VatRateDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.IncludeVatInObject, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21})
        Me.InvoiceItemsSortedDataGridView.DataSource = Me.InvoiceItemsSortedBindingSource
        Me.InvoiceItemsSortedDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InvoiceItemsSortedDataGridView.Location = New System.Drawing.Point(0, 333)
        Me.InvoiceItemsSortedDataGridView.Name = "InvoiceItemsSortedDataGridView"
        Me.InvoiceItemsSortedDataGridView.RowHeadersWidth = 15
        Me.InvoiceItemsSortedDataGridView.Size = New System.Drawing.Size(927, 187)
        Me.InvoiceItemsSortedDataGridView.TabIndex = 1
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
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "NameInvoice"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Turinys"
        Me.DataGridViewTextBoxColumn2.MaxInputLength = 255
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "MeasureUnit"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Mato Vnt."
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'AccountCostsDataGridViewTextBoxColumn
        '
        Me.AccountCostsDataGridViewTextBoxColumn.CloseOnSingleClick = True
        Me.AccountCostsDataGridViewTextBoxColumn.ComboDataGridView = Nothing
        Me.AccountCostsDataGridViewTextBoxColumn.DataPropertyName = "AccountCosts"
        Me.AccountCostsDataGridViewTextBoxColumn.FilterPropertyName = ""
        Me.AccountCostsDataGridViewTextBoxColumn.HeaderText = "Sąnaudų sąsk."
        Me.AccountCostsDataGridViewTextBoxColumn.InstantBinding = True
        Me.AccountCostsDataGridViewTextBoxColumn.Name = "AccountCostsDataGridViewTextBoxColumn"
        Me.AccountCostsDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AccountCostsDataGridViewTextBoxColumn.ValueMember = ""
        '
        'AccountVatDataGridViewTextBoxColumn
        '
        Me.AccountVatDataGridViewTextBoxColumn.CloseOnSingleClick = True
        Me.AccountVatDataGridViewTextBoxColumn.ComboDataGridView = Nothing
        Me.AccountVatDataGridViewTextBoxColumn.DataPropertyName = "AccountVat"
        Me.AccountVatDataGridViewTextBoxColumn.FilterPropertyName = ""
        Me.AccountVatDataGridViewTextBoxColumn.HeaderText = "PVM sąsk."
        Me.AccountVatDataGridViewTextBoxColumn.InstantBinding = True
        Me.AccountVatDataGridViewTextBoxColumn.Name = "AccountVatDataGridViewTextBoxColumn"
        Me.AccountVatDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AccountVatDataGridViewTextBoxColumn.ValueMember = ""
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Ammount"
        Me.DataGridViewTextBoxColumn6.DecimalLength = 4
        DataGridViewCellStyle2.Format = "##,0.0000"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn6.HeaderText = "Kiekis"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "UnitValue"
        Me.DataGridViewTextBoxColumn7.DecimalLength = 4
        DataGridViewCellStyle3.Format = "##,0.0000"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn7.HeaderText = "Vnt. Kaina"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Sum"
        DataGridViewCellStyle4.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn8.HeaderText = "Suma"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "SumCorrection"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Sumos kor."
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'VatRateDataGridViewTextBoxColumn
        '
        Me.VatRateDataGridViewTextBoxColumn.DataPropertyName = "VatRate"
        Me.VatRateDataGridViewTextBoxColumn.HeaderText = "PVM tarifas"
        Me.VatRateDataGridViewTextBoxColumn.Name = "VatRateDataGridViewTextBoxColumn"
        Me.VatRateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.VatRateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "SumVat"
        DataGridViewCellStyle5.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn11.HeaderText = "Suma PVM"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "SumVatCorrection"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Sumos PVM kor."
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'IncludeVatInObject
        '
        Me.IncludeVatInObject.DataPropertyName = "IncludeVatInObject"
        Me.IncludeVatInObject.HeaderText = "Įtraukti PVM į Objektą"
        Me.IncludeVatInObject.Name = "IncludeVatInObject"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "SumTotal"
        DataGridViewCellStyle6.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn13.HeaderText = "Suma Viso"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "UnitValueLTL"
        DataGridViewCellStyle7.Format = "##,0.0000"
        Me.DataGridViewTextBoxColumn14.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn14.HeaderText = "Vnt. Kaina LTL"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "UnitValueLTLCorrection"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Vnt. Kainos LTL kor."
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn15.Visible = False
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "SumLTL"
        DataGridViewCellStyle8.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn16.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn16.HeaderText = "Suma LTL"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Visible = False
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "SumLTLCorrection"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Sumos LTL kor."
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn17.Visible = False
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "SumVatLTL"
        DataGridViewCellStyle9.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn18.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn18.HeaderText = "Suma PVM LTL"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Visible = False
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "SumVatLTLCorrection"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Sumos PVM LTL kor."
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn19.Visible = False
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "SumTotalLTL"
        DataGridViewCellStyle10.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn20.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn20.HeaderText = "Suma Viso LTL"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Visible = False
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "AttachedObject"
        Me.DataGridViewTextBoxColumn21.HeaderText = "Susietas objektas"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.DataSource = Me.InvoiceReceivedBindingSource
        '
        'F_InvoiceReceived
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 552)
        Me.Controls.Add(Me.InvoiceItemsSortedDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_InvoiceReceived"
        Me.ShowInTaskbar = False
        Me.Text = "Gauta sąskaita faktūra"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.InvoiceReceivedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel10.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel11.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.InvoiceItemsSortedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceItemsSortedDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents InvoiceReceivedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AccountSupplierAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents CommentsInternalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CurrencyCodeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CurrencyRateAccTextBox As AccControls.AccTextBox
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SumAccTextBox As AccControls.AccTextBox
    Friend WithEvents SumLTLAccTextBox As AccControls.AccTextBox
    Friend WithEvents SumTotalAccTextBox As AccControls.AccTextBox
    Friend WithEvents SumTotalLTLAccTextBox As AccControls.AccTextBox
    Friend WithEvents SumVatAccTextBox As AccControls.AccTextBox
    Friend WithEvents SumVatLTLAccTextBox As AccControls.AccTextBox
    Friend WithEvents SupplierAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents DateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GetCurrencyRatesButton As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel10 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel11 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents AddAttachedObjectButton As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents InvoiceItemsSortedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceItemsSortedDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TypeHumanReadableComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents UpdateDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InsertDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CopyInvoiceButton As System.Windows.Forms.Button
    Friend WithEvents PasteInvoiceButton As System.Windows.Forms.Button
    Friend WithEvents NewButton As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountCostsDataGridViewTextBoxColumn As AccControls.DataGridViewAccGridComboBoxColumn
    Friend WithEvents AccountVatDataGridViewTextBoxColumn As AccControls.DataGridViewAccGridComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As AccControls.DataGridViewNumericUpDownColumn
    Friend WithEvents VatRateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As AccControls.DataGridViewNumericUpDownColumn
    Friend WithEvents IncludeVatInObject As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As AccControls.DataGridViewNumericUpDownColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As AccControls.DataGridViewNumericUpDownColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As AccControls.DataGridViewNumericUpDownColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LimitationsButton As System.Windows.Forms.Button
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents IndirectVatCostsAccountAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents ActualDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ActualDateIsApplicableCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents IndirectVatAccountAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents IndirectVatSumAccTextBox As AccControls.AccTextBox
    Friend WithEvents CalculateIndirectVatButton As System.Windows.Forms.Button
End Class
