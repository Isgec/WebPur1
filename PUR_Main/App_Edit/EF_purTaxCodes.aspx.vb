Imports System.Web.Script.Serialization
Partial Class EF_purTaxCodes
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
  Protected Sub ODSpurTaxCodes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurTaxCodes.Selected
    Dim tmp As SIS.PUR.purTaxCodes = CType(e.ReturnValue, SIS.PUR.purTaxCodes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurTaxCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurTaxCodes.Init
    DataClassName = "EpurTaxCodes"
    SetFormView = FVpurTaxCodes
  End Sub
  Protected Sub TBLpurTaxCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurTaxCodes.Init
    SetToolBar = TBLpurTaxCodes
  End Sub
  Protected Sub FVpurTaxCodes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurTaxCodes.PreRender
    TBLpurTaxCodes.EnableSave = Editable
    TBLpurTaxCodes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purTaxCodes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurTaxCodes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurTaxCodes", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpurTaxRatesCC As New gvBase
  Protected Sub GVpurTaxRates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurTaxRates.Init
    gvpurTaxRatesCC.DataClassName = "GpurTaxRates"
    gvpurTaxRatesCC.SetGridView = GVpurTaxRates
  End Sub
  Protected Sub TBLpurTaxRates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurTaxRates.Init
    gvpurTaxRatesCC.SetToolBar = TBLpurTaxRates
  End Sub
  Protected Sub GVpurTaxRates_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurTaxRates.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TaxCode As Int32 = GVpurTaxRates.DataKeys(e.CommandArgument).Values("TaxCode")  
        Dim SerialNo As Int32 = GVpurTaxRates.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLpurTaxRates.EditUrl & "?TaxCode=" & TaxCode & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Revisewf".ToLower Then
      Try
        Dim TaxCode As Int32 = GVpurTaxRates.DataKeys(e.CommandArgument).Values("TaxCode")  
        Dim SerialNo As Int32 = GVpurTaxRates.DataKeys(e.CommandArgument).Values("SerialNo")  
        SIS.PUR.purTaxRates.ReviseWF(TaxCode, SerialNo)
        GVpurTaxRates.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpurTaxRates_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpurTaxRates.AddClicked
    Dim TaxCode As Int32 = CType(FVpurTaxCodes.FindControl("F_TaxCode"),TextBox).Text
    TBLpurTaxRates.AddUrl &= "?TaxCode=" & TaxCode
  End Sub

End Class
