Imports System.Web.Script.Serialization
Partial Class GF_purItemCategorySpecValues
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purItemCategorySpecValues.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ItemCategoryID=" & aVal(0) & "&CategorySpecID=" & aVal(1) & "&SerialNo=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurItemCategorySpecValues_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurItemCategorySpecValues.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ItemCategoryID As Int32 = GVpurItemCategorySpecValues.DataKeys(e.CommandArgument).Values("ItemCategoryID")  
        Dim CategorySpecID As Int32 = GVpurItemCategorySpecValues.DataKeys(e.CommandArgument).Values("CategorySpecID")  
        Dim SerialNo As Int32 = GVpurItemCategorySpecValues.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLpurItemCategorySpecValues.EditUrl & "?ItemCategoryID=" & ItemCategoryID & "&CategorySpecID=" & CategorySpecID & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurItemCategorySpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurItemCategorySpecValues.Init
    DataClassName = "GpurItemCategorySpecValues"
    SetGridView = GVpurItemCategorySpecValues
  End Sub
  Protected Sub TBLpurItemCategorySpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemCategorySpecValues.Init
    SetToolBar = TBLpurItemCategorySpecValues
  End Sub
  Protected Sub F_ItemCategoryID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ItemCategoryID.TextChanged
    Session("F_ItemCategoryID") = F_ItemCategoryID.Text
    Session("F_ItemCategoryID_Display") = F_ItemCategoryID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ItemCategoryIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategories.SelectpurItemCategoriesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_CategorySpecID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CategorySpecID.TextChanged
    Session("F_CategorySpecID") = F_CategorySpecID.Text
    Session("F_CategorySpecID_Display") = F_CategorySpecID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CategorySpecIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategorySpecs.SelectpurItemCategorySpecsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_ItemCategoryID_Display.Text = String.Empty
    If Not Session("F_ItemCategoryID_Display") Is Nothing Then
      If Session("F_ItemCategoryID_Display") <> String.Empty Then
        F_ItemCategoryID_Display.Text = Session("F_ItemCategoryID_Display")
      End If
    End If
    F_ItemCategoryID.Text = String.Empty
    If Not Session("F_ItemCategoryID") Is Nothing Then
      If Session("F_ItemCategoryID") <> String.Empty Then
        F_ItemCategoryID.Text = Session("F_ItemCategoryID")
      End If
    End If
    Dim strScriptItemCategoryID As String = "<script type=""text/javascript""> " & _
      "function ACEItemCategoryID_Selected(sender, e) {" & _
      "  var F_ItemCategoryID = $get('" & F_ItemCategoryID.ClientID & "');" & _
      "  var F_ItemCategoryID_Display = $get('" & F_ItemCategoryID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_ItemCategoryID.value = p[0];" & _
      "  F_ItemCategoryID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ItemCategoryID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ItemCategoryID", strScriptItemCategoryID)
      End If
    Dim strScriptPopulatingItemCategoryID As String = "<script type=""text/javascript""> " & _
      "function ACEItemCategoryID_Populating(o,e) {" & _
      "  var p = $get('" & F_ItemCategoryID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEItemCategoryID_Populated(o,e) {" & _
      "  var p = $get('" & F_ItemCategoryID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ItemCategoryIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ItemCategoryIDPopulating", strScriptPopulatingItemCategoryID)
      End If
    F_CategorySpecID_Display.Text = String.Empty
    If Not Session("F_CategorySpecID_Display") Is Nothing Then
      If Session("F_CategorySpecID_Display") <> String.Empty Then
        F_CategorySpecID_Display.Text = Session("F_CategorySpecID_Display")
      End If
    End If
    F_CategorySpecID.Text = String.Empty
    If Not Session("F_CategorySpecID") Is Nothing Then
      If Session("F_CategorySpecID") <> String.Empty Then
        F_CategorySpecID.Text = Session("F_CategorySpecID")
      End If
    End If
    Dim strScriptCategorySpecID As String = "<script type=""text/javascript""> " & _
      "function ACECategorySpecID_Selected(sender, e) {" & _
      "  var F_CategorySpecID = $get('" & F_CategorySpecID.ClientID & "');" & _
      "  var F_CategorySpecID_Display = $get('" & F_CategorySpecID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_CategorySpecID.value = p[1];" & _
      "  F_CategorySpecID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CategorySpecID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CategorySpecID", strScriptCategorySpecID)
      End If
    Dim strScriptPopulatingCategorySpecID As String = "<script type=""text/javascript""> " & _
      "function ACECategorySpecID_Populating(o,e) {" & _
      "  var p = $get('" & F_CategorySpecID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACECategorySpecID_Populated(o,e) {" & _
      "  var p = $get('" & F_CategorySpecID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CategorySpecIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CategorySpecIDPopulating", strScriptPopulatingCategorySpecID)
      End If
    Dim validateScriptItemCategoryID As String = "<script type=""text/javascript"">" & _
      "  function validate_ItemCategoryID(o) {" & _
      "    validated_FK_PUR_ItemCategorySpecValues_ItemCategoryID_main = true;" & _
      "    validate_FK_PUR_ItemCategorySpecValues_ItemCategoryID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateItemCategoryID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateItemCategoryID", validateScriptItemCategoryID)
    End If
    Dim validateScriptCategorySpecID As String = "<script type=""text/javascript"">" & _
      "  function validate_CategorySpecID(o) {" & _
      "    validated_FK_PUR_ItemCategorySpecValues_CategorySpecID_main = true;" & _
      "    validate_FK_PUR_ItemCategorySpecValues_CategorySpecID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCategorySpecID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCategorySpecID", validateScriptCategorySpecID)
    End If
    Dim validateScriptFK_PUR_ItemCategorySpecValues_ItemCategoryID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PUR_ItemCategorySpecValues_ItemCategoryID(o) {" & _
      "    var value = o.id;" & _
      "    var ItemCategoryID = $get('" & F_ItemCategoryID.ClientID & "');" & _
      "    try{" & _
      "    if(ItemCategoryID.value==''){" & _
      "      if(validated_FK_PUR_ItemCategorySpecValues_ItemCategoryID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ItemCategoryID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PUR_ItemCategorySpecValues_ItemCategoryID(value, validated_FK_PUR_ItemCategorySpecValues_ItemCategoryID);" & _
      "  }" & _
      "  validated_FK_PUR_ItemCategorySpecValues_ItemCategoryID_main = false;" & _
      "  function validated_FK_PUR_ItemCategorySpecValues_ItemCategoryID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PUR_ItemCategorySpecValues_ItemCategoryID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PUR_ItemCategorySpecValues_ItemCategoryID", validateScriptFK_PUR_ItemCategorySpecValues_ItemCategoryID)
    End If
    Dim validateScriptFK_PUR_ItemCategorySpecValues_CategorySpecID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PUR_ItemCategorySpecValues_CategorySpecID(o) {" & _
      "    var value = o.id;" & _
      "    var ItemCategoryID = $get('" & F_ItemCategoryID.ClientID & "');" & _
      "    try{" & _
      "    if(ItemCategoryID.value==''){" & _
      "      if(validated_FK_PUR_ItemCategorySpecValues_CategorySpecID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ItemCategoryID.value ;" & _
      "    }catch(ex){}" & _
      "    var CategorySpecID = $get('" & F_CategorySpecID.ClientID & "');" & _
      "    try{" & _
      "    if(CategorySpecID.value==''){" & _
      "      if(validated_FK_PUR_ItemCategorySpecValues_CategorySpecID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + CategorySpecID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PUR_ItemCategorySpecValues_CategorySpecID(value, validated_FK_PUR_ItemCategorySpecValues_CategorySpecID);" & _
      "  }" & _
      "  validated_FK_PUR_ItemCategorySpecValues_CategorySpecID_main = false;" & _
      "  function validated_FK_PUR_ItemCategorySpecValues_CategorySpecID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PUR_ItemCategorySpecValues_CategorySpecID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PUR_ItemCategorySpecValues_CategorySpecID", validateScriptFK_PUR_ItemCategorySpecValues_CategorySpecID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ItemCategorySpecValues_ItemCategoryID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ItemCategoryID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PUR.purItemCategories = SIS.PUR.purItemCategories.purItemCategoriesGetByID(ItemCategoryID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ItemCategorySpecValues_CategorySpecID(ByVal value As String) As String
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
End Class
