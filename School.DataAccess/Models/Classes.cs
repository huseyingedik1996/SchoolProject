using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Models
{
    public class Classes
    {
        public int Id { get; set; }

        public string ClassName { get; set; }
        public List<MajorhasClass> MajorhasClasses { get; set; }
    }
}
