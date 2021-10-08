<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purPurchaseTypes.aspx.vb" Inherits="GF_purPurchaseTypes" title="Maintain List: Purchase Types" %>
<asp:Content ID="CPHpurPurchaseTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurPurchaseTypes" runat="server" Text="&nbsp;List: Purchase Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurPurchaseTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurPurchaseTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purPurchaseTypes.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purPurchaseTypes.aspx"
      ValidationGroup = "purPurchaseTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurPurchaseTypes" runat="server" AssociatedUpdatePanelID="UPNLpurPurchaseTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpurPurchaseTypes" SkinID="gv_silver" runat="server" DataSourceID="ODSpurPurchaseTypes" DataKeyNames="PurchaseTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Purchase Type" SortExpression="[PUR_PurchaseTypes].[PurchaseTypeID]">
          <ItemTemplate>
            <asp:Label ID="LabelPurchaseTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PurchaseTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="[PUR_PurchaseTypes].[Description]">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpurPurchaseTypes"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purPurchaseTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purPurchaseTypesSelectList"
      TypeName = "SIS.PUR.purPurchaseTypes"
      SelectCountMethod = "purPurchaseTypesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpurPurchaseTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
