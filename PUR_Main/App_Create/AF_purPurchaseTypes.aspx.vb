Partial Class AF_purPurchaseTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurPurchaseTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurPurchaseTypes.Init
    DataClassName = "ApurPurchaseTypes"
    SetFormView = FVpurPurchaseTypes
  End Sub
  Protected Sub TBLpurPurchaseTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurPurchaseTypes.Init
    SetToolBar = TBLpurPurchaseTypes
  End Sub
  Protected Sub FVpurPurchaseTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurPurchaseTypes.DataBound
    SIS.PUR.purPurchaseTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurPurchaseTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurPurchaseTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purPurchaseTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurPurchaseTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurPurchaseTypes", mStr)
    End If
    If Request.QueryString("PurchaseTypeID") IsNot Nothing Then
      CType(FVpurPurchaseTypes.FindControl("F_PurchaseTypeID"), TextBox).Text = Request.QueryString("PurchaseTypeID")
      CType(FVpurPurchaseTypes.FindControl("F_PurchaseTypeID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_purPurchaseTypes(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim PurchaseTypeID As String = CType(aVal(1),String)
    Dim oVar As SIS.PUR.purPurchaseTypes = SIS.PUR.purPurchaseTypes.purPurchaseTypesGetByID(PurchaseTypeID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
