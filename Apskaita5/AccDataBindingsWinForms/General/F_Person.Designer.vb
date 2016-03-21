<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_Person
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
        Dim AccountAgainstBankBuyerLabel As System.Windows.Forms.Label
        Dim AccountAgainstBankSupplyerLabel As System.Windows.Forms.Label
        Dim AddressLabel As System.Windows.Forms.Label
        Dim BankLabel As System.Windows.Forms.Label
        Dim BankAccountLabel As System.Windows.Forms.Label
        Dim CodeLabel As System.Windows.Forms.Label
        Dim CodeSODRALabel As System.Windows.Forms.Label
        Dim CodeVATLabel As System.Windows.Forms.Label
        Dim ContactInfoLabel As System.Windows.Forms.Label
        Dim EmailLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim InternalCodeLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim LanguageNameLabel As System.Windows.Forms.Label
        Dim CurrencyCodeLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_Person))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.FetchFromWebButton = New System.Windows.Forms.Button
        Me.CopyPersonButton = New System.Windows.Forms.Button
        Me.PastePersonButton = New System.Windows.Forms.Button
        Me.SavePersonFileButton = New System.Windows.Forms.Button
        Me.OpenPersonFileButton = New System.Windows.Forms.Button
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.IsClientCheckBox = New System.Windows.Forms.CheckBox
        Me.PersonBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IsWorkerCheckBox = New System.Windows.Forms.CheckBox
        Me.IsSupplierCheckBox = New System.Windows.Forms.CheckBox
        Me.CurrencyCodeComboBox = New System.Windows.Forms.ComboBox
        Me.LanguageNameComboBox = New System.Windows.Forms.ComboBox
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.AddressTextBox = New System.Windows.Forms.TextBox
        Me.BankTextBox = New System.Windows.Forms.TextBox
        Me.BankAccountTextBox = New System.Windows.Forms.TextBox
        Me.ContactInfoTextBox = New System.Windows.Forms.TextBox
        Me.EmailTextBox = New System.Windows.Forms.TextBox
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.CodeTextBox = New System.Windows.Forms.TextBox
        Me.CodeVATTextBox = New System.Windows.Forms.TextBox
        Me.CodeSODRATextBox = New System.Windows.Forms.TextBox
        Me.InternalCodeTextBox = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.AccountAgainstBankSupplyerAccGridComboBox = New AccControlsWinForms.AccListComboBox
        Me.AccountAgainstBankBuyerAccGridComboBox = New AccControlsWinForms.AccListComboBox
        Me.IsNaturalPersonCheckBox = New System.Windows.Forms.CheckBox
        Me.IsObsoleteCheckBox = New System.Windows.Forms.CheckBox
        Me.AssignedToGroupsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.AssignedToGroupsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        Me.ErrorWarnInfoProvider1 = New AccControlsWinForms.ErrorWarnInfoProvider(Me.components)
        AccountAgainstBankBuyerLabel = New System.Windows.Forms.Label
        AccountAgainstBankSupplyerLabel = New System.Windows.Forms.Label
        AddressLabel = New System.Windows.Forms.Label
        BankLabel = New System.Windows.Forms.Label
        BankAccountLabel = New System.Windows.Forms.Label
        CodeLabel = New System.Windows.Forms.Label
        CodeSODRALabel = New System.Windows.Forms.Label
        CodeVATLabel = New System.Windows.Forms.Label
        ContactInfoLabel = New System.Windows.Forms.Label
        EmailLabel = New System.Windows.Forms.Label
        IDLabel = New System.Windows.Forms.Label
        InternalCodeLabel = New System.Windows.Forms.Label
        NameLabel = New System.Windows.Forms.Label
        LanguageNameLabel = New System.Windows.Forms.Label
        CurrencyCodeLabel = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.PersonBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.AssignedToGroupsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssignedToGroupsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AccountAgainstBankBuyerLabel
        '
        AccountAgainstBankBuyerLabel.AutoSize = True
        AccountAgainstBankBuyerLabel.Dock = System.Windows.Forms.DockStyle.Fill
        AccountAgainstBankBuyerLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountAgainstBankBuyerLabel.Location = New System.Drawing.Point(3, 0)
        AccountAgainstBankBuyerLabel.Name = "AccountAgainstBankBuyerLabel"
        AccountAgainstBankBuyerLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        AccountAgainstBankBuyerLabel.Size = New System.Drawing.Size(74, 28)
        AccountAgainstBankBuyerLabel.TabIndex = 0
        AccountAgainstBankBuyerLabel.Text = "Pirkėjų:"
        AccountAgainstBankBuyerLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AccountAgainstBankSupplyerLabel
        '
        AccountAgainstBankSupplyerLabel.AutoSize = True
        AccountAgainstBankSupplyerLabel.Dock = System.Windows.Forms.DockStyle.Fill
        AccountAgainstBankSupplyerLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountAgainstBankSupplyerLabel.Location = New System.Drawing.Point(299, 0)
        AccountAgainstBankSupplyerLabel.Name = "AccountAgainstBankSupplyerLabel"
        AccountAgainstBankSupplyerLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        AccountAgainstBankSupplyerLabel.Size = New System.Drawing.Size(74, 28)
        AccountAgainstBankSupplyerLabel.TabIndex = 2
        AccountAgainstBankSupplyerLabel.Text = "Tiekėjų:"
        AccountAgainstBankSupplyerLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AddressLabel
        '
        AddressLabel.AutoSize = True
        AddressLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AddressLabel.Location = New System.Drawing.Point(43, 64)
        AddressLabel.Name = "AddressLabel"
        AddressLabel.Size = New System.Drawing.Size(56, 13)
        AddressLabel.TabIndex = 4
        AddressLabel.Text = "Adresas:"
        '
        'BankLabel
        '
        BankLabel.AutoSize = True
        BankLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BankLabel.Location = New System.Drawing.Point(50, 194)
        BankLabel.Name = "BankLabel"
        BankLabel.Size = New System.Drawing.Size(53, 13)
        BankLabel.TabIndex = 6
        BankLabel.Text = "Bankas:"
        '
        'BankAccountLabel
        '
        BankAccountLabel.AutoSize = True
        BankAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BankAccountLabel.Location = New System.Drawing.Point(5, 167)
        BankAccountLabel.Name = "BankAccountLabel"
        BankAccountLabel.Size = New System.Drawing.Size(98, 13)
        BankAccountLabel.TabIndex = 8
        BankAccountLabel.Text = "Banko sąskaita:"
        '
        'CodeLabel
        '
        CodeLabel.AutoSize = True
        CodeLabel.Dock = System.Windows.Forms.DockStyle.Fill
        CodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CodeLabel.Location = New System.Drawing.Point(3, 0)
        CodeLabel.Name = "CodeLabel"
        CodeLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        CodeLabel.Size = New System.Drawing.Size(111, 25)
        CodeLabel.TabIndex = 10
        CodeLabel.Text = "Įmonės/asmens:"
        CodeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CodeSODRALabel
        '
        CodeSODRALabel.AutoSize = True
        CodeSODRALabel.Dock = System.Windows.Forms.DockStyle.Fill
        CodeSODRALabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CodeSODRALabel.Location = New System.Drawing.Point(3, 25)
        CodeSODRALabel.Name = "CodeSODRALabel"
        CodeSODRALabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        CodeSODRALabel.Size = New System.Drawing.Size(111, 25)
        CodeSODRALabel.TabIndex = 12
        CodeSODRALabel.Text = "Darbuot. SODRA:"
        CodeSODRALabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CodeVATLabel
        '
        CodeVATLabel.AutoSize = True
        CodeVATLabel.Dock = System.Windows.Forms.DockStyle.Fill
        CodeVATLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CodeVATLabel.Location = New System.Drawing.Point(305, 0)
        CodeVATLabel.Name = "CodeVATLabel"
        CodeVATLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        CodeVATLabel.Size = New System.Drawing.Size(100, 25)
        CodeVATLabel.TabIndex = 14
        CodeVATLabel.Text = "PVM mokėtojo:"
        CodeVATLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ContactInfoLabel
        '
        ContactInfoLabel.AutoSize = True
        ContactInfoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContactInfoLabel.Location = New System.Drawing.Point(6, 220)
        ContactInfoLabel.Name = "ContactInfoLabel"
        ContactInfoLabel.Size = New System.Drawing.Size(97, 13)
        ContactInfoLabel.TabIndex = 16
        ContactInfoLabel.Text = "Kontaktinė info:"
        '
        'EmailLabel
        '
        EmailLabel.AutoSize = True
        EmailLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EmailLabel.Location = New System.Drawing.Point(43, 246)
        EmailLabel.Name = "EmailLabel"
        EmailLabel.Size = New System.Drawing.Size(60, 13)
        EmailLabel.TabIndex = 18
        EmailLabel.Text = "E-paštas:"
        '
        'IDLabel
        '
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(79, 12)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(24, 13)
        IDLabel.TabIndex = 20
        IDLabel.Text = "ID:"
        '
        'InternalCodeLabel
        '
        InternalCodeLabel.AutoSize = True
        InternalCodeLabel.Dock = System.Windows.Forms.DockStyle.Fill
        InternalCodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        InternalCodeLabel.Location = New System.Drawing.Point(305, 25)
        InternalCodeLabel.Name = "InternalCodeLabel"
        InternalCodeLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        InternalCodeLabel.Size = New System.Drawing.Size(100, 25)
        InternalCodeLabel.TabIndex = 22
        InternalCodeLabel.Text = "Įmonės vidinis:"
        InternalCodeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'NameLabel
        '
        NameLabel.AutoSize = True
        NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameLabel.Location = New System.Drawing.Point(21, 38)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(82, 13)
        NameLabel.TabIndex = 32
        NameLabel.Text = "Pavadinimas:"
        '
        'LanguageNameLabel
        '
        LanguageNameLabel.AutoSize = True
        LanguageNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LanguageNameLabel.Location = New System.Drawing.Point(60, 272)
        LanguageNameLabel.Name = "LanguageNameLabel"
        LanguageNameLabel.Size = New System.Drawing.Size(43, 13)
        LanguageNameLabel.TabIndex = 35
        LanguageNameLabel.Text = "Kalba:"
        '
        'CurrencyCodeLabel
        '
        CurrencyCodeLabel.AutoSize = True
        CurrencyCodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyCodeLabel.Location = New System.Drawing.Point(425, 272)
        CurrencyCodeLabel.Name = "CurrencyCodeLabel"
        CurrencyCodeLabel.Size = New System.Drawing.Size(50, 13)
        CurrencyCodeLabel.TabIndex = 36
        CurrencyCodeLabel.Text = "Valiuta:"
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel2.Controls.Add(Me.ICancelButton)
        Me.Panel2.Controls.Add(Me.IOkButton)
        Me.Panel2.Controls.Add(Me.IApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 393)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(885, 37)
        Me.Panel2.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 9
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.Controls.Add(Me.FetchFromWebButton, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.CopyPersonButton, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.PastePersonButton, 4, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.SavePersonFileButton, 8, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.OpenPersonFileButton, 6, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(10, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(217, 31)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'FetchFromWebButton
        '
        Me.FetchFromWebButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FetchFromWebButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Web_Database_icon_24p
        Me.FetchFromWebButton.Location = New System.Drawing.Point(0, 0)
        Me.FetchFromWebButton.Margin = New System.Windows.Forms.Padding(0)
        Me.FetchFromWebButton.Name = "FetchFromWebButton"
        Me.FetchFromWebButton.Size = New System.Drawing.Size(32, 30)
        Me.FetchFromWebButton.TabIndex = 0
        Me.FetchFromWebButton.UseVisualStyleBackColor = True
        '
        'CopyPersonButton
        '
        Me.CopyPersonButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyPersonButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Actions_edit_copy_icon_16p
        Me.CopyPersonButton.Location = New System.Drawing.Point(47, 0)
        Me.CopyPersonButton.Margin = New System.Windows.Forms.Padding(0)
        Me.CopyPersonButton.Name = "CopyPersonButton"
        Me.CopyPersonButton.Size = New System.Drawing.Size(30, 29)
        Me.CopyPersonButton.TabIndex = 1
        Me.CopyPersonButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CopyPersonButton.UseVisualStyleBackColor = True
        '
        'PastePersonButton
        '
        Me.PastePersonButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PastePersonButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Paste_icon_16p
        Me.PastePersonButton.Location = New System.Drawing.Point(92, 0)
        Me.PastePersonButton.Margin = New System.Windows.Forms.Padding(0)
        Me.PastePersonButton.Name = "PastePersonButton"
        Me.PastePersonButton.Size = New System.Drawing.Size(30, 29)
        Me.PastePersonButton.TabIndex = 2
        Me.PastePersonButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.PastePersonButton.UseVisualStyleBackColor = True
        '
        'SavePersonFileButton
        '
        Me.SavePersonFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SavePersonFileButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Actions_document_save_icon_16p
        Me.SavePersonFileButton.Location = New System.Drawing.Point(182, 0)
        Me.SavePersonFileButton.Margin = New System.Windows.Forms.Padding(0)
        Me.SavePersonFileButton.Name = "SavePersonFileButton"
        Me.SavePersonFileButton.Size = New System.Drawing.Size(30, 29)
        Me.SavePersonFileButton.TabIndex = 4
        Me.SavePersonFileButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.SavePersonFileButton.UseVisualStyleBackColor = True
        '
        'OpenPersonFileButton
        '
        Me.OpenPersonFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenPersonFileButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.folder_open_icon_16p
        Me.OpenPersonFileButton.Location = New System.Drawing.Point(137, 0)
        Me.OpenPersonFileButton.Margin = New System.Windows.Forms.Padding(0)
        Me.OpenPersonFileButton.Name = "OpenPersonFileButton"
        Me.OpenPersonFileButton.Size = New System.Drawing.Size(30, 29)
        Me.OpenPersonFileButton.TabIndex = 3
        Me.OpenPersonFileButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.OpenPersonFileButton.UseVisualStyleBackColor = True
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(784, 6)
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
        Me.IOkButton.Location = New System.Drawing.Point(578, 6)
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
        Me.IApplyButton.Location = New System.Drawing.Point(682, 6)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(89, 23)
        Me.IApplyButton.TabIndex = 2
        Me.IApplyButton.Text = "Išsaugoti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel3)
        Me.SplitContainer1.Panel1.Controls.Add(CurrencyCodeLabel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CurrencyCodeComboBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LanguageNameComboBox)
        Me.SplitContainer1.Panel1.Controls.Add(LanguageNameLabel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.NameTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.AddressTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BankTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BankAccountTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ContactInfoTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.EmailTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.IDTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(AddressLabel)
        Me.SplitContainer1.Panel1.Controls.Add(BankLabel)
        Me.SplitContainer1.Panel1.Controls.Add(BankAccountLabel)
        Me.SplitContainer1.Panel1.Controls.Add(ContactInfoLabel)
        Me.SplitContainer1.Panel1.Controls.Add(EmailLabel)
        Me.SplitContainer1.Panel1.Controls.Add(IDLabel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.IsNaturalPersonCheckBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.IsObsoleteCheckBox)
        Me.SplitContainer1.Panel1.Controls.Add(NameLabel)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.AssignedToGroupsDataGridView)
        Me.SplitContainer1.Size = New System.Drawing.Size(885, 393)
        Me.SplitContainer1.SplitterDistance = 633
        Me.SplitContainer1.TabIndex = 0
        Me.SplitContainer1.TabStop = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 7
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.Controls.Add(Me.IsClientCheckBox, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.IsWorkerCheckBox, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.IsSupplierCheckBox, 2, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(10, 349)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(620, 30)
        Me.TableLayoutPanel3.TabIndex = 12
        '
        'IsClientCheckBox
        '
        Me.IsClientCheckBox.AutoSize = True
        Me.IsClientCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.PersonBindingSource, "IsClient", True))
        Me.IsClientCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsClientCheckBox.Location = New System.Drawing.Point(3, 3)
        Me.IsClientCheckBox.Name = "IsClientCheckBox"
        Me.IsClientCheckBox.Size = New System.Drawing.Size(71, 17)
        Me.IsClientCheckBox.TabIndex = 0
        Me.IsClientCheckBox.Text = "Pirkėjas"
        '
        'PersonBindingSource
        '
        Me.PersonBindingSource.DataSource = GetType(ApskaitaObjects.General.Person)
        '
        'IsWorkerCheckBox
        '
        Me.IsWorkerCheckBox.AutoSize = True
        Me.IsWorkerCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.PersonBindingSource, "IsWorker", True))
        Me.IsWorkerCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsWorkerCheckBox.Location = New System.Drawing.Point(200, 3)
        Me.IsWorkerCheckBox.Name = "IsWorkerCheckBox"
        Me.IsWorkerCheckBox.Size = New System.Drawing.Size(94, 17)
        Me.IsWorkerCheckBox.TabIndex = 2
        Me.IsWorkerCheckBox.Text = "Darbuotojas"
        '
        'IsSupplierCheckBox
        '
        Me.IsSupplierCheckBox.AutoSize = True
        Me.IsSupplierCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.PersonBindingSource, "IsSupplier", True))
        Me.IsSupplierCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsSupplierCheckBox.Location = New System.Drawing.Point(100, 3)
        Me.IsSupplierCheckBox.Name = "IsSupplierCheckBox"
        Me.IsSupplierCheckBox.Size = New System.Drawing.Size(74, 17)
        Me.IsSupplierCheckBox.TabIndex = 1
        Me.IsSupplierCheckBox.Text = "Tiekėjas"
        '
        'CurrencyCodeComboBox
        '
        Me.CurrencyCodeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonBindingSource, "CurrencyCode", True))
        Me.CurrencyCodeComboBox.FormattingEnabled = True
        Me.CurrencyCodeComboBox.Location = New System.Drawing.Point(481, 269)
        Me.CurrencyCodeComboBox.Name = "CurrencyCodeComboBox"
        Me.CurrencyCodeComboBox.Size = New System.Drawing.Size(121, 21)
        Me.CurrencyCodeComboBox.TabIndex = 10
        '
        'LanguageNameComboBox
        '
        Me.LanguageNameComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonBindingSource, "LanguageName", True))
        Me.LanguageNameComboBox.FormattingEnabled = True
        Me.LanguageNameComboBox.Location = New System.Drawing.Point(101, 269)
        Me.LanguageNameComboBox.Name = "LanguageNameComboBox"
        Me.LanguageNameComboBox.Size = New System.Drawing.Size(296, 21)
        Me.LanguageNameComboBox.TabIndex = 9
        '
        'NameTextBox
        '
        Me.NameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonBindingSource, "Name", True))
        Me.NameTextBox.Location = New System.Drawing.Point(101, 35)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(504, 20)
        Me.NameTextBox.TabIndex = 2
        '
        'AddressTextBox
        '
        Me.AddressTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddressTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonBindingSource, "Address", True))
        Me.AddressTextBox.Location = New System.Drawing.Point(101, 61)
        Me.AddressTextBox.Name = "AddressTextBox"
        Me.AddressTextBox.Size = New System.Drawing.Size(504, 20)
        Me.AddressTextBox.TabIndex = 3
        '
        'BankTextBox
        '
        Me.BankTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BankTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonBindingSource, "Bank", True))
        Me.BankTextBox.Location = New System.Drawing.Point(101, 191)
        Me.BankTextBox.Name = "BankTextBox"
        Me.BankTextBox.Size = New System.Drawing.Size(504, 20)
        Me.BankTextBox.TabIndex = 6
        '
        'BankAccountTextBox
        '
        Me.BankAccountTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BankAccountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonBindingSource, "BankAccount", True))
        Me.BankAccountTextBox.Location = New System.Drawing.Point(101, 164)
        Me.BankAccountTextBox.Name = "BankAccountTextBox"
        Me.BankAccountTextBox.Size = New System.Drawing.Size(504, 20)
        Me.BankAccountTextBox.TabIndex = 5
        '
        'ContactInfoTextBox
        '
        Me.ContactInfoTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContactInfoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonBindingSource, "ContactInfo", True))
        Me.ContactInfoTextBox.Location = New System.Drawing.Point(101, 217)
        Me.ContactInfoTextBox.Name = "ContactInfoTextBox"
        Me.ContactInfoTextBox.Size = New System.Drawing.Size(504, 20)
        Me.ContactInfoTextBox.TabIndex = 7
        '
        'EmailTextBox
        '
        Me.EmailTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonBindingSource, "Email", True))
        Me.EmailTextBox.Location = New System.Drawing.Point(101, 243)
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.Size = New System.Drawing.Size(504, 20)
        Me.EmailTextBox.TabIndex = 8
        '
        'IDTextBox
        '
        Me.IDTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonBindingSource, "ID", True))
        Me.IDTextBox.Location = New System.Drawing.Point(100, 9)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(168, 20)
        Me.IDTextBox.TabIndex = 21
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 87)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(598, 69)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Kodai"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.39154!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.60846!))
        Me.TableLayoutPanel1.Controls.Add(CodeLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CodeTextBox, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(CodeVATLabel, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CodeVATTextBox, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CodeSODRATextBox, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(CodeSODRALabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(InternalCodeLabel, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.InternalCodeTextBox, 3, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(592, 50)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'CodeTextBox
        '
        Me.CodeTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonBindingSource, "Code", True))
        Me.CodeTextBox.Location = New System.Drawing.Point(120, 3)
        Me.CodeTextBox.Name = "CodeTextBox"
        Me.CodeTextBox.Size = New System.Drawing.Size(179, 20)
        Me.CodeTextBox.TabIndex = 0
        '
        'CodeVATTextBox
        '
        Me.CodeVATTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonBindingSource, "CodeVAT", True))
        Me.CodeVATTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CodeVATTextBox.Location = New System.Drawing.Point(411, 3)
        Me.CodeVATTextBox.Name = "CodeVATTextBox"
        Me.CodeVATTextBox.Size = New System.Drawing.Size(178, 20)
        Me.CodeVATTextBox.TabIndex = 1
        '
        'CodeSODRATextBox
        '
        Me.CodeSODRATextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CodeSODRATextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonBindingSource, "CodeSODRA", True))
        Me.CodeSODRATextBox.Location = New System.Drawing.Point(120, 28)
        Me.CodeSODRATextBox.Name = "CodeSODRATextBox"
        Me.CodeSODRATextBox.Size = New System.Drawing.Size(179, 20)
        Me.CodeSODRATextBox.TabIndex = 2
        '
        'InternalCodeTextBox
        '
        Me.InternalCodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PersonBindingSource, "InternalCode", True))
        Me.InternalCodeTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InternalCodeTextBox.Location = New System.Drawing.Point(411, 28)
        Me.InternalCodeTextBox.Name = "InternalCodeTextBox"
        Me.InternalCodeTextBox.Size = New System.Drawing.Size(178, 20)
        Me.InternalCodeTextBox.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 296)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(598, 47)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Koresponduojančio banko operacijų sąsk."
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.AccountAgainstBankSupplyerAccGridComboBox, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.AccountAgainstBankBuyerAccGridComboBox, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(AccountAgainstBankBuyerLabel, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(AccountAgainstBankSupplyerLabel, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(592, 28)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'AccountAgainstBankSupplyerAccGridComboBox
        '
        Me.AccountAgainstBankSupplyerAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PersonBindingSource, "AccountAgainstBankSupplyer", True))
        Me.AccountAgainstBankSupplyerAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountAgainstBankSupplyerAccGridComboBox.EmptyValueString = ""
        Me.AccountAgainstBankSupplyerAccGridComboBox.FilterString = ""
        Me.AccountAgainstBankSupplyerAccGridComboBox.FormattingEnabled = True
        Me.AccountAgainstBankSupplyerAccGridComboBox.InstantBinding = True
        Me.AccountAgainstBankSupplyerAccGridComboBox.Location = New System.Drawing.Point(379, 3)
        Me.AccountAgainstBankSupplyerAccGridComboBox.Name = "AccountAgainstBankSupplyerAccGridComboBox"
        Me.AccountAgainstBankSupplyerAccGridComboBox.Size = New System.Drawing.Size(210, 21)
        Me.AccountAgainstBankSupplyerAccGridComboBox.TabIndex = 1
        '
        'AccountAgainstBankBuyerAccGridComboBox
        '
        Me.AccountAgainstBankBuyerAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PersonBindingSource, "AccountAgainstBankBuyer", True))
        Me.AccountAgainstBankBuyerAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountAgainstBankBuyerAccGridComboBox.EmptyValueString = ""
        Me.AccountAgainstBankBuyerAccGridComboBox.FilterString = ""
        Me.AccountAgainstBankBuyerAccGridComboBox.FormattingEnabled = True
        Me.AccountAgainstBankBuyerAccGridComboBox.InstantBinding = True
        Me.AccountAgainstBankBuyerAccGridComboBox.Location = New System.Drawing.Point(83, 3)
        Me.AccountAgainstBankBuyerAccGridComboBox.Name = "AccountAgainstBankBuyerAccGridComboBox"
        Me.AccountAgainstBankBuyerAccGridComboBox.Size = New System.Drawing.Size(210, 21)
        Me.AccountAgainstBankBuyerAccGridComboBox.TabIndex = 0
        '
        'IsNaturalPersonCheckBox
        '
        Me.IsNaturalPersonCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IsNaturalPersonCheckBox.AutoSize = True
        Me.IsNaturalPersonCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.PersonBindingSource, "IsNaturalPerson", True))
        Me.IsNaturalPersonCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsNaturalPersonCheckBox.Location = New System.Drawing.Point(333, 11)
        Me.IsNaturalPersonCheckBox.Name = "IsNaturalPersonCheckBox"
        Me.IsNaturalPersonCheckBox.Size = New System.Drawing.Size(101, 17)
        Me.IsNaturalPersonCheckBox.TabIndex = 0
        Me.IsNaturalPersonCheckBox.Text = "Fizinis asmuo"
        '
        'IsObsoleteCheckBox
        '
        Me.IsObsoleteCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IsObsoleteCheckBox.AutoSize = True
        Me.IsObsoleteCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.PersonBindingSource, "IsObsolete", True))
        Me.IsObsoleteCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsObsoleteCheckBox.Location = New System.Drawing.Point(460, 11)
        Me.IsObsoleteCheckBox.Name = "IsObsoleteCheckBox"
        Me.IsObsoleteCheckBox.Size = New System.Drawing.Size(123, 17)
        Me.IsObsoleteCheckBox.TabIndex = 1
        Me.IsObsoleteCheckBox.Text = "Nebenaudojamas"
        '
        'AssignedToGroupsDataGridView
        '
        Me.AssignedToGroupsDataGridView.AllowUserToAddRows = False
        Me.AssignedToGroupsDataGridView.AllowUserToDeleteRows = False
        Me.AssignedToGroupsDataGridView.AutoGenerateColumns = False
        Me.AssignedToGroupsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.AssignedToGroupsDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.AssignedToGroupsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AssignedToGroupsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.AssignedToGroupsDataGridView.ColumnHeadersVisible = False
        Me.AssignedToGroupsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewCheckBoxColumn1})
        Me.AssignedToGroupsDataGridView.DataSource = Me.AssignedToGroupsBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AssignedToGroupsDataGridView.DefaultCellStyle = DataGridViewCellStyle1
        Me.AssignedToGroupsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AssignedToGroupsDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.AssignedToGroupsDataGridView.MultiSelect = False
        Me.AssignedToGroupsDataGridView.Name = "AssignedToGroupsDataGridView"
        Me.AssignedToGroupsDataGridView.RowHeadersVisible = False
        Me.AssignedToGroupsDataGridView.Size = New System.Drawing.Size(248, 393)
        Me.AssignedToGroupsDataGridView.TabIndex = 0
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Name"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 5
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "IsAssigned"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "IsAssigned"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 5
        '
        'AssignedToGroupsBindingSource
        '
        Me.AssignedToGroupsBindingSource.DataMember = "AssignedToGroups"
        Me.AssignedToGroupsBindingSource.DataSource = Me.PersonBindingSource
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(150, 32)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(188, 83)
        Me.ProgressFiller1.TabIndex = 2
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(349, 32)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(190, 83)
        Me.ProgressFiller2.TabIndex = 3
        Me.ProgressFiller2.Visible = False
        '
        'ErrorWarnInfoProvider1
        '
        Me.ErrorWarnInfoProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleInformation = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleWarning = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.ContainerControl = Me
        Me.ErrorWarnInfoProvider1.DataSource = Me.PersonBindingSource
        '
        'F_Person
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 430)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_Person"
        Me.Text = "Kontrahento duomenys"
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.PersonBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.AssignedToGroupsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssignedToGroupsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents PersonBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BankTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BankAccountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodeSODRATextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodeVATTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ContactInfoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InternalCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IsNaturalPersonCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents IsObsoleteCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents AssignedToGroupsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents AssignedToGroupsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FetchFromWebButton As System.Windows.Forms.Button
    Friend WithEvents CurrencyCodeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents LanguageNameComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents AccountAgainstBankSupplyerAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents AccountAgainstBankBuyerAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents IsWorkerCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents IsSupplierCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents IsClientCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CopyPersonButton As System.Windows.Forms.Button
    Friend WithEvents PastePersonButton As System.Windows.Forms.Button
    Friend WithEvents OpenPersonFileButton As System.Windows.Forms.Button
    Friend WithEvents SavePersonFileButton As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ErrorWarnInfoProvider1 As AccControlsWinForms.ErrorWarnInfoProvider
End Class
