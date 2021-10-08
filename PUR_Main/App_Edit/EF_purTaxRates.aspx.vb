Imports System.Web.Script.Serialization
Partial Class EF_purTaxRates
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
  Protected Sub ODSpurTaxRates_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurTaxRates.Selected
    Dim tmp As SIS.PUR.purTaxRates = CType(e.ReturnValue, SIS.PUR.purTaxRates)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurTaxRates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurTaxRates.Init
    DataClassName = "EpurTaxRates"
    SetFormView = FVpurTaxRates
  End Sub
  Protected Sub TBLpurTaxRates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurTaxRates.Init
    SetToolBar = TBLpurTaxRates
  End Sub
  Protected Sub FVpurTaxRates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurTaxRates.PreRender
    TBLpurTaxRates.EnableSave = Editable
    TBLpurTaxRates.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purTaxRates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurTaxRates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurTaxRates", mStr)
    End If
  End Sub

End Class
