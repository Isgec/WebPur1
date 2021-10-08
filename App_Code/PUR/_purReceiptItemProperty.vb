Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purReceiptItemProperty
    Private Shared _RecordCount As Integer
    Public Property ReceiptNo As Int32 = 0
    Public Property ReceiptLine As Int32 = 0
    Public Property ItemCode As Int32 = 0
    Public Property ItemCategoryID As Int32 = 0
    Public Property CategorySpecID As Int32 = 0
    Public Property SerialNo As String = ""
    Public Property ValueDataTypeID As String = ""
    Public Property IsRange As String = ""
    Public Property Data1Value As String = ""
    Public Property Data2Value As String = ""
    Public Property PUR_ItemCategories1_CategoryName As String = ""
    Public Property PUR_ItemCategorySpecs2_SpecName As String = ""
    Public Property PUR_ItemCategorySpecValues3_Data1Value As String = ""
    Public Property PUR_Items4_ItemDescription As String = ""
    Public Property PUR_ReceiptDetails5_ItemDescription As String = ""
    Public Property PUR_Receipts6_IsgecGSTIN As String = ""
    Public Property PUR_ValueDataTypes7_ValueDataTypeName As String = ""
    Private _FK_PUR_ReceiptItemProperty_ItemCategoryID As SIS.PUR.purItemCategories = Nothing
    Private _FK_PUR_ReceiptItemProperty_CategorySpecID As SIS.PUR.purItemCategorySpecs = Nothing
    Private _FK_PUR_ReceiptItemProperty_SerialNo As SIS.PUR.purItemCategorySpecValues = Nothing
    Private _FK_PUR_ReceiptItemProperty_ItemCode As SIS.PUR.purItems = Nothing
    Private _FK_PUR_ReceiptItemProperty_ReceiptLine As SIS.PUR.purReceiptDetails = Nothing
    Private _FK_PUR_ReceiptItemProperty_ReceiptNo As SIS.PUR.purReceipts = Nothing
    Private _FK_PUR_ReceiptItemProperty_ValueDataTypeID As SIS.PUR.purValueDataTypes = Nothing
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
        Return _ReceiptNo & "|" & _ReceiptLine & "|" & _ItemCode & "|" & _ItemCategoryID & "|" & _CategorySpecID
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
    Public Class PKpurReceiptItemProperty
      Private _ReceiptNo As Int32 = 0
      Private _ReceiptLine As Int32 = 0
      Private _ItemCode As Int32 = 0
      Private _ItemCategoryID As Int32 = 0
      Private _CategorySpecID As Int32 = 0
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
    Public ReadOnly Property FK_PUR_ReceiptItemProperty_ItemCategoryID() As SIS.PUR.purItemCategories
      Get
        If _FK_PUR_ReceiptItemProperty_ItemCategoryID Is Nothing Then
          _FK_PUR_ReceiptItemProperty_ItemCategoryID = SIS.PUR.purItemCategories.purItemCategoriesGetByID(_ItemCategoryID)
        End If
        Return _FK_PUR_ReceiptItemProperty_ItemCategoryID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptItemProperty_CategorySpecID() As SIS.PUR.purItemCategorySpecs
      Get
        If _FK_PUR_ReceiptItemProperty_CategorySpecID Is Nothing Then
          _FK_PUR_ReceiptItemProperty_CategorySpecID = SIS.PUR.purItemCategorySpecs.purItemCategorySpecsGetByID(_ItemCategoryID, _CategorySpecID)
        End If
        Return _FK_PUR_ReceiptItemProperty_CategorySpecID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptItemProperty_SerialNo() As SIS.PUR.purItemCategorySpecValues
      Get
        If _FK_PUR_ReceiptItemProperty_SerialNo Is Nothing Then
          _FK_PUR_ReceiptItemProperty_SerialNo = SIS.PUR.purItemCategorySpecValues.purItemCategorySpecValuesGetByID(_ItemCategoryID, _CategorySpecID, _SerialNo)
        End If
        Return _FK_PUR_ReceiptItemProperty_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptItemProperty_ItemCode() As SIS.PUR.purItems
      Get
        If _FK_PUR_ReceiptItemProperty_ItemCode Is Nothing Then
          _FK_PUR_ReceiptItemProperty_ItemCode = SIS.PUR.purItems.purItemsGetByID(_ItemCode)
        End If
        Return _FK_PUR_ReceiptItemProperty_ItemCode
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptItemProperty_ReceiptLine() As SIS.PUR.purReceiptDetails
      Get
        If _FK_PUR_ReceiptItemProperty_ReceiptLine Is Nothing Then
          _FK_PUR_ReceiptItemProperty_ReceiptLine = SIS.PUR.purReceiptDetails.purReceiptDetailsGetByID(_ReceiptNo, _ReceiptLine)
        End If
        Return _FK_PUR_ReceiptItemProperty_ReceiptLine
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptItemProperty_ReceiptNo() As SIS.PUR.purReceipts
      Get
        If _FK_PUR_ReceiptItemProperty_ReceiptNo Is Nothing Then
          _FK_PUR_ReceiptItemProperty_ReceiptNo = SIS.PUR.purReceipts.purReceiptsGetByID(_ReceiptNo)
        End If
        Return _FK_PUR_ReceiptItemProperty_ReceiptNo
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ReceiptItemProperty_ValueDataTypeID() As SIS.PUR.purValueDataTypes
      Get
        If _FK_PUR_ReceiptItemProperty_ValueDataTypeID Is Nothing Then
          _FK_PUR_ReceiptItemProperty_ValueDataTypeID = SIS.PUR.purValueDataTypes.purValueDataTypesGetByID(_ValueDataTypeID)
        End If
        Return _FK_PUR_ReceiptItemProperty_ValueDataTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purReceiptItemPropertyGetNewRecord() As SIS.PUR.purReceiptItemProperty
      Return New SIS.PUR.purReceiptItemProperty()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purReceiptItemPropertyGetByID(ByVal ReceiptNo As Int32, ByVal ReceiptLine As Int32, ByVal ItemCode As Int32, ByVal ItemCategoryID As Int32, ByVal CategorySpecID As Int32) As SIS.PUR.purReceiptItemProperty
      Dim Results As SIS.PUR.purReceiptItemProperty = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptItemPropertySelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo",SqlDbType.Int,ReceiptNo.ToString.Length, ReceiptNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptLine",SqlDbType.Int,ReceiptLine.ToString.Length, ReceiptLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.Int,ItemCode.ToString.Length, ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,ItemCategoryID.ToString.Length, ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategorySpecID",SqlDbType.Int,CategorySpecID.ToString.Length, CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purReceiptItemProperty(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purReceiptItemPropertySelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ReceiptNo As Int32, ByVal ReceiptLine As Int32) As List(Of SIS.PUR.purReceiptItemProperty)
      Dim Results As List(Of SIS.PUR.purReceiptItemProperty) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurReceiptItemPropertySelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurReceiptItemPropertySelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ReceiptNo",SqlDbType.Int,10, IIf(ReceiptNo = Nothing, 0,ReceiptNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ReceiptLine",SqlDbType.Int,10, IIf(ReceiptLine = Nothing, 0,ReceiptLine))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purReceiptItemProperty)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purReceiptItemProperty(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purReceiptItemPropertySelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ReceiptNo As Int32, ByVal ReceiptLine As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purReceiptItemPropertyGetByID(ByVal ReceiptNo As Int32, ByVal ReceiptLine As Int32, ByVal ItemCode As Int32, ByVal ItemCategoryID As Int32, ByVal CategorySpecID As Int32, ByVal Filter_ReceiptNo As Int32, ByVal Filter_ReceiptLine As Int32) As SIS.PUR.purReceiptItemProperty
      Return purReceiptItemPropertyGetByID(ReceiptNo, ReceiptLine, ItemCode, ItemCategoryID, CategorySpecID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purReceiptItemPropertyInsert(ByVal Record As SIS.PUR.purReceiptItemProperty) As SIS.PUR.purReceiptItemProperty
      Dim _Rec As SIS.PUR.purReceiptItemProperty = SIS.PUR.purReceiptItemProperty.purReceiptItemPropertyGetNewRecord()
      With _Rec
        .ReceiptNo = Record.ReceiptNo
        .ReceiptLine = Record.ReceiptLine
        .ItemCode = Record.ItemCode
        .ItemCategoryID = Record.ItemCategoryID
        .CategorySpecID = Record.CategorySpecID
        .SerialNo = Record.SerialNo
        .ValueDataTypeID = Record.ValueDataTypeID
        .IsRange = Record.IsRange
        .Data1Value = Record.Data1Value
        .Data2Value = Record.Data2Value
      End With
      Return SIS.PUR.purReceiptItemProperty.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purReceiptItemProperty) As SIS.PUR.purReceiptItemProperty
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptItemPropertyInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo",SqlDbType.Int,11, Record.ReceiptNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptLine",SqlDbType.Int,11, Record.ReceiptLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.Int,11, Record.ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,11, Record.ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategorySpecID",SqlDbType.Int,11, Record.CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Iif(Record.SerialNo= "" ,Convert.DBNull, Record.SerialNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValueDataTypeID",SqlDbType.NVarChar,51, Iif(Record.ValueDataTypeID= "" ,Convert.DBNull, Record.ValueDataTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsRange",SqlDbType.Bit,3, Iif(Record.IsRange= "" ,Convert.DBNull, Record.IsRange))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data1Value",SqlDbType.NVarChar,51, Iif(Record.Data1Value= "" ,Convert.DBNull, Record.Data1Value))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data2Value",SqlDbType.NVarChar,51, Iif(Record.Data2Value= "" ,Convert.DBNull, Record.Data2Value))
          Cmd.Parameters.Add("@Return_ReceiptNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ReceiptNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ReceiptLine", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ReceiptLine").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ItemCode", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemCode").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ItemCategoryID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemCategoryID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_CategorySpecID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_CategorySpecID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ReceiptNo = Cmd.Parameters("@Return_ReceiptNo").Value
          Record.ReceiptLine = Cmd.Parameters("@Return_ReceiptLine").Value
          Record.ItemCode = Cmd.Parameters("@Return_ItemCode").Value
          Record.ItemCategoryID = Cmd.Parameters("@Return_ItemCategoryID").Value
          Record.CategorySpecID = Cmd.Parameters("@Return_CategorySpecID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purReceiptItemPropertyUpdate(ByVal Record As SIS.PUR.purReceiptItemProperty) As SIS.PUR.purReceiptItemProperty
      Dim _Rec As SIS.PUR.purReceiptItemProperty = SIS.PUR.purReceiptItemProperty.purReceiptItemPropertyGetByID(Record.ReceiptNo, Record.ReceiptLine, Record.ItemCode, Record.ItemCategoryID, Record.CategorySpecID)
      With _Rec
        .SerialNo = Record.SerialNo
        .ValueDataTypeID = Record.ValueDataTypeID
        .IsRange = Record.IsRange
        .Data1Value = Record.Data1Value
        .Data2Value = Record.Data2Value
      End With
      Return SIS.PUR.purReceiptItemProperty.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purReceiptItemProperty) As SIS.PUR.purReceiptItemProperty
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptItemPropertyUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ReceiptNo",SqlDbType.Int,11, Record.ReceiptNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ReceiptLine",SqlDbType.Int,11, Record.ReceiptLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemCode",SqlDbType.Int,11, Record.ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemCategoryID",SqlDbType.Int,11, Record.ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CategorySpecID",SqlDbType.Int,11, Record.CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo",SqlDbType.Int,11, Record.ReceiptNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptLine",SqlDbType.Int,11, Record.ReceiptLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.Int,11, Record.ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,11, Record.ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategorySpecID",SqlDbType.Int,11, Record.CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Iif(Record.SerialNo= "" ,Convert.DBNull, Record.SerialNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValueDataTypeID",SqlDbType.NVarChar,51, Iif(Record.ValueDataTypeID= "" ,Convert.DBNull, Record.ValueDataTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsRange",SqlDbType.Bit,3, Iif(Record.IsRange= "" ,Convert.DBNull, Record.IsRange))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data1Value",SqlDbType.NVarChar,51, Iif(Record.Data1Value= "" ,Convert.DBNull, Record.Data1Value))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data2Value",SqlDbType.NVarChar,51, Iif(Record.Data2Value= "" ,Convert.DBNull, Record.Data2Value))
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
    Public Shared Function purReceiptItemPropertyDelete(ByVal Record As SIS.PUR.purReceiptItemProperty) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurReceiptItemPropertyDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ReceiptNo",SqlDbType.Int,Record.ReceiptNo.ToString.Length, Record.ReceiptNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ReceiptLine",SqlDbType.Int,Record.ReceiptLine.ToString.Length, Record.ReceiptLine)
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
