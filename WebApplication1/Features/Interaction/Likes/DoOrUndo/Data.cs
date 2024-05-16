using Account.Create;
using Posts.Create;
using System.ComponentModel.DataAnnotations;

namespace Interaction.Likes.DoOrUndo
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        public DateTime GivedAt { get; set; }
        public string AuthorID { get; set; }
        public int PostId { get; set; }
    }
}
