using Account.Create;

namespace Interaction.Comments.Delete
{
    internal sealed class Request
    {
        public int PostID { get; set; }

        public int Id { get; set; }
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.PostID).NotEmpty().WithMessage("The PostID can't be empty");
            RuleFor(x => x.PostID).Must(AnExistantPost).WithMessage("The Post does not exist on Social Network");
            RuleFor(x => x.Id).NotEmpty().WithMessage("The CommentID can't be empty");
        }
        private bool AnExistantPost(int Id)
        {
            var db = new UsersContext();
            return db.Posts.Any(x => x.Id == Id);
        }
    }

    internal sealed class Response
    {
        public string Message { get; set; } 
    }
}
