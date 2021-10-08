Imports System.Web.Script.Serialization
Partial Class GF_purItemSpecValues
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purItemSpecValues.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SpecID=" & aVal(0) & "&SerialNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurItemSpecValues_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurItemSpecValues.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SpecID As Int32 = GVpurItemSpecValues.DataKeys(e.CommandArgument).Values("SpecID")  
        Dim SerialNo As Int32 = GVpurItemSpecValues.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLpurItemSpecValues.EditUrl & "?SpecID=" & SpecID & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurItemSpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurItemSpecValues.Init
    DataClassName = "GpurItemSpecValues"
    SetGridView = GVpurItemSpecValues
  End Sub
  Protected Sub TBLpurItemSpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemSpecValues.Init
    SetToolBar = TBLpurItemSpecValues
  End Sub
  Protected Sub F_SpecID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SpecID.TextChanged
    Session("F_SpecID") = F_SpecID.Text
    Session("F_SpecID_Display") = F_SpecID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SpecIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemSpecification.SelectpurItemSpecificationAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_SpecID_Display.Text = String.Empty
    If Not Session("F_SpecID_Display") Is Nothing Then
      If Session("F_SpecID_Display") <> String.Empty Then
        F_SpecID_Display.Text = Session("F_SpecID_Display")
      End If
    End If
    F_SpecID.Text = String.Empty
    If Not Session("F_SpecID") Is Nothing Then
      If Session("F_SpecID") <> String.Empty Then
        F_SpecID.Text = Session("F_SpecID")
      End If
    End If
    Dim strScriptSpecID As String = "<script type=""text/javascript""> " & _
      "function ACESpecID_Selected(sender, e) {" & _
      "  var F_SpecID = $get('" & F_SpecID.ClientID & "');" & _
      "  var F_SpecID_Display = $get('" & F_SpecID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_SpecID.value = p[0];" & _
      "  F_SpecID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SpecID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SpecID", strScriptSpecID)
      End If
    Dim strScriptPopulatingSpecID As String = "<script type=""text/javascript""> " & _
      "function ACESpecID_Populating(o,e) {" & _
      "  var p = $get('" & F_SpecID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACESpecID_Populated(o,e) {" & _
      "  var p = $get('" & F_SpecID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SpecIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SpecIDPopulating", strScriptPopulatingSpecID)
      End If
    Dim validateScriptSpecID As String = "<script type=""text/javascript"">" & _
      "  function validate_SpecID(o) {" & _
      "    validated_FK_PUR_ItemSpecValues_SpecID_main = true;" & _
      "    validate_FK_PUR_ItemSpecValues_SpecID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSpecID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSpecID", validateScriptSpecID)
    End If
    Dim validateScriptFK_PUR_ItemSpecValues_SpecID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PUR_ItemSpecValues_SpecID(o) {" & _
      "    var value = o.id;" & _
      "    var SpecID = $get('" & F_SpecID.ClientID & "');" & _
      "    try{" & _
      "    if(SpecID.value==''){" & _
      "      if(validated_FK_PUR_ItemSpecValues_SpecID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + SpecID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PUR_ItemSpecValues_SpecID(value, validated_FK_PUR_ItemSpecValues_SpecID);" & _
      "  }" & _
      "  validated_FK_PUR_ItemSpecValues_SpecID_main = false;" & _
      "  function validated_FK_PUR_ItemSpecValues_SpecID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PUR_ItemSpecValues_SpecID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PUR_ItemSpecValues_SpecID", validateScriptFK_PUR_ItemSpecValues_SpecID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ItemSpecValues_SpecID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SpecID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PUR.purItemSpecification = SIS.PUR.purItemSpecification.purItemSpecificationGetByID(SpecID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
