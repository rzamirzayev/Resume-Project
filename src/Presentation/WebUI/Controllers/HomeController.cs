using Domain.Entities;
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
        public async Task<IActionResult> Index()
        {
            var data = await personDetailService.GetAllAsync();
            return View(data);
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
