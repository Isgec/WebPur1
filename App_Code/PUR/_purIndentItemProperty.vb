Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purIndentItemProperty
    Private Shared _RecordCount As Integer
    Public Property CategorySpecID As Int32 = 0
    Public Property Data1Value As String = ""
    Public Property Data2Value As String = ""
    Public Property IndentNo As Int32 = 0
    Public Property ItemCategoryID As Int32 = 0
    Public Property ItemCode As Int32 = 0
    Public Property IndentLine As Int32 = 0
    Public Property IsRange As String = ""
    Public Property SerialNo As String = ""
    Public Property ValueDataTypeID As String = ""
    Public Property PUR_IndentDetails1_ItemDescription As String = ""
    Public Property PUR_Indents2_IndenterRemarks As String = ""
    Public Property PUR_ItemCategories3_CategoryName As String = ""
    Public Property PUR_ItemCategorySpecs4_SpecName As String = ""
    Public Property PUR_ItemCategorySpecValues5_Data1Value As String = ""
    Public Property PUR_Items6_ItemDescription As String = ""
    Public Property PUR_ValueDataTypes7_ValueDataTypeName As String = ""
    Private _FK_PUR_IndentItemProperty_IndentLine As SIS.PUR.purIndentDetails = Nothing
    Private _FK_PUR_IndentItemProperty_IndentNo As SIS.PUR.purIndents = Nothing
    Private _FK_PUR_IndentItemProperty_ItemCategoryID As SIS.PUR.purItemCategories = Nothing
    Private _FK_PUR_IndentItemProperty_CategorySpecID As SIS.PUR.purItemCategorySpecs = Nothing
    Private _FK_PUR_IndentItemProperty_SerialNo As SIS.PUR.purItemCategorySpecValues = Nothing
    Private _FK_PUR_IndentItemProperty_ItemCode As SIS.PUR.purItems = Nothing
    Private _FK_PUR_IndentItemProperty_ValueDataTypeID As SIS.PUR.purValueDataTypes = Nothing
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
        Return _IndentNo & "|" & _IndentLine & "|" & _ItemCode & "|" & _ItemCategoryID & "|" & _CategorySpecID
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
    Public Class PKpurIndentItemProperty
      Private _IndentNo As Int32 = 0
      Private _IndentLine As Int32 = 0
      Private _ItemCode As Int32 = 0
      Private _ItemCategoryID As Int32 = 0
      Private _CategorySpecID As Int32 = 0
      Public Property IndentNo() As Int32
        Get
          Return _IndentNo
        End Get
        Set(ByVal value As Int32)
          _IndentNo = value
        End Set
      End Property
      Public Property IndentLine() As Int32
        Get
          Return _IndentLine
        End Get
        Set(ByVal value As Int32)
          _IndentLine = value
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
    Public ReadOnly Property FK_PUR_IndentItemProperty_IndentLine() As SIS.PUR.purIndentDetails
      Get
        If _FK_PUR_IndentItemProperty_IndentLine Is Nothing Then
          _FK_PUR_IndentItemProperty_IndentLine = SIS.PUR.purIndentDetails.purIndentDetailsGetByID(_IndentNo, _IndentLine)
        End If
        Return _FK_PUR_IndentItemProperty_IndentLine
      End Get
    End Property
    Public ReadOnly Property FK_PUR_IndentItemProperty_IndentNo() As SIS.PUR.purIndents
      Get
        If _FK_PUR_IndentItemProperty_IndentNo Is Nothing Then
          _FK_PUR_IndentItemProperty_IndentNo = SIS.PUR.purIndents.purIndentsGetByID(_IndentNo)
        End If
        Return _FK_PUR_IndentItemProperty_IndentNo
      End Get
    End Property
    Public ReadOnly Property FK_PUR_IndentItemProperty_ItemCategoryID() As SIS.PUR.purItemCategories
      Get
        If _FK_PUR_IndentItemProperty_ItemCategoryID Is Nothing Then
          _FK_PUR_IndentItemProperty_ItemCategoryID = SIS.PUR.purItemCategories.purItemCategoriesGetByID(_ItemCategoryID)
        End If
        Return _FK_PUR_IndentItemProperty_ItemCategoryID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_IndentItemProperty_CategorySpecID() As SIS.PUR.purItemCategorySpecs
      Get
        If _FK_PUR_IndentItemProperty_CategorySpecID Is Nothing Then
          _FK_PUR_IndentItemProperty_CategorySpecID = SIS.PUR.purItemCategorySpecs.purItemCategorySpecsGetByID(_ItemCategoryID, _CategorySpecID)
        End If
        Return _FK_PUR_IndentItemProperty_CategorySpecID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_IndentItemProperty_SerialNo() As SIS.PUR.purItemCategorySpecValues
      Get
        If _FK_PUR_IndentItemProperty_SerialNo Is Nothing Then
          _FK_PUR_IndentItemProperty_SerialNo = SIS.PUR.purItemCategorySpecValues.purItemCategorySpecValuesGetByID(_ItemCategoryID, _CategorySpecID, _SerialNo)
        End If
        Return _FK_PUR_IndentItemProperty_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_PUR_IndentItemProperty_ItemCode() As SIS.PUR.purItems
      Get
        If _FK_PUR_IndentItemProperty_ItemCode Is Nothing Then
          _FK_PUR_IndentItemProperty_ItemCode = SIS.PUR.purItems.purItemsGetByID(_ItemCode)
        End If
        Return _FK_PUR_IndentItemProperty_ItemCode
      End Get
    End Property
    Public ReadOnly Property FK_PUR_IndentItemProperty_ValueDataTypeID() As SIS.PUR.purValueDataTypes
      Get
        If _FK_PUR_IndentItemProperty_ValueDataTypeID Is Nothing Then
          _FK_PUR_IndentItemProperty_ValueDataTypeID = SIS.PUR.purValueDataTypes.purValueDataTypesGetByID(_ValueDataTypeID)
        End If
        Return _FK_PUR_IndentItemProperty_ValueDataTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purIndentItemPropertyGetNewRecord() As SIS.PUR.purIndentItemProperty
      Return New SIS.PUR.purIndentItemProperty()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purIndentItemPropertyGetByID(ByVal IndentNo As Int32, ByVal IndentLine As Int32, ByVal ItemCode As Int32, ByVal ItemCategoryID As Int32, ByVal CategorySpecID As Int32) As SIS.PUR.purIndentItemProperty
      Dim Results As SIS.PUR.purIndentItemProperty = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurIndentItemPropertySelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentNo",SqlDbType.Int,IndentNo.ToString.Length, IndentNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentLine",SqlDbType.Int,IndentLine.ToString.Length, IndentLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.Int,ItemCode.ToString.Length, ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,ItemCategoryID.ToString.Length, ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategorySpecID",SqlDbType.Int,CategorySpecID.ToString.Length, CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purIndentItemProperty(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purIndentItemPropertySelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IndentNo As Int32, ByVal IndentLine As Int32) As List(Of SIS.PUR.purIndentItemProperty)
      Dim Results As List(Of SIS.PUR.purIndentItemProperty) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurIndentItemPropertySelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurIndentItemPropertySelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IndentNo",SqlDbType.Int,10, IIf(IndentNo = Nothing, 0,IndentNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IndentLine",SqlDbType.Int,10, IIf(IndentLine = Nothing, 0,IndentLine))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purIndentItemProperty)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purIndentItemProperty(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purIndentItemPropertySelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IndentNo As Int32, ByVal IndentLine As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purIndentItemPropertyGetByID(ByVal IndentNo As Int32, ByVal IndentLine As Int32, ByVal ItemCode As Int32, ByVal ItemCategoryID As Int32, ByVal CategorySpecID As Int32, ByVal Filter_IndentNo As Int32, ByVal Filter_IndentLine As Int32) As SIS.PUR.purIndentItemProperty
      Return purIndentItemPropertyGetByID(IndentNo, IndentLine, ItemCode, ItemCategoryID, CategorySpecID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purIndentItemPropertyInsert(ByVal Record As SIS.PUR.purIndentItemProperty) As SIS.PUR.purIndentItemProperty
      Dim _Rec As SIS.PUR.purIndentItemProperty = SIS.PUR.purIndentItemProperty.purIndentItemPropertyGetNewRecord()
      With _Rec
        .CategorySpecID = Record.CategorySpecID
        .Data1Value = Record.Data1Value
        .Data2Value = Record.Data2Value
        .IndentNo = Record.IndentNo
        .ItemCategoryID = Record.ItemCategoryID
        .ItemCode = Record.ItemCode
        .IndentLine = Record.IndentLine
        .IsRange = Record.IsRange
        .SerialNo = Record.SerialNo
        .ValueDataTypeID = Record.ValueDataTypeID
      End With
      Return SIS.PUR.purIndentItemProperty.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purIndentItemProperty) As SIS.PUR.purIndentItemProperty
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurIndentItemPropertyInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategorySpecID",SqlDbType.Int,11, Record.CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data1Value",SqlDbType.NVarChar,51, Iif(Record.Data1Value= "" ,Convert.DBNull, Record.Data1Value))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data2Value",SqlDbType.NVarChar,51, Iif(Record.Data2Value= "" ,Convert.DBNull, Record.Data2Value))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentNo",SqlDbType.Int,11, Record.IndentNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,11, Record.ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.Int,11, Record.ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentLine",SqlDbType.Int,11, Record.IndentLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsRange",SqlDbType.Bit,3, Iif(Record.IsRange= "" ,Convert.DBNull, Record.IsRange))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Iif(Record.SerialNo= "" ,Convert.DBNull, Record.SerialNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValueDataTypeID",SqlDbType.NVarChar,51, Iif(Record.ValueDataTypeID= "" ,Convert.DBNull, Record.ValueDataTypeID))
          Cmd.Parameters.Add("@Return_IndentNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_IndentNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_IndentLine", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_IndentLine").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ItemCode", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemCode").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ItemCategoryID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemCategoryID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_CategorySpecID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_CategorySpecID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.IndentNo = Cmd.Parameters("@Return_IndentNo").Value
          Record.IndentLine = Cmd.Parameters("@Return_IndentLine").Value
          Record.ItemCode = Cmd.Parameters("@Return_ItemCode").Value
          Record.ItemCategoryID = Cmd.Parameters("@Return_ItemCategoryID").Value
          Record.CategorySpecID = Cmd.Parameters("@Return_CategorySpecID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purIndentItemPropertyUpdate(ByVal Record As SIS.PUR.purIndentItemProperty) As SIS.PUR.purIndentItemProperty
      Dim _Rec As SIS.PUR.purIndentItemProperty = SIS.PUR.purIndentItemProperty.purIndentItemPropertyGetByID(Record.IndentNo, Record.IndentLine, Record.ItemCode, Record.ItemCategoryID, Record.CategorySpecID)
      With _Rec
        .Data1Value = Record.Data1Value
        .Data2Value = Record.Data2Value
        .IsRange = Record.IsRange
        .SerialNo = Record.SerialNo
        .ValueDataTypeID = Record.ValueDataTypeID
      End With
      Return SIS.PUR.purIndentItemProperty.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purIndentItemProperty) As SIS.PUR.purIndentItemProperty
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurIndentItemPropertyUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CategorySpecID",SqlDbType.Int,11, Record.CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IndentNo",SqlDbType.Int,11, Record.IndentNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemCategoryID",SqlDbType.Int,11, Record.ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemCode",SqlDbType.Int,11, Record.ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IndentLine",SqlDbType.Int,11, Record.IndentLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategorySpecID",SqlDbType.Int,11, Record.CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data1Value",SqlDbType.NVarChar,51, Iif(Record.Data1Value= "" ,Convert.DBNull, Record.Data1Value))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data2Value",SqlDbType.NVarChar,51, Iif(Record.Data2Value= "" ,Convert.DBNull, Record.Data2Value))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentNo",SqlDbType.Int,11, Record.IndentNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,11, Record.ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.Int,11, Record.ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentLine",SqlDbType.Int,11, Record.IndentLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsRange",SqlDbType.Bit,3, Iif(Record.IsRange= "" ,Convert.DBNull, Record.IsRange))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Iif(Record.SerialNo= "" ,Convert.DBNull, Record.SerialNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValueDataTypeID",SqlDbType.NVarChar,51, Iif(Record.ValueDataTypeID= "" ,Convert.DBNull, Record.ValueDataTypeID))
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
    Public Shared Function purIndentItemPropertyDelete(ByVal Record As SIS.PUR.purIndentItemProperty) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurIndentItemPropertyDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IndentNo",SqlDbType.Int,Record.IndentNo.ToString.Length, Record.IndentNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IndentLine",SqlDbType.Int,Record.IndentLine.ToString.Length, Record.IndentLine)
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
