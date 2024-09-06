using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.BlogPosts;
using Services.SkillPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    class SkillPostService : ISkillPostService
    {
        private readonly ISkillPostRepository skillPostRepository;

        public SkillPostService(ISkillPostRepository skillPostRepository)
        {
            this.skillPostRepository = skillPostRepository;
        }
        public async Task<AddSkillPostResponseDto> AddAsync(AddSkillPostRequestDto model, CancellationToken cancellationToken = default)
        {
            var entity = new Skill { Name=model.Name,GroupId=model.GroupId,SkillLevel=model.SkillLevel,SkillDesc=model.Description};
            await skillPostRepository.AddAsync(entity, cancellationToken);
            await skillPostRepository.SaveAsync(cancellationToken);

            return new AddSkillPostResponseDto { Id = entity.Id, Name=entity.Name, GroupId = entity.GroupId ,SkillLevel= (int)entity.SkillLevel,Description=entity.SkillDesc};
        }

        public async Task<EditSkillPostDto> EditAsync(EditSkillPostDto model, CancellationToken cancellationToken = default)
        {
            var entity = await skillPostRepository.GetAsync(m => m.Id == model.Id, cancellationToken);

            entity.Name = model.Name;
            entity.GroupId = model.GroupId;

            skillPostRepository.Edit(entity);
            await skillPostRepository.SaveAsync(cancellationToken);

            return model;
        }

        public async Task<IEnumerable<SkillPostGetAllDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var data = await skillPostRepository.GetAll()
    .Select(m => new SkillPostGetAllDto
    {
        Id = m.Id,
        Name=m.Name,
        GroupId= m.GroupId,

    })
    .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<EditSkillPostDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var skill = await skillPostRepository.GetAsync(b => b.Id == id, cancellationToken);
            if (skill == null)
            {
                return null;
            }

            return new EditSkillPostDto
            {
                Id = skill.Id,
                Name = skill.Name,
                GroupId = skill.GroupId,
            };
        }
    }

    class SkillGroupService : ISkillGroupService
    {
        private readonly ISkillGroupRepository skillGroupRepository;

        public SkillGroupService(ISkillGroupRepository skillGroupRepository)
        {
            this.skillGroupRepository = skillGroupRepository;
        }
        public async Task<AddSkillGroupResponseDto> AddAsync(AddSkillGroupRequestDto model, CancellationToken cancellationToken = default)
        {
            var entity = new SkillGroup { Name = model.Name ,TypeId=model.TypeId};
            await skillGroupRepository.AddAsync(entity, cancellationToken);
            await skillGroupRepository.SaveAsync(cancellationToken);

            return new AddSkillGroupResponseDto { Id = entity.Id, Name = entity.Name ,TypeId=entity.TypeId};
        }

        public async Task<EditSkillGroupDto> EditAsync(EditSkillGroupDto model, CancellationToken cancellationToken = default)
        {
            var entity = await skillGroupRepository.GetAsync(m => m.Id == model.Id, cancellationToken);

            entity.Name = model.Name;
            entity.TypeId= model.TypeId;

            skillGroupRepository.Edit(entity);
            await skillGroupRepository.SaveAsync(cancellationToken);

            return model;
        }

        public async Task<IEnumerable<SkillGroupGetAllDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var data = await skillGroupRepository.GetAll()
.Select(m => new SkillGroupGetAllDto
{
Id = m.Id,
Name = m.Name,
TypeId=m.TypeId
})
.ToListAsync(cancellationToken);
            return data;
        }

        public async Task<EditSkillGroupDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var skillGroup = await skillGroupRepository.GetAsync(b => b.Id == id, cancellationToken);
            if (skillGroup == null)
            {
                return null;
            }

            return new EditSkillGroupDto
            {
                Id = skillGroup.Id,
                Name = skillGroup.Name,
                TypeId=skillGroup.TypeId
            };
        }
    }

    class SkillTypeService : ISkillTypeService
    {
        private readonly ISkillTypeRepository skillTypeRepository;

        public SkillTypeService(ISkillTypeRepository skillTypeRepository)
        {
            this.skillTypeRepository = skillTypeRepository;
        }
        public async Task<AddSkillTypeResponseDto> AddAsync(AddSkillTypeRequestDto model, CancellationToken cancellationToken = default)
        {
            var entity = new SkillType { Name = model.Name };
            await skillTypeRepository.AddAsync(entity, cancellationToken);
            await skillTypeRepository.SaveAsync(cancellationToken);

            return new AddSkillTypeResponseDto { Id = entity.Id, Name = entity.Name };
        }

        public async Task<EditSkillTypeDto> EditAsync(EditSkillTypeDto model, CancellationToken cancellationToken = default)
        {
            var entity = await skillTypeRepository.GetAsync(m => m.Id == model.Id, cancellationToken);

            entity.Name = model.Name;

            skillTypeRepository.Edit(entity);
            await skillTypeRepository.SaveAsync(cancellationToken);

            return model;
        }

        public async Task<IEnumerable<SkillTypeGetAllDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var data = await skillTypeRepository.GetAll()
.Select(m => new SkillTypeGetAllDto
{
Id = m.Id,
Name = m.Name
})
.ToListAsync(cancellationToken);
            return data;
        }
        public async Task<EditSkillTypeDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var skillType = await skillTypeRepository.GetAsync(b => b.Id == id, cancellationToken);
            if (skillType == null)
            {
                return null;
            }

            return new EditSkillTypeDto
            {
                Id = skillType.Id,
                Name = skillType.Name,
            };
        }
    }


    


}
