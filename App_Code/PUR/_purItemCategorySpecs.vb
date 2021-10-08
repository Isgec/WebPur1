Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purItemCategorySpecs
    Private Shared _RecordCount As Integer
    Public Property ItemCategoryID As Int32 = 0
    Public Property CategorySpecID As Int32 = 0
    Public Property SpecID As String = ""
    Public Property SpecName As String = ""
    Public Property DefaultValueSerialNo As String = ""
    Public Property IsFixed As Boolean = False
    Public Property IsDerived As Boolean = False
    Public Property ValidateValue As Boolean = False
    Public Property UseValues As Boolean = False
    Public Property AllowUserValue As Boolean = False
    Public Property IsRange As Boolean = False
    Public Property ValueDataTypeID As String = ""
    Public Property PUR_ItemCategories1_CategoryName As String = ""
    Public Property PUR_ItemCategorySpecValues2_Data1Value As String = ""
    Public Property PUR_ItemSpecification3_SpecName As String = ""
    Public Property PUR_ValueDataTypes4_ValueDataTypeName As String = ""
    Private _FK_PUR_ItemCategorySpecs_ItemCategoryID As SIS.PUR.purItemCategories = Nothing
    Private _FK_PUR_ItemCategorySpecs_DefaultValueSerialNo As SIS.PUR.purItemCategorySpecValues = Nothing
    Private _FK_PUR_ItemCategorySpecs_SpecID As SIS.PUR.purItemSpecification = Nothing
    Private _FK_PUR_ItemCategorySpecs_ValueDataTypeID As SIS.PUR.purValueDataTypes = Nothing
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
        Return "" & _SpecName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ItemCategoryID & "|" & _CategorySpecID
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
    Public Class PKpurItemCategorySpecs
      Private _ItemCategoryID As Int32 = 0
      Private _CategorySpecID As Int32 = 0
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
    Public ReadOnly Property FK_PUR_ItemCategorySpecs_ItemCategoryID() As SIS.PUR.purItemCategories
      Get
        If _FK_PUR_ItemCategorySpecs_ItemCategoryID Is Nothing Then
          _FK_PUR_ItemCategorySpecs_ItemCategoryID = SIS.PUR.purItemCategories.purItemCategoriesGetByID(_ItemCategoryID)
        End If
        Return _FK_PUR_ItemCategorySpecs_ItemCategoryID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ItemCategorySpecs_DefaultValueSerialNo() As SIS.PUR.purItemCategorySpecValues
      Get
        If _FK_PUR_ItemCategorySpecs_DefaultValueSerialNo Is Nothing Then
          _FK_PUR_ItemCategorySpecs_DefaultValueSerialNo = SIS.PUR.purItemCategorySpecValues.purItemCategorySpecValuesGetByID(_ItemCategoryID, _CategorySpecID, _DefaultValueSerialNo)
        End If
        Return _FK_PUR_ItemCategorySpecs_DefaultValueSerialNo
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ItemCategorySpecs_SpecID() As SIS.PUR.purItemSpecification
      Get
        If _FK_PUR_ItemCategorySpecs_SpecID Is Nothing Then
          _FK_PUR_ItemCategorySpecs_SpecID = SIS.PUR.purItemSpecification.purItemSpecificationGetByID(_SpecID)
        End If
        Return _FK_PUR_ItemCategorySpecs_SpecID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ItemCategorySpecs_ValueDataTypeID() As SIS.PUR.purValueDataTypes
      Get
        If _FK_PUR_ItemCategorySpecs_ValueDataTypeID Is Nothing Then
          _FK_PUR_ItemCategorySpecs_ValueDataTypeID = SIS.PUR.purValueDataTypes.purValueDataTypesGetByID(_ValueDataTypeID)
        End If
        Return _FK_PUR_ItemCategorySpecs_ValueDataTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemCategorySpecsSelectList(ByVal OrderBy As String) As List(Of SIS.PUR.purItemCategorySpecs)
      Dim Results As List(Of SIS.PUR.purItemCategorySpecs) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemCategorySpecsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purItemCategorySpecs)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purItemCategorySpecs(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemCategorySpecsGetNewRecord() As SIS.PUR.purItemCategorySpecs
      Return New SIS.PUR.purItemCategorySpecs()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemCategorySpecsGetByID(ByVal ItemCategoryID As Int32, ByVal CategorySpecID As Int32) As SIS.PUR.purItemCategorySpecs
      Dim Results As SIS.PUR.purItemCategorySpecs = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemCategorySpecsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,ItemCategoryID.ToString.Length, ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategorySpecID",SqlDbType.Int,CategorySpecID.ToString.Length, CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purItemCategorySpecs(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemCategorySpecsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ItemCategoryID As Int32) As List(Of SIS.PUR.purItemCategorySpecs)
      Dim Results As List(Of SIS.PUR.purItemCategorySpecs) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurItemCategorySpecsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurItemCategorySpecsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ItemCategoryID",SqlDbType.Int,10, IIf(ItemCategoryID = Nothing, 0,ItemCategoryID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purItemCategorySpecs)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purItemCategorySpecs(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purItemCategorySpecsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ItemCategoryID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemCategorySpecsGetByID(ByVal ItemCategoryID As Int32, ByVal CategorySpecID As Int32, ByVal Filter_ItemCategoryID As Int32) As SIS.PUR.purItemCategorySpecs
      Return purItemCategorySpecsGetByID(ItemCategoryID, CategorySpecID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purItemCategorySpecsInsert(ByVal Record As SIS.PUR.purItemCategorySpecs) As SIS.PUR.purItemCategorySpecs
      Dim _Rec As SIS.PUR.purItemCategorySpecs = SIS.PUR.purItemCategorySpecs.purItemCategorySpecsGetNewRecord()
      With _Rec
        .ItemCategoryID = Record.ItemCategoryID
        .SpecID = Record.SpecID
        .SpecName = Record.SpecName
        .DefaultValueSerialNo = Record.DefaultValueSerialNo
        .IsFixed = Record.IsFixed
        .IsDerived = Record.IsDerived
        .ValidateValue = Record.ValidateValue
        .UseValues = Record.UseValues
        .AllowUserValue = Record.AllowUserValue
        .IsRange = Record.IsRange
        .ValueDataTypeID = Record.ValueDataTypeID
      End With
      Return SIS.PUR.purItemCategorySpecs.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purItemCategorySpecs) As SIS.PUR.purItemCategorySpecs
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemCategorySpecsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,11, Record.ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecID",SqlDbType.Int,11, Iif(Record.SpecID= "" ,Convert.DBNull, Record.SpecID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecName",SqlDbType.NVarChar,51, Iif(Record.SpecName= "" ,Convert.DBNull, Record.SpecName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DefaultValueSerialNo",SqlDbType.Int,11, Iif(Record.DefaultValueSerialNo= "" ,Convert.DBNull, Record.DefaultValueSerialNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsFixed",SqlDbType.Bit,3, Record.IsFixed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDerived",SqlDbType.Bit,3, Record.IsDerived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValidateValue",SqlDbType.Bit,3, Record.ValidateValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UseValues",SqlDbType.Bit,3, Record.UseValues)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllowUserValue",SqlDbType.Bit,3, Record.AllowUserValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsRange",SqlDbType.Bit,3, Record.IsRange)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValueDataTypeID",SqlDbType.NVarChar,51, Iif(Record.ValueDataTypeID= "" ,Convert.DBNull, Record.ValueDataTypeID))
          Cmd.Parameters.Add("@Return_ItemCategoryID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemCategoryID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_CategorySpecID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_CategorySpecID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ItemCategoryID = Cmd.Parameters("@Return_ItemCategoryID").Value
          Record.CategorySpecID = Cmd.Parameters("@Return_CategorySpecID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purItemCategorySpecsUpdate(ByVal Record As SIS.PUR.purItemCategorySpecs) As SIS.PUR.purItemCategorySpecs
      Dim _Rec As SIS.PUR.purItemCategorySpecs = SIS.PUR.purItemCategorySpecs.purItemCategorySpecsGetByID(Record.ItemCategoryID, Record.CategorySpecID)
      With _Rec
        .SpecID = Record.SpecID
        .SpecName = Record.SpecName
        .DefaultValueSerialNo = Record.DefaultValueSerialNo
        .IsFixed = Record.IsFixed
        .IsDerived = Record.IsDerived
        .ValidateValue = Record.ValidateValue
        .UseValues = Record.UseValues
        .AllowUserValue = Record.AllowUserValue
        .IsRange = Record.IsRange
        .ValueDataTypeID = Record.ValueDataTypeID
      End With
      Return SIS.PUR.purItemCategorySpecs.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purItemCategorySpecs) As SIS.PUR.purItemCategorySpecs
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemCategorySpecsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemCategoryID",SqlDbType.Int,11, Record.ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CategorySpecID",SqlDbType.Int,11, Record.CategorySpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,11, Record.ItemCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecID",SqlDbType.Int,11, Iif(Record.SpecID= "" ,Convert.DBNull, Record.SpecID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecName",SqlDbType.NVarChar,51, Iif(Record.SpecName= "" ,Convert.DBNull, Record.SpecName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DefaultValueSerialNo",SqlDbType.Int,11, Iif(Record.DefaultValueSerialNo= "" ,Convert.DBNull, Record.DefaultValueSerialNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsFixed",SqlDbType.Bit,3, Record.IsFixed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDerived",SqlDbType.Bit,3, Record.IsDerived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValidateValue",SqlDbType.Bit,3, Record.ValidateValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UseValues",SqlDbType.Bit,3, Record.UseValues)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllowUserValue",SqlDbType.Bit,3, Record.AllowUserValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsRange",SqlDbType.Bit,3, Record.IsRange)
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
    Public Shared Function purItemCategorySpecsDelete(ByVal Record As SIS.PUR.purItemCategorySpecs) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemCategorySpecsDelete"
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
'    Autocomplete Method
    Public Shared Function SelectpurItemCategorySpecsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemCategorySpecsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PUR.purItemCategorySpecs = New SIS.PUR.purItemCategorySpecs(Reader)
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
