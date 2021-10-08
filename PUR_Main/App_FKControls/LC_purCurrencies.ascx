<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purCurrencies.ascx.vb" Inherits="LC_purCurrencies" %>
<asp:DropDownList 
  ID = "DDLpurCurrencies"
  DataSourceID = "OdsDdlpurCurrencies"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurCurrencies"
  Runat = "server" 
  ControlToValidate = "DDLpurCurrencies"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurCurrencies"
  TypeName = "SIS.PUR.purCurrencies"
  SortParameterName = "OrderBy"
  SelectMethod = "purCurrenciesSelectList"
  Runat="server" />
