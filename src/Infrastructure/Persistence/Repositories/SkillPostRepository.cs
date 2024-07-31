using Domain.Entities;
using Repositories.Common;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    class SkillPostRepository : AsyncRepository<Skill>, ISkillPostRepository
    {
        public SkillPostRepository(DbContext db) : base(db)
        {
        }
    }
    class SkillGroupRepository : AsyncRepository<SkillGroup>, ISkillGroupRepository
    {
        public SkillGroupRepository(DbContext db) : base(db)
        {
        }
    }
    class SkillTypeRepository : AsyncRepository<SkillType>, ISkillTypeRepository
    {
        public SkillTypeRepository(DbContext db) : base(db)
        {
        }
    }
}
