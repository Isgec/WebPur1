<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purApprovalTypes.aspx.vb" Inherits="GF_purApprovalTypes" title="Maintain List: Approval Types" %>
<asp:Content ID="CPHpurApprovalTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurApprovalTypes" runat="server" Text="&nbsp;List: Approval Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurApprovalTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurApprovalTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purApprovalTypes.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purApprovalTypes.aspx"
      ValidationGroup = "purApprovalTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurApprovalTypes" runat="server" AssociatedUpdatePanelID="UPNLpurApprovalTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpurApprovalTypes" SkinID="gv_silver" runat="server" DataSourceID="ODSpurApprovalTypes" DataKeyNames="AprTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approval Type ID" SortExpression="[PUR_ApprovalTypes].[AprTypeID]">
          <ItemTemplate>
            <asp:Label ID="LabelAprTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AprTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="[PUR_ApprovalTypes].[AprDescription]">
          <ItemTemplate>
            <asp:Label ID="LabelAprDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AprDescription") %>'></asp:Label>
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
      ID = "ODSpurApprovalTypes"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purApprovalTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purApprovalTypesSelectList"
      TypeName = "SIS.PUR.purApprovalTypes"
      SelectCountMethod = "purApprovalTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpurApprovalTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
