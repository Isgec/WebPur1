Imports System.Web.Script.Serialization
Partial Class GF_purReceiptDetails
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purReceiptDetails.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ReceiptNo=" & aVal(0) & "&ReceiptLine=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurReceiptDetails_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurReceiptDetails.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ReceiptNo As Int32 = GVpurReceiptDetails.DataKeys(e.CommandArgument).Values("ReceiptNo")  
        Dim ReceiptLine As Int32 = GVpurReceiptDetails.DataKeys(e.CommandArgument).Values("ReceiptLine")  
        Dim RedirectUrl As String = TBLpurReceiptDetails.EditUrl & "?ReceiptNo=" & ReceiptNo & "&ReceiptLine=" & ReceiptLine
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim ReceiptNo As Int32 = GVpurReceiptDetails.DataKeys(e.CommandArgument).Values("ReceiptNo")  
        Dim ReceiptLine As Int32 = GVpurReceiptDetails.DataKeys(e.CommandArgument).Values("ReceiptLine")  
        SIS.PUR.purReceiptDetails.DeleteWF(ReceiptNo, ReceiptLine)
        GVpurReceiptDetails.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurReceiptDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurReceiptDetails.Init
    DataClassName = "GpurReceiptDetails"
    SetGridView = GVpurReceiptDetails
  End Sub
  Protected Sub TBLpurReceiptDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurReceiptDetails.Init
    SetToolBar = TBLpurReceiptDetails
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
    Dim validateScriptReceiptNo As String = "<script type=""text/javascript"">" & _
      "  function validate_ReceiptNo(o) {" & _
      "    validated_FK_PUR_ReceiptDetails_ReceiptNo_main = true;" & _
      "    validate_FK_PUR_ReceiptDetails_ReceiptNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateReceiptNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateReceiptNo", validateScriptReceiptNo)
    End If
    Dim validateScriptFK_PUR_ReceiptDetails_ReceiptNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PUR_ReceiptDetails_ReceiptNo(o) {" & _
      "    var value = o.id;" & _
      "    var ReceiptNo = $get('" & F_ReceiptNo.ClientID & "');" & _
      "    try{" & _
      "    if(ReceiptNo.value==''){" & _
      "      if(validated_FK_PUR_ReceiptDetails_ReceiptNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ReceiptNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PUR_ReceiptDetails_ReceiptNo(value, validated_FK_PUR_ReceiptDetails_ReceiptNo);" & _
      "  }" & _
      "  validated_FK_PUR_ReceiptDetails_ReceiptNo_main = false;" & _
      "  function validated_FK_PUR_ReceiptDetails_ReceiptNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PUR_ReceiptDetails_ReceiptNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PUR_ReceiptDetails_ReceiptNo", validateScriptFK_PUR_ReceiptDetails_ReceiptNo)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptDetails_ReceiptNo(ByVal value As String) As String
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
