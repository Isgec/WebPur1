<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purOrderDetails.ascx.vb" Inherits="LC_purOrderDetails" %>
<asp:DropDownList 
  ID = "DDLpurOrderDetails"
  DataSourceID = "OdsDdlpurOrderDetails"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurOrderDetails"
  Runat = "server" 
  ControlToValidate = "DDLpurOrderDetails"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurOrderDetails"
  TypeName = "SIS.PUR.purOrderDetails"
  SortParameterName = "OrderBy"
  SelectMethod = "purOrderDetailsSelectList"
  Runat="server" />
