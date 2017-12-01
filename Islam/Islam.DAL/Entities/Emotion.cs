using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Islam.DAL.Entities
{
	public class Emotion
	{
		public Emotion()
		{
			EmotionVectors = new HashSet<EmotionVector>();
		}

		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public Models.Enum Enum { get; set; }

		public ICollection<EmotionVector> EmotionVectors { get; set; }
	}
}
