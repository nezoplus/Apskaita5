<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LocalUserListUserControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LocalUserListDataGridView = New System.Windows.Forms.DataGridView
        Me.LocalUserListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConnectionTechnologyHumanReadableDataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.SqlServerTypeHumanReadableDataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DatabaseNamingConvention = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UseSSL = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.SslCertificateFile = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CannotSetGrants = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.LocalUserListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LocalUserListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LocalUserListDataGridView)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(480, 420)
        Me.Panel1.TabIndex = 0
        '
        'LocalUserListDataGridView
        '
        Me.LocalUserListDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LocalUserListDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.LocalUserListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LocalUserListDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.ConnectionTechnologyHumanReadableDataGridViewComboBoxColumn, Me.SqlServerTypeHumanReadableDataGridViewComboBoxColumn, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn4, Me.DatabaseNamingConvention, Me.UseSSL, Me.SslCertificateFile, Me.CannotSetGrants})
        Me.LocalUserListDataGridView.DataSource = Me.LocalUserListBindingSource
        Me.LocalUserListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LocalUserListDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.LocalUserListDataGridView.Name = "LocalUserListDataGridView"
        Me.LocalUserListDataGridView.Size = New System.Drawing.Size(480, 420)
        Me.LocalUserListDataGridView.TabIndex = 0
        '
        'LocalUserListBindingSource
        '
        Me.LocalUserListBindingSource.DataSource = GetType(AccDataAccessLayer.Security.LocalUser)
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Name"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Vartotojo vardas"
        Me.DataGridViewTextBoxColumn2.MaxInputLength = 100
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'ConnectionTechnologyHumanReadableDataGridViewComboBoxColumn
        '
        Me.ConnectionTechnologyHumanReadableDataGridViewComboBoxColumn.DataPropertyName = "ConnectionTechnologyHumanReadable"
        Me.ConnectionTechnologyHumanReadableDataGridViewComboBoxColumn.HeaderText = "Ryšio technologija"
        Me.ConnectionTechnologyHumanReadableDataGridViewComboBoxColumn.Name = "ConnectionTechnologyHumanReadableDataGridViewComboBoxColumn"
        Me.ConnectionTechnologyHumanReadableDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ConnectionTechnologyHumanReadableDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'SqlServerTypeHumanReadableDataGridViewComboBoxColumn
        '
        Me.SqlServerTypeHumanReadableDataGridViewComboBoxColumn.DataPropertyName = "SqlServerTypeHumanReadable"
        Me.SqlServerTypeHumanReadableDataGridViewComboBoxColumn.HeaderText = "SQL serverio tipas"
        Me.SqlServerTypeHumanReadableDataGridViewComboBoxColumn.Name = "SqlServerTypeHumanReadableDataGridViewComboBoxColumn"
        Me.SqlServerTypeHumanReadableDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SqlServerTypeHumanReadableDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "SqlServerAddress"
        Me.DataGridViewTextBoxColumn6.HeaderText = "SQL serverio adresas"
        Me.DataGridViewTextBoxColumn6.MaxInputLength = 500
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "SqlServerPort"
        Me.DataGridViewTextBoxColumn7.HeaderText = "SQL serverio portas"
        Me.DataGridViewTextBoxColumn7.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ApplicationServerURL"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Application Server URL"
        Me.DataGridViewTextBoxColumn4.MaxInputLength = 500
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DatabaseNamingConvention
        '
        Me.DatabaseNamingConvention.DataPropertyName = "DatabaseNamingConvention"
        Me.DatabaseNamingConvention.HeaderText = "DB pavadinimo šablonas"
        Me.DatabaseNamingConvention.Name = "DatabaseNamingConvention"
        '
        'UseSSL
        '
        Me.UseSSL.DataPropertyName = "UseSSL"
        Me.UseSSL.HeaderText = "Naudoti SSL"
        Me.UseSSL.Name = "UseSSL"
        '
        'SslCertificateFile
        '
        Me.SslCertificateFile.DataPropertyName = "SslCertificateFile"
        Me.SslCertificateFile.HeaderText = "SSL sertifikato failas"
        Me.SslCertificateFile.Name = "SslCertificateFile"
        '
        'CannotSetGrants
        '
        Me.CannotSetGrants.DataPropertyName = "CannotSetGrants"
        Me.CannotSetGrants.HeaderText = "Nenaudoti SQL admin. funkcijų"
        Me.CannotSetGrants.Name = "CannotSetGrants"
        '
        'LocalUserListUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Name = "LocalUserListUserControl"
        Me.Size = New System.Drawing.Size(480, 420)
        Me.Panel1.ResumeLayout(False)
        CType(Me.LocalUserListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LocalUserListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LocalUserListDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents LocalUserListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConnectionTechnologyHumanReadableDataGridViewComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SqlServerTypeHumanReadableDataGridViewComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DatabaseNamingConvention As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UseSSL As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SslCertificateFile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CannotSetGrants As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
