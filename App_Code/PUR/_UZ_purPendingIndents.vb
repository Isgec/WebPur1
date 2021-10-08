Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purPendingIndents
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property SelectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property SelectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function SelectWF(ByVal IndentNo As Int32, ByVal IndentLine As Int32, ByVal OrderedQuantity As Decimal) As SIS.PUR.purPendingIndents
      Dim Results As SIS.PUR.purPendingIndents = purPendingIndentsGetByID(IndentNo, IndentLine)
      Return Results
    End Function
    Public Shared Function UZ_purPendingIndentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IndentNo As Int32) As List(Of SIS.PUR.purPendingIndents)
      Dim Results As List(Of SIS.PUR.purPendingIndents) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppur_LG_PendingIndentsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppur_LG_PendingIndentsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IndentNo", SqlDbType.Int, 10, IIf(IndentNo = Nothing, 0, IndentNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PUR.purPendingIndents)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purPendingIndents(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function

  End Class
End Namespace
