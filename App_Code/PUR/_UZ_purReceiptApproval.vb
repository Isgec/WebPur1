Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purReceiptApproval
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function ApproveWF(ByVal ReceiptNo As Int32, ByVal ApproverRemarks As String) As SIS.PUR.purReceiptApproval
      Dim Receipt As SIS.PUR.purReceiptApproval = purReceiptApprovalGetByID(ReceiptNo)
      Dim RDetails As List(Of SIS.PUR.purReceiptDetails) = SIS.PUR.purReceiptDetails.purReceiptDetailsSelectList(0, 9999, "", False, "", ReceiptNo)
      Dim SBH As SIS.SPMT.SpmtNewSBH = SIS.PUR.purReceipts.GetSBH(Receipt)
      SBH = SIS.SPMT.SpmtNewSBH.InsertData(SBH)
      For Each rd As SIS.PUR.purReceiptDetails In RDetails
        rd.IRNo = SBH.IRNo
        Dim SBD As SIS.SPMT.SpmtNewSBD = SIS.PUR.purReceiptDetails.GetSBD(rd)
        SBD = SIS.SPMT.SpmtNewSBD.InsertData(SBD)
        rd.IRLine = SBD.SerialNo
        SIS.PUR.purReceiptDetails.UpdateData(rd)
      Next
      With Receipt
        .StatusID = enumReceiptStates.IRCreated
        .ApprovedBy = HttpContext.Current.Session("LoginID")
        .ApprovedOn = Now
        .ApproverRemarks = ApproverRemarks
        .IRNO = SBH.IRNo
      End With
      SIS.PUR.purReceipts.UpdateData(Receipt)
      Return Receipt
    End Function
    Public Shared Function RejectWF(ByVal ReceiptNo As Int32, ByVal ApproverRemarks As String) As SIS.PUR.purReceiptApproval
      Dim Results As SIS.PUR.purReceiptApproval = purReceiptApprovalGetByID(ReceiptNo)
      With Results
        .StatusID = enumReceiptStates.Returned
        .ApprovedBy = HttpContext.Current.Session("LoginID")
        .ApprovedOn = Now
        .ApproverRemarks = ApproverRemarks
      End With
      Return Results
    End Function
    Public Shared Function UZ_purReceiptApprovalSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TranTypeID As String, ByVal SupplierID As String, ByVal EmployeeID As String, ByVal CreatedBy As String, ByVal StatusID As Int32) As List(Of SIS.PUR.purReceiptApproval)
      Dim Results As List(Of SIS.PUR.purReceiptApproval) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ReceiptNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppur_LG_ReceiptApprovalSelectListSearch"
            Cmd.CommandText = "sppurReceiptApprovalSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppur_LG_ReceiptApprovalSelectListFilteres"
            Cmd.CommandText = "sppurReceiptApprovalSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TranTypeID",SqlDbType.NVarChar,3, IIf(TranTypeID Is Nothing, String.Empty,TranTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID",SqlDbType.NVarChar,9, IIf(SupplierID Is Nothing, String.Empty,SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID",SqlDbType.NVarChar,8, IIf(EmployeeID Is Nothing, String.Empty,EmployeeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy",SqlDbType.NVarChar,8, IIf(CreatedBy Is Nothing, String.Empty,CreatedBy))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID",SqlDbType.Int,10, IIf(StatusID = Nothing, 0,StatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PUR.purReceiptApproval)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PUR.purReceiptApproval(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
