Public Class frmMain
    Private Sub CategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryToolStripMenuItem.Click
        Dim frm As New frmCategory
        frm.Show()
    End Sub

    Private Sub UnitTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnitTypeToolStripMenuItem.Click
        Dim frm As New frmUnitType
        frm.Show()
    End Sub

    Private Sub SupplierEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierEntryToolStripMenuItem.Click
        Dim frm As New frmCustomerRegistration
        frm.ShowInTaskbar = True
        frm.Show()
    End Sub

    Private Sub PricingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PricingToolStripMenuItem.Click
        Dim frm As New frmPriceDiscountAdjustment
        frm.Show()
    End Sub

   

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim ans As String
        If logOff = False Then
            ans = MsgBox("Are you sure to exit this application?", vbCritical + vbYesNo, "Exit Application..")
            If ans = vbNo Then
                e.Cancel = True
            Else
                'RECORD THE LOG-OUT DATA
                Dim strLogData As String = "'" & USER_ID_LOGGED & "','" & get_Server_Date() & "','LOG-OUT'"
                Call INSERT_DATA_TO_DATABASE("tblUserLoginData", "UserID,DateTimeLogged,ActionType", strLogData)
                Me.Dispose()
                Me.Close()
                End
            End If
        End If
    End Sub

    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            SalesOrderTakingToolStripMenuItem_Click(sender, e)

        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'GENERATE THE COMPANY PROFILE
        Call GENERATE_COMPANY_PROFILE_CONSTANTS(1)
        StatusStrip1.Items(0).Text = "User Logged: " & USER_NAME_LOGGED & ""
        StatusStrip1.Items(1).Text = "Latest Date/Time Logged: " & Now() & ""
        StatusStrip1.Items(2).Text = Now()
    End Sub

    Private Sub RegistrationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrationToolStripMenuItem.Click
        'Dim frm As New frmProductRegistration
        frmProductRegistration.ShowInTaskbar = True
        frmProductRegistration.Show()
    End Sub

    Private Sub RegistrationToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrationToolStripMenuItem1.Click
        Dim frm As New frmEmployee
        frm.ShowInTaskbar = True
        frm.ShowDialog()
    End Sub

    Private Sub PurchaseReceivedItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReceivedItemsToolStripMenuItem.Click
        Dim frm As New frmProductReceiving
        frm.ShowInTaskbar = True
        frm.ShowDialog()
    End Sub

    Private Sub SalesOrderTakingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesOrderTakingToolStripMenuItem.Click
        Dim frm As New frmSalesOrderTaking
        frmSalesOrderTaking.StartPosition = FormStartPosition.CenterScreen
        frmSalesOrderTaking.ShowDialog()
        frmSalesOrderTaking.txtProductBarcode.Focus()
    End Sub

    Private Sub ItemStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemStockToolStripMenuItem.Click
        Dim frm As New frmPORMonitoring
        frm.ShowInTaskbar = True
        frm.ShowDialog()
    End Sub

    Private Sub PurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderToolStripMenuItem.Click
        PurchaseOrderToolStripMenuItem.Enabled = False
        PictureBox1.Visible = False
        Dim frm As New frmPurchaseOrder
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.WindowState = FormWindowState.Maximized
        frm.MdiParent = Me
        frm.ShowIcon = True
        frm.TopMost = True
        frm.Show()
    End Sub

    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        PictureBox1.Height = Me.Height
        PictureBox1.Width = Me.Width
        StatusStrip1.Items(0).Width = Me.Width / 3
        StatusStrip1.Items(1).Width = Me.Width / 3
        StatusStrip1.Items(2).Width = Me.Width / 3
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        StatusStrip1.Items(2).Text = "                                  Date/Time: " & Now()
    End Sub

    Private Sub LogoffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoffToolStripMenuItem.Click
        Dim ctl As Control
        Dim ans As String
        ans = MsgBox("Are you sure to log-off?", vbYesNo + vbInformation, "Log-off.." & USER_NAME_LOGGED)
        If ans = vbYes Then
            'RECORD THE LOG-OUT DATA
            Dim strLogData As String = "'" & USER_ID_LOGGED & "','" & get_Server_Date() & "','LOG-OUT'"
            Call INSERT_DATA_TO_DATABASE("tblUserLoginData", "UserID,DateTimeLogged,ActionType", strLogData)
            For Each ctl In Controls
                If TypeOf ctl Is Form Then
                    ctl.Dispose()
                End If
            Next ctl
            logOff = True
            Me.Dispose()
            'Me.Close()
            frmLogin.Show()
        Else
            'Me.Show()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Dim ans As String
        ans = MsgBox("Are you sure to exit this application?", vbCritical + vbYesNo, "Exit Application..")
        If ans = vbNo Then
            
        Else
            'RECORD THE LOG-OUT DATA
            Dim strLogData As String = "'" & USER_ID_LOGGED & "','" & get_Server_Date() & "','LOG-OUT'"
            Call INSERT_DATA_TO_DATABASE("tblUserLoginData", "UserID,DateTimeLogged,ActionType", strLogData)
            Me.Close()
            Me.Dispose()
            End
        End If
    End Sub

    Private Sub SoldStockInventoryOutgoingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoldStockInventoryOutgoingToolStripMenuItem.Click
        Dim frm As New frmDeliveryMonitoring
        frm.WindowState = FormWindowState.Maximized
        frm.MdiParent = Me
        Me.PictureBox1.Visible = False
        frm.Show()
    End Sub

    Private Sub ReceivedStockInventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivedStockInventoryToolStripMenuItem.Click
        Dim frm As New frmReceivedStockMonitoring
        frm.WindowState = FormWindowState.Normal
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.ShowDialog()
    End Sub

    Private Sub StocksReleasingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StocksReleasingToolStripMenuItem.Click
        Dim frm As New frmProductReleasing
        frm.WindowState = FormWindowState.Normal
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.ShowDialog()
    End Sub

    Private Sub TStripPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TStripPO.Click
        PurchaseOrderToolStripMenuItem_Click(sender, e)
        TStripPO.Enabled = False
    End Sub

    Private Sub TStripStocksReceiving_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TStripStocksReceiving.Click
        TStripStocksReceiving.Enabled = False
        PurchaseReceivedItemsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub TStripStocksReleasing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TStripStocksReleasing.Click
        TStripStocksReleasing.Enabled = False
        StocksReleasingToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStrip1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStrip1.DoubleClick
        ToolStrip1.Dock = IIf(ToolStrip1.Dock = DockStyle.Right, DockStyle.Left, DockStyle.Right)
    End Sub


    Private Sub StockInventoryAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockInventoryAdjustmentToolStripMenuItem.Click
        StockInventoryAdjustmentToolStripMenuItem.Enabled = False
        PictureBox1.Visible = False
        Dim frm As New frmProducInvAdjustment
        frm.WindowState = FormWindowState.Maximized
        frm.MdiParent = Me
        Me.PictureBox1.Visible = False
        frm.Show()
    End Sub
End Class
