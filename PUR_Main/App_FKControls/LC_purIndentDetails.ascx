<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purIndentDetails.ascx.vb" Inherits="LC_purIndentDetails" %>
<asp:DropDownList 
  ID = "DDLpurIndentDetails"
  DataSourceID = "OdsDdlpurIndentDetails"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurIndentDetails"
  Runat = "server" 
  ControlToValidate = "DDLpurIndentDetails"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurIndentDetails"
  TypeName = "SIS.PUR.purIndentDetails"
  SortParameterName = "OrderBy"
  SelectMethod = "purIndentDetailsSelectList"
  Runat="server" />
