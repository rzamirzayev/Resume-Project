using Domain.Entities;

namespace WebUI.Areas.Admin.Models
{
    public class SkillViewModel
    {
            public IEnumerable<Skill> Skills { get; set; }
            public IEnumerable<SkillGroup> SkillGroups { get; set; }
            public IEnumerable<SkillType> SkillTypes { get; set; }
        
    }
}
