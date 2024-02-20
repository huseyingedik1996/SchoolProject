using FluentValidation;
using School.Dto.Dtos.BranchDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Validations.BranchValidations
{
    public class BranchUpdateValidation : AbstractValidator<BranchUpdateDto>
    {
        public BranchUpdateValidation()
        {
            RuleFor(x => x.BranchName).NotEmpty().WithMessage("Bu Alan Boş Geçilemez");
        }
    }
}
