using Account.Create;
using Posts.Create;
using System.Data.Entity;

namespace Interaction.Comments.Delete
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Delete("/interaction/comments/delete");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var db = new UsersContext();
            var response = new Response();
            var post = db.Posts.Find(r.PostID);
            db.Entry(post).Collection(p => p.Comments).Load();
            if (AnExistantComment(r.Id, r.PostID))
            {
                var comment = post.Comments.FirstOrDefault(c => c.Id==r.Id);
                post.Comments.Remove(comment);
                db.Entry(post).State = EntityState.Modified;
                db.Entry(comment).State = EntityState.Deleted;
                response.Message = "The comment was deleted succesfully";
            }
            else 
            {
                response.Message = "You don't have any comment on this Post";
            }
            db.SaveChanges();
            await SendAsync(response);
        }
        private bool AnExistantComment(int Id,int PostID)
        {
            var db = new UsersContext();
            var post = db.Posts.Find(PostID);
            db.Entry(post).Collection(p => p.Comments).Load();
            return post.Comments.Any(c => c.Id == Id);
        }
    }
}