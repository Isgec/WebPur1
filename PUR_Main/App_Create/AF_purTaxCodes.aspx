<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_purTaxCodes.aspx.vb" Inherits="AF_purTaxCodes" title="Add: Tax Codes" %>
<asp:Content ID="CPHpurTaxCodes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurTaxCodes" runat="server" Text="&nbsp;Add: Tax Codes"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurTaxCodes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurTaxCodes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/PUR_Main/App_Edit/EF_purTaxCodes.aspx"
    ValidationGroup = "purTaxCodes"
    runat = "server" />
<asp:FormView ID="FVpurTaxCodes"
  runat = "server"
  DataKeyNames = "TaxCode"
  DataSourceID = "ODSpurTaxCodes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpurTaxCodes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TaxCode" ForeColor="#CC6633" runat="server" Text="Tax Code :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TaxCode" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TaxDescription" runat="server" Text="Tax Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TaxDescription"
            Text='<%# Bind("TaxDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purTaxCodes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Tax Description."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVTaxDescription"
            runat = "server"
            ControlToValidate = "F_TaxDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purTaxCodes"
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
  ID = "ODSpurTaxCodes"
  DataObjectTypeName = "SIS.PUR.purTaxCodes"
  InsertMethod="purTaxCodesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purTaxCodes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
