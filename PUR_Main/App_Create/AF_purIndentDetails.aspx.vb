Imports System.Web.Script.Serialization
Partial Class AF_purIndentDetails
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurIndentDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurIndentDetails.Init
    DataClassName = "ApurIndentDetails"
    SetFormView = FVpurIndentDetails
  End Sub
  Protected Sub TBLpurIndentDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurIndentDetails.Init
    SetToolBar = TBLpurIndentDetails
  End Sub
  'Private Sub ODSpurIndentDetails_Inserting(sender As Object, e As ObjectDataSourceMethodEventArgs) Handles ODSpurIndentDetails.Inserting
  '  Dim x As SIS.PUR.purIndentDetails = CType(e.InputParameters.Values(0), SIS.PUR.purIndentDetails)
  '  x.MainLine = True
  'End Sub
  Protected Sub ODSpurIndentDetails_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurIndentDetails.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PUR.purIndentDetails = CType(e.ReturnValue, SIS.PUR.purIndentDetails)
      Dim ctl As CTL_ItemCategorySpecs = CType(FVpurIndentDetails.FindControl("gvItemProperty"), CTL_ItemCategorySpecs)
      Dim xVal As List(Of SIS.PUR.purItemCategorySpecValues) = ctl.GetData()
      For Each x As SIS.PUR.purItemCategorySpecValues In xVal
        Dim y As New SIS.PUR.purIndentItemProperty
        y.IndentNo = oDC.IndentNo
        y.IndentLine = oDC.IndentLine
        y.ItemCode = oDC.ItemCode
        y.ItemCategoryID = x.ItemCategoryID
        y.CategorySpecID = x.CategorySpecID
        y.SerialNo = x.SerialNo
        y.IsRange = y.FK_PUR_IndentItemProperty_CategorySpecID.IsRange
        y.ValueDataTypeID = y.FK_PUR_IndentItemProperty_CategorySpecID.ValueDataTypeID
        y.Data1Value = x.Data1Value
        y.Data2Value = x.Data2Value
        SIS.PUR.purIndentItemProperty.InsertData(y)
      Next
      '===================================
      'SIS.PUR.purItems.CreateProperty(oDC)
      '===================================
      'Dim tmpURL As String = "?tmp=1"
      'tmpURL &= "&IndentNo=" & oDC.IndentNo
      'tmpURL &= "&IndentLine=" & oDC.IndentLine
      'TBLpurIndentDetails.AfterInsertURL &= tmpURL
    End If
  End Sub
  Protected Sub FVpurIndentDetails_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurIndentDetails.DataBound
    SIS.PUR.purIndentDetails.SetDefaultValues(sender, e)
  End Sub
  Protected Sub FVpurIndentDetails_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurIndentDetails.PreRender
    Dim oF_IndentNo_Display As Label = FVpurIndentDetails.FindControl("F_IndentNo_Display")
    oF_IndentNo_Display.Text = String.Empty
    If Not Session("F_IndentNo_Display") Is Nothing Then
      If Session("F_IndentNo_Display") <> String.Empty Then
        oF_IndentNo_Display.Text = Session("F_IndentNo_Display")
      End If
    End If
    Dim oF_IndentNo As TextBox = FVpurIndentDetails.FindControl("F_IndentNo")
    oF_IndentNo.Enabled = True
    oF_IndentNo.Text = String.Empty
    If Not Session("F_IndentNo") Is Nothing Then
      If Session("F_IndentNo") <> String.Empty Then
        oF_IndentNo.Text = Session("F_IndentNo")
      End If
    End If
    Dim oF_ItemCode_Display As Label = FVpurIndentDetails.FindControl("F_ItemCode_Display")
    Dim oF_ItemCode As TextBox = FVpurIndentDetails.FindControl("F_ItemCode")
    Dim oF_UOM_Display As Label = FVpurIndentDetails.FindControl("F_UOM_Display")
    Dim oF_UOM As TextBox = FVpurIndentDetails.FindControl("F_UOM")
    Dim oF_HSNSACCode_Display As Label = FVpurIndentDetails.FindControl("F_HSNSACCode_Display")
    Dim oF_HSNSACCode As TextBox = FVpurIndentDetails.FindControl("F_HSNSACCode")
    Dim oF_ProjectID_Display As Label = FVpurIndentDetails.FindControl("F_ProjectID_Display")
    Dim oF_ProjectID As TextBox = FVpurIndentDetails.FindControl("F_ProjectID")
    Dim oF_ElementID_Display As Label = FVpurIndentDetails.FindControl("F_ElementID_Display")
    Dim oF_ElementID As TextBox = FVpurIndentDetails.FindControl("F_ElementID")
    Dim oF_EmployeeID_Display As Label = FVpurIndentDetails.FindControl("F_EmployeeID_Display")
    Dim oF_EmployeeID As TextBox = FVpurIndentDetails.FindControl("F_EmployeeID")
    Dim oF_DepartmentID_Display As Label = FVpurIndentDetails.FindControl("F_DepartmentID_Display")
    Dim oF_DepartmentID As TextBox = FVpurIndentDetails.FindControl("F_DepartmentID")
    Dim oF_CostCenterID_Display As Label = FVpurIndentDetails.FindControl("F_CostCenterID_Display")
    Dim oF_CostCenterID As TextBox = FVpurIndentDetails.FindControl("F_CostCenterID")
    Dim oF_DivisionID_Display As Label = FVpurIndentDetails.FindControl("F_DivisionID_Display")
    Dim oF_DivisionID As TextBox = FVpurIndentDetails.FindControl("F_DivisionID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purIndentDetails.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurIndentDetails") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurIndentDetails", mStr)
    End If
    If Request.QueryString("IndentNo") IsNot Nothing Then
      CType(FVpurIndentDetails.FindControl("F_IndentNo"), TextBox).Text = Request.QueryString("IndentNo")
      CType(FVpurIndentDetails.FindControl("F_IndentNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("IndentLine") IsNot Nothing Then
      CType(FVpurIndentDetails.FindControl("F_IndentLine"), TextBox).Text = Request.QueryString("IndentLine")
      CType(FVpurIndentDetails.FindControl("F_IndentLine"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function IndentNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purIndents.SelectpurIndentsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ItemCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItems.SelectpurItemsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function UOMCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SPMT.spmtERPUnits.SelectspmtERPUnitsAutoCompleteList(prefixText, count, contextKey)
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
  Public Shared Function validate_FK_PUR_IndentDetails_DepartmentID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_IndentDetails_DivisionID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_IndentDetails_EmployeeID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_IndentDetails_ProjectID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_IndentDetails_ElementID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_IndentDetails_IndentNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim IndentNo As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.PUR.purIndents = SIS.PUR.purIndents.purIndentsGetByID(IndentNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PUR_IndentDetails_ItemCode(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_IndentDetails_CostCenterID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_IndentDetails_UOM(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_IndentDetails_HSNSACCode(ByVal value As String) As String
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
    Dim ctl As CTL_ItemCategorySpecs = CType(FVpurIndentDetails.FindControl("gvItemProperty"), CTL_ItemCategorySpecs)
    Dim ic As String = CType(FVpurIndentDetails.FindControl("F_ItemCode"), TextBox).Text
    ctl.ItemCode = ic
    ctl.UsedFor = enumUsedFor.Indent
    ctl.Execute()
  End Sub

  Private Sub AF_purIndentDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim x As LC_purTaxCodes = CType(FVpurIndentDetails.FindControl("F_TaxCode"), LC_purTaxCodes)
    AddHandler x.SelectedIndexChanged, AddressOf TaxCodeChanged
  End Sub
  Protected Sub TaxCodeChanged(s As Object, e As EventArgs)
    Dim TaxCode As String = CType(s, DropDownList).SelectedValue
    Dim oIndentNo As TextBox = CType(FVpurIndentDetails.FindControl("F_IndentNo"), TextBox)
    Dim IndentNo As String = oIndentNo.Text
    Dim Indent As SIS.PUR.purIndents = SIS.PUR.purIndents.purIndentsGetByID(IndentNo)
    Dim TaxRate As SIS.PUR.purTaxRates = SIS.PUR.purTaxRates.GetByDate(TaxCode, Indent.CreatedOn)
    Dim preFix As String = oIndentNo.ClientID.Replace("IndentNo", "")
    If TaxRate IsNot Nothing Then
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "applyTax('" & New JavaScriptSerializer().Serialize(TaxRate) & "','" & preFix & "');", True)
    Else
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "applyTax('null','" & preFix & "');", True)
    End If
  End Sub

End Class
