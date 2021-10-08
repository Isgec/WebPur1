<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purPurchaseTypes.ascx.vb" Inherits="LC_purPurchaseTypes" %>
<asp:DropDownList 
  ID = "DDLpurPurchaseTypes"
  DataSourceID = "OdsDdlpurPurchaseTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurPurchaseTypes"
  Runat = "server" 
  ControlToValidate = "DDLpurPurchaseTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurPurchaseTypes"
  TypeName = "SIS.PUR.purPurchaseTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "purPurchaseTypesSelectList"
  Runat="server" />
