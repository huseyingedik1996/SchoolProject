using FluentValidation;
using School.Dto.Dtos.MajorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.MajorValidations
{
    public class MajorCreateValidations : AbstractValidator<MajorCreateDto>
    {
        public MajorCreateValidations()
        {
            RuleFor(x => x.MajorName).NotEmpty().WithMessage("This area can not be null.");
        }
    }
}
