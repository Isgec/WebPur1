Imports System.Web.Script.Serialization
Partial Class EF_purItemCategorySpecValues
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
  Protected Sub ODSpurItemCategorySpecValues_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurItemCategorySpecValues.Selected
    Dim tmp As SIS.PUR.purItemCategorySpecValues = CType(e.ReturnValue, SIS.PUR.purItemCategorySpecValues)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurItemCategorySpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemCategorySpecValues.Init
    DataClassName = "EpurItemCategorySpecValues"
    SetFormView = FVpurItemCategorySpecValues
  End Sub
  Protected Sub TBLpurItemCategorySpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemCategorySpecValues.Init
    SetToolBar = TBLpurItemCategorySpecValues
  End Sub
  Protected Sub FVpurItemCategorySpecValues_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemCategorySpecValues.PreRender
    TBLpurItemCategorySpecValues.EnableSave = Editable
    TBLpurItemCategorySpecValues.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purItemCategorySpecValues.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurItemCategorySpecValues") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurItemCategorySpecValues", mStr)
    End If
  End Sub

End Class
