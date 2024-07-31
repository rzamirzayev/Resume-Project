using Microsoft.AspNetCore.Mvc;
using Services.PersonDetail;

namespace WebUI.ViewComponents
{
    public class PersonDetailViewComponent:ViewComponent
    {
        private readonly IPersonDetailService personDetailService;

        public PersonDetailViewComponent(IPersonDetailService personDetailService) 
        {
            this.personDetailService=personDetailService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response=await personDetailService.GetAllAsync();
            return View(response);
        }
    }
}
