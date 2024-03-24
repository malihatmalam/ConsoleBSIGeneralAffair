using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs.Validation
{
    public class LoginValidation : AbstractValidator<LoginDTO>
    {
        public LoginValidation()
        {
            RuleFor(x => x.UserUsername).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage("Password is required");
            
        }

    }
}
