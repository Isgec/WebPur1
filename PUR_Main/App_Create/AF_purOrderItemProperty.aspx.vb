Partial Class AF_purOrderItemProperty
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurOrderItemProperty_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurOrderItemProperty.Init
    DataClassName = "ApurOrderItemProperty"
    SetFormView = FVpurOrderItemProperty
  End Sub
  Protected Sub TBLpurOrderItemProperty_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurOrderItemProperty.Init
    SetToolBar = TBLpurOrderItemProperty
  End Sub
  Protected Sub FVpurOrderItemProperty_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurOrderItemProperty.DataBound
    SIS.PUR.purOrderItemProperty.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurOrderItemProperty_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurOrderItemProperty.PreRender
    Dim oF_OrderNo_Display As Label  = FVpurOrderItemProperty.FindControl("F_OrderNo_Display")
    oF_OrderNo_Display.Text = String.Empty
    If Not Session("F_OrderNo_Display") Is Nothing Then
      If Session("F_OrderNo_Display") <> String.Empty Then
        oF_OrderNo_Display.Text = Session("F_OrderNo_Display")
      End If
    End If
    Dim oF_OrderNo As TextBox  = FVpurOrderItemProperty.FindControl("F_OrderNo")
    oF_OrderNo.Enabled = True
    oF_OrderNo.Text = String.Empty
    If Not Session("F_OrderNo") Is Nothing Then
      If Session("F_OrderNo") <> String.Empty Then
        oF_OrderNo.Text = Session("F_OrderNo")
      End If
    End If
    Dim oF_OrderLine_Display As Label  = FVpurOrderItemProperty.FindControl("F_OrderLine_Display")
    oF_OrderLine_Display.Text = String.Empty
    If Not Session("F_OrderLine_Display") Is Nothing Then
      If Session("F_OrderLine_Display") <> String.Empty Then
        oF_OrderLine_Display.Text = Session("F_OrderLine_Display")
      End If
    End If
    Dim oF_OrderLine As TextBox  = FVpurOrderItemProperty.FindControl("F_OrderLine")
    oF_OrderLine.Enabled = True
    oF_OrderLine.Text = String.Empty
    If Not Session("F_OrderLine") Is Nothing Then
      If Session("F_OrderLine") <> String.Empty Then
        oF_OrderLine.Text = Session("F_OrderLine")
      End If
    End If
    Dim oF_ItemCode_Display As Label  = FVpurOrderItemProperty.FindControl("F_ItemCode_Display")
    Dim oF_ItemCode As TextBox  = FVpurOrderItemProperty.FindControl("F_ItemCode")
    Dim oF_ItemCategoryID_Display As Label  = FVpurOrderItemProperty.FindControl("F_ItemCategoryID_Display")
    Dim oF_ItemCategoryID As TextBox  = FVpurOrderItemProperty.FindControl("F_ItemCategoryID")
    Dim oF_CategorySpecID_Display As Label  = FVpurOrderItemProperty.FindControl("F_CategorySpecID_Display")
    Dim oF_CategorySpecID As TextBox  = FVpurOrderItemProperty.FindControl("F_CategorySpecID")
    Dim oF_SerialNo_Display As Label  = FVpurOrderItemProperty.FindControl("F_SerialNo_Display")
    Dim oF_SerialNo As TextBox  = FVpurOrderItemProperty.FindControl("F_SerialNo")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purOrderItemProperty.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurOrderItemProperty") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurOrderItemProperty", mStr)
    End If
    If Request.QueryString("OrderNo") IsNot Nothing Then
      CType(FVpurOrderItemProperty.FindControl("F_OrderNo"), TextBox).Text = Request.QueryString("OrderNo")
      CType(FVpurOrderItemProperty.FindControl("F_OrderNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("OrderRev") IsNot Nothing Then
      CType(FVpurOrderItemProperty.FindControl("F_OrderRev"), TextBox).Text = Request.QueryString("OrderRev")
      CType(FVpurOrderItemProperty.FindControl("F_OrderRev"), TextBox).Enabled = False
    End If
    If Request.QueryString("OrderLine") IsNot Nothing Then
      CType(FVpurOrderItemProperty.FindControl("F_OrderLine"), TextBox).Text = Request.QueryString("OrderLine")
      CType(FVpurOrderItemProperty.FindControl("F_OrderLine"), TextBox).Enabled = False
    End If
    If Request.QueryString("ItemCode") IsNot Nothing Then
      CType(FVpurOrderItemProperty.FindControl("F_ItemCode"), TextBox).Text = Request.QueryString("ItemCode")
      CType(FVpurOrderItemProperty.FindControl("F_ItemCode"), TextBox).Enabled = False
    End If
    If Request.QueryString("ItemCategoryID") IsNot Nothing Then
      CType(FVpurOrderItemProperty.FindControl("F_ItemCategoryID"), TextBox).Text = Request.QueryString("ItemCategoryID")
      CType(FVpurOrderItemProperty.FindControl("F_ItemCategoryID"), TextBox).Enabled = False
    End If
    If Request.QueryString("CategorySpecID") IsNot Nothing Then
      CType(FVpurOrderItemProperty.FindControl("F_CategorySpecID"), TextBox).Text = Request.QueryString("CategorySpecID")
      CType(FVpurOrderItemProperty.FindControl("F_CategorySpecID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function OrderNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purOrders.SelectpurOrdersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function OrderLineCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purOrderDetails.SelectpurOrderDetailsAutoCompleteList(prefixText, count, contextKey)
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
  Public Shared Function validate_FK_PUR_OrderItemProperty_ItemCategoryID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_OrderItemProperty_CategorySpecID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_OrderItemProperty_SerialNo(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_OrderItemProperty_ItemCode(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_OrderItemProperty_OrderLine(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim OrderNo As Int32 = CType(aVal(1),Int32)
    Dim OrderRev As Int32 = CType(aVal(2),Int32)
    Dim OrderLine As Int32 = CType(aVal(3),Int32)
    Dim oVar As SIS.PUR.purOrderDetails = SIS.PUR.purOrderDetails.purOrderDetailsGetByID(OrderNo,OrderRev,OrderLine)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_OrderItemProperty_OrderNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim OrderNo As Int32 = CType(aVal(1),Int32)
    Dim OrderRev As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PUR.purOrders = SIS.PUR.purOrders.purOrdersGetByID(OrderNo,OrderRev)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
