using Newtonsoft.Json;

namespace Islam.Models
{
	public class AnalyzeRequest
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}

	public class AddToDbRequest
	{

	}
}