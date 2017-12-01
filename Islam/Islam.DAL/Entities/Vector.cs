using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Islam.DAL.Entities
{
	public class Vector 
	{
		public Vector()
		{
			EmotionVectors = new HashSet<EmotionVector>();
		}

		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Word { get; set; }	

		public ICollection<EmotionVector> EmotionVectors { get; set; }
	}
}
