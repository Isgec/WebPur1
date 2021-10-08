Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purHOrders
    Private Shared _RecordCount As Integer
    Public Property OrderNo As Int32 = 0
    Public Property OrderRev As Int32 = 0
    Private _OrderDate As String = ""
    Public Property PurchaseTypeID As String = ""
    Public Property TranTypeID As String = ""
    Public Property StatusID As String = ""
    Public Property IsgecGSTIN As String = ""
    Public Property IsgecGSTINAddress As String = ""
    Public Property DestinationAddress As String = ""
    Public Property QuatationNo As String = ""
    Private _QuotationDate As String = ""
    Public Property SupplierID As String = ""
    Public Property SupplierGSTIN As String = ""
    Public Property SupplierName As String = ""
    Public Property SupplierGSTINUMBER As String = ""
    Private _DeliveryDate As String = ""
    Public Property PaymentTerms As String = ""
    Public Property DeliveryTerms As String = ""
    Public Property ModeOfDispatch As String = ""
    Public Property InsuranceDetails As String = ""
    Public Property WarrantyDetails As String = ""
    Public Property BuyerRemarks As String = ""
    Public Property CurrencyID As String = ""
    Public Property ConversionFactorINR As String = "0.00"
    Public Property AprTypeID As String = ""
    Public Property CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Public Property ApprovedBy As String = ""
    Private _ApprovedOn As String = ""
    Public Property ApproverRemarks As String = ""
    Public Property ProjectID As String = ""
    Public Property ElementID As String = ""
    Public Property EmployeeID As String = ""
    Public Property DepartmentID As String = ""
    Public Property CostCenterID As String = ""
    Public Property DivisionID As String = ""
    Public Property OrderText As String = ""
    Public Property ReasonOfRevision As String = ""
    Public Property IssuedBy As String = ""
    Private _IssuedOn As String = ""
    Public Property RevisedBy As String = ""
    Private _RevisedOn As String = ""
    Public Property ShipToState As String = ""
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
    Public Property OrderDate() As String
      Get
        If Not _OrderDate = String.Empty Then
          Return Convert.ToDateTime(_OrderDate).ToString("dd/MM/yyyy")
        End If
        Return _OrderDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _OrderDate = ""
         Else
           _OrderDate = value
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
    Public Property IssuedOn() As String
      Get
        If Not _IssuedOn = String.Empty Then
          Return Convert.ToDateTime(_IssuedOn).ToString("dd/MM/yyyy")
        End If
        Return _IssuedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
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
         If Convert.IsDBNull(Value) Then
           _RevisedOn = ""
         Else
           _RevisedOn = value
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
    Public Class PKpurHOrders
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purHOrdersGetNewRecord() As SIS.PUR.purHOrders
      Return New SIS.PUR.purHOrders()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purHOrdersGetByID(ByVal OrderNo As Int32, ByVal OrderRev As Int32) As SIS.PUR.purHOrders
      Dim Results As SIS.PUR.purHOrders = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurHOrdersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.Int,OrderNo.ToString.Length, OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev",SqlDbType.Int,OrderRev.ToString.Length, OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purHOrders(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purHOrdersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.PUR.purHOrders)
      Dim Results As List(Of SIS.PUR.purHOrders) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "OrderNo DESC, OrderRev DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurHOrdersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurHOrdersSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purHOrders)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purHOrders(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purHOrdersSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purHOrdersInsert(ByVal Record As SIS.PUR.purHOrders) As SIS.PUR.purHOrders
      Dim _Rec As SIS.PUR.purHOrders = SIS.PUR.purHOrders.purHOrdersGetNewRecord()
      With _Rec
        .OrderNo = Record.OrderNo
        .OrderRev = Record.OrderRev
        .OrderDate = Record.OrderDate
        .PurchaseTypeID = Record.PurchaseTypeID
        .TranTypeID = Record.TranTypeID
        .StatusID = Record.StatusID
        .IsgecGSTIN = Record.IsgecGSTIN
        .IsgecGSTINAddress = Record.IsgecGSTINAddress
        .DestinationAddress = Record.DestinationAddress
        .QuatationNo = Record.QuatationNo
        .QuotationDate = Record.QuotationDate
        .SupplierID = Record.SupplierID
        .SupplierGSTIN = Record.SupplierGSTIN
        .SupplierName = Record.SupplierName
        .SupplierGSTINUMBER = Record.SupplierGSTINUMBER
        .DeliveryDate = Record.DeliveryDate
        .PaymentTerms = Record.PaymentTerms
        .DeliveryTerms = Record.DeliveryTerms
        .ModeOfDispatch = Record.ModeOfDispatch
        .InsuranceDetails = Record.InsuranceDetails
        .WarrantyDetails = Record.WarrantyDetails
        .BuyerRemarks = Record.BuyerRemarks
        .CurrencyID = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .AprTypeID = Record.AprTypeID
        .CreatedBy = Record.CreatedBy
        .CreatedOn = Record.CreatedOn
        .ApprovedBy = Record.ApprovedBy
        .ApprovedOn = Record.ApprovedOn
        .ApproverRemarks = Record.ApproverRemarks
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .EmployeeID = Record.EmployeeID
        .DepartmentID = Record.DepartmentID
        .CostCenterID = Record.CostCenterID
        .DivisionID = Record.DivisionID
        .OrderText = Record.OrderText
        .ReasonOfRevision = Record.ReasonOfRevision
        .IssuedBy = Record.IssuedBy
        .IssuedOn = Record.IssuedOn
        .RevisedBy = Record.RevisedBy
        .RevisedOn = Record.RevisedOn
        .ShipToState = Record.ShipToState
      End With
      Return SIS.PUR.purHOrders.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purHOrders) As SIS.PUR.purHOrders
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurHOrdersInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.Int,11, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev",SqlDbType.Int,11, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderDate",SqlDbType.DateTime,21, Iif(Record.OrderDate= "" ,Convert.DBNull, Record.OrderDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PurchaseTypeID",SqlDbType.NVarChar,101, Iif(Record.PurchaseTypeID= "" ,Convert.DBNull, Record.PurchaseTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranTypeID",SqlDbType.NVarChar,4, Iif(Record.TranTypeID= "" ,Convert.DBNull, Record.TranTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTIN",SqlDbType.Int,11, Iif(Record.IsgecGSTIN= "" ,Convert.DBNull, Record.IsgecGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTINAddress",SqlDbType.NVarChar,501, Iif(Record.IsgecGSTINAddress= "" ,Convert.DBNull, Record.IsgecGSTINAddress))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DestinationAddress",SqlDbType.NVarChar,501, Iif(Record.DestinationAddress= "" ,Convert.DBNull, Record.DestinationAddress))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuatationNo",SqlDbType.NVarChar,21, Iif(Record.QuatationNo= "" ,Convert.DBNull, Record.QuatationNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuotationDate",SqlDbType.DateTime,21, Iif(Record.QuotationDate= "" ,Convert.DBNull, Record.QuotationDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTIN",SqlDbType.Int,11, Iif(Record.SupplierGSTIN= "" ,Convert.DBNull, Record.SupplierGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.NVarChar,51, Iif(Record.SupplierName= "" ,Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTINUMBER",SqlDbType.NVarChar,51, Iif(Record.SupplierGSTINUMBER= "" ,Convert.DBNull, Record.SupplierGSTINUMBER))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryDate",SqlDbType.DateTime,21, Iif(Record.DeliveryDate= "" ,Convert.DBNull, Record.DeliveryDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentTerms",SqlDbType.NVarChar,501, Iif(Record.PaymentTerms= "" ,Convert.DBNull, Record.PaymentTerms))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryTerms",SqlDbType.NVarChar,501, Iif(Record.DeliveryTerms= "" ,Convert.DBNull, Record.DeliveryTerms))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeOfDispatch",SqlDbType.NVarChar,51, Iif(Record.ModeOfDispatch= "" ,Convert.DBNull, Record.ModeOfDispatch))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InsuranceDetails",SqlDbType.NVarChar,201, Iif(Record.InsuranceDetails= "" ,Convert.DBNull, Record.InsuranceDetails))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WarrantyDetails",SqlDbType.NVarChar,1001, Iif(Record.WarrantyDetails= "" ,Convert.DBNull, Record.WarrantyDetails))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerRemarks",SqlDbType.NVarChar,501, Iif(Record.BuyerRemarks= "" ,Convert.DBNull, Record.BuyerRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,11, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,25, Iif(Record.ConversionFactorINR= "" ,Convert.DBNull, Record.ConversionFactorINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AprTypeID",SqlDbType.NVarChar,11, Iif(Record.AprTypeID= "" ,Convert.DBNull, Record.AprTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,201, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Iif(Record.EmployeeID= "" ,Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Iif(Record.DepartmentID= "" ,Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderText",SqlDbType.NVarChar,4001, Iif(Record.OrderText= "" ,Convert.DBNull, Record.OrderText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReasonOfRevision",SqlDbType.NVarChar,201, Iif(Record.ReasonOfRevision= "" ,Convert.DBNull, Record.ReasonOfRevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedBy",SqlDbType.NVarChar,9, Iif(Record.IssuedBy= "" ,Convert.DBNull, Record.IssuedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedOn",SqlDbType.DateTime,21, Iif(Record.IssuedOn= "" ,Convert.DBNull, Record.IssuedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisedBy",SqlDbType.NVarChar,9, Iif(Record.RevisedBy= "" ,Convert.DBNull, Record.RevisedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisedOn",SqlDbType.DateTime,21, Iif(Record.RevisedOn= "" ,Convert.DBNull, Record.RevisedOn))
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
    Public Shared Function purHOrdersUpdate(ByVal Record As SIS.PUR.purHOrders) As SIS.PUR.purHOrders
      Dim _Rec As SIS.PUR.purHOrders = SIS.PUR.purHOrders.purHOrdersGetByID(Record.OrderNo, Record.OrderRev)
      With _Rec
        .OrderDate = Record.OrderDate
        .PurchaseTypeID = Record.PurchaseTypeID
        .TranTypeID = Record.TranTypeID
        .StatusID = Record.StatusID
        .IsgecGSTIN = Record.IsgecGSTIN
        .IsgecGSTINAddress = Record.IsgecGSTINAddress
        .DestinationAddress = Record.DestinationAddress
        .QuatationNo = Record.QuatationNo
        .QuotationDate = Record.QuotationDate
        .SupplierID = Record.SupplierID
        .SupplierGSTIN = Record.SupplierGSTIN
        .SupplierName = Record.SupplierName
        .SupplierGSTINUMBER = Record.SupplierGSTINUMBER
        .DeliveryDate = Record.DeliveryDate
        .PaymentTerms = Record.PaymentTerms
        .DeliveryTerms = Record.DeliveryTerms
        .ModeOfDispatch = Record.ModeOfDispatch
        .InsuranceDetails = Record.InsuranceDetails
        .WarrantyDetails = Record.WarrantyDetails
        .BuyerRemarks = Record.BuyerRemarks
        .CurrencyID = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .AprTypeID = Record.AprTypeID
        .CreatedBy = Record.CreatedBy
        .CreatedOn = Record.CreatedOn
        .ApprovedBy = Record.ApprovedBy
        .ApprovedOn = Record.ApprovedOn
        .ApproverRemarks = Record.ApproverRemarks
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .EmployeeID = Record.EmployeeID
        .DepartmentID = Record.DepartmentID
        .CostCenterID = Record.CostCenterID
        .DivisionID = Record.DivisionID
        .OrderText = Record.OrderText
        .ReasonOfRevision = Record.ReasonOfRevision
        .IssuedBy = Record.IssuedBy
        .IssuedOn = Record.IssuedOn
        .RevisedBy = Record.RevisedBy
        .RevisedOn = Record.RevisedOn
        .ShipToState = Record.ShipToState
      End With
      Return SIS.PUR.purHOrders.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purHOrders) As SIS.PUR.purHOrders
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurHOrdersUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderNo",SqlDbType.Int,11, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderRev",SqlDbType.Int,11, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.Int,11, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev",SqlDbType.Int,11, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderDate",SqlDbType.DateTime,21, Iif(Record.OrderDate= "" ,Convert.DBNull, Record.OrderDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PurchaseTypeID",SqlDbType.NVarChar,101, Iif(Record.PurchaseTypeID= "" ,Convert.DBNull, Record.PurchaseTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranTypeID",SqlDbType.NVarChar,4, Iif(Record.TranTypeID= "" ,Convert.DBNull, Record.TranTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTIN",SqlDbType.Int,11, Iif(Record.IsgecGSTIN= "" ,Convert.DBNull, Record.IsgecGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTINAddress",SqlDbType.NVarChar,501, Iif(Record.IsgecGSTINAddress= "" ,Convert.DBNull, Record.IsgecGSTINAddress))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DestinationAddress",SqlDbType.NVarChar,501, Iif(Record.DestinationAddress= "" ,Convert.DBNull, Record.DestinationAddress))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuatationNo",SqlDbType.NVarChar,21, Iif(Record.QuatationNo= "" ,Convert.DBNull, Record.QuatationNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuotationDate",SqlDbType.DateTime,21, Iif(Record.QuotationDate= "" ,Convert.DBNull, Record.QuotationDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTIN",SqlDbType.Int,11, Iif(Record.SupplierGSTIN= "" ,Convert.DBNull, Record.SupplierGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.NVarChar,51, Iif(Record.SupplierName= "" ,Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTINUMBER",SqlDbType.NVarChar,51, Iif(Record.SupplierGSTINUMBER= "" ,Convert.DBNull, Record.SupplierGSTINUMBER))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryDate",SqlDbType.DateTime,21, Iif(Record.DeliveryDate= "" ,Convert.DBNull, Record.DeliveryDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentTerms",SqlDbType.NVarChar,501, Iif(Record.PaymentTerms= "" ,Convert.DBNull, Record.PaymentTerms))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryTerms",SqlDbType.NVarChar,501, Iif(Record.DeliveryTerms= "" ,Convert.DBNull, Record.DeliveryTerms))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeOfDispatch",SqlDbType.NVarChar,51, Iif(Record.ModeOfDispatch= "" ,Convert.DBNull, Record.ModeOfDispatch))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InsuranceDetails",SqlDbType.NVarChar,201, Iif(Record.InsuranceDetails= "" ,Convert.DBNull, Record.InsuranceDetails))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WarrantyDetails",SqlDbType.NVarChar,1001, Iif(Record.WarrantyDetails= "" ,Convert.DBNull, Record.WarrantyDetails))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerRemarks",SqlDbType.NVarChar,501, Iif(Record.BuyerRemarks= "" ,Convert.DBNull, Record.BuyerRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,11, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,25, Iif(Record.ConversionFactorINR= "" ,Convert.DBNull, Record.ConversionFactorINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AprTypeID",SqlDbType.NVarChar,11, Iif(Record.AprTypeID= "" ,Convert.DBNull, Record.AprTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,201, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Iif(Record.EmployeeID= "" ,Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Iif(Record.DepartmentID= "" ,Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderText",SqlDbType.NVarChar,4001, Iif(Record.OrderText= "" ,Convert.DBNull, Record.OrderText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReasonOfRevision",SqlDbType.NVarChar,201, Iif(Record.ReasonOfRevision= "" ,Convert.DBNull, Record.ReasonOfRevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedBy",SqlDbType.NVarChar,9, Iif(Record.IssuedBy= "" ,Convert.DBNull, Record.IssuedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedOn",SqlDbType.DateTime,21, Iif(Record.IssuedOn= "" ,Convert.DBNull, Record.IssuedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisedBy",SqlDbType.NVarChar,9, Iif(Record.RevisedBy= "" ,Convert.DBNull, Record.RevisedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisedOn",SqlDbType.DateTime,21, Iif(Record.RevisedOn= "" ,Convert.DBNull, Record.RevisedOn))
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
    Public Shared Function purHOrdersDelete(ByVal Record As SIS.PUR.purHOrders) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurHOrdersDelete"
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
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
