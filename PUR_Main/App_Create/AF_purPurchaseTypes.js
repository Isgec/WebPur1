<script type="text/javascript"> 
var script_purPurchaseTypes = {
    validate_PurchaseTypeID: function(sender) {
      var Prefix = sender.id.replace('PurchaseTypeID','');
      this.validatePK_purPurchaseTypes(sender,Prefix);
      },
    validatePK_purPurchaseTypes: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgpurPurchaseTypes').innerHTML = '';}catch(ex){}
      var PurchaseTypeID = $get(Prefix + 'PurchaseTypeID');
      if(PurchaseTypeID.value=='')
        return true;
      value = value + ',' + PurchaseTypeID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_purPurchaseTypes(value, this.validatedPK_purPurchaseTypes);
    },
    validatedPK_purPurchaseTypes: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVpurPurchaseTypes_L_ErrMsgpurPurchaseTypes').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
