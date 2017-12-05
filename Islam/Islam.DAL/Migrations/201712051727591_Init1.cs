namespace Islam.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Vectors");
            AddColumn("dbo.Vectors", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Vectors", "Word", c => c.String());
            AddPrimaryKey("dbo.Vectors", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Vectors");
            AlterColumn("dbo.Vectors", "Word", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Vectors", "Id");
            AddPrimaryKey("dbo.Vectors", "Word");
        }
    }
}
