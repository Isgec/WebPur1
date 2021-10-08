Partial Class AF_purPOStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurPOStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurPOStatus.Init
    DataClassName = "ApurPOStatus"
    SetFormView = FVpurPOStatus
  End Sub
  Protected Sub TBLpurPOStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurPOStatus.Init
    SetToolBar = TBLpurPOStatus
  End Sub
  Protected Sub FVpurPOStatus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurPOStatus.DataBound
    SIS.PUR.purPOStatus.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurPOStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurPOStatus.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purPOStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurPOStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurPOStatus", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVpurPOStatus.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVpurPOStatus.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
