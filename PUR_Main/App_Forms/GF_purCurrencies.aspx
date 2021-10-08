<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purCurrencies.aspx.vb" Inherits="GF_purCurrencies" title="Maintain List: Currencies" %>
<asp:Content ID="CPHpurCurrencies" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurCurrencies" runat="server" Text="&nbsp;List: Currencies"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurCurrencies" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurCurrencies"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purCurrencies.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purCurrencies.aspx"
      ValidationGroup = "purCurrencies"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurCurrencies" runat="server" AssociatedUpdatePanelID="UPNLpurCurrencies" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpurCurrencies" SkinID="gv_silver" runat="server" DataSourceID="ODSpurCurrencies" DataKeyNames="CurrencyID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Currency" SortExpression="[PUR_Currencies].[CurrencyID]">
          <ItemTemplate>
            <asp:Label ID="LabelCurrencyID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CurrencyID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Currency Name" SortExpression="[PUR_Currencies].[CurrencyName]">
          <ItemTemplate>
            <asp:Label ID="LabelCurrencyName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CurrencyName") %>'></asp:Label>
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
      ID = "ODSpurCurrencies"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purCurrencies"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purCurrenciesSelectList"
      TypeName = "SIS.PUR.purCurrencies"
      SelectCountMethod = "purCurrenciesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpurCurrencies" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
