<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_purIndents.aspx.vb" Inherits="AF_purIndents" title="Add: Indents" %>
<asp:Content ID="CPHpurIndents" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpurIndents" runat="server" Text="&nbsp;Add: Indents"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpurIndents" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpurIndents"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/PUR_Main/App_Edit/EF_purIndents.aspx"
    ValidationGroup = "purIndents"
    runat = "server" />
<asp:FormView ID="FVpurIndents"
  runat = "server"
  DataKeyNames = "IndentNo"
  DataSourceID = "ODSpurIndents"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpurIndents" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IndentNo" ForeColor="#CC6633" runat="server" Text="Indent No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IndentNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TranTypeID" runat="server" Text="Tran Type :" />&nbsp;
        </td>
        <td colspan="3">
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
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsgecGSTIN" runat="server" Text="Isgec GSTIN :" />&nbsp;
        </td>
        <td colspan="3">
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
          <asp:Label ID="L_IsgecGSTINAddress" runat="server" Text="Isgec GSTIN Address :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_IsgecGSTINAddress"
            Text='<%# Bind("IsgecGSTINAddress") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Isgec GSTIN Address."
            TextMode="MultiLine"
            Height="30px"
            MaxLength="500"
            Width="350px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DestinationAddress" runat="server" Text="Destination Address :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DestinationAddress"
            Text='<%# Bind("DestinationAddress") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Destination Address."
            TextMode="MultiLine"
            Height="30px"
            MaxLength="500"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr>
         <td class="alignright">
          <asp:Label ID="L_PaymentTerms" runat="server" Text="Payment Terms :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PaymentTerms"
            Text='<%# Bind("PaymentTerms") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Payment Terms."
            TextMode="MultiLine"
            Height="30px"
            MaxLength="500"
            Width="350px"
            runat="server" />
        </td>
       <td class="alignright">
          <asp:Label ID="L_DeliveryTerms" runat="server" Text="Delivery Terms :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DeliveryTerms"
            Text='<%# Bind("DeliveryTerms") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Delivery Terms."
            TextMode="MultiLine"
            Height="30px"
            MaxLength="500"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_WarrantyDetails" runat="server" Text="Warranty Details :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_WarrantyDetails"
            Text='<%# Bind("WarrantyDetails") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Warranty Details."
            TextMode="MultiLine"
            Height="30px"
            MaxLength="1000"
            Width="350px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_InsuranceDetails" runat="server" Text="Insurance Details :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_InsuranceDetails"
            Text='<%# Bind("InsuranceDetails") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Insurance Details."
            TextMode="MultiLine"
            Height="30px"
            MaxLength="200"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ModeOfDispatch" runat="server" Text="Mode Of Dispatch :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ModeOfDispatch"
            Text='<%# Bind("ModeOfDispatch") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Mode Of Dispatch."
            MaxLength="50"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr>
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
        <td class="alignright">
          <asp:Label ID="L_ApprovedBy" runat="server" Text="To be Approved By :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovedBy"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("ApprovedBy") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Approved By."
            ValidationGroup = "purIndents"
            onblur= "script_purIndents.validate_ApprovedBy(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovedBy_Display"
            Text='<%# Eval("aspnet_users2_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVApprovedBy"
            runat = "server"
            ControlToValidate = "F_ApprovedBy"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "purIndents"
            SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEApprovedBy"
            BehaviorID="B_ACEApprovedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ApprovedByCompletionList"
            TargetControlID="F_ApprovedBy"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_purIndents.ACEApprovedBy_Selected"
            OnClientPopulating="script_purIndents.ACEApprovedBy_Populating"
            OnClientPopulated="script_purIndents.ACEApprovedBy_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IndenterRemarks" runat="server" Text="Indenter Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IndenterRemarks"
            Text='<%# Bind("IndenterRemarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Indenter Remarks."
            TextMode="MultiLine"
            Height="40px"
            MaxLength="500"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
            ValidationGroup = "purIndents"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_ConversionFactorINR" runat="server" Text="Conversion Factor [INR] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ConversionFactorINR"
            Text='<%# Bind("ConversionFactorINR") %>'
            Width="200px"
            CssClass = "mytxt"
            style="text-align: Right"
            MaxLength="24"
            onfocus = "return this.select();"
            onblur="return dc(this,6);"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DepartmentID" runat="server" Text="Department :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_DepartmentID"
            CssClass = "myfktxt"
            Width="56px"
            Text='<%# Bind("DepartmentID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Department."
            onblur= "script_purIndents.validate_DepartmentID(this);"
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
            OnClientItemSelected="script_purIndents.ACEDepartmentID_Selected"
            OnClientPopulating="script_purIndents.ACEDepartmentID_Populating"
            OnClientPopulated="script_purIndents.ACEDepartmentID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CostCenterID" runat="server" Text="Cost Center :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CostCenterID"
            CssClass = "myfktxt"
            Width="56px"
            Text='<%# Bind("CostCenterID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Cost Center."
            onblur= "script_purIndents.validate_CostCenterID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CostCenterID_Display"
            Text='<%# Eval("SPMT_CostCenters10_Description") %>'
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
            OnClientItemSelected="script_purIndents.ACECostCenterID_Selected"
            OnClientPopulating="script_purIndents.ACECostCenterID_Populating"
            OnClientPopulated="script_purIndents.ACECostCenterID_Populated"
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
            Width="72px"
            Text='<%# Bind("EmployeeID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Employee."
            onblur= "script_purIndents.validate_EmployeeID(this);"
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
            OnClientItemSelected="script_purIndents.ACEEmployeeID_Selected"
            OnClientPopulating="script_purIndents.ACEEmployeeID_Populating"
            OnClientPopulated="script_purIndents.ACEEmployeeID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DivisionID" runat="server" Text="Division :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_DivisionID"
            CssClass = "myfktxt"
            Width="56px"
            Text='<%# Bind("DivisionID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Division."
            onblur= "script_purIndents.validate_DivisionID(this);"
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
            OnClientItemSelected="script_purIndents.ACEDivisionID_Selected"
            OnClientPopulating="script_purIndents.ACEDivisionID_Populating"
            OnClientPopulated="script_purIndents.ACEDivisionID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project."
            onblur= "script_purIndents.validate_ProjectID(this);"
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
            OnClientItemSelected="script_purIndents.ACEProjectID_Selected"
            OnClientPopulating="script_purIndents.ACEProjectID_Populating"
            OnClientPopulated="script_purIndents.ACEProjectID_Populated"
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
            Width="72px"
            Text='<%# Bind("ElementID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Element."
            onblur= "script_purIndents.validate_ElementID(this);"
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
            OnClientItemSelected="script_purIndents.ACEElementID_Selected"
            OnClientPopulating="script_purIndents.ACEElementID_Populating"
            OnClientPopulated="script_purIndents.ACEElementID_Populated"
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
  ID = "ODSpurIndents"
  DataObjectTypeName = "SIS.PUR.purIndents"
  InsertMethod="UZ_purIndentsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PUR.purIndents"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
