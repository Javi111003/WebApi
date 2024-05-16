using Account.Create;
using System.Data.Entity;

namespace Interaction.Likes.DoOrUndo
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Post("/interaction/likes/doorundo");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            Response response=new Response();
            var db = new UsersContext();
            var post = db.Posts.Find(r.PostID);
            db.Entry(post).Collection(p => p.Likes).Load();
            if (post.Likes.Any(c => c.AuthorID == r.AuthorID))
            {
                var like = post.Likes.FirstOrDefault(c => c.AuthorID==r.AuthorID);
                post.Likes.Remove(like);
                db.Entry(post).State = EntityState.Modified;
                db.Entry(like).State = EntityState.Deleted;
                response.Message = "Dislike </3";
            }
            else
            {
                var newLike = new Like() { AuthorID= r.AuthorID , PostId=r.PostID , GivedAt=DateTime.Now };
                post.Likes.Add(newLike);
                response.Message = "Like <3";
            }
            db.SaveChanges();
            await SendAsync(response);
        }
    }
}