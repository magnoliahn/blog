namespace blog.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public int PostLikes { get; set; }
        public List<Comments> Comments { get; set; } = new List<Comments>();
    }
}
