using MvcBlogSite.Models;
using System.Text.Json;
using System.IO;

namespace MvcBlogSite.Services
{
    public class PostServices
    {
        private readonly IConfiguration _configuration;

        public PostServices(IConfiguration configuration) // constructor-injection pattern
        {
            _configuration = configuration;
        }

        public async Task<List<Post>> GetAllPostsAsync() // an async method that returns a value must wrap it Task<T>. Task represents work that will complete eventually.
        {
            string path = _configuration["PostsFilePath"];
            string json = await File.ReadAllTextAsync(path); // await pauses this method whithout blocking the whole thread until the file read finishes.

            List<Post> posts = JsonSerializer.Deserialize<List<Post>>(json);
            return posts;
        }
    }
}
