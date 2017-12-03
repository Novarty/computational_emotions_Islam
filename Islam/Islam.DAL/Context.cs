using Islam.DAL.Entities;
using System.Data.Entity;

namespace Islam.DAL
{
	public class Context : DbContext
    {
		public DbSet<Vector> Vectors { get; set; }

		public DbSet<Word> Words { get; set; }

		public Context() : base("islam")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
		}
	}
}
