Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purHOrders
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
        CType(.FindControl("F_OrderDate"), TextBox).Text = ""
        CType(.FindControl("F_PurchaseTypeID"), TextBox).Text = ""
        CType(.FindControl("F_TranTypeID"), TextBox).Text = ""
        CType(.FindControl("F_StatusID"), TextBox).Text = 0
        CType(.FindControl("F_IsgecGSTIN"), TextBox).Text = 0
        CType(.FindControl("F_IsgecGSTINAddress"), TextBox).Text = ""
        CType(.FindControl("F_DestinationAddress"), TextBox).Text = ""
        CType(.FindControl("F_QuatationNo"), TextBox).Text = ""
        CType(.FindControl("F_QuotationDate"), TextBox).Text = ""
        CType(.FindControl("F_SupplierID"), TextBox).Text = ""
        CType(.FindControl("F_SupplierGSTIN"), TextBox).Text = 0
        CType(.FindControl("F_SupplierName"), TextBox).Text = ""
        CType(.FindControl("F_SupplierGSTINUMBER"), TextBox).Text = ""
        CType(.FindControl("F_DeliveryDate"), TextBox).Text = ""
        CType(.FindControl("F_PaymentTerms"), TextBox).Text = ""
        CType(.FindControl("F_DeliveryTerms"), TextBox).Text = ""
        CType(.FindControl("F_ModeOfDispatch"), TextBox).Text = ""
        CType(.FindControl("F_InsuranceDetails"), TextBox).Text = ""
        CType(.FindControl("F_WarrantyDetails"), TextBox).Text = ""
        CType(.FindControl("F_BuyerRemarks"), TextBox).Text = ""
        CType(.FindControl("F_CurrencyID"), TextBox).Text = ""
        CType(.FindControl("F_ConversionFactorINR"), TextBox).Text = 0
        CType(.FindControl("F_AprTypeID"), TextBox).Text = ""
        CType(.FindControl("F_CreatedBy"), TextBox).Text = ""
        CType(.FindControl("F_CreatedOn"), TextBox).Text = ""
        CType(.FindControl("F_ApprovedBy"), TextBox).Text = ""
        CType(.FindControl("F_ApprovedOn"), TextBox).Text = ""
        CType(.FindControl("F_ApproverRemarks"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ElementID"), TextBox).Text = ""
        CType(.FindControl("F_EmployeeID"), TextBox).Text = ""
        CType(.FindControl("F_DepartmentID"), TextBox).Text = ""
        CType(.FindControl("F_CostCenterID"), TextBox).Text = ""
        CType(.FindControl("F_DivisionID"), TextBox).Text = ""
        CType(.FindControl("F_OrderText"), TextBox).Text = ""
        CType(.FindControl("F_ReasonOfRevision"), TextBox).Text = ""
        CType(.FindControl("F_IssuedBy"), TextBox).Text = ""
        CType(.FindControl("F_IssuedOn"), TextBox).Text = ""
        CType(.FindControl("F_RevisedBy"), TextBox).Text = ""
        CType(.FindControl("F_RevisedOn"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
