Partial Class RP_purReceipts
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim ReceiptNo As Int32 = CType(aVal(0), Int32)
    Dim oVar As SIS.PUR.purReceipts = SIS.PUR.purReceipts.purReceiptsGetByID(ReceiptNo)
    Dim oTblpurReceipts As New Table
    oTblpurReceipts.Width = 1000
    oTblpurReceipts.GridLines = GridLines.Both
    oTblpurReceipts.Style.Add("margin-top", "15px")
    oTblpurReceipts.Style.Add("margin-left", "10px")
    Dim oColpurReceipts As TableCell = Nothing
    Dim oRowpurReceipts As TableRow = Nothing
    oRowpurReceipts = New TableRow
    oColpurReceipts = New TableCell
    oColpurReceipts.Text = "Receipt No"
    oColpurReceipts.Font.Bold = True
    oRowpurReceipts.Cells.Add(oColpurReceipts)
    oColpurReceipts = New TableCell
    oColpurReceipts.Text = oVar.ReceiptNo
    oColpurReceipts.Style.Add("text-align", "right")
    oColpurReceipts.ColumnSpan = "2"
    oRowpurReceipts.Cells.Add(oColpurReceipts)
    oColpurReceipts = New TableCell
    oColpurReceipts.Text = "Receipt Date"
    oColpurReceipts.Font.Bold = True
    oRowpurReceipts.Cells.Add(oColpurReceipts)
    oColpurReceipts = New TableCell
    oColpurReceipts.Text = oVar.ReceiptDate
    oColpurReceipts.Style.Add("text-align", "center")
    oColpurReceipts.ColumnSpan = "2"
    oRowpurReceipts.Cells.Add(oColpurReceipts)
    oTblpurReceipts.Rows.Add(oRowpurReceipts)
    form1.Controls.Add(oTblpurReceipts)
    Dim oTblpurReceiptDetails As Table = Nothing
    Dim oRowpurReceiptDetails As TableRow = Nothing
    Dim oColpurReceiptDetails As TableCell = Nothing
    Dim opurReceiptDetailss As List(Of SIS.PUR.purReceiptDetails) = SIS.PUR.purReceiptDetails.UZ_purReceiptDetailsSelectList(0, 999, "", False, "", oVar.ReceiptNo)
    If opurReceiptDetailss.Count > 0 Then
      Dim oTblhpurReceiptDetails As Table = New Table
      oTblhpurReceiptDetails.Width = 1000
      oTblhpurReceiptDetails.Style.Add("margin-top", "15px")
      oTblhpurReceiptDetails.Style.Add("margin-left", "10px")
      oTblhpurReceiptDetails.Style.Add("margin-right", "10px")
      Dim oRowhpurReceiptDetails As TableRow = New TableRow
      Dim oColhpurReceiptDetails As TableCell = New TableCell
      oColhpurReceiptDetails.Font.Bold = True
      oColhpurReceiptDetails.Font.Underline = True
      oColhpurReceiptDetails.Font.Size = 10
      oColhpurReceiptDetails.CssClass = "grpHD"
      oColhpurReceiptDetails.Text = "Receipt Items"
      oRowhpurReceiptDetails.Cells.Add(oColhpurReceiptDetails)
      oTblhpurReceiptDetails.Rows.Add(oRowhpurReceiptDetails)
      form1.Controls.Add(oTblhpurReceiptDetails)
      oTblpurReceiptDetails = New Table
      oTblpurReceiptDetails.Width = 1000
      oTblpurReceiptDetails.GridLines = GridLines.Both
      oTblpurReceiptDetails.Style.Add("margin-left", "10px")
      oTblpurReceiptDetails.Style.Add("margin-right", "10px")
      oRowpurReceiptDetails = New TableRow
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Receipt No"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Receipt Line"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Tran Type"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "left")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Bill Type"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "HSN-SAC Code"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "left")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Item Code"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "UOM"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "left")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Item Description"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "left")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Quantity"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Price"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Assessable Value"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Tax Code"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "CGST Rate"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "CGST Amount"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "SGST Rate"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "SGST Amount"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "IGST Rate"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "IGST Amount"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "CESS Rate"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "CESS Amount"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "TCS Rate"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "TCS Amount"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Currency"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "left")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Conversion Factor INR"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Delivery Date"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "center")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Project"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "left")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Element"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "left")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Employee"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "left")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Department"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "left")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Cost Center"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "left")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Division"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "left")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Main Line"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "center")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Parent Line"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Amount"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Total GST"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Total GST [INR]"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Total Amount"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Total Amount [INR]"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "Original Quantity"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "right")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oColpurReceiptDetails = New TableCell
      oColpurReceiptDetails.Text = "From Order"
      oColpurReceiptDetails.Font.Bold = True
      oColpurReceiptDetails.CssClass = "colHD"
      oColpurReceiptDetails.Style.Add("text-align", "center")
      oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
      oTblpurReceiptDetails.Rows.Add(oRowpurReceiptDetails)
      For Each opurReceiptDetails As SIS.PUR.purReceiptDetails In opurReceiptDetailss
        oRowpurReceiptDetails = New TableRow
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.Text = opurReceiptDetails.PUR_Receipts8_IsgecGSTIN
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.ReceiptLine
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.Text = opurReceiptDetails.SPMT_TranTypes14_Description
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Style.Add("text-align", "left")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.Text = opurReceiptDetails.SPMT_BillTypes10_Description
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.Text = opurReceiptDetails.SPMT_HSNSACCodes13_HSNSACCode
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Style.Add("text-align", "left")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.Text = opurReceiptDetails.PUR_Items7_ItemDescription
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.Text = opurReceiptDetails.SPMT_ERPUnits12_Description
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Style.Add("text-align", "left")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.ItemDescription
        oColpurReceiptDetails.Style.Add("text-align", "left")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.Quantity
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.Price
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.AssessableValue
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.Text = opurReceiptDetails.PUR_TaxCodes9_TaxDescription
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.CGSTRate
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.CGSTAmount
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.SGSTRate
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.SGSTAmount
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.IGSTrate
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.IGSTAmount
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.CESSRate
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.CESSAmount
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.TCSRate
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.TCSAmount
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.Text = opurReceiptDetails.PUR_Currencies6_CurrencyName
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Style.Add("text-align", "left")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.ConversionFactorINR
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.DeliveryDate
        oColpurReceiptDetails.Style.Add("text-align", "center")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.Text = opurReceiptDetails.IDM_Projects4_Description
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Style.Add("text-align", "left")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.Text = opurReceiptDetails.IDM_WBS5_Description
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Style.Add("text-align", "left")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.Text = opurReceiptDetails.HRM_Employees3_EmployeeName
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Style.Add("text-align", "left")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.Text = opurReceiptDetails.HRM_Departments1_Description
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Style.Add("text-align", "left")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.Text = opurReceiptDetails.SPMT_CostCenters11_Description
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Style.Add("text-align", "left")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.Text = opurReceiptDetails.HRM_Divisions2_Description
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Style.Add("text-align", "left")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = IIf(opurReceiptDetails.MainLine, "YES", "NO")
        oColpurReceiptDetails.Style.Add("text-align", "center")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.ParentLine
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.Amount
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.TotalGST
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.TaxAmount
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.TotalAmount
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.TotalAmountINR
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = opurReceiptDetails.OriginalQuantity
        oColpurReceiptDetails.Style.Add("text-align", "right")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.CssClass = "rowHD"
        oColpurReceiptDetails.Text = IIf(opurReceiptDetails.FromOrder, "YES", "NO")
        oColpurReceiptDetails.Style.Add("text-align", "center")
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        oTblpurReceiptDetails.Rows.Add(oRowpurReceiptDetails)
        oRowpurReceiptDetails = New TableRow
        oColpurReceiptDetails = New TableCell
        oColpurReceiptDetails.ColumnSpan = oTblpurReceiptDetails.Rows(0).Cells.Count
        oRowpurReceiptDetails.Cells.Add(oColpurReceiptDetails)
        Dim oTblpurReceiptItemProperty As Table = Nothing
        Dim oRowpurReceiptItemProperty As TableRow = Nothing
        Dim oColpurReceiptItemProperty As TableCell = Nothing
        Dim opurReceiptItemPropertys As List(Of SIS.PUR.purReceiptItemProperty) = SIS.PUR.purReceiptItemProperty.purReceiptItemPropertySelectList(0, 999, "", False, "", opurReceiptDetails.ReceiptNo, opurReceiptDetails.ReceiptLine)
        If opurReceiptItemPropertys.Count > 0 Then
          Dim oTblhpurReceiptItemProperty As Table = New Table
          oTblhpurReceiptItemProperty.Width = 980
          oTblhpurReceiptItemProperty.Style.Add("margin-top", "15px")
          oTblhpurReceiptItemProperty.Style.Add("margin-left", "10px")
          oTblhpurReceiptItemProperty.Style.Add("margin-right", "10px")
          Dim oRowhpurReceiptItemProperty As TableRow = New TableRow
          Dim oColhpurReceiptItemProperty As TableCell = New TableCell
          oColhpurReceiptItemProperty.Font.Bold = True
          oColhpurReceiptItemProperty.Font.Underline = True
          oColhpurReceiptItemProperty.Font.Size = 10
          oColhpurReceiptItemProperty.CssClass = "grpHD"
          oColhpurReceiptItemProperty.Text = "Receipt Item Property"
          oRowhpurReceiptItemProperty.Cells.Add(oColhpurReceiptItemProperty)
          oTblhpurReceiptItemProperty.Rows.Add(oRowhpurReceiptItemProperty)
          oColpurReceiptDetails.Controls.Add(oTblhpurReceiptItemProperty)
          oTblpurReceiptItemProperty = New Table
          oTblpurReceiptItemProperty.Width = 980
          oTblpurReceiptItemProperty.GridLines = GridLines.Both
          oTblpurReceiptItemProperty.Style.Add("margin-left", "10px")
          oTblpurReceiptItemProperty.Style.Add("margin-right", "10px")
          oRowpurReceiptItemProperty = New TableRow
          oColpurReceiptItemProperty = New TableCell
          oColpurReceiptItemProperty.Text = "Receipt No"
          oColpurReceiptItemProperty.Font.Bold = True
          oColpurReceiptItemProperty.CssClass = "colHD"
          oColpurReceiptItemProperty.Style.Add("text-align", "right")
          oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
          oColpurReceiptItemProperty = New TableCell
          oColpurReceiptItemProperty.Text = "Receipt Line"
          oColpurReceiptItemProperty.Font.Bold = True
          oColpurReceiptItemProperty.CssClass = "colHD"
          oColpurReceiptItemProperty.Style.Add("text-align", "right")
          oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
          oColpurReceiptItemProperty = New TableCell
          oColpurReceiptItemProperty.Text = "Item Code"
          oColpurReceiptItemProperty.Font.Bold = True
          oColpurReceiptItemProperty.CssClass = "colHD"
          oColpurReceiptItemProperty.Style.Add("text-align", "right")
          oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
          oColpurReceiptItemProperty = New TableCell
          oColpurReceiptItemProperty.Text = "Item Category"
          oColpurReceiptItemProperty.Font.Bold = True
          oColpurReceiptItemProperty.CssClass = "colHD"
          oColpurReceiptItemProperty.Style.Add("text-align", "right")
          oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
          oColpurReceiptItemProperty = New TableCell
          oColpurReceiptItemProperty.Text = "Category Spec"
          oColpurReceiptItemProperty.Font.Bold = True
          oColpurReceiptItemProperty.CssClass = "colHD"
          oColpurReceiptItemProperty.Style.Add("text-align", "right")
          oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
          oColpurReceiptItemProperty = New TableCell
          oColpurReceiptItemProperty.Text = "Serial No"
          oColpurReceiptItemProperty.Font.Bold = True
          oColpurReceiptItemProperty.CssClass = "colHD"
          oColpurReceiptItemProperty.Style.Add("text-align", "right")
          oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
          oColpurReceiptItemProperty = New TableCell
          oColpurReceiptItemProperty.Text = "Value Data Type"
          oColpurReceiptItemProperty.Font.Bold = True
          oColpurReceiptItemProperty.CssClass = "colHD"
          oColpurReceiptItemProperty.Style.Add("text-align", "left")
          oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
          oColpurReceiptItemProperty = New TableCell
          oColpurReceiptItemProperty.Text = "Is Range"
          oColpurReceiptItemProperty.Font.Bold = True
          oColpurReceiptItemProperty.CssClass = "colHD"
          oColpurReceiptItemProperty.Style.Add("text-align", "center")
          oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
          oColpurReceiptItemProperty = New TableCell
          oColpurReceiptItemProperty.Text = "Data Value [1]"
          oColpurReceiptItemProperty.Font.Bold = True
          oColpurReceiptItemProperty.CssClass = "colHD"
          oColpurReceiptItemProperty.Style.Add("text-align", "left")
          oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
          oColpurReceiptItemProperty = New TableCell
          oColpurReceiptItemProperty.Text = "Data Value [2]"
          oColpurReceiptItemProperty.Font.Bold = True
          oColpurReceiptItemProperty.CssClass = "colHD"
          oColpurReceiptItemProperty.Style.Add("text-align", "left")
          oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
          oTblpurReceiptItemProperty.Rows.Add(oRowpurReceiptItemProperty)
          For Each opurReceiptItemProperty As SIS.PUR.purReceiptItemProperty In opurReceiptItemPropertys
            oRowpurReceiptItemProperty = New TableRow
            oColpurReceiptItemProperty = New TableCell
            oColpurReceiptItemProperty.Text = opurReceiptItemProperty.PUR_Receipts6_IsgecGSTIN
            oColpurReceiptItemProperty.CssClass = "rowHD"
            oColpurReceiptItemProperty.Style.Add("text-align", "right")
            oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
            oColpurReceiptItemProperty = New TableCell
            oColpurReceiptItemProperty.Text = opurReceiptItemProperty.PUR_ReceiptDetails5_ItemDescription
            oColpurReceiptItemProperty.CssClass = "rowHD"
            oColpurReceiptItemProperty.Style.Add("text-align", "right")
            oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
            oColpurReceiptItemProperty = New TableCell
            oColpurReceiptItemProperty.Text = opurReceiptItemProperty.PUR_Items4_ItemDescription
            oColpurReceiptItemProperty.CssClass = "rowHD"
            oColpurReceiptItemProperty.Style.Add("text-align", "right")
            oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
            oColpurReceiptItemProperty = New TableCell
            oColpurReceiptItemProperty.Text = opurReceiptItemProperty.PUR_ItemCategories1_CategoryName
            oColpurReceiptItemProperty.CssClass = "rowHD"
            oColpurReceiptItemProperty.Style.Add("text-align", "right")
            oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
            oColpurReceiptItemProperty = New TableCell
            oColpurReceiptItemProperty.Text = opurReceiptItemProperty.PUR_ItemCategorySpecs2_SpecName
            oColpurReceiptItemProperty.CssClass = "rowHD"
            oColpurReceiptItemProperty.Style.Add("text-align", "right")
            oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
            oColpurReceiptItemProperty = New TableCell
            oColpurReceiptItemProperty.Text = opurReceiptItemProperty.PUR_ItemCategorySpecValues3_Data1Value
            oColpurReceiptItemProperty.CssClass = "rowHD"
            oColpurReceiptItemProperty.Style.Add("text-align", "right")
            oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
            oColpurReceiptItemProperty = New TableCell
            oColpurReceiptItemProperty.Text = opurReceiptItemProperty.PUR_ValueDataTypes7_ValueDataTypeName
            oColpurReceiptItemProperty.CssClass = "rowHD"
            oColpurReceiptItemProperty.Style.Add("text-align", "left")
            oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
            oColpurReceiptItemProperty = New TableCell
            oColpurReceiptItemProperty.CssClass = "rowHD"
            oColpurReceiptItemProperty.Text = IIf(opurReceiptItemProperty.IsRange, "YES", "NO")
            oColpurReceiptItemProperty.Style.Add("text-align", "center")
            oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
            oColpurReceiptItemProperty = New TableCell
            oColpurReceiptItemProperty.CssClass = "rowHD"
            oColpurReceiptItemProperty.Text = opurReceiptItemProperty.Data1Value
            oColpurReceiptItemProperty.Style.Add("text-align", "left")
            oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
            oColpurReceiptItemProperty = New TableCell
            oColpurReceiptItemProperty.CssClass = "rowHD"
            oColpurReceiptItemProperty.Text = opurReceiptItemProperty.Data2Value
            oColpurReceiptItemProperty.Style.Add("text-align", "left")
            oRowpurReceiptItemProperty.Cells.Add(oColpurReceiptItemProperty)
            oTblpurReceiptItemProperty.Rows.Add(oRowpurReceiptItemProperty)
          Next
          oColpurReceiptDetails.Controls.Add(oTblpurReceiptItemProperty)
          oTblpurReceiptDetails.Rows.Add(oRowpurReceiptDetails)
        End If
      Next
      form1.Controls.Add(oTblpurReceiptDetails)
    End If
  End Sub
End Class
