<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purOrders.ascx.vb" Inherits="LC_purOrders" %>
<asp:DropDownList 
  ID = "DDLpurOrders"
  DataSourceID = "OdsDdlpurOrders"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurOrders"
  Runat = "server" 
  ControlToValidate = "DDLpurOrders"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurOrders"
  TypeName = "SIS.PUR.purOrders"
  SortParameterName = "OrderBy"
  SelectMethod = "purOrdersSelectList"
  Runat="server" />
