using Microsoft.AspNetCore.Mvc;

namespace ResumeBackendFinal.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
