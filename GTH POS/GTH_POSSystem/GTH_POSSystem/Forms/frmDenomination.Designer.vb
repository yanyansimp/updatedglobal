<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDenomination
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
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents Copyright As System.Windows.Forms.Label
    Friend WithEvents MainLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DetailsLayoutPanel As System.Windows.Forms.TableLayoutPanel

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDenomination))
        Me.MainLayoutPanel = New System.Windows.Forms.TableLayoutPanel
        Me.DetailsLayoutPanel = New System.Windows.Forms.TableLayoutPanel
        Me.Copyright = New System.Windows.Forms.Label
        Me.Version = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lblChange = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.LFiveCents = New System.Windows.Forms.Label
        Me.LTweenty = New System.Windows.Forms.Label
        Me.LTenCents = New System.Windows.Forms.Label
        Me.LFifty = New System.Windows.Forms.Label
        Me.LTweentyFive = New System.Windows.Forms.Label
        Me.LOneHundred = New System.Windows.Forms.Label
        Me.LOne = New System.Windows.Forms.Label
        Me.LTwoHundred = New System.Windows.Forms.Label
        Me.LFive = New System.Windows.Forms.Label
        Me.LFiveHundred = New System.Windows.Forms.Label
        Me.LTen = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.LOneThousand = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ApplicationTitle = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.MainLayoutPanel.SuspendLayout()
        Me.DetailsLayoutPanel.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainLayoutPanel
        '
        Me.MainLayoutPanel.BackgroundImage = CType(resources.GetObject("MainLayoutPanel.BackgroundImage"), System.Drawing.Image)
        Me.MainLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MainLayoutPanel.ColumnCount = 2
        Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 217.0!))
        Me.MainLayoutPanel.Controls.Add(Me.DetailsLayoutPanel, 1, 1)
        Me.MainLayoutPanel.Controls.Add(Me.GroupBox1, 0, 0)
        Me.MainLayoutPanel.Controls.Add(Me.ApplicationTitle, 1, 0)
        Me.MainLayoutPanel.Controls.Add(Me.Label8, 0, 1)
        Me.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainLayoutPanel.Name = "MainLayoutPanel"
        Me.MainLayoutPanel.RowCount = 2
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 411.0!))
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.MainLayoutPanel.Size = New System.Drawing.Size(679, 472)
        Me.MainLayoutPanel.TabIndex = 0
        '
        'DetailsLayoutPanel
        '
        Me.DetailsLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DetailsLayoutPanel.BackColor = System.Drawing.Color.Transparent
        Me.DetailsLayoutPanel.ColumnCount = 1
        Me.DetailsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247.0!))
        Me.DetailsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142.0!))
        Me.DetailsLayoutPanel.Controls.Add(Me.Copyright, 0, 1)
        Me.DetailsLayoutPanel.Controls.Add(Me.Version, 0, 0)
        Me.DetailsLayoutPanel.Location = New System.Drawing.Point(480, 414)
        Me.DetailsLayoutPanel.Name = "DetailsLayoutPanel"
        Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.DetailsLayoutPanel.Size = New System.Drawing.Size(211, 55)
        Me.DetailsLayoutPanel.TabIndex = 1
        '
        'Copyright
        '
        Me.Copyright.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Copyright.BackColor = System.Drawing.Color.Transparent
        Me.Copyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.Location = New System.Drawing.Point(31, 27)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(185, 28)
        Me.Copyright.TabIndex = 2
        Me.Copyright.Text = "Copyright"
        '
        'Version
        '
        Me.Version.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Version.BackColor = System.Drawing.Color.Transparent
        Me.Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.Location = New System.Drawing.Point(30, 3)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(187, 20)
        Me.Version.TabIndex = 1
        Me.Version.Text = "Version {0}.{1:00}"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GrayText
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(471, 405)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.181!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.819!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblChange, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label30, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.LFiveCents, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.LTweenty, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.LTenCents, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LFifty, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LTweentyFive, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LOneHundred, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.LOne, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LTwoHundred, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LFive, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LFiveHundred, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LTen, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label28, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label26, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label24, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label22, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label20, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label18, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LOneThousand, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 133)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(442, 266)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblChange
        '
        Me.lblChange.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblChange.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblChange, 3)
        Me.lblChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChange.ForeColor = System.Drawing.Color.Yellow
        Me.lblChange.Location = New System.Drawing.Point(130, 234)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(307, 30)
        Me.lblChange.TabIndex = 39
        Me.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label30.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Yellow
        Me.Label30.Location = New System.Drawing.Point(5, 234)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(117, 30)
        Me.Label30.TabIndex = 38
        Me.Label30.Text = "CHANGE DUE: (Php)"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LFiveCents
        '
        Me.LFiveCents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LFiveCents.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LFiveCents.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LFiveCents.ForeColor = System.Drawing.Color.White
        Me.LFiveCents.Location = New System.Drawing.Point(344, 198)
        Me.LFiveCents.Name = "LFiveCents"
        Me.LFiveCents.Size = New System.Drawing.Size(93, 34)
        Me.LFiveCents.TabIndex = 37
        Me.LFiveCents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LTweenty
        '
        Me.LTweenty.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LTweenty.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LTweenty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTweenty.ForeColor = System.Drawing.Color.White
        Me.LTweenty.Location = New System.Drawing.Point(130, 198)
        Me.LTweenty.Name = "LTweenty"
        Me.LTweenty.Size = New System.Drawing.Size(76, 34)
        Me.LTweenty.TabIndex = 36
        Me.LTweenty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LTenCents
        '
        Me.LTenCents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LTenCents.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LTenCents.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTenCents.ForeColor = System.Drawing.Color.White
        Me.LTenCents.Location = New System.Drawing.Point(344, 164)
        Me.LTenCents.Name = "LTenCents"
        Me.LTenCents.Size = New System.Drawing.Size(93, 32)
        Me.LTenCents.TabIndex = 35
        Me.LTenCents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LFifty
        '
        Me.LFifty.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LFifty.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LFifty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LFifty.ForeColor = System.Drawing.Color.White
        Me.LFifty.Location = New System.Drawing.Point(130, 164)
        Me.LFifty.Name = "LFifty"
        Me.LFifty.Size = New System.Drawing.Size(76, 32)
        Me.LFifty.TabIndex = 34
        Me.LFifty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LTweentyFive
        '
        Me.LTweentyFive.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LTweentyFive.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LTweentyFive.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTweentyFive.ForeColor = System.Drawing.Color.White
        Me.LTweentyFive.Location = New System.Drawing.Point(344, 129)
        Me.LTweentyFive.Name = "LTweentyFive"
        Me.LTweentyFive.Size = New System.Drawing.Size(93, 33)
        Me.LTweentyFive.TabIndex = 33
        Me.LTweentyFive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LOneHundred
        '
        Me.LOneHundred.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LOneHundred.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LOneHundred.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LOneHundred.ForeColor = System.Drawing.Color.White
        Me.LOneHundred.Location = New System.Drawing.Point(130, 129)
        Me.LOneHundred.Name = "LOneHundred"
        Me.LOneHundred.Size = New System.Drawing.Size(76, 33)
        Me.LOneHundred.TabIndex = 32
        Me.LOneHundred.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LOne
        '
        Me.LOne.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LOne.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LOne.ForeColor = System.Drawing.Color.White
        Me.LOne.Location = New System.Drawing.Point(344, 94)
        Me.LOne.Name = "LOne"
        Me.LOne.Size = New System.Drawing.Size(93, 33)
        Me.LOne.TabIndex = 31
        Me.LOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LTwoHundred
        '
        Me.LTwoHundred.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LTwoHundred.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LTwoHundred.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTwoHundred.ForeColor = System.Drawing.Color.White
        Me.LTwoHundred.Location = New System.Drawing.Point(130, 94)
        Me.LTwoHundred.Name = "LTwoHundred"
        Me.LTwoHundred.Size = New System.Drawing.Size(76, 33)
        Me.LTwoHundred.TabIndex = 30
        Me.LTwoHundred.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LFive
        '
        Me.LFive.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LFive.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LFive.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LFive.ForeColor = System.Drawing.Color.White
        Me.LFive.Location = New System.Drawing.Point(344, 58)
        Me.LFive.Name = "LFive"
        Me.LFive.Size = New System.Drawing.Size(93, 34)
        Me.LFive.TabIndex = 29
        Me.LFive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LFiveHundred
        '
        Me.LFiveHundred.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LFiveHundred.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LFiveHundred.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LFiveHundred.ForeColor = System.Drawing.Color.White
        Me.LFiveHundred.Location = New System.Drawing.Point(130, 58)
        Me.LFiveHundred.Name = "LFiveHundred"
        Me.LFiveHundred.Size = New System.Drawing.Size(76, 34)
        Me.LFiveHundred.TabIndex = 28
        Me.LFiveHundred.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LTen
        '
        Me.LTen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LTen.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LTen.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTen.ForeColor = System.Drawing.Color.White
        Me.LTen.Location = New System.Drawing.Point(344, 22)
        Me.LTen.Name = "LTen"
        Me.LTen.Size = New System.Drawing.Size(93, 34)
        Me.LTen.TabIndex = 27
        Me.LTen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(214, 198)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(103, 34)
        Me.Label28.TabIndex = 26
        Me.Label28.Text = "0.05"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(5, 198)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(103, 34)
        Me.Label26.TabIndex = 24
        Me.Label26.Text = "20.00"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(214, 164)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(103, 32)
        Me.Label24.TabIndex = 22
        Me.Label24.Text = "0.10"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(5, 164)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(103, 32)
        Me.Label22.TabIndex = 20
        Me.Label22.Text = "50.00"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(214, 129)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(103, 33)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "0.25"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(5, 129)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(103, 33)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "100.00"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(214, 94)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(103, 33)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "1.00"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(5, 94)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 33)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "200.00"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(214, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 34)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "5.00"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(214, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 34)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "10.00"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LOneThousand
        '
        Me.LOneThousand.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LOneThousand.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LOneThousand.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LOneThousand.ForeColor = System.Drawing.Color.White
        Me.LOneThousand.Location = New System.Drawing.Point(130, 22)
        Me.LOneThousand.Name = "LOneThousand"
        Me.LOneThousand.Size = New System.Drawing.Size(76, 34)
        Me.LOneThousand.TabIndex = 6
        Me.LOneThousand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 34)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "1000.00"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(344, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 18)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Quantity"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(130, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 18)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Quantity"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Denomination"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(214, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 18)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Denomination"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 34)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "500.00"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(444, 123)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Change Due (Denomination)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ApplicationTitle
        '
        Me.ApplicationTitle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplicationTitle.BackColor = System.Drawing.Color.Transparent
        Me.ApplicationTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplicationTitle.Location = New System.Drawing.Point(480, 0)
        Me.ApplicationTitle.Name = "ApplicationTitle"
        Me.ApplicationTitle.Size = New System.Drawing.Size(211, 411)
        Me.ApplicationTitle.TabIndex = 0
        Me.ApplicationTitle.Text = "Application Title"
        Me.ApplicationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(3, 427)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(471, 28)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Press F1 twice to start a new transaction!"
        '
        'Timer1
        '
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'frmDenomination
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 472)
        Me.ControlBox = False
        Me.Controls.Add(Me.MainLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDenomination"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.MainLayoutPanel.ResumeLayout(False)
        Me.DetailsLayoutPanel.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ApplicationTitle As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LOneThousand As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LFiveCents As System.Windows.Forms.Label
    Friend WithEvents LTweenty As System.Windows.Forms.Label
    Friend WithEvents LTenCents As System.Windows.Forms.Label
    Friend WithEvents LFifty As System.Windows.Forms.Label
    Friend WithEvents LTweentyFive As System.Windows.Forms.Label
    Friend WithEvents LOneHundred As System.Windows.Forms.Label
    Friend WithEvents LOne As System.Windows.Forms.Label
    Friend WithEvents LTwoHundred As System.Windows.Forms.Label
    Friend WithEvents LFive As System.Windows.Forms.Label
    Friend WithEvents LFiveHundred As System.Windows.Forms.Label
    Friend WithEvents LTen As System.Windows.Forms.Label
    Friend WithEvents lblChange As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer

End Class
