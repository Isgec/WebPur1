<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_purOrderItemProperty.aspx.vb" Inherits="AF_purOrderItemProperty" title="Add: Order Item Property" %>
<asp:Content ID="CPHpurOrderItemProperty" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurOrderItemProperty" runat="server" Text="&nbsp;Add: Order Item Property"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurOrderItemProperty" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurOrderItemProperty"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "purOrderItemProperty"
    runat = "server" />
<asp:FormView ID="FVpurOrderItemProperty"
  runat = "server"
  DataKeyNames = "OrderNo,OrderRev,OrderLine,ItemCode,ItemCategoryID,CategorySpecID"
  DataSourceID = "ODSpurOrderItemProperty"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpurOrderItemProperty" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_OrderNo" ForeColor="#CC6633" runat="server" Text="Order No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_OrderNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("OrderNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Order No."
            ValidationGroup = "purOrderItemProperty"
            onblur= "script_purOrderItemProperty.validate_OrderNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVOrderNo"
            runat = "server"
            ControlToValidate = "F_OrderNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purOrderItemProperty"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_OrderNo_Display"
            Text='<%# Eval("PUR_Orders6_IsgecGSTIN") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEOrderNo"
            BehaviorID="B_ACEOrderNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="OrderNoCompletionList"
            TargetControlID="F_OrderNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purOrderItemProperty.ACEOrderNo_Selected"
            OnClientPopulating="script_purOrderItemProperty.ACEOrderNo_Populating"
            OnClientPopulated="script_purOrderItemProperty.ACEOrderNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_OrderRev" ForeColor="#CC6633" runat="server" Text="Order Rev :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_OrderRev"
            Text='<%# Bind("OrderRev") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mypktxt"
            ValidationGroup="purOrderItemProperty"
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
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purOrderItemProperty"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_OrderLine" ForeColor="#CC6633" runat="server" Text="Order Line :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_OrderLine"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("OrderLine") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Order Line."
            ValidationGroup = "purOrderItemProperty"
            onblur= "script_purOrderItemProperty.validate_OrderLine(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVOrderLine"
            runat = "server"
            ControlToValidate = "F_OrderLine"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purOrderItemProperty"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_OrderLine_Display"
            Text='<%# Eval("PUR_OrderDetails5_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEOrderLine"
            BehaviorID="B_ACEOrderLine"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="OrderLineCompletionList"
            TargetControlID="F_OrderLine"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purOrderItemProperty.ACEOrderLine_Selected"
            OnClientPopulating="script_purOrderItemProperty.ACEOrderLine_Populating"
            OnClientPopulated="script_purOrderItemProperty.ACEOrderLine_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_ItemCode" ForeColor="#CC6633" runat="server" Text="Item Code :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ItemCode"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("ItemCode") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Item Code."
            ValidationGroup = "purOrderItemProperty"
            onblur= "script_purOrderItemProperty.validate_ItemCode(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemCode"
            runat = "server"
            ControlToValidate = "F_ItemCode"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purOrderItemProperty"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ItemCode_Display"
            Text='<%# Eval("PUR_Items4_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
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
            OnClientItemSelected="script_purOrderItemProperty.ACEItemCode_Selected"
            OnClientPopulating="script_purOrderItemProperty.ACEItemCode_Populating"
            OnClientPopulated="script_purOrderItemProperty.ACEItemCode_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemCategoryID" ForeColor="#CC6633" runat="server" Text="Item Category :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ItemCategoryID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("ItemCategoryID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Item Category."
            ValidationGroup = "purOrderItemProperty"
            onblur= "script_purOrderItemProperty.validate_ItemCategoryID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemCategoryID"
            runat = "server"
            ControlToValidate = "F_ItemCategoryID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purOrderItemProperty"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ItemCategoryID_Display"
            Text='<%# Eval("PUR_ItemCategories1_CategoryName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEItemCategoryID"
            BehaviorID="B_ACEItemCategoryID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ItemCategoryIDCompletionList"
            TargetControlID="F_ItemCategoryID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purOrderItemProperty.ACEItemCategoryID_Selected"
            OnClientPopulating="script_purOrderItemProperty.ACEItemCategoryID_Populating"
            OnClientPopulated="script_purOrderItemProperty.ACEItemCategoryID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_CategorySpecID" ForeColor="#CC6633" runat="server" Text="Category Spec :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CategorySpecID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("CategorySpecID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Category Spec."
            ValidationGroup = "purOrderItemProperty"
            onblur= "script_purOrderItemProperty.validate_CategorySpecID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCategorySpecID"
            runat = "server"
            ControlToValidate = "F_CategorySpecID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purOrderItemProperty"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_CategorySpecID_Display"
            Text='<%# Eval("PUR_ItemCategorySpecs2_SpecName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECategorySpecID"
            BehaviorID="B_ACECategorySpecID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CategorySpecIDCompletionList"
            TargetControlID="F_CategorySpecID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purOrderItemProperty.ACECategorySpecID_Selected"
            OnClientPopulating="script_purOrderItemProperty.ACECategorySpecID_Populating"
            OnClientPopulated="script_purOrderItemProperty.ACECategorySpecID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SerialNo" runat="server" Text="Serial No :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_SerialNo"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Serial No."
            onblur= "script_purOrderItemProperty.validate_SerialNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("PUR_ItemCategorySpecValues3_Data1Value") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESerialNo"
            BehaviorID="B_ACESerialNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SerialNoCompletionList"
            TargetControlID="F_SerialNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purOrderItemProperty.ACESerialNo_Selected"
            OnClientPopulating="script_purOrderItemProperty.ACESerialNo_Populating"
            OnClientPopulated="script_purOrderItemProperty.ACESerialNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ValueDataTypeID" runat="server" Text="Value Data Type :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_purValueDataTypes
            ID="F_ValueDataTypeID"
            SelectedValue='<%# Bind("ValueDataTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "purOrderItemProperty"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsRange" runat="server" Text="Is Range :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_IsRange"
           Checked='<%# Bind("IsRange") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Data1Value" runat="server" Text="Data Value [1] :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Data1Value"
            Text='<%# Bind("Data1Value") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purOrderItemProperty"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Data Value [1]."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVData1Value"
            runat = "server"
            ControlToValidate = "F_Data1Value"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purOrderItemProperty"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Data2Value" runat="server" Text="Data Value [2] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Data2Value"
            Text='<%# Bind("Data2Value") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Data Value [2]."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpurOrderItemProperty"
  DataObjectTypeName = "SIS.PUR.purOrderItemProperty"
  InsertMethod="purOrderItemPropertyInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purOrderItemProperty"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
