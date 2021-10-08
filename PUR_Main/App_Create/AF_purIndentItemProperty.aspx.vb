Partial Class AF_purIndentItemProperty
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurIndentItemProperty_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurIndentItemProperty.Init
    DataClassName = "ApurIndentItemProperty"
    SetFormView = FVpurIndentItemProperty
  End Sub
  Protected Sub TBLpurIndentItemProperty_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurIndentItemProperty.Init
    SetToolBar = TBLpurIndentItemProperty
  End Sub
  Protected Sub FVpurIndentItemProperty_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurIndentItemProperty.DataBound
    SIS.PUR.purIndentItemProperty.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurIndentItemProperty_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurIndentItemProperty.PreRender
    Dim oF_IndentNo_Display As Label  = FVpurIndentItemProperty.FindControl("F_IndentNo_Display")
    oF_IndentNo_Display.Text = String.Empty
    If Not Session("F_IndentNo_Display") Is Nothing Then
      If Session("F_IndentNo_Display") <> String.Empty Then
        oF_IndentNo_Display.Text = Session("F_IndentNo_Display")
      End If
    End If
    Dim oF_IndentNo As TextBox  = FVpurIndentItemProperty.FindControl("F_IndentNo")
    oF_IndentNo.Enabled = True
    oF_IndentNo.Text = String.Empty
    If Not Session("F_IndentNo") Is Nothing Then
      If Session("F_IndentNo") <> String.Empty Then
        oF_IndentNo.Text = Session("F_IndentNo")
      End If
    End If
    Dim oF_IndentLine_Display As Label  = FVpurIndentItemProperty.FindControl("F_IndentLine_Display")
    oF_IndentLine_Display.Text = String.Empty
    If Not Session("F_IndentLine_Display") Is Nothing Then
      If Session("F_IndentLine_Display") <> String.Empty Then
        oF_IndentLine_Display.Text = Session("F_IndentLine_Display")
      End If
    End If
    Dim oF_IndentLine As TextBox  = FVpurIndentItemProperty.FindControl("F_IndentLine")
    oF_IndentLine.Enabled = True
    oF_IndentLine.Text = String.Empty
    If Not Session("F_IndentLine") Is Nothing Then
      If Session("F_IndentLine") <> String.Empty Then
        oF_IndentLine.Text = Session("F_IndentLine")
      End If
    End If
    Dim oF_ItemCode_Display As Label  = FVpurIndentItemProperty.FindControl("F_ItemCode_Display")
    Dim oF_ItemCode As TextBox  = FVpurIndentItemProperty.FindControl("F_ItemCode")
    Dim oF_ItemCategoryID_Display As Label  = FVpurIndentItemProperty.FindControl("F_ItemCategoryID_Display")
    Dim oF_ItemCategoryID As TextBox  = FVpurIndentItemProperty.FindControl("F_ItemCategoryID")
    Dim oF_CategorySpecID_Display As Label  = FVpurIndentItemProperty.FindControl("F_CategorySpecID_Display")
    Dim oF_CategorySpecID As TextBox  = FVpurIndentItemProperty.FindControl("F_CategorySpecID")
    Dim oF_SerialNo_Display As Label  = FVpurIndentItemProperty.FindControl("F_SerialNo_Display")
    Dim oF_SerialNo As TextBox  = FVpurIndentItemProperty.FindControl("F_SerialNo")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purIndentItemProperty.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurIndentItemProperty") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurIndentItemProperty", mStr)
    End If
    If Request.QueryString("IndentNo") IsNot Nothing Then
      CType(FVpurIndentItemProperty.FindControl("F_IndentNo"), TextBox).Text = Request.QueryString("IndentNo")
      CType(FVpurIndentItemProperty.FindControl("F_IndentNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("IndentLine") IsNot Nothing Then
      CType(FVpurIndentItemProperty.FindControl("F_IndentLine"), TextBox).Text = Request.QueryString("IndentLine")
      CType(FVpurIndentItemProperty.FindControl("F_IndentLine"), TextBox).Enabled = False
    End If
    If Request.QueryString("ItemCode") IsNot Nothing Then
      CType(FVpurIndentItemProperty.FindControl("F_ItemCode"), TextBox).Text = Request.QueryString("ItemCode")
      CType(FVpurIndentItemProperty.FindControl("F_ItemCode"), TextBox).Enabled = False
    End If
    If Request.QueryString("ItemCategoryID") IsNot Nothing Then
      CType(FVpurIndentItemProperty.FindControl("F_ItemCategoryID"), TextBox).Text = Request.QueryString("ItemCategoryID")
      CType(FVpurIndentItemProperty.FindControl("F_ItemCategoryID"), TextBox).Enabled = False
    End If
    If Request.QueryString("CategorySpecID") IsNot Nothing Then
      CType(FVpurIndentItemProperty.FindControl("F_CategorySpecID"), TextBox).Text = Request.QueryString("CategorySpecID")
      CType(FVpurIndentItemProperty.FindControl("F_CategorySpecID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function IndentNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purIndents.SelectpurIndentsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function IndentLineCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purIndentDetails.SelectpurIndentDetailsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ItemCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItems.SelectpurItemsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ItemCategoryIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategories.SelectpurItemCategoriesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CategorySpecIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategorySpecs.SelectpurItemCategorySpecsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategorySpecValues.SelectpurItemCategorySpecValuesAutoCompleteList(prefixText, count, contextKey)
  End Function
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
  Public Shared Function validate_FK_PUR_IndentItemProperty_ItemCategoryID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_IndentItemProperty_CategorySpecID(ByVal value As String) As String
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
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_IndentItemProperty_ItemCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ItemCode As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PUR.purItems = SIS.PUR.purItems.purItemsGetByID(ItemCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
