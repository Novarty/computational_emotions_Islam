using Newtonsoft.Json;

namespace Islam.Models.Requests
{
	public class AnalyzeRequest
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}