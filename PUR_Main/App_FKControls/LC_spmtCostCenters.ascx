<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_spmtCostCenters.ascx.vb" Inherits="LC_spmtCostCenters" %>
<asp:DropDownList 
  ID = "DDLspmtCostCenters"
  DataSourceID = "OdsDdlspmtCostCenters"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorspmtCostCenters"
  Runat = "server" 
  ControlToValidate = "DDLspmtCostCenters"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlspmtCostCenters"
  TypeName = "SIS.SPMT.spmtCostCenters"
  SortParameterName = "OrderBy"
  SelectMethod = "spmtCostCentersSelectList"
  Runat="server" />
