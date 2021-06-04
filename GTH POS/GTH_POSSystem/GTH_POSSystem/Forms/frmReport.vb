Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class frmReport
#Region "CommonFunctions"
    Private conn As New SqlClient.SqlConnection("Data Source=server_jbg; Initial Catalog=POS;Integrated Security=True;")
    Private ComDset As New DataSet
    Private ComDset1 As New DataSet
    Private LeaderID As Long
    Private MemberID As Long
    Private rMoveVal As Boolean = False
    Dim Batch_Number As Long

    Dim CurrentRowIndex As Integer = 0
#End Region

    Dim cryRpt As New ReportDocument

    Private Sub frmReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If ACCESS_LEVEL = 1 Then
                CrystalReportViewer1.ShowPrintButton = False
                CrystalReportViewer1.ShowExportButton = False
                CrystalReportViewer1.ShowGroupTreeButton = False
                MsgBox("NOTE  : " + vbTab + "YOU CAN VIEW THE REPORT, BUT YOU ARE NOT ALLOWED" + Chr(13) + vbTab + "TO PRINT IT." + Chr(13) + Chr(13) + vbTab + "thank you!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "DENIED. . .")
                ' Exit Sub
            End If

            Dim pth As String
            'pth = System.Environment.GetFolderPath(Environment.SpecialFolder.System)
            'pth = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
            pth = System.Environment.CurrentDirectory
            'MsgBox(strReportSQL)
            Me.Cursor = Cursors.WaitCursor

            sqladapter = New SqlClient.SqlDataAdapter(strReportSQL, conn)
            sqldataset = New DataSet
            sqldataset.Reset()
            sqladapter.Fill(sqldataset, "a")
            CrystalReportViewer1.Visible = True
            CrystalReportViewer1.Height = Me.Height
            CrystalReportViewer1.Width = Me.Width
            If ReportFileName = "rptReceipt.rpt" Then
                cryRpt.Load("..\..\Reports\" & ReportFileName & "")
                cryRpt.Database.Tables(0).SetDataSource(sqldataset.Tables("a"))

                cryRpt.SetParameterValue("CompanyName", COMPANY_NAME)
                cryRpt.SetParameterValue("CompanyAddress", COMPLETE_COMPANY_ADDRESS)
                cryRpt.SetParameterValue("TIN", "TIN:" & COMP_TIN)
                cryRpt.SetParameterValue("PermitNo", "Permit No:" & PERMIT_NUMBER)
                cryRpt.SetParameterValue("Proprietor", "Proprietor:" & PROPRIETOR)
                cryRpt.SetParameterValue("OperatedBy", "Operated by:" & OPERATED_BY)
                cryRpt.SetParameterValue("Customer", "WALK-IN")

                cryRpt.PrintToPrinter(1, 1, 0, 1)
                CrystalReportViewer1.ReportSource = cryRpt

                CrystalReportViewer1.Refresh()

                NOT_SAVE_FLAG = False
                ' Me.Close()
                'Me.Dispose()
                frmDenomination.Focus()

            ElseIf ReportFileName = "rptSales.rpt" Then
                cryRpt.Load("..\..\Reports\" & ReportFileName & "")
                cryRpt.Database.Tables(0).SetDataSource(sqldataset.Tables("a"))

                cryRpt.SetParameterValue("CompanyName", COMPANY_NAME)
                cryRpt.SetParameterValue("CompanyAddress", COMPLETE_COMPANY_ADDRESS)
                cryRpt.SetParameterValue("SalesCoverage", CallingControl)
                'MsgBox(frmSalesMonitoring.cmbClerk.Text)
                cryRpt.SetParameterValue("Cashier", CLERK_IN_QUESTION)
                cryRpt.SetParameterValue("TimeIN", START_DATE_TIME)
                cryRpt.SetParameterValue("TimeOut", END_DATE_TIME)
                'cryRpt.SetParameterValue("Customer", "WALK-IN")
                CrystalReportViewer1.ReportSource = cryRpt

                CrystalReportViewer1.Refresh()

            ElseIf ReportFileName = "rptReceivingReport.rpt" Then
                cryRpt.Load("..\..\Reports\" & ReportFileName & "")
                cryRpt.Database.Tables(0).SetDataSource(sqldataset.Tables("a"))

                cryRpt.SetParameterValue("CompanyName", COMPANY_NAME)
                cryRpt.SetParameterValue("CompanyAddress", COMPLETE_COMPANY_ADDRESS)
                cryRpt.SetParameterValue("PREPAREDBY", USER_NAME_LOGGED)
                cryRpt.SetParameterValue("APPROVEDBY", COMP_PO_APP_OFF)
                cryRpt.SetParameterValue("SupplierName", SUPPLIER_NAME_PRINTING)
                CrystalReportViewer1.ReportSource = cryRpt

                CrystalReportViewer1.Refresh()

                Cursor = Cursors.Default

            ElseIf ReportFileName = "rptPO.rpt" Then ' NOT INTERESTED
                cryRpt.Load("..\..\Reports\" & ReportFileName & "")
                cryRpt.Database.Tables(0).SetDataSource(sqldataset.Tables("a"))

                cryRpt.SetParameterValue("CompanyName", COMPANY_NAME)
                cryRpt.SetParameterValue("CompanyAddress", COMPLETE_COMPANY_ADDRESS)
                cryRpt.SetParameterValue("PREPAREDBY", USER_NAME_LOGGED)
                cryRpt.SetParameterValue("APPROVEDBY", COMP_PO_APP_OFF)
                CrystalReportViewer1.ReportSource = cryRpt

                CrystalReportViewer1.Refresh()

                Cursor = Cursors.Default
            End If
        Catch
            MsgBox(Err.Description)
            MsgBox("REPORT NOT YET AVAILABLE, PLEASE CONTACT ADMINISTRATOR", , Err.Description)
        End Try
        Cursor = Cursors.Default

    End Sub
End Class