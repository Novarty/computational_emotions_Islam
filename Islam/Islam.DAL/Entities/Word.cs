using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Islam.DAL.Entities
{
	public class Vector 
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Word { get; set; }	

		public float Joy { get; set; }

		public float Trust { get; set; }

		public float Fear { get; set; }

		public float Surprise { get; set; }

		public float Sadness { get; set; }

		public float Disgust { get; set; }

		public float Anger { get; set; }

		public float Anticipation { get; set; }
	}
}
