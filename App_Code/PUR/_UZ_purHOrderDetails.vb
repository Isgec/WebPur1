Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purHOrderDetails
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
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
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
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_OrderNo"), TextBox).Text = 0
        CType(.FindControl("F_OrderRev"), TextBox).Text = 0
        CType(.FindControl("F_OrderLine"), TextBox).Text = 0
        CType(.FindControl("F_TranTypeID"), TextBox).Text = ""
        CType(.FindControl("F_BillType"), TextBox).Text = 0
        CType(.FindControl("F_HSNSACCode"), TextBox).Text = ""
        CType(.FindControl("F_ItemCode"), TextBox).Text = 0
        CType(.FindControl("F_UOM"), TextBox).Text = ""
        CType(.FindControl("F_ItemDescription"), TextBox).Text = ""
        CType(.FindControl("F_Quantity"), TextBox).Text = 0
        CType(.FindControl("F_Price"), TextBox).Text = 0
        CType(.FindControl("F_AssessableValue"), TextBox).Text = 0
        CType(.FindControl("F_TaxCode"), TextBox).Text = 0
        CType(.FindControl("F_CGSTRate"), TextBox).Text = 0
        CType(.FindControl("F_CGSTAmount"), TextBox).Text = 0
        CType(.FindControl("F_SGSTRate"), TextBox).Text = 0
        CType(.FindControl("F_SGSTAmount"), TextBox).Text = 0
        CType(.FindControl("F_IGSTrate"), TextBox).Text = 0
        CType(.FindControl("F_IGSTAmount"), TextBox).Text = 0
        CType(.FindControl("F_CESSRate"), TextBox).Text = 0
        CType(.FindControl("F_CESSAmount"), TextBox).Text = 0
        CType(.FindControl("F_TCSRate"), TextBox).Text = 0
        CType(.FindControl("F_TCSAmount"), TextBox).Text = 0
        CType(.FindControl("F_CurrencyID"), TextBox).Text = ""
        CType(.FindControl("F_ConversionFactorINR"), TextBox).Text = 0
        CType(.FindControl("F_DeliveryDate"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ElementID"), TextBox).Text = ""
        CType(.FindControl("F_EmployeeID"), TextBox).Text = ""
        CType(.FindControl("F_DepartmentID"), TextBox).Text = ""
        CType(.FindControl("F_CostCenterID"), TextBox).Text = ""
        CType(.FindControl("F_DivisionID"), TextBox).Text = ""
        CType(.FindControl("F_MainLine"), CheckBox).Checked = False
        CType(.FindControl("F_ParentLine"), TextBox).Text = 0
        CType(.FindControl("F_ReceiptNo"), TextBox).Text = 0
        CType(.FindControl("F_ReceiptLine"), TextBox).Text = 0
        CType(.FindControl("F_ReceivedQuantity"), TextBox).Text = 0
        CType(.FindControl("F_Amount"), TextBox).Text = 0
        CType(.FindControl("F_TotalGST"), TextBox).Text = 0
        CType(.FindControl("F_TaxAmount"), TextBox).Text = 0
        CType(.FindControl("F_TotalAmount"), TextBox).Text = 0
        CType(.FindControl("F_TotalAmountINR"), TextBox).Text = 0
        CType(.FindControl("F_OriginalQuantity"), TextBox).Text = 0
        CType(.FindControl("F_FromIndent"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
