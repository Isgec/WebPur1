<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_purApprovalTypes.aspx.vb" Inherits="AF_purApprovalTypes" title="Add: Approval Types" %>
<asp:Content ID="CPHpurApprovalTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurApprovalTypes" runat="server" Text="&nbsp;Add: Approval Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurApprovalTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurApprovalTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "purApprovalTypes"
    runat = "server" />
<asp:FormView ID="FVpurApprovalTypes"
  runat = "server"
  DataKeyNames = "AprTypeID"
  DataSourceID = "ODSpurApprovalTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpurApprovalTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_AprTypeID" ForeColor="#CC6633" runat="server" Text="Approval Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AprTypeID"
            Text='<%# Bind("AprTypeID") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="purApprovalTypes"
            onblur= "script_purApprovalTypes.validate_AprTypeID(this);"
            ToolTip="Enter value for Approval Type ID."
            MaxLength="10"
            Width="88px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVAprTypeID"
            runat = "server"
            ControlToValidate = "F_AprTypeID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purApprovalTypes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AprDescription" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AprDescription"
            Text='<%# Bind("AprDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purApprovalTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVAprDescription"
            runat = "server"
            ControlToValidate = "F_AprDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purApprovalTypes"
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
  ID = "ODSpurApprovalTypes"
  DataObjectTypeName = "SIS.PUR.purApprovalTypes"
  InsertMethod="purApprovalTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purApprovalTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
