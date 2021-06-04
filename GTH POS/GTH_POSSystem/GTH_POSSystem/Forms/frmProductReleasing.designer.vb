<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductReleasing
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductReleasing))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmbPurchaseCost = New System.Windows.Forms.ComboBox
        Me.cmbUnitPrice = New System.Windows.Forms.ComboBox
        Me.cmbUnitType = New System.Windows.Forms.ComboBox
        Me.txtqtyReceived = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.grpProductListing = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label12 = New System.Windows.Forms.Label
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.rbtnSearchByBarcode = New System.Windows.Forms.RadioButton
        Me.rbtnSearcByDescription = New System.Windows.Forms.RadioButton
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtProductDescription = New System.Windows.Forms.TextBox
        Me.txtQTYOnHand = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtProductBarcode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmbDRNumber = New System.Windows.Forms.ComboBox
        Me.cmbCustomerName = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbReceivedBy = New System.Windows.Forms.ComboBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkEnableAddStocksForRelease = New System.Windows.Forms.CheckBox
        Me.btnAddToDRList = New System.Windows.Forms.Button
        Me.btnDisplayPO = New System.Windows.Forms.Button
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyToRelease = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Price = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PO_NUM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.lblProductReceivedListing = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.btnNewUnitPrice = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.txtDRNumber = New System.Windows.Forms.Label
        Me.grpProductListing.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbPurchaseCost
        '
        Me.cmbPurchaseCost.BackColor = System.Drawing.Color.BurlyWood
        Me.cmbPurchaseCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPurchaseCost.FormattingEnabled = True
        Me.cmbPurchaseCost.Location = New System.Drawing.Point(190, 345)
        Me.cmbPurchaseCost.Name = "cmbPurchaseCost"
        Me.cmbPurchaseCost.Size = New System.Drawing.Size(218, 28)
        Me.cmbPurchaseCost.TabIndex = 101
        '
        'cmbUnitPrice
        '
        Me.cmbUnitPrice.BackColor = System.Drawing.Color.BurlyWood
        Me.cmbUnitPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnitPrice.FormattingEnabled = True
        Me.cmbUnitPrice.Location = New System.Drawing.Point(190, 308)
        Me.cmbUnitPrice.Name = "cmbUnitPrice"
        Me.cmbUnitPrice.Size = New System.Drawing.Size(218, 28)
        Me.cmbUnitPrice.TabIndex = 97
        '
        'cmbUnitType
        '
        Me.cmbUnitType.BackColor = System.Drawing.Color.BurlyWood
        Me.cmbUnitType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnitType.FormattingEnabled = True
        Me.cmbUnitType.Location = New System.Drawing.Point(190, 268)
        Me.cmbUnitType.Name = "cmbUnitType"
        Me.cmbUnitType.Size = New System.Drawing.Size(98, 28)
        Me.cmbUnitType.TabIndex = 96
        '
        'txtqtyReceived
        '
        Me.txtqtyReceived.AcceptsTab = True
        Me.txtqtyReceived.BackColor = System.Drawing.Color.White
        Me.txtqtyReceived.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtqtyReceived.Font = New System.Drawing.Font("Impact", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqtyReceived.ForeColor = System.Drawing.Color.Black
        Me.txtqtyReceived.Location = New System.Drawing.Point(274, 381)
        Me.txtqtyReceived.Name = "txtqtyReceived"
        Me.txtqtyReceived.Size = New System.Drawing.Size(216, 125)
        Me.txtqtyReceived.TabIndex = 93
        Me.txtqtyReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtqtyReceived, "Press F2 to select choices from List. . .")
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DimGray
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(9, 381)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(270, 125)
        Me.Label7.TabIndex = 92
        Me.Label7.Text = "Quantity to Release"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpProductListing
        '
        Me.grpProductListing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpProductListing.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.grpProductListing.Controls.Add(Me.DataGridView1)
        Me.grpProductListing.Controls.Add(Me.Label12)
        Me.grpProductListing.Controls.Add(Me.PictureBox5)
        Me.grpProductListing.Controls.Add(Me.rbtnSearchByBarcode)
        Me.grpProductListing.Controls.Add(Me.rbtnSearcByDescription)
        Me.grpProductListing.Controls.Add(Me.txtSearch)
        Me.grpProductListing.Controls.Add(Me.btnSearch)
        Me.grpProductListing.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.grpProductListing.Location = New System.Drawing.Point(18, 791)
        Me.grpProductListing.Name = "grpProductListing"
        Me.grpProductListing.Size = New System.Drawing.Size(13, 30)
        Me.grpProductListing.TabIndex = 91
        Me.grpProductListing.TabStop = False
        Me.grpProductListing.Text = "Searching. . ."
        Me.grpProductListing.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(14, 94)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(0, 0)
        Me.DataGridView1.TabIndex = 114
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.PeachPuff
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(7, 66)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(173, 17)
        Me.Label12.TabIndex = 113
        Me.Label12.Text = "PRODUCT LISTING. . ."
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.BackColor = System.Drawing.Color.Black
        Me.PictureBox5.Location = New System.Drawing.Point(21, 101)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(0, 0)
        Me.PictureBox5.TabIndex = 105
        Me.PictureBox5.TabStop = False
        '
        'rbtnSearchByBarcode
        '
        Me.rbtnSearchByBarcode.AutoSize = True
        Me.rbtnSearchByBarcode.Location = New System.Drawing.Point(216, 13)
        Me.rbtnSearchByBarcode.Name = "rbtnSearchByBarcode"
        Me.rbtnSearchByBarcode.Size = New System.Drawing.Size(80, 17)
        Me.rbtnSearchByBarcode.TabIndex = 44
        Me.rbtnSearchByBarcode.TabStop = True
        Me.rbtnSearchByBarcode.Text = "By Barcode"
        Me.rbtnSearchByBarcode.UseVisualStyleBackColor = True
        '
        'rbtnSearcByDescription
        '
        Me.rbtnSearcByDescription.AutoSize = True
        Me.rbtnSearcByDescription.Checked = True
        Me.rbtnSearcByDescription.Location = New System.Drawing.Point(89, 13)
        Me.rbtnSearcByDescription.Name = "rbtnSearcByDescription"
        Me.rbtnSearcByDescription.Size = New System.Drawing.Size(93, 17)
        Me.rbtnSearcByDescription.TabIndex = 43
        Me.rbtnSearcByDescription.TabStop = True
        Me.rbtnSearcByDescription.Text = "By Description"
        Me.rbtnSearcByDescription.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.AcceptsTab = True
        Me.txtSearch.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(6, 34)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(327, 29)
        Me.txtSearch.TabIndex = 42
        '
        'btnSearch
        '
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Location = New System.Drawing.Point(339, 34)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(33, 29)
        Me.btnSearch.TabIndex = 40
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.DimGray
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(96, 275)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 17)
        Me.Label9.TabIndex = 85
        Me.Label9.Text = "Unit Type:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.DimGray
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(47, 312)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 17)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "Unit Price (PHP):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.DimGray
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(15, 351)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(166, 17)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "Purchase Cost (PHP):"
        '
        'txtProductDescription
        '
        Me.txtProductDescription.AcceptsTab = True
        Me.txtProductDescription.BackColor = System.Drawing.Color.BurlyWood
        Me.txtProductDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductDescription.Font = New System.Drawing.Font("Impact", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductDescription.Location = New System.Drawing.Point(190, 192)
        Me.txtProductDescription.Multiline = True
        Me.txtProductDescription.Name = "txtProductDescription"
        Me.txtProductDescription.Size = New System.Drawing.Size(299, 70)
        Me.txtProductDescription.TabIndex = 71
        '
        'txtQTYOnHand
        '
        Me.txtQTYOnHand.AcceptsTab = True
        Me.txtQTYOnHand.BackColor = System.Drawing.Color.BurlyWood
        Me.txtQTYOnHand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQTYOnHand.Font = New System.Drawing.Font("Impact", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQTYOnHand.Location = New System.Drawing.Point(417, 268)
        Me.txtQTYOnHand.Name = "txtQTYOnHand"
        Me.txtQTYOnHand.Size = New System.Drawing.Size(72, 30)
        Me.txtQTYOnHand.TabIndex = 75
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.DimGray
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(56, 318)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 17)
        Me.Label4.TabIndex = 81
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.DimGray
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(294, 274)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 17)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "QTY On Hand:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(84, 212)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 17)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Description:"
        '
        'txtProductBarcode
        '
        Me.txtProductBarcode.AcceptsTab = True
        Me.txtProductBarcode.BackColor = System.Drawing.Color.BurlyWood
        Me.txtProductBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductBarcode.Font = New System.Drawing.Font("Impact", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductBarcode.Location = New System.Drawing.Point(190, 134)
        Me.txtProductBarcode.Name = "txtProductBarcode"
        Me.txtProductBarcode.Size = New System.Drawing.Size(299, 53)
        Me.txtProductBarcode.TabIndex = 72
        Me.txtProductBarcode.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DimGray
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(33, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 17)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "ProductID/Barcode:"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DimGray
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.LawnGreen
        Me.Label13.Location = New System.Drawing.Point(258, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(153, 30)
        Me.Label13.TabIndex = 103
        Me.Label13.Text = "Delivery Reference Number"
        '
        'cmbDRNumber
        '
        Me.cmbDRNumber.BackColor = System.Drawing.Color.BurlyWood
        Me.cmbDRNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDRNumber.FormattingEnabled = True
        Me.cmbDRNumber.Location = New System.Drawing.Point(60, 60)
        Me.cmbDRNumber.Name = "cmbDRNumber"
        Me.cmbDRNumber.Size = New System.Drawing.Size(235, 28)
        Me.cmbDRNumber.TabIndex = 102
        '
        'cmbCustomerName
        '
        Me.cmbCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCustomerName.BackColor = System.Drawing.Color.BurlyWood
        Me.cmbCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomerName.FormattingEnabled = True
        Me.cmbCustomerName.Location = New System.Drawing.Point(60, 28)
        Me.cmbCustomerName.Name = "cmbCustomerName"
        Me.cmbCustomerName.Size = New System.Drawing.Size(420, 28)
        Me.cmbCustomerName.TabIndex = 100
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.cmbReceivedBy)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox3.Location = New System.Drawing.Point(36, 566)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(453, 95)
        Me.GroupBox3.TabIndex = 106
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Details:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.DimGray
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(31, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 17)
        Me.Label10.TabIndex = 103
        Me.Label10.Text = "Release Date:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(144, 23)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(289, 26)
        Me.DateTimePicker1.TabIndex = 102
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.DimGray
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(39, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 17)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Released by:"
        '
        'cmbReceivedBy
        '
        Me.cmbReceivedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbReceivedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbReceivedBy.BackColor = System.Drawing.Color.BurlyWood
        Me.cmbReceivedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbReceivedBy.FormattingEnabled = True
        Me.cmbReceivedBy.Location = New System.Drawing.Point(144, 56)
        Me.cmbReceivedBy.Name = "cmbReceivedBy"
        Me.cmbReceivedBy.Size = New System.Drawing.Size(289, 28)
        Me.cmbReceivedBy.TabIndex = 100
        '
        'chkEnableAddStocksForRelease
        '
        Me.chkEnableAddStocksForRelease.BackColor = System.Drawing.Color.White
        Me.chkEnableAddStocksForRelease.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEnableAddStocksForRelease.ForeColor = System.Drawing.Color.Salmon
        Me.chkEnableAddStocksForRelease.Location = New System.Drawing.Point(12, 512)
        Me.chkEnableAddStocksForRelease.Name = "chkEnableAddStocksForRelease"
        Me.chkEnableAddStocksForRelease.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.chkEnableAddStocksForRelease.Size = New System.Drawing.Size(247, 45)
        Me.chkEnableAddStocksForRelease.TabIndex = 118
        Me.chkEnableAddStocksForRelease.Text = "ADD ITEMS FOR DELIVERY. . ."
        Me.ToolTip1.SetToolTip(Me.chkEnableAddStocksForRelease, "Click/Enable to add Items for Delivery...")
        Me.chkEnableAddStocksForRelease.UseVisualStyleBackColor = False
        '
        'btnAddToDRList
        '
        Me.btnAddToDRList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddToDRList.Image = CType(resources.GetObject("btnAddToDRList.Image"), System.Drawing.Image)
        Me.btnAddToDRList.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddToDRList.Location = New System.Drawing.Point(272, 512)
        Me.btnAddToDRList.Name = "btnAddToDRList"
        Me.btnAddToDRList.Size = New System.Drawing.Size(218, 48)
        Me.btnAddToDRList.TabIndex = 117
        Me.btnAddToDRList.Text = "ADD  THIS ITEM TO RELEASING LIST"
        Me.btnAddToDRList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.btnAddToDRList, "Click this button to add item and quantity to delivery list, said items are deliv" & _
                "ered without P.O but in the same D.R. . .")
        Me.btnAddToDRList.UseVisualStyleBackColor = True
        '
        'btnDisplayPO
        '
        Me.btnDisplayPO.Image = CType(resources.GetObject("btnDisplayPO.Image"), System.Drawing.Image)
        Me.btnDisplayPO.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDisplayPO.Location = New System.Drawing.Point(460, 59)
        Me.btnDisplayPO.Name = "btnDisplayPO"
        Me.btnDisplayPO.Size = New System.Drawing.Size(24, 29)
        Me.btnDisplayPO.TabIndex = 101
        Me.btnDisplayPO.Text = "View P.O"
        Me.btnDisplayPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.btnDisplayPO, "Click to Display P.O Details. . .")
        Me.btnDisplayPO.UseVisualStyleBackColor = True
        Me.btnDisplayPO.Visible = False
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToResizeColumns = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.DataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Barcode, Me.Description, Me.QtyToRelease, Me.Unit, Me.Price, Me.Remarks, Me.PO_NUM})
        Me.DataGridView2.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.DataGridView2.Location = New System.Drawing.Point(509, 45)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(806, 741)
        Me.DataGridView2.TabIndex = 108
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
        Me.Description.Width = 220
        '
        'QtyToRelease
        '
        Me.QtyToRelease.HeaderText = "Qty to Release"
        Me.QtyToRelease.Name = "QtyToRelease"
        Me.QtyToRelease.Width = 70
        '
        'Unit
        '
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.Width = 60
        '
        'Price
        '
        Me.Price.HeaderText = "Price"
        Me.Price.Name = "Price"
        Me.Price.ReadOnly = True
        Me.Price.Width = 60
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Amount"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Width = 200
        '
        'PO_NUM
        '
        Me.PO_NUM.HeaderText = "Batch Number"
        Me.PO_NUM.Name = "PO_NUM"
        Me.PO_NUM.Width = 120
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(204, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(203, 22)
        Me.ToolStripMenuItem1.Text = "Modify selected entry. . ."
        '
        'lblProductReceivedListing
        '
        Me.lblProductReceivedListing.AutoSize = True
        Me.lblProductReceivedListing.BackColor = System.Drawing.Color.PeachPuff
        Me.lblProductReceivedListing.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductReceivedListing.ForeColor = System.Drawing.Color.Blue
        Me.lblProductReceivedListing.Location = New System.Drawing.Point(510, 15)
        Me.lblProductReceivedListing.Name = "lblProductReceivedListing"
        Me.lblProductReceivedListing.Size = New System.Drawing.Size(432, 29)
        Me.lblProductReceivedListing.TabIndex = 111
        Me.lblProductReceivedListing.Text = "PRODUCT LISTING (for release). . ."
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Gray
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(929, 87)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(233, 17)
        Me.Label15.TabIndex = 113
        Me.Label15.Text = "Product Received for the Date:"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(1156, 87)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(142, 20)
        Me.DateTimePicker2.TabIndex = 114
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox2.Location = New System.Drawing.Point(43, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(447, 100)
        Me.GroupBox2.TabIndex = 102
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Customer Name:"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(55, 732)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(414, 54)
        Me.Button1.TabIndex = 115
        Me.Button1.Text = "&VIEW RELEASED STOCKS SUMMARY LISTING"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Black
        Me.PictureBox4.Location = New System.Drawing.Point(62, 742)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(413, 50)
        Me.PictureBox4.TabIndex = 116
        Me.PictureBox4.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox7.BackColor = System.Drawing.Color.Black
        Me.PictureBox7.Location = New System.Drawing.Point(514, 54)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(805, 739)
        Me.PictureBox7.TabIndex = 109
        Me.PictureBox7.TabStop = False
        '
        'btnNewUnitPrice
        '
        Me.btnNewUnitPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewUnitPrice.ForeColor = System.Drawing.Color.Red
        Me.btnNewUnitPrice.Image = CType(resources.GetObject("btnNewUnitPrice.Image"), System.Drawing.Image)
        Me.btnNewUnitPrice.Location = New System.Drawing.Point(417, 308)
        Me.btnNewUnitPrice.Name = "btnNewUnitPrice"
        Me.btnNewUnitPrice.Size = New System.Drawing.Size(72, 65)
        Me.btnNewUnitPrice.TabIndex = 98
        Me.btnNewUnitPrice.Text = "CHANGE PRICE"
        Me.btnNewUnitPrice.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = Global.GTH_POSSystem.My.Resources.Resources.square_go
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClose.Location = New System.Drawing.Point(343, 665)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(127, 54)
        Me.btnClose.TabIndex = 79
        Me.btnClose.Text = "&Close"
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.GTH_POSSystem.My.Resources.Resources.square_add
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.Location = New System.Drawing.Point(196, 665)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(126, 54)
        Me.btnSave.TabIndex = 77
        Me.btnSave.Text = "&Save"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNew.Location = New System.Drawing.Point(55, 665)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(121, 54)
        Me.btnNew.TabIndex = 70
        Me.btnNew.Text = "&New"
        Me.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Location = New System.Drawing.Point(61, 675)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(119, 50)
        Me.PictureBox1.TabIndex = 87
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Black
        Me.PictureBox2.Location = New System.Drawing.Point(208, 675)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(119, 50)
        Me.PictureBox2.TabIndex = 88
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Black
        Me.PictureBox3.Location = New System.Drawing.Point(357, 675)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(118, 50)
        Me.PictureBox3.TabIndex = 89
        Me.PictureBox3.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Black
        Me.PictureBox6.Location = New System.Drawing.Point(4, 378)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(491, 132)
        Me.PictureBox6.TabIndex = 105
        Me.PictureBox6.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Black
        Me.PictureBox8.Location = New System.Drawing.Point(18, 514)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(246, 48)
        Me.PictureBox8.TabIndex = 119
        Me.PictureBox8.TabStop = False
        '
        'txtDRNumber
        '
        Me.txtDRNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDRNumber.BackColor = System.Drawing.Color.Transparent
        Me.txtDRNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDRNumber.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtDRNumber.Location = New System.Drawing.Point(1075, 15)
        Me.txtDRNumber.Name = "txtDRNumber"
        Me.txtDRNumber.Size = New System.Drawing.Size(244, 22)
        Me.txtDRNumber.TabIndex = 121
        Me.txtDRNumber.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmProductReleasing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1327, 800)
        Me.Controls.Add(Me.txtDRNumber)
        Me.Controls.Add(Me.btnAddToDRList)
        Me.Controls.Add(Me.cmbCustomerName)
        Me.Controls.Add(Me.btnDisplayPO)
        Me.Controls.Add(Me.grpProductListing)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.cmbDRNumber)
        Me.Controls.Add(Me.lblProductReceivedListing)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.cmbPurchaseCost)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnNewUnitPrice)
        Me.Controls.Add(Me.cmbUnitPrice)
        Me.Controls.Add(Me.cmbUnitType)
        Me.Controls.Add(Me.txtqtyReceived)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtProductDescription)
        Me.Controls.Add(Me.txtQTYOnHand)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtProductBarcode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.chkEnableAddStocksForRelease)
        Me.Controls.Add(Me.PictureBox8)
        Me.KeyPreview = True
        Me.Name = "frmProductReleasing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stocks Releasing/Delivery Form. . . (Create Sales Receipts)"
        Me.grpProductListing.ResumeLayout(False)
        Me.grpProductListing.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbPurchaseCost As System.Windows.Forms.ComboBox
    Friend WithEvents btnNewUnitPrice As System.Windows.Forms.Button
    Friend WithEvents cmbUnitPrice As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUnitType As System.Windows.Forms.ComboBox
    Friend WithEvents txtqtyReceived As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents grpProductListing As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnSearchByBarcode As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSearcByDescription As System.Windows.Forms.RadioButton
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtProductDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtQTYOnHand As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProductBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbReceivedBy As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents lblProductReceivedListing As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbDRNumber As System.Windows.Forms.ComboBox
    Friend WithEvents btnDisplayPO As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddToDRList As System.Windows.Forms.Button
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents chkEnableAddStocksForRelease As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents txtDRNumber As System.Windows.Forms.Label
    Friend WithEvents Barcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyToRelease As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PO_NUM As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
