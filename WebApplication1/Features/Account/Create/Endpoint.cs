
namespace Account.Create
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Get("/account/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            using (var db = new UsersContext())
            {
                var user = new User() { FirstName = r.FirstName, LastName = r.LastName, Age = r.Age, Email = r.Email, Passsword = r.Password, Username = r.UserName };
                db.Users.Add(user);
                db.SaveChanges();
            }           
                await SendAsync(new Response()
                {
                    Message = $"Hello {r.FirstName} {r.LastName}, your account has been created succesfully!",
                    Isover18 = r.Age > 18
                });
        }
    }
}