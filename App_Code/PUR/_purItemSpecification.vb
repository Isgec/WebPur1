Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purItemSpecification
    Private Shared _RecordCount As Integer
    Public Property SpecID As Int32 = 0
    Public Property SpecName As String = ""
    Public Property IsFixed As Boolean = False
    Public Property IsDerived As Boolean = False
    Public Property ValidateValue As Boolean = False
    Public Property UseValues As Boolean = False
    Public Property AllowUserValue As Boolean = False
    Public Property ValueDataTypeID As String = ""
    Public Property IsRange As Boolean = False
    Public Property PUR_ValueDataTypes1_ValueDataTypeName As String = ""
    Private _FK_PUR_ItemSpecification_ValueDataTypeID As SIS.PUR.purValueDataTypes = Nothing
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
        Return _SpecID
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
    Public Class PKpurItemSpecification
      Private _SpecID As Int32 = 0
      Public Property SpecID() As Int32
        Get
          Return _SpecID
        End Get
        Set(ByVal value As Int32)
          _SpecID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PUR_ItemSpecification_ValueDataTypeID() As SIS.PUR.purValueDataTypes
      Get
        If _FK_PUR_ItemSpecification_ValueDataTypeID Is Nothing Then
          _FK_PUR_ItemSpecification_ValueDataTypeID = SIS.PUR.purValueDataTypes.purValueDataTypesGetByID(_ValueDataTypeID)
        End If
        Return _FK_PUR_ItemSpecification_ValueDataTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemSpecificationSelectList(ByVal OrderBy As String) As List(Of SIS.PUR.purItemSpecification)
      Dim Results As List(Of SIS.PUR.purItemSpecification) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemSpecificationSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purItemSpecification)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purItemSpecification(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemSpecificationGetNewRecord() As SIS.PUR.purItemSpecification
      Return New SIS.PUR.purItemSpecification()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemSpecificationGetByID(ByVal SpecID As Int32) As SIS.PUR.purItemSpecification
      Dim Results As SIS.PUR.purItemSpecification = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemSpecificationSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecID",SqlDbType.Int,SpecID.ToString.Length, SpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purItemSpecification(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemSpecificationSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.PUR.purItemSpecification)
      Dim Results As List(Of SIS.PUR.purItemSpecification) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurItemSpecificationSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurItemSpecificationSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purItemSpecification)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purItemSpecification(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purItemSpecificationSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purItemSpecificationInsert(ByVal Record As SIS.PUR.purItemSpecification) As SIS.PUR.purItemSpecification
      Dim _Rec As SIS.PUR.purItemSpecification = SIS.PUR.purItemSpecification.purItemSpecificationGetNewRecord()
      With _Rec
        .SpecName = Record.SpecName
        .IsFixed = Record.IsFixed
        .IsDerived = Record.IsDerived
        .ValidateValue = Record.ValidateValue
        .UseValues = Record.UseValues
        .AllowUserValue = Record.AllowUserValue
        .ValueDataTypeID = Record.ValueDataTypeID
        .IsRange = Record.IsRange
      End With
      Return SIS.PUR.purItemSpecification.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purItemSpecification) As SIS.PUR.purItemSpecification
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemSpecificationInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecName",SqlDbType.NVarChar,51, Iif(Record.SpecName= "" ,Convert.DBNull, Record.SpecName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsFixed",SqlDbType.Bit,3, Record.IsFixed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDerived",SqlDbType.Bit,3, Record.IsDerived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValidateValue",SqlDbType.Bit,3, Record.ValidateValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UseValues",SqlDbType.Bit,3, Record.UseValues)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllowUserValue",SqlDbType.Bit,3, Record.AllowUserValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValueDataTypeID",SqlDbType.NVarChar,51, Iif(Record.ValueDataTypeID= "" ,Convert.DBNull, Record.ValueDataTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsRange",SqlDbType.Bit,3, Record.IsRange)
          Cmd.Parameters.Add("@Return_SpecID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SpecID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SpecID = Cmd.Parameters("@Return_SpecID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purItemSpecificationUpdate(ByVal Record As SIS.PUR.purItemSpecification) As SIS.PUR.purItemSpecification
      Dim _Rec As SIS.PUR.purItemSpecification = SIS.PUR.purItemSpecification.purItemSpecificationGetByID(Record.SpecID)
      With _Rec
        .SpecName = Record.SpecName
        .IsFixed = Record.IsFixed
        .IsDerived = Record.IsDerived
        .ValidateValue = Record.ValidateValue
        .UseValues = Record.UseValues
        .AllowUserValue = Record.AllowUserValue
        .ValueDataTypeID = Record.ValueDataTypeID
        .IsRange = Record.IsRange
      End With
      Return SIS.PUR.purItemSpecification.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purItemSpecification) As SIS.PUR.purItemSpecification
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemSpecificationUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SpecID",SqlDbType.Int,11, Record.SpecID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecName",SqlDbType.NVarChar,51, Iif(Record.SpecName= "" ,Convert.DBNull, Record.SpecName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsFixed",SqlDbType.Bit,3, Record.IsFixed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDerived",SqlDbType.Bit,3, Record.IsDerived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValidateValue",SqlDbType.Bit,3, Record.ValidateValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UseValues",SqlDbType.Bit,3, Record.UseValues)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllowUserValue",SqlDbType.Bit,3, Record.AllowUserValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValueDataTypeID",SqlDbType.NVarChar,51, Iif(Record.ValueDataTypeID= "" ,Convert.DBNull, Record.ValueDataTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsRange",SqlDbType.Bit,3, Record.IsRange)
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
    Public Shared Function purItemSpecificationDelete(ByVal Record As SIS.PUR.purItemSpecification) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemSpecificationDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SpecID",SqlDbType.Int,Record.SpecID.ToString.Length, Record.SpecID)
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
    Public Shared Function SelectpurItemSpecificationAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemSpecificationAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PUR.purItemSpecification = New SIS.PUR.purItemSpecification(Reader)
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
