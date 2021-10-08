Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purAprTypEmpLimit
    Private Shared _RecordCount As Integer
    Public Property SerialNo As Int32 = 0
    Public Property AprTypeID As String = ""
    Public Property CardNo As String = ""
    Public Property ApprovalLimit As String = ""
    Private _FromDate As String = ""
    Private _ToDate As String = ""
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property PUR_ApprovalTypes2_AprDescription As String = ""
    Private _FK_PUR_AprTypEmpLimit_CardNo As SIS.QCM.qcmUsers = Nothing
    Private _FK_PUR_AprTypEmpLimit_AprTypeID As SIS.PUR.purApprovalTypes = Nothing
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
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo
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
    Public Class PKpurAprTypEmpLimit
      Private _SerialNo As Int32 = 0
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PUR_AprTypEmpLimit_CardNo() As SIS.QCM.qcmUsers
      Get
        If _FK_PUR_AprTypEmpLimit_CardNo Is Nothing Then
          _FK_PUR_AprTypEmpLimit_CardNo = SIS.QCM.qcmUsers.qcmUsersGetByID(_CardNo)
        End If
        Return _FK_PUR_AprTypEmpLimit_CardNo
      End Get
    End Property
    Public ReadOnly Property FK_PUR_AprTypEmpLimit_AprTypeID() As SIS.PUR.purApprovalTypes
      Get
        If _FK_PUR_AprTypEmpLimit_AprTypeID Is Nothing Then
          _FK_PUR_AprTypEmpLimit_AprTypeID = SIS.PUR.purApprovalTypes.purApprovalTypesGetByID(_AprTypeID)
        End If
        Return _FK_PUR_AprTypEmpLimit_AprTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purAprTypEmpLimitGetNewRecord() As SIS.PUR.purAprTypEmpLimit
      Return New SIS.PUR.purAprTypEmpLimit()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purAprTypEmpLimitGetByID(ByVal SerialNo As Int32) As SIS.PUR.purAprTypEmpLimit
      Dim Results As SIS.PUR.purAprTypEmpLimit = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurAprTypEmpLimitSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purAprTypEmpLimit(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purAprTypEmpLimitSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As List(Of SIS.PUR.purAprTypEmpLimit)
      Dim Results As List(Of SIS.PUR.purAprTypEmpLimit) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurAprTypEmpLimitSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurAprTypEmpLimitSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo",SqlDbType.NVarChar,8, IIf(CardNo Is Nothing, String.Empty,CardNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purAprTypEmpLimit)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purAprTypEmpLimit(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purAprTypEmpLimitSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purAprTypEmpLimitGetByID(ByVal SerialNo As Int32, ByVal Filter_CardNo As String) As SIS.PUR.purAprTypEmpLimit
      Return purAprTypEmpLimitGetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purAprTypEmpLimitInsert(ByVal Record As SIS.PUR.purAprTypEmpLimit) As SIS.PUR.purAprTypEmpLimit
      Dim _Rec As SIS.PUR.purAprTypEmpLimit = SIS.PUR.purAprTypEmpLimit.purAprTypEmpLimitGetNewRecord()
      With _Rec
        .AprTypeID = Record.AprTypeID
        .CardNo = Record.CardNo
        .ApprovalLimit = Record.ApprovalLimit
        .FromDate = Record.FromDate
        .ToDate = Record.ToDate
      End With
      Return SIS.PUR.purAprTypEmpLimit.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purAprTypEmpLimit) As SIS.PUR.purAprTypEmpLimit
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurAprTypEmpLimitInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AprTypeID",SqlDbType.NVarChar,11, Record.AprTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalLimit",SqlDbType.Int,11, Iif(Record.ApprovalLimit= "" ,Convert.DBNull, Record.ApprovalLimit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromDate",SqlDbType.DateTime,21, Iif(Record.FromDate= "" ,Convert.DBNull, Record.FromDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToDate",SqlDbType.DateTime,21, Iif(Record.ToDate= "" ,Convert.DBNull, Record.ToDate))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purAprTypEmpLimitUpdate(ByVal Record As SIS.PUR.purAprTypEmpLimit) As SIS.PUR.purAprTypEmpLimit
      Dim _Rec As SIS.PUR.purAprTypEmpLimit = SIS.PUR.purAprTypEmpLimit.purAprTypEmpLimitGetByID(Record.SerialNo)
      With _Rec
        .AprTypeID = Record.AprTypeID
        .CardNo = Record.CardNo
        .ApprovalLimit = Record.ApprovalLimit
        .FromDate = Record.FromDate
        .ToDate = Record.ToDate
      End With
      Return SIS.PUR.purAprTypEmpLimit.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purAprTypEmpLimit) As SIS.PUR.purAprTypEmpLimit
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurAprTypEmpLimitUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AprTypeID",SqlDbType.NVarChar,11, Record.AprTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalLimit",SqlDbType.Int,11, Iif(Record.ApprovalLimit= "" ,Convert.DBNull, Record.ApprovalLimit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromDate",SqlDbType.DateTime,21, Iif(Record.FromDate= "" ,Convert.DBNull, Record.FromDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToDate",SqlDbType.DateTime,21, Iif(Record.ToDate= "" ,Convert.DBNull, Record.ToDate))
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
    Public Shared Function purAprTypEmpLimitDelete(ByVal Record As SIS.PUR.purAprTypEmpLimit) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurAprTypEmpLimitDelete"
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
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
