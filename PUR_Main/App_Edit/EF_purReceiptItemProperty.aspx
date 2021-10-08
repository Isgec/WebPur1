<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_purReceiptItemProperty.aspx.vb" Inherits="EF_purReceiptItemProperty" title="Edit: Receipt Item Property" %>
<asp:Content ID="CPHpurReceiptItemProperty" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurReceiptItemProperty" runat="server" Text="&nbsp;Edit: Receipt Item Property"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurReceiptItemProperty" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurReceiptItemProperty"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "purReceiptItemProperty"
    runat = "server" />
<asp:FormView ID="FVpurReceiptItemProperty"
  runat = "server"
  DataKeyNames = "ReceiptNo,ReceiptLine,ItemCode,ItemCategoryID,CategorySpecID"
  DataSourceID = "ODSpurReceiptItemProperty"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ReceiptNo" runat="server" ForeColor="#CC6633" Text="Receipt No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ReceiptNo"
            Width="88px"
            Text='<%# Bind("ReceiptNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Receipt No."
            Runat="Server" />
          <asp:Label
            ID = "F_ReceiptNo_Display"
            Text='<%# Eval("PUR_Receipts6_IsgecGSTIN") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_ReceiptLine" runat="server" ForeColor="#CC6633" Text="Receipt Line :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ReceiptLine"
            Width="88px"
            Text='<%# Bind("ReceiptLine") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Receipt Line."
            Runat="Server" />
          <asp:Label
            ID = "F_ReceiptLine_Display"
            Text='<%# Eval("PUR_ReceiptDetails5_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemCode" runat="server" ForeColor="#CC6633" Text="Item Code :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ItemCode"
            Width="88px"
            Text='<%# Bind("ItemCode") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Item Code."
            Runat="Server" />
          <asp:Label
            ID = "F_ItemCode_Display"
            Text='<%# Eval("PUR_Items4_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_ItemCategoryID" runat="server" ForeColor="#CC6633" Text="Item Category :" /><span style="color:red">*</span></b>
        </td>
        <td>
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
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CategorySpecID" runat="server" ForeColor="#CC6633" Text="Category Spec :" /><span style="color:red">*</span></b>
        </td>
        <td>
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
            Text='<%# Eval("PUR_ItemCategorySpecs2_SpecName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SerialNo" runat="server" Text="Serial No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            CssClass = "myfktxt"
            Text='<%# Bind("SerialNo") %>'
            AutoCompleteType = "None"
            Width="88px"
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
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Data Value [1]."
            MaxLength="50"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Data2Value" runat="server" Text="Data Value [2] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Data2Value"
            Text='<%# Bind("Data2Value") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Data Value [2]."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpurReceiptItemProperty"
  DataObjectTypeName = "SIS.PUR.purReceiptItemProperty"
  SelectMethod = "purReceiptItemPropertyGetByID"
  UpdateMethod="purReceiptItemPropertyUpdate"
  DeleteMethod="purReceiptItemPropertyDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purReceiptItemProperty"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ReceiptNo" Name="ReceiptNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ReceiptLine" Name="ReceiptLine" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemCode" Name="ItemCode" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemCategoryID" Name="ItemCategoryID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CategorySpecID" Name="CategorySpecID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
