namespace Islam.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vectors",
                c => new
                    {
                        Word = c.String(nullable: false, maxLength: 128),
                        Joy = c.Single(nullable: false),
                        Trust = c.Single(nullable: false),
                        Fear = c.Single(nullable: false),
                        Surprise = c.Single(nullable: false),
                        Sadness = c.Single(nullable: false),
                        Disgust = c.Single(nullable: false),
                        Anger = c.Single(nullable: false),
                        Anticipation = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Word);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vectors");
        }
    }
}
