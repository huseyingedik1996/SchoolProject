using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Models
{
    public class Parents
    {
        public int Id { get; set; }
        public string ParentName { get; set; }
        public string ParentSurname { get; set; }
        public string ParentContact { get; set; }
        public string Address { get; set; }
        public Students Students { get; set; }
        public int StudentId { get; set; }
        
    }
}
