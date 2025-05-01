using DataView.Application.DTOs;
using DataView.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataView.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly ResourceService _service;
        public ResourcesController(ResourceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] int page = 1)
        {
            var data = await _service.GetPagedAsync(page);
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ResourceDto dto)
        {
            await _service.AddAsync(dto);
            return Ok("Resource added successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(ResourceDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok("Resource updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Resource deleted successfully.");
        }

    }
}

