<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_BackUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_BackUp))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.SaveToFileButton = New System.Windows.Forms.Button
        Me.OpenFileButton = New System.Windows.Forms.Button
        Me.SaveAsFileNameTextBox = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RecoverFromFileButton = New System.Windows.Forms.Button
        Me.OpenFileButton2 = New System.Windows.Forms.Button
        Me.OpenFileNameTextbox = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(12, 347)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(2, 2)
        Me.Panel1.TabIndex = 0
        '
        'SaveToFileButton
        '
        Me.SaveToFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveToFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveToFileButton.Location = New System.Drawing.Point(248, 37)
        Me.SaveToFileButton.Name = "SaveToFileButton"
        Me.SaveToFileButton.Size = New System.Drawing.Size(75, 23)
        Me.SaveToFileButton.TabIndex = 2
        Me.SaveToFileButton.Text = "Išsaugoti"
        Me.SaveToFileButton.UseVisualStyleBackColor = True
        '
        'OpenFileButton
        '
        Me.OpenFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpenFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenFileButton.Image = Global.ApskaitaWUI.My.Resources.Resources.folder_open_icon_16p
        Me.OpenFileButton.Location = New System.Drawing.Point(300, 11)
        Me.OpenFileButton.Name = "OpenFileButton"
        Me.OpenFileButton.Size = New System.Drawing.Size(25, 23)
        Me.OpenFileButton.TabIndex = 0
        Me.OpenFileButton.UseVisualStyleBackColor = True
        '
        'SaveAsFileNameTextBox
        '
        Me.SaveAsFileNameTextBox.AcceptsReturn = True
        Me.SaveAsFileNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveAsFileNameTextBox.Location = New System.Drawing.Point(10, 11)
        Me.SaveAsFileNameTextBox.Name = "SaveAsFileNameTextBox"
        Me.SaveAsFileNameTextBox.Size = New System.Drawing.Size(287, 20)
        Me.SaveAsFileNameTextBox.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Location = New System.Drawing.Point(12, 447)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(2, 2)
        Me.Panel2.TabIndex = 1
        '
        'RecoverFromFileButton
        '
        Me.RecoverFromFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RecoverFromFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecoverFromFileButton.Location = New System.Drawing.Point(246, 35)
        Me.RecoverFromFileButton.Name = "RecoverFromFileButton"
        Me.RecoverFromFileButton.Size = New System.Drawing.Size(75, 23)
        Me.RecoverFromFileButton.TabIndex = 2
        Me.RecoverFromFileButton.Text = "Atkurti"
        Me.RecoverFromFileButton.UseVisualStyleBackColor = True
        '
        'OpenFileButton2
        '
        Me.OpenFileButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpenFileButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenFileButton2.Image = Global.ApskaitaWUI.My.Resources.Resources.folder_open_icon_16p
        Me.OpenFileButton2.Location = New System.Drawing.Point(298, 9)
        Me.OpenFileButton2.Name = "OpenFileButton2"
        Me.OpenFileButton2.Size = New System.Drawing.Size(25, 23)
        Me.OpenFileButton2.TabIndex = 0
        Me.OpenFileButton2.UseVisualStyleBackColor = True
        '
        'OpenFileNameTextbox
        '
        Me.OpenFileNameTextbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpenFileNameTextbox.Location = New System.Drawing.Point(9, 9)
        Me.OpenFileNameTextbox.Name = "OpenFileNameTextbox"
        Me.OpenFileNameTextbox.Size = New System.Drawing.Size(287, 20)
        Me.OpenFileNameTextbox.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(339, 97)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SaveToFileButton)
        Me.TabPage1.Controls.Add(Me.SaveAsFileNameTextBox)
        Me.TabPage1.Controls.Add(Me.OpenFileButton)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(331, 71)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Daryti atsarginę kopiją"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.RecoverFromFileButton)
        Me.TabPage2.Controls.Add(Me.OpenFileNameTextbox)
        Me.TabPage2.Controls.Add(Me.OpenFileButton2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(331, 71)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Atkurti iš atsarginės kopijos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'F_BackUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 97)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "F_BackUp"
        Me.ShowInTaskbar = False
        Me.Text = "Atsarginės kopijos"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents OpenFileButton As System.Windows.Forms.Button
    Friend WithEvents SaveAsFileNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SaveToFileButton As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RecoverFromFileButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileButton2 As System.Windows.Forms.Button
    Friend WithEvents OpenFileNameTextbox As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
End Class
