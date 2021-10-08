Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PUR
  Partial Public Class purIndentItemProperty
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
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal IndentNo As Int32, ByVal IndentLine As Int32, ByVal ItemCode As Int32, ByVal ItemCategoryID As Int32, ByVal CategorySpecID As Int32, ByVal Data1Value As String, ByVal Data2Value As String, ByVal IsRange As Boolean, ByVal SerialNo As Int32, ByVal ValueDataTypeID As String) As SIS.PUR.purIndentItemProperty
      Dim Results As SIS.PUR.purIndentItemProperty = purIndentItemPropertyGetByID(IndentNo, IndentLine, ItemCode, ItemCategoryID, CategorySpecID)
      Return Results
    End Function
    Public Shared Function GetByItemCode(ByVal IndentNo As Int32, ByVal IndentLine As Int32, ByVal ItemCode As Int32) As List(Of SIS.PUR.purIndentItemProperty)
      Dim ISpecs As New List(Of SIS.PUR.purIndentItemProperty)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppur_LG_IndentItemPropertyByItemCode"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode", SqlDbType.Int, 10, ItemCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentNo", SqlDbType.Int, 10, IndentNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentLine", SqlDbType.Int, 10, IndentLine)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            ISpecs.Add(New SIS.PUR.purIndentItemProperty(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return ISpecs
    End Function
    Public Shared Function DeleteByIndentLine(ByVal IndentNo As Int32, ByVal IndentLine As Int32) As Boolean
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "DELETE PUR_IndentItemProperty where IndentNo=" & IndentNo & " and IndentLine=" & IndentLine
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return True
    End Function

    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_CategorySpecID"), TextBox).Text = ""
        CType(.FindControl("F_CategorySpecID_Display"), Label).Text = ""
        CType(.FindControl("F_Data1Value"), TextBox).Text = ""
        CType(.FindControl("F_Data2Value"), TextBox).Text = ""
        CType(.FindControl("F_IndentNo"), TextBox).Text = ""
        CType(.FindControl("F_IndentNo_Display"), Label).Text = ""
        CType(.FindControl("F_ItemCategoryID"), TextBox).Text = ""
        CType(.FindControl("F_ItemCategoryID_Display"), Label).Text = ""
        CType(.FindControl("F_ItemCode"), TextBox).Text = ""
        CType(.FindControl("F_ItemCode_Display"), Label).Text = ""
        CType(.FindControl("F_IndentLine"), TextBox).Text = ""
        CType(.FindControl("F_IndentLine_Display"), Label).Text = ""
        CType(.FindControl("F_IsRange"), CheckBox).Checked = False
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
        CType(.FindControl("F_ValueDataTypeID"),Object).SelectedValue = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function CopyToOrder(ByVal IndentNo As Int32, ByVal IndentLine As Int32, ByVal OrderNo As Int32, ByVal OrderLine As Int32, ByVal OrderRev As Int32) As List(Of SIS.PUR.purOrderItemProperty)
      Dim OSpecs As New List(Of SIS.PUR.purOrderItemProperty)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select * from PUR_IndentItemProperty where IndentNo=" & IndentNo & " and IndentLine=" & IndentLine
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            OSpecs.Add(New SIS.PUR.purOrderItemProperty(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      For Each OSpec As SIS.PUR.purOrderItemProperty In OSpecs
        With OSpec
          .OrderNo = OrderNo
          .OrderLine = OrderLine
          .OrderRev = OrderRev
        End With
        SIS.PUR.purOrderItemProperty.InsertData(OSpec)
      Next
      Return OSpecs
    End Function
  End Class
End Namespace
