<script type="text/javascript"> 
var script_purOrderDetails = {
    ACEOrderNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('OrderNo','');
      var F_OrderNo = $get(sender._element.id);
      var F_OrderNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_OrderNo.value = p[0];
      F_OrderNo_Display.innerHTML = e.get_text();
    },
    ACEOrderNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('OrderNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEOrderNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEItemCode_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ItemCode','');
      var F_ItemCode = $get(sender._element.id);
      var F_ItemCode_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ItemCode.value = p[0];
      F_ItemCode_Display.innerHTML = e.get_text();
    },
    ACEItemCode_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ItemCode','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEItemCode_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEHSNSACCode_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('HSNSACCode','');
      var F_HSNSACCode = $get(sender._element.id);
      var F_HSNSACCode_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_HSNSACCode.value = p[1];
      F_HSNSACCode_Display.innerHTML = e.get_text();
    },
    ACEHSNSACCode_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('HSNSACCode','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
      var F_BillType = $get(Prefix + 'BillType');
      sender._contextKey = F_BillType.value;
    },
    ACEHSNSACCode_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEProjectID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ProjectID','');
      var F_ProjectID = $get(sender._element.id);
      var F_ProjectID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ProjectID.value = p[0];
      F_ProjectID_Display.innerHTML = e.get_text();
    },
    ACEProjectID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ProjectID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEProjectID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEElementID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ElementID','');
      var F_ElementID = $get(sender._element.id);
      var F_ElementID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ElementID.value = p[0];
      F_ElementID_Display.innerHTML = e.get_text();
    },
    ACEElementID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ElementID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEElementID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEEmployeeID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('EmployeeID','');
      var F_EmployeeID = $get(sender._element.id);
      var F_EmployeeID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_EmployeeID.value = p[0];
      F_EmployeeID_Display.innerHTML = e.get_text();
    },
    ACEEmployeeID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('EmployeeID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEEmployeeID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEDepartmentID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('DepartmentID','');
      var F_DepartmentID = $get(sender._element.id);
      var F_DepartmentID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_DepartmentID.value = p[0];
      F_DepartmentID_Display.innerHTML = e.get_text();
    },
    ACEDepartmentID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('DepartmentID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEDepartmentID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACECostCenterID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('CostCenterID','');
      var F_CostCenterID = $get(sender._element.id);
      var F_CostCenterID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_CostCenterID.value = p[0];
      F_CostCenterID_Display.innerHTML = e.get_text();
    },
    ACECostCenterID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('CostCenterID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECostCenterID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEDivisionID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('DivisionID','');
      var F_DivisionID = $get(sender._element.id);
      var F_DivisionID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_DivisionID.value = p[0];
      F_DivisionID_Display.innerHTML = e.get_text();
    },
    ACEDivisionID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('DivisionID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEDivisionID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ItemCode: function(sender) {
      var Prefix = sender.id.replace('ItemCode','');
      this.validated_FK_PUR_OrderDetails_ItemCode_main = true;
      this.validate_FK_PUR_OrderDetails_ItemCode(sender,Prefix);
      },
    validate_OrderNo: function(sender) {
      var Prefix = sender.id.replace('OrderNo','');
      this.validated_FK_PUR_OrderDetails_OrderNo_main = true;
      this.validate_FK_PUR_OrderDetails_OrderNo(sender,Prefix);
      },
    validate_HSNSACCode: function(sender) {
      var Prefix = sender.id.replace('HSNSACCode','');
      this.validated_FK_PUR_OrderDetails_HSNSACCode_main = true;
      this.validate_FK_PUR_OrderDetails_HSNSACCode(sender,Prefix);
      },
    validate_ProjectID: function(sender) {
      var Prefix = sender.id.replace('ProjectID','');
      this.validated_FK_PUR_OrderDetails_ProjectID_main = true;
      this.validate_FK_PUR_OrderDetails_ProjectID(sender,Prefix);
      },
    validate_ElementID: function(sender) {
      var Prefix = sender.id.replace('ElementID','');
      this.validated_FK_PUR_OrderDetails_ElementID_main = true;
      this.validate_FK_PUR_OrderDetails_ElementID(sender,Prefix);
      },
    validate_EmployeeID: function(sender) {
      var Prefix = sender.id.replace('EmployeeID','');
      this.validated_FK_PUR_OrderDetails_EmployeeID_main = true;
      this.validate_FK_PUR_OrderDetails_EmployeeID(sender,Prefix);
      },
    validate_DepartmentID: function(sender) {
      var Prefix = sender.id.replace('DepartmentID','');
      this.validated_FK_PUR_OrderDetails_DepartmentID_main = true;
      this.validate_FK_PUR_OrderDetails_DepartmentID(sender,Prefix);
      },
    validate_CostCenterID: function(sender) {
      var Prefix = sender.id.replace('CostCenterID','');
      this.validated_FK_PUR_OrderDetails_CostCenterID_main = true;
      this.validate_FK_PUR_OrderDetails_CostCenterID(sender,Prefix);
      },
    validate_DivisionID: function(sender) {
      var Prefix = sender.id.replace('DivisionID','');
      this.validated_FK_PUR_OrderDetails_DivisionID_main = true;
      this.validate_FK_PUR_OrderDetails_DivisionID(sender,Prefix);
      },
    validate_FK_PUR_OrderDetails_DepartmentID: function(o,Prefix) {
      var value = o.id;
      var DepartmentID = $get(Prefix + 'DepartmentID');
      if(DepartmentID.value==''){
        if(this.validated_FK_PUR_OrderDetails_DepartmentID_main){
          var o_d = $get(Prefix + 'DepartmentID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + DepartmentID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_OrderDetails_DepartmentID(value, this.validated_FK_PUR_OrderDetails_DepartmentID);
      },
    validated_FK_PUR_OrderDetails_DepartmentID_main: false,
    validated_FK_PUR_OrderDetails_DepartmentID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purOrderDetails.validated_FK_PUR_OrderDetails_DepartmentID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_OrderDetails_DivisionID: function(o,Prefix) {
      var value = o.id;
      var DivisionID = $get(Prefix + 'DivisionID');
      if(DivisionID.value==''){
        if(this.validated_FK_PUR_OrderDetails_DivisionID_main){
          var o_d = $get(Prefix + 'DivisionID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + DivisionID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_OrderDetails_DivisionID(value, this.validated_FK_PUR_OrderDetails_DivisionID);
      },
    validated_FK_PUR_OrderDetails_DivisionID_main: false,
    validated_FK_PUR_OrderDetails_DivisionID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purOrderDetails.validated_FK_PUR_OrderDetails_DivisionID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_OrderDetails_EmployeeID: function(o,Prefix) {
      var value = o.id;
      var EmployeeID = $get(Prefix + 'EmployeeID');
      if(EmployeeID.value==''){
        if(this.validated_FK_PUR_OrderDetails_EmployeeID_main){
          var o_d = $get(Prefix + 'EmployeeID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + EmployeeID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_OrderDetails_EmployeeID(value, this.validated_FK_PUR_OrderDetails_EmployeeID);
      },
    validated_FK_PUR_OrderDetails_EmployeeID_main: false,
    validated_FK_PUR_OrderDetails_EmployeeID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purOrderDetails.validated_FK_PUR_OrderDetails_EmployeeID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_OrderDetails_ProjectID: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_PUR_OrderDetails_ProjectID_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_OrderDetails_ProjectID(value, this.validated_FK_PUR_OrderDetails_ProjectID);
      },
    validated_FK_PUR_OrderDetails_ProjectID_main: false,
    validated_FK_PUR_OrderDetails_ProjectID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purOrderDetails.validated_FK_PUR_OrderDetails_ProjectID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_OrderDetails_ElementID: function(o,Prefix) {
      var value = o.id;
      var ElementID = $get(Prefix + 'ElementID');
      if(ElementID.value==''){
        if(this.validated_FK_PUR_OrderDetails_ElementID_main){
          var o_d = $get(Prefix + 'ElementID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ElementID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_OrderDetails_ElementID(value, this.validated_FK_PUR_OrderDetails_ElementID);
      },
    validated_FK_PUR_OrderDetails_ElementID_main: false,
    validated_FK_PUR_OrderDetails_ElementID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purOrderDetails.validated_FK_PUR_OrderDetails_ElementID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_OrderDetails_ItemCode: function(o,Prefix) {
      var value = o.id;
      var ItemCode = $get(Prefix + 'ItemCode');
      if(ItemCode.value==''){
        if(this.validated_FK_PUR_OrderDetails_ItemCode_main){
          var o_d = $get(Prefix + 'ItemCode' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCode.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_OrderDetails_ItemCode(value, this.validated_FK_PUR_OrderDetails_ItemCode);
      },
    validated_FK_PUR_OrderDetails_ItemCode_main: false,
    validated_FK_PUR_OrderDetails_ItemCode: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purOrderDetails.validated_FK_PUR_OrderDetails_ItemCode_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
          try{$get(p[1].replace('ItemCode','ItemDescription')).value=p[3];}catch(ex){}
          try{$get(p[1].replace('ItemCode','UOM')).value=p[4];}catch(ex){}
        }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_OrderDetails_OrderNo: function(o,Prefix) {
      var value = o.id;
      var OrderNo = $get(Prefix + 'OrderNo');
      if(OrderNo.value==''){
        if(this.validated_FK_PUR_OrderDetails_OrderNo_main){
          var o_d = $get(Prefix + 'OrderNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + OrderNo.value ;
      var OrderRev = $get(Prefix + 'OrderRev');
      if(OrderRev.value==''){
        if(this.validated_FK_PUR_OrderDetails_OrderNo_main){
          var o_d = $get(Prefix + 'OrderRev' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + OrderRev.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_OrderDetails_OrderNo(value, this.validated_FK_PUR_OrderDetails_OrderNo);
      },
    validated_FK_PUR_OrderDetails_OrderNo_main: false,
    validated_FK_PUR_OrderDetails_OrderNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purOrderDetails.validated_FK_PUR_OrderDetails_OrderNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_OrderDetails_CostCenterID: function(o,Prefix) {
      var value = o.id;
      var CostCenterID = $get(Prefix + 'CostCenterID');
      if(CostCenterID.value==''){
        if(this.validated_FK_PUR_OrderDetails_CostCenterID_main){
          var o_d = $get(Prefix + 'CostCenterID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CostCenterID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_OrderDetails_CostCenterID(value, this.validated_FK_PUR_OrderDetails_CostCenterID);
      },
    validated_FK_PUR_OrderDetails_CostCenterID_main: false,
    validated_FK_PUR_OrderDetails_CostCenterID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purOrderDetails.validated_FK_PUR_OrderDetails_CostCenterID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_OrderDetails_HSNSACCode: function(o,Prefix) {
      var value = o.id;
      var BillType = $get(Prefix + 'BillType');
      if(BillType.value==''){
        if(this.validated_FK_PUR_OrderDetails_HSNSACCode_main){
          var o_d = $get(Prefix + 'BillType' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + BillType.value ;
      var HSNSACCode = $get(Prefix + 'HSNSACCode');
      if(HSNSACCode.value==''){
        if(this.validated_FK_PUR_OrderDetails_HSNSACCode_main){
          var o_d = $get(Prefix + 'HSNSACCode' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + HSNSACCode.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_OrderDetails_HSNSACCode(value, this.validated_FK_PUR_OrderDetails_HSNSACCode);
      },
    validated_FK_PUR_OrderDetails_HSNSACCode_main: false,
    validated_FK_PUR_OrderDetails_HSNSACCode: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purOrderDetails.validated_FK_PUR_OrderDetails_HSNSACCode_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    ACEUOM_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('UOM','');
      var F_UOM = $get(sender._element.id);
      var F_UOM_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_UOM.value = p[0];
      F_UOM_Display.innerHTML = e.get_text();
    },
    ACEUOM_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('UOM','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEUOM_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_UOM: function(sender) {
      var Prefix = sender.id.replace('UOM','');
      this.validated_FK_PUR_OrderDetails_UOM_main = true;
      this.validate_FK_PUR_OrderDetails_UOM(sender,Prefix);
    },
    validate_FK_PUR_OrderDetails_UOM: function(o,Prefix) {
      var value = o.id;
      var UOM = $get(Prefix + 'UOM');
      if(UOM.value==''){
        if(this.validated_FK_PUR_OrderDetails_UOM_main){
          var o_d = $get(Prefix + 'UOM' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + UOM.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validate_FK_PUR_OrderDetails_UOM(value, this.validated_FK_PUR_OrderDetails_UOM);
    },
    validated_FK_PUR_OrderDetails_UOM_main: false,
    validated_FK_PUR_OrderDetails_UOM: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purOrderDetails.validated_FK_PUR_OrderDetails_UOM_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
