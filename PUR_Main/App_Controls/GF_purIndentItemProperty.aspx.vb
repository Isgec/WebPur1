Imports System.Web.Script.Serialization
Partial Class GF_purIndentItemProperty
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purIndentItemProperty.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?IndentNo=" & aVal(0) & "&IndentLine=" & aVal(1) & "&ItemCode=" & aVal(2) & "&ItemCategoryID=" & aVal(3) & "&CategorySpecID=" & aVal(4)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurIndentItemProperty_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurIndentItemProperty.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim IndentNo As Int32 = GVpurIndentItemProperty.DataKeys(e.CommandArgument).Values("IndentNo")  
        Dim IndentLine As Int32 = GVpurIndentItemProperty.DataKeys(e.CommandArgument).Values("IndentLine")  
        Dim ItemCode As Int32 = GVpurIndentItemProperty.DataKeys(e.CommandArgument).Values("ItemCode")  
        Dim ItemCategoryID As Int32 = GVpurIndentItemProperty.DataKeys(e.CommandArgument).Values("ItemCategoryID")  
        Dim CategorySpecID As Int32 = GVpurIndentItemProperty.DataKeys(e.CommandArgument).Values("CategorySpecID")  
        Dim RedirectUrl As String = TBLpurIndentItemProperty.EditUrl & "?IndentNo=" & IndentNo & "&IndentLine=" & IndentLine & "&ItemCode=" & ItemCode & "&ItemCategoryID=" & ItemCategoryID & "&CategorySpecID=" & CategorySpecID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim SerialNo As Int32 = CType(GVpurIndentItemProperty.Rows(e.CommandArgument).FindControl("F_SerialNo"),TextBox).Text
        Dim ValueDataTypeID As String = CType(GVpurIndentItemProperty.Rows(e.CommandArgument).FindControl("LC_ValueDataTypeID"),LC_purValueDataTypes).SelectedValue
        Dim IsRange As Boolean = CType(GVpurIndentItemProperty.Rows(e.CommandArgument).FindControl("F_IsRange"),TextBox).Text
        Dim Data1Value As String = CType(GVpurIndentItemProperty.Rows(e.CommandArgument).FindControl("F_Data1Value"),TextBox).Text
        Dim Data2Value As String = CType(GVpurIndentItemProperty.Rows(e.CommandArgument).FindControl("F_Data2Value"),TextBox).Text
        Dim IndentNo As Int32 = GVpurIndentItemProperty.DataKeys(e.CommandArgument).Values("IndentNo")  
        Dim IndentLine As Int32 = GVpurIndentItemProperty.DataKeys(e.CommandArgument).Values("IndentLine")  
        Dim ItemCode As Int32 = GVpurIndentItemProperty.DataKeys(e.CommandArgument).Values("ItemCode")  
        Dim ItemCategoryID As Int32 = GVpurIndentItemProperty.DataKeys(e.CommandArgument).Values("ItemCategoryID")  
        Dim CategorySpecID As Int32 = GVpurIndentItemProperty.DataKeys(e.CommandArgument).Values("CategorySpecID")  
        SIS.PUR.purIndentItemProperty.DeleteWF(IndentNo, IndentLine, ItemCode, ItemCategoryID, CategorySpecID, SerialNo, ValueDataTypeID, IsRange, Data1Value, Data2Value)
        GVpurIndentItemProperty.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurIndentItemProperty_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurIndentItemProperty.Init
    DataClassName = "GpurIndentItemProperty"
    SetGridView = GVpurIndentItemProperty
  End Sub
  Protected Sub TBLpurIndentItemProperty_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurIndentItemProperty.Init
    SetToolBar = TBLpurIndentItemProperty
  End Sub
  Protected Sub F_IndentLine_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_IndentLine.TextChanged
    Session("F_IndentLine") = F_IndentLine.Text
    Session("F_IndentLine_Display") = F_IndentLine_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function IndentLineCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purIndentDetails.SelectpurIndentDetailsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_IndentNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_IndentNo.TextChanged
    Session("F_IndentNo") = F_IndentNo.Text
    Session("F_IndentNo_Display") = F_IndentNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function IndentNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purIndents.SelectpurIndentsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_IndentLine_Display.Text = String.Empty
    If Not Session("F_IndentLine_Display") Is Nothing Then
      If Session("F_IndentLine_Display") <> String.Empty Then
        F_IndentLine_Display.Text = Session("F_IndentLine_Display")
      End If
    End If
    F_IndentLine.Text = String.Empty
    If Not Session("F_IndentLine") Is Nothing Then
      If Session("F_IndentLine") <> String.Empty Then
        F_IndentLine.Text = Session("F_IndentLine")
      End If
    End If
    Dim strScriptIndentLine As String = "<script type=""text/javascript""> " & _
      "function ACEIndentLine_Selected(sender, e) {" & _
      "  var F_IndentLine = $get('" & F_IndentLine.ClientID & "');" & _
      "  var F_IndentLine_Display = $get('" & F_IndentLine_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_IndentLine.value = p[1];" & _
      "  F_IndentLine_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_IndentLine") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_IndentLine", strScriptIndentLine)
      End If
    Dim strScriptPopulatingIndentLine As String = "<script type=""text/javascript""> " & _
      "function ACEIndentLine_Populating(o,e) {" & _
      "  var p = $get('" & F_IndentLine.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEIndentLine_Populated(o,e) {" & _
      "  var p = $get('" & F_IndentLine.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_IndentLinePopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_IndentLinePopulating", strScriptPopulatingIndentLine)
      End If
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
    Dim strScriptIndentNo As String = "<script type=""text/javascript""> " & _
      "function ACEIndentNo_Selected(sender, e) {" & _
      "  var F_IndentNo = $get('" & F_IndentNo.ClientID & "');" & _
      "  var F_IndentNo_Display = $get('" & F_IndentNo_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_IndentNo.value = p[0];" & _
      "  F_IndentNo_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_IndentNo") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_IndentNo", strScriptIndentNo)
      End If
    Dim strScriptPopulatingIndentNo As String = "<script type=""text/javascript""> " & _
      "function ACEIndentNo_Populating(o,e) {" & _
      "  var p = $get('" & F_IndentNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEIndentNo_Populated(o,e) {" & _
      "  var p = $get('" & F_IndentNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_IndentNoPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_IndentNoPopulating", strScriptPopulatingIndentNo)
      End If
    Dim validateScriptIndentLine As String = "<script type=""text/javascript"">" & _
      "  function validate_IndentLine(o) {" & _
      "    validated_FK_PUR_IndentItemProperty_IndentLine_main = true;" & _
      "    validate_FK_PUR_IndentItemProperty_IndentLine(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateIndentLine") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateIndentLine", validateScriptIndentLine)
    End If
    Dim validateScriptIndentNo As String = "<script type=""text/javascript"">" & _
      "  function validate_IndentNo(o) {" & _
      "    validated_FK_PUR_IndentItemProperty_IndentNo_main = true;" & _
      "    validate_FK_PUR_IndentItemProperty_IndentNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateIndentNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateIndentNo", validateScriptIndentNo)
    End If
    Dim validateScriptFK_PUR_IndentItemProperty_IndentLine As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PUR_IndentItemProperty_IndentLine(o) {" & _
      "    var value = o.id;" & _
      "    var IndentNo = $get('" & F_IndentNo.ClientID & "');" & _
      "    try{" & _
      "    if(IndentNo.value==''){" & _
      "      if(validated_FK_PUR_IndentItemProperty_IndentLine.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + IndentNo.value ;" & _
      "    }catch(ex){}" & _
      "    var IndentLine = $get('" & F_IndentLine.ClientID & "');" & _
      "    try{" & _
      "    if(IndentLine.value==''){" & _
      "      if(validated_FK_PUR_IndentItemProperty_IndentLine.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + IndentLine.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PUR_IndentItemProperty_IndentLine(value, validated_FK_PUR_IndentItemProperty_IndentLine);" & _
      "  }" & _
      "  validated_FK_PUR_IndentItemProperty_IndentLine_main = false;" & _
      "  function validated_FK_PUR_IndentItemProperty_IndentLine(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PUR_IndentItemProperty_IndentLine") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PUR_IndentItemProperty_IndentLine", validateScriptFK_PUR_IndentItemProperty_IndentLine)
    End If
    Dim validateScriptFK_PUR_IndentItemProperty_IndentNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PUR_IndentItemProperty_IndentNo(o) {" & _
      "    var value = o.id;" & _
      "    var IndentNo = $get('" & F_IndentNo.ClientID & "');" & _
      "    try{" & _
      "    if(IndentNo.value==''){" & _
      "      if(validated_FK_PUR_IndentItemProperty_IndentNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + IndentNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PUR_IndentItemProperty_IndentNo(value, validated_FK_PUR_IndentItemProperty_IndentNo);" & _
      "  }" & _
      "  validated_FK_PUR_IndentItemProperty_IndentNo_main = false;" & _
      "  function validated_FK_PUR_IndentItemProperty_IndentNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PUR_IndentItemProperty_IndentNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PUR_IndentItemProperty_IndentNo", validateScriptFK_PUR_IndentItemProperty_IndentNo)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_IndentItemProperty_IndentLine(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim IndentNo As Int32 = CType(aVal(1),Int32)
    Dim IndentLine As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PUR.purIndentDetails = SIS.PUR.purIndentDetails.purIndentDetailsGetByID(IndentNo,IndentLine)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_IndentItemProperty_IndentNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim IndentNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PUR.purIndents = SIS.PUR.purIndents.purIndentsGetByID(IndentNo)
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
  Public Shared Function validate_FK_PUR_IndentItemProperty_SerialNo(ByVal value As String) As String
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
