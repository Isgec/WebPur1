<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purItems.aspx.vb" Inherits="GF_purItems" title="Maintain List: Item Master" %>
<asp:Content ID="CPHpurItems" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurItems" runat="server" Text="&nbsp;List: Item Master"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurItems" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurItems"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purItems.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purItems.aspx"
      ValidationGroup = "purItems"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurItems" runat="server" AssociatedUpdatePanelID="UPNLpurItems" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpurItems" SkinID="gv_silver" runat="server" DataSourceID="ODSpurItems" DataKeyNames="ItemCode">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Code" SortExpression="[PUR_Items].[ItemCode]">
          <ItemTemplate>
            <asp:Label ID="LabelItemCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemCode") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Description" SortExpression="[PUR_Items].[ItemDescription]">
          <ItemTemplate>
            <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM" SortExpression="[SPMT_ERPUnits2].[Description]">
          <ItemTemplate>
             <asp:Label ID="L_UOM" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOM") %>' Text='<%# Eval("SPMT_ERPUnits2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OPB Qty" SortExpression="[PUR_Items].[OPBQty]">
          <ItemTemplate>
            <asp:Label ID="LabelOPBQty" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OPBQty") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="REC Qty" SortExpression="[PUR_Items].[RECQty]">
          <ItemTemplate>
            <asp:Label ID="LabelRECQty" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RECQty") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ISS Qty" SortExpression="[PUR_Items].[ISSQty]">
          <ItemTemplate>
            <asp:Label ID="LabelISSQty" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ISSQty") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BAL Qty" SortExpression="[PUR_Items].[BALQty]">
          <ItemTemplate>
            <asp:Label ID="LabelBALQty" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BALQty") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Category" SortExpression="[PUR_ItemCategories1].[CategoryName]">
          <ItemTemplate>
             <asp:Label ID="L_ItemCategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemCategoryID") %>' Text='<%# Eval("PUR_ItemCategories1_CategoryName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpurItems"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purItems"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purItemsSelectList"
      TypeName = "SIS.PUR.purItems"
      SelectCountMethod = "purItemsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpurItems" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
