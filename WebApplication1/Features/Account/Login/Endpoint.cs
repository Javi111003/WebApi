using Account.Create;

namespace Accont.Login
{
    internal sealed class LoginEndpoint : Endpoint<LoginRequest, LoginResponse, Mapper>
    {
        public override void Configure()
        {
            Get("/account/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(LoginRequest r, CancellationToken c)
        {
            var db = new UsersContext();
            var user = db.Users.Find(r.UserName);
            if (user.Passsword == r.Password)
            {
                await SendAsync(new LoginResponse()
                {
                    Message = "You're inside dude !"
                });
            }
            else
            {
                await SendAsync(new LoginResponse()
                {
                    Message = "The password is wrong,try'll again"
                });
            }
        }
    }
}