<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_purItemSpecValues.aspx.vb" Inherits="AF_purItemSpecValues" title="Add: Possible Values" %>
<asp:Content ID="CPHpurItemSpecValues" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurItemSpecValues" runat="server" Text="&nbsp;Add: Possible Values"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurItemSpecValues" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurItemSpecValues"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "purItemSpecValues"
    runat = "server" />
<asp:FormView ID="FVpurItemSpecValues"
  runat = "server"
  DataKeyNames = "SpecID,SerialNo"
  DataSourceID = "ODSpurItemSpecValues"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpurItemSpecValues" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SpecID" ForeColor="#CC6633" runat="server" Text="Spec ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_SpecID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("SpecID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Spec ID."
            ValidationGroup = "purItemSpecValues"
            onblur= "script_purItemSpecValues.validate_SpecID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSpecID"
            runat = "server"
            ControlToValidate = "F_SpecID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purItemSpecValues"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_SpecID_Display"
            Text='<%# Eval("PUR_ItemSpecification1_SpecName") %>'
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
            OnClientItemSelected="script_purItemSpecValues.ACESpecID_Selected"
            OnClientPopulating="script_purItemSpecValues.ACESpecID_Populating"
            OnClientPopulated="script_purItemSpecValues.ACESpecID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
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
            ValidationGroup = "purItemSpecValues"
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
            ValidationGroup="purItemSpecValues"
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
            ValidationGroup = "purItemSpecValues"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Data2Value" runat="server" Text="Data Value [2] :" />
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Data2Value"
            Text='<%# Bind("Data2Value") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purItemSpecValues"
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
  ID = "ODSpurItemSpecValues"
  DataObjectTypeName = "SIS.PUR.purItemSpecValues"
  InsertMethod="purItemSpecValuesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purItemSpecValues"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
