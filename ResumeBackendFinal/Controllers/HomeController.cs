using Microsoft.AspNetCore.Mvc;

namespace ResumeBackendFinal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(string s)
        {
            return View();
        }

        public IActionResult Resume()
        {
            return View();
        }
    }
}
