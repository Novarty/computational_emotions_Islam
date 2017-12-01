using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Islam.Models.Responses
{
	public class AnalyzeResponse
	{
		[JsonProperty("items")]
		public IEnumerable<AnalyzeResponseItem> Items { get; set; }
	}

	public class AnalyzeResponseItem
	{
		[JsonProperty("emotion")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Enum Emotion { get; set; }

		[JsonProperty("value")]
		public double Value { get; set; }
	}
}