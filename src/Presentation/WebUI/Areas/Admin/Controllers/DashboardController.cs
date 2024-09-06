using Microsoft.AspNetCore.Mvc;
using Services.BlogPosts;
using Services.SkillPosts;
using System.Collections.Generic;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {

        private readonly ISkillPostService _skillPostService;
        private readonly ISkillGroupService _skillGroupService;
        private readonly ISkillTypeService _skillTypeService;
        public DashboardController(ISkillPostService skillPostService, ISkillGroupService skllGroupService, ISkillTypeService skillTypeService)
        {
            _skillPostService = skillPostService;
            _skillGroupService = skllGroupService;
            _skillTypeService = skillTypeService;
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
                SkillTypes = skillTypes
            };

            var viewModel = new CombinedSkillViewModel
            {
                SkillViewModel = skillViewModel
            };

            return View(viewModel);
        }


        [HttpGet]
        public async Task<JsonResult> GetSkillsByGroup(int skillGroupId)
        {
            var skills = await _skillPostService.GetAllAsync();
            var filteredSkills = skills
                .Where(s => s.GroupId == skillGroupId)
                .Select(s => new
                {
                    value = s.Id,
                    text = s.Name
                }).ToList();

            return Json(filteredSkills);
        }



        public async Task<IActionResult> AddSkill([FromForm] AddSkillPostRequestDto model)
        {
            await _skillPostService.AddAsync(model);


            return RedirectToAction("Index");
        }






    } 
}
