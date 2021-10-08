Partial Class AF_purAprTypEmpLimit
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurAprTypEmpLimit_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurAprTypEmpLimit.Init
    DataClassName = "ApurAprTypEmpLimit"
    SetFormView = FVpurAprTypEmpLimit
  End Sub
  Protected Sub TBLpurAprTypEmpLimit_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurAprTypEmpLimit.Init
    SetToolBar = TBLpurAprTypEmpLimit
  End Sub
  Protected Sub FVpurAprTypEmpLimit_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurAprTypEmpLimit.DataBound
    SIS.PUR.purAprTypEmpLimit.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurAprTypEmpLimit_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurAprTypEmpLimit.PreRender
    Dim oF_CardNo_Display As Label  = FVpurAprTypEmpLimit.FindControl("F_CardNo_Display")
    oF_CardNo_Display.Text = String.Empty
    If Not Session("F_CardNo_Display") Is Nothing Then
      If Session("F_CardNo_Display") <> String.Empty Then
        oF_CardNo_Display.Text = Session("F_CardNo_Display")
      End If
    End If
    Dim oF_CardNo As TextBox  = FVpurAprTypEmpLimit.FindControl("F_CardNo")
    oF_CardNo.Enabled = True
    oF_CardNo.Text = String.Empty
    If Not Session("F_CardNo") Is Nothing Then
      If Session("F_CardNo") <> String.Empty Then
        oF_CardNo.Text = Session("F_CardNo")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purAprTypEmpLimit.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurAprTypEmpLimit") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurAprTypEmpLimit", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVpurAprTypEmpLimit.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVpurAprTypEmpLimit.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_AprTypEmpLimit_CardNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CardNo As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(CardNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
