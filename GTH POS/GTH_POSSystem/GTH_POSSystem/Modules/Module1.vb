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
    Public Const sqlConnString = "Data Source=server_jbg; Initial Catalog=POS;Integrated Security=True;"
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
    Public TRANSACTION_NUMBER As Long = 0
    Public OFFICIAL_RECEIPT_NO As String

    Public NOT_SAVE_FLAG As Boolean = False

    'trnno, CompanyName, LegalName, OperatedBy, Proprietor, PermitNumber, TaxID, StreetAddress, City, Country, State, Zip, Phone, Mobile, Fax, EmailAdd, Website

    Public COMPANY_NAME, COMPANY_LEGAL_NAME, OPERATED_BY, PROPRIETOR, PERMIT_NUMBER, TAX_ID, STREET_ADDRESS, COMP_CITY, COMP_COUNTRY, COMP_ZIP, COMP_PHONE, COMP_MOBILE, COMP_FAX, COMP_EMAIL, COMP_WEBSITE, COMP_TIN, COMP_PO_APP_OFF As String
    Public COMPLETE_COMPANY_ADDRESS As String
    Public logOff As Boolean

    Public END_DATE_TIME As String
    Public START_DATE_TIME As String
    Public CLERK_IN_QUESTION As String

    Public DATA_WAS_SAVED As Boolean = False
    Public DATA_WAS_EDITED As Boolean = False

    Public SUPPLIER_NAME_PRINTING As String = ""

    Public Sub GENERATE_COMPANY_PROFILE_CONSTANTS(ByVal COMPANY_ID As Long)
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT  TOP 1  trnno, CompanyName, LegalName, OperatedBy, Proprietor, PermitNumber, TaxID, StreetAddress, City, Country, State, Zip, Phone, Mobile, Fax, EmailAdd, Website,TIN,PO_ApprovingOfficer FROM  tblCompanyProfile WHERE TRNNO = " & COMPANY_ID & "", sqlconnection)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                'cmbBrgy.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    COMPANY_NAME = (.Rows(rowcounter).Item("CompanyName").ToString())
                    COMPANY_LEGAL_NAME = (.Rows(rowcounter).Item("LegalName").ToString())
                    OPERATED_BY = (.Rows(rowcounter).Item("OperatedBy").ToString())
                    PROPRIETOR = (.Rows(rowcounter).Item("Proprietor").ToString())
                    PERMIT_NUMBER = (.Rows(rowcounter).Item("PermitNumber").ToString())
                    TAX_ID = (.Rows(rowcounter).Item("TaxID").ToString())
                    STREET_ADDRESS = (.Rows(rowcounter).Item("StreetAddress").ToString())
                    COMP_CITY = (.Rows(rowcounter).Item("City").ToString())
                    COMP_COUNTRY = (.Rows(rowcounter).Item("Country").ToString())
                    COMP_ZIP = (.Rows(rowcounter).Item("Zip").ToString())
                    COMP_PHONE = (.Rows(rowcounter).Item("Phone").ToString())
                    COMP_MOBILE = (.Rows(rowcounter).Item("Mobile").ToString())
                    COMP_FAX = (.Rows(rowcounter).Item("Fax").ToString())
                    COMP_EMAIL = (.Rows(rowcounter).Item("EmailAdd").ToString())
                    COMP_WEBSITE = (.Rows(rowcounter).Item("Website").ToString())
                    COMPLETE_COMPANY_ADDRESS = STREET_ADDRESS & "," & COMP_CITY
                    COMP_TIN = (.Rows(rowcounter).Item("TIN").ToString())
                    COMP_PO_APP_OFF = (.Rows(rowcounter).Item("PO_ApprovingOfficer").ToString())
                Next

                'cmbBrgy.SelectedIndex = 0
                'COMPANY_NAME, COMPANY_LEGAL_NAME, OPERATED_BY, PROPRIETOR, PERMIT_NUMBER, TAX_ID, STREET_ADDRESS, COMP_CITY, COMP_COUNTRY, COMP_ZIP, COMP_PHONE, COMP_MOBILE, COMP_FAX, COMP_EMAIL, COMP_WEBSITE
                'DataGridView1.DataSource = dsDataset.Tables(0)
                'DataGridView1.AutoResizeColumns()

            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub


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
        Try
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
            End If
            Dim cmdCountHHID As New SqlClient.SqlCommand("SELECT max(" & fldtoquery & ") from " & tblName & "", sqlconnection)
            Return cmdCountHHID.ExecuteScalar.ToString()
        Catch
            Return 0
        End Try
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
            'MsgBox("INSERT INTO " & TABLE_NAME & "(" & FIELD_NAMES & ") VALUES (" & FIELD_VALUES & ")")
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

    Public Sub DELETE_RECORD_IN_DATABASE_PARAMSTRING(ByVal TABLE_NAME As String, ByVal FIELD_NAME_AS_BASE_PARAMETER As String, ByVal IDNO As String)
        If sqlconnection.State = ConnectionState.Closed Then
            sqlconnection.Open()
        End If
        'MsgBox("DELETE FROM " & TABLE_NAME & "  WHERE " & FIELD_NAME_AS_BASE_PARAMETER & "=" & IDNO)
        Dim cmdUpdateVerifyVoter As New SqlClient.SqlCommand("DELETE FROM " & TABLE_NAME & "  WHERE " & FIELD_NAME_AS_BASE_PARAMETER & "='" & IDNO & "'", sqlconnection)
        cmdUpdateVerifyVoter.ExecuteNonQuery()
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

    Public Function getMedianSalesPerDay(ByVal trnID_VALUE2 As String) As String
        Try
            If trnID_VALUE2 = "-" Then
                Return 0
            End If

            Dim SqlCommand As New SqlClient.SqlCommand
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
            End If
            SqlCommand.Connection = sqlconnection
            SqlCommand.CommandText = "select MedianSoldQTY FROM (select ProductID_Barcode,AVG(Quantity) as MedianSoldQTY " _
                                    & " from (select ProductID_Barcode,Quantity , " _
                                    & " ROW_NUMBER() over (partition by ProductID_Barcode order by Quantity ASC) as QuantityRank, " _
                                    & " COUNT(*) over (partition by ProductID_Barcode) as BCodeCount   from  dbo.tblSalesTransaction " _
                                    & "    ) x " _
                                    & " where   x.QuantityRank in (x.BCodeCount/2+1, (x.BCodeCount+1)/2)    " _
                                    & " group by x.ProductID_Barcode)    y " _
                                    & " where y.ProductID_Barcode = '" & trnID_VALUE2 & "'"
            Return SqlCommand.ExecuteScalar.ToString
        Catch
            'MsgBox(Err.Description, , "function getFieldValueFromDbase")
            Return ""
        End Try
    End Function

    Public Function getStandardDeviation(ByVal trnID_VALUE2 As String) As String
        Try
            If trnID_VALUE2 = "-" Then
                Return 0
            End If

            Dim SqlCommand As New SqlClient.SqlCommand
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
            End If
            SqlCommand.Connection = sqlconnection
            SqlCommand.CommandText = "SELECT STDEV(Quantity) as StanDev FROM dbo.tblSalesTransaction where ProductID_Barcode = '" & trnID_VALUE2 & "' group by ProductID_Barcode"
            'SqlCommand.CommandText = "SELECT " & fieldName & " FROM " & tblname & " WHERE " & trnID & " = '" & trnID_VALUE & "' order by trnno desc" 'passed by value was string
            Return SqlCommand.ExecuteScalar.ToString
        Catch
            'MsgBox(Err.Description, , "function getFieldValueFromDbase")
            Return ""
        End Try
    End Function

    Public Function getLEadTimefromDB(ByVal tblname As String, ByVal fieldName As String, ByVal trnID As String, ByVal trnID_VALUE2 As String) As String
        Try
            If trnID_VALUE2 = "-" Then
                Return 0
            End If

            Dim SqlCommand As New SqlClient.SqlCommand
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
            End If
            SqlCommand.Connection = sqlconnection
            SqlCommand.CommandText = "SELECT   DATEDIFF(hh,(SELECT     TOP 1 PO_Date  FROM tblPO WHERE PO_Number = tblProductReceive.PO_Number), (TransactionDate + TimeReceived)) as ss from tblProductReceive where productid_barcode = '" & trnID_VALUE2 & "' order by trnno desc"
            'SqlCommand.CommandText = "SELECT " & fieldName & " FROM " & tblname & " WHERE " & trnID & " = '" & trnID_VALUE & "' order by trnno desc" 'passed by value was string
            Return SqlCommand.ExecuteScalar.ToString
        Catch
            'MsgBox(Err.Description, , "function getFieldValueFromDbase")
            Return ""
        End Try
    End Function


    Public Function getFIELD_VALUE_FROM_DBASE(ByVal tblname As String, ByVal fieldName As String, ByVal trnID As String, ByVal trnID_VALUE As String) As String
        Try
            If trnID_VALUE = "-" Then
                Return 0
            End If

            Dim SqlCommand As New SqlClient.SqlCommand
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
            End If
            SqlCommand.Connection = sqlconnection
            SqlCommand.CommandText = "SELECT " & fieldName & " FROM " & tblname & " WHERE " & trnID & " = '" & trnID_VALUE & "'" 'passed by value was string
            Return SqlCommand.ExecuteScalar.ToString
        Catch
            'MsgBox(Err.Description, , "function getFieldValueFromDbase")
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

    Public Sub SET_AutoNoTable(ByVal transtype As String, ByVal transstatus As Boolean)
        Dim strValue As String = "'" & transtype & "','" & transstatus & "'"
        Call INSERT_DATA_TO_DATABASE("autoNo", "TransType,Status", strValue)
    End Sub

    Public Function GET_TransactionNumberTicket() As Long
        Return getFIELD_VALUE_FROM_DBASE("autoNo", "TransactionAutoNumber", "status", "0")
    End Function

    Public Function get_Server_Date() As String
        Try
            Dim SqlCommand As New SqlClient.SqlCommand
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
            End If
            SqlCommand.Connection = sqlconnection
            SqlCommand.CommandText = "Select GETDATE()" 'passed by value was string
            Return SqlCommand.ExecuteScalar.ToString
        Catch
            'MsgBox(Err.Description)
            Return ""
        End Try
    End Function

    Sub main()

    End Sub
End Module
