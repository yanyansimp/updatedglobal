Imports System.Runtime.InteropServices

Public Class frmLogin
    Public Structure SYSTEMTIME
        Public wYear As UInt16
        Public wMonth As UInt16
        Public wDayOfWeek As UInt16
        Public wDay As UInt16
        Public wHour As UInt16
        Public wMinute As UInt16
        Public wSecond As UInt16
        Public wMilliseconds As UInt16
    End Structure
    Declare Function GetSystemTime Lib "Kernel32.dll" _
        (ByRef lpSystemTime As SYSTEMTIME) As UInt32
    Declare Function SetSystemTime Lib "Kernel32.dll" _
        (ByRef lpSystemTime As SYSTEMTIME) As UInt32
    Public Sub GetTime()
        ' Call the native GetSystemTime method
        ' with the defined structure.
        Dim st As New SYSTEMTIME
        GetSystemTime(st)
        ' Show the current time.
        MessageBox.Show("Current Time: " & st.wHour.ToString() _
            & ":" & st.wMinute.ToString())
    End Sub
    Public Sub SetTime()
        ' Call the native GetSystemTime method
        ' with the defined structure.
        Dim st As New SYSTEMTIME
        GetSystemTime(st)
        ' Set the system clock ahead one hour.
        st.wDay = Convert.ToUInt16(((CInt(st.wDay))))
        SetSystemTime(st)
    End Sub





    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim userID As Long = txtUserID.Text
        ' txtUserID.Text = getFIELD_VALUE_FROM_DBASE("TBL_USER_LIST", "USERID", "USERID", userID)
        If UCase(UsernameTextBox.Text) = getFIELD_VALUE_FROM_DBASE("tblEmployees", "EmployeesName", "trnno", userID) And (PasswordTextBox.Text = Decrypt_PWord(getFIELD_VALUE_FROM_DBASE("tblEmployees", "PASSWORD", "trnno", userID))) Then
            USER_ID_LOGGED = userID
            USER_NAME_LOGGED = getFIELD_VALUE_FROM_DBASE("tblEmployees", "EmployeesName", "EmployeesID", txtUserID.Text)
            ' USER_LOGGED_OFFICE_ID = getFIELD_VALUE_FROM_DBASE("TBL_USER_LIST", "OFFICE", "USERNAME", UsernameTextBox.Text)
            'USER_LOGGED_OFFICE_NAME = getFIELD_VALUE_FROM_DBASE("TBL_REF_OFFICE", "OFFICENAME", "TRNNO", USER_LOGGED_OFFICE_ID)
            'USER_LOGGED_OFFICE_SHORTNAME = getFIELD_VALUE_FROM_DBASE("TBL_REF_OFFICE", "OFFICESHORTNAME", "TRNNO", USER_LOGGED_OFFICE_ID)
            '''''RECORD THE LOG-IN DATA
            Dim strLogData As String = "'" & USER_ID_LOGGED & "','" & get_Server_Date() & "','LOG-IN'"
            'SET THE LOCAL DATE AND TIME (SYNCHRONIZE WITH SERVER)
            SetTime()
            Me.PasswordTextBox.Text = ""
            Me.Hide()
            Call INSERT_DATA_TO_DATABASE("tblUserLoginData", "UserID,DateTimeLogged,ActionType", strLogData)
            frmMain.Show()
        Else
            MsgBox("IVALID USERNAME AND/OR PASSWORD, PLEASE TRY AGAIN OR CONTACT I.T PERSONNEL.", MsgBoxStyle.Critical, "ACCESS DENIED. . . ")
            PasswordTextBox.SelectAll()
            PasswordTextBox.Focus()
        End If
    End Sub


    Private Sub tmrPressF2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPressF2.Tick
        If lblFULLNAME.ForeColor = Color.Red Then
            lblFULLNAME.ForeColor = Color.Black
        Else
            lblFULLNAME.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub txtUserID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUserID.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblFULLNAME.Text = getFIELD_VALUE_FROM_DBASE("TBLEMPLOYEES", "EMPLOYEESNAME", "EMPLOYEESID", txtUserID.Text)
            UsernameTextBox.Text = lblFULLNAME.Text
            If Len(lblFULLNAME.Text) <= 0 Then
                MsgBox("UNIDENTIFIED USER ID, PLEASE TRY AGAIN!", MsgBoxStyle.Critical, "")
                Exit Sub
            End If
            PasswordTextBox.Focus()
        End If
    End Sub

    Private Sub UsernameTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UsernameTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            PasswordTextBox.Focus()
        End If
    End Sub

    Private Sub PasswordTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PasswordTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            OK_Click(sender, e)
        End If
    End Sub

    Private Sub txtUserID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUserID.TextChanged

    End Sub
End Class
