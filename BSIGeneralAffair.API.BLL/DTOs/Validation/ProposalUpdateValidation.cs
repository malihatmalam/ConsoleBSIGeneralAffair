using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs.Validation
{

    public class ProposalUpdateValidation : AbstractValidator<ProposalUpdateDTO>
    {
        public ProposalUpdateValidation()
        {
            RuleFor(x => x.ProposalToken).NotEmpty().WithMessage("Token is required");
            RuleFor(x => x.ProposalObjective).NotEmpty().WithMessage("Proposal Objective is required");
            RuleFor(x => x.ProposalRequireDate).NotEmpty().WithMessage("Require Date is required");
            RuleFor(x => x.ProposalBudget).NotEmpty().WithMessage("Budget is required");
        }
    }
}
