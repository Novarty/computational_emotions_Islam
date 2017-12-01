using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Islam.DAL.Entities
{
	public class EmotionVector
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public float Value { get; set; }

		public Vector Vector { get; set; }

		public Emotion Emotion { get; set; }
	}
}
