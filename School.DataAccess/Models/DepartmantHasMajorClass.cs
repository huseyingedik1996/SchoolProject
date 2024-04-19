using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Models
{
    public class DepartmantHasMajorClass
    {
        public int Id { get; set; }
        public int DepartmantId { get; set; }
        public int MajorHasClassId { get; set; }

        public DepartmantName DepartmantName { get; set; }
        public MajorhasClass MajorHasClass { get; set; }
    }
}
