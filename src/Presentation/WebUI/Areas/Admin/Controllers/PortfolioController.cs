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
        public async Task<IActionResult> Index()
        {
            var data = await portfolioPostervice.GetAllAsync();
            return View(data);

        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(AddPortfolioPostResponseDto modell)
        {
            await portfolioPostervice.AddAsync(modell);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var portfolioPost = await portfolioPostervice.GetByIdAsync(id);

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
        public async Task<IActionResult> Edit(EditPortfolioPostDto model)
        {
            if (!ModelState.IsValid)
                return View();
            await portfolioPostervice.EditAsync(model);
            return RedirectToAction("Index");
        }
    }
}
