<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_purItemCategories.aspx.vb" Inherits="EF_purItemCategories" title="Edit: Item Categories" %>
<asp:Content ID="CPHpurItemCategories" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurItemCategories" runat="server" Text="&nbsp;Edit: Item Categories"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurItemCategories" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurItemCategories"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "purItemCategories"
    runat = "server" />
<asp:FormView ID="FVpurItemCategories"
  runat = "server"
  DataKeyNames = "ItemCategoryID"
  DataSourceID = "ODSpurItemCategories"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemCategoryID" runat="server" ForeColor="#CC6633" Text="Item Category :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ItemCategoryID"
            Text='<%# Bind("ItemCategoryID") %>'
            ToolTip="Value of Item Category."
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
          <asp:Label ID="L_CategoryName" runat="server" Text="Category Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CategoryName"
            Text='<%# Bind("CategoryName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purItemCategories"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Category Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCategoryName"
            runat = "server"
            ControlToValidate = "F_CategoryName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purItemCategories"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ValidateCategoryValues" runat="server" Text="Validate Category Values :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_ValidateCategoryValues"
            Checked='<%# Bind("ValidateCategoryValues") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpurItemCategorySpecs" runat="server" Text="&nbsp;List: Category Spec"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurItemCategorySpecs" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurItemCategorySpecs"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purItemCategorySpecs.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purItemCategorySpecs.aspx?skip=1"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "purItemCategorySpecs"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurItemCategorySpecs" runat="server" AssociatedUpdatePanelID="UPNLpurItemCategorySpecs" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpurItemCategorySpecs" SkinID="gv_silver" runat="server" DataSourceID="ODSpurItemCategorySpecs" DataKeyNames="ItemCategoryID,CategorySpecID">
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
        <asp:TemplateField HeaderText="Category Spec" SortExpression="[PUR_ItemCategorySpecValues2].[Data1Value]">
          <ItemTemplate>
             <asp:Label ID="L_CategorySpecID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CategorySpecID") %>' Text='<%# Eval("PUR_ItemCategorySpecValues2_Data1Value") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Spec" SortExpression="[PUR_ItemSpecification3].[SpecName]">
          <ItemTemplate>
             <asp:Label ID="L_SpecID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SpecID") %>' Text='<%# Eval("PUR_ItemSpecification3_SpecName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Spec Name" SortExpression="[PUR_ItemCategorySpecs].[SpecName]">
          <ItemTemplate>
            <asp:Label ID="LabelSpecName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SpecName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Default Value Serial No" SortExpression="[PUR_ItemCategorySpecValues2].[Data1Value]">
          <ItemTemplate>
             <asp:Label ID="L_DefaultValueSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("DefaultValueSerialNo") %>' Text='<%# Eval("PUR_ItemCategorySpecValues2_Data1Value") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Is Fixed" SortExpression="[PUR_ItemCategorySpecs].[IsFixed]">
          <ItemTemplate>
            <asp:Label ID="LabelIsFixed" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IsFixed") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Is Derived" SortExpression="[PUR_ItemCategorySpecs].[IsDerived]">
          <ItemTemplate>
            <asp:Label ID="LabelIsDerived" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IsDerived") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Validate Value" SortExpression="[PUR_ItemCategorySpecs].[ValidateValue]">
          <ItemTemplate>
            <asp:Label ID="LabelValidateValue" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ValidateValue") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Use Values" SortExpression="[PUR_ItemCategorySpecs].[UseValues]">
          <ItemTemplate>
            <asp:Label ID="LabelUseValues" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UseValues") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Allow User Value" SortExpression="[PUR_ItemCategorySpecs].[AllowUserValue]">
          <ItemTemplate>
            <asp:Label ID="LabelAllowUserValue" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AllowUserValue") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpurItemCategorySpecs"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purItemCategorySpecs"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purItemCategorySpecsSelectList"
      TypeName = "SIS.PUR.purItemCategorySpecs"
      SelectCountMethod = "purItemCategorySpecsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ItemCategoryID" PropertyName="Text" Name="ItemCategoryID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpurItemCategorySpecs" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpurItemCategories"
  DataObjectTypeName = "SIS.PUR.purItemCategories"
  SelectMethod = "purItemCategoriesGetByID"
  UpdateMethod="purItemCategoriesUpdate"
  DeleteMethod="purItemCategoriesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purItemCategories"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemCategoryID" Name="ItemCategoryID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
