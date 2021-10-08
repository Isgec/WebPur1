Imports System.Web.Script.Serialization
Partial Class EF_purReceiptDetails
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
  Public Property FromOrder() As Boolean
    Get
      If ViewState("FromOrder") IsNot Nothing Then
        Return CType(ViewState("FromOrder"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("FromOrder", value)
    End Set
  End Property
  Protected Sub ODSpurReceiptDetails_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurReceiptDetails.Selected
    Dim tmp As SIS.PUR.purReceiptDetails = CType(e.ReturnValue, SIS.PUR.purReceiptDetails)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
    FromOrder = tmp.FromOrder
  End Sub
  Protected Sub FVpurReceiptDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurReceiptDetails.Init
    DataClassName = "EpurReceiptDetails"
    SetFormView = FVpurReceiptDetails
  End Sub
  Protected Sub TBLpurReceiptDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurReceiptDetails.Init
    SetToolBar = TBLpurReceiptDetails
  End Sub
  Protected Sub FVpurReceiptDetails_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurReceiptDetails.PreRender
    TBLpurReceiptDetails.EnableSave = Editable
    TBLpurReceiptDetails.EnableDelete = Deleteable
    If FromOrder Then
      Dim oQty As TextBox = CType(FVpurReceiptDetails.FindControl("F_Quantity"), TextBox)
      oQty.CssClass = "dmytxt"
      oQty.Enabled = False
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purReceiptDetails.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurReceiptDetails") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurReceiptDetails", mStr)
    End If
    showhere_Click(Nothing, Nothing)
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ItemCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItems.SelectpurItemsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UOMCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SPMT.spmtERPUnits.SelectspmtERPUnitsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function HSNSACCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SPMT.spmtHSNSACCodes.SelectspmtHSNSACCodesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ElementIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakWBS.SelectpakWBSAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function EmployeeIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmEmployees.SelectqcmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DepartmentIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmDepartments.SelectqcmDepartmentsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CostCenterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SPMT.spmtCostCenters.SelectspmtCostCentersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DivisionIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmDivisions.SelectqcmDivisionsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptDetails_DepartmentID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim DepartmentID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmDepartments = SIS.QCM.qcmDepartments.qcmDepartmentsGetByID(DepartmentID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptDetails_DivisionID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim DivisionID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmDivisions = SIS.QCM.qcmDivisions.qcmDivisionsGetByID(DivisionID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptDetails_EmployeeID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim EmployeeID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmEmployees = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(EmployeeID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptDetails_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptDetails_ElementID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ElementID As String = CType(aVal(1),String)
    Dim oVar As SIS.PAK.pakWBS = SIS.PAK.pakWBS.pakWBSGetByID(ElementID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptDetails_ItemCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ItemCode As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PUR.purItems = SIS.PUR.purItems.purItemsGetByID(ItemCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField & "|" & oVar.ItemDescription & "|" & oVar.UOM
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptDetails_CostCenterID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CostCenterID As String = CType(aVal(1),String)
    Dim oVar As SIS.SPMT.spmtCostCenters = SIS.SPMT.spmtCostCenters.spmtCostCentersGetByID(CostCenterID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptDetails_UOM(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim UOM As String = CType(aVal(1),String)
    Dim oVar As SIS.SPMT.spmtERPUnits = SIS.SPMT.spmtERPUnits.spmtERPUnitsGetByID(UOM)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptDetails_HSNSACCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim BillType As Int32 = CType(aVal(1),Int32)
    Dim HSNSACCode As String = CType(aVal(2),String)
    Dim oVar As SIS.SPMT.spmtHSNSACCodes = SIS.SPMT.spmtHSNSACCodes.spmtHSNSACCodesGetByID(BillType,HSNSACCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  Protected Sub showhere_Click(sender As Object, e As EventArgs)
    Dim ctl As CTL_ItemCategorySpecs = CType(FVpurReceiptDetails.FindControl("gvItemProperty"), CTL_ItemCategorySpecs)
    Dim ic As String = CType(FVpurReceiptDetails.FindControl("F_ItemCode"), TextBox).Text
    Dim pk() As String = PrimaryKey.Split("|".ToCharArray)
    ctl.ItemCode = ic
    ctl.ReceiptNo = pk(0)
    ctl.ReceiptLine = pk(1)
    ctl.UsedFor = enumUsedFor.Receipt
    ctl.Execute()
  End Sub

  Private Sub ODSpurReceiptDetails_Updated(sender As Object, e As ObjectDataSourceStatusEventArgs) Handles ODSpurReceiptDetails.Updated
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PUR.purReceiptDetails = CType(e.ReturnValue, SIS.PUR.purReceiptDetails)
      SIS.PUR.purReceiptItemProperty.DeleteByReceiptLine(oDC.ReceiptNo, oDC.ReceiptLine)
      Dim ctl As CTL_ItemCategorySpecs = CType(FVpurReceiptDetails.FindControl("gvItemProperty"), CTL_ItemCategorySpecs)
      Dim xVal As List(Of SIS.PUR.purItemCategorySpecValues) = ctl.GetData()
      For Each x As SIS.PUR.purItemCategorySpecValues In xVal
        Dim y As New SIS.PUR.purReceiptItemProperty
        y.ReceiptNo = oDC.ReceiptNo
        y.ReceiptLine = oDC.ReceiptLine
        y.ItemCode = oDC.ItemCode
        y.ItemCategoryID = x.ItemCategoryID
        y.CategorySpecID = x.CategorySpecID
        y.SerialNo = x.SerialNo
        y.IsRange = y.FK_PUR_ReceiptItemProperty_CategorySpecID.IsRange
        y.ValueDataTypeID = y.FK_PUR_ReceiptItemProperty_CategorySpecID.ValueDataTypeID
        y.Data1Value = x.Data1Value
        y.Data2Value = x.Data2Value
        SIS.PUR.purReceiptItemProperty.InsertData(y)
      Next
    End If
  End Sub

  Private Sub EF_purReceiptDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim x As LC_purTaxCodes = CType(FVpurReceiptDetails.FindControl("F_TaxCode"), LC_purTaxCodes)
    AddHandler x.SelectedIndexChanged, AddressOf TaxCodeChanged
  End Sub
  Protected Sub TaxCodeChanged(s As Object, e As EventArgs)
    Dim TaxCode As String = CType(s, DropDownList).SelectedValue
    Dim oReceiptNo As TextBox = CType(FVpurReceiptDetails.FindControl("F_ReceiptNo"), TextBox)
    Dim ReceiptNo As String = oReceiptNo.Text
    Dim Receipt As SIS.PUR.purReceipts = SIS.PUR.purReceipts.purReceiptsGetByID(ReceiptNo)
    Dim TaxRate As SIS.PUR.purTaxRates = SIS.PUR.purTaxRates.GetByDate(TaxCode, Receipt.CreatedOn)
    Dim preFix As String = oReceiptNo.ClientID.Replace("ReceiptNo", "")
    If TaxRate IsNot Nothing Then
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "applyTax('" & New JavaScriptSerializer().Serialize(TaxRate) & "','" & preFix & "');", True)
    Else
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "applyTax('null','" & preFix & "');", True)
    End If
  End Sub

End Class
