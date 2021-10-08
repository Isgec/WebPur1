<script type="text/javascript"> 
var script_purIndentItemProperty = {
    ACEIndentNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('IndentNo','');
      var F_IndentNo = $get(sender._element.id);
      var F_IndentNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_IndentNo.value = p[0];
      F_IndentNo_Display.innerHTML = e.get_text();
    },
    ACEIndentNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('IndentNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEIndentNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEIndentLine_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('IndentLine','');
      var F_IndentLine = $get(sender._element.id);
      var F_IndentLine_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_IndentLine.value = p[1];
      F_IndentLine_Display.innerHTML = e.get_text();
    },
    ACEIndentLine_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('IndentLine','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEIndentLine_Populated: function(sender,e) {
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
    validate_CategorySpecID: function(sender) {
      var Prefix = sender.id.replace('CategorySpecID','');
      this.validated_FK_PUR_IndentItemProperty_CategorySpecID_main = true;
      this.validate_FK_PUR_IndentItemProperty_CategorySpecID(sender,Prefix);
      },
    validate_IndentNo: function(sender) {
      var Prefix = sender.id.replace('IndentNo','');
      this.validated_FK_PUR_IndentItemProperty_IndentNo_main = true;
      this.validate_FK_PUR_IndentItemProperty_IndentNo(sender,Prefix);
      },
    validate_ItemCategoryID: function(sender) {
      var Prefix = sender.id.replace('ItemCategoryID','');
      this.validated_FK_PUR_IndentItemProperty_ItemCategoryID_main = true;
      this.validate_FK_PUR_IndentItemProperty_ItemCategoryID(sender,Prefix);
      },
    validate_ItemCode: function(sender) {
      var Prefix = sender.id.replace('ItemCode','');
      this.validated_FK_PUR_IndentItemProperty_ItemCode_main = true;
      this.validate_FK_PUR_IndentItemProperty_ItemCode(sender,Prefix);
      },
    validate_IndentLine: function(sender) {
      var Prefix = sender.id.replace('IndentLine','');
      this.validated_FK_PUR_IndentItemProperty_IndentLine_main = true;
      this.validate_FK_PUR_IndentItemProperty_IndentLine(sender,Prefix);
      },
    validate_SerialNo: function(sender) {
      var Prefix = sender.id.replace('SerialNo','');
      this.validated_FK_PUR_IndentItemProperty_SerialNo_main = true;
      this.validate_FK_PUR_IndentItemProperty_SerialNo(sender,Prefix);
      },
    validate_FK_PUR_IndentItemProperty_IndentLine: function(o,Prefix) {
      var value = o.id;
      var IndentNo = $get(Prefix + 'IndentNo');
      if(IndentNo.value==''){
        if(this.validated_FK_PUR_IndentItemProperty_IndentLine_main){
          var o_d = $get(Prefix + 'IndentNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + IndentNo.value ;
      var IndentLine = $get(Prefix + 'IndentLine');
      if(IndentLine.value==''){
        if(this.validated_FK_PUR_IndentItemProperty_IndentLine_main){
          var o_d = $get(Prefix + 'IndentLine' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + IndentLine.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_IndentItemProperty_IndentLine(value, this.validated_FK_PUR_IndentItemProperty_IndentLine);
      },
    validated_FK_PUR_IndentItemProperty_IndentLine_main: false,
    validated_FK_PUR_IndentItemProperty_IndentLine: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purIndentItemProperty.validated_FK_PUR_IndentItemProperty_IndentLine_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_IndentItemProperty_IndentNo: function(o,Prefix) {
      var value = o.id;
      var IndentNo = $get(Prefix + 'IndentNo');
      if(IndentNo.value==''){
        if(this.validated_FK_PUR_IndentItemProperty_IndentNo_main){
          var o_d = $get(Prefix + 'IndentNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + IndentNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_IndentItemProperty_IndentNo(value, this.validated_FK_PUR_IndentItemProperty_IndentNo);
      },
    validated_FK_PUR_IndentItemProperty_IndentNo_main: false,
    validated_FK_PUR_IndentItemProperty_IndentNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purIndentItemProperty.validated_FK_PUR_IndentItemProperty_IndentNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_IndentItemProperty_ItemCategoryID: function(o,Prefix) {
      var value = o.id;
      var ItemCategoryID = $get(Prefix + 'ItemCategoryID');
      if(ItemCategoryID.value==''){
        if(this.validated_FK_PUR_IndentItemProperty_ItemCategoryID_main){
          var o_d = $get(Prefix + 'ItemCategoryID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCategoryID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_IndentItemProperty_ItemCategoryID(value, this.validated_FK_PUR_IndentItemProperty_ItemCategoryID);
      },
    validated_FK_PUR_IndentItemProperty_ItemCategoryID_main: false,
    validated_FK_PUR_IndentItemProperty_ItemCategoryID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purIndentItemProperty.validated_FK_PUR_IndentItemProperty_ItemCategoryID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_IndentItemProperty_CategorySpecID: function(o,Prefix) {
      var value = o.id;
      var ItemCategoryID = $get(Prefix + 'ItemCategoryID');
      if(ItemCategoryID.value==''){
        if(this.validated_FK_PUR_IndentItemProperty_CategorySpecID_main){
          var o_d = $get(Prefix + 'ItemCategoryID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCategoryID.value ;
      var CategorySpecID = $get(Prefix + 'CategorySpecID');
      if(CategorySpecID.value==''){
        if(this.validated_FK_PUR_IndentItemProperty_CategorySpecID_main){
          var o_d = $get(Prefix + 'CategorySpecID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CategorySpecID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_IndentItemProperty_CategorySpecID(value, this.validated_FK_PUR_IndentItemProperty_CategorySpecID);
      },
    validated_FK_PUR_IndentItemProperty_CategorySpecID_main: false,
    validated_FK_PUR_IndentItemProperty_CategorySpecID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purIndentItemProperty.validated_FK_PUR_IndentItemProperty_CategorySpecID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_IndentItemProperty_SerialNo: function(o,Prefix) {
      var value = o.id;
      var ItemCategoryID = $get(Prefix + 'ItemCategoryID');
      if(ItemCategoryID.value==''){
        if(this.validated_FK_PUR_IndentItemProperty_SerialNo_main){
          var o_d = $get(Prefix + 'ItemCategoryID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCategoryID.value ;
      var CategorySpecID = $get(Prefix + 'CategorySpecID');
      if(CategorySpecID.value==''){
        if(this.validated_FK_PUR_IndentItemProperty_SerialNo_main){
          var o_d = $get(Prefix + 'CategorySpecID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CategorySpecID.value ;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PUR_IndentItemProperty_SerialNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_IndentItemProperty_SerialNo(value, this.validated_FK_PUR_IndentItemProperty_SerialNo);
      },
    validated_FK_PUR_IndentItemProperty_SerialNo_main: false,
    validated_FK_PUR_IndentItemProperty_SerialNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purIndentItemProperty.validated_FK_PUR_IndentItemProperty_SerialNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_IndentItemProperty_ItemCode: function(o,Prefix) {
      var value = o.id;
      var ItemCode = $get(Prefix + 'ItemCode');
      if(ItemCode.value==''){
        if(this.validated_FK_PUR_IndentItemProperty_ItemCode_main){
          var o_d = $get(Prefix + 'ItemCode' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCode.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_IndentItemProperty_ItemCode(value, this.validated_FK_PUR_IndentItemProperty_ItemCode);
      },
    validated_FK_PUR_IndentItemProperty_ItemCode_main: false,
    validated_FK_PUR_IndentItemProperty_ItemCode: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purIndentItemProperty.validated_FK_PUR_IndentItemProperty_ItemCode_main){
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
