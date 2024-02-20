using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Dto.Dtos.GetDtos
{
    public class StudentJoins
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNumber { get; set; }
        public int StudentNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age { get; set; }
        public string Contact { get; set; }
        public DateTime RegisterDate { get; set; }

        public ParentJoins ParentJoins { get; set; }
        public BaseDto BaseDto { get; set; }
    }
}
