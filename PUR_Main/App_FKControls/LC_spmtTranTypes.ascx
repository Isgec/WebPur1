<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_spmtTranTypes.ascx.vb" Inherits="LC_spmtTranTypes" %>
<asp:DropDownList 
  ID = "DDLspmtTranTypes"
  DataSourceID = "OdsDdlspmtTranTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorspmtTranTypes"
  Runat = "server" 
  ControlToValidate = "DDLspmtTranTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlspmtTranTypes"
  TypeName = "SIS.SPMT.spmtTranTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "spmtTranTypesSelectList"
  Runat="server" />
