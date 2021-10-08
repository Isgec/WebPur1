<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_purItemCategories.aspx.vb" Inherits="AF_purItemCategories" title="Add: Item Categories" %>
<asp:Content ID="CPHpurItemCategories" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurItemCategories" runat="server" Text="&nbsp;Add: Item Categories"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurItemCategories" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurItemCategories"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/PUR_Main/App_Edit/EF_purItemCategories.aspx"
    ValidationGroup = "purItemCategories"
    runat = "server" />
<asp:FormView ID="FVpurItemCategories"
  runat = "server"
  DataKeyNames = "ItemCategoryID"
  DataSourceID = "ODSpurItemCategories"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpurItemCategories" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemCategoryID" ForeColor="#CC6633" runat="server" Text="Item Category :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ItemCategoryID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CategoryName" runat="server" Text="Category Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CategoryName"
            Text='<%# Bind("CategoryName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purItemCategories"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Category Name."
            MaxLength="50"
            Width="408px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpurItemCategories"
  DataObjectTypeName = "SIS.PUR.purItemCategories"
  InsertMethod="purItemCategoriesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purItemCategories"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
