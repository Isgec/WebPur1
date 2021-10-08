Imports System.Web.Script.Serialization
Partial Class GF_purIndentStatus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purIndentStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurIndentStatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurIndentStatus.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim StatusID As Int32 = GVpurIndentStatus.DataKeys(e.CommandArgument).Values("StatusID")  
        Dim RedirectUrl As String = TBLpurIndentStatus.EditUrl & "?StatusID=" & StatusID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurIndentStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurIndentStatus.Init
    DataClassName = "GpurIndentStatus"
    SetGridView = GVpurIndentStatus
  End Sub
  Protected Sub TBLpurIndentStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurIndentStatus.Init
    SetToolBar = TBLpurIndentStatus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
