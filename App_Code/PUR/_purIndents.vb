Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  <DataObject()> _
  Partial Public Class purIndents
    Private Shared _RecordCount As Integer
    Public Property IndentNo As Int32 = 0
    Private _IndentDate As String = ""
    Public Property TranTypeID As String = ""
    Public Property StatusID As String = ""
    Public Property CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Public Property ApprovedBy As String = ""
    Private _ApprovedOn As String = ""
    Public Property InsuranceDetails As String = ""
    Public Property ModeOfDispatch As String = ""
    Public Property CurrencyID As String = ""
    Public Property IsgecGSTIN As String = ""
    Public Property CostCenterID As String = ""
    Public Property ConversionFactorINR As String = "0.00"
    Public Property WarrantyDetails As String = ""
    Public Property EmployeeID As String = ""
    Public Property DepartmentID As String = ""
    Public Property IndenterRemarks As String = ""
    Public Property ProjectID As String = ""
    Public Property DivisionID As String = ""
    Public Property ElementID As String = ""
    Public Property ApproverRemarks As String = ""
    Public Property PaymentTerms As String = ""
    Public Property DeliveryTerms As String = ""
    Public Property DestinationAddress As String = ""
    Public Property IsgecGSTINAddress As String = ""
    Private _DeliveryDate As String = ""
    Public Property BuyerID As String = ""
    Public Property BuyerRemarks As String = ""
    Private _BuyerActionOn As String = ""
    Public Property ShipToState As String = ""
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property aspnet_Users2_UserFullName As String = ""
    Public Property HRM_Departments3_Description As String = ""
    Public Property HRM_Divisions4_Description As String = ""
    Public Property HRM_Employees5_EmployeeName As String = ""
    Public Property IDM_Projects6_Description As String = ""
    Public Property IDM_WBS7_Description As String = ""
    Public Property PUR_Currencies8_CurrencyName As String = ""
    Public Property PUR_IndentStatus9_Description As String = ""
    Public Property SPMT_CostCenters10_Description As String = ""
    Public Property SPMT_IsgecGSTIN11_Description As String = ""
    Public Property SPMT_TranTypes12_Description As String = ""
    Public Property aspnet_Users13_UserFullName As String = ""
    Private _FK_PUR_Indents_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PUR_Indents_ApprovedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PUR_Indents_DepartmentID As SIS.QCM.qcmDepartments = Nothing
    Private _FK_PUR_Indents_DivisionID As SIS.QCM.qcmDivisions = Nothing
    Private _FK_PUR_Indents_EmployeeID As SIS.QCM.qcmEmployees = Nothing
    Private _FK_PUR_Indents_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_PUR_Indents_ElementID As SIS.PAK.pakWBS = Nothing
    Private _FK_PUR_Indents_CurrencyID As SIS.PUR.purCurrencies = Nothing
    Private _FK_PUR_Indents_StatusID As SIS.PUR.purIndentStatus = Nothing
    Private _FK_PUR_Indents_CostCenterID As SIS.SPMT.spmtCostCenters = Nothing
    Private _FK_PUR_Indents_IsgecGSTIN As SIS.SPMT.spmtIsgecGSTIN = Nothing
    Private _FK_PUR_Indents_TranTypeID As SIS.SPMT.spmtTranTypes = Nothing
    Private _FK_PUR_Indents_BuyerID As SIS.QCM.qcmUsers = Nothing
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
    Public Property BuyerActionOn() As String
      Get
        If Not _BuyerActionOn = String.Empty Then
          Return Convert.ToDateTime(_BuyerActionOn).ToString("dd/MM/yyyy")
        End If
        Return _BuyerActionOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _BuyerActionOn = ""
        Else
          _BuyerActionOn = value
        End If
      End Set
    End Property
    Public Property IndentDate() As String
      Get
        If Not _IndentDate = String.Empty Then
          Return Convert.ToDateTime(_IndentDate).ToString("dd/MM/yyyy")
        End If
        Return _IndentDate
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _IndentDate = ""
        Else
          _IndentDate = value
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
    Public Property ApprovedOn() As String
      Get
        If Not _ApprovedOn = String.Empty Then
          Return Convert.ToDateTime(_ApprovedOn).ToString("dd/MM/yyyy")
        End If
        Return _ApprovedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovedOn = ""
         Else
           _ApprovedOn = value
         End If
      End Set
    End Property
    Public Property DeliveryDate() As String
      Get
        If Not _DeliveryDate = String.Empty Then
          Return Convert.ToDateTime(_DeliveryDate).ToString("dd/MM/yyyy")
        End If
        Return _DeliveryDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DeliveryDate = ""
         Else
           _DeliveryDate = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _IndenterRemarks.ToString.PadRight(500, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _IndentNo
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
    Public Class PKpurIndents
      Private _IndentNo As Int32 = 0
      Public Property IndentNo() As Int32
        Get
          Return _IndentNo
        End Get
        Set(ByVal value As Int32)
          _IndentNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PUR_Indents_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PUR_Indents_CreatedBy Is Nothing Then
          _FK_PUR_Indents_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_PUR_Indents_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Indents_ApprovedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PUR_Indents_ApprovedBy Is Nothing Then
          _FK_PUR_Indents_ApprovedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ApprovedBy)
        End If
        Return _FK_PUR_Indents_ApprovedBy
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Indents_DepartmentID() As SIS.QCM.qcmDepartments
      Get
        If _FK_PUR_Indents_DepartmentID Is Nothing Then
          _FK_PUR_Indents_DepartmentID = SIS.QCM.qcmDepartments.qcmDepartmentsGetByID(_DepartmentID)
        End If
        Return _FK_PUR_Indents_DepartmentID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Indents_DivisionID() As SIS.QCM.qcmDivisions
      Get
        If _FK_PUR_Indents_DivisionID Is Nothing Then
          _FK_PUR_Indents_DivisionID = SIS.QCM.qcmDivisions.qcmDivisionsGetByID(_DivisionID)
        End If
        Return _FK_PUR_Indents_DivisionID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Indents_EmployeeID() As SIS.QCM.qcmEmployees
      Get
        If _FK_PUR_Indents_EmployeeID Is Nothing Then
          _FK_PUR_Indents_EmployeeID = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(_EmployeeID)
        End If
        Return _FK_PUR_Indents_EmployeeID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Indents_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_PUR_Indents_ProjectID Is Nothing Then
          _FK_PUR_Indents_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_PUR_Indents_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Indents_ElementID() As SIS.PAK.pakWBS
      Get
        If _FK_PUR_Indents_ElementID Is Nothing Then
          _FK_PUR_Indents_ElementID = SIS.PAK.pakWBS.pakWBSGetByID(_ElementID)
        End If
        Return _FK_PUR_Indents_ElementID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Indents_CurrencyID() As SIS.PUR.purCurrencies
      Get
        If _FK_PUR_Indents_CurrencyID Is Nothing Then
          _FK_PUR_Indents_CurrencyID = SIS.PUR.purCurrencies.purCurrenciesGetByID(_CurrencyID)
        End If
        Return _FK_PUR_Indents_CurrencyID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Indents_StatusID() As SIS.PUR.purIndentStatus
      Get
        If _FK_PUR_Indents_StatusID Is Nothing Then
          _FK_PUR_Indents_StatusID = SIS.PUR.purIndentStatus.purIndentStatusGetByID(_StatusID)
        End If
        Return _FK_PUR_Indents_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Indents_CostCenterID() As SIS.SPMT.spmtCostCenters
      Get
        If _FK_PUR_Indents_CostCenterID Is Nothing Then
          _FK_PUR_Indents_CostCenterID = SIS.SPMT.spmtCostCenters.spmtCostCentersGetByID(_CostCenterID)
        End If
        Return _FK_PUR_Indents_CostCenterID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Indents_IsgecGSTIN() As SIS.SPMT.spmtIsgecGSTIN
      Get
        If _FK_PUR_Indents_IsgecGSTIN Is Nothing Then
          _FK_PUR_Indents_IsgecGSTIN = SIS.SPMT.spmtIsgecGSTIN.spmtIsgecGSTINGetByID(_IsgecGSTIN)
        End If
        Return _FK_PUR_Indents_IsgecGSTIN
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Indents_TranTypeID() As SIS.SPMT.spmtTranTypes
      Get
        If _FK_PUR_Indents_TranTypeID Is Nothing Then
          _FK_PUR_Indents_TranTypeID = SIS.SPMT.spmtTranTypes.spmtTranTypesGetByID(_TranTypeID)
        End If
        Return _FK_PUR_Indents_TranTypeID
      End Get
    End Property
    Public ReadOnly Property FK_PUR_Indents_BuyerID() As SIS.QCM.qcmUsers
      Get
        If _FK_PUR_Indents_BuyerID Is Nothing Then
          _FK_PUR_Indents_BuyerID = SIS.QCM.qcmUsers.qcmUsersGetByID(_BuyerID)
        End If
        Return _FK_PUR_Indents_BuyerID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function purIndentsSelectList(ByVal OrderBy As String) As List(Of SIS.PUR.purIndents)
      Dim Results As List(Of SIS.PUR.purIndents) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "IndentNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurIndentsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purIndents)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purIndents(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purIndentsGetNewRecord() As SIS.PUR.purIndents
      Return New SIS.PUR.purIndents()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purIndentsGetByID(ByVal IndentNo As Int32) As SIS.PUR.purIndents
      Dim Results As SIS.PUR.purIndents = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurIndentsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentNo",SqlDbType.Int,IndentNo.ToString.Length, IndentNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purIndents(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purIndentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TranTypeID As String, ByVal StatusID As Int32, ByVal CreatedBy As String, ByVal EmployeeID As String, ByVal DepartmentID As String, ByVal ProjectID As String, ByVal DivisionID As String) As List(Of SIS.PUR.purIndents)
      Dim Results As List(Of SIS.PUR.purIndents) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "IndentNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppurIndentsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppurIndentsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TranTypeID",SqlDbType.NVarChar,3, IIf(TranTypeID Is Nothing, String.Empty,TranTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID",SqlDbType.Int,10, IIf(StatusID = Nothing, 0,StatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy",SqlDbType.NVarChar,8, IIf(CreatedBy Is Nothing, String.Empty,CreatedBy))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID",SqlDbType.NVarChar,8, IIf(EmployeeID Is Nothing, String.Empty,EmployeeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DepartmentID",SqlDbType.NVarChar,6, IIf(DepartmentID Is Nothing, String.Empty,DepartmentID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DivisionID",SqlDbType.NVarChar,6, IIf(DivisionID Is Nothing, String.Empty,DivisionID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purIndents)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purIndents(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function purIndentsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TranTypeID As String, ByVal StatusID As Int32, ByVal CreatedBy As String, ByVal EmployeeID As String, ByVal DepartmentID As String, ByVal ProjectID As String, ByVal DivisionID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function purIndentsGetByID(ByVal IndentNo As Int32, ByVal Filter_TranTypeID As String, ByVal Filter_StatusID As Int32, ByVal Filter_CreatedBy As String, ByVal Filter_EmployeeID As String, ByVal Filter_DepartmentID As String, ByVal Filter_ProjectID As String, ByVal Filter_DivisionID As String) As SIS.PUR.purIndents
      Return purIndentsGetByID(IndentNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function purIndentsInsert(ByVal Record As SIS.PUR.purIndents) As SIS.PUR.purIndents
      Dim _Rec As SIS.PUR.purIndents = SIS.PUR.purIndents.purIndentsGetNewRecord()
      With _Rec
        .IndentDate = Now
        .TranTypeID = Record.TranTypeID
        .StatusID = enumIndentStates.Free
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .ApprovedBy = Record.ApprovedBy
        .ApprovedOn = Record.ApprovedOn
        .InsuranceDetails = Record.InsuranceDetails
        .ModeOfDispatch = Record.ModeOfDispatch
        .CurrencyID = Record.CurrencyID
        .IsgecGSTIN = Record.IsgecGSTIN
        .CostCenterID = Record.CostCenterID
        .ConversionFactorINR = Record.ConversionFactorINR
        .WarrantyDetails = Record.WarrantyDetails
        .EmployeeID = Record.EmployeeID
        .DepartmentID = Record.DepartmentID
        .IndenterRemarks = Record.IndenterRemarks
        .ProjectID = Record.ProjectID
        .DivisionID = Record.DivisionID
        .ElementID = Record.ElementID
        .ApproverRemarks = Record.ApproverRemarks
        .PaymentTerms = Record.PaymentTerms
        .DeliveryTerms = Record.DeliveryTerms
        .DestinationAddress = Record.DestinationAddress
        .IsgecGSTINAddress = Record.IsgecGSTINAddress
        .DeliveryDate = Record.DeliveryDate
        .ShipToState = Record.ShipToState
      End With
      Return SIS.PUR.purIndents.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PUR.purIndents) As SIS.PUR.purIndents
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurIndentsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentDate",SqlDbType.DateTime,21, Iif(Record.IndentDate= "" ,Convert.DBNull, Record.IndentDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranTypeID",SqlDbType.NVarChar,4, Iif(Record.TranTypeID= "" ,Convert.DBNull, Record.TranTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InsuranceDetails",SqlDbType.NVarChar,201, Iif(Record.InsuranceDetails= "" ,Convert.DBNull, Record.InsuranceDetails))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeOfDispatch",SqlDbType.NVarChar,51, Iif(Record.ModeOfDispatch= "" ,Convert.DBNull, Record.ModeOfDispatch))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,11, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTIN",SqlDbType.Int,11, Iif(Record.IsgecGSTIN= "" ,Convert.DBNull, Record.IsgecGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,25, Iif(Record.ConversionFactorINR= "" ,Convert.DBNull, Record.ConversionFactorINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WarrantyDetails",SqlDbType.NVarChar,1001, Iif(Record.WarrantyDetails= "" ,Convert.DBNull, Record.WarrantyDetails))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Iif(Record.EmployeeID= "" ,Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Iif(Record.DepartmentID= "" ,Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterRemarks",SqlDbType.NVarChar,501, Iif(Record.IndenterRemarks= "" ,Convert.DBNull, Record.IndenterRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,201, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentTerms",SqlDbType.NVarChar,501, Iif(Record.PaymentTerms= "" ,Convert.DBNull, Record.PaymentTerms))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryTerms",SqlDbType.NVarChar,501, Iif(Record.DeliveryTerms= "" ,Convert.DBNull, Record.DeliveryTerms))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DestinationAddress",SqlDbType.NVarChar,501, Iif(Record.DestinationAddress= "" ,Convert.DBNull, Record.DestinationAddress))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTINAddress",SqlDbType.NVarChar,501, Iif(Record.IsgecGSTINAddress= "" ,Convert.DBNull, Record.IsgecGSTINAddress))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryDate",SqlDbType.DateTime,21, Iif(Record.DeliveryDate= "" ,Convert.DBNull, Record.DeliveryDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerID", SqlDbType.NVarChar, 9, IIf(Record.BuyerID = "", Convert.DBNull, Record.BuyerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerRemarks", SqlDbType.NVarChar, 201, IIf(Record.BuyerRemarks = "", Convert.DBNull, Record.BuyerRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerActionOn", SqlDbType.DateTime, 21, IIf(Record.BuyerActionOn = "", Convert.DBNull, Record.BuyerActionOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShipToState", SqlDbType.NVarChar, 3, IIf(Record.ShipToState = "", Convert.DBNull, Record.ShipToState))
          Cmd.Parameters.Add("@Return_IndentNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_IndentNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.IndentNo = Cmd.Parameters("@Return_IndentNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function purIndentsUpdate(ByVal Record As SIS.PUR.purIndents) As SIS.PUR.purIndents
      Dim _Rec As SIS.PUR.purIndents = SIS.PUR.purIndents.purIndentsGetByID(Record.IndentNo)
      With _Rec
        .IndentDate = Record.IndentDate
        .TranTypeID = Record.TranTypeID
        .StatusID = enumIndentStates.Free
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .ApprovedBy = Record.ApprovedBy
        .ApprovedOn = Record.ApprovedOn
        .InsuranceDetails = Record.InsuranceDetails
        .ModeOfDispatch = Record.ModeOfDispatch
        .CurrencyID = Record.CurrencyID
        .IsgecGSTIN = Record.IsgecGSTIN
        .CostCenterID = Record.CostCenterID
        .ConversionFactorINR = Record.ConversionFactorINR
        .WarrantyDetails = Record.WarrantyDetails
        .EmployeeID = Record.EmployeeID
        .DepartmentID = Record.DepartmentID
        .IndenterRemarks = Record.IndenterRemarks
        .ProjectID = Record.ProjectID
        .DivisionID = Record.DivisionID
        .ElementID = Record.ElementID
        .ApproverRemarks = Record.ApproverRemarks
        .PaymentTerms = Record.PaymentTerms
        .DeliveryTerms = Record.DeliveryTerms
        .DestinationAddress = Record.DestinationAddress
        .IsgecGSTINAddress = Record.IsgecGSTINAddress
        .DeliveryDate = Record.DeliveryDate
        .ShipToState = Record.ShipToState
      End With
      Return SIS.PUR.purIndents.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PUR.purIndents) As SIS.PUR.purIndents
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurIndentsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IndentNo",SqlDbType.Int,11, Record.IndentNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentDate",SqlDbType.DateTime,21, Iif(Record.IndentDate= "" ,Convert.DBNull, Record.IndentDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranTypeID",SqlDbType.NVarChar,4, Iif(Record.TranTypeID= "" ,Convert.DBNull, Record.TranTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InsuranceDetails",SqlDbType.NVarChar,201, Iif(Record.InsuranceDetails= "" ,Convert.DBNull, Record.InsuranceDetails))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeOfDispatch",SqlDbType.NVarChar,51, Iif(Record.ModeOfDispatch= "" ,Convert.DBNull, Record.ModeOfDispatch))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,11, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTIN",SqlDbType.Int,11, Iif(Record.IsgecGSTIN= "" ,Convert.DBNull, Record.IsgecGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,25, Iif(Record.ConversionFactorINR= "" ,Convert.DBNull, Record.ConversionFactorINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WarrantyDetails",SqlDbType.NVarChar,1001, Iif(Record.WarrantyDetails= "" ,Convert.DBNull, Record.WarrantyDetails))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Iif(Record.EmployeeID= "" ,Convert.DBNull, Record.EmployeeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Iif(Record.DepartmentID= "" ,Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterRemarks",SqlDbType.NVarChar,501, Iif(Record.IndenterRemarks= "" ,Convert.DBNull, Record.IndenterRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,201, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentTerms",SqlDbType.NVarChar,501, Iif(Record.PaymentTerms= "" ,Convert.DBNull, Record.PaymentTerms))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryTerms",SqlDbType.NVarChar,501, Iif(Record.DeliveryTerms= "" ,Convert.DBNull, Record.DeliveryTerms))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DestinationAddress",SqlDbType.NVarChar,501, Iif(Record.DestinationAddress= "" ,Convert.DBNull, Record.DestinationAddress))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTINAddress",SqlDbType.NVarChar,501, Iif(Record.IsgecGSTINAddress= "" ,Convert.DBNull, Record.IsgecGSTINAddress))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryDate",SqlDbType.DateTime,21, Iif(Record.DeliveryDate= "" ,Convert.DBNull, Record.DeliveryDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerID", SqlDbType.NVarChar, 9, IIf(Record.BuyerID = "", Convert.DBNull, Record.BuyerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerRemarks", SqlDbType.NVarChar, 201, IIf(Record.BuyerRemarks = "", Convert.DBNull, Record.BuyerRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerActionOn", SqlDbType.DateTime, 21, IIf(Record.BuyerActionOn = "", Convert.DBNull, Record.BuyerActionOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShipToState", SqlDbType.NVarChar, 3, IIf(Record.ShipToState = "", Convert.DBNull, Record.ShipToState))
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
    Public Shared Function purIndentsDelete(ByVal Record As SIS.PUR.purIndents) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurIndentsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IndentNo",SqlDbType.Int,Record.IndentNo.ToString.Length, Record.IndentNo)
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
    Public Shared Function SelectpurIndentsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppurIndentsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(500, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PUR.purIndents = New SIS.PUR.purIndents(Reader)
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
