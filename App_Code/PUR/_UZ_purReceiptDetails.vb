Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purReceiptDetails
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
      Dim mRet As Boolean = FK_PUR_ReceiptDetails_ReceiptNo.Editable
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
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
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
    Public Shared Function DeleteWF(ByVal ReceiptNo As Int32, ByVal ReceiptLine As Int32) As SIS.PUR.purReceiptDetails
      Dim Results As SIS.PUR.purReceiptDetails = purReceiptDetailsGetByID(ReceiptNo, ReceiptLine)
      If Results.IRLine <> "" Then
        Throw New Exception("IR Created, cannot delete.")
      End If
      If Results.FromOrder Then
        SIS.PUR.purOrderDetails.ReceiptLineDeleted(Results)
      End If
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Con.Open()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "  DELETE PUR_ReceiptItemProperty where ReceiptNo=" & ReceiptNo & " and ReceiptLine=" & ReceiptLine
          Cmd.CommandText &= " DELETE PUR_ReceiptDetails where ReceiptNo=" & ReceiptNo & " and ReceiptLine=" & ReceiptLine & " and ParentLine=" & ReceiptLine
          Cmd.CommandText &= " DELETE PUR_ReceiptDetails where ReceiptNo=" & ReceiptNo & " and ReceiptLine=" & ReceiptLine
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_purReceiptDetailsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ReceiptNo As Int32) As List(Of SIS.PUR.purReceiptDetails)
      Dim Results As List(Of SIS.PUR.purReceiptDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppur_LG_ReceiptDetailsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppur_LG_ReceiptDetailsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ReceiptNo", SqlDbType.Int, 10, IIf(ReceiptNo = Nothing, 0, ReceiptNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PUR.purReceiptDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purReceiptDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_purReceiptDetailsInsert(ByVal Record As SIS.PUR.purReceiptDetails) As SIS.PUR.purReceiptDetails
      Dim _Result As SIS.PUR.purReceiptDetails = purReceiptDetailsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_purReceiptDetailsUpdate(ByVal Record As SIS.PUR.purReceiptDetails) As SIS.PUR.purReceiptDetails
      Dim _Result As SIS.PUR.purReceiptDetails = purReceiptDetailsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_purReceiptDetailsDelete(ByVal Record As SIS.PUR.purReceiptDetails) As Integer
      Dim _Result as Integer = purReceiptDetailsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          Dim x As SIS.PUR.purReceipts = SIS.PUR.purReceipts.purReceiptsGetByID(HttpContext.Current.Request.QueryString("ReceiptNo"))
          CType(.FindControl("F_ReceiptNo"), TextBox).Text = ""
          CType(.FindControl("F_ReceiptNo_Display"), Label).Text = ""
          CType(.FindControl("F_ReceiptLine"), TextBox).Text = ""
          CType(.FindControl("F_TranTypeID"), Object).SelectedValue = x.TranTypeID
          CType(.FindControl("F_BillType"), Object).SelectedValue = ""
          CType(.FindControl("F_HSNSACCode"), TextBox).Text = ""
          CType(.FindControl("F_HSNSACCode_Display"), Label).Text = ""
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
          CType(.FindControl("F_ProjectID"), TextBox).Text = x.ProjectID
          CType(.FindControl("F_ProjectID_Display"), Label).Text = x.IDM_Projects9_Description
          CType(.FindControl("F_ElementID"), TextBox).Text = x.ElementID
          CType(.FindControl("F_ElementID_Display"), Label).Text = x.IDM_WBS10_Description
          CType(.FindControl("F_EmployeeID"), TextBox).Text = x.EmployeeID
          CType(.FindControl("F_EmployeeID_Display"), Label).Text = x.HRM_Employees8_EmployeeName
          CType(.FindControl("F_DepartmentID"), TextBox).Text = x.DepartmentID
          CType(.FindControl("F_DepartmentID_Display"), Label).Text = x.HRM_Departments6_Description
          CType(.FindControl("F_CostCenterID"), TextBox).Text = x.CostCenterID
          CType(.FindControl("F_CostCenterID_Display"), Label).Text = x.SPMT_CostCenters14_Description
          CType(.FindControl("F_DivisionID"), TextBox).Text = x.DivisionID
          CType(.FindControl("F_DivisionID_Display"), Label).Text = x.HRM_Divisions7_Description
          CType(.FindControl("F_Amount"), TextBox).Text = "0.0000"
          CType(.FindControl("F_TotalGST"), TextBox).Text = "0.0000"
          CType(.FindControl("F_TaxAmount"), TextBox).Text = "0.0000"
          CType(.FindControl("F_TotalAmount"), TextBox).Text = "0.0000"
          CType(.FindControl("F_TotalAmountINR"), TextBox).Text = "0.0000"
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function CalculateAmounts(oID As SIS.PUR.purReceiptDetails) As SIS.PUR.purReceiptDetails
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
    Public Shared Function GetSBD(ByVal Record As SIS.PUR.purReceiptDetails) As SIS.SPMT.SpmtNewSBD
      Dim Rec As New SIS.SPMT.SpmtNewSBD
      With Rec
        .IRNo = Record.IRNo
        .ItemDescription = Record.ItemDescription
        .BillType = Record.BillType
        .HSNSACCode = Record.HSNSACCode
        .UOM = Record.UOM
        .Quantity = Record.Quantity
        .Currency = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .BasicValue = Record.Amount
        .Discount = ""
        .ServiceCharge = ""
        .AssessableValue = Record.AssessableValue
        .IGSTRate = Record.IGSTrate
        .IGSTAmount = Record.IGSTAmount
        .SGSTRate = Record.SGSTRate
        .SGSTAmount = Record.SGSTAmount
        .CGSTRate = Record.CGSTRate
        .CGSTAmount = Record.CGSTAmount
        .CessRate = Record.CESSRate
        .CessAmount = Record.CESSAmount
        .TotalGST = Record.TotalGST
        .TotalAmount = Record.TotalAmount
        .TotalGSTINR = Record.TaxAmount
        .TotalAmountINR = Record.TotalAmountINR
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .EmployeeID = Record.EmployeeID
        .DepartmentID = Record.DepartmentID
        .CostCenterID = Record.CostCenterID
        .UploadBatchNo = ""
        .TCSRate = Record.TCSRate
        .TCSAmount = Record.TCSAmount
        '===========================
        .OrderNo = Record.ReceiptNo
        .POLine = Record.ReceiptLine
        '===========================
      End With
      Return Rec
    End Function
  End Class
End Namespace
