<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purPendingOrders.aspx.vb" Inherits="GF_purPendingOrders" title="Maintain List: Pending for Receipt" %>
<asp:Content ID="CPHpurPendingOrders" ContentPlaceHolderID="cph1" runat="Server">
  <LGM:LGMessageBox ID="LGMessage1" runat="server" />
  <div class="ui-widget-content page">
    <div class="caption">
      <asp:Label ID="LabelpurPendingOrders" runat="server" Text="&nbsp;List: Pending for Receipt"></asp:Label>
    </div>
    <div class="pagedata">
      <asp:UpdatePanel ID="UPNLpurPendingOrders" runat="server">
        <ContentTemplate>
          <table width="100%">
            <tr>
              <td class="sis_formview">
                <LGM:ToolBar0
                  ID="TBLpurPendingOrders"
                  ToolType="lgNMGrid"
                  EditUrl="~/PUR_Main/App_Edit/EF_purPendingOrders.aspx"
                  EnableAdd="False"
                  ValidationGroup="purPendingOrders"
                  runat="server" />
                <asp:UpdateProgress ID="UPGSpurPendingOrders" runat="server" AssociatedUpdatePanelID="UPNLpurPendingOrders" DisplayAfter="100">
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
                          <asp:Label ID="L_OrderNo" runat="server" Text="Order No :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_OrderNo"
                          CssClass="mypktxt"
                          Width="88px"
                          Text=""
                          onfocus="return this.select();"
                          AutoCompleteType="None"
                          onblur="validate_OrderNo(this);"
                          runat="Server" />
                        <asp:Label
                          ID="F_OrderNo_Display"
                          Text=""
                          runat="Server" />
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
                          CompletionListCssClass="autocomplete_completionListElement"
                          CompletionListItemCssClass="autocomplete_listItem"
                          CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                          runat="Server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_OrderRev" runat="server" Text="Order Rev :" /></b>
                      </td>
                      <td>
                        <asp:TextBox ID="F_OrderRev"
                          Text=""
                          Width="88px"
                          Style="text-align: right"
                          CssClass="mytxt"
                          MaxLength="10"
                          onfocus="return this.select();"
                          runat="server" />
                        <AJX:MaskedEditExtender
                          ID="MEEOrderRev"
                          runat="server"
                          Mask="9999999999"
                          AcceptNegative="Left"
                          MaskType="Number"
                          MessageValidatorTip="true"
                          InputDirection="RightToLeft"
                          ErrorTooltipEnabled="true"
                          TargetControlID="F_OrderRev" />
                        <AJX:MaskedEditValidator
                          ID="MEVOrderRev"
                          runat="server"
                          ControlToValidate="F_OrderRev"
                          ControlExtender="MEEOrderRev"
                          InvalidValueMessage="*"
                          EmptyValueMessage=""
                          EmptyValueBlurredText=""
                          Display="Dynamic"
                          EnableClientScript="true"
                          IsValidEmpty="True"
                          SetFocusOnError="true" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_ItemCode" runat="server" Text="Item Code :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_ItemCode"
                          CssClass="myfktxt"
                          Width="88px"
                          Text=""
                          onfocus="return this.select();"
                          AutoCompleteType="None"
                          onblur="validate_ItemCode(this);"
                          runat="Server" />
                        <asp:Label
                          ID="F_ItemCode_Display"
                          Text=""
                          runat="Server" />
                        <AJX:AutoCompleteExtender
                          ID="ACEItemCode"
                          BehaviorID="B_ACEItemCode"
                          ContextKey=""
                          UseContextKey="true"
                          ServiceMethod="ItemCodeCompletionList"
                          TargetControlID="F_ItemCode"
                          CompletionInterval="100"
                          FirstRowSelected="true"
                          MinimumPrefixLength="1"
                          OnClientItemSelected="ACEItemCode_Selected"
                          OnClientPopulating="ACEItemCode_Populating"
                          OnClientPopulated="ACEItemCode_Populated"
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
                          <asp:Label ID="Label1" runat="server" Text="Supplier :" /></b>
                      </td>
                      <td>
                        <script>
                          var script_purOrders = {
                            ACESupplierID_Selected: function (sender, e) {
                              var Prefix = sender._element.id.replace('SupplierID', '');
                              var F_SupplierID = $get(sender._element.id);
                              var F_SupplierID_Display = $get(sender._element.id + '_Display');
                              var retval = e.get_value();
                              var p = retval.split('|');
                              F_SupplierID.value = p[0];
                              F_SupplierID_Display.innerHTML = e.get_text();
                              try { $get(Prefix + 'SupplierName').value = trim(e.get_text()); } catch (x) { }
                            },
                            ACESupplierID_Populating: function (sender, e) {
                              var p = sender.get_element();
                              var Prefix = sender._element.id.replace('SupplierID', '');
                              p.style.backgroundImage = 'url(../../images/loader.gif)';
                              p.style.backgroundRepeat = 'no-repeat';
                              p.style.backgroundPosition = 'right';
                              sender._contextKey = '';
                            },
                            ACESupplierID_Populated: function (sender, e) {
                              var p = sender.get_element();
                              p.style.backgroundImage = 'none';
                            },
                            validate_SupplierID: function (sender) {
                              var Prefix = sender.id.replace('SupplierID', '');
                              this.validated_FK_PUR_Orders_SupplierID_main = true;
                              this.validate_FK_PUR_Orders_SupplierID(sender, Prefix);
                            },
                            validate_FK_PUR_Orders_SupplierID: function (o, Prefix) {
                              var value = o.id;
                              var SupplierID = $get(Prefix + 'SupplierID');
                              if (SupplierID.value == '') {
                                if (this.validated_FK_PUR_Orders_SupplierID_main) {
                                  var o_d = $get(Prefix + 'SupplierID' + '_Display');
                                  try { o_d.innerHTML = ''; } catch (ex) { }
                                }
                                return true;
                              }
                              value = value + ',' + SupplierID.value;
                              o.style.backgroundImage = 'url(../../images/pkloader.gif)';
                              o.style.backgroundRepeat = 'no-repeat';
                              o.style.backgroundPosition = 'right';
                              PageMethods.validate_FK_PUR_Orders_SupplierID(value, this.validated_SupplierID);
                            },
                            validated_FK_PUR_Orders_SupplierID_main: false,
                            validated_SupplierID: function (result) {
                              var p = result.split('|');
                              var o = $get(p[1]);
                              if (script_purOrders.validated_FK_PUR_Orders_SupplierID_main) {
                                var o_d = $get(p[1] + '_Display');
                                try { o_d.innerHTML = p[2]; } catch (ex) { }
                              }
                              o.style.backgroundImage = 'none';
                              if (p[0] == '1') {
                                o.value = '';
                                try{o_d.innerHTML = '';}catch(ex){}
                                __doPostBack(o.id, o.value);
                              } else {
                                __doPostBack(o.id, o.value);
                              }
                            }
                          }

                        </script>
                        <asp:TextBox
                          ID = "F_SupplierID"
                          CssClass = "myfktxt"
                          Text=""
                          AutoCompleteType = "None"
                          Width="80px"
                          onfocus = "return this.select();"
                          onblur= "script_purOrders.validate_SupplierID(this);"
                          Runat="Server" />
                        <asp:Label
                          ID = "F_SupplierID_Display"
                          Text=""
                          CssClass="myLbl"
                          Runat="Server" />
                        <AJX:AutoCompleteExtender
                          ID="ACESupplierID"
                          BehaviorID="B_ACESupplierID"
                          ContextKey=""
                          UseContextKey="true"
                          ServiceMethod="SupplierIDCompletionList"
                          TargetControlID="F_SupplierID"
                          EnableCaching="false"
                          CompletionInterval="100"
                          FirstRowSelected="true"
                          MinimumPrefixLength="1"
                          OnClientItemSelected="script_purOrders.ACESupplierID_Selected"
                          OnClientPopulating="script_purOrders.ACESupplierID_Populating"
                          OnClientPopulated="script_purOrders.ACESupplierID_Populated"
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
                <script type="text/javascript">
                  var script_ReceivedQuantity = {
                    temp: function () {
                    }
                  }
                </script>

                <asp:GridView ID="GVpurPendingOrders" SkinID="gv_silver" runat="server" DataSourceID="ODSpurPendingOrders" DataKeyNames="OrderNo,OrderLine,OrderRev">
                  <Columns>
                    <asp:TemplateField HeaderText="EDIT">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order No" SortExpression="[PUR_Orders8].[OrderNo]">
                      <ItemTemplate>
                        <asp:Label ID="L_OrderNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("OrderNo") %>' Text='<%# Eval("OrderNo") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="REV" SortExpression="[PUR_OrderDetails].[OrderRev]">
                      <ItemTemplate>
                        <asp:Label ID="LabelOrderRev" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OrderRev") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="Item Code" SortExpression="[PUR_Items7].[ItemCode]">
                      <ItemTemplate>
                        <asp:Label ID="L_ItemCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("ItemCode") %>' Title='<%# Eval("PUR_Items7_ItemDescription") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Description" SortExpression="[PUR_OrderDetails].[ItemDescription]">
                      <ItemTemplate>
                        <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UOM" SortExpression="[SPMT_ERPUnits12].[Description]">
                      <ItemTemplate>
                        <asp:Label ID="L_UOM" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOM") %>' Text='<%# Eval("SPMT_ERPUnits12_Description") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity" SortExpression="[PUR_OrderDetails].[Quantity]">
                      <ItemTemplate>
                        <asp:Label ID="LabelQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Quantity") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignright" />
                      <HeaderStyle CssClass="alignright" Width="60px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pending Qty." SortExpression="[PUR_OrderDetails].[OriginalQuantity]">
                      <ItemTemplate>
                        <asp:Label ID="LabelOriginalQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OriginalQuantity") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignright" />
                      <HeaderStyle CssClass="alignright" Width="60px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Receive Qty." SortExpression="[PUR_OrderDetails].[OriginalQuantity]">
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
                        <asp:Button ID="cmdConvert" runat="server" CommandName="cmdConvert" CssClass="nt-but-danger" Text="Convert to Receipt" ToolTip="Convert selected line to material receipt." OnClientClick="lgMessageBox.ExecuteURL('Convert to Material Receipt', '../App_Controls/AF_ctlReceipts.aspx'); return false;" />
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
                  ID="ODSpurPendingOrders"
                  runat="server"
                  DataObjectTypeName="SIS.PUR.purPendingOrders"
                  OldValuesParameterFormatString="original_{0}"
                  SelectMethod="UZ_purPendingOrdersSelectList"
                  TypeName="SIS.PUR.purPendingOrders"
                  SelectCountMethod="purPendingOrdersSelectCount"
                  SortParameterName="OrderBy" EnablePaging="True">
                  <SelectParameters>
                    <asp:ControlParameter ControlID="F_OrderNo" PropertyName="Text" Name="OrderNo" Type="Int32" Size="10" />
                    <asp:ControlParameter ControlID="F_OrderRev" PropertyName="Text" Name="OrderRev" Type="Int32" Size="10" />
                    <asp:ControlParameter ControlID="F_ItemCode" PropertyName="Text" Name="ItemCode" Type="Int32" Size="10" />
                    <asp:ControlParameter ControlID="F_SupplierID" PropertyName="Text" Name="SupplierID" Type="String" Size="9" />
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
          <asp:AsyncPostBackTrigger ControlID="GVpurPendingOrders" EventName="PageIndexChanged" />
          <asp:AsyncPostBackTrigger ControlID="F_OrderNo" />
          <asp:AsyncPostBackTrigger ControlID="F_OrderRev" />
          <asp:AsyncPostBackTrigger ControlID="F_ItemCode" />
          <asp:AsyncPostBackTrigger ControlID="F_SupplierID" />
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
        $get('F_ReceiptNo').value = y.ReceiptNo;
        showProcessingMPV();
        $get('cmdAction').click();
      }
    }
  </script>
    <asp:Button id="cmdAction" runat="server" ClientIDMode="Static" style="display:none;" />
    <asp:TextBox ID="F_ReceiptNo" runat="server" ClientIDMode="Static" style="display:none" Text=""></asp:TextBox>
</asp:Content>
