﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_ImprestSheet
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
        Me.components = New System.ComponentModel.Container()
        Dim DateLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim YearLabel As System.Windows.Forms.Label
        Dim MonthLabel As System.Windows.Forms.Label
        Dim NumberLabel As System.Windows.Forms.Label
        Dim TotalSumLabel As System.Windows.Forms.Label
        Dim InsertDateLabel As System.Windows.Forms.Label
        Dim UpdateDateLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_ImprestSheet))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ExportPaymentsButton = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PaymentDateAccDatePicker = New AccControlsWinForms.AccDatePicker()
        Me.SetPaymentDateButton = New System.Windows.Forms.Button()
        Me.RefreshButton = New System.Windows.Forms.Button()
        Me.ICancelButton = New System.Windows.Forms.Button()
        Me.IApplyButton = New System.Windows.Forms.Button()
        Me.IOkButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button()
        Me.UpdateDateTextBox = New System.Windows.Forms.TextBox()
        Me.ImprestSheetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IDTextBox = New System.Windows.Forms.TextBox()
        Me.InsertDateTextBox = New System.Windows.Forms.TextBox()
        Me.YearTextBox = New System.Windows.Forms.TextBox()
        Me.MonthTextBox = New System.Windows.Forms.TextBox()
        Me.TotalSumAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.NumberAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.DateAccDatePicker = New AccControlsWinForms.AccDatePicker()
        Me.ItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemsDataListView = New BrightIdeasSoftware.DataListView()
        Me.OlvColumn4 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn5 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn6 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn7 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn8 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn9 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn10 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller()
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller()
        Me.ErrorWarnInfoProvider1 = New AccControlsWinForms.ErrorWarnInfoProvider(Me.components)
        DateLabel = New System.Windows.Forms.Label()
        IDLabel = New System.Windows.Forms.Label()
        YearLabel = New System.Windows.Forms.Label()
        MonthLabel = New System.Windows.Forms.Label()
        NumberLabel = New System.Windows.Forms.Label()
        TotalSumLabel = New System.Windows.Forms.Label()
        InsertDateLabel = New System.Windows.Forms.Label()
        UpdateDateLabel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout
        Me.GroupBox3.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        CType(Me.ImprestSheetBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ItemsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ItemsDataListView,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ErrorWarnInfoProvider1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'DateLabel
        '
        DateLabel.AutoSize = true
        DateLabel.Dock = System.Windows.Forms.DockStyle.Fill
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DateLabel.Location = New System.Drawing.Point(246, 60)
        DateLabel.Name = "DateLabel"
        DateLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        DateLabel.Size = New System.Drawing.Size(55, 30)
        DateLabel.TabIndex = 0
        DateLabel.Text = "Data:"
        DateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'IDLabel
        '
        IDLabel.AutoSize = true
        IDLabel.Dock = System.Windows.Forms.DockStyle.Fill
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
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
        YearLabel.AutoSize = true
        YearLabel.Dock = System.Windows.Forms.DockStyle.Fill
        YearLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
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
        MonthLabel.AutoSize = true
        MonthLabel.Dock = System.Windows.Forms.DockStyle.Fill
        MonthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        MonthLabel.Location = New System.Drawing.Point(246, 30)
        MonthLabel.Name = "MonthLabel"
        MonthLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        MonthLabel.Size = New System.Drawing.Size(55, 30)
        MonthLabel.TabIndex = 6
        MonthLabel.Text = "Mėnuo:"
        MonthLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'NumberLabel
        '
        NumberLabel.AutoSize = true
        NumberLabel.Dock = System.Windows.Forms.DockStyle.Fill
        NumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        NumberLabel.Location = New System.Drawing.Point(527, 60)
        NumberLabel.Name = "NumberLabel"
        NumberLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        NumberLabel.Size = New System.Drawing.Size(60, 30)
        NumberLabel.TabIndex = 8
        NumberLabel.Text = "Nr.:"
        NumberLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TotalSumLabel
        '
        TotalSumLabel.AutoSize = true
        TotalSumLabel.Dock = System.Windows.Forms.DockStyle.Fill
        TotalSumLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        TotalSumLabel.Location = New System.Drawing.Point(527, 30)
        TotalSumLabel.Name = "TotalSumLabel"
        TotalSumLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        TotalSumLabel.Size = New System.Drawing.Size(60, 30)
        TotalSumLabel.TabIndex = 14
        TotalSumLabel.Text = "Suma:"
        TotalSumLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'InsertDateLabel
        '
        InsertDateLabel.AutoSize = true
        InsertDateLabel.Dock = System.Windows.Forms.DockStyle.Fill
        InsertDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        InsertDateLabel.Location = New System.Drawing.Point(246, 0)
        InsertDateLabel.Name = "InsertDateLabel"
        InsertDateLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        InsertDateLabel.Size = New System.Drawing.Size(55, 30)
        InsertDateLabel.TabIndex = 55
        InsertDateLabel.Text = "Įtraukta:"
        '
        'UpdateDateLabel
        '
        UpdateDateLabel.AutoSize = true
        UpdateDateLabel.Dock = System.Windows.Forms.DockStyle.Fill
        UpdateDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        UpdateDateLabel.Location = New System.Drawing.Point(527, 0)
        UpdateDateLabel.Name = "UpdateDateLabel"
        UpdateDateLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        UpdateDateLabel.Size = New System.Drawing.Size(60, 30)
        UpdateDateLabel.TabIndex = 56
        UpdateDateLabel.Text = "Pakeista:"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = true
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.ExportPaymentsButton)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.RefreshButton)
        Me.Panel1.Controls.Add(Me.ICancelButton)
        Me.Panel1.Controls.Add(Me.IApplyButton)
        Me.Panel1.Controls.Add(Me.IOkButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 395)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(817, 46)
        Me.Panel1.TabIndex = 2
        '
        'ExportPaymentsButton
        '
        Me.ExportPaymentsButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ExportPaymentsButton.AutoSize = true
        Me.ExportPaymentsButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.credit_card_24
        Me.ExportPaymentsButton.Location = New System.Drawing.Point(269, 8)
        Me.ExportPaymentsButton.Name = "ExportPaymentsButton"
        Me.ExportPaymentsButton.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.ExportPaymentsButton.Size = New System.Drawing.Size(33, 33)
        Me.ExportPaymentsButton.TabIndex = 7
        Me.ExportPaymentsButton.UseVisualStyleBackColor = true
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PaymentDateAccDatePicker)
        Me.GroupBox3.Controls.Add(Me.SetPaymentDateButton)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 40)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = false
        Me.GroupBox3.Text = "Bendra Išmokėjimo Data"
        '
        'PaymentDateAccDatePicker
        '
        Me.PaymentDateAccDatePicker.BoldedDates = Nothing
        Me.PaymentDateAccDatePicker.Location = New System.Drawing.Point(6, 15)
        Me.PaymentDateAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.PaymentDateAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.PaymentDateAccDatePicker.Name = "PaymentDateAccDatePicker"
        Me.PaymentDateAccDatePicker.ShowWeekNumbers = true
        Me.PaymentDateAccDatePicker.Size = New System.Drawing.Size(113, 20)
        Me.PaymentDateAccDatePicker.TabIndex = 0
        '
        'SetPaymentDateButton
        '
        Me.SetPaymentDateButton.Location = New System.Drawing.Point(125, 15)
        Me.SetPaymentDateButton.Name = "SetPaymentDateButton"
        Me.SetPaymentDateButton.Size = New System.Drawing.Size(69, 23)
        Me.SetPaymentDateButton.TabIndex = 1
        Me.SetPaymentDateButton.Text = "Nustatyti"
        Me.SetPaymentDateButton.UseVisualStyleBackColor = true
        '
        'RefreshButton
        '
        Me.RefreshButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Action_file_new_icon_16p
        Me.RefreshButton.Location = New System.Drawing.Point(228, 14)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(24, 24)
        Me.RefreshButton.TabIndex = 1
        Me.RefreshButton.UseVisualStyleBackColor = true
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(730, 14)
        Me.ICancelButton.Name = "ICancelButton"
        Me.ICancelButton.Size = New System.Drawing.Size(75, 23)
        Me.ICancelButton.TabIndex = 4
        Me.ICancelButton.Text = "Atšaukti"
        Me.ICancelButton.UseVisualStyleBackColor = true
        '
        'IApplyButton
        '
        Me.IApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.IApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.IApplyButton.Location = New System.Drawing.Point(649, 14)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(75, 23)
        Me.IApplyButton.TabIndex = 3
        Me.IApplyButton.Text = "Taikyti"
        Me.IApplyButton.UseVisualStyleBackColor = true
        '
        'IOkButton
        '
        Me.IOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.IOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.IOkButton.Location = New System.Drawing.Point(568, 14)
        Me.IOkButton.Name = "IOkButton"
        Me.IOkButton.Size = New System.Drawing.Size(75, 23)
        Me.IOkButton.TabIndex = 2
        Me.IOkButton.Text = "OK"
        Me.IOkButton.UseVisualStyleBackColor = true
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 9
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26!))
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
        Me.TableLayoutPanel1.Controls.Add(DateLabel, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DateAccDatePicker, 4, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(817, 90)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(219, 0)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 90
        Me.ViewJournalEntryButton.TabStop = false
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = true
        '
        'UpdateDateTextBox
        '
        Me.UpdateDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImprestSheetBindingSource, "UpdateDate", true))
        Me.UpdateDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UpdateDateTextBox.Location = New System.Drawing.Point(593, 3)
        Me.UpdateDateTextBox.Name = "UpdateDateTextBox"
        Me.UpdateDateTextBox.ReadOnly = true
        Me.UpdateDateTextBox.Size = New System.Drawing.Size(194, 20)
        Me.UpdateDateTextBox.TabIndex = 57
        Me.UpdateDateTextBox.TabStop = false
        Me.UpdateDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ImprestSheetBindingSource
        '
        Me.ImprestSheetBindingSource.DataSource = GetType(ApskaitaObjects.Workers.ImprestSheet)
        '
        'IDTextBox
        '
        Me.IDTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImprestSheetBindingSource, "ID", true))
        Me.IDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IDTextBox.Location = New System.Drawing.Point(51, 3)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = true
        Me.IDTextBox.Size = New System.Drawing.Size(165, 20)
        Me.IDTextBox.TabIndex = 3
        Me.IDTextBox.TabStop = false
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'InsertDateTextBox
        '
        Me.InsertDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImprestSheetBindingSource, "InsertDate", true))
        Me.InsertDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InsertDateTextBox.Location = New System.Drawing.Point(307, 3)
        Me.InsertDateTextBox.Name = "InsertDateTextBox"
        Me.InsertDateTextBox.ReadOnly = true
        Me.InsertDateTextBox.Size = New System.Drawing.Size(194, 20)
        Me.InsertDateTextBox.TabIndex = 56
        Me.InsertDateTextBox.TabStop = false
        Me.InsertDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'YearTextBox
        '
        Me.YearTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.YearTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImprestSheetBindingSource, "Year", true))
        Me.YearTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.YearTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.YearTextBox.Location = New System.Drawing.Point(51, 33)
        Me.YearTextBox.Name = "YearTextBox"
        Me.YearTextBox.ReadOnly = true
        Me.YearTextBox.Size = New System.Drawing.Size(165, 20)
        Me.YearTextBox.TabIndex = 5
        Me.YearTextBox.TabStop = false
        Me.YearTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MonthTextBox
        '
        Me.MonthTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.MonthTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImprestSheetBindingSource, "Month", true))
        Me.MonthTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MonthTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.MonthTextBox.Location = New System.Drawing.Point(307, 33)
        Me.MonthTextBox.Name = "MonthTextBox"
        Me.MonthTextBox.ReadOnly = true
        Me.MonthTextBox.Size = New System.Drawing.Size(194, 20)
        Me.MonthTextBox.TabIndex = 7
        Me.MonthTextBox.TabStop = false
        Me.MonthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TotalSumAccTextBox
        '
        Me.TotalSumAccTextBox.ButtonVisible = false
        Me.TotalSumAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.ImprestSheetBindingSource, "TotalSum", true))
        Me.TotalSumAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TotalSumAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TotalSumAccTextBox.Location = New System.Drawing.Point(593, 33)
        Me.TotalSumAccTextBox.Name = "TotalSumAccTextBox"
        Me.TotalSumAccTextBox.ReadOnly = true
        Me.TotalSumAccTextBox.Size = New System.Drawing.Size(194, 20)
        Me.TotalSumAccTextBox.TabIndex = 18
        Me.TotalSumAccTextBox.TabStop = false
        Me.TotalSumAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumberAccTextBox
        '
        Me.NumberAccTextBox.ButtonVisible = false
        Me.NumberAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.ImprestSheetBindingSource, "Number", true))
        Me.NumberAccTextBox.DecimalLength = 0
        Me.NumberAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NumberAccTextBox.Location = New System.Drawing.Point(593, 63)
        Me.NumberAccTextBox.Name = "NumberAccTextBox"
        Me.NumberAccTextBox.NegativeValue = false
        Me.NumberAccTextBox.Size = New System.Drawing.Size(194, 20)
        Me.NumberAccTextBox.TabIndex = 1
        Me.NumberAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateAccDatePicker
        '
        Me.DateAccDatePicker.BoldedDates = Nothing
        Me.DateAccDatePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.ImprestSheetBindingSource, "Date", true))
        Me.DateAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateAccDatePicker.Location = New System.Drawing.Point(307, 63)
        Me.DateAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateAccDatePicker.Name = "DateAccDatePicker"
        Me.DateAccDatePicker.ShowWeekNumbers = true
        Me.DateAccDatePicker.Size = New System.Drawing.Size(194, 20)
        Me.DateAccDatePicker.TabIndex = 0
        '
        'ItemsBindingSource
        '
        Me.ItemsBindingSource.DataMember = "Items"
        Me.ItemsBindingSource.DataSource = Me.ImprestSheetBindingSource
        '
        'ItemsDataListView
        '
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn4)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn5)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn6)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn7)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn8)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn9)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn10)
        Me.ItemsDataListView.AllowColumnReorder = true
        Me.ItemsDataListView.AutoGenerateColumns = false
        Me.ItemsDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.ItemsDataListView.CellEditEnterChangesRows = true
        Me.ItemsDataListView.CellEditTabChangesRows = true
        Me.ItemsDataListView.CellEditUseWholeCell = false
        Me.ItemsDataListView.CheckBoxes = true
        Me.ItemsDataListView.CheckedAspectName = "IsChecked"
        Me.ItemsDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn4, Me.OlvColumn5, Me.OlvColumn7, Me.OlvColumn8, Me.OlvColumn9, Me.OlvColumn10})
        Me.ItemsDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.ItemsDataListView.DataSource = Me.ItemsBindingSource
        Me.ItemsDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemsDataListView.FullRowSelect = true
        Me.ItemsDataListView.HasCollapsibleGroups = false
        Me.ItemsDataListView.HeaderWordWrap = true
        Me.ItemsDataListView.HideSelection = false
        Me.ItemsDataListView.HighlightBackgroundColor = System.Drawing.Color.PaleGreen
        Me.ItemsDataListView.HighlightForegroundColor = System.Drawing.Color.Black
        Me.ItemsDataListView.IncludeColumnHeadersInCopy = true
        Me.ItemsDataListView.Location = New System.Drawing.Point(0, 90)
        Me.ItemsDataListView.Name = "ItemsDataListView"
        Me.ItemsDataListView.RenderNonEditableCheckboxesAsDisabled = true
        Me.ItemsDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.ItemsDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.ItemsDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.ItemsDataListView.ShowCommandMenuOnRightClick = true
        Me.ItemsDataListView.ShowGroups = false
        Me.ItemsDataListView.ShowImagesOnSubItems = true
        Me.ItemsDataListView.ShowItemCountOnGroups = true
        Me.ItemsDataListView.ShowItemToolTips = true
        Me.ItemsDataListView.Size = New System.Drawing.Size(817, 305)
        Me.ItemsDataListView.TabIndex = 1
        Me.ItemsDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.ItemsDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.ItemsDataListView.UseCellFormatEvents = true
        Me.ItemsDataListView.UseCompatibleStateImageBehavior = false
        Me.ItemsDataListView.UseFilterIndicator = true
        Me.ItemsDataListView.UseFiltering = true
        Me.ItemsDataListView.UseHotItem = true
        Me.ItemsDataListView.UseNotifyPropertyChanged = true
        Me.ItemsDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "PersonName"
        Me.OlvColumn4.CellEditUseWholeCell = true
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.IsEditable = false
        Me.OlvColumn4.Text = "Vardas, Pavardė"
        Me.OlvColumn4.ToolTipText = ""
        Me.OlvColumn4.Width = 156
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "ID"
        Me.OlvColumn1.CellEditUseWholeCell = true
        Me.OlvColumn1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn1.IsEditable = false
        Me.OlvColumn1.IsVisible = false
        Me.OlvColumn1.Text = "ID"
        Me.OlvColumn1.ToolTipText = ""
        Me.OlvColumn1.Width = 45
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "PersonID"
        Me.OlvColumn3.CellEditUseWholeCell = true
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.IsEditable = false
        Me.OlvColumn3.IsVisible = false
        Me.OlvColumn3.Text = "PersonID"
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 84
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "PersonCode"
        Me.OlvColumn5.CellEditUseWholeCell = true
        Me.OlvColumn5.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.IsEditable = false
        Me.OlvColumn5.Text = "Asm. kodas"
        Me.OlvColumn5.ToolTipText = ""
        Me.OlvColumn5.Width = 103
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "PersonCodeSodra"
        Me.OlvColumn6.CellEditUseWholeCell = true
        Me.OlvColumn6.DisplayIndex = 2
        Me.OlvColumn6.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.IsEditable = false
        Me.OlvColumn6.IsVisible = false
        Me.OlvColumn6.Text = "SODROS kodas"
        Me.OlvColumn6.ToolTipText = ""
        Me.OlvColumn6.Width = 122
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "ContractSerial"
        Me.OlvColumn7.CellEditUseWholeCell = true
        Me.OlvColumn7.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.IsEditable = false
        Me.OlvColumn7.Text = "DS Ser."
        Me.OlvColumn7.ToolTipText = ""
        Me.OlvColumn7.Width = 56
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "ContractNumber"
        Me.OlvColumn8.CellEditUseWholeCell = true
        Me.OlvColumn8.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.IsEditable = false
        Me.OlvColumn8.Text = "DS Nr."
        Me.OlvColumn8.ToolTipText = ""
        Me.OlvColumn8.Width = 53
        '
        'OlvColumn9
        '
        Me.OlvColumn9.AspectName = "PayOffSumTotal"
        Me.OlvColumn9.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn9.CellEditUseWholeCell = true
        Me.OlvColumn9.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn9.Text = "Suma"
        Me.OlvColumn9.ToolTipText = ""
        Me.OlvColumn9.Width = 75
        '
        'OlvColumn10
        '
        Me.OlvColumn10.AspectName = "PayedOutDate"
        Me.OlvColumn10.CellEditUseWholeCell = true
        Me.OlvColumn10.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn10.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn10.Text = "Išmokėta"
        Me.OlvColumn10.ToolTipText = ""
        Me.OlvColumn10.Width = 100
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(261, 204)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(63, 60)
        Me.ProgressFiller1.TabIndex = 4
        Me.ProgressFiller1.Visible = false
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(367, 197)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(132, 67)
        Me.ProgressFiller2.TabIndex = 5
        Me.ProgressFiller2.Visible = false
        '
        'ErrorWarnInfoProvider1
        '
        Me.ErrorWarnInfoProvider1.ContainerControl = Me
        Me.ErrorWarnInfoProvider1.DataSource = Me.ImprestSheetBindingSource
        '
        'F_ImprestSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 441)
        Me.Controls.Add(Me.ItemsDataListView)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "F_ImprestSheet"
        Me.ShowInTaskbar = false
        Me.Text = "Avanso žiniaraštis"
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        CType(Me.ImprestSheetBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ItemsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ItemsDataListView,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ErrorWarnInfoProvider1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents ImprestSheetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents YearTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MonthTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ItemsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents NumberAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents TotalSumAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents UpdateDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InsertDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents SetPaymentDateButton As System.Windows.Forms.Button
    Friend WithEvents ItemsDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn5 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn6 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn7 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn8 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn9 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn10 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ErrorWarnInfoProvider1 As AccControlsWinForms.ErrorWarnInfoProvider
    Friend WithEvents DateAccDatePicker As AccControlsWinForms.AccDatePicker
    Friend WithEvents PaymentDateAccDatePicker As AccControlsWinForms.AccDatePicker
    Friend WithEvents ExportPaymentsButton As Button
End Class
