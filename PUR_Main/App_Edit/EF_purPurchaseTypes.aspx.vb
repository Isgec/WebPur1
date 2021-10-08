Imports System.Web.Script.Serialization
Partial Class EF_purPurchaseTypes
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
  Protected Sub ODSpurPurchaseTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurPurchaseTypes.Selected
    Dim tmp As SIS.PUR.purPurchaseTypes = CType(e.ReturnValue, SIS.PUR.purPurchaseTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurPurchaseTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurPurchaseTypes.Init
    DataClassName = "EpurPurchaseTypes"
    SetFormView = FVpurPurchaseTypes
  End Sub
  Protected Sub TBLpurPurchaseTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurPurchaseTypes.Init
    SetToolBar = TBLpurPurchaseTypes
  End Sub
  Protected Sub FVpurPurchaseTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurPurchaseTypes.PreRender
    TBLpurPurchaseTypes.EnableSave = Editable
    TBLpurPurchaseTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purPurchaseTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurPurchaseTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurPurchaseTypes", mStr)
    End If
  End Sub

End Class
