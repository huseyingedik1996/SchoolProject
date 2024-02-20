using Microsoft.AspNetCore.Mvc;
using School.Business.Services.ServiceInterfaces;
using School.Dto.Dtos.StudentDto;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost("student/create")]
        public async Task<IActionResult> Create([FromBody] StudentCreateDto createDto)
        {
            var created = await _service.Create(createDto);
            return Ok(created);
        }

        [HttpGet("student/getall")]
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

        [HttpPut("student/update")]
        public async Task<IActionResult> Update(StudentUpdateDto updateDto)
        {
            var updated = _service.UpdateDtos(updateDto);
            return Ok();

        }

        [HttpGet("Students/JoinGetall")]
        public IActionResult GetJoins()
        {
            var datas = _service.GetJoins();
            return Ok(datas);
        }
    }
}
