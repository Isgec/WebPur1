<%@ Page Language="VB" MasterPageFile="~/PlaneMaster.master" AutoEventWireup="False" CodeFile="GF_purItemCategorySpecs.aspx.vb" Inherits="GF_purItemCategorySpecs" title="Maintain List: Category Spec" %>
<asp:Content ID="CPHpurItemCategorySpecs" ContentPlaceHolderID="cph1" Runat="Server">
<asp:UpdatePanel ID="UPNLpurItemCategorySpecs" runat="server">
  <ContentTemplate>
    <asp:GridView ID="GVpurItemCategorySpecs" SkinID="gv_silver" runat="server" AllowPaging="false" DataSourceID="ODSpurItemCategorySpecs" DataKeyNames="ItemCategoryID,CategorySpecID">
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
              SelectedValue='<%# Bind("DefaultValueSerialNo") %>'
              OrderBy="DisplayField"
              DataTextField="DDValue"
              DataValueField="PrimaryKey"
              ItemCategoryID='<%# EVal("ItemCategoryID") %>'
              CategorySpecID='<%# EVal("CategorySpecID") %>'
              IncludeDefault="true"
              DefaultText="-- Select --"
              Width="200px"
              CssClass="myddl"
              Runat="Server" />
            </ItemTemplate>
          <ItemStyle CssClass="alignleft" />
        <HeaderStyle CssClass="alignleft" Width="200px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpurItemCategorySpecs"
      DataObjectTypeName = "SIS.PUR.purItemCategorySpecs"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "GetItemCategorySpecs"
      TypeName = "SIS.PUR.purItemCategorySpecs"
      runat = "server">
      <SelectParameters >
        <asp:QueryStringParameter QueryStringField="ItemCode" Name="ItemCode" Type="String" DefaultValue="0" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
      <asp:Button ID="cmdSave" runat="server" CommandName="Insert" Font-Size="14px" Text="Submit" CssClass="nt-but-primary" ValidationGroup="xDmsFolderAuthorizations" />
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpurItemCategorySpecs" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
  <script>
    parent.lgMessageBox.resizeFrame(440,510);
  </script>
</asp:Content>
