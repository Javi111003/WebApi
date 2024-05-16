using Account.Create;

namespace Posts.Delete
{
    internal sealed class Request
    {
        public int PostID { get; set; }
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
           RuleFor(x=>x.PostID).NotEmpty().WithMessage("Provide correctly the ID associated to the Post");
           RuleFor(x =>x.PostID).Must(ExistantPost).WithMessage("These post does not exist on Social Network");
        }
        private bool ExistantPost(int PostId)
        {
            using (var db = new UsersContext())
            {
                return db.Posts.Any(x => x.Id == PostId);
            }
        }
    }

    internal sealed class Response
    {
        public string Message => "The Post was deleted succesfully";
    }
}
