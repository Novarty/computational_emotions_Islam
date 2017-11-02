using Islam.DAL.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Islam.DAL
{
	public class Context : DbContext
    {
		public Context() : base("islam")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new EntityTypeConfiguration<Emotion>());
			modelBuilder.Configurations.Add(new EntityTypeConfiguration<Word>());
			modelBuilder.Configurations.Add(new EntityTypeConfiguration<WordEmotion>());
		}
	}
}
