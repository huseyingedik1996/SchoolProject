using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Business.Services.ServiceInterfaces;
using School.Dto.Dtos.ParentsDtos;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _service;

        public ParentController(IParentService parentService)
        {
            _service = parentService;
        }

        [HttpPost("Parent/create")]
        public async Task<IActionResult> Create(ParentCreateDto createDto)
        {
            var created = await _service.Create(createDto);
            return Ok(created);
        }

        [HttpGet("Parent/getall")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAll();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var list = await _service.GetById(id);
            return Ok(list);
        }


        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.Remove(id);
            return Ok(deleted);
        }

        [HttpPut("Parent/update")]
        public async Task<IActionResult> Update(ParentUpdateDto updateDto)
        {
            var updated = _service.UpdateDtos(updateDto);
            return Ok();

        }
    }
}
