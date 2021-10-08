<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_purApprovalTypes.aspx.vb" Inherits="EF_purApprovalTypes" title="Edit: Approval Types" %>
<asp:Content ID="CPHpurApprovalTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurApprovalTypes" runat="server" Text="&nbsp;Edit: Approval Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurApprovalTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurApprovalTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "purApprovalTypes"
    runat = "server" />
<asp:FormView ID="FVpurApprovalTypes"
  runat = "server"
  DataKeyNames = "AprTypeID"
  DataSourceID = "ODSpurApprovalTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_AprTypeID" runat="server" ForeColor="#CC6633" Text="Approval Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AprTypeID"
            Text='<%# Bind("AprTypeID") %>'
            ToolTip="Value of Approval Type ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AprDescription" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AprDescription"
            Text='<%# Bind("AprDescription") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purApprovalTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpurApprovalTypes"
  DataObjectTypeName = "SIS.PUR.purApprovalTypes"
  SelectMethod = "purApprovalTypesGetByID"
  UpdateMethod="purApprovalTypesUpdate"
  DeleteMethod="purApprovalTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purApprovalTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="AprTypeID" Name="AprTypeID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
