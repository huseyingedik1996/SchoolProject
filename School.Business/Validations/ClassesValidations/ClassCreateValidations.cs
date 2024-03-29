﻿using FluentValidation;
using School.Dto.Dtos.ClassDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.ClassesValidations
{
    public class ClassCreateValidations : AbstractValidator<ClassCreateDto>
    {
        public ClassCreateValidations()
        {
            RuleFor(x => x.ClassName).NotEmpty().WithMessage("Bu Alan Boş Geçilemez");
        }
    }
}
