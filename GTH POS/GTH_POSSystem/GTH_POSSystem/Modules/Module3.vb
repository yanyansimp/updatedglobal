Imports System.IO
Module Module1
    Private conn As OleDb.OleDbConnection
    Private cmd As OleDb.OleDbCommand
    Private reader As OleDb.OleDbDataReader
    Public DID As Integer
    Public Is_FP_Verified As Boolean = False

    Public dbConnection2 As New OleDb.OleDbConnection("Data Source=" & My.Application.Info.DirectoryPath & "\..\Database\SalesInventory.mdb;Provider = Microsoft.JET.OLEDB.4.0;")
    Public dBAdapter2 As OleDb.OleDbDataAdapter
    Public dsDataset2 As DataSet

    Private bmp As Bitmap
    Public cCallingForm As New ComboListData

    Public Function getAvailableCreditLimit(ByVal cid As Long) As Double
        Dim commOleDB As New OleDb.OleDbCommand
        Try
            commOleDB.Connection = dbConnection2
            commOleDB.CommandText = "Select AvailCreditLimit from tblCustomerProfile Where ID=" & cid & ""
            Return (commOleDB.ExecuteScalar.ToString)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Sub UpdateAvailableCreditLimit(ByVal cid As Long, ByVal amt As Double)
        Dim qrystring As String = "update  tblCustomerProfile set AvailCreditLimit=" & amt & " where id=" & cid & ";"
        Dim command As OleDb.OleDbCommand = New OleDb.OleDbCommand(qryString, dbConnection2)
        command.ExecuteNonQuery()
        command.Dispose()
    End Sub

    Public Function getCreditLimit(ByVal CID As Integer) As Double
        Dim commOleDB As New OleDb.OleDbCommand
        commOleDB.Connection = dbConnection2
        commOleDB.CommandText = "Select CreditLimit from tblCustomerProfile Where ID=" & CID & ""
        Return (commOleDB.ExecuteScalar.ToString)
    End Function

    Public Function RecordAlreadyExist(ByVal SQLQueryString As String) As Boolean
        Dim commOleDB As New OleDb.OleDbCommand
        commOleDB.Connection = dbConnection2
        commOleDB.CommandText = SQLQueryString
        Return (commOleDB.ExecuteScalar.ToString)
    End Function

    Public Function getDriver_Viajedor(ByVal DID As Integer) As String
        Dim commOleDB As New OleDb.OleDbCommand
        commOleDB.Connection = dbConnection2
        commOleDB.CommandText = "Select Dname from tblDriver Where DID=" & DID & ""
        Return (commOleDB.ExecuteScalar.ToString)
    End Function

    Public Function getEmployeeName(ByVal EID As Integer) As String
        Dim commOleDB As New OleDb.OleDbCommand
        commOleDB.Connection = dbConnection2
        commOleDB.CommandText = "Select Fullname from tblEmployeeProfile Where EID=" & EID & ""
        Return (commOleDB.ExecuteScalar.ToString)
    End Function

    Public Function getCustomerName(ByVal CID As Integer) As String
        Dim commOleDB As New OleDb.OleDbCommand
        commOleDB.Connection = dbConnection2
        commOleDB.CommandText = "Select Fullname from tblCustomerProfile Where ID=" & CID & ""
        Return (commOleDB.ExecuteScalar.ToString)
    End Function

    Public Function getFishCarName(ByVal FID As Integer) As String
        Dim commOleDB As New OleDb.OleDbCommand
        commOleDB.Connection = dbConnection2
        commOleDB.CommandText = "Select FishCar from tblFishCar Where FID=" & FID & ""
        Return (commOleDB.ExecuteScalar.ToString)
    End Function

    Public Function getFishSpecieID(ByVal FSName As String) As Integer
        Dim commOleDB As New OleDb.OleDbCommand
        commOleDB.Connection = dbConnection2
        commOleDB.CommandText = "Select SpecieID from tblSpecie Where SpecieName='" & FSName & "'"
        Return (commOleDB.ExecuteScalar.ToString)
    End Function

    Public Function getFishSpecieName(ByVal SpecieID As String) As String
        Dim commOleDB As New OleDb.OleDbCommand
        commOleDB.Connection = dbConnection2
        commOleDB.CommandText = "Select SpecieName from tblSpecie Where SpecieID=" & SpecieID & ""
        Return (commOleDB.ExecuteScalar.ToString)
    End Function

    Public Function getUnitID(ByVal UnitName As String) As Integer
        Dim commOleDB As New OleDb.OleDbCommand
        commOleDB.Connection = dbConnection2
        commOleDB.CommandText = "Select UnitID from tblUnitMeasure Where Unit='" & UnitName & "'"
        Return (commOleDB.ExecuteScalar.ToString)
    End Function

    Public Function getUnitName(ByVal UnitID As Integer) As String
        Dim commOleDB As New OleDb.OleDbCommand
        commOleDB.Connection = dbConnection2
        commOleDB.CommandText = "Select Unit from tblUnitMeasure Where UnitID=" & UnitID & ""
        Return (commOleDB.ExecuteScalar.ToString)
    End Function


    Public ReadOnly Property getRecordCount(ByVal qryString As String) As Integer
        Get
            Dim commOleDB As New OleDb.OleDbCommand
            commOleDB.Connection = dbConnection2
            'commOleDB.CommandText = "Select count(*) from tblInmatePersonalData"
            commOleDB.CommandText = qryString
            Return (commOleDB.ExecuteScalar.ToString)
        End Get
    End Property

    Public Function getCustomerStatus(ByVal CID As Integer) As String
        Dim commOleDB As New OleDb.OleDbCommand
        commOleDB.Connection = dbConnection2
        commOleDB.CommandText = "Select Active from tblCustomerProfile Where ID=" & CID & ""
        Return (commOleDB.ExecuteScalar.ToString)
    End Function

    Public Function getCustomerStallLocation(ByVal CID As Integer) As String
        Dim commOleDB As New OleDb.OleDbCommand
        commOleDB.Connection = dbConnection2
        commOleDB.CommandText = "Select StallLocation from tblCustomerProfile Where ID=" & CID & ""
        Return (commOleDB.ExecuteScalar.ToString)
    End Function

    Public Function VerifyFPExistence(ByVal qryString As String) As Boolean
        dBAdapter2 = New OleDb.OleDbDataAdapter(qryString, dbConnection2)
        dsDataset2 = New DataSet
        dbAdapter.Fill(dsDataset2, "ss")
        With dsDataset2.Tables(0)
            If .Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End With
        dBAdapter2.Dispose()
        dsDataset2.Dispose()
    End Function

    Public Function GetImageFromDB(ByRef callingForm As String, ByVal did As Integer) As Bitmap
        Try
            conn = New OleDb.OleDbConnection("Data Source=" & My.Application.Info.DirectoryPath & "\..\Database\SalesInventory.mdb;Provider = Microsoft.JET.OLEDB.4.0;")
            conn.Open()

            cmd = conn.CreateCommand()
            If callingForm = "Driver" Then
                cmd.CommandText = "SELECT Photo FROM tblDriver WHERE DID = " & did & ""
            ElseIf callingForm = "Customer" Then
                cmd.CommandText = "SELECT Photo FROM tblCustomerProfile WHERE ID = " & did & ""
            ElseIf callingForm = "Employee" Then
                cmd.CommandText = "SELECT Photo FROM tblEmployeeProfile WHERE EID = " & did & ""
            End If
            reader = cmd.ExecuteReader

            Dim imgByteArray() As Byte
            If reader.Read Then
                Try
                    imgByteArray = CType(reader(0), Byte())
                    Dim stream As New System.IO.MemoryStream(imgByteArray)
                    bmp = New Bitmap(stream)
                    stream.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Return Nothing
                End Try
            End If
            reader.Close()
            conn.Close()
            cmd.Dispose()
            conn.Dispose()
            Return bmp
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Sub Insert_Image(ByVal FN As String, ByVal did As Integer, ByVal callingForm As String)
        conn = New OleDb.OleDbConnection("Data Source=" & My.Application.Info.DirectoryPath & "\..\Database\SalesInventory.mdb;Provider = Microsoft.JET.OLEDB.4.0;")
        conn.Open()
        'dbConnection2.Open()
        Try
            Dim st As New FileStream(FN, FileMode.Open, FileAccess.Read)
            Dim mbr As BinaryReader = New BinaryReader(st)
            Dim buffer(st.Length) As Byte
            mbr.Read(buffer, 0, CInt(st.Length))
            st.Close()

            Dim Str As String = ""
            If callingForm = "Customer" Then
                Str = "UPDATE tblCustomerProfile SET Photo=? WHERE ID=" & did & ""
            ElseIf callingForm = "Driver" Then
                Str = "UPDATE tblDriver SET Photo=? WHERE DID=" & did & ""
            ElseIf callingForm = "Employee" Then
                Str = "UPDATE tblEmployeeProfile SET Photo=? WHERE EID=" & did & ""
            ElseIf callingForm = "FishDistribution" Then
                Str = "Update tbl"
                'TODO: pic capture for every fish withdrawal
            End If
            Dim Cmdd As New System.Data.OleDb.OleDbCommand(Str, conn)
            Cmdd.Parameters.Add("@photo", System.Data.OleDb.OleDbType.Binary, buffer.Length).Value = buffer
            Cmdd.ExecuteNonQuery()
            MsgBox("Image Saved Successfully")
        Catch ex As Exception
            MsgBox("Error In Insertphoto", MsgBoxStyle.Critical, "Error")
            MsgBox(ex.ToString)
        End Try
        'reader.Close()
        conn.Close()
        conn.Dispose()
    End Sub
    'ExecuteNonQuery(conn.Close())
    'PictureBox1.Image = GetImageFromDB(TextBox1.Text)















    '********************** use this to convert number only in textbox ***********************************
    'Option Explicit

    'Const numSep As String = "." ' Selected seperator - Can be . or :

    'Private Sub UserForm_Initialize()
    '    TextBox1.TextAlign = fmTextAlignRight
    '    TextBox1.MaxLength = 5
    'End Sub

    'Private Sub TextBox1_Change()
    '    If Not IsNumeric(TextBox1.Text) Then TextBox1.Text = "0"
    '    Dim theText As String
    '    theText = Val(Replace(TextBox1.Text, numSep, ""))
    '    If Len(theText) >= 2 Then
    '        theText = Left(theText, Len(theText) - 2) & numSep & Format(Right(theText, 2), "00")
    '    Else
    '        theText = numSep & Format(Right(theText, 2), "00")
    '    End If
    '    TextBox1.Text = theText
    'End Sub

    'Private Sub TextBox1_KeyDown(ByVal KeyCode As MSForms.ReturnInteger, ByVal Shift As Integer)
    '    Select Case KeyCode
    '        Case vbKey0 To vbKey9, vbKeyNumpad0 To vbKeyNumpad9, vbKeyBack, vbKeyDelete  'allowed keys.
    '        Case Else
    '            KeyCode = 0
    '    End Select
    'End Sub


End Module
