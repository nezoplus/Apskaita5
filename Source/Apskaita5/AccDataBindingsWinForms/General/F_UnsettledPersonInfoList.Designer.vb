﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_UnsettledPersonInfoList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_UnsettledPersonInfoList))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ExportPaymentsButton = New System.Windows.Forms.Button()
        Me.RefreshButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MarginOfErrorAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.PersonGroupComboBox = New AccControlsWinForms.AccListComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ForSuppliersRadioButton = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ForBuyersRadioButton = New System.Windows.Forms.RadioButton()
        Me.AccountAccGridComboBox = New AccControlsWinForms.AccListComboBox()
        Me.AsOfDateAccDatePicker = New AccControlsWinForms.AccDatePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UnsettledPersonInfoListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UnsettledPersonInfoListDataTreeView = New BrightIdeasSoftware.TreeListView()
        Me.OlvColumn8 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn7 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn9 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn10 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn11 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn12 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn6 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn2 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn4 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn5 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller()
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller()
        Me.Panel1.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.TableLayoutPanel3.SuspendLayout
        Me.TableLayoutPanel2.SuspendLayout
        CType(Me.UnsettledPersonInfoListBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UnsettledPersonInfoListDataTreeView,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Panel1
        '
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.ExportPaymentsButton)
        Me.Panel1.Controls.Add(Me.RefreshButton)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(874, 87)
        Me.Panel1.TabIndex = 0
        '
        'ExportPaymentsButton
        '
        Me.ExportPaymentsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ExportPaymentsButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.credit_card_24
        Me.ExportPaymentsButton.Location = New System.Drawing.Point(831, 46)
        Me.ExportPaymentsButton.Name = "ExportPaymentsButton"
        Me.ExportPaymentsButton.Size = New System.Drawing.Size(33, 33)
        Me.ExportPaymentsButton.TabIndex = 2
        Me.ExportPaymentsButton.UseVisualStyleBackColor = true
        '
        'RefreshButton
        '
        Me.RefreshButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.RefreshButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Button_Reload_icon_24p
        Me.RefreshButton.Location = New System.Drawing.Point(831, 6)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(33, 34)
        Me.RefreshButton.TabIndex = 1
        Me.RefreshButton.UseVisualStyleBackColor = true
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(825, 58)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.MarginOfErrorAccTextBox, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.PersonGroupComboBox, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(51, 30)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(774, 30)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.Label3.Location = New System.Drawing.Point(488, 3)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Paklaida:"
        '
        'MarginOfErrorAccTextBox
        '
        Me.MarginOfErrorAccTextBox.ButtonVisible = false
        Me.MarginOfErrorAccTextBox.DecimalValue = 5R
        Me.MarginOfErrorAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MarginOfErrorAccTextBox.Location = New System.Drawing.Point(553, 1)
        Me.MarginOfErrorAccTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.MarginOfErrorAccTextBox.Name = "MarginOfErrorAccTextBox"
        Me.MarginOfErrorAccTextBox.NegativeValue = false
        Me.MarginOfErrorAccTextBox.Size = New System.Drawing.Size(195, 20)
        Me.MarginOfErrorAccTextBox.TabIndex = 1
        Me.MarginOfErrorAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PersonGroupComboBox
        '
        Me.PersonGroupComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonGroupComboBox.EmptyValueString = ""
        Me.PersonGroupComboBox.Location = New System.Drawing.Point(3, 3)
        Me.PersonGroupComboBox.Name = "PersonGroupComboBox"
        Me.PersonGroupComboBox.Size = New System.Drawing.Size(459, 20)
        Me.PersonGroupComboBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Data:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 8
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21!))
        Me.TableLayoutPanel2.Controls.Add(Me.ForSuppliersRadioButton, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ForBuyersRadioButton, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.AccountAccGridComboBox, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.AsOfDateAccDatePicker, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(51, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(774, 30)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'ForSuppliersRadioButton
        '
        Me.ForSuppliersRadioButton.AutoSize = true
        Me.ForSuppliersRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.ForSuppliersRadioButton.Location = New System.Drawing.Point(680, 3)
        Me.ForSuppliersRadioButton.Name = "ForSuppliersRadioButton"
        Me.ForSuppliersRadioButton.Size = New System.Drawing.Size(70, 17)
        Me.ForSuppliersRadioButton.TabIndex = 3
        Me.ForSuppliersRadioButton.Text = "Tiekėjai"
        Me.ForSuppliersRadioButton.UseVisualStyleBackColor = true
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.Label4.Location = New System.Drawing.Point(272, 3)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Sąskaita:"
        '
        'ForBuyersRadioButton
        '
        Me.ForBuyersRadioButton.AutoSize = true
        Me.ForBuyersRadioButton.Checked = true
        Me.ForBuyersRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.ForBuyersRadioButton.Location = New System.Drawing.Point(607, 3)
        Me.ForBuyersRadioButton.Name = "ForBuyersRadioButton"
        Me.ForBuyersRadioButton.Size = New System.Drawing.Size(67, 17)
        Me.ForBuyersRadioButton.TabIndex = 2
        Me.ForBuyersRadioButton.TabStop = true
        Me.ForBuyersRadioButton.Text = "Pirkėjai"
        Me.ForBuyersRadioButton.UseVisualStyleBackColor = true
        '
        'AccountAccGridComboBox
        '
        Me.AccountAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountAccGridComboBox.EmptyValueString = ""
        Me.AccountAccGridComboBox.Location = New System.Drawing.Point(337, 1)
        Me.AccountAccGridComboBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.AccountAccGridComboBox.Name = "AccountAccGridComboBox"
        Me.AccountAccGridComboBox.Size = New System.Drawing.Size(245, 20)
        Me.AccountAccGridComboBox.TabIndex = 1
        '
        'AsOfDateAccDatePicker
        '
        Me.AsOfDateAccDatePicker.BoldedDates = Nothing
        Me.AsOfDateAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AsOfDateAccDatePicker.Location = New System.Drawing.Point(3, 3)
        Me.AsOfDateAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.AsOfDateAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.AsOfDateAccDatePicker.Name = "AsOfDateAccDatePicker"
        Me.AsOfDateAccDatePicker.ShowWeekNumbers = true
        Me.AsOfDateAccDatePicker.Size = New System.Drawing.Size(243, 20)
        Me.AsOfDateAccDatePicker.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 36)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Grupė:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UnsettledPersonInfoListBindingSource
        '
        Me.UnsettledPersonInfoListBindingSource.DataSource = GetType(ApskaitaObjects.ActiveReports.UnsettledPersonInfo)
        '
        'UnsettledPersonInfoListDataTreeView
        '
        Me.UnsettledPersonInfoListDataTreeView.AllColumns.Add(Me.OlvColumn8)
        Me.UnsettledPersonInfoListDataTreeView.AllColumns.Add(Me.OlvColumn7)
        Me.UnsettledPersonInfoListDataTreeView.AllColumns.Add(Me.OlvColumn9)
        Me.UnsettledPersonInfoListDataTreeView.AllColumns.Add(Me.OlvColumn10)
        Me.UnsettledPersonInfoListDataTreeView.AllColumns.Add(Me.OlvColumn11)
        Me.UnsettledPersonInfoListDataTreeView.AllColumns.Add(Me.OlvColumn12)
        Me.UnsettledPersonInfoListDataTreeView.AllColumns.Add(Me.OlvColumn1)
        Me.UnsettledPersonInfoListDataTreeView.AllColumns.Add(Me.OlvColumn6)
        Me.UnsettledPersonInfoListDataTreeView.AllColumns.Add(Me.OlvColumn2)
        Me.UnsettledPersonInfoListDataTreeView.AllColumns.Add(Me.OlvColumn3)
        Me.UnsettledPersonInfoListDataTreeView.AllColumns.Add(Me.OlvColumn4)
        Me.UnsettledPersonInfoListDataTreeView.AllColumns.Add(Me.OlvColumn5)
        Me.UnsettledPersonInfoListDataTreeView.AllowColumnReorder = true
        Me.UnsettledPersonInfoListDataTreeView.CausesValidation = false
        Me.UnsettledPersonInfoListDataTreeView.CellEditUseWholeCell = false
        Me.UnsettledPersonInfoListDataTreeView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn8, Me.OlvColumn7, Me.OlvColumn6, Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4, Me.OlvColumn5})
        Me.UnsettledPersonInfoListDataTreeView.CopySelectionOnControlCUsesDragSource = false
        Me.UnsettledPersonInfoListDataTreeView.Cursor = System.Windows.Forms.Cursors.Default
        Me.UnsettledPersonInfoListDataTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UnsettledPersonInfoListDataTreeView.HasCollapsibleGroups = false
        Me.UnsettledPersonInfoListDataTreeView.HeaderWordWrap = true
        Me.UnsettledPersonInfoListDataTreeView.HideSelection = false
        Me.UnsettledPersonInfoListDataTreeView.HighlightBackgroundColor = System.Drawing.Color.Empty
        Me.UnsettledPersonInfoListDataTreeView.HighlightForegroundColor = System.Drawing.Color.Empty
        Me.UnsettledPersonInfoListDataTreeView.IncludeColumnHeadersInCopy = true
        Me.UnsettledPersonInfoListDataTreeView.Location = New System.Drawing.Point(0, 87)
        Me.UnsettledPersonInfoListDataTreeView.Name = "UnsettledPersonInfoListDataTreeView"
        Me.UnsettledPersonInfoListDataTreeView.RenderNonEditableCheckboxesAsDisabled = true
        Me.UnsettledPersonInfoListDataTreeView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.UnsettledPersonInfoListDataTreeView.ShowCommandMenuOnRightClick = true
        Me.UnsettledPersonInfoListDataTreeView.ShowGroups = false
        Me.UnsettledPersonInfoListDataTreeView.ShowItemCountOnGroups = true
        Me.UnsettledPersonInfoListDataTreeView.ShowItemToolTips = true
        Me.UnsettledPersonInfoListDataTreeView.Size = New System.Drawing.Size(874, 418)
        Me.UnsettledPersonInfoListDataTreeView.TabIndex = 1
        Me.UnsettledPersonInfoListDataTreeView.UseCompatibleStateImageBehavior = false
        Me.UnsettledPersonInfoListDataTreeView.UseFilterIndicator = true
        Me.UnsettledPersonInfoListDataTreeView.UseFiltering = true
        Me.UnsettledPersonInfoListDataTreeView.UseHotItem = true
        Me.UnsettledPersonInfoListDataTreeView.UseNotifyPropertyChanged = true
        Me.UnsettledPersonInfoListDataTreeView.UseTranslucentHotItem = true
        Me.UnsettledPersonInfoListDataTreeView.View = System.Windows.Forms.View.Details
        Me.UnsettledPersonInfoListDataTreeView.VirtualMode = true
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "Name"
        Me.OlvColumn8.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.Text = "Kontrahento Pavadinimas"
        Me.OlvColumn8.Width = 153
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "Debt"
        Me.OlvColumn7.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn7.CellEditUseWholeCell = true
        Me.OlvColumn7.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.IsEditable = false
        Me.OlvColumn7.Text = "Skola"
        Me.OlvColumn7.ToolTipText = ""
        Me.OlvColumn7.Width = 100
        '
        'OlvColumn9
        '
        Me.OlvColumn9.AspectName = "Code"
        Me.OlvColumn9.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn9.IsVisible = false
        Me.OlvColumn9.Text = "Kontrahento Kodas"
        '
        'OlvColumn10
        '
        Me.OlvColumn10.AspectName = "CodeInternal"
        Me.OlvColumn10.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn10.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn10.IsVisible = false
        Me.OlvColumn10.Text = "Kontrahento Vidinis Kodas"
        '
        'OlvColumn11
        '
        Me.OlvColumn11.AspectName = "Email"
        Me.OlvColumn11.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn11.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn11.IsVisible = false
        Me.OlvColumn11.Text = "E-paštas"
        '
        'OlvColumn12
        '
        Me.OlvColumn12.AspectName = "Address"
        Me.OlvColumn12.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn12.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn12.IsVisible = false
        Me.OlvColumn12.Text = "Adresas"
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
        Me.OlvColumn1.Width = 100
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "SumInDocument"
        Me.OlvColumn6.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn6.CellEditUseWholeCell = true
        Me.OlvColumn6.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.IsEditable = false
        Me.OlvColumn6.Text = "Dok. Suma"
        Me.OlvColumn6.ToolTipText = ""
        Me.OlvColumn6.Width = 100
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "DocTypeHumanReadable"
        Me.OlvColumn2.CellEditUseWholeCell = true
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.IsEditable = false
        Me.OlvColumn2.Text = "Dok. Tipas"
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 100
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "Date"
        Me.OlvColumn3.AspectToStringFormat = "{0:d}"
        Me.OlvColumn3.CellEditUseWholeCell = true
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.IsEditable = false
        Me.OlvColumn3.Text = "Data"
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 78
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "DocNo"
        Me.OlvColumn4.CellEditUseWholeCell = true
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.IsEditable = false
        Me.OlvColumn4.Text = "Dok. Nr."
        Me.OlvColumn4.ToolTipText = ""
        Me.OlvColumn4.Width = 100
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "Content"
        Me.OlvColumn5.CellEditUseWholeCell = true
        Me.OlvColumn5.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.IsEditable = false
        Me.OlvColumn5.Text = "Turinys"
        Me.OlvColumn5.ToolTipText = ""
        Me.OlvColumn5.Width = 235
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(276, 98)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(147, 49)
        Me.ProgressFiller1.TabIndex = 2
        Me.ProgressFiller1.Visible = false
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(446, 93)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(152, 54)
        Me.ProgressFiller2.TabIndex = 3
        Me.ProgressFiller2.Visible = false
        '
        'F_UnsettledPersonInfoList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 505)
        Me.Controls.Add(Me.UnsettledPersonInfoListDataTreeView)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "F_UnsettledPersonInfoList"
        Me.ShowInTaskbar = false
        Me.Text = "Neapmokėti dokumentai"
        Me.Panel1.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.TableLayoutPanel3.ResumeLayout(false)
        Me.TableLayoutPanel3.PerformLayout
        Me.TableLayoutPanel2.ResumeLayout(false)
        Me.TableLayoutPanel2.PerformLayout
        CType(Me.UnsettledPersonInfoListBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UnsettledPersonInfoListDataTreeView,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MarginOfErrorAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents AccountAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents ForBuyersRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents ForSuppliersRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents UnsettledPersonInfoListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UnsettledPersonInfoListDataTreeView As BrightIdeasSoftware.TreeListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn5 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn6 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn7 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn8 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents PersonGroupComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents OlvColumn9 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn10 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn11 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn12 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents AsOfDateAccDatePicker As AccControlsWinForms.AccDatePicker
    Friend WithEvents ExportPaymentsButton As Button
End Class
