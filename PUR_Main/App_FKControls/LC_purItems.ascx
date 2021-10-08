<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purItems.ascx.vb" Inherits="LC_purItems" %>
<asp:DropDownList 
  ID = "DDLpurItems"
  DataSourceID = "OdsDdlpurItems"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurItems"
  Runat = "server" 
  ControlToValidate = "DDLpurItems"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurItems"
  TypeName = "SIS.PUR.purItems"
  SortParameterName = "OrderBy"
  SelectMethod = "purItemsSelectList"
  Runat="server" />
