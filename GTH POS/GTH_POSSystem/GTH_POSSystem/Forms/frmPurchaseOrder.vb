
Imports System.Data.SqlClient

Public Class frmPurchaseOrder

#Region "CommonFunctions"
    Private conn As New SqlClient.SqlConnection("Data Source=server_jbg; Initial Catalog=POS;Integrated Security=True;")
    Private ComDset As New DataSet
    Private ComDset1 As New DataSet
    Private LeaderID As Long
    Private MemberID As Long
    Private rMoveVal As Boolean = False

    Dim CurrentRowIndex As Integer = 0
#End Region

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

    Private Sub LoadSupplierListing()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT  top 1   SupplierID AS ID, SupplierName, ContactName, ContactTitle, SupplierAddress AS Address, TelNo, FaxNo, Email, CreditTerms,PrintOnCheckAs,BankAccount FROM         tblSupplier WHERE SupplierName like '" & Replace(cmbSupplier.Text, "'", "''") & "%' order by SupplierName", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                'cmbBrgy.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    'cmbBrgy.Items.Add(.Rows(rowcounter).Item("barangayname").ToString())
                    txtAddress.Text = .Rows(rowcounter).Item("Address").ToString()
                    txtSuppID.Text = .Rows(rowcounter).Item("ID").ToString()
                Next
                'DataGridView1.DataSource = dsDataset.Tables(0)
                'DataGridView1.AutoResizeColumns()

            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub change_bkGround(ByVal xxx As Color)
        Dim bgChanger As Control
        For Each bgChanger In Me.Controls
            If TypeOf bgChanger Is TextBox Then
                bgChanger.BackColor = xxx
            ElseIf TypeOf bgChanger Is MaskedTextBox Then
                bgChanger.BackColor = xxx
            ElseIf TypeOf bgChanger Is DateTimePicker Then
                bgChanger.BackColor = xxx
            ElseIf TypeOf bgChanger Is ComboBox Then
                bgChanger.BackColor = xxx
            End If
        Next
        txtSearch.BackColor = Color.White
    End Sub

    Private Sub clearControls()
        Dim cleaner As Control
        For Each cleaner In Me.Controls
            If TypeOf cleaner Is TextBox Then
                cleaner.Text = ""
            ElseIf TypeOf cleaner Is MaskedTextBox Then
                cleaner.Text = ""
            ElseIf TypeOf cleaner Is ComboBox Then
                cleaner.Text = ""
            ElseIf TypeOf cleaner Is DataGridView Then
                DataGridView1.Rows.Clear()
            End If
        Next
    End Sub

    Private Sub change_ReadOnly(ByVal xReadOnly As Boolean)
      
        txtAddress.ReadOnly = xReadOnly
        txtSuppID.ReadOnly = xReadOnly
       
    End Sub

    Private Sub frmPurchaseOrder_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.PurchaseOrderToolStripMenuItem.Enabled = True
        frmMain.PictureBox1.Visible = True
        frmMain.TStripPO.Enabled = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If btnClose.Text = "&Cancel" Then
            btnNew.Enabled = True
            btnClose.Text = "&Close"
            btnSave.Text = "&Save"
            btnNew.Text = "&New"
            Call change_bkGround(Color.BurlyWood)
            Call clearControls()
            'set all entry controls to read only mode
            Call change_ReadOnly(True)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call LoadSuppliersToCombo()
        If btnNew.Text = "&New" Then
            Call change_bkGround(Color.White)
            Call clearControls()
            btnClose.Text = "&Cancel"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnSave.Text = "&Save"
            btnSave.Enabled = True
            'assign preferred P.O number
            txtPONO.Text = "P.O-" & Date.Now.Year & "" & Date.Now.Month & "" & Date.Now.Day & "-" & CStr(getFieldMaxCount("tblPO", "trnno") + 1).PadLeft(4, "0")

            'get company address
            txtShipTo.Text = getFIELD_VALUE_FROM_DBASE("tblCompanyProfile", "StreetAddress+ ', ' + City + ',' + State + ',' + Country + ',' + Zip as ADDRESS", "trnno", "1")
            cmbSupplier.Focus()
        Else
            Call change_bkGround(Color.White)
            btnClose.Text = "&Cancel"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnSave.Text = "&Update"
            btnSave.Enabled = True
            cmbSupplier.Focus()
        End If
        Call change_ReadOnly(True)
    End Sub

    Private Sub cmbSupplier_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbSupplier.KeyDown
        Call LoadSupplierListing()
        If e.KeyCode = Keys.Enter Then
            txtSearch.Focus()
        End If
    End Sub

    Private Sub cmbSupplier_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSupplier.KeyPress


    End Sub

    Private Sub cmbSupplier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSupplier.SelectedIndexChanged

    End Sub

    Private Sub txtSearch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.GotFocus
        ListView1.Visible = True
        ListView1.Top = txtSearch.Top + txtSearch.Height
        ListView1.Left = txtSearch.Left
        ListView1.Width = 800
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Escape Then
            ListView1.Visible = False
            btnSave.Focus()
        End If
    End Sub

  

    Private Sub txtSearch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.LostFocus

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Call LoadProductListing_byBarcode(txtSearch.Text)
    End Sub

    Private Sub LoadPOsToListView()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT trnno, PO_Date, PO_Number, PO_DELIVERY_STATUS  FROM tblPO ORDER BY trnno DESC", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                lsvPOList.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1

                    Dim arr(2) As String
                    Dim itm As ListViewItem

                    'Add first item
                    arr(0) = (.Rows(rowcounter).Item("PO_Date").ToString())
                    arr(1) = (.Rows(rowcounter).Item("PO_Number").ToString())
                    arr(2) = (.Rows(rowcounter).Item("PO_DELIVERY_STATUS").ToString())

                    itm = New ListViewItem(arr)
                    'If getFIELD_VALUE_FROM_DBASE("tblProductReceive", "TOP 1 DR_RefNo", "PO_Number", arr(1)) = "" Then
                    ' lsvPOList.Items.Add(itm).ForeColor = Color.Red
                    ' Else
                    ' lsvPOList.Items.Add(itm).ForeColor = Color.Black
                    'End If

                    'UPDATE COLOR
                    If arr(2) = "NOT YET DELIVERED" Then
                        lsvPOList.Items.Add(itm).ForeColor = Color.Red
                    ElseIf arr(2) = "PARTIAL" Then
                        lsvPOList.Items.Add(itm).ForeColor = Color.Blue
                    ElseIf arr(2) = "COMPLETE" Then
                        lsvPOList.Items.Add(itm).ForeColor = Color.Black
                    End If
                Next
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub LoadProductListing_byBarcode(ByVal bcode As String)
        Dim rowcounter As Integer
        
        sqladapter = New SqlClient.SqlDataAdapter("Select ProductID_Barcode,ProductDesciption,UnitSize, QTYOnHand,UnitName, Price, PurchaseCost,  DateEntered, SetDefault,ProductDiscount,reorderpoint,supplierID,CategoryName,trnno " _
                                             & " FROM         (SELECT     trnno, ProductID_Barcode, Price, PurchaseCost, DateEntered, SetDefault, " _
                                             & " (SELECT     TOP (1) ProductDescription        FROM tblProduct " _
                                             & " WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS ProductDesciption," _
                                              & " (SELECT     TOP (1) UnitSize        FROM tblProduct " _
                                             & " WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS UnitSize," _
                                             & "  (SELECT     TOP (1) QtyOnHand      FROM          tblProduct AS Product_1 " _
                                             & "   WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS QTYOnHand, " _
                                             & "  (SELECT     TOP (1) reorderpoint      FROM          tblProduct AS Product_1 " _
                                             & "   WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS reorderpoint, " _
                                             & "  (SELECT     TOP (1) supplierID      FROM          tblProduct AS Product_1 " _
                                             & "   WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS supplierID, " _
                                             & " (SELECT     TOP (1) ProductDiscount     FROM          tblProduct AS Product_1 " _
                                             & "   WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS ProductDiscount, " _
                                             & " (SELECT     TOP (1) UnitName     FROM          tblProduct AS Product_1 " _
                                             & "   WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS UnitName, " _
                                             & " (SELECT     TOP (1) CategoryName     FROM          tblProduct AS Product_1 " _
                                             & "   WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS CategoryName " _
                                             & " FROM          tblPriceHistory) AS derivedtbl_1 " _
                                             & " WHERE     (ProductDesciption LIKE '%" & bcode & "%') or (ProductID_Barcode LIKE '%" & bcode & "%') AND SetDefault=1 order by ProductDesciption,trnno desc", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
           

            If .Rows.Count > 0 Then
                ListView1.Items.Clear()
                ListView1.Columns.Clear()

                'Add column header
                ListView1.Columns.Add("Barcode", 120)
                ListView1.Columns.Add("Product Desciption", 300)
                ListView1.Columns.Add("Size", 75)
                ListView1.Columns.Add("Unit Name", 75)
                ListView1.Columns.Add("Purchase Cost", 100)
                ListView1.Columns.Add("On Hand", 100)


                'Add items in the listview
                Dim arr(5) As String
                Dim itm As ListViewItem

                For rowcounter = 0 To .Rows.Count - 1

                    'Add first item
                    arr(0) = (.Rows(rowcounter).Item("ProductID_Barcode").ToString())
                    arr(1) = (.Rows(rowcounter).Item("ProductDesciption").ToString())
                    arr(2) = (.Rows(rowcounter).Item("UnitSize").ToString())
                    arr(3) = (.Rows(rowcounter).Item("UnitName").ToString())
                    arr(4) = (.Rows(rowcounter).Item("PurchaseCost").ToString())
                    arr(5) = (.Rows(rowcounter).Item("QtyOnHand").ToString())

                    itm = New ListViewItem(arr)
                    ListView1.Items.Add(itm)
                Next
                'cmbBrgy.SelectedIndex = 0
                'DataGridView1.DataSource = dsDataset.Tables(0)
                'DataGridView1.AutoResizeColumns()

            Else
                'DataGridView1.Columns.Clear()
                If MsgBox("No Record Found!" & Chr(13) & Chr(13) & "Add this Item to database?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "No Record Found. . .") = MsgBoxResult.Yes Then
                    frmProductRegistration.ShowInTaskbar = True
                    frmProductRegistration.Show()
                Else
                    Exit Sub
                End If

            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub ListView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Escape Then
            ListView1.Visible = False
            btnSave.Focus()
        End If
    End Sub

    Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
       
        Dim Barcode, ProductDesciption, UnitSize, UnitName, PurchaseCost, OnHand As String

        Barcode = ListView1.SelectedItems.Item(0).SubItems(0).Text
        ProductDesciption = ListView1.SelectedItems.Item(0).SubItems(1).Text
        UnitSize = ListView1.SelectedItems.Item(0).SubItems(2).Text
        UnitName = ListView1.SelectedItems.Item(0).SubItems(3).Text
        PurchaseCost = ListView1.SelectedItems.Item(0).SubItems(4).Text
        On Error Resume Next

        Dim qty As Double = CDbl(InputBox("Input Quantity to Order for: " & ProductDesciption & ".", "Quantity to Order. . .", "0"))


        Dim Amount As Double = CDbl(PurchaseCost) * qty

        Dim row As String() = New String() {Barcode, ProductDesciption, UnitSize, UnitName, PurchaseCost, qty, Amount}

        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns(4).ReadOnly = True
        DataGridView1.Columns(5).ReadOnly = False
        DataGridView1.Columns(6).ReadOnly = True

        DataGridView1.Rows.Add(row)

        Call COMPUTE_SKU_TOTALAMOUNT()

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub frmPurchaseOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            ListView1.Visible = False
        End If
    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Dim s As Double = Convert.ToDouble(DataGridView1.CurrentRow.Cells(4).Value)
        Dim s1 As Double = Convert.ToDouble(DataGridView1.CurrentRow.Cells(5).Value)
        Dim s13 = s1 * s
        DataGridView1.CurrentRow.Cells(6).Value = s13
        Call COMPUTE_SKU_TOTALAMOUNT()
    End Sub

    Private Sub COMPUTE_SKU_TOTALAMOUNT()
        Dim xRowCount As Integer = 0
        Dim TotalAmount As Double = 0
        Dim sku As Integer = 0
        For xRowCount = 0 To DataGridView1.RowCount - 1
            Dim s As Double = 0 'Convert.ToDouble(DataGridView1.CurrentRow.Cells(6).Value)
            s = Convert.ToDouble(DataGridView1.Rows(xRowCount).Cells(6).Value)
            TotalAmount = TotalAmount + s
            sku = sku + 1
        Next
        txtSKU.Text = sku
        txtTotalAmount.Text = TotalAmount
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If btnSave.Text = "&Update" Then
                'Dim strVALUES As String = "productDescription='" & Replace(Replace(txtProductDescription.Text, "'", "''"), """", """") & "',UnitName='" & Replace(cmbUnitType.Text, "'", "''") & "',CategoryName='" & Replace(cmbCategory.Text, "'", "''") & "',UnitPriceCode=" & unitPriceCode & ",ProductDiscount=" & item_discount & ",QtyOnHand=" & txtQTYOnHand.Text & ",reorderpoint=" & txtReorderPoint.Text & ",SupplierID=" & SupplierID & ""
                ' Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("tblPRODUCT", strVALUES, "ProductID_Barcode='" & txtProductBarcode.Text & "'")
            Else
                'INSERT INFO TO tblPO
                Dim strVALUES As String = "'" & txtSuppID.Text & "','" & DateTimePicker1.Value & "','" & Replace(txtShipTo.Text, "'", "''") & "','" & Replace(txtVendorMessage.Text, "'", "''") & "'," & txtTotalAmount.Text & ",'" & USER_NAME_LOGGED & "'," & txtSKU.Text & "," & IIf(txtDeclaredValue.Text = "", 0, txtDeclaredValue.Text) & ",'" & txtPONO.Text & "','NOT YET DELIVERED'"
                Call INSERT_DATA_TO_DATABASE("tblPO", "SupplierID,PO_Date,PO_ShipTo,PO_VendorMessage,PO_TotalAmount,PO_PreparedBy,PO_SKU,PO_DeclaredValue,PO_Number,PO_DELIVERY_STATUS", strVALUES)

                'INSERT PO DETAILS to tblPO_Details
                With DataGridView1
                    For xxyz = 0 To .Rows.Count - 1

                        Dim bcode As String = .Rows(xxyz).Cells(0).Value.ToString()
                        Dim qtyOrd As Long = .Rows(xxyz).Cells(5).Value.ToString()
                        Dim Amt As Double = .Rows(xxyz).Cells(6).Value.ToString()
                        Dim unitName As String = .Rows(xxyz).Cells(3).Value.ToString()
                        Dim PurchaseCost As Double = .Rows(xxyz).Cells(4).Value.ToString()

                        Dim strVALUES2 As String = "'" & txtPONO.Text & "','" & bcode & "'," & qtyOrd & "," & Amt & "," & PurchaseCost & ""
                        Call INSERT_DATA_TO_DATABASE("tblPO_Details", "PO_Number,ProductID_Barcode,QtyOrdered,Amount,PurchaseCost", strVALUES2)
                    Next
                End With
            End If
            'Call LoadProductListing(txtProductBarcode.Text)

            btnNew.Enabled = True
            btnSave.Text = "&Save"
            btnClose.Text = "&Close"
            btnSave.Enabled = False
            Call clearControls()
            Call change_bkGround(Color.BurlyWood)
            'set all entry controls to read only mode
            Call change_ReadOnly(True)
            Call LoadPOsToListView()
            ''''LoadProductListing_byBarcode(txtProductBarcode.Text)
        Catch
            MsgBox(Err.Description)
            Exit Sub
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub frmPurchaseOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call LoadPOsToListView()

    End Sub

    Private Sub lsvPOList_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvPOList.MouseDoubleClick
        PreviewPOToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub lsvPOList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvPOList.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Visible = True
        End If
    End Sub

    Private Sub PreviewPOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviewPOToolStripMenuItem.Click
        Dim poNO As String = lsvPOList.SelectedItems.Item(0).SubItems(1).Text
        Calling_Form = "Sales Monitoring"
        ReportFileName = "rptPO.rpt"
        strReportSQL = "Select * FROM         vwPO WHERE     PO_Number = '" & poNO & "'"
        Dim frmPrntng As New frmReport

        frmPrntng.WindowState = FormWindowState.Maximized
        frmPrntng.Show()
    End Sub

    Private Sub lsvPOList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsvPOList.SelectedIndexChanged

    End Sub
End Class