<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_purPurchaseTypes.aspx.vb" Inherits="EF_purPurchaseTypes" title="Edit: Purchase Types" %>
<asp:Content ID="CPHpurPurchaseTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurPurchaseTypes" runat="server" Text="&nbsp;Edit: Purchase Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurPurchaseTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurPurchaseTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "purPurchaseTypes"
    runat = "server" />
<asp:FormView ID="FVpurPurchaseTypes"
  runat = "server"
  DataKeyNames = "PurchaseTypeID"
  DataSourceID = "ODSpurPurchaseTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PurchaseTypeID" runat="server" ForeColor="#CC6633" Text="Purchase Type :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PurchaseTypeID"
            Text='<%# Bind("PurchaseTypeID") %>'
            ToolTip="Value of Purchase Type."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purPurchaseTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpurPurchaseTypes"
  DataObjectTypeName = "SIS.PUR.purPurchaseTypes"
  SelectMethod = "purPurchaseTypesGetByID"
  UpdateMethod="purPurchaseTypesUpdate"
  DeleteMethod="purPurchaseTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purPurchaseTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="PurchaseTypeID" Name="PurchaseTypeID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
