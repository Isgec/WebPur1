<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CTL_ItemCategorySpecs.ascx.vb" Inherits="CTL_ItemCategorySpecs" %>
<div style="display:flex;flex-direction:row;justify-content:center;border:1pt solid red;">
  <div style="width:400px;">
    <asp:UpdatePanel ID="UPNLpurItemCategorySpecs" runat="server">
      <ContentTemplate>
        <asp:GridView ID="GVpurItemCategorySpecs" SkinID="gv_silver" runat="server" AllowPaging="false" DataKeyNames="ItemCategoryID,CategorySpecID">
          <Columns>
            <asp:TemplateField HeaderText="Property">
              <ItemTemplate>
                <asp:Label ID="LabelSpecName" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# EVal("SpecName") %>'></asp:Label>
              </ItemTemplate>
              <ItemStyle CssClass="alignleft" />
            <HeaderStyle CssClass="alignleft" Width="300px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Value">
              <ItemTemplate>
                <LGM:CTL_ItemCategorySpecValues
                  ID="F_DefaultValueSerialNo"
                  SelectedValue='<%# Bind("ActualSelectedValue") %>'
                  OrderBy="DisplayField"
                  DataTextField="DDValue"
                  DataValueField="PrimaryKey"
                  ItemCategoryID='<%# EVal("ItemCategoryID") %>'
                  CategorySpecID='<%# EVal("CategorySpecID") %>'
                  IncludeDefault="true"
                  DefaultText="-- Select --"
                  Width="200px"
                  CssClass="myddl"
                  Enabled='<%# Not EVal("IsFixed") %>'
                  Runat="Server" />
                </ItemTemplate>
              <ItemStyle CssClass="alignleft" />
            <HeaderStyle CssClass="alignleft" Width="200px" />
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="Item Properties"></asp:Label>
          </EmptyDataTemplate>
        </asp:GridView>
<%--        <asp:ObjectDataSource 
          ID = "ODSpurItemCategorySpecs"
          DataObjectTypeName = "SIS.PUR.purItemCategorySpecs"
          OldValuesParameterFormatString = "original_{0}"
          SelectMethod = "GetItemCategorySpecs"
          TypeName = "SIS.PUR.purItemCategorySpecs"
          runat = "server">
          <SelectParameters>
            <asp:Parameter Name="ItemCode" Type="String" DefaultValue="0" />
            <asp:Parameter Name="IndentNo" Type="String" DefaultValue="0" />
            <asp:Parameter Name="IndentLine" Type="String" DefaultValue="0" />
            <asp:Parameter Name="OrderNo" Type="String" DefaultValue="0" />
            <asp:Parameter Name="OrderLine" Type="String" DefaultValue="0" />
          </SelectParameters>
        </asp:ObjectDataSource>--%>
      </ContentTemplate>
      <Triggers>
        <asp:AsyncPostBackTrigger ControlID="GVpurItemCategorySpecs" EventName="PageIndexChanged" />
      </Triggers>
    </asp:UpdatePanel>
  </div>
</div>
