using Microsoft.AspNetCore.Mvc;
using Services.SkillPosts;

namespace WebUI.ViewComponents
{
    public class SkillGroupDetailViewComponent:ViewComponent
    {
        private readonly ISkillGroupService skillGroupService;

        public SkillGroupDetailViewComponent(ISkillGroupService skillGroupService)
        {
            this.skillGroupService = skillGroupService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await skillGroupService.GetAllAsync();
            return View(response);
        }
    }
}
