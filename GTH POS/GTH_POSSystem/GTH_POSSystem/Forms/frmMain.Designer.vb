<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LogoffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SalesOrderTakingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.IncommToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PurchaseReceivedItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.StockInventoryAdjustmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.PurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator
        Me.StocksReleasingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MonitoringToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DailySalesAndStockReportDSSRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ReceivedStockInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SoldStockInventoryOutgoingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ItemStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RegistrationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PricingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.CategoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnitTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SupplierEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.PersonnelEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RegistrationToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
        Me.RefreshToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.BackupDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChangeSystemBackgroundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NormalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MinimizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MaximizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.TipOfTheDayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.UserLogged = New System.Windows.Forms.ToolStripStatusLabel
        Me.DateTimeStrip = New System.Windows.Forms.ToolStripStatusLabel
        Me.PresentDateTime = New System.Windows.Forms.ToolStripStatusLabel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.TStripPO = New System.Windows.Forms.ToolStripButton
        Me.TStripStocksReceiving = New System.Windows.Forms.ToolStripButton
        Me.TStripStocksReleasing = New System.Windows.Forms.ToolStripButton
        Me.TStripInvoice = New System.Windows.Forms.ToolStripButton
        Me.TSTransferStock = New System.Windows.Forms.ToolStripButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TSClaimMemo = New System.Windows.Forms.ToolStripButton
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.TransactionToolStripMenuItem, Me.MonitoringToolStripMenuItem, Me.MaintenanceToolStripMenuItem, Me.WindowToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1005, 29)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchToolStripMenuItem, Me.LogoffToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(46, 25)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(131, 26)
        Me.SearchToolStripMenuItem.Text = "Search"
        '
        'LogoffToolStripMenuItem
        '
        Me.LogoffToolStripMenuItem.Name = "LogoffToolStripMenuItem"
        Me.LogoffToolStripMenuItem.Size = New System.Drawing.Size(131, 26)
        Me.LogoffToolStripMenuItem.Text = "Log-off"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(128, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(131, 26)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'TransactionToolStripMenuItem
        '
        Me.TransactionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalesOrderTakingToolStripMenuItem, Me.ToolStripSeparator2, Me.IncommToolStripMenuItem, Me.ToolStripSeparator11, Me.PurchaseOrderToolStripMenuItem, Me.ToolStripSeparator12, Me.StocksReleasingToolStripMenuItem})
        Me.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem"
        Me.TransactionToolStripMenuItem.Size = New System.Drawing.Size(102, 25)
        Me.TransactionToolStripMenuItem.Text = "&Transaction"
        '
        'SalesOrderTakingToolStripMenuItem
        '
        Me.SalesOrderTakingToolStripMenuItem.Name = "SalesOrderTakingToolStripMenuItem"
        Me.SalesOrderTakingToolStripMenuItem.Size = New System.Drawing.Size(272, 26)
        Me.SalesOrderTakingToolStripMenuItem.Text = "Sales Order Taking"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(269, 6)
        '
        'IncommToolStripMenuItem
        '
        Me.IncommToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PurchaseReceivedItemsToolStripMenuItem, Me.ToolStripSeparator3, Me.StockInventoryAdjustmentToolStripMenuItem})
        Me.IncommToolStripMenuItem.Name = "IncommToolStripMenuItem"
        Me.IncommToolStripMenuItem.Size = New System.Drawing.Size(272, 26)
        Me.IncommToolStripMenuItem.Text = "Incoming Stock/ Item Entry "
        '
        'PurchaseReceivedItemsToolStripMenuItem
        '
        Me.PurchaseReceivedItemsToolStripMenuItem.Name = "PurchaseReceivedItemsToolStripMenuItem"
        Me.PurchaseReceivedItemsToolStripMenuItem.Size = New System.Drawing.Size(320, 26)
        Me.PurchaseReceivedItemsToolStripMenuItem.Text = "Incomming Stocks Receiving Form"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(317, 6)
        '
        'StockInventoryAdjustmentToolStripMenuItem
        '
        Me.StockInventoryAdjustmentToolStripMenuItem.Name = "StockInventoryAdjustmentToolStripMenuItem"
        Me.StockInventoryAdjustmentToolStripMenuItem.Size = New System.Drawing.Size(320, 26)
        Me.StockInventoryAdjustmentToolStripMenuItem.Text = "Stock Inventory Adjustment"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(269, 6)
        '
        'PurchaseOrderToolStripMenuItem
        '
        Me.PurchaseOrderToolStripMenuItem.Name = "PurchaseOrderToolStripMenuItem"
        Me.PurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(272, 26)
        Me.PurchaseOrderToolStripMenuItem.Text = "Purchase Order"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(269, 6)
        '
        'StocksReleasingToolStripMenuItem
        '
        Me.StocksReleasingToolStripMenuItem.Name = "StocksReleasingToolStripMenuItem"
        Me.StocksReleasingToolStripMenuItem.Size = New System.Drawing.Size(272, 26)
        Me.StocksReleasingToolStripMenuItem.Text = "Stocks Releasing"
        '
        'MonitoringToolStripMenuItem
        '
        Me.MonitoringToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DailySalesAndStockReportDSSRToolStripMenuItem, Me.ToolStripSeparator4, Me.ReceivedStockInventoryToolStripMenuItem, Me.SoldStockInventoryOutgoingToolStripMenuItem, Me.ToolStripSeparator5, Me.ItemStockToolStripMenuItem})
        Me.MonitoringToolStripMenuItem.Name = "MonitoringToolStripMenuItem"
        Me.MonitoringToolStripMenuItem.Size = New System.Drawing.Size(100, 25)
        Me.MonitoringToolStripMenuItem.Text = "&Monitoring"
        '
        'DailySalesAndStockReportDSSRToolStripMenuItem
        '
        Me.DailySalesAndStockReportDSSRToolStripMenuItem.Name = "DailySalesAndStockReportDSSRToolStripMenuItem"
        Me.DailySalesAndStockReportDSSRToolStripMenuItem.Size = New System.Drawing.Size(333, 26)
        Me.DailySalesAndStockReportDSSRToolStripMenuItem.Text = "Daily Sales and Stock Report (DSSR)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(330, 6)
        '
        'ReceivedStockInventoryToolStripMenuItem
        '
        Me.ReceivedStockInventoryToolStripMenuItem.Name = "ReceivedStockInventoryToolStripMenuItem"
        Me.ReceivedStockInventoryToolStripMenuItem.Size = New System.Drawing.Size(333, 26)
        Me.ReceivedStockInventoryToolStripMenuItem.Text = "Received Stock Inventory (Incoming)"
        '
        'SoldStockInventoryOutgoingToolStripMenuItem
        '
        Me.SoldStockInventoryOutgoingToolStripMenuItem.Name = "SoldStockInventoryOutgoingToolStripMenuItem"
        Me.SoldStockInventoryOutgoingToolStripMenuItem.Size = New System.Drawing.Size(333, 26)
        Me.SoldStockInventoryOutgoingToolStripMenuItem.Text = "Sold Stock Inventory (Outgoing)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(330, 6)
        '
        'ItemStockToolStripMenuItem
        '
        Me.ItemStockToolStripMenuItem.Name = "ItemStockToolStripMenuItem"
        Me.ItemStockToolStripMenuItem.Size = New System.Drawing.Size(333, 26)
        Me.ItemStockToolStripMenuItem.Text = "Item/Stock for Replenishment"
        '
        'MaintenanceToolStripMenuItem
        '
        Me.MaintenanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductToolStripMenuItem, Me.SupplierEntryToolStripMenuItem, Me.CustomerEntryToolStripMenuItem, Me.ToolStripSeparator7, Me.PersonnelEntryToolStripMenuItem, Me.RefreshToolStripMenuItem, Me.RefreshToolStripMenuItem1, Me.ToolStripSeparator8, Me.BackupDatabaseToolStripMenuItem, Me.ChangeSystemBackgroundToolStripMenuItem})
        Me.MaintenanceToolStripMenuItem.Name = "MaintenanceToolStripMenuItem"
        Me.MaintenanceToolStripMenuItem.Size = New System.Drawing.Size(111, 25)
        Me.MaintenanceToolStripMenuItem.Text = "Mai&ntenance"
        '
        'ProductToolStripMenuItem
        '
        Me.ProductToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrationToolStripMenuItem, Me.PricingToolStripMenuItem, Me.ToolStripSeparator6, Me.CategoryToolStripMenuItem, Me.UnitTypeToolStripMenuItem})
        Me.ProductToolStripMenuItem.Name = "ProductToolStripMenuItem"
        Me.ProductToolStripMenuItem.Size = New System.Drawing.Size(281, 26)
        Me.ProductToolStripMenuItem.Text = "Product"
        '
        'RegistrationToolStripMenuItem
        '
        Me.RegistrationToolStripMenuItem.Name = "RegistrationToolStripMenuItem"
        Me.RegistrationToolStripMenuItem.Size = New System.Drawing.Size(164, 26)
        Me.RegistrationToolStripMenuItem.Text = "Registration"
        '
        'PricingToolStripMenuItem
        '
        Me.PricingToolStripMenuItem.Name = "PricingToolStripMenuItem"
        Me.PricingToolStripMenuItem.Size = New System.Drawing.Size(164, 26)
        Me.PricingToolStripMenuItem.Text = "Pricing"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(161, 6)
        '
        'CategoryToolStripMenuItem
        '
        Me.CategoryToolStripMenuItem.Name = "CategoryToolStripMenuItem"
        Me.CategoryToolStripMenuItem.Size = New System.Drawing.Size(164, 26)
        Me.CategoryToolStripMenuItem.Text = "Category"
        '
        'UnitTypeToolStripMenuItem
        '
        Me.UnitTypeToolStripMenuItem.Name = "UnitTypeToolStripMenuItem"
        Me.UnitTypeToolStripMenuItem.Size = New System.Drawing.Size(164, 26)
        Me.UnitTypeToolStripMenuItem.Text = "Unit Type.."
        '
        'SupplierEntryToolStripMenuItem
        '
        Me.SupplierEntryToolStripMenuItem.Name = "SupplierEntryToolStripMenuItem"
        Me.SupplierEntryToolStripMenuItem.Size = New System.Drawing.Size(281, 26)
        Me.SupplierEntryToolStripMenuItem.Text = "Supplier Entry . . ."
        '
        'CustomerEntryToolStripMenuItem
        '
        Me.CustomerEntryToolStripMenuItem.Enabled = False
        Me.CustomerEntryToolStripMenuItem.Name = "CustomerEntryToolStripMenuItem"
        Me.CustomerEntryToolStripMenuItem.Size = New System.Drawing.Size(281, 26)
        Me.CustomerEntryToolStripMenuItem.Text = "Customer Entry . . ."
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(278, 6)
        '
        'PersonnelEntryToolStripMenuItem
        '
        Me.PersonnelEntryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrationToolStripMenuItem1, Me.ToolStripSeparator9, Me.ChangePasswordToolStripMenuItem})
        Me.PersonnelEntryToolStripMenuItem.Name = "PersonnelEntryToolStripMenuItem"
        Me.PersonnelEntryToolStripMenuItem.Size = New System.Drawing.Size(281, 26)
        Me.PersonnelEntryToolStripMenuItem.Text = "Personnel Entry"
        '
        'RegistrationToolStripMenuItem1
        '
        Me.RegistrationToolStripMenuItem1.Name = "RegistrationToolStripMenuItem1"
        Me.RegistrationToolStripMenuItem1.Size = New System.Drawing.Size(204, 26)
        Me.RegistrationToolStripMenuItem1.Text = "Registration"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(201, 6)
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(204, 26)
        Me.ChangePasswordToolStripMenuItem.Text = "Change Password"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(278, 6)
        '
        'RefreshToolStripMenuItem1
        '
        Me.RefreshToolStripMenuItem1.Name = "RefreshToolStripMenuItem1"
        Me.RefreshToolStripMenuItem1.Size = New System.Drawing.Size(281, 26)
        Me.RefreshToolStripMenuItem1.Text = "Refresh"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(278, 6)
        '
        'BackupDatabaseToolStripMenuItem
        '
        Me.BackupDatabaseToolStripMenuItem.Name = "BackupDatabaseToolStripMenuItem"
        Me.BackupDatabaseToolStripMenuItem.Size = New System.Drawing.Size(281, 26)
        Me.BackupDatabaseToolStripMenuItem.Text = "Back-up Database.."
        '
        'ChangeSystemBackgroundToolStripMenuItem
        '
        Me.ChangeSystemBackgroundToolStripMenuItem.Name = "ChangeSystemBackgroundToolStripMenuItem"
        Me.ChangeSystemBackgroundToolStripMenuItem.Size = New System.Drawing.Size(281, 26)
        Me.ChangeSystemBackgroundToolStripMenuItem.Text = "Change System Background.."
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NormalToolStripMenuItem, Me.MinimizeToolStripMenuItem, Me.MaximizeToolStripMenuItem})
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(80, 25)
        Me.WindowToolStripMenuItem.Text = "&Window"
        '
        'NormalToolStripMenuItem
        '
        Me.NormalToolStripMenuItem.Name = "NormalToolStripMenuItem"
        Me.NormalToolStripMenuItem.Size = New System.Drawing.Size(146, 26)
        Me.NormalToolStripMenuItem.Text = "Normal"
        '
        'MinimizeToolStripMenuItem
        '
        Me.MinimizeToolStripMenuItem.Name = "MinimizeToolStripMenuItem"
        Me.MinimizeToolStripMenuItem.Size = New System.Drawing.Size(146, 26)
        Me.MinimizeToolStripMenuItem.Text = "Minimize"
        '
        'MaximizeToolStripMenuItem
        '
        Me.MaximizeToolStripMenuItem.Name = "MaximizeToolStripMenuItem"
        Me.MaximizeToolStripMenuItem.Size = New System.Drawing.Size(146, 26)
        Me.MaximizeToolStripMenuItem.Text = "Maximize"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.ToolStripSeparator10, Me.TipOfTheDayToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(54, 25)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(176, 26)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(173, 6)
        '
        'TipOfTheDayToolStripMenuItem
        '
        Me.TipOfTheDayToolStripMenuItem.Name = "TipOfTheDayToolStripMenuItem"
        Me.TipOfTheDayToolStripMenuItem.Size = New System.Drawing.Size(176, 26)
        Me.TipOfTheDayToolStripMenuItem.Text = "Tip of the Day"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserLogged, Me.DateTimeStrip, Me.PresentDateTime})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 598)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StatusStrip1.Size = New System.Drawing.Size(1005, 39)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'UserLogged
        '
        Me.UserLogged.AutoSize = False
        Me.UserLogged.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.UserLogged.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.UserLogged.Name = "UserLogged"
        Me.UserLogged.Size = New System.Drawing.Size(126, 34)
        Me.UserLogged.Text = "User Logged:"
        '
        'DateTimeStrip
        '
        Me.DateTimeStrip.AutoSize = False
        Me.DateTimeStrip.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.DateTimeStrip.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.DateTimeStrip.Name = "DateTimeStrip"
        Me.DateTimeStrip.Size = New System.Drawing.Size(107, 34)
        Me.DateTimeStrip.Text = "Date/Time:"
        '
        'PresentDateTime
        '
        Me.PresentDateTime.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.PresentDateTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.PresentDateTime.Name = "PresentDateTime"
        Me.PresentDateTime.Size = New System.Drawing.Size(4, 34)
        Me.PresentDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowItemReorder = True
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.TStripPO, Me.TStripStocksReceiving, Me.TStripStocksReleasing, Me.TStripInvoice, Me.TSTransferStock, Me.TSClaimMemo})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(875, 29)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(130, 569)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.White
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(129, 21)
        Me.ToolStripLabel1.Text = "WAREHOUSING"
        '
        'TStripPO
        '
        Me.TStripPO.ForeColor = System.Drawing.Color.White
        Me.TStripPO.Image = CType(resources.GetObject("TStripPO.Image"), System.Drawing.Image)
        Me.TStripPO.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.TStripPO.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TStripPO.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TStripPO.Name = "TStripPO"
        Me.TStripPO.Size = New System.Drawing.Size(129, 56)
        Me.TStripPO.Text = "Purchase Order"
        Me.TStripPO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.TStripPO.ToolTipText = "Create a purchase order for submission to supplier."
        '
        'TStripStocksReceiving
        '
        Me.TStripStocksReceiving.ForeColor = System.Drawing.Color.White
        Me.TStripStocksReceiving.Image = CType(resources.GetObject("TStripStocksReceiving.Image"), System.Drawing.Image)
        Me.TStripStocksReceiving.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TStripStocksReceiving.Name = "TStripStocksReceiving"
        Me.TStripStocksReceiving.Size = New System.Drawing.Size(129, 67)
        Me.TStripStocksReceiving.Text = "Stocks Receiving"
        Me.TStripStocksReceiving.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.TStripStocksReceiving.ToolTipText = "Record receipt of inventory items that arrived with a bill or without a bill to k" & _
            "eep your inventory updated."
        '
        'TStripStocksReleasing
        '
        Me.TStripStocksReleasing.ForeColor = System.Drawing.Color.White
        Me.TStripStocksReleasing.Image = CType(resources.GetObject("TStripStocksReleasing.Image"), System.Drawing.Image)
        Me.TStripStocksReleasing.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TStripStocksReleasing.Name = "TStripStocksReleasing"
        Me.TStripStocksReleasing.Size = New System.Drawing.Size(129, 67)
        Me.TStripStocksReleasing.Text = "Create Sales Receipts"
        Me.TStripStocksReleasing.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.TStripStocksReleasing.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.TStripStocksReleasing.ToolTipText = "Create Sales Receipts (bill your customer and received the payment at the same ti" & _
            "me)."
        '
        'TStripInvoice
        '
        Me.TStripInvoice.ForeColor = System.Drawing.Color.White
        Me.TStripInvoice.Image = CType(resources.GetObject("TStripInvoice.Image"), System.Drawing.Image)
        Me.TStripInvoice.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TStripInvoice.Name = "TStripInvoice"
        Me.TStripInvoice.Size = New System.Drawing.Size(129, 67)
        Me.TStripInvoice.Text = "Create Sales Invoice"
        Me.TStripInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.TStripInvoice.ToolTipText = "Bill you customer and receive the payment later"
        '
        'TSTransferStock
        '
        Me.TSTransferStock.ForeColor = System.Drawing.Color.White
        Me.TSTransferStock.Image = CType(resources.GetObject("TSTransferStock.Image"), System.Drawing.Image)
        Me.TSTransferStock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSTransferStock.Name = "TSTransferStock"
        Me.TSTransferStock.Size = New System.Drawing.Size(129, 67)
        Me.TSTransferStock.Text = "Transfer Stock"
        Me.TSTransferStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1005, 637)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'TSClaimMemo
        '
        Me.TSClaimMemo.ForeColor = System.Drawing.Color.White
        Me.TSClaimMemo.Image = CType(resources.GetObject("TSClaimMemo.Image"), System.Drawing.Image)
        Me.TSClaimMemo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSClaimMemo.Name = "TSClaimMemo"
        Me.TSClaimMemo.Size = New System.Drawing.Size(129, 67)
        Me.TSClaimMemo.Text = "Create Claim Memo"
        Me.TSClaimMemo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.TSClaimMemo.ToolTipText = "Create Claim Memo to claim underlivered or lacking items based on P.O"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 637)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "GTH Point of Sales System. . . Version 1.0"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MonitoringToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesOrderTakingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents IncommToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseReceivedItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StockInventoryAdjustmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DailySalesAndStockReportDSSRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ReceivedStockInventoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SoldStockInventoryOutgoingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ItemStockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupplierEntryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerEntryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PersonnelEntryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BackupDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeSystemBackgroundToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistrationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PricingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CategoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnitTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistrationToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NormalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MinimizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaximizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TipOfTheDayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents UserLogged As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PurchaseOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents DateTimeStrip As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PresentDateTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StocksReleasingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TStripStocksReleasing As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TStripPO As System.Windows.Forms.ToolStripButton
    Friend WithEvents TStripStocksReceiving As System.Windows.Forms.ToolStripButton
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents TStripInvoice As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSTransferStock As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSClaimMemo As System.Windows.Forms.ToolStripButton

End Class
