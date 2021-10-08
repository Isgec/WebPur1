<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purIndents.ascx.vb" Inherits="LC_purIndents" %>
<asp:DropDownList 
  ID = "DDLpurIndents"
  DataSourceID = "OdsDdlpurIndents"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurIndents"
  Runat = "server" 
  ControlToValidate = "DDLpurIndents"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurIndents"
  TypeName = "SIS.PUR.purIndents"
  SortParameterName = "OrderBy"
  SelectMethod = "purIndentsSelectList"
  Runat="server" />
