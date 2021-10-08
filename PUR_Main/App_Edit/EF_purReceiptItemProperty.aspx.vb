Imports System.Web.Script.Serialization
Partial Class EF_purReceiptItemProperty
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSpurReceiptItemProperty_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpurReceiptItemProperty.Selected
    Dim tmp As SIS.PUR.purReceiptItemProperty = CType(e.ReturnValue, SIS.PUR.purReceiptItemProperty)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpurReceiptItemProperty_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurReceiptItemProperty.Init
    DataClassName = "EpurReceiptItemProperty"
    SetFormView = FVpurReceiptItemProperty
  End Sub
  Protected Sub TBLpurReceiptItemProperty_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpurReceiptItemProperty.Init
    SetToolBar = TBLpurReceiptItemProperty
  End Sub
  Protected Sub FVpurReceiptItemProperty_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpurReceiptItemProperty.PreRender
    TBLpurReceiptItemProperty.EnableSave = Editable
    TBLpurReceiptItemProperty.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PUR_Main/App_Edit") & "/EF_purReceiptItemProperty.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpurReceiptItemProperty") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpurReceiptItemProperty", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PUR.purItemCategorySpecValues.SelectpurItemCategorySpecValuesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PUR_ReceiptItemProperty_SerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ItemCategoryID As Int32 = CType(aVal(1),Int32)
    Dim CategorySpecID As Int32 = CType(aVal(2),Int32)
    Dim SerialNo As Int32 = CType(aVal(3),Int32)
    Dim oVar As SIS.PUR.purItemCategorySpecValues = SIS.PUR.purItemCategorySpecValues.purItemCategorySpecValuesGetByID(ItemCategoryID,CategorySpecID,SerialNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
