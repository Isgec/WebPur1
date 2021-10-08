<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purOrderItemProperty.aspx.vb" Inherits="GF_purOrderItemProperty" title="Maintain List: Order Item Property" %>
<asp:Content ID="CPHpurOrderItemProperty" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurOrderItemProperty" runat="server" Text="&nbsp;List: Order Item Property"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurOrderItemProperty" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurOrderItemProperty"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purOrderItemProperty.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purOrderItemProperty.aspx"
      ValidationGroup = "purOrderItemProperty"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurOrderItemProperty" runat="server" AssociatedUpdatePanelID="UPNLpurOrderItemProperty" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_OrderNo" runat="server" Text="Order No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_OrderNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_OrderNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_OrderNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEOrderNo"
            BehaviorID="B_ACEOrderNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="OrderNoCompletionList"
            TargetControlID="F_OrderNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEOrderNo_Selected"
            OnClientPopulating="ACEOrderNo_Populating"
            OnClientPopulated="ACEOrderNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_OrderRev" runat="server" Text="Order Rev :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_OrderRev"
            Text=""
            Width="88px"
            style="text-align: right"
            CssClass = "mytxt"
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
            InvalidValueMessage = "*"
            EmptyValueMessage = ""
            EmptyValueBlurredText = ""
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_OrderLine" runat="server" Text="Order Line :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_OrderLine"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_OrderLine(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_OrderLine_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEOrderLine"
            BehaviorID="B_ACEOrderLine"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="OrderLineCompletionList"
            TargetControlID="F_OrderLine"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEOrderLine_Selected"
            OnClientPopulating="ACEOrderLine_Populating"
            OnClientPopulated="ACEOrderLine_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <script type="text/javascript"> 
   var script_CategorySpecID = {
    ACECategorySpecID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('CategorySpecID','');
      var F_CategorySpecID = $get(sender._element.id);
      var F_CategorySpecID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_CategorySpecID.value = p[1];
      F_CategorySpecID_Display.innerHTML = e.get_text();
    },
    ACECategorySpecID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('CategorySpecID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECategorySpecID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_CategorySpecID: function(sender) {
      var Prefix = sender.id.replace('CategorySpecID','');
      this.validated_FK_PUR_OrderItemProperty_CategorySpecID_main = true;
      this.validate_FK_PUR_OrderItemProperty_CategorySpecID(sender,Prefix);
      },
    validate_FK_PUR_OrderItemProperty_CategorySpecID: function(o,Prefix) {
      var value = o.id;
      var ItemCategoryID = $get(o.id);
      if(ItemCategoryID.value==''){
        if(this.validated_FK_PUR_OrderItemProperty_CategorySpecID_main){
          var o_d = $get(Prefix + 'ItemCategoryID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCategoryID.value ;
      var CategorySpecID = $get(o.id);
      if(CategorySpecID.value==''){
        if(this.validated_FK_PUR_OrderItemProperty_CategorySpecID_main){
          var o_d = $get(Prefix + 'CategorySpecID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CategorySpecID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_OrderItemProperty_CategorySpecID(value, this.validated_FK_PUR_OrderItemProperty_CategorySpecID);
      },
    validated_FK_PUR_OrderItemProperty_CategorySpecID_main: false,
    validated_FK_PUR_OrderItemProperty_CategorySpecID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_CategorySpecID.validated_FK_PUR_OrderItemProperty_CategorySpecID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
    </script>

    <script type="text/javascript"> 
   var script_SerialNo = {
    ACESerialNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('SerialNo','');
      var F_SerialNo = $get(sender._element.id);
      var F_SerialNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_SerialNo.value = p[2];
      F_SerialNo_Display.innerHTML = e.get_text();
    },
    ACESerialNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('SerialNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACESerialNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_SerialNo: function(sender) {
      var Prefix = sender.id.replace('SerialNo','');
      this.validated_FK_PUR_OrderItemProperty_SerialNo_main = true;
      this.validate_FK_PUR_OrderItemProperty_SerialNo(sender,Prefix);
      },
    validate_FK_PUR_OrderItemProperty_SerialNo: function(o,Prefix) {
      var value = o.id;
      var ItemCategoryID = $get(o.id);
      if(ItemCategoryID.value==''){
        if(this.validated_FK_PUR_OrderItemProperty_SerialNo_main){
          var o_d = $get(Prefix + 'ItemCategoryID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCategoryID.value ;
      var CategorySpecID = $get(o.id);
      if(CategorySpecID.value==''){
        if(this.validated_FK_PUR_OrderItemProperty_SerialNo_main){
          var o_d = $get(Prefix + 'CategorySpecID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CategorySpecID.value ;
      var SerialNo = $get(o.id);
      if(SerialNo.value==''){
        if(this.validated_FK_PUR_OrderItemProperty_SerialNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_OrderItemProperty_SerialNo(value, this.validated_FK_PUR_OrderItemProperty_SerialNo);
      },
    validated_FK_PUR_OrderItemProperty_SerialNo_main: false,
    validated_FK_PUR_OrderItemProperty_SerialNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_SerialNo.validated_FK_PUR_OrderItemProperty_SerialNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
    </script>

    <script type="text/javascript"> 
   var script_ValueDataTypeID = {
    temp: function() {
    }
    }
    </script>

    <script type="text/javascript"> 
   var script_IsRange = {
    temp: function() {
    }
    }
    </script>

    <script type="text/javascript"> 
   var script_Data1Value = {
    temp: function() {
    }
    }
    </script>

    <script type="text/javascript"> 
   var script_Data2Value = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVpurOrderItemProperty" SkinID="gv_silver" runat="server" DataSourceID="ODSpurOrderItemProperty" DataKeyNames="OrderNo,OrderRev,OrderLine,ItemCode,ItemCategoryID,CategorySpecID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category Spec" SortExpression="[PUR_ItemCategorySpecs2].[SpecName]">
          <ItemTemplate>
          <asp:TextBox
            ID = "F_CategorySpecID"
            CssClass = "myfktxt"
            Text='<%# Bind("CategorySpecID") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Category Spec."
            ValidationGroup = '<%# "purOrderItemProperty" & Container.DataItemIndex %>'
            onblur= "script_CategorySpecID.validate_CategorySpecID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCategorySpecID"
            runat = "server"
            ControlToValidate = "F_CategorySpecID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "purOrderItemProperty" & Container.DataItemIndex %>'
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
            OnClientItemSelected="script_CategorySpecID.ACECategorySpecID_Selected"
            OnClientPopulating="script_CategorySpecID.ACECategorySpecID_Populating"
            OnClientPopulated="script_CategorySpecID.ACECategorySpecID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />

          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="[PUR_ItemCategorySpecValues3].[Data1Value]">
          <ItemTemplate>
          <asp:TextBox
            ID = "F_SerialNo"
            CssClass = "myfktxt"
            Text='<%# Bind("SerialNo") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Serial No."
            onblur= "script_SerialNo.validate_SerialNo(this);"
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
            OnClientItemSelected="script_SerialNo.ACESerialNo_Selected"
            OnClientPopulating="script_SerialNo.ACESerialNo_Populating"
            OnClientPopulated="script_SerialNo.ACESerialNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />

          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Value Data Type" SortExpression="[PUR_ValueDataTypes7].[ValueDataTypeName]">
          <ItemTemplate>
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
            ValidationGroup = '<%# "purOrderItemProperty" & Container.DataItemIndex %>'
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />

          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Is Range" SortExpression="[PUR_OrderItemProperty].[IsRange]">
          <ItemTemplate>
          <asp:CheckBox ID="F_IsRange"
            Checked='<%# Bind("IsRange") %>'
            CssClass = "mychk"
            runat="server" />

          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Data Value [1]" SortExpression="[PUR_OrderItemProperty].[Data1Value]">
          <ItemTemplate>
          <asp:TextBox ID="F_Data1Value"
            Text='<%# Bind("Data1Value") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "purOrderItemProperty" & Container.DataItemIndex %>'
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
            ValidationGroup = '<%# "purOrderItemProperty" & Container.DataItemIndex %>'
            SetFocusOnError="true" />

          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Data Value [2]" SortExpression="[PUR_OrderItemProperty].[Data2Value]">
          <ItemTemplate>
          <asp:TextBox ID="F_Data2Value"
            Text='<%# Bind("Data2Value") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Data Value [2]."
            MaxLength="50"
            runat="server" />

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
      ID = "ODSpurOrderItemProperty"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purOrderItemProperty"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purOrderItemPropertySelectList"
      TypeName = "SIS.PUR.purOrderItemProperty"
      SelectCountMethod = "purOrderItemPropertySelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_OrderRev" PropertyName="Text" Name="OrderRev" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_OrderNo" PropertyName="Text" Name="OrderNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_OrderLine" PropertyName="Text" Name="OrderLine" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpurOrderItemProperty" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_OrderRev" />
    <asp:AsyncPostBackTrigger ControlID="F_OrderNo" />
    <asp:AsyncPostBackTrigger ControlID="F_OrderLine" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
