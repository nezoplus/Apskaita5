﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_PersonInfoItemList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_PersonInfoItemList))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RefreshButton = New System.Windows.Forms.Button
        Me.LikeStringTextBox = New System.Windows.Forms.TextBox
        Me.ShowClientsCheckBox = New System.Windows.Forms.CheckBox
        Me.ShowWorkersCheckBox = New System.Windows.Forms.CheckBox
        Me.ShowsuppliersCheckBox = New System.Windows.Forms.CheckBox
        Me.PersonInfoItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChangeItem_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteItem_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PersonInfoItemListDataListView = New BrightIdeasSoftware.DataListView
        Me.OlvColumn2 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn1 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn3 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn4 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn5 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn6 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn7 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn8 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn9 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn10 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn11 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn12 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn13 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn14 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn15 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn16 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn17 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn18 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn19 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn20 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn21 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn22 = New BrightIdeasSoftware.OLVColumn
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        Me.Panel1.SuspendLayout()
        CType(Me.PersonInfoItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PersonInfoItemListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.RefreshButton)
        Me.Panel1.Controls.Add(Me.LikeStringTextBox)
        Me.Panel1.Controls.Add(Me.ShowClientsCheckBox)
        Me.Panel1.Controls.Add(Me.ShowWorkersCheckBox)
        Me.Panel1.Controls.Add(Me.ShowsuppliersCheckBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Panel1.Size = New System.Drawing.Size(848, 42)
        Me.Panel1.TabIndex = 0
        '
        'RefreshButton
        '
        Me.RefreshButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RefreshButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Button_Reload_icon_24p
        Me.RefreshButton.Location = New System.Drawing.Point(803, 3)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(33, 33)
        Me.RefreshButton.TabIndex = 4
        Me.RefreshButton.UseVisualStyleBackColor = True
        '
        'LikeStringTextBox
        '
        Me.LikeStringTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LikeStringTextBox.Location = New System.Drawing.Point(260, 10)
        Me.LikeStringTextBox.Name = "LikeStringTextBox"
        Me.LikeStringTextBox.Size = New System.Drawing.Size(537, 20)
        Me.LikeStringTextBox.TabIndex = 3
        Me.LikeStringTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ShowClientsCheckBox
        '
        Me.ShowClientsCheckBox.AutoSize = True
        Me.ShowClientsCheckBox.Checked = True
        Me.ShowClientsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowClientsCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowClientsCheckBox.Location = New System.Drawing.Point(12, 12)
        Me.ShowClientsCheckBox.Name = "ShowClientsCheckBox"
        Me.ShowClientsCheckBox.Size = New System.Drawing.Size(68, 17)
        Me.ShowClientsCheckBox.TabIndex = 0
        Me.ShowClientsCheckBox.Text = "Pirkėjai"
        Me.ShowClientsCheckBox.UseVisualStyleBackColor = True
        '
        'ShowWorkersCheckBox
        '
        Me.ShowWorkersCheckBox.AutoSize = True
        Me.ShowWorkersCheckBox.Checked = True
        Me.ShowWorkersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowWorkersCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowWorkersCheckBox.Location = New System.Drawing.Point(163, 12)
        Me.ShowWorkersCheckBox.Name = "ShowWorkersCheckBox"
        Me.ShowWorkersCheckBox.Size = New System.Drawing.Size(91, 17)
        Me.ShowWorkersCheckBox.TabIndex = 2
        Me.ShowWorkersCheckBox.Text = "Darbuotojai"
        Me.ShowWorkersCheckBox.UseVisualStyleBackColor = True
        '
        'ShowsuppliersCheckBox
        '
        Me.ShowsuppliersCheckBox.AutoSize = True
        Me.ShowsuppliersCheckBox.Checked = True
        Me.ShowsuppliersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowsuppliersCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowsuppliersCheckBox.Location = New System.Drawing.Point(86, 12)
        Me.ShowsuppliersCheckBox.Name = "ShowsuppliersCheckBox"
        Me.ShowsuppliersCheckBox.Size = New System.Drawing.Size(71, 17)
        Me.ShowsuppliersCheckBox.TabIndex = 1
        Me.ShowsuppliersCheckBox.Text = "Tiekėjai"
        Me.ShowsuppliersCheckBox.UseVisualStyleBackColor = True
        '
        'PersonInfoItemListBindingSource
        '
        Me.PersonInfoItemListBindingSource.DataSource = GetType(ApskaitaObjects.ActiveReports.PersonInfoItem)
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeItem_MenuItem, Me.DeleteItem_MenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 48)
        '
        'ChangeItem_MenuItem
        '
        Me.ChangeItem_MenuItem.Name = "ChangeItem_MenuItem"
        Me.ChangeItem_MenuItem.Size = New System.Drawing.Size(107, 22)
        Me.ChangeItem_MenuItem.Text = "Keisti"
        '
        'DeleteItem_MenuItem
        '
        Me.DeleteItem_MenuItem.Name = "DeleteItem_MenuItem"
        Me.DeleteItem_MenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteItem_MenuItem.Text = "Ištrinti"
        '
        'PersonInfoItemListDataListView
        '
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn4)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn5)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn6)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn7)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn8)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn9)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn10)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn11)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn12)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn13)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn14)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn15)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn16)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn17)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn18)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn19)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn20)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn21)
        Me.PersonInfoItemListDataListView.AllColumns.Add(Me.OlvColumn22)
        Me.PersonInfoItemListDataListView.AllowColumnReorder = True
        Me.PersonInfoItemListDataListView.AutoGenerateColumns = False
        Me.PersonInfoItemListDataListView.CausesValidation = False
        Me.PersonInfoItemListDataListView.CellEditUseWholeCell = False
        Me.PersonInfoItemListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4, Me.OlvColumn6, Me.OlvColumn7, Me.OlvColumn10, Me.OlvColumn11, Me.OlvColumn12, Me.OlvColumn13, Me.OlvColumn14, Me.OlvColumn15, Me.OlvColumn16, Me.OlvColumn17})
        Me.PersonInfoItemListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.PersonInfoItemListDataListView.DataSource = Me.PersonInfoItemListBindingSource
        Me.PersonInfoItemListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonInfoItemListDataListView.FullRowSelect = True
        Me.PersonInfoItemListDataListView.HasCollapsibleGroups = False
        Me.PersonInfoItemListDataListView.HeaderWordWrap = True
        Me.PersonInfoItemListDataListView.HideSelection = False
        Me.PersonInfoItemListDataListView.IncludeColumnHeadersInCopy = True
        Me.PersonInfoItemListDataListView.Location = New System.Drawing.Point(0, 42)
        Me.PersonInfoItemListDataListView.Name = "PersonInfoItemListDataListView"
        Me.PersonInfoItemListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.PersonInfoItemListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.PersonInfoItemListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.PersonInfoItemListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.PersonInfoItemListDataListView.ShowCommandMenuOnRightClick = True
        Me.PersonInfoItemListDataListView.ShowGroups = False
        Me.PersonInfoItemListDataListView.ShowImagesOnSubItems = True
        Me.PersonInfoItemListDataListView.ShowItemCountOnGroups = True
        Me.PersonInfoItemListDataListView.ShowItemToolTips = True
        Me.PersonInfoItemListDataListView.Size = New System.Drawing.Size(848, 382)
        Me.PersonInfoItemListDataListView.TabIndex = 4
        Me.PersonInfoItemListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.PersonInfoItemListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.PersonInfoItemListDataListView.UseCellFormatEvents = True
        Me.PersonInfoItemListDataListView.UseCompatibleStateImageBehavior = False
        Me.PersonInfoItemListDataListView.UseFilterIndicator = True
        Me.PersonInfoItemListDataListView.UseFiltering = True
        Me.PersonInfoItemListDataListView.UseHotItem = True
        Me.PersonInfoItemListDataListView.UseNotifyPropertyChanged = True
        Me.PersonInfoItemListDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "Name"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.IsEditable = False
        Me.OlvColumn2.Text = "Pavadinimas"
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 232
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "ID"
        Me.OlvColumn1.CellEditUseWholeCell = True
        Me.OlvColumn1.DisplayIndex = 1
        Me.OlvColumn1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn1.IsEditable = False
        Me.OlvColumn1.IsVisible = False
        Me.OlvColumn1.Text = "ID"
        Me.OlvColumn1.ToolTipText = ""
        Me.OlvColumn1.Width = 100
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "Code"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.IsEditable = False
        Me.OlvColumn3.Text = "Įmonės/ Asmens Kodas"
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 100
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "CodeVAT"
        Me.OlvColumn4.CellEditUseWholeCell = True
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.IsEditable = False
        Me.OlvColumn4.Text = "PVM Mokėtojo Kodas"
        Me.OlvColumn4.ToolTipText = ""
        Me.OlvColumn4.Width = 100
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "InternalCode"
        Me.OlvColumn5.CellEditUseWholeCell = True
        Me.OlvColumn5.DisplayIndex = 4
        Me.OlvColumn5.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.IsEditable = False
        Me.OlvColumn5.IsVisible = False
        Me.OlvColumn5.Text = "Vidinis kodas"
        Me.OlvColumn5.ToolTipText = ""
        Me.OlvColumn5.Width = 100
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "Address"
        Me.OlvColumn6.CellEditUseWholeCell = True
        Me.OlvColumn6.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.IsEditable = False
        Me.OlvColumn6.Text = "Adresas"
        Me.OlvColumn6.ToolTipText = ""
        Me.OlvColumn6.Width = 207
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "CurrencyCode"
        Me.OlvColumn7.CellEditUseWholeCell = True
        Me.OlvColumn7.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.IsEditable = False
        Me.OlvColumn7.Text = "Valiuta"
        Me.OlvColumn7.ToolTipText = ""
        Me.OlvColumn7.Width = 52
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "Bank"
        Me.OlvColumn8.CellEditUseWholeCell = True
        Me.OlvColumn8.DisplayIndex = 7
        Me.OlvColumn8.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.IsEditable = False
        Me.OlvColumn8.IsVisible = False
        Me.OlvColumn8.Text = "Bankas"
        Me.OlvColumn8.ToolTipText = ""
        Me.OlvColumn8.Width = 100
        '
        'OlvColumn9
        '
        Me.OlvColumn9.AspectName = "BankAccount"
        Me.OlvColumn9.CellEditUseWholeCell = True
        Me.OlvColumn9.DisplayIndex = 8
        Me.OlvColumn9.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn9.IsEditable = False
        Me.OlvColumn9.IsVisible = False
        Me.OlvColumn9.Text = "Banko Sąskaita"
        Me.OlvColumn9.ToolTipText = ""
        Me.OlvColumn9.Width = 100
        '
        'OlvColumn10
        '
        Me.OlvColumn10.AspectName = "LanguageName"
        Me.OlvColumn10.CellEditUseWholeCell = True
        Me.OlvColumn10.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn10.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn10.IsEditable = False
        Me.OlvColumn10.Text = "Kalba"
        Me.OlvColumn10.ToolTipText = ""
        Me.OlvColumn10.Width = 100
        '
        'OlvColumn11
        '
        Me.OlvColumn11.AspectName = "Email"
        Me.OlvColumn11.CellEditUseWholeCell = True
        Me.OlvColumn11.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn11.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn11.IsEditable = False
        Me.OlvColumn11.Text = "E-Paštas"
        Me.OlvColumn11.ToolTipText = ""
        Me.OlvColumn11.Width = 100
        '
        'OlvColumn12
        '
        Me.OlvColumn12.AspectName = "ContactInfo"
        Me.OlvColumn12.CellEditUseWholeCell = True
        Me.OlvColumn12.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn12.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn12.IsEditable = False
        Me.OlvColumn12.Text = "Kontaktinė Info"
        Me.OlvColumn12.ToolTipText = ""
        Me.OlvColumn12.Width = 100
        '
        'OlvColumn13
        '
        Me.OlvColumn13.AspectName = "IsClient"
        Me.OlvColumn13.CellEditUseWholeCell = True
        Me.OlvColumn13.CheckBoxes = True
        Me.OlvColumn13.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn13.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn13.IsEditable = False
        Me.OlvColumn13.Text = "Pirkėjas"
        Me.OlvColumn13.ToolTipText = ""
        Me.OlvColumn13.Width = 100
        '
        'OlvColumn14
        '
        Me.OlvColumn14.AspectName = "AccountAgainstBankBuyer"
        Me.OlvColumn14.CellEditUseWholeCell = True
        Me.OlvColumn14.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn14.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn14.IsEditable = False
        Me.OlvColumn14.Text = "Koresp. Pirkėjo Sąsk."
        Me.OlvColumn14.ToolTipText = ""
        Me.OlvColumn14.Width = 100
        '
        'OlvColumn15
        '
        Me.OlvColumn15.AspectName = "IsSupplier"
        Me.OlvColumn15.CellEditUseWholeCell = True
        Me.OlvColumn15.CheckBoxes = True
        Me.OlvColumn15.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn15.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn15.IsEditable = False
        Me.OlvColumn15.Text = "Tiekėjas"
        Me.OlvColumn15.ToolTipText = ""
        Me.OlvColumn15.Width = 100
        '
        'OlvColumn16
        '
        Me.OlvColumn16.AspectName = "AccountAgainstBankSupplyer"
        Me.OlvColumn16.CellEditUseWholeCell = True
        Me.OlvColumn16.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn16.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn16.IsEditable = False
        Me.OlvColumn16.Text = "Koresp. Tiekėjo Sąsk."
        Me.OlvColumn16.ToolTipText = ""
        Me.OlvColumn16.Width = 100
        '
        'OlvColumn17
        '
        Me.OlvColumn17.AspectName = "IsWorker"
        Me.OlvColumn17.CellEditUseWholeCell = True
        Me.OlvColumn17.CheckBoxes = True
        Me.OlvColumn17.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn17.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn17.IsEditable = False
        Me.OlvColumn17.Text = "Darbuotojas"
        Me.OlvColumn17.ToolTipText = ""
        Me.OlvColumn17.Width = 100
        '
        'OlvColumn18
        '
        Me.OlvColumn18.AspectName = "CodeSODRA"
        Me.OlvColumn18.CellEditUseWholeCell = True
        Me.OlvColumn18.DisplayIndex = 17
        Me.OlvColumn18.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn18.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn18.IsEditable = False
        Me.OlvColumn18.IsVisible = False
        Me.OlvColumn18.Text = "SODRA kodas"
        Me.OlvColumn18.ToolTipText = ""
        Me.OlvColumn18.Width = 100
        '
        'OlvColumn19
        '
        Me.OlvColumn19.AspectName = "IsNaturalPerson"
        Me.OlvColumn19.CellEditUseWholeCell = True
        Me.OlvColumn19.CheckBoxes = True
        Me.OlvColumn19.DisplayIndex = 18
        Me.OlvColumn19.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn19.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn19.IsEditable = False
        Me.OlvColumn19.IsVisible = False
        Me.OlvColumn19.Text = "Fizinis asmuo"
        Me.OlvColumn19.ToolTipText = ""
        Me.OlvColumn19.Width = 100
        '
        'OlvColumn20
        '
        Me.OlvColumn20.AspectName = "IsObsolete"
        Me.OlvColumn20.CellEditUseWholeCell = True
        Me.OlvColumn20.CheckBoxes = True
        Me.OlvColumn20.DisplayIndex = 19
        Me.OlvColumn20.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn20.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn20.IsEditable = False
        Me.OlvColumn20.IsVisible = False
        Me.OlvColumn20.Text = "Archyvinis"
        Me.OlvColumn20.ToolTipText = ""
        Me.OlvColumn20.Width = 100
        '
        'OlvColumn21
        '
        Me.OlvColumn21.AspectName = "CodeIsNotReal"
        Me.OlvColumn21.CellEditUseWholeCell = True
        Me.OlvColumn21.CheckBoxes = True
        Me.OlvColumn21.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn21.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn21.IsEditable = False
        Me.OlvColumn21.Text = "Kodas Netikras"
        Me.OlvColumn21.ToolTipText = ""
        Me.OlvColumn21.Width = 20
        '
        'OlvColumn22
        '
        Me.OlvColumn22.AspectName = "StateCode"
        Me.OlvColumn22.CellEditUseWholeCell = True
        Me.OlvColumn22.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn22.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn22.IsEditable = False
        Me.OlvColumn22.IsVisible = False
        Me.OlvColumn22.Text = "Šalis"
        Me.OlvColumn22.ToolTipText = ""
        Me.OlvColumn22.Width = 30
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(237, 52)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(104, 73)
        Me.ProgressFiller1.TabIndex = 5
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(368, 54)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(109, 71)
        Me.ProgressFiller2.TabIndex = 6
        Me.ProgressFiller2.Visible = False
        '
        'F_Persons
        '
        Me.AcceptButton = Me.RefreshButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 424)
        Me.Controls.Add(Me.PersonInfoItemListDataListView)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_Persons"
        Me.ShowInTaskbar = False
        Me.Text = "Kontrahentai"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PersonInfoItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PersonInfoItemListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents ShowWorkersCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ShowsuppliersCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ShowClientsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents LikeStringTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PersonInfoItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ChangeItem_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteItem_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PersonInfoItemListDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn5 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn6 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn7 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn8 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn9 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn10 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn11 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn12 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn13 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn14 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn15 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn16 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn17 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn18 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn19 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn20 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn21 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn22 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
End Class
