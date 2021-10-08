Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purOrders
    Public ReadOnly Property GetConvertLink() As String
      Get
        Return "lgMessageBox.ExecuteURL('Convert to Receipt', '../App_Controls/AF_ctlReceipts.aspx?OrderNo=" & OrderNo & "&OrderRev=" & OrderRev & "'); return false;"
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case StatusID
        Case enumOrderStates.UnderApproval
          mRet = Drawing.Color.Blue
        Case enumOrderStates.Approved
          mRet = Drawing.Color.DarkGoldenrod
        Case enumOrderStates.IssuedToVendor
          mRet = Drawing.Color.Green
        Case enumOrderStates.PartiallyReceived
          mRet = Drawing.Color.Purple
        Case enumOrderStates.MaterialReceived
          mRet = Drawing.Color.CadetBlue
        Case enumOrderStates.Returned
          mRet = Drawing.Color.Red
        Case enumOrderStates.EnquiryFloated
          mRet = Drawing.Color.DarkMagenta
        Case enumOrderStates.Cancelled
          mRet = Drawing.Color.RosyBrown
        Case enumOrderStates.Superseded
          mRet = Drawing.Color.DarkKhaki
      End Select
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case enumOrderStates.Free, enumOrderStates.Returned
          mRet = True
      End Select
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = GetEditable()
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ReviseWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumOrderStates.Approved, enumOrderStates.IssuedToVendor, enumOrderStates.PartiallyReceived
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property IssueWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case enumOrderStates.Approved
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ReviseWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function ReviseWF(ByVal OrderNo As Int32, ByVal OrderRev As Int32) As SIS.PUR.purOrders
      CreateHistory(OrderNo, OrderRev)
      Dim nRev As Integer = OrderRev + 1
      Dim cO As SIS.PUR.purOrders = SIS.PUR.purOrders.purOrdersGetByID(OrderNo, OrderRev)
      With cO
        .StatusID = enumOrderStates.Superseded
      End With
      SIS.PUR.purOrders.UpdateData(cO)
      With cO
        .RevisedBy = HttpContext.Current.Session("LoginID")
        .RevisedOn = Now
        .StatusID = enumOrderStates.Free
        .OrderRev = nRev
      End With
      SIS.PUR.purOrders.InsertData(cO)
      Dim cODs As List(Of SIS.PUR.purOrderDetails) = SIS.PUR.purOrderDetails.purOrderDetailsSelectList(0, 9999, "", False, "", OrderRev, OrderNo)
      For Each cOD As SIS.PUR.purOrderDetails In cODs
        cOD.OrderRev = nRev
        SIS.PUR.purOrderDetails.InsertData(cOD)
        Dim cPs As List(Of SIS.PUR.purOrderItemProperty) = SIS.PUR.purOrderItemProperty.purOrderItemPropertySelectList(0, 9999, "", False, "", cOD.OrderLine, OrderNo, OrderRev)
        For Each cP As SIS.PUR.purOrderItemProperty In cPs
          cP.OrderRev = nRev
          SIS.PUR.purOrderItemProperty.InsertData(cP)
        Next
      Next
      Return cO
    End Function
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal OrderNo As Int32, ByVal OrderRev As Int32) As SIS.PUR.purOrders
      Dim Results As SIS.PUR.purOrders = purOrdersGetByID(OrderNo, OrderRev)
      '========================
      UZ_purOrdersDelete(Results)
      '========================
      Return Results
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property OrderAmount As Decimal
      Get
        Dim mRet As Decimal = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "select isnull(sum(TotalAmountINR),0) as tamt from pur_OrderDetails where MainLine=1 And OrderNo=" & OrderNo & " and OrderRev=" & OrderRev
            Con.Open()
            mRet = Cmd.ExecuteScalar
          End Using
        End Using
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal OrderNo As Int32, ByVal OrderRev As Int32) As SIS.PUR.purOrders
      Dim Results As SIS.PUR.purOrders = purOrdersGetByID(OrderNo, OrderRev)
      If Results.AprTypeID = "" Then Throw New Exception("Approval type not selected.")
      If Results.OrderAmount <= 0 Then Throw New Exception("Total Order Amount is ZERO, Pl. check.")
      With Results
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .StatusID = enumOrderStates.UnderApproval
      End With
      SIS.PUR.purOrders.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function IssueWF(ByVal OrderNo As Int32, ByVal OrderRev As Int32) As SIS.PUR.purOrders
      Dim Results As SIS.PUR.purOrders = purOrdersGetByID(OrderNo, OrderRev)
      With Results
        .IssuedBy = HttpContext.Current.Session("LoginID")
        .IssuedOn = Now
        .StatusID = enumOrderStates.IssuedToVendor
      End With
      SIS.PUR.purOrders.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_purOrdersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PurchaseTypeID As String, ByVal TranTypeID As String, ByVal SupplierID As String, ByVal AprTypeID As String, ByVal EmployeeID As String, ByVal ApprovedBy As String, ByVal CreatedBy As String, ByVal StatusID As Int32) As List(Of SIS.PUR.purOrders)
      Dim Results As List(Of SIS.PUR.purOrders) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "OrderNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppur_LG_OrdersSelectListSearch"
            Cmd.CommandText = "sppurOrdersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppur_LG_OrdersSelectListFilteres"
            Cmd.CommandText = "sppurOrdersSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PurchaseTypeID", SqlDbType.NVarChar, 100, IIf(PurchaseTypeID Is Nothing, String.Empty, PurchaseTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TranTypeID", SqlDbType.NVarChar, 3, IIf(TranTypeID Is Nothing, String.Empty, TranTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID", SqlDbType.NVarChar, 9, IIf(SupplierID Is Nothing, String.Empty, SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_AprTypeID", SqlDbType.NVarChar, 10, IIf(AprTypeID Is Nothing, String.Empty, AprTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID", SqlDbType.NVarChar, 8, IIf(EmployeeID Is Nothing, String.Empty, EmployeeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ApprovedBy", SqlDbType.NVarChar, 8, IIf(ApprovedBy Is Nothing, String.Empty, ApprovedBy))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy", SqlDbType.NVarChar, 8, IIf(CreatedBy Is Nothing, String.Empty, CreatedBy))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID", SqlDbType.Int, 10, IIf(StatusID = Nothing, 0, StatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purOrders)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purOrders(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_purOrdersInsert(ByVal Record As SIS.PUR.purOrders) As SIS.PUR.purOrders
      Dim _Result As SIS.PUR.purOrders = purOrdersInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_purOrdersUpdate(ByVal Record As SIS.PUR.purOrders) As SIS.PUR.purOrders
      Dim _Result As SIS.PUR.purOrders = purOrdersUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_purOrdersDelete(ByVal Record As SIS.PUR.purOrders) As Integer
      Dim CanBeDeleted As Boolean = True
      Dim OrderLines As List(Of SIS.PUR.purOrderDetails) = SIS.PUR.purOrderDetails.purOrderDetailsSelectList(0, 9999, "", False, "", Record.OrderRev, Record.OrderNo)
      For Each OL As SIS.PUR.purOrderDetails In OrderLines
        Try
          SIS.PUR.purOrderDetails.DeleteWF(OL.OrderNo, OL.OrderLine, OL.OrderRev)
        Catch ex As Exception
          CanBeDeleted = False
        End Try
      Next
      If CanBeDeleted Then
        purOrdersDelete(Record)
      Else
        Throw New Exception("All order lines cannot be deleted.")
      End If
      Return Nothing
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      Dim oI As SIS.PUR.purIndents = Nothing
      If HttpContext.Current.Request.QueryString("IndentNo") IsNot Nothing Then
        oI = SIS.PUR.purIndents.purIndentsGetByID(HttpContext.Current.Request.QueryString("IndentNo"))
      End If
      If oI Is Nothing Then
        oI = New SIS.PUR.purIndents
        oI.CurrencyID = "INR"
        oI.ConversionFactorINR = "1.000000"
      End If
      With sender
        Try
          CType(.FindControl("F_OrderNo"), TextBox).Text = "0"
          CType(.FindControl("F_OrderRev"), TextBox).Text = 0
          CType(.FindControl("F_PurchaseTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_TranTypeID"), Object).SelectedValue = oI.TranTypeID
          CType(.FindControl("F_IsgecGSTIN"), Object).SelectedValue = oI.IsgecGSTIN
          CType(.FindControl("F_IsgecGSTINAddress"), TextBox).Text = oI.IsgecGSTINAddress
          CType(.FindControl("F_DestinationAddress"), TextBox).Text = oI.DestinationAddress
          CType(.FindControl("F_SupplierID"), TextBox).Text = ""
          CType(.FindControl("F_SupplierID_Display"), Label).Text = ""
          CType(.FindControl("F_SupplierGSTIN"), TextBox).Text = ""
          CType(.FindControl("F_SupplierGSTIN_Display"), Label).Text = ""
          CType(.FindControl("F_SupplierName"), TextBox).Text = ""
          CType(.FindControl("F_SupplierGSTINUMBER"), TextBox).Text = ""
          CType(.FindControl("F_PaymentTerms"), TextBox).Text = oI.PaymentTerms
          CType(.FindControl("F_DeliveryTerms"), TextBox).Text = oI.DeliveryTerms
          CType(.FindControl("F_InsuranceDetails"), TextBox).Text = oI.InsuranceDetails
          CType(.FindControl("F_WarrantyDetails"), TextBox).Text = oI.WarrantyDetails
          CType(.FindControl("F_ModeOfDispatch"), TextBox).Text = oI.ModeOfDispatch
          CType(.FindControl("F_DeliveryDate"), TextBox).Text = oI.DeliveryDate
          CType(.FindControl("F_CurrencyID"), Object).SelectedValue = oI.CurrencyID
          CType(.FindControl("F_ConversionFactorINR"), TextBox).Text = oI.ConversionFactorINR
          CType(.FindControl("F_QuatationNo"), TextBox).Text = ""
          CType(.FindControl("F_QuotationDate"), TextBox).Text = ""
          CType(.FindControl("F_AprTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_BuyerRemarks"), TextBox).Text = ""
          CType(.FindControl("F_ProjectID"), TextBox).Text = oI.ProjectID
          CType(.FindControl("F_ProjectID_Display"), Label).Text = oI.IDM_Projects6_Description
          CType(.FindControl("F_ElementID"), TextBox).Text = oI.ElementID
          CType(.FindControl("F_ElementID_Display"), Label).Text = oI.IDM_WBS7_Description
          CType(.FindControl("F_EmployeeID"), TextBox).Text = oI.EmployeeID
          CType(.FindControl("F_EmployeeID_Display"), Label).Text = oI.HRM_Employees5_EmployeeName
          CType(.FindControl("F_DepartmentID"), TextBox).Text = oI.DepartmentID
          CType(.FindControl("F_DepartmentID_Display"), Label).Text = oI.HRM_Departments3_Description
          CType(.FindControl("F_CostCenterID"), TextBox).Text = oI.CostCenterID
          CType(.FindControl("F_CostCenterID_Display"), Label).Text = oI.SPMT_CostCenters10_Description
          CType(.FindControl("F_DivisionID"), TextBox).Text = oI.DivisionID
          CType(.FindControl("F_DivisionID_Display"), Label).Text = oI.HRM_Divisions4_Description
          CType(.FindControl("F_OrderText"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetForHistory(OrderNo As Integer, OrderRev As Integer) As SIS.PUR.purHOrders
      Dim mRet As SIS.PUR.purHOrders = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from pur_Orders where OrderNo=" & OrderNo & " and OrderRev=" & OrderRev
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            mRet = New SIS.PUR.purHOrders(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Sub CreateHistory(OrderNo As Integer, OrderRev As Integer)
      Dim cO As SIS.PUR.purHOrders = SIS.PUR.purOrders.GetForHistory(OrderNo, OrderRev)
      SIS.PUR.purHOrders.InsertData(cO)
      Dim cODs As List(Of SIS.PUR.purHOrderDetails) = SIS.PUR.purOrderDetails.GetForHistory(OrderNo, OrderRev)
      For Each cOD As SIS.PUR.purHOrderDetails In cODs
        SIS.PUR.purHOrderDetails.InsertData(cOD)
        Dim cPs As List(Of SIS.PUR.purHOrderItemProperty) = SIS.PUR.purOrderItemProperty.GetForHistory(OrderNo, OrderRev, cOD.OrderLine)
        For Each cP As SIS.PUR.purHOrderItemProperty In cPs
          SIS.PUR.purHOrderItemProperty.InsertData(cP)
        Next
      Next
    End Sub
    Public Shared Sub UpdateStatus(OrderNo As Integer, OrderRev As Integer)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Dim sQty As Decimal = 0
        Dim sRecQty As Decimal = 0
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = " select sum(Quantity) as sQty, sum(ReceivedQuantity) as sRecQty from PUR_OrderDetails where MainLine=1 and OrderNo=" & OrderNo & " and OrderRev=" & OrderRev
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            sQty = Reader("sQty")
            sRecQty = Reader("sRecQty")
          End While
          Reader.Close()
        End Using
        Dim Status As Integer = enumOrderStates.IssuedToVendor
        If sRecQty > 0 Then
          Status = enumOrderStates.PartiallyReceived
        End If
        If sRecQty = sQty Then
          Status = enumOrderStates.MaterialReceived
        End If
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = " update PUR_Orders set StatusID=" & Status & " where OrderNo=" & OrderNo & " and OrderRev=" & OrderRev
          Cmd.ExecuteNonQuery()
        End Using
      End Using
    End Sub
  End Class
End Namespace
