using Account.Create;

namespace Posts.Search
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Post("/posts/search");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            
            var db = new UsersContext(); 
            var post = db.Posts.Find(r.PostId);
            db.Entry(post).Collection(p => p.Likes).Load();
            db.Entry(post).Collection(p => p.Comments).Load();
            foreach(var comment in post.Comments) 
            {
                db.Entry(comment).Collection(c => c.Likes).Load();
            }
            await SendAsync(new Response() { Body=post.Caption , Title=post.Title ,Likes=post.Likes.Count() , CreatedAt=post.CreatedAt , WritedBy=post.AuthorID , Comments=post.Comments });
        }
    }
}