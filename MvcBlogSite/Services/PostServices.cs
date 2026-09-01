using MvcBlogSite.Models;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using Dapper;

namespace MvcBlogSite.Services
{
    public class PostServices
    {
        private readonly string _connectionString;

        public PostServices(IConfiguration configuration) // constructor-injection pattern
        {
            _connectionString = configuration.GetConnectionString("BlogDb");
        }

        public async Task<List<Post>> GetAllPostsAsync() // an async method that returns a value must wrap it Task<T>. Task represents work that will complete eventually.
        {
            using (SqlConnection connection = new SqlConnection(_connectionString)) // opens a connection to the database using the connection string
            {
                string query = "SELECT * FROM Posts"; // SQL query to select all posts
                var posts = await connection.QueryAsync<Post>(query);
                return posts.ToList(); // convert the result to a list and return it
            }
        }

        public async Task AddPostAsync(Post newPost)
        {
            newPost.Id = Guid.NewGuid(); // generate a new unique identifier for the post
            newPost.Date = DateTime.Now; // set the current date and time for the post

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Posts (Id, Title, Content, Author, Date, DateEdited) VALUES (@Id, @Title, @Content, @Author, @Date, @DateEdited)";

                await connection.ExecuteAsync(query, newPost); // execute the query with the new post as a parameter
            }
        }

        public async Task UpdatePostAsync(Guid id, Post updatePost)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Posts SET Title = @Title, Content = @Content, DateEdited = @DateEdited WHERE Id = @Id";

                await connection.ExecuteAsync(query, new
                {
                    Id = id,
                    Title = updatePost.Title,
                    Content = updatePost.Content,
                    DateEdited = DateTime.Now
                });
            }
        }

        public async Task DeletePostAsync(Guid id)
        {
           using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Posts WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
