Partial Class AF_purIndentStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurIndentStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurIndentStatus.Init
    DataClassName = "ApurIndentStatus"
    SetFormView = FVpurIndentStatus
  End Sub
  Protected Sub TBLpurIndentStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurIndentStatus.Init
    SetToolBar = TBLpurIndentStatus
  End Sub
  Protected Sub FVpurIndentStatus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurIndentStatus.DataBound
    SIS.PUR.purIndentStatus.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurIndentStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurIndentStatus.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purIndentStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurIndentStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurIndentStatus", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVpurIndentStatus.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVpurIndentStatus.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
