using BSIGeneralAffairBO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairDAL_C.Interfaces
{
    public interface IBrandDAL : ICrud<Brand>
    {
        IEnumerable<Brand> GetByName(String name);
        int GetCountBrands(string name);
        IEnumerable<Brand> GetWithPaging(int pageNumber, int pageSize, string name);
    }
}
