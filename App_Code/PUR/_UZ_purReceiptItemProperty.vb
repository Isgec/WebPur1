Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purReceiptItemProperty
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
        CType(.FindControl("F_ReceiptNo"), TextBox).Text = ""
        CType(.FindControl("F_ReceiptNo_Display"), Label).Text = ""
        CType(.FindControl("F_ReceiptLine"), TextBox).Text = ""
        CType(.FindControl("F_ReceiptLine_Display"), Label).Text = ""
        CType(.FindControl("F_ItemCode"), TextBox).Text = ""
        CType(.FindControl("F_ItemCode_Display"), Label).Text = ""
        CType(.FindControl("F_ItemCategoryID"), TextBox).Text = ""
        CType(.FindControl("F_ItemCategoryID_Display"), Label).Text = ""
        CType(.FindControl("F_CategorySpecID"), TextBox).Text = ""
        CType(.FindControl("F_CategorySpecID_Display"), Label).Text = ""
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
        CType(.FindControl("F_ValueDataTypeID"),Object).SelectedValue = ""
        CType(.FindControl("F_IsRange"), CheckBox).Checked = False
        CType(.FindControl("F_Data1Value"), TextBox).Text = ""
        CType(.FindControl("F_Data2Value"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function DeleteByReceiptLine(ByVal ReceiptNo As Int32, ByVal ReceiptLine As Int32) As Boolean
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "DELETE PUR_ReceiptItemProperty where ReceiptNo=" & ReceiptNo & " and ReceiptLine=" & ReceiptLine
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return True
    End Function
    Public Shared Function GetByItemCode(ByVal ReceiptNo As Int32, ByVal ReceiptLine As Int32, ByVal ItemCode As Int32) As List(Of SIS.PUR.purReceiptItemProperty)
      Dim ISpecs As New List(Of SIS.PUR.purReceiptItemProperty)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppur_LG_ReceiptItemPropertyByItemCode"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode", SqlDbType.Int, 10, ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo", SqlDbType.Int, 10, ReceiptNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptLine", SqlDbType.Int, 10, ReceiptLine)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            ISpecs.Add(New SIS.PUR.purReceiptItemProperty(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return ISpecs
    End Function
  End Class
End Namespace
