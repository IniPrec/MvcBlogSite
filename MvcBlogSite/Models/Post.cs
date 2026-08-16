using System.ComponentModel.DataAnnotations;

namespace MvcBlogSite.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required!")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Content is required!")]
        public string? Content { get; set; }

        public DateTime Date { get; set; }

        public DateTime? DateEdited { get; set; }

        [Required(ErrorMessage = "Author is required!")]
        public string? Author { get; set; }
    }
}
