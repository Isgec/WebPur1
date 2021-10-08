<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purItemSpecification.ascx.vb" Inherits="LC_purItemSpecification" %>
<asp:DropDownList 
  ID = "DDLpurItemSpecification"
  DataSourceID = "OdsDdlpurItemSpecification"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurItemSpecification"
  Runat = "server" 
  ControlToValidate = "DDLpurItemSpecification"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurItemSpecification"
  TypeName = "SIS.PUR.purItemSpecification"
  SortParameterName = "OrderBy"
  SelectMethod = "purItemSpecificationSelectList"
  Runat="server" />
