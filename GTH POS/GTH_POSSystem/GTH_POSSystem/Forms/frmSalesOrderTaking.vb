Imports System.Data.SqlClient

Public Class frmSalesOrderTaking

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

    Dim unitPriceCode As Long = 0

    Private Sub LoadProductListing_byBarcode(ByVal bcode As String)
        Dim rowcounter As Integer
        Me.Cursor = Cursors.WaitCursor
        If Len(bcode) = 0 Then
            sqladapter = New SqlClient.SqlDataAdapter("SELECT   BARCODE, DESCRIPTION, Price, UNIT, QTYOnHand, DateEntered, SetDefault, ProductDiscount, ReorderPoint, SupplierID, CategoryName  FROM         vwProductPriceDetailsView " _
                                                      & " WHERE  ((Description LIKE '%" & bcode & "%') OR (Barcode LIKE '" & bcode & "%'))  order by Description", conn)
        Else
            sqladapter = New SqlClient.SqlDataAdapter("SELECT   BARCODE, DESCRIPTION, Price, UNIT, QTYOnHand, DateEntered, SetDefault, ProductDiscount, ReorderPoint, SupplierID, CategoryName  FROM         vwProductPriceDetailsView " _
                                                      & " WHERE  ((Description LIKE '%" & bcode & "%') OR (Barcode LIKE '" & bcode & "%'))  order by Description", conn)
        End If

        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                'load the details to input controls

                dgrProductList.DataSource = dsDataset.Tables(0)

                dgrProductList.AutoResizeColumns()
            Else
                dgrProductList.Columns.Clear()
                MsgBox("No Record Found!", MsgBoxStyle.Information, "No Record Found. . .")
                txtProductBarcode.SelectAll()
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub Lock_Controls(ByVal Lflag As Boolean)
        GroupBox1.Enabled = Lflag
        GroupBox3.Enabled = Lflag
        GroupBox4.Enabled = Lflag
    End Sub

    Public Sub change_bkGround(ByVal xxx As Color)
        txtChangeDue.BackColor = xxx
        txtDiscount.BackColor = xxx
        txtFinalDiscount.BackColor = xxx
        txtNetSales.BackColor = xxx
        txtNoOfItems.BackColor = xxx
        txtPayment.BackColor = xxx
        txtProductBarcode.BackColor = xxx
        txtProductDescription.BackColor = xxx
        txtQty.BackColor = xxx
        txtQTYOnHand.BackColor = xxx
    End Sub

    Public Sub ClearControls(Optional ByVal ctlcol As Control.ControlCollection = Nothing)
        If ctlcol Is Nothing Then ctlcol = Me.Controls
        For Each ctl As Control In ctlcol
            If TypeOf (ctl) Is TextBox Then
                DirectCast(ctl, TextBox).Clear()
            ElseIf TypeOf (ctl) Is ComboBox Then
                If ctl.Name = "cmbRoPoint" Then Exit Sub
                DirectCast(ctl, ComboBox).Items.Clear()
            Else
                If Not ctl.Controls Is Nothing OrElse ctl.Controls.Count <> 0 Then
                    ClearControls(ctl.Controls)
                End If
            End If
        Next

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

        'use this iteration when textbox controls is lodged in a groupbox
        For Each ctl In GroupBox4.Controls
            If TypeOf ctl Is TextBox Then ctl.text = ""
            If TypeOf ctl Is ComboBox Then ctl.text = ""
        Next ctl

        For Each ctl In GroupBox1.Controls
            If TypeOf ctl Is ComboBox Then ctl.text = ""
            If TypeOf ctl Is TextBox Then ctl.text = ""
        Next ctl

        txtChangeDue.Clear()
        txtFinalDiscount.Clear()
        txtPayment.Clear()
        txtNoOfItems.Clear()
        txtNetSales.Clear()
        lblTotalAmount.Text = ""


        dgrOrderList.Rows.Clear()

        cmbUnitPrice.SelectedIndex = -1
        cmbUnitType.SelectedIndex = -1
    End Sub

    Private Sub frmSalesOrderTaking_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.F5) Or (e.Alt And e.KeyCode = Keys.Enter) Then 'or alt+enter
            If txtFinalDiscount.Focused Then
                txtPayment.SelectAll()
                txtPayment.Focus()
            Else
                txtFinalDiscount.SelectAll()
                txtFinalDiscount.Focus()
            End If
            Call COMPUTE_SKU_TOTALAMOUNT()

        ElseIf e.KeyCode = Keys.F12 Then
            If NOT_SAVE_FLAG = True Then
                If MsgBox("The present transaction was not yet done!" & Chr(13) & Chr(13) & "Would you like to CANCEL?", MsgBoxStyle.YesNo, "WARNING. . .") = MsgBoxResult.Yes Then
                    'FLAG THE AUTO NUMBER AS USED
                    Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("AUTONO", "STATUS='false'", "TransactionAutoNumber=" & TRANSACTION_NUMBER)

                    Call Lock_Controls(False) 'disable the groupbox

                    Call change_bkGround(Color.DarkGray)

                    Call ClearControls()

                    lblOR.Text = "(O.R#_ _ _ _ _ _)"

                    NOT_SAVE_FLAG = False
                    Me.Dispose()
                    Me.Close()
                End If
            Else
                Me.Dispose()
                Me.Close()
            End If
        ElseIf e.Alt And e.KeyCode = Keys.Q Then
            txtQty.SelectAll()
            txtQty.Focus()
        ElseIf e.Alt And e.KeyCode = Keys.S Then
            dgrOrderList.Focus()
        ElseIf e.Alt And e.KeyCode = Keys.L Then
            dgrOrderList.Focus()
        ElseIf e.Alt And e.KeyCode = Keys.B Then
            txtProductBarcode.Clear()
            txtProductBarcode.Focus()
        ElseIf e.Alt And e.KeyCode = Keys.S Then
            txtProductBarcode.Clear()
            txtProductBarcode.Focus()
        ElseIf e.KeyCode = Keys.F6 Then
            On Error Resume Next
            Call LoadProductListing_byBarcode(txtProductBarcode.Text)
            GroupBox3.Top = txtProductBarcode.Top + txtProductBarcode.Height
            GroupBox3.Left = txtProductBarcode.Left
            GroupBox3.Width = Me.Width - 200
            GroupBox3.Visible = True
            dgrProductList.Enabled = True
            txtProductBarcode.Enabled = True
            If GroupBox1.Enabled = False Then
                GroupBox1.Enabled = True
                txtProductBarcode.Focus()
            End If
        ElseIf e.KeyCode = Keys.F2 Then

            If txtProductBarcode.Focused Then
                txtQty.SelectAll()
                txtQty.Focus()
            Else
                txtProductBarcode.SelectAll()
                txtProductBarcode.Focus()
            End If


        ElseIf e.KeyCode = Keys.F4 Then
            'REPRINT RECEIPT
            Dim ORNUM As String = InputBox("O.R NUMBER TO PRINT", "REPRINTING RECEIPTS . . .")
            If Len(ORNUM) > 0 Then
                Call PRINT_RECEIPT(ORNUM.PadLeft(10, "0"))
            Else
                Beep()
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            'DETECT WHETHER PREVIOUS TRANSACTION WAS SAVED
            If NOT_SAVE_FLAG = True Then
                If MsgBox("The present transaction was not yet done!" & Chr(13) & Chr(13) & "Would you like to CANCEL?", MsgBoxStyle.YesNo, "WARNING. . .") = MsgBoxResult.Yes Then
                    'FLAG THE AUTO NUMBER AS USED
                    Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("AUTONO", "STATUS='false'", "TransactionAutoNumber=" & TRANSACTION_NUMBER)

                    Call Lock_Controls(False) 'disable the groupbox

                    Call change_bkGround(Color.DarkGray)

                    Call ClearControls()

                    NOT_SAVE_FLAG = False
                End If

            Else

                'INITIALIZE THE SAVE FLAG
                NOT_SAVE_FLAG = True

                'SET AUTO NUMBER TICKET
                Call SET_AutoNoTable("SALES", 0)

                'GET AUTO NUMBER VALUE
                TRANSACTION_NUMBER = GET_TransactionNumberTicket()
                OFFICIAL_RECEIPT_NO = TRANSACTION_NUMBER.ToString.PadLeft(10, "0")
                lblOR.Text = "(O.R#" & OFFICIAL_RECEIPT_NO & ")"

                'FLAG THE AUTO NUMBER AS USED
                Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("AUTONO", "STATUS='TRUE'", "TransactionAutoNumber=" & TRANSACTION_NUMBER)

                Call Lock_Controls(True) 'enable the groupbox

                Call change_bkGround(Color.White)

                Call ClearControls()

                txtProductBarcode.Focus()

            End If
            tmrPOR.Enabled = True
            strCurrency = ""
        ElseIf e.KeyCode = Keys.F7 Then
            If NOT_SAVE_FLAG = True Then
                If MsgBox("The present transaction was not yet done!" & Chr(13) & Chr(13) & "Would you like to CANCEL?", MsgBoxStyle.YesNo, "WARNING. . .") = MsgBoxResult.Yes Then
                    'FLAG THE AUTO NUMBER AS USED
                    Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("AUTONO", "STATUS='false'", "TransactionAutoNumber=" & TRANSACTION_NUMBER)

                    Call Lock_Controls(False) 'disable the groupbox

                    Call change_bkGround(Color.DarkGray)

                    Call ClearControls()

                    lblOR.Text = "(O.R#_ _ _ _ _ _)"

                    NOT_SAVE_FLAG = False

                    tmrPOR.Enabled = True
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Or e.KeyCode = Keys.LWin Then
            If GroupBox3.Visible = True Then
                GroupBox3.Visible = False
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            'MsgBox("", MsgBoxStyle.Critical, "")
            Dim frm As New Dialog1
            frm.lblMessage.Text = "Order Revoke not allowed at this time, Thank you!"
            frm.ShowDialog()
        End If

    End Sub

    Private Sub frmSalesOrderTaking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ClearControls()
        Call change_bkGround(Color.DarkGray)
        Call LoadUnitTypeToCombo()
        Call LoadReoderPointToCombo()
        With dgrOrderList
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = False
            .Columns(3).ReadOnly = True
        End With
    End Sub

    Private Sub dgrOrderList_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrOrderList.CellEndEdit
        Dim s As Double = Convert.ToDouble(dgrOrderList.CurrentRow.Cells(1).Value) 'PRICE
        Dim s1 As Double = Convert.ToDouble(dgrOrderList.CurrentRow.Cells(2).Value) 'QTY
        Dim DISCOUNT_ As Double = Convert.ToDouble(dgrOrderList.CurrentRow.Cells(4).Value) / 100 'DISCOUNT
        Dim s13 As Double = (s * s1)
        dgrOrderList.CurrentRow.Cells(3).Value = s13
        Call COMPUTE_SKU_TOTALAMOUNT()
    End Sub

    Private Sub COMPUTE_SKU_TOTALAMOUNT()
        Dim undiscountedAmount As Double = 0
        Dim totalDiscount As Double = 0
        Dim pdisc As Double = 0
        Dim uPrice As Double
        Dim discRate As Double
        Dim pQty As Long

        Dim xRowCount As Integer = 0
        Dim TotalAmount As Double = 0
        Dim sku As Integer = 0
        For xRowCount = 0 To dgrOrderList.RowCount - 1
            Dim s As Double = 0 'Convert.ToDouble(DataGridView1.CurrentRow.Cells(6).Value)
            ' s = Convert.ToDouble(dgrOrderList.Rows(xRowCount).Cells(3).Value)
            uPrice = Convert.ToDouble(dgrOrderList.Rows(xRowCount).Cells(1).Value)
            pQty = Convert.ToDouble(dgrOrderList.Rows(xRowCount).Cells(2).Value)
            undiscountedAmount = undiscountedAmount + (uPrice * pQty)
            discRate = Convert.ToDouble(dgrOrderList.Rows(xRowCount).Cells(4).Value) 'in percent

            s = dgrOrderList.Rows(xRowCount).Cells(3).Value
            pdisc = s * (discRate / 100)

            TotalAmount = TotalAmount + s
            sku = sku + 1
            totalDiscount = totalDiscount + pdisc
        Next
        txtNoOfItems.Text = sku - 1
        lblTotalAmount.Text = FormatNumber(TotalAmount, 2, , , TriState.True)
        txtFinalDiscount.Text = FormatNumber(totalDiscount, 2, , , TriState.True)
    End Sub

    Private Sub addToSalesDatagridview()
        With dgrOrderList
            Dim Barcode As String, ProductDesciption As String, QTY As Double, ItemAmount As Double, Disc As Double, Transtime As String, unitprice As Double
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Barcode = txtProductBarcode.Text
            ProductDesciption = txtProductDescription.Text
            QTY = IIf(txtQty.Text = "", 1, txtQty.Text)
            txtQty.Text = QTY
            unitprice = CDbl(cmbUnitPrice.Text)
            Disc = IIf(txtDiscount.Text = "", 0, CDbl(txtDiscount.Text)) / 100 * unitprice
            ItemAmount = CDbl(QTY) * (CDbl(cmbUnitPrice.Text))
            Disc = txtDiscount.Text
            Transtime = TimeOfDay.Hour & ":" & TimeOfDay.Minute & ":" & TimeOfDay.Second


            Dim row As String() = New String() {ProductDesciption, unitprice, QTY, FormatCurrency(ItemAmount, 2), Disc, Barcode, Transtime}

            .Rows.Add(row)
            .EndEdit()
            Call COMPUTE_SKU_TOTALAMOUNT()
        End With

    End Sub

    Private Sub txtProductBarcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProductBarcode.GotFocus
        txtProductBarcode.BackColor = Color.Aqua
    End Sub

    Private Sub txtProductBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProductBarcode.LostFocus
        txtProductBarcode.BackColor = Color.White
    End Sub

    Private Sub txtProductBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductBarcode.KeyDown
        Try
            If e.KeyCode = Keys.Enter And Len(txtProductBarcode.Text) > 0 Then
                Call LoadProductListing_byBarcode(txtProductBarcode.Text)

                With dgrProductList


                    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    If Me.dgrProductList.Rows.Count = 2 Then
                        'if only one product was found

                        dgrProductList.Visible = True
                        GroupBox3.Top = txtProductBarcode.Top + txtProductBarcode.Height
                        GroupBox3.Left = txtProductBarcode.Left
                        GroupBox3.Visible = True

                        txtProductBarcode.Text = .Item(0, .CurrentCellAddress.Y).Value
                        cmbUnitPrice.Text = .Item(2, .CurrentCellAddress.Y).Value
                        cmbUnitType.Text = .Item(3, .CurrentCellAddress.Y).Value
                        txtQTYOnHand.Text = .Item(4, .CurrentCellAddress.Y).Value
                        txtProductDescription.Text = .Item(1, .CurrentCellAddress.Y).Value
                        txtDiscount.Text = Convert.ToString(IIf(.Item(7, .CurrentCellAddress.Y).Value = "0.00", txtDiscount.Text, .Item(7, .CurrentCellAddress.Y).Value))

                        Call addToSalesDatagridview()

                        GroupBox3.Visible = False
                        txtProductBarcode.Clear()
                        txtProductBarcode.Focus()

                    ElseIf Me.dgrProductList.Rows.Count > 2 Then
                        'if there are two or more products found containing the same description or barcode
                        GroupBox3.Top = txtProductBarcode.Top + txtProductBarcode.Height
                        GroupBox3.Left = txtProductBarcode.Left
                        GroupBox3.Visible = True

                        txtProductBarcode.Text = .Item(0, .CurrentCellAddress.Y).Value
                        cmbUnitPrice.Text = .Item(2, .CurrentCellAddress.Y).Value
                        cmbUnitType.Text = .Item(3, .CurrentCellAddress.Y).Value
                        txtQTYOnHand.Text = .Item(4, .CurrentCellAddress.Y).Value
                        txtProductDescription.Text = .Item(1, .CurrentCellAddress.Y).Value
                        txtDiscount.Text = Convert.ToString(IIf(.Item(7, .CurrentCellAddress.Y).Value = "0.00", txtDiscount.Text, .Item(7, .CurrentCellAddress.Y).Value))
                        dgrProductList.Focus()
                    End If

                End With

            ElseIf e.KeyCode = Keys.Down Then
                If dgrProductList.Rows.Count > 0 Then
                    dgrProductList.Focus()
                Else
                    Beep()
                End If
            ElseIf e.KeyCode = Keys.F4 Then

            End If
        Catch
            MsgBox(Err.Description)
        End Try

    End Sub

    Private Sub dgrProductList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgrProductList.KeyDown
        Try
            If e.KeyCode = Keys.Up And dgrProductList.SelectedRows(0).Index <= 0 Then

            ElseIf e.KeyCode = Keys.Enter Then
                With dgrProductList

                    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    Try
                        If Me.dgrProductList.SelectedRows.Count = 1 Then ' AndAlso Not Me.DataGridView1.SelectedRows(0).Index = Me.DataGridView1.Rows.Count - 1 Then
                            txtProductBarcode.Text = .Item(0, .CurrentCellAddress.Y).Value
                            'BARCODE,ProductDesciption as DESCRIPTION, Price as PRICE,UnitName as UNIT,QTYOnHand,  DateEntered, SetDefault,ProductDiscount,reorderpoint,supplierID,CategoryName,trnno
                            cmbUnitPrice.Text = .Item(2, .CurrentCellAddress.Y).Value
                            cmbUnitType.Text = .Item(3, .CurrentCellAddress.Y).Value
                            txtQTYOnHand.Text = .Item(4, .CurrentCellAddress.Y).Value
                            txtProductDescription.Text = .Item(1, .CurrentCellAddress.Y).Value
                            txtDiscount.Text = .Item(7, .CurrentCellAddress.Y).Value

                            GroupBox3.Visible = False
                            'add to sales datagrid
                            If Len(txtQty.Text) > 0 Then
                                Call addToSalesDatagridview()
                            Else
                                txtQty.Text = "1"
                                Call addToSalesDatagridview()
                            End If
                            txtProductBarcode.Focus()
                        ElseIf Me.dgrProductList.Rows.Count >= 2 Then

                            txtProductBarcode.Text = .Item(0, .CurrentCellAddress.Y).Value
                            'BARCODE,ProductDesciption as DESCRIPTION, Price as PRICE,UnitName as UNIT,QTYOnHand,  DateEntered, SetDefault,ProductDiscount,reorderpoint,supplierID,CategoryName,trnno
                            cmbUnitPrice.Text = .Item(2, .CurrentCellAddress.Y).Value
                            cmbUnitType.Text = .Item(3, .CurrentCellAddress.Y).Value
                            txtQTYOnHand.Text = .Item(4, .CurrentCellAddress.Y).Value
                            txtProductDescription.Text = .Item(1, .CurrentCellAddress.Y).Value
                            txtDiscount.Text = .Item(7, .CurrentCellAddress.Y).Value
                            txtQty.Focus()
                        Else
                            .EndEdit()
                        End If
                    Catch
                        MsgBox(Err.Description)
                    End Try
                End With
            End If
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub dgrProductList_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgrProductList.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
            With dgrProductList
                Try
                    If .SelectedRows.Count > 0 Then 'AndAlso Not Me.DataGridView1.SelectedRows(0).Index = Me.DataGridView1.Rows.Count - 1 Then

                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect

                        'txtProductBarcode.Text = .Item(0, .CurrentCellAddress.Y).Value
                        cmbUnitPrice.Text = .Item(2, .CurrentCellAddress.Y).Value
                        cmbUnitType.Text = .Item(3, .CurrentCellAddress.Y).Value
                        txtQTYOnHand.Text = .Item(4, .CurrentCellAddress.Y).Value
                        txtProductDescription.Text = .Item(1, .CurrentCellAddress.Y).Value
                        txtDiscount.Text = .Item(7, .CurrentCellAddress.Y).Value

                        If e.KeyCode = Keys.Enter Then
                            txtProductBarcode.Focus()
                            cmbUnitPrice.Text = .Item(2, .CurrentCellAddress.Y).Value
                            cmbUnitType.Text = .Item(3, .CurrentCellAddress.Y).Value
                            txtQTYOnHand.Text = .Item(4, .CurrentCellAddress.Y).Value
                            txtProductDescription.Text = .Item(1, .CurrentCellAddress.Y).Value
                            txtDiscount.Text = .Item(7, .CurrentCellAddress.Y).Value
                            'add to sales grid
                            Call addToSalesDatagridview()
                        End If
                    Else
                        .EndEdit()
                    End If
                Catch
                    MsgBox(Err.Description)
                End Try
            End With
        End If
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
                'cmbPurchaseCost.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    cmbUnitPrice.Items.Add(New ComboListData(.Rows(rowcounter).Item("Price").ToString(), .Rows(rowcounter).Item("trnno").ToString()))
                    'cmbPurchaseCost.Items.Add(New ComboListData(.Rows(rowcounter).Item("PurchaseCost").ToString(), .Rows(rowcounter).Item("trnno").ToString()))
                    'cmbUnitPrice.Items.Add(.Rows(rowcounter).Item("Price").ToString())
                    'cmbPurchaseCost.Items.Add(.Rows(rowcounter).Item("PurchaseCost").ToString())
                    '.Add(New ComboListData(.Rows(rowcounter).Item("SupplierName").ToString(), .Rows(rowcounter).Item("SupplierID").ToString()))
                Next
                'cmbUnitPrice.SelectedIndex = 0
            Else
                If Len(txtProductBarcode.Text) > 0 Then
                    'btnNewUnitPrice.Focus()
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

    Private Sub txtFinalDiscount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFinalDiscount.KeyDown
        If (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse e.KeyCode = Keys.Back Then
            acceptableKey = True
        Else
            acceptableKey = False
        End If

        txtNetSales.Text = Convert.ToDouble(IIf(lblTotalAmount.Text = "", 0, lblTotalAmount.Text)) - Convert.ToDouble(IIf(txtFinalDiscount.Text = "", 0, txtFinalDiscount.Text))
        If e.KeyCode = Keys.Enter Then
            txtPayment.SelectAll()
            txtPayment.Focus()
        End If
    End Sub

    Dim strCurrency As String = ""
    Dim acceptableKey As Boolean = False

    Private Sub txtPayment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPayment.KeyDown
        If (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse e.KeyCode = Keys.Back Then
            acceptableKey = True
        Else
            acceptableKey = False
        End If

        If (e.KeyCode = Keys.Enter) Then
            Dim pmt As Double, nsales As Double
            pmt = Convert.ToDouble(txtPayment.Text)
            nsales = Convert.ToDouble(txtNetSales.Text)

            If pmt < nsales Then
                MsgBox("YOU ENTERED SMALLER AMOUNT IN PAYMENT FIELD THAN THE AMOUNT IN THE NET SALES, PLEASE TRY AGAIN. . .")
                txtPayment.Focus()
                Exit Sub
            End If

            'RESET THE NOT_SAVE_FLAG
            NOT_SAVE_FLAG = False

            'INSERT TOTAL TRANSACTION TO tblSalesTransactionTotal
            Call INSERT_TRANSACTION_TO_DATABASE()

            Call PRINT_RECEIPT(OFFICIAL_RECEIPT_NO)

            frmDenomination.lblChange.Text = txtChangeDue.Text
            frmDenomination.ShowDialog()
        End If
    End Sub

    Private Sub PRINT_RECEIPT(ByVal ORNUMBER As String)
        Calling_Form = "PRINT RECEIPT"
        ReportFileName = "rptReceipt.rpt"
        strReportSQL = "Select * from vwReceiptDetails where ORNumber = '" & ORNUMBER & "'"
        Dim frmPrntng As New frmReport

        frmPrntng.WindowState = FormWindowState.Maximized
        frmPrntng.Show()
    End Sub

    Private Sub txtPayment_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPayment.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If acceptableKey = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
            Return
        Else
            If e.KeyChar = Convert.ToChar(Keys.Back) Then
                If strCurrency.Length > 0 Then
                    strCurrency = strCurrency.Substring(0, strCurrency.Length - 1)
                End If
            Else
                strCurrency = strCurrency & e.KeyChar
            End If

            If strCurrency.Length = 0 Then
                txtPayment.Text = ""
            ElseIf strCurrency.Length = 1 Then
                txtPayment.Text = "0.0" & strCurrency
            ElseIf strCurrency.Length = 2 Then
                txtPayment.Text = "0." & strCurrency
            ElseIf strCurrency.Length > 2 Then
                txtPayment.Text = strCurrency.Substring(0, strCurrency.Length - 2) & "." & strCurrency.Substring(strCurrency.Length - 2)
            End If
            txtPayment.Select(txtPayment.Text.Length, 0)

        End If
        e.Handled = True
    End Sub

    Private Sub dgrOrderList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgrOrderList.KeyDown
        If e.KeyCode = Keys.Delete Then
            Call COMPUTE_SKU_TOTALAMOUNT()
        ElseIf (e.Alt = True) And (e.KeyCode = Keys.Enter) Then
            If txtFinalDiscount.Focused Then
                txtPayment.SelectAll()
                txtPayment.Focus()
            Else
                txtFinalDiscount.SelectAll()
                txtFinalDiscount.Focus()
            End If
            Call COMPUTE_SKU_TOTALAMOUNT()
        End If
    End Sub

    Private Sub txtProductDescription_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProductDescription.GotFocus
        txtProductDescription.BackColor = Color.Aqua
    End Sub

    Private Sub txtProductDescription_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProductDescription.LostFocus
        txtProductDescription.BackColor = Color.White
    End Sub

    Private Sub cmbUnitType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUnitType.SelectedIndexChanged

    End Sub

    Private Sub cmbUnitType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUnitType.GotFocus
        cmbUnitType.BackColor = Color.Aqua
    End Sub

    Private Sub cmbUnitType_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUnitType.LostFocus
        cmbUnitType.BackColor = Color.White
    End Sub

    Private Sub cmbUnitPrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUnitPrice.GotFocus
        cmbUnitPrice.BackColor = Color.Aqua
    End Sub

    Private Sub cmbUnitPrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUnitPrice.LostFocus
        cmbUnitPrice.BackColor = Color.White
    End Sub

    Private Sub txtQTYOnHand_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQTYOnHand.GotFocus
        txtQTYOnHand.BackColor = Color.Aqua
    End Sub

    Private Sub txtQTYOnHand_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQTYOnHand.LostFocus
        txtQTYOnHand.BackColor = Color.White
    End Sub

    Private Sub txtDiscount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscount.GotFocus
        txtDiscount.BackColor = Color.Aqua
    End Sub

    Private Sub txtDiscount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscount.LostFocus
        txtDiscount.BackColor = Color.White
    End Sub

    Dim PreviousKeyPressTime As DateTime = Nothing

    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown

        If (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse e.KeyCode = Keys.Back Then
            acceptableKey = True
        Else
            acceptableKey = False
        End If

        If e.KeyCode = Keys.Enter Then
            PreviousKeyPressTime = Nothing
            txtQty.SelectAll()
            txtQty.Focus()
            MsgBox("Press F2 before scanning, thank you!")
        Else
            If PreviousKeyPressTime = Nothing Then
                PreviousKeyPressTime = DateTime.Now
            End If
            Dim startTime As DateTime = Now
            Dim runLength As Global.System.TimeSpan = startTime.Subtract(CType(Me.PreviousKeyPressTime, DateTime))
            Dim millisecs As Integer = runLength.Milliseconds
            Dim secs As Integer = runLength.Seconds
            Dim TotalMiliSecs As Integer = ((secs * 1000) + millisecs)

            If TotalMiliSecs <= 50 Then

            End If
        End If
        PreviousKeyPressTime = DateTime.Now
    End Sub


    Private Sub txtQty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.GotFocus
        txtQty.BackColor = Color.Aqua
    End Sub

    Private Sub txtQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.LostFocus
        txtQty.BackColor = Color.White
    End Sub

    Private Sub txtFinalDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFinalDiscount.TextChanged

    End Sub

    Private Sub txtFinalDiscount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFinalDiscount.GotFocus
        txtFinalDiscount.BackColor = Color.Aqua
    End Sub

    Private Sub txtFinalDiscount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFinalDiscount.LostFocus
        txtFinalDiscount.BackColor = Color.White
    End Sub

    Private Sub txtNetSales_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNetSales.TextChanged

    End Sub

    Private Sub txtNetSales_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNetSales.GotFocus
        txtNetSales.BackColor = Color.Aqua
    End Sub

    Private Sub txtNetSales_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNetSales.LostFocus
        txtNetSales.BackColor = Color.White
    End Sub

    Private Sub txtNoOfItems_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoOfItems.TextChanged

    End Sub

    Private Sub txtNoOfItems_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoOfItems.GotFocus
        txtNoOfItems.BackColor = Color.Aqua
    End Sub

    Private Sub txtNoOfItems_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoOfItems.LostFocus
        txtNoOfItems.BackColor = Color.White
    End Sub

    Private Sub txtChangeDue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChangeDue.TextChanged

    End Sub

    Private Sub txtChangeDue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChangeDue.GotFocus
        txtChangeDue.BackColor = Color.Aqua
    End Sub

    Private Sub txtChangeDue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChangeDue.LostFocus
        txtChangeDue.BackColor = Color.White
    End Sub

    Private Sub txtPayment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPayment.TextChanged
        txtNetSales.Text = Convert.ToDouble(IIf(lblTotalAmount.Text = "", 0, lblTotalAmount.Text)) - Convert.ToDouble(IIf(txtFinalDiscount.Text = "", 0, txtFinalDiscount.Text))
        txtChangeDue.Text = Convert.ToDouble(IIf(txtPayment.Text = "", 0, txtPayment.Text)) - Convert.ToDouble(txtNetSales.Text)
        txtChangeDue.Text = FormatNumber(txtChangeDue.Text, 2, , , TriState.True)
    End Sub

    Private Sub txtPayment_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPayment.GotFocus
        txtPayment.BackColor = Color.Aqua
    End Sub

    Private Sub txtPayment_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPayment.LostFocus
        txtPayment.BackColor = Color.White

    End Sub

    Private Sub txtQty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.Validated
        If Len(txtQty.Text) > 0 Then
            If Not IsNumeric(txtQty.Text) Then
                MsgBox("NOT A NUMBER!")
                txtQty.Focus()
                Exit Sub
            End If
            txtQty.Text = FormatNumber(txtQty.Text, 0, , , TriState.True)
        Else
            txtQty.Text = "0"
        End If
    End Sub

    Private Sub txtPayment_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPayment.Validated
        If Len(txtPayment.Text) > 0 Then
            If Not IsNumeric(txtPayment.Text) Then
                MsgBox("NOT A NUMBER!")
                txtPayment.Focus()
                Exit Sub
            End If
            txtPayment.Text = FormatNumber(txtPayment.Text, 2, , , TriState.True)
        Else
            txtPayment.Text = "0.00"
        End If
    End Sub

    Private Sub txtFinalDiscount_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFinalDiscount.Validated
        If Len(txtFinalDiscount.Text) > 0 Then
            If Not IsNumeric(txtFinalDiscount.Text) Then
                MsgBox("NOT A NUMBER!")
                txtFinalDiscount.Focus()
                Exit Sub
            End If
            txtFinalDiscount.Text = FormatNumber(txtFinalDiscount.Text, 2, , , TriState.True)
        Else
            txtFinalDiscount.Text = "0.00"
        End If
    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If acceptableKey = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
            Return
        End If
    End Sub

    Private Sub txtFinalDiscount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFinalDiscount.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If acceptableKey = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
            Return
        End If
    End Sub

    Private Sub INSERT_TRANSACTION_TO_DATABASE()
        Dim pid, ttime As String
        Dim qty As Long
        Dim dv, amt As Double

        Dim item_discount As Double = IIf(txtDiscount.Text = "", 0, Val(txtDiscount.Text))
        'Dim strVALUES As String = "productDescription='" & Replace(Replace(txtProductDescription.Text, "'", "''"), """", """") & "',UnitName='" & Replace(cmbUnitType.Text, "'", "''") & "',CategoryName='" & Replace(cmbCategory.Text, "'", "''") & "',UnitPriceCode=" & unitPriceCode & ",ProductDiscount=" & item_discount & ",QtyOnHand=" & txtQTYOnHand.Text & ",reorderpoint=" & txtReorderPoint.Text & ",SupplierID=" & SupplierID & ""
        'Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("tblPRODUCT", strVALUES, "ProductID_Barcode='" & txtProductBarcode.Text & "'")
        'Dim strVALUES As String = "'" & Replace(txtProductBarcode.Text, "'", "''") & "','" & Replace(Replace(txtProductDescription.Text, "'", "''"), """", """") & "','" & Replace(cmbUnitType.Text, "'", "''") & "','" & Replace(cmbCategory.Text, "'", "''") & "'," & unitPriceCode & "," & item_discount & "," & txtQTYOnHand.Text & "," & txtReorderPoint.Text & "," & SupplierID & ""

        'COMPUTE VAT SALES
        Dim VatSales As Double = Convert.ToDouble(txtNetSales.Text) / 1.12

        'SAVE THE SALES INFO TO tblSalesTransactionTotal
        Dim strVALUES As String = "'" & OFFICIAL_RECEIPT_NO & "','" & lblTotalAmount.Text & "','" & Replace(txtFinalDiscount.Text, "", "0") & "','" & txtNetSales.Text & "','" & txtNoOfItems.Text & "'," & txtPayment.Text & "," & txtChangeDue.Text & "," & USER_ID_LOGGED & ",'" & Date.Now() & "','" & VatSales & "'"
        Call INSERT_DATA_TO_DATABASE("tblSalesTransactionTotal", "ORNUMBER,TotalAmount,SalesDiscount,NetSales,NoOfItems,Payment,Change,EmployeesID,TransactionDate,VATSALES", strVALUES)

        'SAVE THE SALES TRANSACTION DETAILS
        For xyx = 0 To dgrOrderList.Rows.Count - 2
            '{ProductDesciption, unitprice, QTY, FormatCurrency(ItemAmount, 2), Discount, Barcode, Transtime}
            With dgrOrderList
                ttime = .Rows(xyx).Cells(6).Value.ToString()
                qty = .Rows(xyx).Cells(2).Value.ToString()
                dv = .Rows(xyx).Cells(4).Value.ToString()
                amt = .Rows(xyx).Cells(3).Value.ToString()
                pid = .Rows(xyx).Cells(5).Value.ToString()

                strVALUES = "'" & OFFICIAL_RECEIPT_NO & "','" & pid & "','" & qty & "','" & dv & "','" & amt & "','" & ttime & "'"

                'UPDATE QUANTITY ON HAND (QtyOnHand, QtyOut) in tblProduct
                Dim strfldNamefldValues As String
                Dim PrevQtyOnHand As Long = getFIELD_VALUE_FROM_DBASE("tblProduct", "QtyOnHand", "ProductID_Barcode", pid)
                Dim CurrentQtyOnHand As Long = PrevQtyOnHand - qty
                strfldNamefldValues = "QtyOnHand='" & CurrentQtyOnHand & "',QtyOut='" & qty & "'"
                Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("tblProduct", strfldNamefldValues, "ProductID_Barcode='" & pid & "'")
                'INSERT CURRENT ITEM TRANSACTION TO DATABASE.
                Call INSERT_DATA_TO_DATABASE("tblSalesTransaction", "ORNumber,ProductID_Barcode,Quantity,DiscountValue,Amount,TransactionTime", strVALUES)
            End With
        Next
    End Sub

    Private Sub LoadReoderPointToCombo()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT     ProductDescription, QtyOnHand  FROM tblProduct  WHERE reorderpoint >= QtyOnHand ORDER BY QtyOnHand, ProductDescription", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                cmbRoPoint.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    cmbRoPoint.Items.Add(.Rows(rowcounter).Item("ProductDescription").ToString() & " / QuantityOnHand : " & .Rows(rowcounter).Item("QtyOnHand").ToString())
                Next
            End If
        End With
        tmrPOR.Enabled = True
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Dim rowcounter2 As Integer
    Dim pbcounter As Integer = 6

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPOR.Tick
        tmrPOR.Interval = 2000
        rowcounter2 = rowcounter2 + 1
        With cmbRoPoint
            If .Items.Count > 0 Then
                If rowcounter2 >= .Items.Count Then
                    rowcounter2 = 0
                    LoadReoderPointToCombo()
                    Exit Sub
                End If
                lblReorderPOint.Text = "     Item that reaches the point of reorder   ==>>  " & .Items(rowcounter2).ToString
                lblReorderPOint.ForeColor = Color.Maroon
                lblReorderPOint.Visible = True

            End If
        End With
       
    End Sub
    Dim updown As String = "DOWN"
   
    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If pbcounter = 6 Then
            ' updown = "DOWN"
            'PictureBox6.BackgroundImage = GTH_POSSystem.My.Resources.Resources.square_go
            PictureBox6.BorderStyle = BorderStyle.Fixed3D
        Else
            PictureBox6.BackgroundImage = Nothing
            PictureBox6.BorderStyle = BorderStyle.None
        End If
        If pbcounter = 7 Then
            'PictureBox7.BackgroundImage = GTH_POSSystem.My.Resources.Resources.square_go
            PictureBox7.BorderStyle = BorderStyle.Fixed3D
        Else
            'PictureBox7.BackgroundImage = Nothing
            PictureBox7.BorderStyle = BorderStyle.None
        End If
        If pbcounter = 8 Then
            'PictureBox8.BackgroundImage = GTH_POSSystem.My.Resources.Resources.square_go
            PictureBox8.BorderStyle = BorderStyle.Fixed3D
        Else
            'PictureBox8.BackgroundImage = Nothing
            PictureBox8.BorderStyle = BorderStyle.None
        End If
        If pbcounter = 9 Then
            'PictureBox9.BackgroundImage = GTH_POSSystem.My.Resources.Resources.square_go
            PictureBox9.BorderStyle = BorderStyle.Fixed3D
        Else
            'PictureBox9.BackgroundImage = Nothing
            PictureBox9.BorderStyle = BorderStyle.None
        End If
        If pbcounter = 10 Then
            ' PictureBox10.BackgroundImage = GTH_POSSystem.My.Resources.Resources.square_go
            PictureBox10.BorderStyle = BorderStyle.Fixed3D
        Else
            'PictureBox10.BackgroundImage = Nothing
            PictureBox10.BorderStyle = BorderStyle.None
        End If
        If pbcounter = 11 Then
            ' PictureBox11.BackgroundImage = GTH_POSSystem.My.Resources.Resources.square_go
            PictureBox11.BorderStyle = BorderStyle.Fixed3D
        Else
            'PictureBox11.BackgroundImage = Nothing
            PictureBox11.BorderStyle = BorderStyle.None
        End If
        If pbcounter = 12 Then
            ' PictureBox12.BackgroundImage = GTH_POSSystem.My.Resources.Resources.square_go
            PictureBox12.BorderStyle = BorderStyle.Fixed3D
        Else
            'PictureBox12.BackgroundImage = Nothing
            PictureBox12.BorderStyle = BorderStyle.None
        End If
        If pbcounter = 13 Then
            ' PictureBox13.BackgroundImage = GTH_POSSystem.My.Resources.Resources.square_go
            PictureBox13.BorderStyle = BorderStyle.Fixed3D
            ' pbcounter = 5
        Else
            'PictureBox13.BackgroundImage = Nothing
            PictureBox13.BorderStyle = BorderStyle.None
        End If
        If updown = "DOWN" Then
            pbcounter = pbcounter + 1
            If pbcounter = 13 Then
                updown = "UP"
            End If

        ElseIf updown = "UP" Then
            pbcounter = pbcounter - 1
            If pbcounter < 6 Then
                pbcounter = 6
                updown = "DOWN"
            End If
        End If
        Timer1.Interval = 500
    End Sub

    Private Sub txtProductBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductBarcode.TextChanged

    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click

    End Sub
End Class