using DataView.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataView.Domain.Interfaces
{
    public interface IResourceRepository
    {
        Task<IEnumerable<Resource>> GetPagedAsync(int page, int pageSize);

        //Task<Resource?> GetByIdAsync(int id);
        Task AddAsync(Resource resource);
        Task UpdateAsync(Resource resource);
        Task DeleteAsync(int id);
    }
}
