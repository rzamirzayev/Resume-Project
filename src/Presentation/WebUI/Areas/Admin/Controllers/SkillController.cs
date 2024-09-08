using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.BlogPosts;
using Services.PortfolioPosts;
using Services.SkillPosts;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SkillController : Controller
    {
        private readonly ISkillPostService skillPostService;
        private readonly ISkillGroupService skillGroupService;
        private readonly ISkillTypeService skillTypeService;
        public SkillController(ISkillPostService skillPostService,ISkillGroupService skllGroupService, ISkillTypeService skillTypeService) 
        {
            this.skillPostService= skillPostService;
            this.skillGroupService = skllGroupService;
            this.skillTypeService = skillTypeService;
        }
        public async Task<IActionResult> Index()
        {
            var skillPostDtos = await skillPostService.GetAllAsync();
            var skillGroupDtos = await skillGroupService.GetAllAsync();
            var skillTypeDtos = await skillTypeService.GetAllAsync();

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


        public async Task<IActionResult> Edit(int id)
        {
            var skillPost = await skillPostService.GetByIdAsync(id);

            if (skillPost == null)
            {
                return NotFound();
            }

            var model = new EditSkillPostDto
            {
                Id = skillPost.Id,
                Name = skillPost.Name,
                SkillDesc = skillPost.SkillDesc,
                SkillLevel = skillPost.SkillLevel
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditSkillPostDto model)
        {

            await skillPostService.EditAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await skillPostService.RemoveAsync(id);
            return RedirectToAction("index");
        }

    }
}
