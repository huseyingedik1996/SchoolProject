using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Dto.Dtos.StudenthasMajorClassesDto
{
    public class StudentAllJoinListDto
    {
        public int Id { get; set; }
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


        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public string ParentSurname { get; set; }
        public string ParentContact { get; set; }
        public string ParentAddress { get; set; }
        public int StudentId { get; set; }

        public int ClassId { get; set; }

        public string ClassName { get; set; }

    }
}
