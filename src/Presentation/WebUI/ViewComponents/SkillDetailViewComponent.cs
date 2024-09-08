using Microsoft.AspNetCore.Mvc;
using Services.SkillPosts;

namespace WebUI.ViewComponents
{
    public class SkillDetailViewComponent:ViewComponent
    {
            private readonly ISkillPostService skillPostService;

            public SkillDetailViewComponent(ISkillPostService skillPostService)
            {
                this.skillPostService = skillPostService;
            }
            public async Task<IViewComponentResult> InvokeAsync()
            {
                var response = await skillPostService.GetAllAsync();
                return View(response);
            }
        
    }
}
