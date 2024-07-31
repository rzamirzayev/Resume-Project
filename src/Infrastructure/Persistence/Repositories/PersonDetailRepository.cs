using Repositories.Common;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    class PersonDetailRepository : AsyncRepository<Person>, IPersonDetailRepository
    {
        public PersonDetailRepository(DbContext db) : base(db)
        {
        }
    }
}
