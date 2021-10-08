Partial Class AF_purItems
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItems.Init
    DataClassName = "ApurItems"
    SetFormView = FVpurItems
  End Sub
  Protected Sub TBLpurItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItems.Init
    SetToolBar = TBLpurItems
  End Sub
  Protected Sub FVpurItems_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItems.DataBound
    SIS.PUR.purItems.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurItems_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItems.PreRender
    Dim oF_ItemCategoryID_Display As Label  = FVpurItems.FindControl("F_ItemCategoryID_Display")
    Dim oF_ItemCategoryID As TextBox  = FVpurItems.FindControl("F_ItemCategoryID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purItems.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurItems") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurItems", mStr)
    End If
    If Request.QueryString("ItemCode") IsNot Nothing Then
      CType(FVpurItems.FindControl("F_ItemCode"), TextBox).Text = Request.QueryString("ItemCode")
      CType(FVpurItems.FindControl("F_ItemCode"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ItemCategoryIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategories.SelectpurItemCategoriesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_Items_ItemCategoryID(ByVal value As String) As String
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

End Class
