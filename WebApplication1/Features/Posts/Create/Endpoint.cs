﻿using Account.Create;
using Interaction.Comments.Write;
using Interaction.Likes.DoOrUndo;

namespace Posts.Create
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Post("/posts/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {

            using (var db = new UsersContext())
            {
                var author = db.Users.Find(r.Username);
                var post = new Post() { Author = author.FirstName + " " + author.LastName, AuthorID = author.Username, Caption = r.Caption, Comments = new List<Comment>(), Likes = new List<Like>(), CreatedAt = DateTime.Now ,Title=r.Title};
                db.Posts.Add(post);
                db.Entry(author).Collection(u => u.MyBlog).Load();
                author.MyBlog.Add(post);
                db.SaveChanges();
                await SendAsync(new Response() { Message = $"Congrats {author.FirstName + " " + author.LastName} you have done your first Post on Social Network" });
            }
        }
    }
}