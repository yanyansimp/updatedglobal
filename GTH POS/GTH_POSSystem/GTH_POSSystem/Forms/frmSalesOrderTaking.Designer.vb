<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalesOrderTaking
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
        Dim GroupBox2 As System.Windows.Forms.GroupBox
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSalesOrderTaking))
        Me.dgrOrderList = New System.Windows.Forms.DataGridView
        Me.DESCRIPTION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QUANTITY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AMOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Disc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblOR = New System.Windows.Forms.Label
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDiscount = New System.Windows.Forms.TextBox
        Me.cmbUnitPrice = New System.Windows.Forms.ComboBox
        Me.cmbUnitType = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtProductDescription = New System.Windows.Forms.TextBox
        Me.txtQTYOnHand = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtProductBarcode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dgrProductList = New System.Windows.Forms.DataGridView
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblTotalAmount = New System.Windows.Forms.Label
        Me.txtFinalDiscount = New System.Windows.Forms.TextBox
        Me.txtNetSales = New System.Windows.Forms.TextBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.txtPayment = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtChangeDue = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtNoOfItems = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox12 = New System.Windows.Forms.PictureBox
        Me.PictureBox11 = New System.Windows.Forms.PictureBox
        Me.PictureBox10 = New System.Windows.Forms.PictureBox
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox13 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblReorderPOint = New System.Windows.Forms.Label
        Me.cmbRoPoint = New System.Windows.Forms.ComboBox
        Me.tmrPOR = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        GroupBox2 = New System.Windows.Forms.GroupBox
        GroupBox2.SuspendLayout()
        CType(Me.dgrOrderList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgrProductList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        GroupBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        GroupBox2.Controls.Add(Me.dgrOrderList)
        GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GroupBox2.ForeColor = System.Drawing.Color.Black
        GroupBox2.Location = New System.Drawing.Point(644, 10)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New System.Drawing.Size(597, 790)
        GroupBox2.TabIndex = 57
        GroupBox2.TabStop = False
        GroupBox2.Text = "&SALES. . ."
        '
        'dgrOrderList
        '
        Me.dgrOrderList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgrOrderList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgrOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrOrderList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DESCRIPTION, Me.UnitPrice, Me.QUANTITY, Me.AMOUNT, Me.Disc, Me.Barcode, Me.TransTime})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgrOrderList.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgrOrderList.Location = New System.Drawing.Point(6, 22)
        Me.dgrOrderList.MultiSelect = False
        Me.dgrOrderList.Name = "dgrOrderList"
        Me.dgrOrderList.Size = New System.Drawing.Size(585, 762)
        Me.dgrOrderList.TabIndex = 0
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.HeaderText = "DESCRIPTION"
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.Width = 220
        '
        'UnitPrice
        '
        Me.UnitPrice.HeaderText = "PRICE"
        Me.UnitPrice.Name = "UnitPrice"
        Me.UnitPrice.Width = 80
        '
        'QUANTITY
        '
        Me.QUANTITY.HeaderText = "QTY"
        Me.QUANTITY.Name = "QUANTITY"
        Me.QUANTITY.Width = 60
        '
        'AMOUNT
        '
        Me.AMOUNT.HeaderText = "AMOUNT"
        Me.AMOUNT.Name = "AMOUNT"
        '
        'Disc
        '
        Me.Disc.HeaderText = "%Disc"
        Me.Disc.Name = "Disc"
        Me.Disc.Width = 60
        '
        'Barcode
        '
        Me.Barcode.HeaderText = "Barcode"
        Me.Barcode.Name = "Barcode"
        Me.Barcode.Width = 150
        '
        'TransTime
        '
        Me.TransTime.HeaderText = "Time"
        Me.TransTime.Name = "TransTime"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox1.Controls.Add(Me.lblOR)
        Me.GroupBox1.Controls.Add(Me.txtQty)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDiscount)
        Me.GroupBox1.Controls.Add(Me.cmbUnitPrice)
        Me.GroupBox1.Controls.Add(Me.cmbUnitType)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtProductDescription)
        Me.GroupBox1.Controls.Add(Me.txtQTYOnHand)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtProductBarcode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(158, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(472, 382)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblOR
        '
        Me.lblOR.BackColor = System.Drawing.Color.Transparent
        Me.lblOR.Font = New System.Drawing.Font("Academic M54", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOR.ForeColor = System.Drawing.Color.LightCoral
        Me.lblOR.Location = New System.Drawing.Point(219, 245)
        Me.lblOR.Name = "lblOR"
        Me.lblOR.Size = New System.Drawing.Size(242, 34)
        Me.lblOR.TabIndex = 127
        Me.lblOR.Text = "QTY On Hand:"
        Me.lblOR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtQty
        '
        Me.txtQty.AcceptsTab = True
        Me.txtQty.BackColor = System.Drawing.Color.White
        Me.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQty.Font = New System.Drawing.Font("Impact", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(8, 282)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(453, 86)
        Me.txtQty.TabIndex = 7
        Me.txtQty.TabStop = False
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.DimGray
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(7, 245)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 31)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "&QUANTITY:"
        '
        'txtDiscount
        '
        Me.txtDiscount.AcceptsTab = True
        Me.txtDiscount.BackColor = System.Drawing.Color.White
        Me.txtDiscount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDiscount.Font = New System.Drawing.Font("Impact", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscount.Location = New System.Drawing.Point(389, 197)
        Me.txtDiscount.MaxLength = 5
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.Size = New System.Drawing.Size(72, 30)
        Me.txtDiscount.TabIndex = 5
        '
        'cmbUnitPrice
        '
        Me.cmbUnitPrice.BackColor = System.Drawing.Color.White
        Me.cmbUnitPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnitPrice.FormattingEnabled = True
        Me.cmbUnitPrice.Location = New System.Drawing.Point(162, 193)
        Me.cmbUnitPrice.Name = "cmbUnitPrice"
        Me.cmbUnitPrice.Size = New System.Drawing.Size(86, 28)
        Me.cmbUnitPrice.TabIndex = 6
        '
        'cmbUnitType
        '
        Me.cmbUnitType.BackColor = System.Drawing.Color.White
        Me.cmbUnitType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnitType.FormattingEnabled = True
        Me.cmbUnitType.Location = New System.Drawing.Point(162, 153)
        Me.cmbUnitType.Name = "cmbUnitType"
        Me.cmbUnitType.Size = New System.Drawing.Size(86, 28)
        Me.cmbUnitType.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.DimGray
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(68, 160)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 17)
        Me.Label9.TabIndex = 122
        Me.Label9.Text = "Unit Type:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.DimGray
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(19, 197)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 17)
        Me.Label8.TabIndex = 121
        Me.Label8.Text = "Unit Price (PHP):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.DimGray
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(272, 206)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 17)
        Me.Label6.TabIndex = 120
        Me.Label6.Text = "(%) Discount:"
        '
        'txtProductDescription
        '
        Me.txtProductDescription.AcceptsTab = True
        Me.txtProductDescription.BackColor = System.Drawing.Color.White
        Me.txtProductDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductDescription.Font = New System.Drawing.Font("Impact", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductDescription.Location = New System.Drawing.Point(162, 77)
        Me.txtProductDescription.Multiline = True
        Me.txtProductDescription.Name = "txtProductDescription"
        Me.txtProductDescription.Size = New System.Drawing.Size(299, 70)
        Me.txtProductDescription.TabIndex = 2
        '
        'txtQTYOnHand
        '
        Me.txtQTYOnHand.AcceptsTab = True
        Me.txtQTYOnHand.BackColor = System.Drawing.Color.White
        Me.txtQTYOnHand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQTYOnHand.Font = New System.Drawing.Font("Impact", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQTYOnHand.Location = New System.Drawing.Point(389, 153)
        Me.txtQTYOnHand.Name = "txtQTYOnHand"
        Me.txtQTYOnHand.Size = New System.Drawing.Size(72, 30)
        Me.txtQTYOnHand.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.DimGray
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(266, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 17)
        Me.Label3.TabIndex = 119
        Me.Label3.Text = "QTY On Hand:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(56, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 17)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "Description:"
        '
        'txtProductBarcode
        '
        Me.txtProductBarcode.AcceptsTab = True
        Me.txtProductBarcode.BackColor = System.Drawing.Color.White
        Me.txtProductBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductBarcode.Font = New System.Drawing.Font("Impact", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductBarcode.Location = New System.Drawing.Point(162, 19)
        Me.txtProductBarcode.Name = "txtProductBarcode"
        Me.txtProductBarcode.Size = New System.Drawing.Size(299, 53)
        Me.txtProductBarcode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DimGray
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(32, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 17)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "&Barcode/Name:"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Black
        Me.PictureBox4.Location = New System.Drawing.Point(164, 13)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(472, 386)
        Me.PictureBox4.TabIndex = 56
        Me.PictureBox4.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Location = New System.Drawing.Point(653, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(593, 795)
        Me.PictureBox1.TabIndex = 58
        Me.PictureBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox3.Controls.Add(Me.dgrProductList)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(1263, 124)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(800, 382)
        Me.GroupBox3.TabIndex = 59
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "PRODUCT &LIST. . ."
        Me.GroupBox3.Visible = False
        '
        'dgrProductList
        '
        Me.dgrProductList.AllowUserToDeleteRows = False
        Me.dgrProductList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgrProductList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgrProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgrProductList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgrProductList.Location = New System.Drawing.Point(17, 22)
        Me.dgrProductList.Name = "dgrProductList"
        Me.dgrProductList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgrProductList.Size = New System.Drawing.Size(765, 339)
        Me.dgrProductList.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Black
        Me.PictureBox2.Location = New System.Drawing.Point(1263, 478)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(508, 386)
        Me.PictureBox2.TabIndex = 60
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox4.Controls.Add(Me.lblTotalAmount)
        Me.GroupBox4.Controls.Add(Me.txtFinalDiscount)
        Me.GroupBox4.Controls.Add(Me.txtNetSales)
        Me.GroupBox4.Controls.Add(Me.PictureBox5)
        Me.GroupBox4.Controls.Add(Me.txtPayment)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.txtChangeDue)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txtNoOfItems)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Enabled = False
        Me.GroupBox4.Location = New System.Drawing.Point(159, 405)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(471, 395)
        Me.GroupBox4.TabIndex = 61
        Me.GroupBox4.TabStop = False
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTotalAmount.Font = New System.Drawing.Font("Academic M54", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTotalAmount.Location = New System.Drawing.Point(30, 32)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(411, 70)
        Me.lblTotalAmount.TabIndex = 133
        Me.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFinalDiscount
        '
        Me.txtFinalDiscount.AcceptsTab = True
        Me.txtFinalDiscount.BackColor = System.Drawing.Color.White
        Me.txtFinalDiscount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFinalDiscount.Font = New System.Drawing.Font("Impact", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFinalDiscount.Location = New System.Drawing.Point(130, 126)
        Me.txtFinalDiscount.Name = "txtFinalDiscount"
        Me.txtFinalDiscount.Size = New System.Drawing.Size(113, 37)
        Me.txtFinalDiscount.TabIndex = 8
        '
        'txtNetSales
        '
        Me.txtNetSales.AcceptsTab = True
        Me.txtNetSales.BackColor = System.Drawing.Color.White
        Me.txtNetSales.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNetSales.Font = New System.Drawing.Font("Impact", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNetSales.Location = New System.Drawing.Point(108, 169)
        Me.txtNetSales.Name = "txtNetSales"
        Me.txtNetSales.Size = New System.Drawing.Size(135, 53)
        Me.txtNetSales.TabIndex = 9
        Me.txtNetSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PictureBox5.Location = New System.Drawing.Point(13, 26)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(447, 84)
        Me.PictureBox5.TabIndex = 129
        Me.PictureBox5.TabStop = False
        '
        'txtPayment
        '
        Me.txtPayment.AcceptsTab = True
        Me.txtPayment.BackColor = System.Drawing.Color.White
        Me.txtPayment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPayment.Font = New System.Drawing.Font("Impact", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPayment.Location = New System.Drawing.Point(47, 268)
        Me.txtPayment.Name = "txtPayment"
        Me.txtPayment.Size = New System.Drawing.Size(384, 86)
        Me.txtPayment.TabIndex = 12
        Me.txtPayment.TabStop = False
        Me.txtPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.DimGray
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(39, 234)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(363, 31)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Payment (Cash Received):"
        '
        'txtChangeDue
        '
        Me.txtChangeDue.AcceptsTab = True
        Me.txtChangeDue.BackColor = System.Drawing.Color.White
        Me.txtChangeDue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChangeDue.Font = New System.Drawing.Font("Impact", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChangeDue.Location = New System.Drawing.Point(313, 171)
        Me.txtChangeDue.Name = "txtChangeDue"
        Me.txtChangeDue.Size = New System.Drawing.Size(118, 53)
        Me.txtChangeDue.TabIndex = 11
        Me.txtChangeDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DimGray
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(244, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 57)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "Change Due:"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.DimGray
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(41, 170)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 59)
        Me.Label10.TabIndex = 121
        Me.Label10.Text = "Net Sales:"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DimGray
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(43, 125)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 37)
        Me.Label11.TabIndex = 120
        Me.Label11.Text = "Less/ Discount:"
        '
        'txtNoOfItems
        '
        Me.txtNoOfItems.AcceptsTab = True
        Me.txtNoOfItems.BackColor = System.Drawing.Color.White
        Me.txtNoOfItems.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoOfItems.Font = New System.Drawing.Font("Impact", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoOfItems.Location = New System.Drawing.Point(313, 126)
        Me.txtNoOfItems.Name = "txtNoOfItems"
        Me.txtNoOfItems.Size = New System.Drawing.Size(118, 37)
        Me.txtNoOfItems.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.DimGray
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(247, 126)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 36)
        Me.Label12.TabIndex = 119
        Me.Label12.Text = "No. Of Items:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PictureBox12)
        Me.Panel1.Controls.Add(Me.PictureBox11)
        Me.Panel1.Controls.Add(Me.PictureBox10)
        Me.Panel1.Controls.Add(Me.PictureBox9)
        Me.Panel1.Controls.Add(Me.PictureBox8)
        Me.Panel1.Controls.Add(Me.PictureBox7)
        Me.Panel1.Controls.Add(Me.PictureBox6)
        Me.Panel1.Controls.Add(Me.PictureBox13)
        Me.Panel1.Location = New System.Drawing.Point(9, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(143, 797)
        Me.Panel1.TabIndex = 132
        '
        'PictureBox12
        '
        Me.PictureBox12.BackColor = System.Drawing.Color.DarkOrange
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(4, 583)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(132, 94)
        Me.PictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox12.TabIndex = 144
        Me.PictureBox12.TabStop = False
        '
        'PictureBox11
        '
        Me.PictureBox11.BackColor = System.Drawing.Color.DarkOrange
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(5, 485)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(132, 92)
        Me.PictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox11.TabIndex = 135
        Me.PictureBox11.TabStop = False
        '
        'PictureBox10
        '
        Me.PictureBox10.BackColor = System.Drawing.Color.DarkOrange
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(5, 391)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(132, 88)
        Me.PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox10.TabIndex = 134
        Me.PictureBox10.TabStop = False
        '
        'PictureBox9
        '
        Me.PictureBox9.BackColor = System.Drawing.Color.DarkOrange
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(5, 296)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(132, 89)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox9.TabIndex = 133
        Me.PictureBox9.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.DarkOrange
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(5, 201)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(132, 89)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox8.TabIndex = 132
        Me.PictureBox8.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.DarkOrange
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(5, 108)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(132, 87)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 129
        Me.PictureBox7.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.DarkOrange
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(5, 15)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(132, 87)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 0
        Me.PictureBox6.TabStop = False
        '
        'PictureBox13
        '
        Me.PictureBox13.BackColor = System.Drawing.Color.DarkOrange
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(3, 683)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(132, 91)
        Me.PictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox13.TabIndex = 150
        Me.PictureBox13.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Black
        Me.PictureBox3.Location = New System.Drawing.Point(164, 405)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(472, 401)
        Me.PictureBox3.TabIndex = 62
        Me.PictureBox3.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblReorderPOint)
        Me.Panel2.Location = New System.Drawing.Point(9, 810)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(4)
        Me.Panel2.Size = New System.Drawing.Size(1237, 84)
        Me.Panel2.TabIndex = 133
        '
        'lblReorderPOint
        '
        Me.lblReorderPOint.AutoEllipsis = True
        Me.lblReorderPOint.BackColor = System.Drawing.Color.Transparent
        Me.lblReorderPOint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReorderPOint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblReorderPOint.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReorderPOint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblReorderPOint.Location = New System.Drawing.Point(4, 4)
        Me.lblReorderPOint.Name = "lblReorderPOint"
        Me.lblReorderPOint.Padding = New System.Windows.Forms.Padding(5)
        Me.lblReorderPOint.Size = New System.Drawing.Size(1227, 74)
        Me.lblReorderPOint.TabIndex = 151
        Me.lblReorderPOint.Text = "Label30"
        Me.lblReorderPOint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbRoPoint
        '
        Me.cmbRoPoint.FormattingEnabled = True
        Me.cmbRoPoint.Location = New System.Drawing.Point(1252, 869)
        Me.cmbRoPoint.Name = "cmbRoPoint"
        Me.cmbRoPoint.Size = New System.Drawing.Size(121, 21)
        Me.cmbRoPoint.TabIndex = 151
        Me.cmbRoPoint.Visible = False
        '
        'tmrPOR
        '
        Me.tmrPOR.Enabled = True
        Me.tmrPOR.Interval = 2000
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 250
        '
        'frmSalesOrderTaking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1266, 900)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbRoPoint)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmSalesOrderTaking"
        Me.Opacity = 0.98
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        GroupBox2.ResumeLayout(False)
        CType(Me.dgrOrderList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgrProductList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbUnitPrice As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUnitType As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtQTYOnHand As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProductBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents dgrOrderList As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtChangeDue As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNoOfItems As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents txtPayment As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents txtFinalDiscount As System.Windows.Forms.TextBox
    Friend WithEvents txtNetSales As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents txtProductDescription As System.Windows.Forms.TextBox
    Friend WithEvents dgrProductList As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents lblOR As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbRoPoint As System.Windows.Forms.ComboBox
    Friend WithEvents lblReorderPOint As System.Windows.Forms.Label
    Protected WithEvents tmrPOR As System.Windows.Forms.Timer
    Protected WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents DESCRIPTION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUANTITY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AMOUNT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Disc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Barcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
