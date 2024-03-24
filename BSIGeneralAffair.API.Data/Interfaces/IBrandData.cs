using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.Data.Interfaces
{
    public interface IBrandData
    {
        Task<IEnumerable<Brand>> GetAll();
        Task<IEnumerable<Brand>> GetByName(String name);
        Task<int> GetCount(string name);
    }
}
