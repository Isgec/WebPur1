Imports System.Web.Script.Serialization
Partial Class EF_purItemCategorySpecs
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
  Protected Sub ODSpurItemCategorySpecs_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurItemCategorySpecs.Selected
    Dim tmp As SIS.PUR.purItemCategorySpecs = CType(e.ReturnValue, SIS.PUR.purItemCategorySpecs)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurItemCategorySpecs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemCategorySpecs.Init
    DataClassName = "EpurItemCategorySpecs"
    SetFormView = FVpurItemCategorySpecs
  End Sub
  Protected Sub TBLpurItemCategorySpecs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemCategorySpecs.Init
    SetToolBar = TBLpurItemCategorySpecs
  End Sub
  Protected Sub FVpurItemCategorySpecs_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemCategorySpecs.PreRender
    TBLpurItemCategorySpecs.EnableSave = Editable
    TBLpurItemCategorySpecs.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purItemCategorySpecs.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurItemCategorySpecs") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurItemCategorySpecs", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpurItemCategorySpecValuesCC As New gvBase
  Protected Sub GVpurItemCategorySpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpurItemCategorySpecValues.Init
    gvpurItemCategorySpecValuesCC.DataClassName = "GpurItemCategorySpecValues"
    gvpurItemCategorySpecValuesCC.SetGridView = GVpurItemCategorySpecValues
  End Sub
  Protected Sub TBLpurItemCategorySpecValues_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemCategorySpecValues.Init
    gvpurItemCategorySpecValuesCC.SetToolBar = TBLpurItemCategorySpecValues
  End Sub
  Protected Sub GVpurItemCategorySpecValues_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpurItemCategorySpecValues.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ItemCategoryID As Int32 = GVpurItemCategorySpecValues.DataKeys(e.CommandArgument).Values("ItemCategoryID")  
        Dim CategorySpecID As Int32 = GVpurItemCategorySpecValues.DataKeys(e.CommandArgument).Values("CategorySpecID")  
        Dim SerialNo As Int32 = GVpurItemCategorySpecValues.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLpurItemCategorySpecValues.EditUrl & "?ItemCategoryID=" & ItemCategoryID & "&CategorySpecID=" & CategorySpecID & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpurItemCategorySpecValues_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpurItemCategorySpecValues.AddClicked
    Dim ItemCategoryID As Int32 = CType(FVpurItemCategorySpecs.FindControl("F_ItemCategoryID"),TextBox).Text
    Dim CategorySpecID As Int32 = CType(FVpurItemCategorySpecs.FindControl("F_CategorySpecID"),TextBox).Text
    TBLpurItemCategorySpecValues.AddUrl &= "?ItemCategoryID=" & ItemCategoryID
    TBLpurItemCategorySpecValues.AddUrl &= "&CategorySpecID=" & CategorySpecID
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SpecIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemSpecification.SelectpurItemSpecificationAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DefaultValueSerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategorySpecValues.SelectpurItemCategorySpecValuesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ItemCategorySpecs_DefaultValueSerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ItemCategoryID As Int32 = 0
    Integer.TryParse(aVal(1), ItemCategoryID)
    Dim CategorySpecID As Int32 = 0
    Integer.TryParse(aVal(2), CategorySpecID)
    Dim DefaultValueSerialNo As Int32 = 0
    Integer.TryParse(aVal(3), DefaultValueSerialNo)
    Dim oVar As SIS.PUR.purItemCategorySpecValues = SIS.PUR.purItemCategorySpecValues.purItemCategorySpecValuesGetByID(ItemCategoryID, CategorySpecID, DefaultValueSerialNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ItemCategorySpecs_SpecID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SpecID As Int32 = 0
    Integer.TryParse(aVal(1), SpecID)
    Dim oVar As SIS.PUR.purItemSpecification = SIS.PUR.purItemSpecification.purItemSpecificationGetByID(SpecID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

  Protected Sub cmdImport_Click(sender As Object, e As EventArgs)
    Dim ItemCategoryID As Integer = CType(FVpurItemCategorySpecs.FindControl("F_ItemCategoryID"), TextBox).Text
    Dim CategorySpecID As Integer = CType(FVpurItemCategorySpecs.FindControl("F_CategorySpecID"), TextBox).Text
    Dim SpecID As Integer = CType(FVpurItemCategorySpecs.FindControl("F_SpecID"), TextBox).Text
    Dim oS As SIS.PUR.purItemSpecification = SIS.PUR.purItemSpecification.purItemSpecificationGetByID(SpecID)
    CType(FVpurItemCategorySpecs.FindControl("F_SpecName"), TextBox).Text = oS.SpecName
    CType(FVpurItemCategorySpecs.FindControl("F_IsFixed"), CheckBox).Checked = oS.IsFixed
    CType(FVpurItemCategorySpecs.FindControl("F_IsDerived"), CheckBox).Checked = oS.IsDerived
    CType(FVpurItemCategorySpecs.FindControl("F_ValidateValue"), CheckBox).Checked = oS.ValidateValue
    CType(FVpurItemCategorySpecs.FindControl("F_UseValues"), CheckBox).Checked = oS.UseValues
    CType(FVpurItemCategorySpecs.FindControl("F_AllowUserValue"), CheckBox).Checked = oS.AllowUserValue
    CType(FVpurItemCategorySpecs.FindControl("F_ValueDataTypeID"), LC_purValueDataTypes).SelectedValue = oS.ValueDataTypeID
    CType(FVpurItemCategorySpecs.FindControl("F_IsRange"), CheckBox).Checked = oS.IsRange
    Dim S As SIS.PUR.purItemCategorySpecs = SIS.PUR.purItemCategorySpecs.purItemCategorySpecsGetByID(ItemCategoryID, CategorySpecID)
    With S
      .SpecID = SpecID
      .SpecName = oS.SpecName
      .UseValues = oS.UseValues
      .ValidateValue = oS.ValidateValue
      .IsDerived = oS.IsDerived
      .IsFixed = oS.IsFixed
      .AllowUserValue = oS.AllowUserValue
      .ValueDataTypeID = oS.ValueDataTypeID
      .IsRange = oS.IsRange
    End With
    SIS.PUR.purItemCategorySpecs.UpdateData(S)
    Dim oSVs As List(Of SIS.PUR.purItemCategorySpecValues) = SIS.PUR.purItemCategorySpecValues.purItemCategorySpecValuesSelectList(0, 9999, "", False, "", ItemCategoryID, CategorySpecID)
    For Each oSV As SIS.PUR.purItemCategorySpecValues In oSVs
      SIS.PUR.purItemCategorySpecValues.purItemCategorySpecValuesDelete(oSV)
    Next
    Dim SVs As List(Of SIS.PUR.purItemSpecValues) = SIS.PUR.purItemSpecValues.purItemSpecValuesSelectList(0, 9999, "SerialNo", False, "", SpecID)
    For Each sv As SIS.PUR.purItemSpecValues In SVs
      Dim x As New SIS.PUR.purItemCategorySpecValues
      With x
        .ItemCategoryID = ItemCategoryID
        .CategorySpecID = CategorySpecID
        .SerialNo = 0
        .ValueDataTypeID = sv.ValueDataTypeID
        .IsRange = sv.IsRange
        .Data1Value = sv.Data1Value
        .Data2Value = sv.Data2Value
      End With
      SIS.PUR.purItemCategorySpecValues.InsertData(x)
    Next
    FVpurItemCategorySpecs.DataBind()
    GVpurItemCategorySpecValues.DataBind()
  End Sub
End Class
