using BSIGeneralAffair.API.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.Interfaces
{
    public interface IHomepageBLL
    {
        Task<HomepageDTO> Get(string employeeNumber);
    }
}
