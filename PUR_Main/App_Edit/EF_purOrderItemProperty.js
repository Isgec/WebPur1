<script type="text/javascript"> 
var script_purOrderItemProperty = {
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
    ACEOrderLine_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('OrderLine','');
      var F_OrderLine = $get(sender._element.id);
      var F_OrderLine_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_OrderLine.value = p[1];
      F_OrderLine_Display.innerHTML = e.get_text();
    },
    ACEOrderLine_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('OrderLine','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEOrderLine_Populated: function(sender,e) {
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
    validate_SerialNo: function(sender) {
      var Prefix = sender.id.replace('SerialNo','');
      this.validated_FK_PUR_OrderItemProperty_SerialNo_main = true;
      this.validate_FK_PUR_OrderItemProperty_SerialNo(sender,Prefix);
      },
    validate_FK_PUR_OrderItemProperty_SerialNo: function(o,Prefix) {
      var value = o.id;
      var ItemCategoryID = $get(Prefix + 'ItemCategoryID');
      if(ItemCategoryID.value==''){
        if(this.validated_FK_PUR_OrderItemProperty_SerialNo_main){
          var o_d = $get(Prefix + 'ItemCategoryID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemCategoryID.value ;
      var CategorySpecID = $get(Prefix + 'CategorySpecID');
      if(CategorySpecID.value==''){
        if(this.validated_FK_PUR_OrderItemProperty_SerialNo_main){
          var o_d = $get(Prefix + 'CategorySpecID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CategorySpecID.value ;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PUR_OrderItemProperty_SerialNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_OrderItemProperty_SerialNo(value, this.validated_FK_PUR_OrderItemProperty_SerialNo);
      },
    validated_FK_PUR_OrderItemProperty_SerialNo_main: false,
    validated_FK_PUR_OrderItemProperty_SerialNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purOrderItemProperty.validated_FK_PUR_OrderItemProperty_SerialNo_main){
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
