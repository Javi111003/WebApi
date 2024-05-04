using Account.Create;
namespace Posts.Create
{
    internal sealed class Request
    {
        public string Title { get; set; }
        public string Caption { get; set; }
        public string Username { get; set; }
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Caption).MaximumLength(256).WithMessage("The caption is too long , try'll to rewrited with length more less or equal to 256 chars");
            RuleFor(x => x.Username).Must(ExistantUser).WithMessage($"The username do not exist on the Social Network ");
        }
        private bool ExistantUser(string username)
        {
            var context = new UsersContext();
            return context.Users.Any(x => x.Username == username);
        }
    }

    internal sealed class Response
    {
        public string Message { get; set; }
    }
}
