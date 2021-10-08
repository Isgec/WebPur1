<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_purValueDataTypes.aspx.vb" Inherits="AF_purValueDataTypes" title="Add: Data Types" %>
<asp:Content ID="CPHpurValueDataTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurValueDataTypes" runat="server" Text="&nbsp;Add: Data Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurValueDataTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurValueDataTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "purValueDataTypes"
    runat = "server" />
<asp:FormView ID="FVpurValueDataTypes"
  runat = "server"
  DataKeyNames = "ValueDataTypeID"
  DataSourceID = "ODSpurValueDataTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpurValueDataTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ValueDataTypeID" ForeColor="#CC6633" runat="server" Text="Value Data Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ValueDataTypeID"
            Text='<%# Bind("ValueDataTypeID") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="purValueDataTypes"
            onblur= "script_purValueDataTypes.validate_ValueDataTypeID(this);"
            ToolTip="Enter value for Value Data Type ID."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVValueDataTypeID"
            runat = "server"
            ControlToValidate = "F_ValueDataTypeID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purValueDataTypes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ValueDataTypeName" runat="server" Text="Value Data Type Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ValueDataTypeName"
            Text='<%# Bind("ValueDataTypeName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purValueDataTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Value Data Type Name."
            MaxLength="50"
            Width="408px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpurValueDataTypes"
  DataObjectTypeName = "SIS.PUR.purValueDataTypes"
  InsertMethod="purValueDataTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purValueDataTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
