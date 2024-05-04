using Account.Create;

namespace Posts.Search
{
    internal sealed class Request
    {
        public int PostId { get; set; }
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.PostId).NotEmpty().WithMessage("Please specify the ID of the Post what are you looking for");
            RuleFor(x => x.PostId).Must(AnExistantPost).WithMessage("The Post that you specifyed does not exist on Social Network");
        }
        private bool AnExistantPost(int postId)
        {
            var db = new UsersContext(); 
            return db.Posts.Any(x=>x.Id.Equals(postId));
        }
    }

    internal sealed class Response
    {
        public string Message => "The following title can be what are you looking for :";
        public string Title { get; set; }
        public string Body { get; set; }
        public string WritedBy { get; set; }  

        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }

    }
}
