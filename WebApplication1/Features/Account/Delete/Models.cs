using Account.Create;

namespace Account.Delete
{
    internal sealed class Request
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x=>x.Username).Must(ExistantUser).WithMessage("These account already do not exist on Social network ");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("The password is too short , the minimun length is 8 chars , try'll again");
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
