Imports System.Data.SqlClient
Imports System.IO

Module modSMS

#Region "CommonConnection"
    Private conn As New SqlClient.SqlConnection("Data Source=server; Initial Catalog=POS;Integrated Security=True;")
    Private ComDset As New DataSet
    Private ComDset1 As New DataSet
#End Region

    Public brgy As String
    Public varNAMEOFPCM As String
    Public varNAMEOFBCM As String
    Public varNAMEOFCOBCM As String
    Public varTRV As Long
    Public varMaxTarget As Long
    Public varPercentage As String
    Public varHHCanvassed As Long
    Public varHHMCanvassed As Long
    Public varResult2010 As Long
    Public varResult2013 As Long

    Public dbConnection As SqlConnection
    Public dbAdapter As SqlDataAdapter
    Public dbDataSet As New DataSet
    Public strReportSQL As String
    Public ReportFileName As String
    Private bmp As Bitmap
    Private reader As SqlDataReader

    Public CANDIDATE(30) As Integer
    '1 FORTUN,3 AMANTE,6 CALO,9 AMANTE,14 BURDEOS,16 CAMPOS,17 CARAMPATANA,18 CEMBRANO,19 CHAN
    '21 CULIMA,23 DAYADAY,27 NALCOT,28 NERY,
    Public voterID As Long


    Public Function IsRegisteredNumber(ByVal CN As String) As Boolean
        Dim cNumber As String
        If Len(CN) = 11 Then
            cNumber = "+63" & Right(CN, 10)
        Else
            cNumber = CN
        End If
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim qryString As String = "Select CellPhone from BrgyElect_AllContacts WHERE  (Cellphone = '" & CN & "')"

        dbAdapter = New SqlClient.SqlDataAdapter(qryString, conn)
        dbDataSet = New DataSet
        dbAdapter.Fill(dbDataSet, "ss")
        With dbDataSet.Tables(0)
            If .Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End With
    End Function

    Public Function Format_Barcode(ByVal strTrnno As String) As String
        Dim strNo2 As String
        If Len(strTrnno) = 1 Then
            strNo2 = "*000000-" & strTrnno & "*"
            Return strNo2
        ElseIf Len(strTrnno) = 2 Then
            strNo2 = "*00000-" & strTrnno & "*"
            Return strNo2
        ElseIf Len(strTrnno) = 3 Then
            strNo2 = "*0000-" & strTrnno & "*"
            Return strNo2
        ElseIf Len(strTrnno) = 4 Then
            strNo2 = "*000-" & strTrnno & "*"
            Return strNo2
        ElseIf Len(strTrnno) = 5 Then
            strNo2 = "*00-" & strTrnno & "*"
            Return strNo2
        ElseIf Len(strTrnno) = 6 Then
            strNo2 = "*0-" & strTrnno & "*"
            Return strNo2
        End If
        Return strNo2
    End Function


    Public Function getPol_Position(ByVal trnno As Long) As Long
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim qryString = "Select Pol_Position as POL_POSITION from  ListOfVoters2016 WHERE trnno='" & trnno & "'"
        dbAdapter = New SqlClient.SqlDataAdapter(qryString, conn)
        dbDataSet = New DataSet
        dbAdapter.Fill(dbDataSet, "ss")
        With dbDataSet.Tables(0)
            If .Rows.Count > 0 Then
                Return .Rows(0).Item("POL_POSITION").ToString
            Else
                Return "0"
            End If
        End With
    End Function

    Public Function getPol_Leader(ByVal trnno As Long) As Long
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim qryString = "Select POL_LEADER from  ListOfVoters2016 WHERE trnno='" & trnno & "'"
        dbAdapter = New SqlClient.SqlDataAdapter(qryString, conn)
        dbDataSet = New DataSet
        dbAdapter.Fill(dbDataSet, "ss")
        With dbDataSet.Tables(0)
            If .Rows.Count > 0 Then
                Return .Rows(0).Item("POL_LEADER").ToString
            Else
                Return "0"
            End If
        End With
    End Function

    Public Function getPol_Coordinator(ByVal trnno As Long) As Long
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim qryString = "Select POL_COORDINATOR from  ListOfVoters2016 WHERE trnno='" & trnno & "'"
        dbAdapter = New SqlClient.SqlDataAdapter(qryString, conn)
        dbDataSet = New DataSet
        dbAdapter.Fill(dbDataSet, "ss")
        With dbDataSet.Tables(0)
            If .Rows.Count > 0 Then
                Return .Rows(0).Item("POL_COORDINATOR").ToString
            Else
                Return "0"
            End If
        End With
    End Function

    Public Function getFULLNAME(ByVal trnno As Long) As String
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim qryString = "Select Lastname as FULLNAME from  ListOfVoters2016 WHERE trnno='" & trnno & "'"
        dbAdapter = New SqlClient.SqlDataAdapter(qryString, conn)
        dbDataSet = New DataSet
        dbAdapter.Fill(dbDataSet, "ss")
        With dbDataSet.Tables(0)
            If .Rows.Count > 0 Then
                Return .Rows(0).Item("FULLNAME").ToString
            Else
                Return " "
            End If
        End With
    End Function

    Public Function getPCOSNumber(ByVal PrecinctID As String) As String
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Dim qryString = "Select TOP 1 PrecinctID FROM         BrgyElect_ProjectOfPrecincts where Precinct = '" & PrecinctID & "'"
        dbAdapter = New SqlClient.SqlDataAdapter(qryString, conn)
        dbDataSet = New DataSet
        dbAdapter.Fill(dbDataSet, "ss")
        With dbDataSet.Tables(0)
            If .Rows.Count > 0 Then
                Return .Rows(0).Item("PrecinctID").ToString
            Else
                Return " "
            End If
        End With
    End Function


    Public Function getPOSITION(ByVal trnno As Long) As String
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim qryString = "Select POSITIONTITLE  from tblPositions WHERE PositionNo='" & trnno & "'"
        dbAdapter = New SqlClient.SqlDataAdapter(qryString, conn)
        dbDataSet = New DataSet
        dbAdapter.Fill(dbDataSet, "ss")
        With dbDataSet.Tables(0)
            If .Rows.Count > 0 Then
                Return .Rows(0).Item("POSITIONTITLE").ToString
            Else
                Return " "
            End If
        End With
    End Function

    Public Function getVotersMaxNumber_Grouping() As Long
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdVerCount As New SqlClient.SqlCommand("SELECT max(NoOfMember) from  tblOrgPrinting", conn)
        Return cmdVerCount.ExecuteScalar.ToString()
    End Function

    Public Function getVotersCount_All(ByVal brgy As String) As Long
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdVerCount As New SqlClient.SqlCommand("SELECT COUNT(lastname) from ListOfVoters2016 WHERE (Barangay = '" & brgy & "')", conn)
        Return cmdVerCount.ExecuteScalar.ToString()
    End Function

    Public Function getCOuntSupporter(ByVal brgyname As String) As Long
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdVerCount As New SqlClient.SqlCommand("SELECT COUNT(lastname) from ListOfVoters2016 WHERE (Barangay = '" & brgyname & "')  AND Pol_Property=1", conn)
        Return cmdVerCount.ExecuteScalar.ToString()
    End Function

    Public Function get_BrgyName_UsingBrgyMapCode(ByVal brgyMapcode As String) As String
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdVerCount As New SqlClient.SqlCommand("SELECT Barangayname from tblrefBarangays WHERE (BrgyMapCode = '" & brgyMapcode & "')", conn)
        Return cmdVerCount.ExecuteScalar.ToString()
    End Function

    Public Function getPollingPlace(ByVal PCOSNumber As Integer) As String
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdVerCount As New SqlClient.SqlCommand("SELECT VotingCenter from  BrgyElect_ProjectOfPrecincts WHERE (PrecinctID = " & PCOSNumber & ")", conn)
        Return cmdVerCount.ExecuteScalar.ToString()
    End Function


    Public Function getCanvassedCount_text(ByVal brgy As String) As Long
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdVerCount As New SqlClient.SqlCommand("SELECT COUNT(lastname) from ListOfVoters2016 WHERE (Barangay = '" & brgy & "')  AND Pol_Property=1", conn)
        Return cmdVerCount.ExecuteScalar.ToString()
    End Function

    Public Function getBrgyField_text(ByVal brgyCode As String, ByVal fldtoquery As String, ByVal municipalcode As Long, ByVal fldvalue As String) As Long
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdVerCount As New SqlClient.SqlCommand("SELECT " & fldtoquery & " from tblrefBarangays WHERE (BarangayName = '" & brgyCode & "')", conn)
        Return cmdVerCount.ExecuteScalar.ToString()
    End Function

    Public Function getFieldValue(ByVal tblName As String, ByVal fldtoquery As String, ByVal parameterField As String) As String
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdVerCount As New SqlClient.SqlCommand("SELECT " & fldtoquery & " from " & tblName & " WHERE (" & parameterField & ")", conn)
        Return cmdVerCount.ExecuteScalar.ToString()
    End Function


    Public Function getFieldValue2(ByVal tblName As String, ByVal fldtoquery As String, ByVal VID As String) As String
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdVerCount As New SqlClient.SqlCommand("SELECT COUNT(EVENTNAME) FROM   tblEventAttendanceMonitoring WHERE VID ='" & VID & "'", conn)
        Return cmdVerCount.ExecuteScalar.ToString()
    End Function



    Public Function getUpdateFlag(ByVal brgy As String) As Long
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdVerCount As New SqlClient.SqlCommand("SELECT FVUpdateLock from tblrefBarangays WHERE (BarangayName like '%" & Trim(brgy) & "%')", conn)
        Return cmdVerCount.ExecuteScalar.ToString()
    End Function

    Public Function getBrgyByPhone(ByVal CN As String) As String
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdVerCount As New SqlClient.SqlCommand("SELECT Barangay from BrgyElect_AllContacts WHERE (Cellphone = '" & Trim(CN) & "')", conn)
        Return cmdVerCount.ExecuteScalar.ToString()
    End Function

    

    Public Function getMaxHHID() As Long
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdCountHHID As New SqlClient.SqlCommand("SELECT Max(HHID) from ListOfVoters2016", conn)
        Return cmdCountHHID.ExecuteScalar.ToString()
    End Function

    Public Function getHOUSEHOLDID(ByVal Voters_ID As Long) As Long
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdgetHHID As New SqlClient.SqlCommand("SELECT HHID from ListOfVoters2016 where TRNNO = " & Voters_ID & "", conn)
        Return cmdgetHHID.ExecuteScalar.ToString()
    End Function

    Private Function getPrevious_Comments(ByVal ID As Long) As String
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdGetMemberStatus As New SqlClient.SqlCommand("Select Other_Comments from ListOfVoters2016  WHERE trnno = " & ID & "", conn)
        Return cmdGetMemberStatus.ExecuteScalar.ToString()
    End Function


    Public Function update_Voter_Comments(ByVal ID As Long, ByVal txtcomments As String) As Boolean
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        txtcomments = "-->" & getPrevious_Comments(ID) & "-->" & txtcomments
        Dim cmdUpdateMemberStatus As New SqlClient.SqlCommand("UPDATE ListOfVoters2016 SET Other_Comments='" & txtcomments & "' WHERE trnno = " & ID & "", conn)
        cmdUpdateMemberStatus.ExecuteNonQuery()
        cmdUpdateMemberStatus.Dispose()
        Return True
    End Function

    Public Function GetImageFromDB(ByRef callingForm As String, ByVal id As Integer) As Bitmap
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim cmdGetImage As New SqlClient.SqlCommand("Select votersPicture from ListOfVoters2016 WHERE trnno = " & id & "", conn)

            reader = cmdGetImage.ExecuteReader

            Dim imgByteArray() As Byte
            If reader.Read Then
                Try
                    imgByteArray = CType(reader(0), Byte())
                    Dim stream As New System.IO.MemoryStream(imgByteArray)
                    bmp = New Bitmap(stream)
                    stream.Close()
                Catch ex As Exception
                    If Err.Number = 13 Then
                        ' MessageBox.Show("Picture not found..")
                        bmp = New Bitmap(My.Application.Info.DirectoryPath & "\..\..\images\addusers.bmp")
                    Else
                        MessageBox.Show(ex.Message)
                    End If
                    reader.Close()
                    cmdGetImage.Dispose()
                    'conn.Close()
                    Return bmp
                End Try
            End If
            reader.Close()
            conn.Close()
            cmdGetImage.Dispose()
            Return bmp
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Sub Insert_Image(ByVal FN As String, ByVal did As Integer, ByVal callingForm As String)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Try
            Dim st As New FileStream(FN, FileMode.Open, FileAccess.Read)
            Dim mbr As BinaryReader = New BinaryReader(st)
            Dim buffer(st.Length) As Byte
            mbr.Read(buffer, 0, CInt(st.Length))
            st.Close()

            Dim Str As String = ""
            Str = "UPDATE ListOfVoters2016 SET votersPicture=@photo WHERE trnno=" & did & ""

            'Dim Cmdd As New System.Data.OleDb.OleDbCommand(Str, conn)
            Dim cmdd2 As New SqlCommand(Str, conn)
            cmdd2.Parameters.Add("@photo", SqlDbType.Binary, buffer.Length).Value = buffer
            cmdd2.ExecuteNonQuery()
            MsgBox("Image Saved Successfully")

            'Dim cmd As New SqlCommand("UPDATE ListOfVoters2016 SET votersPicture=@(ImageFile,CustomerID) Values (@ImageData,@CustomerID)", conn)

            '            Dim param As New SqlParameter("@ImageData", SqlDbType.VarBinary)
            '           Dim ImageData As Byte() = IO.File.ReadAllBytes(myfilelocation)
            '          param.Value = ImageData
            '         cmd.Parameters.Add(param)
            '
            'cmd.Parameters.AddWithValue("@CustomerID", 3)
            'Try
            ' conn.Open()
            ' cmd.ExecuteNonQuery()
            ' Catc'h ex As Exception
            '    MessageBox.Show(ex.Message)
            'Finally
            '   conn.Close()
            'End Try



        Catch ex As Exception
            MsgBox("Error In Insertphoto" + vbCrLf + vbCrLf + Err.Description, MsgBoxStyle.Critical, "Error")
            MsgBox(ex.ToString)
        End Try
        'reader.Close()
        conn.Close()
    End Sub

    Public Sub INSERT_MEMBER_PolProperty_Flag(ByVal VoterTRNNO As Long, ByVal CandidateID As Long, ByVal pol_prop As Integer, ByVal oComments As String)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdUpdateMemberStatus As New SqlClient.SqlCommand("INSERT INTO BrgyElect_ListOfVoters_SupporterFlag(VoterTRNNO,CandidateID,Pol_Property,otherComments) " _
                                                              & " VALUES(" & VoterTRNNO & "," & CandidateID & "," & pol_prop & ",'" & oComments & "')", conn)
        cmdUpdateMemberStatus.ExecuteNonQuery()
        cmdUpdateMemberStatus.Dispose()
    End Sub

    Public Sub DELETE_MEMBER_PolProperty_Flag(ByVal VoterTRNNO As Long)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdUpdateMemberStatus2 As New SqlClient.SqlCommand("DELETE FROM BrgyElect_ListOfVoters_SupporterFlag WHERE VoterTRNNO= " & VoterTRNNO & "", conn)
        cmdUpdateMemberStatus2.ExecuteNonQuery()
        cmdUpdateMemberStatus2.Dispose()
    End Sub

    Public Sub UPDATE_MEMBER_PolProperty_Flag(ByVal ID As Long)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdUpdateMemberStatus As New SqlClient.SqlCommand("UPDATE ListOfVoters2016 SET Pol_Property=0, Pol_Position=NULL, Pol_Leader=NULL, Verified=NULL WHERE trnno = " & ID & "", conn)
        cmdUpdateMemberStatus.ExecuteNonQuery()
        cmdUpdateMemberStatus.Dispose()
    End Sub

    Public Sub UPDATE_MEMBER_PolProperty_Floating_Flag(ByVal VoterTRNNO As Long, ByVal CandidateID As Long, ByVal floating As Integer, ByVal oComments As String)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdUpdateMemberStatus As New SqlClient.SqlCommand("UPDATE BrgyElect_ListOfVoters_SupporterFlag SET Pol_Property=0, Floating=" & floating & " WHERE CandidateID =  " & CandidateID & " AND VOterTRnno = '" & VoterTRNNO & "'", conn)
        cmdUpdateMemberStatus.ExecuteNonQuery()
        cmdUpdateMemberStatus.Dispose()
    End Sub

    Public Sub DELETE_SCORE_tblQCVOTES(ByVal candidateNo As Integer, ByVal PrecID As Integer)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdUpdateMemberStatus As New SqlClient.SqlCommand("DELETE FROM TBLQCVOTES WHERE CandidateNo=" & candidateNo & " AND PRECID=" & PrecID & ")", conn)
        cmdUpdateMemberStatus.ExecuteNonQuery()
        cmdUpdateMemberStatus.Dispose()
    End Sub

    Public Sub INSERT_SCORE_tblQCVOTES(ByVal candidateNo As Integer, ByVal PrecID As Integer, ByVal Votes As Integer)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdUpdateMemberStatus As New SqlClient.SqlCommand("INSERT INTO TBLQCVOTES(CandidateNo,PrecID,VOTES) VALUES(" & candidateNo & "," & PrecID & "," & Votes & ")", conn)
        cmdUpdateMemberStatus.ExecuteNonQuery()
        cmdUpdateMemberStatus.Dispose()
    End Sub

    Public Function getPRECINCTID(ByVal Voters_ID As Long) As String
        Dim xStr As String
        xStr = "+" & Voters_ID
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdgetPRECID As New SqlClient.SqlCommand("SELECT PrecinctAssigned from BrgyElect_AllContacts where Cellphone = " & xStr & "", conn)
        Return cmdgetPRECID.ExecuteScalar.ToString()
    End Function

    Public Sub UPDATE_MEMBER_PolStatus(ByVal ID As Long)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdUpdateMemberStatus As New SqlClient.SqlCommand("UPDATE ListOfVoters2016 SET Pol_Property=0, Pol_Position=NULL, Pol_Leader=NULL,Pol_Coordinator=NULL, Verified=NULL WHERE trnno = " & ID & "", conn)
        cmdUpdateMemberStatus.ExecuteNonQuery()
        cmdUpdateMemberStatus.Dispose()
    End Sub
    Public Sub UPDATE_MEMBER_CV(ByVal ID As Long)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdUpdateMemberStatus As New SqlClient.SqlCommand("UPDATE ListOfVoters2016 SET VOTETYPE='CV' WHERE trnno = " & ID & "", conn)
        cmdUpdateMemberStatus.ExecuteNonQuery()
        cmdUpdateMemberStatus.Dispose()
    End Sub
    Public Sub UPDATE_MEMBER_MV(ByVal ID As Long)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmdUpdateMemberStatus As New SqlClient.SqlCommand("UPDATE ListOfVoters2016 SET VOTETYPE='MV' WHERE trnno = " & ID & "", conn)
        cmdUpdateMemberStatus.ExecuteNonQuery()
        cmdUpdateMemberStatus.Dispose()
    End Sub

   
End Module

