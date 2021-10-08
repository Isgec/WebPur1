<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purAprTypEmpLimit.aspx.vb" Inherits="GF_purAprTypEmpLimit" title="Maintain List: Approver Limit" %>
<asp:Content ID="CPHpurAprTypEmpLimit" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurAprTypEmpLimit" runat="server" Text="&nbsp;List: Approver Limit"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurAprTypEmpLimit" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurAprTypEmpLimit"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purAprTypEmpLimit.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purAprTypEmpLimit.aspx"
      ValidationGroup = "purAprTypEmpLimit"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurAprTypEmpLimit" runat="server" AssociatedUpdatePanelID="UPNLpurAprTypEmpLimit" DisplayAfter="100">
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
          <b><asp:Label ID="L_CardNo" runat="server" Text="Card No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CardNo"
            CssClass = "myfktxt"
            Width="72px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_CardNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CardNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECardNo"
            BehaviorID="B_ACECardNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CardNoCompletionList"
            TargetControlID="F_CardNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACECardNo_Selected"
            OnClientPopulating="ACECardNo_Populating"
            OnClientPopulated="ACECardNo_Populated"
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
    <asp:GridView ID="GVpurAprTypEmpLimit" SkinID="gv_silver" runat="server" DataSourceID="ODSpurAprTypEmpLimit" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SerialNo" SortExpression="[PUR_AprTypEmpLimit].[SerialNo]">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approval Type" SortExpression="[PUR_ApprovalTypes2].[AprDescription]">
          <ItemTemplate>
             <asp:Label ID="L_AprTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("AprTypeID") %>' Text='<%# Eval("PUR_ApprovalTypes2_AprDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Card No" SortExpression="[aspnet_users1].[UserFullName]">
          <ItemTemplate>
             <asp:Label ID="L_CardNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CardNo") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approval Limit" SortExpression="[PUR_AprTypEmpLimit].[ApprovalLimit]">
          <ItemTemplate>
            <asp:Label ID="LabelApprovalLimit" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApprovalLimit") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="From Date" SortExpression="[PUR_AprTypEmpLimit].[FromDate]">
          <ItemTemplate>
            <asp:Label ID="LabelFromDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FromDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="To Date" SortExpression="[PUR_AprTypEmpLimit].[ToDate]">
          <ItemTemplate>
            <asp:Label ID="LabelToDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ToDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Extend">
          <ItemTemplate>
            <asp:ImageButton ID="cmdExtend" ValidationGroup='<%# "Extend" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ExtendWFVisible") %>' Enabled='<%# EVal("ExtendWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Extend" SkinID="Extend" OnClientClick='<%# "return Page_ClientValidate(""Extend" & Container.DataItemIndex & """) && confirm(""Extend record ?"");" %>' CommandName="ExtendWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Close">
          <ItemTemplate>
            <asp:ImageButton ID="cmdClose" ValidationGroup='<%# "Close" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CloseWFVisible") %>' Enabled='<%# EVal("CloseWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Close" SkinID="Close" OnClientClick='<%# "return Page_ClientValidate(""Close" & Container.DataItemIndex & """) && confirm(""Close record ?"");" %>' CommandName="CloseWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSpurAprTypEmpLimit"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purAprTypEmpLimit"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purAprTypEmpLimitSelectList"
      TypeName = "SIS.PUR.purAprTypEmpLimit"
      SelectCountMethod = "purAprTypEmpLimitSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_CardNo" PropertyName="Text" Name="CardNo" Type="String" Size="8" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpurAprTypEmpLimit" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_CardNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
