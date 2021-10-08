<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_purItemSpecification.aspx.vb" Inherits="AF_purItemSpecification" title="Add: Specification Master" %>
<asp:Content ID="CPHpurItemSpecification" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurItemSpecification" runat="server" Text="&nbsp;Add: Specification Master"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurItemSpecification" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurItemSpecification"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/PUR_Main/App_Edit/EF_purItemSpecification.aspx"
    ValidationGroup = "purItemSpecification"
    runat = "server" />
<asp:FormView ID="FVpurItemSpecification"
  runat = "server"
  DataKeyNames = "SpecID"
  DataSourceID = "ODSpurItemSpecification"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpurItemSpecification" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SpecID" ForeColor="#CC6633" runat="server" Text="Spec ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SpecID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SpecName" runat="server" Text="Spec Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SpecName"
            Text='<%# Bind("SpecName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purItemSpecification"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Spec Name."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSpecName"
            runat = "server"
            ControlToValidate = "F_SpecName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purItemSpecification"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsFixed" runat="server" Text="Is Fixed :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_IsFixed"
           Checked='<%# Bind("IsFixed") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsDerived" runat="server" Text="Is Derived :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_IsDerived"
           Checked='<%# Bind("IsDerived") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ValidateValue" runat="server" Text="Validate Value :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_ValidateValue"
           Checked='<%# Bind("ValidateValue") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UseValues" runat="server" Text="Use Values :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_UseValues"
           Checked='<%# Bind("UseValues") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AllowUserValue" runat="server" Text="Allow User Value :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_AllowUserValue"
           Checked='<%# Bind("AllowUserValue") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ValueDataTypeID" runat="server" Text="Value Data Type :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_purValueDataTypes
            ID="F_ValueDataTypeID"
            SelectedValue='<%# Bind("ValueDataTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "purItemSpecification"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsRange" runat="server" Text="Is Range :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_IsRange"
           Checked='<%# Bind("IsRange") %>'
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
  ID = "ODSpurItemSpecification"
  DataObjectTypeName = "SIS.PUR.purItemSpecification"
  InsertMethod="purItemSpecificationInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purItemSpecification"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
