<script type="text/javascript"> 
var script_purItemCategorySpecValues = {
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
    validate_ItemCategoryID: function(sender) {
      var Prefix = sender.id.replace('ItemCategoryID','');
      this.validated_FK_PUR_ItemCategorySpecValues_ItemCategoryID_main = true;
      this.validate_FK_PUR_ItemCategorySpecValues_ItemCategoryID(sender,Prefix);
      },
    validate_CategorySpecID: function(sender) {
      var Prefix = sender.id.replace('CategorySpecID','');
      this.validated_FK_PUR_ItemCategorySpecValues_CategorySpecID_main = true;
      this.validate_FK_PUR_ItemCategorySpecValues_CategorySpecID(sender,Prefix);
      },
    validate_FK_PUR_ItemCategorySpecValues_ItemCategoryID: function(o,Prefix) {
      var value = o.id;
      var ItemCategoryID = $get(Prefix + 'ItemCategoryID');
      if(ItemCategoryID.value==''){
        if(this.validated_FK_PUR_ItemCategorySpecValues_ItemCategoryID_main){
          var o_d = $get(Prefix + 'ItemCategoryID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCategoryID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_ItemCategorySpecValues_ItemCategoryID(value, this.validated_FK_PUR_ItemCategorySpecValues_ItemCategoryID);
      },
    validated_FK_PUR_ItemCategorySpecValues_ItemCategoryID_main: false,
    validated_FK_PUR_ItemCategorySpecValues_ItemCategoryID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purItemCategorySpecValues.validated_FK_PUR_ItemCategorySpecValues_ItemCategoryID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PUR_ItemCategorySpecValues_CategorySpecID: function(o,Prefix) {
      var value = o.id;
      var ItemCategoryID = $get(Prefix + 'ItemCategoryID');
      if(ItemCategoryID.value==''){
        if(this.validated_FK_PUR_ItemCategorySpecValues_CategorySpecID_main){
          var o_d = $get(Prefix + 'ItemCategoryID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCategoryID.value ;
      var CategorySpecID = $get(Prefix + 'CategorySpecID');
      if(CategorySpecID.value==''){
        if(this.validated_FK_PUR_ItemCategorySpecValues_CategorySpecID_main){
          var o_d = $get(Prefix + 'CategorySpecID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CategorySpecID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_ItemCategorySpecValues_CategorySpecID(value, this.validated_FK_PUR_ItemCategorySpecValues_CategorySpecID);
      },
    validated_FK_PUR_ItemCategorySpecValues_CategorySpecID_main: false,
    validated_FK_PUR_ItemCategorySpecValues_CategorySpecID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purItemCategorySpecValues.validated_FK_PUR_ItemCategorySpecValues_CategorySpecID_main){
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
