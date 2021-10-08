<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purValueDataTypes.aspx.vb" Inherits="GF_purValueDataTypes" title="Maintain List: Data Types" %>
<asp:Content ID="CPHpurValueDataTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurValueDataTypes" runat="server" Text="&nbsp;List: Data Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurValueDataTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurValueDataTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purValueDataTypes.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purValueDataTypes.aspx"
      ValidationGroup = "purValueDataTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurValueDataTypes" runat="server" AssociatedUpdatePanelID="UPNLpurValueDataTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpurValueDataTypes" SkinID="gv_silver" runat="server" DataSourceID="ODSpurValueDataTypes" DataKeyNames="ValueDataTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Value Data Type ID" SortExpression="[PUR_ValueDataTypes].[ValueDataTypeID]">
          <ItemTemplate>
            <asp:Label ID="LabelValueDataTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ValueDataTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Value Data Type Name" SortExpression="[PUR_ValueDataTypes].[ValueDataTypeName]">
          <ItemTemplate>
            <asp:Label ID="LabelValueDataTypeName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ValueDataTypeName") %>'></asp:Label>
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
      ID = "ODSpurValueDataTypes"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purValueDataTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purValueDataTypesSelectList"
      TypeName = "SIS.PUR.purValueDataTypes"
      SelectCountMethod = "purValueDataTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpurValueDataTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
