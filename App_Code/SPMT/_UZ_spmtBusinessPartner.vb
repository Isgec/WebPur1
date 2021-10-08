Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SPMT
  Partial Public Class spmtBusinessPartner
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
    Public Shared Function GetBPFromERP(ByVal BPID As String) As SIS.SPMT.spmtBusinessPartner
      Dim Results As SIS.SPMT.spmtBusinessPartner = Nothing
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
      Dim Sql As String = ""
      Sql &= "select                                                     "
      Sql &= "  suh.t_bpid as BPID,                                      "
      Sql &= "  suh.t_nama as BPName,                                    "
      Sql &= "  adh.t_ln01 as Address1Line,                              "
      Sql &= "  adh.t_ln02 as Address2Line,                                    "
      Sql &= "  adh.t_ln03 as Address3,                                        "
      Sql &= "  adh.t_ln04 as Address4,                                        "
      Sql &= "  adh.t_ln05 as City,                                            "
      Sql &= "  adh.t_ln06 as State,                                           "
      Sql &= "  adh.t_pstc as Zip,                                             "
      Sql &= "  adh.t_ccty as Country,                                         "
      Sql &= "  cnh.t_fuln as ContactPerson,                                   "
      Sql &= "  cnh.t_telp as ContactNo,                                       "
      Sql &= "  cnh.t_info as EMailID                                          "
      Sql &= "  from ttccom100" & Comp & " as suh                                       "
      Sql &= "  left outer join ttccom130" & Comp & " as adh on suh.t_cadr = adh.t_cadr "
      Sql &= "  left outer join ttccom140" & Comp & " as cnh on suh.t_ccnt = cnh.t_ccnt "
      Sql &= "  where suh.t_bpid ='" & BPID & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.SPMT.spmtBusinessPartner(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      If Results IsNot Nothing Then
        Try
          Try
            Results = SIS.SPMT.spmtBusinessPartner.InsertData(Results)
          Catch exx As Exception
            Results = SIS.SPMT.spmtBusinessPartner.UpdateData(Results)
          End Try
          GetBPGSTINFromERP(Results.BPID, 0)
        Catch ex As Exception
        End Try
      End If
      Return Results
    End Function
    Public Shared Function GetBPGSTINFromERP(ByVal BPID As String, Optional ByVal seqnORfovn As String = "") As List(Of SIS.SPMT.spmtBPGSTIN)
      Dim Results As New List(Of SIS.SPMT.spmtBPGSTIN)
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
      Dim Sql As String = ""
      Sql &= "select                                "
      Sql &= "  t_bpid as BPID,                     "
      Sql &= "  t_fovn as Description,              "
      Sql &= "  t_seqn_l as GSTIN                   "
      Sql &= "  from ttctax400" & Comp
      Sql &= "  where t_bpid ='" & BPID & "'"
      Sql &= "  and t_catg_l = 9 "
      If seqnORfovn <> "" Then
        If IsNumeric(seqnORfovn) Then
          Sql &= "  and t_seqn_l =" & seqnORfovn
        Else
          Sql &= "  and t_fovn ='" & seqnORfovn & "'"
        End If
      End If
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While Reader.Read()
            Results.Add(New SIS.SPMT.spmtBPGSTIN(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      If Results.Count > 0 Then
        For Each tmp As SIS.SPMT.spmtBPGSTIN In Results
          Try
            SIS.SPMT.spmtBPGSTIN.InsertData(tmp)
          Catch ex As Exception
            Try
              SIS.SPMT.spmtBPGSTIN.UpdateData(tmp)
            Catch exX As Exception
            End Try
          End Try
        Next
      End If
      Return Results
    End Function

    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_BPID"), TextBox).Text = ""
        CType(.FindControl("F_BPName"), TextBox).Text = ""
        CType(.FindControl("F_Address1Line"), TextBox).Text = ""
        CType(.FindControl("F_Address2Line"), TextBox).Text = ""
        CType(.FindControl("F_City"), TextBox).Text = ""
        CType(.FindControl("F_EMailID"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
