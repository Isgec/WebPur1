Imports System.Web.Script.Serialization
Partial Class GF_purCurrencies
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purCurrencies.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CurrencyID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurCurrencies_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurCurrencies.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CurrencyID As String = GVpurCurrencies.DataKeys(e.CommandArgument).Values("CurrencyID")  
        Dim RedirectUrl As String = TBLpurCurrencies.EditUrl & "?CurrencyID=" & CurrencyID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurCurrencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurCurrencies.Init
    DataClassName = "GpurCurrencies"
    SetGridView = GVpurCurrencies
  End Sub
  Protected Sub TBLpurCurrencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurCurrencies.Init
    SetToolBar = TBLpurCurrencies
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
