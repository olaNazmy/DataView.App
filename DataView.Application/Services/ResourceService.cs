using DataView.Application.DTOs;
using DataView.Domain.Entities;
using DataView.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataView.Application.Services
{
    public class ResourceService 
    {
        private readonly IResourceRepository _repository;
        public ResourceService(IResourceRepository repository)
        {
            _repository = repository;
        }

        // 
        public async Task<IEnumerable<ResourceDto>> GetPagedAsync(int page)
        {
            var result = await _repository.GetPagedAsync(page, 10);
            return result.Select(r => new ResourceDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Url = r.Url
            });
        }

        //
        public async Task AddAsync(ResourceDto dto)
        {
            var entity = new Resource
            {
                Name = dto.Name,
                Description = dto.Description,
                Url = dto.Url
            };
            await _repository.AddAsync(entity);
        }

        //
        public async Task UpdateAsync(ResourceDto dto)
        {
            var entity = new Resource
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Url = dto.Url
            };
            await _repository.UpdateAsync(entity);
        }

        //
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

    }
}
