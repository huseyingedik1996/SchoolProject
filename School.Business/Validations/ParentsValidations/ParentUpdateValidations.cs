using FluentValidation;
using School.Dto.Dtos.ParentsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.ParentsValidations
{
    public class ParentUpdateValidations : AbstractValidator<ParentUpdateDto>
    {
        public ParentUpdateValidations()
        {
            RuleFor(x => x.ParentName).NotEmpty().WithMessage("This area can not be null.").Length(1, 45);
            RuleFor(x => x.ParentSurname).NotEmpty().WithMessage("This area can not be null.").Length(1, 45);
            RuleFor(x => x.ParentContact).NotEmpty().WithMessage("This area can not be null.").MaximumLength(15);
            RuleFor(x => x.Address).NotEmpty().WithMessage("This area can not be null.").MaximumLength(350);
        }
    }
}
