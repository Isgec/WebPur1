<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_purOrderItemProperty.aspx.vb" Inherits="EF_purOrderItemProperty" title="Edit: Order Item Property" %>
<asp:Content ID="CPHpurOrderItemProperty" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurOrderItemProperty" runat="server" Text="&nbsp;Edit: Order Item Property"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurOrderItemProperty" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurOrderItemProperty"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "purOrderItemProperty"
    runat = "server" />
<asp:FormView ID="FVpurOrderItemProperty"
  runat = "server"
  DataKeyNames = "OrderNo,OrderRev,OrderLine,ItemCode,ItemCategoryID,CategorySpecID"
  DataSourceID = "ODSpurOrderItemProperty"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_OrderNo" runat="server" ForeColor="#CC6633" Text="Order No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_OrderNo"
            Width="88px"
            Text='<%# Bind("OrderNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Order No."
            Runat="Server" />
          <asp:Label
            ID = "F_OrderNo_Display"
            Text='<%# Eval("PUR_Orders6_IsgecGSTIN") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_OrderRev" runat="server" ForeColor="#CC6633" Text="Order Rev :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_OrderRev"
            Text='<%# Bind("OrderRev") %>'
            ToolTip="Value of Order Rev."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_OrderLine" runat="server" ForeColor="#CC6633" Text="Order Line :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_OrderLine"
            Width="88px"
            Text='<%# Bind("OrderLine") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Order Line."
            Runat="Server" />
          <asp:Label
            ID = "F_OrderLine_Display"
            Text='<%# Eval("PUR_OrderDetails5_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
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
      </tr>
      <tr>
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
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SerialNo" runat="server" Text="Serial No :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_SerialNo"
            CssClass = "myfktxt"
            Text='<%# Bind("SerialNo") %>'
            AutoCompleteType = "None"
            Width="88px"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Data1Value" runat="server" Text="Data Value [1] :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Data1Value"
            Text='<%# Bind("Data1Value") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purOrderItemProperty"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Data Value [1]."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Data2Value" runat="server" Text="Data Value [2] :" />&nbsp;
        </td>
        <td colspan="3">
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
  ID = "ODSpurOrderItemProperty"
  DataObjectTypeName = "SIS.PUR.purOrderItemProperty"
  SelectMethod = "purOrderItemPropertyGetByID"
  UpdateMethod="purOrderItemPropertyUpdate"
  DeleteMethod="purOrderItemPropertyDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purOrderItemProperty"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="OrderNo" Name="OrderNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="OrderRev" Name="OrderRev" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="OrderLine" Name="OrderLine" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemCode" Name="ItemCode" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemCategoryID" Name="ItemCategoryID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CategorySpecID" Name="CategorySpecID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
