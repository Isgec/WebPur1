<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_purPOStatus.aspx.vb" Inherits="EF_purPOStatus" title="Edit: PO States" %>
<asp:Content ID="CPHpurPOStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurPOStatus" runat="server" Text="&nbsp;Edit: PO States"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurPOStatus" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurPOStatus"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "purPOStatus"
    runat = "server" />
<asp:FormView ID="FVpurPOStatus"
  runat = "server"
  DataKeyNames = "StatusID"
  DataSourceID = "ODSpurPOStatus"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_StatusID" runat="server" ForeColor="#CC6633" Text="StatusID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_StatusID"
            Text='<%# Bind("StatusID") %>'
            ToolTip="Value of StatusID."
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
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purPOStatus"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purPOStatus"
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
  ID = "ODSpurPOStatus"
  DataObjectTypeName = "SIS.PUR.purPOStatus"
  SelectMethod = "purPOStatusGetByID"
  UpdateMethod="purPOStatusUpdate"
  DeleteMethod="purPOStatusDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purPOStatus"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="StatusID" Name="StatusID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
