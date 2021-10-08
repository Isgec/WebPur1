Imports System.Web.Script.Serialization
Partial Class EF_purPendingIndents
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
  Protected Sub ODSpurPendingIndents_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurPendingIndents.Selected
    Dim tmp As SIS.PUR.purPendingIndents = CType(e.ReturnValue, SIS.PUR.purPendingIndents)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurPendingIndents_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurPendingIndents.Init
    DataClassName = "EpurPendingIndents"
    SetFormView = FVpurPendingIndents
  End Sub
  Protected Sub TBLpurPendingIndents_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurPendingIndents.Init
    SetToolBar = TBLpurPendingIndents
  End Sub
  Protected Sub FVpurPendingIndents_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurPendingIndents.PreRender
    TBLpurPendingIndents.EnableSave = Editable
    TBLpurPendingIndents.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purPendingIndents.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurPendingIndents") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurPendingIndents", mStr)
    End If
  End Sub

End Class
