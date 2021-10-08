<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purReceiptItemProperty.aspx.vb" Inherits="GF_purReceiptItemProperty" title="Maintain List: Receipt Item Property" %>
<asp:Content ID="CPHpurReceiptItemProperty" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurReceiptItemProperty" runat="server" Text="&nbsp;List: Receipt Item Property"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurReceiptItemProperty" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurReceiptItemProperty"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purReceiptItemProperty.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purReceiptItemProperty.aspx"
      ValidationGroup = "purReceiptItemProperty"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurReceiptItemProperty" runat="server" AssociatedUpdatePanelID="UPNLpurReceiptItemProperty" DisplayAfter="100">
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
          <b><asp:Label ID="L_ReceiptNo" runat="server" Text="Receipt No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ReceiptNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ReceiptNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ReceiptNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEReceiptNo"
            BehaviorID="B_ACEReceiptNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ReceiptNoCompletionList"
            TargetControlID="F_ReceiptNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEReceiptNo_Selected"
            OnClientPopulating="ACEReceiptNo_Populating"
            OnClientPopulated="ACEReceiptNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ReceiptLine" runat="server" Text="Receipt Line :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ReceiptLine"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ReceiptLine(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ReceiptLine_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEReceiptLine"
            BehaviorID="B_ACEReceiptLine"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ReceiptLineCompletionList"
            TargetControlID="F_ReceiptLine"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEReceiptLine_Selected"
            OnClientPopulating="ACEReceiptLine_Populating"
            OnClientPopulated="ACEReceiptLine_Populated"
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
    <asp:GridView ID="GVpurReceiptItemProperty" SkinID="gv_silver" runat="server" DataSourceID="ODSpurReceiptItemProperty" DataKeyNames="ReceiptNo,ReceiptLine,ItemCode,ItemCategoryID,CategorySpecID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Receipt No" SortExpression="[PUR_Receipts6].[IsgecGSTIN]">
          <ItemTemplate>
             <asp:Label ID="L_ReceiptNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ReceiptNo") %>' Text='<%# Eval("PUR_Receipts6_IsgecGSTIN") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Receipt Line" SortExpression="[PUR_ReceiptDetails5].[ItemDescription]">
          <ItemTemplate>
             <asp:Label ID="L_ReceiptLine" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ReceiptLine") %>' Text='<%# Eval("PUR_ReceiptDetails5_ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Code" SortExpression="[PUR_Items4].[ItemDescription]">
          <ItemTemplate>
             <asp:Label ID="L_ItemCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemCode") %>' Text='<%# Eval("PUR_Items4_ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Category" SortExpression="[PUR_ItemCategories1].[CategoryName]">
          <ItemTemplate>
             <asp:Label ID="L_ItemCategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemCategoryID") %>' Text='<%# Eval("PUR_ItemCategories1_CategoryName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category Spec" SortExpression="[PUR_ItemCategorySpecs2].[SpecName]">
          <ItemTemplate>
             <asp:Label ID="L_CategorySpecID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CategorySpecID") %>' Text='<%# Eval("PUR_ItemCategorySpecs2_SpecName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="[PUR_ItemCategorySpecValues3].[Data1Value]">
          <ItemTemplate>
             <asp:Label ID="L_SerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SerialNo") %>' Text='<%# Eval("PUR_ItemCategorySpecValues3_Data1Value") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Value Data Type" SortExpression="[PUR_ValueDataTypes7].[ValueDataTypeName]">
          <ItemTemplate>
             <asp:Label ID="L_ValueDataTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ValueDataTypeID") %>' Text='<%# Eval("PUR_ValueDataTypes7_ValueDataTypeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Is Range" SortExpression="[PUR_ReceiptItemProperty].[IsRange]">
          <ItemTemplate>
            <asp:Label ID="LabelIsRange" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IsRange") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Data Value [1]" SortExpression="[PUR_ReceiptItemProperty].[Data1Value]">
          <ItemTemplate>
            <asp:Label ID="LabelData1Value" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Data1Value") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Data Value [2]" SortExpression="[PUR_ReceiptItemProperty].[Data2Value]">
          <ItemTemplate>
            <asp:Label ID="LabelData2Value" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Data2Value") %>'></asp:Label>
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
      ID = "ODSpurReceiptItemProperty"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purReceiptItemProperty"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purReceiptItemPropertySelectList"
      TypeName = "SIS.PUR.purReceiptItemProperty"
      SelectCountMethod = "purReceiptItemPropertySelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ReceiptNo" PropertyName="Text" Name="ReceiptNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ReceiptLine" PropertyName="Text" Name="ReceiptLine" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpurReceiptItemProperty" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ReceiptNo" />
    <asp:AsyncPostBackTrigger ControlID="F_ReceiptLine" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
