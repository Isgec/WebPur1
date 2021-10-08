<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_purCurrencies.aspx.vb" Inherits="AF_purCurrencies" title="Add: Currencies" %>
<asp:Content ID="CPHpurCurrencies" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurCurrencies" runat="server" Text="&nbsp;Add: Currencies"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurCurrencies" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurCurrencies"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "purCurrencies"
    runat = "server" />
<asp:FormView ID="FVpurCurrencies"
  runat = "server"
  DataKeyNames = "CurrencyID"
  DataSourceID = "ODSpurCurrencies"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpurCurrencies" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CurrencyID" ForeColor="#CC6633" runat="server" Text="Currency :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CurrencyID"
            Text='<%# Bind("CurrencyID") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="purCurrencies"
            onblur= "script_purCurrencies.validate_CurrencyID(this);"
            ToolTip="Enter value for Currency."
            MaxLength="10"
            Width="88px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCurrencyID"
            runat = "server"
            ControlToValidate = "F_CurrencyID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purCurrencies"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CurrencyName" runat="server" Text="Currency Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CurrencyName"
            Text='<%# Bind("CurrencyName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purCurrencies"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Currency Name."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCurrencyName"
            runat = "server"
            ControlToValidate = "F_CurrencyName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purCurrencies"
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
  ID = "ODSpurCurrencies"
  DataObjectTypeName = "SIS.PUR.purCurrencies"
  InsertMethod="purCurrenciesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purCurrencies"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
