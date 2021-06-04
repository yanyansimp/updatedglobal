Imports System.Data.SqlClient

Public Class frmSalesMonitoring

#Region "CommonFunctions"
    Private conn As New SqlClient.SqlConnection("Data Source=server_jbg; Initial Catalog=POS;Integrated Security=True;")
    Private ComDset As New DataSet
    Private ComDset1 As New DataSet
    Private LeaderID As Long
    Private userID As Long
    Private rMoveVal As Boolean = False
    Dim Batch_Number As Long

    Dim CurrentRowIndex As Integer = 0
#End Region

    Private Sub frmSalesMonitoring_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.PictureBox1.Visible = True
    End Sub

    Private Sub frmSalesMonitoring_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LoadEmployeeListToCombo()
        Call Load_Logs(userID)
        dtpEndDateTime.Value = Now
        dtpStartDateTime.Value = Now
        dtpEndTime.Value = Now
        dtpStartTime.Value = Now
    End Sub

    Private Sub LoadEmployeeListToCombo()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT   trnno, EmployeesName       FROM tblEmployees ORDER BY EmployeesName", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                cmbClerk.Items.Clear()
                cmbClerk.Items.Add(New ComboListData(("- - A L L - -"), 0))
                For rowcounter = 0 To .Rows.Count - 1
                    cmbClerk.Items.Add(New ComboListData(.Rows(rowcounter).Item("EmployeesName").ToString(), .Rows(rowcounter).Item("trnno").ToString()))
                Next
            End If
        End With

        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub getUserIDFromComboBOx()
        Try
            For Each item As ComboListData In cmbClerk.Items
                If item.Name.ToString = cmbClerk.SelectedItem.ToString Then
                    userID = item.ItemData.ToString
                    GoTo exit_loop2
                End If
            Next
        Catch
            'MsgBox(Err.Description)
        End Try
exit_loop2:
    End Sub

    Private Sub Load_Logs(ByVal userID As String)
        Dim rowcounter As Integer
        If cmbClerk.Text = "- - A L L - -" Then
            sqladapter = New SqlClient.SqlDataAdapter("SELECT     DateTimeLogged, ActionType       FROM tblUserLoginData      ORDER BY trnno DESC", conn)
        Else
            sqladapter = New SqlClient.SqlDataAdapter("SELECT     DateTimeLogged, ActionType       FROM tblUserLoginData         WHERE userID = '" & userID & "' ORDER BY trnno DESC", conn)
        End If
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                ListView1.Items.Clear()
                ListView1.Columns.Clear()

                'Add column header
                ListView1.Columns.Add("DateTime", 130)
                ListView1.Columns.Add("Status", 300)

                'Add items in the listview
                Dim arr(5) As String
                Dim itm As ListViewItem

                For rowcounter = 0 To .Rows.Count - 1

                    'Add first item
                    arr(0) = (.Rows(rowcounter).Item("DateTimeLogged").ToString())
                    arr(1) = (.Rows(rowcounter).Item("ActionType").ToString())

                    itm = New ListViewItem(arr)
                    ListView1.Items.Add(itm)
                Next
                'cmbBrgy.SelectedIndex = 0
                'DataGridView1.DataSource = dsDataset.Tables(0)
                'DataGridView1.AutoResizeColumns()

            Else
                ListView1.Items.Clear()

            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub cmbClerk_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClerk.SelectedIndexChanged
        Call getUserIDFromComboBOx()
        Call Load_Logs(userID)
    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        With ListView1
            ' MsgBox(.SelectedItems.Item(0).SubItems(1).Text)
            If .SelectedItems.Item(0).SubItems(1).Text = "LOG-IN" Then
                dtpStartDateTime.Value = .SelectedItems.Item(0).Text
                dtpStartTime.Value = dtpStartDateTime.Value
            ElseIf .SelectedItems.Item(0).SubItems(1).Text = "LOG-OUT" Then
                dtpEndDateTime.Value = .SelectedItems.Item(0).Text
                dtpEndTime.Value = dtpEndDateTime.Value
            End If
        End With
    End Sub

    Private Sub load_TotalSales()
        Dim rowcounter As Integer
        If cmbClerk.Text = "- - A L L - -" Then
            sqladapter = New SqlClient.SqlDataAdapter("SELECT     ORNumber, TotalAmount, SalesDiscount, NetSales, NoOfItems, Payment, Change, TransactionDate, VATSales " _
                                                    & " FROM tblSalesTransactionTotal WHERE    (TransactionDate >= '" & dtpStartDateTime.Value & "') AND (TransactionDate <= '" & dtpEndDateTime.Value & "') order by TransactionDate,ORNumber", conn)

        Else
            sqladapter = New SqlClient.SqlDataAdapter("SELECT     ORNumber, TotalAmount, SalesDiscount, NetSales, NoOfItems, Payment, Change, TransactionDate, VATSales " _
                                                    & " FROM tblSalesTransactionTotal WHERE     EmployeesID = " & userID & " AND (TransactionDate >= '" & dtpStartDateTime.Value & "') AND (TransactionDate <= '" & dtpEndDateTime.Value & "') order by TransactionDate,ORNumber", conn)
        End If
        ' AND (TransactionDate >= '11/21/2016 7:20:24 PM') AND (TransactionDate <= '11/22/2016 9:55:28 PM')
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                'cmbBrgy.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    'cmbBrgy.Items.Add(.Rows(rowcounter).Item("barangayname").ToString())
                Next
                'cmbBrgy.SelectedIndex = 0
                DataGridView1.DataSource = dsDataset.Tables(0)
                DataGridView1.AutoResizeColumns()

            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub load_SalesDetails(ByVal ORNumber As String)
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT    ORNumber, (SELECT     ProductDescription      FROM tblProduct      WHERE      ProductID_Barcode = tblSalesTransaction.ProductID_Barcode) AS ProductDescription, Quantity, DiscountValue, Amount, TransactionTime    FROM   tblSalesTransaction WHERE     (ORNumber = '" & ORNumber & "')", conn)
        ' AND (TransactionDate >= '11/21/2016 7:20:24 PM') AND (TransactionDate <= '11/22/2016 9:55:28 PM')
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                'cmbBrgy.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    'cmbBrgy.Items.Add(.Rows(rowcounter).Item("barangayname").ToString())
                Next
                'cmbBrgy.SelectedIndex = 0
                dgrOrderList.DataSource = dsDataset.Tables(0)
                dgrOrderList.AutoResizeColumns()
            Else
                dgrOrderList.Rows.Clear()
                dgrOrderList.Columns.Clear()
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub


    Private Sub btnDisplaySales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplaySales.Click
        DataGridView1.Columns.Clear()
        'DataGridView1.Rows.Clear()
        Call load_TotalSales()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        With DataGridView1
            load_SalesDetails(.Item(0, .CurrentCellAddress.Y).Value)
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnPreviewSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewSales.Click
        Calling_Form = "Sales Monitoring"
        END_DATE_TIME = dtpEndDateTime.Value
        START_DATE_TIME = dtpStartDateTime.Value
        CLERK_IN_QUESTION = cmbClerk.Text
        CallingControl = IIf(rbtnDaily.Checked, "Daily Sales Monitoring", IIf(rbtnWeekly.Checked, "Weekly Sales Monitoring", IIf(rbtnMonthly.Checked, "Monthly Sales Monitoring", IIf(rbtnAnnual.Checked, "Annual Sales Monitoring", ""))))
        ReportFileName = "rptSales.rpt"
        If cmbClerk.Text = "- - A L L - -" Then
            strReportSQL = "SELECT     trnno, ORNumber, Description, UnitName, UnitPrice, Quantity, Amount, DiscountValue, TransactionTime, TransactionDate, TotalAmount, EmployeesID, " _
                & " ProductID_Barcode,FinalSalesDiscount,netsales FROM vwSalesMonitoring WHERE  (TransactionDate >= '" & dtpStartDateTime.Value & "') AND (TransactionDate <= '" & dtpEndDateTime.Value & "') order by TransactionDate,ORNumber"
        Else
            strReportSQL = "SELECT     trnno, ORNumber, Description, UnitName, UnitPrice, Quantity, Amount, DiscountValue, TransactionTime, TransactionDate, TotalAmount, EmployeesID, " _
                & " ProductID_Barcode,FinalSalesDiscount,netsales FROM vwSalesMonitoring WHERE  EmployeesID = " & userID & " AND (TransactionDate >= '" & dtpStartDateTime.Value & "') AND (TransactionDate <= '" & dtpEndDateTime.Value & "') order by TransactionDate,ORNumber"

        End If
        Dim frmPrntng As New frmReport

        frmPrntng.WindowState = FormWindowState.Maximized
        frmPrntng.Show()
    End Sub
End Class