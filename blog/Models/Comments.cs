using System.ComponentModel.DataAnnotations;

namespace blog.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public int CommentLikes { get; set; }
        public int PostId { get; set; }
    }
}
