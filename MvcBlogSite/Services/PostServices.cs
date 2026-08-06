using MvcBlogSite.Models;
using System.Text.Json;
using System.IO;

namespace MvcBlogSite.Services
{
    public class PostServices
    {
        public List<Posts> GetAllPosts()
        {
            string path = "Data/posts.json";
            string json = File.ReadAllText(path);
            List<Posts> posts = JsonSerializer.Deserialize<Posts>>(json);
            return posts;
        }
    }
}
