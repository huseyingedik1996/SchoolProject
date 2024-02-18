using FluentValidation;
using School.Dto.Dtos.ParentsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.ParentsValidations
{
    public class ParentCreateValidations : AbstractValidator<ParentCreateDto>
    {
        public ParentCreateValidations()
        {
            RuleFor(x => x.ParentName).NotEmpty().WithMessage("Bu Alan Boş Geçilemez").Length(1,45);
            RuleFor(x => x.ParentSurname).NotEmpty().WithMessage("Bu Alan Boş Geçilemez").Length(1,45);
            RuleFor(x => x.ParentContact).NotEmpty().WithMessage("Bu Alan Boş Geçilemez").MaximumLength(15);
            RuleFor(x => x.Address).NotEmpty().WithMessage("Bu Alan Boş Geçilemez").MaximumLength(350);
        }
    }
}
