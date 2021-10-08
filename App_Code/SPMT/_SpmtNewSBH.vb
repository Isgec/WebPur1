Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SPMT
  <DataObject()> _
  Partial Public Class SpmtNewSBH
    Private Shared _RecordCount As Integer
    Public Property IRNo As Int32 = 0
    Public Property PurchaseType As String = ""
    Public Property TranTypeID As String = ""
    Private _IRReceivedOn As String = ""
    Public Property IsgecGSTIN As String = ""
    Public Property BPID As String = ""
    Public Property SupplierGSTIN As String = ""
    Public Property SupplierName As String = ""
    Public Property SupplierGSTINNumber As String = ""
    Public Property ShipToState As String = ""
    Public Property BillNumber As String = ""
    Private _BillDate As String = ""
    Public Property BillRemarks As String = ""
    Public Property CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Public Property AdviceNo As String = ""
    Public Property ProjectID As String = ""
    Public Property ElementID As String = ""
    Public Property EmployeeID As String = ""
    Public Property DepartmentID As String = ""
    Public Property CostCenterID As String = ""
    Public Property UploadBatchNo As String = ""
    Public Property TotalBillAmount As String = "0.00"
    Public Property OrderNo As String = ""
    Public Property IRReceivedOn() As String
      Get
        If Not _IRReceivedOn = String.Empty Then
          Return Convert.ToDateTime(_IRReceivedOn).ToString("dd/MM/yyyy")
        End If
        Return _IRReceivedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _IRReceivedOn = ""
        Else
          _IRReceivedOn = value
        End If
      End Set
    End Property
    Public Property BillDate() As String
      Get
        If Not _BillDate = String.Empty Then
          Return Convert.ToDateTime(_BillDate).ToString("dd/MM/yyyy")
        End If
        Return _BillDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BillDate = ""
         Else
           _BillDate = value
         End If
      End Set
    End Property
    Public Property CreatedOn() As String
      Get
        If Not _CreatedOn = String.Empty Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy")
        End If
        Return _CreatedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CreatedOn = ""
         Else
           _CreatedOn = value
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
        Return _IRNo
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
    Public Class PKSpmtNewSBH
      Private _IRNo As Int32 = 0
      Public Property IRNo() As Int32
        Get
          Return _IRNo
        End Get
        Set(ByVal value As Int32)
          _IRNo = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SpmtNewSBHGetNewRecord() As SIS.SPMT.SpmtNewSBH
      Return New SIS.SPMT.SpmtNewSBH()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function SpmtNewSBHGetByID(ByVal IRNo As Int32) As SIS.SPMT.SpmtNewSBH
      Dim Results As SIS.SPMT.SpmtNewSBH = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spSpmtNewSBHSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo", SqlDbType.Int, IRNo.ToString.Length, IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.SPMT.SpmtNewSBH(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SpmtNewSBHSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.SPMT.SpmtNewSBH) As SIS.SPMT.SpmtNewSBH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurSpmtNewSBHInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PurchaseType", SqlDbType.NVarChar, 51, IIf(Record.PurchaseType = "", Convert.DBNull, Record.PurchaseType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranTypeID", SqlDbType.NVarChar, 4, IIf(Record.TranTypeID = "", Convert.DBNull, Record.TranTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRReceivedOn", SqlDbType.DateTime, 21, IIf(Record.IRReceivedOn = "", Convert.DBNull, Record.IRReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTIN", SqlDbType.Int, 11, IIf(Record.IsgecGSTIN = "", Convert.DBNull, Record.IsgecGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID", SqlDbType.NVarChar, 10, IIf(Record.BPID = "", Convert.DBNull, Record.BPID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTIN", SqlDbType.Int, 11, IIf(Record.SupplierGSTIN = "", Convert.DBNull, Record.SupplierGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName", SqlDbType.NVarChar, 101, IIf(Record.SupplierName = "", Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTINNumber", SqlDbType.NVarChar, 51, IIf(Record.SupplierGSTINNumber = "", Convert.DBNull, Record.SupplierGSTINNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShipToState", SqlDbType.NVarChar, 3, IIf(Record.ShipToState = "", Convert.DBNull, Record.ShipToState))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillNumber", SqlDbType.NVarChar, 51, IIf(Record.BillNumber = "", Convert.DBNull, Record.BillNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillDate", SqlDbType.DateTime, 21, IIf(Record.BillDate = "", Convert.DBNull, Record.BillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillRemarks", SqlDbType.NVarChar, 501, IIf(Record.BillRemarks = "", Convert.DBNull, Record.BillRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy", SqlDbType.NVarChar, 9, IIf(Record.CreatedBy = "", Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn", SqlDbType.DateTime, 21, IIf(Record.CreatedOn = "", Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdviceNo", SqlDbType.Int, 11, IIf(Record.AdviceNo = "", Convert.DBNull, Record.AdviceNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID", SqlDbType.NVarChar, 9, IIf(Record.ElementID = "", Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 9, IIf(Record.EmployeeID = "", Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID", SqlDbType.NVarChar, 7, IIf(Record.DepartmentID = "", Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID", SqlDbType.NVarChar, 7, IIf(Record.CostCenterID = "", Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadBatchNo", SqlDbType.NVarChar, 51, IIf(Record.UploadBatchNo = "", Convert.DBNull, Record.UploadBatchNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalBillAmount", SqlDbType.Decimal, 21, IIf(Record.TotalBillAmount = "", Convert.DBNull, Record.TotalBillAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo", SqlDbType.Int, 11, IIf(Record.OrderNo = "", Convert.DBNull, Record.OrderNo))
          Cmd.Parameters.Add("@Return_IRNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_IRNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.IRNo = Cmd.Parameters("@Return_IRNo").Value
        End Using
      End Using
      Return Record
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.SPMT.SpmtNewSBH) As SIS.SPMT.SpmtNewSBH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurSpmtNewSBHUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IRNo", SqlDbType.Int, 11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PurchaseType", SqlDbType.NVarChar, 51, IIf(Record.PurchaseType = "", Convert.DBNull, Record.PurchaseType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranTypeID", SqlDbType.NVarChar, 4, IIf(Record.TranTypeID = "", Convert.DBNull, Record.TranTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRReceivedOn", SqlDbType.DateTime, 21, IIf(Record.IRReceivedOn = "", Convert.DBNull, Record.IRReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTIN", SqlDbType.Int, 11, IIf(Record.IsgecGSTIN = "", Convert.DBNull, Record.IsgecGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID", SqlDbType.NVarChar, 10, IIf(Record.BPID = "", Convert.DBNull, Record.BPID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTIN", SqlDbType.Int, 11, IIf(Record.SupplierGSTIN = "", Convert.DBNull, Record.SupplierGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName", SqlDbType.NVarChar, 101, IIf(Record.SupplierName = "", Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTINNumber", SqlDbType.NVarChar, 51, IIf(Record.SupplierGSTINNumber = "", Convert.DBNull, Record.SupplierGSTINNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShipToState", SqlDbType.NVarChar, 3, IIf(Record.ShipToState = "", Convert.DBNull, Record.ShipToState))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillNumber", SqlDbType.NVarChar, 51, IIf(Record.BillNumber = "", Convert.DBNull, Record.BillNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillDate", SqlDbType.DateTime, 21, IIf(Record.BillDate = "", Convert.DBNull, Record.BillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillRemarks", SqlDbType.NVarChar, 501, IIf(Record.BillRemarks = "", Convert.DBNull, Record.BillRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy", SqlDbType.NVarChar, 9, IIf(Record.CreatedBy = "", Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn", SqlDbType.DateTime, 21, IIf(Record.CreatedOn = "", Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdviceNo", SqlDbType.Int, 11, IIf(Record.AdviceNo = "", Convert.DBNull, Record.AdviceNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID", SqlDbType.NVarChar, 9, IIf(Record.ElementID = "", Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 9, IIf(Record.EmployeeID = "", Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID", SqlDbType.NVarChar, 7, IIf(Record.DepartmentID = "", Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID", SqlDbType.NVarChar, 7, IIf(Record.CostCenterID = "", Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadBatchNo", SqlDbType.NVarChar, 51, IIf(Record.UploadBatchNo = "", Convert.DBNull, Record.UploadBatchNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalBillAmount", SqlDbType.Decimal, 21, IIf(Record.TotalBillAmount = "", Convert.DBNull, Record.TotalBillAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo", SqlDbType.Int, 11, IIf(Record.OrderNo = "", Convert.DBNull, Record.OrderNo))
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
    Public Shared Function SpmtNewSBHDelete(ByVal Record As SIS.SPMT.SpmtNewSBH) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spSpmtNewSBHDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IRNo",SqlDbType.Int,Record.IRNo.ToString.Length, Record.IRNo)
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
