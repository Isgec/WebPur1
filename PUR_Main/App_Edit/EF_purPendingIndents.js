<script type="text/javascript"> 
var script_purPendingIndents = {
    ACEIndentNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('IndentNo','');
      var F_IndentNo = $get(sender._element.id);
      var F_IndentNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_IndentNo.value = p[0];
      F_IndentNo_Display.innerHTML = e.get_text();
    },
    ACEIndentNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('IndentNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEIndentNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    temp: function() {
    }
    }
</script>
