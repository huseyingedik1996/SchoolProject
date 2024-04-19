using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Business.Services.ServiceInterfaces;
using School.Dto.Dtos.DepartmantHasMajorClass;
using School.Dto.Dtos.StudentDepartmanDto;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsDepartmant : ControllerBase
    {
        private readonly IStudentsDepartmanService _service;

        public StudentsDepartmant(IStudentsDepartmanService service)
        {
            _service = service;
        }

        [HttpPost("StudenetsDepartmant/create")]
        public async Task<IActionResult> Create(CreateStudentsDepartmant createDto)
        {
            var created = await _service.Create(createDto);
            return Ok(created);
        }

        [HttpGet("StudenetsDepartmant/getall")]
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

        [HttpPut("StudenetsDepartmant/update")]
        public async Task<IActionResult> Update(UpdateStudentsDepartmant updateDto)
        {
            await _service.UpdateDtos(updateDto);
            return Ok();

        }
    }
}
