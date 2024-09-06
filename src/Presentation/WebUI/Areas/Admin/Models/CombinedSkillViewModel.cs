using Services.SkillPosts;

namespace WebUI.Areas.Admin.Models
{
    public class CombinedSkillViewModel
    {
        public SkillViewModel SkillViewModel { get; set; }

        public AddSkillPostResponseDto skillPostResponseDto { get; set; }
    }
}
