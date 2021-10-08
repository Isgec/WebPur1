Imports System.Web.Script.Serialization
Partial Class GF_purItemCategories
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purItemCategories.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ItemCategoryID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurItemCategories_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurItemCategories.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ItemCategoryID As Int32 = GVpurItemCategories.DataKeys(e.CommandArgument).Values("ItemCategoryID")  
        Dim RedirectUrl As String = TBLpurItemCategories.EditUrl & "?ItemCategoryID=" & ItemCategoryID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurItemCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurItemCategories.Init
    DataClassName = "GpurItemCategories"
    SetGridView = GVpurItemCategories
  End Sub
  Protected Sub TBLpurItemCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemCategories.Init
    SetToolBar = TBLpurItemCategories
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
