Partial Class AF_purItemSpecValues
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurItemSpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemSpecValues.Init
    DataClassName = "ApurItemSpecValues"
    SetFormView = FVpurItemSpecValues
  End Sub
  Protected Sub TBLpurItemSpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemSpecValues.Init
    SetToolBar = TBLpurItemSpecValues
  End Sub
  Protected Sub FVpurItemSpecValues_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemSpecValues.DataBound
    SIS.PUR.purItemSpecValues.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurItemSpecValues_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemSpecValues.PreRender
    Dim oF_SpecID_Display As Label  = FVpurItemSpecValues.FindControl("F_SpecID_Display")
    oF_SpecID_Display.Text = String.Empty
    If Not Session("F_SpecID_Display") Is Nothing Then
      If Session("F_SpecID_Display") <> String.Empty Then
        oF_SpecID_Display.Text = Session("F_SpecID_Display")
      End If
    End If
    Dim oF_SpecID As TextBox  = FVpurItemSpecValues.FindControl("F_SpecID")
    oF_SpecID.Enabled = True
    oF_SpecID.Text = String.Empty
    If Not Session("F_SpecID") Is Nothing Then
      If Session("F_SpecID") <> String.Empty Then
        oF_SpecID.Text = Session("F_SpecID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purItemSpecValues.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurItemSpecValues") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurItemSpecValues", mStr)
    End If
    If Request.QueryString("SpecID") IsNot Nothing Then
      CType(FVpurItemSpecValues.FindControl("F_SpecID"), TextBox).Text = Request.QueryString("SpecID")
      CType(FVpurItemSpecValues.FindControl("F_SpecID"), TextBox).Enabled = False
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVpurItemSpecValues.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVpurItemSpecValues.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SpecIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemSpecification.SelectpurItemSpecificationAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ItemSpecValues_SpecID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SpecID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PUR.purItemSpecification = SIS.PUR.purItemSpecification.purItemSpecificationGetByID(SpecID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
