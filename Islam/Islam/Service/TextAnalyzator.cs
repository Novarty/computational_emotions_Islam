﻿using Islam.DAL;
using Islam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Islam.DAL.Entities;

namespace Islam.Service
{
	public class TextAnalyzator
	{
		private Context context;

		public TextAnalyzator(Context context) => this.context = context;

		public EmotionalVector Analyze(string text)
		{
			List<string> newWords = new List<string>();
			List<EmotionalVector> oldEmoVectors = new List<EmotionalVector>();
			List<string> words = ParseTextByWord(text);
			EmotionalVector sum = null;
			foreach (var w in words)
			{
				DAL.Entities.Vector dbvector = context.Vectors.FirstOrDefault(x => x.Word == w);
				if (dbvector != null)
				{
					EmotionalVector emovector = new EmotionalVector(dbvector.Word, dbvector.Joy,
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
			foreach (EmotionalVector oev in oldEmoVectors)
			{
				EmotionalVector oldemovector = oev + sum;
				DAL.Entities.Vector oldvector = context.Vectors.First(x => x.Word.Equals(oev.VerbalSet));
				oldvector.Joy = oldemovector.EmotionalTone[0].Value;
				oldvector.Trust = oldemovector.EmotionalTone[1].Value;
				oldvector.Fear = oldemovector.EmotionalTone[2].Value;
				oldvector.Surprise = oldemovector.EmotionalTone[3].Value;
				oldvector.Sadness = oldemovector.EmotionalTone[4].Value;
				oldvector.Disgust = oldemovector.EmotionalTone[5].Value;
				oldvector.Anger = oldemovector.EmotionalTone[6].Value;
				oldvector.Anticipation = oldemovector.EmotionalTone[7].Value;
			}
			foreach (string nw in newWords)
			{
				Vector newvector = new Vector
				{
					Word = nw,
					Joy = sum.EmotionalTone[0].Value,
					Trust = sum.EmotionalTone[1].Value,
					Fear = sum.EmotionalTone[2].Value,
					Surprise = sum.EmotionalTone[3].Value,
					Sadness = sum.EmotionalTone[4].Value,
					Disgust = sum.EmotionalTone[5].Value,
					Anger = sum.EmotionalTone[6].Value,
					Anticipation = sum.EmotionalTone[7].Value
				};
				context.Vectors.Add(newvector);
			}
			context.SaveChanges();
			return sum;
		}

		private List<string> ParseTextByWord(string text)
		{
			List<string> result = new List<string>();

			string[] words = text.Split(new char[]{' ', ',',
					'.', '-', '"', '(', ')', ';', ':', '?', '!'});
			foreach (var word in words)
			{
				if (!result.Contains(word))
					result.Add(word);
			}
			return result;
		}
	}
}