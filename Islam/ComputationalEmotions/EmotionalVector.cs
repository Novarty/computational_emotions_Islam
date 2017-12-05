using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Islam.Core
{
    public class EmotionalVector
    {
        private string verbalSet;
        public string VerbalSet { get { return verbalSet; } }
        private EmotionValue[] emotionalTone;
        public EmotionValue[] EmotionalTone { get { return emotionalTone; } }
        private EmotionalVector[] summands;
        public EmotionalVector[] Summands { get { return summands; } }

        public EmotionalVector(string verbalSet, float joyValue, float trustValue, float fearValue,
            float surpriseValue, float sadnessValue, float disgustValue, float angerValue, float anticipationValue)
        {
            this.verbalSet = verbalSet;
            var sum = joyValue + trustValue + fearValue + surpriseValue + sadnessValue + disgustValue + angerValue + anticipationValue;
            if (sum > 1f)
            {
                joyValue /= sum;
                trustValue /= sum;
                fearValue /= sum;
                surpriseValue /= sum;
                sadnessValue /= sum;
                disgustValue /= sum;
                angerValue /= sum;
                anticipationValue /= sum;
            }
            emotionalTone = new EmotionValue[] {
                new EmotionValue(Emotion.JOY, joyValue),
                new EmotionValue(Emotion.TRUST, trustValue),
                new EmotionValue(Emotion.FEAR, fearValue),
                new EmotionValue(Emotion.SURPRISE, surpriseValue),
                new EmotionValue(Emotion.SADNESS, sadnessValue),
                new EmotionValue(Emotion.DISGUST, disgustValue),
                new EmotionValue(Emotion.ANGER, angerValue),
                new EmotionValue(Emotion.ANTICIPATION, anticipationValue)
            };
        }

        public static EmotionalVector operator+ (EmotionalVector a, EmotionalVector b)
        {
            var newVec = new EmotionalVector(
                a.verbalSet + " " + b.verbalSet,
                (a.emotionalTone[0].Value + b.emotionalTone[0].Value)/2,
                (a.emotionalTone[1].Value + b.emotionalTone[1].Value) / 2,
                (a.emotionalTone[2].Value + b.emotionalTone[2].Value)/ 2,
                (a.emotionalTone[3].Value + b.emotionalTone[3].Value)/ 2,
                (a.emotionalTone[4].Value + b.emotionalTone[4].Value)/ 2,
                (a.emotionalTone[5].Value + b.emotionalTone[5].Value)/ 2,
                (a.emotionalTone[6].Value + b.emotionalTone[6].Value)/ 2,
                (a.emotionalTone[7].Value + b.emotionalTone[7].Value)/ 2);
            newVec.summands = new EmotionalVector[] {a,b};
            return newVec;
        }
    }
}
