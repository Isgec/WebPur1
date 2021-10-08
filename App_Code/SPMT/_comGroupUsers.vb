Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COM
  <DataObject()> _
  Partial Public Class comGroupUsers
    Private Shared _RecordCount As Integer
    Private _GroupID As String = ""
    Private _LoginID As String = ""
    Private _Active As Boolean = False
    Private _aspnet_Users1_UserFullName As String = ""
    Private _SYS_Groups2_Description As String = ""
    Private _FK_SYS_GroupLogins_aspnet_Users As SIS.COM.comUsers = Nothing
    Private _FK_SYS_GroupLogins_SYS_Groups As SIS.COM.comGroups = Nothing
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
    Public Property GroupID() As String
      Get
        Return _GroupID
      End Get
      Set(ByVal value As String)
        _GroupID = value
      End Set
    End Property
    Public Property LoginID() As String
      Get
        Return _LoginID
      End Get
      Set(ByVal value As String)
        _LoginID = value
      End Set
    End Property
    Public Property Active() As Boolean
      Get
        Return _Active
      End Get
      Set(ByVal value As Boolean)
        _Active = value
      End Set
    End Property
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Property SYS_Groups2_Description() As String
      Get
        Return _SYS_Groups2_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SYS_Groups2_Description = ""
         Else
           _SYS_Groups2_Description = value
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
        Return _GroupID & "|" & _LoginID
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
    Public Class PKcomGroupUsers
      Private _GroupID As String = ""
      Private _LoginID As String = ""
      Public Property GroupID() As String
        Get
          Return _GroupID
        End Get
        Set(ByVal value As String)
          _GroupID = value
        End Set
      End Property
      Public Property LoginID() As String
        Get
          Return _LoginID
        End Get
        Set(ByVal value As String)
          _LoginID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_SYS_GroupLogins_aspnet_Users() As SIS.COM.comUsers
      Get
        If _FK_SYS_GroupLogins_aspnet_Users Is Nothing Then
          _FK_SYS_GroupLogins_aspnet_Users = SIS.COM.comUsers.comUsersGetByID(_LoginID)
        End If
        Return _FK_SYS_GroupLogins_aspnet_Users
      End Get
    End Property
    Public ReadOnly Property FK_SYS_GroupLogins_SYS_Groups() As SIS.COM.comGroups
      Get
        If _FK_SYS_GroupLogins_SYS_Groups Is Nothing Then
          _FK_SYS_GroupLogins_SYS_Groups = SIS.COM.comGroups.comGroupsGetByID(_GroupID)
        End If
        Return _FK_SYS_GroupLogins_SYS_Groups
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function comGroupUsersGetNewRecord() As SIS.COM.comGroupUsers
      Return New SIS.COM.comGroupUsers()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function comGroupUsersGetByID(ByVal GroupID As String, ByVal LoginID As String) As SIS.COM.comGroupUsers
      Dim Results As SIS.COM.comGroupUsers = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetToolsConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcomGroupUsersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID", SqlDbType.NVarChar, GroupID.ToString.Length, GroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, LoginID.ToString.Length, LoginID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.COM.comGroupUsers(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function comGroupUsersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal GroupID As String, ByVal LoginID As String) As List(Of SIS.COM.comGroupUsers)
      Dim Results As List(Of SIS.COM.comGroupUsers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetToolsConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcomGroupUsersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcomGroupUsersSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_GroupID", SqlDbType.NVarChar, 6, IIf(GroupID Is Nothing, String.Empty, GroupID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_LoginID", SqlDbType.NVarChar, 8, IIf(LoginID Is Nothing, String.Empty, LoginID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COM.comGroupUsers)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COM.comGroupUsers(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function comGroupUsersSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal GroupID As String, ByVal LoginID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function comGroupUsersGetByID(ByVal GroupID As String, ByVal LoginID As String, ByVal Filter_GroupID As String, ByVal Filter_LoginID As String) As SIS.COM.comGroupUsers
      Return comGroupUsersGetByID(GroupID, LoginID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function comGroupUsersInsert(ByVal Record As SIS.COM.comGroupUsers) As SIS.COM.comGroupUsers
      Dim _Rec As SIS.COM.comGroupUsers = SIS.COM.comGroupUsers.comGroupUsersGetNewRecord()
      With _Rec
        .GroupID = Record.GroupID
        .LoginID = Record.LoginID
        .Active = Record.Active
      End With
      Return SIS.COM.comGroupUsers.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.COM.comGroupUsers) As SIS.COM.comGroupUsers
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetToolsConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcomGroupUsersInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID", SqlDbType.NVarChar, 7, Record.GroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, Record.LoginID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active", SqlDbType.Bit, 3, Record.Active)
          Cmd.Parameters.Add("@Return_GroupID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_GroupID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_LoginID", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_LoginID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.GroupID = Cmd.Parameters("@Return_GroupID").Value
          Record.LoginID = Cmd.Parameters("@Return_LoginID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function comGroupUsersUpdate(ByVal Record As SIS.COM.comGroupUsers) As SIS.COM.comGroupUsers
      Dim _Rec As SIS.COM.comGroupUsers = SIS.COM.comGroupUsers.comGroupUsersGetByID(Record.GroupID, Record.LoginID)
      With _Rec
        .Active = Record.Active
      End With
      Return SIS.COM.comGroupUsers.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.COM.comGroupUsers) As SIS.COM.comGroupUsers
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetToolsConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcomGroupUsersUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GroupID", SqlDbType.NVarChar, 7, Record.GroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LoginID", SqlDbType.NVarChar, 9, Record.LoginID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID", SqlDbType.NVarChar, 7, Record.GroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, Record.LoginID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active", SqlDbType.Bit, 3, Record.Active)
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
    Public Shared Function comGroupUsersDelete(ByVal Record As SIS.COM.comGroupUsers) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetToolsConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcomGroupUsersDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GroupID", SqlDbType.NVarChar, Record.GroupID.ToString.Length, Record.GroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LoginID", SqlDbType.NVarChar, Record.LoginID.ToString.Length, Record.LoginID)
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
