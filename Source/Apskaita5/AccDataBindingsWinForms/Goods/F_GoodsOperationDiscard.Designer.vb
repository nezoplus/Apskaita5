﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_GoodsOperationDiscard
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
        Dim ComplexOperationIDLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim MeasureUnitLabel As System.Windows.Forms.Label
        Dim AccountingMethodHumanReadableLabel As System.Windows.Forms.Label
        Dim JournalEntryIDLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim DocumentNumberLabel As System.Windows.Forms.Label
        Dim AccountGoodsDiscardCostsLabel As System.Windows.Forms.Label
        Dim AmmountLabel As System.Windows.Forms.Label
        Dim UnitCostLabel As System.Windows.Forms.Label
        Dim TotalCostLabel As System.Windows.Forms.Label
        Dim WarehouseLabel As System.Windows.Forms.Label
        Dim DescriptionLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_GoodsOperationDiscard))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox
        Me.GoodsOperationDiscardBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel
        Me.RefreshCostsInfoButton = New System.Windows.Forms.Button
        Me.TotalCostAccTextBox = New AccControlsWinForms.AccTextBox
        Me.AmmountAccTextBox = New AccControlsWinForms.AccTextBox
        Me.UnitCostAccTextBox = New AccControlsWinForms.AccTextBox
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.MeasureUnitTextBox = New System.Windows.Forms.TextBox
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.WarehouseAccGridComboBox = New AccControlsWinForms.AccListComboBox
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel
        Me.AccountGoodsDiscardCostsAccGridComboBox = New AccControlsWinForms.AccListComboBox
        Me.DocumentNumberTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel
        Me.JournalEntryIDTextBox = New System.Windows.Forms.TextBox
        Me.AccountingMethodHumanReadableTextBox = New System.Windows.Forms.TextBox
        Me.ValuationMethodHumanReadableTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.ComplexOperationIDTextBox = New System.Windows.Forms.TextBox
        Me.ComplexOperationHumanReadableTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button
        Me.UpdateDateTextBox = New System.Windows.Forms.TextBox
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.InsertDateTextBox = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.EditedBaner = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.nCancelButton = New System.Windows.Forms.Button
        Me.ApplyButton = New System.Windows.Forms.Button
        Me.nOkButton = New System.Windows.Forms.Button
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        Me.ErrorWarnInfoProvider1 = New AccControlsWinForms.ErrorWarnInfoProvider(Me.components)
        Me.DateAccDatePicker = New AccControlsWinForms.AccDatePicker
        IDLabel = New System.Windows.Forms.Label
        InsertDateLabel = New System.Windows.Forms.Label
        UpdateDateLabel = New System.Windows.Forms.Label
        ComplexOperationIDLabel = New System.Windows.Forms.Label
        NameLabel = New System.Windows.Forms.Label
        MeasureUnitLabel = New System.Windows.Forms.Label
        AccountingMethodHumanReadableLabel = New System.Windows.Forms.Label
        JournalEntryIDLabel = New System.Windows.Forms.Label
        DateLabel = New System.Windows.Forms.Label
        DocumentNumberLabel = New System.Windows.Forms.Label
        AccountGoodsDiscardCostsLabel = New System.Windows.Forms.Label
        AmmountLabel = New System.Windows.Forms.Label
        UnitCostLabel = New System.Windows.Forms.Label
        TotalCostLabel = New System.Windows.Forms.Label
        WarehouseLabel = New System.Windows.Forms.Label
        DescriptionLabel = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        CType(Me.GoodsOperationDiscardBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.EditedBaner.SuspendLayout()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IDLabel
        '
        IDLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(117, 6)
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
        InsertDateLabel.Location = New System.Drawing.Point(153, 3)
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
        UpdateDateLabel.Location = New System.Drawing.Point(381, 3)
        UpdateDateLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        UpdateDateLabel.Name = "UpdateDateLabel"
        UpdateDateLabel.Size = New System.Drawing.Size(60, 13)
        UpdateDateLabel.TabIndex = 8
        UpdateDateLabel.Text = "Pakeista:"
        '
        'ComplexOperationIDLabel
        '
        ComplexOperationIDLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ComplexOperationIDLabel.AutoSize = True
        ComplexOperationIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ComplexOperationIDLabel.Location = New System.Drawing.Point(3, 36)
        ComplexOperationIDLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        ComplexOperationIDLabel.Name = "ComplexOperationIDLabel"
        ComplexOperationIDLabel.Size = New System.Drawing.Size(138, 13)
        ComplexOperationIDLabel.TabIndex = 4
        ComplexOperationIDLabel.Text = "Kompleksinė operacija:"
        '
        'NameLabel
        '
        NameLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        NameLabel.AutoSize = True
        NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameLabel.Location = New System.Drawing.Point(91, 66)
        NameLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(50, 13)
        NameLabel.TabIndex = 4
        NameLabel.Text = "Prekės:"
        '
        'MeasureUnitLabel
        '
        MeasureUnitLabel.AutoSize = True
        MeasureUnitLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        MeasureUnitLabel.Location = New System.Drawing.Point(375, 3)
        MeasureUnitLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        MeasureUnitLabel.Name = "MeasureUnitLabel"
        MeasureUnitLabel.Size = New System.Drawing.Size(66, 13)
        MeasureUnitLabel.TabIndex = 6
        MeasureUnitLabel.Text = "Mato Vnt.:"
        '
        'AccountingMethodHumanReadableLabel
        '
        AccountingMethodHumanReadableLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        AccountingMethodHumanReadableLabel.AutoSize = True
        AccountingMethodHumanReadableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountingMethodHumanReadableLabel.Location = New System.Drawing.Point(26, 96)
        AccountingMethodHumanReadableLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        AccountingMethodHumanReadableLabel.Name = "AccountingMethodHumanReadableLabel"
        AccountingMethodHumanReadableLabel.Size = New System.Drawing.Size(115, 13)
        AccountingMethodHumanReadableLabel.TabIndex = 6
        AccountingMethodHumanReadableLabel.Text = "Apskaitos Metodai:"
        '
        'JournalEntryIDLabel
        '
        JournalEntryIDLabel.AutoSize = True
        JournalEntryIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        JournalEntryIDLabel.Location = New System.Drawing.Point(389, 3)
        JournalEntryIDLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        JournalEntryIDLabel.Name = "JournalEntryIDLabel"
        JournalEntryIDLabel.Size = New System.Drawing.Size(44, 13)
        JournalEntryIDLabel.TabIndex = 4
        JournalEntryIDLabel.Text = "BŽ ID:"
        '
        'DateLabel
        '
        DateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DateLabel.AutoSize = True
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(103, 126)
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
        DocumentNumberLabel.Location = New System.Drawing.Point(153, 3)
        DocumentNumberLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        DocumentNumberLabel.Name = "DocumentNumberLabel"
        DocumentNumberLabel.Size = New System.Drawing.Size(59, 13)
        DocumentNumberLabel.TabIndex = 6
        DocumentNumberLabel.Text = "Dok. Nr.:"
        '
        'AccountGoodsDiscardCostsLabel
        '
        AccountGoodsDiscardCostsLabel.AutoSize = True
        AccountGoodsDiscardCostsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountGoodsDiscardCostsLabel.Location = New System.Drawing.Point(368, 3)
        AccountGoodsDiscardCostsLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        AccountGoodsDiscardCostsLabel.Name = "AccountGoodsDiscardCostsLabel"
        AccountGoodsDiscardCostsLabel.Size = New System.Drawing.Size(97, 13)
        AccountGoodsDiscardCostsLabel.TabIndex = 8
        AccountGoodsDiscardCostsLabel.Text = "Sąnaudų Sąsk.:"
        '
        'AmmountLabel
        '
        AmmountLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        AmmountLabel.AutoSize = True
        AmmountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AmmountLabel.Location = New System.Drawing.Point(96, 186)
        AmmountLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        AmmountLabel.Name = "AmmountLabel"
        AmmountLabel.Size = New System.Drawing.Size(45, 13)
        AmmountLabel.TabIndex = 4
        AmmountLabel.Text = "Kiekis:"
        '
        'UnitCostLabel
        '
        UnitCostLabel.AutoSize = True
        UnitCostLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UnitCostLabel.Location = New System.Drawing.Point(134, 3)
        UnitCostLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        UnitCostLabel.Name = "UnitCostLabel"
        UnitCostLabel.Size = New System.Drawing.Size(94, 13)
        UnitCostLabel.TabIndex = 6
        UnitCostLabel.Text = "Savikaina Vnt.:"
        '
        'TotalCostLabel
        '
        TotalCostLabel.AutoSize = True
        TotalCostLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TotalCostLabel.Location = New System.Drawing.Point(389, 3)
        TotalCostLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        TotalCostLabel.Name = "TotalCostLabel"
        TotalCostLabel.Size = New System.Drawing.Size(95, 13)
        TotalCostLabel.TabIndex = 8
        TotalCostLabel.Text = "Savikaina Viso:"
        '
        'WarehouseLabel
        '
        WarehouseLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        WarehouseLabel.AutoSize = True
        WarehouseLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        WarehouseLabel.Location = New System.Drawing.Point(82, 156)
        WarehouseLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        WarehouseLabel.Name = "WarehouseLabel"
        WarehouseLabel.Size = New System.Drawing.Size(59, 13)
        WarehouseLabel.TabIndex = 5
        WarehouseLabel.Text = "Sandėlis:"
        '
        'DescriptionLabel
        '
        DescriptionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DescriptionLabel.AutoSize = True
        DescriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DescriptionLabel.Location = New System.Drawing.Point(35, 216)
        DescriptionLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        DescriptionLabel.Name = "DescriptionLabel"
        DescriptionLabel.Size = New System.Drawing.Size(106, 13)
        DescriptionLabel.TabIndex = 7
        DescriptionLabel.Text = "Oper. Aprašymas:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel9, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(DescriptionLabel, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel8, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel7, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel6, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(WarehouseLabel, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(AccountingMethodHumanReadableLabel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(DateLabel, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(NameLabel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(ComplexOperationIDLabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(AmmountLabel, 0, 6)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 9
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(763, 260)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 2
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.DescriptionTextBox, 0, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(144, 213)
        Me.TableLayoutPanel9.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(619, 24)
        Me.TableLayoutPanel9.TabIndex = 7
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscardBindingSource, "Description", True))
        Me.DescriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DescriptionTextBox.Location = New System.Drawing.Point(2, 1)
        Me.DescriptionTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.DescriptionTextBox.MaxLength = 255
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.Size = New System.Drawing.Size(595, 20)
        Me.DescriptionTextBox.TabIndex = 0
        '
        'GoodsOperationDiscardBindingSource
        '
        Me.GoodsOperationDiscardBindingSource.DataSource = GetType(ApskaitaObjects.Goods.GoodsOperationDiscard)
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 9
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.RefreshCostsInfoButton, 3, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.TotalCostAccTextBox, 7, 0)
        Me.TableLayoutPanel8.Controls.Add(TotalCostLabel, 6, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.AmmountAccTextBox, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(UnitCostLabel, 2, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.UnitCostAccTextBox, 4, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(144, 183)
        Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(619, 24)
        Me.TableLayoutPanel8.TabIndex = 6
        '
        'RefreshCostsInfoButton
        '
        Me.RefreshCostsInfoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RefreshCostsInfoButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Button_Reload_icon_16p
        Me.RefreshCostsInfoButton.Location = New System.Drawing.Point(231, 0)
        Me.RefreshCostsInfoButton.Margin = New System.Windows.Forms.Padding(0)
        Me.RefreshCostsInfoButton.Name = "RefreshCostsInfoButton"
        Me.RefreshCostsInfoButton.Size = New System.Drawing.Size(24, 24)
        Me.RefreshCostsInfoButton.TabIndex = 1
        Me.RefreshCostsInfoButton.UseVisualStyleBackColor = True
        '
        'TotalCostAccTextBox
        '
        Me.TotalCostAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.GoodsOperationDiscardBindingSource, "TotalCost", True))
        Me.TotalCostAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TotalCostAccTextBox.Location = New System.Drawing.Point(489, 1)
        Me.TotalCostAccTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.TotalCostAccTextBox.Name = "TotalCostAccTextBox"
        Me.TotalCostAccTextBox.ReadOnly = True
        Me.TotalCostAccTextBox.Size = New System.Drawing.Size(107, 20)
        Me.TotalCostAccTextBox.TabIndex = 9
        Me.TotalCostAccTextBox.TabStop = False
        Me.TotalCostAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AmmountAccTextBox
        '
        Me.AmmountAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.GoodsOperationDiscardBindingSource, "Ammount", True))
        Me.AmmountAccTextBox.DecimalLength = 6
        Me.AmmountAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AmmountAccTextBox.Location = New System.Drawing.Point(2, 1)
        Me.AmmountAccTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.AmmountAccTextBox.Name = "AmmountAccTextBox"
        Me.AmmountAccTextBox.Size = New System.Drawing.Size(107, 20)
        Me.AmmountAccTextBox.TabIndex = 0
        Me.AmmountAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'UnitCostAccTextBox
        '
        Me.UnitCostAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.GoodsOperationDiscardBindingSource, "UnitCost", True))
        Me.UnitCostAccTextBox.DecimalLength = 6
        Me.UnitCostAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UnitCostAccTextBox.Location = New System.Drawing.Point(257, 1)
        Me.UnitCostAccTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.UnitCostAccTextBox.Name = "UnitCostAccTextBox"
        Me.UnitCostAccTextBox.ReadOnly = True
        Me.UnitCostAccTextBox.Size = New System.Drawing.Size(107, 20)
        Me.UnitCostAccTextBox.TabIndex = 7
        Me.UnitCostAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 5
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.MeasureUnitTextBox, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(MeasureUnitLabel, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.NameTextBox, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(144, 63)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(619, 24)
        Me.TableLayoutPanel5.TabIndex = 2
        '
        'MeasureUnitTextBox
        '
        Me.MeasureUnitTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscardBindingSource, "GoodsInfo.MeasureUnit", True))
        Me.MeasureUnitTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MeasureUnitTextBox.Location = New System.Drawing.Point(446, 1)
        Me.MeasureUnitTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.MeasureUnitTextBox.Name = "MeasureUnitTextBox"
        Me.MeasureUnitTextBox.ReadOnly = True
        Me.MeasureUnitTextBox.Size = New System.Drawing.Size(146, 20)
        Me.MeasureUnitTextBox.TabIndex = 7
        Me.MeasureUnitTextBox.TabStop = False
        Me.MeasureUnitTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NameTextBox
        '
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscardBindingSource, "GoodsInfo.Name", True))
        Me.NameTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NameTextBox.Location = New System.Drawing.Point(2, 1)
        Me.NameTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.ReadOnly = True
        Me.NameTextBox.Size = New System.Drawing.Size(348, 20)
        Me.NameTextBox.TabIndex = 5
        Me.NameTextBox.TabStop = False
        Me.NameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.WarehouseAccGridComboBox, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(144, 153)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(619, 24)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'WarehouseAccGridComboBox
        '
        Me.WarehouseAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.GoodsOperationDiscardBindingSource, "Warehouse", True))
        Me.WarehouseAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WarehouseAccGridComboBox.EmptyValueString = ""
        Me.WarehouseAccGridComboBox.InstantBinding = True
        Me.WarehouseAccGridComboBox.Location = New System.Drawing.Point(2, 1)
        Me.WarehouseAccGridComboBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.WarehouseAccGridComboBox.Name = "WarehouseAccGridComboBox"
        Me.WarehouseAccGridComboBox.Size = New System.Drawing.Size(595, 21)
        Me.WarehouseAccGridComboBox.TabIndex = 0
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.AutoScroll = True
        Me.TableLayoutPanel7.ColumnCount = 8
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.AccountGoodsDiscardCostsAccGridComboBox, 6, 0)
        Me.TableLayoutPanel7.Controls.Add(AccountGoodsDiscardCostsLabel, 5, 0)
        Me.TableLayoutPanel7.Controls.Add(DocumentNumberLabel, 2, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.DocumentNumberTextBox, 3, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.DateAccDatePicker, 0, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(144, 123)
        Me.TableLayoutPanel7.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(619, 24)
        Me.TableLayoutPanel7.TabIndex = 4
        '
        'AccountGoodsDiscardCostsAccGridComboBox
        '
        Me.AccountGoodsDiscardCostsAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.GoodsOperationDiscardBindingSource, "AccountGoodsDiscardCosts", True))
        Me.AccountGoodsDiscardCostsAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountGoodsDiscardCostsAccGridComboBox.EmptyValueString = ""
        Me.AccountGoodsDiscardCostsAccGridComboBox.InstantBinding = True
        Me.AccountGoodsDiscardCostsAccGridComboBox.Location = New System.Drawing.Point(470, 1)
        Me.AccountGoodsDiscardCostsAccGridComboBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.AccountGoodsDiscardCostsAccGridComboBox.Name = "AccountGoodsDiscardCostsAccGridComboBox"
        Me.AccountGoodsDiscardCostsAccGridComboBox.Size = New System.Drawing.Size(126, 21)
        Me.AccountGoodsDiscardCostsAccGridComboBox.TabIndex = 2
        '
        'DocumentNumberTextBox
        '
        Me.DocumentNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscardBindingSource, "DocumentNumber", True))
        Me.DocumentNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentNumberTextBox.Location = New System.Drawing.Point(217, 1)
        Me.DocumentNumberTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.DocumentNumberTextBox.MaxLength = 50
        Me.DocumentNumberTextBox.Name = "DocumentNumberTextBox"
        Me.DocumentNumberTextBox.Size = New System.Drawing.Size(126, 20)
        Me.DocumentNumberTextBox.TabIndex = 1
        Me.DocumentNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 6
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.JournalEntryIDTextBox, 4, 0)
        Me.TableLayoutPanel6.Controls.Add(JournalEntryIDLabel, 3, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.AccountingMethodHumanReadableTextBox, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.ValuationMethodHumanReadableTextBox, 1, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(144, 93)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(619, 24)
        Me.TableLayoutPanel6.TabIndex = 3
        '
        'JournalEntryIDTextBox
        '
        Me.JournalEntryIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscardBindingSource, "JournalEntryID", True))
        Me.JournalEntryIDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JournalEntryIDTextBox.Location = New System.Drawing.Point(438, 1)
        Me.JournalEntryIDTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.JournalEntryIDTextBox.Name = "JournalEntryIDTextBox"
        Me.JournalEntryIDTextBox.ReadOnly = True
        Me.JournalEntryIDTextBox.Size = New System.Drawing.Size(152, 20)
        Me.JournalEntryIDTextBox.TabIndex = 5
        Me.JournalEntryIDTextBox.TabStop = False
        Me.JournalEntryIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AccountingMethodHumanReadableTextBox
        '
        Me.AccountingMethodHumanReadableTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscardBindingSource, "GoodsInfo.AccountingMethodHumanReadable", True))
        Me.AccountingMethodHumanReadableTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountingMethodHumanReadableTextBox.Location = New System.Drawing.Point(2, 1)
        Me.AccountingMethodHumanReadableTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.AccountingMethodHumanReadableTextBox.Name = "AccountingMethodHumanReadableTextBox"
        Me.AccountingMethodHumanReadableTextBox.ReadOnly = True
        Me.AccountingMethodHumanReadableTextBox.Size = New System.Drawing.Size(179, 20)
        Me.AccountingMethodHumanReadableTextBox.TabIndex = 7
        Me.AccountingMethodHumanReadableTextBox.TabStop = False
        Me.AccountingMethodHumanReadableTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ValuationMethodHumanReadableTextBox
        '
        Me.ValuationMethodHumanReadableTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscardBindingSource, "GoodsInfo.ValuationMethodHumanReadable", True))
        Me.ValuationMethodHumanReadableTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ValuationMethodHumanReadableTextBox.Location = New System.Drawing.Point(185, 1)
        Me.ValuationMethodHumanReadableTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.ValuationMethodHumanReadableTextBox.Name = "ValuationMethodHumanReadableTextBox"
        Me.ValuationMethodHumanReadableTextBox.ReadOnly = True
        Me.ValuationMethodHumanReadableTextBox.Size = New System.Drawing.Size(179, 20)
        Me.ValuationMethodHumanReadableTextBox.TabIndex = 5
        Me.ValuationMethodHumanReadableTextBox.TabStop = False
        Me.ValuationMethodHumanReadableTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.ComplexOperationIDTextBox, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.ComplexOperationHumanReadableTextBox, 2, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(144, 33)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(619, 24)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'ComplexOperationIDTextBox
        '
        Me.ComplexOperationIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscardBindingSource, "ComplexOperationID", True))
        Me.ComplexOperationIDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComplexOperationIDTextBox.Location = New System.Drawing.Point(2, 1)
        Me.ComplexOperationIDTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.ComplexOperationIDTextBox.Name = "ComplexOperationIDTextBox"
        Me.ComplexOperationIDTextBox.ReadOnly = True
        Me.ComplexOperationIDTextBox.Size = New System.Drawing.Size(168, 20)
        Me.ComplexOperationIDTextBox.TabIndex = 5
        Me.ComplexOperationIDTextBox.TabStop = False
        Me.ComplexOperationIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComplexOperationHumanReadableTextBox
        '
        Me.ComplexOperationHumanReadableTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscardBindingSource, "ComplexOperationHumanReadable", True))
        Me.ComplexOperationHumanReadableTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComplexOperationHumanReadableTextBox.Location = New System.Drawing.Point(194, 1)
        Me.ComplexOperationHumanReadableTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.ComplexOperationHumanReadableTextBox.Name = "ComplexOperationHumanReadableTextBox"
        Me.ComplexOperationHumanReadableTextBox.ReadOnly = True
        Me.ComplexOperationHumanReadableTextBox.Size = New System.Drawing.Size(398, 20)
        Me.ComplexOperationHumanReadableTextBox.TabIndex = 7
        Me.ComplexOperationHumanReadableTextBox.TabStop = False
        Me.ComplexOperationHumanReadableTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.ViewJournalEntryButton, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.UpdateDateTextBox, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(UpdateDateLabel, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.IDTextBox, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(InsertDateLabel, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.InsertDateTextBox, 3, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(144, 3)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(619, 24)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(126, 0)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 91
        Me.ViewJournalEntryButton.TabStop = False
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = True
        '
        'UpdateDateTextBox
        '
        Me.UpdateDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscardBindingSource, "UpdateDate", True))
        Me.UpdateDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UpdateDateTextBox.Location = New System.Drawing.Point(446, 1)
        Me.UpdateDateTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.UpdateDateTextBox.Name = "UpdateDateTextBox"
        Me.UpdateDateTextBox.ReadOnly = True
        Me.UpdateDateTextBox.Size = New System.Drawing.Size(143, 20)
        Me.UpdateDateTextBox.TabIndex = 9
        Me.UpdateDateTextBox.TabStop = False
        Me.UpdateDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IDTextBox
        '
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscardBindingSource, "ID", True))
        Me.IDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IDTextBox.Location = New System.Drawing.Point(2, 1)
        Me.IDTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(122, 20)
        Me.IDTextBox.TabIndex = 6
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'InsertDateTextBox
        '
        Me.InsertDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscardBindingSource, "InsertDate", True))
        Me.InsertDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InsertDateTextBox.Location = New System.Drawing.Point(213, 1)
        Me.InsertDateTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.InsertDateTextBox.Name = "InsertDateTextBox"
        Me.InsertDateTextBox.ReadOnly = True
        Me.InsertDateTextBox.Size = New System.Drawing.Size(143, 20)
        Me.InsertDateTextBox.TabIndex = 7
        Me.InsertDateTextBox.TabStop = False
        Me.InsertDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.EditedBaner)
        Me.Panel2.Controls.Add(Me.nCancelButton)
        Me.Panel2.Controls.Add(Me.ApplyButton)
        Me.Panel2.Controls.Add(Me.nOkButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 260)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Panel2.Size = New System.Drawing.Size(763, 43)
        Me.Panel2.TabIndex = 1
        '
        'EditedBaner
        '
        Me.EditedBaner.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditedBaner.BackColor = System.Drawing.Color.Red
        Me.EditedBaner.Controls.Add(Me.Label4)
        Me.EditedBaner.Location = New System.Drawing.Point(412, 11)
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
        'nCancelButton
        '
        Me.nCancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.nCancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nCancelButton.Location = New System.Drawing.Point(676, 13)
        Me.nCancelButton.Name = "nCancelButton"
        Me.nCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.nCancelButton.TabIndex = 3
        Me.nCancelButton.Text = "Atšaukti"
        Me.nCancelButton.UseVisualStyleBackColor = True
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyButton.Location = New System.Drawing.Point(595, 13)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(75, 23)
        Me.ApplyButton.TabIndex = 2
        Me.ApplyButton.Text = "Taikyti"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'nOkButton
        '
        Me.nOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nOkButton.Location = New System.Drawing.Point(514, 13)
        Me.nOkButton.Name = "nOkButton"
        Me.nOkButton.Size = New System.Drawing.Size(75, 23)
        Me.nOkButton.TabIndex = 1
        Me.nOkButton.Text = "OK"
        Me.nOkButton.UseVisualStyleBackColor = True
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(397, 43)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(179, 58)
        Me.ProgressFiller1.TabIndex = 2
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(140, 29)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(184, 71)
        Me.ProgressFiller2.TabIndex = 3
        Me.ProgressFiller2.Visible = False
        '
        'ErrorWarnInfoProvider1
        '
        Me.ErrorWarnInfoProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleInformation = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleWarning = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.ContainerControl = Me
        Me.ErrorWarnInfoProvider1.DataSource = Me.GoodsOperationDiscardBindingSource
        '
        'DateAccDatePicker
        '
        Me.DateAccDatePicker.BoldedDates = Nothing
        Me.DateAccDatePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.GoodsOperationDiscardBindingSource, "Date", True))
        Me.DateAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateAccDatePicker.Location = New System.Drawing.Point(0, 0)
        Me.DateAccDatePicker.Margin = New System.Windows.Forms.Padding(0)
        Me.DateAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateAccDatePicker.Name = "DateAccDatePicker"
        Me.DateAccDatePicker.ReadOnly = False
        Me.DateAccDatePicker.ShowWeekNumbers = True
        Me.DateAccDatePicker.Size = New System.Drawing.Size(130, 24)
        Me.DateAccDatePicker.TabIndex = 0
        '
        'F_GoodsOperationDiscard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 303)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_GoodsOperationDiscard"
        Me.ShowInTaskbar = False
        Me.Text = "Prekių Nurašymas"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        CType(Me.GoodsOperationDiscardBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.EditedBaner.ResumeLayout(False)
        Me.EditedBaner.PerformLayout()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UpdateDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GoodsOperationDiscardBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InsertDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ComplexOperationIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ComplexOperationHumanReadableTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents MeasureUnitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents JournalEntryIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AccountingMethodHumanReadableTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ValuationMethodHumanReadableTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents AccountGoodsDiscardCostsAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents DocumentNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TotalCostAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents AmmountAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents UnitCostAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents WarehouseAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RefreshCostsInfoButton As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents EditedBaner As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nCancelButton As System.Windows.Forms.Button
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents nOkButton As System.Windows.Forms.Button
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ErrorWarnInfoProvider1 As AccControlsWinForms.ErrorWarnInfoProvider
    Friend WithEvents DateAccDatePicker As AccControlsWinForms.AccDatePicker
End Class
