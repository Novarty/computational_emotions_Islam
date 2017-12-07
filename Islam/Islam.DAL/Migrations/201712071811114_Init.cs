namespace Islam.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                        Priority = c.Double(nullable: false, defaultValue: 1d),
                        Joy = c.Single(nullable: false),
                        Trust = c.Single(nullable: false),
                        Fear = c.Single(nullable: false),
                        Surprise = c.Single(nullable: false),
                        Sadness = c.Single(nullable: false),
                        Disgust = c.Single(nullable: false),
                        Anger = c.Single(nullable: false),
                        Anticipation = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Words");
            DropTable("dbo.Vectors");
        }
    }
}
