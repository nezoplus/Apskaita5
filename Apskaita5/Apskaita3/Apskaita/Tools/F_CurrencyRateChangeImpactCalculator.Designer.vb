<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_CurrencyRateChangeImpactCalculator
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_CurrencyRateChangeImpactCalculator))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.CurrencyRateChangeImpactAccTextBox = New AccControls.AccTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SumStartAccTextBox = New AccControls.AccTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SumEndAccTextBox = New AccControls.AccTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CalculationDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GetCurrencyRatesButton = New System.Windows.Forms.Button
        Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New AccControls.CalendarColumn
        Me.DataGridViewTextBoxColumn2 = New AccControls.DataGridViewAccTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn4 = New AccControls.DataGridViewAccTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New AccControls.DataGridViewAccTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.CurrencyRateChangeImpactAccTextBox, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.SumStartAccTextBox, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.SumEndAccTextBox, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CalculationDateDateTimePicker, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(606, 51)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'CurrencyRateChangeImpactAccTextBox
        '
        Me.CurrencyRateChangeImpactAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyRateChangeImpactAccTextBox.KeepBackColorWhenReadOnly = False
        Me.CurrencyRateChangeImpactAccTextBox.Location = New System.Drawing.Point(411, 3)
        Me.CurrencyRateChangeImpactAccTextBox.Name = "CurrencyRateChangeImpactAccTextBox"
        Me.CurrencyRateChangeImpactAccTextBox.ReadOnly = True
        Me.CurrencyRateChangeImpactAccTextBox.Size = New System.Drawing.Size(175, 20)
        Me.CurrencyRateChangeImpactAccTextBox.TabIndex = 1
        Me.CurrencyRateChangeImpactAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(313, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(92, 18)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Skirtumas LTL:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(87, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Suma LTL pr.:"
        '
        'SumStartAccTextBox
        '
        Me.SumStartAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumStartAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumStartAccTextBox.Location = New System.Drawing.Point(117, 28)
        Me.SumStartAccTextBox.Name = "SumStartAccTextBox"
        Me.SumStartAccTextBox.ReadOnly = True
        Me.SumStartAccTextBox.Size = New System.Drawing.Size(175, 20)
        Me.SumStartAccTextBox.TabIndex = 2
        Me.SumStartAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(315, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label3.Size = New System.Drawing.Size(90, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Suma LTL pb.:"
        '
        'SumEndAccTextBox
        '
        Me.SumEndAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumEndAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumEndAccTextBox.Location = New System.Drawing.Point(411, 28)
        Me.SumEndAccTextBox.Name = "SumEndAccTextBox"
        Me.SumEndAccTextBox.ReadOnly = True
        Me.SumEndAccTextBox.Size = New System.Drawing.Size(175, 20)
        Me.SumEndAccTextBox.TabIndex = 3
        Me.SumEndAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(108, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Skaičiavimo data:"
        '
        'CalculationDateDateTimePicker
        '
        Me.CalculationDateDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CalculationDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CalculationDateDateTimePicker.Location = New System.Drawing.Point(117, 3)
        Me.CalculationDateDateTimePicker.Name = "CalculationDateDateTimePicker"
        Me.CalculationDateDateTimePicker.Size = New System.Drawing.Size(175, 20)
        Me.CalculationDateDateTimePicker.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.GetCurrencyRatesButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 380)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(606, 31)
        Me.Panel2.TabIndex = 2
        '
        'GetCurrencyRatesButton
        '
        Me.GetCurrencyRatesButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GetCurrencyRatesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetCurrencyRatesButton.Location = New System.Drawing.Point(531, 6)
        Me.GetCurrencyRatesButton.Name = "GetCurrencyRatesButton"
        Me.GetCurrencyRatesButton.Size = New System.Drawing.Size(63, 22)
        Me.GetCurrencyRatesButton.TabIndex = 18
        Me.GetCurrencyRatesButton.Text = "$->LTL"
        Me.GetCurrencyRatesButton.UseVisualStyleBackColor = True
        '
        'F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemBindingSource
        '
        Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemBindingSource.DataSource = GetType(ApskaitaWUI.F_CurrencyRateChangeImpactCalculator.CurrencyRateCalculationItem)
        '
        'F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView
        '
        Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView.DataSource = Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemBindingSource
        Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView.Location = New System.Drawing.Point(0, 51)
        Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView.Name = "F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView"
        Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView.RowHeadersWidth = 20
        Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView.Size = New System.Drawing.Size(606, 329)
        Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Date"
        DataGridViewCellStyle2.Format = "d"
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn1.HeaderText = "Data"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AllowNegative = False
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Sum"
        DataGridViewCellStyle3.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn2.HeaderText = "Suma"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CurrencyCode"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Valiuta"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AllowNegative = False
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "CurrencyRateStart"
        Me.DataGridViewTextBoxColumn4.DecimalLength = 6
        DataGridViewCellStyle4.Format = "##,0.000000"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn4.HeaderText = "Kursas pr."
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "SumLTLStart"
        DataGridViewCellStyle5.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn5.HeaderText = "Suma LTL pr."
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AllowNegative = False
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "CurrencyRateEnd"
        Me.DataGridViewTextBoxColumn6.DecimalLength = 6
        DataGridViewCellStyle6.Format = "##,0.000000"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn6.HeaderText = "Kursas pb."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "SumLTLEnd"
        DataGridViewCellStyle7.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn7.HeaderText = "Suma LTL pb."
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "CurrencyRateChangeImpact"
        DataGridViewCellStyle8.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn8.HeaderText = "Kurso pasik. įtaka"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'F_CurrencyRateChangeImpactCalculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 411)
        Me.Controls.Add(Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_CurrencyRateChangeImpactCalculator"
        Me.ShowInTaskbar = False
        Me.Text = "Valiutos kurso pasikeitimo įtakos kalkuliatorius"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CalculationDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents SumEndAccTextBox As AccControls.AccTextBox
    Friend WithEvents SumStartAccTextBox As AccControls.AccTextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GetCurrencyRatesButton As System.Windows.Forms.Button
    Friend WithEvents CurrencyRateChangeImpactAccTextBox As AccControls.AccTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As AccControls.CalendarColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
