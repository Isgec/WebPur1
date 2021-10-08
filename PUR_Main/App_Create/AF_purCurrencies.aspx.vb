Partial Class AF_purCurrencies
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurCurrencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurCurrencies.Init
    DataClassName = "ApurCurrencies"
    SetFormView = FVpurCurrencies
  End Sub
  Protected Sub TBLpurCurrencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurCurrencies.Init
    SetToolBar = TBLpurCurrencies
  End Sub
  Protected Sub FVpurCurrencies_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurCurrencies.DataBound
    SIS.PUR.purCurrencies.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurCurrencies_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurCurrencies.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purCurrencies.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurCurrencies") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurCurrencies", mStr)
    End If
    If Request.QueryString("CurrencyID") IsNot Nothing Then
      CType(FVpurCurrencies.FindControl("F_CurrencyID"), TextBox).Text = Request.QueryString("CurrencyID")
      CType(FVpurCurrencies.FindControl("F_CurrencyID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_purCurrencies(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CurrencyID As String = CType(aVal(1),String)
    Dim oVar As SIS.PUR.purCurrencies = SIS.PUR.purCurrencies.purCurrenciesGetByID(CurrencyID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
