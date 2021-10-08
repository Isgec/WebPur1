<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_purPendingIndents.aspx.vb" Inherits="EF_purPendingIndents" title="Edit: Pending for Ordering" %>
<asp:Content ID="CPHpurPendingIndents" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurPendingIndents" runat="server" Text="&nbsp;Edit: Pending for Ordering"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurPendingIndents" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurPendingIndents"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "purPendingIndents"
    runat = "server" />
<asp:FormView ID="FVpurPendingIndents"
  runat = "server"
  DataKeyNames = "IndentNo,IndentLine"
  DataSourceID = "ODSpurPendingIndents"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IndentNo" runat="server" ForeColor="#CC6633" Text="Indent No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_IndentNo"
            Width="88px"
            Text='<%# Bind("IndentNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Indent No."
            Runat="Server" />
          <asp:Label
            ID = "F_IndentNo_Display"
            Text='<%# Eval("PUR_Indents7_IndenterRemarks") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_IndentLine" runat="server" ForeColor="#CC6633" Text="Indent Line :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_IndentLine"
            Text='<%# Bind("IndentLine") %>'
            ToolTip="Value of Indent Line."
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
          <asp:Label ID="L_ItemCode" runat="server" Text="Item Code :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ItemCode"
            Width="88px"
            Text='<%# Bind("ItemCode") %>'
            Enabled = "False"
            ToolTip="Value of Item Code."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ItemCode_Display"
            Text='<%# Eval("PUR_Items8_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_UOM" runat="server" Text="UOM :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_UOM"
            Width="32px"
            Text='<%# Bind("UOM") %>'
            Enabled = "False"
            ToolTip="Value of UOM."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_UOM_Display"
            Text='<%# Eval("SPMT_ERPUnits12_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemDescription" runat="server" Text="Item Description :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ItemDescription"
            Text='<%# Bind("ItemDescription") %>'
            ToolTip="Value of Item Description."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OriginalQuantity" runat="server" Text="Pending Qty. :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_OriginalQuantity"
            Text='<%# Bind("OriginalQuantity") %>'
            ToolTip="Value of Pending Qty.."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_OrderedQuantity" runat="server" Text="Order Qty. :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_OrderedQuantity"
            Text='<%# Bind("OrderedQuantity") %>'
            style="text-align: right"
            Width="184px"
            CssClass = "mytxt"
            MaxLength="22"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEOrderedQuantity"
            runat = "server"
            mask = "999999999999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_OrderedQuantity" />
          <AJX:MaskedEditValidator 
            ID = "MEVOrderedQuantity"
            runat = "server"
            ControlToValidate = "F_OrderedQuantity"
            ControlExtender = "MEEOrderedQuantity"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Price" runat="server" Text="Price :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Price"
            Text='<%# Bind("Price") %>'
            ToolTip="Value of Price."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Amount" runat="server" Text="Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Amount"
            Text='<%# Bind("Amount") %>'
            ToolTip="Value of Amount."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AssessableValue" runat="server" Text="Assessable Value :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AssessableValue"
            Text='<%# Bind("AssessableValue") %>'
            ToolTip="Value of Assessable Value."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TaxCode" runat="server" Text="Tax Code :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TaxCode"
            Width="88px"
            Text='<%# Bind("TaxCode") %>'
            Enabled = "False"
            ToolTip="Value of Tax Code."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_TaxCode_Display"
            Text='<%# Eval("PUR_TaxCodes9_TaxDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CGSTRate" runat="server" Text="CGST Rate :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CGSTRate"
            Text='<%# Bind("CGSTRate") %>'
            ToolTip="Value of CGST Rate."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CGSTAmount" runat="server" Text="CGST Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CGSTAmount"
            Text='<%# Bind("CGSTAmount") %>'
            ToolTip="Value of CGST Amount."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SGSTRate" runat="server" Text="SGST Rate :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SGSTRate"
            Text='<%# Bind("SGSTRate") %>'
            ToolTip="Value of SGST Rate."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SGSTAmount" runat="server" Text="SGST Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SGSTAmount"
            Text='<%# Bind("SGSTAmount") %>'
            ToolTip="Value of SGST Amount."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IGSTrate" runat="server" Text="IGST Rate :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_IGSTrate"
            Text='<%# Bind("IGSTrate") %>'
            ToolTip="Value of IGST Rate."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_IGSTAmount" runat="server" Text="IGST Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_IGSTAmount"
            Text='<%# Bind("IGSTAmount") %>'
            ToolTip="Value of IGST Amount."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CESSRate" runat="server" Text="CESS Rate :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CESSRate"
            Text='<%# Bind("CESSRate") %>'
            ToolTip="Value of CESS Rate."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CESSAmount" runat="server" Text="CESS Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CESSAmount"
            Text='<%# Bind("CESSAmount") %>'
            ToolTip="Value of CESS Amount."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TCSRate" runat="server" Text="TCS Rate :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TCSRate"
            Text='<%# Bind("TCSRate") %>'
            ToolTip="Value of TCS Rate."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TCSAmount" runat="server" Text="TCS Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TCSAmount"
            Text='<%# Bind("TCSAmount") %>'
            ToolTip="Value of TCS Amount."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TotalGST" runat="server" Text="Total GST :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalGST"
            Text='<%# Bind("TotalGST") %>'
            ToolTip="Value of Total GST."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TaxAmount" runat="server" Text="Tax Amount [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TaxAmount"
            Text='<%# Bind("TaxAmount") %>'
            ToolTip="Value of Tax Amount [INR]."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TotalAmount" runat="server" Text="Total Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalAmount"
            Text='<%# Bind("TotalAmount") %>'
            ToolTip="Value of Total Amount."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TotalAmountINR" runat="server" Text="Total Amount [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalAmountINR"
            Text='<%# Bind("TotalAmountINR") %>'
            ToolTip="Value of Total Amount [INR]."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CurrencyID" runat="server" Text="Currency :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CurrencyID"
            Width="88px"
            Text='<%# Bind("CurrencyID") %>'
            Enabled = "False"
            ToolTip="Value of Currency."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CurrencyID_Display"
            Text='<%# Eval("PUR_Currencies6_CurrencyName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ConversionFactorINR" runat="server" Text="Conversion Factor [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ConversionFactorINR"
            Text='<%# Bind("ConversionFactorINR") %>'
            ToolTip="Value of Conversion Factor [INR]."
            Enabled = "False"
            Width="200px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TranTypeID" runat="server" Text="Tran Type :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_TranTypeID"
            Width="32px"
            Text='<%# Bind("TranTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Tran Type."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_TranTypeID_Display"
            Text='<%# Eval("SPMT_TranTypes15_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BillType" runat="server" Text="HSN Type :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_BillType"
            Width="88px"
            Text='<%# Bind("BillType") %>'
            Enabled = "False"
            ToolTip="Value of HSN Type."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_BillType_Display"
            Text='<%# Eval("SPMT_BillTypes10_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_HSNSACCode" runat="server" Text="HSN/SAC Code :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_HSNSACCode"
            Width="168px"
            Text='<%# Bind("HSNSACCode") %>'
            Enabled = "False"
            ToolTip="Value of HSN/SAC Code."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_HSNSACCode_Display"
            Text='<%# Eval("SPMT_HSNSACCodes14_HSNSACCode") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DeliveryDate" runat="server" Text="Delivery Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DeliveryDate"
            Text='<%# Bind("DeliveryDate") %>'
            ToolTip="Value of Delivery Date."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            Enabled = "False"
            ToolTip="Value of Project."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ElementID" runat="server" Text="Element :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ElementID"
            Width="72px"
            Text='<%# Bind("ElementID") %>'
            Enabled = "False"
            ToolTip="Value of Element."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ElementID_Display"
            Text='<%# Eval("IDM_WBS5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_EmployeeID" runat="server" Text="Employee :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_EmployeeID"
            Width="72px"
            Text='<%# Bind("EmployeeID") %>'
            Enabled = "False"
            ToolTip="Value of Employee."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_EmployeeID_Display"
            Text='<%# Eval("HRM_Employees3_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DepartmentID" runat="server" Text="Department :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_DepartmentID"
            Width="56px"
            Text='<%# Bind("DepartmentID") %>'
            Enabled = "False"
            ToolTip="Value of Department."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_DepartmentID_Display"
            Text='<%# Eval("HRM_Departments1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CostCenterID" runat="server" Text="Cost Center :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CostCenterID"
            Width="56px"
            Text='<%# Bind("CostCenterID") %>'
            Enabled = "False"
            ToolTip="Value of Cost Center."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CostCenterID_Display"
            Text='<%# Eval("SPMT_CostCenters11_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DivisionID" runat="server" Text="Division :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_DivisionID"
            Width="56px"
            Text='<%# Bind("DivisionID") %>'
            Enabled = "False"
            ToolTip="Value of Division."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_DivisionID_Display"
            Text='<%# Eval("HRM_Divisions2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
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
  ID = "ODSpurPendingIndents"
  DataObjectTypeName = "SIS.PUR.purPendingIndents"
  SelectMethod = "purPendingIndentsGetByID"
  UpdateMethod="UZ_purPendingIndentsUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purPendingIndents"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="IndentNo" Name="IndentNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="IndentLine" Name="IndentLine" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
