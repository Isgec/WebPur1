<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_purItemCategorySpecValues.aspx.vb" Inherits="EF_purItemCategorySpecValues" title="Edit: Category Spec Values" %>
<asp:Content ID="CPHpurItemCategorySpecValues" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurItemCategorySpecValues" runat="server" Text="&nbsp;Edit: Category Spec Values"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurItemCategorySpecValues" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurItemCategorySpecValues"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "purItemCategorySpecValues"
    runat = "server" />
<asp:FormView ID="FVpurItemCategorySpecValues"
  runat = "server"
  DataKeyNames = "ItemCategoryID,CategorySpecID,SerialNo"
  DataSourceID = "ODSpurItemCategorySpecValues"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemCategoryID" runat="server" ForeColor="#CC6633" Text="Item Category :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ItemCategoryID"
            Width="88px"
            Text='<%# Bind("ItemCategoryID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Item Category."
            Runat="Server" />
          <asp:Label
            ID = "F_ItemCategoryID_Display"
            Text='<%# Eval("PUR_ItemCategories1_CategoryName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CategorySpecID" runat="server" ForeColor="#CC6633" Text="Category Spec :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CategorySpecID"
            Width="88px"
            Text='<%# Bind("CategorySpecID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Category Spec."
            Runat="Server" />
          <asp:Label
            ID = "F_CategorySpecID_Display"
            Text='<%# Eval("PUR_ItemCategorySpecs2_SpecName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
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
          <asp:Label ID="L_ValueDataTypeID" runat="server" Text="Value Data Type :" />&nbsp;
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Data1Value" runat="server" Text="Data Value [1] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Data1Value"
            Text='<%# Bind("Data1Value") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Data Value [1]."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Data2Value" runat="server" Text="Data Value [2] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Data2Value"
            Text='<%# Bind("Data2Value") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Data Value [2]."
            MaxLength="50"
            runat="server" />
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
  ID = "ODSpurItemCategorySpecValues"
  DataObjectTypeName = "SIS.PUR.purItemCategorySpecValues"
  SelectMethod = "purItemCategorySpecValuesGetByID"
  UpdateMethod="purItemCategorySpecValuesUpdate"
  DeleteMethod="purItemCategorySpecValuesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purItemCategorySpecValues"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemCategoryID" Name="ItemCategoryID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CategorySpecID" Name="CategorySpecID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
