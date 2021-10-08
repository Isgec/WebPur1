<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_purHOrders.aspx.vb" Inherits="GF_purHOrders" title="Maintain List: H-Orders" %>
<asp:Content ID="CPHpurHOrders" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpurHOrders" runat="server" Text="&nbsp;List: H-Orders"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpurHOrders" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpurHOrders"
      ToolType = "lgNMGrid"
      EditUrl = "~/PUR_Main/App_Edit/EF_purHOrders.aspx"
      EnableAdd = "False"
      ValidationGroup = "purHOrders"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpurHOrders" runat="server" AssociatedUpdatePanelID="UPNLpurHOrders" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpurHOrders" SkinID="gv_silver" runat="server" DataSourceID="ODSpurHOrders" DataKeyNames="OrderNo,OrderRev">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OrderNo" SortExpression="[PUR_HOrders].[OrderNo]">
          <ItemTemplate>
            <asp:Label ID="LabelOrderNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OrderNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OrderRev" SortExpression="[PUR_HOrders].[OrderRev]">
          <ItemTemplate>
            <asp:Label ID="LabelOrderRev" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OrderRev") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OrderDate" SortExpression="[PUR_HOrders].[OrderDate]">
          <ItemTemplate>
            <asp:Label ID="LabelOrderDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OrderDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PurchaseTypeID" SortExpression="[PUR_HOrders].[PurchaseTypeID]">
          <ItemTemplate>
            <asp:Label ID="LabelPurchaseTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PurchaseTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TranTypeID" SortExpression="[PUR_HOrders].[TranTypeID]">
          <ItemTemplate>
            <asp:Label ID="LabelTranTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TranTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="StatusID" SortExpression="[PUR_HOrders].[StatusID]">
          <ItemTemplate>
            <asp:Label ID="LabelStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("StatusID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IsgecGSTIN" SortExpression="[PUR_HOrders].[IsgecGSTIN]">
          <ItemTemplate>
            <asp:Label ID="LabelIsgecGSTIN" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IsgecGSTIN") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IsgecGSTINAddress" SortExpression="[PUR_HOrders].[IsgecGSTINAddress]">
          <ItemTemplate>
            <asp:Label ID="LabelIsgecGSTINAddress" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IsgecGSTINAddress") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DestinationAddress" SortExpression="[PUR_HOrders].[DestinationAddress]">
          <ItemTemplate>
            <asp:Label ID="LabelDestinationAddress" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DestinationAddress") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="QuatationNo" SortExpression="[PUR_HOrders].[QuatationNo]">
          <ItemTemplate>
            <asp:Label ID="LabelQuatationNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("QuatationNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="QuotationDate" SortExpression="[PUR_HOrders].[QuotationDate]">
          <ItemTemplate>
            <asp:Label ID="LabelQuotationDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("QuotationDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SupplierID" SortExpression="[PUR_HOrders].[SupplierID]">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SupplierGSTIN" SortExpression="[PUR_HOrders].[SupplierGSTIN]">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierGSTIN" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierGSTIN") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SupplierName" SortExpression="[PUR_HOrders].[SupplierName]">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SupplierGSTINUMBER" SortExpression="[PUR_HOrders].[SupplierGSTINUMBER]">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierGSTINUMBER" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierGSTINUMBER") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DeliveryDate" SortExpression="[PUR_HOrders].[DeliveryDate]">
          <ItemTemplate>
            <asp:Label ID="LabelDeliveryDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DeliveryDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PaymentTerms" SortExpression="[PUR_HOrders].[PaymentTerms]">
          <ItemTemplate>
            <asp:Label ID="LabelPaymentTerms" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PaymentTerms") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DeliveryTerms" SortExpression="[PUR_HOrders].[DeliveryTerms]">
          <ItemTemplate>
            <asp:Label ID="LabelDeliveryTerms" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DeliveryTerms") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ModeOfDispatch" SortExpression="[PUR_HOrders].[ModeOfDispatch]">
          <ItemTemplate>
            <asp:Label ID="LabelModeOfDispatch" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ModeOfDispatch") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="InsuranceDetails" SortExpression="[PUR_HOrders].[InsuranceDetails]">
          <ItemTemplate>
            <asp:Label ID="LabelInsuranceDetails" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("InsuranceDetails") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="WarrantyDetails" SortExpression="[PUR_HOrders].[WarrantyDetails]">
          <ItemTemplate>
            <asp:Label ID="LabelWarrantyDetails" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("WarrantyDetails") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BuyerRemarks" SortExpression="[PUR_HOrders].[BuyerRemarks]">
          <ItemTemplate>
            <asp:Label ID="LabelBuyerRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BuyerRemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CurrencyID" SortExpression="[PUR_HOrders].[CurrencyID]">
          <ItemTemplate>
            <asp:Label ID="LabelCurrencyID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CurrencyID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ConversionFactorINR" SortExpression="[PUR_HOrders].[ConversionFactorINR]">
          <ItemTemplate>
            <asp:Label ID="LabelConversionFactorINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ConversionFactorINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="AprTypeID" SortExpression="[PUR_HOrders].[AprTypeID]">
          <ItemTemplate>
            <asp:Label ID="LabelAprTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AprTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CreatedBy" SortExpression="[PUR_HOrders].[CreatedBy]">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedBy") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CreatedOn" SortExpression="[PUR_HOrders].[CreatedOn]">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ApprovedBy" SortExpression="[PUR_HOrders].[ApprovedBy]">
          <ItemTemplate>
            <asp:Label ID="LabelApprovedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApprovedBy") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ApprovedOn" SortExpression="[PUR_HOrders].[ApprovedOn]">
          <ItemTemplate>
            <asp:Label ID="LabelApprovedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApprovedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ApproverRemarks" SortExpression="[PUR_HOrders].[ApproverRemarks]">
          <ItemTemplate>
            <asp:Label ID="LabelApproverRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApproverRemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ProjectID" SortExpression="[PUR_HOrders].[ProjectID]">
          <ItemTemplate>
            <asp:Label ID="LabelProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ElementID" SortExpression="[PUR_HOrders].[ElementID]">
          <ItemTemplate>
            <asp:Label ID="LabelElementID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ElementID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="EmployeeID" SortExpression="[PUR_HOrders].[EmployeeID]">
          <ItemTemplate>
            <asp:Label ID="LabelEmployeeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EmployeeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DepartmentID" SortExpression="[PUR_HOrders].[DepartmentID]">
          <ItemTemplate>
            <asp:Label ID="LabelDepartmentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DepartmentID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CostCenterID" SortExpression="[PUR_HOrders].[CostCenterID]">
          <ItemTemplate>
            <asp:Label ID="LabelCostCenterID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CostCenterID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DivisionID" SortExpression="[PUR_HOrders].[DivisionID]">
          <ItemTemplate>
            <asp:Label ID="LabelDivisionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DivisionID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OrderText" SortExpression="[PUR_HOrders].[OrderText]">
          <ItemTemplate>
            <asp:Label ID="LabelOrderText" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OrderText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ReasonOfRevision" SortExpression="[PUR_HOrders].[ReasonOfRevision]">
          <ItemTemplate>
            <asp:Label ID="LabelReasonOfRevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ReasonOfRevision") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IssuedBy" SortExpression="[PUR_HOrders].[IssuedBy]">
          <ItemTemplate>
            <asp:Label ID="LabelIssuedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IssuedBy") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IssuedOn" SortExpression="[PUR_HOrders].[IssuedOn]">
          <ItemTemplate>
            <asp:Label ID="LabelIssuedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IssuedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="RevisedBy" SortExpression="[PUR_HOrders].[RevisedBy]">
          <ItemTemplate>
            <asp:Label ID="LabelRevisedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RevisedBy") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="RevisedOn" SortExpression="[PUR_HOrders].[RevisedOn]">
          <ItemTemplate>
            <asp:Label ID="LabelRevisedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RevisedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpurHOrders"
      runat = "server"
      DataObjectTypeName = "SIS.PUR.purHOrders"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "purHOrdersSelectList"
      TypeName = "SIS.PUR.purHOrders"
      SelectCountMethod = "purHOrdersSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpurHOrders" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
