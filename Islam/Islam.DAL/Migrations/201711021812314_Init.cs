namespace Islam.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emotions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WordEmotions",
                c => new
                    {
                        WordId = c.Int(nullable: false),
                        EmotionId = c.Int(nullable: false),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.WordId, t.EmotionId })
                .ForeignKey("dbo.Emotions", t => t.EmotionId, cascadeDelete: true)
                .ForeignKey("dbo.Words", t => t.WordId, cascadeDelete: true)
                .Index(t => t.WordId)
                .Index(t => t.EmotionId);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WordEmotions", "WordId", "dbo.Words");
            DropForeignKey("dbo.WordEmotions", "EmotionId", "dbo.Emotions");
            DropIndex("dbo.WordEmotions", new[] { "EmotionId" });
            DropIndex("dbo.WordEmotions", new[] { "WordId" });
            DropTable("dbo.Words");
            DropTable("dbo.WordEmotions");
            DropTable("dbo.Emotions");
        }
    }
}
