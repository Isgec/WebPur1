<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_purIndentDetails.aspx.vb" Inherits="AF_purIndentDetails" title="Add: Indent Items" %>
<asp:Content ID="CPHpurIndentDetails" ContentPlaceHolderID="cph1" runat="Server">
  <script type="text/javascript">
    function applyTax(o, p) {
      var t = '';
      if (o != 'null')
        t = JSON.parse(o);
      var r = ['IGSTrate', 'SGSTRate', 'CGSTRate', 'CESSRate', 'TCSRate'];
      var a = ['IGSTAmount', 'SGSTAmount', 'CGSTAmount', 'CESSAmount', 'TCSAmount'];
      var x = '';
      if (t != '') {
        for (var i = 0; i < r.length; i++) {
          x = $get(p + r[i]);
          x.value = parseFloat(t[r[i]]).toFixed(4);
          x.disabled = true;
          x.setAttribute('class', x.getAttribute('class').replace('mytxt', 'dmytxt'));
        }
        for (var i = 0; i < a.length; i++) {
          x = $get(p + a[i]);
          x.value = '0.0000';
          x.disabled = true;
          x.setAttribute('class', x.getAttribute('class').replace('mytxt', 'dmytxt'));
        }
      } else {
        for (var i = 0; i < r.length; i++) {
          x = $get(p + r[i]);
          x.value = '0.0000';
          x.disabled = false;
          x.setAttribute('class', x.getAttribute('class').replace('dmytxt', 'mytxt'));
        }
        for (var i = 0; i < a.length; i++) {
          x = $get(p + a[i]);
          x.value = '0.0000';
          x.disabled = false;
          x.setAttribute('class', x.getAttribute('class').replace('dmytxt', 'mytxt'));
        }
      }
      validate_tots(x);
    }
    function validate_tots(o) {
      o.value = o.value.replace(new RegExp('_', 'g'), '');
      var aVal = o.id.split('_F_');
      var Prefix = aVal[0] + '_F_';
      var Qty = $get(Prefix + 'Quantity');
      var Price = $get(Prefix + 'Price');
      var Amt = $get(Prefix + 'Amount');
      var AssessableValue = $get(Prefix + 'AssessableValue');
      var CessRate = $get(Prefix + 'CESSRate');
      var CessAmount = $get(Prefix + 'CESSAmount');
      var TotalGST = $get(Prefix + 'TotalGST');
      var TotalGSTINR = $get(Prefix + 'TaxAmount');
      var TotalAmount = $get(Prefix + 'TotalAmount');
      var ConversionFactorINR = $get(Prefix + 'ConversionFactorINR');
      var TotalAmountINR = $get(Prefix + 'TotalAmountINR');
      var IGSTRate = $get(Prefix + 'IGSTrate');
      var IGSTAmount = $get(Prefix + 'IGSTAmount');
      var SGSTRate = $get(Prefix + 'SGSTRate');
      var SGSTAmount = $get(Prefix + 'SGSTAmount');
      var CGSTRate = $get(Prefix + 'CGSTRate');
      var CGSTAmount = $get(Prefix + 'CGSTAmount');
      var TCSRate = $get(Prefix + 'TCSRate');
      var TCSAmount = $get(Prefix + 'TCSAmount');
      try {
        Amt.value = (parseFloat(Qty.value) * parseFloat(Price.value)).toFixed(4);
        if (!parseFloat(AssessableValue.value) > 0)
          AssessableValue.value = Amt.value;
        if (parseFloat(CessRate.value) > 0)
          CessAmount.value = (parseFloat(CessRate.value) * parseFloat(AssessableValue.value) * 0.01).toFixed(4);
        if (parseFloat(IGSTRate.value) > 0)
          IGSTAmount.value = (parseFloat(IGSTRate.value) * parseFloat(AssessableValue.value) * 0.01).toFixed(4);
        if (parseFloat(SGSTRate.value) > 0)
          SGSTAmount.value = (parseFloat(SGSTRate.value) * parseFloat(AssessableValue.value) * 0.01).toFixed(4);
        if (parseFloat(CGSTRate.value) > 0)
          CGSTAmount.value = (parseFloat(CGSTRate.value) * parseFloat(AssessableValue.value) * 0.01).toFixed(4);

        TotalGST.value = (parseFloat(CessAmount.value) + parseFloat(IGSTAmount.value) + parseFloat(SGSTAmount.value) + parseFloat(CGSTAmount.value)).toFixed(4);
        TotalGSTINR.value = (parseFloat(TotalGST.value) * parseFloat(ConversionFactorINR.value)).toFixed(4);

        if (parseFloat(TCSRate.value) != NaN)
          TCSAmount.value = (parseFloat(TCSRate.value) * (parseFloat(AssessableValue.value) + parseFloat(TotalGST.value)) * 0.01).toFixed(4);

        TotalAmount.value = (parseFloat(AssessableValue.value) + parseFloat(TotalGST.value) + parseFloat(TCSAmount.value)).toFixed(4);
        TotalAmountINR.value = (parseFloat(TotalAmount.value) * parseFloat(ConversionFactorINR.value)).toFixed(4);
      } catch (e) { }
    }
  </script>
  <LGM:LGMessageBox ID="LGMessage1" runat="server" />
  <div id="div1" class="ui-widget-content page">
    <div id="div2" class="caption">
      <asp:Label ID="LabelpurIndentDetails" runat="server" Text="&nbsp;Add: Indent Items"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
      <LGM:ToolBar0
        ID="TBLpurIndentDetails"
        ToolType="lgNMAdd"
        InsertAndStay="False"
        ValidationGroup="purIndentDetails"
        runat="server" />
      <asp:FormView ID="FVpurIndentDetails"
        runat="server"
        DataKeyNames="IndentNo,IndentLine"
        DataSourceID="ODSpurIndentDetails"
        DefaultMode="Insert" CssClass="sis_formview">
        <InsertItemTemplate>
          <div id="frmdiv" class="ui-widget-content minipage">
            <asp:Label ID="L_ErrMsgpurIndentDetails" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
            <table style="margin: auto; border: solid 1pt lightgrey">
              <tr>
                <td class="alignright">
                  <b>
                    <asp:Label ID="L_IndentNo" ForeColor="#CC6633" runat="server" Text="Indent No :" /><span style="color: red">*</span></b>
                </td>
                <td>
                  <asp:TextBox
                    ID="F_IndentNo"
                    CssClass="mypktxt"
                    Width="88px"
                    Text='<%# Bind("IndentNo") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for Indent No."
                    ValidationGroup="purIndentDetails"
                    onblur="script_purIndentDetails.validate_IndentNo(this);"
                    runat="Server" />
                  <asp:RequiredFieldValidator
                    ID="RFVIndentNo"
                    runat="server"
                    ControlToValidate="F_IndentNo"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup="purIndentDetails"
                    SetFocusOnError="true" />
                  <asp:Label
                    ID="F_IndentNo_Display"
                    Text='<%# Eval("PUR_Indents7_IndenterRemarks") %>'
                    CssClass="myLbl"
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACEIndentNo"
                    BehaviorID="B_ACEIndentNo"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="IndentNoCompletionList"
                    TargetControlID="F_IndentNo"
                    EnableCaching="false"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="script_purIndentDetails.ACEIndentNo_Selected"
                    OnClientPopulating="script_purIndentDetails.ACEIndentNo_Populating"
                    OnClientPopulated="script_purIndentDetails.ACEIndentNo_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
                <td class="alignright">
                  <b>
                    <asp:Label ID="L_IndentLine" ForeColor="#CC6633" runat="server" Text="Indent Line :" /><span style="color: red">*</span></b>
                </td>
                <td>
                  <asp:TextBox ID="F_IndentLine" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_ItemCode" runat="server" Text="Item Code :" /><span style="color: red">*</span>
                </td>
                <td>
                  <input id="old_item" type="text" style="display: none;" />
                  <asp:TextBox
                    ID="F_ItemCode"
                    CssClass="myfktxt"
                    Width="88px"
                    Text='<%# Bind("ItemCode") %>'
                    AutoCompleteType="None"
                    onfocus="$get('old_item').value=this.value;return this.select();"
                    ToolTip="Enter value for Item Code."
                    ValidationGroup="purIndentDetails"
                    ClientIDMode="Static"
                    onblur="script_purIndentDetails.validate_ItemCode(this);$get('showhere').click();"
                    runat="Server" />
                  <asp:Label
                    ID="F_ItemCode_Display"
                    Text='<%# Eval("PUR_Items8_ItemDescription") %>'
                    CssClass="myLbl"
                    ClientIDMode="Static"
                    runat="Server" />
                  <asp:RequiredFieldValidator
                    ID="RFVItemCode"
                    runat="server"
                    ControlToValidate="F_ItemCode"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup="purIndentDetails"
                    SetFocusOnError="true" />
                  <AJX:AutoCompleteExtender
                    ID="ACEItemCode"
                    BehaviorID="B_ACEItemCode"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="ItemCodeCompletionList"
                    TargetControlID="F_ItemCode"
                    EnableCaching="false"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="script_purIndentDetails.ACEItemCode_Selected"
                    OnClientPopulating="script_purIndentDetails.ACEItemCode_Populating"
                    OnClientPopulated="script_purIndentDetails.ACEItemCode_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                  <script>
                    function show_prop() {
                      var val = $get('F_ItemCode').value;
                      lgMessageBox.ExecuteURL('Item Properties', '../App_Controls/GF_purItemCategorySpecs.aspx?ItemCode=' + val);
                      return false;
                    }
                  </script>
                  <asp:Button ID="cmdProperty" runat="server" CssClass="nt-but-danger" Text="Properties" Style="display: none;" OnClientClick="return show_prop();" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_UOM" runat="server" Text="UOM :" /><span style="color: red">*</span>
                </td>
                <td>
                  <asp:TextBox
                    ID="F_UOM"
                    CssClass="myfktxt"
                    Width="32px"
                    Text='<%# Bind("UOM") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for UOM."
                    ValidationGroup="purIndentDetails"
                    onblur="script_purIndentDetails.validate_UOM(this);"
                    ClientIDMode="Static"
                    runat="Server" />
                  <asp:Label
                    ID="F_UOM_Display"
                    Text='<%# Eval("SPMT_ERPUnits12_Description") %>'
                    CssClass="myLbl"
                    ClientIDMode="Static"
                    runat="Server" />
                  <asp:RequiredFieldValidator
                    ID="RFVUOM"
                    runat="server"
                    ControlToValidate="F_UOM"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup="purIndentDetails"
                    SetFocusOnError="true" />
                  <AJX:AutoCompleteExtender
                    ID="ACEUOM"
                    BehaviorID="B_ACEUOM"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="UOMCompletionList"
                    TargetControlID="F_UOM"
                    EnableCaching="false"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="script_purIndentDetails.ACEUOM_Selected"
                    OnClientPopulating="script_purIndentDetails.ACEUOM_Populating"
                    OnClientPopulated="script_purIndentDetails.ACEUOM_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
              </tr>
              <tr>
                <td colspan="4">
                  <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                      <asp:Button ID="showhere" runat="server" ClientIDMode="Static" Style="display: none;" OnClientClick="if($get('old_item').value==$get('F_ItemCode').value) return false;return true;" OnClick="showhere_Click" />
                      <LGM:CTL_ItemCategorySpecs ID="gvItemProperty" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                      <asp:AsyncPostBackTrigger ControlID="showhere" EventName="Click" />
                    </Triggers>
                  </asp:UpdatePanel>
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_ItemDescription" runat="server" Text="Item Description :" />&nbsp;
                </td>
                <td colspan="3">
                  <asp:TextBox ID="F_ItemDescription"
                    Text='<%# Bind("ItemDescription") %>'
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter value for Item Description."
                    MaxLength="1000"
                    Width="95%"
                    ClientIDMode="Static"
                    TextMode="MultiLine"
                    Height="36px"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_Quantity" runat="server" Text="Quantity :" /><span style="color: red">*</span>
                </td>
                <td>
                  <asp:TextBox ID="F_Quantity"
                    Text='<%# Bind("Quantity") %>'
                    Width="184px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    ValidationGroup="purIndentDetails"
                    MaxLength="22"
                    onfocus="return this.select();"
                    onblur="dc(this,4);validate_tots(this);"
                    runat="server" />
                  <asp:CompareValidator
                    ID="CVQuantity"
                    runat="server"
                    ControlToValidate="F_Quantity"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Operator="GreaterThan"
                    Display="Dynamic"
                    ValidationGroup="purIndentDetails"
                    Type="Double"
                    ValueToCompare="0.0001" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_Price" runat="server" Text="Price :" /><span style="color: red">*</span>
                </td>
                <td>
                  <asp:TextBox ID="F_Price"
                    Text='<%# Bind("Price") %>'
                    Width="184px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    ValidationGroup="purIndentDetails"
                    MaxLength="22"
                    onfocus="return this.select();"
                    onblur="dc(this,4);validate_tots(this);"
                    runat="server" />
                  <asp:CompareValidator
                    ID="CVPrice"
                    runat="server"
                    ControlToValidate="F_Price"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Operator="GreaterThan"
                    Display="Dynamic"
                    ValidationGroup="purIndentDetails"
                    Type="Double"
                    ValueToCompare="0.0001" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="Label1" runat="server" Text="Amount :" />&nbsp;
                </td>
                <td colspan="3">
                  <asp:TextBox ID="F_Amount"
                    Text='<%# Bind("Amount") %>'
                    Enabled="false"
                    Width="184px"
                    CssClass="dmytxt"
                    Style="text-align: Right"
                    MaxLength="22"
                    runat="server" />
                </td>

              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_AssessableValue" runat="server" Text="Assessable Value :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_AssessableValue"
                    Text='<%# Bind("AssessableValue") %>'
                    Width="184px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    MaxLength="22"
                    onfocus="return this.select();"
                    onblur="dc(this,4);validate_tots(this);"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_TaxCode" runat="server" Text="Tax Code :" />&nbsp;
                </td>
                <td>
                  <LGM:LC_purTaxCodes
                    ID="F_TaxCode"
                    SelectedValue='<%# Bind("TaxCode") %>'
                    OrderBy="DisplayField"
                    DataTextField="DisplayField"
                    DataValueField="PrimaryKey"
                    IncludeDefault="true"
                    DefaultText="-- Select --"
                    Width="200px"
                    CssClass="myddl"
                    runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_CGSTRate" runat="server" Text="CGST Rate :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_CGSTRate"
                    Text='<%# Bind("CGSTRate") %>'
                    Width="184px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    MaxLength="22"
                    onfocus="return this.select();"
                    onblur="dc(this,4);validate_tots(this);"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_CGSTAmount" runat="server" Text="CGST Amount :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_CGSTAmount"
                    Text='<%# Bind("CGSTAmount") %>'
                    Width="184px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    MaxLength="22"
                    onfocus="return this.select();"
                    onblur="dc(this,4);validate_tots(this);"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_SGSTRate" runat="server" Text="SGST Rate :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_SGSTRate"
                    Text='<%# Bind("SGSTRate") %>'
                    Width="184px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    MaxLength="22"
                    onfocus="return this.select();"
                    onblur="dc(this,4);validate_tots(this);"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_SGSTAmount" runat="server" Text="SGST Amount :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_SGSTAmount"
                    Text='<%# Bind("SGSTAmount") %>'
                    Width="184px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    MaxLength="22"
                    onfocus="return this.select();"
                    onblur="dc(this,4);validate_tots(this);"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_IGSTrate" runat="server" Text="IGST Rate :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_IGSTrate"
                    Text='<%# Bind("IGSTrate") %>'
                    Width="184px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    MaxLength="22"
                    onfocus="return this.select();"
                    onblur="dc(this,4);validate_tots(this);"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_IGSTAmount" runat="server" Text="IGST Amount :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_IGSTAmount"
                    Text='<%# Bind("IGSTAmount") %>'
                    Width="184px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    MaxLength="22"
                    onfocus="return this.select();"
                    onblur="dc(this,4);validate_tots(this);"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_CESSRate" runat="server" Text="CESS Rate :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_CESSRate"
                    Text='<%# Bind("CESSRate") %>'
                    Width="184px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    MaxLength="22"
                    onfocus="return this.select();"
                    onblur="dc(this,4);validate_tots(this);"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_CESSAmount" runat="server" Text="CESS Amount :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_CESSAmount"
                    Text='<%# Bind("CESSAmount") %>'
                    Width="184px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    MaxLength="22"
                    onfocus="return this.select();"
                    onblur="dc(this,4);validate_tots(this);"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_TCSRate" runat="server" Text="TCS Rate :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_TCSRate"
                    Text='<%# Bind("TCSRate") %>'
                    Width="184px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    MaxLength="22"
                    onfocus="return this.select();"
                    onblur="dc(this,4);validate_tots(this);"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_TCSAmount" runat="server" Text="TCS Amount :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_TCSAmount"
                    Text='<%# Bind("TCSAmount") %>'
                    Width="184px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    MaxLength="22"
                    onfocus="return this.select();"
                    onblur="dc(this,4);validate_tots(this);"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_CurrencyID" runat="server" Text="Currency :" /><span style="color: red">*</span>
                </td>
                <td>
                  <LGM:LC_purCurrencies
                    ID="F_CurrencyID"
                    SelectedValue='<%# Bind("CurrencyID") %>'
                    OrderBy="DisplayField"
                    DataTextField="DisplayField"
                    DataValueField="PrimaryKey"
                    IncludeDefault="true"
                    DefaultText="-- Select --"
                    Width="200px"
                    CssClass="myddl"
                    ValidationGroup="purIndentDetails"
                    RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
                    runat="Server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_ConversionFactorINR" runat="server" Text="Conversion Factor [INR] :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_ConversionFactorINR"
                    Text='<%# Bind("ConversionFactorINR") %>'
                    Width="200px"
                    CssClass="mytxt"
                    Style="text-align: Right"
                    MaxLength="24"
                    onfocus="return this.select();"
                    onblur="dc(this,4);validate_tots(this);"
                    runat="server" />
                  <asp:CompareValidator
                    ID="CVConversionFactorINR"
                    runat="server"
                    ControlToValidate="F_ConversionFactorINR"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Operator="GreaterThan"
                    Display="Dynamic"
                    ValidationGroup="purIndentDetails"
                    Type="Double"
                    ValueToCompare="0.000001" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_TotalGST" runat="server" Text="Total GST :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_TotalGST"
                    Text='<%# Bind("TotalGST") %>'
                    Enabled="False"
                    ToolTip="Value of Total GST."
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: right"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_TaxAmount" runat="server" Text="Total GST [INR] :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_TaxAmount"
                    Text='<%# Bind("TaxAmount") %>'
                    Enabled="False"
                    ToolTip="Value of Total GST [INR]."
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: right"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_TotalAmount" runat="server" Text="Total Amount :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_TotalAmount"
                    Text='<%# Bind("TotalAmount") %>'
                    Enabled="False"
                    ToolTip="Value of Total Amount."
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: right"
                    runat="server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_TotalAmountINR" runat="server" Text="Total Amount INR :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_TotalAmountINR"
                    Text='<%# Bind("TotalAmountINR") %>'
                    Enabled="False"
                    ToolTip="Value of Total Amount INR."
                    Width="168px"
                    CssClass="dmytxt"
                    Style="text-align: right"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_TranTypeID" runat="server" Text="Tran Type :" />&nbsp;
                </td>
                <td colspan="3">
                  <LGM:LC_spmtTranTypes
                    ID="F_TranTypeID"
                    SelectedValue='<%# Bind("TranTypeID") %>'
                    OrderBy="DisplayField"
                    DataTextField="DisplayField"
                    DataValueField="PrimaryKey"
                    IncludeDefault="true"
                    DefaultText="-- Select --"
                    Width="200px"
                    CssClass="myddl"
                    runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_BillType" runat="server" Text="HSN Type :" />&nbsp;
                </td>
                <td>
                  <LGM:LC_spmtBillTypes
                    ID="F_BillType"
                    SelectedValue='<%# Bind("BillType") %>'
                    OrderBy="DisplayField"
                    DataTextField="DisplayField"
                    DataValueField="PrimaryKey"
                    IncludeDefault="true"
                    DefaultText="-- Select --"
                    Width="200px"
                    CssClass="myddl"
                    runat="Server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_HSNSACCode" runat="server" Text="HSN/SAC Code :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox
                    ID="F_HSNSACCode"
                    CssClass="myfktxt"
                    Width="168px"
                    Text='<%# Bind("HSNSACCode") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for HSN/SAC Code."
                    onblur="script_purIndentDetails.validate_HSNSACCode(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_HSNSACCode_Display"
                    Text='<%# Eval("SPMT_HSNSACCodes14_HSNSACCode") %>'
                    CssClass="myLbl"
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACEHSNSACCode"
                    BehaviorID="B_ACEHSNSACCode"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="HSNSACCodeCompletionList"
                    TargetControlID="F_HSNSACCode"
                    EnableCaching="false"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="script_purIndentDetails.ACEHSNSACCode_Selected"
                    OnClientPopulating="script_purIndentDetails.ACEHSNSACCode_Populating"
                    OnClientPopulated="script_purIndentDetails.ACEHSNSACCode_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_DeliveryDate" runat="server" Text="Delivery Date :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_DeliveryDate"
                    Text='<%# Bind("DeliveryDate") %>'
                    Width="80px"
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    runat="server" />
                  <asp:Image ID="ImageButtonDeliveryDate" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer; vertical-align: bottom" ImageUrl="~/Images/cal.png" />
                  <AJX:CalendarExtender
                    ID="CEDeliveryDate"
                    TargetControlID="F_DeliveryDate"
                    Format="dd/MM/yyyy"
                    runat="server" CssClass="MyCalendar" PopupButtonID="ImageButtonDeliveryDate" />
                  <AJX:MaskedEditExtender
                    ID="MEEDeliveryDate"
                    runat="server"
                    Mask="99/99/9999"
                    MaskType="Date"
                    CultureName="en-GB"
                    MessageValidatorTip="true"
                    InputDirection="LeftToRight"
                    ErrorTooltipEnabled="true"
                    TargetControlID="F_DeliveryDate" />
                  <AJX:MaskedEditValidator
                    ID="MEVDeliveryDate"
                    runat="server"
                    ControlToValidate="F_DeliveryDate"
                    ControlExtender="MEEDeliveryDate"
                    EmptyValueBlurredText="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    IsValidEmpty="True"
                    SetFocusOnError="true" />
                </td>
                <td></td>
                <td></td>
              </tr>
              <tr>
                <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_ProjectID" runat="server" Text="Project :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox
                    ID="F_ProjectID"
                    CssClass="myfktxt"
                    Width="56px"
                    Text='<%# Bind("ProjectID") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for Project."
                    onblur="script_purIndentDetails.validate_ProjectID(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_ProjectID_Display"
                    Text='<%# Eval("IDM_Projects4_Description") %>'
                    CssClass="myLbl"
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACEProjectID"
                    BehaviorID="B_ACEProjectID"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="ProjectIDCompletionList"
                    TargetControlID="F_ProjectID"
                    EnableCaching="false"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="script_purIndentDetails.ACEProjectID_Selected"
                    OnClientPopulating="script_purIndentDetails.ACEProjectID_Populating"
                    OnClientPopulated="script_purIndentDetails.ACEProjectID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_ElementID" runat="server" Text="Element :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox
                    ID="F_ElementID"
                    CssClass="myfktxt"
                    Width="72px"
                    Text='<%# Bind("ElementID") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for Element."
                    onblur="script_purIndentDetails.validate_ElementID(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_ElementID_Display"
                    Text='<%# Eval("IDM_WBS5_Description") %>'
                    CssClass="myLbl"
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACEElementID"
                    BehaviorID="B_ACEElementID"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="ElementIDCompletionList"
                    TargetControlID="F_ElementID"
                    EnableCaching="false"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="script_purIndentDetails.ACEElementID_Selected"
                    OnClientPopulating="script_purIndentDetails.ACEElementID_Populating"
                    OnClientPopulated="script_purIndentDetails.ACEElementID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_EmployeeID" runat="server" Text="Employee :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox
                    ID="F_EmployeeID"
                    CssClass="myfktxt"
                    Width="72px"
                    Text='<%# Bind("EmployeeID") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for Employee."
                    onblur="script_purIndentDetails.validate_EmployeeID(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_EmployeeID_Display"
                    Text='<%# Eval("HRM_Employees3_EmployeeName") %>'
                    CssClass="myLbl"
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACEEmployeeID"
                    BehaviorID="B_ACEEmployeeID"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="EmployeeIDCompletionList"
                    TargetControlID="F_EmployeeID"
                    EnableCaching="false"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="script_purIndentDetails.ACEEmployeeID_Selected"
                    OnClientPopulating="script_purIndentDetails.ACEEmployeeID_Populating"
                    OnClientPopulated="script_purIndentDetails.ACEEmployeeID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_DepartmentID" runat="server" Text="Department :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox
                    ID="F_DepartmentID"
                    CssClass="myfktxt"
                    Width="56px"
                    Text='<%# Bind("DepartmentID") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for Department."
                    onblur="script_purIndentDetails.validate_DepartmentID(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_DepartmentID_Display"
                    Text='<%# Eval("HRM_Departments1_Description") %>'
                    CssClass="myLbl"
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACEDepartmentID"
                    BehaviorID="B_ACEDepartmentID"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="DepartmentIDCompletionList"
                    TargetControlID="F_DepartmentID"
                    EnableCaching="false"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="script_purIndentDetails.ACEDepartmentID_Selected"
                    OnClientPopulating="script_purIndentDetails.ACEDepartmentID_Populating"
                    OnClientPopulated="script_purIndentDetails.ACEDepartmentID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_CostCenterID" runat="server" Text="Cost Center :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox
                    ID="F_CostCenterID"
                    CssClass="myfktxt"
                    Width="56px"
                    Text='<%# Bind("CostCenterID") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for Cost Center."
                    onblur="script_purIndentDetails.validate_CostCenterID(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_CostCenterID_Display"
                    Text='<%# Eval("SPMT_CostCenters11_Description") %>'
                    CssClass="myLbl"
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACECostCenterID"
                    BehaviorID="B_ACECostCenterID"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="CostCenterIDCompletionList"
                    TargetControlID="F_CostCenterID"
                    EnableCaching="false"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="script_purIndentDetails.ACECostCenterID_Selected"
                    OnClientPopulating="script_purIndentDetails.ACECostCenterID_Populating"
                    OnClientPopulated="script_purIndentDetails.ACECostCenterID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
                <td class="alignright">
                  <asp:Label ID="L_DivisionID" runat="server" Text="Division :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox
                    ID="F_DivisionID"
                    CssClass="myfktxt"
                    Width="56px"
                    Text='<%# Bind("DivisionID") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for Division."
                    onblur="script_purIndentDetails.validate_DivisionID(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_DivisionID_Display"
                    Text='<%# Eval("HRM_Divisions2_Description") %>'
                    CssClass="myLbl"
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACEDivisionID"
                    BehaviorID="B_ACEDivisionID"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="DivisionIDCompletionList"
                    TargetControlID="F_DivisionID"
                    EnableCaching="false"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="script_purIndentDetails.ACEDivisionID_Selected"
                    OnClientPopulating="script_purIndentDetails.ACEDivisionID_Populating"
                    OnClientPopulated="script_purIndentDetails.ACEDivisionID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
              </tr>
            </table>
          </div>
        </InsertItemTemplate>
      </asp:FormView>
      <asp:ObjectDataSource
        ID="ODSpurIndentDetails"
        DataObjectTypeName="SIS.PUR.purIndentDetails"
        InsertMethod="UZ_purIndentDetailsInsert"
        OldValuesParameterFormatString="original_{0}"
        TypeName="SIS.PUR.purIndentDetails"
        SelectMethod="GetNewRecord"
        runat="server"></asp:ObjectDataSource>
    </div>
  </div>
</asp:Content>
