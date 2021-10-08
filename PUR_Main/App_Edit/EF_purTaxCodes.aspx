<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_purTaxCodes.aspx.vb" Inherits="EF_purTaxCodes" title="Edit: Tax Codes" %>
<asp:Content ID="CPHpurTaxCodes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurTaxCodes" runat="server" Text="&nbsp;Edit: Tax Codes"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurTaxCodes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurTaxCodes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "purTaxCodes"
    runat = "server" />
<asp:FormView ID="FVpurTaxCodes"
  runat = "server"
  DataKeyNames = "TaxCode"
  DataSourceID = "ODSpurTaxCodes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TaxCode" runat="server" ForeColor="#CC6633" Text="Tax Code :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TaxCode"
            Text='<%# Bind("TaxCode") %>'
            ToolTip="Value of Tax Code."
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
          <asp:Label ID="L_TaxDescription" runat="server" Text="Tax Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TaxDescription"
            Text='<%# Bind("TaxDescription") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="purTaxCodes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Tax Description."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpurTaxRates" runat="server" Text="&nbsp;List: Tax Rates"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurTaxRates" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurTaxRates"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purTaxRates.aspx"
      AddUrl = "~/PUR_Main/App_Create/AF_purTaxRates.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "purTaxRates"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurTaxRates" runat="server" AssociatedUpdatePanelID="UPNLpurTaxRates" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpurTaxRates" SkinID="gv_silver" runat="server" DataSourceID="ODSpurTaxRates" DataKeyNames="TaxCode,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tax Code" SortExpression="[PUR_TaxCodes1].[TaxDescription]">
          <ItemTemplate>
             <asp:Label ID="L_TaxCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TaxCode") %>' Text='<%# Eval("PUR_TaxCodes1_TaxDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="[PUR_TaxRates].[SerialNo]">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="From Date" SortExpression="[PUR_TaxRates].[FromDate]">
          <ItemTemplate>
            <asp:Label ID="LabelFromDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FromDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="To Date" SortExpression="[PUR_TaxRates].[ToDate]">
          <ItemTemplate>
            <asp:Label ID="LabelToDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ToDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IGST Rate" SortExpression="[PUR_TaxRates].[TaxRate]">
          <ItemTemplate>
            <asp:Label ID="LabelTaxRate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TaxRate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CGST Rate" SortExpression="[PUR_TaxRates].[CGSTRate]">
          <ItemTemplate>
            <asp:Label ID="LabelCGSTRate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CGSTRate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SGST Rate" SortExpression="[PUR_TaxRates].[SGSTRate]">
          <ItemTemplate>
            <asp:Label ID="LabelSGSTRate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SGSTRate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cess Rate" SortExpression="[PUR_TaxRates].[CessRate]">
          <ItemTemplate>
            <asp:Label ID="LabelCessRate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CessRate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TCS Rate" SortExpression="[PUR_TaxRates].[TCSRate]">
          <ItemTemplate>
            <asp:Label ID="LabelTCSRate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TCSRate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Revise">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRevise" ValidationGroup='<%# "Revise" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ReviseWFVisible") %>' Enabled='<%# EVal("ReviseWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Revise" SkinID="Revise" OnClientClick='<%# "return Page_ClientValidate(""Revise" & Container.DataItemIndex & """) && confirm(""Revise record ?"");" %>' CommandName="ReviseWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpurTaxRates"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purTaxRates"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purTaxRatesSelectList"
      TypeName = "SIS.PUR.purTaxRates"
      SelectCountMethod = "purTaxRatesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TaxCode" PropertyName="Text" Name="TaxCode" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpurTaxRates" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpurTaxCodes"
  DataObjectTypeName = "SIS.PUR.purTaxCodes"
  SelectMethod = "purTaxCodesGetByID"
  UpdateMethod="purTaxCodesUpdate"
  DeleteMethod="purTaxCodesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purTaxCodes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="TaxCode" Name="TaxCode" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
