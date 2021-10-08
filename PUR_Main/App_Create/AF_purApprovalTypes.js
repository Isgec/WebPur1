<script type="text/javascript"> 
var script_purApprovalTypes = {
    validate_AprTypeID: function(sender) {
      var Prefix = sender.id.replace('AprTypeID','');
      this.validatePK_purApprovalTypes(sender,Prefix);
      },
    validatePK_purApprovalTypes: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgpurApprovalTypes').innerHTML = '';}catch(ex){}
      var AprTypeID = $get(Prefix + 'AprTypeID');
      if(AprTypeID.value=='')
        return true;
      value = value + ',' + AprTypeID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_purApprovalTypes(value, this.validatedPK_purApprovalTypes);
    },
    validatedPK_purApprovalTypes: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVpurApprovalTypes_L_ErrMsgpurApprovalTypes').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
