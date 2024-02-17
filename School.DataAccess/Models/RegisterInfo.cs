using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Models
{
    public class RegisterInfo
    {
        public int Id {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Students Student { get; set; }

        public int StudentId { get; set; }
    }
}
