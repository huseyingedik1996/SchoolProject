using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Context
{
    public class SchoolContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<AppRole> AppRoles { get; set; }
        public virtual DbSet<Parents> Parents { get; set; }
        public virtual DbSet<Majors> Majors { get; set; }
        public virtual DbSet<MajorhasClass> MajorClasses { get; set; }
        public virtual DbSet<StudenthasMajorClass> StudenthasMajorClasses { get; set; }


        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) 
        {
            
        }
    }
}
