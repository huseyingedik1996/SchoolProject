using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Business.Services.ServiceInterfaces;
using School.Dto.Dtos.ClassDtos;


namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassesService _service;

        public ClassesController(IClassesService service)
        {
            _service = service;
        }

        [HttpPost("Classes/create")]
        public async Task<IActionResult> Create(ClassCreateDto createDto)
        {
            var created = await _service.Create(createDto);
            return Ok(created);
        }

        [HttpGet("Classes/getall")]
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

        [HttpPut("Classes/update")]
        public async Task<IActionResult> Update(ClassUpdateDto updateDto)
        {
            await _service.UpdateDtos(updateDto);
            return Ok();

        }
    }
}
