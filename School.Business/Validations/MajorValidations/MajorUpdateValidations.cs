using FluentValidation;
using School.Dto.Dtos.MajorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.MajorValidations
{
    public class MajorUpdateValidations : AbstractValidator<MajorUpdateDto>
    {
        public MajorUpdateValidations()
        {
            RuleFor(x => x.MajorName).NotEmpty().WithMessage("Bu Alan Boş Geçilemez");
        }
    }
}
