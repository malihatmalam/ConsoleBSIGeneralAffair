using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.Interfaces
{
    public interface IOfficeBLL
    {
        Task<IEnumerable<OfficeLocation>> GetAll();
        Task<IEnumerable<OfficeLocation>> GetByName(String name);
        Task<int> GetCount(string name);
    }
}
