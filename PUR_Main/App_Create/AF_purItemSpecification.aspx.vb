Partial Class AF_purItemSpecification
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurItemSpecification_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemSpecification.Init
    DataClassName = "ApurItemSpecification"
    SetFormView = FVpurItemSpecification
  End Sub
  Protected Sub TBLpurItemSpecification_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemSpecification.Init
    SetToolBar = TBLpurItemSpecification
  End Sub
  Protected Sub ODSpurItemSpecification_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurItemSpecification.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PUR.purItemSpecification = CType(e.ReturnValue,SIS.PUR.purItemSpecification)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&SpecID=" & oDC.SpecID
      TBLpurItemSpecification.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVpurItemSpecification_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemSpecification.DataBound
    SIS.PUR.purItemSpecification.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurItemSpecification_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemSpecification.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purItemSpecification.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurItemSpecification") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurItemSpecification", mStr)
    End If
    If Request.QueryString("SpecID") IsNot Nothing Then
      CType(FVpurItemSpecification.FindControl("F_SpecID"), TextBox).Text = Request.QueryString("SpecID")
      CType(FVpurItemSpecification.FindControl("F_SpecID"), TextBox).Enabled = False
    End If
  End Sub

End Class
