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

<ValidationProperty("SelectedValue")> _
Partial Class LC_purOrders
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public ReadOnly Property LCClientID() As String
    Get
      Return DDLpurOrders.ClientID
    End Get
  End Property
  Public Property AddAttributes() As String
    Get
      Return DDLpurOrders.Attributes.ToString
    End Get
    Set(ByVal value As String)
      Try
        Dim aVal() As String = value.Split(",".ToCharArray)
        DDLpurOrders.Attributes.Add(aVal(0), aVal(1))
      Catch ex As Exception
      End Try
    End Set
  End Property
  Public Property CssClass() As String
    Get
      Return DDLpurOrders.CssClass
    End Get
    Set(ByVal value As String)
      DDLpurOrders.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLpurOrders.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLpurOrders.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatorpurOrders.Text
    End Get
    Set(ByVal value As String)
      If value = String.Empty Then
        RequiredFieldValidatorpurOrders.Enabled = False
      Else
        RequiredFieldValidatorpurOrders.Text = value
      End If
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatorpurOrders.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorpurOrders.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLpurOrders.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLpurOrders.Enabled = value
      RequiredFieldValidatorpurOrders.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLpurOrders.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLpurOrders.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLpurOrders.DataTextField
    End Get
    Set(ByVal value As String)
      DDLpurOrders.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLpurOrders.DataValueField
    End Get
    Set(ByVal value As String)
      DDLpurOrders.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLpurOrders.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLpurOrders.SelectedValue = String.Empty
      Else
        DDLpurOrders.SelectedValue = value
      End If
    End Set
  End Property
  Public Property OrderBy() As String
    Get
      Return _OrderBy
    End Get
    Set(ByVal value As String)
      _OrderBy = value
    End Set
  End Property
  Public Property IncludeDefault() As Boolean
    Get
      Return _IncludeDefault
    End Get
    Set(ByVal value As Boolean)
      _IncludeDefault = value
    End Set
  End Property
  Public Property DefaultText() As String
    Get
      Return _DefaultText
    End Get
    Set(ByVal value As String)
      _DefaultText = value
    End Set
  End Property
  Public Property DefaultValue() As String
    Get
      Return _DefaultValue
    End Get
    Set(ByVal value As String)
      _DefaultValue = value
    End Set
  End Property
  Protected Sub OdsDdlpurOrders_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdlpurOrders.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLpurOrders_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLpurOrders.DataBinding
    If _IncludeDefault Then
      DDLpurOrders.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLpurOrders_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLpurOrders.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
