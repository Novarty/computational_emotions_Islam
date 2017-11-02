using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Islam.DAL.Entities
{
	public class WordEmotion
	{
		[Key]
		[Column(Order = 1)]
		public int WordId { get; set; }

		[Key]
		[Column(Order = 2)]
		public int EmotionId { get; set; }

		[ForeignKey("WordId")]
		public virtual Word Word { get; set; }
		
		[ForeignKey("EmotionId")]
		public virtual Emotion Emotion { get; set; }

		public float Value { get; set; }
	}
}
