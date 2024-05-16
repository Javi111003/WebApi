using Account.Create;

namespace Interaction.Comments.Write
{
    internal sealed class Request
    {
        public string Body { get; set; }
        public int PostID  { get; set; }
        public string AuthorID { get; set; }
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Body).NotEmpty().WithMessage("The comment can't be empty");
            RuleFor(x => x.Body).MaximumLength(256).WithMessage("The comment can't be more long than 256 chars");
            RuleFor(x => x.PostID).NotEmpty().WithMessage("The PostID can't be empty");
            RuleFor(x => x.PostID).Must(AnExistantPost).WithMessage("The Post does not exist on Social Network");
            RuleFor(x => x.AuthorID).NotEmpty().WithMessage("The AuthorID can't be empty");
            RuleFor(x => x.AuthorID).Must(AnExistantUser).WithMessage("The AuthorID does not exist on Social Network");
        }
        private bool AnExistantUser(string Id)
        {
            var db = new UsersContext();
            return db.Users.Any(x => x.Username == Id);
        }
        private bool AnExistantPost(int Id)
        {
            var db = new UsersContext();
            return db.Posts.Any(x => x.Id == Id);
        }
    }

    internal sealed class Response
    {
        public string Message => "Your comment has been published succesfully";
    }
}
