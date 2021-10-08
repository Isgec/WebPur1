<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purIndentDetails.aspx.vb" Inherits="GF_purIndentDetails" title="Maintain List: Indent Items" %>
<asp:Content ID="CPHpurIndentDetails" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurIndentDetails" runat="server" Text="&nbsp;List: Indent Items"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurIndentDetails" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurIndentDetails"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purIndentDetails.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purIndentDetails.aspx?skip=1"
      AddPostBack = "True"
      ValidationGroup = "purIndentDetails"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurIndentDetails" runat="server" AssociatedUpdatePanelID="UPNLpurIndentDetails" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IndentNo" runat="server" Text="Indent No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_IndentNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_IndentNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_IndentNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEIndentNo"
            BehaviorID="B_ACEIndentNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="IndentNoCompletionList"
            TargetControlID="F_IndentNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEIndentNo_Selected"
            OnClientPopulating="ACEIndentNo_Populating"
            OnClientPopulated="ACEIndentNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVpurIndentDetails" SkinID="gv_silver" runat="server" DataSourceID="ODSpurIndentDetails" DataKeyNames="IndentNo,IndentLine">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Indent Line" SortExpression="[PUR_IndentDetails].[IndentLine]">
          <ItemTemplate>
            <asp:Label ID="LabelIndentLine" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndentLine") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Code" SortExpression="[PUR_Items8].[ItemDescription]">
          <ItemTemplate>
             <asp:Label ID="L_ItemCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemCode") %>' Text='<%# Eval("PUR_Items8_ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM" SortExpression="[SPMT_ERPUnits12].[Description]">
          <ItemTemplate>
             <asp:Label ID="L_UOM" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOM") %>' Text='<%# Eval("SPMT_ERPUnits12_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Description" SortExpression="[PUR_IndentDetails].[ItemDescription]">
          <ItemTemplate>
            <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity" SortExpression="[PUR_IndentDetails].[Quantity]">
          <ItemTemplate>
            <asp:Label ID="LabelQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Quantity") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Price" SortExpression="[PUR_IndentDetails].[Price]">
          <ItemTemplate>
            <asp:Label ID="LabelPrice" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Price") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Order No" SortExpression="[PUR_IndentDetails].[OrderNo]">
          <ItemTemplate>
            <asp:Label ID="LabelOrderNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OrderNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Order Line" SortExpression="[PUR_IndentDetails].[OrderLine]">
          <ItemTemplate>
            <asp:Label ID="LabelOrderLine" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OrderLine") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Ordered Quantity" SortExpression="[PUR_IndentDetails].[OrderedQuantity]">
          <ItemTemplate>
            <asp:Label ID="LabelOrderedQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OrderedQuantity") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Property">
          <ItemTemplate>
            <asp:ImageButton ID="cmdProperty" ValidationGroup='<%# "Property" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("PropertyWFVisible") %>' Enabled='<%# EVal("PropertyWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Property" SkinID="Property" OnClientClick='<%# "return Page_ClientValidate(""Property" & Container.DataItemIndex & """) && confirm(""Property record ?"");" %>' CommandName="PropertyWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpurIndentDetails"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purIndentDetails"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_purIndentDetailsSelectList"
      TypeName = "SIS.PUR.purIndentDetails"
      SelectCountMethod = "purIndentDetailsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_IndentNo" PropertyName="Text" Name="IndentNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpurIndentDetails" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_IndentNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
