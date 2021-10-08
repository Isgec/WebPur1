<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purItemCategorySpecValues.ascx.vb" Inherits="LC_purItemCategorySpecValues" %>
<asp:DropDownList 
  ID = "DDLpurItemCategorySpecValues"
  DataSourceID = "OdsDdlpurItemCategorySpecValues"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurItemCategorySpecValues"
  Runat = "server" 
  ControlToValidate = "DDLpurItemCategorySpecValues"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurItemCategorySpecValues"
  TypeName = "SIS.PUR.purItemCategorySpecValues"
  SelectMethod = "purItemCategorySpecValuesSelectList"
  Runat="server" />
