using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.DataAccess.Context;
using School.DataAccess.Models;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddRoleController : ControllerBase
    {
        private readonly SchoolContext _context;

        public AddRoleController(SchoolContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(AppRole appRole)
        {
            _context.AppRoles.Add(appRole);
            _context.SaveChanges();
            return Ok();
        }
    }
}
