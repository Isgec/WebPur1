Imports System.Web.Script.Serialization
Partial Class EF_purItemCategories
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
  Protected Sub ODSpurItemCategories_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurItemCategories.Selected
    Dim tmp As SIS.PUR.purItemCategories = CType(e.ReturnValue, SIS.PUR.purItemCategories)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurItemCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemCategories.Init
    DataClassName = "EpurItemCategories"
    SetFormView = FVpurItemCategories
  End Sub
  Protected Sub TBLpurItemCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemCategories.Init
    SetToolBar = TBLpurItemCategories
  End Sub
  Protected Sub FVpurItemCategories_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemCategories.PreRender
    TBLpurItemCategories.EnableSave = Editable
    TBLpurItemCategories.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purItemCategories.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurItemCategories") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurItemCategories", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpurItemCategorySpecsCC As New gvBase
  Protected Sub GVpurItemCategorySpecs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurItemCategorySpecs.Init
    gvpurItemCategorySpecsCC.DataClassName = "GpurItemCategorySpecs"
    gvpurItemCategorySpecsCC.SetGridView = GVpurItemCategorySpecs
  End Sub
  Protected Sub TBLpurItemCategorySpecs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemCategorySpecs.Init
    gvpurItemCategorySpecsCC.SetToolBar = TBLpurItemCategorySpecs
  End Sub
  Protected Sub GVpurItemCategorySpecs_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurItemCategorySpecs.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ItemCategoryID As Int32 = GVpurItemCategorySpecs.DataKeys(e.CommandArgument).Values("ItemCategoryID")  
        Dim CategorySpecID As Int32 = GVpurItemCategorySpecs.DataKeys(e.CommandArgument).Values("CategorySpecID")  
        Dim RedirectUrl As String = TBLpurItemCategorySpecs.EditUrl & "?ItemCategoryID=" & ItemCategoryID & "&CategorySpecID=" & CategorySpecID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpurItemCategorySpecs_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpurItemCategorySpecs.AddClicked
    Dim ItemCategoryID As Int32 = CType(FVpurItemCategories.FindControl("F_ItemCategoryID"),TextBox).Text
    TBLpurItemCategorySpecs.AddUrl &= "&ItemCategoryID=" & ItemCategoryID
  End Sub

End Class
