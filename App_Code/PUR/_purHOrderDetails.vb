Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purHOrderDetails
    Private Shared _RecordCount As Integer
    Public Property OrderNo As Int32 = 0
    Public Property OrderRev As Int32 = 0
    Public Property OrderLine As Int32 = 0
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
    Public Property ReceiptNo As String = ""
    Public Property ReceiptLine As String = ""
    Public Property ReceivedQuantity As String = "0.00"
    Public Property Amount As String = "0.00"
    Public Property TotalGST As String = "0.00"
    Public Property TaxAmount As String = "0.00"
    Public Property TotalAmount As String = "0.00"
    Public Property TotalAmountINR As String = "0.00"
    Public Property OriginalQuantity As String = "0.00"
    Public Property FromIndent As Boolean = False
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
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _OrderNo & "|" & _OrderRev & "|" & _OrderLine
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
    Public Class PKpurHOrderDetails
      Private _OrderNo As Int32 = 0
      Private _OrderRev As Int32 = 0
      Private _OrderLine As Int32 = 0
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
      Public Property OrderLine() As Int32
        Get
          Return _OrderLine
        End Get
        Set(ByVal value As Int32)
          _OrderLine = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purHOrderDetailsGetNewRecord() As SIS.PUR.purHOrderDetails
      Return New SIS.PUR.purHOrderDetails()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purHOrderDetailsGetByID(ByVal OrderNo As Int32, ByVal OrderRev As Int32, ByVal OrderLine As Int32) As SIS.PUR.purHOrderDetails
      Dim Results As SIS.PUR.purHOrderDetails = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurHOrderDetailsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.Int,OrderNo.ToString.Length, OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev",SqlDbType.Int,OrderRev.ToString.Length, OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderLine",SqlDbType.Int,OrderLine.ToString.Length, OrderLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purHOrderDetails(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purHOrderDetailsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal OrderNo As Int32, ByVal OrderRev As Int32) As List(Of SIS.PUR.purHOrderDetails)
      Dim Results As List(Of SIS.PUR.purHOrderDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurHOrderDetailsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurHOrderDetailsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_OrderNo",SqlDbType.Int,10, IIf(OrderNo = Nothing, 0,OrderNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_OrderRev",SqlDbType.Int,10, IIf(OrderRev = Nothing, 0,OrderRev))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purHOrderDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purHOrderDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purHOrderDetailsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal OrderNo As Int32, ByVal OrderRev As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purHOrderDetailsGetByID(ByVal OrderNo As Int32, ByVal OrderRev As Int32, ByVal OrderLine As Int32, ByVal Filter_OrderNo As Int32, ByVal Filter_OrderRev As Int32) As SIS.PUR.purHOrderDetails
      Return purHOrderDetailsGetByID(OrderNo, OrderRev, OrderLine)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purHOrderDetailsInsert(ByVal Record As SIS.PUR.purHOrderDetails) As SIS.PUR.purHOrderDetails
      Dim _Rec As SIS.PUR.purHOrderDetails = SIS.PUR.purHOrderDetails.purHOrderDetailsGetNewRecord()
      With _Rec
        .OrderNo = Record.OrderNo
        .OrderRev = Record.OrderRev
        .OrderLine = Record.OrderLine
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
        .MainLine = Record.MainLine
        .ParentLine = Record.ParentLine
        .ReceiptNo = Record.ReceiptNo
        .ReceiptLine = Record.ReceiptLine
        .ReceivedQuantity = Record.ReceivedQuantity
        .Amount = Record.Amount
        .TotalGST = Record.TotalGST
        .TaxAmount = Record.TaxAmount
        .TotalAmount = Record.TotalAmount
        .TotalAmountINR = Record.TotalAmountINR
        .OriginalQuantity = Record.OriginalQuantity
        .FromIndent = Record.FromIndent
      End With
      Return SIS.PUR.purHOrderDetails.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purHOrderDetails) As SIS.PUR.purHOrderDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurHOrderDetailsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.Int,11, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev",SqlDbType.Int,11, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderLine",SqlDbType.Int,11, Record.OrderLine)
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
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo",SqlDbType.Int,11, Iif(Record.ReceiptNo= "" ,Convert.DBNull, Record.ReceiptNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptLine",SqlDbType.Int,11, Iif(Record.ReceiptLine= "" ,Convert.DBNull, Record.ReceiptLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedQuantity",SqlDbType.Decimal,23, Iif(Record.ReceivedQuantity= "" ,Convert.DBNull, Record.ReceivedQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount",SqlDbType.Decimal,23, Iif(Record.Amount= "" ,Convert.DBNull, Record.Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalGST",SqlDbType.Decimal,23, Iif(Record.TotalGST= "" ,Convert.DBNull, Record.TotalGST))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxAmount",SqlDbType.Decimal,23, Iif(Record.TaxAmount= "" ,Convert.DBNull, Record.TaxAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmount",SqlDbType.Decimal,23, Iif(Record.TotalAmount= "" ,Convert.DBNull, Record.TotalAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmountINR",SqlDbType.Decimal,23, Iif(Record.TotalAmountINR= "" ,Convert.DBNull, Record.TotalAmountINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OriginalQuantity",SqlDbType.Decimal,23, Iif(Record.OriginalQuantity= "" ,Convert.DBNull, Record.OriginalQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromIndent",SqlDbType.Bit,3, Record.FromIndent)
          Cmd.Parameters.Add("@Return_OrderNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_OrderNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_OrderRev", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_OrderRev").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_OrderLine", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_OrderLine").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.OrderNo = Cmd.Parameters("@Return_OrderNo").Value
          Record.OrderRev = Cmd.Parameters("@Return_OrderRev").Value
          Record.OrderLine = Cmd.Parameters("@Return_OrderLine").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purHOrderDetailsUpdate(ByVal Record As SIS.PUR.purHOrderDetails) As SIS.PUR.purHOrderDetails
      Dim _Rec As SIS.PUR.purHOrderDetails = SIS.PUR.purHOrderDetails.purHOrderDetailsGetByID(Record.OrderNo, Record.OrderRev, Record.OrderLine)
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
        .MainLine = Record.MainLine
        .ParentLine = Record.ParentLine
        .ReceiptNo = Record.ReceiptNo
        .ReceiptLine = Record.ReceiptLine
        .ReceivedQuantity = Record.ReceivedQuantity
        .Amount = Record.Amount
        .TotalGST = Record.TotalGST
        .TaxAmount = Record.TaxAmount
        .TotalAmount = Record.TotalAmount
        .TotalAmountINR = Record.TotalAmountINR
        .OriginalQuantity = Record.OriginalQuantity
        .FromIndent = Record.FromIndent
      End With
      Return SIS.PUR.purHOrderDetails.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purHOrderDetails) As SIS.PUR.purHOrderDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurHOrderDetailsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderNo",SqlDbType.Int,11, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderRev",SqlDbType.Int,11, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderLine",SqlDbType.Int,11, Record.OrderLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.Int,11, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev",SqlDbType.Int,11, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderLine",SqlDbType.Int,11, Record.OrderLine)
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
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo",SqlDbType.Int,11, Iif(Record.ReceiptNo= "" ,Convert.DBNull, Record.ReceiptNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptLine",SqlDbType.Int,11, Iif(Record.ReceiptLine= "" ,Convert.DBNull, Record.ReceiptLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedQuantity",SqlDbType.Decimal,23, Iif(Record.ReceivedQuantity= "" ,Convert.DBNull, Record.ReceivedQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount",SqlDbType.Decimal,23, Iif(Record.Amount= "" ,Convert.DBNull, Record.Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalGST",SqlDbType.Decimal,23, Iif(Record.TotalGST= "" ,Convert.DBNull, Record.TotalGST))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxAmount",SqlDbType.Decimal,23, Iif(Record.TaxAmount= "" ,Convert.DBNull, Record.TaxAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmount",SqlDbType.Decimal,23, Iif(Record.TotalAmount= "" ,Convert.DBNull, Record.TotalAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmountINR",SqlDbType.Decimal,23, Iif(Record.TotalAmountINR= "" ,Convert.DBNull, Record.TotalAmountINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OriginalQuantity",SqlDbType.Decimal,23, Iif(Record.OriginalQuantity= "" ,Convert.DBNull, Record.OriginalQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromIndent",SqlDbType.Bit,3, Record.FromIndent)
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
    Public Shared Function purHOrderDetailsDelete(ByVal Record As SIS.PUR.purHOrderDetails) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurHOrderDetailsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderNo",SqlDbType.Int,Record.OrderNo.ToString.Length, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderRev",SqlDbType.Int,Record.OrderRev.ToString.Length, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderLine",SqlDbType.Int,Record.OrderLine.ToString.Length, Record.OrderLine)
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
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
