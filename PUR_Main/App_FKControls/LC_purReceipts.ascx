<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purReceipts.ascx.vb" Inherits="LC_purReceipts" %>
<asp:DropDownList 
  ID = "DDLpurReceipts"
  DataSourceID = "OdsDdlpurReceipts"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurReceipts"
  Runat = "server" 
  ControlToValidate = "DDLpurReceipts"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurReceipts"
  TypeName = "SIS.PUR.purReceipts"
  SortParameterName = "OrderBy"
  SelectMethod = "purReceiptsSelectList"
  Runat="server" />
