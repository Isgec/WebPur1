<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purIndentStatus.aspx.vb" Inherits="GF_purIndentStatus" title="Maintain List: Indent States" %>
<asp:Content ID="CPHpurIndentStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurIndentStatus" runat="server" Text="&nbsp;List: Indent States"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurIndentStatus" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurIndentStatus"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purIndentStatus.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purIndentStatus.aspx"
      ValidationGroup = "purIndentStatus"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurIndentStatus" runat="server" AssociatedUpdatePanelID="UPNLpurIndentStatus" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpurIndentStatus" SkinID="gv_silver" runat="server" DataSourceID="ODSpurIndentStatus" DataKeyNames="StatusID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="StatusID" SortExpression="[PUR_IndentStatus].[StatusID]">
          <ItemTemplate>
            <asp:Label ID="LabelStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("StatusID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="[PUR_IndentStatus].[Description]">
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
      ID = "ODSpurIndentStatus"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purIndentStatus"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purIndentStatusSelectList"
      TypeName = "SIS.PUR.purIndentStatus"
      SelectCountMethod = "purIndentStatusSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpurIndentStatus" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
