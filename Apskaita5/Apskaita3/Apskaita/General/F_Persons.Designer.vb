<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Persons
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_Persons))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RefreshButton = New System.Windows.Forms.Button
        Me.LikeStringTextBox = New System.Windows.Forms.TextBox
        Me.ShowClientsCheckBox = New System.Windows.Forms.CheckBox
        Me.ShowWorkersCheckBox = New System.Windows.Forms.CheckBox
        Me.ShowsuppliersCheckBox = New System.Windows.Forms.CheckBox
        Me.PersonInfoItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PersonInfoItemListDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn5 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.PersonInfoItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PersonInfoItemListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.RefreshButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Button_Reload_icon_24p
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
        'PersonInfoItemListDataGridView
        '
        Me.PersonInfoItemListDataGridView.AllowUserToAddRows = False
        Me.PersonInfoItemListDataGridView.AllowUserToDeleteRows = False
        Me.PersonInfoItemListDataGridView.AllowUserToOrderColumns = True
        Me.PersonInfoItemListDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PersonInfoItemListDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.PersonInfoItemListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PersonInfoItemListDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewCheckBoxColumn3, Me.DataGridViewTextBoxColumn15, Me.DataGridViewCheckBoxColumn4, Me.DataGridViewTextBoxColumn16, Me.DataGridViewCheckBoxColumn5, Me.DataGridViewTextBoxColumn8, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewCheckBoxColumn2})
        Me.PersonInfoItemListDataGridView.DataSource = Me.PersonInfoItemListBindingSource
        Me.PersonInfoItemListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonInfoItemListDataGridView.Location = New System.Drawing.Point(0, 42)
        Me.PersonInfoItemListDataGridView.Name = "PersonInfoItemListDataGridView"
        Me.PersonInfoItemListDataGridView.ReadOnly = True
        Me.PersonInfoItemListDataGridView.RowHeadersVisible = False
        Me.PersonInfoItemListDataGridView.Size = New System.Drawing.Size(848, 382)
        Me.PersonInfoItemListDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Name"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Pavadinimas"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Code"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Įmonės/ Asmens Kodas"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "CodeVAT"
        Me.DataGridViewTextBoxColumn7.HeaderText = "PVM Mokėtojo Kodas"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "InternalCode"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Vidinis kodas"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Address"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Adresas"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "CurrencyCode"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Valiuta"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Bank"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Bankas"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "BankAccount"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Banko Sąskaita"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "LanguageName"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Kalba"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Email"
        Me.DataGridViewTextBoxColumn9.HeaderText = "E-Paštas"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "ContactInfo"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Kontaktinė Info"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "IsClient"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "Pirkėjas"
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "AccountAgainstBankBuyer"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Koresp. Pirkėjo Sąsk."
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewCheckBoxColumn4
        '
        Me.DataGridViewCheckBoxColumn4.DataPropertyName = "IsSupplier"
        Me.DataGridViewCheckBoxColumn4.HeaderText = "Tiekėjas"
        Me.DataGridViewCheckBoxColumn4.Name = "DataGridViewCheckBoxColumn4"
        Me.DataGridViewCheckBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "AccountAgainstBankSupplyer"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Koresp. Tiekėjo Sąsk."
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewCheckBoxColumn5
        '
        Me.DataGridViewCheckBoxColumn5.DataPropertyName = "IsWorker"
        Me.DataGridViewCheckBoxColumn5.HeaderText = "Darbuotojas"
        Me.DataGridViewCheckBoxColumn5.Name = "DataGridViewCheckBoxColumn5"
        Me.DataGridViewCheckBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "CodeSODRA"
        Me.DataGridViewTextBoxColumn8.HeaderText = "SODRA kodas"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "IsNaturalPerson"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Fizinis asmuo"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        Me.DataGridViewCheckBoxColumn1.Visible = False
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "IsObsolete"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Archyvinis"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.ReadOnly = True
        Me.DataGridViewCheckBoxColumn2.Visible = False
        '
        'F_Persons
        '
        Me.AcceptButton = Me.RefreshButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 424)
        Me.Controls.Add(Me.PersonInfoItemListDataGridView)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_Persons"
        Me.ShowInTaskbar = False
        Me.Text = "Kontrahentai"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PersonInfoItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PersonInfoItemListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents PersonInfoItemListDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
