using FluentValidation;
using FluentValidation.Validators;
using School.Dto.Dtos.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.StudentValidations
{
    public class StudentCreateValidations : AbstractValidator<StudentCreateDto>
    {
        public StudentCreateValidations()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("This area can not be null.").Length(1, 45);
            RuleFor(x => x.Surname).NotEmpty().WithMessage("This area can not be null.").Length(1, 45);
            RuleFor(x => x.Address).NotEmpty().WithMessage("This area can not be null.").Length(10, 350);
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage("This area can not be null.");
            RuleFor(x => x.City).NotEmpty().WithMessage("This area can not be null.").Length(1, 25);
            RuleFor(x => x.Contact).NotEmpty().WithMessage("This area can not be null.").Length(1, 15);
        }
    }
}
