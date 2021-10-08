Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purOrders
    Private Shared _RecordCount As Integer
    Public Property OrderNo As Int32 = 0
    Public Property OrderRev As Int32 = 0
    Public Property PurchaseTypeID As String = ""
    Public Property TranTypeID As String = ""
    Public Property IsgecGSTIN As String = ""
    Public Property IsgecGSTINAddress As String = ""
    Public Property DestinationAddress As String = ""
    Public Property SupplierID As String = ""
    Public Property SupplierGSTIN As String = ""
    Public Property SupplierName As String = ""
    Public Property SupplierGSTINUMBER As String = ""
    Public Property PaymentTerms As String = ""
    Public Property DeliveryTerms As String = ""
    Public Property InsuranceDetails As String = ""
    Public Property WarrantyDetails As String = ""
    Public Property ModeOfDispatch As String = ""
    Private _DeliveryDate As String = ""
    Public Property CurrencyID As String = ""
    Public Property ConversionFactorINR As String = "0.00"
    Public Property QuatationNo As String = ""
    Private _QuotationDate As String = ""
    Public Property AprTypeID As String = ""
    Public Property BuyerRemarks As String = ""
    Public Property ProjectID As String = ""
    Public Property ElementID As String = ""
    Public Property EmployeeID As String = ""
    Public Property DepartmentID As String = ""
    Public Property CostCenterID As String = ""
    Public Property DivisionID As String = ""
    Public Property OrderText As String = ""
    Public Property ApproverRemarks As String = ""
    Private _ApprovedOn As String = ""
    Public Property ApprovedBy As String = ""
    Private _CreatedOn As String = ""
    Public Property CreatedBy As String = ""
    Private _OrderDate As String = ""
    Public Property ReasonOfRevision As String = ""
    Public Property StatusID As String = ""
    Public Property IssuedBy As String = ""
    Private _IssuedOn As String = ""
    Public Property RevisedBy As String = ""
    Private _RevisedOn As String = ""
    Public Property ShipToState As String = ""
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property aspnet_Users2_UserFullName As String = ""
    Public Property HRM_Departments3_Description As String = ""
    Public Property HRM_Divisions4_Description As String = ""
    Public Property HRM_Employees5_EmployeeName As String = ""
    Public Property IDM_Projects6_Description As String = ""
    Public Property IDM_WBS7_Description As String = ""
    Public Property PUR_ApprovalTypes8_AprDescription As String = ""
    Public Property PUR_Currencies9_CurrencyName As String = ""
    Public Property PUR_POStatus10_Description As String = ""
    Public Property PUR_PurchaseTypes11_Description As String = ""
    Public Property SPMT_CostCenters12_Description As String = ""
    Public Property SPMT_IsgecGSTIN13_Description As String = ""
    Public Property SPMT_TranTypes14_Description As String = ""
    Public Property VR_BPGSTIN15_Description As String = ""
    Public Property VR_BusinessPartner16_BPName As String = ""
    Public Property aspnet_Users17_UserFullName As String = ""
    Public Property aspnet_Users18_UserFullName As String = ""
    Private _FK_PUR_Orders_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PUR_Orders_ApprovedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PUR_Orders_DepartmentID As SIS.QCM.qcmDepartments = Nothing
    Private _FK_PUR_Orders_DivisionID As SIS.QCM.qcmDivisions = Nothing
    Private _FK_PUR_Orders_EmployeeID As SIS.QCM.qcmEmployees = Nothing
    Private _FK_PUR_Orders_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_PUR_Orders_ElementID As SIS.PAK.pakWBS = Nothing
    Private _FK_PUR_Orders_AprTypeID As SIS.PUR.purApprovalTypes = Nothing
    Private _FK_PUR_Orders_CurrencyID As SIS.PUR.purCurrencies = Nothing
    Private _FK_PUR_Orders_StatusID As SIS.PUR.purPOStatus = Nothing
    Private _FK_PUR_Orders_PurchaseTypeID As SIS.PUR.purPurchaseTypes = Nothing
    Private _FK_PUR_Orders_CostCenterID As SIS.SPMT.spmtCostCenters = Nothing
    Private _FK_PUR_Orders_IsgecGSTIN As SIS.SPMT.spmtIsgecGSTIN = Nothing
    Private _FK_PUR_Orders_TranTypeID As SIS.SPMT.spmtTranTypes = Nothing
    Private _FK_PUR_Orders_SupplierGSTIN As SIS.SPMT.spmtBPGSTIN = Nothing
    Private _FK_PUR_Orders_SupplierID As SIS.SPMT.spmtBusinessPartner = Nothing
    Private _FK_PUR_Orders_IssuedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PUR_Orders_RevisedBy As SIS.QCM.qcmUsers = Nothing
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
    Public Property DeliveryDate() As String
      Get
        If Not _DeliveryDate = String.Empty Then
          Return Convert.ToDateTime(_DeliveryDate).ToString("dd/MM/yyyy")
        End If
        Return _DeliveryDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DeliveryDate = ""
         Else
           _DeliveryDate = value
         End If
      End Set
    End Property
    Public Property QuotationDate() As String
      Get
        If Not _QuotationDate = String.Empty Then
          Return Convert.ToDateTime(_QuotationDate).ToString("dd/MM/yyyy")
        End If
        Return _QuotationDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _QuotationDate = ""
         Else
           _QuotationDate = value
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
    Public Property IssuedOn() As String
      Get
        If Not _IssuedOn = String.Empty Then
          Return Convert.ToDateTime(_IssuedOn).ToString("dd/MM/yyyy")
        End If
        Return _IssuedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _IssuedOn = ""
        Else
          _IssuedOn = value
        End If
      End Set
    End Property
    Public Property RevisedOn() As String
      Get
        If Not _RevisedOn = String.Empty Then
          Return Convert.ToDateTime(_RevisedOn).ToString("dd/MM/yyyy")
        End If
        Return _RevisedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _RevisedOn = ""
        Else
          _RevisedOn = value
        End If
      End Set
    End Property
    Public Property OrderDate() As String
      Get
        If Not _OrderDate = String.Empty Then
          Return Convert.ToDateTime(_OrderDate).ToString("dd/MM/yyyy")
        End If
        Return _OrderDate
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _OrderDate = ""
        Else
          _OrderDate = value
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
        Return _OrderNo & "|" & _OrderRev
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
    Public Class PKpurOrders
      Private _OrderNo As Int32 = 0
      Private _OrderRev As Int32 = 0
      Public Property OrderNo() As Int32
        Get
          Return _OrderNo
        End Get
        Set(ByVal value As Int32)
          _OrderNo = value
        End Set
      End Property
      Public Property OrderRev() As Int32
        Get
          Return _OrderRev
        End Get
        Set(ByVal value As Int32)
          _OrderRev = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PUR_Orders_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PUR_Orders_CreatedBy Is Nothing Then
          _FK_PUR_Orders_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_PUR_Orders_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_ApprovedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PUR_Orders_ApprovedBy Is Nothing Then
          _FK_PUR_Orders_ApprovedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ApprovedBy)
        End If
        Return _FK_PUR_Orders_ApprovedBy
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_DepartmentID() As SIS.QCM.qcmDepartments
      Get
        If _FK_PUR_Orders_DepartmentID Is Nothing Then
          _FK_PUR_Orders_DepartmentID = SIS.QCM.qcmDepartments.qcmDepartmentsGetByID(_DepartmentID)
        End If
        Return _FK_PUR_Orders_DepartmentID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_DivisionID() As SIS.QCM.qcmDivisions
      Get
        If _FK_PUR_Orders_DivisionID Is Nothing Then
          _FK_PUR_Orders_DivisionID = SIS.QCM.qcmDivisions.qcmDivisionsGetByID(_DivisionID)
        End If
        Return _FK_PUR_Orders_DivisionID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_EmployeeID() As SIS.QCM.qcmEmployees
      Get
        If _FK_PUR_Orders_EmployeeID Is Nothing Then
          _FK_PUR_Orders_EmployeeID = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(_EmployeeID)
        End If
        Return _FK_PUR_Orders_EmployeeID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_PUR_Orders_ProjectID Is Nothing Then
          _FK_PUR_Orders_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_PUR_Orders_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_ElementID() As SIS.PAK.pakWBS
      Get
        If _FK_PUR_Orders_ElementID Is Nothing Then
          _FK_PUR_Orders_ElementID = SIS.PAK.pakWBS.pakWBSGetByID(_ElementID)
        End If
        Return _FK_PUR_Orders_ElementID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_AprTypeID() As SIS.PUR.purApprovalTypes
      Get
        If _FK_PUR_Orders_AprTypeID Is Nothing Then
          _FK_PUR_Orders_AprTypeID = SIS.PUR.purApprovalTypes.purApprovalTypesGetByID(_AprTypeID)
        End If
        Return _FK_PUR_Orders_AprTypeID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_CurrencyID() As SIS.PUR.purCurrencies
      Get
        If _FK_PUR_Orders_CurrencyID Is Nothing Then
          _FK_PUR_Orders_CurrencyID = SIS.PUR.purCurrencies.purCurrenciesGetByID(_CurrencyID)
        End If
        Return _FK_PUR_Orders_CurrencyID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_StatusID() As SIS.PUR.purPOStatus
      Get
        If _FK_PUR_Orders_StatusID Is Nothing Then
          _FK_PUR_Orders_StatusID = SIS.PUR.purPOStatus.purPOStatusGetByID(_StatusID)
        End If
        Return _FK_PUR_Orders_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_PurchaseTypeID() As SIS.PUR.purPurchaseTypes
      Get
        If _FK_PUR_Orders_PurchaseTypeID Is Nothing Then
          _FK_PUR_Orders_PurchaseTypeID = SIS.PUR.purPurchaseTypes.purPurchaseTypesGetByID(_PurchaseTypeID)
        End If
        Return _FK_PUR_Orders_PurchaseTypeID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_CostCenterID() As SIS.SPMT.spmtCostCenters
      Get
        If _FK_PUR_Orders_CostCenterID Is Nothing Then
          _FK_PUR_Orders_CostCenterID = SIS.SPMT.spmtCostCenters.spmtCostCentersGetByID(_CostCenterID)
        End If
        Return _FK_PUR_Orders_CostCenterID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_IsgecGSTIN() As SIS.SPMT.spmtIsgecGSTIN
      Get
        If _FK_PUR_Orders_IsgecGSTIN Is Nothing Then
          _FK_PUR_Orders_IsgecGSTIN = SIS.SPMT.spmtIsgecGSTIN.spmtIsgecGSTINGetByID(_IsgecGSTIN)
        End If
        Return _FK_PUR_Orders_IsgecGSTIN
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_TranTypeID() As SIS.SPMT.spmtTranTypes
      Get
        If _FK_PUR_Orders_TranTypeID Is Nothing Then
          _FK_PUR_Orders_TranTypeID = SIS.SPMT.spmtTranTypes.spmtTranTypesGetByID(_TranTypeID)
        End If
        Return _FK_PUR_Orders_TranTypeID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_SupplierGSTIN() As SIS.SPMT.spmtBPGSTIN
      Get
        If _FK_PUR_Orders_SupplierGSTIN Is Nothing Then
          _FK_PUR_Orders_SupplierGSTIN = SIS.SPMT.spmtBPGSTIN.spmtBPGSTINGetByID(_SupplierID, _SupplierGSTIN)
        End If
        Return _FK_PUR_Orders_SupplierGSTIN
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_SupplierID() As SIS.SPMT.spmtBusinessPartner
      Get
        If _FK_PUR_Orders_SupplierID Is Nothing Then
          _FK_PUR_Orders_SupplierID = SIS.SPMT.spmtBusinessPartner.spmtBusinessPartnerGetByID(_SupplierID)
        End If
        Return _FK_PUR_Orders_SupplierID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_IssuedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PUR_Orders_IssuedBy Is Nothing Then
          _FK_PUR_Orders_IssuedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_IssuedBy)
        End If
        Return _FK_PUR_Orders_IssuedBy
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Orders_RevisedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PUR_Orders_RevisedBy Is Nothing Then
          _FK_PUR_Orders_RevisedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_RevisedBy)
        End If
        Return _FK_PUR_Orders_RevisedBy
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function purOrdersSelectList(ByVal OrderBy As String) As List(Of SIS.PUR.purOrders)
      Dim Results As List(Of SIS.PUR.purOrders) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "OrderNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrdersSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purOrders)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purOrders(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purOrdersGetNewRecord() As SIS.PUR.purOrders
      Return New SIS.PUR.purOrders()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purOrdersGetByID(ByVal OrderNo As Int32, ByVal OrderRev As Int32) As SIS.PUR.purOrders
      Dim Results As SIS.PUR.purOrders = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrdersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.Int,OrderNo.ToString.Length, OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev",SqlDbType.Int,OrderRev.ToString.Length, OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purOrders(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purOrdersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PurchaseTypeID As String, ByVal TranTypeID As String, ByVal SupplierID As String, ByVal AprTypeID As String, ByVal EmployeeID As String, ByVal ApprovedBy As String, ByVal CreatedBy As String, ByVal StatusID As Int32) As List(Of SIS.PUR.purOrders)
      Dim Results As List(Of SIS.PUR.purOrders) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "OrderNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurOrdersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurOrdersSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PurchaseTypeID",SqlDbType.NVarChar,100, IIf(PurchaseTypeID Is Nothing, String.Empty,PurchaseTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TranTypeID",SqlDbType.NVarChar,3, IIf(TranTypeID Is Nothing, String.Empty,TranTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID",SqlDbType.NVarChar,9, IIf(SupplierID Is Nothing, String.Empty,SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_AprTypeID",SqlDbType.NVarChar,10, IIf(AprTypeID Is Nothing, String.Empty,AprTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID",SqlDbType.NVarChar,8, IIf(EmployeeID Is Nothing, String.Empty,EmployeeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ApprovedBy",SqlDbType.NVarChar,8, IIf(ApprovedBy Is Nothing, String.Empty,ApprovedBy))
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
          Results = New List(Of SIS.PUR.purOrders)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purOrders(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purOrdersSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PurchaseTypeID As String, ByVal TranTypeID As String, ByVal SupplierID As String, ByVal AprTypeID As String, ByVal EmployeeID As String, ByVal ApprovedBy As String, ByVal CreatedBy As String, ByVal StatusID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purOrdersGetByID(ByVal OrderNo As Int32, ByVal OrderRev As Int32, ByVal Filter_PurchaseTypeID As String, ByVal Filter_TranTypeID As String, ByVal Filter_SupplierID As String, ByVal Filter_AprTypeID As String, ByVal Filter_EmployeeID As String, ByVal Filter_ApprovedBy As String, ByVal Filter_CreatedBy As String, ByVal Filter_StatusID As Int32) As SIS.PUR.purOrders
      Return purOrdersGetByID(OrderNo, OrderRev)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purOrdersInsert(ByVal Record As SIS.PUR.purOrders) As SIS.PUR.purOrders
      Dim _Rec As SIS.PUR.purOrders = SIS.PUR.purOrders.purOrdersGetNewRecord()
      With _Rec
        .OrderNo = 0
        .OrderRev = 0
        .PurchaseTypeID = Record.PurchaseTypeID
        .TranTypeID = Record.TranTypeID
        .IsgecGSTIN = Record.IsgecGSTIN
        .IsgecGSTINAddress = Record.IsgecGSTINAddress
        .DestinationAddress = Record.DestinationAddress
        .SupplierID = Record.SupplierID
        .SupplierGSTIN = Record.SupplierGSTIN
        .SupplierName = Record.SupplierName
        .SupplierGSTINUMBER = Record.SupplierGSTINUMBER
        .PaymentTerms = Record.PaymentTerms
        .DeliveryTerms = Record.DeliveryTerms
        .InsuranceDetails = Record.InsuranceDetails
        .WarrantyDetails = Record.WarrantyDetails
        .ModeOfDispatch = Record.ModeOfDispatch
        .DeliveryDate = Record.DeliveryDate
        .CurrencyID = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .QuatationNo = Record.QuatationNo
        .QuotationDate = Record.QuotationDate
        .AprTypeID = Record.AprTypeID
        .BuyerRemarks = Record.BuyerRemarks
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .EmployeeID = Record.EmployeeID
        .DepartmentID = Record.DepartmentID
        .CostCenterID = Record.CostCenterID
        .DivisionID = Record.DivisionID
        .OrderText = Record.OrderText
        .ApproverRemarks = Record.ApproverRemarks
        .ApprovedOn = Record.ApprovedOn
        .ApprovedBy = Record.ApprovedBy
        .CreatedOn = Now
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .OrderDate = Now
        .ReasonOfRevision = Record.ReasonOfRevision
        .StatusID = enumOrderStates.Free
        .ShipToState = Record.ShipToState
      End With
      Return SIS.PUR.purOrders.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purOrders) As SIS.PUR.purOrders
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrdersInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo", SqlDbType.Int, 11, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev", SqlDbType.Int, 11, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PurchaseTypeID", SqlDbType.NVarChar, 101, IIf(Record.PurchaseTypeID = "", Convert.DBNull, Record.PurchaseTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranTypeID",SqlDbType.NVarChar,4, Iif(Record.TranTypeID= "" ,Convert.DBNull, Record.TranTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTIN",SqlDbType.Int,11, Iif(Record.IsgecGSTIN= "" ,Convert.DBNull, Record.IsgecGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTINAddress",SqlDbType.NVarChar,501, Iif(Record.IsgecGSTINAddress= "" ,Convert.DBNull, Record.IsgecGSTINAddress))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DestinationAddress",SqlDbType.NVarChar,501, Iif(Record.DestinationAddress= "" ,Convert.DBNull, Record.DestinationAddress))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTIN",SqlDbType.Int,11, Iif(Record.SupplierGSTIN= "" ,Convert.DBNull, Record.SupplierGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.NVarChar,51, Iif(Record.SupplierName= "" ,Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTINUMBER",SqlDbType.NVarChar,51, Iif(Record.SupplierGSTINUMBER= "" ,Convert.DBNull, Record.SupplierGSTINUMBER))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentTerms",SqlDbType.NVarChar,501, Iif(Record.PaymentTerms= "" ,Convert.DBNull, Record.PaymentTerms))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryTerms",SqlDbType.NVarChar,501, Iif(Record.DeliveryTerms= "" ,Convert.DBNull, Record.DeliveryTerms))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InsuranceDetails",SqlDbType.NVarChar,201, Iif(Record.InsuranceDetails= "" ,Convert.DBNull, Record.InsuranceDetails))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WarrantyDetails",SqlDbType.NVarChar,1001, Iif(Record.WarrantyDetails= "" ,Convert.DBNull, Record.WarrantyDetails))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeOfDispatch",SqlDbType.NVarChar,51, Iif(Record.ModeOfDispatch= "" ,Convert.DBNull, Record.ModeOfDispatch))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryDate",SqlDbType.DateTime,21, Iif(Record.DeliveryDate= "" ,Convert.DBNull, Record.DeliveryDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,11, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,25, Iif(Record.ConversionFactorINR= "" ,Convert.DBNull, Record.ConversionFactorINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuatationNo",SqlDbType.NVarChar,21, Iif(Record.QuatationNo= "" ,Convert.DBNull, Record.QuatationNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuotationDate",SqlDbType.DateTime,21, Iif(Record.QuotationDate= "" ,Convert.DBNull, Record.QuotationDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AprTypeID",SqlDbType.NVarChar,11, Iif(Record.AprTypeID= "" ,Convert.DBNull, Record.AprTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerRemarks",SqlDbType.NVarChar,501, Iif(Record.BuyerRemarks= "" ,Convert.DBNull, Record.BuyerRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Iif(Record.EmployeeID= "" ,Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Iif(Record.DepartmentID= "" ,Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderText",SqlDbType.NVarChar,100001, Iif(Record.OrderText= "" ,Convert.DBNull, Record.OrderText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,201, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderDate",SqlDbType.DateTime,21, Iif(Record.OrderDate= "" ,Convert.DBNull, Record.OrderDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReasonOfRevision",SqlDbType.NVarChar,201, Iif(Record.ReasonOfRevision= "" ,Convert.DBNull, Record.ReasonOfRevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedOn", SqlDbType.DateTime, 21, IIf(Record.IssuedOn = "", Convert.DBNull, Record.IssuedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedBy", SqlDbType.NVarChar, 9, IIf(Record.IssuedBy = "", Convert.DBNull, Record.IssuedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisedOn", SqlDbType.DateTime, 21, IIf(Record.RevisedOn = "", Convert.DBNull, Record.RevisedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisedBy", SqlDbType.NVarChar, 9, IIf(Record.RevisedBy = "", Convert.DBNull, Record.RevisedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShipToState", SqlDbType.NVarChar, 3, IIf(Record.ShipToState = "", Convert.DBNull, Record.ShipToState))

          Cmd.Parameters.Add("@Return_OrderNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_OrderNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_OrderRev", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_OrderRev").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.OrderNo = Cmd.Parameters("@Return_OrderNo").Value
          Record.OrderRev = Cmd.Parameters("@Return_OrderRev").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purOrdersUpdate(ByVal Record As SIS.PUR.purOrders) As SIS.PUR.purOrders
      Dim _Rec As SIS.PUR.purOrders = SIS.PUR.purOrders.purOrdersGetByID(Record.OrderNo, Record.OrderRev)
      With _Rec
        .PurchaseTypeID = Record.PurchaseTypeID
        .TranTypeID = Record.TranTypeID
        .IsgecGSTIN = Record.IsgecGSTIN
        .IsgecGSTINAddress = Record.IsgecGSTINAddress
        .DestinationAddress = Record.DestinationAddress
        .SupplierID = Record.SupplierID
        .SupplierGSTIN = Record.SupplierGSTIN
        .SupplierName = Record.SupplierName
        .SupplierGSTINUMBER = Record.SupplierGSTINUMBER
        .PaymentTerms = Record.PaymentTerms
        .DeliveryTerms = Record.DeliveryTerms
        .InsuranceDetails = Record.InsuranceDetails
        .WarrantyDetails = Record.WarrantyDetails
        .ModeOfDispatch = Record.ModeOfDispatch
        .DeliveryDate = Record.DeliveryDate
        .CurrencyID = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .QuatationNo = Record.QuatationNo
        .QuotationDate = Record.QuotationDate
        .AprTypeID = Record.AprTypeID
        .BuyerRemarks = Record.BuyerRemarks
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .EmployeeID = Record.EmployeeID
        .DepartmentID = Record.DepartmentID
        .CostCenterID = Record.CostCenterID
        .DivisionID = Record.DivisionID
        .OrderText = Record.OrderText
        .ApproverRemarks = Record.ApproverRemarks
        .ApprovedOn = Record.ApprovedOn
        .ApprovedBy = Record.ApprovedBy
        .CreatedOn = Now
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .OrderDate = Record.OrderDate
        .ReasonOfRevision = Record.ReasonOfRevision
        .StatusID = enumOrderStates.Free
        .ShipToState = Record.ShipToState
      End With
      Return SIS.PUR.purOrders.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purOrders) As SIS.PUR.purOrders
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrdersUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderNo",SqlDbType.Int,11, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderRev",SqlDbType.Int,11, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev",SqlDbType.Int,11, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PurchaseTypeID",SqlDbType.NVarChar,101, Iif(Record.PurchaseTypeID= "" ,Convert.DBNull, Record.PurchaseTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranTypeID",SqlDbType.NVarChar,4, Iif(Record.TranTypeID= "" ,Convert.DBNull, Record.TranTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTIN",SqlDbType.Int,11, Iif(Record.IsgecGSTIN= "" ,Convert.DBNull, Record.IsgecGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTINAddress",SqlDbType.NVarChar,501, Iif(Record.IsgecGSTINAddress= "" ,Convert.DBNull, Record.IsgecGSTINAddress))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DestinationAddress",SqlDbType.NVarChar,501, Iif(Record.DestinationAddress= "" ,Convert.DBNull, Record.DestinationAddress))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTIN",SqlDbType.Int,11, Iif(Record.SupplierGSTIN= "" ,Convert.DBNull, Record.SupplierGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.NVarChar,51, Iif(Record.SupplierName= "" ,Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTINUMBER",SqlDbType.NVarChar,51, Iif(Record.SupplierGSTINUMBER= "" ,Convert.DBNull, Record.SupplierGSTINUMBER))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentTerms",SqlDbType.NVarChar,501, Iif(Record.PaymentTerms= "" ,Convert.DBNull, Record.PaymentTerms))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryTerms",SqlDbType.NVarChar,501, Iif(Record.DeliveryTerms= "" ,Convert.DBNull, Record.DeliveryTerms))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InsuranceDetails",SqlDbType.NVarChar,201, Iif(Record.InsuranceDetails= "" ,Convert.DBNull, Record.InsuranceDetails))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WarrantyDetails",SqlDbType.NVarChar,1001, Iif(Record.WarrantyDetails= "" ,Convert.DBNull, Record.WarrantyDetails))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeOfDispatch",SqlDbType.NVarChar,51, Iif(Record.ModeOfDispatch= "" ,Convert.DBNull, Record.ModeOfDispatch))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryDate",SqlDbType.DateTime,21, Iif(Record.DeliveryDate= "" ,Convert.DBNull, Record.DeliveryDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,11, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,25, Iif(Record.ConversionFactorINR= "" ,Convert.DBNull, Record.ConversionFactorINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuatationNo",SqlDbType.NVarChar,21, Iif(Record.QuatationNo= "" ,Convert.DBNull, Record.QuatationNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuotationDate",SqlDbType.DateTime,21, Iif(Record.QuotationDate= "" ,Convert.DBNull, Record.QuotationDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AprTypeID",SqlDbType.NVarChar,11, Iif(Record.AprTypeID= "" ,Convert.DBNull, Record.AprTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerRemarks",SqlDbType.NVarChar,501, Iif(Record.BuyerRemarks= "" ,Convert.DBNull, Record.BuyerRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Iif(Record.EmployeeID= "" ,Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Iif(Record.DepartmentID= "" ,Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderText",SqlDbType.NVarChar,100001, Iif(Record.OrderText= "" ,Convert.DBNull, Record.OrderText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,201, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderDate",SqlDbType.DateTime,21, Iif(Record.OrderDate= "" ,Convert.DBNull, Record.OrderDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReasonOfRevision",SqlDbType.NVarChar,201, Iif(Record.ReasonOfRevision= "" ,Convert.DBNull, Record.ReasonOfRevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedOn", SqlDbType.DateTime, 21, IIf(Record.IssuedOn = "", Convert.DBNull, Record.IssuedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedBy", SqlDbType.NVarChar, 9, IIf(Record.IssuedBy = "", Convert.DBNull, Record.IssuedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisedOn", SqlDbType.DateTime, 21, IIf(Record.RevisedOn = "", Convert.DBNull, Record.RevisedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisedBy", SqlDbType.NVarChar, 9, IIf(Record.RevisedBy = "", Convert.DBNull, Record.RevisedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShipToState", SqlDbType.NVarChar, 3, IIf(Record.ShipToState = "", Convert.DBNull, Record.ShipToState))

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
    Public Shared Function purOrdersDelete(ByVal Record As SIS.PUR.purOrders) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrdersDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderNo",SqlDbType.Int,Record.OrderNo.ToString.Length, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderRev",SqlDbType.Int,Record.OrderRev.ToString.Length, Record.OrderRev)
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
    Public Shared Function SelectpurOrdersAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrdersAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(10, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PUR.purOrders = New SIS.PUR.purOrders(Reader)
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
