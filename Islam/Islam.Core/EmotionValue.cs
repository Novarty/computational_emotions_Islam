using Islam.Models;

namespace Islam.Core
{
	public class EmotionValue
	{
		private Emotion emotion;
		public Emotion Emotion { get { return emotion; } }
		private float value;
		public float Value { get { return value; } }
        public void SetValue(float value)
        {
            this.value = value;
        }
        public EmotionValue(Emotion emotion, float value)
		{
			this.emotion = emotion;
			this.value = (value < 0f) ? 0f : (value > 1f) ? 1f : value;
		}
	}
}
