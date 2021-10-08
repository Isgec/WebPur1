<script type="text/javascript"> 
var script_purValueDataTypes = {
    validate_ValueDataTypeID: function(sender) {
      var Prefix = sender.id.replace('ValueDataTypeID','');
      this.validatePK_purValueDataTypes(sender,Prefix);
      },
    validatePK_purValueDataTypes: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgpurValueDataTypes').innerHTML = '';}catch(ex){}
      var ValueDataTypeID = $get(Prefix + 'ValueDataTypeID');
      if(ValueDataTypeID.value=='')
        return true;
      value = value + ',' + ValueDataTypeID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_purValueDataTypes(value, this.validatedPK_purValueDataTypes);
    },
    validatedPK_purValueDataTypes: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVpurValueDataTypes_L_ErrMsgpurValueDataTypes').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
