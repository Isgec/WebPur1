Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purHOrderItemProperty
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
        CType(.FindControl("F_ItemCode"), TextBox).Text = 0
        CType(.FindControl("F_ItemCategoryID"), TextBox).Text = 0
        CType(.FindControl("F_CategorySpecID"), TextBox).Text = 0
        CType(.FindControl("F_SerialNo"), TextBox).Text = 0
        CType(.FindControl("F_ValueDataTypeID"), TextBox).Text = ""
        CType(.FindControl("F_IsRange"), CheckBox).Checked = False
        CType(.FindControl("F_Data1Value"), TextBox).Text = ""
        CType(.FindControl("F_Data2Value"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
