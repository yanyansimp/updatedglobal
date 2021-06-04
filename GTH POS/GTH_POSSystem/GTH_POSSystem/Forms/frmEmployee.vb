Imports System.Data.SqlClient

Public Class frmEmployee
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
        sqladapter = New SqlClient.SqlDataAdapter("SELECT  EmployeesID, EmployeesName, EmployeesTitle, EmployeesContactNo, EmployeesAddress, Password, Email,trnno FROM       tblEmployees WHERE EmployeesName like '%" & txtSearch.Text & "%' order by EmployeesName", conn)
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
    End Sub

    Private Sub change_ReadOnly(ByVal xReadOnly As Boolean)
        txtEmployeesID.ReadOnly = xReadOnly
        txtCPW.ReadOnly = xReadOnly
        txtEmpAddress.ReadOnly = xReadOnly
        txtEmpContact.ReadOnly = xReadOnly
        txtEmpEmail.ReadOnly = xReadOnly
        txtEmployeesID.ReadOnly = xReadOnly
        txtEmpName.ReadOnly = xReadOnly
        txtEmpPW.ReadOnly = xReadOnly
        txtEmpTitle.ReadOnly = xReadOnly
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
            txtEmployeesID.Text = getFieldMaxCount("tblEmployees", "EmployeesID") + 1
            txtEmpName.Focus()
        Else
            Call change_bkGround(Color.White)
            btnClose.Text = "&Cancel"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnSave.Text = "&Update"
            btnSave.Enabled = True
            txtEmpName.Focus()
        End If
        Call change_ReadOnly(False)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim userleverl As Integer = IIf(rbtnStaff.Checked, 1, IIf(rbtnSupervisor.Checked, 2, IIf(rbtnAdministrator.Checked, 3, 0)))

        If btnSave.Text = "&Update" Then
            Dim strVALUES As String = " EmployeesID='" & Replace(txtEmployeesID.Text, "'", "''") & "', EmployeesName='" & Replace(txtEmpName.Text, "'", "''") & "', EmployeesTitle='" & Replace(txtEmpTitle.Text, "'", "''") & "', EmployeesContactNo='" & Replace(txtEmpContact.Text, "'", "''") & "', EmployeesAddress='" & Replace(txtEmpAddress.Text, "'", "''") & "', Password='" & Encrypt_PWord(Replace(txtEmpPW.Text, "'", "''")) & "', Email='" & Replace(txtEmpEmail.Text, "'", "''") & "',UserLevel=" & userleverl & ""
            Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("tblEmployees", strVALUES, "trnno='" & DataGridView1.Item(7, DataGridView1.CurrentCellAddress.Y).Value & "'")
        Else
            Dim strVALUES As String = "'" & Replace(txtEmployeesID.Text, "'", "''") & "','" & Replace(txtEmpName.Text, "'", "''") & "','" & Replace(txtEmpTitle.Text, "'", "''") & "','" & Replace(txtEmpContact.Text, "'", "''") & "','" & txtEmpAddress.Text & "','" & Encrypt_PWord(Replace(txtEmpPW.Text, "'", "''")) & "','" & Replace(txtEmpEmail.Text, "'", "''") & "'," & userleverl & ""
            Call INSERT_DATA_TO_DATABASE("tblEmployees", " EmployeesID, EmployeesName, EmployeesTitle, EmployeesContactNo, EmployeesAddress, Password, Email,UserLevel", strVALUES)

        End If
        Call LoadSupplierListing()
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

    Private Sub frmSupplierRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LoadSupplierListing()
    End Sub

    Private Sub DataGridView1_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Rows.Count > 0 Then
            With DataGridView1
                Try
                    If Me.DataGridView1.SelectedRows.Count > 0 Then ' AndAlso Not Me.DataGridView1.SelectedRows(0).Index = Me.DataGridView1.Rows.Count - 1 Then

                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        'EmployeesID, EmployeesName, EmployeesTitle, EmployeesContactNo, EmployeesAddress, Password, Email
                        txtEmployeesID.Text = .Item(0, .CurrentCellAddress.Y).Value
                        txtEmpName.Text = .Item(1, .CurrentCellAddress.Y).Value
                        txtEmpTitle.Text = .Item(2, .CurrentCellAddress.Y).Value
                        txtEmpContact.Text = .Item(3, .CurrentCellAddress.Y).Value
                        txtEmpAddress.Text = .Item(4, .CurrentCellAddress.Y).Value
                        txtEmpPW.Text = .Item(5, .CurrentCellAddress.Y).Value
                        txtEmpEmail.Text = IIf(.Item(6, .CurrentCellAddress.Y).Value = "", "N/A", .Item(6, .CurrentCellAddress.Y).Value)
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
        End If
        btnNew.Enabled = True
    End Sub

    Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
            With DataGridView1
                Try
                    If Me.DataGridView1.SelectedRows.Count > 0 Then 'AndAlso Not Me.DataGridView1.SelectedRows(0).Index = Me.DataGridView1.Rows.Count - 1 Then

                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect

                        txtEmployeesID.Text = .Item(0, .CurrentCellAddress.Y).Value
                        txtEmpName.Text = .Item(1, .CurrentCellAddress.Y).Value
                        txtEmpTitle.Text = .Item(2, .CurrentCellAddress.Y).Value
                        txtEmpContact.Text = .Item(3, .CurrentCellAddress.Y).Value
                        txtEmpAddress.Text = .Item(4, .CurrentCellAddress.Y).Value
                        txtEmpPW.Text = .Item(5, .CurrentCellAddress.Y).Value
                        txtEmpEmail.Text = .Item(6, .CurrentCellAddress.Y).Value
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

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Call LoadSupplierListing()
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(sender, e)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

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