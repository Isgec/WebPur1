<script type="text/javascript"> 
var script_purItemSpecValues = {
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
    validate_SpecID: function(sender) {
      var Prefix = sender.id.replace('SpecID','');
      this.validated_FK_PUR_ItemSpecValues_SpecID_main = true;
      this.validate_FK_PUR_ItemSpecValues_SpecID(sender,Prefix);
      },
    validate_FK_PUR_ItemSpecValues_SpecID: function(o,Prefix) {
      var value = o.id;
      var SpecID = $get(Prefix + 'SpecID');
      if(SpecID.value==''){
        if(this.validated_FK_PUR_ItemSpecValues_SpecID_main){
          var o_d = $get(Prefix + 'SpecID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SpecID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_ItemSpecValues_SpecID(value, this.validated_FK_PUR_ItemSpecValues_SpecID);
      },
    validated_FK_PUR_ItemSpecValues_SpecID_main: false,
    validated_FK_PUR_ItemSpecValues_SpecID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purItemSpecValues.validated_FK_PUR_ItemSpecValues_SpecID_main){
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
