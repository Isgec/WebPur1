<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_purOrders.aspx.vb" Inherits="AF_purOrders" title="Add: Orders" %>
<asp:Content ID="CPHpurOrders" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurOrders" runat="server" Text="&nbsp;Add: Orders"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurOrders" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurOrders"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/PUR_Main/App_Edit/EF_purOrders.aspx"
    ValidationGroup = "purOrders"
    runat = "server" />
<asp:FormView ID="FVpurOrders"
  runat = "server"
  DataKeyNames = "OrderNo,OrderRev"
  DataSourceID = "ODSpurOrders"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpurOrders" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_OrderNo" ForeColor="#CC6633" runat="server" Text="Order No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_OrderNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_OrderRev" ForeColor="#CC6633" runat="server" Text="Order Rev :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_OrderRev"
            Text="0"
            Width="88px"
            style="text-align: Right"
            CssClass = "mypktxt"
            Enabled="false"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PurchaseTypeID" runat="server" Text="Purchase Type :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_purPurchaseTypes
            ID="F_PurchaseTypeID"
            SelectedValue='<%# Bind("PurchaseTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "purOrders"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_AprTypeID" runat="server" Text="Approval Type :" />&nbsp;
        </td>
        <td>
          <LGM:LC_purApprovalTypes
            ID="F_AprTypeID"
            SelectedValue='<%# Bind("AprTypeID") %>'
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TranTypeID" runat="server" Text="Tran Type :" />&nbsp;
        </td>
        <td>
          <LGM:LC_spmtTranTypes
            ID="F_TranTypeID"
            SelectedValue='<%# Bind("TranTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_IsgecGSTIN" runat="server" Text="Isgec GSTIN :" />&nbsp;
        </td>
        <td>
          <LGM:LC_spmtIsgecGSTIN
            ID="F_IsgecGSTIN"
            SelectedValue='<%# Bind("IsgecGSTIN") %>'
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
          <asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_SupplierID"
            CssClass = "myfktxt"
            Text='<%# Bind("SupplierID") %>'
            AutoCompleteType = "None"
            Width="80px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Supplier."
            ValidationGroup = "purOrders"
            onblur= "script_purOrders.validate_SupplierID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSupplierID"
            runat = "server"
            ControlToValidate = "F_SupplierID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purOrders"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_SupplierID_Display"
            Text='<%# Eval("VR_BusinessPartner16_BPName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESupplierID"
            BehaviorID="B_ACESupplierID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SupplierIDCompletionList"
            TargetControlID="F_SupplierID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purOrders.ACESupplierID_Selected"
            OnClientPopulating="script_purOrders.ACESupplierID_Populating"
            OnClientPopulated="script_purOrders.ACESupplierID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierName" runat="server" Text="Supplier Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierName"
            Text='<%# Bind("SupplierName") %>'
            Width="300px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Supplier Name."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierGSTIN" runat="server" Text="Supplier GSTIN :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SupplierGSTIN"
            CssClass = "myfktxt"
            Text='<%# Bind("SupplierGSTIN") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Supplier GSTIN."
            onblur= "script_purOrders.validate_SupplierGSTIN(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SupplierGSTIN_Display"
            Text='<%# Eval("VR_BPGSTIN15_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESupplierGSTIN"
            BehaviorID="B_ACESupplierGSTIN"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SupplierGSTINCompletionList"
            TargetControlID="F_SupplierGSTIN"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purOrders.ACESupplierGSTIN_Selected"
            OnClientPopulating="script_purOrders.ACESupplierGSTIN_Populating"
            OnClientPopulated="script_purOrders.ACESupplierGSTIN_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierGSTINUMBER" runat="server" Text="Supplier GST Number :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierGSTINUMBER"
            Text='<%# Bind("SupplierGSTINUMBER") %>'
            Width="300px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Supplier GST Number."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ModeOfDispatch" runat="server" Text="Mode Of Dispatch :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ModeOfDispatch"
            Text='<%# Bind("ModeOfDispatch") %>'
            Width="300px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Mode Of Dispatch."
            MaxLength="50"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DeliveryDate" runat="server" Text="Delivery Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DeliveryDate"
            Text='<%# Bind("DeliveryDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonDeliveryDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDeliveryDate"
            TargetControlID="F_DeliveryDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDeliveryDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEDeliveryDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_DeliveryDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVDeliveryDate"
            runat = "server"
            ControlToValidate = "F_DeliveryDate"
            ControlExtender = "MEEDeliveryDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CurrencyID" runat="server" Text="Currency :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_purCurrencies
            ID="F_CurrencyID"
            SelectedValue='<%# Bind("CurrencyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "purOrders"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_ConversionFactorINR" runat="server" Text="Conversion Factor [INR] :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ConversionFactorINR"
            Text='<%# Bind("ConversionFactorINR") %>'
            style="text-align: right"
            Width="200px"
            CssClass = "mytxt"
            ValidationGroup= "purOrders"
            MaxLength="24"
            onfocus = "return this.select();"
            onblur="return dc(this,6);"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_QuatationNo" runat="server" Text="Quatation No. :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_QuatationNo"
            Text='<%# Bind("QuatationNo") %>'
            Width="168px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Quatation No.."
            MaxLength="20"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_QuotationDate" runat="server" Text="Quotation Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_QuotationDate"
            Text='<%# Bind("QuotationDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonQuotationDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEQuotationDate"
            TargetControlID="F_QuotationDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonQuotationDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEQuotationDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_QuotationDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVQuotationDate"
            runat = "server"
            ControlToValidate = "F_QuotationDate"
            ControlExtender = "MEEQuotationDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DestinationAddress" runat="server" Text="Destination Address :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DestinationAddress"
            Text='<%# Bind("DestinationAddress") %>'
            Width="300px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Destination Address."
            MaxLength="500"
            TextMode="MultiLine" Height="60px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_IsgecGSTINAddress" runat="server" Text="Billing Address :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_IsgecGSTINAddress"
            Text='<%# Bind("IsgecGSTINAddress") %>'
            Width="300px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter Billing Address."
            MaxLength="500"
            TextMode="MultiLine" 
            Height="60px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PaymentTerms" runat="server" Text="Payment Terms :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PaymentTerms"
            Text='<%# Bind("PaymentTerms") %>'
            Width="700px"
            TextMode="MultiLine" Height="40px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Payment Terms."
            MaxLength="500"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DeliveryTerms" runat="server" Text="Delivery Terms :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DeliveryTerms"
            Text='<%# Bind("DeliveryTerms") %>'
            Width="700px"
            TextMode="MultiLine" Height="40px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Delivery Terms."
            MaxLength="500"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_InsuranceDetails" runat="server" Text="Insurance Details :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_InsuranceDetails"
            Text='<%# Bind("InsuranceDetails") %>'
            Width="700px"
            TextMode="MultiLine" Height="40px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Insurance Details."
            MaxLength="200"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_WarrantyDetails" runat="server" Text="Warranty Details :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WarrantyDetails"
            Text='<%# Bind("WarrantyDetails") %>'
            Width="700px"
            TextMode="MultiLine" Height="40px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Warranty Details."
            MaxLength="1000"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OrderText" runat="server" Text="Order Text :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_OrderText"
            Text='<%# Bind("OrderText") %>'
            Width="700px"
            TextMode="MultiLine" Height="40px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Order Text."
            MaxLength="100000"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BuyerRemarks" runat="server" Text="Buyer Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BuyerRemarks"
            Text='<%# Bind("BuyerRemarks") %>'
            Width="700px"
            TextMode="MultiLine" Height="40px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Buyer Remarks."
            MaxLength="500"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            Width="56px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project."
            onblur= "script_purOrders.validate_ProjectID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects6_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purOrders.ACEProjectID_Selected"
            OnClientPopulating="script_purOrders.ACEProjectID_Populating"
            OnClientPopulated="script_purOrders.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ElementID" runat="server" Text="Element :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ElementID"
            CssClass = "myfktxt"
            Text='<%# Bind("ElementID") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Element."
            onblur= "script_purOrders.validate_ElementID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ElementID_Display"
            Text='<%# Eval("IDM_WBS7_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEElementID"
            BehaviorID="B_ACEElementID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ElementIDCompletionList"
            TargetControlID="F_ElementID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purOrders.ACEElementID_Selected"
            OnClientPopulating="script_purOrders.ACEElementID_Populating"
            OnClientPopulated="script_purOrders.ACEElementID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
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
            CssClass = "myfktxt"
            Text='<%# Bind("EmployeeID") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Employee."
            onblur= "script_purOrders.validate_EmployeeID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_EmployeeID_Display"
            Text='<%# Eval("HRM_Employees5_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEEmployeeID"
            BehaviorID="B_ACEEmployeeID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="EmployeeIDCompletionList"
            TargetControlID="F_EmployeeID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purOrders.ACEEmployeeID_Selected"
            OnClientPopulating="script_purOrders.ACEEmployeeID_Populating"
            OnClientPopulated="script_purOrders.ACEEmployeeID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DepartmentID" runat="server" Text="Department :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_DepartmentID"
            CssClass = "myfktxt"
            Text='<%# Bind("DepartmentID") %>'
            AutoCompleteType = "None"
            Width="56px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Department."
            onblur= "script_purOrders.validate_DepartmentID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_DepartmentID_Display"
            Text='<%# Eval("HRM_Departments3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDepartmentID"
            BehaviorID="B_ACEDepartmentID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DepartmentIDCompletionList"
            TargetControlID="F_DepartmentID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purOrders.ACEDepartmentID_Selected"
            OnClientPopulating="script_purOrders.ACEDepartmentID_Populating"
            OnClientPopulated="script_purOrders.ACEDepartmentID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CostCenterID" runat="server" Text="CostCenter :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CostCenterID"
            CssClass = "myfktxt"
            Text='<%# Bind("CostCenterID") %>'
            AutoCompleteType = "None"
            Width="56px"
            onfocus = "return this.select();"
            ToolTip="Enter value for CostCenter."
            onblur= "script_purOrders.validate_CostCenterID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CostCenterID_Display"
            Text='<%# Eval("SPMT_CostCenters12_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECostCenterID"
            BehaviorID="B_ACECostCenterID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CostCenterIDCompletionList"
            TargetControlID="F_CostCenterID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purOrders.ACECostCenterID_Selected"
            OnClientPopulating="script_purOrders.ACECostCenterID_Populating"
            OnClientPopulated="script_purOrders.ACECostCenterID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DivisionID" runat="server" Text="DivisionID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_DivisionID"
            CssClass = "myfktxt"
            Text='<%# Bind("DivisionID") %>'
            AutoCompleteType = "None"
            Width="56px"
            onfocus = "return this.select();"
            ToolTip="Enter value for DivisionID."
            onblur= "script_purOrders.validate_DivisionID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_DivisionID_Display"
            Text='<%# Eval("HRM_Divisions4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDivisionID"
            BehaviorID="B_ACEDivisionID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DivisionIDCompletionList"
            TargetControlID="F_DivisionID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purOrders.ACEDivisionID_Selected"
            OnClientPopulating="script_purOrders.ACEDivisionID_Populating"
            OnClientPopulated="script_purOrders.ACEDivisionID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpurOrders"
  DataObjectTypeName = "SIS.PUR.purOrders"
  InsertMethod="UZ_purOrdersInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purOrders"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
