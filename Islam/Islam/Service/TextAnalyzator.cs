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
        //private List<string> newWords = new List<string>();
        //public string[] NewWords { get { return newWords.ToArray(); } }

        public TextAnalyzator(Context context)
        {
            this.context = context;
        }

        public void Analyze(string text)
        {
            var words = ParseTextByWord(text);
            EmotionalVector sum = null;
            foreach (var w in words)
            {
                var dbw = context.Vectors.Find(w);
                //var vec = new EmotionalVector(dbw.Word.Value)
                if (dbw!=null)
                {
                    sum = sum != null ? sum + vec : vec;
                }
                else
                {
                    context.Vectors.Add(new DAL.Entities.Vector());
                }
            }
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