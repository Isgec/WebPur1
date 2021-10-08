Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purPendingOrders
    Inherits SIS.PUR.purOrderDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purPendingOrdersGetNewRecord() As SIS.PUR.purPendingOrders
      Return New SIS.PUR.purPendingOrders()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purPendingOrdersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal OrderNo As Int32, ByVal OrderRev As Int32, ByVal ItemCode As Int32) As List(Of SIS.PUR.purPendingOrders)
      Dim Results As List(Of SIS.PUR.purPendingOrders) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurPendingOrdersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurPendingOrdersSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_OrderNo",SqlDbType.Int,10, IIf(OrderNo = Nothing, 0,OrderNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_OrderRev",SqlDbType.Int,10, IIf(OrderRev = Nothing, 0,OrderRev))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ItemCode",SqlDbType.Int,10, IIf(ItemCode = Nothing, 0,ItemCode))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PUR.purPendingOrders)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purPendingOrders(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purPendingOrdersSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal OrderNo As Int32, ByVal OrderRev As Int32, ByVal ItemCode As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purPendingOrdersGetByID(ByVal OrderNo As Int32, ByVal OrderLine As Int32, ByVal OrderRev As Int32) As SIS.PUR.purPendingOrders
      Dim Results As SIS.PUR.purPendingOrders = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurOrderDetailsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.Int,OrderNo.ToString.Length, OrderNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderLine",SqlDbType.Int,OrderLine.ToString.Length, OrderLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderRev",SqlDbType.Int,OrderRev.ToString.Length, OrderRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purPendingOrders(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purPendingOrdersGetByID(ByVal OrderNo As Int32, ByVal OrderLine As Int32, ByVal OrderRev As Int32, ByVal Filter_OrderNo As Int32, ByVal Filter_OrderRev As Int32, ByVal Filter_ItemCode As Int32) As SIS.PUR.purPendingOrders
      Dim Results As SIS.PUR.purPendingOrders = SIS.PUR.purPendingOrders.purPendingOrdersGetByID(OrderNo, OrderLine, OrderRev)
      Return Results
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
