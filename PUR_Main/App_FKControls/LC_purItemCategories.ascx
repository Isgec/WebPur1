<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purItemCategories.ascx.vb" Inherits="LC_purItemCategories" %>
<asp:DropDownList 
  ID = "DDLpurItemCategories"
  DataSourceID = "OdsDdlpurItemCategories"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurItemCategories"
  Runat = "server" 
  ControlToValidate = "DDLpurItemCategories"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurItemCategories"
  TypeName = "SIS.PUR.purItemCategories"
  SortParameterName = "OrderBy"
  SelectMethod = "purItemCategoriesSelectList"
  Runat="server" />
