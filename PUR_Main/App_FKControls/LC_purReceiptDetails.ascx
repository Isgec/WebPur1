<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purReceiptDetails.ascx.vb" Inherits="LC_purReceiptDetails" %>
<asp:DropDownList 
  ID = "DDLpurReceiptDetails"
  DataSourceID = "OdsDdlpurReceiptDetails"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurReceiptDetails"
  Runat = "server" 
  ControlToValidate = "DDLpurReceiptDetails"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurReceiptDetails"
  TypeName = "SIS.PUR.purReceiptDetails"
  SortParameterName = "OrderBy"
  SelectMethod = "purReceiptDetailsSelectList"
  Runat="server" />
