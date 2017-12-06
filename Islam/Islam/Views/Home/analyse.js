$(document).ready(function() {
	$(document).on('click', '#analyse_btn', function(event) {
		event.preventDefault();

		var textarea_val = $('#text').val();
		var analyse_url = 'http://localhost:8081//analyzer/analyze';

		jQuery.post(analyse_url, { text : textarea_val})
            .done(function(response) {
            	var resp_list = response['items'];
				$.each( resp_list, function() {							
  					var elem_id = "#"+this.emotion;
  					elem_value = $(elem_id).find('.value')[0];  					
  					$(elem_value).html(this.value);
  				});

            });
        });

});