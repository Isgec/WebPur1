<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_purItemCategorySpecs.aspx.vb" Inherits="EF_purItemCategorySpecs" title="Edit: Category Spec" %>
<asp:Content ID="CPHpurItemCategorySpecs" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurItemCategorySpecs" runat="server" Text="&nbsp;Edit: Category Spec"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurItemCategorySpecs" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurItemCategorySpecs"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "purItemCategorySpecs"
    runat = "server" />
<asp:FormView ID="FVpurItemCategorySpecs"
  runat = "server"
  DataKeyNames = "ItemCategoryID,CategorySpecID"
  DataSourceID = "ODSpurItemCategorySpecs"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemCategoryID" runat="server" ForeColor="#CC6633" Text="Item Category :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ItemCategoryID"
            Width="88px"
            Text='<%# Bind("ItemCategoryID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Item Category."
            Runat="Server" />
          <asp:Label
            ID = "F_ItemCategoryID_Display"
            Text='<%# Eval("PUR_ItemCategories1_CategoryName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CategorySpecID" runat="server" ForeColor="#CC6633" Text="Category Spec :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CategorySpecID"
            Width="88px"
            Text='<%# Bind("CategorySpecID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Category Spec."
            Runat="Server" />
          <asp:Label
            ID = "F_CategorySpecID_Display"
            Text='<%# Eval("PUR_ItemCategorySpecValues2_Data1Value") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SpecID" runat="server" Text="Spec :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_SpecID"
            CssClass = "myfktxt"
            Text='<%# Bind("SpecID") %>'
            AutoCompleteType = "None"
            Width="88px"
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
          <asp:Button ID="cmdImport" runat="server" CssClass="nt-but-primary" Text="Import" OnClientClick="return confirm('Existing data will be deleted and new values will be populated. Do you want to continue ?');" OnClick="cmdImport_Click" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SpecName" runat="server" Text="Spec Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SpecName"
            Text='<%# Bind("SpecName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purItemCategorySpecs"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Spec Name."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DefaultValueSerialNo" runat="server" Text="Default Value Serial No :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_DefaultValueSerialNo"
            CssClass = "myfktxt"
            Text='<%# Bind("DefaultValueSerialNo") %>'
            AutoCompleteType = "None"
            Width="88px"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsFixed" runat="server" Text="Is Fixed :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_IsFixed"
            Checked='<%# Bind("IsFixed") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsDerived" runat="server" Text="Is Derived :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_IsDerived"
            Checked='<%# Bind("IsDerived") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ValidateValue" runat="server" Text="Validate Value :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_ValidateValue"
            Checked='<%# Bind("ValidateValue") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UseValues" runat="server" Text="Use Values :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_UseValues"
            Checked='<%# Bind("UseValues") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AllowUserValue" runat="server" Text="Allow User Value :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_AllowUserValue"
            Checked='<%# Bind("AllowUserValue") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpurItemCategorySpecValues" runat="server" Text="&nbsp;List: Category Spec Values"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurItemCategorySpecValues" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurItemCategorySpecValues"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purItemCategorySpecValues.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purItemCategorySpecValues.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "purItemCategorySpecValues"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurItemCategorySpecValues" runat="server" AssociatedUpdatePanelID="UPNLpurItemCategorySpecValues" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpurItemCategorySpecValues" SkinID="gv_silver" runat="server" DataSourceID="ODSpurItemCategorySpecValues" DataKeyNames="ItemCategoryID,CategorySpecID,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Category" SortExpression="[PUR_ItemCategories1].[CategoryName]">
          <ItemTemplate>
             <asp:Label ID="L_ItemCategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemCategoryID") %>' Text='<%# Eval("PUR_ItemCategories1_CategoryName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category Spec" SortExpression="[PUR_ItemCategorySpecs2].[SpecName]">
          <ItemTemplate>
             <asp:Label ID="L_CategorySpecID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CategorySpecID") %>' Text='<%# Eval("PUR_ItemCategorySpecs2_SpecName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="[PUR_ItemCategorySpecValues].[SerialNo]">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Value Data Type" SortExpression="[PUR_ValueDataTypes3].[ValueDataTypeName]">
          <ItemTemplate>
             <asp:Label ID="L_ValueDataTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ValueDataTypeID") %>' Text='<%# Eval("PUR_ValueDataTypes3_ValueDataTypeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Is Range" SortExpression="[PUR_ItemCategorySpecValues].[IsRange]">
          <ItemTemplate>
            <asp:Label ID="LabelIsRange" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IsRange") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Data Value [1]" SortExpression="[PUR_ItemCategorySpecValues].[Data1Value]">
          <ItemTemplate>
            <asp:Label ID="LabelData1Value" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Data1Value") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Data Value [2]" SortExpression="[PUR_ItemCategorySpecValues].[Data2Value]">
          <ItemTemplate>
            <asp:Label ID="LabelData2Value" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Data2Value") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpurItemCategorySpecValues"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purItemCategorySpecValues"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purItemCategorySpecValuesSelectList"
      TypeName = "SIS.PUR.purItemCategorySpecValues"
      SelectCountMethod = "purItemCategorySpecValuesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ItemCategoryID" PropertyName="Text" Name="ItemCategoryID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_CategorySpecID" PropertyName="Text" Name="CategorySpecID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpurItemCategorySpecValues" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpurItemCategorySpecs"
  DataObjectTypeName = "SIS.PUR.purItemCategorySpecs"
  SelectMethod = "purItemCategorySpecsGetByID"
  UpdateMethod="purItemCategorySpecsUpdate"
  DeleteMethod="purItemCategorySpecsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purItemCategorySpecs"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemCategoryID" Name="ItemCategoryID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CategorySpecID" Name="CategorySpecID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
