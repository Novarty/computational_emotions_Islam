$(document).ready(function () {
	$("#sbm").click(function (event) {
		event.preventDefault();

		var text = $("#text").val();
		var analyse_url = "/analyzer/analyze?request=" + text;

		$.ajax({
			type: "GET",
			url: analyse_url,
			data: JSON.stringify(text),
			contentType: "application/json",
			success: function (response) {
				var resp_list = responce['items'];
				$.each(resp_list, function (key, item) {
					var item_id = item.id;
					var value = item.value;
					var elem = $("#" + item_id);
					$(elem).find('.value')[0].html(value);
				});

			}
		});
	})
})