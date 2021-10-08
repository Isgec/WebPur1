Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purIndentDetails
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
      Dim mRet As Boolean = True
      Try
        mRet = FK_PUR_IndentDetails_IndentNo.DeleteWFVisible
      Catch ex As Exception
      End Try
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      mRet = GetEditable()
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
    Public ReadOnly Property PropertyWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property PropertyWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function PropertyWF(ByVal IndentNo As Int32, ByVal IndentLine As Int32) As SIS.PUR.purIndentDetails
      Dim Results As SIS.PUR.purIndentDetails = purIndentDetailsGetByID(IndentNo, IndentLine)
      Return Results
    End Function
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
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
    Public Shared Function DeleteWF(ByVal IndentNo As Int32, ByVal IndentLine As Int32) As SIS.PUR.purIndentDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Con.Open()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "  DELETE PUR_IndentItemProperty where Indentno=" & IndentNo & " and IndentLine=" & IndentLine
          Cmd.CommandText &= " DELETE PUR_IndentDetails where Indentno=" & IndentNo & " and ParentLine=" & IndentLine
          Cmd.CommandText &= " DELETE PUR_IndentDetails where Indentno=" & IndentNo & " and IndentLine=" & IndentLine
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return Nothing
    End Function
    Public Shared Function UZ_purIndentDetailsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IndentNo As Int32) As List(Of SIS.PUR.purIndentDetails)
      Dim Results As List(Of SIS.PUR.purIndentDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppur_LG_IndentDetailsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppur_LG_IndentDetailsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IndentNo", SqlDbType.Int, 10, IIf(IndentNo = Nothing, 0, IndentNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purIndentDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purIndentDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_purIndentDetailsInsert(ByVal Record As SIS.PUR.purIndentDetails) As SIS.PUR.purIndentDetails
      Dim _Result As SIS.PUR.purIndentDetails = purIndentDetailsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_purIndentDetailsUpdate(ByVal Record As SIS.PUR.purIndentDetails) As SIS.PUR.purIndentDetails
      Dim _Result As SIS.PUR.purIndentDetails = purIndentDetailsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_purIndentDetailsDelete(ByVal Record As SIS.PUR.purIndentDetails) As Integer
      DeleteWF(Record.IndentNo, Record.IndentLine)
      Return 0
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          Dim x As SIS.PUR.purIndents = SIS.PUR.purIndents.purIndentsGetByID(HttpContext.Current.Request.QueryString("IndentNo"))
          CType(.FindControl("F_IndentNo"), TextBox).Text = ""
          CType(.FindControl("F_IndentNo_Display"), Label).Text = ""
          CType(.FindControl("F_IndentLine"), TextBox).Text = ""
          CType(.FindControl("F_ItemCode"), TextBox).Text = ""
          CType(.FindControl("F_ItemCode_Display"), Label).Text = ""
          CType(.FindControl("F_UOM"), TextBox).Text = ""
          CType(.FindControl("F_UOM_Display"), Label).Text = ""
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
          CType(.FindControl("F_CostCenterID_Display"), Label).Text = x.SPMT_CostCenters10_Description
          CType(.FindControl("F_DivisionID"), TextBox).Text = x.DivisionID
          CType(.FindControl("F_DivisionID_Display"), Label).Text = x.HRM_Divisions4_Description
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetAsOrderLine(ByVal IndentNo As Int32, ByVal IndentLine As Int32) As SIS.PUR.purOrderDetails
      Dim Results As SIS.PUR.purOrderDetails = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from pur_IndentDetails where IndentNo=" & IndentNo & " and IndentLine=" & IndentLine
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
    Public Shared Function GetByOrderLine(ByVal OrderNo As Int32, ByVal OrderLine As Int32, ByVal OrderRev As Integer) As SIS.PUR.purIndentDetails
      Dim Results As SIS.PUR.purIndentDetails = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from pur_IndentDetails where MainLine=0 And OrderNo=" & OrderNo & " and OrderLine=" & OrderLine & " and OrderRev=" & OrderRev
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purIndentDetails(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function IndentLineToOrderLine(ByVal IndentNo As Int32, ByVal IndentLine As Int32, ByVal QuantityToOrder As Decimal, ByVal OrderNo As Integer, ByVal OrderRev As Integer) As SIS.PUR.purOrderDetails
      Dim oID As SIS.PUR.purIndentDetails = SIS.PUR.purIndentDetails.purIndentDetailsGetByID(IndentNo, IndentLine)
      Dim bID As SIS.PUR.purIndentDetails = SIS.PUR.purIndentDetails.purIndentDetailsGetByID(IndentNo, IndentLine)

      bID.MainLine = False
      bID.Quantity = QuantityToOrder
      bID.OrderedQuantity = bID.Quantity
      bID.OriginalQuantity = 0
      bID.ParentLine = oID.IndentLine
      bID.OrderNo = OrderNo
      bID.OrderRev = OrderRev
      bID = SIS.PUR.purIndentDetails.CalculateAmounts(bID)
      bID = SIS.PUR.purIndentDetails.InsertData(bID)

      oID.OrderNo = OrderNo
      oID.OrderRev = OrderRev
      oID.OrderedQuantity = Convert.ToDecimal(oID.OrderedQuantity) + Convert.ToDecimal(bID.Quantity)
      oID.OriginalQuantity = Convert.ToDecimal(oID.Quantity) - Convert.ToDecimal(oID.OrderedQuantity)
      oID = SIS.PUR.purIndentDetails.UpdateData(oID)

      Dim nOD As SIS.PUR.purOrderDetails = SIS.PUR.purIndentDetails.GetAsOrderLine(bID.IndentNo, bID.IndentLine)
      nOD.OrderNo = OrderNo
      nOD.OrderRev = OrderRev
      nOD.OrderLine = 0
      nOD.OriginalQuantity = nOD.Quantity
      nOD.ReceivedQuantity = 0
      nOD.MainLine = True
      nOD.ParentLine = ""
      nOD.FromIndent = True
      nOD = SIS.PUR.purOrderDetails.CalculateAmounts(nOD)
      nOD = SIS.PUR.purOrderDetails.InsertData(nOD)

      bID.OrderLine = nOD.OrderLine
      bID = SIS.PUR.purIndentDetails.UpdateData(bID)
      oID.OrderLine = nOD.OrderLine
      oID = SIS.PUR.purIndentDetails.UpdateData(oID)

      SIS.PUR.purIndentItemProperty.CopyToOrder(oID.IndentNo, oID.IndentLine, nOD.OrderNo, nOD.OrderLine, nOD.OrderRev)

      SIS.PUR.purIndents.UpdateStatus(oID.IndentNo)

      Return nOD
    End Function
    Public Shared Function OrderLineDeleted(ByVal oL As SIS.PUR.purOrderDetails) As SIS.PUR.purOrderDetails
      Dim bID As SIS.PUR.purIndentDetails = SIS.PUR.purIndentDetails.GetByOrderLine(oL.OrderNo, oL.OrderLine, oL.OrderRev)
      If bID Is Nothing Then Return oL
      Dim oID As SIS.PUR.purIndentDetails = SIS.PUR.purIndentDetails.purIndentDetailsGetByID(bID.IndentNo, bID.ParentLine)
      oID.OrderedQuantity = Convert.ToDecimal(oID.OrderedQuantity) - Convert.ToDecimal(bID.Quantity)
      oID.OriginalQuantity = Convert.ToDecimal(oID.Quantity) - Convert.ToDecimal(oID.OrderedQuantity)
      If oID.OrderNo = oL.OrderNo AndAlso oID.OrderLine = oL.OrderLine Then
        oID.OrderNo = ""
        oID.OrderLine = ""
        oID.OrderRev = ""
      End If
      oID = SIS.PUR.purIndentDetails.UpdateData(oID)
      SIS.PUR.purIndentDetails.UZ_purIndentDetailsDelete(bID)

      SIS.PUR.purIndents.UpdateStatus(oID.IndentNo)

      Return oL
    End Function

    Public Shared Function CalculateAmounts(oID As SIS.PUR.purIndentDetails) As SIS.PUR.purIndentDetails
      Dim parseFloat = Function(x As String) Convert.ToDecimal(x)
      With oID
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
      Return oID
    End Function
  End Class
End Namespace
