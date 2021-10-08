Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purItemSpecValues
    Private Shared _RecordCount As Integer
    Public Property SpecID As Int32 = 0
    Public Property SerialNo As Int32 = 0
    Public Property ValueDataTypeID As String = ""
    Public Property IsRange As Boolean = False
    Public Property Data1Value As String = ""
    Public Property Data2Value As String = ""
    Public Property PUR_ItemSpecification1_SpecName As String = ""
    Public Property PUR_ValueDataTypes2_ValueDataTypeName As String = ""
    Private _FK_PUR_ItemSpecValues_SpecID As SIS.PUR.purItemSpecification = Nothing
    Private _FK_PUR_ItemSpecValues_ValueDataTypeID As SIS.PUR.purValueDataTypes = Nothing
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
        Return _SpecID & "|" & _SerialNo
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
    Public Class PKpurItemSpecValues
      Private _SpecID As Int32 = 0
      Private _SerialNo As Int32 = 0
      Public Property SpecID() As Int32
        Get
          Return _SpecID
        End Get
        Set(ByVal value As Int32)
          _SpecID = value
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
    Public ReadOnly Property FK_PUR_ItemSpecValues_SpecID() As SIS.PUR.purItemSpecification
      Get
        If _FK_PUR_ItemSpecValues_SpecID Is Nothing Then
          _FK_PUR_ItemSpecValues_SpecID = SIS.PUR.purItemSpecification.purItemSpecificationGetByID(_SpecID)
        End If
        Return _FK_PUR_ItemSpecValues_SpecID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_ItemSpecValues_ValueDataTypeID() As SIS.PUR.purValueDataTypes
      Get
        If _FK_PUR_ItemSpecValues_ValueDataTypeID Is Nothing Then
          _FK_PUR_ItemSpecValues_ValueDataTypeID = SIS.PUR.purValueDataTypes.purValueDataTypesGetByID(_ValueDataTypeID)
        End If
        Return _FK_PUR_ItemSpecValues_ValueDataTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemSpecValuesSelectList(ByVal OrderBy As String) As List(Of SIS.PUR.purItemSpecValues)
      Dim Results As List(Of SIS.PUR.purItemSpecValues) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemSpecValuesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purItemSpecValues)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purItemSpecValues(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemSpecValuesGetNewRecord() As SIS.PUR.purItemSpecValues
      Return New SIS.PUR.purItemSpecValues()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemSpecValuesGetByID(ByVal SpecID As Int32, ByVal SerialNo As Int32) As SIS.PUR.purItemSpecValues
      Dim Results As SIS.PUR.purItemSpecValues = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemSpecValuesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecID",SqlDbType.Int,SpecID.ToString.Length, SpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purItemSpecValues(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemSpecValuesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SpecID As Int32) As List(Of SIS.PUR.purItemSpecValues)
      Dim Results As List(Of SIS.PUR.purItemSpecValues) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurItemSpecValuesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurItemSpecValuesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SpecID",SqlDbType.Int,10, IIf(SpecID = Nothing, 0,SpecID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purItemSpecValues)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purItemSpecValues(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purItemSpecValuesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SpecID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemSpecValuesGetByID(ByVal SpecID As Int32, ByVal SerialNo As Int32, ByVal Filter_SpecID As Int32) As SIS.PUR.purItemSpecValues
      Return purItemSpecValuesGetByID(SpecID, SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purItemSpecValuesInsert(ByVal Record As SIS.PUR.purItemSpecValues) As SIS.PUR.purItemSpecValues
      Dim _Rec As SIS.PUR.purItemSpecValues = SIS.PUR.purItemSpecValues.purItemSpecValuesGetNewRecord()
      With _Rec
        .SpecID = Record.SpecID
        .ValueDataTypeID = Record.ValueDataTypeID
        .IsRange = Record.IsRange
        .Data1Value = Record.Data1Value
        .Data2Value = Record.Data2Value
      End With
      Return SIS.PUR.purItemSpecValues.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purItemSpecValues) As SIS.PUR.purItemSpecValues
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemSpecValuesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecID",SqlDbType.Int,11, Record.SpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValueDataTypeID",SqlDbType.NVarChar,51, Record.ValueDataTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsRange",SqlDbType.Bit,3, Record.IsRange)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data1Value",SqlDbType.NVarChar,51, Iif(Record.Data1Value= "" ,Convert.DBNull, Record.Data1Value))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Data2Value",SqlDbType.NVarChar,51, Iif(Record.Data2Value= "" ,Convert.DBNull, Record.Data2Value))
          Cmd.Parameters.Add("@Return_SpecID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SpecID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SpecID = Cmd.Parameters("@Return_SpecID").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purItemSpecValuesUpdate(ByVal Record As SIS.PUR.purItemSpecValues) As SIS.PUR.purItemSpecValues
      Dim _Rec As SIS.PUR.purItemSpecValues = SIS.PUR.purItemSpecValues.purItemSpecValuesGetByID(Record.SpecID, Record.SerialNo)
      With _Rec
        .ValueDataTypeID = Record.ValueDataTypeID
        .IsRange = Record.IsRange
        .Data1Value = Record.Data1Value
        .Data2Value = Record.Data2Value
      End With
      Return SIS.PUR.purItemSpecValues.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purItemSpecValues) As SIS.PUR.purItemSpecValues
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemSpecValuesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SpecID",SqlDbType.Int,11, Record.SpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecID",SqlDbType.Int,11, Record.SpecID)
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
    Public Shared Function purItemSpecValuesDelete(ByVal Record As SIS.PUR.purItemSpecValues) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemSpecValuesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SpecID",SqlDbType.Int,Record.SpecID.ToString.Length, Record.SpecID)
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
    Public Shared Function SelectpurItemSpecValuesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemSpecValuesAutoCompleteList"
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
            Dim Tmp As SIS.PUR.purItemSpecValues = New SIS.PUR.purItemSpecValues(Reader)
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
