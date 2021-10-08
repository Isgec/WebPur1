Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purOrderDetails
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
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
      Dim mRet As Boolean = FK_PUR_OrderDetails_OrderNo.GetEditable
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = FK_PUR_OrderDetails_OrderNo.GetDeleteable
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
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = FK_PUR_OrderDetails_OrderNo.DeleteWFVisible
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
    Public Shared Function DeleteWF(ByVal OrderNo As Int32, ByVal OrderLine As Int32, ByVal OrderRev As Int32) As SIS.PUR.purOrderDetails
      Dim Results As SIS.PUR.purOrderDetails = purOrderDetailsGetByID(OrderNo, OrderLine, OrderRev)
      If Convert.ToDecimal(Results.ReceivedQuantity) > 0 Then
        Throw New Exception("Material Receipt is created, cannot delete.")
      End If
      If Results.FromIndent Then
        SIS.PUR.purIndentDetails.OrderLineDeleted(Results)
      End If
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Con.Open()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "  DELETE PUR_OrderItemProperty where OrderNo=" & OrderNo & " and OrderLine=" & OrderLine & " and OrderRev=" & OrderRev
          Cmd.CommandText &= " DELETE PUR_OrderDetails where OrderNo=" & OrderNo & " and OrderRev=" & OrderRev & " and ParentLine=" & OrderLine
          Cmd.CommandText &= " DELETE PUR_OrderDetails where OrderNo=" & OrderNo & " and OrderLine=" & OrderLine & " and OrderRev=" & OrderRev
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_purOrderDetailsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal OrderRev As Int32, ByVal OrderNo As Int32) As List(Of SIS.PUR.purOrderDetails)
      Dim Results As List(Of SIS.PUR.purOrderDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppur_LG_OrderDetailsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppur_LG_OrderDetailsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_OrderRev", SqlDbType.Int, 10, IIf(OrderRev = Nothing, 0, OrderRev))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_OrderNo",SqlDbType.Int,10, IIf(OrderNo = Nothing, 0,OrderNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purOrderDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purOrderDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_purOrderDetailsInsert(ByVal Record As SIS.PUR.purOrderDetails) As SIS.PUR.purOrderDetails
      Dim _Result As SIS.PUR.purOrderDetails = purOrderDetailsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_purOrderDetailsUpdate(ByVal Record As SIS.PUR.purOrderDetails) As SIS.PUR.purOrderDetails
      Dim _Result As SIS.PUR.purOrderDetails = purOrderDetailsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_purOrderDetailsDelete(ByVal Record As SIS.PUR.purOrderDetails) As Integer
      DeleteWF(Record.OrderNo, Record.OrderLine, Record.OrderRev)
      Return 0
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          Dim x As SIS.PUR.purOrders = SIS.PUR.purOrders.purOrdersGetByID(HttpContext.Current.Request.QueryString("OrderNo"), HttpContext.Current.Request.QueryString("OrderRev"))
          CType(.FindControl("F_OrderNo"), TextBox).Text = ""
          CType(.FindControl("F_OrderNo_Display"), Label).Text = ""
          CType(.FindControl("F_OrderRev"), TextBox).Text = 0
          CType(.FindControl("F_OrderLine"), TextBox).Text = ""
          CType(.FindControl("F_ItemCode"), TextBox).Text = ""
          CType(.FindControl("F_ItemCode_Display"), Label).Text = ""
          CType(.FindControl("F_UOM"), TextBox).Text = ""
          CType(.FindControl("F_ItemDescription"), TextBox).Text = ""
          CType(.FindControl("F_Quantity"), TextBox).Text = "0.0000"
          CType(.FindControl("F_Price"), TextBox).Text = "0.0000"
          CType(.FindControl("F_AssessableValue"), TextBox).Text = "0.0000"
          CType(.FindControl("F_TaxCode"), Object).SelectedValue = ""
          CType(.FindControl("F_CGSTRate"), TextBox).Text = "0.0000"
          CType(.FindControl("F_CGSTAmount"), TextBox).Text = "0.0000"
          CType(.FindControl("F_SGSTRate"), TextBox).Text = "0.0000"
          CType(.FindControl("F_SGSTAmount"), TextBox).Text = "0.0000"
          CType(.FindControl("F_IGSTrate"), TextBox).Text = "0.0000"
          CType(.FindControl("F_IGSTAmount"), TextBox).Text = "0.0000"
          CType(.FindControl("F_CESSRate"), TextBox).Text = "0.0000"
          CType(.FindControl("F_CESSAmount"), TextBox).Text = "0.0000"
          CType(.FindControl("F_TCSRate"), TextBox).Text = "0.0000"
          CType(.FindControl("F_TCSAmount"), TextBox).Text = "0.0000"
          CType(.FindControl("F_CurrencyID"), Object).SelectedValue = x.CurrencyID
          CType(.FindControl("F_ConversionFactorINR"), TextBox).Text = x.ConversionFactorINR
          CType(.FindControl("F_Amount"), TextBox).Text = "0.0000"
          CType(.FindControl("F_TotalGST"), TextBox).Text = "0.0000"
          CType(.FindControl("F_TaxAmount"), TextBox).Text = "0.0000"
          CType(.FindControl("F_TotalAmount"), TextBox).Text = "0.0000"
          CType(.FindControl("F_TotalAmountINR"), TextBox).Text = "0.0000"
          CType(.FindControl("F_TranTypeID"), Object).SelectedValue = x.TranTypeID
          CType(.FindControl("F_BillType"), Object).SelectedValue = ""
          CType(.FindControl("F_HSNSACCode"), TextBox).Text = ""
          CType(.FindControl("F_HSNSACCode_Display"), Label).Text = ""
          CType(.FindControl("F_DeliveryDate"), TextBox).Text = x.DeliveryDate
          CType(.FindControl("F_ProjectID"), TextBox).Text = x.ProjectID
          CType(.FindControl("F_ProjectID_Display"), Label).Text = x.IDM_Projects6_Description
          CType(.FindControl("F_ElementID"), TextBox).Text = x.ElementID
          CType(.FindControl("F_ElementID_Display"), Label).Text = x.IDM_WBS7_Description
          CType(.FindControl("F_EmployeeID"), TextBox).Text = x.EmployeeID
          CType(.FindControl("F_EmployeeID_Display"), Label).Text = x.HRM_Employees5_EmployeeName
          CType(.FindControl("F_DepartmentID"), TextBox).Text = x.DepartmentID
          CType(.FindControl("F_DepartmentID_Display"), Label).Text = x.HRM_Departments3_Description
          CType(.FindControl("F_CostCenterID"), TextBox).Text = x.CostCenterID
          CType(.FindControl("F_CostCenterID_Display"), Label).Text = x.SPMT_CostCenters12_Description
          CType(.FindControl("F_DivisionID"), TextBox).Text = x.DivisionID
          CType(.FindControl("F_DivisionID_Display"), Label).Text = x.HRM_Divisions4_Description
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function CalculateAmounts(oOD As SIS.PUR.purOrderDetails) As SIS.PUR.purOrderDetails
      Dim parseFloat = Function(x As String) Convert.ToDecimal(x)
      With oOD
        .Amount = (parseFloat(.Quantity) * parseFloat(.Price))
        .AssessableValue = .Amount
        If (parseFloat(.CESSRate) > 0) Then .CESSAmount = (parseFloat(.CESSRate) * parseFloat(.AssessableValue) * 0.01)
        If (parseFloat(.IGSTrate) > 0) Then .IGSTAmount = (parseFloat(.IGSTrate) * parseFloat(.AssessableValue) * 0.01)
        If (parseFloat(.SGSTRate) > 0) Then .SGSTAmount = (parseFloat(.SGSTRate) * parseFloat(.AssessableValue) * 0.01)
        If (parseFloat(.CGSTRate) > 0) Then .CGSTAmount = (parseFloat(.CGSTRate) * parseFloat(.AssessableValue) * 0.01)

        .TotalGST = (parseFloat(.CESSAmount) + parseFloat(.IGSTAmount) + parseFloat(.SGSTAmount) + parseFloat(.CGSTAmount))
        .TaxAmount = (parseFloat(.TotalGST) * parseFloat(.ConversionFactorINR))

        If (parseFloat(.TCSRate) > 0) Then .TCSAmount = (parseFloat(.TCSRate) * (parseFloat(.AssessableValue) + parseFloat(.TotalGST)) * 0.01)

        .TotalAmount = (parseFloat(.AssessableValue) + parseFloat(.TotalGST) + parseFloat(.TCSAmount))
        .TotalAmountINR = (parseFloat(.TotalAmount) * parseFloat(.ConversionFactorINR))

      End With
      Return oOD
    End Function
    Public Shared Function GetForHistory(OrderNo As Integer, OrderRev As Integer) As List(Of SIS.PUR.purHOrderDetails)
      Dim mRet As New List(Of SIS.PUR.purHOrderDetails)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from pur_OrderDetails where OrderNo=" & OrderNo & " and OrderRev=" & OrderRev
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While Reader.Read()
            mRet.Add(New SIS.PUR.purHOrderDetails(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function OrderLineToReceiptLine(ByVal OrderNo As Int32, ByVal OrderLine As Int32, OrderRev As Int32, ByVal QuantityToReceipt As Decimal, ByVal ReceiptNo As Integer) As SIS.PUR.purReceiptDetails
      Dim oID As SIS.PUR.purOrderDetails = SIS.PUR.purOrderDetails.purOrderDetailsGetByID(OrderNo, OrderLine, OrderRev)
      Dim bID As SIS.PUR.purOrderDetails = SIS.PUR.purOrderDetails.purOrderDetailsGetByID(OrderNo, OrderLine, OrderRev)

      bID.MainLine = False
      bID.OrderLine = 0
      bID.Quantity = QuantityToReceipt
      bID.ReceivedQuantity = bID.Quantity
      bID.OriginalQuantity = 0
      bID.ParentLine = oID.OrderLine
      bID.ReceiptNo = ReceiptNo
      bID = SIS.PUR.purOrderDetails.CalculateAmounts(bID)
      bID = SIS.PUR.purOrderDetails.InsertData(bID)

      oID.ReceiptNo = ReceiptNo
      oID.ReceivedQuantity = Convert.ToDecimal(oID.ReceivedQuantity) + Convert.ToDecimal(bID.Quantity)
      oID.OriginalQuantity = Convert.ToDecimal(oID.Quantity) - Convert.ToDecimal(oID.ReceivedQuantity)
      oID = SIS.PUR.purOrderDetails.UpdateData(oID)

      Dim nOD As SIS.PUR.purReceiptDetails = SIS.PUR.purOrderDetails.GetAsReceiptLine(bID.OrderNo, bID.OrderLine, bID.OrderRev)
      nOD.ReceiptNo = ReceiptNo
      nOD.ReceiptLine = 0
      nOD.OriginalQuantity = nOD.Quantity
      nOD.MainLine = True
      nOD.ParentLine = ""
      nOD.FromOrder = True
      nOD = SIS.PUR.purReceiptDetails.CalculateAmounts(nOD)
      nOD = SIS.PUR.purReceiptDetails.InsertData(nOD)

      bID.ReceiptLine = nOD.ReceiptLine
      bID = SIS.PUR.purOrderDetails.UpdateData(bID)
      oID.ReceiptLine = nOD.ReceiptLine
      oID = SIS.PUR.purOrderDetails.UpdateData(oID)

      SIS.PUR.purOrderItemProperty.CopyToReceipt(oID.OrderNo, oID.OrderLine, oID.OrderRev, nOD.ReceiptNo, nOD.ReceiptLine)

      SIS.PUR.purOrders.UpdateStatus(oID.OrderNo, oID.OrderRev)

      Return nOD
    End Function
    Public Shared Function GetAsReceiptLine(ByVal OrderNo As Int32, ByVal OrderLine As Int32, ByVal OrderRev As Int32) As SIS.PUR.purReceiptDetails
      Dim Results As SIS.PUR.purReceiptDetails = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from pur_OrderDetails where OrderNo=" & OrderNo & " and OrderLine=" & OrderLine & " and OrderRev=" & OrderRev
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purReceiptDetails(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function ReceiptLineDeleted(ByVal oL As SIS.PUR.purReceiptDetails) As SIS.PUR.purReceiptDetails
      Dim bID As SIS.PUR.purOrderDetails = SIS.PUR.purOrderDetails.GetByReceiptLine(oL.ReceiptNo, oL.ReceiptLine)
      If bID Is Nothing Then Return oL
      Dim oID As SIS.PUR.purOrderDetails = SIS.PUR.purOrderDetails.purOrderDetailsGetByID(bID.OrderNo, bID.ParentLine, bID.OrderRev)
      oID.ReceivedQuantity = Convert.ToDecimal(oID.ReceivedQuantity) - Convert.ToDecimal(bID.Quantity)
      oID.OriginalQuantity = Convert.ToDecimal(oID.Quantity) - Convert.ToDecimal(oID.ReceivedQuantity)
      If oID.ReceiptNo = oL.ReceiptNo AndAlso oID.ReceiptLine = oL.ReceiptLine Then
        oID.ReceiptNo = ""
        oID.ReceiptLine = ""
      End If
      oID = SIS.PUR.purOrderDetails.UpdateData(oID)
      SIS.PUR.purOrderDetails.UZ_purOrderDetailsDelete(bID)

      SIS.PUR.purOrders.UpdateStatus(oID.OrderNo, oID.OrderRev)
      Return oL
    End Function
    Public Shared Function GetByReceiptLine(ByVal ReceiptNo As Int32, ByVal ReceiptLine As Int32) As SIS.PUR.purOrderDetails
      Dim Results As SIS.PUR.purOrderDetails = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from pur_OrderDetails where MainLine=0 And ReceiptNo=" & ReceiptNo & " and ReceiptLine=" & ReceiptLine
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purOrderDetails(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
