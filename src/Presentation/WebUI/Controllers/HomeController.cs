using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Contexts;
using Services;
using Services.PersonDetail;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        //private readonly DataContext db;
        private readonly IContactPostService contactPostService;
        private readonly IPersonDetailService personDetailService;

        public HomeController(IContactPostService contactPostService,IPersonDetailService personDetailService) {
            //this.db = db;
            this.contactPostService = contactPostService;
            this.personDetailService = personDetailService;
        }

        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [AllowAnonymous]

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(string fullName,string email,string subject,string content)
        {
            await contactPostService.Add(fullName,email,subject,content);
            return RedirectToAction("Index"); 
        }

        public IActionResult Resume()
        {
            return View();
        }
    }
}
