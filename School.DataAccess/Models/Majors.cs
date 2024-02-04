using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Models
{
    public class Majors
    {
        public int Id { get; set; }
        public string MajorName { get; set; }
        public List<MajorhasClass> MajorhasClasses { get; set; }
    }
}
