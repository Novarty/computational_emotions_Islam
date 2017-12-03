namespace Islam.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class Initailize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Emotion = c.Byte(nullable: false),
                        Value = c.Single(nullable: false),
                        Word_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Words", t => t.Word_Id)
                .Index(t => t.Word_Id);
            
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
            DropForeignKey("dbo.Vectors", "Word_Id", "dbo.Words");
            DropIndex("dbo.Vectors", new[] { "Word_Id" });
            DropTable("dbo.Words");
            DropTable("dbo.Vectors");
        }
    }
}
