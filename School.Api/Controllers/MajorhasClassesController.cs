using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Business.Services.ServiceInterfaces;
using School.Dto.Dtos.MajorhasClassesDto;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorhasClassesController : ControllerBase
    {
        private readonly IMajorhasClassService _service;

        public MajorhasClassesController(IMajorhasClassService service)
        {
            _service = service;
        }

        [HttpPost("MajorhasClasses/create")]
        public async Task<IActionResult> Create(MajorhasClassesCreateDto createDto)
        {
            var created = await _service.Create(createDto);
            return Ok(created);
        }

        [HttpGet("MajorhasClasses/getall")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAll();
            return Ok(list);
        }

        [HttpGet("MajorhasClasses/getallef")]
        public async Task<IActionResult> GetAllEf()
        {
            var list = await _service.GetAllEf();
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

        [HttpPut("MajorhasClasses/update")]
        public async Task<IActionResult> Update(MajorhasClassesUpdateDto updateDto)
        {
            var updated = _service.UpdateDtos(updateDto);
            return Ok();

        }
    }
}
