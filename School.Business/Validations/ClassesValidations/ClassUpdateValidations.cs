using FluentValidation;
using School.Dto.Dtos.ClassDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.ClassesValidations
{
    public class ClassUpdateValidations : AbstractValidator<ClassUpdateDto>
    {
        public ClassUpdateValidations()
        {
            RuleFor(x => x.ClassName).NotEmpty().WithMessage("This area can not be null");
        }
    }
}
