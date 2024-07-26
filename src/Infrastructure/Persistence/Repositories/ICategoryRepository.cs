using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface ICategoryRepository<T>
    {
        IQueryable<Category> GetAll();
        Task<Category> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        void AddAsync(Category entry, CancellationToken cancellationToken = default);
        void Edit(Category entry);
        void Remove(Category entry);
        Task<int> SaveAsync();
    }
}
