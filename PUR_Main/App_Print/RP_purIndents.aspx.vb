Partial Class RP_purIndents
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim IndentNo As Int32 = CType(aVal(0), Int32)
    Dim oVar As SIS.PUR.purIndents = SIS.PUR.purIndents.purIndentsGetByID(IndentNo)
    Dim tpi As New Table
    tpi.Width = 1000
    tpi.GridLines = GridLines.Both
    tpi.Style.Add("margin-top", "15px")
    tpi.Style.Add("margin-left", "10px")
    Dim ctpi As TableCell = Nothing
    Dim rtpi As TableRow = Nothing
    rtpi = New TableRow
    ctpi = New TableCell
    ctpi.Text = "Indent No"
    ctpi.Font.Bold = True
    ctpi.Font.Size = 10
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.IndentNo
    ctpi.Style.Add("text-align", "left")
    ctpi.ColumnSpan = "2"
    ctpi.Font.Bold = True
    ctpi.Font.Size = 10
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = "Indent Date"
    ctpi.Font.Bold = True
    ctpi.Font.Size = 10
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.IndentDate
    ctpi.Style.Add("text-align", "left")
    ctpi.Font.Size = 10
    ctpi.ColumnSpan = "2"
    rtpi.Cells.Add(ctpi)
    tpi.Rows.Add(rtpi)
    rtpi = New TableRow
    ctpi = New TableCell
    ctpi.Text = "Tran Type"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.TranTypeID
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.SPMT_TranTypes12_Description
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = "Status"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    'ctpi = New TableCell
    'ctpi.Text = oVar.StatusID
    'ctpi.Style.Add("text-align", "right")
    'rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.PUR_IndentStatus9_Description
    ctpi.Style.Add("text-align", "left")
    ctpi.Font.Bold = True
    ctpi.ColumnSpan = 2
    rtpi.Cells.Add(ctpi)
    tpi.Rows.Add(rtpi)
    rtpi = New TableRow
    ctpi = New TableCell
    ctpi.Text = "Isgec GSTIN Address"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.IsgecGSTINAddress
    ctpi.Style.Add("text-align", "left")
    ctpi.ColumnSpan = "2"
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = "Destination Address"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.DestinationAddress
    ctpi.Style.Add("text-align", "left")
    ctpi.ColumnSpan = "2"
    rtpi.Cells.Add(ctpi)
    tpi.Rows.Add(rtpi)
    rtpi = New TableRow
    ctpi = New TableCell
    ctpi.Text = "Delivery Terms"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.DeliveryTerms
    ctpi.Style.Add("text-align", "left")
    ctpi.ColumnSpan = "2"
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = "Payment Terms"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.PaymentTerms
    ctpi.Style.Add("text-align", "left")
    ctpi.ColumnSpan = "2"
    rtpi.Cells.Add(ctpi)
    tpi.Rows.Add(rtpi)
    rtpi = New TableRow
    ctpi = New TableCell
    ctpi.Text = "Warranty Details"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.WarrantyDetails
    ctpi.Style.Add("text-align", "left")
    ctpi.ColumnSpan = "2"
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = "Insurance Details"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.InsuranceDetails
    ctpi.Style.Add("text-align", "left")
    ctpi.ColumnSpan = "2"
    rtpi.Cells.Add(ctpi)
    tpi.Rows.Add(rtpi)
    rtpi = New TableRow
    ctpi = New TableCell
    ctpi.Text = "Mode Of Dispatch"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.ModeOfDispatch
    ctpi.Style.Add("text-align", "left")
    ctpi.ColumnSpan = "2"
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = "Isgec GSTIN"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.IsgecGSTIN
    ctpi.Style.Add("text-align", "right")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.SPMT_IsgecGSTIN11_Description
    ctpi.Style.Add("text-align", "right")
    rtpi.Cells.Add(ctpi)
    tpi.Rows.Add(rtpi)
    rtpi = New TableRow
    ctpi = New TableCell
    ctpi.Text = "Indenter Remarks"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.IndenterRemarks
    ctpi.Style.Add("text-align", "left")
    ctpi.ColumnSpan = "2"
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = "Approver Remarks"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.ApproverRemarks
    ctpi.Style.Add("text-align", "left")
    ctpi.ColumnSpan = "2"
    rtpi.Cells.Add(ctpi)
    tpi.Rows.Add(rtpi)
    rtpi = New TableRow
    ctpi = New TableCell
    ctpi.Text = "Created By"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.CreatedBy
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.aspnet_Users1_UserFullName
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = "Approved By"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.ApprovedBy
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.aspnet_Users2_UserFullName
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    tpi.Rows.Add(rtpi)
    rtpi = New TableRow
    ctpi = New TableCell
    ctpi.Text = "Created On"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.CreatedOn
    ctpi.Style.Add("text-align", "center")
    ctpi.ColumnSpan = "2"
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = "Approved On"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.ApprovedOn
    ctpi.Style.Add("text-align", "center")
    ctpi.ColumnSpan = "2"
    rtpi.Cells.Add(ctpi)
    tpi.Rows.Add(rtpi)
    rtpi = New TableRow
    ctpi = New TableCell
    ctpi.Text = "Currency"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.CurrencyID
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.PUR_Currencies8_CurrencyName
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = "Conversion Factor [INR]"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.ConversionFactorINR
    ctpi.Style.Add("text-align", "left")
    ctpi.ColumnSpan = "2"
    rtpi.Cells.Add(ctpi)
    tpi.Rows.Add(rtpi)
    rtpi = New TableRow
    ctpi = New TableCell
    ctpi.Text = "Department"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.DepartmentID
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.HRM_Departments3_Description
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = "Cost Center"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.CostCenterID
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.SPMT_CostCenters10_Description
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    tpi.Rows.Add(rtpi)
    rtpi = New TableRow
    ctpi = New TableCell
    ctpi.Text = "Employee"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.EmployeeID
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.HRM_Employees5_EmployeeName
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = "Division"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.DivisionID
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.HRM_Divisions4_Description
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    tpi.Rows.Add(rtpi)
    rtpi = New TableRow
    ctpi = New TableCell
    ctpi.Text = "Project"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.ProjectID
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.IDM_Projects6_Description
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = "Element"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.ElementID
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.IDM_WBS7_Description
    ctpi.Style.Add("text-align", "left")
    rtpi.Cells.Add(ctpi)
    tpi.Rows.Add(rtpi)
    rtpi = New TableRow
    ctpi = New TableCell
    ctpi.Text = "Delivery Date"
    ctpi.Font.Bold = True
    rtpi.Cells.Add(ctpi)
    ctpi = New TableCell
    ctpi.Text = oVar.DeliveryDate
    ctpi.Style.Add("text-align", "center")
    ctpi.ColumnSpan = "5"
    rtpi.Cells.Add(ctpi)
    tpi.Rows.Add(rtpi)
    form1.Controls.Add(tpi)
    Dim tpid As Table = Nothing
    Dim rtpid As TableRow = Nothing
    Dim ctpid As TableCell = Nothing
    Dim opurIndentDetailss As List(Of SIS.PUR.purIndentDetails) = SIS.PUR.purIndentDetails.UZ_purIndentDetailsSelectList(0, 999, "", False, "", oVar.IndentNo)
    If opurIndentDetailss.Count > 0 Then
      Dim tpihd As Table = New Table
      tpihd.Width = 1000
      tpihd.Style.Add("margin-top", "15px")
      tpihd.Style.Add("margin-left", "10px")
      tpihd.Style.Add("margin-right", "10px")
      Dim rtpihd As TableRow = New TableRow
      Dim ctpihd As TableCell = New TableCell
      ctpihd.Font.Bold = True
      ctpihd.Font.Underline = True
      ctpihd.Font.Size = 10
      ctpihd.CssClass = "grpHD"
      ctpihd.Text = "Indent Items"
      rtpihd.Cells.Add(ctpihd)
      tpihd.Rows.Add(rtpihd)
      form1.Controls.Add(tpihd)
      tpid = New Table
      tpid.Width = 1000
      tpid.GridLines = GridLines.Both
      tpid.Style.Add("margin-left", "10px")
      tpid.Style.Add("margin-right", "10px")
      rtpid = New TableRow
      ctpid = New TableCell
      ctpid.Text = "S.N."
      ctpid.Font.Bold = True
      ctpid.CssClass = "colHD"
      ctpid.Style.Add("text-align", "center")
      rtpid.Cells.Add(ctpid)
      ctpid = New TableCell
      ctpid.Text = "Item Code"
      ctpid.Font.Bold = True
      ctpid.CssClass = "colHD"
      ctpid.Style.Add("text-align", "right")
      rtpid.Cells.Add(ctpid)
      ctpid = New TableCell
      ctpid.Text = "Item Description"
      ctpid.Font.Bold = True
      ctpid.CssClass = "colHD"
      ctpid.Style.Add("text-align", "left")
      rtpid.Cells.Add(ctpid)
      ctpid = New TableCell
      ctpid.Text = "UOM"
      ctpid.Font.Bold = True
      ctpid.CssClass = "colHD"
      ctpid.Style.Add("text-align", "left")
      rtpid.Cells.Add(ctpid)
      ctpid = New TableCell
      ctpid.Text = "Quantity"
      ctpid.Font.Bold = True
      ctpid.CssClass = "colHD"
      ctpid.Style.Add("text-align", "right")
      rtpid.Cells.Add(ctpid)
      ctpid = New TableCell
      ctpid.Text = "Price"
      ctpid.Font.Bold = True
      ctpid.CssClass = "colHD"
      ctpid.Style.Add("text-align", "right")
      rtpid.Cells.Add(ctpid)
      ctpid = New TableCell
      ctpid.Text = "Total Tax"
      ctpid.Font.Bold = True
      ctpid.CssClass = "colHD"
      ctpid.Style.Add("text-align", "right")
      rtpid.Cells.Add(ctpid)
      ctpid = New TableCell
      ctpid.Text = "Total Amount"
      ctpid.Font.Bold = True
      ctpid.CssClass = "colHD"
      ctpid.Style.Add("text-align", "right")
      rtpid.Cells.Add(ctpid)
      ctpid = New TableCell
      ctpid.Text = "Delivery Date"
      ctpid.Font.Bold = True
      ctpid.CssClass = "colHD"
      ctpid.Style.Add("text-align", "center")
      rtpid.Cells.Add(ctpid)
      tpid.Rows.Add(rtpid)
      Dim sn As Integer = 0
      For Each opurIndentDetails As SIS.PUR.purIndentDetails In opurIndentDetailss
        sn = sn + 1
        rtpid = New TableRow
        ctpid = New TableCell
        ctpid.Text = sn
        ctpid.CssClass = "rowHD"
        ctpid.Style.Add("text-align", "center")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.Text = opurIndentDetails.PUR_Items8_ItemDescription
        ctpid.CssClass = "rowHD"
        ctpid.Style.Add("text-align", "right")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.CssClass = "rowHD"
        ctpid.Text = opurIndentDetails.ItemDescription
        ctpid.Style.Add("text-align", "left")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.Text = opurIndentDetails.SPMT_ERPUnits12_Description
        ctpid.CssClass = "rowHD"
        ctpid.Style.Add("text-align", "left")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.CssClass = "rowHD"
        ctpid.Text = opurIndentDetails.Quantity
        ctpid.Style.Add("text-align", "right")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.CssClass = "rowHD"
        ctpid.Text = opurIndentDetails.Price
        ctpid.Style.Add("text-align", "right")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.CssClass = "rowHD"
        ctpid.Text = opurIndentDetails.TaxAmount
        ctpid.Style.Add("text-align", "right")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.CssClass = "rowHD"
        ctpid.Text = opurIndentDetails.TotalAmountINR
        ctpid.Style.Add("text-align", "right")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.CssClass = "rowHD"
        ctpid.Text = opurIndentDetails.DeliveryDate
        ctpid.Style.Add("text-align", "center")
        rtpid.Cells.Add(ctpid)
        tpid.Rows.Add(rtpid)



        rtpid = New TableRow

        ctpid = New TableCell
        ctpid.ColumnSpan = tpid.Rows(0).Cells.Count
        rtpid.Cells.Add(ctpid)
        Dim oTblpurIndentItemProperty As Table = Nothing
        Dim oRowpurIndentItemProperty As TableRow = Nothing
        Dim oColpurIndentItemProperty As TableCell = Nothing
        Dim opurIndentItemPropertys As List(Of SIS.PUR.purIndentItemProperty) = SIS.PUR.purIndentItemProperty.purIndentItemPropertySelectList(0, 999, "", False, "", opurIndentDetails.IndentNo, opurIndentDetails.IndentLine)
        If opurIndentItemPropertys.Count > 0 Then
          oTblpurIndentItemProperty = New Table
          oTblpurIndentItemProperty.BorderStyle = BorderStyle.None
          oTblpurIndentItemProperty.Width = 500
          'oTblpurIndentItemProperty.GridLines = GridLines.Both
          oTblpurIndentItemProperty.Style.Add("margin-bottom", "10px")
          oTblpurIndentItemProperty.Style.Add("margin-left", "10px")
          oTblpurIndentItemProperty.Style.Add("margin-right", "10px")
          oRowpurIndentItemProperty = New TableRow
          oColpurIndentItemProperty = New TableCell
          oColpurIndentItemProperty.Text = "Specification"
          oColpurIndentItemProperty.Font.Bold = True
          oColpurIndentItemProperty.CssClass = "scolHD"
          oColpurIndentItemProperty.Style.Add("text-align", "right")
          oRowpurIndentItemProperty.Cells.Add(oColpurIndentItemProperty)
          oColpurIndentItemProperty = New TableCell
          oColpurIndentItemProperty.Text = "Value"
          oColpurIndentItemProperty.Font.Bold = True
          oColpurIndentItemProperty.CssClass = "scolHD"
          oColpurIndentItemProperty.Style.Add("text-align", "left")
          oRowpurIndentItemProperty.Cells.Add(oColpurIndentItemProperty)
          oTblpurIndentItemProperty.Rows.Add(oRowpurIndentItemProperty)
          For Each opurIndentItemProperty As SIS.PUR.purIndentItemProperty In opurIndentItemPropertys
            oRowpurIndentItemProperty = New TableRow
            oColpurIndentItemProperty = New TableCell
            oColpurIndentItemProperty.Text = opurIndentItemProperty.PUR_ItemCategorySpecs4_SpecName
            oColpurIndentItemProperty.CssClass = "rowHD"
            oColpurIndentItemProperty.Style.Add("text-align", "right")
            oRowpurIndentItemProperty.Cells.Add(oColpurIndentItemProperty)
            oColpurIndentItemProperty = New TableCell
            oColpurIndentItemProperty.CssClass = "rowHD"
            oColpurIndentItemProperty.Text = opurIndentItemProperty.Data1Value & IIf(opurIndentItemProperty.IsRange, "  -  " & opurIndentItemProperty.Data2Value, "")
            oColpurIndentItemProperty.Style.Add("text-align", "left")
            oRowpurIndentItemProperty.Cells.Add(oColpurIndentItemProperty)
            oTblpurIndentItemProperty.Rows.Add(oRowpurIndentItemProperty)
          Next
          ctpid.Controls.Add(oTblpurIndentItemProperty)
          tpid.Rows.Add(rtpid)
        End If
      Next
      form1.Controls.Add(tpid)
    End If
  End Sub
End Class
