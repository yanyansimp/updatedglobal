
Imports System.Data.SqlClient


Public Class frmPriceDiscountAdjustment

#Region "CommonFunctions"
    Private conn As New SqlClient.SqlConnection("Data Source=server_jbg; Initial Catalog=POS;Integrated Security=True;")
    Private ComDset As New DataSet
    Private ComDset1 As New DataSet
    Private LeaderID As Long
    Private MemberID As Long
    Private rMoveVal As Boolean = False

    Dim CurrentRowIndex As Integer = 0
#End Region

    Private Sub LoadProductListing_byBarcode(ByVal bcode As String)
        Dim rowcounter As Integer
        If rbtnSearcByDescription.Checked Then
            sqladapter = New SqlClient.SqlDataAdapter("SELECT     trnno,ProductDesciption, ProductID_Barcode, Price, PurchaseCost, DateEntered, SetDefault, QTYOnHand,ProductDiscount " _
                                                 & " FROM         (SELECT     trnno, ProductID_Barcode, Price, PurchaseCost, DateEntered, SetDefault, " _
                                                 & " (SELECT     TOP (1) ProductDescription        FROM tblProduct " _
                                                 & " WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS ProductDesciption," _
                                                 & "  (SELECT     TOP (1) QtyOnHand      FROM          tblProduct AS Product_1 " _
                                                 & "   WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS QTYOnHand, " _
                                                 & " (SELECT     TOP (1) ProductDiscount     FROM          tblProduct AS Product_1 " _
                                                 & "   WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS ProductDiscount " _
                                                 & " FROM          tblPriceHistory) AS derivedtbl_1 " _
                                                 & " WHERE     (ProductDesciption LIKE '%" & bcode & "%') order by ProductDesciption,trnno desc", conn)
        Else
            sqladapter = New SqlClient.SqlDataAdapter("SELECT     trnno, ProductDesciption, ProductID_Barcode, Price, PurchaseCost, DateEntered, SetDefault,QTYOnHand,ProductDiscount " _
                                                 & " FROM         (SELECT     trnno, ProductID_Barcode, Price, PurchaseCost, DateEntered, SetDefault, " _
                                                 & " (SELECT     TOP (1) ProductDescription        FROM tblProduct " _
                                                 & " WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS ProductDesciption," _
                                                 & "  (SELECT     TOP (1) QtyOnHand      FROM          tblProduct AS Product_1 " _
                                                 & "   WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS QTYOnHand, " _
                                                 & " (SELECT     TOP (1) ProductDiscount     FROM          tblProduct AS Product_1 " _
                                                 & "   WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS ProductDiscount " _
                                                 & " FROM          tblPriceHistory) AS derivedtbl_1 " _
                                                 & " WHERE     (ProductID_Barcode LIKE '" & bcode & "%') order by ProductDesciption,trnno desc", conn)
        End If
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

    Private Sub LoadProductListingadsf()
        Dim rowcounter As Integer
        If rbtnSearcByDescription.Checked Then
            sqladapter = New SqlClient.SqlDataAdapter("SELECT     trnno,ProductDesciption, ProductID_Barcode, Price, PurchaseCost, DateEntered, SetDefault, QTYOnHand,ProductDiscount " _
                                                 & " FROM         (SELECT     trnno, ProductID_Barcode, Price, PurchaseCost, DateEntered, SetDefault, " _
                                                 & " (SELECT     TOP (1) ProductDescription        FROM tblProduct " _
                                                 & " WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS ProductDesciption," _
                                                 & "  (SELECT     TOP (1) QtyOnHand      FROM          tblProduct AS Product_1 " _
                                                 & "   WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS QTYOnHand, " _
                                                 & " (SELECT     TOP (1) ProductDiscount     FROM          tblProduct AS Product_1 " _
                                                 & "   WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS ProductDiscount " _
                                                 & " FROM          tblPriceHistory) AS derivedtbl_1 " _
                                                 & " WHERE     (ProductDesciption LIKE '%" & txtSearch.Text & "%') order by ProductDesciption,trnno desc", conn)
        Else
            sqladapter = New SqlClient.SqlDataAdapter("SELECT     trnno, ProductDesciption, ProductID_Barcode, Price, PurchaseCost, DateEntered, SetDefault,QTYOnHand,ProductDiscount " _
                                                 & " FROM         (SELECT     trnno, ProductID_Barcode, Price, PurchaseCost, DateEntered, SetDefault, " _
                                                 & " (SELECT     TOP (1) ProductDescription        FROM tblProduct " _
                                                 & " WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS ProductDesciption," _
                                                 & "  (SELECT     TOP (1) QtyOnHand      FROM          tblProduct AS Product_1 " _
                                                 & "   WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS QTYOnHand, " _
                                                 & " (SELECT     TOP (1) ProductDiscount     FROM          tblProduct AS Product_1 " _
                                                 & "   WHERE      (ProductID_Barcode = tblPriceHistory.ProductID_Barcode)) AS ProductDiscount " _
                                                 & " FROM          tblPriceHistory) AS derivedtbl_1 " _
                                                 & " WHERE     (ProductID_Barcode LIKE '%" & txtSearch.Text & "%') order by ProductDesciption,trnno desc", conn)
        End If
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

    Public Sub change_bkGround(ByVal xxx As Color)
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
            ElseIf TypeOf cleaner Is CheckBox Then
                CheckBox1.Checked = False
            End If
        Next
    End Sub

    Private Sub change_ReadOnly(ByVal xReadOnly As Boolean)
        txtDiscount.ReadOnly = xReadOnly
        txtPurchaseCost.ReadOnly = xReadOnly
        txtSellingPrice.ReadOnly = xReadOnly
    End Sub


    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If btnNew.Text = "&New" Then
            'MsgBox("Adding New Price is not allowed in this module, Please select the item in the list click Edit then Save.")
            'Exit Sub
            Call change_bkGround(Color.White)
            Call clearControls()
            btnClose.Text = "&Cancel"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnSave.Text = "&Save"
            btnSave.Enabled = True
            ''get the highest SupplierID from table Supplier
            'txtProductID.Text = getFieldMaxCount("Supplier", "SupplierID") + 1
            'txtProdDescription.Focus()
        Else
            Call change_bkGround(Color.White)
            btnClose.Text = "&Cancel"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnSave.Text = "&Save"
            btnSave.Enabled = True
        End If
        Call change_ReadOnly(False)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "&Update" Then
            Dim strVALUES As String = "Price ='" & Replace(txtSellingPrice.Text, " '", "''") & "',PurchaseCost='" & Replace(txtPurchaseCost.Text, "'", "''") & "',DateEntered='" & Now() & "',SetDefault='" & IIf(CheckBox1.Checked, 1, 0) & "'"
            Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("tblPriceHistory", strVALUES, "trnno=" & txtProductID.Text & "")
            'update the discount field from tblPRoduct
            Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("TBLPRODUCT", "PRODUCTDISCOUNT=" & txtDiscount.Text, "ProductID_Barcode='" & txtProductID.Text & "'")
        Else
            Dim strVALUES As String = "'" & Replace(txtProductID.Text, "'", "''") & "','" & Replace(txtSellingPrice.Text, "'", "''") & "','" & Replace(txtPurchaseCost.Text, "'", "''") & "','" & Now() & "','" & IIf(CheckBox1.Checked, 1, 0) & "'"
            'call the function that will update (all items with prices) the SETDEFAULT=0 price datafield
            Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("TBLPRICEHISTORY", "SETDEFAULT=0", "ProductID_Barcode='" & txtProductID.Text & "'")
            'now insert the values to TBLPRICEHISTORY
            Call INSERT_DATA_TO_DATABASE("TBLPRICEHISTORY", "PRODUCTID_BARCODE,PRICE,PURCHASECOST,DATEENTERED,SETDEFAULT", strVALUES)
            'update the discount field from tblPRoduct
            Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("TBLPRODUCT", "PRODUCTDISCOUNT=" & txtDiscount.Text, "ProductID_Barcode='" & txtProductID.Text & "'")
        End If
        Call LoadProductListing_byBarcode(txtProductID.Text)
        btnNew.Enabled = True
        btnSave.Text = "&Save"
        btnClose.Text = "&Close"
        btnSave.Enabled = False
        Call clearControls()
        Call change_bkGround(Color.BurlyWood)
        'set all entry controls to read only mode
        Call change_ReadOnly(True)
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

    Private Sub frmPriceDiscountAdjustment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'txtProductID.Text = frmProductRegistration.txtProductBarcode.Text
        Call LoadProductListing_byBarcode(txtProductID.Text)
        If Calling_Form = "frmStocksEntryForm" Then
            txtSearch.Focus()
        End If
    End Sub

    Private Sub DataGridView1_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Rows.Count > 0 Then
            With DataGridView1
                Try
                    If Me.DataGridView1.SelectedRows.Count > 0 Then ' AndAlso Not Me.DataGridView1.SelectedRows(0).Index = Me.DataGridView1.Rows.Count - 1 Then
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        txtProductID.Text = .Item(2, .CurrentCellAddress.Y).Value
                        txtDiscount.Text = .Item(8, .CurrentCellAddress.Y).Value
                        txtPurchaseCost.Text = .Item(4, .CurrentCellAddress.Y).Value
                        txtSellingPrice.Text = .Item(3, .CurrentCellAddress.Y).Value
                        CheckBox1.Checked = .Item(6, .CurrentCellAddress.Y).Value
                        CurrentRowIndex = .CurrentRow.Index
                        .EditMode = DataGridViewEditMode.EditProgrammatically
                        btnSave.Text = "&Save"
                        btnClose.Text = "&Cancel"
                        btnNew.Text = "&Edit"
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
        End If
        btnNew.Enabled = True
    End Sub

    Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
            With DataGridView1
                Try
                    If Me.DataGridView1.SelectedRows.Count > 0 Then 'AndAlso Not Me.DataGridView1.SelectedRows(0).Index = Me.DataGridView1.Rows.Count - 1 Then

                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect

                        txtProductID.Text = .Item(2, .CurrentCellAddress.Y).Value
                        txtDiscount.Text = .Item(8, .CurrentCellAddress.Y).Value
                        txtPurchaseCost.Text = .Item(4, .CurrentCellAddress.Y).Value
                        txtSellingPrice.Text = .Item(3, .CurrentCellAddress.Y).Value
                        CheckBox1.Checked = .Item(6, .CurrentCellAddress.Y).Value
                        CurrentRowIndex = .CurrentRow.Index
                        .EditMode = DataGridViewEditMode.EditProgrammatically
                        btnSave.Text = "&Save"
                        btnClose.Text = "&Cancel"
                        btnNew.Text = "&Edit"
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
        ElseIf e.KeyCode = Keys.Up And DataGridView1.SelectedRows(0).Index <= 0 Then
            txtSearch.Focus()

        ElseIf e.KeyCode = Keys.Enter Then
        If Me.DataGridView1.SelectedRows.Count > 0 AndAlso _
                   Not Me.DataGridView1.SelectedRows(0).Index = _
                   Me.DataGridView1.Rows.Count - 1 Then
            btnNew_Click(sender, e)
        End If
        End If
        btnNew.Enabled = True
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Call LoadProductListing_byBarcode(txtSearch.Text)
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(sender, e)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub rbtnSearchByBarcode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnSearchByBarcode.CheckedChanged

    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(sender, e)
        ElseIf e.KeyCode = Keys.Down Then
            DataGridView1.Focus()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Up And DataGridView1.SelectedRows(0).Index <= 0 Then
            txtSearch.Focus()
        End If
    End Sub
End Class