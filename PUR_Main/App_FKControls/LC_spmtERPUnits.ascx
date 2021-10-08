<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_spmtERPUnits.ascx.vb" Inherits="LC_spmtERPUnits" %>
<asp:DropDownList 
  ID = "DDLspmtERPUnits"
  DataSourceID = "OdsDdlspmtERPUnits"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorspmtERPUnits"
  Runat = "server" 
  ControlToValidate = "DDLspmtERPUnits"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlspmtERPUnits"
  TypeName = "SIS.SPMT.spmtERPUnits"
  SortParameterName = "OrderBy"
  SelectMethod = "spmtERPUnitsSelectList"
  Runat="server" />
