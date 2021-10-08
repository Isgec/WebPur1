<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purIndentItemProperty.aspx.vb" Inherits="GF_purIndentItemProperty" title="Maintain List: Indent Item Property" %>
<asp:Content ID="CPHpurIndentItemProperty" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurIndentItemProperty" runat="server" Text="&nbsp;List: Indent Item Property"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurIndentItemProperty" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurIndentItemProperty"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purIndentItemProperty.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purIndentItemProperty.aspx"
      AddPostBack = "True"
      ValidationGroup = "purIndentItemProperty"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurIndentItemProperty" runat="server" AssociatedUpdatePanelID="UPNLpurIndentItemProperty" DisplayAfter="100">
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
          <b><asp:Label ID="L_IndentNo" runat="server" Text="Indent No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_IndentNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_IndentNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_IndentNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEIndentNo"
            BehaviorID="B_ACEIndentNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="IndentNoCompletionList"
            TargetControlID="F_IndentNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEIndentNo_Selected"
            OnClientPopulating="ACEIndentNo_Populating"
            OnClientPopulated="ACEIndentNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IndentLine" runat="server" Text="Indent Line :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_IndentLine"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_IndentLine(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_IndentLine_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEIndentLine"
            BehaviorID="B_ACEIndentLine"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="IndentLineCompletionList"
            TargetControlID="F_IndentLine"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEIndentLine_Selected"
            OnClientPopulating="ACEIndentLine_Populating"
            OnClientPopulated="ACEIndentLine_Populated"
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
      this.validated_FK_PUR_IndentItemProperty_SerialNo_main = true;
      this.validate_FK_PUR_IndentItemProperty_SerialNo(sender,Prefix);
      },
    validate_FK_PUR_IndentItemProperty_SerialNo: function(o,Prefix) {
      var value = o.id;
      var ItemCategoryID = $get(o.id);
      if(ItemCategoryID.value==''){
        if(this.validated_FK_PUR_IndentItemProperty_SerialNo_main){
          var o_d = $get(Prefix + 'ItemCategoryID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCategoryID.value ;
      var CategorySpecID = $get(o.id);
      if(CategorySpecID.value==''){
        if(this.validated_FK_PUR_IndentItemProperty_SerialNo_main){
          var o_d = $get(Prefix + 'CategorySpecID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CategorySpecID.value ;
      var SerialNo = $get(o.id);
      if(SerialNo.value==''){
        if(this.validated_FK_PUR_IndentItemProperty_SerialNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_IndentItemProperty_SerialNo(value, this.validated_FK_PUR_IndentItemProperty_SerialNo);
      },
    validated_FK_PUR_IndentItemProperty_SerialNo_main: false,
    validated_FK_PUR_IndentItemProperty_SerialNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_SerialNo.validated_FK_PUR_IndentItemProperty_SerialNo_main){
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

    <asp:GridView ID="GVpurIndentItemProperty" SkinID="gv_silver" runat="server" DataSourceID="ODSpurIndentItemProperty" DataKeyNames="IndentNo,IndentLine,ItemCode,ItemCategoryID,CategorySpecID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category Spec" SortExpression="[PUR_ItemCategorySpecs4].[SpecName]">
          <ItemTemplate>
             <asp:Label ID="L_CategorySpecID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CategorySpecID") %>' Text='<%# Eval("PUR_ItemCategorySpecs4_SpecName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="[PUR_ItemCategorySpecValues5].[Data1Value]">
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
            ValidationGroup = '<%# "purIndentItemProperty" & Container.DataItemIndex %>'
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />

          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Is Range" SortExpression="[PUR_IndentItemProperty].[IsRange]">
          <ItemTemplate>
          <asp:CheckBox ID="F_IsRange"
            Checked='<%# Bind("IsRange") %>'
            CssClass = "mychk"
            runat="server" />

          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Data Value [1]" SortExpression="[PUR_IndentItemProperty].[Data1Value]">
          <ItemTemplate>
          <asp:TextBox ID="F_Data1Value"
            Text='<%# Bind("Data1Value") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "purIndentItemProperty" & Container.DataItemIndex %>'
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
            ValidationGroup = '<%# "purIndentItemProperty" & Container.DataItemIndex %>'
            SetFocusOnError="true" />

          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Data Value [2]" SortExpression="[PUR_IndentItemProperty].[Data2Value]">
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
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpurIndentItemProperty"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purIndentItemProperty"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purIndentItemPropertySelectList"
      TypeName = "SIS.PUR.purIndentItemProperty"
      SelectCountMethod = "purIndentItemPropertySelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_IndentLine" PropertyName="Text" Name="IndentLine" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_IndentNo" PropertyName="Text" Name="IndentNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpurIndentItemProperty" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_IndentLine" />
    <asp:AsyncPostBackTrigger ControlID="F_IndentNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
