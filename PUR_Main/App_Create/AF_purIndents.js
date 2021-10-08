<script type="text/javascript"> 
var script_purIndents = {
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
    validate_CostCenterID: function(sender) {
      var Prefix = sender.id.replace('CostCenterID','');
      this.validated_FK_PUR_Indents_CostCenterID_main = true;
      this.validate_FK_PUR_Indents_CostCenterID(sender,Prefix);
      },
    validate_EmployeeID: function(sender) {
      var Prefix = sender.id.replace('EmployeeID','');
      this.validated_FK_PUR_Indents_EmployeeID_main = true;
      this.validate_FK_PUR_Indents_EmployeeID(sender,Prefix);
      },
    validate_DepartmentID: function(sender) {
      var Prefix = sender.id.replace('DepartmentID','');
      this.validated_FK_PUR_Indents_DepartmentID_main = true;
      this.validate_FK_PUR_Indents_DepartmentID(sender,Prefix);
      },
    validate_ProjectID: function(sender) {
      var Prefix = sender.id.replace('ProjectID','');
      this.validated_FK_PUR_Indents_ProjectID_main = true;
      this.validate_FK_PUR_Indents_ProjectID(sender,Prefix);
      },
    validate_DivisionID: function(sender) {
      var Prefix = sender.id.replace('DivisionID','');
      this.validated_FK_PUR_Indents_DivisionID_main = true;
      this.validate_FK_PUR_Indents_DivisionID(sender,Prefix);
      },
    validate_ElementID: function(sender) {
      var Prefix = sender.id.replace('ElementID','');
      this.validated_FK_PUR_Indents_ElementID_main = true;
      this.validate_FK_PUR_Indents_ElementID(sender,Prefix);
      },
    validate_FK_PUR_Indents_DepartmentID: function(o,Prefix) {
      var value = o.id;
      var DepartmentID = $get(Prefix + 'DepartmentID');
      if(DepartmentID.value==''){
        if(this.validated_FK_PUR_Indents_DepartmentID_main){
          var o_d = $get(Prefix + 'DepartmentID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + DepartmentID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_Indents_DepartmentID(value, this.validated_FK_PUR_Indents_DepartmentID);
      },
    validated_FK_PUR_Indents_DepartmentID_main: false,
    validated_FK_PUR_Indents_DepartmentID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purIndents.validated_FK_PUR_Indents_DepartmentID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_Indents_DivisionID: function(o,Prefix) {
      var value = o.id;
      var DivisionID = $get(Prefix + 'DivisionID');
      if(DivisionID.value==''){
        if(this.validated_FK_PUR_Indents_DivisionID_main){
          var o_d = $get(Prefix + 'DivisionID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + DivisionID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_Indents_DivisionID(value, this.validated_FK_PUR_Indents_DivisionID);
      },
    validated_FK_PUR_Indents_DivisionID_main: false,
    validated_FK_PUR_Indents_DivisionID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purIndents.validated_FK_PUR_Indents_DivisionID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_Indents_EmployeeID: function(o,Prefix) {
      var value = o.id;
      var EmployeeID = $get(Prefix + 'EmployeeID');
      if(EmployeeID.value==''){
        if(this.validated_FK_PUR_Indents_EmployeeID_main){
          var o_d = $get(Prefix + 'EmployeeID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + EmployeeID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_Indents_EmployeeID(value, this.validated_FK_PUR_Indents_EmployeeID);
      },
    validated_FK_PUR_Indents_EmployeeID_main: false,
    validated_FK_PUR_Indents_EmployeeID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purIndents.validated_FK_PUR_Indents_EmployeeID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_Indents_ProjectID: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_PUR_Indents_ProjectID_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_Indents_ProjectID(value, this.validated_FK_PUR_Indents_ProjectID);
      },
    validated_FK_PUR_Indents_ProjectID_main: false,
    validated_FK_PUR_Indents_ProjectID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purIndents.validated_FK_PUR_Indents_ProjectID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_Indents_ElementID: function(o,Prefix) {
      var value = o.id;
      var ElementID = $get(Prefix + 'ElementID');
      if(ElementID.value==''){
        if(this.validated_FK_PUR_Indents_ElementID_main){
          var o_d = $get(Prefix + 'ElementID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ElementID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_Indents_ElementID(value, this.validated_FK_PUR_Indents_ElementID);
      },
    validated_FK_PUR_Indents_ElementID_main: false,
    validated_FK_PUR_Indents_ElementID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purIndents.validated_FK_PUR_Indents_ElementID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_Indents_CostCenterID: function(o,Prefix) {
      var value = o.id;
      var CostCenterID = $get(Prefix + 'CostCenterID');
      if(CostCenterID.value==''){
        if(this.validated_FK_PUR_Indents_CostCenterID_main){
          var o_d = $get(Prefix + 'CostCenterID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CostCenterID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_Indents_CostCenterID(value, this.validated_FK_PUR_Indents_CostCenterID);
      },
    validated_FK_PUR_Indents_CostCenterID_main: false,
    validated_FK_PUR_Indents_CostCenterID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purIndents.validated_FK_PUR_Indents_CostCenterID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    ACEApprovedBy_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ApprovedBy','');
      var F_ApprovedBy = $get(sender._element.id);
      var F_ApprovedBy_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ApprovedBy.value = p[0];
      F_ApprovedBy_Display.innerHTML = e.get_text();
    },
    ACEApprovedBy_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ApprovedBy','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEApprovedBy_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ApprovedBy: function(sender) {
      var Prefix = sender.id.replace('ApprovedBy','');
      this.validated_FK_PUR_Indents_ApprovedBy_main = true;
      this.validate_FK_PUR_Indents_ApprovedBy(sender,Prefix);
    },
    validate_FK_PUR_Indents_ApprovedBy: function(o,Prefix) {
      var value = o.id;
      var ApprovedBy = $get(Prefix + 'ApprovedBy');
      if(ApprovedBy.value==''){
        if(this.validated_FK_PUR_Indents_ApprovedBy_main){
          var o_d = $get(Prefix + 'ApprovedBy' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ApprovedBy.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validate_FK_PUR_Indents_ApprovedBy(value, this.validated_FK_PUR_Indents_ApprovedBy);
    },
    validated_FK_PUR_Indents_ApprovedBy_main: false,
    validated_FK_PUR_Indents_ApprovedBy: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purIndents.validated_FK_PUR_Indents_ApprovedBy_main){
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
