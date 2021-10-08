Partial Class AF_purTaxRates
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurTaxRates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurTaxRates.Init
    DataClassName = "ApurTaxRates"
    SetFormView = FVpurTaxRates
  End Sub
  Protected Sub TBLpurTaxRates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurTaxRates.Init
    SetToolBar = TBLpurTaxRates
  End Sub
  Protected Sub FVpurTaxRates_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurTaxRates.DataBound
    SIS.PUR.purTaxRates.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurTaxRates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurTaxRates.PreRender
    Dim oF_TaxCode_Display As Label  = FVpurTaxRates.FindControl("F_TaxCode_Display")
    oF_TaxCode_Display.Text = String.Empty
    If Not Session("F_TaxCode_Display") Is Nothing Then
      If Session("F_TaxCode_Display") <> String.Empty Then
        oF_TaxCode_Display.Text = Session("F_TaxCode_Display")
      End If
    End If
    Dim oF_TaxCode As TextBox  = FVpurTaxRates.FindControl("F_TaxCode")
    oF_TaxCode.Enabled = True
    oF_TaxCode.Text = String.Empty
    If Not Session("F_TaxCode") Is Nothing Then
      If Session("F_TaxCode") <> String.Empty Then
        oF_TaxCode.Text = Session("F_TaxCode")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purTaxRates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurTaxRates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurTaxRates", mStr)
    End If
    If Request.QueryString("TaxCode") IsNot Nothing Then
      CType(FVpurTaxRates.FindControl("F_TaxCode"), TextBox).Text = Request.QueryString("TaxCode")
      CType(FVpurTaxRates.FindControl("F_TaxCode"), TextBox).Enabled = False
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVpurTaxRates.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVpurTaxRates.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TaxCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purTaxCodes.SelectpurTaxCodesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_TaxRates_Code(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TaxCode As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PUR.purTaxCodes = SIS.PUR.purTaxCodes.purTaxCodesGetByID(TaxCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
