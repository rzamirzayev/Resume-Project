using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.PersonDetail;
using Services.SkillPosts;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {

        private readonly ISkillPostService _skillPostService;
        private readonly ISkillGroupService _skillGroupService;
        private readonly ISkillTypeService _skillTypeService;
        private readonly IPersonDetailService personDetailService;
        public DashboardController(ISkillPostService skillPostService, ISkillGroupService skllGroupService, ISkillTypeService skillTypeService,IPersonDetailService personDetailService)
        {
            _skillPostService = skillPostService;
            _skillGroupService = skllGroupService;
            _skillTypeService = skillTypeService;
            this.personDetailService = personDetailService;
        }

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
                Name = dto.Name
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
                SkillTypes = skillTypes,
               
            };

            
            var person = await personDetailService.GetByIdAsync(3);
            var model = new EditPersonDetailDto
            {
                Id = person.Id,
                FullName = person.FullName,
                Experience = person.Experience,
                DateOfBirth = person.DateOfBirth,
                Location = person.Location,
                Fax = person.Fax,
                Bio = person.Bio,
                Website = person.Website,
            };
            var viewModel = new CombinedSkillViewModel
            {
                SkillViewModel = skillViewModel,
                EditPersonDetailDto =model
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> PersonDetail(CombinedSkillViewModel model)
        {

            await personDetailService.EditAsync(model.EditPersonDetailDto);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<JsonResult> GetSkillsByGroup(int skillGroupId)
        {
            var skills = new List<string>(); 
            if (skillGroupId == 2) 
            {
                skills = new List<string> { "HTML", "CSS", "SASS", "JavaScript" };
            }
            if (skillGroupId == 1)
            {
                skills = new List<string> { "C#", "Java", "C++" };
            }

            return Json(skills);
        }

        [Authorize("admin.skills.add")]
        [HttpPost]
        public async Task<IActionResult> AddSkill([FromForm] CombinedSkillViewModel model)
        {
            await _skillPostService.AddAsync(model.SkillPostRequestDto);


            return RedirectToAction("Index");
        }






    } 
}
