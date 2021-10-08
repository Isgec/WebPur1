Partial Class AF_purOrders
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpurOrders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurOrders.Init
    DataClassName = "ApurOrders"
    SetFormView = FVpurOrders
  End Sub
  Protected Sub TBLpurOrders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurOrders.Init
    SetToolBar = TBLpurOrders
  End Sub
  Protected Sub ODSpurOrders_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurOrders.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PUR.purOrders = CType(e.ReturnValue,SIS.PUR.purOrders)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&OrderNo=" & oDC.OrderNo
      tmpURL &= "&OrderRev=" & oDC.OrderRev
      TBLpurOrders.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVpurOrders_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurOrders.DataBound
    SIS.PUR.purOrders.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpurOrders_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurOrders.PreRender
    Dim oF_PurchaseTypeID As LC_purPurchaseTypes = FVpurOrders.FindControl("F_PurchaseTypeID")
    oF_PurchaseTypeID.Enabled = True
    oF_PurchaseTypeID.SelectedValue = String.Empty
    If Not Session("F_PurchaseTypeID") Is Nothing Then
      If Session("F_PurchaseTypeID") <> String.Empty Then
        oF_PurchaseTypeID.SelectedValue = Session("F_PurchaseTypeID")
      End If
    End If
    Dim oF_TranTypeID As LC_spmtTranTypes = FVpurOrders.FindControl("F_TranTypeID")
    oF_TranTypeID.Enabled = True
    oF_TranTypeID.SelectedValue = String.Empty
    If Not Session("F_TranTypeID") Is Nothing Then
      If Session("F_TranTypeID") <> String.Empty Then
        oF_TranTypeID.SelectedValue = Session("F_TranTypeID")
      End If
    End If
    Dim oF_SupplierID_Display As Label  = FVpurOrders.FindControl("F_SupplierID_Display")
    oF_SupplierID_Display.Text = String.Empty
    If Not Session("F_SupplierID_Display") Is Nothing Then
      If Session("F_SupplierID_Display") <> String.Empty Then
        oF_SupplierID_Display.Text = Session("F_SupplierID_Display")
      End If
    End If
    Dim oF_SupplierID As TextBox  = FVpurOrders.FindControl("F_SupplierID")
    oF_SupplierID.Enabled = True
    oF_SupplierID.Text = String.Empty
    If Not Session("F_SupplierID") Is Nothing Then
      If Session("F_SupplierID") <> String.Empty Then
        oF_SupplierID.Text = Session("F_SupplierID")
      End If
    End If
    Dim oF_SupplierGSTIN_Display As Label  = FVpurOrders.FindControl("F_SupplierGSTIN_Display")
    Dim oF_SupplierGSTIN As TextBox  = FVpurOrders.FindControl("F_SupplierGSTIN")
    Dim oF_AprTypeID As LC_purApprovalTypes = FVpurOrders.FindControl("F_AprTypeID")
    oF_AprTypeID.Enabled = True
    oF_AprTypeID.SelectedValue = String.Empty
    If Not Session("F_AprTypeID") Is Nothing Then
      If Session("F_AprTypeID") <> String.Empty Then
        oF_AprTypeID.SelectedValue = Session("F_AprTypeID")
      End If
    End If
    Dim oF_ProjectID_Display As Label  = FVpurOrders.FindControl("F_ProjectID_Display")
    Dim oF_ProjectID As TextBox  = FVpurOrders.FindControl("F_ProjectID")
    Dim oF_ElementID_Display As Label  = FVpurOrders.FindControl("F_ElementID_Display")
    Dim oF_ElementID As TextBox  = FVpurOrders.FindControl("F_ElementID")
    Dim oF_EmployeeID_Display As Label  = FVpurOrders.FindControl("F_EmployeeID_Display")
    oF_EmployeeID_Display.Text = String.Empty
    If Not Session("F_EmployeeID_Display") Is Nothing Then
      If Session("F_EmployeeID_Display") <> String.Empty Then
        oF_EmployeeID_Display.Text = Session("F_EmployeeID_Display")
      End If
    End If
    Dim oF_EmployeeID As TextBox  = FVpurOrders.FindControl("F_EmployeeID")
    oF_EmployeeID.Enabled = True
    oF_EmployeeID.Text = String.Empty
    If Not Session("F_EmployeeID") Is Nothing Then
      If Session("F_EmployeeID") <> String.Empty Then
        oF_EmployeeID.Text = Session("F_EmployeeID")
      End If
    End If
    Dim oF_DepartmentID_Display As Label  = FVpurOrders.FindControl("F_DepartmentID_Display")
    Dim oF_DepartmentID As TextBox  = FVpurOrders.FindControl("F_DepartmentID")
    Dim oF_CostCenterID_Display As Label  = FVpurOrders.FindControl("F_CostCenterID_Display")
    Dim oF_CostCenterID As TextBox  = FVpurOrders.FindControl("F_CostCenterID")
    Dim oF_DivisionID_Display As Label  = FVpurOrders.FindControl("F_DivisionID_Display")
    Dim oF_DivisionID As TextBox  = FVpurOrders.FindControl("F_DivisionID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Create") & "/AF_purOrders.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurOrders") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurOrders", mStr)
    End If
    If Request.QueryString("OrderNo") IsNot Nothing Then
      CType(FVpurOrders.FindControl("F_OrderNo"), TextBox).Text = Request.QueryString("OrderNo")
      CType(FVpurOrders.FindControl("F_OrderNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("OrderRev") IsNot Nothing Then
      CType(FVpurOrders.FindControl("F_OrderRev"), TextBox).Text = Request.QueryString("OrderRev")
      CType(FVpurOrders.FindControl("F_OrderRev"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SPMT.spmtBusinessPartner.SelectspmtBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierGSTINCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SPMT.spmtBPGSTIN.SelectspmtBPGSTINAutoCompleteList(prefixText, count, contextKey)
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
  Public Shared Function validate_FK_PUR_Orders_DepartmentID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_Orders_DivisionID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_Orders_EmployeeID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_Orders_ProjectID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_Orders_ElementID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_Orders_CostCenterID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PUR_Orders_SupplierGSTIN(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SupplierID As String = CType(aVal(1),String)
    Dim SupplierGSTIN As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.SPMT.spmtBPGSTIN = SIS.SPMT.spmtBPGSTIN.spmtBPGSTINGetByID(SupplierID,SupplierGSTIN)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_Orders_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SupplierID As String = CType(aVal(1),String)
    Dim oVar As SIS.SPMT.spmtBusinessPartner = SIS.SPMT.spmtBusinessPartner.spmtBusinessPartnerGetByID(SupplierID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
