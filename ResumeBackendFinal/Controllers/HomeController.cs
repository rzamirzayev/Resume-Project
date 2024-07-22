using Microsoft.AspNetCore.Mvc;

namespace ResumeBackendFinal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
