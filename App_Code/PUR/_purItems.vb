Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purItems
    Private Shared _RecordCount As Integer
    Public Property ItemCode As Int32 = 0
    Public Property ItemDescription As String = ""
    Public Property UOM As String = ""
    Public Property OPBQty As String = "0.00"
    Public Property RECQty As String = "0.00"
    Public Property ISSQty As String = "0.00"
    Public Property BALQty As String = "0.00"
    Public Property ItemCategoryID As String = ""
    Public Property PUR_ItemCategories1_CategoryName As String = ""
    Public Property SPMT_ERPUnits2_Description As String = ""
    Private _FK_PUR_Items_ItemCategoryID As SIS.PUR.purItemCategories = Nothing
    Private _FK_PUR_Items_UOM As SIS.SPMT.spmtERPUnits = Nothing
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
        Return "" & _ItemDescription.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ItemCode
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
    Public Class PKpurItems
      Private _ItemCode As Int32 = 0
      Public Property ItemCode() As Int32
        Get
          Return _ItemCode
        End Get
        Set(ByVal value As Int32)
          _ItemCode = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PUR_Items_ItemCategoryID() As SIS.PUR.purItemCategories
      Get
        If _FK_PUR_Items_ItemCategoryID Is Nothing Then
          _FK_PUR_Items_ItemCategoryID = SIS.PUR.purItemCategories.purItemCategoriesGetByID(_ItemCategoryID)
        End If
        Return _FK_PUR_Items_ItemCategoryID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Items_UOM() As SIS.SPMT.spmtERPUnits
      Get
        If _FK_PUR_Items_UOM Is Nothing Then
          _FK_PUR_Items_UOM = SIS.SPMT.spmtERPUnits.spmtERPUnitsGetByID(_UOM)
        End If
        Return _FK_PUR_Items_UOM
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemsSelectList(ByVal OrderBy As String) As List(Of SIS.PUR.purItems)
      Dim Results As List(Of SIS.PUR.purItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purItems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purItems(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemsGetNewRecord() As SIS.PUR.purItems
      Return New SIS.PUR.purItems()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemsGetByID(ByVal ItemCode As Int32) As SIS.PUR.purItems
      Dim Results As SIS.PUR.purItems = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.Int,ItemCode.ToString.Length, ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purItems(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purItemsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.PUR.purItems)
      Dim Results As List(Of SIS.PUR.purItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurItemsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurItemsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purItems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purItems(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purItemsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purItemsInsert(ByVal Record As SIS.PUR.purItems) As SIS.PUR.purItems
      Dim _Rec As SIS.PUR.purItems = SIS.PUR.purItems.purItemsGetNewRecord()
      With _Rec
        .ItemDescription = Record.ItemDescription
        .UOM = Record.UOM
        .OPBQty = Record.OPBQty
        .RECQty = Record.RECQty
        .ISSQty = Record.ISSQty
        .BALQty = Record.BALQty
        .ItemCategoryID = Record.ItemCategoryID
      End With
      Return SIS.PUR.purItems.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purItems) As SIS.PUR.purItems
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,101, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM",SqlDbType.NVarChar,4, Iif(Record.UOM= "" ,Convert.DBNull, Record.UOM))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OPBQty",SqlDbType.Decimal,23, Iif(Record.OPBQty= "" ,Convert.DBNull, Record.OPBQty))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RECQty",SqlDbType.Decimal,23, Iif(Record.RECQty= "" ,Convert.DBNull, Record.RECQty))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISSQty",SqlDbType.Decimal,23, Iif(Record.ISSQty= "" ,Convert.DBNull, Record.ISSQty))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BALQty",SqlDbType.Decimal,23, Iif(Record.BALQty= "" ,Convert.DBNull, Record.BALQty))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,11, Iif(Record.ItemCategoryID= "" ,Convert.DBNull, Record.ItemCategoryID))
          Cmd.Parameters.Add("@Return_ItemCode", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemCode").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ItemCode = Cmd.Parameters("@Return_ItemCode").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purItemsUpdate(ByVal Record As SIS.PUR.purItems) As SIS.PUR.purItems
      Dim _Rec As SIS.PUR.purItems = SIS.PUR.purItems.purItemsGetByID(Record.ItemCode)
      With _Rec
        .ItemDescription = Record.ItemDescription
        .UOM = Record.UOM
        .OPBQty = Record.OPBQty
        .RECQty = Record.RECQty
        .ISSQty = Record.ISSQty
        .BALQty = Record.BALQty
        .ItemCategoryID = Record.ItemCategoryID
      End With
      Return SIS.PUR.purItems.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purItems) As SIS.PUR.purItems
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemCode",SqlDbType.Int,11, Record.ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,101, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM",SqlDbType.NVarChar,4, Iif(Record.UOM= "" ,Convert.DBNull, Record.UOM))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OPBQty",SqlDbType.Decimal,23, Iif(Record.OPBQty= "" ,Convert.DBNull, Record.OPBQty))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RECQty",SqlDbType.Decimal,23, Iif(Record.RECQty= "" ,Convert.DBNull, Record.RECQty))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISSQty",SqlDbType.Decimal,23, Iif(Record.ISSQty= "" ,Convert.DBNull, Record.ISSQty))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BALQty",SqlDbType.Decimal,23, Iif(Record.BALQty= "" ,Convert.DBNull, Record.BALQty))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCategoryID",SqlDbType.Int,11, Iif(Record.ItemCategoryID= "" ,Convert.DBNull, Record.ItemCategoryID))
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
    Public Shared Function purItemsDelete(ByVal Record As SIS.PUR.purItems) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemCode",SqlDbType.Int,Record.ItemCode.ToString.Length, Record.ItemCode)
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
    Public Shared Function SelectpurItemsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurItemsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PUR.purItems = New SIS.PUR.purItems(Reader)
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
