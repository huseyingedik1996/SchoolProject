using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Business.Services.ServiceInterfaces;
using School.Dto.Dtos.MajorDtos;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : ControllerBase
    {
        private readonly IMajorService _service;

        public MajorsController(IMajorService service)
        {
            _service = service;
        }

        [HttpPost("Major/create")]
        public async Task<IActionResult> Create(MajorCreateDto createDto)
        {
            var created = await _service.Create(createDto);
            return Ok(created);
        }

        [HttpGet("Major/getall")]
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

        [HttpPut("Major/update")]
        public async Task<IActionResult> Update(MajorUpdateDto updateDto)
        {
            var updated = _service.UpdateDtos(updateDto);
            return Ok();

        }
    }
}
