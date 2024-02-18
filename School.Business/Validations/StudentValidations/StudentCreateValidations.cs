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
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu Alan Boş Geçilemez ve Uznunluk 1-45 arasında olmalıdır").Length(1, 45);
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Bu Alan Boş Geçilemez ve Uznunluk 1-45 arasında olmalıdır").Length(1, 45);
            RuleFor(x => x.Address).NotEmpty().WithMessage("Bu Alan Boş Geçilemez ve Uznunluk 10-350 arasında olmalıdır").Length(10, 350);
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage("Bu Alan Boş Geçilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Bu Alan Boş Geçilemez ve Uznunluk 1-25 arasında olmalıdır").Length(1, 25);
            RuleFor(x => x.Contact).NotEmpty().WithMessage("Bu Alan Boş Geçilemez ve Uznunluk 1-15 arasında olmalıdır").Length(1, 15);
            RuleFor(x => x.TCNumber).NotEmpty().WithMessage("Bu Alan Boş Geçilemez");

        }
    }
}
