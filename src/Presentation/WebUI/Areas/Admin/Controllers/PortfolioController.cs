using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.BlogPosts;
using Services.PortfolioPosts;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioPostervice portfolioPostervice;

        public PortfolioController(IPortfolioPostervice portfolioPostervice)
        {
            this.portfolioPostervice = portfolioPostervice;
        }
        [Authorize(Policy = "admin.portfolio.get")]

        public async Task<IActionResult> Index()
        {
            var data = await portfolioPostervice.GetAllAsync();
            return View(data);

        }
        [Authorize(Policy = "admin.portfolio.create")]

        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "admin.portfolio.create")]

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AddPortfolioPostRequestDto modell)
        {
            await portfolioPostervice.AddAsync(modell);
            return RedirectToAction("Index");
        }
        [Authorize(Policy = "admin.portfolio.edit")]

        public async Task<IActionResult> Edit(int id)
        {
            var portfolioPost = await portfolioPostervice.GetById(id);

            if (portfolioPost == null)
            {
                return NotFound();
            }

            var model = new EditPortfolioPostDto
            {
                Id = portfolioPost.Id,
                Title = portfolioPost.Title,
                Desc = portfolioPost.Desc,
                ImagePath = portfolioPost.ImagePath
            };

            return View(model);
        }
        [HttpPost]
        [Authorize(Policy = "admin.portfolio.edit")]

        public async Task<IActionResult> Edit(EditPortfolioPostDto model)
        {

            await portfolioPostervice.EditAsync(model);
            return RedirectToAction("Index");
        }
        [Authorize(Policy = "admin.portfolio.detail")]

        public async Task<IActionResult> Details(int id)
        {
            var data = await portfolioPostervice.GetById(id);
            return View(data);

        }
        [Authorize(Policy = "admin.portfolio.remove")]

        public async Task<IActionResult> Remove (int id)
        {
            await portfolioPostervice.RemoveAsync(id); 
            var result = new { Success = true, Message = "Silindi" };
            return new JsonResult(result);
        }
    }
}
