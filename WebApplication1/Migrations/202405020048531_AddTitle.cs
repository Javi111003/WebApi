namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Title");
        }
    }
}
