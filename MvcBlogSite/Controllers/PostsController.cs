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

        public async Task<IActionResult> Index()
        {
            List<Post> posts = await _postServices.GetAllPostsAsync();
            return View(posts);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            List<Post> posts = await _postServices.GetAllPostsAsync();
            Post post = posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
    }
}
