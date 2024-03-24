using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs.Validation
{
    public class ProposalCreateValidation : AbstractValidator<ProposalCreateDTO>
    {
        public ProposalCreateValidation() 
        {
            RuleFor(x => x.EmployeeIdnumber).NotEmpty().WithMessage("Employee Number is required");
            RuleFor(x => x.ProposalObjective).NotEmpty().WithMessage("Proposal Objective is required");
            RuleFor(x => x.ProposalRequireDate).NotEmpty().WithMessage("Require Date is required");
            RuleFor(x => x.ProposalBudget).NotEmpty().WithMessage("Budget is required");
            RuleFor(x => x.ProposalType).NotEmpty().WithMessage("Type proposal is required");
        }
    }
}
