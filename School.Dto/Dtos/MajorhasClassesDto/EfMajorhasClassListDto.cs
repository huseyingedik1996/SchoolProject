using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Dto.Dtos.MajorhasClassesDto
{
    public class EfMajorhasClassListDto
    {
        public int Id { get; set; }
        public int ClassesId { get; set; }
        public int MajorsId { get; set; }
        public string MajorName { get; set; }
        public string ClassName { get; set; }
    }
}
