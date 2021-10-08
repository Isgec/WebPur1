Imports System.Web.Script.Serialization
Partial Class EF_purItemSpecValues
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
  Protected Sub ODSpurItemSpecValues_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurItemSpecValues.Selected
    Dim tmp As SIS.PUR.purItemSpecValues = CType(e.ReturnValue, SIS.PUR.purItemSpecValues)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurItemSpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemSpecValues.Init
    DataClassName = "EpurItemSpecValues"
    SetFormView = FVpurItemSpecValues
  End Sub
  Protected Sub TBLpurItemSpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemSpecValues.Init
    SetToolBar = TBLpurItemSpecValues
  End Sub
  Protected Sub FVpurItemSpecValues_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemSpecValues.PreRender
    TBLpurItemSpecValues.EnableSave = Editable
    TBLpurItemSpecValues.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purItemSpecValues.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurItemSpecValues") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurItemSpecValues", mStr)
    End If
  End Sub

End Class
