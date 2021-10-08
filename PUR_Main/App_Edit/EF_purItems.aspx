<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_purItems.aspx.vb" Inherits="EF_purItems" title="Edit: Item Master" %>
<asp:Content ID="CPHpurItems" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurItems" runat="server" Text="&nbsp;Edit: Item Master"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurItems" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurItems"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "purItems"
    runat = "server" />
<asp:FormView ID="FVpurItems"
  runat = "server"
  DataKeyNames = "ItemCode"
  DataSourceID = "ODSpurItems"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemCode" runat="server" ForeColor="#CC6633" Text="Item Code :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ItemCode"
            Text='<%# Bind("ItemCode") %>'
            ToolTip="Value of Item Code."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemDescription" runat="server" Text="Item Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ItemDescription"
            Text='<%# Bind("ItemDescription") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purItems"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Item Description."
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemDescription"
            runat = "server"
            ControlToValidate = "F_ItemDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purItems"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UOM" runat="server" Text="UOM :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_spmtERPUnits
            ID="F_UOM"
            SelectedValue='<%# Bind("UOM") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "purItems"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OPBQty" runat="server" Text="OPB Qty :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_OPBQty"
            Text='<%# Bind("OPBQty") %>'
            style="text-align: right"
            Width="184px"
            CssClass = "mytxt"
            MaxLength="22"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEOPBQty"
            runat = "server"
            mask = "999999999999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_OPBQty" />
          <AJX:MaskedEditValidator 
            ID = "MEVOPBQty"
            runat = "server"
            ControlToValidate = "F_OPBQty"
            ControlExtender = "MEEOPBQty"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RECQty" runat="server" Text="REC Qty :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RECQty"
            Text='<%# Bind("RECQty") %>'
            style="text-align: right"
            Width="184px"
            CssClass = "mytxt"
            MaxLength="22"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEERECQty"
            runat = "server"
            mask = "999999999999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_RECQty" />
          <AJX:MaskedEditValidator 
            ID = "MEVRECQty"
            runat = "server"
            ControlToValidate = "F_RECQty"
            ControlExtender = "MEERECQty"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ISSQty" runat="server" Text="ISS Qty :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ISSQty"
            Text='<%# Bind("ISSQty") %>'
            style="text-align: right"
            Width="184px"
            CssClass = "mytxt"
            MaxLength="22"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEISSQty"
            runat = "server"
            mask = "999999999999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ISSQty" />
          <AJX:MaskedEditValidator 
            ID = "MEVISSQty"
            runat = "server"
            ControlToValidate = "F_ISSQty"
            ControlExtender = "MEEISSQty"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BALQty" runat="server" Text="BAL Qty :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BALQty"
            Text='<%# Bind("BALQty") %>'
            style="text-align: right"
            Width="184px"
            CssClass = "mytxt"
            MaxLength="22"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEBALQty"
            runat = "server"
            mask = "999999999999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_BALQty" />
          <AJX:MaskedEditValidator 
            ID = "MEVBALQty"
            runat = "server"
            ControlToValidate = "F_BALQty"
            ControlExtender = "MEEBALQty"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemCategoryID" runat="server" Text="Item Category :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ItemCategoryID"
            CssClass = "myfktxt"
            Text='<%# Bind("ItemCategoryID") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Item Category."
            onblur= "script_purItems.validate_ItemCategoryID(this);"
            Runat="Server" />
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
            OnClientItemSelected="script_purItems.ACEItemCategoryID_Selected"
            OnClientPopulating="script_purItems.ACEItemCategoryID_Populating"
            OnClientPopulated="script_purItems.ACEItemCategoryID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
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
  ID = "ODSpurItems"
  DataObjectTypeName = "SIS.PUR.purItems"
  SelectMethod = "purItemsGetByID"
  UpdateMethod="purItemsUpdate"
  DeleteMethod="purItemsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purItems"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemCode" Name="ItemCode" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
