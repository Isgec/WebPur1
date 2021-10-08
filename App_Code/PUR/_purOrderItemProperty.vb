Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purOrderItemProperty
    Private Shared _RecordCount As Integer
    Public Property CategorySpecID As Int32 = 0
    Public Property SerialNo As String = ""
    Public Property ValueDataTypeID As String = ""
    Public Property IsRange As String = ""
    Public Property Data1Value As String = ""
    Public Property Data2Value As String = ""
    Public Property ItemCode As Int32 = 0
    Public Property OrderLine As Int32 = 0
    Public Property OrderNo As Int32 = 0
    Public Property OrderRev As Int32 = 0
    Public Property ItemCategoryID As Int32 = 0
    Public Property PUR_ItemCategories1_CategoryName As String = ""
    Public Property PUR_ItemCategorySpecs2_SpecName As String = ""
    Public Property PUR_ItemCategorySpecValues3_Data1Value As String = ""
    Public Property PUR_Items4_ItemDescription As String = ""
    Public Property PUR_OrderDetails5_ItemDescription As String = ""
    Public Property PUR_Orders6_IsgecGSTIN As String = ""
    Public Property PUR_ValueDataTypes7_ValueDataTypeName As String = ""
    Private _FK_PUR_OrderItemProperty_ItemCategoryID As SIS.PUR.purItemCategories = Nothing
    Private _FK_PUR_OrderItemProperty_CategorySpecID As SIS.PUR.purItemCategorySpecs = Nothing
    Private _FK_PUR_OrderItemProperty_SerialNo As SIS.PUR.purItemCategorySpecValues = Nothing
    Private _FK_PUR_OrderItemProperty_ItemCode As SIS.PUR.purItems = Nothing
    Private _FK_PUR_OrderItemProperty_OrderLine As SIS.PUR.purOrderDetails = Nothing
    Private _FK_PUR_OrderItemProperty_OrderNo As SIS.PUR.purOrders = Nothing
    Private _FK_PUR_OrderItemProperty_ValueDataTypeID As SIS.PUR.purValueDataTypes = Nothing
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
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _OrderNo & "|" & _OrderRev & "|" & _OrderLine & "|" & _ItemCode & "|" & _ItemCategoryID & "|" & _CategorySpecID
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
    Public Class PKpurOrderItemProperty
      Private _OrderNo As Int32 = 0
      Private _OrderRev As Int32 = 0
      Private _OrderLine As Int32 = 0
      Private _ItemCode As Int32 = 0
      Private _ItemCategoryID As Int32 = 0
      Private _CategorySpecID As Int32 = 0
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
      Public Property ItemCode() As Int32
        Get
          Return _ItemCode
        End Get
        Set(ByVal value As Int32)
          _ItemCode = value
        End Set
      End Property
      Public Property ItemCategoryID() As Int32
        Get
          Return _ItemCategoryID
        End Get
        Set(ByVal value As Int32)
          _ItemCategoryID = value
        End Set
      End Property
      Public Property CategorySpecID() As Int32
        Get
          Return _CategorySpecID
        End Get
        Set(ByVal value As Int32)
          _CategorySpecID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PUR_OrderItemProperty_ItemCategoryID() As SIS.PUR.purItemCategories
      Get
        If _FK_PUR_OrderItemProperty_ItemCategoryID Is Nothing Then
          _FK_PUR_OrderItemProperty_ItemCategoryID = SIS.PUR.purItemCategories.purItemCategoriesGetByID(_ItemCategoryID)
        End If
        Return _FK_PUR_OrderItemProperty_ItemCategoryID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderItemProperty_CategorySpecID() As SIS.PUR.purItemCategorySpecs
      Get
        If _FK_PUR_OrderItemProperty_CategorySpecID Is Nothing Then
          _FK_PUR_OrderItemProperty_CategorySpecID = SIS.PUR.purItemCategorySpecs.purItemCategorySpecsGetByID(_ItemCategoryID, _CategorySpecID)
        End If
        Return _FK_PUR_OrderItemProperty_CategorySpecID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderItemProperty_SerialNo() As SIS.PUR.purItemCategorySpecValues
      Get
        If _FK_PUR_OrderItemProperty_SerialNo Is Nothing Then
          _FK_PUR_OrderItemProperty_SerialNo = SIS.PUR.purItemCategorySpecValues.purItemCategorySpecValuesGetByID(_ItemCategoryID, _CategorySpecID, _SerialNo)
        End If
        Return _FK_PUR_OrderItemProperty_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderItemProperty_ItemCode() As SIS.PUR.purItems
      Get
        If _FK_PUR_OrderItemProperty_ItemCode Is Nothing Then
          _FK_PUR_OrderItemProperty_ItemCode = SIS.PUR.purItems.purItemsGetByID(_ItemCode)
        End If
        Return _FK_PUR_OrderItemProperty_ItemCode
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderItemProperty_OrderLine() As SIS.PUR.purOrderDetails
      Get
        If _FK_PUR_OrderItemProperty_OrderLine Is Nothing Then
          _FK_PUR_OrderItemProperty_OrderLine = SIS.PUR.purOrderDetails.purOrderDetailsGetByID(_OrderNo, _OrderRev, _OrderLine)
        End If
        Return _FK_PUR_OrderItemProperty_OrderLine
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderItemProperty_OrderNo() As SIS.PUR.purOrders
      Get
        If _FK_PUR_OrderItemProperty_OrderNo Is Nothing Then
          _FK_PUR_OrderItemProperty_OrderNo = SIS.PUR.purOrders.purOrdersGetByID(_OrderNo, _OrderRev)
        End If
        Return _FK_PUR_OrderItemProperty_OrderNo
      End Get
    End Property
    Public ReadOnly Property FK_PUR_OrderItemProperty_ValueDataTypeID() As SIS.PUR.purValueDataTypes
      Get
        If _FK_PUR_OrderItemProperty_ValueDataTypeID Is Nothing Then
          _FK_PUR_OrderItemProperty_ValueDataTypeID = SIS.PUR.purValueDataTypes.purValueDataTypesGetByID(_ValueDataTypeID)
        End If
        Return _FK_PUR_OrderItemProperty_ValueDataTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purOrderItemPropertyGetNewRecord() As SIS.PUR.purOrderItemProperty
      Return New SIS.PUR.purOrderItemProperty()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purOrderItemPropertyGetByID(ByVal OrderNo As Int32, ByVal OrderRev As Int32, ByVal OrderLine As Int32, ByVal ItemCode As Int32, ByVal ItemCategoryID As Int32, ByVal CategorySpecID As Int32) As SIS.PUR.purOrderItemProperty
      Dim Results As SIS.PUR.purOrderItemProperty = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrderItemPropertySelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.Int,OrderNo.ToString.Length, OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev",SqlDbType.Int,OrderRev.ToString.Length, OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderLine",SqlDbType.Int,OrderLine.ToString.Length, OrderLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.Int,ItemCode.ToString.Length, ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,ItemCategoryID.ToString.Length, ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategorySpecID",SqlDbType.Int,CategorySpecID.ToString.Length, CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purOrderItemProperty(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purOrderItemPropertySelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal OrderLine As Int32, ByVal OrderNo As Int32, ByVal OrderRev As Int32) As List(Of SIS.PUR.purOrderItemProperty)
      Dim Results As List(Of SIS.PUR.purOrderItemProperty) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurOrderItemPropertySelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurOrderItemPropertySelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_OrderLine",SqlDbType.Int,10, IIf(OrderLine = Nothing, 0,OrderLine))
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
          Results = New List(Of SIS.PUR.purOrderItemProperty)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purOrderItemProperty(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purOrderItemPropertySelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal OrderLine As Int32, ByVal OrderNo As Int32, ByVal OrderRev As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purOrderItemPropertyGetByID(ByVal OrderNo As Int32, ByVal OrderRev As Int32, ByVal OrderLine As Int32, ByVal ItemCode As Int32, ByVal ItemCategoryID As Int32, ByVal CategorySpecID As Int32, ByVal Filter_OrderLine As Int32, ByVal Filter_OrderNo As Int32, ByVal Filter_OrderRev As Int32) As SIS.PUR.purOrderItemProperty
      Return purOrderItemPropertyGetByID(OrderNo, OrderRev, OrderLine, ItemCode, ItemCategoryID, CategorySpecID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purOrderItemPropertyInsert(ByVal Record As SIS.PUR.purOrderItemProperty) As SIS.PUR.purOrderItemProperty
      Dim _Rec As SIS.PUR.purOrderItemProperty = SIS.PUR.purOrderItemProperty.purOrderItemPropertyGetNewRecord()
      With _Rec
        .CategorySpecID = Record.CategorySpecID
        .SerialNo = Record.SerialNo
        .ValueDataTypeID = Record.ValueDataTypeID
        .IsRange = Record.IsRange
        .Data1Value = Record.Data1Value
        .Data2Value = Record.Data2Value
        .ItemCode = Record.ItemCode
        .OrderLine = Record.OrderLine
        .OrderNo = Record.OrderNo
        .OrderRev = Record.OrderRev
        .ItemCategoryID = Record.ItemCategoryID
      End With
      Return SIS.PUR.purOrderItemProperty.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purOrderItemProperty) As SIS.PUR.purOrderItemProperty
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrderItemPropertyInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategorySpecID",SqlDbType.Int,11, Record.CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Iif(Record.SerialNo= "" ,Convert.DBNull, Record.SerialNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValueDataTypeID",SqlDbType.NVarChar,51, Iif(Record.ValueDataTypeID= "" ,Convert.DBNull, Record.ValueDataTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsRange",SqlDbType.Bit,3, Iif(Record.IsRange= "" ,Convert.DBNull, Record.IsRange))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data1Value",SqlDbType.NVarChar,51, Iif(Record.Data1Value= "" ,Convert.DBNull, Record.Data1Value))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data2Value",SqlDbType.NVarChar,51, Iif(Record.Data2Value= "" ,Convert.DBNull, Record.Data2Value))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.Int,11, Record.ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderLine",SqlDbType.Int,11, Record.OrderLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.Int,11, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev",SqlDbType.Int,11, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,11, Record.ItemCategoryID)
          Cmd.Parameters.Add("@Return_OrderNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_OrderNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_OrderRev", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_OrderRev").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_OrderLine", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_OrderLine").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ItemCode", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemCode").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ItemCategoryID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemCategoryID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_CategorySpecID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_CategorySpecID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.OrderNo = Cmd.Parameters("@Return_OrderNo").Value
          Record.OrderRev = Cmd.Parameters("@Return_OrderRev").Value
          Record.OrderLine = Cmd.Parameters("@Return_OrderLine").Value
          Record.ItemCode = Cmd.Parameters("@Return_ItemCode").Value
          Record.ItemCategoryID = Cmd.Parameters("@Return_ItemCategoryID").Value
          Record.CategorySpecID = Cmd.Parameters("@Return_CategorySpecID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purOrderItemPropertyUpdate(ByVal Record As SIS.PUR.purOrderItemProperty) As SIS.PUR.purOrderItemProperty
      Dim _Rec As SIS.PUR.purOrderItemProperty = SIS.PUR.purOrderItemProperty.purOrderItemPropertyGetByID(Record.OrderNo, Record.OrderRev, Record.OrderLine, Record.ItemCode, Record.ItemCategoryID, Record.CategorySpecID)
      With _Rec
        .SerialNo = Record.SerialNo
        .ValueDataTypeID = Record.ValueDataTypeID
        .IsRange = Record.IsRange
        .Data1Value = Record.Data1Value
        .Data2Value = Record.Data2Value
      End With
      Return SIS.PUR.purOrderItemProperty.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purOrderItemProperty) As SIS.PUR.purOrderItemProperty
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrderItemPropertyUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CategorySpecID",SqlDbType.Int,11, Record.CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemCode",SqlDbType.Int,11, Record.ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderLine",SqlDbType.Int,11, Record.OrderLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderNo",SqlDbType.Int,11, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderRev",SqlDbType.Int,11, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemCategoryID",SqlDbType.Int,11, Record.ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategorySpecID",SqlDbType.Int,11, Record.CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Iif(Record.SerialNo= "" ,Convert.DBNull, Record.SerialNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValueDataTypeID",SqlDbType.NVarChar,51, Iif(Record.ValueDataTypeID= "" ,Convert.DBNull, Record.ValueDataTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsRange",SqlDbType.Bit,3, Iif(Record.IsRange= "" ,Convert.DBNull, Record.IsRange))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data1Value",SqlDbType.NVarChar,51, Iif(Record.Data1Value= "" ,Convert.DBNull, Record.Data1Value))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data2Value",SqlDbType.NVarChar,51, Iif(Record.Data2Value= "" ,Convert.DBNull, Record.Data2Value))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.Int,11, Record.ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderLine",SqlDbType.Int,11, Record.OrderLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.Int,11, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev",SqlDbType.Int,11, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,11, Record.ItemCategoryID)
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
    Public Shared Function purOrderItemPropertyDelete(ByVal Record As SIS.PUR.purOrderItemProperty) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrderItemPropertyDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderNo",SqlDbType.Int,Record.OrderNo.ToString.Length, Record.OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderRev",SqlDbType.Int,Record.OrderRev.ToString.Length, Record.OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OrderLine",SqlDbType.Int,Record.OrderLine.ToString.Length, Record.OrderLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemCode",SqlDbType.Int,Record.ItemCode.ToString.Length, Record.ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemCategoryID",SqlDbType.Int,Record.ItemCategoryID.ToString.Length, Record.ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CategorySpecID",SqlDbType.Int,Record.CategorySpecID.ToString.Length, Record.CategorySpecID)
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
