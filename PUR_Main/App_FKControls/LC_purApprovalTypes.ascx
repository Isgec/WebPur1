<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purApprovalTypes.ascx.vb" Inherits="LC_purApprovalTypes" %>
<asp:DropDownList 
  ID = "DDLpurApprovalTypes"
  DataSourceID = "OdsDdlpurApprovalTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurApprovalTypes"
  Runat = "server" 
  ControlToValidate = "DDLpurApprovalTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurApprovalTypes"
  TypeName = "SIS.PUR.purApprovalTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "purApprovalTypesSelectList"
  Runat="server" />
