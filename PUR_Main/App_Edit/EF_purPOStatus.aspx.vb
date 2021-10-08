Imports System.Web.Script.Serialization
Partial Class EF_purPOStatus
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
  Protected Sub ODSpurPOStatus_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurPOStatus.Selected
    Dim tmp As SIS.PUR.purPOStatus = CType(e.ReturnValue, SIS.PUR.purPOStatus)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurPOStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurPOStatus.Init
    DataClassName = "EpurPOStatus"
    SetFormView = FVpurPOStatus
  End Sub
  Protected Sub TBLpurPOStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurPOStatus.Init
    SetToolBar = TBLpurPOStatus
  End Sub
  Protected Sub FVpurPOStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurPOStatus.PreRender
    TBLpurPOStatus.EnableSave = Editable
    TBLpurPOStatus.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purPOStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurPOStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurPOStatus", mStr)
    End If
  End Sub

End Class
