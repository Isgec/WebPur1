Imports System.Web.Script.Serialization
Partial Class EF_purAprTypEmpLimit
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSpurAprTypEmpLimit_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurAprTypEmpLimit.Selected
    Dim tmp As SIS.PUR.purAprTypEmpLimit = CType(e.ReturnValue, SIS.PUR.purAprTypEmpLimit)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurAprTypEmpLimit_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurAprTypEmpLimit.Init
    DataClassName = "EpurAprTypEmpLimit"
    SetFormView = FVpurAprTypEmpLimit
  End Sub
  Protected Sub TBLpurAprTypEmpLimit_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurAprTypEmpLimit.Init
    SetToolBar = TBLpurAprTypEmpLimit
  End Sub
  Protected Sub FVpurAprTypEmpLimit_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurAprTypEmpLimit.PreRender
    TBLpurAprTypEmpLimit.EnableSave = Editable
    TBLpurAprTypEmpLimit.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purAprTypEmpLimit.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurAprTypEmpLimit") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurAprTypEmpLimit", mStr)
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
