﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_ImportedPersonList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_ImportedPersonList))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PasteButton = New System.Windows.Forms.Button()
        Me.OpenFileButton = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ApplyButton = New System.Windows.Forms.Button()
        Me.ImportedPersonListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ImportedPersonListDataListView = New BrightIdeasSoftware.DataListView()
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn4 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn5 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn6 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn7 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn8 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn9 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn10 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn11 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn12 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn13 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn14 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn15 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn16 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn17 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn18 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn19 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn20 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn21 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn22 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn23 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller()
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ImportedPersonListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImportedPersonListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.PasteButton)
        Me.Panel1.Controls.Add(Me.OpenFileButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Panel1.Size = New System.Drawing.Size(880, 45)
        Me.Panel1.TabIndex = 1
        '
        'PasteButton
        '
        Me.PasteButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PasteButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Paste_icon_24p
        Me.PasteButton.Location = New System.Drawing.Point(787, 9)
        Me.PasteButton.Name = "PasteButton"
        Me.PasteButton.Size = New System.Drawing.Size(35, 30)
        Me.PasteButton.TabIndex = 8
        Me.PasteButton.UseVisualStyleBackColor = True
        '
        'OpenFileButton
        '
        Me.OpenFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpenFileButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.folder_open_icon_24p
        Me.OpenFileButton.Location = New System.Drawing.Point(838, 9)
        Me.OpenFileButton.Name = "OpenFileButton"
        Me.OpenFileButton.Size = New System.Drawing.Size(30, 30)
        Me.OpenFileButton.TabIndex = 5
        Me.OpenFileButton.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.ApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 530)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(880, 39)
        Me.Panel2.TabIndex = 3
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplyButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyButton.Location = New System.Drawing.Point(762, 11)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(106, 25)
        Me.ApplyButton.TabIndex = 67
        Me.ApplyButton.Text = "Importuoti"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'ImportedPersonListBindingSource
        '
        Me.ImportedPersonListBindingSource.DataSource = GetType(ApskaitaObjects.General.ImportedPerson)
        '
        'ImportedPersonListDataListView
        '
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn4)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn5)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn6)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn7)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn8)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn9)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn10)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn11)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn12)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn13)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn14)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn15)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn16)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn17)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn18)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn19)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn20)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn21)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn22)
        Me.ImportedPersonListDataListView.AllColumns.Add(Me.OlvColumn23)
        Me.ImportedPersonListDataListView.AllowColumnReorder = True
        Me.ImportedPersonListDataListView.AutoGenerateColumns = False
        Me.ImportedPersonListDataListView.CausesValidation = False
        Me.ImportedPersonListDataListView.CellEditUseWholeCell = False
        Me.ImportedPersonListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn1, Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4, Me.OlvColumn5, Me.OlvColumn6, Me.OlvColumn7, Me.OlvColumn8, Me.OlvColumn9, Me.OlvColumn10, Me.OlvColumn11, Me.OlvColumn12, Me.OlvColumn13, Me.OlvColumn14, Me.OlvColumn15, Me.OlvColumn16, Me.OlvColumn17, Me.OlvColumn18, Me.OlvColumn19})
        Me.ImportedPersonListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.ImportedPersonListDataListView.DataSource = Me.ImportedPersonListBindingSource
        Me.ImportedPersonListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImportedPersonListDataListView.FullRowSelect = True
        Me.ImportedPersonListDataListView.HasCollapsibleGroups = False
        Me.ImportedPersonListDataListView.HeaderWordWrap = True
        Me.ImportedPersonListDataListView.HideSelection = False
        Me.ImportedPersonListDataListView.HighlightBackgroundColor = System.Drawing.Color.PaleGreen
        Me.ImportedPersonListDataListView.HighlightForegroundColor = System.Drawing.Color.Black
        Me.ImportedPersonListDataListView.IncludeColumnHeadersInCopy = True
        Me.ImportedPersonListDataListView.Location = New System.Drawing.Point(0, 45)
        Me.ImportedPersonListDataListView.Name = "ImportedPersonListDataListView"
        Me.ImportedPersonListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.ImportedPersonListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.ImportedPersonListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.ImportedPersonListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.ImportedPersonListDataListView.ShowCommandMenuOnRightClick = True
        Me.ImportedPersonListDataListView.ShowGroups = False
        Me.ImportedPersonListDataListView.ShowImagesOnSubItems = True
        Me.ImportedPersonListDataListView.ShowItemCountOnGroups = True
        Me.ImportedPersonListDataListView.ShowItemToolTips = True
        Me.ImportedPersonListDataListView.Size = New System.Drawing.Size(880, 485)
        Me.ImportedPersonListDataListView.TabIndex = 4
        Me.ImportedPersonListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.ImportedPersonListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.ImportedPersonListDataListView.UseCellFormatEvents = True
        Me.ImportedPersonListDataListView.UseCompatibleStateImageBehavior = False
        Me.ImportedPersonListDataListView.UseFilterIndicator = True
        Me.ImportedPersonListDataListView.UseFiltering = True
        Me.ImportedPersonListDataListView.UseHotItem = True
        Me.ImportedPersonListDataListView.UseNotifyPropertyChanged = True
        Me.ImportedPersonListDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "Name"
        Me.OlvColumn1.CellEditUseWholeCell = True
        Me.OlvColumn1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn1.IsEditable = False
        Me.OlvColumn1.Text = "Pavadinimas"
        Me.OlvColumn1.ToolTipText = ""
        Me.OlvColumn1.Width = 190
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "Code"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.IsEditable = False
        Me.OlvColumn2.Text = "Įmonės Kodas"
        Me.OlvColumn2.ToolTipText = "Įmonės ar asmens kodas"
        Me.OlvColumn2.Width = 100
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "CodeVAT"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.IsEditable = False
        Me.OlvColumn3.Text = "PVM Kodas"
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 100
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "CodeSODRA"
        Me.OlvColumn4.CellEditUseWholeCell = True
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.IsEditable = False
        Me.OlvColumn4.Text = "SODRA Kodas"
        Me.OlvColumn4.ToolTipText = "Darbuotojo SODRA kodas"
        Me.OlvColumn4.Width = 100
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "InternalCode"
        Me.OlvColumn5.CellEditUseWholeCell = True
        Me.OlvColumn5.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.IsEditable = False
        Me.OlvColumn5.Text = "Vidinis Kodas"
        Me.OlvColumn5.ToolTipText = "Kodas vidiniam naudojimui"
        Me.OlvColumn5.Width = 70
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "Address"
        Me.OlvColumn6.CellEditUseWholeCell = True
        Me.OlvColumn6.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.IsEditable = False
        Me.OlvColumn6.Text = "Adresas"
        Me.OlvColumn6.ToolTipText = "Adresas"
        Me.OlvColumn6.Width = 151
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "LanguageCode"
        Me.OlvColumn7.CellEditUseWholeCell = True
        Me.OlvColumn7.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.IsEditable = False
        Me.OlvColumn7.Text = "Kalba"
        Me.OlvColumn7.ToolTipText = "Kalbos kodas pgl. ISO 639-1"
        Me.OlvColumn7.Width = 64
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "CurrencyCode"
        Me.OlvColumn8.CellEditUseWholeCell = True
        Me.OlvColumn8.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.IsEditable = False
        Me.OlvColumn8.Text = "Valiuta"
        Me.OlvColumn8.ToolTipText = "Valiutos kodas pgl. ISO 4217"
        Me.OlvColumn8.Width = 48
        '
        'OlvColumn9
        '
        Me.OlvColumn9.AspectName = "Bank"
        Me.OlvColumn9.CellEditUseWholeCell = True
        Me.OlvColumn9.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn9.IsEditable = False
        Me.OlvColumn9.Text = "Bankas"
        Me.OlvColumn9.ToolTipText = "Banko pavadinimas"
        Me.OlvColumn9.Width = 100
        '
        'OlvColumn10
        '
        Me.OlvColumn10.AspectName = "BankAccount"
        Me.OlvColumn10.CellEditUseWholeCell = True
        Me.OlvColumn10.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn10.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn10.IsEditable = False
        Me.OlvColumn10.Text = "Banko Sąskaita"
        Me.OlvColumn10.ToolTipText = "Banko sąskaitos numeris"
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
        Me.OlvColumn11.ToolTipText = "E-Paštas"
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
        Me.OlvColumn12.ToolTipText = "Kontaktinė Info"
        Me.OlvColumn12.Width = 100
        '
        'OlvColumn13
        '
        Me.OlvColumn13.AspectName = "AccountAgainstBankBuyer"
        Me.OlvColumn13.CellEditUseWholeCell = True
        Me.OlvColumn13.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn13.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn13.IsEditable = False
        Me.OlvColumn13.Text = "Pirkėjų Sąsk."
        Me.OlvColumn13.ToolTipText = "Kontrahentui pagal nutylėjimą kontuojama pirkėjų sąskaita"
        Me.OlvColumn13.Width = 100
        '
        'OlvColumn14
        '
        Me.OlvColumn14.AspectName = "AccountAgainstBankSupplyer"
        Me.OlvColumn14.CellEditUseWholeCell = True
        Me.OlvColumn14.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn14.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn14.IsEditable = False
        Me.OlvColumn14.Text = "Tiekėjų Sąsk."
        Me.OlvColumn14.ToolTipText = "Kontrahentui pagal nutylėjimą kontuojama tiekėjų sąskaita"
        Me.OlvColumn14.Width = 100
        '
        'OlvColumn15
        '
        Me.OlvColumn15.AspectName = "IsNaturalPerson"
        Me.OlvColumn15.CellEditUseWholeCell = True
        Me.OlvColumn15.CheckBoxes = True
        Me.OlvColumn15.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn15.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn15.IsEditable = False
        Me.OlvColumn15.Text = "Fizinis Asmuo"
        Me.OlvColumn15.ToolTipText = "Fizinis Asmuo"
        Me.OlvColumn15.Width = 100
        '
        'OlvColumn16
        '
        Me.OlvColumn16.AspectName = "IsClient"
        Me.OlvColumn16.CellEditUseWholeCell = True
        Me.OlvColumn16.CheckBoxes = True
        Me.OlvColumn16.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn16.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn16.IsEditable = False
        Me.OlvColumn16.Text = "Pirkėjas"
        Me.OlvColumn16.ToolTipText = "Pirkėjas"
        Me.OlvColumn16.Width = 100
        '
        'OlvColumn17
        '
        Me.OlvColumn17.AspectName = "IsSupplier"
        Me.OlvColumn17.CellEditUseWholeCell = True
        Me.OlvColumn17.CheckBoxes = True
        Me.OlvColumn17.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn17.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn17.IsEditable = False
        Me.OlvColumn17.Text = "Tiekėjas"
        Me.OlvColumn17.ToolTipText = "Tiekėjas"
        Me.OlvColumn17.Width = 100
        '
        'OlvColumn18
        '
        Me.OlvColumn18.AspectName = "IsWorker"
        Me.OlvColumn18.CellEditUseWholeCell = True
        Me.OlvColumn18.CheckBoxes = True
        Me.OlvColumn18.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn18.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn18.IsEditable = False
        Me.OlvColumn18.Text = "Darbuotojas"
        Me.OlvColumn18.ToolTipText = "Darbuotojas"
        Me.OlvColumn18.Width = 100
        '
        'OlvColumn19
        '
        Me.OlvColumn19.AspectName = "IsObsolete"
        Me.OlvColumn19.CellEditUseWholeCell = True
        Me.OlvColumn19.CheckBoxes = True
        Me.OlvColumn19.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn19.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn19.IsEditable = False
        Me.OlvColumn19.Text = "Nebenaudojamas"
        Me.OlvColumn19.ToolTipText = "Nebenaudojami istoriniai duomenys"
        Me.OlvColumn19.Width = 100
        '
        'OlvColumn20
        '
        Me.OlvColumn20.AspectName = "AlreadyPresent"
        Me.OlvColumn20.CellEditUseWholeCell = True
        Me.OlvColumn20.CheckBoxes = True
        Me.OlvColumn20.DisplayIndex = 19
        Me.OlvColumn20.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn20.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn20.IsEditable = False
        Me.OlvColumn20.IsVisible = False
        Me.OlvColumn20.Text = "Jau Įtrauktas"
        Me.OlvColumn20.ToolTipText = "Kontrahentas su tokiu kodu jau įtrauktas į duomenų bazę"
        Me.OlvColumn20.Width = 100
        '
        'OlvColumn21
        '
        Me.OlvColumn21.AspectName = "NotUniqueCode"
        Me.OlvColumn21.CellEditUseWholeCell = True
        Me.OlvColumn21.CheckBoxes = True
        Me.OlvColumn21.DisplayIndex = 20
        Me.OlvColumn21.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn21.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn21.IsEditable = False
        Me.OlvColumn21.IsVisible = False
        Me.OlvColumn21.Text = "Kontrahento kodas neunikalus importuojamuose duomenyse"
        Me.OlvColumn21.ToolTipText = ""
        Me.OlvColumn21.Width = 100
        '
        'OlvColumn22
        '
        Me.OlvColumn22.AspectName = "CodeIsNotReal"
        Me.OlvColumn22.CellEditUseWholeCell = True
        Me.OlvColumn22.CheckBoxes = True
        Me.OlvColumn22.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn22.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn22.IsEditable = False
        Me.OlvColumn22.Text = "Kodas Netikras"
        Me.OlvColumn22.ToolTipText = ""
        Me.OlvColumn22.Width = 20
        '
        'OlvColumn23
        '
        Me.OlvColumn23.AspectName = "StateCode"
        Me.OlvColumn23.CellEditUseWholeCell = True
        Me.OlvColumn23.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn23.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn23.IsEditable = False
        Me.OlvColumn23.IsVisible = False
        Me.OlvColumn23.Text = "Šalis"
        Me.OlvColumn23.ToolTipText = ""
        Me.OlvColumn23.Width = 30
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(303, 74)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(158, 90)
        Me.ProgressFiller1.TabIndex = 5
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(467, 74)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(178, 90)
        Me.ProgressFiller2.TabIndex = 6
        Me.ProgressFiller2.Visible = False
        '
        'F_ImportedPersonList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 569)
        Me.Controls.Add(Me.ImportedPersonListDataListView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_ImportedPersonList"
        Me.ShowInTaskbar = False
        Me.Text = "Kontrahentų importas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.ImportedPersonListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImportedPersonListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PasteButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileButton As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents ImportedPersonListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ImportedPersonListDataListView As BrightIdeasSoftware.DataListView
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
    Friend WithEvents OlvColumn23 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
End Class
