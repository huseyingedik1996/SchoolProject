using FluentValidation;
using School.Dto.Dtos.StudentDepartmanDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.StudentsDepartmanValidations
{
    public class UpdateStudentsDepartmanValidation : AbstractValidator<UpdateStudentsDepartmant>
    {
        public UpdateStudentsDepartmanValidation() {

            RuleFor(x => x.DepartmantHasMajorClassId).NotEmpty();
            RuleFor(x => x.StudentId).NotEmpty();
        }
    }
}
