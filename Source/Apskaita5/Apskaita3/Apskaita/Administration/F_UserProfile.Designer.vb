﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_UserProfile
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
        Dim DetailsLabel As System.Windows.Forms.Label
        Dim PositionLabel As System.Windows.Forms.Label
        Dim RealNameLabel As System.Windows.Forms.Label
        Dim SignatureLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_UserProfile))
        Me.UserProfileBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DetailsTextBox = New System.Windows.Forms.TextBox
        Me.PositionTextBox = New System.Windows.Forms.TextBox
        Me.RealNameTextBox = New System.Windows.Forms.TextBox
        Me.SignaturePictureBox = New System.Windows.Forms.PictureBox
        Me.UpdateDeniedByServerPoliticsCheckBox = New System.Windows.Forms.CheckBox
        Me.ClearImageButton = New System.Windows.Forms.Button
        Me.OpenImageButton = New System.Windows.Forms.Button
        Me.ApplyButtonI = New System.Windows.Forms.Button
        Me.OkButtonI = New System.Windows.Forms.Button
        Me.CancelButtonI = New System.Windows.Forms.Button
        DetailsLabel = New System.Windows.Forms.Label
        PositionLabel = New System.Windows.Forms.Label
        RealNameLabel = New System.Windows.Forms.Label
        SignatureLabel = New System.Windows.Forms.Label
        CType(Me.UserProfileBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SignaturePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DetailsLabel
        '
        DetailsLabel.AutoSize = True
        DetailsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DetailsLabel.Location = New System.Drawing.Point(56, 41)
        DetailsLabel.Name = "DetailsLabel"
        DetailsLabel.Size = New System.Drawing.Size(54, 13)
        DetailsLabel.TabIndex = 1
        DetailsLabel.Text = "Detalės:"
        '
        'PositionLabel
        '
        PositionLabel.AutoSize = True
        PositionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PositionLabel.Location = New System.Drawing.Point(335, 15)
        PositionLabel.Name = "PositionLabel"
        PositionLabel.Size = New System.Drawing.Size(60, 13)
        PositionLabel.TabIndex = 3
        PositionLabel.Text = "Pareigos:"
        '
        'RealNameLabel
        '
        RealNameLabel.AutoSize = True
        RealNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        RealNameLabel.Location = New System.Drawing.Point(6, 15)
        RealNameLabel.Name = "RealNameLabel"
        RealNameLabel.Size = New System.Drawing.Size(104, 13)
        RealNameLabel.TabIndex = 5
        RealNameLabel.Text = "Vardas, pavardė:"
        '
        'SignatureLabel
        '
        SignatureLabel.AutoSize = True
        SignatureLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SignatureLabel.Location = New System.Drawing.Point(54, 64)
        SignatureLabel.Name = "SignatureLabel"
        SignatureLabel.Size = New System.Drawing.Size(56, 13)
        SignatureLabel.TabIndex = 7
        SignatureLabel.Text = "Parašas:"
        '
        'UserProfileBindingSource
        '
        Me.UserProfileBindingSource.DataSource = GetType(AccDataAccessLayer.Security.UserProfile)
        '
        'DetailsTextBox
        '
        Me.DetailsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserProfileBindingSource, "Details", True))
        Me.DetailsTextBox.Location = New System.Drawing.Point(116, 38)
        Me.DetailsTextBox.MaxLength = 255
        Me.DetailsTextBox.Name = "DetailsTextBox"
        Me.DetailsTextBox.Size = New System.Drawing.Size(514, 20)
        Me.DetailsTextBox.TabIndex = 2
        '
        'PositionTextBox
        '
        Me.PositionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserProfileBindingSource, "Position", True))
        Me.PositionTextBox.Location = New System.Drawing.Point(401, 12)
        Me.PositionTextBox.MaxLength = 100
        Me.PositionTextBox.Name = "PositionTextBox"
        Me.PositionTextBox.Size = New System.Drawing.Size(229, 20)
        Me.PositionTextBox.TabIndex = 4
        '
        'RealNameTextBox
        '
        Me.RealNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserProfileBindingSource, "RealName", True))
        Me.RealNameTextBox.Location = New System.Drawing.Point(116, 12)
        Me.RealNameTextBox.MaxLength = 50
        Me.RealNameTextBox.Name = "RealNameTextBox"
        Me.RealNameTextBox.Size = New System.Drawing.Size(202, 20)
        Me.RealNameTextBox.TabIndex = 6
        '
        'SignaturePictureBox
        '
        Me.SignaturePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SignaturePictureBox.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.UserProfileBindingSource, "Signature", True))
        Me.SignaturePictureBox.Location = New System.Drawing.Point(116, 64)
        Me.SignaturePictureBox.MaximumSize = New System.Drawing.Size(236, 87)
        Me.SignaturePictureBox.Name = "SignaturePictureBox"
        Me.SignaturePictureBox.Size = New System.Drawing.Size(236, 87)
        Me.SignaturePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SignaturePictureBox.TabIndex = 8
        Me.SignaturePictureBox.TabStop = False
        '
        'UpdateDeniedByServerPoliticsCheckBox
        '
        Me.UpdateDeniedByServerPoliticsCheckBox.AutoSize = True
        Me.UpdateDeniedByServerPoliticsCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.UserProfileBindingSource, "UpdateDeniedByServerPolitics", True))
        Me.UpdateDeniedByServerPoliticsCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdateDeniedByServerPoliticsCheckBox.Location = New System.Drawing.Point(379, 73)
        Me.UpdateDeniedByServerPoliticsCheckBox.Name = "UpdateDeniedByServerPoliticsCheckBox"
        Me.UpdateDeniedByServerPoliticsCheckBox.Size = New System.Drawing.Size(251, 17)
        Me.UpdateDeniedByServerPoliticsCheckBox.TabIndex = 10
        Me.UpdateDeniedByServerPoliticsCheckBox.Text = "Serverio politika draudžia taisyti pačiam"
        '
        'ClearImageButton
        '
        Me.ClearImageButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearImageButton.Location = New System.Drawing.Point(24, 111)
        Me.ClearImageButton.Name = "ClearImageButton"
        Me.ClearImageButton.Size = New System.Drawing.Size(86, 23)
        Me.ClearImageButton.TabIndex = 12
        Me.ClearImageButton.Text = "Clear image"
        Me.ClearImageButton.UseVisualStyleBackColor = True
        '
        'OpenImageButton
        '
        Me.OpenImageButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenImageButton.Location = New System.Drawing.Point(24, 82)
        Me.OpenImageButton.Name = "OpenImageButton"
        Me.OpenImageButton.Size = New System.Drawing.Size(86, 23)
        Me.OpenImageButton.TabIndex = 11
        Me.OpenImageButton.Text = "Open file..."
        Me.OpenImageButton.UseVisualStyleBackColor = True
        '
        'ApplyButtonI
        '
        Me.ApplyButtonI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyButtonI.Location = New System.Drawing.Point(461, 128)
        Me.ApplyButtonI.Name = "ApplyButtonI"
        Me.ApplyButtonI.Size = New System.Drawing.Size(86, 23)
        Me.ApplyButtonI.TabIndex = 14
        Me.ApplyButtonI.Text = "Apply"
        Me.ApplyButtonI.UseVisualStyleBackColor = True
        '
        'OkButtonI
        '
        Me.OkButtonI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButtonI.Location = New System.Drawing.Point(367, 128)
        Me.OkButtonI.Name = "OkButtonI"
        Me.OkButtonI.Size = New System.Drawing.Size(86, 23)
        Me.OkButtonI.TabIndex = 13
        Me.OkButtonI.Text = "Ok"
        Me.OkButtonI.UseVisualStyleBackColor = True
        '
        'CancelButtonI
        '
        Me.CancelButtonI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelButtonI.Location = New System.Drawing.Point(556, 128)
        Me.CancelButtonI.Name = "CancelButtonI"
        Me.CancelButtonI.Size = New System.Drawing.Size(86, 23)
        Me.CancelButtonI.TabIndex = 15
        Me.CancelButtonI.Text = "Cancel"
        Me.CancelButtonI.UseVisualStyleBackColor = True
        '
        'F_UserProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 161)
        Me.Controls.Add(Me.ApplyButtonI)
        Me.Controls.Add(Me.OkButtonI)
        Me.Controls.Add(Me.CancelButtonI)
        Me.Controls.Add(Me.ClearImageButton)
        Me.Controls.Add(Me.OpenImageButton)
        Me.Controls.Add(DetailsLabel)
        Me.Controls.Add(Me.DetailsTextBox)
        Me.Controls.Add(PositionLabel)
        Me.Controls.Add(Me.PositionTextBox)
        Me.Controls.Add(RealNameLabel)
        Me.Controls.Add(Me.RealNameTextBox)
        Me.Controls.Add(SignatureLabel)
        Me.Controls.Add(Me.SignaturePictureBox)
        Me.Controls.Add(Me.UpdateDeniedByServerPoliticsCheckBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "F_UserProfile"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Vartotojo profilis"
        CType(Me.UserProfileBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SignaturePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UserProfileBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DetailsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PositionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RealNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SignaturePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UpdateDeniedByServerPoliticsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ClearImageButton As System.Windows.Forms.Button
    Friend WithEvents OpenImageButton As System.Windows.Forms.Button
    Friend WithEvents ApplyButtonI As System.Windows.Forms.Button
    Friend WithEvents OkButtonI As System.Windows.Forms.Button
    Friend WithEvents CancelButtonI As System.Windows.Forms.Button
End Class
