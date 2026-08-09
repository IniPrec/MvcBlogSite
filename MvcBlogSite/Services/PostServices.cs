using MvcBlogSite.Models;
using System.Text.Json;
using System.IO;

namespace MvcBlogSite.Services
{
    public class PostServices
    {
        public List<Post> GetAllPosts()
        {
            string path = "Data/posts.json";
            string json = File.ReadAllText(path);
            List<Post> posts = JsonSerializer.Deserialize<List<Post>>(json);
            return posts;
        }
    }
}
