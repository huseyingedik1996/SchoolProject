using FluentValidation;
using School.Dto.Dtos.StudenthasMajorClassesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.StudenthasMajorClassValidations
{
    public class StudenthasMajorClassUpdateValidations : AbstractValidator<StudenthasMajorClassesUpdateDto>
    {
        public StudenthasMajorClassUpdateValidations()
        {
            RuleFor(x => x.StudentsId).NotEmpty();
            RuleFor(x => x.MajorhasClassesId).NotEmpty();
        }
    }
}
