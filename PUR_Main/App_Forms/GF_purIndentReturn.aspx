<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purIndentReturn.aspx.vb" Inherits="GF_purIndentReturn" title="Maintain List: Return Indent" %>
<asp:Content ID="CPHpurIndentReturn" ContentPlaceHolderID="cph1" runat="Server">
  <LGM:LGMessageBox ID="LGMessage1" runat="server" />
  <div class="ui-widget-content page">
    <div class="caption">
      <asp:Label ID="LabelpurIndentReturn" runat="server" Text="&nbsp;List: Return Indent"></asp:Label>
    </div>
    <div class="pagedata">
      <asp:UpdatePanel ID="UPNLpurIndentReturn" runat="server">
        <ContentTemplate>
          <table width="100%">
            <tr>
              <td class="sis_formview">
                <LGM:ToolBar0
                  ID="TBLpurIndentReturn"
                  ToolType="lgNMGrid"
                  EditUrl="~/PUR_Main/App_Edit/EF_purIndentReturn.aspx"
                  EnableAdd="False"
                  ValidationGroup="purIndentReturn"
                  runat="server" />
                <asp:UpdateProgress ID="UPGSpurIndentReturn" runat="server" AssociatedUpdatePanelID="UPNLpurIndentReturn" DisplayAfter="100">
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
                        <b>
                          <asp:Label ID="L_TranTypeID" runat="server" Text="Tran Type :" /></b>
                      </td>
                      <td>
                        <LGM:LC_spmtTranTypes
                          ID="F_TranTypeID"
                          OrderBy="Description"
                          DataTextField="Description"
                          DataValueField="TranTypeID"
                          IncludeDefault="true"
                          DefaultText="-- Select --"
                          Width="200px"
                          AutoPostBack="true"
                          RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
                          CssClass="myddl"
                          runat="Server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_DepartmentID" runat="server" Text="Department :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_DepartmentID"
                          CssClass="myfktxt"
                          Width="56px"
                          Text=""
                          onfocus="return this.select();"
                          AutoCompleteType="None"
                          onblur="validate_DepartmentID(this);"
                          runat="Server" />
                        <asp:Label
                          ID="F_DepartmentID_Display"
                          Text=""
                          runat="Server" />
                        <AJX:AutoCompleteExtender
                          ID="ACEDepartmentID"
                          BehaviorID="B_ACEDepartmentID"
                          ContextKey=""
                          UseContextKey="true"
                          ServiceMethod="DepartmentIDCompletionList"
                          TargetControlID="F_DepartmentID"
                          CompletionInterval="100"
                          FirstRowSelected="true"
                          MinimumPrefixLength="1"
                          OnClientItemSelected="ACEDepartmentID_Selected"
                          OnClientPopulating="ACEDepartmentID_Populating"
                          OnClientPopulated="ACEDepartmentID_Populated"
                          CompletionSetCount="10"
                          CompletionListCssClass="autocomplete_completionListElement"
                          CompletionListItemCssClass="autocomplete_listItem"
                          CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                          runat="Server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_EmployeeID" runat="server" Text="Employee :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_EmployeeID"
                          CssClass="myfktxt"
                          Width="72px"
                          Text=""
                          onfocus="return this.select();"
                          AutoCompleteType="None"
                          onblur="validate_EmployeeID(this);"
                          runat="Server" />
                        <asp:Label
                          ID="F_EmployeeID_Display"
                          Text=""
                          runat="Server" />
                        <AJX:AutoCompleteExtender
                          ID="ACEEmployeeID"
                          BehaviorID="B_ACEEmployeeID"
                          ContextKey=""
                          UseContextKey="true"
                          ServiceMethod="EmployeeIDCompletionList"
                          TargetControlID="F_EmployeeID"
                          CompletionInterval="100"
                          FirstRowSelected="true"
                          MinimumPrefixLength="1"
                          OnClientItemSelected="ACEEmployeeID_Selected"
                          OnClientPopulating="ACEEmployeeID_Populating"
                          OnClientPopulated="ACEEmployeeID_Populated"
                          CompletionSetCount="10"
                          CompletionListCssClass="autocomplete_completionListElement"
                          CompletionListItemCssClass="autocomplete_listItem"
                          CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                          runat="Server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_DivisionID" runat="server" Text="Division :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_DivisionID"
                          CssClass="myfktxt"
                          Width="56px"
                          Text=""
                          onfocus="return this.select();"
                          AutoCompleteType="None"
                          onblur="validate_DivisionID(this);"
                          runat="Server" />
                        <asp:Label
                          ID="F_DivisionID_Display"
                          Text=""
                          runat="Server" />
                        <AJX:AutoCompleteExtender
                          ID="ACEDivisionID"
                          BehaviorID="B_ACEDivisionID"
                          ContextKey=""
                          UseContextKey="true"
                          ServiceMethod="DivisionIDCompletionList"
                          TargetControlID="F_DivisionID"
                          CompletionInterval="100"
                          FirstRowSelected="true"
                          MinimumPrefixLength="1"
                          OnClientItemSelected="ACEDivisionID_Selected"
                          OnClientPopulating="ACEDivisionID_Populating"
                          OnClientPopulated="ACEDivisionID_Populated"
                          CompletionSetCount="10"
                          CompletionListCssClass="autocomplete_completionListElement"
                          CompletionListItemCssClass="autocomplete_listItem"
                          CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                          runat="Server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_ProjectID" runat="server" Text="Project :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_ProjectID"
                          CssClass="myfktxt"
                          Width="56px"
                          Text=""
                          onfocus="return this.select();"
                          AutoCompleteType="None"
                          onblur="validate_ProjectID(this);"
                          runat="Server" />
                        <asp:Label
                          ID="F_ProjectID_Display"
                          Text=""
                          runat="Server" />
                        <AJX:AutoCompleteExtender
                          ID="ACEProjectID"
                          BehaviorID="B_ACEProjectID"
                          ContextKey=""
                          UseContextKey="true"
                          ServiceMethod="ProjectIDCompletionList"
                          TargetControlID="F_ProjectID"
                          CompletionInterval="100"
                          FirstRowSelected="true"
                          MinimumPrefixLength="1"
                          OnClientItemSelected="ACEProjectID_Selected"
                          OnClientPopulating="ACEProjectID_Populating"
                          OnClientPopulated="ACEProjectID_Populated"
                          CompletionSetCount="10"
                          CompletionListCssClass="autocomplete_completionListElement"
                          CompletionListItemCssClass="autocomplete_listItem"
                          CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                          runat="Server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_CreatedBy"
                          CssClass="myfktxt"
                          Width="72px"
                          Text=""
                          onfocus="return this.select();"
                          AutoCompleteType="None"
                          onblur="validate_CreatedBy(this);"
                          runat="Server" />
                        <asp:Label
                          ID="F_CreatedBy_Display"
                          Text=""
                          runat="Server" />
                        <AJX:AutoCompleteExtender
                          ID="ACECreatedBy"
                          BehaviorID="B_ACECreatedBy"
                          ContextKey=""
                          UseContextKey="true"
                          ServiceMethod="CreatedByCompletionList"
                          TargetControlID="F_CreatedBy"
                          CompletionInterval="100"
                          FirstRowSelected="true"
                          MinimumPrefixLength="1"
                          OnClientItemSelected="ACECreatedBy_Selected"
                          OnClientPopulating="ACECreatedBy_Populating"
                          OnClientPopulated="ACECreatedBy_Populated"
                          CompletionSetCount="10"
                          CompletionListCssClass="autocomplete_completionListElement"
                          CompletionListItemCssClass="autocomplete_listItem"
                          CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                          runat="Server" />
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
                <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
                <script type="text/javascript">
                  var pcnt = 0;
                  function print_report(o) {
                    pcnt = pcnt + 1;
                    var nam = 'wTask' + pcnt;
                    var url = self.location.href.replace('App_Forms/GF_purIndentReturn', 'App_Print/RP_purIndents');
                    url = url + '?pk=' + o.alt;
                    window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
                    return false;
                  }
                </script>
                <script type="text/javascript">
                  var script_ApproverRemarks = {
                    temp: function () {
                    }
                  }
                </script>

                <asp:GridView ID="GVpurIndentReturn" SkinID="gv_silver" runat="server" DataSourceID="ODSpurIndentReturn" DataKeyNames="IndentNo">
                  <Columns>
                    <asp:TemplateField HeaderText="PRINT">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Indent No" SortExpression="[PUR_Indents].[IndentNo]">
                      <ItemTemplate>
                        <asp:Label ID="LabelIndentNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndentNo") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tran Type" SortExpression="[SPMT_TranTypes12].[Description]">
                      <ItemTemplate>
                        <asp:Label ID="L_TranTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TranTypeID") %>' Text='<%# Eval("SPMT_TranTypes12_Description") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created By" SortExpression="[aspnet_users1].[UserFullName]">
                      <ItemTemplate>
                        <asp:Label ID="L_CreatedBy" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("CreatedBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created On" SortExpression="[PUR_Indents].[CreatedOn]">
                      <ItemTemplate>
                        <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Approved By" SortExpression="[aspnet_users1].[UserFullName]">
                      <ItemTemplate>
                        <asp:Label ID="L_ApprovedBy" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("ApprovedBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Approved On" SortExpression="[PUR_Indents].[ApprovedOn]">
                      <ItemTemplate>
                        <asp:Label ID="LabelApprovedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApprovedOn") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Buyer Remarks" SortExpression="[PUR_Indents].[BuyerRemarks]">
                      <ItemTemplate>
                        <asp:TextBox ID="F_BuyerRemarks"
                          Text='<%# Bind("BuyerRemarks") %>'
                          Width="300px"
                          CssClass="mytxt"
                          onfocus="return this.select();"
                          ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
                          onblur="this.value=this.value.replace(/\'/g,'');"
                          ToolTip="Enter value for Buyer Remarks."
                          MaxLength="200"
                          runat="server" />
                        <asp:RequiredFieldValidator
                          ID="RFVBuyerRemarks"
                          runat="server"
                          ControlToValidate="F_BuyerRemarks"
                          ErrorMessage="<div class='errorLG'>Required!</div>"
                          Display="Dynamic"
                          EnableClientScript="true"
                          ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
                          SetFocusOnError="true" />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="300px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Convert To Order">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdInitiateWF" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Convert Indent To Order" SkinID="forward" OnClientClick='<%# Eval("GetConvertLink") %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Return">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Return" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Return record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemTemplate>
                        </td></tr>
            <tr style="background-color: AntiqueWhite; color: DeepPink">
              <td></td>
              <td colspan="4">
                <asp:Label ID="L_IndenterRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("IndenterRemarks") %>' Text='<%# Eval("IndenterRemarks") %>'></asp:Label>
              </td>
              <td colspan="4">
                <asp:Label ID="L_ApproverRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ApproverRemarks") %>' Text='<%# Eval("ApproverRemarks") %>'></asp:Label>
              </td>
              <td></td>
              <td></td>
            </tr>
                      </ItemTemplate>
                      <HeaderStyle Width="1px" />
                    </asp:TemplateField>
                  </Columns>
                  <EmptyDataTemplate>
                    <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                  </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource
                  ID="ODSpurIndentReturn"
                  runat="server"
                  DataObjectTypeName="SIS.PUR.purIndentReturn"
                  OldValuesParameterFormatString="original_{0}"
                  SelectMethod="UZ_purIndentReturnSelectList"
                  TypeName="SIS.PUR.purIndentReturn"
                  SelectCountMethod="purIndentReturnSelectCount"
                  SortParameterName="OrderBy" EnablePaging="True">
                  <SelectParameters>
                    <asp:ControlParameter ControlID="F_TranTypeID" PropertyName="SelectedValue" Name="TranTypeID" Type="String" Size="3" />
                    <asp:ControlParameter ControlID="F_CreatedBy" PropertyName="Text" Name="CreatedBy" Type="String" Size="8" />
                    <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
                    <asp:ControlParameter ControlID="F_DivisionID" PropertyName="Text" Name="DivisionID" Type="String" Size="6" />
                    <asp:ControlParameter ControlID="F_EmployeeID" PropertyName="Text" Name="EmployeeID" Type="String" Size="8" />
                    <asp:ControlParameter ControlID="F_DepartmentID" PropertyName="Text" Name="DepartmentID" Type="String" Size="6" />
                    <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                    <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                  </SelectParameters>
                </asp:ObjectDataSource>
                <br />
              </td>
            </tr>
          </table>
        </ContentTemplate>
        <Triggers>
          <asp:AsyncPostBackTrigger ControlID="GVpurIndentReturn" EventName="PageIndexChanged" />
          <asp:AsyncPostBackTrigger ControlID="F_TranTypeID" />
          <asp:AsyncPostBackTrigger ControlID="F_CreatedBy" />
          <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
          <asp:AsyncPostBackTrigger ControlID="F_DivisionID" />
          <asp:AsyncPostBackTrigger ControlID="F_EmployeeID" />
          <asp:AsyncPostBackTrigger ControlID="F_DepartmentID" />
        </Triggers>
      </asp:UpdatePanel>
    </div>
  </div>
  <script>
    function closeIframe(z) {
      lgMessageBox.close();
      var y = JSON.parse(z);
      if (y.err)
        alert(y.msg);
      if (!y.err) {
        $get('F_OrderNo').value = y.OrderNo;
        $get('F_IndentNo').value = y.IndentNo;
        showProcessingMPV();
        $get('cmdAction').click();
      }
    }
  </script>
  <asp:Button ID="cmdAction" runat="server" ClientIDMode="Static" Style="display: none;" />
  <asp:TextBox ID="F_OrderNo" runat="server" ClientIDMode="Static" Style="display: none" Text=""></asp:TextBox>
  <asp:TextBox ID="F_IndentNo" runat="server" ClientIDMode="Static" Style="display: none" Text=""></asp:TextBox>
</asp:Content>
