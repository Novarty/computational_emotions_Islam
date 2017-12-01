namespace Islam.DAL.Migrations
{
    using System;
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
                        Enum = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmotionVectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Single(nullable: false),
                        Emotion_Id = c.Int(),
                        Vector_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emotions", t => t.Emotion_Id)
                .ForeignKey("dbo.Vectors", t => t.Vector_Id)
                .Index(t => t.Emotion_Id)
                .Index(t => t.Vector_Id);
            
            CreateTable(
                "dbo.Vectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmotionVectors", "Vector_Id", "dbo.Vectors");
            DropForeignKey("dbo.EmotionVectors", "Emotion_Id", "dbo.Emotions");
            DropIndex("dbo.EmotionVectors", new[] { "Vector_Id" });
            DropIndex("dbo.EmotionVectors", new[] { "Emotion_Id" });
            DropTable("dbo.Vectors");
            DropTable("dbo.EmotionVectors");
            DropTable("dbo.Emotions");
        }
    }
}
