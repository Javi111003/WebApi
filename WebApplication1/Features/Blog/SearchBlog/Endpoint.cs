using Account.Create;
using MongoDB.Driver.Linq;
using Posts.Create;

namespace Blog.Search
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Post("/blog/searchblog");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var db = new UsersContext();
            User user = db.Users.Find(r.Username);
            db.Entry(user).Collection(u => u.MyBlog).Load();
            await SendAsync(new Response() { 
            Message=$"The posts associated to {user.Username} :"
            ,Blog = user.MyBlog
            });
        }
    }
}