Imports System.Web.Script.Serialization
Partial Class EF_purIndentStatus
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
  Protected Sub ODSpurIndentStatus_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurIndentStatus.Selected
    Dim tmp As SIS.PUR.purIndentStatus = CType(e.ReturnValue, SIS.PUR.purIndentStatus)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurIndentStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurIndentStatus.Init
    DataClassName = "EpurIndentStatus"
    SetFormView = FVpurIndentStatus
  End Sub
  Protected Sub TBLpurIndentStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurIndentStatus.Init
    SetToolBar = TBLpurIndentStatus
  End Sub
  Protected Sub FVpurIndentStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurIndentStatus.PreRender
    TBLpurIndentStatus.EnableSave = Editable
    TBLpurIndentStatus.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purIndentStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurIndentStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurIndentStatus", mStr)
    End If
  End Sub

End Class
