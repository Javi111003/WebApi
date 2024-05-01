using Account.Create;
using System.ComponentModel.DataAnnotations;

namespace Posts.Create
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Author { get; set; }

        public string AuthorID { get; set; }
        public string Caption { get; set; }

        public DateTime CreatedAt { get; set; }

        public  ICollection<Like> Likes { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
    public class Like
    {
        [Key]
        public int Id { get; set; }
        public DateTime GivedAt { get; set; }

        public User Author { get; set; }
        public int AuthorID { get; set; }
        public Post Received { get; set; }
        public int PostId { get; set; }
    }
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public User Author { get; set; }
        public int AuthorID { get; set; }
        public string Content { get; set; }
        public Post PostAssociated { get; set; }
        public int PostId { get; set; }

    }
}
