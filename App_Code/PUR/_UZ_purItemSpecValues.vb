Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purItemSpecValues
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
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          Dim tmp As SIS.PUR.purItemSpecification = SIS.PUR.purItemSpecification.purItemSpecificationGetByID(HttpContext.Current.Request.QueryString("SpecID"))
          CType(.FindControl("F_SpecID"), TextBox).Text = tmp.SpecID
          CType(.FindControl("F_SpecID_Display"), Label).Text = tmp.SpecName
          CType(.FindControl("F_SerialNo"), TextBox).Text = ""
          CType(.FindControl("F_ValueDataTypeID"), Object).SelectedValue = tmp.ValueDataTypeID
          CType(.FindControl("F_IsRange"), CheckBox).Checked = tmp.IsRange
          CType(.FindControl("F_Data1Value"), TextBox).Text = ""
          CType(.FindControl("F_Data2Value"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
