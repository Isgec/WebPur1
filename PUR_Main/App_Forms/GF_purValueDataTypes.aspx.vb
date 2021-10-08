Imports System.Web.Script.Serialization
Partial Class GF_purValueDataTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PUR_Main/App_Display/DF_purValueDataTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ValueDataTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpurValueDataTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurValueDataTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ValueDataTypeID As String = GVpurValueDataTypes.DataKeys(e.CommandArgument).Values("ValueDataTypeID")  
        Dim RedirectUrl As String = TBLpurValueDataTypes.EditUrl & "?ValueDataTypeID=" & ValueDataTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpurValueDataTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurValueDataTypes.Init
    DataClassName = "GpurValueDataTypes"
    SetGridView = GVpurValueDataTypes
  End Sub
  Protected Sub TBLpurValueDataTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurValueDataTypes.Init
    SetToolBar = TBLpurValueDataTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
