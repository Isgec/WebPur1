Imports System.Web.Script.Serialization
Partial Class EF_purValueDataTypes
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
  Protected Sub ODSpurValueDataTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurValueDataTypes.Selected
    Dim tmp As SIS.PUR.purValueDataTypes = CType(e.ReturnValue, SIS.PUR.purValueDataTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurValueDataTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurValueDataTypes.Init
    DataClassName = "EpurValueDataTypes"
    SetFormView = FVpurValueDataTypes
  End Sub
  Protected Sub TBLpurValueDataTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurValueDataTypes.Init
    SetToolBar = TBLpurValueDataTypes
  End Sub
  Protected Sub FVpurValueDataTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurValueDataTypes.PreRender
    TBLpurValueDataTypes.EnableSave = Editable
    TBLpurValueDataTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purValueDataTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurValueDataTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurValueDataTypes", mStr)
    End If
  End Sub

End Class
