using Islam.DAL.Entities;
using System.Data.Entity;

namespace Islam.DAL
{
	public class Context : DbContext
    {
		public DbSet<Emotion> Emotions { get; set; }
		public DbSet<Word> Words { get; set; }
		public DbSet<WordEmotion> WordEmotions { get; set; }

		public Context() : base("islam")
		{
		}
	}
}
