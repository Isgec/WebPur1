<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_purReceiptItemProperty.aspx.vb" Inherits="AF_purReceiptItemProperty" title="Add: Receipt Item Property" %>
<asp:Content ID="CPHpurReceiptItemProperty" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurReceiptItemProperty" runat="server" Text="&nbsp;Add: Receipt Item Property"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurReceiptItemProperty" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurReceiptItemProperty"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "purReceiptItemProperty"
    runat = "server" />
<asp:FormView ID="FVpurReceiptItemProperty"
  runat = "server"
  DataKeyNames = "ReceiptNo,ReceiptLine,ItemCode,ItemCategoryID,CategorySpecID"
  DataSourceID = "ODSpurReceiptItemProperty"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpurReceiptItemProperty" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ReceiptNo" ForeColor="#CC6633" runat="server" Text="Receipt No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ReceiptNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("ReceiptNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Receipt No."
            ValidationGroup = "purReceiptItemProperty"
            onblur= "script_purReceiptItemProperty.validate_ReceiptNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVReceiptNo"
            runat = "server"
            ControlToValidate = "F_ReceiptNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purReceiptItemProperty"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ReceiptNo_Display"
            Text='<%# Eval("PUR_Receipts6_IsgecGSTIN") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEReceiptNo"
            BehaviorID="B_ACEReceiptNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ReceiptNoCompletionList"
            TargetControlID="F_ReceiptNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purReceiptItemProperty.ACEReceiptNo_Selected"
            OnClientPopulating="script_purReceiptItemProperty.ACEReceiptNo_Populating"
            OnClientPopulated="script_purReceiptItemProperty.ACEReceiptNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_ReceiptLine" ForeColor="#CC6633" runat="server" Text="Receipt Line :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ReceiptLine"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("ReceiptLine") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Receipt Line."
            ValidationGroup = "purReceiptItemProperty"
            onblur= "script_purReceiptItemProperty.validate_ReceiptLine(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVReceiptLine"
            runat = "server"
            ControlToValidate = "F_ReceiptLine"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purReceiptItemProperty"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ReceiptLine_Display"
            Text='<%# Eval("PUR_ReceiptDetails5_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEReceiptLine"
            BehaviorID="B_ACEReceiptLine"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ReceiptLineCompletionList"
            TargetControlID="F_ReceiptLine"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purReceiptItemProperty.ACEReceiptLine_Selected"
            OnClientPopulating="script_purReceiptItemProperty.ACEReceiptLine_Populating"
            OnClientPopulated="script_purReceiptItemProperty.ACEReceiptLine_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
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
            ValidationGroup = "purReceiptItemProperty"
            onblur= "script_purReceiptItemProperty.validate_ItemCode(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemCode"
            runat = "server"
            ControlToValidate = "F_ItemCode"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purReceiptItemProperty"
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
            OnClientItemSelected="script_purReceiptItemProperty.ACEItemCode_Selected"
            OnClientPopulating="script_purReceiptItemProperty.ACEItemCode_Populating"
            OnClientPopulated="script_purReceiptItemProperty.ACEItemCode_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
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
            ValidationGroup = "purReceiptItemProperty"
            onblur= "script_purReceiptItemProperty.validate_ItemCategoryID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemCategoryID"
            runat = "server"
            ControlToValidate = "F_ItemCategoryID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purReceiptItemProperty"
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
            OnClientItemSelected="script_purReceiptItemProperty.ACEItemCategoryID_Selected"
            OnClientPopulating="script_purReceiptItemProperty.ACEItemCategoryID_Populating"
            OnClientPopulated="script_purReceiptItemProperty.ACEItemCategoryID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
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
            ValidationGroup = "purReceiptItemProperty"
            onblur= "script_purReceiptItemProperty.validate_CategorySpecID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCategorySpecID"
            runat = "server"
            ControlToValidate = "F_CategorySpecID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purReceiptItemProperty"
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
            OnClientItemSelected="script_purReceiptItemProperty.ACECategorySpecID_Selected"
            OnClientPopulating="script_purReceiptItemProperty.ACECategorySpecID_Populating"
            OnClientPopulated="script_purReceiptItemProperty.ACECategorySpecID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SerialNo" runat="server" Text="Serial No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Serial No."
            onblur= "script_purReceiptItemProperty.validate_SerialNo(this);"
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
            OnClientItemSelected="script_purReceiptItemProperty.ACESerialNo_Selected"
            OnClientPopulating="script_purReceiptItemProperty.ACESerialNo_Populating"
            OnClientPopulated="script_purReceiptItemProperty.ACESerialNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ValueDataTypeID" runat="server" Text="Value Data Type :" />&nbsp;
        </td>
        <td>
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
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_IsRange" runat="server" Text="Is Range :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_IsRange"
           Checked='<%# Bind("IsRange") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Data1Value" runat="server" Text="Data Value [1] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Data1Value"
            Text='<%# Bind("Data1Value") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Data Value [1]."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Data2Value" runat="server" Text="Data Value [2] :" />&nbsp;
        </td>
        <td>
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
  ID = "ODSpurReceiptItemProperty"
  DataObjectTypeName = "SIS.PUR.purReceiptItemProperty"
  InsertMethod="purReceiptItemPropertyInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purReceiptItemProperty"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
