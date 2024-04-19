using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Models
{
    public class Students 
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
        public DateTime LastUpdate { get; set; }
        public DateTime RegisterDate { get; set; }


        public AppUser AppUser { get; set; }
        public List<StudenthasMajorClass> StudenthasMajorClasses { get; set; }
        public List<StudentsDepartmant> StudentsDepartmant { get; set; }

    }
}
