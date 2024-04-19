using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Models
{
    public class DepartmantName
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DepartmantHasMajorClass> HasMajorClass { get; set; }
    }
}
