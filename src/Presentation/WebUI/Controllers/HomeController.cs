using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistence.Contexts;
using Services;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext db;
        private readonly IContactPostService contactPostService;

        public HomeController(DataContext db,IContactPostService contactPostService) {
            this.db = db;
            this.contactPostService = contactPostService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(string fullName,string email,string subject,string content)
        {
            var responseMessage=contactPostService.Add(fullName,email,subject,content);
            return Json(new
            {
                error = false,
                message = responseMessage
            }); ;
        }

        public IActionResult Resume()
        {
            return View();
        }
    }
}
