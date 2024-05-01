namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifingUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "AuthorID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "AuthorID", c => c.Int(nullable: false));
        }
    }
}
