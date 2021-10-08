Imports System.Web.Script.Serialization
Partial Class EF_purItemSpecification
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
  Protected Sub ODSpurItemSpecification_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurItemSpecification.Selected
    Dim tmp As SIS.PUR.purItemSpecification = CType(e.ReturnValue, SIS.PUR.purItemSpecification)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurItemSpecification_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemSpecification.Init
    DataClassName = "EpurItemSpecification"
    SetFormView = FVpurItemSpecification
  End Sub
  Protected Sub TBLpurItemSpecification_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemSpecification.Init
    SetToolBar = TBLpurItemSpecification
  End Sub
  Protected Sub FVpurItemSpecification_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemSpecification.PreRender
    TBLpurItemSpecification.EnableSave = Editable
    TBLpurItemSpecification.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purItemSpecification.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurItemSpecification") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurItemSpecification", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpurItemSpecValuesCC As New gvBase
  Protected Sub GVpurItemSpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurItemSpecValues.Init
    gvpurItemSpecValuesCC.DataClassName = "GpurItemSpecValues"
    gvpurItemSpecValuesCC.SetGridView = GVpurItemSpecValues
  End Sub
  Protected Sub TBLpurItemSpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemSpecValues.Init
    gvpurItemSpecValuesCC.SetToolBar = TBLpurItemSpecValues
  End Sub
  Protected Sub GVpurItemSpecValues_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurItemSpecValues.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SpecID As Int32 = GVpurItemSpecValues.DataKeys(e.CommandArgument).Values("SpecID")  
        Dim SerialNo As Int32 = GVpurItemSpecValues.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLpurItemSpecValues.EditUrl & "?SpecID=" & SpecID & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpurItemSpecValues_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpurItemSpecValues.AddClicked
    Dim SpecID As Int32 = CType(FVpurItemSpecification.FindControl("F_SpecID"),TextBox).Text
    TBLpurItemSpecValues.AddUrl &= "?SpecID=" & SpecID
  End Sub

End Class
