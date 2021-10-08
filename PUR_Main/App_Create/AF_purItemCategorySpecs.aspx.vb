Imports System.Web.Script.Serialization
Partial Class AF_purItemCategorySpecs
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurItemCategorySpecs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemCategorySpecs.Init
    DataClassName = "ApurItemCategorySpecs"
    SetFormView = FVpurItemCategorySpecs
  End Sub
  Protected Sub TBLpurItemCategorySpecs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurItemCategorySpecs.Init
    SetToolBar = TBLpurItemCategorySpecs
  End Sub
  Protected Sub ODSpurItemCategorySpecs_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurItemCategorySpecs.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PUR.purItemCategorySpecs = CType(e.ReturnValue, SIS.PUR.purItemCategorySpecs)
      ImportSpecValues(oDC)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&ItemCategoryID=" & oDC.ItemCategoryID
      tmpURL &= "&CategorySpecID=" & oDC.CategorySpecID
      TBLpurItemCategorySpecs.AfterInsertURL &= tmpURL
    End If
  End Sub
  Protected Sub ImportSpecValues(oDC As SIS.PUR.purItemCategorySpecs)
    Dim ItemCategoryID As Integer = oDC.ItemCategoryID
    Dim CategorySpecID As Integer = oDC.CategorySpecID
    Dim SpecID As String = oDC.SpecID
    If SpecID <> "" Then
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
    End If
  End Sub
  Protected Sub FVpurItemCategorySpecs_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemCategorySpecs.DataBound
    SIS.PUR.purItemCategorySpecs.SetDefaultValues(sender, e)
  End Sub
  Protected Sub FVpurItemCategorySpecs_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurItemCategorySpecs.PreRender
    Dim oF_ItemCategoryID_Display As Label = FVpurItemCategorySpecs.FindControl("F_ItemCategoryID_Display")
    oF_ItemCategoryID_Display.Text = String.Empty
    If Not Session("F_ItemCategoryID_Display") Is Nothing Then
      If Session("F_ItemCategoryID_Display") <> String.Empty Then
        oF_ItemCategoryID_Display.Text = Session("F_ItemCategoryID_Display")
      End If
    End If
    Dim oF_ItemCategoryID As TextBox = FVpurItemCategorySpecs.FindControl("F_ItemCategoryID")
    oF_ItemCategoryID.Enabled = True
    oF_ItemCategoryID.Text = String.Empty
    If Not Session("F_ItemCategoryID") Is Nothing Then
      If Session("F_ItemCategoryID") <> String.Empty Then
        oF_ItemCategoryID.Text = Session("F_ItemCategoryID")
      End If
    End If
    Dim oF_CategorySpecID_Display As Label = FVpurItemCategorySpecs.FindControl("F_CategorySpecID_Display")
    Dim oF_CategorySpecID As TextBox = FVpurItemCategorySpecs.FindControl("F_CategorySpecID")
    Dim oF_SpecID_Display As Label = FVpurItemCategorySpecs.FindControl("F_SpecID_Display")
    Dim oF_SpecID As TextBox = FVpurItemCategorySpecs.FindControl("F_SpecID")
    Dim oF_DefaultValueSerialNo_Display As Label = FVpurItemCategorySpecs.FindControl("F_DefaultValueSerialNo_Display")
    Dim oF_DefaultValueSerialNo As TextBox = FVpurItemCategorySpecs.FindControl("F_DefaultValueSerialNo")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purItemCategorySpecs.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurItemCategorySpecs") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurItemCategorySpecs", mStr)
    End If
    If Request.QueryString("ItemCategoryID") IsNot Nothing Then
      CType(FVpurItemCategorySpecs.FindControl("F_ItemCategoryID"), TextBox).Text = Request.QueryString("ItemCategoryID")
      CType(FVpurItemCategorySpecs.FindControl("F_ItemCategoryID"), TextBox).Enabled = False
    End If
    If Request.QueryString("CategorySpecID") IsNot Nothing Then
      CType(FVpurItemCategorySpecs.FindControl("F_CategorySpecID"), TextBox).Text = Request.QueryString("CategorySpecID")
      CType(FVpurItemCategorySpecs.FindControl("F_CategorySpecID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ItemCategoryIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategories.SelectpurItemCategoriesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CategorySpecIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategorySpecValues.SelectpurItemCategorySpecValuesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function SpecIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemSpecification.SelectpurItemSpecificationAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function DefaultValueSerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategorySpecValues.SelectpurItemCategorySpecValuesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PUR_ItemCategorySpecs_ItemCategoryID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ItemCategoryID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.PUR.purItemCategories = SIS.PUR.purItemCategories.purItemCategoriesGetByID(ItemCategoryID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PUR_ItemCategorySpecs_DefaultValueSerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
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
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PUR_ItemCategorySpecs_SpecID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim SpecID As Int32 = 0
    Integer.TryParse(aVal(1), SpecID)
    Dim oVar As SIS.PUR.purItemSpecification = SIS.PUR.purItemSpecification.purItemSpecificationGetByID(SpecID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField & "|" & New JavaScriptSerializer().Serialize(oVar)
    End If
    Return mRet
  End Function

End Class
