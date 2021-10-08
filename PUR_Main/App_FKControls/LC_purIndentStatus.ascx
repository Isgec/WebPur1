<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purIndentStatus.ascx.vb" Inherits="LC_purIndentStatus" %>
<asp:DropDownList 
  ID = "DDLpurIndentStatus"
  DataSourceID = "OdsDdlpurIndentStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurIndentStatus"
  Runat = "server" 
  ControlToValidate = "DDLpurIndentStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurIndentStatus"
  TypeName = "SIS.PUR.purIndentStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "purIndentStatusSelectList"
  Runat="server" />
