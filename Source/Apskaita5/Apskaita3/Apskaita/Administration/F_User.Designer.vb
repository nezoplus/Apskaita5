﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_User
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
        Dim PositionLabel As System.Windows.Forms.Label
        Dim PasswordLabel As System.Windows.Forms.Label
        Dim HostLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim RealNameLabel As System.Windows.Forms.Label
        Dim DetailsLabel As System.Windows.Forms.Label
        Dim PasswordRepeatedLabel As System.Windows.Forms.Label
        Dim SignatureLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_User))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.UserInfoListDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserInfoListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RefreshButton = New System.Windows.Forms.Button
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.RolesDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RolesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UserBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RoleListDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.RoleListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.EditedBaner = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.ApplyButtonI = New System.Windows.Forms.Button
        Me.OkButtonI = New System.Windows.Forms.Button
        Me.CancelButtonI = New System.Windows.Forms.Button
        Me.ClearImageButton = New System.Windows.Forms.Button
        Me.OpenImageButton = New System.Windows.Forms.Button
        Me.PasswordTextBox = New System.Windows.Forms.TextBox
        Me.IsAdminCheckBox = New System.Windows.Forms.CheckBox
        Me.SignaturePictureBox = New System.Windows.Forms.PictureBox
        Me.PasswordRepeatedTextBox = New System.Windows.Forms.TextBox
        Me.RealNameTextBox = New System.Windows.Forms.TextBox
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.DetailsTextBox = New System.Windows.Forms.TextBox
        Me.HostTextBox = New System.Windows.Forms.TextBox
        Me.PositionTextBox = New System.Windows.Forms.TextBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        PositionLabel = New System.Windows.Forms.Label
        PasswordLabel = New System.Windows.Forms.Label
        HostLabel = New System.Windows.Forms.Label
        NameLabel = New System.Windows.Forms.Label
        RealNameLabel = New System.Windows.Forms.Label
        DetailsLabel = New System.Windows.Forms.Label
        PasswordRepeatedLabel = New System.Windows.Forms.Label
        SignatureLabel = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.UserInfoListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserInfoListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.RolesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RolesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RoleListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RoleListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.EditedBaner.SuspendLayout()
        CType(Me.SignaturePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PositionLabel
        '
        PositionLabel.AutoSize = True
        PositionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PositionLabel.Location = New System.Drawing.Point(349, 60)
        PositionLabel.Name = "PositionLabel"
        PositionLabel.Size = New System.Drawing.Size(60, 13)
        PositionLabel.TabIndex = 18
        PositionLabel.Text = "Pareigos:"
        '
        'PasswordLabel
        '
        PasswordLabel.AutoSize = True
        PasswordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PasswordLabel.Location = New System.Drawing.Point(20, 34)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New System.Drawing.Size(76, 13)
        PasswordLabel.TabIndex = 14
        PasswordLabel.Text = "Slaptažodis:"
        '
        'HostLabel
        '
        HostLabel.AutoSize = True
        HostLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        HostLabel.Location = New System.Drawing.Point(317, 8)
        HostLabel.Name = "HostLabel"
        HostLabel.Size = New System.Drawing.Size(92, 13)
        HostLabel.TabIndex = 2
        HostLabel.Text = "Vartotojo sritis:"
        '
        'NameLabel
        '
        NameLabel.AutoSize = True
        NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameLabel.Location = New System.Drawing.Point(46, 8)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(50, 13)
        NameLabel.TabIndex = 10
        NameLabel.Text = "Vardas:"
        '
        'RealNameLabel
        '
        RealNameLabel.AutoSize = True
        RealNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        RealNameLabel.Location = New System.Drawing.Point(8, 60)
        RealNameLabel.Name = "RealNameLabel"
        RealNameLabel.Size = New System.Drawing.Size(88, 13)
        RealNameLabel.TabIndex = 20
        RealNameLabel.Text = "Tikras vardas:"
        '
        'DetailsLabel
        '
        DetailsLabel.AutoSize = True
        DetailsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DetailsLabel.Location = New System.Drawing.Point(42, 86)
        DetailsLabel.Name = "DetailsLabel"
        DetailsLabel.Size = New System.Drawing.Size(54, 13)
        DetailsLabel.TabIndex = 0
        DetailsLabel.Text = "Detalės:"
        '
        'PasswordRepeatedLabel
        '
        PasswordRepeatedLabel.AutoSize = True
        PasswordRepeatedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PasswordRepeatedLabel.Location = New System.Drawing.Point(301, 34)
        PasswordRepeatedLabel.Name = "PasswordRepeatedLabel"
        PasswordRepeatedLabel.Size = New System.Drawing.Size(120, 13)
        PasswordRepeatedLabel.TabIndex = 16
        PasswordRepeatedLabel.Text = "Slaptažodis pakart.:"
        '
        'SignatureLabel
        '
        SignatureLabel.AutoSize = True
        SignatureLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SignatureLabel.Location = New System.Drawing.Point(40, 140)
        SignatureLabel.Name = "SignatureLabel"
        SignatureLabel.Size = New System.Drawing.Size(56, 13)
        SignatureLabel.TabIndex = 22
        SignatureLabel.Text = "Parašas:"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.UserInfoListDataGridView)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(863, 509)
        Me.SplitContainer1.SplitterDistance = 223
        Me.SplitContainer1.TabIndex = 0
        '
        'UserInfoListDataGridView
        '
        Me.UserInfoListDataGridView.AllowUserToAddRows = False
        Me.UserInfoListDataGridView.AllowUserToDeleteRows = False
        Me.UserInfoListDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.UserInfoListDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.UserInfoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UserInfoListDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.UserInfoListDataGridView.DataSource = Me.UserInfoListBindingSource
        Me.UserInfoListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserInfoListDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.UserInfoListDataGridView.Name = "UserInfoListDataGridView"
        Me.UserInfoListDataGridView.RowHeadersVisible = False
        Me.UserInfoListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UserInfoListDataGridView.Size = New System.Drawing.Size(223, 457)
        Me.UserInfoListDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Name"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Vardas"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "RealName"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Tikras vardas"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'UserInfoListBindingSource
        '
        Me.UserInfoListBindingSource.DataSource = GetType(AccDataAccessLayer.Security.UserAdministration.UserInfo)
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.RefreshButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 457)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.Panel1.Size = New System.Drawing.Size(223, 52)
        Me.Panel1.TabIndex = 0
        '
        'RefreshButton
        '
        Me.RefreshButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RefreshButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefreshButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Button_Reload_icon_24p
        Me.RefreshButton.Location = New System.Drawing.Point(85, 8)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(39, 36)
        Me.RefreshButton.TabIndex = 0
        Me.RefreshButton.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 233)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.AutoScroll = True
        Me.SplitContainer2.Panel1.Controls.Add(Me.RolesDataGridView)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.RoleListDataGridView)
        Me.SplitContainer2.Size = New System.Drawing.Size(636, 276)
        Me.SplitContainer2.SplitterDistance = 231
        Me.SplitContainer2.TabIndex = 1
        '
        'RolesDataGridView
        '
        Me.RolesDataGridView.AllowUserToAddRows = False
        Me.RolesDataGridView.AllowUserToDeleteRows = False
        Me.RolesDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RolesDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.RolesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RolesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn4})
        Me.RolesDataGridView.DataSource = Me.RolesBindingSource
        Me.RolesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RolesDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.RolesDataGridView.MultiSelect = False
        Me.RolesDataGridView.Name = "RolesDataGridView"
        Me.RolesDataGridView.ReadOnly = True
        Me.RolesDataGridView.RowHeadersVisible = False
        Me.RolesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.RolesDataGridView.Size = New System.Drawing.Size(231, 276)
        Me.RolesDataGridView.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DatabaseName"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Database"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "CompanyName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Įmonė"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'RolesBindingSource
        '
        Me.RolesBindingSource.DataMember = "Roles"
        Me.RolesBindingSource.DataSource = Me.UserBindingSource
        '
        'UserBindingSource
        '
        Me.UserBindingSource.DataSource = GetType(AccDataAccessLayer.Security.UserAdministration.User)
        '
        'RoleListDataGridView
        '
        Me.RoleListDataGridView.AllowUserToAddRows = False
        Me.RoleListDataGridView.AllowUserToDeleteRows = False
        Me.RoleListDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RoleListDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.RoleListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RoleListDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewCheckBoxColumn3})
        Me.RoleListDataGridView.DataSource = Me.RoleListBindingSource
        Me.RoleListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RoleListDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.RoleListDataGridView.Name = "RoleListDataGridView"
        Me.RoleListDataGridView.RowHeadersVisible = False
        Me.RoleListDataGridView.Size = New System.Drawing.Size(401, 276)
        Me.RoleListDataGridView.TabIndex = 0
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "RoleNameHumanReadable"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Teisių objektas"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "LevelRead"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Skaityti"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 55
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "LevelWrite"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Įvesti"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Width = 44
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "LevelUpdate"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "Keisti"
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.Width = 44
        '
        'RoleListBindingSource
        '
        Me.RoleListBindingSource.DataMember = "RoleList"
        Me.RoleListBindingSource.DataSource = Me.RolesBindingSource
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.EditedBaner)
        Me.Panel2.Controls.Add(Me.ApplyButtonI)
        Me.Panel2.Controls.Add(Me.OkButtonI)
        Me.Panel2.Controls.Add(Me.CancelButtonI)
        Me.Panel2.Controls.Add(Me.ClearImageButton)
        Me.Panel2.Controls.Add(Me.OpenImageButton)
        Me.Panel2.Controls.Add(SignatureLabel)
        Me.Panel2.Controls.Add(Me.PasswordTextBox)
        Me.Panel2.Controls.Add(Me.IsAdminCheckBox)
        Me.Panel2.Controls.Add(PasswordRepeatedLabel)
        Me.Panel2.Controls.Add(Me.SignaturePictureBox)
        Me.Panel2.Controls.Add(Me.PasswordRepeatedTextBox)
        Me.Panel2.Controls.Add(DetailsLabel)
        Me.Panel2.Controls.Add(Me.RealNameTextBox)
        Me.Panel2.Controls.Add(Me.NameTextBox)
        Me.Panel2.Controls.Add(RealNameLabel)
        Me.Panel2.Controls.Add(Me.DetailsTextBox)
        Me.Panel2.Controls.Add(Me.HostTextBox)
        Me.Panel2.Controls.Add(NameLabel)
        Me.Panel2.Controls.Add(Me.PositionTextBox)
        Me.Panel2.Controls.Add(HostLabel)
        Me.Panel2.Controls.Add(PasswordLabel)
        Me.Panel2.Controls.Add(PositionLabel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Panel2.Size = New System.Drawing.Size(636, 233)
        Me.Panel2.TabIndex = 0
        '
        'EditedBaner
        '
        Me.EditedBaner.BackColor = System.Drawing.Color.Red
        Me.EditedBaner.Controls.Add(Me.Label4)
        Me.EditedBaner.Location = New System.Drawing.Point(352, 173)
        Me.EditedBaner.Name = "EditedBaner"
        Me.EditedBaner.Size = New System.Drawing.Size(83, 25)
        Me.EditedBaner.TabIndex = 52
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
        'ApplyButtonI
        '
        Me.ApplyButtonI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyButtonI.Location = New System.Drawing.Point(446, 204)
        Me.ApplyButtonI.Name = "ApplyButtonI"
        Me.ApplyButtonI.Size = New System.Drawing.Size(86, 23)
        Me.ApplyButtonI.TabIndex = 10
        Me.ApplyButtonI.Text = "Taikyti"
        Me.ApplyButtonI.UseVisualStyleBackColor = True
        '
        'OkButtonI
        '
        Me.OkButtonI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButtonI.Location = New System.Drawing.Point(352, 204)
        Me.OkButtonI.Name = "OkButtonI"
        Me.OkButtonI.Size = New System.Drawing.Size(86, 23)
        Me.OkButtonI.TabIndex = 9
        Me.OkButtonI.Text = "Ok"
        Me.OkButtonI.UseVisualStyleBackColor = True
        '
        'CancelButtonI
        '
        Me.CancelButtonI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelButtonI.Location = New System.Drawing.Point(541, 204)
        Me.CancelButtonI.Name = "CancelButtonI"
        Me.CancelButtonI.Size = New System.Drawing.Size(86, 23)
        Me.CancelButtonI.TabIndex = 11
        Me.CancelButtonI.Text = "Atšaukti"
        Me.CancelButtonI.UseVisualStyleBackColor = True
        '
        'ClearImageButton
        '
        Me.ClearImageButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearImageButton.Location = New System.Drawing.Point(4, 191)
        Me.ClearImageButton.Name = "ClearImageButton"
        Me.ClearImageButton.Size = New System.Drawing.Size(86, 23)
        Me.ClearImageButton.TabIndex = 8
        Me.ClearImageButton.Text = "Be parašo"
        Me.ClearImageButton.UseVisualStyleBackColor = True
        '
        'OpenImageButton
        '
        Me.OpenImageButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenImageButton.Location = New System.Drawing.Point(49, 158)
        Me.OpenImageButton.Name = "OpenImageButton"
        Me.OpenImageButton.Size = New System.Drawing.Size(41, 27)
        Me.OpenImageButton.TabIndex = 7
        Me.OpenImageButton.Text = "..."
        Me.OpenImageButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.OpenImageButton.UseVisualStyleBackColor = True
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserBindingSource, "Password", True))
        Me.PasswordTextBox.Location = New System.Drawing.Point(96, 31)
        Me.PasswordTextBox.MaxLength = 50
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(179, 20)
        Me.PasswordTextBox.TabIndex = 2
        '
        'IsAdminCheckBox
        '
        Me.IsAdminCheckBox.AutoSize = True
        Me.IsAdminCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.UserBindingSource, "IsAdmin", True))
        Me.IsAdminCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsAdminCheckBox.Location = New System.Drawing.Point(509, 140)
        Me.IsAdminCheckBox.Name = "IsAdminCheckBox"
        Me.IsAdminCheckBox.Size = New System.Drawing.Size(115, 17)
        Me.IsAdminCheckBox.TabIndex = 12
        Me.IsAdminCheckBox.Text = "Administratorius"
        '
        'SignaturePictureBox
        '
        Me.SignaturePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SignaturePictureBox.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.UserBindingSource, "Signature", True))
        Me.SignaturePictureBox.Location = New System.Drawing.Point(96, 140)
        Me.SignaturePictureBox.MaximumSize = New System.Drawing.Size(236, 87)
        Me.SignaturePictureBox.Name = "SignaturePictureBox"
        Me.SignaturePictureBox.Size = New System.Drawing.Size(236, 87)
        Me.SignaturePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SignaturePictureBox.TabIndex = 23
        Me.SignaturePictureBox.TabStop = False
        '
        'PasswordRepeatedTextBox
        '
        Me.PasswordRepeatedTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserBindingSource, "PasswordRepeated", True))
        Me.PasswordRepeatedTextBox.Location = New System.Drawing.Point(421, 31)
        Me.PasswordRepeatedTextBox.MaxLength = 50
        Me.PasswordRepeatedTextBox.Name = "PasswordRepeatedTextBox"
        Me.PasswordRepeatedTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordRepeatedTextBox.Size = New System.Drawing.Size(179, 20)
        Me.PasswordRepeatedTextBox.TabIndex = 3
        '
        'RealNameTextBox
        '
        Me.RealNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserBindingSource, "RealName", True))
        Me.RealNameTextBox.Location = New System.Drawing.Point(96, 57)
        Me.RealNameTextBox.MaxLength = 255
        Me.RealNameTextBox.Name = "RealNameTextBox"
        Me.RealNameTextBox.Size = New System.Drawing.Size(191, 20)
        Me.RealNameTextBox.TabIndex = 4
        '
        'NameTextBox
        '
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserBindingSource, "Name", True))
        Me.NameTextBox.Location = New System.Drawing.Point(96, 5)
        Me.NameTextBox.MaxLength = 50
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(191, 20)
        Me.NameTextBox.TabIndex = 0
        '
        'DetailsTextBox
        '
        Me.DetailsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserBindingSource, "Details", True))
        Me.DetailsTextBox.Location = New System.Drawing.Point(96, 83)
        Me.DetailsTextBox.MaxLength = 255
        Me.DetailsTextBox.Multiline = True
        Me.DetailsTextBox.Name = "DetailsTextBox"
        Me.DetailsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.DetailsTextBox.Size = New System.Drawing.Size(528, 51)
        Me.DetailsTextBox.TabIndex = 6
        '
        'HostTextBox
        '
        Me.HostTextBox.AutoCompleteCustomSource.AddRange(New String() {"localhost", "127.0.0.1", "%"})
        Me.HostTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.HostTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.HostTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserBindingSource, "Host", True))
        Me.HostTextBox.Location = New System.Drawing.Point(409, 5)
        Me.HostTextBox.MaxLength = 50
        Me.HostTextBox.Name = "HostTextBox"
        Me.HostTextBox.Size = New System.Drawing.Size(191, 20)
        Me.HostTextBox.TabIndex = 1
        '
        'PositionTextBox
        '
        Me.PositionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserBindingSource, "Position", True))
        Me.PositionTextBox.Location = New System.Drawing.Point(409, 57)
        Me.PositionTextBox.MaxLength = 50
        Me.PositionTextBox.Name = "PositionTextBox"
        Me.PositionTextBox.Size = New System.Drawing.Size(191, 20)
        Me.PositionTextBox.TabIndex = 5
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.DataSource = Me.UserBindingSource
        '
        'F_User
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 509)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_User"
        Me.ShowInTaskbar = False
        Me.Text = "Vartotojų administravimas"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.UserInfoListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserInfoListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.RolesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RolesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RoleListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RoleListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.EditedBaner.ResumeLayout(False)
        Me.EditedBaner.PerformLayout()
        CType(Me.SignaturePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents UserInfoListDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserInfoListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents UserBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IsAdminCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SignaturePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents PasswordRepeatedTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RealNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DetailsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents HostTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PositionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents RolesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RolesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RoleListDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents RoleListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ClearImageButton As System.Windows.Forms.Button
    Friend WithEvents OpenImageButton As System.Windows.Forms.Button
    Friend WithEvents ApplyButtonI As System.Windows.Forms.Button
    Friend WithEvents OkButtonI As System.Windows.Forms.Button
    Friend WithEvents CancelButtonI As System.Windows.Forms.Button
    Friend WithEvents EditedBaner As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
