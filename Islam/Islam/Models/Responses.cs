using Newtonsoft.Json;
using System.Collections.Generic;

namespace Islam.Models
{
	public class AnalyzeResponse
	{
		[JsonProperty("items")]
		public IEnumerable<AnalyzeResponseItem> Items { get; set; }
	}

	public class AnalyzeResponseItem
	{
		[JsonProperty("emotion")]
		public string Emotion { get; set; }

		[JsonProperty("value")]
		public float Value { get; set; }
	}
}