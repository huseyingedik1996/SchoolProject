using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Business.Services.ServiceInterfaces;
using School.Dto.Dtos.ClassDtos;
using School.Dto.Dtos.DepartmantName;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmanNameController : ControllerBase
    {
        private readonly IDepartmanNameService _service;

        public DepartmanNameController(IDepartmanNameService service)
        {
            _service = service;
        }

        [HttpPost("DepartmanName/create")]
        public async Task<IActionResult> Create(CreateDepartmantName createDto)
        {
            var created = await _service.Create(createDto);
            return Ok(created);
        }

        [HttpGet("DepartmanName/getall")]
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

        [HttpPut("DepartmantName/update")]
        public async Task<IActionResult> Update(UpdateDepartmantName updateDto)
        {
            await _service.UpdateDtos(updateDto);
            return Ok();

        }
    }
}
