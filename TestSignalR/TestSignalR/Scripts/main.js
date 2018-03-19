    var timeDiff = 0;
    
     $(function ()
      {
        var hub = $.connection.timeHub;
        
        hub.client.onConnected = function (ServTimeMs)
        {
            timeDiff = new Date() - ServTimeMs ;
            timer = setTimeout(digitalWatch, 1000);
        }
        
        hub.client.changeTime = function(ServTimeMs)
        {
            timeDiff =  new Date() - ServTimeMs ;
        }
        
        $.connection.hub.start().done( function()
        {
            hub.server.connect();
           
        })
         
          hub.client.errorMessage = function (message)
        {
            alert(message);
        }

            $('#btn-change').on('click', function()
            {
          hub.server.changeServHours($('#input-hours').val());          
            })
       })
    
  var watch = function  () {
            var date = new Date(new Date() -timeDiff);
            var hours = date.getHours();
            var minutes = date.getMinutes();
            var seconds = date.getSeconds();
            if (hours < 10) hours = "0" + hours;
            if (minutes < 10) minutes = "0" + minutes;
            if (seconds < 10) seconds = "0" + seconds;
            $('#time').text(hours + ":" + minutes + ":" + seconds);
     }

function digitalWatch () {
    setInterval( watch, 1000);
}
                

      