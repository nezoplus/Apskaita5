<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_NewGoodsOperationSelector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_NewGoodsOperationSelector))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GoodsInfoListAccGridComboBox = New AccControls.AccGridComboBox
        Me.WarehouseInfoListAccGridComboBox = New AccControls.AccGridComboBox
        Me.SimpleOperationRadioButton = New System.Windows.Forms.RadioButton
        Me.ComplexOperationRadioButton = New System.Windows.Forms.RadioButton
        Me.SimpleOperationTypeComboBox = New System.Windows.Forms.ComboBox
        Me.ComplexOperationTypeComboBox = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CreateOperationButton = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.CalculationInfoListAccGridComboBox = New AccControls.AccGridComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.InventorizationDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Prekė:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Sandėlis:"
        '
        'GoodsInfoListAccGridComboBox
        '
        Me.GoodsInfoListAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GoodsInfoListAccGridComboBox.FilterPropertyName = ""
        Me.GoodsInfoListAccGridComboBox.FormattingEnabled = True
        Me.GoodsInfoListAccGridComboBox.InstantBinding = True
        Me.GoodsInfoListAccGridComboBox.Location = New System.Drawing.Point(89, 10)
        Me.GoodsInfoListAccGridComboBox.Name = "GoodsInfoListAccGridComboBox"
        Me.GoodsInfoListAccGridComboBox.Size = New System.Drawing.Size(453, 21)
        Me.GoodsInfoListAccGridComboBox.TabIndex = 0
        '
        'WarehouseInfoListAccGridComboBox
        '
        Me.WarehouseInfoListAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WarehouseInfoListAccGridComboBox.FilterPropertyName = ""
        Me.WarehouseInfoListAccGridComboBox.FormattingEnabled = True
        Me.WarehouseInfoListAccGridComboBox.InstantBinding = True
        Me.WarehouseInfoListAccGridComboBox.Location = New System.Drawing.Point(89, 37)
        Me.WarehouseInfoListAccGridComboBox.Name = "WarehouseInfoListAccGridComboBox"
        Me.WarehouseInfoListAccGridComboBox.Size = New System.Drawing.Size(453, 21)
        Me.WarehouseInfoListAccGridComboBox.TabIndex = 1
        '
        'SimpleOperationRadioButton
        '
        Me.SimpleOperationRadioButton.AutoSize = True
        Me.SimpleOperationRadioButton.Checked = True
        Me.SimpleOperationRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleOperationRadioButton.Location = New System.Drawing.Point(89, 64)
        Me.SimpleOperationRadioButton.Name = "SimpleOperationRadioButton"
        Me.SimpleOperationRadioButton.Size = New System.Drawing.Size(133, 17)
        Me.SimpleOperationRadioButton.TabIndex = 2
        Me.SimpleOperationRadioButton.TabStop = True
        Me.SimpleOperationRadioButton.Text = "Paprasta Operacija"
        Me.SimpleOperationRadioButton.UseVisualStyleBackColor = True
        '
        'ComplexOperationRadioButton
        '
        Me.ComplexOperationRadioButton.AutoSize = True
        Me.ComplexOperationRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComplexOperationRadioButton.Location = New System.Drawing.Point(89, 114)
        Me.ComplexOperationRadioButton.Name = "ComplexOperationRadioButton"
        Me.ComplexOperationRadioButton.Size = New System.Drawing.Size(154, 17)
        Me.ComplexOperationRadioButton.TabIndex = 4
        Me.ComplexOperationRadioButton.Text = "Kompleksinė Operacija"
        Me.ComplexOperationRadioButton.UseVisualStyleBackColor = True
        '
        'SimpleOperationTypeComboBox
        '
        Me.SimpleOperationTypeComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleOperationTypeComboBox.FormattingEnabled = True
        Me.SimpleOperationTypeComboBox.Location = New System.Drawing.Point(89, 87)
        Me.SimpleOperationTypeComboBox.Name = "SimpleOperationTypeComboBox"
        Me.SimpleOperationTypeComboBox.Size = New System.Drawing.Size(453, 21)
        Me.SimpleOperationTypeComboBox.TabIndex = 3
        '
        'ComplexOperationTypeComboBox
        '
        Me.ComplexOperationTypeComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComplexOperationTypeComboBox.Enabled = False
        Me.ComplexOperationTypeComboBox.FormattingEnabled = True
        Me.ComplexOperationTypeComboBox.Location = New System.Drawing.Point(89, 137)
        Me.ComplexOperationTypeComboBox.Name = "ComplexOperationTypeComboBox"
        Me.ComplexOperationTypeComboBox.Size = New System.Drawing.Size(453, 21)
        Me.ComplexOperationTypeComboBox.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(41, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Tipas:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(41, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Tipas:"
        '
        'CreateOperationButton
        '
        Me.CreateOperationButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CreateOperationButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreateOperationButton.Location = New System.Drawing.Point(467, 219)
        Me.CreateOperationButton.Name = "CreateOperationButton"
        Me.CreateOperationButton.Size = New System.Drawing.Size(75, 23)
        Me.CreateOperationButton.TabIndex = 7
        Me.CreateOperationButton.Text = "Sukurti"
        Me.CreateOperationButton.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 167)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Kalkuliacija:"
        '
        'CalculationInfoListAccGridComboBox
        '
        Me.CalculationInfoListAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CalculationInfoListAccGridComboBox.Enabled = False
        Me.CalculationInfoListAccGridComboBox.FilterPropertyName = ""
        Me.CalculationInfoListAccGridComboBox.FormattingEnabled = True
        Me.CalculationInfoListAccGridComboBox.InstantBinding = True
        Me.CalculationInfoListAccGridComboBox.Location = New System.Drawing.Point(89, 164)
        Me.CalculationInfoListAccGridComboBox.Name = "CalculationInfoListAccGridComboBox"
        Me.CalculationInfoListAccGridComboBox.Size = New System.Drawing.Size(453, 21)
        Me.CalculationInfoListAccGridComboBox.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 195)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Inventorizacijos Data:"
        '
        'InventorizationDateDateTimePicker
        '
        Me.InventorizationDateDateTimePicker.Enabled = False
        Me.InventorizationDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.InventorizationDateDateTimePicker.Location = New System.Drawing.Point(144, 191)
        Me.InventorizationDateDateTimePicker.Name = "InventorizationDateDateTimePicker"
        Me.InventorizationDateDateTimePicker.Size = New System.Drawing.Size(138, 20)
        Me.InventorizationDateDateTimePicker.TabIndex = 14
        '
        'F_NewGoodsOperationSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 249)
        Me.Controls.Add(Me.InventorizationDateDateTimePicker)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CalculationInfoListAccGridComboBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CreateOperationButton)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComplexOperationTypeComboBox)
        Me.Controls.Add(Me.SimpleOperationTypeComboBox)
        Me.Controls.Add(Me.ComplexOperationRadioButton)
        Me.Controls.Add(Me.SimpleOperationRadioButton)
        Me.Controls.Add(Me.WarehouseInfoListAccGridComboBox)
        Me.Controls.Add(Me.GoodsInfoListAccGridComboBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "F_NewGoodsOperationSelector"
        Me.ShowInTaskbar = False
        Me.Text = "Nauja Prekių Operacija"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GoodsInfoListAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents WarehouseInfoListAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents SimpleOperationRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents ComplexOperationRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents SimpleOperationTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ComplexOperationTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CreateOperationButton As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CalculationInfoListAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents InventorizationDateDateTimePicker As System.Windows.Forms.DateTimePicker
End Class
