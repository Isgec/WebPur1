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
    temp: function() {
    }
    }
</script>
