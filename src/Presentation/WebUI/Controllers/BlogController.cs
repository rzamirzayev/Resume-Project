using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.BlogPosts;

namespace WebUI.Controllers
{
    [AllowAnonymous]

    public class BlogController : Controller
    {
        private readonly IBlogPostService blogPostService;
        public BlogController(IBlogPostService blogPostService) {
            this.blogPostService = blogPostService;
        }
        public async Task<ActionResult> Index()
        {
            var data = await blogPostService.GetAllAsync();
            return View(data);
        }
        public async Task<IActionResult> Details(int id)
        {
            var entity=await blogPostService.GetByIdAsync(id);
            return View(entity);
        }
    }
}
