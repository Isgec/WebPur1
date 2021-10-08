Imports System.Web.Script.Serialization
Partial Class GF_purPendingIndents
  Inherits SIS.SYS.GridBase
  Protected Sub GVpurPendingIndents_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurPendingIndents.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim IndentNo As Int32 = GVpurPendingIndents.DataKeys(e.CommandArgument).Values("IndentNo")
        Dim IndentLine As Int32 = GVpurPendingIndents.DataKeys(e.CommandArgument).Values("IndentLine")
        Dim RedirectUrl As String = TBLpurPendingIndents.EditUrl & "?IndentNo=" & IndentNo & "&IndentLine=" & IndentLine
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Selectwf".ToLower Then
      Try
        Dim OriginalQuantity As Decimal = CType(GVpurPendingIndents.Rows(e.CommandArgument).FindControl("F_OriginalQuantity"), TextBox).Text
        Dim IndentNo As Int32 = GVpurPendingIndents.DataKeys(e.CommandArgument).Values("IndentNo")
        Dim IndentLine As Int32 = GVpurPendingIndents.DataKeys(e.CommandArgument).Values("IndentLine")
        SIS.PUR.purPendingIndents.SelectWF(IndentNo, IndentLine, OriginalQuantity)
        GVpurPendingIndents.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurPendingIndents_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurPendingIndents.Init
    DataClassName = "GpurPendingIndents"
    SetGridView = GVpurPendingIndents
  End Sub
  Protected Sub TBLpurPendingIndents_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurPendingIndents.Init
    SetToolBar = TBLpurPendingIndents
  End Sub
  Protected Sub F_IndentNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_IndentNo.TextChanged
    Session("F_IndentNo") = F_IndentNo.Text
    Session("F_IndentNo_Display") = F_IndentNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function IndentNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purIndents.SelectpurIndentsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_IndentNo_Display.Text = String.Empty
    If Not Session("F_IndentNo_Display") Is Nothing Then
      If Session("F_IndentNo_Display") <> String.Empty Then
        F_IndentNo_Display.Text = Session("F_IndentNo_Display")
      End If
    End If
    F_IndentNo.Text = String.Empty
    If Not Session("F_IndentNo") Is Nothing Then
      If Session("F_IndentNo") <> String.Empty Then
        F_IndentNo.Text = Session("F_IndentNo")
      End If
    End If
    Dim strScriptIndentNo As String = "<script type=""text/javascript""> " &
      "function ACEIndentNo_Selected(sender, e) {" &
      "  var F_IndentNo = $get('" & F_IndentNo.ClientID & "');" &
      "  var F_IndentNo_Display = $get('" & F_IndentNo_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_IndentNo.value = p[0];" &
      "  F_IndentNo_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_IndentNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_IndentNo", strScriptIndentNo)
    End If
    Dim strScriptPopulatingIndentNo As String = "<script type=""text/javascript""> " &
      "function ACEIndentNo_Populating(o,e) {" &
      "  var p = $get('" & F_IndentNo.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEIndentNo_Populated(o,e) {" &
      "  var p = $get('" & F_IndentNo.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_IndentNoPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_IndentNoPopulating", strScriptPopulatingIndentNo)
    End If
    Dim validateScriptIndentNo As String = "<script type=""text/javascript"">" &
      "  function validate_IndentNo(o) {" &
      "    validated_FK_PUR_IndentDetails_IndentNo_main = true;" &
      "    validate_FK_PUR_IndentDetails_IndentNo(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateIndentNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateIndentNo", validateScriptIndentNo)
    End If
    Dim validateScriptFK_PUR_IndentDetails_IndentNo As String = "<script type=""text/javascript"">" &
      "  function validate_FK_PUR_IndentDetails_IndentNo(o) {" &
      "    var value = o.id;" &
      "    var IndentNo = $get('" & F_IndentNo.ClientID & "');" &
      "    try{" &
      "    if(IndentNo.value==''){" &
      "      if(validated_FK_PUR_IndentDetails_IndentNo.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + IndentNo.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_PUR_IndentDetails_IndentNo(value, validated_FK_PUR_IndentDetails_IndentNo);" &
      "  }" &
      "  validated_FK_PUR_IndentDetails_IndentNo_main = false;" &
      "  function validated_FK_PUR_IndentDetails_IndentNo(result) {" &
      "    var p = result.split('|');" &
      "    var o = $get(p[1]);" &
      "    var o_d = $get(p[1]+'_Display');" &
      "    try{o_d.innerHTML = p[2];}catch(ex){}" &
      "    o.style.backgroundImage  = 'none';" &
      "    if(p[0]=='1'){" &
      "      o.value='';" &
      "      try{o_d.innerHTML = '';}catch(ex){}" &
      "      __doPostBack(o.id, o.value);" &
      "    }" &
      "    else" &
      "      __doPostBack(o.id, o.value);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PUR_IndentDetails_IndentNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PUR_IndentDetails_IndentNo", validateScriptFK_PUR_IndentDetails_IndentNo)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PUR_IndentDetails_IndentNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim IndentNo As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.PUR.purIndents = SIS.PUR.purIndents.purIndentsGetByID(IndentNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  Private Sub cmdAction_Click(sender As Object, e As EventArgs) Handles cmdAction.Click
    Dim OrderNo As String = F_OrderNo.Text
    For Each r As GridViewRow In GVpurPendingIndents.Rows
      If r.RowType = DataControlRowType.DataRow Then
        Dim chk As CheckBox = r.FindControl("chkSelect")
        If chk.Checked Then
          Dim IndentNo As String = GVpurPendingIndents.DataKeys(r.RowIndex).Values("IndentNo")
          Dim IndentLine As String = GVpurPendingIndents.DataKeys(r.RowIndex).Values("IndentLine")
          Dim OriginalQuantity As Decimal = CType(GVpurPendingIndents.Rows(r.RowIndex).FindControl("F_OriginalQuantity"), TextBox).Text
          SIS.PUR.purIndentDetails.IndentLineToOrderLine(IndentNo, IndentLine, OriginalQuantity, OrderNo, 0)
        End If
      End If
    Next
    'If stay Here
    'GVpurPendingIndents.DataBind()
    'Redirect To Edit Order
    Response.Redirect("~/PUR_Main/App_Edit/EF_purOrders.aspx?OrderNo=" & OrderNo)
  End Sub

End Class
