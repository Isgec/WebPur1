Imports System.Web.Script.Serialization
Partial Class GF_purOrderDetails
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purOrderDetails.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?OrderNo=" & aVal(0) & "&OrderLine=" & aVal(1) & "&OrderRev=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurOrderDetails_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurOrderDetails.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim OrderNo As Int32 = GVpurOrderDetails.DataKeys(e.CommandArgument).Values("OrderNo")  
        Dim OrderLine As Int32 = GVpurOrderDetails.DataKeys(e.CommandArgument).Values("OrderLine")  
        Dim OrderRev As Int32 = GVpurOrderDetails.DataKeys(e.CommandArgument).Values("OrderRev")  
        Dim RedirectUrl As String = TBLpurOrderDetails.EditUrl & "?OrderNo=" & OrderNo & "&OrderLine=" & OrderLine & "&OrderRev=" & OrderRev
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim OrderNo As Int32 = GVpurOrderDetails.DataKeys(e.CommandArgument).Values("OrderNo")  
        Dim OrderLine As Int32 = GVpurOrderDetails.DataKeys(e.CommandArgument).Values("OrderLine")  
        Dim OrderRev As Int32 = GVpurOrderDetails.DataKeys(e.CommandArgument).Values("OrderRev")  
        SIS.PUR.purOrderDetails.DeleteWF(OrderNo, OrderLine, OrderRev)
        GVpurOrderDetails.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurOrderDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurOrderDetails.Init
    DataClassName = "GpurOrderDetails"
    SetGridView = GVpurOrderDetails
  End Sub
  Protected Sub TBLpurOrderDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurOrderDetails.Init
    SetToolBar = TBLpurOrderDetails
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
  Protected Sub F_OrderRev_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_OrderRev.TextChanged
    Session("F_OrderRev") = F_OrderRev.Text
    InitGridPage()
  End Sub
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
    Dim validateScriptOrderNo As String = "<script type=""text/javascript"">" & _
      "  function validate_OrderNo(o) {" & _
      "    validated_FK_PUR_OrderDetails_OrderNo_main = true;" & _
      "    validate_FK_PUR_OrderDetails_OrderNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateOrderNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateOrderNo", validateScriptOrderNo)
    End If
    Dim validateScriptFK_PUR_OrderDetails_OrderNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PUR_OrderDetails_OrderNo(o) {" & _
      "    var value = o.id;" & _
      "    var OrderNo = $get('" & F_OrderNo.ClientID & "');" & _
      "    try{" & _
      "    if(OrderNo.value==''){" & _
      "      if(validated_FK_PUR_OrderDetails_OrderNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + OrderNo.value ;" & _
      "    }catch(ex){}" & _
      "    var OrderRev = $get('" & F_OrderRev.ClientID & "');" & _
      "    try{" & _
      "    if(OrderRev.value==''){" & _
      "      if(validated_FK_PUR_OrderDetails_OrderNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + OrderRev.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PUR_OrderDetails_OrderNo(value, validated_FK_PUR_OrderDetails_OrderNo);" & _
      "  }" & _
      "  validated_FK_PUR_OrderDetails_OrderNo_main = false;" & _
      "  function validated_FK_PUR_OrderDetails_OrderNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PUR_OrderDetails_OrderNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PUR_OrderDetails_OrderNo", validateScriptFK_PUR_OrderDetails_OrderNo)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_OrderDetails_OrderNo(ByVal value As String) As String
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
End Class
