Imports System.Web.Script.Serialization
Partial Class GF_purOrderItemProperty
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purOrderItemProperty.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?OrderNo=" & aVal(0) & "&OrderRev=" & aVal(1) & "&OrderLine=" & aVal(2) & "&ItemCode=" & aVal(3) & "&ItemCategoryID=" & aVal(4) & "&CategorySpecID=" & aVal(5)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurOrderItemProperty_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurOrderItemProperty.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim OrderNo As Int32 = GVpurOrderItemProperty.DataKeys(e.CommandArgument).Values("OrderNo")  
        Dim OrderRev As Int32 = GVpurOrderItemProperty.DataKeys(e.CommandArgument).Values("OrderRev")  
        Dim OrderLine As Int32 = GVpurOrderItemProperty.DataKeys(e.CommandArgument).Values("OrderLine")  
        Dim ItemCode As Int32 = GVpurOrderItemProperty.DataKeys(e.CommandArgument).Values("ItemCode")  
        Dim ItemCategoryID As Int32 = GVpurOrderItemProperty.DataKeys(e.CommandArgument).Values("ItemCategoryID")  
        Dim CategorySpecID As Int32 = GVpurOrderItemProperty.DataKeys(e.CommandArgument).Values("CategorySpecID")  
        Dim RedirectUrl As String = TBLpurOrderItemProperty.EditUrl & "?OrderNo=" & OrderNo & "&OrderRev=" & OrderRev & "&OrderLine=" & OrderLine & "&ItemCode=" & ItemCode & "&ItemCategoryID=" & ItemCategoryID & "&CategorySpecID=" & CategorySpecID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurOrderItemProperty_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurOrderItemProperty.Init
    DataClassName = "GpurOrderItemProperty"
    SetGridView = GVpurOrderItemProperty
  End Sub
  Protected Sub TBLpurOrderItemProperty_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurOrderItemProperty.Init
    SetToolBar = TBLpurOrderItemProperty
  End Sub
  Protected Sub F_OrderRev_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_OrderRev.TextChanged
    Session("F_OrderRev") = F_OrderRev.Text
    InitGridPage()
  End Sub
  Protected Sub F_OrderNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_OrderNo.TextChanged
    Session("F_OrderNo") = F_OrderNo.Text
    Session("F_OrderNo_Display") = F_OrderNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function OrderNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purOrders.SelectpurOrdersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_OrderLine_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_OrderLine.TextChanged
    Session("F_OrderLine") = F_OrderLine.Text
    Session("F_OrderLine_Display") = F_OrderLine_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function OrderLineCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purOrderDetails.SelectpurOrderDetailsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_OrderNo_Display.Text = String.Empty
    If Not Session("F_OrderNo_Display") Is Nothing Then
      If Session("F_OrderNo_Display") <> String.Empty Then
        F_OrderNo_Display.Text = Session("F_OrderNo_Display")
      End If
    End If
    F_OrderNo.Text = String.Empty
    If Not Session("F_OrderNo") Is Nothing Then
      If Session("F_OrderNo") <> String.Empty Then
        F_OrderNo.Text = Session("F_OrderNo")
      End If
    End If
    Dim strScriptOrderNo As String = "<script type=""text/javascript""> " & _
      "function ACEOrderNo_Selected(sender, e) {" & _
      "  var F_OrderNo = $get('" & F_OrderNo.ClientID & "');" & _
      "  var F_OrderNo_Display = $get('" & F_OrderNo_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_OrderNo.value = p[0];" & _
      "  F_OrderNo_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_OrderNo") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_OrderNo", strScriptOrderNo)
      End If
    Dim strScriptPopulatingOrderNo As String = "<script type=""text/javascript""> " & _
      "function ACEOrderNo_Populating(o,e) {" & _
      "  var p = $get('" & F_OrderNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEOrderNo_Populated(o,e) {" & _
      "  var p = $get('" & F_OrderNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_OrderNoPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_OrderNoPopulating", strScriptPopulatingOrderNo)
      End If
    F_OrderLine_Display.Text = String.Empty
    If Not Session("F_OrderLine_Display") Is Nothing Then
      If Session("F_OrderLine_Display") <> String.Empty Then
        F_OrderLine_Display.Text = Session("F_OrderLine_Display")
      End If
    End If
    F_OrderLine.Text = String.Empty
    If Not Session("F_OrderLine") Is Nothing Then
      If Session("F_OrderLine") <> String.Empty Then
        F_OrderLine.Text = Session("F_OrderLine")
      End If
    End If
    Dim strScriptOrderLine As String = "<script type=""text/javascript""> " & _
      "function ACEOrderLine_Selected(sender, e) {" & _
      "  var F_OrderLine = $get('" & F_OrderLine.ClientID & "');" & _
      "  var F_OrderLine_Display = $get('" & F_OrderLine_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_OrderLine.value = p[1];" & _
      "  F_OrderLine_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_OrderLine") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_OrderLine", strScriptOrderLine)
      End If
    Dim strScriptPopulatingOrderLine As String = "<script type=""text/javascript""> " & _
      "function ACEOrderLine_Populating(o,e) {" & _
      "  var p = $get('" & F_OrderLine.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEOrderLine_Populated(o,e) {" & _
      "  var p = $get('" & F_OrderLine.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_OrderLinePopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_OrderLinePopulating", strScriptPopulatingOrderLine)
      End If
    Dim validateScriptOrderNo As String = "<script type=""text/javascript"">" & _
      "  function validate_OrderNo(o) {" & _
      "    validated_FK_PUR_OrderItemProperty_OrderNo_main = true;" & _
      "    validate_FK_PUR_OrderItemProperty_OrderNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateOrderNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateOrderNo", validateScriptOrderNo)
    End If
    Dim validateScriptOrderLine As String = "<script type=""text/javascript"">" & _
      "  function validate_OrderLine(o) {" & _
      "    validated_FK_PUR_OrderItemProperty_OrderLine_main = true;" & _
      "    validate_FK_PUR_OrderItemProperty_OrderLine(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateOrderLine") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateOrderLine", validateScriptOrderLine)
    End If
    Dim validateScriptFK_PUR_OrderItemProperty_OrderLine As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PUR_OrderItemProperty_OrderLine(o) {" & _
      "    var value = o.id;" & _
      "    var OrderNo = $get('" & F_OrderNo.ClientID & "');" & _
      "    try{" & _
      "    if(OrderNo.value==''){" & _
      "      if(validated_FK_PUR_OrderItemProperty_OrderLine.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + OrderNo.value ;" & _
      "    }catch(ex){}" & _
      "    var OrderRev = $get('" & F_OrderRev.ClientID & "');" & _
      "    try{" & _
      "    if(OrderRev.value==''){" & _
      "      if(validated_FK_PUR_OrderItemProperty_OrderLine.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + OrderRev.value ;" & _
      "    }catch(ex){}" & _
      "    var OrderLine = $get('" & F_OrderLine.ClientID & "');" & _
      "    try{" & _
      "    if(OrderLine.value==''){" & _
      "      if(validated_FK_PUR_OrderItemProperty_OrderLine.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + OrderLine.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PUR_OrderItemProperty_OrderLine(value, validated_FK_PUR_OrderItemProperty_OrderLine);" & _
      "  }" & _
      "  validated_FK_PUR_OrderItemProperty_OrderLine_main = false;" & _
      "  function validated_FK_PUR_OrderItemProperty_OrderLine(result) {" & _
      "    var p = result.split('|');" & _
      "    var o = $get(p[1]);" & _
      "    var o_d = $get(p[1]+'_Display');" & _
      "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
      "    o.style.backgroundImage  = 'none';" & _
      "    if(p[0]=='1'){" & _
      "      o.value='';" & _
      "      try{o_d.innerHTML = '';}catch(ex){}" & _
      "      __doPostBack(o.id, o.value);" & _
      "    }" & _
      "    else" & _
      "      __doPostBack(o.id, o.value);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PUR_OrderItemProperty_OrderLine") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PUR_OrderItemProperty_OrderLine", validateScriptFK_PUR_OrderItemProperty_OrderLine)
    End If
    Dim validateScriptFK_PUR_OrderItemProperty_OrderNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PUR_OrderItemProperty_OrderNo(o) {" & _
      "    var value = o.id;" & _
      "    var OrderNo = $get('" & F_OrderNo.ClientID & "');" & _
      "    try{" & _
      "    if(OrderNo.value==''){" & _
      "      if(validated_FK_PUR_OrderItemProperty_OrderNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + OrderNo.value ;" & _
      "    }catch(ex){}" & _
      "    var OrderRev = $get('" & F_OrderRev.ClientID & "');" & _
      "    try{" & _
      "    if(OrderRev.value==''){" & _
      "      if(validated_FK_PUR_OrderItemProperty_OrderNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + OrderRev.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PUR_OrderItemProperty_OrderNo(value, validated_FK_PUR_OrderItemProperty_OrderNo);" & _
      "  }" & _
      "  validated_FK_PUR_OrderItemProperty_OrderNo_main = false;" & _
      "  function validated_FK_PUR_OrderItemProperty_OrderNo(result) {" & _
      "    var p = result.split('|');" & _
      "    var o = $get(p[1]);" & _
      "    var o_d = $get(p[1]+'_Display');" & _
      "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
      "    o.style.backgroundImage  = 'none';" & _
      "    if(p[0]=='1'){" & _
      "      o.value='';" & _
      "      try{o_d.innerHTML = '';}catch(ex){}" & _
      "      __doPostBack(o.id, o.value);" & _
      "    }" & _
      "    else" & _
      "      __doPostBack(o.id, o.value);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PUR_OrderItemProperty_OrderNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PUR_OrderItemProperty_OrderNo", validateScriptFK_PUR_OrderItemProperty_OrderNo)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_OrderItemProperty_OrderLine(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim OrderNo As Int32 = CType(aVal(1),Int32)
    Dim OrderRev As Int32 = CType(aVal(2),Int32)
    Dim OrderLine As Int32 = CType(aVal(3),Int32)
    Dim oVar As SIS.PUR.purOrderDetails = SIS.PUR.purOrderDetails.purOrderDetailsGetByID(OrderNo,OrderRev,OrderLine)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_OrderItemProperty_OrderNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim OrderNo As Int32 = CType(aVal(1),Int32)
    Dim OrderRev As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PUR.purOrders = SIS.PUR.purOrders.purOrdersGetByID(OrderNo,OrderRev)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CategorySpecIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategorySpecs.SelectpurItemCategorySpecsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_OrderItemProperty_CategorySpecID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ItemCategoryID As Int32 = CType(aVal(1),Int32)
    Dim CategorySpecID As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PUR.purItemCategorySpecs = SIS.PUR.purItemCategorySpecs.purItemCategorySpecsGetByID(ItemCategoryID,CategorySpecID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategorySpecValues.SelectpurItemCategorySpecValuesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_OrderItemProperty_SerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ItemCategoryID As Int32 = CType(aVal(1),Int32)
    Dim CategorySpecID As Int32 = CType(aVal(2),Int32)
    Dim SerialNo As Int32 = CType(aVal(3),Int32)
    Dim oVar As SIS.PUR.purItemCategorySpecValues = SIS.PUR.purItemCategorySpecValues.purItemCategorySpecValuesGetByID(ItemCategoryID,CategorySpecID,SerialNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function





End Class
