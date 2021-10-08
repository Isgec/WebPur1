Imports System.Web.Script.Serialization
Partial Class GF_purItems
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purItems.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ItemCode=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurItems_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurItems.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ItemCode As Int32 = GVpurItems.DataKeys(e.CommandArgument).Values("ItemCode")  
        Dim RedirectUrl As String = TBLpurItems.EditUrl & "?ItemCode=" & ItemCode
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurItems.Init
    DataClassName = "GpurItems"
    SetGridView = GVpurItems
  End Sub
  Protected Sub TBLpurItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItems.Init
    SetToolBar = TBLpurItems
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
