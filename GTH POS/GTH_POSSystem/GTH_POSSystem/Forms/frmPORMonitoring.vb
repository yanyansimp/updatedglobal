Imports System.Data.SqlClient

Public Class frmPORMonitoring

#Region "CommonFunctions"
    Private conn As New SqlClient.SqlConnection("Data Source=server_jbg; Initial Catalog=POS;Integrated Security=True;")
    Private ComDset As New DataSet
    Private ComDset1 As New DataSet
    Private LeaderID As Long
    Private userID As Long
    Private rMoveVal As Boolean = False
    Dim Batch_Number As Long

    Dim CurrentRowIndex As Integer = 0
#End Region

    Dim SupplierID As Long

    Private Sub frmPORMonitoring_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.PictureBox1.Visible = True
    End Sub

    Private Sub frmPORMonitoring_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LoadSuppliersToCombo()
        load_POR()
    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        '' If ListView1.Items.Count > 0 Then
        'On Error Resume Next
        'Dim suppid As String = ListView1.SelectedItems.Item(0).SubItems(1).Text
        'suppid = StrReverse(suppid)
        'suppid = Replace(StrReverse(Mid(suppid, InStr(suppid, "-", CompareMethod.Binary))), "-", "")
        'cmbSupplier.Text = getFIELD_VALUE_FROM_DBASE("tblSupplier", "SupplierName", "SupplierID", suppid)
        'End If
    End Sub

    
    Private Sub load_POR()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("SELECT DISTINCT reorderpoint     FROM tblProduct ORDER BY reorderpoint", conn)
        ' AND (TransactionDate >= '11/21/2016 7:20:24 PM') AND (TransactionDate <= '11/22/2016 9:55:28 PM')
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                cmbPointOfReorder.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    cmbPointOfReorder.Items.Add(.Rows(rowcounter).Item("reorderpoint").ToString())
                Next
                cmbPointOfReorder.SelectedIndex = 0
            Else

            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub


    Private Sub btnDisplaySales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplaySales.Click
        Call load_POR_LIST()

    End Sub

 
    Private Sub LoadSuppliersToCombo()
        Dim rowcounter As Integer
        sqladapter = New SqlClient.SqlDataAdapter("Select SupplierID,SupplierName from tblSupplier order by SupplierName", conn)
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                cmbSupplier.Items.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    cmbSupplier.Items.Add(New ComboListData(.Rows(rowcounter).Item("SupplierName").ToString(), .Rows(rowcounter).Item("SupplierID").ToString()))
                Next
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub

    Private Sub getSupplierIDFromComboBOx()
        Try
            For Each item As ComboListData In cmbSupplier.Items
                If item.Name.ToString = cmbSupplier.SelectedItem.ToString Then
                    SupplierID = item.ItemData.ToString
                    GoTo exit_loop2
                End If
            Next
        Catch
        End Try
exit_loop2:
    End Sub

    Private Sub btnPreviewSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewPOR.Click

    End Sub

    Private Sub cmbSupplier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSupplier.SelectedIndexChanged
        getSupplierIDFromComboBOx()
    End Sub

    Private Sub load_POR_LIST()
        Dim Barcode As String, StanDeviation As String, ProductDesciption As String, UnitName As String, PreviousOrder As Double, PO_NUM As String, SalesPerDay As String, qtyReceived As String, unitprice As Double, LeadTime As String

        Dim rowcounter As Integer
        If chkPerSupplier.Checked Then
            sqladapter = New SqlClient.SqlDataAdapter("SELECT     ProductID_Barcode as Barcode, ProductDescription as Description, UnitName as Unit, " _
                         & "  (SELECT     TOP (1) PurchaseCost    FROM tblPriceHistory    WHERE      (trnno = tblProduct.UnitPriceCode)) AS [SUPPLIER PRICE]" _
                         & " , QtyOnHand, QtyInn AS [PREVIOUS ORDER], reorderpoint, (SELECT     TOP (1) SupplierName   FROM tblSupplier " _
                         & " WHERE      (SupplierID = tblProduct.SupplierID)) AS SUPPLIER, SupplierID      FROM tblProduct " _
                         & " WHERE(QtyOnHand <= '" & IIf(cmbPointOfReorder.Text = "", 0, cmbPointOfReorder.Text) & "') AND SUPPLIERID = " & SupplierID & "  ORDER BY ProductDescription", conn)
        Else
            sqladapter = New SqlClient.SqlDataAdapter("SELECT     ProductID_Barcode as Barcode, ProductDescription as Description, UnitName as Unit, " _
                         & "  (SELECT     TOP (1) PurchaseCost    FROM tblPriceHistory    WHERE      (trnno = tblProduct.UnitPriceCode)) AS [SUPPLIER PRICE]" _
                         & " , QtyOnHand, QtyInn AS [PREVIOUS ORDER], reorderpoint, (SELECT     TOP (1) SupplierName   FROM tblSupplier " _
                         & " WHERE      (SupplierID = tblProduct.SupplierID)) AS SUPPLIER, SupplierID      FROM tblProduct " _
                         & " WHERE(QtyOnHand <= '" & IIf(cmbPointOfReorder.Text = "", 0, cmbPointOfReorder.Text) & "') ORDER BY ProductDescription", conn)
        End If
        
        dsDataset = New DataSet
        dsDataset.Reset()
        sqladapter.Fill(dsDataset, "a")
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        With dsDataset.Tables("a")
            If .Rows.Count > 0 Then
                DataGridView1.Rows.Clear()
                For rowcounter = 0 To .Rows.Count - 1
                    'cmbBrgy.Items.Add(.Rows(rowcounter).Item("barangayname").ToString())

                    Barcode = .Rows(rowcounter).Item("Barcode").ToString()
                    ProductDesciption = .Rows(rowcounter).Item("Description").ToString()
                    PreviousOrder = IIf(.Rows(rowcounter).Item("PREVIOUS ORDER").ToString() = "", 0, .Rows(rowcounter).Item("PREVIOUS ORDER").ToString())
                    UnitName = .Rows(rowcounter).Item("Unit").ToString()
                    unitprice = IIf(.Rows(rowcounter).Item("SUPPLIER PRICE").ToString() = "", 0, .Rows(rowcounter).Item("SUPPLIER PRICE").ToString())
                    qtyReceived = IIf(.Rows(rowcounter).Item("QtyOnHand").ToString() = "", 0, .Rows(rowcounter).Item("QtyOnHand").ToString())
                    Dim strLEadTime As String = " top 1  DATEDIFF(hh,(SELECT     TOP 1 PO_Date  FROM tblPO WHERE PO_Number = tblProductReceive.PO_Number), (TransactionDate + TimeReceived)) as ss "
                    LeadTime = getLEadTimefromDB("tblProductReceive", strLEadTime, "ProductID_Barcode", Barcode)
                    Dim xLeadtime As Double = IIf(LeadTime = "", 1, LeadTime) / 24
                    LeadTime = FormatNumber(xLeadtime, 2, , , TriState.True) & " day/s"
                    SalesPerDay = getMedianSalesPerDay(Barcode)
                    StanDeviation = getStandardDeviation(Barcode)

                    Dim row As String() = New String() {Barcode, ProductDesciption, PreviousOrder, UnitName, qtyReceived, unitprice, LeadTime, SalesPerDay, StanDeviation} 'FormatCurrency(unitprice, 2)
                    DataGridView1.Rows.Add(row)

                Next
            Else
                DataGridView1.Rows.Clear()
            End If
        End With
        sqladapter.Dispose()
        dsDataset.Dispose()
    End Sub
    'AVERAGE SALES PER DAY
    ' Calculate the average alongside standard deviation. That way you can see average sales per day and how consistently they hit that average. lower SD indicates better consistency
    'example : you get sales by day over 5 days for one product("P1") 7, 5, 5, 7 & 6 then in the same time frame another product("P2") gets 30, 0, 0, 0 & 0. Both will have the same 
    'average of 6 a day but P1 will have an SD of 1 and P2 will have an SD of 13.5.
    'You know although both have sold on average the same a indicating factor of which sells more consistently. High average and low SDs are your best products.
    'I used this formula on POS data for a cocktail bar. Helped spot the better consistent sellers amongst those which were bought on a one off hen do night with a favourite drink.

    'select MedianSoldQTY FROM 
    '(select ProductID_Barcode,AVG(Quantity) as MedianSoldQTY
    '	from (select ProductID_Barcode,Quantity , 
    '			ROW_NUMBER() over (partition by ProductID_Barcode order by Quantity ASC) as QuantityRank,
    '			COUNT(*) over (partition by ProductID_Barcode) as BCodeCount   from  dbo.tblSalesTransaction
    '	) x
    'where   x.QuantityRank in (x.BCodeCount/2+1, (x.BCodeCount+1)/2)    
    'group by x.ProductID_Barcode)    y
    'where y.ProductID_Barcode = '9556089016254'

    Private Sub chkPerSupplier_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPerSupplier.CheckedChanged
        If chkPerSupplier.Checked Then
            cmbSupplier.Enabled = True
            btnCreatePO.Enabled = True
        Else
            cmbSupplier.Enabled = False
            btnCreatePO.Enabled = False
        End If
    End Sub

    Private Sub cmbPointOfReorder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPointOfReorder.SelectedIndexChanged
        Call load_POR_LIST()
    End Sub
End Class