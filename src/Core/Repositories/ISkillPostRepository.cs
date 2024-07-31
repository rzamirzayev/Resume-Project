using Domain.Entities;
using Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISkillPostRepository:IAsyncRepository<Skill>
    {
    }
    public interface ISkillGroupRepository : IAsyncRepository<SkillGroup>
    {
    }
    public interface ISkillTypeRepository : IAsyncRepository<SkillType>
    {
    }
}
