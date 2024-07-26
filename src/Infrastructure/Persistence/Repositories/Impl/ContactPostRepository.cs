using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Impl
{
     class ContactPostRepository : AsyncRepository<ContactPost>, IContactPostRepository
    {
        public ContactPostRepository(DbContext db) : base(db)
        {
        }

    }
};
