<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_purTaxCodes.ascx.vb" Inherits="LC_purTaxCodes" %>
<asp:UpdatePanel ID="updpnl" runat="server">
  <ContentTemplate>
    <asp:DropDownList
      ID="DDLpurTaxCodes"
      DataSourceID="OdsDdlpurTaxCodes"
      AppendDataBoundItems="true"
      SkinID="DropDownSkin"
      Width="200px"
      CssClass="myddl"
      AutoPostBack="true"
      runat="server" />
    <asp:RequiredFieldValidator
      ID="RequiredFieldValidatorpurTaxCodes"
      runat="server"
      ControlToValidate="DDLpurTaxCodes"
      ErrorMessage="<div class='errorLG'>Required!</div>"
      Display="Dynamic"
      EnableClientScript="true"
      ValidationGroup="none"
      SetFocusOnError="true" />
    <asp:ObjectDataSource
      ID="OdsDdlpurTaxCodes"
      TypeName="SIS.PUR.purTaxCodes"
      SortParameterName="OrderBy"
      SelectMethod="purTaxCodesSelectList"
      runat="server" />
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="DDLpurTaxCodes" EventName="SelectedIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
