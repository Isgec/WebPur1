<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purOrderCancel.aspx.vb" Inherits="GF_purOrderCancel" title="Maintain List: Cancel / Receive Order" %>
<asp:Content ID="CPHpurOrderCancel" ContentPlaceHolderID="cph1" runat="Server">
  <LGM:LGMessageBox ID="LGMessage1" runat="server" />
  <div class="ui-widget-content page">
    <div class="caption">
      <asp:Label ID="LabelpurOrderCancel" runat="server" Text="&nbsp;List: Cancel / Receive Order"></asp:Label>
    </div>
    <div class="pagedata">
      <asp:UpdatePanel ID="UPNLpurOrderCancel" runat="server">
        <ContentTemplate>
          <table width="100%">
            <tr>
              <td class="sis_formview">
                <LGM:ToolBar0
                  ID="TBLpurOrderCancel"
                  ToolType="lgNMGrid"
                  EnableAdd="False"
                  ValidationGroup="purOrderCancel"
                  runat="server" />
                <asp:UpdateProgress ID="UPGSpurOrderCancel" runat="server" AssociatedUpdatePanelID="UPNLpurOrderCancel" DisplayAfter="100">
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
                          <asp:Label ID="L_PurchaseTypeID" runat="server" Text="Purchase Type :" /></b>
                      </td>
                      <td>
                        <LGM:LC_purPurchaseTypes
                          ID="F_PurchaseTypeID"
                          OrderBy="Description"
                          DataTextField="Description"
                          DataValueField="PurchaseTypeID"
                          IncludeDefault="true"
                          DefaultText="-- Select --"
                          Width="400px"
                          AutoPostBack="true"
                          RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
                          CssClass="myddl"
                          runat="Server" />
                      </td>
                    </tr>
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
                          <asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_SupplierID"
                          CssClass="myfktxt"
                          Width="80px"
                          Text=""
                          onfocus="return this.select();"
                          AutoCompleteType="None"
                          onblur="validate_SupplierID(this);"
                          runat="Server" />
                        <asp:Label
                          ID="F_SupplierID_Display"
                          Text=""
                          runat="Server" />
                        <AJX:AutoCompleteExtender
                          ID="ACESupplierID"
                          BehaviorID="B_ACESupplierID"
                          ContextKey=""
                          UseContextKey="true"
                          ServiceMethod="SupplierIDCompletionList"
                          TargetControlID="F_SupplierID"
                          CompletionInterval="100"
                          FirstRowSelected="true"
                          MinimumPrefixLength="1"
                          OnClientItemSelected="ACESupplierID_Selected"
                          OnClientPopulating="ACESupplierID_Populating"
                          OnClientPopulated="ACESupplierID_Populated"
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
                          <asp:Label ID="L_AprTypeID" runat="server" Text="Apr Type :" /></b>
                      </td>
                      <td>
                        <LGM:LC_purApprovalTypes
                          ID="F_AprTypeID"
                          OrderBy="AprDescription"
                          DataTextField="AprDescription"
                          DataValueField="AprTypeID"
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
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_StatusID" runat="server" Text="Status :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_StatusID"
                          CssClass="myfktxt"
                          Width="88px"
                          Text=""
                          onfocus="return this.select();"
                          AutoCompleteType="None"
                          onblur="validate_StatusID(this);"
                          runat="Server" />
                        <asp:Label
                          ID="F_StatusID_Display"
                          Text=""
                          runat="Server" />
                        <AJX:AutoCompleteExtender
                          ID="ACEStatusID"
                          BehaviorID="B_ACEStatusID"
                          ContextKey=""
                          UseContextKey="true"
                          ServiceMethod="StatusIDCompletionList"
                          TargetControlID="F_StatusID"
                          CompletionInterval="100"
                          FirstRowSelected="true"
                          MinimumPrefixLength="1"
                          OnClientItemSelected="ACEStatusID_Selected"
                          OnClientPopulating="ACEStatusID_Populating"
                          OnClientPopulated="ACEStatusID_Populated"
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
                          <asp:Label ID="L_ApprovedBy" runat="server" Text="Approved By :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_ApprovedBy"
                          CssClass="myfktxt"
                          Width="72px"
                          Text=""
                          onfocus="return this.select();"
                          AutoCompleteType="None"
                          onblur="validate_ApprovedBy(this);"
                          runat="Server" />
                        <asp:Label
                          ID="F_ApprovedBy_Display"
                          Text=""
                          runat="Server" />
                        <AJX:AutoCompleteExtender
                          ID="ACEApprovedBy"
                          BehaviorID="B_ACEApprovedBy"
                          ContextKey=""
                          UseContextKey="true"
                          ServiceMethod="ApprovedByCompletionList"
                          TargetControlID="F_ApprovedBy"
                          CompletionInterval="100"
                          FirstRowSelected="true"
                          MinimumPrefixLength="1"
                          OnClientItemSelected="ACEApprovedBy_Selected"
                          OnClientPopulating="ACEApprovedBy_Populating"
                          OnClientPopulated="ACEApprovedBy_Populated"
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
                    var url = self.location.href.replace('App_Forms/GF_purOrderCancel', 'App_Print/RP_purOrders');
                    url = url + '?pk=' + o.alt;
                    window.open(url, nam, 'left=20,top=20,width=1050,height=600,toolbar=1,resizable=1,scrollbars=1');
                    return false;
                  }
                </script>
                <script type="text/javascript">
                  var script_BuyerRemarks = {
                    temp: function () {
                    }
                  }
                </script>

                <asp:GridView ID="GVpurOrderCancel" SkinID="gv_silver" runat="server" DataSourceID="ODSpurOrderCancel" DataKeyNames="OrderNo,OrderRev">
                  <Columns>
                    <asp:TemplateField HeaderText="PRINT">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order No" SortExpression="[PUR_Orders].[OrderNo]">
                      <ItemTemplate>
                        <asp:Label ID="LabelOrderNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("OrderNo") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="REV" SortExpression="[PUR_Orders].[OrderRev]">
                      <ItemTemplate>
                        <asp:Label ID="LabelOrderRev" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("OrderRev") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tran Type" SortExpression="[SPMT_TranTypes14].[Description]">
                      <ItemTemplate>
                        <asp:Label ID="L_TranTypeID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("TranTypeID") %>' Text='<%# Eval("SPMT_TranTypes14_Description") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier" SortExpression="[VR_BusinessPartner16].[BPName]">
                      <ItemTemplate>
                        <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# EVal("SupplierID") %>' Title='<%# Eval("VR_BusinessPartner16_BPName") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier Name" SortExpression="[PUR_Orders].[SupplierName]">
                      <ItemTemplate>
                        <asp:Label ID="LabelSupplierName" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SupplierName") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created By" SortExpression="[aspnet_users1].[UserFullName]">
                      <ItemTemplate>
                        <asp:Label ID="L_CreatedBy" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("CreatedBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created On" SortExpression="[PUR_Orders].[CreatedOn]">
                      <ItemTemplate>
                        <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Buyer Remarks" SortExpression="[PUR_Orders].[BuyerRemarks]">
                      <ItemTemplate>
                        <asp:TextBox ID="F_BuyerRemarks"
                          Text='<%# Bind("BuyerRemarks") %>'
                          Width="250px"
                          CssClass="mytxt"
                          onfocus="return this.select();"
                          ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
                          onblur="this.value=this.value.replace(/\'/g,'');"
                          ToolTip="Enter value for Buyer Remarks."
                          MaxLength="500"
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
                      <HeaderStyle CssClass="alignleft" Width="250px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Convert to Receipt">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Convert Order to Receipt" SkinID="forward" OnClientClick='<%# Eval("GetConvertLink") %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cancel">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Cancel Order" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Cancel Purchase Order ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
                  ID="ODSpurOrderCancel"
                  runat="server"
                  DataObjectTypeName="SIS.PUR.purOrderCancel"
                  OldValuesParameterFormatString="original_{0}"
                  SelectMethod="UZ_purOrderCancelSelectList"
                  TypeName="SIS.PUR.purOrderCancel"
                  SelectCountMethod="purOrderCancelSelectCount"
                  SortParameterName="OrderBy" EnablePaging="True">
                  <SelectParameters>
                    <asp:ControlParameter ControlID="F_TranTypeID" PropertyName="SelectedValue" Name="TranTypeID" Type="String" Size="3" />
                    <asp:ControlParameter ControlID="F_SupplierID" PropertyName="Text" Name="SupplierID" Type="String" Size="9" />
                    <asp:ControlParameter ControlID="F_CreatedBy" PropertyName="Text" Name="CreatedBy" Type="String" Size="8" />
                    <asp:ControlParameter ControlID="F_EmployeeID" PropertyName="Text" Name="EmployeeID" Type="String" Size="8" />
                    <asp:ControlParameter ControlID="F_ApprovedBy" PropertyName="Text" Name="ApprovedBy" Type="String" Size="8" />
                    <asp:ControlParameter ControlID="F_StatusID" PropertyName="Text" Name="StatusID" Type="Int32" Size="10" />
                    <asp:ControlParameter ControlID="F_AprTypeID" PropertyName="SelectedValue" Name="AprTypeID" Type="String" Size="10" />
                    <asp:ControlParameter ControlID="F_PurchaseTypeID" PropertyName="SelectedValue" Name="PurchaseTypeID" Type="String" Size="100" />
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
          <asp:AsyncPostBackTrigger ControlID="GVpurOrderCancel" EventName="PageIndexChanged" />
          <asp:AsyncPostBackTrigger ControlID="F_TranTypeID" />
          <asp:AsyncPostBackTrigger ControlID="F_SupplierID" />
          <asp:AsyncPostBackTrigger ControlID="F_CreatedBy" />
          <asp:AsyncPostBackTrigger ControlID="F_EmployeeID" />
          <asp:AsyncPostBackTrigger ControlID="F_ApprovedBy" />
          <asp:AsyncPostBackTrigger ControlID="F_StatusID" />
          <asp:AsyncPostBackTrigger ControlID="F_AprTypeID" />
          <asp:AsyncPostBackTrigger ControlID="F_PurchaseTypeID" />
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
        $get('F_OrderRev').value = y.OrderRev;
        $get('F_ReceiptNo').value = y.ReceiptNo;
        showProcessingMPV();
        $get('cmdAction').click();
      }
    }
  </script>
  <asp:Button ID="cmdAction" runat="server" ClientIDMode="Static" Style="display: none;" />
  <asp:TextBox ID="F_OrderNo" runat="server" ClientIDMode="Static" Style="display: none" Text=""></asp:TextBox>
  <asp:TextBox ID="F_OrderRev" runat="server" ClientIDMode="Static" Style="display: none" Text=""></asp:TextBox>
  <asp:TextBox ID="F_ReceiptNo" runat="server" ClientIDMode="Static" Style="display: none" Text=""></asp:TextBox>
</asp:Content>
