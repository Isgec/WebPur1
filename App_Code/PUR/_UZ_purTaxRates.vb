Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purTaxRates
    Public Property IGSTrate As Decimal
      Get
        Return _TaxRate
      End Get
      Set(value As Decimal)
        _TaxRate = value
      End Set
    End Property
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
    Public Function GetDeleteable() As Boolean
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
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ReviseWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
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
    Public Shared Function ReviseWF(ByVal TaxCode As Int32, ByVal SerialNo As Int32) As SIS.PUR.purTaxRates
      Dim Results As SIS.PUR.purTaxRates = purTaxRatesGetByID(TaxCode, SerialNo)
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_TaxCode"), TextBox).Text = ""
          CType(.FindControl("F_TaxCode_Display"), Label).Text = ""
          CType(.FindControl("F_SerialNo"), TextBox).Text = ""
          CType(.FindControl("F_FromDate"), TextBox).Text = ""
          CType(.FindControl("F_ToDate"), TextBox).Text = ""
          CType(.FindControl("F_TaxRate"), TextBox).Text = 0
          CType(.FindControl("F_CGSTRate"), TextBox).Text = 0
          CType(.FindControl("F_SGSTRate"), TextBox).Text = 0
          CType(.FindControl("F_CessRate"), TextBox).Text = 0
          CType(.FindControl("F_TCSRate"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetByDate(ByVal TaxCode As String, ByVal FDate As String) As SIS.PUR.purTaxRates
      Dim Results As SIS.PUR.purTaxRates = Nothing
      If TaxCode = "" Then Return Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select top 1 * from PUR_TaxRates where taxcode=" & TaxCode & " and fromdate<=convert(datetime,'" & FDate & "',103)  and todate>=convert(datetime,'" & FDate & "',103)"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PUR.purTaxRates(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
