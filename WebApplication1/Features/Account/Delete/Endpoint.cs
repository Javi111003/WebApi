﻿using Account.Create;
using Posts.Create;

namespace Account.Delete
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Delete("/account/delete");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            using (var db = new UsersContext())
            {
                var author = db.Users.Find(r.Username);
                var response = new Response();
                db.Entry(author).Collection(u => u.MyBlog).Load();
                if (r.Password == author.Passsword)
                {
                    foreach(var post in author.MyBlog)
                    {
                        db.Posts.Remove(post);  
                    }
                    db.Users.Remove(author);
                    db.SaveChanges();
                    response.Message = $"The account under the name {r.Username} was deleted succesfully from Social Network";
                }
                else
                {
                    response.Message = $"The password is wrong , try'll to another one for can be delete the account :{r.Username}";
                }
                await SendAsync(response);
            }
        }
    }
}