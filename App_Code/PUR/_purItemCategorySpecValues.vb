Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purItemCategorySpecValues
    Private Shared _RecordCount As Integer
    Public Property ItemCategoryID As Int32 = 0
    Public Property CategorySpecID As Int32 = 0
    Public Property SerialNo As Int32 = 0
    Public Property ValueDataTypeID As String = ""
    Public Property IsRange As Boolean = False
    Public Property Data1Value As String = ""
    Public Property Data2Value As String = ""
    Public Property PUR_ItemCategories1_CategoryName As String = ""
    Public Property PUR_ItemCategorySpecs2_SpecName As String = ""
    Public Property PUR_ValueDataTypes3_ValueDataTypeName As String = ""
    Private _FK_PUR_ItemCategorySpecValues_ItemCategoryID As SIS.PUR.purItemCategories = Nothing
    Private _FK_PUR_ItemCategorySpecValues_CategorySpecID As SIS.PUR.purItemCategorySpecs = Nothing
    Private _FK_PUR_ItemCategorySpecValues_ValueDataTypeID As SIS.PUR.purValueDataTypes = Nothing
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
        Return "" & _Data1Value.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ItemCategoryID & "|" & _CategorySpecID & "|" & _SerialNo
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
    Public Class PKpurItemCategorySpecValues
      Private _ItemCategoryID As Int32 = 0
      Private _CategorySpecID As Int32 = 0
      Private _SerialNo As Int32 = 0
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
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PUR_ItemCategorySpecValues_ItemCategoryID() As SIS.PUR.purItemCategories
      Get
        If _FK_PUR_ItemCategorySpecValues_ItemCategoryID Is Nothing Then
          _FK_PUR_ItemCategorySpecValues_ItemCategoryID = SIS.PUR.purItemCategories.purItemCategoriesGetByID(_ItemCategoryID)
        End If
        Return _FK_PUR_ItemCategorySpecValues_ItemCategoryID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ItemCategorySpecValues_CategorySpecID() As SIS.PUR.purItemCategorySpecs
      Get
        If _FK_PUR_ItemCategorySpecValues_CategorySpecID Is Nothing Then
          _FK_PUR_ItemCategorySpecValues_CategorySpecID = SIS.PUR.purItemCategorySpecs.purItemCategorySpecsGetByID(_ItemCategoryID, _CategorySpecID)
        End If
        Return _FK_PUR_ItemCategorySpecValues_CategorySpecID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ItemCategorySpecValues_ValueDataTypeID() As SIS.PUR.purValueDataTypes
      Get
        If _FK_PUR_ItemCategorySpecValues_ValueDataTypeID Is Nothing Then
          _FK_PUR_ItemCategorySpecValues_ValueDataTypeID = SIS.PUR.purValueDataTypes.purValueDataTypesGetByID(_ValueDataTypeID)
        End If
        Return _FK_PUR_ItemCategorySpecValues_ValueDataTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemCategorySpecValuesSelectList(ByVal OrderBy As String) As List(Of SIS.PUR.purItemCategorySpecValues)
      Dim Results As List(Of SIS.PUR.purItemCategorySpecValues) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemCategorySpecValuesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purItemCategorySpecValues)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purItemCategorySpecValues(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemCategorySpecValuesGetNewRecord() As SIS.PUR.purItemCategorySpecValues
      Return New SIS.PUR.purItemCategorySpecValues()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemCategorySpecValuesGetByID(ByVal ItemCategoryID As Int32, ByVal CategorySpecID As Int32, ByVal SerialNo As Int32) As SIS.PUR.purItemCategorySpecValues
      Dim Results As SIS.PUR.purItemCategorySpecValues = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemCategorySpecValuesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,ItemCategoryID.ToString.Length, ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategorySpecID",SqlDbType.Int,CategorySpecID.ToString.Length, CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purItemCategorySpecValues(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemCategorySpecValuesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ItemCategoryID As Int32, ByVal CategorySpecID As Int32) As List(Of SIS.PUR.purItemCategorySpecValues)
      Dim Results As List(Of SIS.PUR.purItemCategorySpecValues) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurItemCategorySpecValuesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurItemCategorySpecValuesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ItemCategoryID",SqlDbType.Int,10, IIf(ItemCategoryID = Nothing, 0,ItemCategoryID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CategorySpecID",SqlDbType.Int,10, IIf(CategorySpecID = Nothing, 0,CategorySpecID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purItemCategorySpecValues)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purItemCategorySpecValues(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purItemCategorySpecValuesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ItemCategoryID As Int32, ByVal CategorySpecID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemCategorySpecValuesGetByID(ByVal ItemCategoryID As Int32, ByVal CategorySpecID As Int32, ByVal SerialNo As Int32, ByVal Filter_ItemCategoryID As Int32, ByVal Filter_CategorySpecID As Int32) As SIS.PUR.purItemCategorySpecValues
      Return purItemCategorySpecValuesGetByID(ItemCategoryID, CategorySpecID, SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purItemCategorySpecValuesInsert(ByVal Record As SIS.PUR.purItemCategorySpecValues) As SIS.PUR.purItemCategorySpecValues
      Dim _Rec As SIS.PUR.purItemCategorySpecValues = SIS.PUR.purItemCategorySpecValues.purItemCategorySpecValuesGetNewRecord()
      With _Rec
        .ItemCategoryID = Record.ItemCategoryID
        .CategorySpecID = Record.CategorySpecID
        .ValueDataTypeID = Record.ValueDataTypeID
        .IsRange = Record.IsRange
        .Data1Value = Record.Data1Value
        .Data2Value = Record.Data2Value
      End With
      Return SIS.PUR.purItemCategorySpecValues.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purItemCategorySpecValues) As SIS.PUR.purItemCategorySpecValues
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemCategorySpecValuesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,11, Record.ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategorySpecID",SqlDbType.Int,11, Record.CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValueDataTypeID",SqlDbType.NVarChar,51, Record.ValueDataTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsRange",SqlDbType.Bit,3, Record.IsRange)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data1Value",SqlDbType.NVarChar,51, Iif(Record.Data1Value= "" ,Convert.DBNull, Record.Data1Value))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data2Value",SqlDbType.NVarChar,51, Iif(Record.Data2Value= "" ,Convert.DBNull, Record.Data2Value))
          Cmd.Parameters.Add("@Return_ItemCategoryID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemCategoryID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_CategorySpecID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_CategorySpecID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ItemCategoryID = Cmd.Parameters("@Return_ItemCategoryID").Value
          Record.CategorySpecID = Cmd.Parameters("@Return_CategorySpecID").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purItemCategorySpecValuesUpdate(ByVal Record As SIS.PUR.purItemCategorySpecValues) As SIS.PUR.purItemCategorySpecValues
      Dim _Rec As SIS.PUR.purItemCategorySpecValues = SIS.PUR.purItemCategorySpecValues.purItemCategorySpecValuesGetByID(Record.ItemCategoryID, Record.CategorySpecID, Record.SerialNo)
      With _Rec
        .ValueDataTypeID = Record.ValueDataTypeID
        .IsRange = Record.IsRange
        .Data1Value = Record.Data1Value
        .Data2Value = Record.Data2Value
      End With
      Return SIS.PUR.purItemCategorySpecValues.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purItemCategorySpecValues) As SIS.PUR.purItemCategorySpecValues
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemCategorySpecValuesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemCategoryID",SqlDbType.Int,11, Record.ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CategorySpecID",SqlDbType.Int,11, Record.CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,11, Record.ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategorySpecID",SqlDbType.Int,11, Record.CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValueDataTypeID",SqlDbType.NVarChar,51, Record.ValueDataTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsRange",SqlDbType.Bit,3, Record.IsRange)
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
    Public Shared Function purItemCategorySpecValuesDelete(ByVal Record As SIS.PUR.purItemCategorySpecValues) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemCategorySpecValuesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemCategoryID",SqlDbType.Int,Record.ItemCategoryID.ToString.Length, Record.ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CategorySpecID",SqlDbType.Int,Record.CategorySpecID.ToString.Length, Record.CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
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
    Public Shared Function SelectpurItemCategorySpecValuesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemCategorySpecValuesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),"" & "|" & "" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PUR.purItemCategorySpecValues = New SIS.PUR.purItemCategorySpecValues(Reader)
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
