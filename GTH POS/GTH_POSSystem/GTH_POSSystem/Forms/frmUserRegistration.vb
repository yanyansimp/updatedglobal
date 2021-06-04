Public Class frmUserRegistration

#Region "connection variable"
    Private sqlconnection As New SqlClient.SqlConnection(sqlConnString)
#End Region

    Private Sub loadUSERS()
        sqladapter = New SqlClient.SqlDataAdapter("SELECT  * FROM        TBL_USER_LIST", sqlconnection)
        sqldataset = New DataSet
        sqldataset.Reset()
        sqladapter.Fill(sqldataset, "a")

        Try
            With sqldataset.Tables("a")
                If .Rows.Count > 0 Then
                    lblRecordCount.Text = "(" & .Rows.Count.ToString & ") Record/s Found.."
                    sqladapter.Fill(sqldataset, "TTbl")
                    DataGridView1.DataSource = sqldataset.Tables(0)
                    DataGridView1.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells)
                    DataGridView1.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.AllCells)
                    DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Else
                    lblRecordCount.Text = "(" & .Rows.Count.ToString & ") Record/s Found.."
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        sqladapter.Dispose()
        sqldataset.Dispose()
    End Sub

    Private Sub clear_controls()
        txtConfirmPassword.Text = ""
        txtPassword.Text = ""
        txtPosition.Text = ""
        txtUserID.Text = ""
        txtUsername.Text = ""
        lblofficeid.Text = ""
        cmbOffice.Text = ""
        cmbEmployeeName.Text = ""
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If calling_menu = "btnUserAdministration" Then
            MDIParent1.btnUserAdministration.Enabled = True
            MDIParent1.BringControlstoFront()
        End If
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmbDocumentType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOffice.GotFocus
        lblPressF2.Top = cmbEmployeeName.Top
        lblPressF2.Left = cmbOffice.Left '+ cmbSender.Width + 18
        lblPressF2.Visible = True
    End Sub

    Private Sub cmbDocumentType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbOffice.KeyDown
        If e.KeyCode = Keys.F2 Then
            CallingControl = "frmUserRegistration.cmbOffice"
            frmAddOffice.ShowDialog()
        End If
    End Sub

    Private Sub cmbDocumentType_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOffice.LostFocus
        lblPressF2.Visible = False
    End Sub

    Private Sub tmrPressF2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPressF2.Tick
        If lblPressF2.ForeColor = Color.Red Then
            lblPressF2.ForeColor = Color.Black
        Else
            lblPressF2.ForeColor = Color.Red
        End If
    End Sub

    Private Sub cmbEmployeeName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEmployeeName.GotFocus
        lblPressF2.Top = txtPosition.Top
        lblPressF2.Left = cmbOffice.Left '+ cmbSender.Width + 18
        lblPressF2.Visible = True
    End Sub

    Private Sub cmbEmployeeName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbEmployeeName.KeyDown
        If e.KeyCode = Keys.F2 Then
            CallingControl = "frmUserRegistration.cmbEmployeeName"
            frmAddEmployee.ShowDialog()
        End If
    End Sub

    Private Sub cmbEmployeeName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEmployeeName.LostFocus
        lblPressF2.Visible = False
    End Sub

    Private Sub frmUserRegistration_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Calling_Form = "MDI MAIN" Then
            MDIParent1.btnEmployeeAdministration.Enabled = True
            MDIParent1.BringControlstoFront()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(txtUsername.Text) <= 0 Or Len(txtConfirmPassword.Text) <= 0 Or Len(txtUserID.Text) <= 0 Then
            MsgBox("Username and/or Password was left empty, please try again!", MsgBoxStyle.Exclamation, "Blank entry boxes detected. . . ")
            Exit Sub
        End If

        Try
            If txtPassword.Text <> txtConfirmPassword.Text Then
                MsgBox("Password and Confirm Password does not match, Please try again!")
            Else
                'MsgBox(Decrypt_PWord(txtPassword.Text))
                'MsgBox(Encrypt_PWord(Decrypt_PWord(txtPassword.Text)))
                Dim STR_VALUES As String = "'" & txtUserID.Text & "','" & txtUsername.Text & "','" & Encrypt_PWord(txtPassword.Text) & "',0,'" & lblofficeid.Text & "'"
                Call INSERT_DATA_TO_DATABASE("TBL_USER_LIST", "USERID,USERNAME,PASSWORD,ACCESSRIGHT,OFFICE", STR_VALUES)
                MsgBox("User Successfully added, Thank you!")
                Call clear_controls()
                Call loadUSERS()
            End If
        Catch
            If Err.Number = 5 Then
                MsgBox("USER NAME ALREADY REGISTERED, PLEASE TRY AGAIN", MsgBoxStyle.Critical, "DUPLICATE...")
            Else
                MsgBox(Err.Description, , Err.Number)
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub frmUserRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call loadUSERS()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If btnNew.Text = "&New" Then
            Call clear_controls()
            cmbOffice.Focus()
            btnNew.Text = "&Cancel"
        Else
            Call clear_controls()
            btnNew.Text = "&New"
        End If
    End Sub
End Class