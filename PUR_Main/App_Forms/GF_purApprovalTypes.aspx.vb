Imports System.Web.Script.Serialization
Partial Class GF_purApprovalTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purApprovalTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?AprTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurApprovalTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurApprovalTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim AprTypeID As String = GVpurApprovalTypes.DataKeys(e.CommandArgument).Values("AprTypeID")  
        Dim RedirectUrl As String = TBLpurApprovalTypes.EditUrl & "?AprTypeID=" & AprTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurApprovalTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurApprovalTypes.Init
    DataClassName = "GpurApprovalTypes"
    SetGridView = GVpurApprovalTypes
  End Sub
  Protected Sub TBLpurApprovalTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurApprovalTypes.Init
    SetToolBar = TBLpurApprovalTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
