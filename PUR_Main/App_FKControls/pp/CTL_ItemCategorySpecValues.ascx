<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CTL_ItemCategorySpecValues.ascx.vb" Inherits="CTL_ItemCategorySpecValues" %>
<asp:DropDownList 
  ID = "DDLpurItemCategorySpecValues"
  DataSourceID = "OdsDdlpurItemCategorySpecValues"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorpurItemCategorySpecValues"
  Runat = "server" 
  ControlToValidate = "DDLpurItemCategorySpecValues"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlpurItemCategorySpecValues"
  TypeName = "SIS.PUR.purItemCategorySpecValues"
  SelectMethod = "purItemCategorySpecValuesSelectList"
  Runat="server">
  <SelectParameters>
    <asp:Parameter Name="ItemCategoryID" Type="Int32" DefaultValue="0" />
    <asp:Parameter Name="CategorySpecID" Type="Int32" DefaultValue="0" />
  </SelectParameters>
</asp:ObjectDataSource>
