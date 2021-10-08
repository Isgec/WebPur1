<script type="text/javascript"> 
var script_purItemCategorySpecs = {
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
    ACESpecID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('SpecID','');
      var F_SpecID = $get(sender._element.id);
      var F_SpecID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_SpecID.value = p[0];
      F_SpecID_Display.innerHTML = e.get_text();
    },
    ACESpecID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('SpecID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACESpecID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEDefaultValueSerialNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('DefaultValueSerialNo','');
      var F_DefaultValueSerialNo = $get(sender._element.id);
      var F_DefaultValueSerialNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_DefaultValueSerialNo.value = p[2];
      F_DefaultValueSerialNo_Display.innerHTML = e.get_text();
    },
    ACEDefaultValueSerialNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('DefaultValueSerialNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEDefaultValueSerialNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_SpecID: function(sender) {
      var Prefix = sender.id.replace('SpecID','');
      this.validated_FK_PUR_ItemCategorySpecs_SpecID_main = true;
      this.validate_FK_PUR_ItemCategorySpecs_SpecID(sender,Prefix);
      },
    validate_DefaultValueSerialNo: function(sender) {
      var Prefix = sender.id.replace('DefaultValueSerialNo','');
      this.validated_FK_PUR_ItemCategorySpecs_DefaultValueSerialNo_main = true;
      this.validate_FK_PUR_ItemCategorySpecs_DefaultValueSerialNo(sender,Prefix);
      },
    validate_FK_PUR_ItemCategorySpecs_DefaultValueSerialNo: function(o,Prefix) {
      var value = o.id;
      var ItemCategoryID = $get(Prefix + 'ItemCategoryID');
      if(ItemCategoryID.value==''){
        if(this.validated_FK_PUR_ItemCategorySpecs_DefaultValueSerialNo_main){
          var o_d = $get(Prefix + 'ItemCategoryID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCategoryID.value ;
      var CategorySpecID = $get(Prefix + 'CategorySpecID');
      if(CategorySpecID.value==''){
        if(this.validated_FK_PUR_ItemCategorySpecs_DefaultValueSerialNo_main){
          var o_d = $get(Prefix + 'CategorySpecID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CategorySpecID.value ;
      var DefaultValueSerialNo = $get(Prefix + 'DefaultValueSerialNo');
      if(DefaultValueSerialNo.value==''){
        if(this.validated_FK_PUR_ItemCategorySpecs_DefaultValueSerialNo_main){
          var o_d = $get(Prefix + 'DefaultValueSerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + DefaultValueSerialNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_ItemCategorySpecs_DefaultValueSerialNo(value, this.validated_FK_PUR_ItemCategorySpecs_DefaultValueSerialNo);
      },
    validated_FK_PUR_ItemCategorySpecs_DefaultValueSerialNo_main: false,
    validated_FK_PUR_ItemCategorySpecs_DefaultValueSerialNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purItemCategorySpecs.validated_FK_PUR_ItemCategorySpecs_DefaultValueSerialNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_ItemCategorySpecs_SpecID: function(o,Prefix) {
      var value = o.id;
      var SpecID = $get(Prefix + 'SpecID');
      if(SpecID.value==''){
        if(this.validated_FK_PUR_ItemCategorySpecs_SpecID_main){
          var o_d = $get(Prefix + 'SpecID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SpecID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_ItemCategorySpecs_SpecID(value, this.validated_FK_PUR_ItemCategorySpecs_SpecID);
      },
    validated_FK_PUR_ItemCategorySpecs_SpecID_main: false,
    validated_FK_PUR_ItemCategorySpecs_SpecID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purItemCategorySpecs.validated_FK_PUR_ItemCategorySpecs_SpecID_main){
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
