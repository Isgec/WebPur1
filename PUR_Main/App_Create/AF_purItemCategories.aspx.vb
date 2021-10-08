Partial Class AF_purItemCategories
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurItemCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemCategories.Init
    DataClassName = "ApurItemCategories"
    SetFormView = FVpurItemCategories
  End Sub
  Protected Sub TBLpurItemCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemCategories.Init
    SetToolBar = TBLpurItemCategories
  End Sub
  Protected Sub ODSpurItemCategories_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurItemCategories.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PUR.purItemCategories = CType(e.ReturnValue,SIS.PUR.purItemCategories)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&ItemCategoryID=" & oDC.ItemCategoryID
      TBLpurItemCategories.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVpurItemCategories_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemCategories.DataBound
    SIS.PUR.purItemCategories.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurItemCategories_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemCategories.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purItemCategories.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurItemCategories") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurItemCategories", mStr)
    End If
    If Request.QueryString("ItemCategoryID") IsNot Nothing Then
      CType(FVpurItemCategories.FindControl("F_ItemCategoryID"), TextBox).Text = Request.QueryString("ItemCategoryID")
      CType(FVpurItemCategories.FindControl("F_ItemCategoryID"), TextBox).Enabled = False
    End If
  End Sub

End Class
