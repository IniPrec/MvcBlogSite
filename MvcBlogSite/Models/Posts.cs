namespace MvcBlogSite.Models
{
    public class Posts
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Author { get; set; }
    }
}
