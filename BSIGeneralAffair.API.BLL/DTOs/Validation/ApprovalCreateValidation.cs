using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs.Validation
{
    public class ApprovalCreateValidation : AbstractValidator<ApprovalCreateDTO>
    {
        public ApprovalCreateValidation()
        {
            RuleFor(x => x.ProposalToken).NotEmpty().WithMessage("Proposal Token is required");
            RuleFor(x => x.EmployeeIDNumber).NotEmpty().WithMessage("Employee number is required");
            RuleFor(x => x.ApprovalReason).NotEmpty().WithMessage("Reason is required");
            RuleFor(x => x.ApprovalStatus).NotEmpty().WithMessage("Type Approval is required");
        }
    }
}
