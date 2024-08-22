using Microsoft.AspNetCore.Mvc;
using Services.SkillPosts;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {



        public IActionResult Index()
        {
            return View();
        }




    }
}
