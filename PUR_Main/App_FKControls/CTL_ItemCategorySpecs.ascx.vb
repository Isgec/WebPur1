Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Partial Class CTL_ItemCategorySpecs
  Inherits System.Web.UI.UserControl
  Public Property UsedFor As enumUsedFor
    Get
      If ViewState("UsedFor") IsNot Nothing Then
        Return ViewState("UsedFor")
      End If
      Return enumUsedFor.Indent
    End Get
    Set(value As enumUsedFor)
      ViewState.Add("UsedFor", value)
    End Set
  End Property
  Public Sub Execute()
    Dim ODS As New ObjectDataSource
    ODS.SelectMethod = "GetItemCategorySpecs"
    ODS.DataObjectTypeName = "SIS.PUR.purItemCategorySpecs"
    ODS.TypeName = "SIS.PUR.purItemCategorySpecs"
    Select Case UsedFor
      Case enumUsedFor.Indent
        ODS.SelectParameters.Add("ItemCode", ItemCode)
        ODS.SelectParameters.Add("UsedFor", UsedFor)
        ODS.SelectParameters.Add("Header", IndentNo)
        ODS.SelectParameters.Add("Line", IndentLine)
        ODS.SelectParameters.Add("Rev", "")
      Case enumUsedFor.Order
        ODS.SelectParameters.Add("ItemCode", ItemCode)
        ODS.SelectParameters.Add("UsedFor", UsedFor)
        ODS.SelectParameters.Add("Header", OrderNo)
        ODS.SelectParameters.Add("Rev", RevNo)
        ODS.SelectParameters.Add("Line", OrderLine)
      Case enumUsedFor.Receipt
        ODS.SelectParameters.Add("ItemCode", ItemCode)
        ODS.SelectParameters.Add("UsedFor", UsedFor)
        ODS.SelectParameters.Add("Header", ReceiptNo)
        ODS.SelectParameters.Add("Line", ReceiptLine)
        ODS.SelectParameters.Add("Rev", "")
    End Select
    GVpurItemCategorySpecs.DataSource = ODS
    GVpurItemCategorySpecs.DataBind()
  End Sub
  Public Property IndentNo As String
    Get
      If ViewState("IndentNo") IsNot Nothing Then
        Return ViewState("IndentNo")
      End If
      Return 0
    End Get
    Set(value As String)
      ViewState.Add("IndentNo", value)
    End Set
  End Property
  Public Property IndentLine As String
    Get
      If ViewState("IndentLine") IsNot Nothing Then
        Return ViewState("IndentLine")
      End If
      Return 0
    End Get
    Set(value As String)
      ViewState.Add("IndentLine", value)
    End Set
  End Property
  Public Property OrderNo As String
    Get
      If ViewState("OrderNo") IsNot Nothing Then
        Return ViewState("OrderNo")
      End If
      Return 0
    End Get
    Set(value As String)
      ViewState.Add("OrderNo", value)
    End Set
  End Property
  Public Property RevNo As String
    Get
      If ViewState("RevNo") IsNot Nothing Then
        Return ViewState("RevNo")
      End If
      Return 0
    End Get
    Set(value As String)
      ViewState.Add("RevNo", value)
    End Set
  End Property
  Public Property OrderLine As String
    Get
      If ViewState("OrderLine") IsNot Nothing Then
        Return ViewState("OrderLine")
      End If
      Return 0
    End Get
    Set(value As String)
      ViewState.Add("OrderLine", value)
    End Set
  End Property
  Public Property ReceiptNo As String
    Get
      If ViewState("ReceiptNo") IsNot Nothing Then
        Return ViewState("ReceiptNo")
      End If
      Return 0
    End Get
    Set(value As String)
      ViewState.Add("ReceiptNo", value)
    End Set
  End Property
  Public Property ReceiptLine As String
    Get
      If ViewState("ReceiptLine") IsNot Nothing Then
        Return ViewState("ReceiptLine")
      End If
      Return 0
    End Get
    Set(value As String)
      ViewState.Add("ReceiptLine", value)
    End Set
  End Property
  Public Property ItemCode As String
    Get
      If ViewState("ItemCode") IsNot Nothing Then
        Return ViewState("ItemCode")
      End If
      Return 0
    End Get
    Set(value As String)
      ViewState.Add("ItemCode", value)
    End Set
  End Property
  Public Function GetData() As List(Of SIS.PUR.purItemCategorySpecValues)
    Dim mRet As New List(Of SIS.PUR.purItemCategorySpecValues)
    For Each r As GridViewRow In GVpurItemCategorySpecs.Rows
      If r.RowType = DataControlRowType.DataRow Then
        Dim x As New SIS.PUR.purItemCategorySpecValues
        x.ItemCategoryID = GVpurItemCategorySpecs.DataKeys(r.RowIndex).Values("ItemCategoryID")
        x.CategorySpecID = GVpurItemCategorySpecs.DataKeys(r.RowIndex).Values("CategorySpecID")
        Dim z As SIS.PUR.purItemCategorySpecs = SIS.PUR.purItemCategorySpecs.purItemCategorySpecsGetByID(x.ItemCategoryID, x.CategorySpecID)
        x.ValueDataTypeID = z.ValueDataTypeID
        If z.IsFixed Then
          x.SerialNo = z.DefaultValueSerialNo
        Else
          x.SerialNo = CType(r.FindControl("F_DefaultValueSerialNo"), CTL_ItemCategorySpecValues).SelectedValue.Split("|".ToCharArray)(2)
        End If
        Dim y As SIS.PUR.purItemCategorySpecValues = SIS.PUR.purItemCategorySpecValues.purItemCategorySpecValuesGetByID(x.ItemCategoryID, x.CategorySpecID, x.SerialNo)
        If z.IsRange Then
          x.Data1Value = y.Data1Value
          x.Data2Value = y.Data2Value
        Else
          x.Data1Value = y.Data1Value
        End If
        mRet.Add(x)
      End If
    Next
    Return mRet
  End Function

End Class
