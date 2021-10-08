<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purItemSpecification.aspx.vb" Inherits="GF_purItemSpecification" title="Maintain List: Specification Master" %>
<asp:Content ID="CPHpurItemSpecification" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurItemSpecification" runat="server" Text="&nbsp;List: Specification Master"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurItemSpecification" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurItemSpecification"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purItemSpecification.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purItemSpecification.aspx?skip=1"
      ValidationGroup = "purItemSpecification"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurItemSpecification" runat="server" AssociatedUpdatePanelID="UPNLpurItemSpecification" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpurItemSpecification" SkinID="gv_silver" runat="server" DataSourceID="ODSpurItemSpecification" DataKeyNames="SpecID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Spec ID" SortExpression="[PUR_ItemSpecification].[SpecID]">
          <ItemTemplate>
            <asp:Label ID="LabelSpecID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SpecID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Spec Name" SortExpression="[PUR_ItemSpecification].[SpecName]">
          <ItemTemplate>
            <asp:Label ID="LabelSpecName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SpecName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Is Fixed" SortExpression="[PUR_ItemSpecification].[IsFixed]">
          <ItemTemplate>
            <asp:Label ID="LabelIsFixed" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IsFixed") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Is Derived" SortExpression="[PUR_ItemSpecification].[IsDerived]">
          <ItemTemplate>
            <asp:Label ID="LabelIsDerived" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IsDerived") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Validate Value" SortExpression="[PUR_ItemSpecification].[ValidateValue]">
          <ItemTemplate>
            <asp:Label ID="LabelValidateValue" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ValidateValue") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Use Values" SortExpression="[PUR_ItemSpecification].[UseValues]">
          <ItemTemplate>
            <asp:Label ID="LabelUseValues" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UseValues") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Allow User Value" SortExpression="[PUR_ItemSpecification].[AllowUserValue]">
          <ItemTemplate>
            <asp:Label ID="LabelAllowUserValue" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AllowUserValue") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Value Data Type" SortExpression="[PUR_ValueDataTypes1].[ValueDataTypeName]">
          <ItemTemplate>
             <asp:Label ID="L_ValueDataTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ValueDataTypeID") %>' Text='<%# Eval("PUR_ValueDataTypes1_ValueDataTypeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Is Range" SortExpression="[PUR_ItemSpecification].[IsRange]">
          <ItemTemplate>
            <asp:Label ID="LabelIsRange" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IsRange") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpurItemSpecification"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purItemSpecification"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purItemSpecificationSelectList"
      TypeName = "SIS.PUR.purItemSpecification"
      SelectCountMethod = "purItemSpecificationSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpurItemSpecification" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
