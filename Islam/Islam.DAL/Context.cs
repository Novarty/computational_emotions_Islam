using Islam.DAL.Entities;
using System.Data.Entity;

namespace Islam.DAL
{
	public class Context : DbContext
    {
		public DbSet<Emotion> Emotions { get; set; }

		public DbSet<Vector> Vectors { get; set; }

		public DbSet<EmotionVector> EmotionVectors { get; set; }

		public Context() : base("islam")
		{
		}
	}
}
