using FluentValidation;
using School.Dto.Dtos.MajorhasClassesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.MajorhasClassesValidations
{
    public class MajorhasClassCreateValidations : AbstractValidator<MajorhasClassesCreateDto>
    {
        public MajorhasClassCreateValidations()
        {
            RuleFor(x => x.ClassesId).NotEmpty().WithMessage("This area can not be null.");
            RuleFor(x => x.MajorsId).NotEmpty().WithMessage("This area can not be null.");
        }
    }
}
