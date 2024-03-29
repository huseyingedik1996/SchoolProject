﻿using FluentValidation;
using School.Dto.Dtos.MajorhasClassesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.MajorhasClassesValidations
{
    public class MajorhasClassUpdateValidations : AbstractValidator<MajorhasClassesUpdateDto>
    {
        public MajorhasClassUpdateValidations()
        {
            RuleFor(x => x.ClassesId).NotEmpty().WithMessage("Bu Alan Boş Geçilemez");
            RuleFor(x => x.MajorsId).NotEmpty().WithMessage("Bu Alan Boş Geçilemez");
        }
    }
}
