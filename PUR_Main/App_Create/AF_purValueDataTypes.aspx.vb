Partial Class AF_purValueDataTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurValueDataTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurValueDataTypes.Init
    DataClassName = "ApurValueDataTypes"
    SetFormView = FVpurValueDataTypes
  End Sub
  Protected Sub TBLpurValueDataTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurValueDataTypes.Init
    SetToolBar = TBLpurValueDataTypes
  End Sub
  Protected Sub FVpurValueDataTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurValueDataTypes.DataBound
    SIS.PUR.purValueDataTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurValueDataTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurValueDataTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purValueDataTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurValueDataTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurValueDataTypes", mStr)
    End If
    If Request.QueryString("ValueDataTypeID") IsNot Nothing Then
      CType(FVpurValueDataTypes.FindControl("F_ValueDataTypeID"), TextBox).Text = Request.QueryString("ValueDataTypeID")
      CType(FVpurValueDataTypes.FindControl("F_ValueDataTypeID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_purValueDataTypes(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ValueDataTypeID As String = CType(aVal(1),String)
    Dim oVar As SIS.PUR.purValueDataTypes = SIS.PUR.purValueDataTypes.purValueDataTypesGetByID(ValueDataTypeID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
