<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_ConsolidatedReportsStructure
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_ConsolidatedReportsStructure))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.RemoveItemButton = New System.Windows.Forms.Button
        Me.ItemDownButton = New System.Windows.Forms.Button
        Me.ItemUpButton = New System.Windows.Forms.Button
        Me.AddItemButton = New System.Windows.Forms.Button
        Me.GetNewFormButton = New System.Windows.Forms.Button
        Me.SaveInDatabaseButton = New System.Windows.Forms.Button
        Me.SaveAsFileButton = New System.Windows.Forms.Button
        Me.OpenFileButton = New System.Windows.Forms.Button
        Me.FetchFromDatabaseButton = New System.Windows.Forms.Button
        Me.ReportView = New System.Windows.Forms.TreeView
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.RemoveItemButton)
        Me.Panel1.Controls.Add(Me.ItemDownButton)
        Me.Panel1.Controls.Add(Me.ItemUpButton)
        Me.Panel1.Controls.Add(Me.AddItemButton)
        Me.Panel1.Controls.Add(Me.GetNewFormButton)
        Me.Panel1.Controls.Add(Me.SaveInDatabaseButton)
        Me.Panel1.Controls.Add(Me.SaveAsFileButton)
        Me.Panel1.Controls.Add(Me.OpenFileButton)
        Me.Panel1.Controls.Add(Me.FetchFromDatabaseButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(575, 74)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(305, 5)
        Me.Label1.MaximumSize = New System.Drawing.Size(150, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 65)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "* Varnelėmis žymimos tos ataskaitų eiltės, kuriose kreditinis likutis turi būti a" & _
            "tvaizduojamas kaip teigiamas skaičius."
        '
        'RemoveItemButton
        '
        Me.RemoveItemButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveItemButton.Location = New System.Drawing.Point(475, 38)
        Me.RemoveItemButton.Name = "RemoveItemButton"
        Me.RemoveItemButton.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.RemoveItemButton.Size = New System.Drawing.Size(33, 33)
        Me.RemoveItemButton.TabIndex = 9
        Me.RemoveItemButton.Text = "-"
        Me.RemoveItemButton.UseVisualStyleBackColor = True
        '
        'ItemDownButton
        '
        Me.ItemDownButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemDownButton.Location = New System.Drawing.Point(514, 38)
        Me.ItemDownButton.Name = "ItemDownButton"
        Me.ItemDownButton.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ItemDownButton.Size = New System.Drawing.Size(33, 33)
        Me.ItemDownButton.TabIndex = 8
        Me.ItemDownButton.Text = "v"
        Me.ItemDownButton.UseVisualStyleBackColor = True
        '
        'ItemUpButton
        '
        Me.ItemUpButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemUpButton.Location = New System.Drawing.Point(514, 5)
        Me.ItemUpButton.Name = "ItemUpButton"
        Me.ItemUpButton.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ItemUpButton.Size = New System.Drawing.Size(33, 33)
        Me.ItemUpButton.TabIndex = 7
        Me.ItemUpButton.Text = "^"
        Me.ItemUpButton.UseVisualStyleBackColor = True
        '
        'AddItemButton
        '
        Me.AddItemButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddItemButton.Location = New System.Drawing.Point(475, 5)
        Me.AddItemButton.Name = "AddItemButton"
        Me.AddItemButton.Size = New System.Drawing.Size(33, 33)
        Me.AddItemButton.TabIndex = 6
        Me.AddItemButton.Text = "+"
        Me.AddItemButton.UseVisualStyleBackColor = True
        '
        'GetNewFormButton
        '
        Me.GetNewFormButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetNewFormButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Action_file_new_icon_24p
        Me.GetNewFormButton.Location = New System.Drawing.Point(128, 12)
        Me.GetNewFormButton.Name = "GetNewFormButton"
        Me.GetNewFormButton.Size = New System.Drawing.Size(43, 43)
        Me.GetNewFormButton.TabIndex = 5
        Me.GetNewFormButton.UseVisualStyleBackColor = True
        '
        'SaveInDatabaseButton
        '
        Me.SaveInDatabaseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveInDatabaseButton.Image = Global.ApskaitaWUI.My.Resources.Resources.database_save
        Me.SaveInDatabaseButton.Location = New System.Drawing.Point(68, 12)
        Me.SaveInDatabaseButton.Name = "SaveInDatabaseButton"
        Me.SaveInDatabaseButton.Size = New System.Drawing.Size(43, 43)
        Me.SaveInDatabaseButton.TabIndex = 4
        Me.SaveInDatabaseButton.UseVisualStyleBackColor = True
        '
        'SaveAsFileButton
        '
        Me.SaveAsFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveAsFileButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Actions_document_save_icon_24p
        Me.SaveAsFileButton.Location = New System.Drawing.Point(241, 12)
        Me.SaveAsFileButton.Name = "SaveAsFileButton"
        Me.SaveAsFileButton.Size = New System.Drawing.Size(35, 33)
        Me.SaveAsFileButton.TabIndex = 3
        Me.SaveAsFileButton.UseVisualStyleBackColor = True
        '
        'OpenFileButton
        '
        Me.OpenFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenFileButton.Image = Global.ApskaitaWUI.My.Resources.Resources.folder_open_icon_24p
        Me.OpenFileButton.Location = New System.Drawing.Point(190, 12)
        Me.OpenFileButton.Name = "OpenFileButton"
        Me.OpenFileButton.Size = New System.Drawing.Size(35, 33)
        Me.OpenFileButton.TabIndex = 2
        Me.OpenFileButton.UseVisualStyleBackColor = True
        '
        'FetchFromDatabaseButton
        '
        Me.FetchFromDatabaseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FetchFromDatabaseButton.Image = Global.ApskaitaWUI.My.Resources.Resources.database_refresh
        Me.FetchFromDatabaseButton.Location = New System.Drawing.Point(10, 12)
        Me.FetchFromDatabaseButton.Name = "FetchFromDatabaseButton"
        Me.FetchFromDatabaseButton.Size = New System.Drawing.Size(43, 43)
        Me.FetchFromDatabaseButton.TabIndex = 1
        Me.FetchFromDatabaseButton.UseVisualStyleBackColor = True
        '
        'ReportView
        '
        Me.ReportView.CheckBoxes = True
        Me.ReportView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportView.HideSelection = False
        Me.ReportView.LabelEdit = True
        Me.ReportView.Location = New System.Drawing.Point(0, 74)
        Me.ReportView.Name = "ReportView"
        Me.ReportView.Size = New System.Drawing.Size(575, 496)
        Me.ReportView.TabIndex = 1
        '
        'F_ConsolidatedReportsStructure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 570)
        Me.Controls.Add(Me.ReportView)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_ConsolidatedReportsStructure"
        Me.Text = "Finansinės atskaitomybės dokumentų struktūra"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FetchFromDatabaseButton As System.Windows.Forms.Button
    Friend WithEvents GetNewFormButton As System.Windows.Forms.Button
    Friend WithEvents SaveInDatabaseButton As System.Windows.Forms.Button
    Friend WithEvents SaveAsFileButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileButton As System.Windows.Forms.Button
    Friend WithEvents ItemDownButton As System.Windows.Forms.Button
    Friend WithEvents ItemUpButton As System.Windows.Forms.Button
    Friend WithEvents AddItemButton As System.Windows.Forms.Button
    Friend WithEvents ReportView As System.Windows.Forms.TreeView
    Friend WithEvents RemoveItemButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
