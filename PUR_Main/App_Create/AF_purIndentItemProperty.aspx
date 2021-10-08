<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_purIndentItemProperty.aspx.vb" Inherits="AF_purIndentItemProperty" title="Add: Indent Item Property" %>
<asp:Content ID="CPHpurIndentItemProperty" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurIndentItemProperty" runat="server" Text="&nbsp;Add: Indent Item Property"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurIndentItemProperty" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurIndentItemProperty"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "purIndentItemProperty"
    runat = "server" />
<asp:FormView ID="FVpurIndentItemProperty"
  runat = "server"
  DataKeyNames = "IndentNo,IndentLine,ItemCode,ItemCategoryID,CategorySpecID"
  DataSourceID = "ODSpurIndentItemProperty"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpurIndentItemProperty" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IndentNo" ForeColor="#CC6633" runat="server" Text="Indent No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_IndentNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("IndentNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Indent No."
            ValidationGroup = "purIndentItemProperty"
            onblur= "script_purIndentItemProperty.validate_IndentNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVIndentNo"
            runat = "server"
            ControlToValidate = "F_IndentNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purIndentItemProperty"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_IndentNo_Display"
            Text='<%# Eval("PUR_Indents2_IndenterRemarks") %>'
            CssClass="myLbl"
            Runat="Server" />
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
            OnClientItemSelected="script_purIndentItemProperty.ACEIndentNo_Selected"
            OnClientPopulating="script_purIndentItemProperty.ACEIndentNo_Populating"
            OnClientPopulated="script_purIndentItemProperty.ACEIndentNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_IndentLine" ForeColor="#CC6633" runat="server" Text="Indent Line :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_IndentLine"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("IndentLine") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Indent Line."
            ValidationGroup = "purIndentItemProperty"
            onblur= "script_purIndentItemProperty.validate_IndentLine(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVIndentLine"
            runat = "server"
            ControlToValidate = "F_IndentLine"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purIndentItemProperty"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_IndentLine_Display"
            Text='<%# Eval("PUR_IndentDetails1_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEIndentLine"
            BehaviorID="B_ACEIndentLine"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="IndentLineCompletionList"
            TargetControlID="F_IndentLine"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purIndentItemProperty.ACEIndentLine_Selected"
            OnClientPopulating="script_purIndentItemProperty.ACEIndentLine_Populating"
            OnClientPopulated="script_purIndentItemProperty.ACEIndentLine_Populated"
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
            ValidationGroup = "purIndentItemProperty"
            onblur= "script_purIndentItemProperty.validate_ItemCode(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemCode"
            runat = "server"
            ControlToValidate = "F_ItemCode"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purIndentItemProperty"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ItemCode_Display"
            Text='<%# Eval("PUR_Items6_ItemDescription") %>'
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
            OnClientItemSelected="script_purIndentItemProperty.ACEItemCode_Selected"
            OnClientPopulating="script_purIndentItemProperty.ACEItemCode_Populating"
            OnClientPopulated="script_purIndentItemProperty.ACEItemCode_Populated"
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
            ValidationGroup = "purIndentItemProperty"
            onblur= "script_purIndentItemProperty.validate_ItemCategoryID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemCategoryID"
            runat = "server"
            ControlToValidate = "F_ItemCategoryID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purIndentItemProperty"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ItemCategoryID_Display"
            Text='<%# Eval("PUR_ItemCategories3_CategoryName") %>'
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
            OnClientItemSelected="script_purIndentItemProperty.ACEItemCategoryID_Selected"
            OnClientPopulating="script_purIndentItemProperty.ACEItemCategoryID_Populating"
            OnClientPopulated="script_purIndentItemProperty.ACEItemCategoryID_Populated"
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
            ValidationGroup = "purIndentItemProperty"
            onblur= "script_purIndentItemProperty.validate_CategorySpecID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCategorySpecID"
            runat = "server"
            ControlToValidate = "F_CategorySpecID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purIndentItemProperty"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_CategorySpecID_Display"
            Text='<%# Eval("PUR_ItemCategorySpecs4_SpecName") %>'
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
            OnClientItemSelected="script_purIndentItemProperty.ACECategorySpecID_Selected"
            OnClientPopulating="script_purIndentItemProperty.ACECategorySpecID_Populating"
            OnClientPopulated="script_purIndentItemProperty.ACECategorySpecID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
            onblur= "script_purIndentItemProperty.validate_SerialNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("PUR_ItemCategorySpecValues5_Data1Value") %>'
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
            OnClientItemSelected="script_purIndentItemProperty.ACESerialNo_Selected"
            OnClientPopulating="script_purIndentItemProperty.ACESerialNo_Populating"
            OnClientPopulated="script_purIndentItemProperty.ACESerialNo_Populated"
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
            ValidationGroup = "purIndentItemProperty"
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
            ValidationGroup="purIndentItemProperty"
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
            ValidationGroup = "purIndentItemProperty"
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
  ID = "ODSpurIndentItemProperty"
  DataObjectTypeName = "SIS.PUR.purIndentItemProperty"
  InsertMethod="purIndentItemPropertyInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purIndentItemProperty"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
