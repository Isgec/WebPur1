Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purItemCategorySpecs
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
          CType(.FindControl("F_ItemCategoryID"), TextBox).Text = ""
          CType(.FindControl("F_ItemCategoryID_Display"), Label).Text = ""
          CType(.FindControl("F_CategorySpecID"), TextBox).Text = ""
          CType(.FindControl("F_SpecID"), TextBox).Text = ""
          CType(.FindControl("F_SpecID_Display"), Label).Text = ""
          CType(.FindControl("F_SpecName"), TextBox).Text = ""
          CType(.FindControl("F_DefaultValueSerialNo"), TextBox).Text = ""
          CType(.FindControl("F_DefaultValueSerialNo_Display"), Label).Text = ""
          CType(.FindControl("F_IsFixed"), CheckBox).Checked = False
          CType(.FindControl("F_IsDerived"), CheckBox).Checked = False
          CType(.FindControl("F_ValidateValue"), CheckBox).Checked = False
          CType(.FindControl("F_UseValues"), CheckBox).Checked = False
          CType(.FindControl("F_AllowUserValue"), CheckBox).Checked = False
          CType(.FindControl("F_IsRange"), CheckBox).Checked = False
          CType(.FindControl("F_ValueDataTypeID"), Object).SelectedValue = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetByItemCode(ItemCode As String) As List(Of SIS.PUR.purItemCategorySpecs)
      Dim Results As New List(Of SIS.PUR.purItemCategorySpecs)
      If ItemCode <> "" Then
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "sppur_LG_ItemCategorySpecsByItemCode"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode", SqlDbType.Int, 10, ItemCode)
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            While (Reader.Read())
              Results.Add(New SIS.PUR.purItemCategorySpecs(Reader))
            End While
            Reader.Close()
          End Using
        End Using
      End If
      Return Results
    End Function
    Public Property IndentedSpec As SIS.PUR.purIndentItemProperty = Nothing
    Public Property OrderedSpec As SIS.PUR.purOrderItemProperty = Nothing
    Public Property ReceiptSpec As SIS.PUR.purReceiptItemProperty = Nothing
    Public Sub SetSelected(UsedFor As enumUsedFor)
      ActualSelectedValue = DefaultValueSerialNo
      Select Case UsedFor
        Case enumUsedFor.Indent
          If IndentedSpec IsNot Nothing Then ActualSelectedValue = IndentedSpec.SerialNo
        Case enumUsedFor.Order
          If OrderedSpec IsNot Nothing Then ActualSelectedValue = OrderedSpec.SerialNo
        Case enumUsedFor.Receipt
          If ReceiptSpec IsNot Nothing Then ActualSelectedValue = ReceiptSpec.SerialNo
      End Select
      If ActualSelectedValue <> "" Then ActualSelectedValue = ItemCategoryID & "|" & CategorySpecID & "|" & ActualSelectedValue

    End Sub
    Public Property ActualSelectedValue As String = ""
    Public Shared Function GetItemCategorySpecs(ItemCode As String, UsedFor As enumUsedFor, Header As String, Line As String, Rev As String) As List(Of SIS.PUR.purItemCategorySpecs)
      Dim Results As List(Of SIS.PUR.purItemCategorySpecs) = SIS.PUR.purItemCategorySpecs.GetByItemCode(ItemCode)
      If Header <> "" Then
        If Line = "" Then Line = 0
        Select Case UsedFor
          Case enumUsedFor.Indent
            Dim ISpecs As List(Of SIS.PUR.purIndentItemProperty) = SIS.PUR.purIndentItemProperty.GetByItemCode(Header, Line, ItemCode)
            For Each r As SIS.PUR.purItemCategorySpecs In Results
              For Each x As SIS.PUR.purIndentItemProperty In ISpecs
                If r.ItemCategoryID = x.ItemCategoryID AndAlso r.CategorySpecID = x.CategorySpecID Then
                  r.IndentedSpec = x
                  Exit For
                End If
              Next
              r.SetSelected(UsedFor)
            Next
          Case enumUsedFor.Order
            Dim ISpecs As List(Of SIS.PUR.purOrderItemProperty) = SIS.PUR.purOrderItemProperty.GetByItemCode(Header, Line, ItemCode, Rev)
            For Each r As SIS.PUR.purItemCategorySpecs In Results
              For Each x As SIS.PUR.purOrderItemProperty In ISpecs
                If r.ItemCategoryID = x.ItemCategoryID AndAlso r.CategorySpecID = x.CategorySpecID Then
                  r.OrderedSpec = x
                  Exit For
                End If
              Next
              r.SetSelected(UsedFor)
            Next
          Case enumUsedFor.Receipt
            Dim ISpecs As List(Of SIS.PUR.purReceiptItemProperty) = SIS.PUR.purReceiptItemProperty.GetByItemCode(Header, Line, ItemCode)
            For Each r As SIS.PUR.purItemCategorySpecs In Results
              For Each x As SIS.PUR.purReceiptItemProperty In ISpecs
                If r.ItemCategoryID = x.ItemCategoryID AndAlso r.CategorySpecID = x.CategorySpecID Then
                  r.ReceiptSpec = x
                  Exit For
                End If
              Next
              r.SetSelected(UsedFor)
            Next
        End Select
      End If
      Return Results
    End Function
  End Class
End Namespace
