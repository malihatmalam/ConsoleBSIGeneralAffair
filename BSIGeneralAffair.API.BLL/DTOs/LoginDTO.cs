using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.DTOs
{
    public class LoginDTO
    {
        public string UserUsername { get; set; } = null!;

        public string UserPassword { get; set; } = null!;
    }
}
