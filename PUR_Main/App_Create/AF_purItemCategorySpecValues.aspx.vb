Partial Class AF_purItemCategorySpecValues
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurItemCategorySpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemCategorySpecValues.Init
    DataClassName = "ApurItemCategorySpecValues"
    SetFormView = FVpurItemCategorySpecValues
  End Sub
  Protected Sub TBLpurItemCategorySpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemCategorySpecValues.Init
    SetToolBar = TBLpurItemCategorySpecValues
  End Sub
  Protected Sub FVpurItemCategorySpecValues_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemCategorySpecValues.DataBound
    SIS.PUR.purItemCategorySpecValues.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurItemCategorySpecValues_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemCategorySpecValues.PreRender
    Dim oF_ItemCategoryID_Display As Label  = FVpurItemCategorySpecValues.FindControl("F_ItemCategoryID_Display")
    oF_ItemCategoryID_Display.Text = String.Empty
    If Not Session("F_ItemCategoryID_Display") Is Nothing Then
      If Session("F_ItemCategoryID_Display") <> String.Empty Then
        oF_ItemCategoryID_Display.Text = Session("F_ItemCategoryID_Display")
      End If
    End If
    Dim oF_ItemCategoryID As TextBox  = FVpurItemCategorySpecValues.FindControl("F_ItemCategoryID")
    oF_ItemCategoryID.Enabled = True
    oF_ItemCategoryID.Text = String.Empty
    If Not Session("F_ItemCategoryID") Is Nothing Then
      If Session("F_ItemCategoryID") <> String.Empty Then
        oF_ItemCategoryID.Text = Session("F_ItemCategoryID")
      End If
    End If
    Dim oF_CategorySpecID_Display As Label  = FVpurItemCategorySpecValues.FindControl("F_CategorySpecID_Display")
    oF_CategorySpecID_Display.Text = String.Empty
    If Not Session("F_CategorySpecID_Display") Is Nothing Then
      If Session("F_CategorySpecID_Display") <> String.Empty Then
        oF_CategorySpecID_Display.Text = Session("F_CategorySpecID_Display")
      End If
    End If
    Dim oF_CategorySpecID As TextBox  = FVpurItemCategorySpecValues.FindControl("F_CategorySpecID")
    oF_CategorySpecID.Enabled = True
    oF_CategorySpecID.Text = String.Empty
    If Not Session("F_CategorySpecID") Is Nothing Then
      If Session("F_CategorySpecID") <> String.Empty Then
        oF_CategorySpecID.Text = Session("F_CategorySpecID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purItemCategorySpecValues.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurItemCategorySpecValues") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurItemCategorySpecValues", mStr)
    End If
    If Request.QueryString("ItemCategoryID") IsNot Nothing Then
      CType(FVpurItemCategorySpecValues.FindControl("F_ItemCategoryID"), TextBox).Text = Request.QueryString("ItemCategoryID")
      CType(FVpurItemCategorySpecValues.FindControl("F_ItemCategoryID"), TextBox).Enabled = False
    End If
    If Request.QueryString("CategorySpecID") IsNot Nothing Then
      CType(FVpurItemCategorySpecValues.FindControl("F_CategorySpecID"), TextBox).Text = Request.QueryString("CategorySpecID")
      CType(FVpurItemCategorySpecValues.FindControl("F_CategorySpecID"), TextBox).Enabled = False
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVpurItemCategorySpecValues.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVpurItemCategorySpecValues.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
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
