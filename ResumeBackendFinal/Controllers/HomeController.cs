using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ResumeBackendFinal.Models.Contexts;
using ResumeBackendFinal.Models.Entities;

namespace ResumeBackendFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext db;

        public HomeController(DataContext db) {
            this.db = db;
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
            var post = new ContactPost
            {
                FullName = fullName,
                Email = email,
                Subject = subject,
                Content = content,
                CreatedAt= DateTime.Now
            };
            db.ContactPosts.Add(post);
            db.SaveChanges();
            return Json(new
            {
                error=false,
                message="Muraciet qebul olundu."
            });
        }

        public IActionResult Resume()
        {
            return View();
        }
    }
}
