Public Class frmProductReceiving

#Region "CommonFunctions"
    Private conn As New SqlClient.SqlConnection("Data Source=server_jbg; Initial Catalog=POS;Integrated Security=True;")
    Private ComDset As New DataSet
    Private ComDset1 As New DataSet
    Private LeaderID As Long
    Private MemberID As Long
    Private rMoveVal As Boolean = False
    Dim Batch_Number As Long

    Dim CurrentRowIndex As Integer = 0
#End Region

    Dim SupplierID As Long
    Dim unitPriceCode As Long
    Dim New_Entry_Flag As Boolean = False

    Public Sub changebground(ByVal xxxx As Color, Optional ByVal ctlcol As Control.ControlCollection = Nothing)
        If ctlcol Is Nothing Then ctlcol = Me.Controls
        For Each ctl As Control In ctlcol
            If TypeOf (ctl) Is ComboBox Then
                DirectCast(ctl, ComboBox).BackColor = xxxx
            End If
        Next
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
            End If
        Next
        If DataGridView2.Rows.Count >= 2 Then DataGridView2.Rows.Clear()
        cmbPurchaseCost.SelectedIndex = -1
        'cmbSupplier.SelectedIndex = -1
        cmbUnitPrice.SelectedIndex = -1
        cmbUnitType.SelectedIndex = -1
    End Sub

    Private Sub change_ReadOnly(ByVal xReadOnly As Boolean)
        txtProductDescription.ReadOnly = xReadOnly
        txtQTYOnHand.ReadOnly = xReadOnly
        ' txtUnitPrice.ReadOnly = xReadOnly
        'cmbPurchaseCost.re = xReadOnly
    End Sub


    Private Sub LoadProductListing_byBarcode(ByVal bcode As String)
        Dim rowcounter As Integer
        If rbtnSearchByBarcode.Checked Then
            sqladapter = New SqlClient.SqlDataAdapter("Select ProductID_Barcode,ProductDesciption, QTYOnHand,UnitName, Price, PurchaseCost,  DateEntered, SetDefault,ProductDiscount,reorderpoint,supplierID,CategoryName,trnno " _
                                                 & " FROM         (SELECT     trnno, ProductID_Barcode, Price, PurchaseCost, DateEntered, SetDefault, " _
                                                 & " (SELECT     TOP (1) ProductDescription        FROM tblProduct " _
                                                 & " WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS ProductDesciption," _
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
                                                 & " WHERE     ((ProductID_Barcode LIKE '" & bcode & "%')  OR (ProductDesciption LIKE '%" & bcode & "%')) AND SETDefault=1 order by ProductDesciption,trnno desc", conn)
        Else
            sqladapter = New SqlClient.SqlDataAdapter("Select ProductID_Barcode,ProductDesciption, QTYOnHand,UnitName, Price, PurchaseCost,  DateEntered, SetDefault,ProductDiscount,reorderpoint,supplierID,CategoryName,trnno " _
                                                 & " FROM         (SELECT     trnno, ProductID_Barcode, Price, PurchaseCost, DateEntered, SetDefault, " _
                                                 & " (SELECT     TOP (1) ProductDescription        FROM tblProduct " _
                                                 & " WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS ProductDesciption," _
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
                                                 & " WHERE      ((ProductID_Barcode LIKE '" & bcode & "%')  OR (ProductDesciption LIKE '%" & bcode & "%')) AND SetDefault=1 order by ProductDesciption,trnno desc", conn)
        End If
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                'load the details to input controls

                grpProductListing.Visible = True
                DataGridView1.DataSource = dsDataset.Tables(0)
                DataGridView1.AutoResizeColumns()
            Else
                DataGridView1.Columns.Clear()
                If MsgBox("No Record Found!" & Chr(13) & Chr(13) & "Add this Item to database?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "No Record Found. . .") = MsgBoxResult.Yes Then
                    MsgBox("ADDING ITEM IS NOT ALLOWED IN THIS MODULE. ", MsgBoxStyle.Information, "")
                Else
                    'Call clearControls()
                    'btnNew.Enabled = True
                    'btnClose.Text = "&Close"
                    'btnSave.Text = "&Save"
                    'btnNew.Text = "&New"
                    'Call change_bkGround(Color.BurlyWood)
                    'Call clearControls()
                    ''''set all entry controls to read only mode
                    'Call change_ReadOnly(True)
                    txtProductBarcode.Focus()
                End If

            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub LoadUnitPriceToCombo(ByVal productBarcode As String)
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("Select trnno,ProductID_Barcode,Price,PurchaseCost from tblPriceHistory where ProductID_Barcode like '" & productBarcode & "%' and SETDEFAULT=1 order by trnno desc", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                cmbUnitPrice.Items.Clear()
                cmbPurchaseCost.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    cmbUnitPrice.Items.Add(New ComboListData(.Rows(rowcounter).Item("Price").ToString(), .Rows(rowcounter).Item("trnno").ToString()))
                    cmbPurchaseCost.Items.Add(New ComboListData(.Rows(rowcounter).Item("PurchaseCost").ToString(), .Rows(rowcounter).Item("trnno").ToString()))
                    'cmbUnitPrice.Items.Add(.Rows(rowcounter).Item("Price").ToString())
                    'cmbPurchaseCost.Items.Add(.Rows(rowcounter).Item("PurchaseCost").ToString())
                    '.Add(New ComboListData(.Rows(rowcounter).Item("SupplierName").ToString(), .Rows(rowcounter).Item("SupplierID").ToString()))
                Next
                'cmbUnitPrice.SelectedIndex = 0
            Else
                If Len(txtProductBarcode.Text) > 0 Then
                    btnNewUnitPrice.Focus()
                    MsgBox("This product doesn't have PRICE on record, please ADD price to database to proceed. Thank you!", MsgBoxStyle.Information, "No Record Found. . .")

                End If
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub getUnitPriceIDFromComboBOx()
        Try
            For Each item As ComboListData In cmbUnitPrice.Items
                If item.Name.ToString = cmbUnitPrice.SelectedItem.ToString Then
                    unitPriceCode = item.ItemData.ToString
                    GoTo exit_loop2
                End If
            Next
        Catch
            MsgBox(Err.Description)
        End Try
exit_loop2:
    End Sub

    Private Sub LoadPOToCombo(ByVal suppid As Long)
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT trnno,PO_Number  FROM tblPO     WHERE SupplierID = '" & suppid & "' ORDER BY trnno DESC", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                cmbPO.Items.Clear()
                cmbPO.Text = ""
                For rowcounter = 0 To .Rows.Count - 1
                    cmbPO.Items.Add(New ComboListData(.Rows(rowcounter).Item("PO_Number").ToString().PadLeft(6, "0"), .Rows(rowcounter).Item("trnno").ToString()))
                Next
                cmbPO.SelectedIndex = 0
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
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

    Private Sub LoadUnitTypeToCombo()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("Select UnitCode,UnitName from tblUnitType order by UnitName", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                cmbUnitType.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    cmbUnitType.Items.Add(.Rows(rowcounter).Item("UnitName").ToString())
                Next
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub load_PO_details(ByVal PONUM As String)
        Dim Barcode As String, ProductDesciption As String, UnitName As String, QTYordered As Double, PO_NUM As String, Disc As Double, Transtime As String, unitprice As Double

        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT     ProductID_Barcode as Barcode, Description, QtyOrdered as Ordered, UNIT as Unit,PO_Number,PurchaseCost " _
                                        & " FROM vwPO  WHERE      PO_Number  = '" & cmbPO.Text & "'", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        DataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView2.EditMode = DataGridViewEditMode.EditOnF2
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                DataGridView2.Rows.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    'cmbBrgy.Items.Add(.Rows(rowcounter).Item("barangayname").ToString())

                    Barcode = .Rows(rowcounter).Item("Barcode").ToString()
                    ProductDesciption = .Rows(rowcounter).Item("Description").ToString()
                    QTYordered = .Rows(rowcounter).Item("Ordered").ToString()
                    UnitName = .Rows(rowcounter).Item("Unit").ToString()
                    PO_NUM = .Rows(rowcounter).Item("PO_Number").ToString()
                    unitprice = IIf(.Rows(rowcounter).Item("PurchaseCost").ToString() = "", 0, .Rows(rowcounter).Item("PurchaseCost").ToString())

                    Dim row As String() = New String() {Barcode, ProductDesciption, QTYordered, UnitName, "", unitprice, "", "", PO_NUM} 'FormatCurrency(unitprice, 2)
                    DataGridView2.Rows.Add(row)

                Next
            Else
                DataGridView2.Rows.Clear()
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub


    Private Sub load_ProductReceived()

        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT     ProductID_Barcode,  (SELECT     TOP 1 ProductDescription     FROM tblProduct " _
                                        & "    WHERE      (ProductID_Barcode = tblProductReceive.ProductID_Barcode)) AS ProductDesciption, QtyReceived, " _
                                        & " (SELECT     TOP 1 UnitName            FROM          tblProduct AS Product_1 " _
                                        & " WHERE      (ProductID_Barcode = tblProductReceive.ProductID_Barcode)) AS UnitName, TransactionDate, TimeReceived, EmployeesID, SupplierID,bATCH_NUMBER " _
                                        & " FROM tblProductReceive where TransactionDate = '" & DateTimePicker2.Text & "' ORDER BY TransactionDate, TimeReceived DESC, trnno DESC,batch_number desc", conn)
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
                DataGridView2.DataSource = dsDataset.Tables(0)
                DataGridView2.AutoResizeColumns()

            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub LoadProductListing(ByVal strBarcodes As String)
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("Select ProductID_Barcode,ProductDesciption, QTYOnHand,UnitName, Price, PurchaseCost,  DateEntered, SetDefault,ProductDiscount,reorderpoint,supplierID,CategoryName,trnno" _
                                                 & " FROM         (SELECT     trnno, ProductID_Barcode, Price, PurchaseCost, DateEntered, SetDefault, " _
                                                 & " (SELECT     TOP (1) ProductDescription        FROM tblProduct " _
                                                 & " WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS ProductDesciption," _
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
                                                 & " WHERE     (ProductDesciption LIKE '%" & strBarcodes & "%') and setdefault = 1 order by ProductDesciption,trnno desc", conn)
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

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If btnNew.Text = "&New" Then
            Call change_bkGround(Color.White)
            Call clearControls()
            'get the new batch number for this batch of products received

            btnClose.Text = "&Cancel"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnSave.Text = "&Save"

            DATA_WAS_SAVED = False

            cmbSupplier.Focus()

            New_Entry_Flag = True
        Else
            Call change_bkGround(Color.White)
            btnClose.Text = "&Cancel"
            btnNew.Enabled = False
            btnSave.Text = "&Update"
            btnSave.Enabled = True
            txtProductDescription.Focus()
        End If
        Call change_ReadOnly(False)
        chkEnableAddDeliveryToDR_MouseClick(sender, e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim complete_del As String = "COMPLETE"
        Dim TotalAmount As Double
        Dim purchasecost As Double
        Dim xxyzz As String
        Dim qtyReceived As Long
        Dim DrRefNo As String = txtSuppCode.Text & "-" & txtDRNumber.Text
        Dim poNum As String = ""

        'VALIDATE ENTRIES BEFORE SAVING TO DATABASE
        If Len(txtDRNumber.Text) <= 0 Then
            MsgBox("INVALID ENTRY, PLEASE PROVIDE DELIVERY REFERENCE NUMBER (D.R #), THANK YOU", MsgBoxStyle.Critical, "SAVING ERROR. . .")
            txtDRNumber.Focus()
            Exit Sub
        ElseIf Len(cmbSupplier.Text) <= 0 Then
            MsgBox("INVALID ENTRY, PLEASE SELECT SUPPLIER FROM SUPPLIER LIST. THANK YOU", MsgBoxStyle.Critical, "SAVING ERROR. . .")
            cmbSupplier.Focus()
            Exit Sub
        End If

        Call getSupplierIDFromComboBOx()

        If btnSave.Text = "&Update" Then
            'update tblProduct UnitPriceCode,QtyOnHand,QTYInn,SupplierID
            Dim newQtyOnHand As Double = (getFIELD_VALUE_FROM_DBASE("tblProduct", "QtyOnHand", "ProductID_Barcode", txtProductBarcode.Text) - getFIELD_VALUE_FROM_DBASE("tblProduct", "QtyInn", "ProductID_Barcode", txtProductBarcode.Text)) + txtqtyReceived.Text
            Dim strVALUES As String = "UnitPriceCode=" & unitPriceCode & ",QtyOnHand=" & newQtyOnHand & ",QtyInn=" & Val(txtqtyReceived.Text) & ",SupplierID=" & SupplierID & ""
            Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("tblPRODUCT", strVALUES, "ProductID_Barcode='" & txtProductBarcode.Text & "'")
            '
            'Call update data of tblProductReceived
            Dim strVALUES2 As String = "'" & Replace(txtProductBarcode.Text, "'", "''") & "'," & unitPriceCode & "," & txtQTYOnHand.Text & "," & SupplierID & ""
            strVALUES2 = "TransactionDate='" & DateTimePicker1.Text & "',QTYReceived = " & txtqtyReceived.Text & ",EmployeesID='" & USER_ID_LOGGED & "', SupplierID = " & SupplierID & ",TimeReceived = '" & TimeOfDay & "'"
            Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("tblProductReceive", strVALUES2, "ProductID_Barcode='" & txtProductBarcode.Text & "'")

            Call load_ProductReceived()
            If MsgBox("Do you want to EDIT more entries for this Batch?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "ADD MORE ENTRIES?") = MsgBoxResult.Yes Then
                Call clearControls()
                Call change_bkGround(Color.White)
                grpProductListing.Visible = False
                DataGridView2.Focus()
            Else
                btnNew.Enabled = True
                btnSave.Text = "&Save"
                btnClose.Text = "&Close"
                btnNew.Text = "&New"
                btnSave.Enabled = False
                Batch_Number = 0
                Call clearControls()
                Call change_bkGround(Color.BurlyWood)
                'set all entry controls to read only mode
                Call change_ReadOnly(True)
                LoadProductListing_byBarcode(txtProductBarcode.Text)
            End If

        Else
            With DataGridView2
                Batch_Number = getFieldMaxValue("tblProductReceive", "Batch_Number") + 1
                'delete records containing the same information from tblProductReceive
                Call DELETE_RECORD_IN_DATABASE_PARAMSTRING("tblProductReceive", "DR_RefNo", DrRefNo)
                For xDatagridRows As Integer = 0 To .Rows.Count - 2

                    'update tblProduct QtyOnHand,QTYInn,SupplierID
                    xxyzz = .Rows(xDatagridRows).Cells(0).Value
                    qtyReceived = IIf(.Rows(xDatagridRows).Cells(4).Value = "", 0, .Rows(xDatagridRows).Cells(4).Value)
                    Dim QTYONHAND As Long = getFIELD_VALUE_FROM_DBASE("tblProduct", "QtyOnHand", "ProductID_Barcode", xxyzz)
                    Dim newQtyOnHand As Long = QTYONHAND + qtyReceived
                    Dim strUpdateTblProduct_VALUES As String = " QtyOnHand=" & newQtyOnHand & ", QtyInn = " & qtyReceived & ", SupplierID = " & SupplierID
                    Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("tblPRODUCT", strUpdateTblProduct_VALUES, "ProductID_Barcode='" & xxyzz & "'")

                    Dim timeofdAY As String = Trim(Mid(CStr(Now), InStr(CStr(Now), " ", CompareMethod.Text)))
                    poNum = .Rows(xDatagridRows).Cells(8).Value
                    Dim strDelivery_status As String = .Rows(xDatagridRows).Cells(6).Value
                    If complete_del = "COMPLETE" Then
                        If strDelivery_status = "COMPLETE DELIVERY" Then
                            complete_del = "COMPLETE"
                        Else
                            complete_del = "PARTIAL"
                        End If
                    End If
                    Dim rems As String = .Rows(xDatagridRows).Cells(7).Value


                    TotalAmount = TotalAmount + (.Rows(xDatagridRows).Cells(5).Value * .Rows(xDatagridRows).Cells(4).Value)
                    purchasecost = .Rows(xDatagridRows).Cells(5).Value

                    'Insert to tblProductReceived Table 

                    Dim strVALUES As String = "'" & Replace(xxyzz, "'", "''") & "','" & DateTimePicker1.Text & "','" & qtyReceived & "'," & USER_ID_LOGGED & "," & SupplierID & ",'" & timeofdAY & "'," & Batch_Number & ",'" & poNum & "','" & strDelivery_status & "','" & DrRefNo & "','" & rems & "','" & purchasecost & "'"
                    Call INSERT_DATA_TO_DATABASE("tblProductReceive", "ProductID_Barcode,TransactionDate,QtyReceived,EmployeesID,SupplierID,TimeReceived,Batch_Number,PO_Number,Delivery_Status,DR_RefNo,Remarks,PurchaseCost", strVALUES)

                Next
                'delete records containing the same information from tblProductReceiveSummary
                Call DELETE_RECORD_IN_DATABASE_PARAMSTRING("tblProductReceivedSummary", "DR_RefNo", DrRefNo)

                'Insert to tblProductReceivedSummary Table
                Dim addtopayable As Boolean = 0
                If MsgBox("ADD THIS PURCHASE ORDER AMOUNT TO PAYABLE? [YES/NO]", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                    addtopayable = 1
                Else
                    addtopayable = 0
                End If
                Dim strVALUES2 As String = "'" & DrRefNo & "','" & DateTimePicker1.Text & "','" & SupplierID & "'," & Batch_Number & ",'" & TotalAmount & "','" & addtopayable & "','" & complete_del & "'"
                Call INSERT_DATA_TO_DATABASE("tblProductReceivedSummary", "DR_RefNo,TransactionDate,SupplierID,BatchNumber,DR_TotalAmount,AddedToAccountPayable,DELIVERY_STATUS", strVALUES2)

                'update PO_DELIVERY_STATUS in tblPO

                Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("tblPO", "PO_DELIVERY_STATUS='" & complete_del & "'", "PO_Number='" & poNum & "'")
            End With

            btnNew.Enabled = True
            btnClose.Text = "&Close"
            btnSave.Text = "&Save"
            btnNew.Text = "&New"
            DATA_WAS_EDITED = False
            DATA_WAS_SAVED = False
            Call change_bkGround(Color.BurlyWood)
            Call clearControls()
            'set all entry controls to read only mode
            Call change_ReadOnly(True)
        End If
        New_Entry_Flag = False
        '
        'LOAD PRODUCT RECEIVED AT THE FOLLOWING SORT"
        ' TransactionDate = '" & DateTimePicker2.Text & "' ORDER BY TransactionDate, TimeReceived DESC, trnno DESC,batch_number desc
        ''

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If btnClose.Text = "&Cancel" Then
            btnNew.Enabled = True
            btnClose.Text = "&Close"
            btnSave.Text = "&Save"
            btnNew.Text = "&New"
            DATA_WAS_EDITED = False
            DATA_WAS_SAVED = False
            Call change_bkGround(Color.BurlyWood)
            Call clearControls()
            'set all entry controls to read only mode
            Call change_ReadOnly(True)

            New_Entry_Flag = False
        Else
            Me.Close()
        End If
    End Sub


    Private Sub DataGridView2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellEndEdit

        Dim sOrdered As Double = Convert.ToDouble(DataGridView2.CurrentRow.Cells(2).Value)
        Dim sDelivered As Double = Convert.ToDouble(IIf(DataGridView2.CurrentRow.Cells(4).Value = "", "0", DataGridView2.CurrentRow.Cells(4).Value))
        Dim s13 = sOrdered - sDelivered
        DataGridView2.CurrentRow.Cells(6).Value = IIf(sOrdered = sDelivered, "COMPLETE DELIVERY", IIf(sOrdered < sDelivered, "OVER DELIVERY", IIf(sOrdered > sDelivered, "PARTIAL DELIVERY", "")))
        DataGridView2.CurrentRow.Cells(6).Value = IIf(sDelivered = 0, "NO DELIVERY", DataGridView2.CurrentRow.Cells(6).Value)
        DATA_WAS_EDITED = True
    End Sub

    Private Sub frmProductReceiving_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.TStripStocksReceiving.Enabled = True
    End Sub



    Private Sub frmProductRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LoadProductListing_byBarcode(txtProductBarcode.Text)
        Call LoadUnitPriceToCombo(txtProductBarcode.Text)
        Call LoadUnitTypeToCombo()
        Call LoadSuppliersToCombo()
        'load product received
        ' Call load_ProductReceived()
        cmbReceivedBy.Text = USER_NAME_LOGGED

        With DataGridView2
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = False
            .Columns(5).ReadOnly = True
            .Columns(6).ReadOnly = False
            .Columns(7).ReadOnly = False
        End With
    End Sub

    Private Sub DataGridView1_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        '
        'note update txtProductBarcode_KeyDown if you will change this code
        '
        If DataGridView1.Rows.Count > 0 Then
            With DataGridView1
                Try
                    If Me.DataGridView1.SelectedRows.Count > 0 Then ' AndAlso Not Me.DataGridView1.SelectedRows(0).Index = Me.DataGridView1.Rows.Count - 1 Then

                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect

                        txtProductBarcode.Text = .Item(0, .CurrentCellAddress.Y).Value
                        txtProductDescription.Text = .Item(1, .CurrentCellAddress.Y).Value
                        txtQTYOnHand.Text = .Item(2, .CurrentCellAddress.Y).Value
                        Call LoadUnitPriceToCombo(txtProductBarcode.Text)
                        cmbUnitPrice.Text = .Item(4, .CurrentCellAddress.Y).Value
                        cmbPurchaseCost.Text = .Item(5, .CurrentCellAddress.Y).Value
                        cmbUnitType.Text = .Item(3, .CurrentCellAddress.Y).Value
                        'cmbSupplier.Text = getFIELD_VALUE_FROM_DBASE("tblSupplier", "SupplierName", "SupplierID", .Item(10, .CurrentCellAddress.Y).Value)
                        CurrentRowIndex = .CurrentRow.Index
                        .EditMode = DataGridViewEditMode.EditProgrammatically
                        btnSave.Text = "&Save"
                        btnClose.Text = "&Cancel"
                        'btnNew.Text = "&Edit"
                    Else
                        btnNew.Text = "&New"
                        .EndEdit()
                    End If
                Catch
                    MsgBox(Err.Description)
                    Exit Sub
                End Try
            End With
            'set all entry controls to read only mode
            Call change_ReadOnly(True)
        End If
    End Sub

    Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
            With DataGridView1
                Try
                    If Me.DataGridView1.SelectedRows.Count > 0 Then 'AndAlso Not Me.DataGridView1.SelectedRows(0).Index = Me.DataGridView1.Rows.Count - 1 Then

                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect

                        txtProductBarcode.Text = .Item(0, .CurrentCellAddress.Y).Value
                        txtProductDescription.Text = .Item(1, .CurrentCellAddress.Y).Value
                        txtQTYOnHand.Text = .Item(2, .CurrentCellAddress.Y).Value
                        Call LoadUnitPriceToCombo(txtProductBarcode.Text)
                        cmbUnitPrice.Text = .Item(4, .CurrentCellAddress.Y).Value
                        cmbPurchaseCost.Text = .Item(5, .CurrentCellAddress.Y).Value
                        cmbUnitType.Text = .Item(3, .CurrentCellAddress.Y).Value
                        'cmbSupplier.Text = getFIELD_VALUE_FROM_DBASE("tblSupplier", "SupplierName", "SupplierID", .Item(10, .CurrentCellAddress.Y).Value)
                        CurrentRowIndex = .CurrentRow.Index
                        .EditMode = DataGridViewEditMode.EditProgrammatically
                        btnSave.Text = "&Save"
                        btnClose.Text = "&Cancel"
                        'btnNew.Text = "&Edit"
                    Else
                        btnNew.Text = "&New"
                        .EndEdit()
                    End If
                Catch
                    MsgBox(Err.Description)
                End Try
            End With
            'set all entry controls to read only mode
            Call change_ReadOnly(True)
        ElseIf e.KeyCode = Keys.Enter Then
            If Me.DataGridView1.SelectedRows.Count > 0 AndAlso _
                       Not Me.DataGridView1.SelectedRows(0).Index = _
                       Me.DataGridView1.Rows.Count - 1 Then
                'btnNew_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call LoadProductListing(txtSearch.Text)
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(sender, e)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(sender, e)
        ElseIf e.KeyCode = Keys.Down Then
            DataGridView1.Focus()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Up And DataGridView1.SelectedRows(0).Index <= 0 Then
            txtSearch.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            With DataGridView1
                Try
                    If Me.DataGridView1.SelectedRows.Count > 0 Then ' AndAlso Not Me.DataGridView1.SelectedRows(0).Index = Me.DataGridView1.Rows.Count - 1 Then

                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect

                        txtProductBarcode.Text = .Item(0, .CurrentCellAddress.Y).Value
                        txtProductDescription.Text = .Item(1, .CurrentCellAddress.Y).Value
                        txtQTYOnHand.Text = .Item(2, .CurrentCellAddress.Y).Value
                        'txtContactTitle.Text = .Item(3, .CurrentCellAddress.Y).Value
                        cmbUnitPrice.Text = .Item(4, .CurrentCellAddress.Y).Value
                        'txtTelNo.Text = .Item(5, .CurrentCellAddress.Y).Value
                        cmbPurchaseCost.Text = .Item(5, .CurrentCellAddress.Y).Value
                        CurrentRowIndex = .CurrentRow.Index
                        .EditMode = DataGridViewEditMode.EditProgrammatically
                        btnSave.Text = "&Save"
                        btnClose.Text = "&Cancel"
                        'btnNew.Text = "&Edit"
                        grpProductListing.Visible = False
                        txtqtyReceived.Focus()
                    Else
                        btnNew.Text = "&New"
                        .EndEdit()
                    End If
                Catch
                    MsgBox(Err.Description)
                End Try
            End With
        End If
    End Sub

    Private Sub txtProductBarcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProductBarcode.GotFocus
        grpProductListing.Visible = True
        grpProductListing.Top = txtProductBarcode.Top + txtProductBarcode.Height
        grpProductListing.Left = txtProductBarcode.Left
        grpProductListing.Width = 800
        grpProductListing.Height = 400
    End Sub

    Private Sub txtProductBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductBarcode.KeyDown
        Dim bbcode As String = txtProductBarcode.Text

        If e.KeyCode = Keys.Enter Then
            rbtnSearchByBarcode.Checked = True
            'Call clearControls()
            txtProductBarcode.Text = bbcode
            Call LoadProductListing_byBarcode(txtProductBarcode.Text)
            '--------------------------------------------------------------- code from datagridview1_cellclick---------------------------------------------------------------------
            If DataGridView1.Rows.Count = 1 Then
                grpProductListing.Visible = False
                With DataGridView1
                    Try
                        If Me.DataGridView1.SelectedRows.Count > 0 Then ' AndAlso Not Me.DataGridView1.SelectedRows(0).Index = Me.DataGridView1.Rows.Count - 1 Then

                            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

                            txtProductBarcode.Text = .Item(0, .CurrentCellAddress.Y).Value
                            txtProductDescription.Text = .Item(1, .CurrentCellAddress.Y).Value
                            txtQTYOnHand.Text = .Item(2, .CurrentCellAddress.Y).Value
                            Call LoadUnitPriceToCombo(txtProductBarcode.Text)
                            cmbUnitPrice.Text = .Item(4, .CurrentCellAddress.Y).Value
                            cmbPurchaseCost.Text = .Item(5, .CurrentCellAddress.Y).Value
                            cmbUnitType.Text = .Item(3, .CurrentCellAddress.Y).Value
                            'cmbSupplier.Text = getFIELD_VALUE_FROM_DBASE("tblSupplier", "SupplierName", "SupplierID", .Item(10, .CurrentCellAddress.Y).Value)
                            CurrentRowIndex = .CurrentRow.Index
                            txtqtyReceived.Focus()
                            .EditMode = DataGridViewEditMode.EditProgrammatically
                            btnSave.Text = "&Save"
                            'btnClose.Text = "&Cancel"
                            'btnNew.Text = "&Edit"
                        Else
                            'btnNew.Text = "&New"
                            .EndEdit()
                        End If
                    Catch
                        MsgBox(Err.Description)
                        Exit Sub
                    End Try
                End With
            ElseIf DataGridView1.Rows.Count > 1 Then
                'show the products within the list that matches the searched barcode
                txtProductBarcode.Text = bbcode
                grpProductListing.Visible = True
                grpProductListing.Visible = True
                grpProductListing.Top = txtProductBarcode.Top + txtProductBarcode.Height
                grpProductListing.Left = txtProductBarcode.Left
                grpProductListing.Width = 800
                grpProductListing.Height = 400
                DataGridView1.Focus()
            End If
        ElseIf e.KeyCode = Keys.F2 Then
            'show the products within the list that matches the searched barcode
            txtProductBarcode.Text = bbcode
            grpProductListing.Visible = True
            grpProductListing.Top = txtProductBarcode.Top + txtProductBarcode.Height
            grpProductListing.Left = txtProductBarcode.Left
            grpProductListing.Width = 800
            grpProductListing.Height = 400
            DataGridView1.Focus()
        End If
    End Sub

    Private Sub frmProductReceiving_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F10 Then
            grpProductListing.Visible = True
            grpProductListing.Top = txtProductBarcode.Top + txtProductBarcode.Height
            grpProductListing.Left = txtProductBarcode.Left
            grpProductListing.Width = 800
            grpProductListing.Height = 400
            DataGridView1.Focus()
        ElseIf e.KeyCode = Keys.F11 Then
            grpProductListing.Visible = False
            DataGridView1.Focus()
            lblProductReceivedListing.Text = "PRODUCT RECEIVED LISTING FOR THE DATE " & DateTimePicker1.Text
        ElseIf e.KeyCode = Keys.Escape Then
            grpProductListing.Visible = False
            txtProductBarcode.Focus()
        End If
    End Sub

    Private Sub btnNewUnitPrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewUnitPrice.Click
        Dim frm As New frmPriceDiscountAdjustment
        frm.btnNew.Enabled = False
        frm.change_bkGround(Color.White)
        frm.rbtnSearchByBarcode.Checked = True
        frm.txtSearch.Text = txtProductBarcode.Text
        frm.txtProductID.Text = txtProductBarcode.Text
        frm.txtPurchaseCost.Text = cmbPurchaseCost.Text
        Calling_Form = "frmStocksEntryForm"
        frm.ShowDialog()
    End Sub

    Private Sub btnAddNewSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayPO.Click
        If DATA_WAS_EDITED = True Then
            If MsgBox("CHANGES NOT SAVED, RELOAD P.O ANYWAY?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical, "") = MsgBoxResult.Yes Then
                Call load_PO_details(cmbPO.Text)
                DATA_WAS_EDITED = False
            End If
        Else
            Call load_PO_details(cmbPO.Text)
        End If
        Dim drnum As String = getFIELD_VALUE_FROM_DBASE("tblProductReceive", "TOP 1 DR_RefNo", "PO_Number", cmbPO.Text)
        If Len(drnum) > 0 Then
            txtDRNumber.Text = Replace(getFIELD_VALUE_FROM_DBASE("tblProductReceive", "TOP 1 DR_RefNo", "PO_Number", cmbPO.Text), txtSuppCode.Text & "-", "")
        Else
            txtDRNumber.Text = ""
        End If
    End Sub




    Private Sub btnSearch_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Call LoadProductListing_byBarcode(txtProductBarcode.Text)
    End Sub

    Private Sub txtSearch_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call LoadProductListing_byBarcode(txtSearch.Text)
        End If
    End Sub

    Private Sub cmbUnitPrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUnitPrice.GotFocus
        Call LoadUnitPriceToCombo(txtProductBarcode.Text)
        If cmbUnitPrice.Items.Count <= 0 Then
            btnNewUnitPrice_Click(sender, e)
            btnNewUnitPrice.Focus()
        End If
    End Sub

   

    Private Sub txtqtyReceived_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtqtyReceived.KeyDown


        If e.KeyCode = Keys.F3 And grpProductListing.Visible = True Then
            txtProductBarcode_KeyDown(sender, e)
            DataGridView1.Focus() 'product list
        ElseIf e.KeyCode = Keys.F2 And grpProductListing.Visible = False Then
            DataGridView2.Focus() 'received product list
            lblProductReceivedListing.Text = "PRODUCT RECEIVED LISTING FOR THE DATE " & DateTimePicker1.Text
        End If
    End Sub

   

    '
    'PRODUCT RECEIVED LIST..
    Private Sub DataGridView2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView2.KeyDown
        If e.KeyCode = Keys.Up And DataGridView1.SelectedRows(0).Index <= 0 Then
            txtSearch.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            With DataGridView2
                Try
                    If Me.DataGridView1.SelectedRows.Count > 0 Then ' AndAlso Not Me.DataGridView1.SelectedRows(0).Index = Me.DataGridView1.Rows.Count - 1 Then

                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect

                        txtProductBarcode.Text = .Item(0, .CurrentCellAddress.Y).Value
                        txtProductDescription.Text = .Item(1, .CurrentCellAddress.Y).Value
                        txtQTYOnHand.Text = .Item(2, .CurrentCellAddress.Y).Value
                        'txtContactTitle.Text = .Item(3, .CurrentCellAddress.Y).Value
                        'txtUnitPrice.Text = .Item(4, .CurrentCellAddress.Y).Value
                        'txtTelNo.Text = .Item(5, .CurrentCellAddress.Y).Value
                        cmbPurchaseCost.Text = .Item(6, .CurrentCellAddress.Y).Value
                        CurrentRowIndex = .CurrentRow.Index
                        .EditMode = DataGridViewEditMode.EditProgrammatically
                        btnSave.Text = "&Update"
                        btnClose.Text = "&Cancel"
                        'btnNew.Text = "&Edit"
                        txtqtyReceived.Focus()
                    Else
                        btnNew.Text = "&New"
                        .EndEdit()
                    End If
                Catch
                    MsgBox(Err.Description)
                End Try
            End With
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        Call load_ProductReceived()
    End Sub

    Private Sub txtqtyReceived_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtqtyReceived.Validated
        If Not IsNumeric(txtqtyReceived.Text) Then
            MsgBox("Not a number, Please try again!")
            txtqtyReceived.Focus()
            txtqtyReceived.SelectAll()
        End If
    End Sub

    Private Sub txtProductBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductBarcode.TextChanged
        txtSearch.Text = txtProductBarcode.Text
    End Sub

    Private Sub DataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        'edit items details
        With DataGridView2
            txtProductBarcode.Text = .Item(0, .CurrentCellAddress.Y).Value
            txtProductDescription.Text = .Item(1, .CurrentCellAddress.Y).Value
            txtqtyReceived.Text = .Item(2, .CurrentCellAddress.Y).Value
            cmbUnitType.Text = .Item(3, .CurrentCellAddress.Y).Value
            ' cmbSupplier.Text = getFIELD_VALUE_FROM_DBASE("tblSupplier", "SupplierName", "SupplierID", .Item(7, .CurrentCellAddress.Y).Value)
            DateTimePicker1.Text = .Item(4, .CurrentCellAddress.Y).Value
            cmbUnitPrice.Text = getFIELD_VALUE_FROM_DBASE("tblPriceHistory", "Price", "SetDefault = 1 AND trnno", getFIELD_VALUE_FROM_DBASE("tblProduct", "UnitPriceCode", "ProductID_Barcode", .Item(0, .CurrentCellAddress.Y).Value))
            cmbPurchaseCost.Text = getFIELD_VALUE_FROM_DBASE("tblPriceHistory", "PurchaseCost", "SetDefault = 1 AND trnno", getFIELD_VALUE_FROM_DBASE("tblProduct", "UnitPriceCode", "ProductID_Barcode", .Item(0, .CurrentCellAddress.Y).Value))
            txtQTYOnHand.Text = getFIELD_VALUE_FROM_DBASE("tblProduct", "QtyOnHand", "ProductID_Barcode", .Item(0, .CurrentCellAddress.Y).Value)
            cmbSupplier.Text = getFIELD_VALUE_FROM_DBASE("tblSupplier", "SupplierName", "SupplierID", .Item(7, .CurrentCellAddress.Y).Value)
        End With
        btnClose.Text = "&Cancel"
        btnNew.Enabled = False
        btnSave.Enabled = True
        btnSave.Text = "&Update"
        txtqtyReceived.Focus()
    End Sub

    Private Sub DataGridView2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Visible = True
        End If
    End Sub

    Private Sub cmbSupplier_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSupplier.LostFocus
        If Len(cmbSupplier.Text) > 0 And Len(cmbPO.Text) > 0 Then
            btnAddNewSupplier_Click(sender, e)
        End If
    End Sub

    Private Sub cmbSupplier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSupplier.SelectedIndexChanged
        getSupplierIDFromComboBOx()
        txtSuppCode.Text = SupplierID
        Call LoadPOToCombo(SupplierID)
        'suggest/extract a posible DR number
        Dim drnum As String = getFIELD_VALUE_FROM_DBASE("tblProductReceive", "TOP 1 DR_RefNo", "PO_Number", cmbPO.Text)
        If Len(drnum) > 0 Then
            txtDRNumber.Text = Replace(getFIELD_VALUE_FROM_DBASE("tblProductReceive", "TOP 1 DR_RefNo", "PO_Number", cmbPO.Text), txtSuppCode.Text & "-", "")
        Else
            txtDRNumber.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmReceivedStockMonitoring
        frm.WindowState = FormWindowState.Normal
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.ShowDialog()
    End Sub

    Private Sub grpProductListing_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpProductListing.Enter

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub cmbSupplier_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSupplier.SelectedValueChanged
        getSupplierIDFromComboBOx()
        Call LoadPOToCombo(SupplierID)
    End Sub


    Private Sub chkEnableAddDeliveryToDR_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkEnableAddDeliveryToDR.MouseClick
        If chkEnableAddDeliveryToDR.CheckState = CheckState.Checked Then
            txtProductBarcode.Enabled = True
            txtProductDescription.Enabled = True
            cmbUnitType.Enabled = True
            txtQTYOnHand.Enabled = True
            cmbUnitPrice.Enabled = True
            cmbPurchaseCost.Enabled = True
            txtqtyReceived.Enabled = True
            btnAddToDRList.Enabled = True

            txtProductBarcode.BackColor = Color.White
            txtProductDescription.BackColor = Color.White
            cmbUnitType.BackColor = Color.White
            txtQTYOnHand.BackColor = Color.White
            cmbUnitPrice.BackColor = Color.White
            cmbPurchaseCost.BackColor = Color.White
            txtqtyReceived.BackColor = Color.White
            btnAddToDRList.BackColor = Color.White

        Else
            txtProductBarcode.Enabled = False
            txtProductDescription.Enabled = False
            cmbUnitType.Enabled = False
            txtQTYOnHand.Enabled = False
            cmbUnitPrice.Enabled = False
            cmbPurchaseCost.Enabled = False
            txtqtyReceived.Enabled = False
            btnAddToDRList.Enabled = False

            txtProductBarcode.BackColor = Color.BurlyWood
            txtProductDescription.BackColor = Color.BurlyWood
            cmbUnitType.BackColor = Color.BurlyWood
            txtQTYOnHand.BackColor = Color.BurlyWood
            cmbUnitPrice.BackColor = Color.BurlyWood
            cmbPurchaseCost.BackColor = Color.BurlyWood
            txtqtyReceived.BackColor = Color.BurlyWood
            btnAddToDRList.BackColor = Color.BurlyWood
        End If
    End Sub

    Private Sub cmbPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPO.SelectedIndexChanged
        btnAddNewSupplier_Click(sender, e)
        'suggest/extract a posible DR number
        Dim drnum As String = getFIELD_VALUE_FROM_DBASE("tblProductReceive", "TOP 1 DR_RefNo", "PO_Number", cmbPO.Text)
        If Len(drnum) > 0 Then
            txtDRNumber.Text = Replace(getFIELD_VALUE_FROM_DBASE("tblProductReceive", "TOP 1 DR_RefNo", "PO_Number", cmbPO.Text), txtSuppCode.Text & "-", "")
        Else
            txtDRNumber.Text = ""
        End If
    End Sub

    Private Sub btnAddToDRList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToDRList.Click
        If Len(txtDRNumber.Text) <= 0 Then
            MsgBox("Please provide supplier D.R REFERENCE NUMBER to proceed, Thank you!")
            txtDRNumber.Focus()
            Exit Sub
        End If
        If Len(txtProductBarcode.Text) > 0 And Len(txtqtyReceived.Text) > 0 Then
            Dim Barcode As String, ProductDesciption As String, UnitName As String, QTYordered As Double, QTYReceived As Double, Disc As Double, Transtime As String, unitprice As Double


            Barcode = txtProductBarcode.Text
            ProductDesciption = txtProductDescription.Text
            QTYReceived = txtqtyReceived.Text
            UnitName = cmbUnitType.Text
            QTYordered = 0
            unitprice = cmbPurchaseCost.Text

            Dim row As String() = New String() {Barcode, ProductDesciption, QTYordered, UnitName, QTYReceived, unitprice, "OVER DELIVERY", "DELIVERY WITHOUT P.O", "NO P.O"} 'FormatCurrency(unitprice, 2)
            DataGridView2.Rows.Add(row)

            DATA_WAS_SAVED = False
            DATA_WAS_EDITED = True

            'clear the entry controls
            txtProductBarcode.Text = ""
            txtProductDescription.Text = ""
            txtQTYOnHand.Text = ""
            cmbUnitPrice.Text = ""
            cmbUnitType.Text = ""
            cmbPurchaseCost.Text = ""
            txtqtyReceived.Text = ""

        ElseIf Len(txtProductBarcode.Text) <= 0 Then
            txtProductBarcode.Focus()
        ElseIf Len(txtqtyReceived.Text) <= 0 Then
            txtqtyReceived.Focus()
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles DataGridView2.UserDeletingRow

        'Dim startingBalanceRow As Long = getFIELD_VALUE_FROM_DBASE("tblPO_Details", "count(trnno)", "PO_Number", cmbPO.Text)
        With DataGridView2
            ' Check if the starting balance row is included in the selected rows
            Dim startingBalanceRow2 As String = .SelectedRows.Item(0).Cells(8).Value
            If .SelectedRows.Item(0).Cells(8).Value = "NO P.O" Then
                e.Cancel = False
            Else
                ' Do not allow the user to delete the Starting Balance row.
                MessageBox.Show("Cannot delete this item, it is included in the P.O!")

                ' Cancel the deletion if the Starting Balance row is included.
                e.Cancel = True
            End If
        End With
    End Sub

  
    Private Sub DataGridView2_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseClick
        If Len(txtDRNumber.Text) <= 0 Then
            MsgBox("Please provide supplier D.R REFERENCE NUMBER to proceed, Thank you!")
            txtDRNumber.Focus()
            DataGridView2.EndEdit()
            Exit Sub
        End If
    End Sub

    Private Sub btnDisplayDR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayDR.Click
        Call load_DR_Details(txtSuppCode.Text & "-" & txtDRNumber.Text)
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
        DataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView2.EditMode = DataGridViewEditMode.EditOnF2
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                DataGridView2.Rows.Clear()
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
                    DataGridView2.Rows.Add(row)

                Next
            Else
                DataGridView2.Rows.Clear()
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSuppCode.TextChanged

    End Sub

    Private Sub txtDRNumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDRNumber.LostFocus
        Dim DR_Ref As String = txtSuppCode.Text & "-" & txtDRNumber.Text
        Dim duplicate_DR_number As String
        If txtDRNumber.Text = "" Then Exit Sub
        duplicate_DR_number = getFIELD_VALUE_FROM_DBASE("tblProductReceivedSummary", "DR_RefNo", "DR_RefNO", DR_Ref)
        If DR_Ref = duplicate_DR_number And New_Entry_Flag = True Then
            If MsgBox("This DR Number already exists in Database, Please try another number." + Chr(13) + Chr(13) + " Thank you!", MsgBoxStyle.Critical + MsgBoxStyle.OkCancel, "") = MsgBoxResult.Ok Then
                txtDRNumber.Focus()
            Else
                If btnClose.Text = "&Cancel" Then btnClose_Click(sender, e)
            End If

        End If
    End Sub

    Private Sub txtDRNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDRNumber.TextChanged

    End Sub
End Class