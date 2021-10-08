<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_purPurchaseTypes.aspx.vb" Inherits="AF_purPurchaseTypes" title="Add: Purchase Types" %>
<asp:Content ID="CPHpurPurchaseTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurPurchaseTypes" runat="server" Text="&nbsp;Add: Purchase Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurPurchaseTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurPurchaseTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "purPurchaseTypes"
    runat = "server" />
<asp:FormView ID="FVpurPurchaseTypes"
  runat = "server"
  DataKeyNames = "PurchaseTypeID"
  DataSourceID = "ODSpurPurchaseTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpurPurchaseTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PurchaseTypeID" ForeColor="#CC6633" runat="server" Text="Purchase Type :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PurchaseTypeID"
            Text='<%# Bind("PurchaseTypeID") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="purPurchaseTypes"
            onblur= "script_purPurchaseTypes.validate_PurchaseTypeID(this);"
            ToolTip="Enter value for Purchase Type."
            MaxLength="100"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVPurchaseTypeID"
            runat = "server"
            ControlToValidate = "F_PurchaseTypeID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purPurchaseTypes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purPurchaseTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purPurchaseTypes"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpurPurchaseTypes"
  DataObjectTypeName = "SIS.PUR.purPurchaseTypes"
  InsertMethod="purPurchaseTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purPurchaseTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
