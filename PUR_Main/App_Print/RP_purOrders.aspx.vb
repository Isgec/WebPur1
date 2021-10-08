Partial Class RP_purOrders
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim OrderNo As Int32 = CType(aVal(0), Int32)
    If aVal(1) = "" Then aVal(1) = 0
    Dim OrderRev As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.PUR.purOrders = SIS.PUR.purOrders.purOrdersGetByID(OrderNo, OrderRev)

    Dim tpi As New Table
    Dim ctpi As TableCell = Nothing
    Dim rtpi As TableRow = Nothing
    rtpi = New TableRow
    tpi.Width = 1000
    tpi.GridLines = GridLines.None
    tpi.Style.Add("margin-top", "15px")
    tpi.Style.Add("margin-left", "10px")

    ctpi = New TableCell
    Dim img As New Image
    img.ImageUrl = "~/Images/ijtlogo.png"
    ctpi.Controls.Add(img)
    ctpi.Style.Add("text-align", "left")
    ctpi.Style.Add("padding-left", "0px")
    rtpi.Cells.Add(ctpi)


    ctpi = New TableCell
    ctpi.Text = "PURCHASE ORDER"
    ctpi.Font.Bold = True
    ctpi.Style.Add("text-align", "center")
    ctpi.Font.Size = 14
    rtpi.Cells.Add(ctpi)

    ctpi = New TableCell
    ctpi.Text = "&nbsp;&nbsp;&nbsp;&nbsp;"
    ctpi.Font.Bold = True
    ctpi.Style.Add("text-align", "right")
    ctpi.Font.Size = 14
    rtpi.Cells.Add(ctpi)


    tpi.Rows.Add(rtpi)
    form1.Controls.Add(tpi)



    Dim tbl As Table = Nothing
    Dim cel As TableCell = Nothing
    Dim row As TableRow = Nothing

    tbl = New Table
    With tbl
      .Width = 1000
      .GridLines = GridLines.Both
      .Style.Add("margin-top", "15px")
      .Style.Add("margin-left", "10px")
      .CssClass = "po-B"
    End With

    row = New TableRow
    cel = New TableCell
    cel.VerticalAlign = VerticalAlign.Top
    cel.Controls.Add(SupplierAddressTable(oVar))
    row.Cells.Add(cel)
    cel = New TableCell
    cel.VerticalAlign = VerticalAlign.Top
    cel.Controls.Add(PONumberTable(oVar))
    row.Cells.Add(cel)
    tbl.Rows.Add(row)


    form1.Controls.Add(tbl)


    Dim tpid As Table = Nothing
    Dim rtpid As TableRow = Nothing
    Dim ctpid As TableCell = Nothing
    Dim opurOrderDetailss As List(Of SIS.PUR.purOrderDetails) = SIS.PUR.purOrderDetails.UZ_purOrderDetailsSelectList(0, 999, "", False, "", oVar.OrderRev, oVar.OrderNo)
    If opurOrderDetailss.Count > 0 Then
      tpid = New Table
      With tpid
        .Width = 1000
        .GridLines = GridLines.Both
        .Style.Add("margin-top", "15px")
        .Style.Add("margin-left", "10px")
        .CssClass = "po-B"
      End With
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
      For Each opurOrderDetails As SIS.PUR.purOrderDetails In opurOrderDetailss
        sn = sn + 1
        rtpid = New TableRow
        ctpid = New TableCell
        ctpid.Text = sn
        ctpid.CssClass = "rowHD"
        ctpid.Style.Add("text-align", "center")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.Text = opurOrderDetails.PUR_Items7_ItemDescription
        ctpid.CssClass = "rowHD"
        ctpid.Style.Add("text-align", "right")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.CssClass = "rowHD"
        ctpid.Text = opurOrderDetails.ItemDescription
        ctpid.Style.Add("text-align", "left")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.Text = opurOrderDetails.SPMT_ERPUnits12_Description
        ctpid.CssClass = "rowHD"
        ctpid.Style.Add("text-align", "left")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.CssClass = "rowHD"
        ctpid.Text = opurOrderDetails.Quantity
        ctpid.Style.Add("text-align", "right")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.CssClass = "rowHD"
        ctpid.Text = opurOrderDetails.Price
        ctpid.Style.Add("text-align", "right")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.CssClass = "rowHD"
        ctpid.Text = opurOrderDetails.TaxAmount
        ctpid.Style.Add("text-align", "right")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.CssClass = "rowHD"
        ctpid.Text = opurOrderDetails.TotalAmountINR
        ctpid.Style.Add("text-align", "right")
        rtpid.Cells.Add(ctpid)
        ctpid = New TableCell
        ctpid.CssClass = "rowHD"
        ctpid.Text = opurOrderDetails.DeliveryDate
        ctpid.Style.Add("text-align", "center")
        rtpid.Cells.Add(ctpid)
        tpid.Rows.Add(rtpid)



        rtpid = New TableRow

        ctpid = New TableCell
        ctpid.ColumnSpan = tpid.Rows(0).Cells.Count
        rtpid.Cells.Add(ctpid)
        Dim oTblpurOrderItemProperty As Table = Nothing
        Dim oRowpurOrderItemProperty As TableRow = Nothing
        Dim oColpurOrderItemProperty As TableCell = Nothing
        Dim opurOrderItemPropertys As List(Of SIS.PUR.purOrderItemProperty) = SIS.PUR.purOrderItemProperty.purOrderItemPropertySelectList(0, 999, "", False, "", opurOrderDetails.OrderLine, opurOrderDetails.OrderNo, opurOrderDetails.OrderRev)
        If opurOrderItemPropertys.Count > 0 Then
          oTblpurOrderItemProperty = New Table
          oTblpurOrderItemProperty.BorderStyle = BorderStyle.None
          oTblpurOrderItemProperty.Width = 500
          'oTblpurOrderItemProperty.GridLines = GridLines.Both
          oTblpurOrderItemProperty.Style.Add("margin-bottom", "10px")
          oTblpurOrderItemProperty.Style.Add("margin-left", "10px")
          oTblpurOrderItemProperty.Style.Add("margin-right", "10px")
          oRowpurOrderItemProperty = New TableRow
          oColpurOrderItemProperty = New TableCell
          oColpurOrderItemProperty.Text = "Specification"
          oColpurOrderItemProperty.Font.Bold = True
          oColpurOrderItemProperty.CssClass = "scolHD"
          oColpurOrderItemProperty.Style.Add("text-align", "right")
          oRowpurOrderItemProperty.Cells.Add(oColpurOrderItemProperty)
          oColpurOrderItemProperty = New TableCell
          oColpurOrderItemProperty.Text = "Value"
          oColpurOrderItemProperty.Font.Bold = True
          oColpurOrderItemProperty.CssClass = "scolHD"
          oColpurOrderItemProperty.Style.Add("text-align", "left")
          oRowpurOrderItemProperty.Cells.Add(oColpurOrderItemProperty)
          oTblpurOrderItemProperty.Rows.Add(oRowpurOrderItemProperty)
          For Each opurOrderItemProperty As SIS.PUR.purOrderItemProperty In opurOrderItemPropertys
            oRowpurOrderItemProperty = New TableRow
            oColpurOrderItemProperty = New TableCell
            oColpurOrderItemProperty.Text = opurOrderItemProperty.PUR_ItemCategorySpecs2_SpecName
            oColpurOrderItemProperty.CssClass = "rowHD"
            oColpurOrderItemProperty.Style.Add("text-align", "right")
            oRowpurOrderItemProperty.Cells.Add(oColpurOrderItemProperty)
            oColpurOrderItemProperty = New TableCell
            oColpurOrderItemProperty.CssClass = "rowHD"
            oColpurOrderItemProperty.Text = opurOrderItemProperty.Data1Value & IIf(opurOrderItemProperty.IsRange, "  -  " & opurOrderItemProperty.Data2Value, "")
            oColpurOrderItemProperty.Style.Add("text-align", "left")
            oRowpurOrderItemProperty.Cells.Add(oColpurOrderItemProperty)
            oTblpurOrderItemProperty.Rows.Add(oRowpurOrderItemProperty)
          Next
          ctpid.Controls.Add(oTblpurOrderItemProperty)
          tpid.Rows.Add(rtpid)
        End If
      Next
      form1.Controls.Add(tpid)
    End If
    '==================After Item============
    tbl = New Table
    With tbl
      .Width = 1000
      .GridLines = GridLines.Both
      .Style.Add("margin-top", "15px")
      .Style.Add("margin-left", "10px")
      .CssClass = "po-B"
    End With

    row = New TableRow
    cel = New TableCell
    cel.VerticalAlign = VerticalAlign.Top
    cel.Style.Add("min-height", "60px")
    cel.Style.Add("width", "50%")
    cel.Text = "<b><u>Payment Terms:</u></b><br/>" & oVar.PaymentTerms.Replace(Chr(13), "<br/>").Replace(Chr(10), "<br/>")
    row.Cells.Add(cel)
    cel = New TableCell
    cel.VerticalAlign = VerticalAlign.Top
    cel.Style.Add("min-height", "60px")
    cel.Style.Add("width", "50%")
    cel.Text = "<b><u>Delivery Terms:</u></b><br/>" & oVar.DeliveryTerms.Replace(Chr(13), "<br/>").Replace(Chr(10), "<br/>")
    row.Cells.Add(cel)
    tbl.Rows.Add(row)


    row = New TableRow
    cel = New TableCell
    cel.VerticalAlign = VerticalAlign.Top
    cel.Style.Add("min-height", "60px")
    cel.Text = "<b><u>Insurance Terms:</u></b><br/>" & oVar.InsuranceDetails.Replace(Chr(13), "<br/>").Replace(Chr(10), "<br/>")
    row.Cells.Add(cel)
    cel = New TableCell
    cel.VerticalAlign = VerticalAlign.Top
    cel.Style.Add("min-height", "60px")
    cel.Text = "<b><u>Warranty Terms:</u></b><br/>" & oVar.WarrantyDetails.Replace(Chr(13), "<br/>").Replace(Chr(10), "<br/>")
    row.Cells.Add(cel)
    tbl.Rows.Add(row)

    row = New TableRow
    cel = New TableCell
    cel.VerticalAlign = VerticalAlign.Top
    cel.Style.Add("min-height", "60px")
    cel.ColumnSpan = 2
    cel.Text = "<b><u>Mode Of Despatch:</u></b><br/>" & oVar.ModeOfDispatch.Replace(Chr(13), "<br/>").Replace(Chr(10), "<br/>")
    row.Cells.Add(cel)
    tbl.Rows.Add(row)

    form1.Controls.Add(tbl)


    tbl = New Table
    With tbl
      .Width = 1000
      .GridLines = GridLines.Both
      .Style.Add("margin-top", "15px")
      .Style.Add("margin-left", "10px")
      .CssClass = "po-B"
    End With

    row = New TableRow
    cel = New TableCell
    cel.VerticalAlign = VerticalAlign.Top
    cel.Style.Add("min-height", "60px")
    cel.Text = "<b><u>Delivery Address:</u></b><br/>" & oVar.DestinationAddress.Replace(Chr(13), "<br/>").Replace(Chr(10), "<br/>")
    row.Cells.Add(cel)
    cel = New TableCell
    cel.VerticalAlign = VerticalAlign.Top
    cel.Style.Add("min-height", "60px")
    cel.Text = "<b><u>Billing Address:</u></b><br/>" & oVar.IsgecGSTINAddress.Replace(Chr(13), "<br/>").Replace(Chr(10), "<br/>")
    row.Cells.Add(cel)
    tbl.Rows.Add(row)

    form1.Controls.Add(tbl)

    tbl = New Table
    With tbl
      .Width = 1000
      .GridLines = GridLines.Both
      .Style.Add("margin-top", "15px")
      .Style.Add("margin-left", "10px")
      .CssClass = "po-B"
    End With

    row = New TableRow
    cel = New TableCell
    cel.VerticalAlign = VerticalAlign.Top
    cel.Style.Add("min-height", "60px")
    cel.ColumnSpan = 2
    cel.Text = "<b><u>Remarks:</u></b><br/>" & oVar.BuyerRemarks.Replace(Chr(13), "<br/>").Replace(Chr(10), "<br/>")
    row.Cells.Add(cel)
    tbl.Rows.Add(row)

    form1.Controls.Add(tbl)

    '============For Isgec heavy
    tbl = New Table
    With tbl
      .Width = 1000
      .Style.Add("margin-top", "25px")
      .Style.Add("margin-left", "10px")
    End With

    row = New TableRow
    cel = New TableCell
    cel.VerticalAlign = VerticalAlign.Top
    cel.HorizontalAlign = HorizontalAlign.Right
    cel.Style.Add("min-height", "60px")
    cel.Text = "<b>For ISGEC HEAVY ENGINEERING LIMITED</b> "
    row.Cells.Add(cel)
    tbl.Rows.Add(row)

    row = New TableRow
    cel = New TableCell
    cel.VerticalAlign = VerticalAlign.Top
    cel.HorizontalAlign = HorizontalAlign.Right
    cel.Style.Add("min-height", "60px")
    cel.Text = oVar.FK_PUR_Orders_CreatedBy.UserFullName
    row.Cells.Add(cel)
    tbl.Rows.Add(row)


    form1.Controls.Add(tbl)


  End Sub
  Private Function PONumberTable(oVar As SIS.PUR.purOrders) As Table
    Dim Tbl As Table = Nothing
    Dim row As TableRow = Nothing
    Dim cel As TableCell = Nothing
    Tbl = New Table
    With Tbl
      '.Width = 1000
      '.GridLines = GridLines.None
      '.Style.Add("margin-top", "15px")
      '.Style.Add("margin-left", "10px")
      .CssClass = "po-noB"
    End With
    row = New TableRow
    cel = New TableCell
    With cel
      .Text = "PO Number:"
      .Font.Bold = True
    End With
    row.Cells.Add(cel)
    cel = New TableCell
    With cel
      .Text = oVar.OrderNo & " REV.: " & oVar.OrderRev
      .Font.Bold = True
      .Font.Size = 10
    End With
    row.Cells.Add(cel)

    Tbl.Rows.Add(row)

    row = New TableRow
    cel = New TableCell
    With cel
      .Text = "PO Date:"
      .Font.Bold = True
    End With
    row.Cells.Add(cel)
    cel = New TableCell
    With cel
      .Text = oVar.OrderDate
    End With
    row.Cells.Add(cel)

    Tbl.Rows.Add(row)

    row = New TableRow
    cel = New TableCell
    With cel
      .Text = "Qtation No:"
      .Font.Bold = True
    End With
    row.Cells.Add(cel)
    cel = New TableCell
    With cel
      .Text = oVar.QuatationNo
    End With
    row.Cells.Add(cel)

    Tbl.Rows.Add(row)
    row = New TableRow
    cel = New TableCell
    With cel
      .Text = "Quotation Date:"
      .Font.Bold = True
    End With
    row.Cells.Add(cel)
    cel = New TableCell
    With cel
      .Text = oVar.QuotationDate
    End With
    row.Cells.Add(cel)

    Tbl.Rows.Add(row)
    Return Tbl
  End Function

  Private Function SupplierAddressTable(oVar As SIS.PUR.purOrders) As Table
    Dim Tbl As Table = Nothing
    Dim row As TableRow = Nothing
    Dim cel As TableCell = Nothing
    Tbl = New Table
    With Tbl
      '.Width = 1000
      '.GridLines = GridLines.None
      '.Style.Add("margin-top", "15px")
      '.Style.Add("margin-left", "10px")
      .CssClass = "po-noB"
    End With
    row = New TableRow

    cel = New TableCell
    With cel
      .Text = "Supplier:"
      .Font.Bold = True
    End With
    row.Cells.Add(cel)

    cel = New TableCell
    With cel
      .Text = oVar.SupplierID & "- " & oVar.SupplierName
    End With
    row.Cells.Add(cel)

    Tbl.Rows.Add(row)

    row = New TableRow

    cel = New TableCell
    With cel
      .Text = "Address:"
      .Font.Bold = True
    End With
    row.Cells.Add(cel)

    cel = New TableCell
    With cel
      If oVar.SupplierID <> "" Then
        .Text = oVar.FK_PUR_Orders_SupplierID.Address1Line & oVar.FK_PUR_Orders_SupplierID.Address2Line & oVar.FK_PUR_Orders_SupplierID.City
      End If
    End With
    row.Cells.Add(cel)

    Tbl.Rows.Add(row)

    Return Tbl
  End Function
End Class
