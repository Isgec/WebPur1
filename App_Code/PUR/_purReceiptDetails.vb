Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purReceiptDetails
    Private Shared _RecordCount As Integer
    Public Property ReceiptNo As Int32 = 0
    Public Property ReceiptLine As Int32 = 0
    Public Property TranTypeID As String = ""
    Public Property BillType As String = ""
    Public Property HSNSACCode As String = ""
    Public Property ItemCode As String = ""
    Public Property UOM As String = ""
    Public Property ItemDescription As String = ""
    Public Property Quantity As String = "0.00"
    Public Property Price As String = "0.00"
    Public Property AssessableValue As String = "0.00"
    Public Property TaxCode As String = ""
    Public Property CGSTRate As String = "0.00"
    Public Property CGSTAmount As String = "0.00"
    Public Property SGSTRate As String = "0.00"
    Public Property SGSTAmount As String = "0.00"
    Public Property IGSTrate As String = "0.00"
    Public Property IGSTAmount As String = "0.00"
    Public Property CESSRate As String = "0.00"
    Public Property CESSAmount As String = "0.00"
    Public Property TCSRate As String = "0.00"
    Public Property TCSAmount As String = "0.00"
    Public Property CurrencyID As String = ""
    Public Property ConversionFactorINR As String = "0.00"
    Private _DeliveryDate As String = ""
    Public Property ProjectID As String = ""
    Public Property ElementID As String = ""
    Public Property EmployeeID As String = ""
    Public Property DepartmentID As String = ""
    Public Property CostCenterID As String = ""
    Public Property DivisionID As String = ""
    Public Property MainLine As String = ""
    Public Property ParentLine As String = ""
    Public Property Amount As String = "0.00"
    Public Property TotalGST As String = "0.00"
    Public Property TaxAmount As String = "0.00"
    Public Property TotalAmount As String = "0.00"
    Public Property TotalAmountINR As String = "0.00"
    Public Property OriginalQuantity As String = "0.00"
    Public Property FromOrder As Boolean = False
    Public Property HRM_Departments1_Description As String = ""
    Public Property HRM_Divisions2_Description As String = ""
    Public Property HRM_Employees3_EmployeeName As String = ""
    Public Property IDM_Projects4_Description As String = ""
    Public Property IDM_WBS5_Description As String = ""
    Public Property PUR_Currencies6_CurrencyName As String = ""
    Public Property PUR_Items7_ItemDescription As String = ""
    Public Property PUR_Receipts8_IsgecGSTIN As String = ""
    Public Property PUR_TaxCodes9_TaxDescription As String = ""
    Public Property SPMT_BillTypes10_Description As String = ""
    Public Property SPMT_CostCenters11_Description As String = ""
    Public Property SPMT_ERPUnits12_Description As String = ""
    Public Property SPMT_HSNSACCodes13_HSNSACCode As String = ""
    Public Property SPMT_TranTypes14_Description As String = ""
    Public Property IRNo As String = ""
    Public Property IRLine As String = ""
    Private _FK_PUR_ReceiptDetails_DepartmentID As SIS.QCM.qcmDepartments = Nothing
    Private _FK_PUR_ReceiptDetails_DivisionID As SIS.QCM.qcmDivisions = Nothing
    Private _FK_PUR_ReceiptDetails_EmployeeID As SIS.QCM.qcmEmployees = Nothing
    Private _FK_PUR_ReceiptDetails_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_PUR_ReceiptDetails_ElementID As SIS.PAK.pakWBS = Nothing
    Private _FK_PUR_ReceiptDetails_CurrencyID As SIS.PUR.purCurrencies = Nothing
    Private _FK_PUR_ReceiptDetails_ItemCode As SIS.PUR.purItems = Nothing
    Private _FK_PUR_ReceiptDetails_ReceiptNo As SIS.PUR.purReceipts = Nothing
    Private _FK_PUR_ReceiptDetails_TaxCode As SIS.PUR.purTaxCodes = Nothing
    Private _FK_PUR_ReceiptDetails_BillType As SIS.SPMT.spmtBillTypes = Nothing
    Private _FK_PUR_ReceiptDetails_CostCenterID As SIS.SPMT.spmtCostCenters = Nothing
    Private _FK_PUR_ReceiptDetails_UOM As SIS.SPMT.spmtERPUnits = Nothing
    Private _FK_PUR_ReceiptDetails_HSNSACCode As SIS.SPMT.spmtHSNSACCodes = Nothing
    Private _FK_PUR_ReceiptDetails_TranTypeID As SIS.SPMT.spmtTranTypes = Nothing
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
        Return _ReceiptNo & "|" & _ReceiptLine
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
    Public Class PKpurReceiptDetails
      Private _ReceiptNo As Int32 = 0
      Private _ReceiptLine As Int32 = 0
      Public Property ReceiptNo() As Int32
        Get
          Return _ReceiptNo
        End Get
        Set(ByVal value As Int32)
          _ReceiptNo = value
        End Set
      End Property
      Public Property ReceiptLine() As Int32
        Get
          Return _ReceiptLine
        End Get
        Set(ByVal value As Int32)
          _ReceiptLine = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PUR_ReceiptDetails_DepartmentID() As SIS.QCM.qcmDepartments
      Get
        If _FK_PUR_ReceiptDetails_DepartmentID Is Nothing Then
          _FK_PUR_ReceiptDetails_DepartmentID = SIS.QCM.qcmDepartments.qcmDepartmentsGetByID(_DepartmentID)
        End If
        Return _FK_PUR_ReceiptDetails_DepartmentID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptDetails_DivisionID() As SIS.QCM.qcmDivisions
      Get
        If _FK_PUR_ReceiptDetails_DivisionID Is Nothing Then
          _FK_PUR_ReceiptDetails_DivisionID = SIS.QCM.qcmDivisions.qcmDivisionsGetByID(_DivisionID)
        End If
        Return _FK_PUR_ReceiptDetails_DivisionID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptDetails_EmployeeID() As SIS.QCM.qcmEmployees
      Get
        If _FK_PUR_ReceiptDetails_EmployeeID Is Nothing Then
          _FK_PUR_ReceiptDetails_EmployeeID = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(_EmployeeID)
        End If
        Return _FK_PUR_ReceiptDetails_EmployeeID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptDetails_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_PUR_ReceiptDetails_ProjectID Is Nothing Then
          _FK_PUR_ReceiptDetails_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_PUR_ReceiptDetails_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptDetails_ElementID() As SIS.PAK.pakWBS
      Get
        If _FK_PUR_ReceiptDetails_ElementID Is Nothing Then
          _FK_PUR_ReceiptDetails_ElementID = SIS.PAK.pakWBS.pakWBSGetByID(_ElementID)
        End If
        Return _FK_PUR_ReceiptDetails_ElementID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptDetails_CurrencyID() As SIS.PUR.purCurrencies
      Get
        If _FK_PUR_ReceiptDetails_CurrencyID Is Nothing Then
          _FK_PUR_ReceiptDetails_CurrencyID = SIS.PUR.purCurrencies.purCurrenciesGetByID(_CurrencyID)
        End If
        Return _FK_PUR_ReceiptDetails_CurrencyID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptDetails_ItemCode() As SIS.PUR.purItems
      Get
        If _FK_PUR_ReceiptDetails_ItemCode Is Nothing Then
          _FK_PUR_ReceiptDetails_ItemCode = SIS.PUR.purItems.purItemsGetByID(_ItemCode)
        End If
        Return _FK_PUR_ReceiptDetails_ItemCode
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptDetails_ReceiptNo() As SIS.PUR.purReceipts
      Get
        If _FK_PUR_ReceiptDetails_ReceiptNo Is Nothing Then
          _FK_PUR_ReceiptDetails_ReceiptNo = SIS.PUR.purReceipts.purReceiptsGetByID(_ReceiptNo)
        End If
        Return _FK_PUR_ReceiptDetails_ReceiptNo
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptDetails_TaxCode() As SIS.PUR.purTaxCodes
      Get
        If _FK_PUR_ReceiptDetails_TaxCode Is Nothing Then
          _FK_PUR_ReceiptDetails_TaxCode = SIS.PUR.purTaxCodes.purTaxCodesGetByID(_TaxCode)
        End If
        Return _FK_PUR_ReceiptDetails_TaxCode
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptDetails_BillType() As SIS.SPMT.spmtBillTypes
      Get
        If _FK_PUR_ReceiptDetails_BillType Is Nothing Then
          _FK_PUR_ReceiptDetails_BillType = SIS.SPMT.spmtBillTypes.spmtBillTypesGetByID(_BillType)
        End If
        Return _FK_PUR_ReceiptDetails_BillType
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptDetails_CostCenterID() As SIS.SPMT.spmtCostCenters
      Get
        If _FK_PUR_ReceiptDetails_CostCenterID Is Nothing Then
          _FK_PUR_ReceiptDetails_CostCenterID = SIS.SPMT.spmtCostCenters.spmtCostCentersGetByID(_CostCenterID)
        End If
        Return _FK_PUR_ReceiptDetails_CostCenterID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptDetails_UOM() As SIS.SPMT.spmtERPUnits
      Get
        If _FK_PUR_ReceiptDetails_UOM Is Nothing Then
          _FK_PUR_ReceiptDetails_UOM = SIS.SPMT.spmtERPUnits.spmtERPUnitsGetByID(_UOM)
        End If
        Return _FK_PUR_ReceiptDetails_UOM
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptDetails_HSNSACCode() As SIS.SPMT.spmtHSNSACCodes
      Get
        If _FK_PUR_ReceiptDetails_HSNSACCode Is Nothing Then
          _FK_PUR_ReceiptDetails_HSNSACCode = SIS.SPMT.spmtHSNSACCodes.spmtHSNSACCodesGetByID(_BillType, _HSNSACCode)
        End If
        Return _FK_PUR_ReceiptDetails_HSNSACCode
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptDetails_TranTypeID() As SIS.SPMT.spmtTranTypes
      Get
        If _FK_PUR_ReceiptDetails_TranTypeID Is Nothing Then
          _FK_PUR_ReceiptDetails_TranTypeID = SIS.SPMT.spmtTranTypes.spmtTranTypesGetByID(_TranTypeID)
        End If
        Return _FK_PUR_ReceiptDetails_TranTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purReceiptDetailsSelectList(ByVal OrderBy As String) As List(Of SIS.PUR.purReceiptDetails)
      Dim Results As List(Of SIS.PUR.purReceiptDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptDetailsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purReceiptDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purReceiptDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purReceiptDetailsGetNewRecord() As SIS.PUR.purReceiptDetails
      Return New SIS.PUR.purReceiptDetails()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purReceiptDetailsGetByID(ByVal ReceiptNo As Int32, ByVal ReceiptLine As Int32) As SIS.PUR.purReceiptDetails
      Dim Results As SIS.PUR.purReceiptDetails = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptDetailsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo",SqlDbType.Int,ReceiptNo.ToString.Length, ReceiptNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptLine",SqlDbType.Int,ReceiptLine.ToString.Length, ReceiptLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purReceiptDetails(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purReceiptDetailsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ReceiptNo As Int32) As List(Of SIS.PUR.purReceiptDetails)
      Dim Results As List(Of SIS.PUR.purReceiptDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurReceiptDetailsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurReceiptDetailsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ReceiptNo",SqlDbType.Int,10, IIf(ReceiptNo = Nothing, 0,ReceiptNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purReceiptDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purReceiptDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purReceiptDetailsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ReceiptNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purReceiptDetailsGetByID(ByVal ReceiptNo As Int32, ByVal ReceiptLine As Int32, ByVal Filter_ReceiptNo As Int32) As SIS.PUR.purReceiptDetails
      Return purReceiptDetailsGetByID(ReceiptNo, ReceiptLine)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purReceiptDetailsInsert(ByVal Record As SIS.PUR.purReceiptDetails) As SIS.PUR.purReceiptDetails
      Dim _Rec As SIS.PUR.purReceiptDetails = SIS.PUR.purReceiptDetails.purReceiptDetailsGetNewRecord()
      With _Rec
        .ReceiptNo = Record.ReceiptNo
        .TranTypeID = Record.TranTypeID
        .BillType = Record.BillType
        .HSNSACCode = Record.HSNSACCode
        .ItemCode = Record.ItemCode
        .UOM = Record.UOM
        .ItemDescription = Record.ItemDescription
        .Quantity = Record.Quantity
        .Price = Record.Price
        .AssessableValue = Record.AssessableValue
        .TaxCode = Record.TaxCode
        .CGSTRate = Record.CGSTRate
        .CGSTAmount = Record.CGSTAmount
        .SGSTRate = Record.SGSTRate
        .SGSTAmount = Record.SGSTAmount
        .IGSTrate = Record.IGSTrate
        .IGSTAmount = Record.IGSTAmount
        .CESSRate = Record.CESSRate
        .CESSAmount = Record.CESSAmount
        .TCSRate = Record.TCSRate
        .TCSAmount = Record.TCSAmount
        .CurrencyID = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .DeliveryDate = Record.DeliveryDate
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .EmployeeID = Record.EmployeeID
        .DepartmentID = Record.DepartmentID
        .CostCenterID = Record.CostCenterID
        .DivisionID = Record.DivisionID
        .Amount = Record.Amount
        .TotalGST = Record.TotalGST
        .TaxAmount = Record.TaxAmount
        .TotalAmount = Record.TotalAmount
        .TotalAmountINR = Record.TotalAmountINR
        '======================
        .MainLine = True
        .ParentLine = ""
        .OriginalQuantity = Record.Quantity
      End With
      Return SIS.PUR.purReceiptDetails.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purReceiptDetails) As SIS.PUR.purReceiptDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptDetailsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo",SqlDbType.Int,11, Record.ReceiptNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranTypeID",SqlDbType.NVarChar,4, Iif(Record.TranTypeID= "" ,Convert.DBNull, Record.TranTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillType",SqlDbType.Int,11, Iif(Record.BillType= "" ,Convert.DBNull, Record.BillType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSNSACCode",SqlDbType.NVarChar,21, Iif(Record.HSNSACCode= "" ,Convert.DBNull, Record.HSNSACCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.Int,11, Iif(Record.ItemCode= "" ,Convert.DBNull, Record.ItemCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM",SqlDbType.NVarChar,4, Iif(Record.UOM= "" ,Convert.DBNull, Record.UOM))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,1001, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,23, Iif(Record.Quantity= "" ,Convert.DBNull, Record.Quantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Price",SqlDbType.Decimal,23, Iif(Record.Price= "" ,Convert.DBNull, Record.Price))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssessableValue",SqlDbType.Decimal,23, Iif(Record.AssessableValue= "" ,Convert.DBNull, Record.AssessableValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxCode",SqlDbType.Int,11, Iif(Record.TaxCode= "" ,Convert.DBNull, Record.TaxCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTRate",SqlDbType.Decimal,23, Iif(Record.CGSTRate= "" ,Convert.DBNull, Record.CGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTAmount",SqlDbType.Decimal,23, Iif(Record.CGSTAmount= "" ,Convert.DBNull, Record.CGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTRate",SqlDbType.Decimal,23, Iif(Record.SGSTRate= "" ,Convert.DBNull, Record.SGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTAmount",SqlDbType.Decimal,23, Iif(Record.SGSTAmount= "" ,Convert.DBNull, Record.SGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTrate",SqlDbType.Decimal,23, Iif(Record.IGSTrate= "" ,Convert.DBNull, Record.IGSTrate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTAmount",SqlDbType.Decimal,23, Iif(Record.IGSTAmount= "" ,Convert.DBNull, Record.IGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CESSRate",SqlDbType.Decimal,23, Iif(Record.CESSRate= "" ,Convert.DBNull, Record.CESSRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CESSAmount",SqlDbType.Decimal,23, Iif(Record.CESSAmount= "" ,Convert.DBNull, Record.CESSAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCSRate",SqlDbType.Decimal,23, Iif(Record.TCSRate= "" ,Convert.DBNull, Record.TCSRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCSAmount",SqlDbType.Decimal,23, Iif(Record.TCSAmount= "" ,Convert.DBNull, Record.TCSAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,11, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,25, Iif(Record.ConversionFactorINR= "" ,Convert.DBNull, Record.ConversionFactorINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryDate",SqlDbType.DateTime,21, Iif(Record.DeliveryDate= "" ,Convert.DBNull, Record.DeliveryDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Iif(Record.EmployeeID= "" ,Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Iif(Record.DepartmentID= "" ,Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MainLine",SqlDbType.Bit,3, Iif(Record.MainLine= "" ,Convert.DBNull, Record.MainLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentLine",SqlDbType.Int,11, Iif(Record.ParentLine= "" ,Convert.DBNull, Record.ParentLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount",SqlDbType.Decimal,23, Iif(Record.Amount= "" ,Convert.DBNull, Record.Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalGST",SqlDbType.Decimal,23, Iif(Record.TotalGST= "" ,Convert.DBNull, Record.TotalGST))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxAmount",SqlDbType.Decimal,23, Iif(Record.TaxAmount= "" ,Convert.DBNull, Record.TaxAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmount",SqlDbType.Decimal,23, Iif(Record.TotalAmount= "" ,Convert.DBNull, Record.TotalAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmountINR",SqlDbType.Decimal,23, Iif(Record.TotalAmountINR= "" ,Convert.DBNull, Record.TotalAmountINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OriginalQuantity",SqlDbType.Decimal,23, Iif(Record.OriginalQuantity= "" ,Convert.DBNull, Record.OriginalQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromOrder",SqlDbType.Bit,3, Record.FromOrder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo", SqlDbType.Int, 11, IIf(Record.IRNO = "", Convert.DBNull, Record.IRNO))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRLine", SqlDbType.Int, 11, IIf(Record.IRLine = "", Convert.DBNull, Record.IRLine))
          Cmd.Parameters.Add("@Return_ReceiptNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ReceiptNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ReceiptLine", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ReceiptLine").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ReceiptNo = Cmd.Parameters("@Return_ReceiptNo").Value
          Record.ReceiptLine = Cmd.Parameters("@Return_ReceiptLine").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purReceiptDetailsUpdate(ByVal Record As SIS.PUR.purReceiptDetails) As SIS.PUR.purReceiptDetails
      Dim _Rec As SIS.PUR.purReceiptDetails = SIS.PUR.purReceiptDetails.purReceiptDetailsGetByID(Record.ReceiptNo, Record.ReceiptLine)
      With _Rec
        .TranTypeID = Record.TranTypeID
        .BillType = Record.BillType
        .HSNSACCode = Record.HSNSACCode
        .ItemCode = Record.ItemCode
        .UOM = Record.UOM
        .ItemDescription = Record.ItemDescription
        .Quantity = Record.Quantity
        .Price = Record.Price
        .AssessableValue = Record.AssessableValue
        .TaxCode = Record.TaxCode
        .CGSTRate = Record.CGSTRate
        .CGSTAmount = Record.CGSTAmount
        .SGSTRate = Record.SGSTRate
        .SGSTAmount = Record.SGSTAmount
        .IGSTrate = Record.IGSTrate
        .IGSTAmount = Record.IGSTAmount
        .CESSRate = Record.CESSRate
        .CESSAmount = Record.CESSAmount
        .TCSRate = Record.TCSRate
        .TCSAmount = Record.TCSAmount
        .CurrencyID = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .DeliveryDate = Record.DeliveryDate
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .EmployeeID = Record.EmployeeID
        .DepartmentID = Record.DepartmentID
        .CostCenterID = Record.CostCenterID
        .DivisionID = Record.DivisionID
        .Amount = Record.Amount
        .TotalGST = Record.TotalGST
        .TaxAmount = Record.TaxAmount
        .TotalAmount = Record.TotalAmount
        .TotalAmountINR = Record.TotalAmountINR
        '============================
        .OriginalQuantity = Record.Quantity
      End With
      Return SIS.PUR.purReceiptDetails.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purReceiptDetails) As SIS.PUR.purReceiptDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptDetailsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ReceiptNo",SqlDbType.Int,11, Record.ReceiptNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ReceiptLine",SqlDbType.Int,11, Record.ReceiptLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo",SqlDbType.Int,11, Record.ReceiptNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranTypeID",SqlDbType.NVarChar,4, Iif(Record.TranTypeID= "" ,Convert.DBNull, Record.TranTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillType",SqlDbType.Int,11, Iif(Record.BillType= "" ,Convert.DBNull, Record.BillType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSNSACCode",SqlDbType.NVarChar,21, Iif(Record.HSNSACCode= "" ,Convert.DBNull, Record.HSNSACCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.Int,11, Iif(Record.ItemCode= "" ,Convert.DBNull, Record.ItemCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM",SqlDbType.NVarChar,4, Iif(Record.UOM= "" ,Convert.DBNull, Record.UOM))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,1001, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,23, Iif(Record.Quantity= "" ,Convert.DBNull, Record.Quantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Price",SqlDbType.Decimal,23, Iif(Record.Price= "" ,Convert.DBNull, Record.Price))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssessableValue",SqlDbType.Decimal,23, Iif(Record.AssessableValue= "" ,Convert.DBNull, Record.AssessableValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxCode",SqlDbType.Int,11, Iif(Record.TaxCode= "" ,Convert.DBNull, Record.TaxCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTRate",SqlDbType.Decimal,23, Iif(Record.CGSTRate= "" ,Convert.DBNull, Record.CGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTAmount",SqlDbType.Decimal,23, Iif(Record.CGSTAmount= "" ,Convert.DBNull, Record.CGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTRate",SqlDbType.Decimal,23, Iif(Record.SGSTRate= "" ,Convert.DBNull, Record.SGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTAmount",SqlDbType.Decimal,23, Iif(Record.SGSTAmount= "" ,Convert.DBNull, Record.SGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTrate",SqlDbType.Decimal,23, Iif(Record.IGSTrate= "" ,Convert.DBNull, Record.IGSTrate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTAmount",SqlDbType.Decimal,23, Iif(Record.IGSTAmount= "" ,Convert.DBNull, Record.IGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CESSRate",SqlDbType.Decimal,23, Iif(Record.CESSRate= "" ,Convert.DBNull, Record.CESSRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CESSAmount",SqlDbType.Decimal,23, Iif(Record.CESSAmount= "" ,Convert.DBNull, Record.CESSAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCSRate",SqlDbType.Decimal,23, Iif(Record.TCSRate= "" ,Convert.DBNull, Record.TCSRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCSAmount",SqlDbType.Decimal,23, Iif(Record.TCSAmount= "" ,Convert.DBNull, Record.TCSAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,11, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,25, Iif(Record.ConversionFactorINR= "" ,Convert.DBNull, Record.ConversionFactorINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryDate",SqlDbType.DateTime,21, Iif(Record.DeliveryDate= "" ,Convert.DBNull, Record.DeliveryDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Iif(Record.EmployeeID= "" ,Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Iif(Record.DepartmentID= "" ,Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MainLine",SqlDbType.Bit,3, Iif(Record.MainLine= "" ,Convert.DBNull, Record.MainLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentLine",SqlDbType.Int,11, Iif(Record.ParentLine= "" ,Convert.DBNull, Record.ParentLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount",SqlDbType.Decimal,23, Iif(Record.Amount= "" ,Convert.DBNull, Record.Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalGST",SqlDbType.Decimal,23, Iif(Record.TotalGST= "" ,Convert.DBNull, Record.TotalGST))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxAmount",SqlDbType.Decimal,23, Iif(Record.TaxAmount= "" ,Convert.DBNull, Record.TaxAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmount",SqlDbType.Decimal,23, Iif(Record.TotalAmount= "" ,Convert.DBNull, Record.TotalAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmountINR",SqlDbType.Decimal,23, Iif(Record.TotalAmountINR= "" ,Convert.DBNull, Record.TotalAmountINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OriginalQuantity",SqlDbType.Decimal,23, Iif(Record.OriginalQuantity= "" ,Convert.DBNull, Record.OriginalQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromOrder",SqlDbType.Bit,3, Record.FromOrder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo", SqlDbType.Int, 11, IIf(Record.IRNO = "", Convert.DBNull, Record.IRNO))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRLine", SqlDbType.Int, 11, IIf(Record.IRLine = "", Convert.DBNull, Record.IRLine))
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
    Public Shared Function purReceiptDetailsDelete(ByVal Record As SIS.PUR.purReceiptDetails) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptDetailsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ReceiptNo",SqlDbType.Int,Record.ReceiptNo.ToString.Length, Record.ReceiptNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ReceiptLine",SqlDbType.Int,Record.ReceiptLine.ToString.Length, Record.ReceiptLine)
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
    Public Shared Function SelectpurReceiptDetailsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptDetailsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(1000, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PUR.purReceiptDetails = New SIS.PUR.purReceiptDetails(Reader)
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
