using FluentValidation;
using School.Dto.Dtos.DepartmantHasMajorClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.DepartmanHasClassMajorValidations
{
    public class CreateDepartmanHasClassMajorValidation : AbstractValidator<CreateDepartmanHasMajorClass>
    {
        public CreateDepartmanHasClassMajorValidation()
        {
            RuleFor(x => x.DepartmantNameId).NotEmpty();
            RuleFor(x => x.MajorHasClassId).NotEmpty();
        }
    }
}
