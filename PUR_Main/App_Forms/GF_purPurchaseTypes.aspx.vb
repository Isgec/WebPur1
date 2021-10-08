Imports System.Web.Script.Serialization
Partial Class GF_purPurchaseTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purPurchaseTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?PurchaseTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurPurchaseTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurPurchaseTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim PurchaseTypeID As String = GVpurPurchaseTypes.DataKeys(e.CommandArgument).Values("PurchaseTypeID")  
        Dim RedirectUrl As String = TBLpurPurchaseTypes.EditUrl & "?PurchaseTypeID=" & PurchaseTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurPurchaseTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurPurchaseTypes.Init
    DataClassName = "GpurPurchaseTypes"
    SetGridView = GVpurPurchaseTypes
  End Sub
  Protected Sub TBLpurPurchaseTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurPurchaseTypes.Init
    SetToolBar = TBLpurPurchaseTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
