using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.Interfaces
{
    public interface IBrandBLL
    {
        Task<IEnumerable<Brand>> GetAll();
        Task<IEnumerable<Brand>> GetByName(String name);
        Task<int> GetCount(string name);
    }
}
