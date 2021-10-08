Partial Class AF_purReceiptItemProperty
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurReceiptItemProperty_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurReceiptItemProperty.Init
    DataClassName = "ApurReceiptItemProperty"
    SetFormView = FVpurReceiptItemProperty
  End Sub
  Protected Sub TBLpurReceiptItemProperty_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurReceiptItemProperty.Init
    SetToolBar = TBLpurReceiptItemProperty
  End Sub
  Protected Sub FVpurReceiptItemProperty_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurReceiptItemProperty.DataBound
    SIS.PUR.purReceiptItemProperty.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurReceiptItemProperty_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurReceiptItemProperty.PreRender
    Dim oF_ReceiptNo_Display As Label  = FVpurReceiptItemProperty.FindControl("F_ReceiptNo_Display")
    oF_ReceiptNo_Display.Text = String.Empty
    If Not Session("F_ReceiptNo_Display") Is Nothing Then
      If Session("F_ReceiptNo_Display") <> String.Empty Then
        oF_ReceiptNo_Display.Text = Session("F_ReceiptNo_Display")
      End If
    End If
    Dim oF_ReceiptNo As TextBox  = FVpurReceiptItemProperty.FindControl("F_ReceiptNo")
    oF_ReceiptNo.Enabled = True
    oF_ReceiptNo.Text = String.Empty
    If Not Session("F_ReceiptNo") Is Nothing Then
      If Session("F_ReceiptNo") <> String.Empty Then
        oF_ReceiptNo.Text = Session("F_ReceiptNo")
      End If
    End If
    Dim oF_ReceiptLine_Display As Label  = FVpurReceiptItemProperty.FindControl("F_ReceiptLine_Display")
    oF_ReceiptLine_Display.Text = String.Empty
    If Not Session("F_ReceiptLine_Display") Is Nothing Then
      If Session("F_ReceiptLine_Display") <> String.Empty Then
        oF_ReceiptLine_Display.Text = Session("F_ReceiptLine_Display")
      End If
    End If
    Dim oF_ReceiptLine As TextBox  = FVpurReceiptItemProperty.FindControl("F_ReceiptLine")
    oF_ReceiptLine.Enabled = True
    oF_ReceiptLine.Text = String.Empty
    If Not Session("F_ReceiptLine") Is Nothing Then
      If Session("F_ReceiptLine") <> String.Empty Then
        oF_ReceiptLine.Text = Session("F_ReceiptLine")
      End If
    End If
    Dim oF_ItemCode_Display As Label  = FVpurReceiptItemProperty.FindControl("F_ItemCode_Display")
    Dim oF_ItemCode As TextBox  = FVpurReceiptItemProperty.FindControl("F_ItemCode")
    Dim oF_ItemCategoryID_Display As Label  = FVpurReceiptItemProperty.FindControl("F_ItemCategoryID_Display")
    Dim oF_ItemCategoryID As TextBox  = FVpurReceiptItemProperty.FindControl("F_ItemCategoryID")
    Dim oF_CategorySpecID_Display As Label  = FVpurReceiptItemProperty.FindControl("F_CategorySpecID_Display")
    Dim oF_CategorySpecID As TextBox  = FVpurReceiptItemProperty.FindControl("F_CategorySpecID")
    Dim oF_SerialNo_Display As Label  = FVpurReceiptItemProperty.FindControl("F_SerialNo_Display")
    Dim oF_SerialNo As TextBox  = FVpurReceiptItemProperty.FindControl("F_SerialNo")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purReceiptItemProperty.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurReceiptItemProperty") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurReceiptItemProperty", mStr)
    End If
    If Request.QueryString("ReceiptNo") IsNot Nothing Then
      CType(FVpurReceiptItemProperty.FindControl("F_ReceiptNo"), TextBox).Text = Request.QueryString("ReceiptNo")
      CType(FVpurReceiptItemProperty.FindControl("F_ReceiptNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("ReceiptLine") IsNot Nothing Then
      CType(FVpurReceiptItemProperty.FindControl("F_ReceiptLine"), TextBox).Text = Request.QueryString("ReceiptLine")
      CType(FVpurReceiptItemProperty.FindControl("F_ReceiptLine"), TextBox).Enabled = False
    End If
    If Request.QueryString("ItemCode") IsNot Nothing Then
      CType(FVpurReceiptItemProperty.FindControl("F_ItemCode"), TextBox).Text = Request.QueryString("ItemCode")
      CType(FVpurReceiptItemProperty.FindControl("F_ItemCode"), TextBox).Enabled = False
    End If
    If Request.QueryString("ItemCategoryID") IsNot Nothing Then
      CType(FVpurReceiptItemProperty.FindControl("F_ItemCategoryID"), TextBox).Text = Request.QueryString("ItemCategoryID")
      CType(FVpurReceiptItemProperty.FindControl("F_ItemCategoryID"), TextBox).Enabled = False
    End If
    If Request.QueryString("CategorySpecID") IsNot Nothing Then
      CType(FVpurReceiptItemProperty.FindControl("F_CategorySpecID"), TextBox).Text = Request.QueryString("CategorySpecID")
      CType(FVpurReceiptItemProperty.FindControl("F_CategorySpecID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ReceiptNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purReceipts.SelectpurReceiptsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ReceiptLineCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purReceiptDetails.SelectpurReceiptDetailsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ItemCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItems.SelectpurItemsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ItemCategoryIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategories.SelectpurItemCategoriesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CategorySpecIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategorySpecs.SelectpurItemCategorySpecsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategorySpecValues.SelectpurItemCategorySpecValuesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptItemProperty_ItemCategoryID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ItemCategoryID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PUR.purItemCategories = SIS.PUR.purItemCategories.purItemCategoriesGetByID(ItemCategoryID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptItemProperty_CategorySpecID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ItemCategoryID As Int32 = CType(aVal(1),Int32)
    Dim CategorySpecID As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PUR.purItemCategorySpecs = SIS.PUR.purItemCategorySpecs.purItemCategorySpecsGetByID(ItemCategoryID,CategorySpecID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptItemProperty_SerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ItemCategoryID As Int32 = CType(aVal(1),Int32)
    Dim CategorySpecID As Int32 = CType(aVal(2),Int32)
    Dim SerialNo As Int32 = CType(aVal(3),Int32)
    Dim oVar As SIS.PUR.purItemCategorySpecValues = SIS.PUR.purItemCategorySpecValues.purItemCategorySpecValuesGetByID(ItemCategoryID,CategorySpecID,SerialNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptItemProperty_ItemCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ItemCode As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PUR.purItems = SIS.PUR.purItems.purItemsGetByID(ItemCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptItemProperty_ReceiptLine(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ReceiptNo As Int32 = CType(aVal(1),Int32)
    Dim ReceiptLine As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PUR.purReceiptDetails = SIS.PUR.purReceiptDetails.purReceiptDetailsGetByID(ReceiptNo,ReceiptLine)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptItemProperty_ReceiptNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ReceiptNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PUR.purReceipts = SIS.PUR.purReceipts.purReceiptsGetByID(ReceiptNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
