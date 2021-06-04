
Imports System.Data.SqlClient


Public Class frmProducInvAdjustment

#Region "CommonFunctions"
    Private conn As New SqlClient.SqlConnection("Data Source=server_jbg; Initial Catalog=POS;Integrated Security=True;")
    Private ComDset As New DataSet
    Private ComDset1 As New DataSet
    Private LeaderID As Long
    Private MemberID As Long
    Private rMoveVal As Boolean = False

    Dim CurrentRowIndex As Integer = 0
#End Region

    Private Sub LoadSupplierListing()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT     ProductID_Barcode, ProductDescription, UnitName, QtyOnHand  FROM         tblProduct WHERE ProductDescription like '%" & txtSearch.Text & "%' or ProductID_Barcode like '%" & txtSearch.Text & "%' order by ProductDescription", conn)
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
    End Sub

    Private Sub change_ReadOnly(ByVal xReadOnly As Boolean)
        txtSuppName.ReadOnly = xReadOnly
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If btnNew.Text = "&New" Then
            Call change_bkGround(Color.White)
            Call clearControls()
            btnClose.Text = "&Cancel"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnSave.Text = "&Update"
            btnSave.Enabled = True
            'get the highest SupplierID from table Supplier
            txtSuppID.Text = getFieldMaxCount("UnitType", "UnitCode") + 1
            txtSuppName.Focus()
        Else
            If Len(txtSuppID.Text) <= 0 Then
                Dim frmm As New Dialog1
                frmm.lblMessage.Text = "Please Select Item before EDIT, Thank you!"
                frmm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                frmm.ShowDialog()
            Else
                Call change_bkGround(Color.White)
                btnClose.Text = "&Cancel"
                btnNew.Enabled = False
                btnSave.Enabled = True
                btnSave.Text = "&Update"
                btnSave.Enabled = True
                txtNewQtyOnHand.Focus()
            End If
        End If
        Call change_ReadOnly(False)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "&Update" Then
            Dim strVALUES As String = "QTYONHAND =" & Replace(txtNewQtyOnHand.Text, "'", "''") & ""
            Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("tblProduct", strVALUES, "ProductID_Barcode='" & txtSuppID.Text & "'")
        Else
            Dim strVALUES As String = "'" & Replace(txtSuppName.Text, "'", "''") & "'"
            Call INSERT_DATA_TO_DATABASE("UNITTYPE", "UNITNAME", strVALUES)
        End If
        Call LoadSupplierListing()
        btnNew.Enabled = True
        btnSave.Text = "&Update"
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
            btnSave.Text = "&Update"
            btnNew.Text = "&Edit"
            Call change_bkGround(Color.BurlyWood)
            Call clearControls()
            'set all entry controls to read only mode
            Call change_ReadOnly(True)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub frmProducInvAdjustment_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.StockInventoryAdjustmentToolStripMenuItem.Enabled = True
        frmMain.PictureBox1.Visible = True
    End Sub

    Private Sub frmSupplierRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LoadSupplierListing()
    End Sub

    Private Sub DataGridView1_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Rows.Count > 0 Then
            With DataGridView1
                Try
                    If Me.DataGridView1.SelectedRows.Count > 0 Then ' AndAlso Not Me.DataGridView1.SelectedRows(0).Index = Me.DataGridView1.Rows.Count - 1 Then

                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect

                        txtSuppID.Text = .Item(0, .CurrentCellAddress.Y).Value
                        txtSuppName.Text = .Item(1, .CurrentCellAddress.Y).Value
                        txtPreQty.Text = .Item(3, .CurrentCellAddress.Y).Value
                        CurrentRowIndex = .CurrentRow.Index
                        .EditMode = DataGridViewEditMode.EditProgrammatically
                        btnSave.Text = "&Update"
                        btnClose.Text = "&Cancel"
                        btnNew.Text = "&Edit"
                    Else
                        btnNew.Text = "&Edit"
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

                        txtSuppID.Text = .Item(0, .CurrentCellAddress.Y).Value
                        txtSuppName.Text = .Item(1, .CurrentCellAddress.Y).Value
                        txtPreQty.Text = .Item(3, .CurrentCellAddress.Y).Value
                        CurrentRowIndex = .CurrentRow.Index
                        .EditMode = DataGridViewEditMode.EditProgrammatically
                        btnSave.Text = "&Update"
                        btnClose.Text = "&Cancel"
                        btnNew.Text = "&Edit"
                    Else
                        btnNew.Text = "&Edit"
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

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Call LoadSupplierListing()
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(sender, e)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class