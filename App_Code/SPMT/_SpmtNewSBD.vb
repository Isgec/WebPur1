Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SPMT
  <DataObject()> _
  Partial Public Class SpmtNewSBD
    Private Shared _RecordCount As Integer
    Public Property IRNo As Int32 = 0
    Public Property SerialNo As Int32 = 0
    Public Property ItemDescription As String = ""
    Public Property BillType As String = ""
    Public Property HSNSACCode As String = ""
    Public Property UOM As String = ""
    Public Property Quantity As String = "0.00"
    Public Property Currency As String = ""
    Public Property ConversionFactorINR As String = "0.00"
    Public Property BasicValue As String = "0.00"
    Public Property Discount As String = "0.00"
    Public Property ServiceCharge As String = "0.00"
    Public Property AssessableValue As String = "0.00"
    Public Property IGSTRate As String = "0.00"
    Public Property IGSTAmount As String = "0.00"
    Public Property SGSTRate As String = "0.00"
    Public Property SGSTAmount As String = "0.00"
    Public Property CGSTRate As String = "0.00"
    Public Property CGSTAmount As String = "0.00"
    Public Property CessRate As String = "0.00"
    Public Property CessAmount As String = "0.00"
    Public Property TotalGST As String = "0.00"
    Public Property TotalAmount As String = "0.00"
    Public Property TotalGSTINR As String = "0.00"
    Public Property TotalAmountINR As String = "0.00"
    Public Property ProjectID As String = ""
    Public Property ElementID As String = ""
    Public Property EmployeeID As String = ""
    Public Property DepartmentID As String = ""
    Public Property CostCenterID As String = ""
    Public Property UploadBatchNo As String = ""
    Public Property TCSRate As String = "0.00"
    Public Property TCSAmount As String = "0.00"
    Public Property OrderNo As String = ""
    Public Property POLine As String = ""
    Public ReadOnly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _IRNo & "|" & _SerialNo
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
    Public Class PKSpmtNewSBD
      Private _IRNo As Int32 = 0
      Private _SerialNo As Int32 = 0
      Public Property IRNo() As Int32
        Get
          Return _IRNo
        End Get
        Set(ByVal value As Int32)
          _IRNo = value
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SpmtNewSBDGetNewRecord() As SIS.SPMT.SpmtNewSBD
      Return New SIS.SPMT.SpmtNewSBD()
    End Function
    Public Shared Function SpmtNewSBDSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.SPMT.SpmtNewSBD) As SIS.SPMT.SpmtNewSBD
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurSpmtNewSBDInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo", SqlDbType.Int, 11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription", SqlDbType.NVarChar, 101, IIf(Record.ItemDescription = "", Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillType", SqlDbType.Int, 11, IIf(Record.BillType = "", Convert.DBNull, Record.BillType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSNSACCode", SqlDbType.NVarChar, 21, IIf(Record.HSNSACCode = "", Convert.DBNull, Record.HSNSACCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM", SqlDbType.NVarChar, 4, IIf(Record.UOM = "", Convert.DBNull, Record.UOM))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity", SqlDbType.Decimal, 21, IIf(Record.Quantity = "", Convert.DBNull, Record.Quantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Currency", SqlDbType.NVarChar, 51, IIf(Record.Currency = "", Convert.DBNull, Record.Currency))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR", SqlDbType.Decimal, 25, IIf(Record.ConversionFactorINR = "", Convert.DBNull, Record.ConversionFactorINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BasicValue", SqlDbType.Decimal, 21, IIf(Record.BasicValue = "", Convert.DBNull, Record.BasicValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Discount", SqlDbType.Decimal, 21, IIf(Record.Discount = "", Convert.DBNull, Record.Discount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceCharge", SqlDbType.Decimal, 21, IIf(Record.ServiceCharge = "", Convert.DBNull, Record.ServiceCharge))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssessableValue", SqlDbType.Decimal, 21, IIf(Record.AssessableValue = "", Convert.DBNull, Record.AssessableValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTRate", SqlDbType.Decimal, 21, IIf(Record.IGSTRate = "", Convert.DBNull, Record.IGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTAmount", SqlDbType.Decimal, 21, IIf(Record.IGSTAmount = "", Convert.DBNull, Record.IGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTRate", SqlDbType.Decimal, 21, IIf(Record.SGSTRate = "", Convert.DBNull, Record.SGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTAmount", SqlDbType.Decimal, 21, IIf(Record.SGSTAmount = "", Convert.DBNull, Record.SGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTRate", SqlDbType.Decimal, 21, IIf(Record.CGSTRate = "", Convert.DBNull, Record.CGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTAmount", SqlDbType.Decimal, 21, IIf(Record.CGSTAmount = "", Convert.DBNull, Record.CGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CessRate", SqlDbType.Decimal, 21, IIf(Record.CessRate = "", Convert.DBNull, Record.CessRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CessAmount", SqlDbType.Decimal, 21, IIf(Record.CessAmount = "", Convert.DBNull, Record.CessAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalGST", SqlDbType.Decimal, 21, IIf(Record.TotalGST = "", Convert.DBNull, Record.TotalGST))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmount", SqlDbType.Decimal, 21, IIf(Record.TotalAmount = "", Convert.DBNull, Record.TotalAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalGSTINR", SqlDbType.Decimal, 21, IIf(Record.TotalGSTINR = "", Convert.DBNull, Record.TotalGSTINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmountINR", SqlDbType.Decimal, 21, IIf(Record.TotalAmountINR = "", Convert.DBNull, Record.TotalAmountINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID", SqlDbType.NVarChar, 9, IIf(Record.ElementID = "", Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 9, IIf(Record.EmployeeID = "", Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID", SqlDbType.NVarChar, 7, IIf(Record.DepartmentID = "", Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID", SqlDbType.NVarChar, 7, IIf(Record.CostCenterID = "", Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadBatchNo", SqlDbType.NVarChar, 51, IIf(Record.UploadBatchNo = "", Convert.DBNull, Record.UploadBatchNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCSRate", SqlDbType.Decimal, 23, IIf(Record.TCSRate = "", Convert.DBNull, Record.TCSRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCSAmount", SqlDbType.Decimal, 21, IIf(Record.TCSAmount = "", Convert.DBNull, Record.TCSAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo", SqlDbType.Int, 11, IIf(Record.OrderNo = "", Convert.DBNull, Record.OrderNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POLine", SqlDbType.Int, 11, IIf(Record.POLine = "", Convert.DBNull, Record.POLine))
          Cmd.Parameters.Add("@Return_IRNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_IRNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.IRNo = Cmd.Parameters("@Return_IRNo").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.SPMT.SpmtNewSBD) As SIS.SPMT.SpmtNewSBD
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurSpmtNewSBDUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IRNo", SqlDbType.Int, 11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo", SqlDbType.Int, 11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo", SqlDbType.Int, 11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription", SqlDbType.NVarChar, 101, IIf(Record.ItemDescription = "", Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillType", SqlDbType.Int, 11, IIf(Record.BillType = "", Convert.DBNull, Record.BillType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSNSACCode", SqlDbType.NVarChar, 21, IIf(Record.HSNSACCode = "", Convert.DBNull, Record.HSNSACCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM", SqlDbType.NVarChar, 4, IIf(Record.UOM = "", Convert.DBNull, Record.UOM))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity", SqlDbType.Decimal, 21, IIf(Record.Quantity = "", Convert.DBNull, Record.Quantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Currency", SqlDbType.NVarChar, 51, IIf(Record.Currency = "", Convert.DBNull, Record.Currency))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR", SqlDbType.Decimal, 25, IIf(Record.ConversionFactorINR = "", Convert.DBNull, Record.ConversionFactorINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BasicValue", SqlDbType.Decimal, 21, IIf(Record.BasicValue = "", Convert.DBNull, Record.BasicValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Discount", SqlDbType.Decimal, 21, IIf(Record.Discount = "", Convert.DBNull, Record.Discount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceCharge", SqlDbType.Decimal, 21, IIf(Record.ServiceCharge = "", Convert.DBNull, Record.ServiceCharge))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssessableValue", SqlDbType.Decimal, 21, IIf(Record.AssessableValue = "", Convert.DBNull, Record.AssessableValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTRate", SqlDbType.Decimal, 21, IIf(Record.IGSTRate = "", Convert.DBNull, Record.IGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTAmount", SqlDbType.Decimal, 21, IIf(Record.IGSTAmount = "", Convert.DBNull, Record.IGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTRate", SqlDbType.Decimal, 21, IIf(Record.SGSTRate = "", Convert.DBNull, Record.SGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTAmount", SqlDbType.Decimal, 21, IIf(Record.SGSTAmount = "", Convert.DBNull, Record.SGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTRate", SqlDbType.Decimal, 21, IIf(Record.CGSTRate = "", Convert.DBNull, Record.CGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTAmount", SqlDbType.Decimal, 21, IIf(Record.CGSTAmount = "", Convert.DBNull, Record.CGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CessRate", SqlDbType.Decimal, 21, IIf(Record.CessRate = "", Convert.DBNull, Record.CessRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CessAmount", SqlDbType.Decimal, 21, IIf(Record.CessAmount = "", Convert.DBNull, Record.CessAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalGST", SqlDbType.Decimal, 21, IIf(Record.TotalGST = "", Convert.DBNull, Record.TotalGST))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmount", SqlDbType.Decimal, 21, IIf(Record.TotalAmount = "", Convert.DBNull, Record.TotalAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalGSTINR", SqlDbType.Decimal, 21, IIf(Record.TotalGSTINR = "", Convert.DBNull, Record.TotalGSTINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmountINR", SqlDbType.Decimal, 21, IIf(Record.TotalAmountINR = "", Convert.DBNull, Record.TotalAmountINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID", SqlDbType.NVarChar, 9, IIf(Record.ElementID = "", Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 9, IIf(Record.EmployeeID = "", Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID", SqlDbType.NVarChar, 7, IIf(Record.DepartmentID = "", Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID", SqlDbType.NVarChar, 7, IIf(Record.CostCenterID = "", Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadBatchNo", SqlDbType.NVarChar, 51, IIf(Record.UploadBatchNo = "", Convert.DBNull, Record.UploadBatchNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCSRate", SqlDbType.Decimal, 23, IIf(Record.TCSRate = "", Convert.DBNull, Record.TCSRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TCSAmount", SqlDbType.Decimal, 21, IIf(Record.TCSAmount = "", Convert.DBNull, Record.TCSAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo", SqlDbType.Int, 11, IIf(Record.OrderNo = "", Convert.DBNull, Record.OrderNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POLine", SqlDbType.Int, 11, IIf(Record.POLine = "", Convert.DBNull, Record.POLine))
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
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
