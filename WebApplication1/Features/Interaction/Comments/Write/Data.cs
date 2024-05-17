using Interaction.Likes.DoOrUndo;
using System.ComponentModel.DataAnnotations;


namespace Interaction.Comments.Write
{

    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AuthorID { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
