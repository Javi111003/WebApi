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
            await SendAsync(new LoginResponse() 
            {
                Message = "You're inside!"
            });
        }
    }
}