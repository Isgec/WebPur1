<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purItemSpecValues.ascx.vb" Inherits="LC_purItemSpecValues" %>
<asp:DropDownList 
  ID = "DDLpurItemSpecValues"
  DataSourceID = "OdsDdlpurItemSpecValues"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurItemSpecValues"
  Runat = "server" 
  ControlToValidate = "DDLpurItemSpecValues"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurItemSpecValues"
  TypeName = "SIS.PUR.purItemSpecValues"
  SortParameterName = "OrderBy"
  SelectMethod = "purItemSpecValuesSelectList"
  Runat="server" />
