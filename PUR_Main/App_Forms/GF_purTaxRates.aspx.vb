Imports System.Web.Script.Serialization
Partial Class GF_purTaxRates
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purTaxRates.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?TaxCode=" & aVal(0) & "&SerialNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurTaxRates_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurTaxRates.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TaxCode As Int32 = GVpurTaxRates.DataKeys(e.CommandArgument).Values("TaxCode")  
        Dim SerialNo As Int32 = GVpurTaxRates.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLpurTaxRates.EditUrl & "?TaxCode=" & TaxCode & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Revisewf".ToLower Then
      Try
        Dim TaxCode As Int32 = GVpurTaxRates.DataKeys(e.CommandArgument).Values("TaxCode")  
        Dim SerialNo As Int32 = GVpurTaxRates.DataKeys(e.CommandArgument).Values("SerialNo")  
        SIS.PUR.purTaxRates.ReviseWF(TaxCode, SerialNo)
        GVpurTaxRates.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurTaxRates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurTaxRates.Init
    DataClassName = "GpurTaxRates"
    SetGridView = GVpurTaxRates
  End Sub
  Protected Sub TBLpurTaxRates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurTaxRates.Init
    SetToolBar = TBLpurTaxRates
  End Sub
  Protected Sub F_TaxCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_TaxCode.TextChanged
    Session("F_TaxCode") = F_TaxCode.Text
    Session("F_TaxCode_Display") = F_TaxCode_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TaxCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purTaxCodes.SelectpurTaxCodesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_TaxCode_Display.Text = String.Empty
    If Not Session("F_TaxCode_Display") Is Nothing Then
      If Session("F_TaxCode_Display") <> String.Empty Then
        F_TaxCode_Display.Text = Session("F_TaxCode_Display")
      End If
    End If
    F_TaxCode.Text = String.Empty
    If Not Session("F_TaxCode") Is Nothing Then
      If Session("F_TaxCode") <> String.Empty Then
        F_TaxCode.Text = Session("F_TaxCode")
      End If
    End If
    Dim strScriptTaxCode As String = "<script type=""text/javascript""> " & _
      "function ACETaxCode_Selected(sender, e) {" & _
      "  var F_TaxCode = $get('" & F_TaxCode.ClientID & "');" & _
      "  var F_TaxCode_Display = $get('" & F_TaxCode_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_TaxCode.value = p[0];" & _
      "  F_TaxCode_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_TaxCode") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_TaxCode", strScriptTaxCode)
      End If
    Dim strScriptPopulatingTaxCode As String = "<script type=""text/javascript""> " & _
      "function ACETaxCode_Populating(o,e) {" & _
      "  var p = $get('" & F_TaxCode.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACETaxCode_Populated(o,e) {" & _
      "  var p = $get('" & F_TaxCode.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_TaxCodePopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_TaxCodePopulating", strScriptPopulatingTaxCode)
      End If
    Dim validateScriptTaxCode As String = "<script type=""text/javascript"">" & _
      "  function validate_TaxCode(o) {" & _
      "    validated_FK_PUR_TaxRates_Code_main = true;" & _
      "    validate_FK_PUR_TaxRates_Code(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateTaxCode") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateTaxCode", validateScriptTaxCode)
    End If
    Dim validateScriptFK_PUR_TaxRates_Code As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PUR_TaxRates_Code(o) {" & _
      "    var value = o.id;" & _
      "    var TaxCode = $get('" & F_TaxCode.ClientID & "');" & _
      "    try{" & _
      "    if(TaxCode.value==''){" & _
      "      if(validated_FK_PUR_TaxRates_Code.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + TaxCode.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PUR_TaxRates_Code(value, validated_FK_PUR_TaxRates_Code);" & _
      "  }" & _
      "  validated_FK_PUR_TaxRates_Code_main = false;" & _
      "  function validated_FK_PUR_TaxRates_Code(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PUR_TaxRates_Code") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PUR_TaxRates_Code", validateScriptFK_PUR_TaxRates_Code)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_TaxRates_Code(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TaxCode As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PUR.purTaxCodes = SIS.PUR.purTaxCodes.purTaxCodesGetByID(TaxCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
