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
        public async Task<IActionResult> Create([FromForm] AddPortfolioPostRequestDto modell)
        {
            await portfolioPostervice.AddAsync(modell);
            return RedirectToAction("Index");
        }

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
        public async Task<IActionResult> Edit(EditPortfolioPostDto model)
        {

            await portfolioPostervice.EditAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await portfolioPostervice.GetById(id);
            return View(data);

        }
    }
}
