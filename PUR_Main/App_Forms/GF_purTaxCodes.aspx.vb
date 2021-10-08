Imports System.Web.Script.Serialization
Partial Class GF_purTaxCodes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purTaxCodes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?TaxCode=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurTaxCodes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurTaxCodes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TaxCode As Int32 = GVpurTaxCodes.DataKeys(e.CommandArgument).Values("TaxCode")  
        Dim RedirectUrl As String = TBLpurTaxCodes.EditUrl & "?TaxCode=" & TaxCode
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurTaxCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurTaxCodes.Init
    DataClassName = "GpurTaxCodes"
    SetGridView = GVpurTaxCodes
  End Sub
  Protected Sub TBLpurTaxCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurTaxCodes.Init
    SetToolBar = TBLpurTaxCodes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
