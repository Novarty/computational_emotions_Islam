$(document).ready(function() {
	$(document).on('click', '#analyse_btn', function(event) {
		event.preventDefault();

		var text = $('#text').value();
		var analyse_url = '/analyzer/analyze';

		$.ajax({
			type : 'POST',
			url: analyse_url,
			data: JSON.stringify(text),
			contentType: "application/json",
			success: function(response) {
				var resp_list = responce['items'];
				$.each( resp_list, function( key, item) {
  					var item_id = item.id;
  					var value = item.value;
  					var elem = $("#"+item_id);
  					$(elem).find('.value')[0].html(value);
				});

		})

	
}) 