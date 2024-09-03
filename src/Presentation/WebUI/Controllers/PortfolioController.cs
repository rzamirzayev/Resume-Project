using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.PortfolioPosts;

namespace WebUI.Controllers
{
    [AllowAnonymous]

    public class PortfolioController : Controller
    {
        private readonly IPortfolioPostervice portfolioPostervice;

        public PortfolioController(IPortfolioPostervice portfolioPostervice) {
            this.portfolioPostervice = portfolioPostervice;
        }
        public async Task<IActionResult> Index()
        {
            var data = await portfolioPostervice.GetAllAsync();
            return View(data);
        }
    }
}
