using FluentValidation;
using School.Dto.Dtos.DepartmantName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.DepartmantNameValidations
{
    public class DepartmantNameUpdateValidation : AbstractValidator<UpdateDepartmantName>
    {
        public DepartmantNameUpdateValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
