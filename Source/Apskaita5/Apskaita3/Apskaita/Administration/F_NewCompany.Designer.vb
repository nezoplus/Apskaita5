﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_NewCompany
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
        Dim CodeLabel As System.Windows.Forms.Label
        Dim CodeVATLabel As System.Windows.Forms.Label
        Dim HeadPersonLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim BaseCurrencyLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_NewCompany))
        Me.SaveCompanyButton = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CompanyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.BaseCurrencyComboBox = New System.Windows.Forms.ComboBox
        Me.CodeTextBox = New System.Windows.Forms.TextBox
        Me.CodeVATTextBox = New System.Windows.Forms.TextBox
        Me.HeadPersonTextBox = New System.Windows.Forms.TextBox
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.ReadWriteAuthorization1 = New Csla.Windows.ReadWriteAuthorization(Me.components)
        CodeLabel = New System.Windows.Forms.Label
        CodeVATLabel = New System.Windows.Forms.Label
        HeadPersonLabel = New System.Windows.Forms.Label
        NameLabel = New System.Windows.Forms.Label
        BaseCurrencyLabel = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'CodeLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(CodeLabel, False)
        CodeLabel.AutoSize = True
        CodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CodeLabel.Location = New System.Drawing.Point(52, 32)
        CodeLabel.Name = "CodeLabel"
        CodeLabel.Size = New System.Drawing.Size(89, 13)
        CodeLabel.TabIndex = 6
        CodeLabel.Text = "Įmonės kodas:"
        '
        'CodeVATLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(CodeVATLabel, False)
        CodeVATLabel.AutoSize = True
        CodeVATLabel.Location = New System.Drawing.Point(398, 32)
        CodeVATLabel.Name = "CodeVATLabel"
        CodeVATLabel.Size = New System.Drawing.Size(75, 13)
        CodeVATLabel.TabIndex = 10
        CodeVATLabel.Text = "PVM kodas:"
        '
        'HeadPersonLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(HeadPersonLabel, False)
        HeadPersonLabel.AutoSize = True
        HeadPersonLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        HeadPersonLabel.Location = New System.Drawing.Point(38, 58)
        HeadPersonLabel.Name = "HeadPersonLabel"
        HeadPersonLabel.Size = New System.Drawing.Size(103, 13)
        HeadPersonLabel.TabIndex = 14
        HeadPersonLabel.Text = "Įmonės vadovas:"
        '
        'NameLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(NameLabel, False)
        NameLabel.AutoSize = True
        NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameLabel.Location = New System.Drawing.Point(59, 6)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(82, 13)
        NameLabel.TabIndex = 20
        NameLabel.Text = "Pavadinimas:"
        '
        'BaseCurrencyLabel
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(BaseCurrencyLabel, False)
        BaseCurrencyLabel.AutoSize = True
        BaseCurrencyLabel.Location = New System.Drawing.Point(50, 84)
        BaseCurrencyLabel.Name = "BaseCurrencyLabel"
        BaseCurrencyLabel.Size = New System.Drawing.Size(91, 13)
        BaseCurrencyLabel.TabIndex = 20
        BaseCurrencyLabel.Text = "Bazinė valiuta:"
        '
        'SaveCompanyButton
        '
        Me.SaveCompanyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.SaveCompanyButton, False)
        Me.SaveCompanyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveCompanyButton.Location = New System.Drawing.Point(604, 6)
        Me.SaveCompanyButton.Name = "SaveCompanyButton"
        Me.SaveCompanyButton.Size = New System.Drawing.Size(88, 29)
        Me.SaveCompanyButton.TabIndex = 0
        Me.SaveCompanyButton.Text = "Registruoti"
        Me.SaveCompanyButton.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.Panel2, False)
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.SaveCompanyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 111)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(723, 38)
        Me.Panel2.TabIndex = 1
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.DataSource = Me.CompanyBindingSource
        '
        'CompanyBindingSource
        '
        Me.CompanyBindingSource.DataSource = GetType(ApskaitaObjects.General.Company)
        '
        'Panel3
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.Panel3, False)
        Me.Panel3.Controls.Add(BaseCurrencyLabel)
        Me.Panel3.Controls.Add(Me.BaseCurrencyComboBox)
        Me.Panel3.Controls.Add(CodeLabel)
        Me.Panel3.Controls.Add(Me.CodeTextBox)
        Me.Panel3.Controls.Add(CodeVATLabel)
        Me.Panel3.Controls.Add(Me.CodeVATTextBox)
        Me.Panel3.Controls.Add(HeadPersonLabel)
        Me.Panel3.Controls.Add(Me.HeadPersonTextBox)
        Me.Panel3.Controls.Add(NameLabel)
        Me.Panel3.Controls.Add(Me.NameTextBox)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(723, 111)
        Me.Panel3.TabIndex = 0
        '
        'BaseCurrencyComboBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.BaseCurrencyComboBox, False)
        Me.BaseCurrencyComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyBindingSource, "BaseCurrency", True))
        Me.BaseCurrencyComboBox.FormattingEnabled = True
        Me.BaseCurrencyComboBox.Location = New System.Drawing.Point(147, 81)
        Me.BaseCurrencyComboBox.Name = "BaseCurrencyComboBox"
        Me.BaseCurrencyComboBox.Size = New System.Drawing.Size(121, 21)
        Me.BaseCurrencyComboBox.TabIndex = 4
        '
        'CodeTextBox
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.CodeTextBox, True)
        Me.CodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyBindingSource, "Code", True))
        Me.CodeTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodeTextBox.Location = New System.Drawing.Point(147, 29)
        Me.CodeTextBox.MaxLength = 20
        Me.CodeTextBox.Name = "CodeTextBox"
        Me.CodeTextBox.Size = New System.Drawing.Size(223, 20)
        Me.CodeTextBox.TabIndex = 1
        Me.CodeTextBox.Tag = ""
        '
        'CodeVATTextBox
        '
        Me.CodeVATTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.CodeVATTextBox, True)
        Me.CodeVATTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyBindingSource, "CodeVAT", True))
        Me.CodeVATTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodeVATTextBox.Location = New System.Drawing.Point(479, 29)
        Me.CodeVATTextBox.MaxLength = 20
        Me.CodeVATTextBox.Name = "CodeVATTextBox"
        Me.CodeVATTextBox.Size = New System.Drawing.Size(213, 20)
        Me.CodeVATTextBox.TabIndex = 2
        '
        'HeadPersonTextBox
        '
        Me.HeadPersonTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.HeadPersonTextBox, True)
        Me.HeadPersonTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyBindingSource, "HeadPerson", True))
        Me.HeadPersonTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeadPersonTextBox.Location = New System.Drawing.Point(147, 55)
        Me.HeadPersonTextBox.MaxLength = 255
        Me.HeadPersonTextBox.Name = "HeadPersonTextBox"
        Me.HeadPersonTextBox.Size = New System.Drawing.Size(545, 20)
        Me.HeadPersonTextBox.TabIndex = 3
        '
        'NameTextBox
        '
        Me.NameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me.NameTextBox, True)
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyBindingSource, "Name", True))
        Me.NameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameTextBox.Location = New System.Drawing.Point(147, 3)
        Me.NameTextBox.MaxLength = 255
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(545, 20)
        Me.NameTextBox.TabIndex = 0
        '
        'F_NewCompany
        '
        Me.ReadWriteAuthorization1.SetApplyAuthorization(Me, False)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 149)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "F_NewCompany"
        Me.ShowInTaskbar = False
        Me.Text = "Naujos įmonės registravimas duomenų bazėje"
        Me.Panel2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveCompanyButton As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CompanyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodeVATTextBox As System.Windows.Forms.TextBox
    Friend WithEvents HeadPersonTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ReadWriteAuthorization1 As Csla.Windows.ReadWriteAuthorization
    Friend WithEvents BaseCurrencyComboBox As System.Windows.Forms.ComboBox
End Class
