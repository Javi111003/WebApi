using Account.Create;
using System.Runtime.CompilerServices;

namespace LikeOrDislike
{
    internal sealed class Request
    {
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public string Username { get; set; }
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username can not be empty")
                .Must(AnExistantUser).WithMessage("These user does not exist on Social Network");
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("Post ID can not be empty")
                .Must(AnExistantPost).WithMessage("These post does not exist on Social Network");
            RuleFor(x => x.CommentId)
                .NotEmpty().WithMessage("Comment ID can not be empty");

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
        public string Message { get; set; }
    }
}
