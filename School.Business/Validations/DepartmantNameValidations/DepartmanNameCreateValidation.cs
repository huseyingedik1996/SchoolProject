using FluentValidation;
using School.Dto.Dtos.DepartmantName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.DepartmantNameValidations
{
    public class DepartmanNameCreateValidation : AbstractValidator<CreateDepartmantName>
    {
        public DepartmanNameCreateValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
