using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Models
{
    public class StudenthasMajorClass
    {
        public int Id { get; set; }
        public int StudentsId { get; set; }
        public int MajorhasClassesId { get; set; }

        public MajorhasClass MajorhasClasses { get; set; }
        public Students Students { get; set; }
    }
}
