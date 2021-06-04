<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPORMonitoring
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
        Dim GroupBox3 As System.Windows.Forms.GroupBox
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPORMonitoring))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyOrdered = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Received = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Price = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeliveryStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AveSales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StanDev = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.cmbPointOfReorder = New System.Windows.Forms.ComboBox
        Me.chkAll = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnCreatePO = New System.Windows.Forms.Button
        Me.cmbSupplier = New System.Windows.Forms.ComboBox
        Me.chkPerSupplier = New System.Windows.Forms.CheckBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnPreviewPOR = New System.Windows.Forms.Button
        Me.btnDisplaySales = New System.Windows.Forms.Button
        GroupBox3 = New System.Windows.Forms.GroupBox
        GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
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
        GroupBox3.Location = New System.Drawing.Point(12, 131)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New System.Drawing.Size(1061, 449)
        GroupBox3.TabIndex = 107
        GroupBox3.TabStop = False
        GroupBox3.Text = "DETAILS . . ."
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Barcode, Me.Description, Me.QtyOrdered, Me.Unit, Me.Received, Me.Price, Me.DeliveryStatus, Me.AveSales, Me.StanDev})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.DataGridView1.Location = New System.Drawing.Point(6, 25)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1049, 418)
        Me.DataGridView1.TabIndex = 109
        '
        'Barcode
        '
        Me.Barcode.HeaderText = "Barcode"
        Me.Barcode.Name = "Barcode"
        Me.Barcode.Width = 120
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.Width = 250
        '
        'QtyOrdered
        '
        Me.QtyOrdered.HeaderText = "Previous Order"
        Me.QtyOrdered.Name = "QtyOrdered"
        Me.QtyOrdered.Width = 70
        '
        'Unit
        '
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.Width = 60
        '
        'Received
        '
        Me.Received.HeaderText = "Qty On Hand"
        Me.Received.Name = "Received"
        Me.Received.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Received.Width = 80
        '
        'Price
        '
        Me.Price.HeaderText = "Supplier Price"
        Me.Price.Name = "Price"
        Me.Price.ReadOnly = True
        '
        'DeliveryStatus
        '
        Me.DeliveryStatus.HeaderText = "Average Delivery Lead Time"
        Me.DeliveryStatus.Name = "DeliveryStatus"
        Me.DeliveryStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'AveSales
        '
        Me.AveSales.HeaderText = "Median Sales /day"
        Me.AveSales.Name = "AveSales"
        '
        'StanDev
        '
        Me.StanDev.HeaderText = "Standard Deviation (Sales/day)"
        Me.StanDev.Name = "StanDev"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(-2, -15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(579, 67)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(17, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(559, 25)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "STOCKS THAT REACHES POINT OF RE-ORDER. . ."
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.35802!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.64198!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cmbPointOfReorder, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chkAll, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 70)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(364, 45)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'cmbPointOfReorder
        '
        Me.cmbPointOfReorder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPointOfReorder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPointOfReorder.FormattingEnabled = True
        Me.cmbPointOfReorder.Location = New System.Drawing.Point(213, 11)
        Me.cmbPointOfReorder.Name = "cmbPointOfReorder"
        Me.cmbPointOfReorder.Size = New System.Drawing.Size(76, 28)
        Me.cmbPointOfReorder.TabIndex = 115
        '
        'chkAll
        '
        Me.chkAll.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAll.AutoSize = True
        Me.chkAll.Checked = True
        Me.chkAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAll.Location = New System.Drawing.Point(298, 11)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(60, 28)
        Me.chkAll.TabIndex = 113
        Me.chkAll.Text = "All"
        Me.chkAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(198, 34)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "POINT OF REORDER:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCreatePO)
        Me.GroupBox2.Controls.Add(Me.cmbSupplier)
        Me.GroupBox2.Controls.Add(Me.chkPerSupplier)
        Me.GroupBox2.Location = New System.Drawing.Point(385, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(397, 64)
        Me.GroupBox2.TabIndex = 110
        Me.GroupBox2.TabStop = False
        '
        'btnCreatePO
        '
        Me.btnCreatePO.Image = CType(resources.GetObject("btnCreatePO.Image"), System.Drawing.Image)
        Me.btnCreatePO.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreatePO.Location = New System.Drawing.Point(291, 17)
        Me.btnCreatePO.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCreatePO.Name = "btnCreatePO"
        Me.btnCreatePO.Size = New System.Drawing.Size(100, 39)
        Me.btnCreatePO.TabIndex = 115
        Me.btnCreatePO.Text = "Create P.O for this Supplier"
        Me.btnCreatePO.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnCreatePO.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnCreatePO.UseVisualStyleBackColor = True
        '
        'cmbSupplier
        '
        Me.cmbSupplier.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSupplier.Enabled = False
        Me.cmbSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSupplier.FormattingEnabled = True
        Me.cmbSupplier.Location = New System.Drawing.Point(6, 28)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Size = New System.Drawing.Size(278, 28)
        Me.cmbSupplier.TabIndex = 114
        '
        'chkPerSupplier
        '
        Me.chkPerSupplier.AutoSize = True
        Me.chkPerSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPerSupplier.Location = New System.Drawing.Point(6, 0)
        Me.chkPerSupplier.Name = "chkPerSupplier"
        Me.chkPerSupplier.Size = New System.Drawing.Size(126, 24)
        Me.chkPerSupplier.TabIndex = 112
        Me.chkPerSupplier.Text = "Per Supplier"
        Me.chkPerSupplier.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClose.Location = New System.Drawing.Point(981, 21)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(89, 94)
        Me.btnClose.TabIndex = 111
        Me.btnClose.Text = "CLOSE"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPreviewPOR
        '
        Me.btnPreviewPOR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPreviewPOR.Image = CType(resources.GetObject("btnPreviewPOR.Image"), System.Drawing.Image)
        Me.btnPreviewPOR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPreviewPOR.Location = New System.Drawing.Point(886, 21)
        Me.btnPreviewPOR.Name = "btnPreviewPOR"
        Me.btnPreviewPOR.Size = New System.Drawing.Size(89, 94)
        Me.btnPreviewPOR.TabIndex = 109
        Me.btnPreviewPOR.Text = "PRINT PREVIEW"
        Me.btnPreviewPOR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPreviewPOR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPreviewPOR.UseVisualStyleBackColor = True
        '
        'btnDisplaySales
        '
        Me.btnDisplaySales.Image = CType(resources.GetObject("btnDisplaySales.Image"), System.Drawing.Image)
        Me.btnDisplaySales.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDisplaySales.Location = New System.Drawing.Point(788, 21)
        Me.btnDisplaySales.Name = "btnDisplaySales"
        Me.btnDisplaySales.Size = New System.Drawing.Size(92, 94)
        Me.btnDisplaySales.TabIndex = 108
        Me.btnDisplaySales.Text = "VIEW LIST"
        Me.btnDisplaySales.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDisplaySales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDisplaySales.UseVisualStyleBackColor = True
        '
        'frmPORMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1085, 603)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnPreviewPOR)
        Me.Controls.Add(Me.btnDisplaySales)
        Me.Controls.Add(GroupBox3)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmPORMonitoring"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        GroupBox3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnDisplaySales As System.Windows.Forms.Button
    Friend WithEvents btnPreviewPOR As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkPerSupplier As System.Windows.Forms.CheckBox
    Friend WithEvents cmbSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmbPointOfReorder As System.Windows.Forms.ComboBox
    Friend WithEvents Barcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyOrdered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Received As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeliveryStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AveSales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StanDev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCreatePO As System.Windows.Forms.Button
End Class
