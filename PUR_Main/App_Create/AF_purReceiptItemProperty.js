<script type="text/javascript"> 
var script_purReceiptItemProperty = {
    ACEReceiptNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ReceiptNo','');
      var F_ReceiptNo = $get(sender._element.id);
      var F_ReceiptNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ReceiptNo.value = p[0];
      F_ReceiptNo_Display.innerHTML = e.get_text();
    },
    ACEReceiptNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ReceiptNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEReceiptNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEReceiptLine_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ReceiptLine','');
      var F_ReceiptLine = $get(sender._element.id);
      var F_ReceiptLine_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ReceiptLine.value = p[1];
      F_ReceiptLine_Display.innerHTML = e.get_text();
    },
    ACEReceiptLine_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ReceiptLine','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEReceiptLine_Populated: function(sender,e) {
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
    ACEItemCategoryID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ItemCategoryID','');
      var F_ItemCategoryID = $get(sender._element.id);
      var F_ItemCategoryID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ItemCategoryID.value = p[0];
      F_ItemCategoryID_Display.innerHTML = e.get_text();
    },
    ACEItemCategoryID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ItemCategoryID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEItemCategoryID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACECategorySpecID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('CategorySpecID','');
      var F_CategorySpecID = $get(sender._element.id);
      var F_CategorySpecID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_CategorySpecID.value = p[1];
      F_CategorySpecID_Display.innerHTML = e.get_text();
    },
    ACECategorySpecID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('CategorySpecID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECategorySpecID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACESerialNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('SerialNo','');
      var F_SerialNo = $get(sender._element.id);
      var F_SerialNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_SerialNo.value = p[2];
      F_SerialNo_Display.innerHTML = e.get_text();
    },
    ACESerialNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('SerialNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACESerialNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ReceiptNo: function(sender) {
      var Prefix = sender.id.replace('ReceiptNo','');
      this.validated_FK_PUR_ReceiptItemProperty_ReceiptNo_main = true;
      this.validate_FK_PUR_ReceiptItemProperty_ReceiptNo(sender,Prefix);
      },
    validate_ReceiptLine: function(sender) {
      var Prefix = sender.id.replace('ReceiptLine','');
      this.validated_FK_PUR_ReceiptItemProperty_ReceiptLine_main = true;
      this.validate_FK_PUR_ReceiptItemProperty_ReceiptLine(sender,Prefix);
      },
    validate_ItemCode: function(sender) {
      var Prefix = sender.id.replace('ItemCode','');
      this.validated_FK_PUR_ReceiptItemProperty_ItemCode_main = true;
      this.validate_FK_PUR_ReceiptItemProperty_ItemCode(sender,Prefix);
      },
    validate_ItemCategoryID: function(sender) {
      var Prefix = sender.id.replace('ItemCategoryID','');
      this.validated_FK_PUR_ReceiptItemProperty_ItemCategoryID_main = true;
      this.validate_FK_PUR_ReceiptItemProperty_ItemCategoryID(sender,Prefix);
      },
    validate_CategorySpecID: function(sender) {
      var Prefix = sender.id.replace('CategorySpecID','');
      this.validated_FK_PUR_ReceiptItemProperty_CategorySpecID_main = true;
      this.validate_FK_PUR_ReceiptItemProperty_CategorySpecID(sender,Prefix);
      },
    validate_SerialNo: function(sender) {
      var Prefix = sender.id.replace('SerialNo','');
      this.validated_FK_PUR_ReceiptItemProperty_SerialNo_main = true;
      this.validate_FK_PUR_ReceiptItemProperty_SerialNo(sender,Prefix);
      },
    validate_FK_PUR_ReceiptItemProperty_ItemCategoryID: function(o,Prefix) {
      var value = o.id;
      var ItemCategoryID = $get(Prefix + 'ItemCategoryID');
      if(ItemCategoryID.value==''){
        if(this.validated_FK_PUR_ReceiptItemProperty_ItemCategoryID_main){
          var o_d = $get(Prefix + 'ItemCategoryID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCategoryID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_ReceiptItemProperty_ItemCategoryID(value, this.validated_FK_PUR_ReceiptItemProperty_ItemCategoryID);
      },
    validated_FK_PUR_ReceiptItemProperty_ItemCategoryID_main: false,
    validated_FK_PUR_ReceiptItemProperty_ItemCategoryID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purReceiptItemProperty.validated_FK_PUR_ReceiptItemProperty_ItemCategoryID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_ReceiptItemProperty_CategorySpecID: function(o,Prefix) {
      var value = o.id;
      var ItemCategoryID = $get(Prefix + 'ItemCategoryID');
      if(ItemCategoryID.value==''){
        if(this.validated_FK_PUR_ReceiptItemProperty_CategorySpecID_main){
          var o_d = $get(Prefix + 'ItemCategoryID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCategoryID.value ;
      var CategorySpecID = $get(Prefix + 'CategorySpecID');
      if(CategorySpecID.value==''){
        if(this.validated_FK_PUR_ReceiptItemProperty_CategorySpecID_main){
          var o_d = $get(Prefix + 'CategorySpecID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CategorySpecID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_ReceiptItemProperty_CategorySpecID(value, this.validated_FK_PUR_ReceiptItemProperty_CategorySpecID);
      },
    validated_FK_PUR_ReceiptItemProperty_CategorySpecID_main: false,
    validated_FK_PUR_ReceiptItemProperty_CategorySpecID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purReceiptItemProperty.validated_FK_PUR_ReceiptItemProperty_CategorySpecID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_ReceiptItemProperty_SerialNo: function(o,Prefix) {
      var value = o.id;
      var ItemCategoryID = $get(Prefix + 'ItemCategoryID');
      if(ItemCategoryID.value==''){
        if(this.validated_FK_PUR_ReceiptItemProperty_SerialNo_main){
          var o_d = $get(Prefix + 'ItemCategoryID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCategoryID.value ;
      var CategorySpecID = $get(Prefix + 'CategorySpecID');
      if(CategorySpecID.value==''){
        if(this.validated_FK_PUR_ReceiptItemProperty_SerialNo_main){
          var o_d = $get(Prefix + 'CategorySpecID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CategorySpecID.value ;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PUR_ReceiptItemProperty_SerialNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_ReceiptItemProperty_SerialNo(value, this.validated_FK_PUR_ReceiptItemProperty_SerialNo);
      },
    validated_FK_PUR_ReceiptItemProperty_SerialNo_main: false,
    validated_FK_PUR_ReceiptItemProperty_SerialNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purReceiptItemProperty.validated_FK_PUR_ReceiptItemProperty_SerialNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_ReceiptItemProperty_ItemCode: function(o,Prefix) {
      var value = o.id;
      var ItemCode = $get(Prefix + 'ItemCode');
      if(ItemCode.value==''){
        if(this.validated_FK_PUR_ReceiptItemProperty_ItemCode_main){
          var o_d = $get(Prefix + 'ItemCode' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCode.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_ReceiptItemProperty_ItemCode(value, this.validated_FK_PUR_ReceiptItemProperty_ItemCode);
      },
    validated_FK_PUR_ReceiptItemProperty_ItemCode_main: false,
    validated_FK_PUR_ReceiptItemProperty_ItemCode: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purReceiptItemProperty.validated_FK_PUR_ReceiptItemProperty_ItemCode_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_ReceiptItemProperty_ReceiptLine: function(o,Prefix) {
      var value = o.id;
      var ReceiptNo = $get(Prefix + 'ReceiptNo');
      if(ReceiptNo.value==''){
        if(this.validated_FK_PUR_ReceiptItemProperty_ReceiptLine_main){
          var o_d = $get(Prefix + 'ReceiptNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ReceiptNo.value ;
      var ReceiptLine = $get(Prefix + 'ReceiptLine');
      if(ReceiptLine.value==''){
        if(this.validated_FK_PUR_ReceiptItemProperty_ReceiptLine_main){
          var o_d = $get(Prefix + 'ReceiptLine' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ReceiptLine.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_ReceiptItemProperty_ReceiptLine(value, this.validated_FK_PUR_ReceiptItemProperty_ReceiptLine);
      },
    validated_FK_PUR_ReceiptItemProperty_ReceiptLine_main: false,
    validated_FK_PUR_ReceiptItemProperty_ReceiptLine: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purReceiptItemProperty.validated_FK_PUR_ReceiptItemProperty_ReceiptLine_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_ReceiptItemProperty_ReceiptNo: function(o,Prefix) {
      var value = o.id;
      var ReceiptNo = $get(Prefix + 'ReceiptNo');
      if(ReceiptNo.value==''){
        if(this.validated_FK_PUR_ReceiptItemProperty_ReceiptNo_main){
          var o_d = $get(Prefix + 'ReceiptNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ReceiptNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_ReceiptItemProperty_ReceiptNo(value, this.validated_FK_PUR_ReceiptItemProperty_ReceiptNo);
      },
    validated_FK_PUR_ReceiptItemProperty_ReceiptNo_main: false,
    validated_FK_PUR_ReceiptItemProperty_ReceiptNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purReceiptItemProperty.validated_FK_PUR_ReceiptItemProperty_ReceiptNo_main){
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
