<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_PayOutNaturalPerson
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
        Dim CodeSODRALabel As System.Windows.Forms.Label
        Dim CodeVMILabel As System.Windows.Forms.Label
        Dim ContentLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim DocNumberLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim JournalEntryIDLabel As System.Windows.Forms.Label
        Dim PersonCodeSODRALabel As System.Windows.Forms.Label
        Dim PersonInfoLabel As System.Windows.Forms.Label
        Dim RateGPMLabel As System.Windows.Forms.Label
        Dim SODRABaseLabel As System.Windows.Forms.Label
        Dim SumBrutoLabel As System.Windows.Forms.Label
        Dim SumNetoLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_PayOutNaturalPerson))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.SODRABaseAccTextBox = New AccControls.AccTextBox
        Me.PayOutNaturalPersonBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CodeVMIMTGCComboBox = New AccControls.MTGCComboBox
        Me.CodeSODRAMTGCComboBox = New AccControls.MTGCComboBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.ContributionSODRAAccTextBox = New AccControls.AccTextBox
        Me.DeductionGPMAccTextBox = New AccControls.AccTextBox
        Me.DeductionPSDAccTextBox = New AccControls.AccTextBox
        Me.RateGPMComboBox = New System.Windows.Forms.ComboBox
        Me.DeductionSODRAAccTextBox = New AccControls.AccTextBox
        Me.RatePSDForCompanyComboBox = New System.Windows.Forms.ComboBox
        Me.TotalPSDAccTextBox = New AccControls.AccTextBox
        Me.TotalSODRAAccTextBox = New AccControls.AccTextBox
        Me.RateSODRAForCompanyComboBox = New System.Windows.Forms.ComboBox
        Me.RatePSDForPersonComboBox = New System.Windows.Forms.ComboBox
        Me.RateSODRAForPersonComboBox = New System.Windows.Forms.ComboBox
        Me.ContributionPSDAccTextBox = New AccControls.AccTextBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LoadJournalEntryButton = New System.Windows.Forms.Button
        Me.RefreshJournalEntryListButton = New System.Windows.Forms.Button
        Me.JournalEntryListComboBox = New System.Windows.Forms.ComboBox
        Me.JournalEntryListDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button
        Me.JournalEntryIDTextBox = New System.Windows.Forms.TextBox
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.DocNumberTextBox = New System.Windows.Forms.TextBox
        Me.ContentTextBox = New System.Windows.Forms.TextBox
        Me.PersonInfoTextBox = New System.Windows.Forms.TextBox
        Me.SumNetoAccTextBox = New AccControls.AccTextBox
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.PersonCodeSODRATextBox = New System.Windows.Forms.TextBox
        Me.SumBrutoAccTextBox = New AccControls.AccTextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CodeSODRALabel = New System.Windows.Forms.Label
        CodeVMILabel = New System.Windows.Forms.Label
        ContentLabel = New System.Windows.Forms.Label
        DateLabel = New System.Windows.Forms.Label
        DocNumberLabel = New System.Windows.Forms.Label
        IDLabel = New System.Windows.Forms.Label
        JournalEntryIDLabel = New System.Windows.Forms.Label
        PersonCodeSODRALabel = New System.Windows.Forms.Label
        PersonInfoLabel = New System.Windows.Forms.Label
        RateGPMLabel = New System.Windows.Forms.Label
        SODRABaseLabel = New System.Windows.Forms.Label
        SumBrutoLabel = New System.Windows.Forms.Label
        SumNetoLabel = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Label9 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.PayOutNaturalPersonBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CodeSODRALabel
        '
        CodeSODRALabel.AutoSize = True
        CodeSODRALabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CodeSODRALabel.Location = New System.Drawing.Point(251, 217)
        CodeSODRALabel.Name = "CodeSODRALabel"
        CodeSODRALabel.Size = New System.Drawing.Size(144, 13)
        CodeSODRALabel.TabIndex = 0
        CodeSODRALabel.Text = "SODROS deklar. kodas:"
        '
        'CodeVMILabel
        '
        CodeVMILabel.AutoSize = True
        CodeVMILabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CodeVMILabel.Location = New System.Drawing.Point(576, 217)
        CodeVMILabel.Name = "CodeVMILabel"
        CodeVMILabel.Size = New System.Drawing.Size(114, 13)
        CodeVMILabel.TabIndex = 2
        CodeVMILabel.Text = "VMI deklar. kodas:"
        '
        'ContentLabel
        '
        ContentLabel.AutoSize = True
        ContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContentLabel.Location = New System.Drawing.Point(24, 100)
        ContentLabel.Name = "ContentLabel"
        ContentLabel.Size = New System.Drawing.Size(52, 13)
        ContentLabel.TabIndex = 4
        ContentLabel.Text = "Turinys:"
        '
        'DateLabel
        '
        DateLabel.AutoSize = True
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(288, 22)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(38, 13)
        DateLabel.TabIndex = 10
        DateLabel.Text = "Data:"
        '
        'DocNumberLabel
        '
        DocNumberLabel.AutoSize = True
        DocNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DocNumberLabel.Location = New System.Drawing.Point(17, 48)
        DocNumberLabel.Name = "DocNumberLabel"
        DocNumberLabel.Size = New System.Drawing.Size(59, 13)
        DocNumberLabel.TabIndex = 18
        DocNumberLabel.Text = "Dok. Nr.:"
        '
        'IDLabel
        '
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(81, 14)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(24, 13)
        IDLabel.TabIndex = 20
        IDLabel.Text = "ID:"
        '
        'JournalEntryIDLabel
        '
        JournalEntryIDLabel.AutoSize = True
        JournalEntryIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        JournalEntryIDLabel.Location = New System.Drawing.Point(32, 22)
        JournalEntryIDLabel.Name = "JournalEntryIDLabel"
        JournalEntryIDLabel.Size = New System.Drawing.Size(44, 13)
        JournalEntryIDLabel.TabIndex = 24
        JournalEntryIDLabel.Text = "BŽ ID:"
        '
        'PersonCodeSODRALabel
        '
        PersonCodeSODRALabel.AutoSize = True
        PersonCodeSODRALabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PersonCodeSODRALabel.Location = New System.Drawing.Point(263, 244)
        PersonCodeSODRALabel.Name = "PersonCodeSODRALabel"
        PersonCodeSODRALabel.Size = New System.Drawing.Size(132, 13)
        PersonCodeSODRALabel.TabIndex = 26
        PersonCodeSODRALabel.Text = "Asm. SODROS kodas:"
        '
        'PersonInfoLabel
        '
        PersonInfoLabel.AutoSize = True
        PersonInfoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PersonInfoLabel.Location = New System.Drawing.Point(28, 74)
        PersonInfoLabel.Name = "PersonInfoLabel"
        PersonInfoLabel.Size = New System.Drawing.Size(48, 13)
        PersonInfoLabel.TabIndex = 28
        PersonInfoLabel.Text = "Asmuo:"
        '
        'RateGPMLabel
        '
        RateGPMLabel.Dock = System.Windows.Forms.DockStyle.Fill
        RateGPMLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        RateGPMLabel.Location = New System.Drawing.Point(115, 20)
        RateGPMLabel.Name = "RateGPMLabel"
        RateGPMLabel.Size = New System.Drawing.Size(83, 30)
        RateGPMLabel.TabIndex = 30
        RateGPMLabel.Text = "Tarifas:"
        RateGPMLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SODRABaseLabel
        '
        SODRABaseLabel.Dock = System.Windows.Forms.DockStyle.Fill
        SODRABaseLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SODRABaseLabel.Location = New System.Drawing.Point(115, 90)
        SODRABaseLabel.Name = "SODRABaseLabel"
        SODRABaseLabel.Size = New System.Drawing.Size(83, 30)
        SODRABaseLabel.TabIndex = 40
        SODRABaseLabel.Text = "Tarifas:"
        SODRABaseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SumBrutoLabel
        '
        SumBrutoLabel.AutoSize = True
        SumBrutoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumBrutoLabel.Location = New System.Drawing.Point(9, 244)
        SumBrutoLabel.Name = "SumBrutoLabel"
        SumBrutoLabel.Size = New System.Drawing.Size(97, 13)
        SumBrutoLabel.TabIndex = 42
        SumBrutoLabel.Text = "Suma popierius:"
        '
        'SumNetoLabel
        '
        SumNetoLabel.AutoSize = True
        SumNetoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumNetoLabel.Location = New System.Drawing.Point(528, 22)
        SumNetoLabel.Name = "SumNetoLabel"
        SumNetoLabel.Size = New System.Drawing.Size(96, 13)
        SumNetoLabel.TabIndex = 44
        SumNetoLabel.Text = "Suma išmokėta:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(3, 20)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(97, 13)
        Label1.TabIndex = 52
        Label1.Text = "IŠSKAIČIUOTA:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(3, 90)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(106, 13)
        Label2.TabIndex = 53
        Label2.Text = "PRISKAIČIUOTA:"
        '
        'Label3
        '
        Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(115, 50)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(83, 30)
        Label3.TabIndex = 54
        Label3.Text = "Suma:"
        Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label4.Location = New System.Drawing.Point(115, 120)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(83, 30)
        Label4.TabIndex = 55
        Label4.Text = "Suma:"
        Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label5.Location = New System.Drawing.Point(115, 160)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(83, 31)
        Label5.TabIndex = 56
        Label5.Text = "Suma viso:"
        Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(204, 0)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(188, 20)
        Label6.TabIndex = 55
        Label6.Text = "GPM:"
        Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label7
        '
        Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.Location = New System.Drawing.Point(418, 0)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(188, 20)
        Label7.TabIndex = 57
        Label7.Text = "PSD"
        Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label8
        '
        Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label8.Location = New System.Drawing.Point(632, 0)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(188, 20)
        Label8.TabIndex = 55
        Label8.Text = "SODRA"
        Label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label9.Location = New System.Drawing.Point(12, 217)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(94, 13)
        Label9.TabIndex = 55
        Label9.Text = "SODROS bazė:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SODRABaseAccTextBox)
        Me.Panel1.Controls.Add(Me.CodeVMIMTGCComboBox)
        Me.Panel1.Controls.Add(Me.CodeSODRAMTGCComboBox)
        Me.Panel1.Controls.Add(Label9)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(CodeSODRALabel)
        Me.Panel1.Controls.Add(CodeVMILabel)
        Me.Panel1.Controls.Add(IDLabel)
        Me.Panel1.Controls.Add(Me.IDTextBox)
        Me.Panel1.Controls.Add(PersonCodeSODRALabel)
        Me.Panel1.Controls.Add(Me.PersonCodeSODRATextBox)
        Me.Panel1.Controls.Add(SumBrutoLabel)
        Me.Panel1.Controls.Add(Me.SumBrutoAccTextBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(886, 478)
        Me.Panel1.TabIndex = 0
        '
        'SODRABaseAccTextBox
        '
        Me.SODRABaseAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.PayOutNaturalPersonBindingSource, "SODRABase", True))
        Me.SODRABaseAccTextBox.DecimalLength = 0
        Me.SODRABaseAccTextBox.Location = New System.Drawing.Point(112, 214)
        Me.SODRABaseAccTextBox.Name = "SODRABaseAccTextBox"
        Me.SODRABaseAccTextBox.NegativeValue = False
        Me.SODRABaseAccTextBox.Size = New System.Drawing.Size(114, 20)
        Me.SODRABaseAccTextBox.SupressFormating = True
        Me.SODRABaseAccTextBox.TabIndex = 2
        Me.SODRABaseAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PayOutNaturalPersonBindingSource
        '
        Me.PayOutNaturalPersonBindingSource.DataSource = GetType(ApskaitaObjects.Workers.PayOutNaturalPerson)
        '
        'CodeVMIMTGCComboBox
        '
        Me.CodeVMIMTGCComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CodeVMIMTGCComboBox.BorderStyle = AccControls.MTGCComboBox.TipiBordi.Fixed3D
        Me.CodeVMIMTGCComboBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CodeVMIMTGCComboBox.ColumnNum = 1
        Me.CodeVMIMTGCComboBox.ColumnWidth = "121"
        Me.CodeVMIMTGCComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PayOutNaturalPersonBindingSource, "CodeVMI", True))
        Me.CodeVMIMTGCComboBox.DisplayMember = "Text"
        Me.CodeVMIMTGCComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CodeVMIMTGCComboBox.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.CodeVMIMTGCComboBox.DropDownForeColor = System.Drawing.Color.Black
        Me.CodeVMIMTGCComboBox.DropDownStyle = AccControls.MTGCComboBox.CustomDropDownStyle.DropDown
        Me.CodeVMIMTGCComboBox.DropDownWidth = 141
        Me.CodeVMIMTGCComboBox.FormattingEnabled = True
        Me.CodeVMIMTGCComboBox.GridLineColor = System.Drawing.Color.LightGray
        Me.CodeVMIMTGCComboBox.GridLineHorizontal = False
        Me.CodeVMIMTGCComboBox.GridLineVertical = False
        Me.CodeVMIMTGCComboBox.LoadingType = AccControls.MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.CodeVMIMTGCComboBox.Location = New System.Drawing.Point(696, 214)
        Me.CodeVMIMTGCComboBox.ManagingFastMouseMoving = True
        Me.CodeVMIMTGCComboBox.ManagingFastMouseMovingInterval = 30
        Me.CodeVMIMTGCComboBox.Name = "CodeVMIMTGCComboBox"
        Me.CodeVMIMTGCComboBox.SelectedItem = Nothing
        Me.CodeVMIMTGCComboBox.SelectedValue = Nothing
        Me.CodeVMIMTGCComboBox.Size = New System.Drawing.Size(153, 21)
        Me.CodeVMIMTGCComboBox.SourceObject = Nothing
        Me.CodeVMIMTGCComboBox.SourceObjectAddEmptyItem = False
        Me.CodeVMIMTGCComboBox.SourcePropertiesString = ""
        Me.CodeVMIMTGCComboBox.TabIndex = 4
        Me.CodeVMIMTGCComboBox.ValueForNothing = Nothing
        '
        'CodeSODRAMTGCComboBox
        '
        Me.CodeSODRAMTGCComboBox.BorderStyle = AccControls.MTGCComboBox.TipiBordi.Fixed3D
        Me.CodeSODRAMTGCComboBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CodeSODRAMTGCComboBox.ColumnNum = 1
        Me.CodeSODRAMTGCComboBox.ColumnWidth = "121"
        Me.CodeSODRAMTGCComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PayOutNaturalPersonBindingSource, "CodeSODRA", True))
        Me.CodeSODRAMTGCComboBox.DisplayMember = "Text"
        Me.CodeSODRAMTGCComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CodeSODRAMTGCComboBox.DropDownBackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.CodeSODRAMTGCComboBox.DropDownForeColor = System.Drawing.Color.Black
        Me.CodeSODRAMTGCComboBox.DropDownStyle = AccControls.MTGCComboBox.CustomDropDownStyle.DropDown
        Me.CodeSODRAMTGCComboBox.DropDownWidth = 141
        Me.CodeSODRAMTGCComboBox.FormattingEnabled = True
        Me.CodeSODRAMTGCComboBox.GridLineColor = System.Drawing.Color.LightGray
        Me.CodeSODRAMTGCComboBox.GridLineHorizontal = False
        Me.CodeSODRAMTGCComboBox.GridLineVertical = False
        Me.CodeSODRAMTGCComboBox.LoadingType = AccControls.MTGCComboBox.CaricamentoCombo.ComboBoxItem
        Me.CodeSODRAMTGCComboBox.Location = New System.Drawing.Point(401, 214)
        Me.CodeSODRAMTGCComboBox.ManagingFastMouseMoving = True
        Me.CodeSODRAMTGCComboBox.ManagingFastMouseMovingInterval = 30
        Me.CodeSODRAMTGCComboBox.Name = "CodeSODRAMTGCComboBox"
        Me.CodeSODRAMTGCComboBox.SelectedItem = Nothing
        Me.CodeSODRAMTGCComboBox.SelectedValue = Nothing
        Me.CodeSODRAMTGCComboBox.Size = New System.Drawing.Size(153, 21)
        Me.CodeSODRAMTGCComboBox.SourceObject = Nothing
        Me.CodeSODRAMTGCComboBox.SourceObjectAddEmptyItem = False
        Me.CodeSODRAMTGCComboBox.SourcePropertiesString = ""
        Me.CodeSODRAMTGCComboBox.TabIndex = 3
        Me.CodeSODRAMTGCComboBox.ValueForNothing = Nothing
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.Controls.Add(Label8, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Label6, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Label2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Label4, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(SODRABaseLabel, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ContributionSODRAAccTextBox, 6, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.DeductionGPMAccTextBox, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Label3, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DeductionPSDAccTextBox, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.RateGPMComboBox, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DeductionSODRAAccTextBox, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.RatePSDForCompanyComboBox, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TotalPSDAccTextBox, 4, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TotalSODRAAccTextBox, 6, 7)
        Me.TableLayoutPanel1.Controls.Add(RateGPMLabel, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.RateSODRAForCompanyComboBox, 6, 4)
        Me.TableLayoutPanel1.Controls.Add(Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.RatePSDForPersonComboBox, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.RateSODRAForPersonComboBox, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Label7, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Label5, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.ContributionPSDAccTextBox, 4, 5)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 267)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(846, 191)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'ContributionSODRAAccTextBox
        '
        Me.ContributionSODRAAccTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContributionSODRAAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.PayOutNaturalPersonBindingSource, "ContributionSODRA", True))
        Me.ContributionSODRAAccTextBox.KeepBackColorWhenReadOnly = False
        Me.ContributionSODRAAccTextBox.Location = New System.Drawing.Point(632, 123)
        Me.ContributionSODRAAccTextBox.Name = "ContributionSODRAAccTextBox"
        Me.ContributionSODRAAccTextBox.NegativeValue = False
        Me.ContributionSODRAAccTextBox.ReadOnly = True
        Me.ContributionSODRAAccTextBox.Size = New System.Drawing.Size(188, 20)
        Me.ContributionSODRAAccTextBox.TabIndex = 9
        Me.ContributionSODRAAccTextBox.TabStop = False
        Me.ContributionSODRAAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DeductionGPMAccTextBox
        '
        Me.DeductionGPMAccTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeductionGPMAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.PayOutNaturalPersonBindingSource, "DeductionGPM", True))
        Me.DeductionGPMAccTextBox.KeepBackColorWhenReadOnly = False
        Me.DeductionGPMAccTextBox.Location = New System.Drawing.Point(204, 53)
        Me.DeductionGPMAccTextBox.Name = "DeductionGPMAccTextBox"
        Me.DeductionGPMAccTextBox.NegativeValue = False
        Me.DeductionGPMAccTextBox.ReadOnly = True
        Me.DeductionGPMAccTextBox.Size = New System.Drawing.Size(188, 20)
        Me.DeductionGPMAccTextBox.TabIndex = 13
        Me.DeductionGPMAccTextBox.TabStop = False
        Me.DeductionGPMAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DeductionPSDAccTextBox
        '
        Me.DeductionPSDAccTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeductionPSDAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.PayOutNaturalPersonBindingSource, "DeductionPSD", True))
        Me.DeductionPSDAccTextBox.KeepBackColorWhenReadOnly = False
        Me.DeductionPSDAccTextBox.Location = New System.Drawing.Point(418, 53)
        Me.DeductionPSDAccTextBox.Name = "DeductionPSDAccTextBox"
        Me.DeductionPSDAccTextBox.NegativeValue = False
        Me.DeductionPSDAccTextBox.ReadOnly = True
        Me.DeductionPSDAccTextBox.Size = New System.Drawing.Size(188, 20)
        Me.DeductionPSDAccTextBox.TabIndex = 15
        Me.DeductionPSDAccTextBox.TabStop = False
        Me.DeductionPSDAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RateGPMComboBox
        '
        Me.RateGPMComboBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RateGPMComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PayOutNaturalPersonBindingSource, "RateGPM", True))
        Me.RateGPMComboBox.FormattingEnabled = True
        Me.RateGPMComboBox.Location = New System.Drawing.Point(204, 23)
        Me.RateGPMComboBox.Name = "RateGPMComboBox"
        Me.RateGPMComboBox.Size = New System.Drawing.Size(188, 21)
        Me.RateGPMComboBox.TabIndex = 1
        '
        'DeductionSODRAAccTextBox
        '
        Me.DeductionSODRAAccTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeductionSODRAAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.PayOutNaturalPersonBindingSource, "DeductionSODRA", True))
        Me.DeductionSODRAAccTextBox.KeepBackColorWhenReadOnly = False
        Me.DeductionSODRAAccTextBox.Location = New System.Drawing.Point(632, 53)
        Me.DeductionSODRAAccTextBox.Name = "DeductionSODRAAccTextBox"
        Me.DeductionSODRAAccTextBox.NegativeValue = False
        Me.DeductionSODRAAccTextBox.ReadOnly = True
        Me.DeductionSODRAAccTextBox.Size = New System.Drawing.Size(188, 20)
        Me.DeductionSODRAAccTextBox.TabIndex = 17
        Me.DeductionSODRAAccTextBox.TabStop = False
        Me.DeductionSODRAAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RatePSDForCompanyComboBox
        '
        Me.RatePSDForCompanyComboBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RatePSDForCompanyComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PayOutNaturalPersonBindingSource, "RatePSDForCompany", True))
        Me.RatePSDForCompanyComboBox.FormattingEnabled = True
        Me.RatePSDForCompanyComboBox.Location = New System.Drawing.Point(418, 93)
        Me.RatePSDForCompanyComboBox.Name = "RatePSDForCompanyComboBox"
        Me.RatePSDForCompanyComboBox.Size = New System.Drawing.Size(188, 21)
        Me.RatePSDForCompanyComboBox.TabIndex = 4
        '
        'TotalPSDAccTextBox
        '
        Me.TotalPSDAccTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TotalPSDAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.PayOutNaturalPersonBindingSource, "TotalPSD", True))
        Me.TotalPSDAccTextBox.KeepBackColorWhenReadOnly = False
        Me.TotalPSDAccTextBox.Location = New System.Drawing.Point(418, 163)
        Me.TotalPSDAccTextBox.Name = "TotalPSDAccTextBox"
        Me.TotalPSDAccTextBox.ReadOnly = True
        Me.TotalPSDAccTextBox.Size = New System.Drawing.Size(188, 20)
        Me.TotalPSDAccTextBox.TabIndex = 47
        Me.TotalPSDAccTextBox.TabStop = False
        Me.TotalPSDAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TotalSODRAAccTextBox
        '
        Me.TotalSODRAAccTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TotalSODRAAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.PayOutNaturalPersonBindingSource, "TotalSODRA", True))
        Me.TotalSODRAAccTextBox.KeepBackColorWhenReadOnly = False
        Me.TotalSODRAAccTextBox.Location = New System.Drawing.Point(632, 163)
        Me.TotalSODRAAccTextBox.Name = "TotalSODRAAccTextBox"
        Me.TotalSODRAAccTextBox.ReadOnly = True
        Me.TotalSODRAAccTextBox.Size = New System.Drawing.Size(188, 20)
        Me.TotalSODRAAccTextBox.TabIndex = 49
        Me.TotalSODRAAccTextBox.TabStop = False
        Me.TotalSODRAAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RateSODRAForCompanyComboBox
        '
        Me.RateSODRAForCompanyComboBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RateSODRAForCompanyComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PayOutNaturalPersonBindingSource, "RateSODRAForCompany", True))
        Me.RateSODRAForCompanyComboBox.FormattingEnabled = True
        Me.RateSODRAForCompanyComboBox.Location = New System.Drawing.Point(632, 93)
        Me.RateSODRAForCompanyComboBox.Name = "RateSODRAForCompanyComboBox"
        Me.RateSODRAForCompanyComboBox.Size = New System.Drawing.Size(188, 21)
        Me.RateSODRAForCompanyComboBox.TabIndex = 5
        '
        'RatePSDForPersonComboBox
        '
        Me.RatePSDForPersonComboBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RatePSDForPersonComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PayOutNaturalPersonBindingSource, "RatePSDForPerson", True))
        Me.RatePSDForPersonComboBox.FormattingEnabled = True
        Me.RatePSDForPersonComboBox.Location = New System.Drawing.Point(418, 23)
        Me.RatePSDForPersonComboBox.Name = "RatePSDForPersonComboBox"
        Me.RatePSDForPersonComboBox.Size = New System.Drawing.Size(188, 21)
        Me.RatePSDForPersonComboBox.TabIndex = 2
        '
        'RateSODRAForPersonComboBox
        '
        Me.RateSODRAForPersonComboBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RateSODRAForPersonComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PayOutNaturalPersonBindingSource, "RateSODRAForPerson", True))
        Me.RateSODRAForPersonComboBox.FormattingEnabled = True
        Me.RateSODRAForPersonComboBox.Location = New System.Drawing.Point(632, 23)
        Me.RateSODRAForPersonComboBox.Name = "RateSODRAForPersonComboBox"
        Me.RateSODRAForPersonComboBox.Size = New System.Drawing.Size(188, 21)
        Me.RateSODRAForPersonComboBox.TabIndex = 3
        '
        'ContributionPSDAccTextBox
        '
        Me.ContributionPSDAccTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContributionPSDAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.PayOutNaturalPersonBindingSource, "ContributionPSD", True))
        Me.ContributionPSDAccTextBox.KeepBackColorWhenReadOnly = False
        Me.ContributionPSDAccTextBox.Location = New System.Drawing.Point(418, 123)
        Me.ContributionPSDAccTextBox.Name = "ContributionPSDAccTextBox"
        Me.ContributionPSDAccTextBox.NegativeValue = False
        Me.ContributionPSDAccTextBox.ReadOnly = True
        Me.ContributionPSDAccTextBox.Size = New System.Drawing.Size(188, 20)
        Me.ContributionPSDAccTextBox.TabIndex = 7
        Me.ContributionPSDAccTextBox.TabStop = False
        Me.ContributionPSDAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.SystemColors.Info
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.LoadJournalEntryButton)
        Me.Panel3.Controls.Add(Me.RefreshJournalEntryListButton)
        Me.Panel3.Controls.Add(Me.JournalEntryListComboBox)
        Me.Panel3.Controls.Add(Me.JournalEntryListDateDateTimePicker)
        Me.Panel3.Location = New System.Drawing.Point(11, 37)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(836, 44)
        Me.Panel3.TabIndex = 0
        '
        'LoadJournalEntryButton
        '
        Me.LoadJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LoadJournalEntryButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadJournalEntryButton.Location = New System.Drawing.Point(666, 5)
        Me.LoadJournalEntryButton.Name = "LoadJournalEntryButton"
        Me.LoadJournalEntryButton.Size = New System.Drawing.Size(144, 23)
        Me.LoadJournalEntryButton.TabIndex = 3
        Me.LoadJournalEntryButton.Text = "Įkrauti išmok. oper."
        Me.LoadJournalEntryButton.UseVisualStyleBackColor = True
        '
        'RefreshJournalEntryListButton
        '
        Me.RefreshJournalEntryListButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Button_Reload_icon_16p
        Me.RefreshJournalEntryListButton.Location = New System.Drawing.Point(120, 4)
        Me.RefreshJournalEntryListButton.Name = "RefreshJournalEntryListButton"
        Me.RefreshJournalEntryListButton.Size = New System.Drawing.Size(24, 24)
        Me.RefreshJournalEntryListButton.TabIndex = 1
        Me.RefreshJournalEntryListButton.UseVisualStyleBackColor = True
        '
        'JournalEntryListComboBox
        '
        Me.JournalEntryListComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.JournalEntryListComboBox.DropDownWidth = 350
        Me.JournalEntryListComboBox.FormattingEnabled = True
        Me.JournalEntryListComboBox.Location = New System.Drawing.Point(162, 6)
        Me.JournalEntryListComboBox.Name = "JournalEntryListComboBox"
        Me.JournalEntryListComboBox.Size = New System.Drawing.Size(483, 21)
        Me.JournalEntryListComboBox.TabIndex = 2
        '
        'JournalEntryListDateDateTimePicker
        '
        Me.JournalEntryListDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.JournalEntryListDateDateTimePicker.Location = New System.Drawing.Point(5, 6)
        Me.JournalEntryListDateDateTimePicker.Name = "JournalEntryListDateDateTimePicker"
        Me.JournalEntryListDateDateTimePicker.Size = New System.Drawing.Size(109, 20)
        Me.JournalEntryListDateDateTimePicker.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ViewJournalEntryButton)
        Me.GroupBox1.Controls.Add(Me.JournalEntryIDTextBox)
        Me.GroupBox1.Controls.Add(JournalEntryIDLabel)
        Me.GroupBox1.Controls.Add(DateLabel)
        Me.GroupBox1.Controls.Add(Me.DateDateTimePicker)
        Me.GroupBox1.Controls.Add(Me.DocNumberTextBox)
        Me.GroupBox1.Controls.Add(ContentLabel)
        Me.GroupBox1.Controls.Add(DocNumberLabel)
        Me.GroupBox1.Controls.Add(Me.ContentTextBox)
        Me.GroupBox1.Controls.Add(Me.PersonInfoTextBox)
        Me.GroupBox1.Controls.Add(PersonInfoLabel)
        Me.GroupBox1.Controls.Add(Me.SumNetoAccTextBox)
        Me.GroupBox1.Controls.Add(SumNetoLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(838, 125)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Išmokėjimo operacijos duomenys"
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.ApskaitaWUI.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(261, 16)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 53
        Me.ViewJournalEntryButton.TabStop = False
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = True
        '
        'JournalEntryIDTextBox
        '
        Me.JournalEntryIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PayOutNaturalPersonBindingSource, "JournalEntryID", True))
        Me.JournalEntryIDTextBox.Location = New System.Drawing.Point(82, 19)
        Me.JournalEntryIDTextBox.Name = "JournalEntryIDTextBox"
        Me.JournalEntryIDTextBox.ReadOnly = True
        Me.JournalEntryIDTextBox.Size = New System.Drawing.Size(154, 20)
        Me.JournalEntryIDTextBox.TabIndex = 25
        Me.JournalEntryIDTextBox.TabStop = False
        Me.JournalEntryIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateDateTimePicker
        '
        Me.DateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.PayOutNaturalPersonBindingSource, "Date", True))
        Me.DateDateTimePicker.Enabled = False
        Me.DateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDateTimePicker.Location = New System.Drawing.Point(332, 19)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(172, 20)
        Me.DateDateTimePicker.TabIndex = 11
        Me.DateDateTimePicker.TabStop = False
        '
        'DocNumberTextBox
        '
        Me.DocNumberTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DocNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PayOutNaturalPersonBindingSource, "DocNumber", True))
        Me.DocNumberTextBox.Location = New System.Drawing.Point(82, 45)
        Me.DocNumberTextBox.Name = "DocNumberTextBox"
        Me.DocNumberTextBox.ReadOnly = True
        Me.DocNumberTextBox.Size = New System.Drawing.Size(731, 20)
        Me.DocNumberTextBox.TabIndex = 19
        Me.DocNumberTextBox.TabStop = False
        '
        'ContentTextBox
        '
        Me.ContentTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PayOutNaturalPersonBindingSource, "Content", True))
        Me.ContentTextBox.Location = New System.Drawing.Point(82, 97)
        Me.ContentTextBox.Name = "ContentTextBox"
        Me.ContentTextBox.ReadOnly = True
        Me.ContentTextBox.Size = New System.Drawing.Size(731, 20)
        Me.ContentTextBox.TabIndex = 5
        Me.ContentTextBox.TabStop = False
        '
        'PersonInfoTextBox
        '
        Me.PersonInfoTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PersonInfoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PayOutNaturalPersonBindingSource, "PersonInfo", True))
        Me.PersonInfoTextBox.Location = New System.Drawing.Point(82, 71)
        Me.PersonInfoTextBox.Name = "PersonInfoTextBox"
        Me.PersonInfoTextBox.ReadOnly = True
        Me.PersonInfoTextBox.Size = New System.Drawing.Size(731, 20)
        Me.PersonInfoTextBox.TabIndex = 29
        Me.PersonInfoTextBox.TabStop = False
        '
        'SumNetoAccTextBox
        '
        Me.SumNetoAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SumNetoAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.PayOutNaturalPersonBindingSource, "SumNeto", True))
        Me.SumNetoAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumNetoAccTextBox.Location = New System.Drawing.Point(630, 19)
        Me.SumNetoAccTextBox.Name = "SumNetoAccTextBox"
        Me.SumNetoAccTextBox.NegativeValue = False
        Me.SumNetoAccTextBox.ReadOnly = True
        Me.SumNetoAccTextBox.Size = New System.Drawing.Size(183, 20)
        Me.SumNetoAccTextBox.TabIndex = 45
        Me.SumNetoAccTextBox.TabStop = False
        Me.SumNetoAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IDTextBox
        '
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PayOutNaturalPersonBindingSource, "ID", True))
        Me.IDTextBox.Location = New System.Drawing.Point(111, 11)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(200, 20)
        Me.IDTextBox.TabIndex = 21
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PersonCodeSODRATextBox
        '
        Me.PersonCodeSODRATextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PersonCodeSODRATextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PayOutNaturalPersonBindingSource, "PersonCodeSODRA", True))
        Me.PersonCodeSODRATextBox.Location = New System.Drawing.Point(401, 241)
        Me.PersonCodeSODRATextBox.Name = "PersonCodeSODRATextBox"
        Me.PersonCodeSODRATextBox.Size = New System.Drawing.Size(448, 20)
        Me.PersonCodeSODRATextBox.TabIndex = 6
        '
        'SumBrutoAccTextBox
        '
        Me.SumBrutoAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.PayOutNaturalPersonBindingSource, "SumBruto", True))
        Me.SumBrutoAccTextBox.Location = New System.Drawing.Point(112, 241)
        Me.SumBrutoAccTextBox.Name = "SumBrutoAccTextBox"
        Me.SumBrutoAccTextBox.NegativeValue = False
        Me.SumBrutoAccTextBox.Size = New System.Drawing.Size(114, 20)
        Me.SumBrutoAccTextBox.TabIndex = 5
        Me.SumBrutoAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.ICancelButton)
        Me.Panel2.Controls.Add(Me.IOkButton)
        Me.Panel2.Controls.Add(Me.IApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 478)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(886, 32)
        Me.Panel2.TabIndex = 1
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(785, 6)
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
        Me.IOkButton.Location = New System.Drawing.Point(579, 6)
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
        Me.IApplyButton.Location = New System.Drawing.Point(683, 6)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(89, 23)
        Me.IApplyButton.TabIndex = 1
        Me.IApplyButton.Text = "Išsaugoti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.DataSource = Me.PayOutNaturalPersonBindingSource
        '
        'F_PayOutNaturalPerson
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(886, 510)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_PayOutNaturalPerson"
        Me.ShowInTaskbar = False
        Me.Text = "Išmoka fiziniam asmeniui"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PayOutNaturalPersonBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PayOutNaturalPersonBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ContributionPSDAccTextBox As AccControls.AccTextBox
    Friend WithEvents ContributionSODRAAccTextBox As AccControls.AccTextBox
    Friend WithEvents DateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents DeductionGPMAccTextBox As AccControls.AccTextBox
    Friend WithEvents DeductionPSDAccTextBox As AccControls.AccTextBox
    Friend WithEvents DeductionSODRAAccTextBox As AccControls.AccTextBox
    Friend WithEvents DocNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents JournalEntryIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PersonCodeSODRATextBox As System.Windows.Forms.TextBox
    Friend WithEvents PersonInfoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RateGPMComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RatePSDForCompanyComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RatePSDForPersonComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RateSODRAForCompanyComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RateSODRAForPersonComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents SumBrutoAccTextBox As AccControls.AccTextBox
    Friend WithEvents SumNetoAccTextBox As AccControls.AccTextBox
    Friend WithEvents TotalPSDAccTextBox As AccControls.AccTextBox
    Friend WithEvents TotalSODRAAccTextBox As AccControls.AccTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LoadJournalEntryButton As System.Windows.Forms.Button
    Friend WithEvents RefreshJournalEntryListButton As System.Windows.Forms.Button
    Friend WithEvents JournalEntryListComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents JournalEntryListDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents CodeVMIMTGCComboBox As AccControls.MTGCComboBox
    Friend WithEvents CodeSODRAMTGCComboBox As AccControls.MTGCComboBox
    Friend WithEvents SODRABaseAccTextBox As AccControls.AccTextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
End Class
