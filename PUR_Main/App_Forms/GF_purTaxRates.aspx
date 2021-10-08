<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purTaxRates.aspx.vb" Inherits="GF_purTaxRates" title="Maintain List: Tax Rates" %>
<asp:Content ID="CPHpurTaxRates" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurTaxRates" runat="server" Text="&nbsp;List: Tax Rates"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurTaxRates" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurTaxRates"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purTaxRates.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purTaxRates.aspx"
      AddPostBack = "True"
      ValidationGroup = "purTaxRates"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurTaxRates" runat="server" AssociatedUpdatePanelID="UPNLpurTaxRates" DisplayAfter="100">
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
          <b><asp:Label ID="L_TaxCode" runat="server" Text="Tax Code :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_TaxCode"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_TaxCode(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_TaxCode_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETaxCode"
            BehaviorID="B_ACETaxCode"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TaxCodeCompletionList"
            TargetControlID="F_TaxCode"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACETaxCode_Selected"
            OnClientPopulating="ACETaxCode_Populating"
            OnClientPopulated="ACETaxCode_Populated"
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
    <asp:GridView ID="GVpurTaxRates" SkinID="gv_silver" runat="server" DataSourceID="ODSpurTaxRates" DataKeyNames="TaxCode,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tax Code" SortExpression="[PUR_TaxCodes1].[TaxDescription]">
          <ItemTemplate>
             <asp:Label ID="L_TaxCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TaxCode") %>' Text='<%# Eval("PUR_TaxCodes1_TaxDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="[PUR_TaxRates].[SerialNo]">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="From Date" SortExpression="[PUR_TaxRates].[FromDate]">
          <ItemTemplate>
            <asp:Label ID="LabelFromDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FromDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="To Date" SortExpression="[PUR_TaxRates].[ToDate]">
          <ItemTemplate>
            <asp:Label ID="LabelToDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ToDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IGST Rate" SortExpression="[PUR_TaxRates].[TaxRate]">
          <ItemTemplate>
            <asp:Label ID="LabelTaxRate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TaxRate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CGST Rate" SortExpression="[PUR_TaxRates].[CGSTRate]">
          <ItemTemplate>
            <asp:Label ID="LabelCGSTRate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CGSTRate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SGST Rate" SortExpression="[PUR_TaxRates].[SGSTRate]">
          <ItemTemplate>
            <asp:Label ID="LabelSGSTRate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SGSTRate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cess Rate" SortExpression="[PUR_TaxRates].[CessRate]">
          <ItemTemplate>
            <asp:Label ID="LabelCessRate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CessRate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TCS Rate" SortExpression="[PUR_TaxRates].[TCSRate]">
          <ItemTemplate>
            <asp:Label ID="LabelTCSRate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TCSRate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Revise">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRevise" ValidationGroup='<%# "Revise" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ReviseWFVisible") %>' Enabled='<%# EVal("ReviseWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Revise" SkinID="Revise" OnClientClick='<%# "return Page_ClientValidate(""Revise" & Container.DataItemIndex & """) && confirm(""Revise record ?"");" %>' CommandName="ReviseWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSpurTaxRates"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purTaxRates"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purTaxRatesSelectList"
      TypeName = "SIS.PUR.purTaxRates"
      SelectCountMethod = "purTaxRatesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TaxCode" PropertyName="Text" Name="TaxCode" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpurTaxRates" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_TaxCode" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
