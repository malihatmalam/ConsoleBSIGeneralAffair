using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.Data.Interfaces
{
    public interface IOfficeData
    {
        Task<IEnumerable<OfficeLocation>> GetAll();
        Task<IEnumerable<OfficeLocation>> GetByName(String name);
        Task<int> GetCount(string name);
    }
}
