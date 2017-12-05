namespace Islam.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddedPriority : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vectors", "Priority", c => c.Double(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vectors", "Priority");
        }
    }
}
