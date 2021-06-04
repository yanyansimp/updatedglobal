Imports System.Data.SqlClient

Module Module1
    Public DBPath As String = ""
    'Public conn As New OleDb.OleDbConnection("Data Source=" & My.Application.Info.DirectoryPath & "\..\Database\SalesInventory.mdb;Provider = Microsoft.JET.OLEDB.4.0;")
    'Public conn As New OleDb.OleDbConnection("Data Source=C:\BPMIS\database\2009\City-all.mdb;Provider = Microsoft.JET.OLEDB.4.0;")
    'Public conn As New OleDb.OleDbConnection("Data Source=C:\BPMIS\database\2009\city-all (2).mdb;Provider = Microsoft.JET.OLEDB.4.0;")

    Public cmd As OleDb.OleDbCommand
    Public reader As OleDb.OleDbDataReader

    Public dBAdapter As OleDb.OleDbDataAdapter
    Public dsDataset As DataSet

    Private bmp As Bitmap
    Public strReportSQL As String
    Public ReportFileName As String

    'sql server variables
    Public sqlConn As SqlClient.SqlConnection()
    Public sqlcmd As SqlClient.SqlCommand
    Public sqlreader As SqlClient.SqlDataReader
    Public sqladapter As SqlClient.SqlDataAdapter
    Public sqldataset As DataSet

    'Public Const sqlConnString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SkillsRegistry;Data Source=laptop\sqlexpress"
    'Public Const sqlConnString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SkillsRegistry;Data Source=jbgmis"
    ''''Public Const sqlConnString = "Persist Security Info=False;User ID=sa;Password=sa;Initial Catalog=POS;Data Source=SERVER"
    Public Const sqlConnString = "Data Source=server_jbg; Initial Catalog=Philhealth;Integrated Security=True;"
    'Public Const sqlConnString = "Provider=DOLEDB.1;Password=123456;User ID=JOEL;Data Source=jbgmisorig;Location=LOCALHOST;Mode=ReadWrite;Port=5236"
    Public CallingControl As String = ""
    Public Value_To_Be_Passed
    Public Calling_Form As String

    'printing variable
    Public strSQL_AGE As String
    Public strSQL_SEX As String
    Public strSQL_COURSE As String
    Public strSQL_STATUS As String
    Public strSQL_EMPLOYED As String
    Public strSQL_PREFERED_OCCUPATION As String
    Public strSQL_BRGY As String
    Public strSQL_YEAR As String
    Public strSQL_Month As String

    Public calling_menu As String

    Public USER_ID_LOGGED As String
    Public USER_NAME_LOGGED As String
    Public USER_LOGGED_OFFICE_NAME As String
    Public USER_LOGGED_OFFICE_SHORTNAME As String
    Public USER_LOGGED_OFFICE_ID As Long

    Public DESTINATION_OFFICE_SHORT_NAME As String
    Public ACCESS_LEVEL As Integer = 0 'USER BY DEFAULT

    Public NEW_PATIENT_ENTRY_FLAG As Boolean = False

    Public Function GenerateParticipatingBrgysData_Barangays(ByVal mth As Integer, ByVal period1 As Date, ByVal period2 As Date) As String
        Dim SqlCommand As New SqlClient.SqlCommand
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        SqlCommand.Connection = sqlconnection

        SqlCommand.CommandText = "SELECT     COUNT(Expr1) AS Expr1 FROM  (SELECT     COUNT(BARANGAY) AS Expr1   FROM  TBL_PERSONAL_INFORMATION   WHERE    ((month(DATEENCODED) = '" & mth & "') AND (YEAR(DATEENCODED) = '" & period1.Year & "')) AND (MUNICIPALITY = '2002') GROUP BY BARANGAY) AS derivedtbl_1"
        Return MonthName(mth) & "=" & SqlCommand.ExecuteScalar.ToString

    End Function

    Public Function GenerateParticipatingBrgysData_SkillsRegistrants(ByVal mth As Integer, ByVal sexcode As Integer, ByVal period1 As Date, ByVal period2 As Date) As String
        Dim SqlCommand2 As New SqlClient.SqlCommand
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        SqlCommand2.Connection = sqlconnection
        SqlCommand2.CommandText = "SELECT distinct  COUNT(IDNO) AS Expr1  FROM TBL_PERSONAL_INFORMATION WHERE  ((month(DATEENCODED) = '" & mth & "') AND (YEAR(DATEENCODED) = '" & period1.Year & "')) AND (MUNICIPALITY = '2002') AND (NOT_INTERESTED = 'False') AND (LEAVE_BARANGAY = 'False') AND (SEX = " & sexcode & ")" 'AND       "
        'SqlCommand2.CommandText = "(SELECT COUNT(IDNO) AS Expr1  FROM TBL_PERSONAL_INFORMATION WHERE (MUNICIPALITY = '2002') AND (NOT_INTERESTED = 'False') AND (LEAVE_BARANGAY = 'False') AND (SEX = 0) AND (MONTH(DATEENCODED) = '" & mth & "') GROUP BY DATEENCODED AS derived1"

        Return MonthName(mth) & "=" & SqlCommand2.ExecuteScalar.ToString
        MsgBox(GenerateParticipatingBrgysData_SkillsRegistrants)
    End Function

    Public Function Get_CivilStatus_Count_SkillsRegistrants(ByVal mth As Integer, ByVal sexcode As Integer, ByVal period1 As Date, ByVal period2 As Date, ByVal CStatus As Integer) As String
        Dim SqlCommand2 As New SqlClient.SqlCommand
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        SqlCommand2.Connection = sqlconnection
        SqlCommand2.CommandText = "SELECT distinct  COUNT(IDNO) AS Expr1  FROM TBL_PERSONAL_INFORMATION WHERE  ((month(DATEENCODED) = '" & mth & "') AND (YEAR(DATEENCODED) = '" & period1.Year & "')) AND (MUNICIPALITY = '2002') AND (NOT_INTERESTED = 'False') AND (LEAVE_BARANGAY = 'False')  AND (CSTATUS=" & CStatus & ")" 'AND       "
        'SqlCommand2.CommandText = "(SELECT COUNT(IDNO) AS Expr1  FROM TBL_PERSONAL_INFORMATION WHERE (MUNICIPALITY = '2002') AND (NOT_INTERESTED = 'False') AND (LEAVE_BARANGAY = 'False') AND (SEX = 0) AND (MONTH(DATEENCODED) = '" & mth & "') GROUP BY DATEENCODED AS derived1"

        Return MonthName(mth) & "=" & SqlCommand2.ExecuteScalar.ToString
    End Function

    Public Function gotFocusBackColor(ByVal calling_control As Control) As Color
        calling_control.BackColor = Color.LightGray
    End Function
    'use to trap numbers only
    'how to call : in keypress event type
    'If TrapKey(Asc(e.KeyChar)) Then
    'e.KeyChar = ""
    'End If
    Public Function TrapKey(ByVal KCode As String) As Boolean
        If (KCode >= 48 And KCode <= 57) Or KCode = 8 Or KCode = Asc(".") Then
            TrapKey = False
        Else
            TrapKey = True
        End If
    End Function

    Private sqlconnection As New SqlClient.SqlConnection(sqlConnString)

    Public Function getFieldMaxValue(ByVal tblName As String, ByVal fldtoquery As String) As Long
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        Dim cmdCountHHID As New SqlClient.SqlCommand("SELECT max(" & fldtoquery & ") from " & tblName & "", sqlconnection)
        Return cmdCountHHID.ExecuteScalar.ToString()
    End Function

    Public Function getFieldMaxCount(ByVal tblName As String, ByVal fldtoquery As String) As Long
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        Dim cmdCountHHID As New SqlClient.SqlCommand("SELECT count(" & fldtoquery & ") from " & tblName & "", sqlconnection)
        Return cmdCountHHID.ExecuteScalar.ToString()
    End Function

    Public Function GET_HIGHEST_IDNO_FROM_TBL_PERSONAL_INFORMATION() As Long
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        Dim cmdVerCount As New SqlClient.SqlCommand("SELECT max(IDNO) from TBL_PERSONAL_INFORMATION", sqlconnection)
        Return cmdVerCount.ExecuteScalar.ToString()
    End Function

    Public Sub INSERT_DATA_TO_DATABASE(ByVal TABLE_NAME As String, ByVal FIELD_NAMES As String, ByVal FIELD_VALUES As String)
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        Try
            Dim cmdUpdateVerifyVoter As New SqlClient.SqlCommand("INSERT INTO " & TABLE_NAME & "(" & FIELD_NAMES & ") VALUES (" & FIELD_VALUES & ")", sqlconnection)
            ' MsgBox("INSERT INTO " & TABLE_NAME & "(" & FIELD_NAMES & ") VALUES (" & FIELD_VALUES & ")")
            cmdUpdateVerifyVoter.ExecuteNonQuery()
        Catch
            If Err.Number = 5 Then
                MsgBox("THIS BARCODE ALREADY EXIST IN DATABASE, PLEASE MODIFY THEN SAVE. THANK YOU!" + Chr(13) + Chr(13) + Err.Description, MsgBoxStyle.Critical, "ERROR IN SAVING. . .")
            End If
        End Try
        sqlconnection.Close()
    End Sub

    Public Sub UPDATE_DATA_TO_DATABASE(ByVal TABLE_NAME As String, ByVal FIELD_NAMES_FIELD_VALUES As String, ByVal IDNO As Long)
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        'MsgBox("UPDATE " & TABLE_NAME & " SET " & FIELD_NAMES_FIELD_VALUES & " WHERE IDNO=" & IDNO, MsgBoxStyle.Exclamation, "UPDATE SUCCEEDED..")
        Dim cmdUpdateVerifyVoter As New SqlClient.SqlCommand("UPDATE " & TABLE_NAME & " SET " & FIELD_NAMES_FIELD_VALUES & " WHERE IDNO=" & IDNO, sqlconnection)
        cmdUpdateVerifyVoter.ExecuteNonQuery()
        sqlconnection.Close()
    End Sub

    Public Sub UPDATE_DATA_TO_DATABASE_COMPANYCODE(ByVal TABLE_NAME As String, ByVal FIELD_NAMES_FIELD_VALUES As String, ByVal CompanyCode As Long)
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        'MsgBox("UPDATE " & TABLE_NAME & " SET " & FIELD_NAMES_FIELD_VALUES & " WHERE IDNO=" & IDNO, MsgBoxStyle.Exclamation, "UPDATE SUCCEEDED..")
        Dim cmdUpdateVerifyVoter As New SqlClient.SqlCommand("UPDATE " & TABLE_NAME & " SET " & FIELD_NAMES_FIELD_VALUES & " WHERE COMPANYCODE=" & CompanyCode, sqlconnection)
        cmdUpdateVerifyVoter.ExecuteNonQuery()
        sqlconnection.Close()
    End Sub

    Public Sub UPDATE_DATA_TO_DATABASE_WITH_TRNNO(ByVal TABLE_NAME As String, ByVal FIELD_NAMES_FIELD_VALUES As String, ByVal IDNO As Long, ByVal TRNNO As Integer)
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        'MsgBox("UPDATE " & TABLE_NAME & " SET " & FIELD_NAMES_FIELD_VALUES & " WHERE IDNO=" & IDNO)
        Dim cmdUpdateVerifyVoter As New SqlClient.SqlCommand("UPDATE " & TABLE_NAME & " SET " & FIELD_NAMES_FIELD_VALUES & " WHERE IDNO=" & IDNO & "AND TRNNO=" & TRNNO, sqlconnection)
        cmdUpdateVerifyVoter.ExecuteNonQuery()
        sqlconnection.Close()
    End Sub

    Public Sub UPDATE_DATA_TO_DATABASE_USING_TRNNO(ByVal TABLE_NAME As String, ByVal FIELD_NAMES_FIELD_VALUES As String, ByVal TRNNO As Integer)
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        'MsgBox("UPDATE " & TABLE_NAME & " SET " & FIELD_NAMES_FIELD_VALUES & " WHERE IDNO=" & IDNO)
        Dim cmdUpdateVerifyVoter As New SqlClient.SqlCommand("UPDATE " & TABLE_NAME & " SET " & FIELD_NAMES_FIELD_VALUES & " WHERE  TRNNO=" & TRNNO, sqlconnection)
        cmdUpdateVerifyVoter.ExecuteNonQuery()
        sqlconnection.Close()
    End Sub

    Public Sub UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER(ByVal TABLE_NAME As String, ByVal FIELD_NAMES_FIELD_VALUES As String, ByVal PARAMETER_STRING As String)
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        'MsgBox("UPDATE " & TABLE_NAME & " SET " & FIELD_NAMES_FIELD_VALUES & " WHERE  " & PARAMETER_STRING)
        Dim cmdUpdateVerifyVoter As New SqlClient.SqlCommand("UPDATE " & TABLE_NAME & " SET " & FIELD_NAMES_FIELD_VALUES & " WHERE  " & PARAMETER_STRING, sqlconnection)
        cmdUpdateVerifyVoter.ExecuteNonQuery()
        cmdUpdateVerifyVoter.Dispose()
        sqlconnection.Close()
    End Sub

    Public Sub DELETE_RECORD_IN_DATABASE(ByVal TABLE_NAME As String, ByVal FIELD_NAME_AS_BASE_PARAMETER As String, ByVal IDNO As Long)
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        'MsgBox("DELETE FROM " & TABLE_NAME & "  WHERE " & FIELD_NAME_AS_BASE_PARAMETER & "=" & IDNO)
        Dim cmdUpdateVerifyVoter As New SqlClient.SqlCommand("DELETE FROM " & TABLE_NAME & "  WHERE " & FIELD_NAME_AS_BASE_PARAMETER & "=" & IDNO, sqlconnection)
        cmdUpdateVerifyVoter.ExecuteNonQuery()
        sqlconnection.Close()
    End Sub

    Public Function getCOUNTRY_NAME(ByVal CountryID As Integer) As String
        Dim SqlCommand As New SqlClient.SqlCommand
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        SqlCommand.Connection = sqlconnection
        SqlCommand.CommandText = "Select CountryName from tblrefCountry WHERE CountryID=" & CountryID & " "
        Return SqlCommand.ExecuteScalar.ToString
    End Function

    Public Function getPROVINCE_NAME(ByVal PROV_CODE As Integer) As String
        Dim SqlCommand As New SqlClient.SqlCommand
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        Try
            SqlCommand.Connection = sqlconnection
            SqlCommand.CommandText = "Select PROVINCE from tblrefPROVINCES WHERE PROVINCECODE=" & PROV_CODE & " "
            Return SqlCommand.ExecuteScalar.ToString
        Catch
            Return 101 ' not specified
        End Try
    End Function

    Public Function getOCCUPATION_TITLE(ByVal OCCUP_CODE As Integer) As String
        Try
            Dim SqlCommand As New SqlClient.SqlCommand
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
            End If
            SqlCommand.Connection = sqlconnection
            SqlCommand.CommandText = "Select OCCUPATIONAL_TITLE from tblrefOccupation WHERE OCCUP_CODE=" & OCCUP_CODE & " "
            Return SqlCommand.ExecuteScalar.ToString
        Catch
            Return ""
        End Try
    End Function

    Public Function getBARANGAY_NAME(ByVal brgyId As Integer) As String
        Try
            Dim SqlCommand As New SqlClient.SqlCommand
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
            End If
            SqlCommand.Connection = sqlconnection
            SqlCommand.CommandText = "Select BarangayName from tblrefBarangays WHERE BarangayCODE=" & brgyId & "  "
            Return SqlCommand.ExecuteScalar.ToString
        Catch
            Return ""
        End Try
    End Function

    Public Function getMunicipal_NAME(ByVal muncode As String, ByVal provcode As Integer) As String
        Try
            Dim SqlCommand As New SqlClient.SqlCommand
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
            End If
            SqlCommand.Connection = sqlconnection
            SqlCommand.CommandText = "Select Municipality from tblrefMunicipalCoding WHERE  MunCode=" & muncode & " and Province=" & provcode & ""
            Return SqlCommand.ExecuteScalar.ToString
        Catch
            Return ""
        End Try
    End Function

    Public Function getFIELD_VALUE_FROM_DBASE(ByVal tblname As String, ByVal fieldName As String, ByVal trnID As String, ByVal trnID_VALUE As String) As String
        Try
            Dim SqlCommand As New SqlClient.SqlCommand
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
            End If
            SqlCommand.Connection = sqlconnection
            SqlCommand.CommandText = "SELECT " & fieldName & " FROM " & tblname & " WHERE " & trnID & " = '" & trnID_VALUE & "'" 'passed by value was string
            Return SqlCommand.ExecuteScalar.ToString
        Catch
            'MsgBox(Err.Description)
            Return ""
        End Try
    End Function

    Public Function get_LIKE_FIELD_VALUE_FROM_DBASE(ByVal tblname As String, ByVal fieldName As String, ByVal trnID As String, ByVal trnID_VALUE As String) As String
        Try
            Dim SqlCommand As New SqlClient.SqlCommand
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
            End If
            SqlCommand.Connection = sqlconnection
            SqlCommand.CommandText = "SELECT " & fieldName & " FROM " & tblname & " WHERE " & trnID & " like '" & trnID_VALUE & "%'" 'passed by value was string
            Return SqlCommand.ExecuteScalar.ToString
        Catch
            'MsgBox(Err.Description)
            Return ""
        End Try
    End Function

    Sub main()

    End Sub
End Module
