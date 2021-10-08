Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purReceipts
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case StatusID
        Case enumReceiptStates.UnderApproval
          mRet = Drawing.Color.Blue
        Case enumReceiptStates.IRCreated
          mRet = Drawing.Color.DarkGoldenrod
        Case enumReceiptStates.Returned
          mRet = Drawing.Color.Red
      End Select
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case enumReceiptStates.Free, enumReceiptStates.Returned
          mRet = True
      End Select
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = GetEditable()
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal ReceiptNo As Int32) As SIS.PUR.purReceipts
      Dim Results As SIS.PUR.purReceipts = purReceiptsGetByID(ReceiptNo)
      '========================
      UZ_purReceiptsDelete(Results)
      '========================
      Return Results
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal ReceiptNo As Int32) As SIS.PUR.purReceipts
      Dim Results As SIS.PUR.purReceipts = purReceiptsGetByID(ReceiptNo)
      With Results
        .StatusID = enumReceiptStates.UnderApproval
        .PostedInACBy = HttpContext.Current.Session("LoginID")
        .PostedInACOn = Now
      End With
      SIS.PUR.purReceipts.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_purReceiptsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PurchaseTypeID As String, ByVal TranTypeID As String, ByVal SupplierID As String, ByVal EmployeeID As String, ByVal CreatedBy As String, ByVal StatusID As Int32) As List(Of SIS.PUR.purReceipts)
      Dim Results As List(Of SIS.PUR.purReceipts) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ReceiptNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppur_LG_ReceiptsSelectListSearch"
            Cmd.CommandText = "sppurReceiptsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppur_LG_ReceiptsSelectListFilteres"
            Cmd.CommandText = "sppurReceiptsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PurchaseTypeID",SqlDbType.NVarChar,100, IIf(PurchaseTypeID Is Nothing, String.Empty,PurchaseTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TranTypeID",SqlDbType.NVarChar,3, IIf(TranTypeID Is Nothing, String.Empty,TranTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID",SqlDbType.NVarChar,9, IIf(SupplierID Is Nothing, String.Empty,SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID",SqlDbType.NVarChar,8, IIf(EmployeeID Is Nothing, String.Empty,EmployeeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy",SqlDbType.NVarChar,8, IIf(CreatedBy Is Nothing, String.Empty,CreatedBy))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID",SqlDbType.Int,10, IIf(StatusID = Nothing, 0,StatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purReceipts)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purReceipts(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_purReceiptsInsert(ByVal Record As SIS.PUR.purReceipts) As SIS.PUR.purReceipts
      Dim _Result As SIS.PUR.purReceipts = purReceiptsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_purReceiptsUpdate(ByVal Record As SIS.PUR.purReceipts) As SIS.PUR.purReceipts
      Dim _Result As SIS.PUR.purReceipts = purReceiptsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_purReceiptsDelete(ByVal Record As SIS.PUR.purReceipts) As Integer
      Dim CanBeDeleted As Boolean = True
      Dim ReceiptLines As List(Of SIS.PUR.purReceiptDetails) = SIS.PUR.purReceiptDetails.purReceiptDetailsSelectList(0, 9999, "", False, "", Record.ReceiptNo)
      For Each OL As SIS.PUR.purReceiptDetails In ReceiptLines
        Try
          SIS.PUR.purReceiptDetails.DeleteWF(OL.ReceiptNo, OL.ReceiptLine)
        Catch ex As Exception
          CanBeDeleted = False
        End Try
      Next
      If CanBeDeleted Then
        purReceiptsDelete(Record)
      Else
        Throw New Exception("All Receipt lines cannot be deleted.")
      End If
      Return Nothing
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      Dim OrderNo As String = "0"
      Dim OrderRev As String = "0"
      If HttpContext.Current.Request.QueryString("OrderNo") IsNot Nothing Then
        OrderNo = HttpContext.Current.Request.QueryString("OrderNo")
      End If
      If HttpContext.Current.Request.QueryString("OrderRev") IsNot Nothing Then
        OrderRev = HttpContext.Current.Request.QueryString("OrderRev")
      End If
      Dim oI As SIS.PUR.purOrders = Nothing
      If OrderNo <> "0" Then
        oI = SIS.PUR.purOrders.purOrdersGetByID(OrderNo, OrderRev)
      End If
      If oI Is Nothing Then
        oI = New SIS.PUR.purOrders
        oI.CurrencyID = "INR"
        oI.ConversionFactorINR = "1.000000"
      End If
      With sender
        Try
          CType(.FindControl("F_ReceiptNo"), TextBox).Text = "0"
          CType(.FindControl("F_PurchaseTypeID"), Object).SelectedValue = oI.PurchaseTypeID
          CType(.FindControl("F_TranTypeID"), Object).SelectedValue = oI.TranTypeID
          CType(.FindControl("F_SupplierID"), TextBox).Text = oI.SupplierID
          CType(.FindControl("F_SupplierID_Display"), Label).Text = oI.VR_BusinessPartner16_BPName
          CType(.FindControl("F_SupplierName"), TextBox).Text = oI.SupplierName
          CType(.FindControl("F_SupplierGSTIN"), TextBox).Text = oI.SupplierGSTIN
          CType(.FindControl("F_SupplierGSTIN_Display"), Label).Text = oI.VR_BPGSTIN15_Description
          CType(.FindControl("F_SupplierGSTINUMBER"), TextBox).Text = oI.SupplierGSTINUMBER
          CType(.FindControl("F_ShipToState"), Object).SelectedValue = oI.ShipToState
          CType(.FindControl("F_IsgecGSTIN"), Object).SelectedValue = oI.IsgecGSTIN
          CType(.FindControl("F_BillNumber"), TextBox).Text = ""
          CType(.FindControl("F_BillDate"), TextBox).Text = ""
          CType(.FindControl("F_BillRemarks"), TextBox).Text = ""
          CType(.FindControl("F_BillReceivedOn"), TextBox).Text = Now.ToString("dd/MM/yyyy")
          CType(.FindControl("F_ApprovedBy"), TextBox).Text = ""
          CType(.FindControl("F_ApprovedBy_Display"), Label).Text = ""
          CType(.FindControl("F_BuyerRemarks"), TextBox).Text = ""
          CType(.FindControl("F_CurrencyID"), Object).SelectedValue = oI.CurrencyID
          CType(.FindControl("F_ConversionFactorINR"), TextBox).Text = oI.ConversionFactorINR
          CType(.FindControl("F_AdvanceRate"), TextBox).Text = "0.0000"
          CType(.FindControl("F_AdvanceAmount"), TextBox).Text = "0.0000"
          CType(.FindControl("F_RetensionRate"), TextBox).Text = "0.0000"
          CType(.FindControl("F_RetensionAmount"), TextBox).Text = "0.0000"
          CType(.FindControl("F_ProjectID"), TextBox).Text = oI.ProjectID
          CType(.FindControl("F_ProjectID_Display"), Label).Text = oI.IDM_Projects6_Description
          CType(.FindControl("F_ElementID"), TextBox).Text = oI.ElementID
          CType(.FindControl("F_ElementID_Display"), Label).Text = oI.IDM_WBS7_Description
          CType(.FindControl("F_EmployeeID"), TextBox).Text = oI.EmployeeID
          CType(.FindControl("F_EmployeeID_Display"), Label).Text = oI.HRM_Employees5_EmployeeName
          CType(.FindControl("F_DepartmentID"), TextBox).Text = oI.DepartmentID
          CType(.FindControl("F_DepartmentID_Display"), Label).Text = oI.HRM_Departments3_Description
          CType(.FindControl("F_CostCenterID"), TextBox).Text = oI.CostCenterID
          CType(.FindControl("F_CostCenterID_Display"), Label).Text = oI.SPMT_CostCenters12_Description
          CType(.FindControl("F_DivisionID"), TextBox).Text = oI.DivisionID
          CType(.FindControl("F_DivisionID_Display"), Label).Text = oI.HRM_Divisions4_Description
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetSBH(ByVal Record As SIS.PUR.purReceipts) As SIS.SPMT.SpmtNewSBH
      Dim Rec As New SIS.SPMT.SpmtNewSBH
      With Rec
        .PurchaseType = Record.PurchaseTypeID
        .IRReceivedOn = Record.BillReceivedOn
        .BPID = Record.SupplierID
        .SupplierGSTINNumber = Record.SupplierGSTINUMBER
        '============================
        .OrderNo = Record.ReceiptNo
        '============================
        .TranTypeID = Record.TranTypeID
        .IsgecGSTIN = Record.IsgecGSTIN
        .SupplierGSTIN = Record.SupplierGSTIN
        .SupplierName = Record.SupplierName
        .ShipToState = Record.ShipToState
        .BillNumber = Record.BillNumber
        .BillDate = Record.BillDate
        .BillRemarks = Record.BillRemarks
        .CreatedBy = Record.CreatedBy
        .CreatedOn = Record.CreatedOn
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .EmployeeID = Record.EmployeeID
        .DepartmentID = Record.DepartmentID
        .CostCenterID = Record.CostCenterID
        .TotalBillAmount = Record.TotalBillAmount
      End With
      Return Rec
    End Function

  End Class
End Namespace
