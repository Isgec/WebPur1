<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_purValueDataTypes.aspx.vb" Inherits="EF_purValueDataTypes" title="Edit: Data Types" %>
<asp:Content ID="CPHpurValueDataTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurValueDataTypes" runat="server" Text="&nbsp;Edit: Data Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurValueDataTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurValueDataTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "purValueDataTypes"
    runat = "server" />
<asp:FormView ID="FVpurValueDataTypes"
  runat = "server"
  DataKeyNames = "ValueDataTypeID"
  DataSourceID = "ODSpurValueDataTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ValueDataTypeID" runat="server" ForeColor="#CC6633" Text="Value Data Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ValueDataTypeID"
            Text='<%# Bind("ValueDataTypeID") %>'
            ToolTip="Value of Value Data Type ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ValueDataTypeName" runat="server" Text="Value Data Type Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ValueDataTypeName"
            Text='<%# Bind("ValueDataTypeName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purValueDataTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Value Data Type Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVValueDataTypeName"
            runat = "server"
            ControlToValidate = "F_ValueDataTypeName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purValueDataTypes"
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
  ID = "ODSpurValueDataTypes"
  DataObjectTypeName = "SIS.PUR.purValueDataTypes"
  SelectMethod = "purValueDataTypesGetByID"
  UpdateMethod="purValueDataTypesUpdate"
  DeleteMethod="purValueDataTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purValueDataTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ValueDataTypeID" Name="ValueDataTypeID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
