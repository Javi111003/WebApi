namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentLikes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Likes", "Comment_Id", c => c.Int());
            CreateIndex("dbo.Likes", "Comment_Id");
            AddForeignKey("dbo.Likes", "Comment_Id", "dbo.Comments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "Comment_Id", "dbo.Comments");
            DropIndex("dbo.Likes", new[] { "Comment_Id" });
            DropColumn("dbo.Likes", "Comment_Id");
        }
    }
}
