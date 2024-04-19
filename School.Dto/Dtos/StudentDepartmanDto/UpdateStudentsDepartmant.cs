using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Dto.Dtos.StudentDepartmanDto
{
    public class UpdateStudentsDepartmant
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DepartmantHasMajorClassId { get; set; }
    }
}
