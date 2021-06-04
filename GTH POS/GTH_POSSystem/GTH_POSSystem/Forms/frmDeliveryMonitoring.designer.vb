<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeliveryMonitoring
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim GroupBox2 As System.Windows.Forms.GroupBox
        Dim GroupBox3 As System.Windows.Forms.GroupBox
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeliveryMonitoring))
        Me.dgrOrderList = New System.Windows.Forms.DataGridView
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbClerk = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.rbtnAnnual = New System.Windows.Forms.RadioButton
        Me.rbtnMonthly = New System.Windows.Forms.RadioButton
        Me.rbtnWeekly = New System.Windows.Forms.RadioButton
        Me.rbtnDaily = New System.Windows.Forms.RadioButton
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.dtpEndTime = New System.Windows.Forms.DateTimePicker
        Me.dtpStartTime = New System.Windows.Forms.DateTimePicker
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.DateTime = New System.Windows.Forms.ColumnHeader
        Me.Status = New System.Windows.Forms.ColumnHeader
        Me.btnPreviewSales = New System.Windows.Forms.Button
        Me.btnDisplaySales = New System.Windows.Forms.Button
        GroupBox2 = New System.Windows.Forms.GroupBox
        GroupBox3 = New System.Windows.Forms.GroupBox
        GroupBox2.SuspendLayout()
        CType(Me.dgrOrderList, System.ComponentModel.ISupportInitialize).BeginInit()
        GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        GroupBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        GroupBox2.Controls.Add(Me.dgrOrderList)
        GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GroupBox2.ForeColor = System.Drawing.Color.Black
        GroupBox2.Location = New System.Drawing.Point(243, 437)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New System.Drawing.Size(1047, 188)
        GroupBox2.TabIndex = 106
        GroupBox2.TabStop = False
        GroupBox2.Text = "Details"
        '
        'dgrOrderList
        '
        Me.dgrOrderList.AllowUserToDeleteRows = False
        Me.dgrOrderList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgrOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrOrderList.Location = New System.Drawing.Point(6, 25)
        Me.dgrOrderList.MultiSelect = False
        Me.dgrOrderList.Name = "dgrOrderList"
        Me.dgrOrderList.Size = New System.Drawing.Size(1035, 227)
        Me.dgrOrderList.TabIndex = 0
        '
        'GroupBox3
        '
        GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        GroupBox3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        GroupBox3.Controls.Add(Me.DataGridView1)
        GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GroupBox3.ForeColor = System.Drawing.Color.Black
        GroupBox3.Location = New System.Drawing.Point(243, 142)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New System.Drawing.Size(1047, 289)
        GroupBox3.TabIndex = 107
        GroupBox3.TabStop = False
        GroupBox3.Text = "Sales"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 25)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1035, 258)
        Me.DataGridView1.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "DESCRIPTION"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 220
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "PRICE"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "QTY"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 70
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "AMOUNT"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Discount"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Time"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Barcode"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbClerk)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rbtnAnnual)
        Me.GroupBox1.Controls.Add(Me.rbtnMonthly)
        Me.GroupBox1.Controls.Add(Me.rbtnWeekly)
        Me.GroupBox1.Controls.Add(Me.rbtnDaily)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(34, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(484, 107)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Period:"
        '
        'cmbClerk
        '
        Me.cmbClerk.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbClerk.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClerk.FormattingEnabled = True
        Me.cmbClerk.Location = New System.Drawing.Point(164, 63)
        Me.cmbClerk.Name = "cmbClerk"
        Me.cmbClerk.Size = New System.Drawing.Size(299, 33)
        Me.cmbClerk.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(33, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 25)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Cashier:"
        '
        'rbtnAnnual
        '
        Me.rbtnAnnual.AutoSize = True
        Me.rbtnAnnual.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnAnnual.ForeColor = System.Drawing.Color.Black
        Me.rbtnAnnual.Location = New System.Drawing.Point(380, 31)
        Me.rbtnAnnual.Name = "rbtnAnnual"
        Me.rbtnAnnual.Size = New System.Drawing.Size(83, 24)
        Me.rbtnAnnual.TabIndex = 4
        Me.rbtnAnnual.Text = "Annual"
        Me.rbtnAnnual.UseVisualStyleBackColor = True
        '
        'rbtnMonthly
        '
        Me.rbtnMonthly.AutoSize = True
        Me.rbtnMonthly.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnMonthly.ForeColor = System.Drawing.Color.Black
        Me.rbtnMonthly.Location = New System.Drawing.Point(252, 31)
        Me.rbtnMonthly.Name = "rbtnMonthly"
        Me.rbtnMonthly.Size = New System.Drawing.Size(89, 24)
        Me.rbtnMonthly.TabIndex = 3
        Me.rbtnMonthly.Text = "Monthly"
        Me.rbtnMonthly.UseVisualStyleBackColor = True
        '
        'rbtnWeekly
        '
        Me.rbtnWeekly.AutoSize = True
        Me.rbtnWeekly.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnWeekly.ForeColor = System.Drawing.Color.Black
        Me.rbtnWeekly.Location = New System.Drawing.Point(130, 31)
        Me.rbtnWeekly.Name = "rbtnWeekly"
        Me.rbtnWeekly.Size = New System.Drawing.Size(84, 24)
        Me.rbtnWeekly.TabIndex = 2
        Me.rbtnWeekly.Text = "Weekly"
        Me.rbtnWeekly.UseVisualStyleBackColor = True
        '
        'rbtnDaily
        '
        Me.rbtnDaily.AutoSize = True
        Me.rbtnDaily.Checked = True
        Me.rbtnDaily.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnDaily.ForeColor = System.Drawing.Color.Black
        Me.rbtnDaily.Location = New System.Drawing.Point(23, 31)
        Me.rbtnDaily.Name = "rbtnDaily"
        Me.rbtnDaily.Size = New System.Drawing.Size(66, 24)
        Me.rbtnDaily.TabIndex = 1
        Me.rbtnDaily.TabStop = True
        Me.rbtnDaily.Text = "Daily"
        Me.rbtnDaily.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.8125!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.1875!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 269.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEndTime, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpStartTime, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDateTime, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpStartDateTime, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(537, 25)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(479, 94)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'dtpEndTime
        '
        Me.dtpEndTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpEndTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpEndTime.Location = New System.Drawing.Point(209, 51)
        Me.dtpEndTime.Name = "dtpEndTime"
        Me.dtpEndTime.Size = New System.Drawing.Size(264, 26)
        Me.dtpEndTime.TabIndex = 15
        '
        'dtpStartTime
        '
        Me.dtpStartTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpStartTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpStartTime.Location = New System.Drawing.Point(209, 6)
        Me.dtpStartTime.Name = "dtpStartTime"
        Me.dtpStartTime.Size = New System.Drawing.Size(264, 26)
        Me.dtpStartTime.TabIndex = 14
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpEndDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDateTime.Location = New System.Drawing.Point(113, 51)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.Size = New System.Drawing.Size(87, 26)
        Me.dtpEndDateTime.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 43)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "End Date/Time:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 42)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Start Date/Time:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpStartDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDateTime.Location = New System.Drawing.Point(113, 6)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.Size = New System.Drawing.Size(87, 26)
        Me.dtpStartDateTime.TabIndex = 11
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListView1.AutoArrange = False
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.DateTime, Me.Status})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.Location = New System.Drawing.Point(34, 142)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(203, 483)
        Me.ListView1.TabIndex = 105
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'DateTime
        '
        Me.DateTime.Text = "DateTime"
        Me.DateTime.Width = 97
        '
        'Status
        '
        Me.Status.Text = "Status"
        Me.Status.Width = 163
        '
        'btnPreviewSales
        '
        Me.btnPreviewSales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPreviewSales.Image = CType(resources.GetObject("btnPreviewSales.Image"), System.Drawing.Image)
        Me.btnPreviewSales.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPreviewSales.Location = New System.Drawing.Point(1114, 13)
        Me.btnPreviewSales.Name = "btnPreviewSales"
        Me.btnPreviewSales.Size = New System.Drawing.Size(89, 106)
        Me.btnPreviewSales.TabIndex = 109
        Me.btnPreviewSales.Text = "PREVIEW DELIVERY"
        Me.btnPreviewSales.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPreviewSales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPreviewSales.UseVisualStyleBackColor = True
        '
        'btnDisplaySales
        '
        Me.btnDisplaySales.Image = CType(resources.GetObject("btnDisplaySales.Image"), System.Drawing.Image)
        Me.btnDisplaySales.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDisplaySales.Location = New System.Drawing.Point(1016, 13)
        Me.btnDisplaySales.Name = "btnDisplaySales"
        Me.btnDisplaySales.Size = New System.Drawing.Size(92, 106)
        Me.btnDisplaySales.TabIndex = 108
        Me.btnDisplaySales.Text = "DISPLAY DELIVERY"
        Me.btnDisplaySales.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDisplaySales.UseVisualStyleBackColor = True
        '
        'frmDeliveryMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1329, 637)
        Me.Controls.Add(Me.btnPreviewSales)
        Me.Controls.Add(Me.btnDisplaySales)
        Me.Controls.Add(GroupBox3)
        Me.Controls.Add(GroupBox2)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmDeliveryMonitoring"
        Me.Text = "Daily Delivery Monitoring. . ."
        GroupBox2.ResumeLayout(False)
        CType(Me.dgrOrderList, System.ComponentModel.ISupportInitialize).EndInit()
        GroupBox3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnAnnual As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnMonthly As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnWeekly As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnDaily As System.Windows.Forms.RadioButton
    Friend WithEvents cmbClerk As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents DateTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents Status As System.Windows.Forms.ColumnHeader
    Friend WithEvents dgrOrderList As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpEndTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnDisplaySales As System.Windows.Forms.Button
    Friend WithEvents btnPreviewSales As System.Windows.Forms.Button
End Class
