using Account.Create;
using Posts.Create;

namespace Blog.Search
{
    internal sealed class Request
    {
        public string Username { get; set; }
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Insert the username correctly")
                .Must(AnExistantUser).WithMessage("That user does not exists on the Social Network");
        }
        private bool AnExistantUser(string username) 
        {
            var db = new UsersContext();
            return db.Users.Any(u=> u.Username == username);
        }
    }

    internal sealed class Response
    {
        public string Message {  get; set; }
        public ICollection<Post> Blog {  get; set; }

    }
}
