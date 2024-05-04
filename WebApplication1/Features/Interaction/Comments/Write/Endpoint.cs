using Account.Create;

namespace Interaction.Comments.Write
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Post("/interaction/comments/write");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var db = new UsersContext();
            Comment com = new Comment() { AuthorID = r.AuthorID, Content = r.Body, CreatedAt = DateTime.Now, PostId=r.PostID };
            var post = db.Posts.Find(r.PostID);
            db.Entry(post).Collection(p => p.Comments).Load();
            post.Comments.Add(com);
            db.SaveChanges();
            await SendAsync(new Response());
        }
    }
}