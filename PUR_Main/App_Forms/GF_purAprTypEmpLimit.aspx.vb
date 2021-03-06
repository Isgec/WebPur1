Imports System.Web.Script.Serialization
Partial Class GF_purAprTypEmpLimit
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purAprTypEmpLimit.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurAprTypEmpLimit_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurAprTypEmpLimit.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpurAprTypEmpLimit.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLpurAprTypEmpLimit.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Extendwf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpurAprTypEmpLimit.DataKeys(e.CommandArgument).Values("SerialNo")  
        SIS.PUR.purAprTypEmpLimit.ExtendWF(SerialNo)
        GVpurAprTypEmpLimit.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Closewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpurAprTypEmpLimit.DataKeys(e.CommandArgument).Values("SerialNo")  
        SIS.PUR.purAprTypEmpLimit.CloseWF(SerialNo)
        GVpurAprTypEmpLimit.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurAprTypEmpLimit_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurAprTypEmpLimit.Init
    DataClassName = "GpurAprTypEmpLimit"
    SetGridView = GVpurAprTypEmpLimit
  End Sub
  Protected Sub TBLpurAprTypEmpLimit_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurAprTypEmpLimit.Init
    SetToolBar = TBLpurAprTypEmpLimit
  End Sub
  Protected Sub F_CardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CardNo.TextChanged
    Session("F_CardNo") = F_CardNo.Text
    Session("F_CardNo_Display") = F_CardNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_CardNo_Display.Text = String.Empty
    If Not Session("F_CardNo_Display") Is Nothing Then
      If Session("F_CardNo_Display") <> String.Empty Then
        F_CardNo_Display.Text = Session("F_CardNo_Display")
      End If
    End If
    F_CardNo.Text = String.Empty
    If Not Session("F_CardNo") Is Nothing Then
      If Session("F_CardNo") <> String.Empty Then
        F_CardNo.Text = Session("F_CardNo")
      End If
    End If
    Dim strScriptCardNo As String = "<script type=""text/javascript""> " & _
      "function ACECardNo_Selected(sender, e) {" & _
      "  var F_CardNo = $get('" & F_CardNo.ClientID & "');" & _
      "  var F_CardNo_Display = $get('" & F_CardNo_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_CardNo.value = p[0];" & _
      "  F_CardNo_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CardNo") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CardNo", strScriptCardNo)
      End If
    Dim strScriptPopulatingCardNo As String = "<script type=""text/javascript""> " & _
      "function ACECardNo_Populating(o,e) {" & _
      "  var p = $get('" & F_CardNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACECardNo_Populated(o,e) {" & _
      "  var p = $get('" & F_CardNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CardNoPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CardNoPopulating", strScriptPopulatingCardNo)
      End If
    Dim validateScriptCardNo As String = "<script type=""text/javascript"">" & _
      "  function validate_CardNo(o) {" & _
      "    validated_FK_PUR_AprTypEmpLimit_CardNo_main = true;" & _
      "    validate_FK_PUR_AprTypEmpLimit_CardNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCardNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCardNo", validateScriptCardNo)
    End If
    Dim validateScriptFK_PUR_AprTypEmpLimit_CardNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PUR_AprTypEmpLimit_CardNo(o) {" & _
      "    var value = o.id;" & _
      "    var CardNo = $get('" & F_CardNo.ClientID & "');" & _
      "    try{" & _
      "    if(CardNo.value==''){" & _
      "      if(validated_FK_PUR_AprTypEmpLimit_CardNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + CardNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PUR_AprTypEmpLimit_CardNo(value, validated_FK_PUR_AprTypEmpLimit_CardNo);" & _
      "  }" & _
      "  validated_FK_PUR_AprTypEmpLimit_CardNo_main = false;" & _
      "  function validated_FK_PUR_AprTypEmpLimit_CardNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PUR_AprTypEmpLimit_CardNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PUR_AprTypEmpLimit_CardNo", validateScriptFK_PUR_AprTypEmpLimit_CardNo)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_AprTypEmpLimit_CardNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CardNo As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(CardNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
