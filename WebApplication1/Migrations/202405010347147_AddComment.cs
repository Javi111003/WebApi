namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        AuthorID = c.Int(nullable: false),
                        Content = c.String(),
                        PostId = c.Int(nullable: false),
                        Author_Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Username)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.Author_Username);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GivedAt = c.DateTime(nullable: false),
                        AuthorID = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                        Author_Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Username)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.Author_Username);
            
            CreateTable(
                "dbo.UserUsers",
                c => new
                    {
                        User_Username = c.String(nullable: false, maxLength: 128),
                        User_Username1 = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.User_Username, t.User_Username1 })
                .ForeignKey("dbo.Users", t => t.User_Username)
                .ForeignKey("dbo.Users", t => t.User_Username1)
                .Index(t => t.User_Username)
                .Index(t => t.User_Username1);
            
            AddColumn("dbo.Posts", "User_Username", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "User_Username");
            AddForeignKey("dbo.Posts", "User_Username", "dbo.Users", "Username");
            DropColumn("dbo.Posts", "Likes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Likes", c => c.Int(nullable: false));
            DropForeignKey("dbo.Likes", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Likes", "Author_Username", "dbo.Users");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "Author_Username", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_Username", "dbo.Users");
            DropForeignKey("dbo.UserUsers", "User_Username1", "dbo.Users");
            DropForeignKey("dbo.UserUsers", "User_Username", "dbo.Users");
            DropIndex("dbo.UserUsers", new[] { "User_Username1" });
            DropIndex("dbo.UserUsers", new[] { "User_Username" });
            DropIndex("dbo.Likes", new[] { "Author_Username" });
            DropIndex("dbo.Likes", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "Author_Username" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "User_Username" });
            DropColumn("dbo.Posts", "User_Username");
            DropTable("dbo.UserUsers");
            DropTable("dbo.Likes");
            DropTable("dbo.Comments");
        }
    }
}
