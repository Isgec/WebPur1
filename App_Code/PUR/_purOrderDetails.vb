Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purOrderDetails
    Private Shared _RecordCount As Integer
    Public Property OrderLine As Int32 = 0
    Public Property ItemCode As String = ""
    Public Property UOM As String = ""
    Public Property ItemDescription As String = ""
    Public Property Quantity As String = "0.00"
    Public Property Price As String = "0.00"
    Private _DeliveryDate As String = ""
    Public Property TotalGST As String = "0.00"
    Public Property TotalAmountINR As String = "0.00"
    Public Property OrderRev As Int32 = 0
    Public Property TaxCode As String = ""
    Public Property AssessableValue As String = "0.00"
    Public Property OrderNo As Int32 = 0
    Public Property IGSTrate As String = "0.00"
    Public Property TaxAmount As String = "0.00"
    Public Property CGSTRate As String = "0.00"
    Public Property CGSTAmount As String = "0.00"
    Public Property TCSRate As String = "0.00"
    Public Property CESSAmount As String = "0.00"
    Public Property SGSTRate As String = "0.00"
    Public Property SGSTAmount As String = "0.00"
    Public Property CESSRate As String = "0.00"
    Public Property Amount As String = "0.00"
    Public Property TotalAmount As String = "0.00"
    Public Property TCSAmount As String = "0.00"
    Public Property IGSTAmount As String = "0.00"
    Public Property ReceiptLine As String = ""
    Public Property BillType As String = ""
    Public Property HSNSACCode As String = ""
    Public Property CurrencyID As String = ""
    Public Property ConversionFactorINR As String = "0.00"
    Public Property TranTypeID As String = ""
    Public Property ProjectID As String = ""
    Public Property ElementID As String = ""
    Public Property EmployeeID As String = ""
    Public Property DepartmentID As String = ""
    Public Property CostCenterID As String = ""
    Public Property DivisionID As String = ""
    Public Property MainLine As String = ""
    Public Property ReceivedQuantity As String = "0.00"
    Public Property ReceiptNo As String = ""
    Public Property ParentLine As String = ""
    Public Property OriginalQuantity As String = "0.00"
    Public Property FromIndent As Boolean = False
    Public Property HRM_Departments1_Description As String = ""
    Public Property HRM_Divisions2_Description As String = ""
    Public Property HRM_Employees3_EmployeeName As String = ""
    Public Property IDM_Projects4_Description As String = ""
    Public Property IDM_WBS5_Description As String = ""
    Public Property PUR_Currencies6_CurrencyName As String = ""
    Public Property PUR_Items7_ItemDescription As String = ""
    Public Property PUR_Orders8_IsgecGSTIN As String = ""
    Public Property PUR_TaxCodes9_TaxDescription As String = ""
    Public Property SPMT_BillTypes10_Description As String = ""
    Public Property SPMT_CostCenters11_Description As String = ""
    Public Property SPMT_ERPUnits12_Description As String = ""
    Public Property SPMT_HSNSACCodes13_HSNSACCode As String = ""
    Public Property SPMT_TranTypes14_Description As String = ""
    Private _FK_PUR_OrderDetails_DepartmentID As SIS.QCM.qcmDepartments = Nothing
    Private _FK_PUR_OrderDetails_DivisionID As SIS.QCM.qcmDivisions = Nothing
    Private _FK_PUR_OrderDetails_EmployeeID As SIS.QCM.qcmEmployees = Nothing
    Private _FK_PUR_OrderDetails_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_PUR_OrderDetails_ElementID As SIS.PAK.pakWBS = Nothing
    Private _FK_PUR_OrderDetails_CurrencyID As SIS.PUR.purCurrencies = Nothing
    Private _FK_PUR_OrderDetails_ItemCode As SIS.PUR.purItems = Nothing
    Private _FK_PUR_OrderDetails_OrderNo As SIS.PUR.purOrders = Nothing
    Private _FK_PUR_OrderDetails_TaxCode As SIS.PUR.purTaxCodes = Nothing
    Private _FK_PUR_OrderDetails_BillType As SIS.SPMT.spmtBillTypes = Nothing
    Private _FK_PUR_OrderDetails_CostCenterID As SIS.SPMT.spmtCostCenters = Nothing
    Private _FK_PUR_OrderDetails_UOM As SIS.SPMT.spmtERPUnits = Nothing
    Private _FK_PUR_OrderDetails_HSNSACCode As SIS.SPMT.spmtHSNSACCodes = Nothing
    Private _FK_PUR_OrderDetails_TranTypeID As SIS.SPMT.spmtTranTypes = Nothing
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
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _ItemDescription.ToString.PadRight(1000, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _OrderNo & "|" & _OrderLine & "|" & _OrderRev
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
    Public Class PKpurOrderDetails
      Private _OrderNo As Int32 = 0
      Private _OrderLine As Int32 = 0
      Private _OrderRev As Int32 = 0
      Public Property OrderNo() As Int32
        Get
          Return _OrderNo
        End Get
        Set(ByVal value As Int32)
          _OrderNo = value
        End Set
      End Property
      Public Property OrderLine() As Int32
        Get
          Return _OrderLine
        End Get
        Set(ByVal value As Int32)
          _OrderLine = value
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
    Public ReadOnly Property FK_PUR_OrderDetails_DepartmentID() As SIS.QCM.qcmDepartments
      Get
        If _FK_PUR_OrderDetails_DepartmentID Is Nothing Then
          _FK_PUR_OrderDetails_DepartmentID = SIS.QCM.qcmDepartments.qcmDepartmentsGetByID(_DepartmentID)
        End If
        Return _FK_PUR_OrderDetails_DepartmentID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderDetails_DivisionID() As SIS.QCM.qcmDivisions
      Get
        If _FK_PUR_OrderDetails_DivisionID Is Nothing Then
          _FK_PUR_OrderDetails_DivisionID = SIS.QCM.qcmDivisions.qcmDivisionsGetByID(_DivisionID)
        End If
        Return _FK_PUR_OrderDetails_DivisionID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderDetails_EmployeeID() As SIS.QCM.qcmEmployees
      Get
        If _FK_PUR_OrderDetails_EmployeeID Is Nothing Then
          _FK_PUR_OrderDetails_EmployeeID = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(_EmployeeID)
        End If
        Return _FK_PUR_OrderDetails_EmployeeID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderDetails_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_PUR_OrderDetails_ProjectID Is Nothing Then
          _FK_PUR_OrderDetails_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_PUR_OrderDetails_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderDetails_ElementID() As SIS.PAK.pakWBS
      Get
        If _FK_PUR_OrderDetails_ElementID Is Nothing Then
          _FK_PUR_OrderDetails_ElementID = SIS.PAK.pakWBS.pakWBSGetByID(_ElementID)
        End If
        Return _FK_PUR_OrderDetails_ElementID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderDetails_CurrencyID() As SIS.PUR.purCurrencies
      Get
        If _FK_PUR_OrderDetails_CurrencyID Is Nothing Then
          _FK_PUR_OrderDetails_CurrencyID = SIS.PUR.purCurrencies.purCurrenciesGetByID(_CurrencyID)
        End If
        Return _FK_PUR_OrderDetails_CurrencyID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderDetails_ItemCode() As SIS.PUR.purItems
      Get
        If _FK_PUR_OrderDetails_ItemCode Is Nothing Then
          _FK_PUR_OrderDetails_ItemCode = SIS.PUR.purItems.purItemsGetByID(_ItemCode)
        End If
        Return _FK_PUR_OrderDetails_ItemCode
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderDetails_OrderNo() As SIS.PUR.purOrders
      Get
        If _FK_PUR_OrderDetails_OrderNo Is Nothing Then
          _FK_PUR_OrderDetails_OrderNo = SIS.PUR.purOrders.purOrdersGetByID(_OrderNo, _OrderRev)
        End If
        Return _FK_PUR_OrderDetails_OrderNo
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderDetails_TaxCode() As SIS.PUR.purTaxCodes
      Get
        If _FK_PUR_OrderDetails_TaxCode Is Nothing Then
          _FK_PUR_OrderDetails_TaxCode = SIS.PUR.purTaxCodes.purTaxCodesGetByID(_TaxCode)
        End If
        Return _FK_PUR_OrderDetails_TaxCode
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderDetails_BillType() As SIS.SPMT.spmtBillTypes
      Get
        If _FK_PUR_OrderDetails_BillType Is Nothing Then
          _FK_PUR_OrderDetails_BillType = SIS.SPMT.spmtBillTypes.spmtBillTypesGetByID(_BillType)
        End If
        Return _FK_PUR_OrderDetails_BillType
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderDetails_CostCenterID() As SIS.SPMT.spmtCostCenters
      Get
        If _FK_PUR_OrderDetails_CostCenterID Is Nothing Then
          _FK_PUR_OrderDetails_CostCenterID = SIS.SPMT.spmtCostCenters.spmtCostCentersGetByID(_CostCenterID)
        End If
        Return _FK_PUR_OrderDetails_CostCenterID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderDetails_UOM() As SIS.SPMT.spmtERPUnits
      Get
        If _FK_PUR_OrderDetails_UOM Is Nothing Then
          _FK_PUR_OrderDetails_UOM = SIS.SPMT.spmtERPUnits.spmtERPUnitsGetByID(_UOM)
        End If
        Return _FK_PUR_OrderDetails_UOM
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderDetails_HSNSACCode() As SIS.SPMT.spmtHSNSACCodes
      Get
        If _FK_PUR_OrderDetails_HSNSACCode Is Nothing Then
          _FK_PUR_OrderDetails_HSNSACCode = SIS.SPMT.spmtHSNSACCodes.spmtHSNSACCodesGetByID(_BillType, _HSNSACCode)
        End If
        Return _FK_PUR_OrderDetails_HSNSACCode
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderDetails_TranTypeID() As SIS.SPMT.spmtTranTypes
      Get
        If _FK_PUR_OrderDetails_TranTypeID Is Nothing Then
          _FK_PUR_OrderDetails_TranTypeID = SIS.SPMT.spmtTranTypes.spmtTranTypesGetByID(_TranTypeID)
        End If
        Return _FK_PUR_OrderDetails_TranTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purOrderDetailsSelectList(ByVal OrderBy As String) As List(Of SIS.PUR.purOrderDetails)
      Dim Results As List(Of SIS.PUR.purOrderDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrderDetailsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purOrderDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purOrderDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purOrderDetailsGetNewRecord() As SIS.PUR.purOrderDetails
      Return New SIS.PUR.purOrderDetails()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purOrderDetailsGetByID(ByVal OrderNo As Int32, ByVal OrderLine As Int32, ByVal OrderRev As Int32) As SIS.PUR.purOrderDetails
      Dim Results As SIS.PUR.purOrderDetails = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrderDetailsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.Int,OrderNo.ToString.Length, OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderLine",SqlDbType.Int,OrderLine.ToString.Length, OrderLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev",SqlDbType.Int,OrderRev.ToString.Length, OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purOrderDetails(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purOrderDetailsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal OrderRev As Int32, ByVal OrderNo As Int32) As List(Of SIS.PUR.purOrderDetails)
      Dim Results As List(Of SIS.PUR.purOrderDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurOrderDetailsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurOrderDetailsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_OrderRev",SqlDbType.Int,10, IIf(OrderRev = Nothing, 0,OrderRev))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_OrderNo",SqlDbType.Int,10, IIf(OrderNo = Nothing, 0,OrderNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purOrderDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purOrderDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purOrderDetailsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal OrderRev As Int32, ByVal OrderNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purOrderDetailsGetByID(ByVal OrderNo As Int32, ByVal OrderLine As Int32, ByVal OrderRev As Int32, ByVal Filter_OrderRev As Int32, ByVal Filter_OrderNo As Int32) As SIS.PUR.purOrderDetails
      Return purOrderDetailsGetByID(OrderNo, OrderLine, OrderRev)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purOrderDetailsInsert(ByVal Record As SIS.PUR.purOrderDetails) As SIS.PUR.purOrderDetails
      Dim _Rec As SIS.PUR.purOrderDetails = SIS.PUR.purOrderDetails.purOrderDetailsGetNewRecord()
      With _Rec
        .OrderLine = 0
        .ItemCode = Record.ItemCode
        .UOM = Record.UOM
        .ItemDescription = Record.ItemDescription
        .Quantity = Record.Quantity
        .Price = Record.Price
        .DeliveryDate = Record.DeliveryDate
        .TotalGST = Record.TotalGST
        .TotalAmountINR = Record.TotalAmountINR
        .OrderRev = Record.OrderRev
        .TaxCode = Record.TaxCode
        .AssessableValue = Record.AssessableValue
        .OrderNo = Record.OrderNo
        .IGSTrate = Record.IGSTrate
        .TaxAmount = Record.TaxAmount
        .CGSTRate = Record.CGSTRate
        .CGSTAmount = Record.CGSTAmount
        .TCSRate = Record.TCSRate
        .CESSAmount = Record.CESSAmount
        .SGSTRate = Record.SGSTRate
        .SGSTAmount = Record.SGSTAmount
        .CESSRate = Record.CESSRate
        .Amount = Record.Amount
        .TotalAmount = Record.TotalAmount
        .TCSAmount = Record.TCSAmount
        .IGSTAmount = Record.IGSTAmount
        .ReceiptLine = Record.ReceiptLine
        .BillType = Record.BillType
        .HSNSACCode = Record.HSNSACCode
        .CurrencyID = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .TranTypeID = Record.TranTypeID
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .EmployeeID = Record.EmployeeID
        .DepartmentID = Record.DepartmentID
        .CostCenterID = Record.CostCenterID
        .DivisionID = Record.DivisionID
        .ReceiptNo = Record.ReceiptNo
        '===============
        .MainLine = True
        .ReceivedQuantity = 0
        .OriginalQuantity = Record.Quantity
      End With
      Return SIS.PUR.purOrderDetails.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purOrderDetails) As SIS.PUR.purOrderDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrderDetailsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderLine", SqlDbType.Int, 11, Record.OrderLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode", SqlDbType.Int, 11, IIf(Record.ItemCode = "", Convert.DBNull, Record.ItemCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM",SqlDbType.NVarChar,4, Iif(Record.UOM= "" ,Convert.DBNull, Record.UOM))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,1001, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,23, Iif(Record.Quantity= "" ,Convert.DBNull, Record.Quantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Price",SqlDbType.Decimal,23, Iif(Record.Price= "" ,Convert.DBNull, Record.Price))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryDate",SqlDbType.DateTime,21, Iif(Record.DeliveryDate= "" ,Convert.DBNull, Record.DeliveryDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalGST",SqlDbType.Decimal,23, Iif(Record.TotalGST= "" ,Convert.DBNull, Record.TotalGST))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmountINR",SqlDbType.Decimal,23, Iif(Record.TotalAmountINR= "" ,Convert.DBNull, Record.TotalAmountINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev",SqlDbType.Int,11, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxCode",SqlDbType.Int,11, Iif(Record.TaxCode= "" ,Convert.DBNull, Record.TaxCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssessableValue",SqlDbType.Decimal,23, Iif(Record.AssessableValue= "" ,Convert.DBNull, Record.AssessableValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.Int,11, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTrate",SqlDbType.Decimal,23, Iif(Record.IGSTrate= "" ,Convert.DBNull, Record.IGSTrate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxAmount",SqlDbType.Decimal,23, Iif(Record.TaxAmount= "" ,Convert.DBNull, Record.TaxAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTRate",SqlDbType.Decimal,23, Iif(Record.CGSTRate= "" ,Convert.DBNull, Record.CGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTAmount",SqlDbType.Decimal,23, Iif(Record.CGSTAmount= "" ,Convert.DBNull, Record.CGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCSRate",SqlDbType.Decimal,23, Iif(Record.TCSRate= "" ,Convert.DBNull, Record.TCSRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CESSAmount",SqlDbType.Decimal,23, Iif(Record.CESSAmount= "" ,Convert.DBNull, Record.CESSAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTRate",SqlDbType.Decimal,23, Iif(Record.SGSTRate= "" ,Convert.DBNull, Record.SGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTAmount",SqlDbType.Decimal,23, Iif(Record.SGSTAmount= "" ,Convert.DBNull, Record.SGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CESSRate",SqlDbType.Decimal,23, Iif(Record.CESSRate= "" ,Convert.DBNull, Record.CESSRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount",SqlDbType.Decimal,23, Iif(Record.Amount= "" ,Convert.DBNull, Record.Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmount",SqlDbType.Decimal,23, Iif(Record.TotalAmount= "" ,Convert.DBNull, Record.TotalAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCSAmount",SqlDbType.Decimal,23, Iif(Record.TCSAmount= "" ,Convert.DBNull, Record.TCSAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTAmount",SqlDbType.Decimal,23, Iif(Record.IGSTAmount= "" ,Convert.DBNull, Record.IGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptLine",SqlDbType.Int,11, Iif(Record.ReceiptLine= "" ,Convert.DBNull, Record.ReceiptLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillType",SqlDbType.Int,11, Iif(Record.BillType= "" ,Convert.DBNull, Record.BillType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSNSACCode",SqlDbType.NVarChar,21, Iif(Record.HSNSACCode= "" ,Convert.DBNull, Record.HSNSACCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,11, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,25, Iif(Record.ConversionFactorINR= "" ,Convert.DBNull, Record.ConversionFactorINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranTypeID",SqlDbType.NVarChar,4, Iif(Record.TranTypeID= "" ,Convert.DBNull, Record.TranTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Iif(Record.EmployeeID= "" ,Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Iif(Record.DepartmentID= "" ,Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MainLine",SqlDbType.Bit,3, Iif(Record.MainLine= "" ,Convert.DBNull, Record.MainLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedQuantity",SqlDbType.Decimal,23, Iif(Record.ReceivedQuantity= "" ,Convert.DBNull, Record.ReceivedQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo",SqlDbType.Int,11, Iif(Record.ReceiptNo= "" ,Convert.DBNull, Record.ReceiptNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentLine",SqlDbType.Int,11, Iif(Record.ParentLine= "" ,Convert.DBNull, Record.ParentLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OriginalQuantity",SqlDbType.Decimal,23, Iif(Record.OriginalQuantity= "" ,Convert.DBNull, Record.OriginalQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromIndent", SqlDbType.Bit, 3, Record.FromIndent)
          Cmd.Parameters.Add("@Return_OrderNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_OrderNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_OrderLine", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_OrderLine").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_OrderRev", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_OrderRev").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.OrderNo = Cmd.Parameters("@Return_OrderNo").Value
          Record.OrderLine = Cmd.Parameters("@Return_OrderLine").Value
          Record.OrderRev = Cmd.Parameters("@Return_OrderRev").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purOrderDetailsUpdate(ByVal Record As SIS.PUR.purOrderDetails) As SIS.PUR.purOrderDetails
      Dim _Rec As SIS.PUR.purOrderDetails = SIS.PUR.purOrderDetails.purOrderDetailsGetByID(Record.OrderNo, Record.OrderLine, Record.OrderRev)
      With _Rec
        .ItemCode = Record.ItemCode
        .UOM = Record.UOM
        .ItemDescription = Record.ItemDescription
        .Quantity = Record.Quantity
        .Price = Record.Price
        .DeliveryDate = Record.DeliveryDate
        .TotalGST = Record.TotalGST
        .TotalAmountINR = Record.TotalAmountINR
        .TaxCode = Record.TaxCode
        .AssessableValue = Record.AssessableValue
        .IGSTrate = Record.IGSTrate
        .TaxAmount = Record.TaxAmount
        .CGSTRate = Record.CGSTRate
        .CGSTAmount = Record.CGSTAmount
        .TCSRate = Record.TCSRate
        .CESSAmount = Record.CESSAmount
        .SGSTRate = Record.SGSTRate
        .SGSTAmount = Record.SGSTAmount
        .CESSRate = Record.CESSRate
        .Amount = Record.Amount
        .TotalAmount = Record.TotalAmount
        .TCSAmount = Record.TCSAmount
        .IGSTAmount = Record.IGSTAmount
        .ReceiptLine = Record.ReceiptLine
        .BillType = Record.BillType
        .HSNSACCode = Record.HSNSACCode
        .CurrencyID = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .TranTypeID = Record.TranTypeID
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .EmployeeID = Record.EmployeeID
        .DepartmentID = Record.DepartmentID
        .CostCenterID = Record.CostCenterID
        .DivisionID = Record.DivisionID
        .ReceiptNo = Record.ReceiptNo
        '===============
        .OriginalQuantity = Convert.ToDecimal(Record.Quantity) - Convert.ToDecimal(.ReceivedQuantity)
      End With
      Return SIS.PUR.purOrderDetails.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purOrderDetails) As SIS.PUR.purOrderDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrderDetailsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderLine",SqlDbType.Int,11, Record.OrderLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderRev",SqlDbType.Int,11, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderNo",SqlDbType.Int,11, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.Int,11, Iif(Record.ItemCode= "" ,Convert.DBNull, Record.ItemCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM",SqlDbType.NVarChar,4, Iif(Record.UOM= "" ,Convert.DBNull, Record.UOM))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,1001, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,23, Iif(Record.Quantity= "" ,Convert.DBNull, Record.Quantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Price",SqlDbType.Decimal,23, Iif(Record.Price= "" ,Convert.DBNull, Record.Price))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryDate",SqlDbType.DateTime,21, Iif(Record.DeliveryDate= "" ,Convert.DBNull, Record.DeliveryDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalGST",SqlDbType.Decimal,23, Iif(Record.TotalGST= "" ,Convert.DBNull, Record.TotalGST))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmountINR",SqlDbType.Decimal,23, Iif(Record.TotalAmountINR= "" ,Convert.DBNull, Record.TotalAmountINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev",SqlDbType.Int,11, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxCode",SqlDbType.Int,11, Iif(Record.TaxCode= "" ,Convert.DBNull, Record.TaxCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssessableValue",SqlDbType.Decimal,23, Iif(Record.AssessableValue= "" ,Convert.DBNull, Record.AssessableValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.Int,11, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTrate",SqlDbType.Decimal,23, Iif(Record.IGSTrate= "" ,Convert.DBNull, Record.IGSTrate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxAmount",SqlDbType.Decimal,23, Iif(Record.TaxAmount= "" ,Convert.DBNull, Record.TaxAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTRate",SqlDbType.Decimal,23, Iif(Record.CGSTRate= "" ,Convert.DBNull, Record.CGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTAmount",SqlDbType.Decimal,23, Iif(Record.CGSTAmount= "" ,Convert.DBNull, Record.CGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCSRate",SqlDbType.Decimal,23, Iif(Record.TCSRate= "" ,Convert.DBNull, Record.TCSRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CESSAmount",SqlDbType.Decimal,23, Iif(Record.CESSAmount= "" ,Convert.DBNull, Record.CESSAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTRate",SqlDbType.Decimal,23, Iif(Record.SGSTRate= "" ,Convert.DBNull, Record.SGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTAmount",SqlDbType.Decimal,23, Iif(Record.SGSTAmount= "" ,Convert.DBNull, Record.SGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CESSRate",SqlDbType.Decimal,23, Iif(Record.CESSRate= "" ,Convert.DBNull, Record.CESSRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount",SqlDbType.Decimal,23, Iif(Record.Amount= "" ,Convert.DBNull, Record.Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmount",SqlDbType.Decimal,23, Iif(Record.TotalAmount= "" ,Convert.DBNull, Record.TotalAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCSAmount",SqlDbType.Decimal,23, Iif(Record.TCSAmount= "" ,Convert.DBNull, Record.TCSAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTAmount",SqlDbType.Decimal,23, Iif(Record.IGSTAmount= "" ,Convert.DBNull, Record.IGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptLine",SqlDbType.Int,11, Iif(Record.ReceiptLine= "" ,Convert.DBNull, Record.ReceiptLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillType",SqlDbType.Int,11, Iif(Record.BillType= "" ,Convert.DBNull, Record.BillType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSNSACCode",SqlDbType.NVarChar,21, Iif(Record.HSNSACCode= "" ,Convert.DBNull, Record.HSNSACCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,11, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,25, Iif(Record.ConversionFactorINR= "" ,Convert.DBNull, Record.ConversionFactorINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranTypeID",SqlDbType.NVarChar,4, Iif(Record.TranTypeID= "" ,Convert.DBNull, Record.TranTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Iif(Record.EmployeeID= "" ,Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Iif(Record.DepartmentID= "" ,Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MainLine",SqlDbType.Bit,3, Iif(Record.MainLine= "" ,Convert.DBNull, Record.MainLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedQuantity",SqlDbType.Decimal,23, Iif(Record.ReceivedQuantity= "" ,Convert.DBNull, Record.ReceivedQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo",SqlDbType.Int,11, Iif(Record.ReceiptNo= "" ,Convert.DBNull, Record.ReceiptNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentLine",SqlDbType.Int,11, Iif(Record.ParentLine= "" ,Convert.DBNull, Record.ParentLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OriginalQuantity",SqlDbType.Decimal,23, Iif(Record.OriginalQuantity= "" ,Convert.DBNull, Record.OriginalQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromIndent", SqlDbType.Bit, 3, Record.FromIndent)
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
    Public Shared Function purOrderDetailsDelete(ByVal Record As SIS.PUR.purOrderDetails) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrderDetailsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderNo",SqlDbType.Int,Record.OrderNo.ToString.Length, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderLine",SqlDbType.Int,Record.OrderLine.ToString.Length, Record.OrderLine)
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
    Public Shared Function SelectpurOrderDetailsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrderDetailsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(1000, " "),"" & "|" & "" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PUR.purOrderDetails = New SIS.PUR.purOrderDetails(Reader)
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
