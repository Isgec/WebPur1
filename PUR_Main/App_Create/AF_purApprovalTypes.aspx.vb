Partial Class AF_purApprovalTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurApprovalTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurApprovalTypes.Init
    DataClassName = "ApurApprovalTypes"
    SetFormView = FVpurApprovalTypes
  End Sub
  Protected Sub TBLpurApprovalTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurApprovalTypes.Init
    SetToolBar = TBLpurApprovalTypes
  End Sub
  Protected Sub FVpurApprovalTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurApprovalTypes.DataBound
    SIS.PUR.purApprovalTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurApprovalTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurApprovalTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purApprovalTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurApprovalTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurApprovalTypes", mStr)
    End If
    If Request.QueryString("AprTypeID") IsNot Nothing Then
      CType(FVpurApprovalTypes.FindControl("F_AprTypeID"), TextBox).Text = Request.QueryString("AprTypeID")
      CType(FVpurApprovalTypes.FindControl("F_AprTypeID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_purApprovalTypes(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim AprTypeID As String = CType(aVal(1),String)
    Dim oVar As SIS.PUR.purApprovalTypes = SIS.PUR.purApprovalTypes.purApprovalTypesGetByID(AprTypeID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
