using Microsoft.AspNetCore.Mvc;
using Services.BlogPosts;
using Services.SkillPosts;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillPostService _skillPostService;
        private readonly ISkillGroupService _skillGroupService;
        private readonly ISkillTypeService _skillTypeService;
        public SkillController(ISkillPostService skillPostService,ISkillGroupService skllGroupService, ISkillTypeService skillTypeService) 
        {
            _skillPostService= skillPostService;
            _skillGroupService = skllGroupService;
            _skillTypeService = skillTypeService;
        }
        [Area("admin")]
        public async Task<IActionResult> Index()
        {
            var skillPostDtos = await _skillPostService.GetAllAsync();
            var skillGroupDtos = await _skillGroupService.GetAllAsync();
            var skillTypeDtos = await _skillTypeService.GetAllAsync();

            var skills = skillPostDtos.Select(dto => new Domain.Entities.Skill
            {
                Id = dto.Id,
                Name = dto.Name,
                GroupId = dto.GroupId
            }).ToList();

            var skillGroups = skillGroupDtos.Select(dto => new Domain.Entities.SkillGroup
            {
                Id = dto.Id,
                TypeId = dto.TypeId,
                Name = dto.Name,
                GroupDesc=dto.GroupDesc
            }).ToList();

            var skillTypes = skillTypeDtos.Select(dto => new Domain.Entities.SkillType
            {
                Id = dto.Id,
                Name = dto.Name
            }).ToList();

   
            var skillViewModel = new SkillViewModel
            {
                Skills = skills,
                SkillGroups = skillGroups,
                SkillTypes = skillTypes
            };


            return View(skillViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill(
    string skillName,
    int skillGroupId,
    string skillGroupName,
    int skillGroupTypeId,
    string skillTypeName)
        {
     
            var skillType = await _skillTypeService.GetByIdAsync(skillGroupTypeId);
            if (skillType == null)
            {
            
                var skillTypeDto = new AddSkillTypeRequestDto { Name = skillTypeName };
                await _skillTypeService.AddAsync(skillTypeDto);
            }

      
            var skillGroup = await _skillGroupService.GetByIdAsync(skillGroupId);
            if (skillGroup == null)
            {
      
                var skillGroupDto = new AddSkillGroupRequestDto { Name = skillGroupName, TypeId = skillGroupTypeId };
                await _skillGroupService.AddAsync(skillGroupDto);
            }

            var skillDto = new AddSkillPostRequestDto { Name = skillName, GroupId = skillGroupId };
            await _skillPostService.AddAsync(skillDto);


            return RedirectToAction("Index");
        }
    }
}
