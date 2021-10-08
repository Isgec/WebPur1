<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purPOStatus.ascx.vb" Inherits="LC_purPOStatus" %>
<asp:DropDownList 
  ID = "DDLpurPOStatus"
  DataSourceID = "OdsDdlpurPOStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurPOStatus"
  Runat = "server" 
  ControlToValidate = "DDLpurPOStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurPOStatus"
  TypeName = "SIS.PUR.purPOStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "purPOStatusSelectList"
  Runat="server" />
