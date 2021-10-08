Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purIndents
    Public ReadOnly Property GetConvertLink() As String
      Get
        Return "lgMessageBox.ExecuteURL('Convert to Purchase Order', '../App_Controls/AF_ctlOrders.aspx?IndentNo=" & IndentNo & "'); return false;"
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case StatusID
        Case enumIndentStates.UnderApproval
          mRet = Drawing.Color.Blue
        Case enumIndentStates.PendingForOrdering
          mRet = Drawing.Color.DarkGoldenrod
        Case enumIndentStates.OrderPlaced
          mRet = Drawing.Color.Green
        Case enumIndentStates.PartiallyOrdered
          mRet = Drawing.Color.Purple
        Case enumIndentStates.Returned
          mRet = Drawing.Color.Red
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
      Try
        Select Case StatusID
          Case enumIndentStates.Free, enumIndentStates.Returned
            mRet = True
        End Select
      Catch ex As Exception
      End Try
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Return GetEditable()
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Return GetEditable()
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
        Return GetEditable()
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
    Public Shared Function DeleteWF(ByVal IndentNo As Int32) As SIS.PUR.purIndents
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Con.Open()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "  DELETE PUR_IndentItemProperty where indentno=" & IndentNo
          Cmd.CommandText &= " DELETE PUR_IndentDetails where indentno=" & IndentNo
          Cmd.CommandText &= " DELETE PUR_Indents where indentno=" & IndentNo
          Try
            Cmd.ExecuteNonQuery()
          Catch ex As Exception
            Throw New Exception("All Lines cannot be deleted")
          End Try
        End Using
      End Using
      Return Nothing
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Return GetEditable()
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
    Public Shared Function InitiateWF(ByVal IndentNo As Int32) As SIS.PUR.purIndents
      Dim tmpitms As List(Of SIS.PUR.purIndentDetails) = SIS.PUR.purIndentDetails.purIndentDetailsSelectList(0, 99, "", False, "", IndentNo)
      If tmpitms.Count <= 0 Then
        Throw New Exception("Item not found in Indent, can not forward.")
      End If
      Dim Results As SIS.PUR.purIndents = purIndentsGetByID(IndentNo)
      With Results
        .StatusID = enumIndentStates.UnderApproval
        .CreatedOn = Now
        .CreatedBy = HttpContext.Current.Session("LoginID")
      End With
      SIS.PUR.purIndents.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_purIndentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TranTypeID As String, ByVal StatusID As Int32, ByVal CreatedBy As String, ByVal EmployeeID As String, ByVal DepartmentID As String, ByVal ProjectID As String, ByVal DivisionID As String) As List(Of SIS.PUR.purIndents)
      Dim Results As List(Of SIS.PUR.purIndents) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "IndentNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppur_LG_IndentsSelectListSearch"
            Cmd.CommandText = "sppurIndentsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppur_LG_IndentsSelectListFilteres"
            Cmd.CommandText = "sppurIndentsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TranTypeID", SqlDbType.NVarChar, 3, IIf(TranTypeID Is Nothing, String.Empty, TranTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID", SqlDbType.Int, 10, IIf(StatusID = Nothing, 0, StatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy", SqlDbType.NVarChar, 8, IIf(CreatedBy Is Nothing, String.Empty, CreatedBy))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID", SqlDbType.NVarChar, 8, IIf(EmployeeID Is Nothing, String.Empty, EmployeeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DepartmentID", SqlDbType.NVarChar, 6, IIf(DepartmentID Is Nothing, String.Empty, DepartmentID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DivisionID", SqlDbType.NVarChar, 6, IIf(DivisionID Is Nothing, String.Empty, DivisionID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
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
    Public Shared Function UZ_purIndentsInsert(ByVal Record As SIS.PUR.purIndents) As SIS.PUR.purIndents
      Dim _Result As SIS.PUR.purIndents = purIndentsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_purIndentsUpdate(ByVal Record As SIS.PUR.purIndents) As SIS.PUR.purIndents
      Dim _Result As SIS.PUR.purIndents = purIndentsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_purIndentsDelete(ByVal Record As SIS.PUR.purIndents) As Integer
      DeleteWF(Record.IndentNo)
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_IndentNo"), TextBox).Text = ""
          CType(.FindControl("F_TranTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_InsuranceDetails"), TextBox).Text = ""
          CType(.FindControl("F_ModeOfDispatch"), TextBox).Text = ""
          CType(.FindControl("F_CurrencyID"), Object).SelectedValue = "INR"
          CType(.FindControl("F_IsgecGSTIN"), Object).SelectedValue = ""
          CType(.FindControl("F_CostCenterID"), TextBox).Text = ""
          CType(.FindControl("F_CostCenterID_Display"), Label).Text = ""
          CType(.FindControl("F_ConversionFactorINR"), TextBox).Text = "1.000000"
          CType(.FindControl("F_WarrantyDetails"), TextBox).Text = ""
          CType(.FindControl("F_EmployeeID"), TextBox).Text = ""
          CType(.FindControl("F_EmployeeID_Display"), Label).Text = ""
          CType(.FindControl("F_DepartmentID"), TextBox).Text = ""
          CType(.FindControl("F_DepartmentID_Display"), Label).Text = ""
          CType(.FindControl("F_IndenterRemarks"), TextBox).Text = ""
          CType(.FindControl("F_ProjectID"), TextBox).Text = ""
          CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
          CType(.FindControl("F_DivisionID"), TextBox).Text = ""
          CType(.FindControl("F_DivisionID_Display"), Label).Text = ""
          CType(.FindControl("F_ElementID"), TextBox).Text = ""
          CType(.FindControl("F_ElementID_Display"), Label).Text = ""
          CType(.FindControl("F_PaymentTerms"), TextBox).Text = ""
          CType(.FindControl("F_DeliveryTerms"), TextBox).Text = ""
          CType(.FindControl("F_DestinationAddress"), TextBox).Text = ""
          CType(.FindControl("F_IsgecGSTINAddress"), TextBox).Text = ""
          CType(.FindControl("F_DeliveryDate"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Sub UpdateStatus(IndentNo As Integer)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Dim sQty As Decimal = 0
        Dim sOrdQty As Decimal = 0
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = " select sum(Quantity) as sQty, sum(OrderedQuantity) as sOrdQty from PUR_IndentDetails where MainLine=1 and IndentNo=" & IndentNo
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            sQty = Reader("sQty")
            sOrdQty = Reader("sOrdQty")
          End While
          Reader.Close()
        End Using
        Dim Status As Integer = enumIndentStates.PendingForOrdering
        If sOrdQty > 0 Then
          Status = enumIndentStates.PartiallyOrdered
        End If
        If sOrdQty = sQty Then
          Status = enumIndentStates.OrderPlaced
        End If
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = " update PUR_Indents set StatusID=" & Status & " where IndentNo=" & IndentNo
          Cmd.ExecuteNonQuery()
        End Using
      End Using
    End Sub
  End Class
End Namespace
