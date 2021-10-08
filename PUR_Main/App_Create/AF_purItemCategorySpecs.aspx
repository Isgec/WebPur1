<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_purItemCategorySpecs.aspx.vb" Inherits="AF_purItemCategorySpecs" title="Add: Category Spec" %>
<asp:Content ID="CPHpurItemCategorySpecs" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurItemCategorySpecs" runat="server" Text="&nbsp;Add: Category Spec"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurItemCategorySpecs" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurItemCategorySpecs"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/PUR_Main/App_Edit/EF_purItemCategorySpecs.aspx"
    ValidationGroup = "purItemCategorySpecs"
    runat = "server" />
<asp:FormView ID="FVpurItemCategorySpecs"
  runat = "server"
  DataKeyNames = "ItemCategoryID,CategorySpecID"
  DataSourceID = "ODSpurItemCategorySpecs"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpurItemCategorySpecs" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemCategoryID" ForeColor="#CC6633" runat="server" Text="Item Category :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ItemCategoryID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("ItemCategoryID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Item Category."
            ValidationGroup = "purItemCategorySpecs"
            onblur= "script_purItemCategorySpecs.validate_ItemCategoryID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemCategoryID"
            runat = "server"
            ControlToValidate = "F_ItemCategoryID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purItemCategorySpecs"
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
            OnClientItemSelected="script_purItemCategorySpecs.ACEItemCategoryID_Selected"
            OnClientPopulating="script_purItemCategorySpecs.ACEItemCategoryID_Populating"
            OnClientPopulated="script_purItemCategorySpecs.ACEItemCategoryID_Populated"
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
        <td colspan="3">
          <asp:TextBox ID="F_CategorySpecID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SpecID" runat="server" Text="Spec :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_SpecID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("SpecID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Spec."
            onblur= "script_purItemCategorySpecs.validate_SpecID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SpecID_Display"
            Text='<%# Eval("PUR_ItemSpecification3_SpecName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESpecID"
            BehaviorID="B_ACESpecID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SpecIDCompletionList"
            TargetControlID="F_SpecID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purItemCategorySpecs.ACESpecID_Selected"
            OnClientPopulating="script_purItemCategorySpecs.ACESpecID_Populating"
            OnClientPopulated="script_purItemCategorySpecs.ACESpecID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SpecName" runat="server" Text="Spec Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SpecName"
            Text='<%# Bind("SpecName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purItemCategorySpecs"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Spec Name."
            MaxLength="50"
            Width="408px"
            ClientIDMode="Static"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSpecName"
            runat = "server"
            ControlToValidate = "F_SpecName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purItemCategorySpecs"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DefaultValueSerialNo" runat="server" Text="Default Value Serial No :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_DefaultValueSerialNo"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("DefaultValueSerialNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Default Value Serial No."
            onblur= "script_purItemCategorySpecs.validate_DefaultValueSerialNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_DefaultValueSerialNo_Display"
            Text='<%# Eval("PUR_ItemCategorySpecValues2_Data1Value") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDefaultValueSerialNo"
            BehaviorID="B_ACEDefaultValueSerialNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DefaultValueSerialNoCompletionList"
            TargetControlID="F_DefaultValueSerialNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purItemCategorySpecs.ACEDefaultValueSerialNo_Selected"
            OnClientPopulating="script_purItemCategorySpecs.ACEDefaultValueSerialNo_Populating"
            OnClientPopulated="script_purItemCategorySpecs.ACEDefaultValueSerialNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsFixed" runat="server" Text="Is Fixed :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_IsFixed"
           Checked='<%# Bind("IsFixed") %>'
           CssClass = "mychk"
            ClientIDMode="Static"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsDerived" runat="server" Text="Is Derived :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_IsDerived"
           Checked='<%# Bind("IsDerived") %>'
           CssClass = "mychk"
            ClientIDMode="Static"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ValidateValue" runat="server" Text="Validate Value :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_ValidateValue"
           Checked='<%# Bind("ValidateValue") %>'
           CssClass = "mychk"
            ClientIDMode="Static"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UseValues" runat="server" Text="Use Values :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_UseValues"
           Checked='<%# Bind("UseValues") %>'
           CssClass = "mychk"
            ClientIDMode="Static"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AllowUserValue" runat="server" Text="Allow User Value :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_AllowUserValue"
           Checked='<%# Bind("AllowUserValue") %>'
           CssClass = "mychk"
            ClientIDMode="Static"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ValueDataTypeID" runat="server" Text="Value Data TypeID :" /><span style="color:red">*</span>
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
            ClientIDMode="Static"
            ValidationGroup = "purItemCategorySpecs"
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
           ClientIDMode="Static"
           CssClass = "mychk"
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
  ID = "ODSpurItemCategorySpecs"
  DataObjectTypeName = "SIS.PUR.purItemCategorySpecs"
  InsertMethod="purItemCategorySpecsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purItemCategorySpecs"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
