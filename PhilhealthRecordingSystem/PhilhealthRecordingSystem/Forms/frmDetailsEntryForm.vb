Imports System.IO
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop


Public Class frmDetailsEntryForm

#Region "Common Variable"
    Private dbConnection As New SqlClient.SqlConnection("Data Source=server_jbg; Initial Catalog=Philhealth;Integrated Security=True;")
    Private ComDset As New DataSet
    Private ComDset1 As New DataSet
    Private conn As New SqlClient.SqlConnection("Data Source=server_jbg; Initial Catalog=PHILHEALTH;Integrated Security=True;")
    Private LeaderID As Long
    Private MemberID As Long
    Private rMoveVal As Boolean = False
    Dim Batch_Number As Long
    Dim PHIC_No As String

    Dim CurrentRowIndex As Integer = 0
#End Region


    Dim x(10000000) As String

    Private Sub load_PatientList()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("Select NameOfPatient, NameOfMember FROM    tblCF1  ORDER BY   NameOfPatient, trnno DESC", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                cmbPatient.Items.Clear()
                cmbNameOfMember.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    cmbPatient.Items.Add(.Rows(rowcounter).Item("NameOfPatient").ToString())
                    cmbNameOfMember.Items.Add(.Rows(rowcounter).Item("NameOfMember").ToString())
                Next
                'cmbBrgy.SelectedIndex = 0
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub load_TypeOfMember()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("Select distinct TypeOfMember FROM    tblCF1  ORDER BY    TypeOfMember", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                cmbTypeOfMember.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    cmbTypeOfMember.Items.Add(.Rows(rowcounter).Item("TypeOfMember").ToString())
                Next
                'cmbBrgy.SelectedIndex = 0
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub load_RelationshipList()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("Select distinct  RelationshipToMember FROM    tblCF1  ORDER BY    RelationshipToMember", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                cmbRelToMember.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    cmbRelToMember.Items.Add(.Rows(rowcounter).Item("RelationshipToMember").ToString())
                Next
                'cmbBrgy.SelectedIndex = 0
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub load_Doctors()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT     DRName         FROM tblDoctors  ORDER BY DRName", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                cmbPhysician.Items.Clear()
                cmbSurgeon.Items.Clear()
                cmbVisitingPhys.Items.Clear()
                cmbAnesth.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    cmbPhysician.Items.Add(.Rows(rowcounter).Item("DRName").ToString())
                    cmbSurgeon.Items.Add(.Rows(rowcounter).Item("DRName").ToString())
                    cmbVisitingPhys.Items.Add(.Rows(rowcounter).Item("DRName").ToString())
                    cmbAnesth.Items.Add(.Rows(rowcounter).Item("DRName").ToString())
                Next
                'cmbBrgy.SelectedIndex = 0
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

  

    Private Sub load_Months()
        cmbMonth.Items.Clear()
        Dim xx As Integer = 0
        For xx = 1 To 12
            cmbMonth.Items.Add(MonthName(xx))
        Next
        cmbMonth.Text = MonthName(Month(Now))
        cmbYear.Text = Year(Now)
    End Sub

    Private Sub load_of_patient()

    End Sub

    Private Sub btnExtractICDCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtractICDCodes.Click
        Dim xx, y As Double
        'For BrgyCapt
        'Dim fs As New FileStream("D:\trial progs\reading textfileVOtersListfromPDF\reading textfileVOtersListfromPDF\LOV\PCVL_BUTUAN CITY3_Final.txt", FileMode.Open, FileAccess.Read)
        Dim fs As New FileStream("H:\GTH Softwares\PhilhealthRecordingSystem\ICDCodes2.txt", FileMode.Open, FileAccess.Read)
        'For SK
        'Dim fs As New FileStream("D:\adn Files\eRelated\Brgy Elections 2010\BUTUAN CITY SKPCVL.txt", FileMode.Open, FileAccess.Read)
        'declaring a FileStream to open the file named file.doc with access mode of reading

        cmbAge.Text = ""
        Dim d As New StreamReader(fs)
        'creating a new StreamReader and passing the filestream object fs as argument
        d.BaseStream.Seek(0, SeekOrigin.Begin)
        'Seek method is used to move the cursor to different positions in a file, in this code, to 
        'the beginning
        While d.Peek() > -1
            'peek method of StreamReader object tells how much more data is left in the file
            ''TextBox1.Text &= d.ReadLine()
            cmbAge.Text = d.ReadLine
            x(xx) = cmbAge.Text
            xx = xx + 1
            'displaying text from doc file in the RichTextBox
        End While
        d.Close()
        Call evaluateICDCodes(xx, 0)

    End Sub

    Private Sub evaluateICDCodes(ByVal upBound As Long, ByVal LoBound As Long)
        dbConnection = New SqlConnection("Data Source=server_jbg; Initial Catalog=Philhealth;Integrated Security=True;")
        Dim REC_cOUNT As Long
        Dim y As Long
        dbConnection.Open()


        Dim ICDProfFee As Double
        Dim ICDCode As String = ""
        Dim ICDGroup As String = ""
        Dim ICDDescription As String = ""
        Dim ICDCaseRate As Double
        Dim initialPosition As Integer

        ProgressBar1.Maximum = upBound

        For y = 0 To upBound
            ProgressBar1.Value = y
            cmbAge.Text = x(y)

            If Trim(cmbAge.Text) = "ICD CODE" Then
                ICDCode = x(y + 1)
                ICDCode = Replace(ICDCode, """", "")
                ICDGroup = x(y + 2)
                ICDDescription = x(y + 3)
                ICDDescription = Replace(Replace(ICDDescription, "'", "''"), """", "")
                Dim xxxx As String = x(y + 4)
                ICDCaseRate = Replace((xxxx), """", "")
                Dim xxxxx As String = x(y + 5)
                ICDProfFee = Replace((xxxxx), """", "")
                Dim xxxxxx As String = x(y + 6)
                Dim ICDHeathCareInstFee As Double = Replace((xxxxxx), """", "")

                Dim cmd As New SqlCommand("INSERT INTO tblICDCodes (ICDCode,ICDDescription,ICDGroup,ICDCaseRate,ICDProfFee,ICDHealthCareInstFee) " _
                                     & " VALUES('" & Replace(ICDCode, "�", "Ñ") & "','" & Replace(Replace(ICDGroup, "'", "''"), """", "") & "','" & Replace(ICDDescription, """", "") & "'," & ICDCaseRate & "," & ICDProfFee & "," & ICDHeathCareInstFee & ")", dbConnection)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                y = y + 5
            Else
                ICDCode = x(y + 1)
                ICDCode = Replace(ICDCode, """", "")
                ICDGroup = x(y + 2)
                ICDDescription = x(y + 3)
                ICDDescription = Replace(Replace(ICDDescription, "'", "''"), """", "")
                Dim xxxx As String = x(y + 4)
                ICDCaseRate = Replace((xxxx), """", "")
                Dim xxxxx As String = x(y + 5)
                ICDProfFee = Replace((xxxxx), """", "")
                Dim xxxxxx As String = x(y + 6)
                Dim ICDHeathCareInstFee As Double = Replace((xxxxxx), """", "")

                Dim cmd As New SqlCommand("INSERT INTO tblICDCodes (ICDCode,ICDDescription,ICDGroup,ICDCaseRate,ICDProfFee,ICDHealthCareInstFee) " _
                                     & " VALUES('" & Replace(ICDCode, "�", "Ñ") & "','" & Replace(Replace(ICDGroup, "'", "''"), """", "") & "','" & Replace(ICDDescription, """", "") & "'," & ICDCaseRate & "," & ICDProfFee & "," & ICDHeathCareInstFee & ")", dbConnection)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                y = y + 5
            End If
        Next
        MsgBox(REC_cOUNT)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim xx, y As Double
        'For BrgyCapt
        'Dim fs As New FileStream("D:\trial progs\reading textfileVOtersListfromPDF\reading textfileVOtersListfromPDF\LOV\PCVL_BUTUAN CITY3_Final.txt", FileMode.Open, FileAccess.Read)
        Dim fs As New FileStream("H:\GTH Softwares\PhilhealthRecordingSystem\RVS.txt", FileMode.Open, FileAccess.Read)
        'For SK
        'Dim fs As New FileStream("D:\adn Files\eRelated\Brgy Elections 2010\BUTUAN CITY SKPCVL.txt", FileMode.Open, FileAccess.Read)
        'declaring a FileStream to open the file named file.doc with access mode of reading

        cmbAge.Text = ""
        Dim d As New StreamReader(fs)
        'creating a new StreamReader and passing the filestream object fs as argument
        d.BaseStream.Seek(0, SeekOrigin.Begin)
        'Seek method is used to move the cursor to different positions in a file, in this code, to 
        'the beginning
        While d.Peek() > -1
            'peek method of StreamReader object tells how much more data is left in the file
            ''TextBox1.Text &= d.ReadLine()
            cmbAge.Text = d.ReadLine
            If IsNumeric(cmbAge.Text) And Len(cmbAge.Text) = 5 Then
                x(xx) = Trim(Replace(cmbAge.Text, """", ""))
                Debug.Print(Trim(Replace(cmbAge.Text, """", "")))
            ElseIf IsNumeric(cmbAge.Text) And Len(cmbAge.Text) < 5 Then
                x(xx) = "~""" & cmbAge.Text & """"
                Debug.Print("~""" & cmbAge.Text & """")
            Else
                x(xx) = "~" & cmbAge.Text
                Debug.Print("~" & cmbAge.Text)
            End If
            xx = xx + 1

            'displaying text from doc file in the RichTextBox
        End While
        d.Close()
        Call evaluateRVSCodes(xx, 0)
    End Sub

    Private Sub evaluateRVSCodes(ByVal upBound As Long, ByVal LoBound As Long)
        dbConnection = New SqlConnection("Data Source=server_jbg; Initial Catalog=Philhealth;Integrated Security=True;")
        Dim REC_cOUNT As Long
        Dim y As Long
        dbConnection.Open()



        Dim RVSCode As String = ""
        Dim RVSDescription As String = ""
        Dim RVSCaseRate As Double
        Dim RVSProfFee As Double
        Dim HCareInstFee As Double
        Dim RVSSubGroup As String

        ProgressBar1.Maximum = upBound

        For y = 0 To upBound
            ProgressBar1.Value = y
            cmbAge.Text = x(y)
            'If TextBox1.Text = "" Then
            ' GoTo nextLine
            ' End If

            If IsNumeric(x(y)) Then
                If (Len(x(y)) = 5 And InStr(x(y), "~", CompareMethod.Text) = 0) Then
                    cmbAge.Text = x(y)

                    If InStr(x(y - 1), "~""", CompareMethod.Text) = 0 Then
                        RVSSubGroup = Replace(x(y - 1), "~", "")
                    End If

                    RVSCode = x(y)
                    y = y + 1
                    RVSDescription = Replace(Replace(x(y), "~", ""), """", "")
                    y = y + 1
                    RVSCaseRate = Replace(Replace(x(y), "~", ""), """", "")
                    y = y + 1
                    RVSProfFee = Replace(Replace(x(y), "~", ""), """", "")
                    y = y + 1
                    HCareInstFee = Replace(Replace(x(y), "~", ""), """", "")

                End If
                'insert to database
                Dim cmd As New SqlCommand("INSERT INTO tblRVSCodes (RVSCode,RVSSubGroup,RVSDescription,CaseRate,ProfessionalFee,HealthCareInstitutionFee) " _
                                 & " VALUES('" & RVSCode & "','" & Replace(RVSSubGroup, """", "") & "','" & Replace(Replace(RVSDescription, """", ""), "'", "") & "'," & RVSCaseRate & "," & RVSProfFee & "," & HCareInstFee & ")", dbConnection)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If

nextline:
        Next
        MsgBox(REC_cOUNT)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
        Me.Close()
    End Sub

    
    Private Sub frmDetailsEntryForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call load_Months()
        Call load_PatientList()
        Call load_RelationshipList()
        Call load_TypeOfMember()
        Call load_Doctors()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(cmbPhicNumber.Text) = 0 Then
                MsgBox("PLEASE PROVIDE PHILHEALTH ID NUMBER TO PROCEED, THANK YOU!", MsgBoxStyle.Information, "INSERT ERROR. . .")
                cmbPhicNumber.Focus()
                Exit Sub
            End If
            If btnSave.Text = "&Update" Then
                'Dim strVALUES As String = "productDescription='" & Replace(Replace(txtProductDescription.Text, "'", "''"), """", """") & "',UnitName='" & Replace(cmbUnitType.Text, "'", "''") & "',CategoryName='" & Replace(cmbCategory.Text, "'", "''") & "',UnitPriceCode=" & unitPriceCode & ",ProductDiscount=" & item_discount & ",QtyOnHand=" & txtQTYOnHand.Text & ",reorderpoint=" & txtReorderPoint.Text & ",SupplierID=" & SupplierID & ""
                'Call UPDATE_DATA_TO_DATABASE_USING_ANY_FIELD_AS_PARAMETER("tblPRODUCT", strVALUES, "ProductID_Barcode='" & txtProductBarcode.Text & "'")
            Else
                If NEW_PATIENT_ENTRY_FLAG = True Then
                    'insert CF1
                    Dim strVALUES As String = "'" & cmbMonth.Text & "','" & cmbYear.Text & "','" & Replace(cmbPatient.Text, "'", "''") & "','" & Replace(cmbNameOfMember.Text, "'", "''") & "','" & cmbRelToMember.Text & "'," & cmbAge.Text & ",'" & cmbPhicNumber.Text & "','" & cmbTypeOfMember.Text & "'"
                    Call INSERT_DATA_TO_DATABASE("tblCF1", "Month,Year,NameOfPatient,NameOfMember,RelationshipToMember,Age,PHICNumber,TypeOfMember", strVALUES)
                Else
                    'update CF1

                End If
                NEW_PATIENT_ENTRY_FLAG = False

                'get the trnno of patient (treat as patientID of CF2--PK)
                Dim patientID As Long = getFIELD_VALUE_FROM_DBASE("tblCF1", "TOP 1 trnno", "PHICNumber", cmbPhicNumber.Text)

                'insert to CF2

                Dim strVALUES2 As String = "'" & patientID & "','" & cmbPhicNumber.Text & "','" & dtpDateFiled.Text & "','" & dtpDateAdmitted.Text & "','" & dtpDateDischarge.Text & "','" & cmbCaseType.Text & "','" & Replace(Replace(txtAdmDiagnosis.Text, "'", "''"), """", """") & "','" & Replace(Replace(txtFinalDiagnosis.Text, "'", "''"), """", """") & "'" _
                                            & " ,'" & cmbICD10.Text & "','" & cmbRVS.Text & "','" & cmbPhysician.Text & "','" & cmbSurgeon.Text & "','" & cmbVisitingPhys.Text & "','" & cmbAnesth.Text & "','" & Replace(Replace(cmbRemarks.Text, "'", "''"), """", """") & "'" _
                                            & " ,'" & txtSOA.Text & "','" & txtDateSubmitted.Text & "','" & txtDateTransmitted.Text & "','" & txtRTHDef.Text & "','" & txtRTHReceived.Text & "','" & txtRTHTransmitted.Text & "'," & IIf(txtRefunds.Text = "", 0, txtRefunds.Text) & ",'" & cmbEncodedBy.Text & "'"
                Call INSERT_DATA_TO_DATABASE("tblCF2_OtherInfo", "PatientID, PhilhealthID, DateFiled, DateAdmitted, DateDischarge, CaseType, AdmissionDiagnosis, FinalDiagnosis, ICD10, RVS, " _
                                                    & " AttendingPhysician, OB_Surgeon, VisitingPhysician, Anesthesiologits, Remarks, SOABillNumber, DateSubmitted, DateTransmitted, " _
                                                    & " RTHDeficiency, RTHReceived, RTHTransmitted, Refunds, EncodedBy", strVALUES2)

                'insert to Fees and Charges

                'SELECT     trnno, DateFiled, PatientID, PhilhealthID, RoomAcc, EmerRoomF, LaborRoomF, DeliveryRoomF, OperatingRoomF, PhysVisitF, DeliveriesF, NursingCareF, SurgicalF, 
                'AnesF, TranIVF, ElectApplF, SuppliesF, DrugsMedsF, LabChargesF, NewBornScreenF, OxygenF, XRayF, ECGF, UltrasF, DroplightF, PhototF, ElectrodesF, 
                'OtherChargesF FROM tblFeesandCharges

                Dim strVALUES3 As String = "'" & dtpDateFiled.Text & "','" & patientID & "','" & cmbPhicNumber.Text & "', '" & txtRoomAcc.Text & "','" & txtEmerRoomFee.Text & "','" & txtLaborRoomFee.Text & "','" & txtDelRoomFee.Text & "','" & txtOperRoomFee.Text & "','" & txtPhysDailyVisitFee.Text & "','" & txtDeliveryFee.Text & "','" & txtNursingCareFee.Text & "','" & txtSurgicalFee.Text & "', " _
                                            & "'" & txtAnesFee.Text & "','" & txtTransIVFee.Text & "','" & txtApplianceFee.Text & "','" & txtSuppliesOtherFee.Text & "','" & txtDrugsMedsFee.Text & "','" & txtLabFee.Text & "','" & txtNewBornScreenFee.Text & "','" & txtOxygenFee.Text & "','" & txtXrayFee.Text & "','" & txtECGFee.Text & "','" & txtUltrasoundFee.Text & "','" & txtDroplightFee.Text & "','" & txtPhotoTherapyFee.Text & "','" & txtElectrodsFee.Text & "', " _
                                            & "'" & txtOtherCharges.Text & "'"
                Call INSERT_DATA_TO_DATABASE("tblFeesandCharges", "DateFiled, PatientID, PhilhealthID, RoomAcc, EmerRoomF, LaborRoomF, DeliveryRoomF, OperatingRoomF, PhysVisitF, DeliveriesF, NursingCareF, SurgicalF, " _
                                            & " 'AnesF, TranIVF, ElectApplF, SuppliesF, DrugsMedsF, LabChargesF, NewBornScreenF, OxygenF, XRayF, ECGF, UltrasF, DroplightF, PhototF, ElectrodesF, " _
                                            & " 'OtherChargesF ", strVALUES3)

                MsgBox("Records successfully saved, thank you!", MsgBoxStyle.Information, "S A V E D . . .")
                End If
                'Call LoadProductListing(txtProductBarcode.Text)

                btnNew.Enabled = True
                btnSave.Text = "&Save"
                btnClose.Text = "&Close"
                btnSave.Enabled = False
                ''Call clearControls()
                ''Call change_bkGround(Color.BurlyWood)
                'set all entry controls to read only mode
                ''Call change_ReadOnly(True)
                ''LoadProductListing_byBarcode(txtProductBarcode.Text)
        Catch
            MsgBox(Err.Description)
            Exit Sub
        End Try
    End Sub


    Private Sub cmbRVS_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRVS.GotFocus
        lblStatus.Visible = True
        Timer1.Enabled = True
        lblStatus.Top = GroupBox3.Top + cmbRVS.Top - cmbRVS.Height
        lblStatus.Left = cmbRVS.Left
        lblStatus.Text = "Press F2 to view RVS Code listing. . ."
    End Sub


    Private Sub cmbRVS_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRVS.LostFocus
        lblStatus.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub cmbICD10_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbICD10.GotFocus
        lblStatus.Visible = True
        Timer1.Enabled = True
        lblStatus.Top = GroupBox3.Top + Label14.Top
        lblStatus.Left = cmbICD10.Left
        lblStatus.Text = "Press F2 to view ICD Code listing. . ."
    End Sub

    Private Sub cmbICD10_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbICD10.LostFocus
        lblStatus.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub cmbICD10_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbICD10.KeyDown
        If e.KeyCode = Keys.F2 Then
            Call load_ICDRVSCodes()
            TabControl1.SelectedIndex = 0
            grpICDRVSCodes.Height = 612
            grpICDRVSCodes.Width = Me.Width - 200
            grpICDRVSCodes.Visible = True
            txtSearchICDCode.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            cmbRVS.Focus()
        End If
    End Sub

    Private Sub load_ICDRVSCodes()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT   ICDCode, ICDDescription, ICDGroup, ICDCaseRate, ICDProfFee, ICDHealthCareInstFee " _
                                        & " FROM tblICDCodes Where ICDCode like '%" & txtSearchICDCode.Text & "%' OR ICDDescription like '%" & txtSearchICDCode.Text & "%' ORDER BY ICDGroup", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                'ICDCodes
                CheckedListBox1.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    CheckedListBox1.Items.Add(.Rows(rowcounter).Item("ICDCode").ToString().PadRight(10) & "--" & .Rows(rowcounter).Item("ICDDescription").ToString().PadRight(10) & " ;Rate" & .Rows(rowcounter).Item("ICDCaseRate").ToString() & " ;PF" & .Rows(rowcounter).Item("ICDProfFee").ToString() & " ;HCIF" & .Rows(rowcounter).Item("ICDHealthCareInstFee").ToString())
                Next
                'cmbBrgy.SelectedIndex = 0
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub load_RVSOnly()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("Select RVSCode, RVSGroup, RVSSubGroup, RVSDescription, CaseRate, ProfessionalFee, HealthCareInstitutionFee " _
                                        & " FROM  tblRVSCodes Where RVSCode like '%" & txtSearchRVS.Text & "%' OR RVSDescription like '%" & txtSearchRVS.Text & "%' ORDER BY  RVSDescription", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                'ICDCodes
                CheckedListBox2.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    CheckedListBox2.Items.Add(.Rows(rowcounter).Item("RVSCode").ToString().PadRight(10) & "--" & .Rows(rowcounter).Item("RVSDescription").ToString().PadRight(10) & " ;Rate" & .Rows(rowcounter).Item("CaseRate").ToString() & " ;PF" & .Rows(rowcounter).Item("ProfessionalFee").ToString() & " ;HCIF" & .Rows(rowcounter).Item("HealthCareInstitutionFee").ToString())
                Next
                'cmbBrgy.SelectedIndex = 0
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub txtSearchICDCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchICDCode.TextChanged
       

        Dim checkedItems As New List(Of Object)(CheckedListBox1.CheckedItems.Count)
        For Each i As Object In CheckedListBox1.CheckedItems
            If i = "" Then Exit For
            checkedItems.Add(i)
        Next

        Call load_ICDRVSCodes()

        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            If checkedItems.Contains(CheckedListBox1.Items(i)) Then
                CheckedListBox1.SetItemChecked(i, True)
            End If
        Next
    End Sub


    Private Sub CheckedListBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CheckedListBox1.MouseClick
        If cmbICD10.Text = "" Then
            cmbICD10.Text = Trim(Replace(StrReverse(Mid(StrReverse(CheckedListBox1.Text), InStr(StrReverse(CheckedListBox1.Text), "--", CompareMethod.Text))), "--", ""))
        Else
            cmbICD10.Text = cmbICD10.Text & ";" & Trim(Replace(StrReverse(Mid(StrReverse(CheckedListBox1.Text), InStr(StrReverse(CheckedListBox1.Text), "--", CompareMethod.Text))), "--", ""))
        End If

    End Sub

    Private Sub txtCloseRVS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCloseRVS.Click
        grpICDRVSCodes.Visible = False
        cmbRVS.Text = ""
        For i = 0 To CheckedListBox2.CheckedItems.Count - 1
            'cmbICD10.Text = (CheckedListBox1.CheckedItems(i))
            If cmbRVS.Text = "" Then
                cmbRVS.Text = Trim(Replace(StrReverse(Mid(StrReverse(CheckedListBox2.CheckedItems(i)), InStr(StrReverse(CheckedListBox2.CheckedItems(i)), "--", CompareMethod.Text))), "--", ""))
            Else
                cmbRVS.Text = cmbRVS.Text & ";" & Trim(Replace(StrReverse(Mid(StrReverse(CheckedListBox2.CheckedItems(i)), InStr(StrReverse(CheckedListBox2.CheckedItems(i)), "--", CompareMethod.Text))), "--", ""))
            End If
        Next i
    End Sub

    Private Sub txtSearchRVS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchRVS.TextChanged
        Call load_RVSOnly()
    End Sub


    Private Sub cmbRVS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbRVS.KeyDown
        If e.KeyCode = Keys.F2 Then
            Call load_RVSOnly()
            TabControl1.SelectedIndex = 1
            grpICDRVSCodes.Height = 612
            grpICDRVSCodes.Width = Me.Width
            grpICDRVSCodes.Visible = True
            txtSearchRVS.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            txtRoomAcc.Focus()
        End If
    End Sub

    Private Sub CheckedListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox2.SelectedIndexChanged
        If cmbRVS.Text = "" Then
            cmbRVS.Text = Trim(Replace(StrReverse(Mid(StrReverse(CheckedListBox2.Text), InStr(StrReverse(CheckedListBox2.Text), "--", CompareMethod.Text))), "--", ""))
        Else
            cmbRVS.Text = cmbRVS.Text & ";" & Trim(Replace(StrReverse(Mid(StrReverse(CheckedListBox2.Text), InStr(StrReverse(CheckedListBox2.Text), "--", CompareMethod.Text))), "--", ""))
        End If
    End Sub

    Private Sub txtRoomAcc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRoomAcc.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmerRoomFee.Focus()
        End If
    End Sub

    Private Sub txtRoomAcc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRoomAcc.Validated
        If Len(txtRoomAcc.Text) > 0 Then
            If Not IsNumeric(txtRoomAcc.Text) Then
                MsgBox("NOT A NUMBER!")
                txtRoomAcc.Focus()
                Exit Sub
            End If
            txtRoomAcc.Text = FormatNumber(txtRoomAcc.Text, 2, , , TriState.True)
        Else
            txtRoomAcc.Text = "0.00"
        End If
    End Sub

    Private Sub txtEmerRoomFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmerRoomFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtLaborRoomFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtRoomAcc.Focus()
        End If
    End Sub

    Private Sub txtEmerRoomFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmerRoomFee.Validated
        If Len(txtEmerRoomFee.Text) > 0 Then
            If Not IsNumeric(txtEmerRoomFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtRoomAcc.Focus()
                Exit Sub
            End If
            txtEmerRoomFee.Text = FormatNumber(txtEmerRoomFee.Text, 2, , , TriState.True)
        Else
            txtEmerRoomFee.Text = "0.00"
        End If
    End Sub

    Private Sub txtLaborRoomFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLaborRoomFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDelRoomFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtEmerRoomFee.Focus()
        End If
    End Sub

    Private Sub txtLaborRoomFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLaborRoomFee.Validated
        If Len(txtLaborRoomFee.Text) > 0 Then
            If Not IsNumeric(txtLaborRoomFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtRoomAcc.Focus()
                Exit Sub
            End If
            txtLaborRoomFee.Text = FormatNumber(txtLaborRoomFee.Text, 2, , , TriState.True)
        Else
            txtLaborRoomFee.Text = "0.00"
        End If
    End Sub

    Private Sub txtDelRoomFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDelRoomFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOperRoomFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtLaborRoomFee.Focus()
        End If
    End Sub

    Private Sub txtDelRoomFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDelRoomFee.Validated
        If Len(txtDelRoomFee.Text) > 0 Then
            If Not IsNumeric(txtDelRoomFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtRoomAcc.Focus()
                Exit Sub
            End If
            txtDelRoomFee.Text = FormatNumber(txtDelRoomFee.Text, 2, , , TriState.True)
        Else
            txtDelRoomFee.Text = "0.00"
        End If
    End Sub

    Private Sub txtOperRoomFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOperRoomFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPhysDailyVisitFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtDelRoomFee.Focus()
        End If
    End Sub

    Private Sub txtOperRoomFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOperRoomFee.Validated
        If Len(txtOperRoomFee.Text) > 0 Then
            If Not IsNumeric(txtOperRoomFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtOperRoomFee.Focus()
                Exit Sub
            End If
            txtOperRoomFee.Text = FormatNumber(txtOperRoomFee.Text, 2, , , TriState.True)
        Else
            txtOperRoomFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtPhysDailyVisitFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPhysDailyVisitFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDeliveryFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtOperRoomFee.Focus()
        End If
    End Sub

    Private Sub txtPhysDailyVisitFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPhysDailyVisitFee.Validated
        If Len(txtPhysDailyVisitFee.Text) > 0 Then
            If Not IsNumeric(txtPhysDailyVisitFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtPhysDailyVisitFee.Focus()
                Exit Sub
            End If
            txtPhysDailyVisitFee.Text = FormatNumber(txtPhysDailyVisitFee.Text, 2, , , TriState.True)
        Else
            txtPhysDailyVisitFee.Text = "0.00"
        End If
    End Sub

    Private Sub txtDeliveryFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeliveryFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNursingCareFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtPhysDailyVisitFee.Focus()
        End If
    End Sub

    Private Sub txtDeliveryFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDeliveryFee.Validated
        If Len(txtDeliveryFee.Text) > 0 Then
            If Not IsNumeric(txtDeliveryFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtDeliveryFee.Focus()
                Exit Sub
            End If
            txtDeliveryFee.Text = FormatNumber(txtDeliveryFee.Text, 2, , , TriState.True)
        Else
            txtDeliveryFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtNursingCareFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNursingCareFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSurgicalFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtDeliveryFee.Focus()
        End If
    End Sub

    Private Sub txtNursingCareFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNursingCareFee.Validated
        If Len(txtNursingCareFee.Text) > 0 Then
            If Not IsNumeric(txtNursingCareFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtNursingCareFee.Focus()
                Exit Sub
            End If
            txtNursingCareFee.Text = FormatNumber(txtNursingCareFee.Text, 2, , , TriState.True)
        Else
            txtNursingCareFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtSurgicalFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSurgicalFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAnesFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtNursingCareFee.Focus()
        End If
    End Sub

    Private Sub txtSurgicalFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSurgicalFee.Validated
        If Len(txtSurgicalFee.Text) > 0 Then
            If Not IsNumeric(txtSurgicalFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtSurgicalFee.Focus()
                Exit Sub
            End If
            txtSurgicalFee.Text = FormatNumber(txtSurgicalFee.Text, 2, , , TriState.True)
        Else
            txtSurgicalFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtAnesFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAnesFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTransIVFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtSurgicalFee.Focus()
        End If
    End Sub

    Private Sub txtAnesFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAnesFee.Validated
        If Len(txtAnesFee.Text) > 0 Then
            If Not IsNumeric(txtAnesFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtAnesFee.Focus()
                Exit Sub
            End If
            txtAnesFee.Text = FormatNumber(txtAnesFee.Text, 2, , , TriState.True)
        Else
            txtAnesFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtTransIVFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTransIVFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtApplianceFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtAnesFee.Focus()
        End If
    End Sub

    Private Sub txtTransIVFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTransIVFee.Validated
        If Len(txtTransIVFee.Text) > 0 Then
            If Not IsNumeric(txtTransIVFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtTransIVFee.Focus()
                Exit Sub
            End If
            txtTransIVFee.Text = FormatNumber(txtTransIVFee.Text, 2, , , TriState.True)
        Else
            txtTransIVFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtApplianceFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtApplianceFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSuppliesOtherFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtTransIVFee.Focus()
        End If
    End Sub

    Private Sub txtApplianceFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApplianceFee.Validated
        If Len(txtApplianceFee.Text) > 0 Then
            If Not IsNumeric(txtApplianceFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtApplianceFee.Focus()
                Exit Sub
            End If
            txtApplianceFee.Text = FormatNumber(txtApplianceFee.Text, 2, , , TriState.True)
        Else
            txtApplianceFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtSuppliesOtherFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSuppliesOtherFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDrugsMedsFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtApplianceFee.Focus()
        End If
    End Sub

    Private Sub txtSuppliesOtherFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSuppliesOtherFee.Validated
        If Len(txtSuppliesOtherFee.Text) > 0 Then
            If Not IsNumeric(txtSuppliesOtherFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtSuppliesOtherFee.Focus()
                Exit Sub
            End If
            txtSuppliesOtherFee.Text = FormatNumber(txtSuppliesOtherFee.Text, 2, , , TriState.True)
        Else
            txtSuppliesOtherFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtDrugsMedsFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDrugsMedsFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtLabFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtSuppliesOtherFee.Focus()
        End If
    End Sub

    Private Sub txtDrugsMedsFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDrugsMedsFee.Validated
        If Len(txtDrugsMedsFee.Text) > 0 Then
            If Not IsNumeric(txtDrugsMedsFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtDrugsMedsFee.Focus()
                Exit Sub
            End If
            txtDrugsMedsFee.Text = FormatNumber(txtDrugsMedsFee.Text, 2, , , TriState.True)
        Else
            txtDrugsMedsFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtLabFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLabFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNewBornScreenFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtDrugsMedsFee.Focus()
        End If
    End Sub

    Private Sub txtLabFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLabFee.Validated
        If Len(txtLabFee.Text) > 0 Then
            If Not IsNumeric(txtLabFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtLabFee.Focus()
                Exit Sub
            End If
            txtLabFee.Text = FormatNumber(txtLabFee.Text, 2, , , TriState.True)
        Else
            txtLabFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtNewBornScreenFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNewBornScreenFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOxygenFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtLabFee.Focus()
        End If
    End Sub

    Private Sub txtNewBornScreenFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNewBornScreenFee.Validated
        If Len(txtNewBornScreenFee.Text) > 0 Then
            If Not IsNumeric(txtNewBornScreenFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtNewBornScreenFee.Focus()
                Exit Sub
            End If
            txtNewBornScreenFee.Text = FormatNumber(txtNewBornScreenFee.Text, 2, , , TriState.True)
        Else
            txtNewBornScreenFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtOxygenFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOxygenFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtXrayFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtNewBornScreenFee.Focus()
        End If
    End Sub

    Private Sub txtOxygenFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOxygenFee.Validated
        If Len(txtOxygenFee.Text) > 0 Then
            If Not IsNumeric(txtOxygenFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtOxygenFee.Focus()
                Exit Sub
            End If
            txtOxygenFee.Text = FormatNumber(txtOxygenFee.Text, 2, , , TriState.True)
        Else
            txtOxygenFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtXrayFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtXrayFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtECGFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtOxygenFee.Focus()
        End If
    End Sub

    Private Sub txtXrayFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtXrayFee.Validated
        If Len(txtXrayFee.Text) > 0 Then
            If Not IsNumeric(txtXrayFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtXrayFee.Focus()
                Exit Sub
            End If
            txtXrayFee.Text = FormatNumber(txtXrayFee.Text, 2, , , TriState.True)
        Else
            txtXrayFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtECGFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtECGFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtUltrasoundFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtXrayFee.Focus()
        End If
    End Sub

    Private Sub txtECGFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtECGFee.Validated
        If Len(txtECGFee.Text) > 0 Then
            If Not IsNumeric(txtECGFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtECGFee.Focus()
                Exit Sub
            End If
            txtECGFee.Text = FormatNumber(txtECGFee.Text, 2, , , TriState.True)
        Else
            txtECGFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtUltrasoundFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUltrasoundFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDroplightFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtECGFee.Focus()
        End If
    End Sub

    Private Sub txtUltrasoundFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUltrasoundFee.Validated
        If Len(txtUltrasoundFee.Text) > 0 Then
            If Not IsNumeric(txtUltrasoundFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtUltrasoundFee.Focus()
                Exit Sub
            End If
            txtUltrasoundFee.Text = FormatNumber(txtUltrasoundFee.Text, 2, , , TriState.True)
        Else
            txtUltrasoundFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtDroplightFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDroplightFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPhotoTherapyFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtUltrasoundFee.Focus()
        End If
    End Sub

    Private Sub txtDroplightFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDroplightFee.Validated
        If Len(txtDroplightFee.Text) > 0 Then
            If Not IsNumeric(txtDroplightFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtDroplightFee.Focus()
                Exit Sub
            End If
            txtDroplightFee.Text = FormatNumber(txtDroplightFee.Text, 2, , , TriState.True)
        Else
            txtDroplightFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtPhotoTherapyFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPhotoTherapyFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtElectrodsFee.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtDroplightFee.Focus()
        End If
    End Sub

    Private Sub txtPhotoTherapyFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPhotoTherapyFee.Validated
        If Len(txtPhotoTherapyFee.Text) > 0 Then
            If Not IsNumeric(txtPhotoTherapyFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtPhotoTherapyFee.Focus()
                Exit Sub
            End If
            txtPhotoTherapyFee.Text = FormatNumber(txtPhotoTherapyFee.Text, 2, , , TriState.True)
        Else
            txtPhotoTherapyFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtElectrodsFee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtElectrodsFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOtherCharges.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtPhotoTherapyFee.Focus()
        End If
    End Sub

    Private Sub txtElectrodsFee_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtElectrodsFee.Validated
        If Len(txtElectrodsFee.Text) > 0 Then
            If Not IsNumeric(txtElectrodsFee.Text) Then
                MsgBox("NOT A NUMBER!")
                txtElectrodsFee.Focus()
                Exit Sub
            End If
            txtElectrodsFee.Text = FormatNumber(txtElectrodsFee.Text, 2, , , TriState.True)
        Else
            txtElectrodsFee.Text = "0.00"
        End If

    End Sub

    Private Sub txtOtherCharges_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOtherCharges.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbPhysician.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtElectrodsFee.Focus()
        End If
    End Sub

    Private Sub txtOtherCharges_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOtherCharges.Validated
        If Len(txtOtherCharges.Text) > 0 Then
            If Not IsNumeric(txtOtherCharges.Text) Then
                MsgBox("NOT A NUMBER!")
                txtOtherCharges.Focus()
                Exit Sub
            End If
            txtOtherCharges.Text = FormatNumber(txtOtherCharges.Text, 2, , , TriState.True)
        Else
            txtOtherCharges.Text = "0.00"
        End If

    End Sub

    Private Sub cmbPhysician_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbPhysician.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbSurgeon.Focus()
        End If
    End Sub

    Private Sub cmbPhysician_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPhysician.SelectedIndexChanged

    End Sub

    Private Sub cmbSurgeon_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSurgeon.DropDown
      
    End Sub

    Private Sub cmbSurgeon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbSurgeon.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbVisitingPhys.Focus()
        End If
    End Sub

    Private Sub cmbVisitingPhys_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbVisitingPhys.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbAnesth.Focus()
        End If
    End Sub

    Private Sub cmbAnesth_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbAnesth.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbRemarks.Focus()
        End If
    End Sub

    Private Sub cmbRemarks_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSOA.Focus()
        End If
    End Sub

    Private Sub txtSOA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSOA.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDateSubmitted.Focus()
        End If
    End Sub

    Private Sub txtDateSubmitted_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDateSubmitted.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDateTransmitted.Focus()
        End If
    End Sub

    Private Sub txtDateSubmitted_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDateSubmitted.TextChanged

    End Sub

    Private Sub txtDateTransmitted_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDateTransmitted.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRTHDef.Focus()
        End If
    End Sub

    Private Sub txtRTHDef_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRTHDef.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRTHReceived.Focus()
        End If
    End Sub

    Private Sub txtRTHReceived_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRTHReceived.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRTHTransmitted.Focus()
        End If
    End Sub

    Private Sub txtRTHTransmitted_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRTHTransmitted.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRefunds.Focus()
        End If
    End Sub

    Private Sub txtRefunds_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRefunds.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbEncodedBy.Focus()
        End If
    End Sub

    Private Sub txtRefunds_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRefunds.Validated
        If Len(txtRefunds.Text) > 0 Then
            If Not IsNumeric(txtRefunds.Text) Then
                MsgBox("NOT A NUMBER!")
                txtRefunds.Focus()
                Exit Sub
            End If
            txtRefunds.Text = FormatNumber(txtRefunds.Text, 2, , , TriState.True)
        Else
            txtRefunds.Text = "0.00"
        End If
    End Sub

    Private Sub cmbEncodedBy_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbEncodedBy.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub cmbMonth_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbMonth.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbYear.Focus()
        End If
    End Sub

    Private Sub cmbYear_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbYear.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbPatient.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            cmbMonth.Focus()
        End If
    End Sub

    Private Sub cmbPatient_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbPatient.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbNameOfMember.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            cmbYear.Focus()
        End If
    End Sub

    Private Sub cmbNameOfMember_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbNameOfMember.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbTypeOfMember.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            cmbPatient.Focus()
        End If
    End Sub

    Private Sub cmbTypeOfMember_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTypeOfMember.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbRelToMember.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            cmbNameOfMember.Focus()
        End If
    End Sub

    Private Sub cmbRelToMember_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbRelToMember.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbPhicNumber.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            cmbTypeOfMember.Focus()
        End If
    End Sub

    Private Sub cmbPhicNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbPhicNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbAge.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            cmbRelToMember.Focus()
        End If
    End Sub

    Private Sub cmbAge_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbAge.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpDateFiled.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            cmbPhicNumber.Focus()
        End If
    End Sub

    Private Sub dtpDateFiled_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDateFiled.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpDateAdmitted.Focus()
        End If
    End Sub

    Private Sub dtpDateAdmitted_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDateAdmitted.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpDateDischarge.Focus()
        End If
    End Sub

    Private Sub dtpDateDischarge_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDateDischarge.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbCaseType.Focus()
        End If
    End Sub

    Private Sub cmbCaseType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCaseType.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAdmDiagnosis.Focus()
        End If
    End Sub

    Private Sub txtAdmDiagnosis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAdmDiagnosis.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFinalDiagnosis.Focus()
        End If
    End Sub

    Private Sub txtFinalDiagnosis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFinalDiagnosis.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbICD10.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        cmbICD10.Text = ""
        grpICDRVSCodes.Visible = False

        For i = 0 To CheckedListBox1.CheckedItems.Count - 1
            'cmbICD10.Text = (CheckedListBox1.CheckedItems(i))
            If cmbICD10.Text = "" Then
                cmbICD10.Text = Trim(Replace(StrReverse(Mid(StrReverse(CheckedListBox1.CheckedItems(i)), InStr(StrReverse(CheckedListBox1.CheckedItems(i)), "--", CompareMethod.Text))), "--", ""))
            Else
                cmbICD10.Text = cmbICD10.Text & ";" & Trim(Replace(StrReverse(Mid(StrReverse(CheckedListBox1.CheckedItems(i)), InStr(StrReverse(CheckedListBox1.CheckedItems(i)), "--", CompareMethod.Text))), "--", ""))
            End If
        Next i

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If lblStatus.ForeColor = Color.Red Then
            lblStatus.ForeColor = Color.Blue
        Else
            lblStatus.ForeColor = Color.Red
        End If
    End Sub

   

    Private Sub cmbICD10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbICD10.SelectedIndexChanged

    End Sub


    Private Sub cmbRVS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRVS.SelectedIndexChanged

    End Sub

    Private Sub btnCloseICDRVSCodes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCloseICDRVSCodes.Click

    End Sub
End Class