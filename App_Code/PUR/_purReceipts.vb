Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purReceipts
    Private Shared _RecordCount As Integer
    Public Property ReceiptNo As Int32 = 0
    Public Property PurchaseTypeID As String = ""
    Public Property TranTypeID As String = ""
    Public Property SupplierID As String = ""
    Public Property SupplierName As String = ""
    Public Property SupplierGSTIN As String = ""
    Public Property SupplierGSTINUMBER As String = ""
    Public Property ShipToState As String = ""
    Public Property IsgecGSTIN As String = ""
    Public Property BillNumber As String = ""
    Private _BillDate As String = ""
    Public Property BillRemarks As String = ""
    Private _BillReceivedOn As String = ""
    Public Property ApprovedBy As String = ""
    Public Property BuyerRemarks As String = ""
    Public Property CurrencyID As String = ""
    Public Property ConversionFactorINR As String = "0.00"
    Public Property AdvanceRate As String = "0.00"
    Public Property AdvanceAmount As String = "0.00"
    Public Property RetensionRate As String = "0.00"
    Public Property RetensionAmount As String = "0.00"
    Public Property ProjectID As String = ""
    Public Property ElementID As String = ""
    Public Property EmployeeID As String = ""
    Public Property DepartmentID As String = ""
    Public Property CostCenterID As String = ""
    Public Property DivisionID As String = ""
    Public Property TotalBillAmount As String = "0.00"
    Public Property CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Public Property ApproverRemarks As String = ""
    Private _ApprovedOn As String = ""
    Public Property ReceivedInACBy As String = ""
    Private _ReceivedInACOn As String = ""
    Public Property PostedInACBy As String = ""
    Private _PostedInACOn As String = ""
    Public Property LockedInACBy As String = ""
    Private _LockedInACOn As String = ""
    Public Property VoucherType As String = ""
    Public Property VoucherNo As String = ""
    Public Property ERPCompany As String = ""
    Public Property AccountsRemarks As String = ""
    Private _ReceiptDate As String = ""
    Public Property StatusID As String = ""
    Public Property IRNO As String = ""
    Public Property IsgecGSTINAddress As String = ""
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property aspnet_Users2_UserFullName As String = ""
    Public Property aspnet_Users3_UserFullName As String = ""
    Public Property aspnet_Users4_UserFullName As String = ""
    Public Property aspnet_Users5_UserFullName As String = ""
    Public Property HRM_Departments6_Description As String = ""
    Public Property HRM_Divisions7_Description As String = ""
    Public Property HRM_Employees8_EmployeeName As String = ""
    Public Property IDM_Projects9_Description As String = ""
    Public Property IDM_WBS10_Description As String = ""
    Public Property PUR_Currencies11_CurrencyName As String = ""
    Public Property PUR_ReceiptStatus12_Description As String = ""
    Public Property PUR_PurchaseTypes13_Description As String = ""
    Public Property SPMT_CostCenters14_Description As String = ""
    Public Property SPMT_ERPStates15_Description As String = ""
    Public Property SPMT_IsgecGSTIN16_Description As String = ""
    Public Property SPMT_TranTypes17_Description As String = ""
    Public Property VR_BPGSTIN18_Description As String = ""
    Public Property VR_BusinessPartner19_BPName As String = ""
    Private _FK_PUR_Receipts_ApprovedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PUR_Receipts_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PUR_Receipts_ReceivedInACBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PUR_Receipts_PostedInACBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PUR_Receipts_LockedInACBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PUR_Receipts_DepartmentID As SIS.QCM.qcmDepartments = Nothing
    Private _FK_PUR_Receipts_DivisionID As SIS.QCM.qcmDivisions = Nothing
    Private _FK_PUR_Receipts_EmployeeID As SIS.QCM.qcmEmployees = Nothing
    Private _FK_PUR_Receipts_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_PUR_Receipts_ElementID As SIS.PAK.pakWBS = Nothing
    Private _FK_PUR_Receipts_CurrencyID As SIS.PUR.purCurrencies = Nothing
    Private _FK_PUR_Receipts_StatusID As SIS.PUR.purReceiptStatus = Nothing
    Private _FK_PUR_Receipts_PurchaseTypeID As SIS.PUR.purPurchaseTypes = Nothing
    Private _FK_PUR_Receipts_CostCenterID As SIS.SPMT.spmtCostCenters = Nothing
    Private _FK_PUR_Receipts_ShipToState As SIS.SPMT.spmtERPStates = Nothing
    Private _FK_PUR_Receipts_IsgecGSTIN As SIS.SPMT.spmtIsgecGSTIN = Nothing
    Private _FK_PUR_Receipts_TranTypeID As SIS.SPMT.spmtTranTypes = Nothing
    Private _FK_PUR_Receipts_SupplierGSTIN As SIS.SPMT.spmtBPGSTIN = Nothing
    Private _FK_PUR_Receipts_SupplierID As SIS.SPMT.spmtBusinessPartner = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property BillDate() As String
      Get
        If Not _BillDate = String.Empty Then
          Return Convert.ToDateTime(_BillDate).ToString("dd/MM/yyyy")
        End If
        Return _BillDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BillDate = ""
         Else
           _BillDate = value
         End If
      End Set
    End Property
    Public Property BillReceivedOn() As String
      Get
        If Not _BillReceivedOn = String.Empty Then
          Return Convert.ToDateTime(_BillReceivedOn).ToString("dd/MM/yyyy")
        End If
        Return _BillReceivedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BillReceivedOn = ""
         Else
           _BillReceivedOn = value
         End If
      End Set
    End Property
    Public Property CreatedOn() As String
      Get
        If Not _CreatedOn = String.Empty Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy")
        End If
        Return _CreatedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CreatedOn = ""
         Else
           _CreatedOn = value
         End If
      End Set
    End Property
    Public Property ApprovedOn() As String
      Get
        If Not _ApprovedOn = String.Empty Then
          Return Convert.ToDateTime(_ApprovedOn).ToString("dd/MM/yyyy")
        End If
        Return _ApprovedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovedOn = ""
         Else
           _ApprovedOn = value
         End If
      End Set
    End Property
    Public Property ReceivedInACOn() As String
      Get
        If Not _ReceivedInACOn = String.Empty Then
          Return Convert.ToDateTime(_ReceivedInACOn).ToString("dd/MM/yyyy")
        End If
        Return _ReceivedInACOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReceivedInACOn = ""
         Else
           _ReceivedInACOn = value
         End If
      End Set
    End Property
    Public Property PostedInACOn() As String
      Get
        If Not _PostedInACOn = String.Empty Then
          Return Convert.ToDateTime(_PostedInACOn).ToString("dd/MM/yyyy")
        End If
        Return _PostedInACOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PostedInACOn = ""
         Else
           _PostedInACOn = value
         End If
      End Set
    End Property
    Public Property LockedInACOn() As String
      Get
        If Not _LockedInACOn = String.Empty Then
          Return Convert.ToDateTime(_LockedInACOn).ToString("dd/MM/yyyy")
        End If
        Return _LockedInACOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _LockedInACOn = ""
         Else
           _LockedInACOn = value
         End If
      End Set
    End Property
    Public Property ReceiptDate() As String
      Get
        If Not _ReceiptDate = String.Empty Then
          Return Convert.ToDateTime(_ReceiptDate).ToString("dd/MM/yyyy")
        End If
        Return _ReceiptDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReceiptDate = ""
         Else
           _ReceiptDate = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _IsgecGSTIN.ToString.PadRight(10, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ReceiptNo
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKpurReceipts
      Private _ReceiptNo As Int32 = 0
      Public Property ReceiptNo() As Int32
        Get
          Return _ReceiptNo
        End Get
        Set(ByVal value As Int32)
          _ReceiptNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PUR_Receipts_ApprovedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PUR_Receipts_ApprovedBy Is Nothing Then
          _FK_PUR_Receipts_ApprovedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ApprovedBy)
        End If
        Return _FK_PUR_Receipts_ApprovedBy
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PUR_Receipts_CreatedBy Is Nothing Then
          _FK_PUR_Receipts_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_PUR_Receipts_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_ReceivedInACBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PUR_Receipts_ReceivedInACBy Is Nothing Then
          _FK_PUR_Receipts_ReceivedInACBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ReceivedInACBy)
        End If
        Return _FK_PUR_Receipts_ReceivedInACBy
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_PostedInACBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PUR_Receipts_PostedInACBy Is Nothing Then
          _FK_PUR_Receipts_PostedInACBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_PostedInACBy)
        End If
        Return _FK_PUR_Receipts_PostedInACBy
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_LockedInACBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PUR_Receipts_LockedInACBy Is Nothing Then
          _FK_PUR_Receipts_LockedInACBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_LockedInACBy)
        End If
        Return _FK_PUR_Receipts_LockedInACBy
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_DepartmentID() As SIS.QCM.qcmDepartments
      Get
        If _FK_PUR_Receipts_DepartmentID Is Nothing Then
          _FK_PUR_Receipts_DepartmentID = SIS.QCM.qcmDepartments.qcmDepartmentsGetByID(_DepartmentID)
        End If
        Return _FK_PUR_Receipts_DepartmentID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_DivisionID() As SIS.QCM.qcmDivisions
      Get
        If _FK_PUR_Receipts_DivisionID Is Nothing Then
          _FK_PUR_Receipts_DivisionID = SIS.QCM.qcmDivisions.qcmDivisionsGetByID(_DivisionID)
        End If
        Return _FK_PUR_Receipts_DivisionID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_EmployeeID() As SIS.QCM.qcmEmployees
      Get
        If _FK_PUR_Receipts_EmployeeID Is Nothing Then
          _FK_PUR_Receipts_EmployeeID = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(_EmployeeID)
        End If
        Return _FK_PUR_Receipts_EmployeeID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_PUR_Receipts_ProjectID Is Nothing Then
          _FK_PUR_Receipts_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_PUR_Receipts_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_ElementID() As SIS.PAK.pakWBS
      Get
        If _FK_PUR_Receipts_ElementID Is Nothing Then
          _FK_PUR_Receipts_ElementID = SIS.PAK.pakWBS.pakWBSGetByID(_ElementID)
        End If
        Return _FK_PUR_Receipts_ElementID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_CurrencyID() As SIS.PUR.purCurrencies
      Get
        If _FK_PUR_Receipts_CurrencyID Is Nothing Then
          _FK_PUR_Receipts_CurrencyID = SIS.PUR.purCurrencies.purCurrenciesGetByID(_CurrencyID)
        End If
        Return _FK_PUR_Receipts_CurrencyID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_StatusID() As SIS.PUR.purReceiptStatus
      Get
        If _FK_PUR_Receipts_StatusID Is Nothing Then
          _FK_PUR_Receipts_StatusID = SIS.PUR.purReceiptStatus.purReceiptStatusGetByID(_StatusID)
        End If
        Return _FK_PUR_Receipts_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_PurchaseTypeID() As SIS.PUR.purPurchaseTypes
      Get
        If _FK_PUR_Receipts_PurchaseTypeID Is Nothing Then
          _FK_PUR_Receipts_PurchaseTypeID = SIS.PUR.purPurchaseTypes.purPurchaseTypesGetByID(_PurchaseTypeID)
        End If
        Return _FK_PUR_Receipts_PurchaseTypeID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_CostCenterID() As SIS.SPMT.spmtCostCenters
      Get
        If _FK_PUR_Receipts_CostCenterID Is Nothing Then
          _FK_PUR_Receipts_CostCenterID = SIS.SPMT.spmtCostCenters.spmtCostCentersGetByID(_CostCenterID)
        End If
        Return _FK_PUR_Receipts_CostCenterID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_ShipToState() As SIS.SPMT.spmtERPStates
      Get
        If _FK_PUR_Receipts_ShipToState Is Nothing Then
          _FK_PUR_Receipts_ShipToState = SIS.SPMT.spmtERPStates.spmtERPStatesGetByID(_ShipToState)
        End If
        Return _FK_PUR_Receipts_ShipToState
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_IsgecGSTIN() As SIS.SPMT.spmtIsgecGSTIN
      Get
        If _FK_PUR_Receipts_IsgecGSTIN Is Nothing Then
          _FK_PUR_Receipts_IsgecGSTIN = SIS.SPMT.spmtIsgecGSTIN.spmtIsgecGSTINGetByID(_IsgecGSTIN)
        End If
        Return _FK_PUR_Receipts_IsgecGSTIN
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_TranTypeID() As SIS.SPMT.spmtTranTypes
      Get
        If _FK_PUR_Receipts_TranTypeID Is Nothing Then
          _FK_PUR_Receipts_TranTypeID = SIS.SPMT.spmtTranTypes.spmtTranTypesGetByID(_TranTypeID)
        End If
        Return _FK_PUR_Receipts_TranTypeID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_SupplierGSTIN() As SIS.SPMT.spmtBPGSTIN
      Get
        If _FK_PUR_Receipts_SupplierGSTIN Is Nothing Then
          _FK_PUR_Receipts_SupplierGSTIN = SIS.SPMT.spmtBPGSTIN.spmtBPGSTINGetByID(_SupplierID, _SupplierGSTIN)
        End If
        Return _FK_PUR_Receipts_SupplierGSTIN
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Receipts_SupplierID() As SIS.SPMT.spmtBusinessPartner
      Get
        If _FK_PUR_Receipts_SupplierID Is Nothing Then
          _FK_PUR_Receipts_SupplierID = SIS.SPMT.spmtBusinessPartner.spmtBusinessPartnerGetByID(_SupplierID)
        End If
        Return _FK_PUR_Receipts_SupplierID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purReceiptsSelectList(ByVal OrderBy As String) As List(Of SIS.PUR.purReceipts)
      Dim Results As List(Of SIS.PUR.purReceipts) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ReceiptNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptsSelectList"
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purReceiptsGetNewRecord() As SIS.PUR.purReceipts
      Return New SIS.PUR.purReceipts()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purReceiptsGetByID(ByVal ReceiptNo As Int32) As SIS.PUR.purReceipts
      Dim Results As SIS.PUR.purReceipts = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo",SqlDbType.Int,ReceiptNo.ToString.Length, ReceiptNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purReceipts(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purReceiptsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PurchaseTypeID As String, ByVal TranTypeID As String, ByVal SupplierID As String, ByVal EmployeeID As String, ByVal CreatedBy As String, ByVal StatusID As Int32) As List(Of SIS.PUR.purReceipts)
      Dim Results As List(Of SIS.PUR.purReceipts) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ReceiptNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurReceiptsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
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
    Public Shared Function purReceiptsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PurchaseTypeID As String, ByVal TranTypeID As String, ByVal SupplierID As String, ByVal EmployeeID As String, ByVal CreatedBy As String, ByVal StatusID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purReceiptsGetByID(ByVal ReceiptNo As Int32, ByVal Filter_PurchaseTypeID As String, ByVal Filter_TranTypeID As String, ByVal Filter_SupplierID As String, ByVal Filter_EmployeeID As String, ByVal Filter_CreatedBy As String, ByVal Filter_StatusID As Int32) As SIS.PUR.purReceipts
      Return purReceiptsGetByID(ReceiptNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purReceiptsInsert(ByVal Record As SIS.PUR.purReceipts) As SIS.PUR.purReceipts
      Dim _Rec As SIS.PUR.purReceipts = SIS.PUR.purReceipts.purReceiptsGetNewRecord()
      With _Rec
        .PurchaseTypeID = Record.PurchaseTypeID
        .TranTypeID = Record.TranTypeID
        .SupplierID = Record.SupplierID
        .SupplierName = Record.SupplierName
        .SupplierGSTIN = Record.SupplierGSTIN
        .SupplierGSTINUMBER = Record.SupplierGSTINUMBER
        .ShipToState = Record.ShipToState
        .IsgecGSTIN = Record.IsgecGSTIN
        .BillNumber = Record.BillNumber
        .BillDate = Record.BillDate
        .BillRemarks = Record.BillRemarks
        .BillReceivedOn = Record.BillReceivedOn
        .ApprovedBy = Record.ApprovedBy
        .BuyerRemarks = Record.BuyerRemarks
        .CurrencyID = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .AdvanceRate = Record.AdvanceRate
        .AdvanceAmount = Record.AdvanceAmount
        .RetensionRate = Record.RetensionRate
        .RetensionAmount = Record.RetensionAmount
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .EmployeeID = Record.EmployeeID
        .DepartmentID = Record.DepartmentID
        .CostCenterID = Record.CostCenterID
        .DivisionID = Record.DivisionID
        .TotalBillAmount = Record.TotalBillAmount
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .ApproverRemarks = Record.ApproverRemarks
        .ApprovedOn = Record.ApprovedOn
        .ReceivedInACBy = Record.ReceivedInACBy
        .ReceivedInACOn = Record.ReceivedInACOn
        .PostedInACBy = Record.PostedInACBy
        .PostedInACOn = Record.PostedInACOn
        .LockedInACBy = Record.LockedInACBy
        .LockedInACOn = Record.LockedInACOn
        .VoucherType = Record.VoucherType
        .VoucherNo = Record.VoucherNo
        .ERPCompany = Record.ERPCompany
        .AccountsRemarks = Record.AccountsRemarks
        .ReceiptDate = Now
        .StatusID = enumReceiptStates.Free
        .IsgecGSTINAddress = Record.IsgecGSTINAddress
      End With
      Return SIS.PUR.purReceipts.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purReceipts) As SIS.PUR.purReceipts
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PurchaseTypeID",SqlDbType.NVarChar,101, Iif(Record.PurchaseTypeID= "" ,Convert.DBNull, Record.PurchaseTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranTypeID",SqlDbType.NVarChar,4, Iif(Record.TranTypeID= "" ,Convert.DBNull, Record.TranTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.NVarChar,51, Iif(Record.SupplierName= "" ,Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTIN",SqlDbType.Int,11, Iif(Record.SupplierGSTIN= "" ,Convert.DBNull, Record.SupplierGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTINUMBER",SqlDbType.NVarChar,51, Iif(Record.SupplierGSTINUMBER= "" ,Convert.DBNull, Record.SupplierGSTINUMBER))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShipToState",SqlDbType.NVarChar,3, Iif(Record.ShipToState= "" ,Convert.DBNull, Record.ShipToState))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTIN",SqlDbType.Int,11, Iif(Record.IsgecGSTIN= "" ,Convert.DBNull, Record.IsgecGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillNumber",SqlDbType.NVarChar,51, Iif(Record.BillNumber= "" ,Convert.DBNull, Record.BillNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillDate",SqlDbType.DateTime,21, Iif(Record.BillDate= "" ,Convert.DBNull, Record.BillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillRemarks",SqlDbType.NVarChar,501, Iif(Record.BillRemarks= "" ,Convert.DBNull, Record.BillRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillReceivedOn",SqlDbType.DateTime,21, Iif(Record.BillReceivedOn= "" ,Convert.DBNull, Record.BillReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerRemarks",SqlDbType.NVarChar,501, Iif(Record.BuyerRemarks= "" ,Convert.DBNull, Record.BuyerRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,11, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,25, Iif(Record.ConversionFactorINR= "" ,Convert.DBNull, Record.ConversionFactorINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceRate",SqlDbType.Decimal,23, Iif(Record.AdvanceRate= "" ,Convert.DBNull, Record.AdvanceRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceAmount",SqlDbType.Decimal,23, Iif(Record.AdvanceAmount= "" ,Convert.DBNull, Record.AdvanceAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RetensionRate",SqlDbType.Decimal,23, Iif(Record.RetensionRate= "" ,Convert.DBNull, Record.RetensionRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RetensionAmount",SqlDbType.Decimal,23, Iif(Record.RetensionAmount= "" ,Convert.DBNull, Record.RetensionAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Iif(Record.EmployeeID= "" ,Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Iif(Record.DepartmentID= "" ,Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalBillAmount",SqlDbType.Decimal,23, Iif(Record.TotalBillAmount= "" ,Convert.DBNull, Record.TotalBillAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,201, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedInACBy",SqlDbType.NVarChar,9, Iif(Record.ReceivedInACBy= "" ,Convert.DBNull, Record.ReceivedInACBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedInACOn",SqlDbType.DateTime,21, Iif(Record.ReceivedInACOn= "" ,Convert.DBNull, Record.ReceivedInACOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedInACBy",SqlDbType.NVarChar,9, Iif(Record.PostedInACBy= "" ,Convert.DBNull, Record.PostedInACBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedInACOn",SqlDbType.DateTime,21, Iif(Record.PostedInACOn= "" ,Convert.DBNull, Record.PostedInACOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockedInACBy",SqlDbType.NVarChar,9, Iif(Record.LockedInACBy= "" ,Convert.DBNull, Record.LockedInACBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockedInACOn",SqlDbType.DateTime,21, Iif(Record.LockedInACOn= "" ,Convert.DBNull, Record.LockedInACOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoucherType",SqlDbType.NVarChar,4, Iif(Record.VoucherType= "" ,Convert.DBNull, Record.VoucherType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoucherNo",SqlDbType.NVarChar,11, Iif(Record.VoucherNo= "" ,Convert.DBNull, Record.VoucherNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPCompany",SqlDbType.NVarChar,4, Iif(Record.ERPCompany= "" ,Convert.DBNull, Record.ERPCompany))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AccountsRemarks",SqlDbType.NVarChar,101, Iif(Record.AccountsRemarks= "" ,Convert.DBNull, Record.AccountsRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptDate",SqlDbType.DateTime,21, Iif(Record.ReceiptDate= "" ,Convert.DBNull, Record.ReceiptDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTINAddress",SqlDbType.NVarChar,501, Iif(Record.IsgecGSTINAddress= "" ,Convert.DBNull, Record.IsgecGSTINAddress))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo", SqlDbType.Int, 11, IIf(Record.IRNO = "", Convert.DBNull, Record.IRNO))
          Cmd.Parameters.Add("@Return_ReceiptNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ReceiptNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ReceiptNo = Cmd.Parameters("@Return_ReceiptNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purReceiptsUpdate(ByVal Record As SIS.PUR.purReceipts) As SIS.PUR.purReceipts
      Dim _Rec As SIS.PUR.purReceipts = SIS.PUR.purReceipts.purReceiptsGetByID(Record.ReceiptNo)
      With _Rec
        .PurchaseTypeID = Record.PurchaseTypeID
        .TranTypeID = Record.TranTypeID
        .SupplierID = Record.SupplierID
        .SupplierName = Record.SupplierName
        .SupplierGSTIN = Record.SupplierGSTIN
        .SupplierGSTINUMBER = Record.SupplierGSTINUMBER
        .ShipToState = Record.ShipToState
        .IsgecGSTIN = Record.IsgecGSTIN
        .BillNumber = Record.BillNumber
        .BillDate = Record.BillDate
        .BillRemarks = Record.BillRemarks
        .BillReceivedOn = Record.BillReceivedOn
        .ApprovedBy = Record.ApprovedBy
        .BuyerRemarks = Record.BuyerRemarks
        .CurrencyID = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .AdvanceRate = Record.AdvanceRate
        .AdvanceAmount = Record.AdvanceAmount
        .RetensionRate = Record.RetensionRate
        .RetensionAmount = Record.RetensionAmount
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .EmployeeID = Record.EmployeeID
        .DepartmentID = Record.DepartmentID
        .CostCenterID = Record.CostCenterID
        .DivisionID = Record.DivisionID
        .TotalBillAmount = Record.TotalBillAmount
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .ApproverRemarks = Record.ApproverRemarks
        .ApprovedOn = Record.ApprovedOn
        .ReceivedInACBy = Record.ReceivedInACBy
        .ReceivedInACOn = Record.ReceivedInACOn
        .PostedInACBy = Record.PostedInACBy
        .PostedInACOn = Record.PostedInACOn
        .LockedInACBy = Record.LockedInACBy
        .LockedInACOn = Record.LockedInACOn
        .VoucherType = Record.VoucherType
        .VoucherNo = Record.VoucherNo
        .ERPCompany = Record.ERPCompany
        .AccountsRemarks = Record.AccountsRemarks
        .ReceiptDate = Record.ReceiptDate
        .StatusID = Record.StatusID
        .IsgecGSTINAddress = Record.IsgecGSTINAddress
      End With
      Return SIS.PUR.purReceipts.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purReceipts) As SIS.PUR.purReceipts
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ReceiptNo",SqlDbType.Int,11, Record.ReceiptNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PurchaseTypeID",SqlDbType.NVarChar,101, Iif(Record.PurchaseTypeID= "" ,Convert.DBNull, Record.PurchaseTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranTypeID",SqlDbType.NVarChar,4, Iif(Record.TranTypeID= "" ,Convert.DBNull, Record.TranTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.NVarChar,51, Iif(Record.SupplierName= "" ,Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTIN",SqlDbType.Int,11, Iif(Record.SupplierGSTIN= "" ,Convert.DBNull, Record.SupplierGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTINUMBER",SqlDbType.NVarChar,51, Iif(Record.SupplierGSTINUMBER= "" ,Convert.DBNull, Record.SupplierGSTINUMBER))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShipToState",SqlDbType.NVarChar,3, Iif(Record.ShipToState= "" ,Convert.DBNull, Record.ShipToState))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTIN",SqlDbType.Int,11, Iif(Record.IsgecGSTIN= "" ,Convert.DBNull, Record.IsgecGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillNumber",SqlDbType.NVarChar,51, Iif(Record.BillNumber= "" ,Convert.DBNull, Record.BillNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillDate",SqlDbType.DateTime,21, Iif(Record.BillDate= "" ,Convert.DBNull, Record.BillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillRemarks",SqlDbType.NVarChar,501, Iif(Record.BillRemarks= "" ,Convert.DBNull, Record.BillRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillReceivedOn",SqlDbType.DateTime,21, Iif(Record.BillReceivedOn= "" ,Convert.DBNull, Record.BillReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerRemarks",SqlDbType.NVarChar,501, Iif(Record.BuyerRemarks= "" ,Convert.DBNull, Record.BuyerRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,11, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,25, Iif(Record.ConversionFactorINR= "" ,Convert.DBNull, Record.ConversionFactorINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceRate",SqlDbType.Decimal,23, Iif(Record.AdvanceRate= "" ,Convert.DBNull, Record.AdvanceRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceAmount",SqlDbType.Decimal,23, Iif(Record.AdvanceAmount= "" ,Convert.DBNull, Record.AdvanceAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RetensionRate",SqlDbType.Decimal,23, Iif(Record.RetensionRate= "" ,Convert.DBNull, Record.RetensionRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RetensionAmount",SqlDbType.Decimal,23, Iif(Record.RetensionAmount= "" ,Convert.DBNull, Record.RetensionAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Iif(Record.EmployeeID= "" ,Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Iif(Record.DepartmentID= "" ,Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalBillAmount",SqlDbType.Decimal,23, Iif(Record.TotalBillAmount= "" ,Convert.DBNull, Record.TotalBillAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,201, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedInACBy",SqlDbType.NVarChar,9, Iif(Record.ReceivedInACBy= "" ,Convert.DBNull, Record.ReceivedInACBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedInACOn",SqlDbType.DateTime,21, Iif(Record.ReceivedInACOn= "" ,Convert.DBNull, Record.ReceivedInACOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedInACBy",SqlDbType.NVarChar,9, Iif(Record.PostedInACBy= "" ,Convert.DBNull, Record.PostedInACBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedInACOn",SqlDbType.DateTime,21, Iif(Record.PostedInACOn= "" ,Convert.DBNull, Record.PostedInACOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockedInACBy",SqlDbType.NVarChar,9, Iif(Record.LockedInACBy= "" ,Convert.DBNull, Record.LockedInACBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockedInACOn",SqlDbType.DateTime,21, Iif(Record.LockedInACOn= "" ,Convert.DBNull, Record.LockedInACOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoucherType",SqlDbType.NVarChar,4, Iif(Record.VoucherType= "" ,Convert.DBNull, Record.VoucherType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoucherNo",SqlDbType.NVarChar,11, Iif(Record.VoucherNo= "" ,Convert.DBNull, Record.VoucherNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPCompany",SqlDbType.NVarChar,4, Iif(Record.ERPCompany= "" ,Convert.DBNull, Record.ERPCompany))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AccountsRemarks",SqlDbType.NVarChar,101, Iif(Record.AccountsRemarks= "" ,Convert.DBNull, Record.AccountsRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptDate",SqlDbType.DateTime,21, Iif(Record.ReceiptDate= "" ,Convert.DBNull, Record.ReceiptDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTINAddress",SqlDbType.NVarChar,501, Iif(Record.IsgecGSTINAddress= "" ,Convert.DBNull, Record.IsgecGSTINAddress))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo", SqlDbType.Int, 11, IIf(Record.IRNO = "", Convert.DBNull, Record.IRNO))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function purReceiptsDelete(ByVal Record As SIS.PUR.purReceipts) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ReceiptNo",SqlDbType.Int,Record.ReceiptNo.ToString.Length, Record.ReceiptNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
'    Autocomplete Method
    Public Shared Function SelectpurReceiptsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(10, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PUR.purReceipts = New SIS.PUR.purReceipts(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
