Imports System.Web.Script.Serialization
Partial Class GF_purHOrders
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purHOrders.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?OrderNo=" & aVal(0) & "&OrderRev=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurHOrders_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurHOrders.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim OrderNo As Int32 = GVpurHOrders.DataKeys(e.CommandArgument).Values("OrderNo")  
        Dim OrderRev As Int32 = GVpurHOrders.DataKeys(e.CommandArgument).Values("OrderRev")  
        Dim RedirectUrl As String = TBLpurHOrders.EditUrl & "?OrderNo=" & OrderNo & "&OrderRev=" & OrderRev
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurHOrders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurHOrders.Init
    DataClassName = "GpurHOrders"
    SetGridView = GVpurHOrders
  End Sub
  Protected Sub TBLpurHOrders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurHOrders.Init
    SetToolBar = TBLpurHOrders
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
