using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Models
{
    public class MajorhasClass
    {
        public int Id { get; set; }
        public int ClassesId { get; set; }
        public int MajorsId { get; set; }


        public Classes Classes { get; set; }
        public Majors Majors { get; set; }
        public List<StudenthasMajorClass> StudenthasMajorClasses { get; set; }
        public List<DepartmantHasMajorClass> HasMajorClass { get; set; }
    }
}
