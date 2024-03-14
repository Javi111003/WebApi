namespace Account.Create
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            //Post("/account/create");
            Get("/account/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            await SendAsync(new Response()
            {
                Message = $"Hello {r.FirstName} {r.LastName} your request has been received !",
                Isover18 = r.Age > 18
            });
        }
    }
}