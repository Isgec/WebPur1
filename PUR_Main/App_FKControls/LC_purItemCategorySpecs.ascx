<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purItemCategorySpecs.ascx.vb" Inherits="LC_purItemCategorySpecs" %>
<asp:DropDownList 
  ID = "DDLpurItemCategorySpecs"
  DataSourceID = "OdsDdlpurItemCategorySpecs"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurItemCategorySpecs"
  Runat = "server" 
  ControlToValidate = "DDLpurItemCategorySpecs"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurItemCategorySpecs"
  TypeName = "SIS.PUR.purItemCategorySpecs"
  SortParameterName = "OrderBy"
  SelectMethod = "purItemCategorySpecsSelectList"
  Runat="server" />
