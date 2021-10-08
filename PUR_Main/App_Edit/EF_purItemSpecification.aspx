<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_purItemSpecification.aspx.vb" Inherits="EF_purItemSpecification" title="Edit: Specification Master" %>
<asp:Content ID="CPHpurItemSpecification" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurItemSpecification" runat="server" Text="&nbsp;Edit: Specification Master"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurItemSpecification" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurItemSpecification"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "purItemSpecification"
    runat = "server" />
<asp:FormView ID="FVpurItemSpecification"
  runat = "server"
  DataKeyNames = "SpecID"
  DataSourceID = "ODSpurItemSpecification"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SpecID" runat="server" ForeColor="#CC6633" Text="Spec ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SpecID"
            Text='<%# Bind("SpecID") %>'
            ToolTip="Value of Spec ID."
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
          <asp:Label ID="L_SpecName" runat="server" Text="Spec Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SpecName"
            Text='<%# Bind("SpecName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purItemSpecification"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Spec Name."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpurItemSpecValues" runat="server" Text="&nbsp;List: Possible Values"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurItemSpecValues" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurItemSpecValues"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purItemSpecValues.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purItemSpecValues.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "purItemSpecValues"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurItemSpecValues" runat="server" AssociatedUpdatePanelID="UPNLpurItemSpecValues" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpurItemSpecValues" SkinID="gv_silver" runat="server" DataSourceID="ODSpurItemSpecValues" DataKeyNames="SpecID,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Spec ID" SortExpression="[PUR_ItemSpecification1].[SpecName]">
          <ItemTemplate>
             <asp:Label ID="L_SpecID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SpecID") %>' Text='<%# Eval("PUR_ItemSpecification1_SpecName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="[PUR_ItemSpecValues].[SerialNo]">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Value Data Type" SortExpression="[PUR_ValueDataTypes2].[ValueDataTypeName]">
          <ItemTemplate>
             <asp:Label ID="L_ValueDataTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ValueDataTypeID") %>' Text='<%# Eval("PUR_ValueDataTypes2_ValueDataTypeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Is Range" SortExpression="[PUR_ItemSpecValues].[IsRange]">
          <ItemTemplate>
            <asp:Label ID="LabelIsRange" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IsRange") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Data Value [1]" SortExpression="[PUR_ItemSpecValues].[Data1Value]">
          <ItemTemplate>
            <asp:Label ID="LabelData1Value" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Data1Value") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Data Value [2]" SortExpression="[PUR_ItemSpecValues].[Data2Value]">
          <ItemTemplate>
            <asp:Label ID="LabelData2Value" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Data2Value") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpurItemSpecValues"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purItemSpecValues"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purItemSpecValuesSelectList"
      TypeName = "SIS.PUR.purItemSpecValues"
      SelectCountMethod = "purItemSpecValuesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SpecID" PropertyName="Text" Name="SpecID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpurItemSpecValues" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpurItemSpecification"
  DataObjectTypeName = "SIS.PUR.purItemSpecification"
  SelectMethod = "purItemSpecificationGetByID"
  UpdateMethod="purItemSpecificationUpdate"
  DeleteMethod="purItemSpecificationDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purItemSpecification"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SpecID" Name="SpecID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
