Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purItems
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
          CType(.FindControl("F_ItemCode"), TextBox).Text = ""
          CType(.FindControl("F_ItemDescription"), TextBox).Text = ""
          CType(.FindControl("F_UOM"), Object).SelectedValue = ""
          CType(.FindControl("F_OPBQty"), TextBox).Text = 0
          CType(.FindControl("F_RECQty"), TextBox).Text = 0
          CType(.FindControl("F_ISSQty"), TextBox).Text = 0
          CType(.FindControl("F_BALQty"), TextBox).Text = 0
          CType(.FindControl("F_ItemCategoryID"), TextBox).Text = ""
          CType(.FindControl("F_ItemCategoryID_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function CreateProperty(oDC As SIS.PUR.purIndentDetails) As Boolean
      Dim mRet As Boolean = True
      Dim cateSpecs As List(Of SIS.PUR.purItemCategorySpecs) = SIS.PUR.purItemCategorySpecs.purItemCategorySpecsSelectList(0, 9999, "", False, "", oDC.FK_PUR_IndentDetails_ItemCode.ItemCategoryID)
      For Each cs As SIS.PUR.purItemCategorySpecs In cateSpecs
        Dim x As New SIS.PUR.purIndentItemProperty
        With x
          .IndentNo = oDC.IndentNo
          .IndentLine = oDC.IndentLine
          .ItemCode = oDC.ItemCode
          .ItemCategoryID = cs.ItemCategoryID
          .CategorySpecID = cs.CategorySpecID
          .SerialNo = cs.DefaultValueSerialNo
          .ValueDataTypeID = cs.ValueDataTypeID
          .IsRange = cs.IsRange
          .Data1Value = .FK_PUR_IndentItemProperty_SerialNo.Data1Value
          .Data2Value = .FK_PUR_IndentItemProperty_SerialNo.Data2Value
        End With
        SIS.PUR.purIndentItemProperty.InsertData(x)
      Next
      Return mRet
    End Function
    Public Shared Function GetProperty(ItemCode As Integer) As List(Of SIS.PUR.purIndentItemProperty)
      Dim mRet As New List(Of SIS.PUR.purIndentItemProperty)
      Dim Itm As SIS.PUR.purItems = SIS.PUR.purItems.purItemsGetByID(ItemCode)
      Dim cateSpecs As List(Of SIS.PUR.purItemCategorySpecs) = SIS.PUR.purItemCategorySpecs.purItemCategorySpecsSelectList(0, 9999, "", False, "", Itm.ItemCategoryID)
      For Each cs As SIS.PUR.purItemCategorySpecs In cateSpecs
        Dim x As New SIS.PUR.purIndentItemProperty
        With x
          '.IndentNo = oDC.IndentNo
          '.IndentLine = oDC.IndentLine
          '.ItemCode = oDC.ItemCode
          .ItemCategoryID = cs.ItemCategoryID
          .CategorySpecID = cs.CategorySpecID
          .SerialNo = cs.DefaultValueSerialNo
          .ValueDataTypeID = cs.ValueDataTypeID
          .IsRange = cs.IsRange
          .Data1Value = .FK_PUR_IndentItemProperty_SerialNo.Data1Value
          .Data2Value = .FK_PUR_IndentItemProperty_SerialNo.Data2Value
        End With
        SIS.PUR.purIndentItemProperty.InsertData(x)
      Next
      Return mRet
    End Function

  End Class
End Namespace
