<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purReceiptStatus.ascx.vb" Inherits="LC_purReceiptStatus" %>
<asp:DropDownList 
  ID = "DDLpurReceiptStatus"
  DataSourceID = "OdsDdlpurReceiptStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurReceiptStatus"
  Runat = "server" 
  ControlToValidate = "DDLpurReceiptStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurReceiptStatus"
  TypeName = "SIS.PUR.purReceiptStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "purReceiptStatusSelectList"
  Runat="server" />
