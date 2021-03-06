Imports System.Web.Script.Serialization
Partial Class EF_purCurrencies
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
  Protected Sub ODSpurCurrencies_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurCurrencies.Selected
    Dim tmp As SIS.PUR.purCurrencies = CType(e.ReturnValue, SIS.PUR.purCurrencies)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurCurrencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurCurrencies.Init
    DataClassName = "EpurCurrencies"
    SetFormView = FVpurCurrencies
  End Sub
  Protected Sub TBLpurCurrencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurCurrencies.Init
    SetToolBar = TBLpurCurrencies
  End Sub
  Protected Sub FVpurCurrencies_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurCurrencies.PreRender
    TBLpurCurrencies.EnableSave = Editable
    TBLpurCurrencies.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purCurrencies.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurCurrencies") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurCurrencies", mStr)
    End If
  End Sub

End Class
