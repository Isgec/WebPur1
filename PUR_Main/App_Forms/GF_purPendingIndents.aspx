<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purPendingIndents.aspx.vb" Inherits="GF_purPendingIndents" title="Maintain List: Pending for Ordering" %>
<asp:Content ID="CPHpurPendingIndents" ContentPlaceHolderID="cph1" runat="Server">
  <LGM:LGMessageBox ID="LGMessage1" runat="server" />
  <div class="ui-widget-content page">
    <div class="caption">
      <asp:Label ID="LabelpurPendingIndents" runat="server" Text="&nbsp;List: Pending for Ordering"></asp:Label>
    </div>
    <div class="pagedata">
      <asp:UpdatePanel ID="UPNLpurPendingIndents" runat="server">
        <ContentTemplate>
          <table width="100%">
            <tr>
              <td class="sis_formview">
                <LGM:ToolBar0
                  ID="TBLpurPendingIndents"
                  ToolType="lgNMGrid"
                  EditUrl="~/PUR_Main/App_Edit/EF_purPendingIndents.aspx"
                  EnableAdd="False"
                  ValidationGroup="purPendingIndents"
                  runat="server" />
                <asp:UpdateProgress ID="UPGSpurPendingIndents" runat="server" AssociatedUpdatePanelID="UPNLpurPendingIndents" DisplayAfter="100">
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
                          <asp:Label ID="L_IndentNo" runat="server" Text="Indent No :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_IndentNo"
                          CssClass="mypktxt"
                          Width="88px"
                          Text=""
                          onfocus="return this.select();"
                          AutoCompleteType="None"
                          onblur="validate_IndentNo(this);"
                          runat="Server" />
                        <asp:Label
                          ID="F_IndentNo_Display"
                          Text=""
                          runat="Server" />
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
                  var script_OrderedQuantity = {
                    temp: function () {
                    }
                  }
                </script>

                <asp:GridView ID="GVpurPendingIndents" SkinID="gv_silver" runat="server" DataSourceID="ODSpurPendingIndents" DataKeyNames="IndentNo,IndentLine">
                  <Columns>
                    <asp:TemplateField HeaderText="EDIT">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Indent No" SortExpression="[PUR_Indents7].[IndenterNo]">
                      <ItemTemplate>
                        <asp:Label ID="L_IndentNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("IndentNo") %>' Text='<%# Eval("IndentNo") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="60px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Indent Line" SortExpression="[PUR_IndentDetails].[IndentLine]">
                      <ItemTemplate>
                        <asp:Label ID="LabelIndentLine" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndentLine") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Code" SortExpression="[PUR_IndentDetails].[ItemCode]">
                      <ItemTemplate>
                        <asp:Label ID="L_ItemCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("PUR_Items8_ItemDescription") %>' Text='<%# Eval("ItemCode") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Description" SortExpression="[PUR_IndentDetails].[ItemDescription]">
                      <ItemTemplate>
                        <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="300px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UOM" SortExpression="[SPMT_ERPUnits12].[Description]">
                      <ItemTemplate>
                        <asp:Label ID="L_UOM" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOM") %>' Text='<%# Eval("SPMT_ERPUnits12_Description") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Indent Qty." SortExpression="[PUR_IndentDetails].[Quantity]">
                      <ItemTemplate>
                        <asp:Label ID="LabelQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Quantity") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignright" />
                      <HeaderStyle CssClass="alignright" Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delivery Date" SortExpression="[PUR_IndentDetails].[DeliveryDate]">
                      <ItemTemplate>
                        <asp:Label ID="LabelDeliveryDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DeliveryDate") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pending Qty." SortExpression="[PUR_IndentDetails].[OriginalQuantity]">
                      <ItemTemplate>
                        <asp:Label ID="LabelOriginalQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OriginalQuantity") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignright" />
                      <HeaderStyle CssClass="alignright" Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order Qty." SortExpression="[PUR_IndentDetails].[OriginalQuantity]">
                      <ItemTemplate>
                        <asp:TextBox ID="F_OriginalQuantity"
                          Text='<%# Bind("OriginalQuantity") %>'
                          Style="text-align: right"
                          Width="120px"
                          CssClass="mytxt"
                          MaxLength="22"
                          onfocus="return this.select();"
                          onblur="return dc(this,4);"
                          ValidationGroup='<%# "Select" & Container.DataItemIndex %>'
                          runat="server" />
                        <asp:CompareValidator
                          ID="CVOriginalQuantity"
                          runat="server"
                          SetFocusOnError="true"
                          ControlToValidate="F_OriginalQuantity"
                          ErrorMessage="<br/><div class='errorLG' style='whiteSpace:nowrap;width:100%;'>Greater than pending or Required!</div>"
                          Operator="LessThanEqual"
                          Display="Dynamic"
                          ValidationGroup='<%# "Select" & Container.DataItemIndex %>'
                          Type="Double"
                          ValueToCompare='<%# EVal("OriginalQuantity") %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignright" />
                      <HeaderStyle CssClass="alignright" Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <HeaderTemplate>
                        <asp:Button ID="cmdConvert" runat="server" CommandName="cmdConvert" CssClass="nt-but-danger" Text="Convert to Order" ToolTip="Convert selected line to purchase order." OnClientClick="lgMessageBox.ExecuteURL('Convert to Purchase Order', '../App_Controls/AF_ctlOrders.aspx'); return false;" />
                      </HeaderTemplate>
                      <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" ToolTip="Select" CssClass="mychk" />
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
                  ID="ODSpurPendingIndents"
                  runat="server"
                  DataObjectTypeName="SIS.PUR.purPendingIndents"
                  OldValuesParameterFormatString="original_{0}"
                  SelectMethod="UZ_purPendingIndentsSelectList"
                  TypeName="SIS.PUR.purPendingIndents"
                  SelectCountMethod="purPendingIndentsSelectCount"
                  SortParameterName="OrderBy" EnablePaging="True">
                  <SelectParameters>
                    <asp:ControlParameter ControlID="F_IndentNo" PropertyName="Text" Name="IndentNo" Type="Int32" Size="10" />
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
          <asp:AsyncPostBackTrigger ControlID="GVpurPendingIndents" EventName="PageIndexChanged" />
          <asp:AsyncPostBackTrigger ControlID="F_IndentNo" />
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
        showProcessingMPV();
        $get('cmdAction').click();
      }
    }
  </script>
    <asp:Button id="cmdAction" runat="server" ClientIDMode="Static" style="display:none;" />
    <asp:TextBox ID="F_OrderNo" runat="server" ClientIDMode="Static" style="display:none" Text=""></asp:TextBox>
</asp:Content>
