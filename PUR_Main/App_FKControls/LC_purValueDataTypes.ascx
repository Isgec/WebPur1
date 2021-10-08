<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purValueDataTypes.ascx.vb" Inherits="LC_purValueDataTypes" %>
<asp:DropDownList 
  ID = "DDLpurValueDataTypes"
  DataSourceID = "OdsDdlpurValueDataTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurValueDataTypes"
  Runat = "server" 
  ControlToValidate = "DDLpurValueDataTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurValueDataTypes"
  TypeName = "SIS.PUR.purValueDataTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "purValueDataTypesSelectList"
  Runat="server" />
