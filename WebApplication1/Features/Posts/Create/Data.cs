using Account.Create;
using System.ComponentModel.DataAnnotations;
using Interaction.Likes.DoOrUndo;
using Interaction.Comments.Write;

namespace Posts.Create
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }   

        public string Author { get; set; }

        public string AuthorID { get; set; }
        public string Caption { get; set; }

        public DateTime CreatedAt { get; set; }

        public  ICollection<Like> Likes { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
 
}
