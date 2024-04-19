using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Dto.Dtos.DepartmantHasMajorClass
{
    public class CreateDepartmanHasMajorClass
    {
        public int Id { get; set; }
        public int DepartmantNameId { get; set; }
        public int MajorHasClassId { get; set; }

    }
}
