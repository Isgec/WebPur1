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
    temp: function() {
    }
    }
</script>
