using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.Data.Interfaces
{
    public interface IHomepageData
    {
        Task<Homepage> GetHomepage(string employeeNumber);
    }
}
