<script type="text/javascript"> 
var script_purTaxRates = {
    ACETaxCode_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TaxCode','');
      var F_TaxCode = $get(sender._element.id);
      var F_TaxCode_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TaxCode.value = p[0];
      F_TaxCode_Display.innerHTML = e.get_text();
    },
    ACETaxCode_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TaxCode','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETaxCode_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_TaxCode: function(sender) {
      var Prefix = sender.id.replace('TaxCode','');
      this.validated_FK_PUR_TaxRates_Code_main = true;
      this.validate_FK_PUR_TaxRates_Code(sender,Prefix);
      },
    validate_FK_PUR_TaxRates_Code: function(o,Prefix) {
      var value = o.id;
      var TaxCode = $get(Prefix + 'TaxCode');
      if(TaxCode.value==''){
        if(this.validated_FK_PUR_TaxRates_Code_main){
          var o_d = $get(Prefix + 'TaxCode' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TaxCode.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PUR_TaxRates_Code(value, this.validated_FK_PUR_TaxRates_Code);
      },
    validated_FK_PUR_TaxRates_Code_main: false,
    validated_FK_PUR_TaxRates_Code: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_purTaxRates.validated_FK_PUR_TaxRates_Code_main){
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
