<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_LongTermAssetOperation
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
        Dim AssetAquisitionOpIDLabel As System.Windows.Forms.Label
        Dim AssetIDLabel As System.Windows.Forms.Label
        Dim AssetMeasureUnitLabel As System.Windows.Forms.Label
        Dim AssetNameLabel As System.Windows.Forms.Label
        Dim AssetDateAcquiredLabel As System.Windows.Forms.Label
        Dim AssetLiquidationValueLabel As System.Windows.Forms.Label
        Dim AssetAcquiredAccountLabel As System.Windows.Forms.Label
        Dim AssetContraryAccountLabel As System.Windows.Forms.Label
        Dim AssetValueDecreaseAccountLabel As System.Windows.Forms.Label
        Dim AssetValueIncreaseAccountLabel As System.Windows.Forms.Label
        Dim AssetValueIncreaseAmortizationAccountLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim CurrentAssetValuePerUnitLabel As System.Windows.Forms.Label
        Dim CurrentAssetAmmountLabel As System.Windows.Forms.Label
        Dim CurrentAssetValueLabel As System.Windows.Forms.Label
        Dim CurrentAmortizationPeriodLabel As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim CurrentAssetValueRevaluedPortionPerUnitLabel As System.Windows.Forms.Label
        Dim CurrentAssetValueRevaluedPortionLabel As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim AmortizationCalculatedForMonthsLabel As System.Windows.Forms.Label
        Dim CurrentUsageTermMonthsLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim TypeHumanReadableLabel As System.Windows.Forms.Label
        Dim AccountChangeTypeHumanReadableLabel As System.Windows.Forms.Label
        Dim AccountCorrespondingLabel As System.Windows.Forms.Label
        Dim ActNumberLabel As System.Windows.Forms.Label
        Dim ContentLabel As System.Windows.Forms.Label
        Dim JournalEntryIDLabel As System.Windows.Forms.Label
        Dim JournalEntryDocNumberLabel As System.Windows.Forms.Label
        Dim JournalEntryContentLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_LongTermAssetOperation))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.EditedBaner = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.NewItemButton = New System.Windows.Forms.Button
        Me.CancelButton = New System.Windows.Forms.Button
        Me.ApplyButton = New System.Windows.Forms.Button
        Me.OkButton = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LimitationsButton = New System.Windows.Forms.Button
        Me.AccountCorrespondingAccGridComboBox = New AccControls.AccGridComboBox
        Me.LongTermAssetOperationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button
        Me.JournalEntryContentTextBox = New System.Windows.Forms.TextBox
        Me.RefreshJournalEntryInfoButton = New System.Windows.Forms.Button
        Me.JournalEntryIDTextBox = New System.Windows.Forms.TextBox
        Me.JournalEntryInfoComboBox = New System.Windows.Forms.ComboBox
        Me.AttachJournalEntryInfoButton = New System.Windows.Forms.Button
        Me.JournalEntryDocNumberTextBox = New System.Windows.Forms.TextBox
        Me.TypeHumanReadableComboBox = New System.Windows.Forms.ComboBox
        Me.ContentTextBox = New System.Windows.Forms.TextBox
        Me.ActNumberAccBox = New AccControls.AccTextBox
        Me.AccountChangeTypeHumanReadableComboBox = New System.Windows.Forms.ComboBox
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.IsComplexActCheckBox = New System.Windows.Forms.CheckBox
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.CalculateAmortizationButton = New System.Windows.Forms.Button
        Me.AmortizationCalculationsButton = New System.Windows.Forms.Button
        Me.AmortizationCalculatedForMonthsTextBox = New System.Windows.Forms.TextBox
        Me.CurrentUsageTermMonthsTextBox = New System.Windows.Forms.TextBox
        Me.AfterOperationAssetValueRevaluedPortionAccBox = New AccControls.AccTextBox
        Me.AfterOperationAssetValueRevaluedPortionPerUnitAccBox = New AccControls.AccTextBox
        Me.RevaluedPortionTotalValueChangeAccBox = New AccControls.AccTextBox
        Me.RevaluedPortionUnitValueChangeAccBox = New AccControls.AccTextBox
        Me.CurrentAssetValueRevaluedPortionAccBox = New AccControls.AccTextBox
        Me.CurrentAssetValueRevaluedPortionPerUnitAccBox = New AccControls.AccTextBox
        Me.NewAmortizationPeriodAccBox = New AccControls.AccTextBox
        Me.AfterOperationAssetValueAccBox = New AccControls.AccTextBox
        Me.AfterOperationAssetAmmountAccBox = New AccControls.AccTextBox
        Me.AfterOperationAssetValuePerUnitAccBox = New AccControls.AccTextBox
        Me.AmmountChangeAccBox = New AccControls.AccTextBox
        Me.TotalValueChangeAccBox = New AccControls.AccTextBox
        Me.UnitValueChangeAccBox = New AccControls.AccTextBox
        Me.CurrentAmortizationPeriodTextBox = New System.Windows.Forms.TextBox
        Me.CurrentAssetValueAccBox = New AccControls.AccTextBox
        Me.CurrentAssetAmmountTextBox = New System.Windows.Forms.TextBox
        Me.CurrentAssetValuePerUnitAccBox = New AccControls.AccTextBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.AssetAcquiredAccountTextBox = New System.Windows.Forms.TextBox
        Me.AfterOperationValueIncreaseAmortizationAccountValuePerUnitAccBox = New AccControls.AccTextBox
        Me.AssetContraryAccountTextBox = New System.Windows.Forms.TextBox
        Me.AfterOperationValueIncreaseAccountValuePerUnitAccBox = New AccControls.AccTextBox
        Me.AfterOperationValueDecreaseAccountValuePerUnitAccBox = New AccControls.AccTextBox
        Me.AssetValueDecreaseAccountTextBox = New System.Windows.Forms.TextBox
        Me.AfterOperationAmortizationAccountValuePerUnitAccBox = New AccControls.AccTextBox
        Me.AfterOperationAcquisitionAccountValuePerUnitAccBox = New AccControls.AccTextBox
        Me.AssetValueIncreaseAccountTextBox = New System.Windows.Forms.TextBox
        Me.AfterOperationValueIncreaseAmortizationAccountValueAccBox = New AccControls.AccTextBox
        Me.AssetValueIncreaseAmortizationAccountTextBox = New System.Windows.Forms.TextBox
        Me.AfterOperationValueIncreaseAccountValueAccBox = New AccControls.AccTextBox
        Me.AfterOperationValueDecreaseAccountValueAccBox = New AccControls.AccTextBox
        Me.AfterOperationAmortizationAccountValueAccBox = New AccControls.AccTextBox
        Me.CurrentAcquisitionAccountValueAccBox = New AccControls.AccTextBox
        Me.AfterOperationAcquisitionAccountValueAccBox = New AccControls.AccTextBox
        Me.CurrentAmortizationAccountValueAccBox = New AccControls.AccTextBox
        Me.CurrentValueDecreaseAccountValueAccBox = New AccControls.AccTextBox
        Me.CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox = New AccControls.AccTextBox
        Me.CurrentValueIncreaseAccountValueAccBox = New AccControls.AccTextBox
        Me.CurrentValueIncreaseAccountValuePerUnitAccBox = New AccControls.AccTextBox
        Me.CurrentValueIncreaseAmortizationAccountValueAccBox = New AccControls.AccTextBox
        Me.CurrentValueDecreaseAccountValuePerUnitAccBox = New AccControls.AccTextBox
        Me.CurrentAmortizationAccountValuePerUnitAccBox = New AccControls.AccTextBox
        Me.CurrentAcquisitionAccountValuePerUnitAccBox = New AccControls.AccTextBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.CurrentUsageStatusCheckBox = New System.Windows.Forms.CheckBox
        Me.AssetNameTextBox = New System.Windows.Forms.TextBox
        Me.AssetMeasureUnitTextBox = New System.Windows.Forms.TextBox
        Me.AssetLiquidationValueAccBox = New AccControls.AccTextBox
        Me.AssetIDTextBox = New System.Windows.Forms.TextBox
        Me.AssetAquisitionOpIDTextBox = New System.Windows.Forms.TextBox
        Me.AssetDateAcquiredDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        AssetAquisitionOpIDLabel = New System.Windows.Forms.Label
        AssetIDLabel = New System.Windows.Forms.Label
        AssetMeasureUnitLabel = New System.Windows.Forms.Label
        AssetNameLabel = New System.Windows.Forms.Label
        AssetDateAcquiredLabel = New System.Windows.Forms.Label
        AssetLiquidationValueLabel = New System.Windows.Forms.Label
        AssetAcquiredAccountLabel = New System.Windows.Forms.Label
        AssetContraryAccountLabel = New System.Windows.Forms.Label
        AssetValueDecreaseAccountLabel = New System.Windows.Forms.Label
        AssetValueIncreaseAccountLabel = New System.Windows.Forms.Label
        AssetValueIncreaseAmortizationAccountLabel = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        CurrentAssetValuePerUnitLabel = New System.Windows.Forms.Label
        CurrentAssetAmmountLabel = New System.Windows.Forms.Label
        CurrentAssetValueLabel = New System.Windows.Forms.Label
        CurrentAmortizationPeriodLabel = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Label9 = New System.Windows.Forms.Label
        CurrentAssetValueRevaluedPortionPerUnitLabel = New System.Windows.Forms.Label
        CurrentAssetValueRevaluedPortionLabel = New System.Windows.Forms.Label
        Label10 = New System.Windows.Forms.Label
        AmortizationCalculatedForMonthsLabel = New System.Windows.Forms.Label
        CurrentUsageTermMonthsLabel = New System.Windows.Forms.Label
        DateLabel = New System.Windows.Forms.Label
        IDLabel = New System.Windows.Forms.Label
        TypeHumanReadableLabel = New System.Windows.Forms.Label
        AccountChangeTypeHumanReadableLabel = New System.Windows.Forms.Label
        AccountCorrespondingLabel = New System.Windows.Forms.Label
        ActNumberLabel = New System.Windows.Forms.Label
        ContentLabel = New System.Windows.Forms.Label
        JournalEntryIDLabel = New System.Windows.Forms.Label
        JournalEntryDocNumberLabel = New System.Windows.Forms.Label
        JournalEntryContentLabel = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.EditedBaner.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.LongTermAssetOperationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AssetAquisitionOpIDLabel
        '
        AssetAquisitionOpIDLabel.AutoSize = True
        AssetAquisitionOpIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AssetAquisitionOpIDLabel.Location = New System.Drawing.Point(385, 33)
        AssetAquisitionOpIDLabel.Name = "AssetAquisitionOpIDLabel"
        AssetAquisitionOpIDLabel.Size = New System.Drawing.Size(85, 13)
        AssetAquisitionOpIDLabel.TabIndex = 0
        AssetAquisitionOpIDLabel.Text = "Įsig. oper. ID:"
        '
        'AssetIDLabel
        '
        AssetIDLabel.AutoSize = True
        AssetIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AssetIDLabel.Location = New System.Drawing.Point(80, 34)
        AssetIDLabel.Name = "AssetIDLabel"
        AssetIDLabel.Size = New System.Drawing.Size(58, 13)
        AssetIDLabel.TabIndex = 2
        AssetIDLabel.Text = "Turto ID:"
        '
        'AssetMeasureUnitLabel
        '
        AssetMeasureUnitLabel.AutoSize = True
        AssetMeasureUnitLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AssetMeasureUnitLabel.Location = New System.Drawing.Point(545, 33)
        AssetMeasureUnitLabel.Name = "AssetMeasureUnitLabel"
        AssetMeasureUnitLabel.Size = New System.Drawing.Size(65, 13)
        AssetMeasureUnitLabel.TabIndex = 4
        AssetMeasureUnitLabel.Text = "Mato vnt.:"
        '
        'AssetNameLabel
        '
        AssetNameLabel.AutoSize = True
        AssetNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AssetNameLabel.Location = New System.Drawing.Point(20, 8)
        AssetNameLabel.Name = "AssetNameLabel"
        AssetNameLabel.Size = New System.Drawing.Size(115, 13)
        AssetNameLabel.TabIndex = 6
        AssetNameLabel.Text = "Turto pavadinimas:"
        '
        'AssetDateAcquiredLabel
        '
        AssetDateAcquiredLabel.AutoSize = True
        AssetDateAcquiredLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AssetDateAcquiredLabel.Location = New System.Drawing.Point(205, 34)
        AssetDateAcquiredLabel.Name = "AssetDateAcquiredLabel"
        AssetDateAcquiredLabel.Size = New System.Drawing.Size(64, 13)
        AssetDateAcquiredLabel.TabIndex = 9
        AssetDateAcquiredLabel.Text = "Įsig. data:"
        '
        'AssetLiquidationValueLabel
        '
        AssetLiquidationValueLabel.AutoSize = True
        AssetLiquidationValueLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AssetLiquidationValueLabel.Location = New System.Drawing.Point(506, 60)
        AssetLiquidationValueLabel.Name = "AssetLiquidationValueLabel"
        AssetLiquidationValueLabel.Size = New System.Drawing.Size(98, 13)
        AssetLiquidationValueLabel.TabIndex = 10
        AssetLiquidationValueLabel.Text = "Likv. vertė vnt.:"
        '
        'AssetAcquiredAccountLabel
        '
        AssetAcquiredAccountLabel.AutoSize = True
        AssetAcquiredAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AssetAcquiredAccountLabel.Location = New System.Drawing.Point(70, 24)
        AssetAcquiredAccountLabel.Name = "AssetAcquiredAccountLabel"
        AssetAcquiredAccountLabel.Size = New System.Drawing.Size(67, 13)
        AssetAcquiredAccountLabel.TabIndex = 8
        AssetAcquiredAccountLabel.Text = "Savikaina:"
        '
        'AssetContraryAccountLabel
        '
        AssetContraryAccountLabel.AutoSize = True
        AssetContraryAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AssetContraryAccountLabel.Location = New System.Drawing.Point(58, 50)
        AssetContraryAccountLabel.Name = "AssetContraryAccountLabel"
        AssetContraryAccountLabel.Size = New System.Drawing.Size(79, 13)
        AssetContraryAccountLabel.TabIndex = 9
        AssetContraryAccountLabel.Text = "Amortizacija:"
        '
        'AssetValueDecreaseAccountLabel
        '
        AssetValueDecreaseAccountLabel.AutoSize = True
        AssetValueDecreaseAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AssetValueDecreaseAccountLabel.Location = New System.Drawing.Point(47, 76)
        AssetValueDecreaseAccountLabel.Name = "AssetValueDecreaseAccountLabel"
        AssetValueDecreaseAccountLabel.Size = New System.Drawing.Size(90, 13)
        AssetValueDecreaseAccountLabel.TabIndex = 10
        AssetValueDecreaseAccountLabel.Text = "Vertės sumaž.:"
        '
        'AssetValueIncreaseAccountLabel
        '
        AssetValueIncreaseAccountLabel.AutoSize = True
        AssetValueIncreaseAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AssetValueIncreaseAccountLabel.Location = New System.Drawing.Point(50, 102)
        AssetValueIncreaseAccountLabel.Name = "AssetValueIncreaseAccountLabel"
        AssetValueIncreaseAccountLabel.Size = New System.Drawing.Size(87, 13)
        AssetValueIncreaseAccountLabel.TabIndex = 11
        AssetValueIncreaseAccountLabel.Text = "Pervertinimas:"
        '
        'AssetValueIncreaseAmortizationAccountLabel
        '
        AssetValueIncreaseAmortizationAccountLabel.AutoSize = True
        AssetValueIncreaseAmortizationAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AssetValueIncreaseAmortizationAccountLabel.Location = New System.Drawing.Point(5, 128)
        AssetValueIncreaseAmortizationAccountLabel.Name = "AssetValueIncreaseAmortizationAccountLabel"
        AssetValueIncreaseAmortizationAccountLabel.Size = New System.Drawing.Size(132, 13)
        AssetValueIncreaseAmortizationAccountLabel.TabIndex = 12
        AssetValueIncreaseAmortizationAccountLabel.Text = "Pervert. dalies amort.:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(153, 5)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(73, 13)
        Label1.TabIndex = 14
        Label1.Text = "Apsk. sąsk."
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(270, 5)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(90, 13)
        Label2.TabIndex = 22
        Label2.Text = "Vertė prieš op."
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(366, 5)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(116, 13)
        Label3.TabIndex = 28
        Label3.Text = "Vertė prieš op. vnt."
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label5.Location = New System.Drawing.Point(515, 5)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(77, 13)
        Label5.TabIndex = 34
        Label5.Text = "Vertė po op."
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(609, 5)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(103, 13)
        Label6.TabIndex = 40
        Label6.Text = "Vertė po op. vnt."
        '
        'CurrentAssetValuePerUnitLabel
        '
        CurrentAssetValuePerUnitLabel.AutoSize = True
        CurrentAssetValuePerUnitLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrentAssetValuePerUnitLabel.Location = New System.Drawing.Point(77, 276)
        CurrentAssetValuePerUnitLabel.Name = "CurrentAssetValuePerUnitLabel"
        CurrentAssetValuePerUnitLabel.Size = New System.Drawing.Size(67, 13)
        CurrentAssetValuePerUnitLabel.TabIndex = 41
        CurrentAssetValuePerUnitLabel.Text = "Vertė vnt.:"
        '
        'CurrentAssetAmmountLabel
        '
        CurrentAssetAmmountLabel.AutoSize = True
        CurrentAssetAmmountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrentAssetAmmountLabel.Location = New System.Drawing.Point(99, 302)
        CurrentAssetAmmountLabel.Name = "CurrentAssetAmmountLabel"
        CurrentAssetAmmountLabel.Size = New System.Drawing.Size(45, 13)
        CurrentAssetAmmountLabel.TabIndex = 42
        CurrentAssetAmmountLabel.Text = "Kiekis:"
        '
        'CurrentAssetValueLabel
        '
        CurrentAssetValueLabel.AutoSize = True
        CurrentAssetValueLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrentAssetValueLabel.Location = New System.Drawing.Point(103, 328)
        CurrentAssetValueLabel.Name = "CurrentAssetValueLabel"
        CurrentAssetValueLabel.Size = New System.Drawing.Size(41, 13)
        CurrentAssetValueLabel.TabIndex = 43
        CurrentAssetValueLabel.Text = "Vertė:"
        '
        'CurrentAmortizationPeriodLabel
        '
        CurrentAmortizationPeriodLabel.AutoSize = True
        CurrentAmortizationPeriodLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrentAmortizationPeriodLabel.Location = New System.Drawing.Point(69, 406)
        CurrentAmortizationPeriodLabel.Name = "CurrentAmortizationPeriodLabel"
        CurrentAmortizationPeriodLabel.Size = New System.Drawing.Size(75, 13)
        CurrentAmortizationPeriodLabel.TabIndex = 44
        CurrentAmortizationPeriodLabel.Text = "Amort. laik.:"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.Location = New System.Drawing.Point(165, 257)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(68, 13)
        Label7.TabIndex = 46
        Label7.Text = "Prieš oper."
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label8.Location = New System.Drawing.Point(279, 257)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(48, 13)
        Label8.TabIndex = 50
        Label8.Text = "Pokytis"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label9.Location = New System.Drawing.Point(394, 257)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(69, 13)
        Label9.TabIndex = 55
        Label9.Text = "Po operac."
        '
        'CurrentAssetValueRevaluedPortionPerUnitLabel
        '
        CurrentAssetValueRevaluedPortionPerUnitLabel.AutoSize = True
        CurrentAssetValueRevaluedPortionPerUnitLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrentAssetValueRevaluedPortionPerUnitLabel.Location = New System.Drawing.Point(7, 354)
        CurrentAssetValueRevaluedPortionPerUnitLabel.Name = "CurrentAssetValueRevaluedPortionPerUnitLabel"
        CurrentAssetValueRevaluedPortionPerUnitLabel.Size = New System.Drawing.Size(137, 13)
        CurrentAssetValueRevaluedPortionPerUnitLabel.TabIndex = 55
        CurrentAssetValueRevaluedPortionPerUnitLabel.Text = "Perv. dalies vertė vnt.:"
        '
        'CurrentAssetValueRevaluedPortionLabel
        '
        CurrentAssetValueRevaluedPortionLabel.AutoSize = True
        CurrentAssetValueRevaluedPortionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrentAssetValueRevaluedPortionLabel.Location = New System.Drawing.Point(33, 380)
        CurrentAssetValueRevaluedPortionLabel.Name = "CurrentAssetValueRevaluedPortionLabel"
        CurrentAssetValueRevaluedPortionLabel.Size = New System.Drawing.Size(111, 13)
        CurrentAssetValueRevaluedPortionLabel.TabIndex = 56
        CurrentAssetValueRevaluedPortionLabel.Text = "Perv. dalies vertė:"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label10.Location = New System.Drawing.Point(9, 5)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(101, 13)
        Label10.TabIndex = 63
        Label10.Text = "AMORTIZACIJA:"
        '
        'AmortizationCalculatedForMonthsLabel
        '
        AmortizationCalculatedForMonthsLabel.AutoSize = True
        AmortizationCalculatedForMonthsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AmortizationCalculatedForMonthsLabel.Location = New System.Drawing.Point(25, 52)
        AmortizationCalculatedForMonthsLabel.Name = "AmortizationCalculatedForMonthsLabel"
        AmortizationCalculatedForMonthsLabel.Size = New System.Drawing.Size(125, 13)
        AmortizationCalculatedForMonthsLabel.TabIndex = 62
        AmortizationCalculatedForMonthsLabel.Text = "Oper. pask. už mėn.:"
        '
        'CurrentUsageTermMonthsLabel
        '
        CurrentUsageTermMonthsLabel.AutoSize = True
        CurrentUsageTermMonthsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrentUsageTermMonthsLabel.Location = New System.Drawing.Point(10, 26)
        CurrentUsageTermMonthsLabel.Name = "CurrentUsageTermMonthsLabel"
        CurrentUsageTermMonthsLabel.Size = New System.Drawing.Size(141, 13)
        CurrentUsageTermMonthsLabel.TabIndex = 63
        CurrentUsageTermMonthsLabel.Text = "Iki oper. pask. už mėn.:"
        '
        'DateLabel
        '
        DateLabel.AutoSize = True
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(110, 433)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(38, 13)
        DateLabel.TabIndex = 62
        DateLabel.Text = "Data:"
        '
        'IDLabel
        '
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(497, 377)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(24, 13)
        IDLabel.TabIndex = 64
        IDLabel.Text = "ID:"
        '
        'TypeHumanReadableLabel
        '
        TypeHumanReadableLabel.AutoSize = True
        TypeHumanReadableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TypeHumanReadableLabel.Location = New System.Drawing.Point(270, 431)
        TypeHumanReadableLabel.Name = "TypeHumanReadableLabel"
        TypeHumanReadableLabel.Size = New System.Drawing.Size(73, 13)
        TypeHumanReadableLabel.TabIndex = 65
        TypeHumanReadableLabel.Text = "Oper. tipas:"
        '
        'AccountChangeTypeHumanReadableLabel
        '
        AccountChangeTypeHumanReadableLabel.AutoSize = True
        AccountChangeTypeHumanReadableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountChangeTypeHumanReadableLabel.Location = New System.Drawing.Point(11, 458)
        AccountChangeTypeHumanReadableLabel.Name = "AccountChangeTypeHumanReadableLabel"
        AccountChangeTypeHumanReadableLabel.Size = New System.Drawing.Size(132, 13)
        AccountChangeTypeHumanReadableLabel.TabIndex = 66
        AccountChangeTypeHumanReadableLabel.Text = "Sąsk. pakeitimo tipas:"
        '
        'AccountCorrespondingLabel
        '
        AccountCorrespondingLabel.AutoSize = True
        AccountCorrespondingLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountCorrespondingLabel.Location = New System.Drawing.Point(382, 458)
        AccountCorrespondingLabel.Name = "AccountCorrespondingLabel"
        AccountCorrespondingLabel.Size = New System.Drawing.Size(88, 13)
        AccountCorrespondingLabel.TabIndex = 67
        AccountCorrespondingLabel.Text = "Koresp. sąsk.:"
        '
        'ActNumberLabel
        '
        ActNumberLabel.AutoSize = True
        ActNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ActNumberLabel.Location = New System.Drawing.Point(622, 458)
        ActNumberLabel.Name = "ActNumberLabel"
        ActNumberLabel.Size = New System.Drawing.Size(58, 13)
        ActNumberLabel.TabIndex = 68
        ActNumberLabel.Text = "Akto Nr.:"
        '
        'ContentLabel
        '
        ContentLabel.AutoSize = True
        ContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContentLabel.Location = New System.Drawing.Point(96, 485)
        ContentLabel.Name = "ContentLabel"
        ContentLabel.Size = New System.Drawing.Size(52, 13)
        ContentLabel.TabIndex = 69
        ContentLabel.Text = "Turinys:"
        '
        'JournalEntryIDLabel
        '
        JournalEntryIDLabel.AutoSize = True
        JournalEntryIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        JournalEntryIDLabel.Location = New System.Drawing.Point(3, 10)
        JournalEntryIDLabel.Name = "JournalEntryIDLabel"
        JournalEntryIDLabel.Size = New System.Drawing.Size(143, 13)
        JournalEntryIDLabel.TabIndex = 70
        JournalEntryIDLabel.Text = "SUSIETA BŽ OPER. ID:"
        '
        'JournalEntryDocNumberLabel
        '
        JournalEntryDocNumberLabel.AutoSize = True
        JournalEntryDocNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        JournalEntryDocNumberLabel.Location = New System.Drawing.Point(244, 10)
        JournalEntryDocNumberLabel.Name = "JournalEntryDocNumberLabel"
        JournalEntryDocNumberLabel.Size = New System.Drawing.Size(59, 13)
        JournalEntryDocNumberLabel.TabIndex = 71
        JournalEntryDocNumberLabel.Text = "Dok. Nr.:"
        '
        'JournalEntryContentLabel
        '
        JournalEntryContentLabel.AutoSize = True
        JournalEntryContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        JournalEntryContentLabel.Location = New System.Drawing.Point(403, 10)
        JournalEntryContentLabel.Name = "JournalEntryContentLabel"
        JournalEntryContentLabel.Size = New System.Drawing.Size(52, 13)
        JournalEntryContentLabel.TabIndex = 72
        JournalEntryContentLabel.Text = "Turinys:"
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.EditedBaner)
        Me.Panel2.Controls.Add(Me.NewItemButton)
        Me.Panel2.Controls.Add(Me.CancelButton)
        Me.Panel2.Controls.Add(Me.ApplyButton)
        Me.Panel2.Controls.Add(Me.OkButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 582)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Panel2.Size = New System.Drawing.Size(794, 42)
        Me.Panel2.TabIndex = 1
        '
        'EditedBaner
        '
        Me.EditedBaner.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditedBaner.BackColor = System.Drawing.Color.Red
        Me.EditedBaner.Controls.Add(Me.Label4)
        Me.EditedBaner.Location = New System.Drawing.Point(362, 10)
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
        'NewItemButton
        '
        Me.NewItemButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewItemButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.NewItemButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewItemButton.Location = New System.Drawing.Point(707, 12)
        Me.NewItemButton.Name = "NewItemButton"
        Me.NewItemButton.Size = New System.Drawing.Size(75, 23)
        Me.NewItemButton.TabIndex = 3
        Me.NewItemButton.Text = "Nauja"
        Me.NewItemButton.UseVisualStyleBackColor = True
        '
        'CancelButton
        '
        Me.CancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelButton.Location = New System.Drawing.Point(626, 12)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton.TabIndex = 2
        Me.CancelButton.Text = "Atšaukti"
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyButton.Location = New System.Drawing.Point(545, 12)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(75, 23)
        Me.ApplyButton.TabIndex = 1
        Me.ApplyButton.Text = "Taikyti"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.Location = New System.Drawing.Point(464, 12)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "OK"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LimitationsButton)
        Me.Panel1.Controls.Add(Me.AccountCorrespondingAccGridComboBox)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.TypeHumanReadableComboBox)
        Me.Panel1.Controls.Add(ContentLabel)
        Me.Panel1.Controls.Add(Me.ContentTextBox)
        Me.Panel1.Controls.Add(ActNumberLabel)
        Me.Panel1.Controls.Add(Me.ActNumberAccBox)
        Me.Panel1.Controls.Add(AccountCorrespondingLabel)
        Me.Panel1.Controls.Add(AccountChangeTypeHumanReadableLabel)
        Me.Panel1.Controls.Add(Me.AccountChangeTypeHumanReadableComboBox)
        Me.Panel1.Controls.Add(TypeHumanReadableLabel)
        Me.Panel1.Controls.Add(IDLabel)
        Me.Panel1.Controls.Add(Me.IDTextBox)
        Me.Panel1.Controls.Add(Me.IsComplexActCheckBox)
        Me.Panel1.Controls.Add(DateLabel)
        Me.Panel1.Controls.Add(Me.DateDateTimePicker)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.AfterOperationAssetValueRevaluedPortionAccBox)
        Me.Panel1.Controls.Add(Me.AfterOperationAssetValueRevaluedPortionPerUnitAccBox)
        Me.Panel1.Controls.Add(Me.RevaluedPortionTotalValueChangeAccBox)
        Me.Panel1.Controls.Add(Me.RevaluedPortionUnitValueChangeAccBox)
        Me.Panel1.Controls.Add(CurrentAssetValueRevaluedPortionLabel)
        Me.Panel1.Controls.Add(Me.CurrentAssetValueRevaluedPortionAccBox)
        Me.Panel1.Controls.Add(CurrentAssetValueRevaluedPortionPerUnitLabel)
        Me.Panel1.Controls.Add(Me.CurrentAssetValueRevaluedPortionPerUnitAccBox)
        Me.Panel1.Controls.Add(Label9)
        Me.Panel1.Controls.Add(Me.NewAmortizationPeriodAccBox)
        Me.Panel1.Controls.Add(Me.AfterOperationAssetValueAccBox)
        Me.Panel1.Controls.Add(Me.AfterOperationAssetAmmountAccBox)
        Me.Panel1.Controls.Add(Me.AfterOperationAssetValuePerUnitAccBox)
        Me.Panel1.Controls.Add(Label8)
        Me.Panel1.Controls.Add(Me.AmmountChangeAccBox)
        Me.Panel1.Controls.Add(Me.TotalValueChangeAccBox)
        Me.Panel1.Controls.Add(Me.UnitValueChangeAccBox)
        Me.Panel1.Controls.Add(Label7)
        Me.Panel1.Controls.Add(CurrentAmortizationPeriodLabel)
        Me.Panel1.Controls.Add(Me.CurrentAmortizationPeriodTextBox)
        Me.Panel1.Controls.Add(CurrentAssetValueLabel)
        Me.Panel1.Controls.Add(Me.CurrentAssetValueAccBox)
        Me.Panel1.Controls.Add(CurrentAssetAmmountLabel)
        Me.Panel1.Controls.Add(Me.CurrentAssetAmmountTextBox)
        Me.Panel1.Controls.Add(CurrentAssetValuePerUnitLabel)
        Me.Panel1.Controls.Add(Me.CurrentAssetValuePerUnitAccBox)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 582)
        Me.Panel1.TabIndex = 0
        '
        'LimitationsButton
        '
        Me.LimitationsButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Action_lock_icon_32p
        Me.LimitationsButton.Location = New System.Drawing.Point(724, 369)
        Me.LimitationsButton.Name = "LimitationsButton"
        Me.LimitationsButton.Size = New System.Drawing.Size(50, 45)
        Me.LimitationsButton.TabIndex = 18
        Me.LimitationsButton.UseVisualStyleBackColor = True
        '
        'AccountCorrespondingAccGridComboBox
        '
        Me.AccountCorrespondingAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.LongTermAssetOperationBindingSource, "AccountCorresponding", True))
        Me.AccountCorrespondingAccGridComboBox.FilterPropertyName = ""
        Me.AccountCorrespondingAccGridComboBox.FormattingEnabled = True
        Me.AccountCorrespondingAccGridComboBox.InstantBinding = True
        Me.AccountCorrespondingAccGridComboBox.Location = New System.Drawing.Point(476, 455)
        Me.AccountCorrespondingAccGridComboBox.Name = "AccountCorrespondingAccGridComboBox"
        Me.AccountCorrespondingAccGridComboBox.Size = New System.Drawing.Size(121, 21)
        Me.AccountCorrespondingAccGridComboBox.TabIndex = 3
        '
        'LongTermAssetOperationBindingSource
        '
        Me.LongTermAssetOperationBindingSource.DataSource = GetType(ApskaitaObjects.Assets.LongTermAssetOperation)
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.ViewJournalEntryButton)
        Me.Panel6.Controls.Add(Me.JournalEntryContentTextBox)
        Me.Panel6.Controls.Add(Me.RefreshJournalEntryInfoButton)
        Me.Panel6.Controls.Add(Me.JournalEntryIDTextBox)
        Me.Panel6.Controls.Add(Me.JournalEntryInfoComboBox)
        Me.Panel6.Controls.Add(Me.AttachJournalEntryInfoButton)
        Me.Panel6.Controls.Add(Me.JournalEntryDocNumberTextBox)
        Me.Panel6.Controls.Add(JournalEntryIDLabel)
        Me.Panel6.Controls.Add(JournalEntryContentLabel)
        Me.Panel6.Controls.Add(JournalEntryDocNumberLabel)
        Me.Panel6.Location = New System.Drawing.Point(7, 508)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(769, 62)
        Me.Panel6.TabIndex = 17
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.ApskaitaWUI.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(217, 4)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 3
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = True
        '
        'JournalEntryContentTextBox
        '
        Me.JournalEntryContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "JournalEntryContent", True))
        Me.JournalEntryContentTextBox.Location = New System.Drawing.Point(456, 7)
        Me.JournalEntryContentTextBox.Name = "JournalEntryContentTextBox"
        Me.JournalEntryContentTextBox.ReadOnly = True
        Me.JournalEntryContentTextBox.Size = New System.Drawing.Size(299, 20)
        Me.JournalEntryContentTextBox.TabIndex = 73
        Me.JournalEntryContentTextBox.TabStop = False
        '
        'RefreshJournalEntryInfoButton
        '
        Me.RefreshJournalEntryInfoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RefreshJournalEntryInfoButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Button_Reload_icon_16p
        Me.RefreshJournalEntryInfoButton.Location = New System.Drawing.Point(608, 30)
        Me.RefreshJournalEntryInfoButton.Name = "RefreshJournalEntryInfoButton"
        Me.RefreshJournalEntryInfoButton.Size = New System.Drawing.Size(24, 24)
        Me.RefreshJournalEntryInfoButton.TabIndex = 0
        Me.RefreshJournalEntryInfoButton.UseVisualStyleBackColor = True
        '
        'JournalEntryIDTextBox
        '
        Me.JournalEntryIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "JournalEntryID", True))
        Me.JournalEntryIDTextBox.Location = New System.Drawing.Point(142, 7)
        Me.JournalEntryIDTextBox.Name = "JournalEntryIDTextBox"
        Me.JournalEntryIDTextBox.ReadOnly = True
        Me.JournalEntryIDTextBox.Size = New System.Drawing.Size(58, 20)
        Me.JournalEntryIDTextBox.TabIndex = 71
        Me.JournalEntryIDTextBox.TabStop = False
        '
        'JournalEntryInfoComboBox
        '
        Me.JournalEntryInfoComboBox.FormattingEnabled = True
        Me.JournalEntryInfoComboBox.Location = New System.Drawing.Point(142, 33)
        Me.JournalEntryInfoComboBox.Name = "JournalEntryInfoComboBox"
        Me.JournalEntryInfoComboBox.Size = New System.Drawing.Size(461, 21)
        Me.JournalEntryInfoComboBox.TabIndex = 1
        '
        'AttachJournalEntryInfoButton
        '
        Me.AttachJournalEntryInfoButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AttachJournalEntryInfoButton.Location = New System.Drawing.Point(645, 31)
        Me.AttachJournalEntryInfoButton.Name = "AttachJournalEntryInfoButton"
        Me.AttachJournalEntryInfoButton.Size = New System.Drawing.Size(110, 23)
        Me.AttachJournalEntryInfoButton.TabIndex = 2
        Me.AttachJournalEntryInfoButton.Text = "Prijungti BŽ"
        Me.AttachJournalEntryInfoButton.UseVisualStyleBackColor = True
        '
        'JournalEntryDocNumberTextBox
        '
        Me.JournalEntryDocNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "JournalEntryDocNumber", True))
        Me.JournalEntryDocNumberTextBox.Location = New System.Drawing.Point(299, 7)
        Me.JournalEntryDocNumberTextBox.Name = "JournalEntryDocNumberTextBox"
        Me.JournalEntryDocNumberTextBox.ReadOnly = True
        Me.JournalEntryDocNumberTextBox.Size = New System.Drawing.Size(98, 20)
        Me.JournalEntryDocNumberTextBox.TabIndex = 72
        Me.JournalEntryDocNumberTextBox.TabStop = False
        '
        'TypeHumanReadableComboBox
        '
        Me.TypeHumanReadableComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "TypeHumanReadable", True))
        Me.TypeHumanReadableComboBox.FormattingEnabled = True
        Me.TypeHumanReadableComboBox.Location = New System.Drawing.Point(341, 428)
        Me.TypeHumanReadableComboBox.Name = "TypeHumanReadableComboBox"
        Me.TypeHumanReadableComboBox.Size = New System.Drawing.Size(433, 21)
        Me.TypeHumanReadableComboBox.TabIndex = 1
        '
        'ContentTextBox
        '
        Me.ContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "Content", True))
        Me.ContentTextBox.Location = New System.Drawing.Point(149, 482)
        Me.ContentTextBox.Name = "ContentTextBox"
        Me.ContentTextBox.Size = New System.Drawing.Size(625, 20)
        Me.ContentTextBox.TabIndex = 5
        '
        'ActNumberAccBox
        '
        Me.ActNumberAccBox.BackColor = System.Drawing.Color.White
        Me.ActNumberAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "ActNumber", True))
        Me.ActNumberAccBox.DecimalLength = 0
        Me.ActNumberAccBox.KeepBackColorWhenReadOnly = False
        Me.ActNumberAccBox.Location = New System.Drawing.Point(686, 455)
        Me.ActNumberAccBox.Name = "ActNumberAccBox"
        Me.ActNumberAccBox.NegativeValue = False
        Me.ActNumberAccBox.Size = New System.Drawing.Size(88, 20)
        Me.ActNumberAccBox.TabIndex = 4
        Me.ActNumberAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AccountChangeTypeHumanReadableComboBox
        '
        Me.AccountChangeTypeHumanReadableComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "AccountChangeTypeHumanReadable", True))
        Me.AccountChangeTypeHumanReadableComboBox.FormattingEnabled = True
        Me.AccountChangeTypeHumanReadableComboBox.Location = New System.Drawing.Point(149, 455)
        Me.AccountChangeTypeHumanReadableComboBox.Name = "AccountChangeTypeHumanReadableComboBox"
        Me.AccountChangeTypeHumanReadableComboBox.Size = New System.Drawing.Size(219, 21)
        Me.AccountChangeTypeHumanReadableComboBox.TabIndex = 2
        '
        'IDTextBox
        '
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "ID", True))
        Me.IDTextBox.Location = New System.Drawing.Point(524, 374)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(86, 20)
        Me.IDTextBox.TabIndex = 65
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IsComplexActCheckBox
        '
        Me.IsComplexActCheckBox.AutoSize = True
        Me.IsComplexActCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.LongTermAssetOperationBindingSource, "IsComplexAct", True))
        Me.IsComplexActCheckBox.Enabled = False
        Me.IsComplexActCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsComplexActCheckBox.Location = New System.Drawing.Point(499, 402)
        Me.IsComplexActCheckBox.Name = "IsComplexActCheckBox"
        Me.IsComplexActCheckBox.Size = New System.Drawing.Size(128, 17)
        Me.IsComplexActCheckBox.TabIndex = 64
        Me.IsComplexActCheckBox.TabStop = False
        Me.IsComplexActCheckBox.Text = "Kompleksinis dok."
        '
        'DateDateTimePicker
        '
        Me.DateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.LongTermAssetOperationBindingSource, "Date", True))
        Me.DateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDateTimePicker.Location = New System.Drawing.Point(149, 429)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(100, 20)
        Me.DateDateTimePicker.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.CalculateAmortizationButton)
        Me.Panel5.Controls.Add(Me.AmortizationCalculationsButton)
        Me.Panel5.Controls.Add(Me.AmortizationCalculatedForMonthsTextBox)
        Me.Panel5.Controls.Add(Me.CurrentUsageTermMonthsTextBox)
        Me.Panel5.Controls.Add(CurrentUsageTermMonthsLabel)
        Me.Panel5.Controls.Add(Label10)
        Me.Panel5.Controls.Add(AmortizationCalculatedForMonthsLabel)
        Me.Panel5.Location = New System.Drawing.Point(499, 253)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(275, 110)
        Me.Panel5.TabIndex = 6
        '
        'CalculateAmortizationButton
        '
        Me.CalculateAmortizationButton.Enabled = False
        Me.CalculateAmortizationButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalculateAmortizationButton.Location = New System.Drawing.Point(125, 75)
        Me.CalculateAmortizationButton.Name = "CalculateAmortizationButton"
        Me.CalculateAmortizationButton.Size = New System.Drawing.Size(101, 23)
        Me.CalculateAmortizationButton.TabIndex = 1
        Me.CalculateAmortizationButton.Text = "Paskaičiuoti"
        Me.CalculateAmortizationButton.UseVisualStyleBackColor = True
        '
        'AmortizationCalculationsButton
        '
        Me.AmortizationCalculationsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AmortizationCalculationsButton.Location = New System.Drawing.Point(10, 75)
        Me.AmortizationCalculationsButton.Name = "AmortizationCalculationsButton"
        Me.AmortizationCalculationsButton.Size = New System.Drawing.Size(101, 23)
        Me.AmortizationCalculationsButton.TabIndex = 2
        Me.AmortizationCalculationsButton.Text = "Pagrindimas"
        Me.AmortizationCalculationsButton.UseVisualStyleBackColor = True
        '
        'AmortizationCalculatedForMonthsTextBox
        '
        Me.AmortizationCalculatedForMonthsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "AmortizationCalculatedForMonths", True))
        Me.AmortizationCalculatedForMonthsTextBox.Location = New System.Drawing.Point(150, 49)
        Me.AmortizationCalculatedForMonthsTextBox.Name = "AmortizationCalculatedForMonthsTextBox"
        Me.AmortizationCalculatedForMonthsTextBox.ReadOnly = True
        Me.AmortizationCalculatedForMonthsTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AmortizationCalculatedForMonthsTextBox.TabIndex = 63
        Me.AmortizationCalculatedForMonthsTextBox.TabStop = False
        Me.AmortizationCalculatedForMonthsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentUsageTermMonthsTextBox
        '
        Me.CurrentUsageTermMonthsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "CurrentUsageTermMonths", True))
        Me.CurrentUsageTermMonthsTextBox.Location = New System.Drawing.Point(150, 23)
        Me.CurrentUsageTermMonthsTextBox.Name = "CurrentUsageTermMonthsTextBox"
        Me.CurrentUsageTermMonthsTextBox.ReadOnly = True
        Me.CurrentUsageTermMonthsTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentUsageTermMonthsTextBox.TabIndex = 64
        Me.CurrentUsageTermMonthsTextBox.TabStop = False
        Me.CurrentUsageTermMonthsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AfterOperationAssetValueRevaluedPortionAccBox
        '
        Me.AfterOperationAssetValueRevaluedPortionAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AfterOperationAssetValueRevaluedPortion", True))
        Me.AfterOperationAssetValueRevaluedPortionAccBox.KeepBackColorWhenReadOnly = False
        Me.AfterOperationAssetValueRevaluedPortionAccBox.Location = New System.Drawing.Point(378, 377)
        Me.AfterOperationAssetValueRevaluedPortionAccBox.Name = "AfterOperationAssetValueRevaluedPortionAccBox"
        Me.AfterOperationAssetValueRevaluedPortionAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AfterOperationAssetValueRevaluedPortionAccBox.TabIndex = 15
        Me.AfterOperationAssetValueRevaluedPortionAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AfterOperationAssetValueRevaluedPortionPerUnitAccBox
        '
        Me.AfterOperationAssetValueRevaluedPortionPerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AfterOperationAssetValueRevaluedPortionPerUnit", True))
        Me.AfterOperationAssetValueRevaluedPortionPerUnitAccBox.KeepBackColorWhenReadOnly = False
        Me.AfterOperationAssetValueRevaluedPortionPerUnitAccBox.Location = New System.Drawing.Point(378, 351)
        Me.AfterOperationAssetValueRevaluedPortionPerUnitAccBox.Name = "AfterOperationAssetValueRevaluedPortionPerUnitAccBox"
        Me.AfterOperationAssetValueRevaluedPortionPerUnitAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AfterOperationAssetValueRevaluedPortionPerUnitAccBox.TabIndex = 14
        Me.AfterOperationAssetValueRevaluedPortionPerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RevaluedPortionTotalValueChangeAccBox
        '
        Me.RevaluedPortionTotalValueChangeAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "RevaluedPortionTotalValueChange", True))
        Me.RevaluedPortionTotalValueChangeAccBox.KeepBackColorWhenReadOnly = False
        Me.RevaluedPortionTotalValueChangeAccBox.Location = New System.Drawing.Point(256, 377)
        Me.RevaluedPortionTotalValueChangeAccBox.Name = "RevaluedPortionTotalValueChangeAccBox"
        Me.RevaluedPortionTotalValueChangeAccBox.Size = New System.Drawing.Size(100, 20)
        Me.RevaluedPortionTotalValueChangeAccBox.TabIndex = 11
        Me.RevaluedPortionTotalValueChangeAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RevaluedPortionUnitValueChangeAccBox
        '
        Me.RevaluedPortionUnitValueChangeAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "RevaluedPortionUnitValueChange", True))
        Me.RevaluedPortionUnitValueChangeAccBox.KeepBackColorWhenReadOnly = False
        Me.RevaluedPortionUnitValueChangeAccBox.Location = New System.Drawing.Point(256, 351)
        Me.RevaluedPortionUnitValueChangeAccBox.Name = "RevaluedPortionUnitValueChangeAccBox"
        Me.RevaluedPortionUnitValueChangeAccBox.Size = New System.Drawing.Size(100, 20)
        Me.RevaluedPortionUnitValueChangeAccBox.TabIndex = 10
        Me.RevaluedPortionUnitValueChangeAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentAssetValueRevaluedPortionAccBox
        '
        Me.CurrentAssetValueRevaluedPortionAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "CurrentAssetValueRevaluedPortion", True))
        Me.CurrentAssetValueRevaluedPortionAccBox.KeepBackColorWhenReadOnly = False
        Me.CurrentAssetValueRevaluedPortionAccBox.Location = New System.Drawing.Point(150, 377)
        Me.CurrentAssetValueRevaluedPortionAccBox.Name = "CurrentAssetValueRevaluedPortionAccBox"
        Me.CurrentAssetValueRevaluedPortionAccBox.NegativeValue = False
        Me.CurrentAssetValueRevaluedPortionAccBox.ReadOnly = True
        Me.CurrentAssetValueRevaluedPortionAccBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentAssetValueRevaluedPortionAccBox.TabIndex = 57
        Me.CurrentAssetValueRevaluedPortionAccBox.TabStop = False
        Me.CurrentAssetValueRevaluedPortionAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentAssetValueRevaluedPortionPerUnitAccBox
        '
        Me.CurrentAssetValueRevaluedPortionPerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "CurrentAssetValueRevaluedPortionPerUnit", True))
        Me.CurrentAssetValueRevaluedPortionPerUnitAccBox.KeepBackColorWhenReadOnly = False
        Me.CurrentAssetValueRevaluedPortionPerUnitAccBox.Location = New System.Drawing.Point(150, 351)
        Me.CurrentAssetValueRevaluedPortionPerUnitAccBox.Name = "CurrentAssetValueRevaluedPortionPerUnitAccBox"
        Me.CurrentAssetValueRevaluedPortionPerUnitAccBox.NegativeValue = False
        Me.CurrentAssetValueRevaluedPortionPerUnitAccBox.ReadOnly = True
        Me.CurrentAssetValueRevaluedPortionPerUnitAccBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentAssetValueRevaluedPortionPerUnitAccBox.TabIndex = 56
        Me.CurrentAssetValueRevaluedPortionPerUnitAccBox.TabStop = False
        Me.CurrentAssetValueRevaluedPortionPerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NewAmortizationPeriodAccBox
        '
        Me.NewAmortizationPeriodAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "NewAmortizationPeriod", True))
        Me.NewAmortizationPeriodAccBox.DecimalLength = 0
        Me.NewAmortizationPeriodAccBox.KeepBackColorWhenReadOnly = False
        Me.NewAmortizationPeriodAccBox.Location = New System.Drawing.Point(378, 403)
        Me.NewAmortizationPeriodAccBox.Name = "NewAmortizationPeriodAccBox"
        Me.NewAmortizationPeriodAccBox.NegativeValue = False
        Me.NewAmortizationPeriodAccBox.Size = New System.Drawing.Size(100, 20)
        Me.NewAmortizationPeriodAccBox.TabIndex = 16
        Me.NewAmortizationPeriodAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AfterOperationAssetValueAccBox
        '
        Me.AfterOperationAssetValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AfterOperationAssetValue", True))
        Me.AfterOperationAssetValueAccBox.KeepBackColorWhenReadOnly = False
        Me.AfterOperationAssetValueAccBox.Location = New System.Drawing.Point(378, 325)
        Me.AfterOperationAssetValueAccBox.Name = "AfterOperationAssetValueAccBox"
        Me.AfterOperationAssetValueAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AfterOperationAssetValueAccBox.TabIndex = 13
        Me.AfterOperationAssetValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AfterOperationAssetAmmountAccBox
        '
        Me.AfterOperationAssetAmmountAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AfterOperationAssetAmmount", True))
        Me.AfterOperationAssetAmmountAccBox.DecimalLength = 0
        Me.AfterOperationAssetAmmountAccBox.KeepBackColorWhenReadOnly = False
        Me.AfterOperationAssetAmmountAccBox.Location = New System.Drawing.Point(378, 299)
        Me.AfterOperationAssetAmmountAccBox.Name = "AfterOperationAssetAmmountAccBox"
        Me.AfterOperationAssetAmmountAccBox.NegativeValue = False
        Me.AfterOperationAssetAmmountAccBox.ReadOnly = True
        Me.AfterOperationAssetAmmountAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AfterOperationAssetAmmountAccBox.TabIndex = 52
        Me.AfterOperationAssetAmmountAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AfterOperationAssetValuePerUnitAccBox
        '
        Me.AfterOperationAssetValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AfterOperationAssetValuePerUnit", True))
        Me.AfterOperationAssetValuePerUnitAccBox.KeepBackColorWhenReadOnly = False
        Me.AfterOperationAssetValuePerUnitAccBox.Location = New System.Drawing.Point(378, 273)
        Me.AfterOperationAssetValuePerUnitAccBox.Name = "AfterOperationAssetValuePerUnitAccBox"
        Me.AfterOperationAssetValuePerUnitAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AfterOperationAssetValuePerUnitAccBox.TabIndex = 12
        Me.AfterOperationAssetValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AmmountChangeAccBox
        '
        Me.AmmountChangeAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AmmountChange", True))
        Me.AmmountChangeAccBox.DecimalLength = 0
        Me.AmmountChangeAccBox.KeepBackColorWhenReadOnly = False
        Me.AmmountChangeAccBox.Location = New System.Drawing.Point(256, 299)
        Me.AmmountChangeAccBox.Name = "AmmountChangeAccBox"
        Me.AmmountChangeAccBox.NegativeValue = False
        Me.AmmountChangeAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AmmountChangeAccBox.TabIndex = 8
        Me.AmmountChangeAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TotalValueChangeAccBox
        '
        Me.TotalValueChangeAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "TotalValueChange", True))
        Me.TotalValueChangeAccBox.KeepBackColorWhenReadOnly = False
        Me.TotalValueChangeAccBox.Location = New System.Drawing.Point(256, 325)
        Me.TotalValueChangeAccBox.Name = "TotalValueChangeAccBox"
        Me.TotalValueChangeAccBox.Size = New System.Drawing.Size(100, 20)
        Me.TotalValueChangeAccBox.TabIndex = 9
        Me.TotalValueChangeAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'UnitValueChangeAccBox
        '
        Me.UnitValueChangeAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "UnitValueChange", True))
        Me.UnitValueChangeAccBox.KeepBackColorWhenReadOnly = False
        Me.UnitValueChangeAccBox.Location = New System.Drawing.Point(256, 273)
        Me.UnitValueChangeAccBox.Name = "UnitValueChangeAccBox"
        Me.UnitValueChangeAccBox.Size = New System.Drawing.Size(100, 20)
        Me.UnitValueChangeAccBox.TabIndex = 7
        Me.UnitValueChangeAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentAmortizationPeriodTextBox
        '
        Me.CurrentAmortizationPeriodTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "CurrentAmortizationPeriod", True))
        Me.CurrentAmortizationPeriodTextBox.Location = New System.Drawing.Point(150, 403)
        Me.CurrentAmortizationPeriodTextBox.Name = "CurrentAmortizationPeriodTextBox"
        Me.CurrentAmortizationPeriodTextBox.ReadOnly = True
        Me.CurrentAmortizationPeriodTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentAmortizationPeriodTextBox.TabIndex = 45
        Me.CurrentAmortizationPeriodTextBox.TabStop = False
        Me.CurrentAmortizationPeriodTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentAssetValueAccBox
        '
        Me.CurrentAssetValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "CurrentAssetValue", True))
        Me.CurrentAssetValueAccBox.KeepBackColorWhenReadOnly = False
        Me.CurrentAssetValueAccBox.Location = New System.Drawing.Point(150, 325)
        Me.CurrentAssetValueAccBox.Name = "CurrentAssetValueAccBox"
        Me.CurrentAssetValueAccBox.NegativeValue = False
        Me.CurrentAssetValueAccBox.ReadOnly = True
        Me.CurrentAssetValueAccBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentAssetValueAccBox.TabIndex = 44
        Me.CurrentAssetValueAccBox.TabStop = False
        Me.CurrentAssetValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentAssetAmmountTextBox
        '
        Me.CurrentAssetAmmountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "CurrentAssetAmmount", True))
        Me.CurrentAssetAmmountTextBox.Location = New System.Drawing.Point(150, 299)
        Me.CurrentAssetAmmountTextBox.Name = "CurrentAssetAmmountTextBox"
        Me.CurrentAssetAmmountTextBox.ReadOnly = True
        Me.CurrentAssetAmmountTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentAssetAmmountTextBox.TabIndex = 43
        Me.CurrentAssetAmmountTextBox.TabStop = False
        Me.CurrentAssetAmmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentAssetValuePerUnitAccBox
        '
        Me.CurrentAssetValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "CurrentAssetValuePerUnit", True))
        Me.CurrentAssetValuePerUnitAccBox.KeepBackColorWhenReadOnly = False
        Me.CurrentAssetValuePerUnitAccBox.Location = New System.Drawing.Point(150, 273)
        Me.CurrentAssetValuePerUnitAccBox.Name = "CurrentAssetValuePerUnitAccBox"
        Me.CurrentAssetValuePerUnitAccBox.NegativeValue = False
        Me.CurrentAssetValuePerUnitAccBox.ReadOnly = True
        Me.CurrentAssetValuePerUnitAccBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentAssetValuePerUnitAccBox.TabIndex = 42
        Me.CurrentAssetValuePerUnitAccBox.TabStop = False
        Me.CurrentAssetValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.AssetAcquiredAccountTextBox)
        Me.Panel4.Controls.Add(Label6)
        Me.Panel4.Controls.Add(AssetAcquiredAccountLabel)
        Me.Panel4.Controls.Add(Me.AfterOperationValueIncreaseAmortizationAccountValuePerUnitAccBox)
        Me.Panel4.Controls.Add(Me.AssetContraryAccountTextBox)
        Me.Panel4.Controls.Add(Me.AfterOperationValueIncreaseAccountValuePerUnitAccBox)
        Me.Panel4.Controls.Add(AssetContraryAccountLabel)
        Me.Panel4.Controls.Add(Me.AfterOperationValueDecreaseAccountValuePerUnitAccBox)
        Me.Panel4.Controls.Add(Me.AssetValueDecreaseAccountTextBox)
        Me.Panel4.Controls.Add(Me.AfterOperationAmortizationAccountValuePerUnitAccBox)
        Me.Panel4.Controls.Add(AssetValueDecreaseAccountLabel)
        Me.Panel4.Controls.Add(Me.AfterOperationAcquisitionAccountValuePerUnitAccBox)
        Me.Panel4.Controls.Add(Me.AssetValueIncreaseAccountTextBox)
        Me.Panel4.Controls.Add(Label5)
        Me.Panel4.Controls.Add(AssetValueIncreaseAccountLabel)
        Me.Panel4.Controls.Add(Me.AfterOperationValueIncreaseAmortizationAccountValueAccBox)
        Me.Panel4.Controls.Add(Me.AssetValueIncreaseAmortizationAccountTextBox)
        Me.Panel4.Controls.Add(Me.AfterOperationValueIncreaseAccountValueAccBox)
        Me.Panel4.Controls.Add(AssetValueIncreaseAmortizationAccountLabel)
        Me.Panel4.Controls.Add(Me.AfterOperationValueDecreaseAccountValueAccBox)
        Me.Panel4.Controls.Add(Label1)
        Me.Panel4.Controls.Add(Me.AfterOperationAmortizationAccountValueAccBox)
        Me.Panel4.Controls.Add(Me.CurrentAcquisitionAccountValueAccBox)
        Me.Panel4.Controls.Add(Me.AfterOperationAcquisitionAccountValueAccBox)
        Me.Panel4.Controls.Add(Me.CurrentAmortizationAccountValueAccBox)
        Me.Panel4.Controls.Add(Label3)
        Me.Panel4.Controls.Add(Me.CurrentValueDecreaseAccountValueAccBox)
        Me.Panel4.Controls.Add(Me.CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox)
        Me.Panel4.Controls.Add(Me.CurrentValueIncreaseAccountValueAccBox)
        Me.Panel4.Controls.Add(Me.CurrentValueIncreaseAccountValuePerUnitAccBox)
        Me.Panel4.Controls.Add(Me.CurrentValueIncreaseAmortizationAccountValueAccBox)
        Me.Panel4.Controls.Add(Me.CurrentValueDecreaseAccountValuePerUnitAccBox)
        Me.Panel4.Controls.Add(Label2)
        Me.Panel4.Controls.Add(Me.CurrentAmortizationAccountValuePerUnitAccBox)
        Me.Panel4.Controls.Add(Me.CurrentAcquisitionAccountValuePerUnitAccBox)
        Me.Panel4.Location = New System.Drawing.Point(5, 95)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(769, 152)
        Me.Panel4.TabIndex = 1
        '
        'AssetAcquiredAccountTextBox
        '
        Me.AssetAcquiredAccountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "AssetAcquiredAccount", True))
        Me.AssetAcquiredAccountTextBox.Location = New System.Drawing.Point(143, 21)
        Me.AssetAcquiredAccountTextBox.Name = "AssetAcquiredAccountTextBox"
        Me.AssetAcquiredAccountTextBox.ReadOnly = True
        Me.AssetAcquiredAccountTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AssetAcquiredAccountTextBox.TabIndex = 9
        Me.AssetAcquiredAccountTextBox.TabStop = False
        Me.AssetAcquiredAccountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AfterOperationValueIncreaseAmortizationAccountValuePerUnitAccBox
        '
        Me.AfterOperationValueIncreaseAmortizationAccountValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AfterOperationValueIncreaseAmortizationAccountValuePerUnit", True))
        Me.AfterOperationValueIncreaseAmortizationAccountValuePerUnitAccBox.DecimalLength = 4
        Me.AfterOperationValueIncreaseAmortizationAccountValuePerUnitAccBox.KeepBackColorWhenReadOnly = False
        Me.AfterOperationValueIncreaseAmortizationAccountValuePerUnitAccBox.Location = New System.Drawing.Point(612, 125)
        Me.AfterOperationValueIncreaseAmortizationAccountValuePerUnitAccBox.Name = "AfterOperationValueIncreaseAmortizationAccountValuePerUnitAccBox"
        Me.AfterOperationValueIncreaseAmortizationAccountValuePerUnitAccBox.ReadOnly = True
        Me.AfterOperationValueIncreaseAmortizationAccountValuePerUnitAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AfterOperationValueIncreaseAmortizationAccountValuePerUnitAccBox.TabIndex = 39
        Me.AfterOperationValueIncreaseAmortizationAccountValuePerUnitAccBox.TabStop = False
        Me.AfterOperationValueIncreaseAmortizationAccountValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AssetContraryAccountTextBox
        '
        Me.AssetContraryAccountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "AssetContraryAccount", True))
        Me.AssetContraryAccountTextBox.Location = New System.Drawing.Point(143, 47)
        Me.AssetContraryAccountTextBox.Name = "AssetContraryAccountTextBox"
        Me.AssetContraryAccountTextBox.ReadOnly = True
        Me.AssetContraryAccountTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AssetContraryAccountTextBox.TabIndex = 10
        Me.AssetContraryAccountTextBox.TabStop = False
        Me.AssetContraryAccountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AfterOperationValueIncreaseAccountValuePerUnitAccBox
        '
        Me.AfterOperationValueIncreaseAccountValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AfterOperationValueIncreaseAccountValuePerUnit", True))
        Me.AfterOperationValueIncreaseAccountValuePerUnitAccBox.DecimalLength = 4
        Me.AfterOperationValueIncreaseAccountValuePerUnitAccBox.KeepBackColorWhenReadOnly = False
        Me.AfterOperationValueIncreaseAccountValuePerUnitAccBox.Location = New System.Drawing.Point(612, 99)
        Me.AfterOperationValueIncreaseAccountValuePerUnitAccBox.Name = "AfterOperationValueIncreaseAccountValuePerUnitAccBox"
        Me.AfterOperationValueIncreaseAccountValuePerUnitAccBox.ReadOnly = True
        Me.AfterOperationValueIncreaseAccountValuePerUnitAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AfterOperationValueIncreaseAccountValuePerUnitAccBox.TabIndex = 38
        Me.AfterOperationValueIncreaseAccountValuePerUnitAccBox.TabStop = False
        Me.AfterOperationValueIncreaseAccountValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AfterOperationValueDecreaseAccountValuePerUnitAccBox
        '
        Me.AfterOperationValueDecreaseAccountValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AfterOperationValueDecreaseAccountValuePerUnit", True))
        Me.AfterOperationValueDecreaseAccountValuePerUnitAccBox.DecimalLength = 4
        Me.AfterOperationValueDecreaseAccountValuePerUnitAccBox.KeepBackColorWhenReadOnly = False
        Me.AfterOperationValueDecreaseAccountValuePerUnitAccBox.Location = New System.Drawing.Point(612, 73)
        Me.AfterOperationValueDecreaseAccountValuePerUnitAccBox.Name = "AfterOperationValueDecreaseAccountValuePerUnitAccBox"
        Me.AfterOperationValueDecreaseAccountValuePerUnitAccBox.ReadOnly = True
        Me.AfterOperationValueDecreaseAccountValuePerUnitAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AfterOperationValueDecreaseAccountValuePerUnitAccBox.TabIndex = 37
        Me.AfterOperationValueDecreaseAccountValuePerUnitAccBox.TabStop = False
        Me.AfterOperationValueDecreaseAccountValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AssetValueDecreaseAccountTextBox
        '
        Me.AssetValueDecreaseAccountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "AssetValueDecreaseAccount", True))
        Me.AssetValueDecreaseAccountTextBox.Location = New System.Drawing.Point(143, 73)
        Me.AssetValueDecreaseAccountTextBox.Name = "AssetValueDecreaseAccountTextBox"
        Me.AssetValueDecreaseAccountTextBox.ReadOnly = True
        Me.AssetValueDecreaseAccountTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AssetValueDecreaseAccountTextBox.TabIndex = 11
        Me.AssetValueDecreaseAccountTextBox.TabStop = False
        Me.AssetValueDecreaseAccountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AfterOperationAmortizationAccountValuePerUnitAccBox
        '
        Me.AfterOperationAmortizationAccountValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AfterOperationAmortizationAccountValuePerUnit", True))
        Me.AfterOperationAmortizationAccountValuePerUnitAccBox.DecimalLength = 4
        Me.AfterOperationAmortizationAccountValuePerUnitAccBox.KeepBackColorWhenReadOnly = False
        Me.AfterOperationAmortizationAccountValuePerUnitAccBox.Location = New System.Drawing.Point(612, 47)
        Me.AfterOperationAmortizationAccountValuePerUnitAccBox.Name = "AfterOperationAmortizationAccountValuePerUnitAccBox"
        Me.AfterOperationAmortizationAccountValuePerUnitAccBox.ReadOnly = True
        Me.AfterOperationAmortizationAccountValuePerUnitAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AfterOperationAmortizationAccountValuePerUnitAccBox.TabIndex = 36
        Me.AfterOperationAmortizationAccountValuePerUnitAccBox.TabStop = False
        Me.AfterOperationAmortizationAccountValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AfterOperationAcquisitionAccountValuePerUnitAccBox
        '
        Me.AfterOperationAcquisitionAccountValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AfterOperationAcquisitionAccountValuePerUnit", True))
        Me.AfterOperationAcquisitionAccountValuePerUnitAccBox.DecimalLength = 4
        Me.AfterOperationAcquisitionAccountValuePerUnitAccBox.KeepBackColorWhenReadOnly = False
        Me.AfterOperationAcquisitionAccountValuePerUnitAccBox.Location = New System.Drawing.Point(612, 21)
        Me.AfterOperationAcquisitionAccountValuePerUnitAccBox.Name = "AfterOperationAcquisitionAccountValuePerUnitAccBox"
        Me.AfterOperationAcquisitionAccountValuePerUnitAccBox.ReadOnly = True
        Me.AfterOperationAcquisitionAccountValuePerUnitAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AfterOperationAcquisitionAccountValuePerUnitAccBox.TabIndex = 35
        Me.AfterOperationAcquisitionAccountValuePerUnitAccBox.TabStop = False
        Me.AfterOperationAcquisitionAccountValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AssetValueIncreaseAccountTextBox
        '
        Me.AssetValueIncreaseAccountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "AssetValueIncreaseAccount", True))
        Me.AssetValueIncreaseAccountTextBox.Location = New System.Drawing.Point(143, 99)
        Me.AssetValueIncreaseAccountTextBox.Name = "AssetValueIncreaseAccountTextBox"
        Me.AssetValueIncreaseAccountTextBox.ReadOnly = True
        Me.AssetValueIncreaseAccountTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AssetValueIncreaseAccountTextBox.TabIndex = 12
        Me.AssetValueIncreaseAccountTextBox.TabStop = False
        Me.AssetValueIncreaseAccountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AfterOperationValueIncreaseAmortizationAccountValueAccBox
        '
        Me.AfterOperationValueIncreaseAmortizationAccountValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AfterOperationValueIncreaseAmortizationAccountValue", True))
        Me.AfterOperationValueIncreaseAmortizationAccountValueAccBox.KeepBackColorWhenReadOnly = False
        Me.AfterOperationValueIncreaseAmortizationAccountValueAccBox.Location = New System.Drawing.Point(505, 125)
        Me.AfterOperationValueIncreaseAmortizationAccountValueAccBox.Name = "AfterOperationValueIncreaseAmortizationAccountValueAccBox"
        Me.AfterOperationValueIncreaseAmortizationAccountValueAccBox.ReadOnly = True
        Me.AfterOperationValueIncreaseAmortizationAccountValueAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AfterOperationValueIncreaseAmortizationAccountValueAccBox.TabIndex = 33
        Me.AfterOperationValueIncreaseAmortizationAccountValueAccBox.TabStop = False
        Me.AfterOperationValueIncreaseAmortizationAccountValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AssetValueIncreaseAmortizationAccountTextBox
        '
        Me.AssetValueIncreaseAmortizationAccountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "AssetValueIncreaseAmortizationAccount", True))
        Me.AssetValueIncreaseAmortizationAccountTextBox.Location = New System.Drawing.Point(143, 125)
        Me.AssetValueIncreaseAmortizationAccountTextBox.Name = "AssetValueIncreaseAmortizationAccountTextBox"
        Me.AssetValueIncreaseAmortizationAccountTextBox.ReadOnly = True
        Me.AssetValueIncreaseAmortizationAccountTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AssetValueIncreaseAmortizationAccountTextBox.TabIndex = 13
        Me.AssetValueIncreaseAmortizationAccountTextBox.TabStop = False
        Me.AssetValueIncreaseAmortizationAccountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AfterOperationValueIncreaseAccountValueAccBox
        '
        Me.AfterOperationValueIncreaseAccountValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AfterOperationValueIncreaseAccountValue", True))
        Me.AfterOperationValueIncreaseAccountValueAccBox.KeepBackColorWhenReadOnly = False
        Me.AfterOperationValueIncreaseAccountValueAccBox.Location = New System.Drawing.Point(506, 99)
        Me.AfterOperationValueIncreaseAccountValueAccBox.Name = "AfterOperationValueIncreaseAccountValueAccBox"
        Me.AfterOperationValueIncreaseAccountValueAccBox.ReadOnly = True
        Me.AfterOperationValueIncreaseAccountValueAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AfterOperationValueIncreaseAccountValueAccBox.TabIndex = 32
        Me.AfterOperationValueIncreaseAccountValueAccBox.TabStop = False
        Me.AfterOperationValueIncreaseAccountValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AfterOperationValueDecreaseAccountValueAccBox
        '
        Me.AfterOperationValueDecreaseAccountValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AfterOperationValueDecreaseAccountValue", True))
        Me.AfterOperationValueDecreaseAccountValueAccBox.KeepBackColorWhenReadOnly = False
        Me.AfterOperationValueDecreaseAccountValueAccBox.Location = New System.Drawing.Point(506, 73)
        Me.AfterOperationValueDecreaseAccountValueAccBox.Name = "AfterOperationValueDecreaseAccountValueAccBox"
        Me.AfterOperationValueDecreaseAccountValueAccBox.ReadOnly = True
        Me.AfterOperationValueDecreaseAccountValueAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AfterOperationValueDecreaseAccountValueAccBox.TabIndex = 31
        Me.AfterOperationValueDecreaseAccountValueAccBox.TabStop = False
        Me.AfterOperationValueDecreaseAccountValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AfterOperationAmortizationAccountValueAccBox
        '
        Me.AfterOperationAmortizationAccountValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AfterOperationAmortizationAccountValue", True))
        Me.AfterOperationAmortizationAccountValueAccBox.KeepBackColorWhenReadOnly = False
        Me.AfterOperationAmortizationAccountValueAccBox.Location = New System.Drawing.Point(506, 47)
        Me.AfterOperationAmortizationAccountValueAccBox.Name = "AfterOperationAmortizationAccountValueAccBox"
        Me.AfterOperationAmortizationAccountValueAccBox.ReadOnly = True
        Me.AfterOperationAmortizationAccountValueAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AfterOperationAmortizationAccountValueAccBox.TabIndex = 30
        Me.AfterOperationAmortizationAccountValueAccBox.TabStop = False
        Me.AfterOperationAmortizationAccountValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentAcquisitionAccountValueAccBox
        '
        Me.CurrentAcquisitionAccountValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "CurrentAcquisitionAccountValue", True))
        Me.CurrentAcquisitionAccountValueAccBox.KeepBackColorWhenReadOnly = False
        Me.CurrentAcquisitionAccountValueAccBox.Location = New System.Drawing.Point(266, 21)
        Me.CurrentAcquisitionAccountValueAccBox.Name = "CurrentAcquisitionAccountValueAccBox"
        Me.CurrentAcquisitionAccountValueAccBox.NegativeValue = False
        Me.CurrentAcquisitionAccountValueAccBox.ReadOnly = True
        Me.CurrentAcquisitionAccountValueAccBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentAcquisitionAccountValueAccBox.TabIndex = 15
        Me.CurrentAcquisitionAccountValueAccBox.TabStop = False
        Me.CurrentAcquisitionAccountValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AfterOperationAcquisitionAccountValueAccBox
        '
        Me.AfterOperationAcquisitionAccountValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AfterOperationAcquisitionAccountValue", True))
        Me.AfterOperationAcquisitionAccountValueAccBox.KeepBackColorWhenReadOnly = False
        Me.AfterOperationAcquisitionAccountValueAccBox.Location = New System.Drawing.Point(505, 21)
        Me.AfterOperationAcquisitionAccountValueAccBox.Name = "AfterOperationAcquisitionAccountValueAccBox"
        Me.AfterOperationAcquisitionAccountValueAccBox.ReadOnly = True
        Me.AfterOperationAcquisitionAccountValueAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AfterOperationAcquisitionAccountValueAccBox.TabIndex = 29
        Me.AfterOperationAcquisitionAccountValueAccBox.TabStop = False
        Me.AfterOperationAcquisitionAccountValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentAmortizationAccountValueAccBox
        '
        Me.CurrentAmortizationAccountValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "CurrentAmortizationAccountValue", True))
        Me.CurrentAmortizationAccountValueAccBox.KeepBackColorWhenReadOnly = False
        Me.CurrentAmortizationAccountValueAccBox.Location = New System.Drawing.Point(266, 47)
        Me.CurrentAmortizationAccountValueAccBox.Name = "CurrentAmortizationAccountValueAccBox"
        Me.CurrentAmortizationAccountValueAccBox.NegativeValue = False
        Me.CurrentAmortizationAccountValueAccBox.ReadOnly = True
        Me.CurrentAmortizationAccountValueAccBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentAmortizationAccountValueAccBox.TabIndex = 16
        Me.CurrentAmortizationAccountValueAccBox.TabStop = False
        Me.CurrentAmortizationAccountValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentValueDecreaseAccountValueAccBox
        '
        Me.CurrentValueDecreaseAccountValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "CurrentValueDecreaseAccountValue", True))
        Me.CurrentValueDecreaseAccountValueAccBox.KeepBackColorWhenReadOnly = False
        Me.CurrentValueDecreaseAccountValueAccBox.Location = New System.Drawing.Point(266, 73)
        Me.CurrentValueDecreaseAccountValueAccBox.Name = "CurrentValueDecreaseAccountValueAccBox"
        Me.CurrentValueDecreaseAccountValueAccBox.NegativeValue = False
        Me.CurrentValueDecreaseAccountValueAccBox.ReadOnly = True
        Me.CurrentValueDecreaseAccountValueAccBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentValueDecreaseAccountValueAccBox.TabIndex = 17
        Me.CurrentValueDecreaseAccountValueAccBox.TabStop = False
        Me.CurrentValueDecreaseAccountValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox
        '
        Me.CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "CurrentValueIncreaseAmortizationAccountValuePerUnit", True))
        Me.CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox.DecimalLength = 4
        Me.CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox.KeepBackColorWhenReadOnly = False
        Me.CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox.Location = New System.Drawing.Point(372, 125)
        Me.CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox.Name = "CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox"
        Me.CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox.NegativeValue = False
        Me.CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox.ReadOnly = True
        Me.CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox.TabIndex = 27
        Me.CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox.TabStop = False
        Me.CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentValueIncreaseAccountValueAccBox
        '
        Me.CurrentValueIncreaseAccountValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "CurrentValueIncreaseAccountValue", True))
        Me.CurrentValueIncreaseAccountValueAccBox.KeepBackColorWhenReadOnly = False
        Me.CurrentValueIncreaseAccountValueAccBox.Location = New System.Drawing.Point(266, 99)
        Me.CurrentValueIncreaseAccountValueAccBox.Name = "CurrentValueIncreaseAccountValueAccBox"
        Me.CurrentValueIncreaseAccountValueAccBox.NegativeValue = False
        Me.CurrentValueIncreaseAccountValueAccBox.ReadOnly = True
        Me.CurrentValueIncreaseAccountValueAccBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentValueIncreaseAccountValueAccBox.TabIndex = 19
        Me.CurrentValueIncreaseAccountValueAccBox.TabStop = False
        Me.CurrentValueIncreaseAccountValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentValueIncreaseAccountValuePerUnitAccBox
        '
        Me.CurrentValueIncreaseAccountValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "CurrentValueIncreaseAccountValuePerUnit", True))
        Me.CurrentValueIncreaseAccountValuePerUnitAccBox.DecimalLength = 4
        Me.CurrentValueIncreaseAccountValuePerUnitAccBox.KeepBackColorWhenReadOnly = False
        Me.CurrentValueIncreaseAccountValuePerUnitAccBox.Location = New System.Drawing.Point(372, 99)
        Me.CurrentValueIncreaseAccountValuePerUnitAccBox.Name = "CurrentValueIncreaseAccountValuePerUnitAccBox"
        Me.CurrentValueIncreaseAccountValuePerUnitAccBox.NegativeValue = False
        Me.CurrentValueIncreaseAccountValuePerUnitAccBox.ReadOnly = True
        Me.CurrentValueIncreaseAccountValuePerUnitAccBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentValueIncreaseAccountValuePerUnitAccBox.TabIndex = 26
        Me.CurrentValueIncreaseAccountValuePerUnitAccBox.TabStop = False
        Me.CurrentValueIncreaseAccountValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentValueIncreaseAmortizationAccountValueAccBox
        '
        Me.CurrentValueIncreaseAmortizationAccountValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "CurrentValueIncreaseAmortizationAccountValue", True))
        Me.CurrentValueIncreaseAmortizationAccountValueAccBox.KeepBackColorWhenReadOnly = False
        Me.CurrentValueIncreaseAmortizationAccountValueAccBox.Location = New System.Drawing.Point(266, 125)
        Me.CurrentValueIncreaseAmortizationAccountValueAccBox.Name = "CurrentValueIncreaseAmortizationAccountValueAccBox"
        Me.CurrentValueIncreaseAmortizationAccountValueAccBox.NegativeValue = False
        Me.CurrentValueIncreaseAmortizationAccountValueAccBox.ReadOnly = True
        Me.CurrentValueIncreaseAmortizationAccountValueAccBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentValueIncreaseAmortizationAccountValueAccBox.TabIndex = 21
        Me.CurrentValueIncreaseAmortizationAccountValueAccBox.TabStop = False
        Me.CurrentValueIncreaseAmortizationAccountValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentValueDecreaseAccountValuePerUnitAccBox
        '
        Me.CurrentValueDecreaseAccountValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "CurrentValueDecreaseAccountValuePerUnit", True))
        Me.CurrentValueDecreaseAccountValuePerUnitAccBox.DecimalLength = 4
        Me.CurrentValueDecreaseAccountValuePerUnitAccBox.KeepBackColorWhenReadOnly = False
        Me.CurrentValueDecreaseAccountValuePerUnitAccBox.Location = New System.Drawing.Point(372, 73)
        Me.CurrentValueDecreaseAccountValuePerUnitAccBox.Name = "CurrentValueDecreaseAccountValuePerUnitAccBox"
        Me.CurrentValueDecreaseAccountValuePerUnitAccBox.NegativeValue = False
        Me.CurrentValueDecreaseAccountValuePerUnitAccBox.ReadOnly = True
        Me.CurrentValueDecreaseAccountValuePerUnitAccBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentValueDecreaseAccountValuePerUnitAccBox.TabIndex = 25
        Me.CurrentValueDecreaseAccountValuePerUnitAccBox.TabStop = False
        Me.CurrentValueDecreaseAccountValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentAmortizationAccountValuePerUnitAccBox
        '
        Me.CurrentAmortizationAccountValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "CurrentAmortizationAccountValuePerUnit", True))
        Me.CurrentAmortizationAccountValuePerUnitAccBox.DecimalLength = 4
        Me.CurrentAmortizationAccountValuePerUnitAccBox.KeepBackColorWhenReadOnly = False
        Me.CurrentAmortizationAccountValuePerUnitAccBox.Location = New System.Drawing.Point(372, 47)
        Me.CurrentAmortizationAccountValuePerUnitAccBox.Name = "CurrentAmortizationAccountValuePerUnitAccBox"
        Me.CurrentAmortizationAccountValuePerUnitAccBox.NegativeValue = False
        Me.CurrentAmortizationAccountValuePerUnitAccBox.ReadOnly = True
        Me.CurrentAmortizationAccountValuePerUnitAccBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentAmortizationAccountValuePerUnitAccBox.TabIndex = 24
        Me.CurrentAmortizationAccountValuePerUnitAccBox.TabStop = False
        Me.CurrentAmortizationAccountValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentAcquisitionAccountValuePerUnitAccBox
        '
        Me.CurrentAcquisitionAccountValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "CurrentAcquisitionAccountValuePerUnit", True))
        Me.CurrentAcquisitionAccountValuePerUnitAccBox.DecimalLength = 4
        Me.CurrentAcquisitionAccountValuePerUnitAccBox.KeepBackColorWhenReadOnly = False
        Me.CurrentAcquisitionAccountValuePerUnitAccBox.Location = New System.Drawing.Point(372, 21)
        Me.CurrentAcquisitionAccountValuePerUnitAccBox.Name = "CurrentAcquisitionAccountValuePerUnitAccBox"
        Me.CurrentAcquisitionAccountValuePerUnitAccBox.NegativeValue = False
        Me.CurrentAcquisitionAccountValuePerUnitAccBox.ReadOnly = True
        Me.CurrentAcquisitionAccountValuePerUnitAccBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentAcquisitionAccountValuePerUnitAccBox.TabIndex = 23
        Me.CurrentAcquisitionAccountValuePerUnitAccBox.TabStop = False
        Me.CurrentAcquisitionAccountValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel3
        '
        Me.Panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel3.BackColor = System.Drawing.SystemColors.Info
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.CurrentUsageStatusCheckBox)
        Me.Panel3.Controls.Add(Me.AssetNameTextBox)
        Me.Panel3.Controls.Add(AssetMeasureUnitLabel)
        Me.Panel3.Controls.Add(AssetNameLabel)
        Me.Panel3.Controls.Add(AssetLiquidationValueLabel)
        Me.Panel3.Controls.Add(Me.AssetMeasureUnitTextBox)
        Me.Panel3.Controls.Add(Me.AssetLiquidationValueAccBox)
        Me.Panel3.Controls.Add(Me.AssetIDTextBox)
        Me.Panel3.Controls.Add(AssetAquisitionOpIDLabel)
        Me.Panel3.Controls.Add(AssetIDLabel)
        Me.Panel3.Controls.Add(Me.AssetAquisitionOpIDTextBox)
        Me.Panel3.Controls.Add(Me.AssetDateAcquiredDateTimePicker)
        Me.Panel3.Controls.Add(AssetDateAcquiredLabel)
        Me.Panel3.Location = New System.Drawing.Point(5, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(769, 86)
        Me.Panel3.TabIndex = 0
        '
        'CurrentUsageStatusCheckBox
        '
        Me.CurrentUsageStatusCheckBox.AutoSize = True
        Me.CurrentUsageStatusCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.LongTermAssetOperationBindingSource, "CurrentUsageStatus", True))
        Me.CurrentUsageStatusCheckBox.Enabled = False
        Me.CurrentUsageStatusCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentUsageStatusCheckBox.Location = New System.Drawing.Point(143, 60)
        Me.CurrentUsageStatusCheckBox.Name = "CurrentUsageStatusCheckBox"
        Me.CurrentUsageStatusCheckBox.Size = New System.Drawing.Size(147, 17)
        Me.CurrentUsageStatusCheckBox.TabIndex = 12
        Me.CurrentUsageStatusCheckBox.TabStop = False
        Me.CurrentUsageStatusCheckBox.Text = "Naudojama šiuo metu"
        '
        'AssetNameTextBox
        '
        Me.AssetNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "AssetName", True))
        Me.AssetNameTextBox.Location = New System.Drawing.Point(141, 5)
        Me.AssetNameTextBox.Name = "AssetNameTextBox"
        Me.AssetNameTextBox.ReadOnly = True
        Me.AssetNameTextBox.Size = New System.Drawing.Size(569, 20)
        Me.AssetNameTextBox.TabIndex = 7
        Me.AssetNameTextBox.TabStop = False
        '
        'AssetMeasureUnitTextBox
        '
        Me.AssetMeasureUnitTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "AssetMeasureUnit", True))
        Me.AssetMeasureUnitTextBox.Location = New System.Drawing.Point(610, 30)
        Me.AssetMeasureUnitTextBox.Name = "AssetMeasureUnitTextBox"
        Me.AssetMeasureUnitTextBox.ReadOnly = True
        Me.AssetMeasureUnitTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AssetMeasureUnitTextBox.TabIndex = 5
        Me.AssetMeasureUnitTextBox.TabStop = False
        Me.AssetMeasureUnitTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AssetLiquidationValueAccBox
        '
        Me.AssetLiquidationValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationBindingSource, "AssetLiquidationValue", True))
        Me.AssetLiquidationValueAccBox.Location = New System.Drawing.Point(610, 57)
        Me.AssetLiquidationValueAccBox.Name = "AssetLiquidationValueAccBox"
        Me.AssetLiquidationValueAccBox.NegativeValue = False
        Me.AssetLiquidationValueAccBox.ReadOnly = True
        Me.AssetLiquidationValueAccBox.Size = New System.Drawing.Size(100, 20)
        Me.AssetLiquidationValueAccBox.TabIndex = 11
        Me.AssetLiquidationValueAccBox.TabStop = False
        Me.AssetLiquidationValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AssetIDTextBox
        '
        Me.AssetIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "AssetID", True))
        Me.AssetIDTextBox.Location = New System.Drawing.Point(141, 31)
        Me.AssetIDTextBox.Name = "AssetIDTextBox"
        Me.AssetIDTextBox.ReadOnly = True
        Me.AssetIDTextBox.Size = New System.Drawing.Size(58, 20)
        Me.AssetIDTextBox.TabIndex = 3
        Me.AssetIDTextBox.TabStop = False
        Me.AssetIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AssetAquisitionOpIDTextBox
        '
        Me.AssetAquisitionOpIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationBindingSource, "AssetAquisitionOpID", True))
        Me.AssetAquisitionOpIDTextBox.Location = New System.Drawing.Point(476, 30)
        Me.AssetAquisitionOpIDTextBox.Name = "AssetAquisitionOpIDTextBox"
        Me.AssetAquisitionOpIDTextBox.ReadOnly = True
        Me.AssetAquisitionOpIDTextBox.Size = New System.Drawing.Size(63, 20)
        Me.AssetAquisitionOpIDTextBox.TabIndex = 1
        Me.AssetAquisitionOpIDTextBox.TabStop = False
        Me.AssetAquisitionOpIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AssetDateAcquiredDateTimePicker
        '
        Me.AssetDateAcquiredDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.LongTermAssetOperationBindingSource, "AssetDateAcquired", True))
        Me.AssetDateAcquiredDateTimePicker.Enabled = False
        Me.AssetDateAcquiredDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.AssetDateAcquiredDateTimePicker.Location = New System.Drawing.Point(275, 30)
        Me.AssetDateAcquiredDateTimePicker.Name = "AssetDateAcquiredDateTimePicker"
        Me.AssetDateAcquiredDateTimePicker.Size = New System.Drawing.Size(100, 20)
        Me.AssetDateAcquiredDateTimePicker.TabIndex = 10
        Me.AssetDateAcquiredDateTimePicker.TabStop = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.DataSource = Me.LongTermAssetOperationBindingSource
        '
        'F_LongTermAssetOperation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.ClientSize = New System.Drawing.Size(794, 624)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_LongTermAssetOperation"
        Me.ShowInTaskbar = False
        Me.Text = "Operacija su ilgalaikiu turtu"
        Me.Panel2.ResumeLayout(False)
        Me.EditedBaner.ResumeLayout(False)
        Me.EditedBaner.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.LongTermAssetOperationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents EditedBaner As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NewItemButton As System.Windows.Forms.Button
    Friend WithEvents CancelButton As System.Windows.Forms.Button
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents AssetNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LongTermAssetOperationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssetMeasureUnitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AssetIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AssetAquisitionOpIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AssetLiquidationValueAccBox As AccControls.AccTextBox
    Friend WithEvents AssetDateAcquiredDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CurrentUsageStatusCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CurrentValueDecreaseAccountValueAccBox As AccControls.AccTextBox
    Friend WithEvents CurrentAmortizationAccountValueAccBox As AccControls.AccTextBox
    Friend WithEvents CurrentAcquisitionAccountValueAccBox As AccControls.AccTextBox
    Friend WithEvents AssetValueIncreaseAmortizationAccountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AssetValueIncreaseAccountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AssetValueDecreaseAccountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AssetContraryAccountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AssetAcquiredAccountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AfterOperationAmortizationAccountValueAccBox As AccControls.AccTextBox
    Friend WithEvents AfterOperationAcquisitionAccountValueAccBox As AccControls.AccTextBox
    Friend WithEvents CurrentValueIncreaseAmortizationAccountValuePerUnitAccBox As AccControls.AccTextBox
    Friend WithEvents CurrentValueIncreaseAccountValuePerUnitAccBox As AccControls.AccTextBox
    Friend WithEvents CurrentValueDecreaseAccountValuePerUnitAccBox As AccControls.AccTextBox
    Friend WithEvents CurrentAmortizationAccountValuePerUnitAccBox As AccControls.AccTextBox
    Friend WithEvents CurrentAcquisitionAccountValuePerUnitAccBox As AccControls.AccTextBox
    Friend WithEvents CurrentValueIncreaseAmortizationAccountValueAccBox As AccControls.AccTextBox
    Friend WithEvents CurrentValueIncreaseAccountValueAccBox As AccControls.AccTextBox
    Friend WithEvents AfterOperationValueIncreaseAmortizationAccountValuePerUnitAccBox As AccControls.AccTextBox
    Friend WithEvents AfterOperationValueIncreaseAccountValuePerUnitAccBox As AccControls.AccTextBox
    Friend WithEvents AfterOperationValueDecreaseAccountValuePerUnitAccBox As AccControls.AccTextBox
    Friend WithEvents AfterOperationAmortizationAccountValuePerUnitAccBox As AccControls.AccTextBox
    Friend WithEvents AfterOperationAcquisitionAccountValuePerUnitAccBox As AccControls.AccTextBox
    Friend WithEvents AfterOperationValueIncreaseAmortizationAccountValueAccBox As AccControls.AccTextBox
    Friend WithEvents AfterOperationValueIncreaseAccountValueAccBox As AccControls.AccTextBox
    Friend WithEvents AfterOperationValueDecreaseAccountValueAccBox As AccControls.AccTextBox
    Friend WithEvents CurrentAmortizationPeriodTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CurrentAssetValueAccBox As AccControls.AccTextBox
    Friend WithEvents CurrentAssetAmmountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CurrentAssetValuePerUnitAccBox As AccControls.AccTextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents NewAmortizationPeriodAccBox As AccControls.AccTextBox
    Friend WithEvents AfterOperationAssetValueAccBox As AccControls.AccTextBox
    Friend WithEvents AfterOperationAssetAmmountAccBox As AccControls.AccTextBox
    Friend WithEvents AfterOperationAssetValuePerUnitAccBox As AccControls.AccTextBox
    Friend WithEvents AmmountChangeAccBox As AccControls.AccTextBox
    Friend WithEvents TotalValueChangeAccBox As AccControls.AccTextBox
    Friend WithEvents UnitValueChangeAccBox As AccControls.AccTextBox
    Friend WithEvents AfterOperationAssetValueRevaluedPortionAccBox As AccControls.AccTextBox
    Friend WithEvents AfterOperationAssetValueRevaluedPortionPerUnitAccBox As AccControls.AccTextBox
    Friend WithEvents RevaluedPortionTotalValueChangeAccBox As AccControls.AccTextBox
    Friend WithEvents RevaluedPortionUnitValueChangeAccBox As AccControls.AccTextBox
    Friend WithEvents CurrentAssetValueRevaluedPortionAccBox As AccControls.AccTextBox
    Friend WithEvents CurrentAssetValueRevaluedPortionPerUnitAccBox As AccControls.AccTextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents AmortizationCalculationsButton As System.Windows.Forms.Button
    Friend WithEvents AmortizationCalculatedForMonthsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CurrentUsageTermMonthsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CalculateAmortizationButton As System.Windows.Forms.Button
    Friend WithEvents IsComplexActCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents DateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ActNumberAccBox As AccControls.AccTextBox
    Friend WithEvents AccountChangeTypeHumanReadableComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TypeHumanReadableComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents JournalEntryInfoComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents AttachJournalEntryInfoButton As System.Windows.Forms.Button
    Friend WithEvents JournalEntryIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents JournalEntryDocNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents JournalEntryContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RefreshJournalEntryInfoButton As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents AccountCorrespondingAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents LimitationsButton As System.Windows.Forms.Button
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
End Class
