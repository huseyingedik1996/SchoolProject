using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Models
{
    public class AppUser : IdentityUser<int>
    {
        public Students Students { get; set; }
        public int StudentsId { get; set; }
    }
}
