Partial Class AF_purTaxCodes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurTaxCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurTaxCodes.Init
    DataClassName = "ApurTaxCodes"
    SetFormView = FVpurTaxCodes
  End Sub
  Protected Sub TBLpurTaxCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurTaxCodes.Init
    SetToolBar = TBLpurTaxCodes
  End Sub
  Protected Sub ODSpurTaxCodes_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurTaxCodes.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PUR.purTaxCodes = CType(e.ReturnValue,SIS.PUR.purTaxCodes)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&TaxCode=" & oDC.TaxCode
      TBLpurTaxCodes.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVpurTaxCodes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurTaxCodes.DataBound
    SIS.PUR.purTaxCodes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurTaxCodes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurTaxCodes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purTaxCodes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurTaxCodes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurTaxCodes", mStr)
    End If
    If Request.QueryString("TaxCode") IsNot Nothing Then
      CType(FVpurTaxCodes.FindControl("F_TaxCode"), TextBox).Text = Request.QueryString("TaxCode")
      CType(FVpurTaxCodes.FindControl("F_TaxCode"), TextBox).Enabled = False
    End If
  End Sub

End Class
