using Islam.DAL;
using Islam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Islam.Service
{
    public class TextAnalyzator
    {
        private Context context;

        public TextAnalyzator(Context context)
        {
            this.context = context;
        }

        public EmotionalVector Analyze(string text)
        {
            List<string> newWords = new List<string>();
            List<EmotionalVector> oldEmoVectors = new List<EmotionalVector>();
            var words = ParseTextByWord(text);
            EmotionalVector sum = null;
            foreach (var w in words)
            {
                var dbvector = context.Vectors.First(x => x.Word.Equals(w));
                if (dbvector != null)
                {
                    var emovector = new EmotionalVector(dbvector.Word, dbvector.Joy,
                        dbvector.Trust, dbvector.Fear, dbvector.Surprise, dbvector.Sadness,
                        dbvector.Disgust, dbvector.Anger, dbvector.Anticipation);
                    sum = sum != null ? sum + emovector : emovector;
                    oldEmoVectors.Add(emovector);
                }
                else
                {
                    newWords.Add(w);
                }
            }
            foreach (var oev in oldEmoVectors)
            {
                var oldemovector = oev+sum;
                var oldvector = context.Vectors.First(x => x.Word.Equals(oev.VerbalSet));
                oldvector.Joy = oldemovector.EmotionalTone[0].Value;
                oldvector.Trust = oldemovector.EmotionalTone[1].Value;
                oldvector.Fear = oldemovector.EmotionalTone[2].Value;
                oldvector.Surprise = oldemovector.EmotionalTone[3].Value;
                oldvector.Sadness = oldemovector.EmotionalTone[4].Value;
                oldvector.Disgust = oldemovector.EmotionalTone[5].Value;
                oldvector.Anger = oldemovector.EmotionalTone[6].Value;
                oldvector.Anticipation = oldemovector.EmotionalTone[7].Value;
            }
            foreach (var nw in newWords)
            {
                var newvector = new DAL.Entities.Vector();
                newvector.Word = nw;
                newvector.Joy = sum.EmotionalTone[0].Value;
                newvector.Trust = sum.EmotionalTone[1].Value;
                newvector.Fear = sum.EmotionalTone[2].Value;
                newvector.Surprise = sum.EmotionalTone[3].Value;
                newvector.Sadness = sum.EmotionalTone[4].Value;
                newvector.Disgust = sum.EmotionalTone[5].Value;
                newvector.Anger = sum.EmotionalTone[6].Value;
                newvector.Anticipation = sum.EmotionalTone[7].Value;
                context.Vectors.Add(newvector);
            }
            context.SaveChanges();
            return sum;
        }

        private List<string> ParseTextByWord(string text)
        {
            //string text = System.IO.File.ReadAllText(textpath);
            List<string> result = new List<string>();

            var words = text.Split(new char[]{' ', ',',
                    '.', '-', '"', '(', ')', ';', ':', '?', '!'});
            foreach (var word in words)
            {
                if (!result.Contains(word))
                    result.Add(word);
            }
            return result;

            //EmotionalVector sum = null;
            //var vectors = GetVectorsFromExcel(excelPath);
            //foreach (string word in result)
            //{
            //    var vec = vectors.Find(x => x.VerbalSet.Equals(word));
            //    if (vec != null)
            //    {
            //        //Console.WriteLine(word);
            //        sum = sum != null ? sum + vec : vec;
            //    }
            //}

            //Console.WriteLine();
            //float valsum = 0;
            //foreach (var e in sum.EmotionalTone)
            //{
            //    //Console.WriteLine(e.Emotion + " = " + e.Value);
            //    valsum += e.Value;
            //}
            //Console.Write("SUM = " + valsum);
            //Console.ReadKey();
            //Console.WriteLine("Press any key to exit.");
            //System.Console.ReadKey();
        }
    }
}