Imports System.Data.SqlClient

Public Class frmReceivedStockMonitoring

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

    Dim SupplierID As Long

    Private Sub frmReceivedStockMonitoring_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.PictureBox1.Visible = True
    End Sub

    Private Sub frmReceivedStockMonitoring_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Load_DR_Listing()
        Call LoadSuppliersToCombo()
        dtpStartDateTime.Value = Now
    End Sub

    Private Sub Load_DR_Listing()
        Dim rowcounter As Integer
        If chkAll.Checked = False And chkPerSupplier.Checked = True Then
            sqladapter = New SqlClient.SqlDataAdapter("SELECT  TransactionDate, DR_RefNo, DR_TotalAmount FROM tblProductReceivedSummary WHERE   TransactionDate = '" & dtpStartDateTime.Text & "'  AND SupplierID = " & SupplierID & " ORDER BY TransactionDate DESC, trnno DESC", conn)
        ElseIf chkAll.Checked = False Then
            sqladapter = New SqlClient.SqlDataAdapter("SELECT  TransactionDate, DR_RefNo, DR_TotalAmount FROM tblProductReceivedSummary WHERE     TransactionDate = '" & dtpStartDateTime.Text & "' ORDER BY TransactionDate DESC, trnno DESC", conn)
        ElseIf chkPerSupplier.Checked = True Then
            sqladapter = New SqlClient.SqlDataAdapter("SELECT  TransactionDate, DR_RefNo, DR_TotalAmount FROM tblProductReceivedSummary where SupplierID = " & SupplierID & "  ORDER BY TransactionDate DESC, trnno DESC", conn)
        Else
            sqladapter = New SqlClient.SqlDataAdapter("SELECT  TransactionDate, DR_RefNo, DR_TotalAmount FROM tblProductReceivedSummary  ORDER BY TransactionDate DESC, trnno DESC", conn)
        End If
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                ListView1.Items.Clear()
                ' ListView1.Columns.Clear()

                'Add column header
                ''''ListView1.Columns.Add("DateTime", 130)
                ''''ListView1.Columns.Add("Status", 300)

                'Add items in the listview
                Dim arr(5) As String
                Dim itm As ListViewItem

                For rowcounter = 0 To .Rows.Count - 1

                    'Add first item
                    arr(0) = String.Format(.Rows(rowcounter).Item("TransactionDate").ToString(), "d")
                    arr(1) = (.Rows(rowcounter).Item("DR_RefNo").ToString())
                    arr(2) = (.Rows(rowcounter).Item("DR_TotalAmount").ToString())

                    itm = New ListViewItem(arr)
                    If getFIELD_VALUE_FROM_DBASE("tblProductReceiveDSummary", "TOP 1 DELIVERY_STATUS", "DR_RefNo", arr(1)) = "PARTIAL" Then
                        ListView1.Items.Add(itm).ForeColor = Color.Blue
                    ElseIf getFIELD_VALUE_FROM_DBASE("tblProductReceiveDSummary", "TOP 1 DELIVERY_STATUS", "DR_RefNo", arr(1)) = "COMPLETE" Then
                        ListView1.Items.Add(itm).ForeColor = Color.Black
                    End If
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

    Private Sub Load_Logs(ByVal userID As String)
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT     DateTimeLogged, ActionType       FROM tblUserLoginData         WHERE userID = '" & userID & "' ORDER BY trnno DESC", conn)
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

    Private Sub cmbClerk_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Load_Logs(userID)
    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        If ListView1.Items.Count > 0 Then
            On Error Resume Next
            Dim suppid As String = ListView1.SelectedItems.Item(0).SubItems(1).Text
            suppid = StrReverse(suppid)
            suppid = Replace(StrReverse(Mid(suppid, InStr(suppid, "-", CompareMethod.Binary))), "-", "")
            cmbSupplier.Text = getFIELD_VALUE_FROM_DBASE("tblSupplier", "SupplierName", "SupplierID", suppid)
            Call load_DR_Details(ListView1.SelectedItems.Item(0).SubItems(1).Text)
        End If
    End Sub

    Private Sub load_TotalSales()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT     ORNumber, TotalAmount, SalesDiscount, NetSales, NoOfItems, Payment, Change, TransactionDate, VATSales " _
                                                & " FROM tblSalesTransactionTotal WHERE     EmployeesID = " & userID & " AND (TransactionDate >= '" & dtpStartDateTime.Value & "')  order by TransactionDate,ORNumber", conn)
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
            Else

            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub


    Private Sub btnDisplaySales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplaySales.Click
        'DataGridView1.Rows.Clear()
        Load_DR_Listing()

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        With DataGridView1
            load_SalesDetails(.Item(0, .CurrentCellAddress.Y).Value)
        End With
    End Sub

    Private Sub LoadSuppliersToCombo()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("Select SupplierID,SupplierName from tblSupplier order by SupplierName", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                cmbSupplier.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    cmbSupplier.Items.Add(New ComboListData(.Rows(rowcounter).Item("SupplierName").ToString(), .Rows(rowcounter).Item("SupplierID").ToString()))
                Next
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub getSupplierIDFromComboBOx()
        Try
            For Each item As ComboListData In cmbSupplier.Items
                If item.Name.ToString = cmbSupplier.SelectedItem.ToString Then
                    SupplierID = item.ItemData.ToString
                    GoTo exit_loop2
                End If
            Next
        Catch
        End Try
exit_loop2:
    End Sub

    Private Sub btnPreviewSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewSales.Click
        Try
            Dim poNO As String = ListView1.SelectedItems.Item(0).SubItems(1).Text
            SUPPLIER_NAME_PRINTING = cmbSupplier.Text
            Calling_Form = "Sales Monitoring"
            ReportFileName = "rptReceivingReport.rpt"
            strReportSQL = "SELECT     ProductID_Barcode as Barcode, (SELECT     TOP 1 ProductDescription    FROM tblProduct  " _
                                                & " WHERE      (ProductID_Barcode = tblProductReceive.ProductID_Barcode)) AS Description, " _
                                                & " (SELECT     TOP 1 QtyOrdered FROM tblPO_Details " _
                                                & "   WHERE      (ProductID_Barcode = tblProductReceive.ProductID_Barcode) AND (PO_Number = tblProductReceive.PO_Number)) AS Ordered, " _
                                                & "  (SELECT     TOP (1) UnitName " _
                                                & "    FROM          tblProduct AS tblProduct_1 " _
                                                & "    WHERE      (ProductID_Barcode = tblProductReceive.ProductID_Barcode)) AS Unit, QtyReceived, " _
                                                & " PurchaseCost, DELIVERY_STATUS, " _
                                                & "  Remarks, PO_Number, DR_RefNo, Batch_Number, TransactionDate FROM         tblProductReceive " _
                                                & " WHERE     (dbo.tblProductReceive.DR_RefNo = '" & poNO & "')"
            Dim frmPrntng As New frmReport

            frmPrntng.WindowState = FormWindowState.Maximized
            frmPrntng.Show()
        Catch
            MsgBox(Err.Description, , "btnPreviewSales_Click")
        End Try

    End Sub

    Private Sub cmbSupplier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSupplier.SelectedIndexChanged
        getSupplierIDFromComboBOx()
    End Sub

    Private Sub load_DR_Details(ByVal drnum As String)
        Dim Barcode As String, ProductDesciption As String, UnitName As String, QTYordered As Double, PO_NUM As String, Del_Status As String, qtyReceived As String, unitprice As Double, remarks As String

        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT     ProductID_Barcode as Barcode, (SELECT     TOP 1 ProductDescription    FROM tblProduct  " _
                                            & " WHERE      (ProductID_Barcode = tblProductReceive.ProductID_Barcode)) AS Description, " _
                                            & " (SELECT     TOP 1 QtyOrdered FROM tblPO_Details " _
                                            & "   WHERE      (ProductID_Barcode = tblProductReceive.ProductID_Barcode) AND (PO_Number = tblProductReceive.PO_Number)) AS Ordered, " _
                                            & "  (SELECT     TOP (1) UnitName " _
                                            & "    FROM          tblProduct AS tblProduct_1 " _
                                            & "    WHERE      (ProductID_Barcode = tblProductReceive.ProductID_Barcode)) AS Unit, QtyReceived, " _
                                            & " PurchaseCost, DELIVERY_STATUS, " _
                                            & "  Remarks, PO_Number, DR_RefNo FROM         tblProductReceive " _
                                            & " WHERE     (dbo.tblProductReceive.DR_RefNo = '" & drnum & "')", conn)


        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                DataGridView1.Rows.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    'cmbBrgy.Items.Add(.Rows(rowcounter).Item("barangayname").ToString())

                    Barcode = .Rows(rowcounter).Item("Barcode").ToString()
                    ProductDesciption = .Rows(rowcounter).Item("Description").ToString()
                    QTYordered = IIf(.Rows(rowcounter).Item("Ordered").ToString() = "", 0, .Rows(rowcounter).Item("Ordered").ToString())
                    UnitName = .Rows(rowcounter).Item("Unit").ToString()
                    PO_NUM = .Rows(rowcounter).Item("PO_Number").ToString()
                    unitprice = IIf(.Rows(rowcounter).Item("PurchaseCost").ToString() = "", 0, .Rows(rowcounter).Item("PurchaseCost").ToString())
                    qtyReceived = .Rows(rowcounter).Item("QtyReceived").ToString()
                    Del_Status = .Rows(rowcounter).Item("DELIVERY_STATUS").ToString()
                    remarks = .Rows(rowcounter).Item("Remarks").ToString()

                    Dim row As String() = New String() {Barcode, ProductDesciption, QTYordered, UnitName, qtyReceived, unitprice, Del_Status, remarks, PO_NUM} 'FormatCurrency(unitprice, 2)
                    DataGridView1.Rows.Add(row)

                Next
            Else
                DataGridView1.Rows.Clear()
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        If ListView1.Items.Count > 0 Then
            Call load_DR_Details(ListView1.SelectedItems.Item(0).SubItems(1).Text)
        End If
    End Sub

    Private Sub chkPerSupplier_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPerSupplier.CheckedChanged
        If chkPerSupplier.Checked Then
            cmbSupplier.Enabled = True
        Else
            cmbSupplier.Enabled = False
        End If
    End Sub
End Class