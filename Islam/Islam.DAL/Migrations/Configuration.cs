namespace Islam.DAL.Migrations
{
	using Islam.DAL.Entities;
	using Islam.Models;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

			if (context.Emotions.Count() == 0)
			{
				context.Emotions.Add(new Emotion { Enum = Enum.ANGER });
				context.Emotions.Add(new Emotion { Enum = Enum.ANTICIPATION });
				context.Emotions.Add(new Emotion { Enum = Enum.DISGUST });
				context.Emotions.Add(new Emotion { Enum = Enum.FEAR });
				context.Emotions.Add(new Emotion { Enum = Enum.JOY });
				context.Emotions.Add(new Emotion { Enum = Enum.SADNESS });
				context.Emotions.Add(new Emotion { Enum = Enum.SURPRISE });
				context.Emotions.Add(new Emotion { Enum = Enum.TRUST });
				context.SaveChanges();
			}
        }
    }
}
