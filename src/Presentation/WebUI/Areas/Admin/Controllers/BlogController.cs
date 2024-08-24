using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.BlogPosts;
using Services.PortfolioPosts;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogPostService blogPostService;

        public BlogController(IBlogPostService blogPostService) {
            this.blogPostService = blogPostService;
        }
        [Authorize(Policy = "admin.blog.get")]
        public async Task<IActionResult> Index()
        {
            var data = await blogPostService.GetAllAsync();
            return View(data);

        }

        [Authorize(Policy="admin.blog.create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Policy = "admin.blog.create")]


        public async Task<IActionResult> Create([FromForm] AddBlogPostRequestDto model)
        {

            await blogPostService.AddAsync(model);
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "admin.blog.edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var blogPost = await blogPostService.GetByIdAsync(id);

            if (blogPost == null)
            {
                return NotFound(); 
            }

            var model = new EditBlogPostDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Body = blogPost.Body,
                ImagePath = blogPost.ImagePath
            };

            return View(model);
        }
        [Authorize(Policy = "admin.blog.edit")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditBlogPostDto model)
        {

            await blogPostService.EditAsync(model);
            return RedirectToAction("Index");
        }
        [Authorize(Policy= "admin.blog.remove")]

        public async Task<IActionResult> Remove(int id)
        {
            await blogPostService.RemoveAsync(id);
            return Json(new
            {
                error = false,
                message = "OK"
            });
        }

    }
}
