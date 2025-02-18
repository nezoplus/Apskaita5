﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_TillSpendingsOrder
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
        Dim AccountLabel As System.Windows.Forms.Label
        Dim AccountCurrencyLabel As System.Windows.Forms.Label
        Dim AccountCurrencyRateChangeImpactLabel As System.Windows.Forms.Label
        Dim AdditionalContentLabel As System.Windows.Forms.Label
        Dim AttachmentsDescriptionLabel As System.Windows.Forms.Label
        Dim ContentLabel As System.Windows.Forms.Label
        Dim CurrencyRateChangeImpactLabel As System.Windows.Forms.Label
        Dim CurrencyRateInAccountLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim DocumentNumberLabel As System.Windows.Forms.Label
        Dim DocumentSerialLabel As System.Windows.Forms.Label
        Dim FullDocumentNumberLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim ReceiverLabel As System.Windows.Forms.Label
        Dim ReceiversRepresentativeLabel As System.Windows.Forms.Label
        Dim SumLabel As System.Windows.Forms.Label
        Dim SumCorespondencesLabel As System.Windows.Forms.Label
        Dim SumLTLLabel As System.Windows.Forms.Label
        Dim AdvanceReportIDLabel As System.Windows.Forms.Label
        Dim AdvanceReportDescriptionLabel As System.Windows.Forms.Label
        Dim InsertDateLabel As System.Windows.Forms.Label
        Dim UpdateDateLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_TillSpendingsOrder))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.OpenAdvanceReportButton = New System.Windows.Forms.Button
        Me.RemoveAdvanceReportInfoButton = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button
        Me.UpdateDateTextBox = New System.Windows.Forms.TextBox
        Me.TillSpendingsOrderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.InsertDateTextBox = New System.Windows.Forms.TextBox
        Me.DocumentSerialComboBox = New System.Windows.Forms.ComboBox
        Me.RefreshNumberButton = New System.Windows.Forms.Button
        Me.DocumentNumberAccTextBox = New AccControlsWinForms.AccTextBox
        Me.DateAccDatePicker = New AccControlsWinForms.AccDatePicker
        Me.AddAdvanceReportInfoButton = New System.Windows.Forms.Button
        Me.AccountAccGridComboBox = New AccControlsWinForms.AccListComboBox
        Me.AdditionalContentTextBox = New System.Windows.Forms.TextBox
        Me.AdvanceReportIDTextBox = New System.Windows.Forms.TextBox
        Me.AdvanceReportDescriptionTextBox = New System.Windows.Forms.TextBox
        Me.AttachmentsDescriptionTextBox = New System.Windows.Forms.TextBox
        Me.ContentTextBox = New System.Windows.Forms.TextBox
        Me.FullDocumentNumberTextBox = New System.Windows.Forms.TextBox
        Me.ReceiverAccGridComboBox = New AccControlsWinForms.AccListComboBox
        Me.ReceiversRepresentativeTextBox = New System.Windows.Forms.TextBox
        Me.AccountCurrencyTextBox = New System.Windows.Forms.TextBox
        Me.AccountCurrencyRateChangeImpactAccGridComboBox = New AccControlsWinForms.AccListComboBox
        Me.CurrencyRateChangeImpactAccTextBox = New AccControlsWinForms.AccTextBox
        Me.CurrencyRateInAccountAccTextBox = New AccControlsWinForms.AccTextBox
        Me.IsUnderPayRollCheckBox = New System.Windows.Forms.CheckBox
        Me.SumAccTextBox = New AccControlsWinForms.AccTextBox
        Me.SumCorespondencesAccTextBox = New AccControlsWinForms.AccTextBox
        Me.SumLTLAccTextBox = New AccControlsWinForms.AccTextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GetCurrencyRatesButton = New System.Windows.Forms.Button
        Me.BookEntryItemsDataListView = New BrightIdeasSoftware.DataListView
        Me.OlvColumn1 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn2 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn3 = New BrightIdeasSoftware.OLVColumn
        Me.BookEntryItemsSortedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        Me.ErrorWarnInfoProvider1 = New AccControlsWinForms.ErrorWarnInfoProvider(Me.components)
        AccountLabel = New System.Windows.Forms.Label
        AccountCurrencyLabel = New System.Windows.Forms.Label
        AccountCurrencyRateChangeImpactLabel = New System.Windows.Forms.Label
        AdditionalContentLabel = New System.Windows.Forms.Label
        AttachmentsDescriptionLabel = New System.Windows.Forms.Label
        ContentLabel = New System.Windows.Forms.Label
        CurrencyRateChangeImpactLabel = New System.Windows.Forms.Label
        CurrencyRateInAccountLabel = New System.Windows.Forms.Label
        DateLabel = New System.Windows.Forms.Label
        DocumentNumberLabel = New System.Windows.Forms.Label
        DocumentSerialLabel = New System.Windows.Forms.Label
        FullDocumentNumberLabel = New System.Windows.Forms.Label
        IDLabel = New System.Windows.Forms.Label
        ReceiverLabel = New System.Windows.Forms.Label
        ReceiversRepresentativeLabel = New System.Windows.Forms.Label
        SumLabel = New System.Windows.Forms.Label
        SumCorespondencesLabel = New System.Windows.Forms.Label
        SumLTLLabel = New System.Windows.Forms.Label
        AdvanceReportIDLabel = New System.Windows.Forms.Label
        AdvanceReportDescriptionLabel = New System.Windows.Forms.Label
        InsertDateLabel = New System.Windows.Forms.Label
        UpdateDateLabel = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.TillSpendingsOrderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.BookEntryItemsDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BookEntryItemsSortedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AccountLabel
        '
        AccountLabel.AutoSize = True
        AccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountLabel.Location = New System.Drawing.Point(70, 93)
        AccountLabel.Name = "AccountLabel"
        AccountLabel.Size = New System.Drawing.Size(89, 13)
        AccountLabel.TabIndex = 0
        AccountLabel.Text = "Lėšų sąskaita:"
        '
        'AccountCurrencyLabel
        '
        AccountCurrencyLabel.AutoSize = True
        AccountCurrencyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountCurrencyLabel.Location = New System.Drawing.Point(108, 60)
        AccountCurrencyLabel.Name = "AccountCurrencyLabel"
        AccountCurrencyLabel.Size = New System.Drawing.Size(50, 13)
        AccountCurrencyLabel.TabIndex = 2
        AccountCurrencyLabel.Text = "Valiuta:"
        '
        'AccountCurrencyRateChangeImpactLabel
        '
        AccountCurrencyRateChangeImpactLabel.AutoSize = True
        AccountCurrencyRateChangeImpactLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountCurrencyRateChangeImpactLabel.Location = New System.Drawing.Point(5, 112)
        AccountCurrencyRateChangeImpactLabel.Name = "AccountCurrencyRateChangeImpactLabel"
        AccountCurrencyRateChangeImpactLabel.Size = New System.Drawing.Size(153, 13)
        AccountCurrencyRateChangeImpactLabel.TabIndex = 4
        AccountCurrencyRateChangeImpactLabel.Text = "Kurso pasik. įtakos sąsk.:"
        '
        'AdditionalContentLabel
        '
        AdditionalContentLabel.AutoSize = True
        AdditionalContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AdditionalContentLabel.Location = New System.Drawing.Point(43, 199)
        AdditionalContentLabel.Name = "AdditionalContentLabel"
        AdditionalContentLabel.Size = New System.Drawing.Size(116, 13)
        AdditionalContentLabel.TabIndex = 6
        AdditionalContentLabel.Text = "Papildomas turinys:"
        '
        'AttachmentsDescriptionLabel
        '
        AttachmentsDescriptionLabel.AutoSize = True
        AttachmentsDescriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AttachmentsDescriptionLabel.Location = New System.Drawing.Point(89, 225)
        AttachmentsDescriptionLabel.Name = "AttachmentsDescriptionLabel"
        AttachmentsDescriptionLabel.Size = New System.Drawing.Size(70, 13)
        AttachmentsDescriptionLabel.TabIndex = 12
        AttachmentsDescriptionLabel.Text = "Pridedama:"
        '
        'ContentLabel
        '
        ContentLabel.AutoSize = True
        ContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContentLabel.Location = New System.Drawing.Point(107, 120)
        ContentLabel.Name = "ContentLabel"
        ContentLabel.Size = New System.Drawing.Size(52, 13)
        ContentLabel.TabIndex = 14
        ContentLabel.Text = "Turinys:"
        '
        'CurrencyRateChangeImpactLabel
        '
        CurrencyRateChangeImpactLabel.AutoSize = True
        CurrencyRateChangeImpactLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyRateChangeImpactLabel.Location = New System.Drawing.Point(45, 139)
        CurrencyRateChangeImpactLabel.Name = "CurrencyRateChangeImpactLabel"
        CurrencyRateChangeImpactLabel.Size = New System.Drawing.Size(113, 13)
        CurrencyRateChangeImpactLabel.TabIndex = 16
        CurrencyRateChangeImpactLabel.Text = "Kurso pasik. įtaka:"
        '
        'CurrencyRateInAccountLabel
        '
        CurrencyRateInAccountLabel.AutoSize = True
        CurrencyRateInAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyRateInAccountLabel.Location = New System.Drawing.Point(109, 86)
        CurrencyRateInAccountLabel.Name = "CurrencyRateInAccountLabel"
        CurrencyRateInAccountLabel.Size = New System.Drawing.Size(49, 13)
        CurrencyRateInAccountLabel.TabIndex = 18
        CurrencyRateInAccountLabel.Text = "Kursas:"
        '
        'DateLabel
        '
        DateLabel.AutoSize = True
        DateLabel.Dock = System.Windows.Forms.DockStyle.Fill
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(3, 30)
        DateLabel.Name = "DateLabel"
        DateLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        DateLabel.Size = New System.Drawing.Size(156, 30)
        DateLabel.TabIndex = 20
        DateLabel.Text = "Data:"
        DateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'DocumentNumberLabel
        '
        DocumentNumberLabel.AutoSize = True
        DocumentNumberLabel.Dock = System.Windows.Forms.DockStyle.Fill
        DocumentNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DocumentNumberLabel.Location = New System.Drawing.Point(550, 30)
        DocumentNumberLabel.Name = "DocumentNumberLabel"
        DocumentNumberLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        DocumentNumberLabel.Size = New System.Drawing.Size(60, 30)
        DocumentNumberLabel.TabIndex = 22
        DocumentNumberLabel.Text = "Nr.:"
        DocumentNumberLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'DocumentSerialLabel
        '
        DocumentSerialLabel.AutoSize = True
        DocumentSerialLabel.Dock = System.Windows.Forms.DockStyle.Fill
        DocumentSerialLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DocumentSerialLabel.Location = New System.Drawing.Point(329, 30)
        DocumentSerialLabel.Name = "DocumentSerialLabel"
        DocumentSerialLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        DocumentSerialLabel.Size = New System.Drawing.Size(55, 30)
        DocumentSerialLabel.TabIndex = 24
        DocumentSerialLabel.Text = "Serija:"
        DocumentSerialLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'FullDocumentNumberLabel
        '
        FullDocumentNumberLabel.AutoSize = True
        FullDocumentNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FullDocumentNumberLabel.Location = New System.Drawing.Point(93, 67)
        FullDocumentNumberLabel.Name = "FullDocumentNumberLabel"
        FullDocumentNumberLabel.Size = New System.Drawing.Size(66, 13)
        FullDocumentNumberLabel.TabIndex = 26
        FullDocumentNumberLabel.Text = "Pilnas Nr.:"
        '
        'IDLabel
        '
        IDLabel.AutoSize = True
        IDLabel.Dock = System.Windows.Forms.DockStyle.Top
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(3, 0)
        IDLabel.Name = "IDLabel"
        IDLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        IDLabel.Size = New System.Drawing.Size(156, 19)
        IDLabel.TabIndex = 28
        IDLabel.Text = "ID:"
        IDLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ReceiverLabel
        '
        ReceiverLabel.AutoSize = True
        ReceiverLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ReceiverLabel.Location = New System.Drawing.Point(102, 146)
        ReceiverLabel.Name = "ReceiverLabel"
        ReceiverLabel.Size = New System.Drawing.Size(57, 13)
        ReceiverLabel.TabIndex = 32
        ReceiverLabel.Text = "Gavėjas:"
        '
        'ReceiversRepresentativeLabel
        '
        ReceiversRepresentativeLabel.AutoSize = True
        ReceiversRepresentativeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ReceiversRepresentativeLabel.Location = New System.Drawing.Point(56, 173)
        ReceiversRepresentativeLabel.Name = "ReceiversRepresentativeLabel"
        ReceiversRepresentativeLabel.Size = New System.Drawing.Size(103, 13)
        ReceiversRepresentativeLabel.TabIndex = 34
        ReceiversRepresentativeLabel.Text = "Gavėjo atstovas:"
        '
        'SumLabel
        '
        SumLabel.AutoSize = True
        SumLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumLabel.Location = New System.Drawing.Point(116, 34)
        SumLabel.Name = "SumLabel"
        SumLabel.Size = New System.Drawing.Size(42, 13)
        SumLabel.TabIndex = 36
        SumLabel.Text = "Suma:"
        '
        'SumCorespondencesLabel
        '
        SumCorespondencesLabel.AutoSize = True
        SumCorespondencesLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumCorespondencesLabel.Location = New System.Drawing.Point(70, 191)
        SumCorespondencesLabel.Name = "SumCorespondencesLabel"
        SumCorespondencesLabel.Size = New System.Drawing.Size(88, 13)
        SumCorespondencesLabel.TabIndex = 38
        SumCorespondencesLabel.Text = "Suma koresp.:"
        '
        'SumLTLLabel
        '
        SumLTLLabel.AutoSize = True
        SumLTLLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumLTLLabel.Location = New System.Drawing.Point(90, 165)
        SumLTLLabel.Name = "SumLTLLabel"
        SumLTLLabel.Size = New System.Drawing.Size(68, 13)
        SumLTLLabel.TabIndex = 40
        SumLTLLabel.Text = "Suma LTL:"
        '
        'AdvanceReportIDLabel
        '
        AdvanceReportIDLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        AdvanceReportIDLabel.AutoSize = True
        AdvanceReportIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AdvanceReportIDLabel.Location = New System.Drawing.Point(601, 251)
        AdvanceReportIDLabel.Name = "AdvanceReportIDLabel"
        AdvanceReportIDLabel.Size = New System.Drawing.Size(66, 13)
        AdvanceReportIDLabel.TabIndex = 10
        AdvanceReportIDLabel.Text = "Apysk. ID:"
        '
        'AdvanceReportDescriptionLabel
        '
        AdvanceReportDescriptionLabel.AutoSize = True
        AdvanceReportDescriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AdvanceReportDescriptionLabel.Location = New System.Drawing.Point(48, 251)
        AdvanceReportDescriptionLabel.Name = "AdvanceReportDescriptionLabel"
        AdvanceReportDescriptionLabel.Size = New System.Drawing.Size(111, 13)
        AdvanceReportDescriptionLabel.TabIndex = 8
        AdvanceReportDescriptionLabel.Text = "Avanso apyskaita:"
        '
        'InsertDateLabel
        '
        InsertDateLabel.AutoSize = True
        InsertDateLabel.Dock = System.Windows.Forms.DockStyle.Fill
        InsertDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        InsertDateLabel.Location = New System.Drawing.Point(329, 0)
        InsertDateLabel.Name = "InsertDateLabel"
        InsertDateLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        InsertDateLabel.Size = New System.Drawing.Size(55, 30)
        InsertDateLabel.TabIndex = 43
        InsertDateLabel.Text = "Įtraukta:"
        '
        'UpdateDateLabel
        '
        UpdateDateLabel.AutoSize = True
        UpdateDateLabel.Dock = System.Windows.Forms.DockStyle.Fill
        UpdateDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UpdateDateLabel.Location = New System.Drawing.Point(550, 0)
        UpdateDateLabel.Name = "UpdateDateLabel"
        UpdateDateLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        UpdateDateLabel.Size = New System.Drawing.Size(60, 30)
        UpdateDateLabel.TabIndex = 44
        UpdateDateLabel.Text = "Pakeista:"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.OpenAdvanceReportButton)
        Me.Panel1.Controls.Add(Me.RemoveAdvanceReportInfoButton)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.AddAdvanceReportInfoButton)
        Me.Panel1.Controls.Add(AccountLabel)
        Me.Panel1.Controls.Add(Me.AccountAccGridComboBox)
        Me.Panel1.Controls.Add(AdditionalContentLabel)
        Me.Panel1.Controls.Add(Me.AdditionalContentTextBox)
        Me.Panel1.Controls.Add(Me.AdvanceReportIDTextBox)
        Me.Panel1.Controls.Add(AdvanceReportDescriptionLabel)
        Me.Panel1.Controls.Add(AdvanceReportIDLabel)
        Me.Panel1.Controls.Add(Me.AdvanceReportDescriptionTextBox)
        Me.Panel1.Controls.Add(AttachmentsDescriptionLabel)
        Me.Panel1.Controls.Add(Me.AttachmentsDescriptionTextBox)
        Me.Panel1.Controls.Add(ContentLabel)
        Me.Panel1.Controls.Add(Me.ContentTextBox)
        Me.Panel1.Controls.Add(FullDocumentNumberLabel)
        Me.Panel1.Controls.Add(Me.FullDocumentNumberTextBox)
        Me.Panel1.Controls.Add(ReceiverLabel)
        Me.Panel1.Controls.Add(Me.ReceiverAccGridComboBox)
        Me.Panel1.Controls.Add(ReceiversRepresentativeLabel)
        Me.Panel1.Controls.Add(Me.ReceiversRepresentativeTextBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Panel1.Size = New System.Drawing.Size(807, 274)
        Me.Panel1.TabIndex = 0
        '
        'OpenAdvanceReportButton
        '
        Me.OpenAdvanceReportButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.open_document_16
        Me.OpenAdvanceReportButton.Location = New System.Drawing.Point(220, 245)
        Me.OpenAdvanceReportButton.Margin = New System.Windows.Forms.Padding(0)
        Me.OpenAdvanceReportButton.Name = "OpenAdvanceReportButton"
        Me.OpenAdvanceReportButton.Size = New System.Drawing.Size(24, 24)
        Me.OpenAdvanceReportButton.TabIndex = 5
        Me.OpenAdvanceReportButton.UseVisualStyleBackColor = True
        '
        'RemoveAdvanceReportInfoButton
        '
        Me.RemoveAdvanceReportInfoButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveAdvanceReportInfoButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Remove_attachment_16x16
        Me.RemoveAdvanceReportInfoButton.Location = New System.Drawing.Point(192, 245)
        Me.RemoveAdvanceReportInfoButton.Margin = New System.Windows.Forms.Padding(0)
        Me.RemoveAdvanceReportInfoButton.Name = "RemoveAdvanceReportInfoButton"
        Me.RemoveAdvanceReportInfoButton.Size = New System.Drawing.Size(24, 24)
        Me.RemoveAdvanceReportInfoButton.TabIndex = 4
        Me.RemoveAdvanceReportInfoButton.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoScroll = True
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 10
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ViewJournalEntryButton, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.UpdateDateTextBox, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(UpdateDateLabel, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.IDTextBox, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.InsertDateTextBox, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(InsertDateLabel, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(DateLabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(DocumentSerialLabel, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DocumentSerialComboBox, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(DocumentNumberLabel, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.RefreshNumberButton, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DocumentNumberAccTextBox, 8, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DateAccDatePicker, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(807, 60)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(302, 0)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 91
        Me.ViewJournalEntryButton.TabStop = False
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = True
        '
        'UpdateDateTextBox
        '
        Me.UpdateDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TillSpendingsOrderBindingSource, "UpdateDate", True))
        Me.UpdateDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UpdateDateTextBox.Location = New System.Drawing.Point(640, 3)
        Me.UpdateDateTextBox.Name = "UpdateDateTextBox"
        Me.UpdateDateTextBox.ReadOnly = True
        Me.UpdateDateTextBox.Size = New System.Drawing.Size(134, 20)
        Me.UpdateDateTextBox.TabIndex = 45
        Me.UpdateDateTextBox.TabStop = False
        Me.UpdateDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TillSpendingsOrderBindingSource
        '
        Me.TillSpendingsOrderBindingSource.DataSource = GetType(ApskaitaObjects.Documents.TillSpendingsOrder)
        '
        'IDTextBox
        '
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TillSpendingsOrderBindingSource, "ID", True))
        Me.IDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IDTextBox.Location = New System.Drawing.Point(165, 3)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(134, 20)
        Me.IDTextBox.TabIndex = 29
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'InsertDateTextBox
        '
        Me.InsertDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TillSpendingsOrderBindingSource, "InsertDate", True))
        Me.InsertDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InsertDateTextBox.Location = New System.Drawing.Point(390, 3)
        Me.InsertDateTextBox.Name = "InsertDateTextBox"
        Me.InsertDateTextBox.ReadOnly = True
        Me.InsertDateTextBox.Size = New System.Drawing.Size(134, 20)
        Me.InsertDateTextBox.TabIndex = 44
        Me.InsertDateTextBox.TabStop = False
        Me.InsertDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DocumentSerialComboBox
        '
        Me.DocumentSerialComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TillSpendingsOrderBindingSource, "DocumentSerial", True))
        Me.DocumentSerialComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentSerialComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DocumentSerialComboBox.FormattingEnabled = True
        Me.DocumentSerialComboBox.Location = New System.Drawing.Point(390, 33)
        Me.DocumentSerialComboBox.Name = "DocumentSerialComboBox"
        Me.DocumentSerialComboBox.Size = New System.Drawing.Size(134, 21)
        Me.DocumentSerialComboBox.TabIndex = 1
        '
        'RefreshNumberButton
        '
        Me.RefreshNumberButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RefreshNumberButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Button_Reload_icon_16p
        Me.RefreshNumberButton.Location = New System.Drawing.Point(613, 30)
        Me.RefreshNumberButton.Margin = New System.Windows.Forms.Padding(0)
        Me.RefreshNumberButton.Name = "RefreshNumberButton"
        Me.RefreshNumberButton.Size = New System.Drawing.Size(24, 24)
        Me.RefreshNumberButton.TabIndex = 2
        Me.RefreshNumberButton.UseVisualStyleBackColor = True
        '
        'DocumentNumberAccTextBox
        '
        Me.DocumentNumberAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.TillSpendingsOrderBindingSource, "DocumentNumber", True))
        Me.DocumentNumberAccTextBox.DecimalLength = 0
        Me.DocumentNumberAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentNumberAccTextBox.Location = New System.Drawing.Point(640, 33)
        Me.DocumentNumberAccTextBox.Name = "DocumentNumberAccTextBox"
        Me.DocumentNumberAccTextBox.NegativeValue = False
        Me.DocumentNumberAccTextBox.Size = New System.Drawing.Size(134, 20)
        Me.DocumentNumberAccTextBox.TabIndex = 3
        Me.DocumentNumberAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateAccDatePicker
        '
        Me.DateAccDatePicker.BoldedDates = Nothing
        Me.DateAccDatePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.TillSpendingsOrderBindingSource, "Date", True))
        Me.DateAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateAccDatePicker.Location = New System.Drawing.Point(165, 33)
        Me.DateAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateAccDatePicker.Name = "DateAccDatePicker"
        Me.DateAccDatePicker.ReadOnly = False
        Me.DateAccDatePicker.ShowWeekNumbers = True
        Me.DateAccDatePicker.Size = New System.Drawing.Size(134, 24)
        Me.DateAccDatePicker.TabIndex = 0
        '
        'AddAdvanceReportInfoButton
        '
        Me.AddAdvanceReportInfoButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddAdvanceReportInfoButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.attach_icon_16x16
        Me.AddAdvanceReportInfoButton.Location = New System.Drawing.Point(164, 245)
        Me.AddAdvanceReportInfoButton.Margin = New System.Windows.Forms.Padding(0)
        Me.AddAdvanceReportInfoButton.Name = "AddAdvanceReportInfoButton"
        Me.AddAdvanceReportInfoButton.Size = New System.Drawing.Size(24, 24)
        Me.AddAdvanceReportInfoButton.TabIndex = 3
        Me.AddAdvanceReportInfoButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.AddAdvanceReportInfoButton.UseVisualStyleBackColor = True
        '
        'AccountAccGridComboBox
        '
        Me.AccountAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AccountAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TillSpendingsOrderBindingSource, "Account", True))
        Me.AccountAccGridComboBox.EmptyValueString = ""
        Me.AccountAccGridComboBox.InstantBinding = True
        Me.AccountAccGridComboBox.Location = New System.Drawing.Point(164, 90)
        Me.AccountAccGridComboBox.Name = "AccountAccGridComboBox"
        Me.AccountAccGridComboBox.Size = New System.Drawing.Size(611, 21)
        Me.AccountAccGridComboBox.TabIndex = 1
        '
        'AdditionalContentTextBox
        '
        Me.AdditionalContentTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AdditionalContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TillSpendingsOrderBindingSource, "AdditionalContent", True))
        Me.AdditionalContentTextBox.Location = New System.Drawing.Point(164, 196)
        Me.AdditionalContentTextBox.MaxLength = 255
        Me.AdditionalContentTextBox.Name = "AdditionalContentTextBox"
        Me.AdditionalContentTextBox.Size = New System.Drawing.Size(611, 20)
        Me.AdditionalContentTextBox.TabIndex = 5
        '
        'AdvanceReportIDTextBox
        '
        Me.AdvanceReportIDTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AdvanceReportIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TillSpendingsOrderBindingSource, "AdvanceReportID", True))
        Me.AdvanceReportIDTextBox.Location = New System.Drawing.Point(667, 248)
        Me.AdvanceReportIDTextBox.Name = "AdvanceReportIDTextBox"
        Me.AdvanceReportIDTextBox.ReadOnly = True
        Me.AdvanceReportIDTextBox.Size = New System.Drawing.Size(108, 20)
        Me.AdvanceReportIDTextBox.TabIndex = 11
        Me.AdvanceReportIDTextBox.TabStop = False
        Me.AdvanceReportIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AdvanceReportDescriptionTextBox
        '
        Me.AdvanceReportDescriptionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AdvanceReportDescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TillSpendingsOrderBindingSource, "AdvanceReportDescription", True))
        Me.AdvanceReportDescriptionTextBox.Location = New System.Drawing.Point(247, 248)
        Me.AdvanceReportDescriptionTextBox.Name = "AdvanceReportDescriptionTextBox"
        Me.AdvanceReportDescriptionTextBox.ReadOnly = True
        Me.AdvanceReportDescriptionTextBox.Size = New System.Drawing.Size(345, 20)
        Me.AdvanceReportDescriptionTextBox.TabIndex = 9
        Me.AdvanceReportDescriptionTextBox.TabStop = False
        '
        'AttachmentsDescriptionTextBox
        '
        Me.AttachmentsDescriptionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AttachmentsDescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TillSpendingsOrderBindingSource, "AttachmentsDescription", True))
        Me.AttachmentsDescriptionTextBox.Location = New System.Drawing.Point(164, 222)
        Me.AttachmentsDescriptionTextBox.MaxLength = 255
        Me.AttachmentsDescriptionTextBox.Name = "AttachmentsDescriptionTextBox"
        Me.AttachmentsDescriptionTextBox.Size = New System.Drawing.Size(611, 20)
        Me.AttachmentsDescriptionTextBox.TabIndex = 6
        '
        'ContentTextBox
        '
        Me.ContentTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TillSpendingsOrderBindingSource, "Content", True))
        Me.ContentTextBox.Location = New System.Drawing.Point(164, 117)
        Me.ContentTextBox.MaxLength = 255
        Me.ContentTextBox.Name = "ContentTextBox"
        Me.ContentTextBox.Size = New System.Drawing.Size(611, 20)
        Me.ContentTextBox.TabIndex = 2
        '
        'FullDocumentNumberTextBox
        '
        Me.FullDocumentNumberTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FullDocumentNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TillSpendingsOrderBindingSource, "FullDocumentNumber", True))
        Me.FullDocumentNumberTextBox.Location = New System.Drawing.Point(164, 64)
        Me.FullDocumentNumberTextBox.Name = "FullDocumentNumberTextBox"
        Me.FullDocumentNumberTextBox.ReadOnly = True
        Me.FullDocumentNumberTextBox.Size = New System.Drawing.Size(611, 20)
        Me.FullDocumentNumberTextBox.TabIndex = 27
        Me.FullDocumentNumberTextBox.TabStop = False
        '
        'ReceiverAccGridComboBox
        '
        Me.ReceiverAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReceiverAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TillSpendingsOrderBindingSource, "Receiver", True))
        Me.ReceiverAccGridComboBox.EmptyValueString = ""
        Me.ReceiverAccGridComboBox.InstantBinding = True
        Me.ReceiverAccGridComboBox.Location = New System.Drawing.Point(164, 143)
        Me.ReceiverAccGridComboBox.Name = "ReceiverAccGridComboBox"
        Me.ReceiverAccGridComboBox.Size = New System.Drawing.Size(611, 21)
        Me.ReceiverAccGridComboBox.TabIndex = 3
        '
        'ReceiversRepresentativeTextBox
        '
        Me.ReceiversRepresentativeTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReceiversRepresentativeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TillSpendingsOrderBindingSource, "ReceiversRepresentative", True))
        Me.ReceiversRepresentativeTextBox.Location = New System.Drawing.Point(164, 170)
        Me.ReceiversRepresentativeTextBox.MaxLength = 255
        Me.ReceiversRepresentativeTextBox.Name = "ReceiversRepresentativeTextBox"
        Me.ReceiversRepresentativeTextBox.Size = New System.Drawing.Size(611, 20)
        Me.ReceiversRepresentativeTextBox.TabIndex = 4
        '
        'AccountCurrencyTextBox
        '
        Me.AccountCurrencyTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AccountCurrencyTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TillSpendingsOrderBindingSource, "AccountCurrency", True))
        Me.AccountCurrencyTextBox.Location = New System.Drawing.Point(164, 57)
        Me.AccountCurrencyTextBox.Name = "AccountCurrencyTextBox"
        Me.AccountCurrencyTextBox.ReadOnly = True
        Me.AccountCurrencyTextBox.Size = New System.Drawing.Size(194, 20)
        Me.AccountCurrencyTextBox.TabIndex = 3
        Me.AccountCurrencyTextBox.TabStop = False
        Me.AccountCurrencyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AccountCurrencyRateChangeImpactAccGridComboBox
        '
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TillSpendingsOrderBindingSource, "AccountCurrencyRateChangeImpact", True))
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.EmptyValueString = ""
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.InstantBinding = True
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.Location = New System.Drawing.Point(164, 109)
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.Name = "AccountCurrencyRateChangeImpactAccGridComboBox"
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.Size = New System.Drawing.Size(194, 21)
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.TabIndex = 4
        '
        'CurrencyRateChangeImpactAccTextBox
        '
        Me.CurrencyRateChangeImpactAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrencyRateChangeImpactAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.TillSpendingsOrderBindingSource, "CurrencyRateChangeImpact", True))
        Me.CurrencyRateChangeImpactAccTextBox.Location = New System.Drawing.Point(164, 136)
        Me.CurrencyRateChangeImpactAccTextBox.Name = "CurrencyRateChangeImpactAccTextBox"
        Me.CurrencyRateChangeImpactAccTextBox.Size = New System.Drawing.Size(194, 20)
        Me.CurrencyRateChangeImpactAccTextBox.TabIndex = 5
        Me.CurrencyRateChangeImpactAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrencyRateInAccountAccTextBox
        '
        Me.CurrencyRateInAccountAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrencyRateInAccountAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.TillSpendingsOrderBindingSource, "CurrencyRateInAccount", True))
        Me.CurrencyRateInAccountAccTextBox.DecimalLength = 6
        Me.CurrencyRateInAccountAccTextBox.Location = New System.Drawing.Point(164, 83)
        Me.CurrencyRateInAccountAccTextBox.Name = "CurrencyRateInAccountAccTextBox"
        Me.CurrencyRateInAccountAccTextBox.NegativeValue = False
        Me.CurrencyRateInAccountAccTextBox.Size = New System.Drawing.Size(194, 20)
        Me.CurrencyRateInAccountAccTextBox.TabIndex = 3
        Me.CurrencyRateInAccountAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IsUnderPayRollCheckBox
        '
        Me.IsUnderPayRollCheckBox.AutoSize = True
        Me.IsUnderPayRollCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TillSpendingsOrderBindingSource, "IsUnderPayRoll", True))
        Me.IsUnderPayRollCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsUnderPayRollCheckBox.Location = New System.Drawing.Point(164, 8)
        Me.IsUnderPayRollCheckBox.Name = "IsUnderPayRollCheckBox"
        Me.IsUnderPayRollCheckBox.Size = New System.Drawing.Size(112, 17)
        Me.IsUnderPayRollCheckBox.TabIndex = 0
        Me.IsUnderPayRollCheckBox.Text = "Pagal žiniaraštį"
        '
        'SumAccTextBox
        '
        Me.SumAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SumAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.TillSpendingsOrderBindingSource, "Sum", True))
        Me.SumAccTextBox.Location = New System.Drawing.Point(164, 31)
        Me.SumAccTextBox.Name = "SumAccTextBox"
        Me.SumAccTextBox.NegativeValue = False
        Me.SumAccTextBox.Size = New System.Drawing.Size(194, 20)
        Me.SumAccTextBox.TabIndex = 1
        Me.SumAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumCorespondencesAccTextBox
        '
        Me.SumCorespondencesAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SumCorespondencesAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.TillSpendingsOrderBindingSource, "SumCorespondences", True))
        Me.SumCorespondencesAccTextBox.Location = New System.Drawing.Point(164, 188)
        Me.SumCorespondencesAccTextBox.Name = "SumCorespondencesAccTextBox"
        Me.SumCorespondencesAccTextBox.ReadOnly = True
        Me.SumCorespondencesAccTextBox.Size = New System.Drawing.Size(194, 20)
        Me.SumCorespondencesAccTextBox.TabIndex = 39
        Me.SumCorespondencesAccTextBox.TabStop = False
        Me.SumCorespondencesAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumLTLAccTextBox
        '
        Me.SumLTLAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SumLTLAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.TillSpendingsOrderBindingSource, "SumLTL", True))
        Me.SumLTLAccTextBox.Location = New System.Drawing.Point(164, 162)
        Me.SumLTLAccTextBox.Name = "SumLTLAccTextBox"
        Me.SumLTLAccTextBox.ReadOnly = True
        Me.SumLTLAccTextBox.Size = New System.Drawing.Size(194, 20)
        Me.SumLTLAccTextBox.TabIndex = 6
        Me.SumLTLAccTextBox.TabStop = False
        Me.SumLTLAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.ICancelButton)
        Me.Panel2.Controls.Add(Me.IOkButton)
        Me.Panel2.Controls.Add(Me.IApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 548)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(807, 32)
        Me.Panel2.TabIndex = 2
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(706, 6)
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
        Me.IOkButton.Location = New System.Drawing.Point(500, 6)
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
        Me.IApplyButton.Location = New System.Drawing.Point(604, 6)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(89, 23)
        Me.IApplyButton.TabIndex = 2
        Me.IApplyButton.Text = "Išsaugoti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 274)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GetCurrencyRatesButton)
        Me.SplitContainer1.Panel1.Controls.Add(Me.SumCorespondencesAccTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.SumLTLAccTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(SumLTLLabel)
        Me.SplitContainer1.Panel1.Controls.Add(SumCorespondencesLabel)
        Me.SplitContainer1.Panel1.Controls.Add(AccountCurrencyLabel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.SumAccTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.AccountCurrencyTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(SumLabel)
        Me.SplitContainer1.Panel1.Controls.Add(AccountCurrencyRateChangeImpactLabel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.IsUnderPayRollCheckBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.AccountCurrencyRateChangeImpactAccGridComboBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CurrencyRateInAccountAccTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(CurrencyRateInAccountLabel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CurrencyRateChangeImpactAccTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(CurrencyRateChangeImpactLabel)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.BookEntryItemsDataListView)
        Me.SplitContainer1.Size = New System.Drawing.Size(807, 274)
        Me.SplitContainer1.SplitterDistance = 406
        Me.SplitContainer1.TabIndex = 1
        '
        'GetCurrencyRatesButton
        '
        Me.GetCurrencyRatesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetCurrencyRatesButton.Location = New System.Drawing.Point(50, 81)
        Me.GetCurrencyRatesButton.Name = "GetCurrencyRatesButton"
        Me.GetCurrencyRatesButton.Size = New System.Drawing.Size(53, 23)
        Me.GetCurrencyRatesButton.TabIndex = 2
        Me.GetCurrencyRatesButton.Text = "$->€"
        Me.GetCurrencyRatesButton.UseVisualStyleBackColor = True
        '
        'BookEntryItemsDataListView
        '
        Me.BookEntryItemsDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.BookEntryItemsDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.BookEntryItemsDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.BookEntryItemsDataListView.AllowColumnReorder = True
        Me.BookEntryItemsDataListView.AutoGenerateColumns = False
        Me.BookEntryItemsDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.BookEntryItemsDataListView.CellEditEnterChangesRows = True
        Me.BookEntryItemsDataListView.CellEditTabChangesRows = True
        Me.BookEntryItemsDataListView.CellEditUseWholeCell = False
        Me.BookEntryItemsDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn1, Me.OlvColumn2})
        Me.BookEntryItemsDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.BookEntryItemsDataListView.DataSource = Me.BookEntryItemsSortedBindingSource
        Me.BookEntryItemsDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BookEntryItemsDataListView.FullRowSelect = True
        Me.BookEntryItemsDataListView.HasCollapsibleGroups = False
        Me.BookEntryItemsDataListView.HeaderWordWrap = True
        Me.BookEntryItemsDataListView.HideSelection = False
        Me.BookEntryItemsDataListView.IncludeColumnHeadersInCopy = True
        Me.BookEntryItemsDataListView.Location = New System.Drawing.Point(0, 0)
        Me.BookEntryItemsDataListView.Name = "BookEntryItemsDataListView"
        Me.BookEntryItemsDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.BookEntryItemsDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.BookEntryItemsDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.BookEntryItemsDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.BookEntryItemsDataListView.ShowCommandMenuOnRightClick = True
        Me.BookEntryItemsDataListView.ShowGroups = False
        Me.BookEntryItemsDataListView.ShowImagesOnSubItems = True
        Me.BookEntryItemsDataListView.ShowItemCountOnGroups = True
        Me.BookEntryItemsDataListView.ShowItemToolTips = True
        Me.BookEntryItemsDataListView.Size = New System.Drawing.Size(397, 274)
        Me.BookEntryItemsDataListView.TabIndex = 3
        Me.BookEntryItemsDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.BookEntryItemsDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.BookEntryItemsDataListView.UseCellFormatEvents = True
        Me.BookEntryItemsDataListView.UseCompatibleStateImageBehavior = False
        Me.BookEntryItemsDataListView.UseFilterIndicator = True
        Me.BookEntryItemsDataListView.UseFiltering = True
        Me.BookEntryItemsDataListView.UseHotItem = True
        Me.BookEntryItemsDataListView.UseNotifyPropertyChanged = True
        Me.BookEntryItemsDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "Account"
        Me.OlvColumn1.CellEditUseWholeCell = True
        Me.OlvColumn1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn1.Text = "Sąskaita"
        Me.OlvColumn1.ToolTipText = ""
        Me.OlvColumn1.Width = 131
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "Amount"
        Me.OlvColumn2.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.Text = "Suma"
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 131
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "Person"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.DisplayIndex = 1
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.IsVisible = False
        Me.OlvColumn3.Text = "Asmuo"
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 100
        '
        'BookEntryItemsSortedBindingSource
        '
        Me.BookEntryItemsSortedBindingSource.DataMember = "BookEntryItems"
        Me.BookEntryItemsSortedBindingSource.DataSource = Me.TillSpendingsOrderBindingSource
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(144, 339)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(143, 74)
        Me.ProgressFiller1.TabIndex = 3
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(313, 336)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(210, 85)
        Me.ProgressFiller2.TabIndex = 4
        Me.ProgressFiller2.Visible = False
        '
        'ErrorWarnInfoProvider1
        '
        Me.ErrorWarnInfoProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleInformation = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleWarning = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.ContainerControl = Me
        Me.ErrorWarnInfoProvider1.DataSource = Me.TillSpendingsOrderBindingSource
        '
        'F_TillSpendingsOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 580)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_TillSpendingsOrder"
        Me.ShowInTaskbar = False
        Me.Text = "Kasos išlaidų orderis"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.TillSpendingsOrderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.BookEntryItemsDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BookEntryItemsSortedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents AccountAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents TillSpendingsOrderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AccountCurrencyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AccountCurrencyRateChangeImpactAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents AdditionalContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AttachmentsDescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CurrencyRateChangeImpactAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CurrencyRateInAccountAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents DocumentNumberAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents DocumentSerialComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents FullDocumentNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IsUnderPayRollCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ReceiverAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents ReceiversRepresentativeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SumAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents SumCorespondencesAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents SumLTLAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RefreshNumberButton As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents BookEntryItemsSortedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GetCurrencyRatesButton As System.Windows.Forms.Button
    Friend WithEvents RemoveAdvanceReportInfoButton As System.Windows.Forms.Button
    Friend WithEvents AddAdvanceReportInfoButton As System.Windows.Forms.Button
    Friend WithEvents AdvanceReportDescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdvanceReportIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UpdateDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InsertDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
    Friend WithEvents OpenAdvanceReportButton As System.Windows.Forms.Button
    Friend WithEvents BookEntryItemsDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ErrorWarnInfoProvider1 As AccControlsWinForms.ErrorWarnInfoProvider
    Friend WithEvents DateAccDatePicker As AccControlsWinForms.AccDatePicker
End Class
