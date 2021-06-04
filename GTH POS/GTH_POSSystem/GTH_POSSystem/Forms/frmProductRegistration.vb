
Imports System.Data.SqlClient


Public Class frmProductRegistration

#Region "CommonFunctions"
    Private conn As New SqlClient.SqlConnection("Data Source=server_jbg; Initial Catalog=POS;Integrated Security=True;")
    Private ComDset As New DataSet
    Private ComDset1 As New DataSet
    Private LeaderID As Long
    Private MemberID As Long
    Private rMoveVal As Boolean = False

    Dim CurrentRowIndex As Integer = 0
#End Region

    Dim SupplierID As Long
    Dim unitPriceCode As Long
    Dim PrevBCODE As String

    Private Sub LoadProductListing_byBarcode(ByVal bcode As String)
        Dim rowcounter As Integer
        If rbtnSearcByDescription.Checked Then
            sqladapter = New SqlClient.SqlDataAdapter("SELECT     ProductID_Barcode AS BARCODE, ProductDescription AS DESCRIPTION, (SELECT     TOP 1 Price " _
                                                & " FROM tblPriceHistory    WHERE      SetDefault = 1 AND trnno = tblProduct.UnitPriceCode) AS PRICE, (SELECT     TOP 1 PurchaseCost " _
                                                & " FROM tblPriceHistory    WHERE      SetDefault = 1 AND trnno = tblProduct.UnitPriceCode) AS PurchaseCost, UnitName AS UNIT, QtyOnHand AS QTYOnHand, " _
                                                & " (SELECT     TOP 1 DateEntered          FROM          tblPriceHistory AS tblPriceHistory_1 " _
                                                & " WHERE      SetDefault = 1 AND trnno = tblProduct.UnitPriceCode) AS DateEntered,   (SELECT     TOP 1 SetDefault " _
                                                & " FROM          tblPriceHistory AS tblPriceHistory_2  WHERE      SetDefault = 1 AND trnno = tblProduct.UnitPriceCode) AS SetDefault, ProductDiscount, reorderpoint, SupplierID, CategoryName " _
                                                & " FROM  tblProduct " _
                                                & " WHERE    (ProductDescription LIKE '%" & bcode & "%')   order by ProductDescription", conn)
        Else
            sqladapter = New SqlClient.SqlDataAdapter("SELECT     ProductID_Barcode AS BARCODE, ProductDescription AS DESCRIPTION, (SELECT     TOP 1 Price " _
                                                & " FROM tblPriceHistory    WHERE      SetDefault = 1 AND trnno = tblProduct.UnitPriceCode) AS PRICE, (SELECT     TOP 1 PurchaseCost " _
                                                & " FROM tblPriceHistory    WHERE      SetDefault = 1 AND trnno = tblProduct.UnitPriceCode) AS PurchaseCost, UnitName AS UNIT, QtyOnHand AS QTYOnHand, " _
                                                & " (SELECT     TOP 1 DateEntered          FROM          tblPriceHistory AS tblPriceHistory_1 " _
                                                & " WHERE      SetDefault = 1 AND trnno = tblProduct.UnitPriceCode) AS DateEntered,   (SELECT     TOP 1 SetDefault " _
                                                & " FROM          tblPriceHistory AS tblPriceHistory_2  WHERE      SetDefault = 1 AND trnno = tblProduct.UnitPriceCode) AS SetDefault, ProductDiscount, reorderpoint, SupplierID, CategoryName " _
                                                & " FROM  tblProduct " _
                                                & " WHERE     (ProductID_Barcode LIKE '%" & bcode & "%')  order by ProductDescription", conn)
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
            Else
                DataGridView1.Columns.Clear()
                If MsgBox("No Record Found!" & Chr(13) & Chr(13) & "Add this Item to database?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "No Record Found. . .") = MsgBoxResult.Yes Then
                    txtProductDescription.Focus()
                    Exit Sub
                Else
                    Call clearControls()
                    btnNew.Enabled = True
                    btnClose.Text = "&Close"
                    btnSave.Text = "&Save"
                    btnNew.Text = "&New"
                    Call change_bkGround(Color.BurlyWood)
                    Call clearControls()
                    'set all entry controls to read only mode
                    Call change_ReadOnly(True)
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
                    'MsgBox(item.ItemData.ToString)
                    unitPriceCode = item.ItemData.ToString
                    GoTo exit_loop2
                End If
            Next
        Catch
            MsgBox(Err.Description)
        End Try
exit_loop2:
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

    Private Sub LoadCategoryToCombo()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("Select CategoryID,CategoryName from tblCategory order by CategoryName", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                cmbCategory.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    cmbCategory.Items.Add(.Rows(rowcounter).Item("CategoryName").ToString())
                Next
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
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

    Private Sub LoadProductListing(ByVal strBarcodes As String)
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT     ProductID_Barcode AS BARCODE, ProductDescription AS DESCRIPTION, (SELECT     TOP 1 Price " _
                                                & " FROM tblPriceHistory    WHERE      SetDefault = 1 AND trnno = tblProduct.UnitPriceCode) AS PRICE, (SELECT     TOP 1 PurchaseCost " _
                                                & " FROM tblPriceHistory    WHERE      SetDefault = 1 AND trnno = tblProduct.UnitPriceCode) AS PurchaseCost, UnitName AS UNIT, QtyOnHand AS QTYOnHand, " _
                                                & " (SELECT     TOP 1 DateEntered          FROM          tblPriceHistory AS tblPriceHistory_1 " _
                                                & " WHERE      SetDefault = 1 AND trnno = tblProduct.UnitPriceCode) AS DateEntered,   (SELECT     TOP 1 SetDefault " _
                                                & " FROM          tblPriceHistory AS tblPriceHistory_2  WHERE      SetDefault = 1 AND trnno = tblProduct.UnitPriceCode) AS SetDefault, ProductDiscount, reorderpoint, SupplierID, CategoryName " _
                                                & " FROM  tblProduct " _
                                                 & " WHERE     (ProductDescription LIKE '%" & strBarcodes & "%') order by ProductDescription", conn)
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

    Public Sub clearControls()
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
        cmbCategory.SelectedIndex = -1
        cmbPurchaseCost.SelectedIndex = -1
        cmbSupplier.SelectedIndex = -1
        cmbUnitPrice.SelectedIndex = -1
        cmbUnitType.SelectedIndex = -1
    End Sub

    Private Sub change_ReadOnly(ByVal xReadOnly As Boolean)
        txtProductDescription.ReadOnly = xReadOnly
        txtQTYOnHand.ReadOnly = xReadOnly
        ' txtUnitPrice.ReadOnly = xReadOnly
        'cmbPurchaseCost.re = xReadOnly
        txtReorderPoint.ReadOnly = xReadOnly
    End Sub


    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If btnNew.Text = "&New" Then
            Call change_bkGround(Color.White)
            Call clearControls()
            btnClose.Text = "&Cancel"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnSave.Text = "&Save"
            btnSave.Enabled = True
            'get the highest SupplierID from table Supplier
            'txtProductBarcode.Text = getFieldMaxCount("Supplier", "SupplierID") + 1
            txtProductBarcode.Focus()
        Else
            Call change_bkGround(Color.White)
            btnClose.Text = "&Cancel"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnSave.Text = "&Update"
            btnSave.Enabled = True
            txtProductDescription.Focus()
        End If
        Call change_ReadOnly(False)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Call getSupplierIDFromComboBOx()
            Call getUnitPriceIDFromComboBOx()
            Dim item_discount As Double = IIf(txtDiscount.Text = "", 0, Val(txtDiscount.Text))
            If btnSave.Text = "&Update" Then
                Dim strVALUES As String = "ProductID_Barcode='" & Replace(Replace(txtProductBarcode.Text, "'", "''"), """", """") & "',productDescription='" & Replace(Replace(txtProductDescription.Text, "'", "''"), """", """") & "',UnitName='" & Replace(cmbUnitType.Text, "'", "''") & "',CategoryName='" & Replace(cmbCategory.Text, "'", "''") & "',UnitPriceCode=" & unitPriceCode & ",ProductDiscount=" & item_discount & ",QtyOnHand=" & txtQTYOnHand.Text & ",reorderpoint=" & txtReorderPoint.Text & ",SupplierID=" & SupplierID & ""
                Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("tblPRODUCT", strVALUES, "ProductID_Barcode='" & PrevBCODE & "'")
                'update the price history table (tblPriceHistory)
                strVALUES = "ProductID_Barcode = '" & Replace(Replace(txtProductBarcode.Text, "'", "''"), """", """") & "'"
                Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("tblPriceHistory", strVALUES, "ProductID_Barcode='" & PrevBCODE & "'")
            Else
                Dim strVALUES As String = "'" & Replace(txtProductBarcode.Text, "'", "''") & "','" & Replace(Replace(txtProductDescription.Text, "'", "''"), """", """") & "','" & Replace(cmbUnitType.Text, "'", "''") & "','" & Replace(cmbCategory.Text, "'", "''") & "'," & unitPriceCode & "," & item_discount & "," & txtQTYOnHand.Text & "," & txtReorderPoint.Text & "," & SupplierID & ""
                Call INSERT_DATA_TO_DATABASE("tblPRODUCT", "ProductID_Barcode,ProductDescription,UnitName,CategoryName,UnitPriceCode,ProductDiscount,QtyOnHand,reorderpoint,SupplierID", strVALUES)

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
            LoadProductListing_byBarcode(txtProductBarcode.Text)
        Catch
            MsgBox(Err.Description)
            Exit Sub
        End Try
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

    Private Sub frmProductRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LoadProductListing(txtProductBarcode.Text)
        Call LoadUnitPriceToCombo(txtProductBarcode.Text)
        Call LoadCategoryToCombo()
        Call LoadUnitTypeToCombo()
        Call LoadSuppliersToCombo()
        Me.KeyPreview = True
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
                        PrevBCODE = txtProductBarcode.Text
                        txtProductDescription.Text = .Item(1, .CurrentCellAddress.Y).Value
                        txtQTYOnHand.Text = .Item(5, .CurrentCellAddress.Y).Value
                        Call LoadUnitPriceToCombo(txtProductBarcode.Text)
                        cmbUnitPrice.Text = .Item(2, .CurrentCellAddress.Y).Value
                        cmbPurchaseCost.Text = .Item(3, .CurrentCellAddress.Y).Value
                        cmbUnitType.Text = .Item(4, .CurrentCellAddress.Y).Value
                        cmbCategory.Text = .Item(11, .CurrentCellAddress.Y).Value
                        txtReorderPoint.Text = .Item(9, .CurrentCellAddress.Y).Value
                        cmbSupplier.Text = getFIELD_VALUE_FROM_DBASE("tblSupplier", "SupplierName", "SupplierID", .Item(9, .CurrentCellAddress.Y).Value)
                        CurrentRowIndex = .CurrentRow.Index
                        .EditMode = DataGridViewEditMode.EditProgrammatically
                        btnSave.Text = "&Update"
                        btnClose.Text = "&Cancel"
                        btnNew.Text = "&Edit"
                    Else
                        btnNew.Text = "&New"
                        .EndEdit()
                    End If
                Catch
                    MsgBox(Err.Description)
                    btnSave.Text = "&Update"
                    btnClose.Text = "&Cancel"
                    btnNew.Text = "&Edit"
                    Exit Sub
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

                        txtProductBarcode.Text = .Item(0, .CurrentCellAddress.Y).Value
                        PrevBCODE = txtProductBarcode.Text
                        txtProductDescription.Text = .Item(1, .CurrentCellAddress.Y).Value
                        txtQTYOnHand.Text = .Item(2, .CurrentCellAddress.Y).Value
                        Call LoadUnitPriceToCombo(txtProductBarcode.Text)
                        cmbUnitPrice.Text = .Item(4, .CurrentCellAddress.Y).Value
                        cmbPurchaseCost.Text = .Item(5, .CurrentCellAddress.Y).Value
                        cmbUnitType.Text = .Item(3, .CurrentCellAddress.Y).Value
                        cmbCategory.Text = .Item(11, .CurrentCellAddress.Y).Value
                        txtReorderPoint.Text = .Item(9, .CurrentCellAddress.Y).Value
                        cmbSupplier.Text = getFIELD_VALUE_FROM_DBASE("tblSupplier", "SupplierName", "SupplierID", .Item(10, .CurrentCellAddress.Y).Value)
                        CurrentRowIndex = .CurrentRow.Index
                        .EditMode = DataGridViewEditMode.EditProgrammatically
                        btnSave.Text = "&Update"
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
        ElseIf e.KeyCode = Keys.Enter Then
            If Me.DataGridView1.SelectedRows.Count > 0 AndAlso _
                       Not Me.DataGridView1.SelectedRows(0).Index = _
                       Me.DataGridView1.Rows.Count - 1 Then
                btnNew_Click(sender, e)
            End If
        End If
        btnNew.Enabled = True
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call LoadProductListing(txtSearch.Text)
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(sender, e)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

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
                        PrevBCODE = txtProductBarcode.Text
                        txtProductDescription.Text = .Item(1, .CurrentCellAddress.Y).Value
                        txtQTYOnHand.Text = .Item(2, .CurrentCellAddress.Y).Value
                        'txtContactTitle.Text = .Item(3, .CurrentCellAddress.Y).Value
                        'txtUnitPrice.Text = .Item(4, .CurrentCellAddress.Y).Value
                        'txtTelNo.Text = .Item(5, .CurrentCellAddress.Y).Value
                        cmbPurchaseCost.Text = .Item(6, .CurrentCellAddress.Y).Value
                        'txtUnitType.Text = .Item(7, .CurrentCellAddress.Y).Value
                        txtReorderPoint.Text = .Item(8, .CurrentCellAddress.Y).Value
                        CurrentRowIndex = .CurrentRow.Index
                        .EditMode = DataGridViewEditMode.EditProgrammatically
                        btnSave.Text = "&Update"
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
        End If
    End Sub


    Private Sub txtProductBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductBarcode.KeyDown
        Dim bbcode As String = txtProductBarcode.Text

        If e.KeyCode = Keys.Enter Then
            rbtnSearchByBarcode.Checked = True
            Call clearControls()
            txtProductBarcode.Text = bbcode
            Call LoadProductListing_byBarcode(txtProductBarcode.Text)
            '--------------------------------------------------------------- code from datagridview1_cellclick---------------------------------------------------------------------
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
                            cmbCategory.Text = .Item(11, .CurrentCellAddress.Y).Value
                            txtReorderPoint.Text = .Item(9, .CurrentCellAddress.Y).Value
                            cmbSupplier.Text = getFIELD_VALUE_FROM_DBASE("tblSupplier", "SupplierName", "SupplierID", .Item(10, .CurrentCellAddress.Y).Value)
                            CurrentRowIndex = .CurrentRow.Index
                            .EditMode = DataGridViewEditMode.EditProgrammatically
                            'btnSave.Text = "&Update"
                            'btnClose.Text = "&Cancel"
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
                '''''Call change_ReadOnly(True)
            End If
            'btnNew.Enabled = False 'do not allow new button to be clicked, it was already click even before a barcode was scanned
            '-------------------------------------------------------------------------------------------------------------------------------------------------------------
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

    Private Sub btnAddNewSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewSupplier.Click
        Dim frm As New frmCustomerRegistration
        frm.ShowDialog()
    End Sub

    Private Sub btnAddCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCategory.Click
        Dim frm As New frmCategory
        frm.ShowDialog()
    End Sub

    Private Sub btnSearch_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Call LoadProductListing_byBarcode(txtSearch.Text)
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


    Private Sub cmbCategory_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCategory.GotFocus
        Call LoadCategoryToCombo()
    End Sub

    Private Sub cmbSupplier_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSupplier.GotFocus
        LoadSuppliersToCombo()
    End Sub

    Private Sub cmbUnitType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUnitType.GotFocus
        Call LoadUnitTypeToCombo()
    End Sub

   
End Class