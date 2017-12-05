using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Islam.Core
{
    public class EmotionValue
    {
        private Emotion emotion;
        public Emotion Emotion { get { return emotion; } }
        private float value;
        public float Value { get { return value; } }

        public EmotionValue(Emotion emotion, float value)
        {
            this.emotion = emotion;
            this.value = (value < 0f) ? 0f : (value > 1f) ? 1f : value;
        }
    }
}

public enum Emotion
{
    JOY,
    TRUST,
    FEAR,
    SURPRISE,
    SADNESS,
    DISGUST,
    ANGER,
    ANTICIPATION
}
