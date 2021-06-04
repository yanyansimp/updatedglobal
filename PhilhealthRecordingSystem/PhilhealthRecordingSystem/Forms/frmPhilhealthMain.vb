Public Class frmMain

#Region "CommonFunctions"
    Private conn As New SqlClient.SqlConnection("Data Source=server_jbg; Initial Catalog=PHILHEALTH;Integrated Security=True;")
    Private ComDset As New DataSet
    Private ComDset1 As New DataSet
    Private LeaderID As Long
    Private MemberID As Long
    Private rMoveVal As Boolean = False
    Dim Batch_Number As Long
    Dim PHIC_No As String

    Dim CurrentRowIndex As Integer = 0
#End Region

    Dim SupplierID As Long
    Dim unitPriceCode As Long

    Private Sub load_PatientList()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("Select NameOfPatient, NameOfMember, RelationshipToMember, Age, PHICNumber, Month, Year, trnno,TypeOfMember " _
                                    & " FROM    tblCF1 where  NameOfPatient like '%" & txtSearch.Text & "%' or PHICNumber like '%" & txtSearch.Text & "%' ORDER BY   NameOfPatient, trnno DESC", conn)
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

    Private Sub load_Patient_AdmissionList()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT     trnno, PatientID, PhilhealthID, DateFiled, DateAdmitted, DateDischarge, CaseType, AdmissionDiagnosis, FinalDiagnosis, ICD10, RVS, AttendingPhysician, " _
                                                & " OB_Surgeon, VisitingPhysician, Anesthesiologits, Remarks, SOABillNumber, DateSubmitted, DateTransmitted, RTHDeficiency, RTHReceived, RTHTransmitted, " _
                                                & " Refunds, EncodedBy        FROM tblCF2_OtherInfo  WHERE     (PhilhealthID = '" & PHIC_No & "')", conn)
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
                DataGridView2.DataSource = dsDataset.Tables(0)
                DataGridView2.AutoResizeColumns()

            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub


    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call load_PatientList()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Call load_PatientList()
    End Sub

    Private Sub btnNewPatientEntryForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewPatientEntryForm.Click
        NEW_PATIENT_ENTRY_FLAG = True
        Dim frm As New frmDetailsEntryForm
        frm.btnNew.Enabled = False
        frm.cmbPatient.Focus()
        frm.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Call load_admission_list()
        Call load_Patient_AdmissionList()
    End Sub

    Private Sub load_admission_list()
        If DataGridView1.Rows.Count > 0 Then
            With DataGridView1
                Try
                    If Me.DataGridView1.SelectedRows.Count > 0 Then ' AndAlso Not Me.DataGridView1.SelectedRows(0).Index = Me.DataGridView1.Rows.Count - 1 Then

                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        lblPatientName.Text = .Item(0, .CurrentCellAddress.Y).Value
                        PHIC_No = .Item(4, .CurrentCellAddress.Y).Value
                        .EditMode = DataGridViewEditMode.EditProgrammatically
                    Else
                        .EndEdit()
                    End If
                Catch
                    MsgBox(Err.Description)
                    Exit Sub
                End Try
            End With
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Visible = True
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If Len(lblPatientName.Text) = 0 Then
            MsgBox("Please click patient name before adding New Admission Record, Thank you!", MsgBoxStyle.Information, "New Record. . .")
        Else
            Dim frm As New frmDetailsEntryForm
            'load the CF1 details from DatagridView1
            'NameOfPatient, NameOfMember, RelationshipToMember, Age, PHICNumber, Month, Year, trnno
            With DataGridView1
                frm.cmbMonth.Text = .Item(5, .CurrentCellAddress.Y).Value
                frm.cmbYear.Text = .Item(6, .CurrentCellAddress.Y).Value
                frm.dtpDateFiled.Text = DataGridView2.Item(3, DataGridView2.CurrentCellAddress.Y).Value
                frm.cmbPatient.Text = .Item(0, .CurrentCellAddress.Y).Value
                frm.cmbNameOfMember.Text = .Item(1, .CurrentCellAddress.Y).Value
                frm.cmbTypeOfMember.Text = IIf(IsDBNull(.Item(8, .CurrentCellAddress.Y).Value), "", .Item(8, .CurrentCellAddress.Y).Value)
                frm.cmbRelToMember.Text = .Item(2, .CurrentCellAddress.Y).Value
                frm.cmbPhicNumber.Text = .Item(4, .CurrentCellAddress.Y).Value
                frm.cmbAge.Text = IIf(IsDBNull(.Item(3, .CurrentCellAddress.Y).Value), "", .Item(3, .CurrentCellAddress.Y).Value)
            End With

            frm.ShowDialog()
        End If
    End Sub

    Private Sub EditTheSelectedAdmissionRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditTheSelectedAdmissionRecordToolStripMenuItem.Click
        If DataGridView2.SelectedRows.Count > 0 Then
            Dim frm As New frmDetailsEntryForm
            'load the CF1 details from DatagridView1
            'NameOfPatient, NameOfMember, RelationshipToMember, Age, PHICNumber, Month, Year, trnno
            With DataGridView1
                frm.cmbMonth.Text = .Item(5, .CurrentCellAddress.Y).Value
                frm.cmbYear.Text = .Item(6, .CurrentCellAddress.Y).Value
                frm.cmbPatient.Text = .Item(0, .CurrentCellAddress.Y).Value
                frm.cmbNameOfMember.Text = .Item(1, .CurrentCellAddress.Y).Value
                frm.cmbTypeOfMember.Text = IIf(IsDBNull(.Item(8, .CurrentCellAddress.Y).Value), "", .Item(8, .CurrentCellAddress.Y).Value)
                frm.cmbRelToMember.Text = .Item(2, .CurrentCellAddress.Y).Value
                frm.cmbPhicNumber.Text = .Item(4, .CurrentCellAddress.Y).Value
                frm.cmbAge.Text = IIf(IsDBNull(.Item(3, .CurrentCellAddress.Y).Value), "", .Item(3, .CurrentCellAddress.Y).Value)
            End With
            'trnno, PatientID, PhilhealthID, DateFiled, DateAdmitted, DateDischarge, CaseType, AdmissionDiagnosis, FinalDiagnosis, ICD10, RVS, AttendingPhysician, " _
            'OB_Surgeon, VisitingPhysician, Anesthesiologits, Remarks, SOABillNumber, DateSubmitted, DateTransmitted, RTHDeficiency, RTHReceived, RTHTransmitted, " _
            'Refunds, EncodedBy
            With DataGridView2
                frm.dtpDateFiled.Text = IIf(IsDBNull(.Item(3, .CurrentCellAddress.Y).Value), "", .Item(3, .CurrentCellAddress.Y).Value)
                frm.dtpDateAdmitted.Text = IIf(IsDBNull(.Item(4, .CurrentCellAddress.Y).Value), "", .Item(4, .CurrentCellAddress.Y).Value)
                frm.dtpDateDischarge.Text = IIf(IsDBNull(.Item(5, .CurrentCellAddress.Y).Value), "", .Item(5, .CurrentCellAddress.Y).Value)
                frm.cmbCaseType.Text = IIf(IsDBNull(.Item(6, .CurrentCellAddress.Y).Value), "", .Item(6, .CurrentCellAddress.Y).Value)
                frm.txtAdmDiagnosis.Text = IIf(IsDBNull(.Item(7, .CurrentCellAddress.Y).Value), "", .Item(7, .CurrentCellAddress.Y).Value)
                frm.txtFinalDiagnosis.Text = IIf(IsDBNull(.Item(8, .CurrentCellAddress.Y).Value), "", .Item(8, .CurrentCellAddress.Y).Value)
                frm.cmbICD10.Text = IIf(IsDBNull(.Item(9, .CurrentCellAddress.Y).Value), "", .Item(9, .CurrentCellAddress.Y).Value)
                frm.cmbRVS.Text = IIf(IsDBNull(.Item(10, .CurrentCellAddress.Y).Value), "", .Item(10, .CurrentCellAddress.Y).Value)
                frm.cmbPhysician.Text = IIf(IsDBNull(.Item(11, .CurrentCellAddress.Y).Value), "", .Item(11, .CurrentCellAddress.Y).Value)
                frm.cmbSurgeon.Text = IIf(IsDBNull(.Item(12, .CurrentCellAddress.Y).Value), "", .Item(12, .CurrentCellAddress.Y).Value)
                frm.cmbVisitingPhys.Text = IIf(IsDBNull(.Item(13, .CurrentCellAddress.Y).Value), "", .Item(13, .CurrentCellAddress.Y).Value)
                frm.cmbAnesth.Text = IIf(IsDBNull(.Item(14, .CurrentCellAddress.Y).Value), "", .Item(14, .CurrentCellAddress.Y).Value)
                frm.cmbRemarks.Text = IIf(IsDBNull(.Item(15, .CurrentCellAddress.Y).Value), "", .Item(15, .CurrentCellAddress.Y).Value)
                frm.txtSOA.Text = IIf(IsDBNull(.Item(16, .CurrentCellAddress.Y).Value), "", .Item(16, .CurrentCellAddress.Y).Value)
                frm.txtDateSubmitted.Text = IIf(IsDBNull(.Item(17, .CurrentCellAddress.Y).Value), "", .Item(17, .CurrentCellAddress.Y).Value)
                frm.txtDateTransmitted.Text = IIf(IsDBNull(.Item(18, .CurrentCellAddress.Y).Value), "", .Item(18, .CurrentCellAddress.Y).Value)
                frm.txtRTHDef.Text = IIf(IsDBNull(.Item(19, .CurrentCellAddress.Y).Value), "", .Item(19, .CurrentCellAddress.Y).Value)
                frm.txtRTHReceived.Text = IIf(IsDBNull(.Item(20, .CurrentCellAddress.Y).Value), "", .Item(20, .CurrentCellAddress.Y).Value)
                frm.txtRTHTransmitted.Text = IIf(IsDBNull(.Item(21, .CurrentCellAddress.Y).Value), "", .Item(21, .CurrentCellAddress.Y).Value)
                frm.txtRefunds.Text = IIf(IsDBNull(.Item(22, .CurrentCellAddress.Y).Value), "", .Item(22, .CurrentCellAddress.Y).Value)
                frm.cmbEncodedBy.Text = IIf(IsDBNull(.Item(23, .CurrentCellAddress.Y).Value), "", .Item(23, .CurrentCellAddress.Y).Value)
            End With
            'trnno, PatientID, PhilhealthID, RoomAcc, EmerRoomF, LaborRoomF, DeliveryRoomF, OperatingRoomF, PhysVisitF, DeliveriesF, NursingCareF, SurgicalF, AnesF, 
            'TranIVF, ElectApplF, SuppliesF, DrugsMedsF, LabChargesF, NewBornScreenF, OxygenF, XRayF, ECGF, UltrasF, DroplightF, PhototF, ElectrodesF, OtherChargesF
            'FROM(tblFeesandCharges)
            Dim dfiled As String = (DataGridView2.Item(3, DataGridView2.CurrentCellAddress.Y).Value)

            sqladapter = New SqlClient.SqlDataAdapter("SELECT   RoomAcc, EmerRoomF, LaborRoomF, DeliveryRoomF, OperatingRoomF, PhysVisitF, DeliveriesF, NursingCareF, SurgicalF, AnesF, " _
                                                    & " TranIVF, ElectApplF, SuppliesF, DrugsMedsF, LabChargesF, NewBornScreenF, OxygenF, XRayF, ECGF, UltrasF, DroplightF, PhototF, ElectrodesF, OtherChargesF " _
                                                    & " FROM tblFeesandCharges  WHERE     (PhilhealthID = '" & PHIC_No & "') AND DateFiled = '" & dfiled & "'", conn)
            dsDataset = New DataSet
            dsDataset.Reset()
            sqladapter.Fill(dsDataset, "a")
            With dsDataset.Tables("a")
                If .Rows.Count > 0 Then
                    frm.txtRoomAcc.Text = dsDataset.Tables("a").Rows(0).Item("RoomAcc").ToString()
                    frm.txtEmerRoomFee.Text = dsDataset.Tables("a").Rows(0).Item("EmerRoomF").ToString()
                    frm.txtLaborRoomFee.Text = dsDataset.Tables("a").Rows(0).Item("LaborRoomF").ToString()
                    frm.txtDelRoomFee.Text = dsDataset.Tables("a").Rows(0).Item("DeliveryRoomF").ToString()
                    frm.txtOperRoomFee.Text = dsDataset.Tables("a").Rows(0).Item("OperatingRoomF").ToString()
                    frm.txtPhysDailyVisitFee.Text = dsDataset.Tables("a").Rows(0).Item("PhysVisitF").ToString()
                    frm.txtDeliveryFee.Text = dsDataset.Tables("a").Rows(0).Item("DeliveriesF").ToString()
                    frm.txtNursingCareFee.Text = dsDataset.Tables("a").Rows(0).Item("NursingCareF").ToString()
                    frm.txtSurgicalFee.Text = dsDataset.Tables("a").Rows(0).Item("SurgicalF").ToString()
                    frm.txtAnesFee.Text = dsDataset.Tables("a").Rows(0).Item("AnesF").ToString()
                    frm.txtTransIVFee.Text = dsDataset.Tables("a").Rows(0).Item("TranIVF").ToString()
                    frm.txtApplianceFee.Text = dsDataset.Tables("a").Rows(0).Item("ElectApplF").ToString()
                    frm.txtElectrodsFee.Text = dsDataset.Tables("a").Rows(0).Item("ElectrodesF").ToString()
                    frm.txtSuppliesOtherFee.Text = dsDataset.Tables("a").Rows(0).Item("SuppliesF").ToString()
                    frm.txtDrugsMedsFee.Text = dsDataset.Tables("a").Rows(0).Item("DrugsMedsF").ToString()
                    frm.txtLabFee.Text = dsDataset.Tables("a").Rows(0).Item("LabChargesF").ToString()
                    frm.txtNewBornScreenFee.Text = dsDataset.Tables("a").Rows(0).Item("NewBornScreenF").ToString()
                    frm.txtOxygenFee.Text = dsDataset.Tables("a").Rows(0).Item("OxygenF").ToString()
                    frm.txtXrayFee.Text = dsDataset.Tables("a").Rows(0).Item("XRayF").ToString()
                    frm.txtECGFee.Text = dsDataset.Tables("a").Rows(0).Item("ECGF").ToString()
                    frm.txtUltrasoundFee.Text = dsDataset.Tables("a").Rows(0).Item("UltrasF").ToString()
                    frm.txtDroplightFee.Text = dsDataset.Tables("a").Rows(0).Item("DroplightF").ToString()
                    frm.txtPhotoTherapyFee.Text = dsDataset.Tables("a").Rows(0).Item("PhototF").ToString()
                    frm.txtOtherCharges.Text = dsDataset.Tables("a").Rows(0).Item("OtherChargesF").ToString()
                End If
            End With
            sqladapter.Dispose()
            dsDataset.Dispose()
            frm.ShowDialog()
        Else
            MsgBox("PLEASE SELECT ADMISSION RECORD TO EDIT", MsgBoxStyle.Critical, "E D I T . . . error!")
            DataGridView2.Focus()
        End If
    End Sub
End Class
