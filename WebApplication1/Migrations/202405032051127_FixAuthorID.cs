namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAuthorID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Author_Username", "dbo.Users");
            DropForeignKey("dbo.Likes", "Author_Username", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "Author_Username" });
            DropIndex("dbo.Likes", new[] { "Author_Username" });
            AlterColumn("dbo.Comments", "AuthorID", c => c.String());
            AlterColumn("dbo.Likes", "AuthorID", c => c.String());
            DropColumn("dbo.Comments", "Author_Username");
            DropColumn("dbo.Likes", "Author_Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Likes", "Author_Username", c => c.String(maxLength: 128));
            AddColumn("dbo.Comments", "Author_Username", c => c.String(maxLength: 128));
            AlterColumn("dbo.Likes", "AuthorID", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "AuthorID", c => c.Int(nullable: false));
            CreateIndex("dbo.Likes", "Author_Username");
            CreateIndex("dbo.Comments", "Author_Username");
            AddForeignKey("dbo.Likes", "Author_Username", "dbo.Users", "Username");
            AddForeignKey("dbo.Comments", "Author_Username", "dbo.Users", "Username");
        }
    }
}
