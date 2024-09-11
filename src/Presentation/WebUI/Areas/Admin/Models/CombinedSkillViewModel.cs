using Services.PersonDetail;
using Services.SkillPosts;

namespace WebUI.Areas.Admin.Models
{
    public class CombinedSkillViewModel
    {
        public SkillViewModel SkillViewModel { get; set; }

        public AddSkillPostRequestDto SkillPostRequestDto { get; set; }
        public EditPersonDetailDto EditPersonDetailDto { get; set;}
        
    }
}
