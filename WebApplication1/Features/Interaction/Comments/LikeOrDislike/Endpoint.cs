using Account.Create;
using Interaction.Likes.DoOrUndo;
using Posts.Create;
using System.Data.Entity;

namespace LikeOrDislike
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Post("/interaction/comments/likeordislike");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var response = new Response();
            var db = new UsersContext();
            var post = db.Posts.Find(r.PostId);
            db.Entry(post).Collection(p => p.Comments).Load();
            if (AnExistantComment(r.CommentId, r.PostId))
            {
                    var comment = post.Comments.First(c=>c.AuthorID==r.Username);
                    db.Entry(comment).Collection(c => c.Likes).Load();
                    if (comment.Likes.Any(l => l.AuthorID == r.Username))
                    {
                        var like = comment.Likes.First(l => l.AuthorID == r.Username);
                        comment.Likes.Remove(like);
                        db.Entry(like).State= EntityState.Deleted;
                        db.Entry(comment).State = EntityState.Modified;
                        db.Entry(post).State = EntityState.Modified;
                        response.Message = "Dislike</3";
                    }
                    else
                    {
                        var newlike= new Like() { AuthorID = r.Username , GivedAt = DateTime.Now , PostId = post.Id };
                        comment.Likes.Add(newlike);
                        db.Entry(newlike).State = EntityState.Added;
                        db.Entry(comment).State = EntityState.Modified;
                        db.Entry(post).State = EntityState.Modified;
                        response.Message = "like<3";
                    }
                db.SaveChanges();

            }
            else
            {
                response.Message = "The comment does not exist on these post";
            }
            await SendAsync(response);
        }
        private bool AnExistantComment(int Id, int PostID)
        {
            var db = new UsersContext();
            var post = db.Posts.Find(PostID);
            db.Entry(post).Collection(p => p.Comments).Load();
            return post.Comments.Any(c => c.Id == Id);
        }
    }
}