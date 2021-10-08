Imports System.Web.Script.Serialization
Partial Class GF_purItemSpecification
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purItemSpecification.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SpecID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurItemSpecification_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurItemSpecification.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SpecID As Int32 = GVpurItemSpecification.DataKeys(e.CommandArgument).Values("SpecID")  
        Dim RedirectUrl As String = TBLpurItemSpecification.EditUrl & "?SpecID=" & SpecID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurItemSpecification_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurItemSpecification.Init
    DataClassName = "GpurItemSpecification"
    SetGridView = GVpurItemSpecification
  End Sub
  Protected Sub TBLpurItemSpecification_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemSpecification.Init
    SetToolBar = TBLpurItemSpecification
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
