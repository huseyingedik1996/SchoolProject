using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Models
{
    public class StudentsDepartmant
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DepartmantHasMajorClassId { get; set; }

        public Students Student { get; set; }
        public DepartmantHasMajorClass DepartmantHasMajorClass { get; set; }
    }
}
