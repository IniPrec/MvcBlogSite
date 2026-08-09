using Microsoft.AspNetCore.Mvc;
using MvcBlogSite.Services;
using MvcBlogSite.Models;

namespace MvcBlogSite.Controllers
{
    public class PostsController : Controller
    {
        private readonly PostServices _postServices;

        public PostsController(PostServices postServices)
        {
            _postServices = postServices;
        }

        public IActionResult Index()
        {
            List<Post> posts = _postServices.GetAllPosts();
            return View(posts);
        }

        public IActionResult Details(Guid id)
        {
            List<Post> posts = _postServices.GetAllPosts();
            Post post = posts.FirstOrDefault(p => p.Id == id); // LINQ. Searches the list for the first post whose ID matches the provided ID. If no match is found, it returns null.

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
    }
}
