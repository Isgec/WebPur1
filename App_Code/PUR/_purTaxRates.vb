Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purTaxRates
    Private Shared _RecordCount As Integer
    Public Property TaxCode As Int32 = 0
    Public Property SerialNo As Int32 = 0
    Private _FromDate As String = ""
    Private _ToDate As String = ""
    Public Property TaxRate As String = "0.0000"
    Public Property CGSTRate As String = "0.0000"
    Public Property SGSTRate As String = "0.0000"
    Public Property CESSRate As String = "0.0000"
    Public Property TCSRate As String = "0.0000"
    Public Property PUR_TaxCodes1_TaxDescription As String = ""
    Private _FK_PUR_TaxRates_Code As SIS.PUR.purTaxCodes = Nothing
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
    Public Property FromDate() As String
      Get
        If Not _FromDate = String.Empty Then
          Return Convert.ToDateTime(_FromDate).ToString("dd/MM/yyyy")
        End If
        Return _FromDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _FromDate = ""
         Else
           _FromDate = value
         End If
      End Set
    End Property
    Public Property ToDate() As String
      Get
        If Not _ToDate = String.Empty Then
          Return Convert.ToDateTime(_ToDate).ToString("dd/MM/yyyy")
        End If
        Return _ToDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ToDate = ""
         Else
           _ToDate = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _TaxRate.ToString.PadRight(18, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _TaxCode & "|" & _SerialNo
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
    Public Class PKpurTaxRates
      Private _TaxCode As Int32 = 0
      Private _SerialNo As Int32 = 0
      Public Property TaxCode() As Int32
        Get
          Return _TaxCode
        End Get
        Set(ByVal value As Int32)
          _TaxCode = value
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
    Public ReadOnly Property FK_PUR_TaxRates_Code() As SIS.PUR.purTaxCodes
      Get
        If _FK_PUR_TaxRates_Code Is Nothing Then
          _FK_PUR_TaxRates_Code = SIS.PUR.purTaxCodes.purTaxCodesGetByID(_TaxCode)
        End If
        Return _FK_PUR_TaxRates_Code
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purTaxRatesSelectList(ByVal OrderBy As String) As List(Of SIS.PUR.purTaxRates)
      Dim Results As List(Of SIS.PUR.purTaxRates) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurTaxRatesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purTaxRates)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purTaxRates(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purTaxRatesGetNewRecord() As SIS.PUR.purTaxRates
      Return New SIS.PUR.purTaxRates()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purTaxRatesGetByID(ByVal TaxCode As Int32, ByVal SerialNo As Int32) As SIS.PUR.purTaxRates
      Dim Results As SIS.PUR.purTaxRates = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurTaxRatesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxCode",SqlDbType.Int,TaxCode.ToString.Length, TaxCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purTaxRates(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purTaxRatesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TaxCode As Int32) As List(Of SIS.PUR.purTaxRates)
      Dim Results As List(Of SIS.PUR.purTaxRates) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurTaxRatesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurTaxRatesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TaxCode",SqlDbType.Int,10, IIf(TaxCode = Nothing, 0,TaxCode))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purTaxRates)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purTaxRates(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purTaxRatesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TaxCode As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purTaxRatesGetByID(ByVal TaxCode As Int32, ByVal SerialNo As Int32, ByVal Filter_TaxCode As Int32) As SIS.PUR.purTaxRates
      Return purTaxRatesGetByID(TaxCode, SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purTaxRatesInsert(ByVal Record As SIS.PUR.purTaxRates) As SIS.PUR.purTaxRates
      Dim _Rec As SIS.PUR.purTaxRates = SIS.PUR.purTaxRates.purTaxRatesGetNewRecord()
      With _Rec
        .TaxCode = Record.TaxCode
        .FromDate = Record.FromDate
        .ToDate = Record.ToDate
        .TaxRate = Record.TaxRate
        .CGSTRate = Record.CGSTRate
        .SGSTRate = Record.SGSTRate
        .CessRate = Record.CessRate
        .TCSRate = Record.TCSRate
      End With
      Return SIS.PUR.purTaxRates.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purTaxRates) As SIS.PUR.purTaxRates
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurTaxRatesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxCode",SqlDbType.Int,11, Record.TaxCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromDate",SqlDbType.DateTime,21, Iif(Record.FromDate= "" ,Convert.DBNull, Record.FromDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToDate",SqlDbType.DateTime,21, Iif(Record.ToDate= "" ,Convert.DBNull, Record.ToDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxRate",SqlDbType.Decimal,23, Iif(Record.TaxRate= "" ,Convert.DBNull, Record.TaxRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTRate",SqlDbType.Decimal,23, Iif(Record.CGSTRate= "" ,Convert.DBNull, Record.CGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTRate",SqlDbType.Decimal,23, Iif(Record.SGSTRate= "" ,Convert.DBNull, Record.SGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CessRate",SqlDbType.Decimal,23, Iif(Record.CessRate= "" ,Convert.DBNull, Record.CessRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCSRate",SqlDbType.Decimal,23, Iif(Record.TCSRate= "" ,Convert.DBNull, Record.TCSRate))
          Cmd.Parameters.Add("@Return_TaxCode", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_TaxCode").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.TaxCode = Cmd.Parameters("@Return_TaxCode").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purTaxRatesUpdate(ByVal Record As SIS.PUR.purTaxRates) As SIS.PUR.purTaxRates
      Dim _Rec As SIS.PUR.purTaxRates = SIS.PUR.purTaxRates.purTaxRatesGetByID(Record.TaxCode, Record.SerialNo)
      With _Rec
        .FromDate = Record.FromDate
        .ToDate = Record.ToDate
        .TaxRate = Record.TaxRate
        .CGSTRate = Record.CGSTRate
        .SGSTRate = Record.SGSTRate
        .CessRate = Record.CessRate
        .TCSRate = Record.TCSRate
      End With
      Return SIS.PUR.purTaxRates.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purTaxRates) As SIS.PUR.purTaxRates
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurTaxRatesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TaxCode",SqlDbType.Int,11, Record.TaxCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxCode",SqlDbType.Int,11, Record.TaxCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromDate",SqlDbType.DateTime,21, Iif(Record.FromDate= "" ,Convert.DBNull, Record.FromDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToDate",SqlDbType.DateTime,21, Iif(Record.ToDate= "" ,Convert.DBNull, Record.ToDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxRate",SqlDbType.Decimal,23, Iif(Record.TaxRate= "" ,Convert.DBNull, Record.TaxRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTRate",SqlDbType.Decimal,23, Iif(Record.CGSTRate= "" ,Convert.DBNull, Record.CGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTRate",SqlDbType.Decimal,23, Iif(Record.SGSTRate= "" ,Convert.DBNull, Record.SGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CessRate",SqlDbType.Decimal,23, Iif(Record.CessRate= "" ,Convert.DBNull, Record.CessRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCSRate",SqlDbType.Decimal,23, Iif(Record.TCSRate= "" ,Convert.DBNull, Record.TCSRate))
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
    Public Shared Function purTaxRatesDelete(ByVal Record As SIS.PUR.purTaxRates) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurTaxRatesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TaxCode",SqlDbType.Int,Record.TaxCode.ToString.Length, Record.TaxCode)
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
    Public Shared Function SelectpurTaxRatesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurTaxRatesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(18, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PUR.purTaxRates = New SIS.PUR.purTaxRates(Reader)
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
