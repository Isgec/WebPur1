<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purItemCategories.aspx.vb" Inherits="GF_purItemCategories" title="Maintain List: Item Categories" %>
<asp:Content ID="CPHpurItemCategories" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurItemCategories" runat="server" Text="&nbsp;List: Item Categories"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurItemCategories" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurItemCategories"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purItemCategories.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purItemCategories.aspx?skip=1"
      ValidationGroup = "purItemCategories"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurItemCategories" runat="server" AssociatedUpdatePanelID="UPNLpurItemCategories" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpurItemCategories" SkinID="gv_silver" runat="server" DataSourceID="ODSpurItemCategories" DataKeyNames="ItemCategoryID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Category" SortExpression="[PUR_ItemCategories].[ItemCategoryID]">
          <ItemTemplate>
            <asp:Label ID="LabelItemCategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemCategoryID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category Name" SortExpression="[PUR_ItemCategories].[CategoryName]">
          <ItemTemplate>
            <asp:Label ID="LabelCategoryName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CategoryName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Validate Category Values" SortExpression="[PUR_ItemCategories].[ValidateCategoryValues]">
          <ItemTemplate>
            <asp:Label ID="LabelValidateCategoryValues" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ValidateCategoryValues") %>'></asp:Label>
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
      ID = "ODSpurItemCategories"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purItemCategories"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purItemCategoriesSelectList"
      TypeName = "SIS.PUR.purItemCategories"
      SelectCountMethod = "purItemCategoriesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpurItemCategories" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
