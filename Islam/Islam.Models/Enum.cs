using System.Runtime.Serialization;

namespace Islam.Models
{
	public enum Enum : byte
	{
		[EnumMember(Value = "joy")]
		JOY = 0,

		[EnumMember(Value = "trust")]
		TRUST = 1,

		[EnumMember(Value = "fear")]
		FEAR = 2,

		[EnumMember(Value = "surprise")]
		SURPRISE = 3,

		[EnumMember(Value = "sudness")]
		SADNESS = 4,

		[EnumMember(Value = "disgust")]
		DISGUST = 5,

		[EnumMember(Value = "anger")]
		ANGER = 6,

		[EnumMember(Value = "anticipation")]
		ANTICIPATION = 7
	}
}
