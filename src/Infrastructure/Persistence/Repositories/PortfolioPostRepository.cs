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
    class PortfolioPostRepository : AsyncRepository<PortfolioPost>, IPortfolioPostRepository
    {
        public PortfolioPostRepository(DbContext db) : base(db)
        {
        }
    }
}
