using System.Runtime.Serialization;

namespace Islam.Models
{
	public enum Emotion : byte
	{
		[EnumMember(Value = "joy")]
		JOY = 1,

		[EnumMember(Value = "trust")]
		TRUST = 2,

		[EnumMember(Value = "fear")]
		FEAR = 3,

		[EnumMember(Value = "surprise")]
		SURPRISE = 4,

		[EnumMember(Value = "sadness")]
		SADNESS = 5,

		[EnumMember(Value = "disgust")]
		DISGUST = 6,

		[EnumMember(Value = "anger")]
		ANGER = 7,

		[EnumMember(Value = "anticipation")]
		ANTICIPATION = 8
	}
}
