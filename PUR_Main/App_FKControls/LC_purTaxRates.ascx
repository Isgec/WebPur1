<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purTaxRates.ascx.vb" Inherits="LC_purTaxRates" %>
<asp:DropDownList 
  ID = "DDLpurTaxRates"
  DataSourceID = "OdsDdlpurTaxRates"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurTaxRates"
  Runat = "server" 
  ControlToValidate = "DDLpurTaxRates"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurTaxRates"
  TypeName = "SIS.PUR.purTaxRates"
  SortParameterName = "OrderBy"
  SelectMethod = "purTaxRatesSelectList"
  Runat="server" />
