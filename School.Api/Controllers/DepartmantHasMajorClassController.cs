﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Business.Services.ServiceInterfaces;
using School.Dto.Dtos.DepartmantHasMajorClass;
using School.Dto.Dtos.DepartmantName;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmantHasMajorClassController : ControllerBase
    {
        private readonly IDepartmanHasClassMajorService _service;

        public DepartmantHasMajorClassController(IDepartmanHasClassMajorService service)
        {
            _service = service;
        }

        [HttpPost("DepartmanHasMajorclass/create")]
        public async Task<IActionResult> Create(CreateDepartmanHasMajorClass createDto)
        {
            var created = await _service.Create(createDto);
            return Ok(created);
        }

        [HttpGet("DepartmanHasMajorclass/getall")]
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

        [HttpPut("DepartmanHasMajorclass/update")]
        public async Task<IActionResult> Update(UpdateDepartmanHasMajorClass updateDto)
        {
            await _service.UpdateDtos(updateDto);
            return Ok();

        }
    }
}
