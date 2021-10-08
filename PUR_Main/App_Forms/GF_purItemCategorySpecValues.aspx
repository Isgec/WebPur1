<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purItemCategorySpecValues.aspx.vb" Inherits="GF_purItemCategorySpecValues" title="Maintain List: Category Spec Values" %>
<asp:Content ID="CPHpurItemCategorySpecValues" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurItemCategorySpecValues" runat="server" Text="&nbsp;List: Category Spec Values"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurItemCategorySpecValues" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurItemCategorySpecValues"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purItemCategorySpecValues.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purItemCategorySpecValues.aspx"
      AddPostBack = "True"
      ValidationGroup = "purItemCategorySpecValues"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurItemCategorySpecValues" runat="server" AssociatedUpdatePanelID="UPNLpurItemCategorySpecValues" DisplayAfter="100">
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
          <b><asp:Label ID="L_ItemCategoryID" runat="server" Text="Item Category :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ItemCategoryID"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ItemCategoryID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ItemCategoryID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEItemCategoryID"
            BehaviorID="B_ACEItemCategoryID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ItemCategoryIDCompletionList"
            TargetControlID="F_ItemCategoryID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEItemCategoryID_Selected"
            OnClientPopulating="ACEItemCategoryID_Populating"
            OnClientPopulated="ACEItemCategoryID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CategorySpecID" runat="server" Text="Category Spec :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CategorySpecID"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_CategorySpecID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CategorySpecID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECategorySpecID"
            BehaviorID="B_ACECategorySpecID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CategorySpecIDCompletionList"
            TargetControlID="F_CategorySpecID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACECategorySpecID_Selected"
            OnClientPopulating="ACECategorySpecID_Populating"
            OnClientPopulated="ACECategorySpecID_Populated"
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
    <asp:GridView ID="GVpurItemCategorySpecValues" SkinID="gv_silver" runat="server" DataSourceID="ODSpurItemCategorySpecValues" DataKeyNames="ItemCategoryID,CategorySpecID,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
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
        <asp:TemplateField HeaderText="Serial No" SortExpression="[PUR_ItemCategorySpecValues].[SerialNo]">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Value Data Type" SortExpression="[PUR_ValueDataTypes3].[ValueDataTypeName]">
          <ItemTemplate>
             <asp:Label ID="L_ValueDataTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ValueDataTypeID") %>' Text='<%# Eval("PUR_ValueDataTypes3_ValueDataTypeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Is Range" SortExpression="[PUR_ItemCategorySpecValues].[IsRange]">
          <ItemTemplate>
            <asp:Label ID="LabelIsRange" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IsRange") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Data Value [1]" SortExpression="[PUR_ItemCategorySpecValues].[Data1Value]">
          <ItemTemplate>
            <asp:Label ID="LabelData1Value" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Data1Value") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Data Value [2]" SortExpression="[PUR_ItemCategorySpecValues].[Data2Value]">
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
      ID = "ODSpurItemCategorySpecValues"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purItemCategorySpecValues"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purItemCategorySpecValuesSelectList"
      TypeName = "SIS.PUR.purItemCategorySpecValues"
      SelectCountMethod = "purItemCategorySpecValuesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ItemCategoryID" PropertyName="Text" Name="ItemCategoryID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_CategorySpecID" PropertyName="Text" Name="CategorySpecID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpurItemCategorySpecValues" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ItemCategoryID" />
    <asp:AsyncPostBackTrigger ControlID="F_CategorySpecID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
