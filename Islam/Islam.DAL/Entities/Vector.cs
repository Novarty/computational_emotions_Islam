using Islam.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Islam.DAL.Entities
{
	public class Vector
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public Emotion Emotion { get; set; }

		public float Value { get; set; }

		public Word Word { get; set; }
	}
}
