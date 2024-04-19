using FluentValidation;
using School.Dto.Dtos.StudentDepartmanDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.StudentsDepartmanValidations
{
    public class CreateStudentsDepartmanValidation : AbstractValidator<CreateStudentsDepartmant>

    {
        public CreateStudentsDepartmanValidation() {

            RuleFor(x => x.DepartmantHasMajorClassId).NotEmpty();
            
        }
    }
}
