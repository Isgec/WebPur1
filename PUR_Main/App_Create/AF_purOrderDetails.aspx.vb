Imports System.Web.Script.Serialization
Partial Class AF_purOrderDetails
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurOrderDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurOrderDetails.Init
    DataClassName = "ApurOrderDetails"
    SetFormView = FVpurOrderDetails
  End Sub
  Protected Sub TBLpurOrderDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurOrderDetails.Init
    SetToolBar = TBLpurOrderDetails
  End Sub
  Protected Sub ODSpurOrderDetails_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurOrderDetails.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PUR.purOrderDetails = CType(e.ReturnValue, SIS.PUR.purOrderDetails)
      Dim ctl As CTL_ItemCategorySpecs = CType(FVpurOrderDetails.FindControl("gvItemProperty"), CTL_ItemCategorySpecs)
      Dim xVal As List(Of SIS.PUR.purItemCategorySpecValues) = ctl.GetData()
      For Each x As SIS.PUR.purItemCategorySpecValues In xVal
        Dim y As New SIS.PUR.purOrderItemProperty
        y.OrderNo = oDC.OrderNo
        y.OrderRev = oDC.OrderRev
        y.OrderLine = oDC.OrderLine
        y.ItemCode = oDC.ItemCode
        y.ItemCategoryID = x.ItemCategoryID
        y.CategorySpecID = x.CategorySpecID
        y.SerialNo = x.SerialNo
        y.IsRange = y.FK_PUR_OrderItemProperty_CategorySpecID.IsRange
        y.ValueDataTypeID = y.FK_PUR_OrderItemProperty_CategorySpecID.ValueDataTypeID
        y.Data1Value = x.Data1Value
        y.Data2Value = x.Data2Value
        SIS.PUR.purOrderItemProperty.InsertData(y)
      Next
    End If
  End Sub
  Protected Sub FVpurOrderDetails_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurOrderDetails.DataBound
    SIS.PUR.purOrderDetails.SetDefaultValues(sender, e)
  End Sub
  Protected Sub FVpurOrderDetails_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurOrderDetails.PreRender
    Dim oF_OrderNo_Display As Label = FVpurOrderDetails.FindControl("F_OrderNo_Display")
    oF_OrderNo_Display.Text = String.Empty
    If Not Session("F_OrderNo_Display") Is Nothing Then
      If Session("F_OrderNo_Display") <> String.Empty Then
        oF_OrderNo_Display.Text = Session("F_OrderNo_Display")
      End If
    End If
    Dim oF_OrderNo As TextBox = FVpurOrderDetails.FindControl("F_OrderNo")
    oF_OrderNo.Enabled = True
    oF_OrderNo.Text = String.Empty
    If Not Session("F_OrderNo") Is Nothing Then
      If Session("F_OrderNo") <> String.Empty Then
        oF_OrderNo.Text = Session("F_OrderNo")
      End If
    End If
    Dim oF_ItemCode_Display As Label = FVpurOrderDetails.FindControl("F_ItemCode_Display")
    Dim oF_ItemCode As TextBox = FVpurOrderDetails.FindControl("F_ItemCode")
    Dim oF_UOM_Display As Label = FVpurOrderDetails.FindControl("F_UOM_Display")
    Dim oF_UOM As TextBox = FVpurOrderDetails.FindControl("F_UOM")
    Dim oF_HSNSACCode_Display As Label = FVpurOrderDetails.FindControl("F_HSNSACCode_Display")
    Dim oF_HSNSACCode As TextBox = FVpurOrderDetails.FindControl("F_HSNSACCode")
    Dim oF_ProjectID_Display As Label = FVpurOrderDetails.FindControl("F_ProjectID_Display")
    Dim oF_ProjectID As TextBox = FVpurOrderDetails.FindControl("F_ProjectID")
    Dim oF_ElementID_Display As Label = FVpurOrderDetails.FindControl("F_ElementID_Display")
    Dim oF_ElementID As TextBox = FVpurOrderDetails.FindControl("F_ElementID")
    Dim oF_EmployeeID_Display As Label = FVpurOrderDetails.FindControl("F_EmployeeID_Display")
    Dim oF_EmployeeID As TextBox = FVpurOrderDetails.FindControl("F_EmployeeID")
    Dim oF_DepartmentID_Display As Label = FVpurOrderDetails.FindControl("F_DepartmentID_Display")
    Dim oF_DepartmentID As TextBox = FVpurOrderDetails.FindControl("F_DepartmentID")
    Dim oF_CostCenterID_Display As Label = FVpurOrderDetails.FindControl("F_CostCenterID_Display")
    Dim oF_CostCenterID As TextBox = FVpurOrderDetails.FindControl("F_CostCenterID")
    Dim oF_DivisionID_Display As Label = FVpurOrderDetails.FindControl("F_DivisionID_Display")
    Dim oF_DivisionID As TextBox = FVpurOrderDetails.FindControl("F_DivisionID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purOrderDetails.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurOrderDetails") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurOrderDetails", mStr)
    End If
    If Request.QueryString("OrderNo") IsNot Nothing Then
      CType(FVpurOrderDetails.FindControl("F_OrderNo"), TextBox).Text = Request.QueryString("OrderNo")
      CType(FVpurOrderDetails.FindControl("F_OrderNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("OrderLine") IsNot Nothing Then
      CType(FVpurOrderDetails.FindControl("F_OrderLine"), TextBox).Text = Request.QueryString("OrderLine")
      CType(FVpurOrderDetails.FindControl("F_OrderLine"), TextBox).Enabled = False
    End If
    If Request.QueryString("OrderRev") IsNot Nothing Then
      CType(FVpurOrderDetails.FindControl("F_OrderRev"), TextBox).Text = Request.QueryString("OrderRev")
      CType(FVpurOrderDetails.FindControl("F_OrderRev"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function UOMCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SPMT.spmtERPUnits.SelectspmtERPUnitsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function OrderNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purOrders.SelectpurOrdersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ItemCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItems.SelectpurItemsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function HSNSACCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SPMT.spmtHSNSACCodes.SelectspmtHSNSACCodesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ElementIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakWBS.SelectpakWBSAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function EmployeeIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmEmployees.SelectqcmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function DepartmentIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmDepartments.SelectqcmDepartmentsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CostCenterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SPMT.spmtCostCenters.SelectspmtCostCentersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function DivisionIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmDivisions.SelectqcmDivisionsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PUR_OrderDetails_DepartmentID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim DepartmentID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmDepartments = SIS.QCM.qcmDepartments.qcmDepartmentsGetByID(DepartmentID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PUR_OrderDetails_DivisionID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim DivisionID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmDivisions = SIS.QCM.qcmDivisions.qcmDivisionsGetByID(DivisionID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PUR_OrderDetails_EmployeeID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim EmployeeID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmEmployees = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(EmployeeID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PUR_OrderDetails_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PUR_OrderDetails_ElementID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ElementID As String = CType(aVal(1), String)
    Dim oVar As SIS.PAK.pakWBS = SIS.PAK.pakWBS.pakWBSGetByID(ElementID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PUR_OrderDetails_ItemCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ItemCode As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.PUR.purItems = SIS.PUR.purItems.purItemsGetByID(ItemCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField & "|" & oVar.ItemDescription & "|" & oVar.UOM
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PUR_OrderDetails_UOM(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim UOM As String = CType(aVal(1), String)
    Dim oVar As SIS.SPMT.spmtERPUnits = SIS.SPMT.spmtERPUnits.spmtERPUnitsGetByID(UOM)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PUR_OrderDetails_OrderNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim OrderNo As Int32 = CType(aVal(1), Int32)
    Dim OrderRev As Int32 = CType(aVal(2), Int32)
    Dim oVar As SIS.PUR.purOrders = SIS.PUR.purOrders.purOrdersGetByID(OrderNo, OrderRev)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PUR_OrderDetails_CostCenterID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim CostCenterID As String = CType(aVal(1), String)
    Dim oVar As SIS.SPMT.spmtCostCenters = SIS.SPMT.spmtCostCenters.spmtCostCentersGetByID(CostCenterID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PUR_OrderDetails_HSNSACCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim BillType As Int32 = CType(aVal(1), Int32)
    Dim HSNSACCode As String = CType(aVal(2), String)
    Dim oVar As SIS.SPMT.spmtHSNSACCodes = SIS.SPMT.spmtHSNSACCodes.spmtHSNSACCodesGetByID(BillType, HSNSACCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  Protected Sub showhere_Click(sender As Object, e As EventArgs)
    Dim ctl As CTL_ItemCategorySpecs = CType(FVpurOrderDetails.FindControl("gvItemProperty"), CTL_ItemCategorySpecs)
    Dim ic As String = CType(FVpurOrderDetails.FindControl("F_ItemCode"), TextBox).Text
    ctl.ItemCode = ic
    ctl.UsedFor = enumUsedFor.Order
    ctl.Execute()
  End Sub

  Private Sub AF_purOrderDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim x As LC_purTaxCodes = CType(FVpurOrderDetails.FindControl("F_TaxCode"), LC_purTaxCodes)
    AddHandler x.SelectedIndexChanged, AddressOf TaxCodeChanged
  End Sub
  Protected Sub TaxCodeChanged(s As Object, e As EventArgs)
    Dim TaxCode As String = CType(s, DropDownList).SelectedValue
    Dim oOrderNo As TextBox = CType(FVpurOrderDetails.FindControl("F_OrderNo"), TextBox)
    Dim oOrderRev As TextBox = CType(FVpurOrderDetails.FindControl("F_OrderRev"), TextBox)
    Dim OrderNo As String = oOrderNo.Text
    Dim OrderRev As String = oOrderRev.Text
    Dim Order As SIS.PUR.purOrders = SIS.PUR.purOrders.purOrdersGetByID(OrderNo, OrderRev)
    Dim TaxRate As SIS.PUR.purTaxRates = SIS.PUR.purTaxRates.GetByDate(TaxCode, Order.CreatedOn)
    Dim preFix As String = oOrderNo.ClientID.Replace("OrderNo", "")
    If TaxRate IsNot Nothing Then
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "applyTax('" & New JavaScriptSerializer().Serialize(TaxRate) & "','" & preFix & "');", True)
    Else
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "applyTax('null','" & preFix & "');", True)
    End If
  End Sub

End Class
