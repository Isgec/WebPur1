Imports System.Web.Script.Serialization
Partial Class GF_purReceiptItemProperty
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purReceiptItemProperty.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ReceiptNo=" & aVal(0) & "&ReceiptLine=" & aVal(1) & "&ItemCode=" & aVal(2) & "&ItemCategoryID=" & aVal(3) & "&CategorySpecID=" & aVal(4)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurReceiptItemProperty_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurReceiptItemProperty.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ReceiptNo As Int32 = GVpurReceiptItemProperty.DataKeys(e.CommandArgument).Values("ReceiptNo")  
        Dim ReceiptLine As Int32 = GVpurReceiptItemProperty.DataKeys(e.CommandArgument).Values("ReceiptLine")  
        Dim ItemCode As Int32 = GVpurReceiptItemProperty.DataKeys(e.CommandArgument).Values("ItemCode")  
        Dim ItemCategoryID As Int32 = GVpurReceiptItemProperty.DataKeys(e.CommandArgument).Values("ItemCategoryID")  
        Dim CategorySpecID As Int32 = GVpurReceiptItemProperty.DataKeys(e.CommandArgument).Values("CategorySpecID")  
        Dim RedirectUrl As String = TBLpurReceiptItemProperty.EditUrl & "?ReceiptNo=" & ReceiptNo & "&ReceiptLine=" & ReceiptLine & "&ItemCode=" & ItemCode & "&ItemCategoryID=" & ItemCategoryID & "&CategorySpecID=" & CategorySpecID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurReceiptItemProperty_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurReceiptItemProperty.Init
    DataClassName = "GpurReceiptItemProperty"
    SetGridView = GVpurReceiptItemProperty
  End Sub
  Protected Sub TBLpurReceiptItemProperty_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurReceiptItemProperty.Init
    SetToolBar = TBLpurReceiptItemProperty
  End Sub
  Protected Sub F_ReceiptNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ReceiptNo.TextChanged
    Session("F_ReceiptNo") = F_ReceiptNo.Text
    Session("F_ReceiptNo_Display") = F_ReceiptNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ReceiptNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purReceipts.SelectpurReceiptsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_ReceiptLine_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ReceiptLine.TextChanged
    Session("F_ReceiptLine") = F_ReceiptLine.Text
    Session("F_ReceiptLine_Display") = F_ReceiptLine_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ReceiptLineCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purReceiptDetails.SelectpurReceiptDetailsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_ReceiptNo_Display.Text = String.Empty
    If Not Session("F_ReceiptNo_Display") Is Nothing Then
      If Session("F_ReceiptNo_Display") <> String.Empty Then
        F_ReceiptNo_Display.Text = Session("F_ReceiptNo_Display")
      End If
    End If
    F_ReceiptNo.Text = String.Empty
    If Not Session("F_ReceiptNo") Is Nothing Then
      If Session("F_ReceiptNo") <> String.Empty Then
        F_ReceiptNo.Text = Session("F_ReceiptNo")
      End If
    End If
    Dim strScriptReceiptNo As String = "<script type=""text/javascript""> " & _
      "function ACEReceiptNo_Selected(sender, e) {" & _
      "  var F_ReceiptNo = $get('" & F_ReceiptNo.ClientID & "');" & _
      "  var F_ReceiptNo_Display = $get('" & F_ReceiptNo_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_ReceiptNo.value = p[0];" & _
      "  F_ReceiptNo_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ReceiptNo") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ReceiptNo", strScriptReceiptNo)
      End If
    Dim strScriptPopulatingReceiptNo As String = "<script type=""text/javascript""> " & _
      "function ACEReceiptNo_Populating(o,e) {" & _
      "  var p = $get('" & F_ReceiptNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEReceiptNo_Populated(o,e) {" & _
      "  var p = $get('" & F_ReceiptNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ReceiptNoPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ReceiptNoPopulating", strScriptPopulatingReceiptNo)
      End If
    F_ReceiptLine_Display.Text = String.Empty
    If Not Session("F_ReceiptLine_Display") Is Nothing Then
      If Session("F_ReceiptLine_Display") <> String.Empty Then
        F_ReceiptLine_Display.Text = Session("F_ReceiptLine_Display")
      End If
    End If
    F_ReceiptLine.Text = String.Empty
    If Not Session("F_ReceiptLine") Is Nothing Then
      If Session("F_ReceiptLine") <> String.Empty Then
        F_ReceiptLine.Text = Session("F_ReceiptLine")
      End If
    End If
    Dim strScriptReceiptLine As String = "<script type=""text/javascript""> " & _
      "function ACEReceiptLine_Selected(sender, e) {" & _
      "  var F_ReceiptLine = $get('" & F_ReceiptLine.ClientID & "');" & _
      "  var F_ReceiptLine_Display = $get('" & F_ReceiptLine_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_ReceiptLine.value = p[1];" & _
      "  F_ReceiptLine_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ReceiptLine") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ReceiptLine", strScriptReceiptLine)
      End If
    Dim strScriptPopulatingReceiptLine As String = "<script type=""text/javascript""> " & _
      "function ACEReceiptLine_Populating(o,e) {" & _
      "  var p = $get('" & F_ReceiptLine.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEReceiptLine_Populated(o,e) {" & _
      "  var p = $get('" & F_ReceiptLine.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ReceiptLinePopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ReceiptLinePopulating", strScriptPopulatingReceiptLine)
      End If
    Dim validateScriptReceiptNo As String = "<script type=""text/javascript"">" & _
      "  function validate_ReceiptNo(o) {" & _
      "    validated_FK_PUR_ReceiptItemProperty_ReceiptNo_main = true;" & _
      "    validate_FK_PUR_ReceiptItemProperty_ReceiptNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateReceiptNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateReceiptNo", validateScriptReceiptNo)
    End If
    Dim validateScriptReceiptLine As String = "<script type=""text/javascript"">" & _
      "  function validate_ReceiptLine(o) {" & _
      "    validated_FK_PUR_ReceiptItemProperty_ReceiptLine_main = true;" & _
      "    validate_FK_PUR_ReceiptItemProperty_ReceiptLine(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateReceiptLine") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateReceiptLine", validateScriptReceiptLine)
    End If
    Dim validateScriptFK_PUR_ReceiptItemProperty_ReceiptLine As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PUR_ReceiptItemProperty_ReceiptLine(o) {" & _
      "    var value = o.id;" & _
      "    var ReceiptNo = $get('" & F_ReceiptNo.ClientID & "');" & _
      "    try{" & _
      "    if(ReceiptNo.value==''){" & _
      "      if(validated_FK_PUR_ReceiptItemProperty_ReceiptLine.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ReceiptNo.value ;" & _
      "    }catch(ex){}" & _
      "    var ReceiptLine = $get('" & F_ReceiptLine.ClientID & "');" & _
      "    try{" & _
      "    if(ReceiptLine.value==''){" & _
      "      if(validated_FK_PUR_ReceiptItemProperty_ReceiptLine.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ReceiptLine.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PUR_ReceiptItemProperty_ReceiptLine(value, validated_FK_PUR_ReceiptItemProperty_ReceiptLine);" & _
      "  }" & _
      "  validated_FK_PUR_ReceiptItemProperty_ReceiptLine_main = false;" & _
      "  function validated_FK_PUR_ReceiptItemProperty_ReceiptLine(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PUR_ReceiptItemProperty_ReceiptLine") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PUR_ReceiptItemProperty_ReceiptLine", validateScriptFK_PUR_ReceiptItemProperty_ReceiptLine)
    End If
    Dim validateScriptFK_PUR_ReceiptItemProperty_ReceiptNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PUR_ReceiptItemProperty_ReceiptNo(o) {" & _
      "    var value = o.id;" & _
      "    var ReceiptNo = $get('" & F_ReceiptNo.ClientID & "');" & _
      "    try{" & _
      "    if(ReceiptNo.value==''){" & _
      "      if(validated_FK_PUR_ReceiptItemProperty_ReceiptNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ReceiptNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PUR_ReceiptItemProperty_ReceiptNo(value, validated_FK_PUR_ReceiptItemProperty_ReceiptNo);" & _
      "  }" & _
      "  validated_FK_PUR_ReceiptItemProperty_ReceiptNo_main = false;" & _
      "  function validated_FK_PUR_ReceiptItemProperty_ReceiptNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PUR_ReceiptItemProperty_ReceiptNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PUR_ReceiptItemProperty_ReceiptNo", validateScriptFK_PUR_ReceiptItemProperty_ReceiptNo)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptItemProperty_ReceiptLine(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ReceiptNo As Int32 = CType(aVal(1),Int32)
    Dim ReceiptLine As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PUR.purReceiptDetails = SIS.PUR.purReceiptDetails.purReceiptDetailsGetByID(ReceiptNo,ReceiptLine)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptItemProperty_ReceiptNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ReceiptNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PUR.purReceipts = SIS.PUR.purReceipts.purReceiptsGetByID(ReceiptNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
