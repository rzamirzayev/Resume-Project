using Microsoft.AspNetCore.Mvc;

namespace ResumeBackendFinal.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
