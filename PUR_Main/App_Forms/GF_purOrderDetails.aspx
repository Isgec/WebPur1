<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purOrderDetails.aspx.vb" Inherits="GF_purOrderDetails" title="Maintain List: Order Items" %>
<asp:Content ID="CPHpurOrderDetails" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurOrderDetails" runat="server" Text="&nbsp;List: Order Items"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurOrderDetails" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurOrderDetails"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purOrderDetails.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purOrderDetails.aspx?skip=1"
      AddPostBack = "True"
      ValidationGroup = "purOrderDetails"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurOrderDetails" runat="server" AssociatedUpdatePanelID="UPNLpurOrderDetails" DisplayAfter="100">
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
          <b><asp:Label ID="L_OrderRev" runat="server" Text="Order Rev :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_OrderRev"
            Text=""
            Width="88px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEOrderRev"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_OrderRev" />
          <AJX:MaskedEditValidator 
            ID = "MEVOrderRev"
            runat = "server"
            ControlToValidate = "F_OrderRev"
            ControlExtender = "MEEOrderRev"
            InvalidValueMessage = "*"
            EmptyValueMessage = ""
            EmptyValueBlurredText = ""
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_OrderNo" runat="server" Text="Order No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_OrderNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_OrderNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_OrderNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEOrderNo"
            BehaviorID="B_ACEOrderNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="OrderNoCompletionList"
            TargetControlID="F_OrderNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEOrderNo_Selected"
            OnClientPopulating="ACEOrderNo_Populating"
            OnClientPopulated="ACEOrderNo_Populated"
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
    <asp:GridView ID="GVpurOrderDetails" SkinID="gv_silver" runat="server" DataSourceID="ODSpurOrderDetails" DataKeyNames="OrderNo,OrderLine,OrderRev">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Order Line" SortExpression="[PUR_OrderDetails].[OrderLine]">
          <ItemTemplate>
            <asp:Label ID="LabelOrderLine" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OrderLine") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tran Type" SortExpression="[SPMT_TranTypes14].[Description]">
          <ItemTemplate>
             <asp:Label ID="L_TranTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TranTypeID") %>' Text='<%# Eval("SPMT_TranTypes14_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Code" SortExpression="[PUR_Items7].[ItemDescription]">
          <ItemTemplate>
             <asp:Label ID="L_ItemCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemCode") %>' Text='<%# Eval("PUR_Items7_ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM" SortExpression="[SPMT_ERPUnits12].[Description]">
          <ItemTemplate>
             <asp:Label ID="L_UOM" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOM") %>' Text='<%# Eval("SPMT_ERPUnits12_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Description" SortExpression="[PUR_OrderDetails].[ItemDescription]">
          <ItemTemplate>
            <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity" SortExpression="[PUR_OrderDetails].[Quantity]">
          <ItemTemplate>
            <asp:Label ID="LabelQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Quantity") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Price" SortExpression="[PUR_OrderDetails].[Price]">
          <ItemTemplate>
            <asp:Label ID="LabelPrice" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Price") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delivery Date" SortExpression="[PUR_OrderDetails].[DeliveryDate]">
          <ItemTemplate>
            <asp:Label ID="LabelDeliveryDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DeliveryDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
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
      ID = "ODSpurOrderDetails"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purOrderDetails"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_purOrderDetailsSelectList"
      TypeName = "SIS.PUR.purOrderDetails"
      SelectCountMethod = "purOrderDetailsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_OrderNo" PropertyName="Text" Name="OrderNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_OrderRev" PropertyName="Text" Name="OrderRev" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpurOrderDetails" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_OrderNo" />
    <asp:AsyncPostBackTrigger ControlID="F_OrderRev" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
