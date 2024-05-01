using Account.Create;
using Posts.Create;

namespace Posts.Delete
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Delete("/posts/delete");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            using (var db = new UsersContext())
            {
                Post post = db.Posts.Find(r.PostID);
                User author = db.Users.Find(post.AuthorID);
                author.MyBlog.Remove(post);
                db.Posts.Remove(post);
                db.SaveChanges();
            }
                await SendAsync(new Response());
        }
    }
}