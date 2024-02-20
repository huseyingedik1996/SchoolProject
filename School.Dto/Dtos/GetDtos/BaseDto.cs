using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Dto.Dtos.GetDtos
{
    public class BaseDto
    {
        public string ClassName { get; set; }
        public string MajorName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ParentName { get; set; }
        public string ParentSurname { get; set; }
        public string ParentContact { get; set; }
        public string Address { get; set; }
    }
}
