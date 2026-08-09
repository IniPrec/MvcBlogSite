using Microsoft.AspNetCore.Mvc;
using MvcBlogSite.Services;
using MvcBlogSite.Models;

namespace MvcBlogSite.Controllers
{
    public class PostController : Controller
    {
        private readonly PostServices _postServices;

        public PostController(PostServices postServices)
        {
            _postServices = postServices;
        }

        public IActionResult Index()
        {
            List<Post> post = _postServices.GetAllPosts();
            return View();
        }
    }
}
