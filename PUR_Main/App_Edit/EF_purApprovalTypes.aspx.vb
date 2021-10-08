Imports System.Web.Script.Serialization
Partial Class EF_purApprovalTypes
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
  Protected Sub ODSpurApprovalTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurApprovalTypes.Selected
    Dim tmp As SIS.PUR.purApprovalTypes = CType(e.ReturnValue, SIS.PUR.purApprovalTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurApprovalTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurApprovalTypes.Init
    DataClassName = "EpurApprovalTypes"
    SetFormView = FVpurApprovalTypes
  End Sub
  Protected Sub TBLpurApprovalTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurApprovalTypes.Init
    SetToolBar = TBLpurApprovalTypes
  End Sub
  Protected Sub FVpurApprovalTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurApprovalTypes.PreRender
    TBLpurApprovalTypes.EnableSave = Editable
    TBLpurApprovalTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purApprovalTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurApprovalTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurApprovalTypes", mStr)
    End If
  End Sub

End Class
