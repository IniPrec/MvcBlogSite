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

        public async Task AddPostAsync(Post newPost)
        {
            newPost.Id = Guid.NewGuid(); // generate a new unique identifier for the post
            newPost.Date = DateTime.Now; // set the current date and time for the post
            List<Post> posts = await GetAllPostsAsync(); // read the existing posts from the file
            posts.Add(newPost); // add new one to the list
            string json = JsonSerializer.Serialize(posts); // convert the list back to JSON. The opposit of deserialize.
            string path = _configuration["PostsFilePath"]; // get the file path from configuration
            await File.WriteAllTextAsync(path, json); // overwrite the file with the updated JSON
        }

        public async Task UpdatePostAsync(Guid id, Post updatePost)
        {
            List<Post> posts = await GetAllPostsAsync();
            Post existingPost = posts.FirstOrDefault(p => p.Id == id);

            if (existingPost != null)
            {
                existingPost.Title = updatePost.Title;
                existingPost.Content = updatePost.Content;
                existingPost.DateEdited = DateTime.Now;
            }

            string json = JsonSerializer.Serialize(posts);
            string path = _configuration["PostsFilePath"];
            await File.WriteAllTextAsync(path, json);
        }
    }
}
