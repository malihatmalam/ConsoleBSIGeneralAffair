using BSIGeneralAffairBO_C;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairDAL_C.Interfaces
{
    public interface ICategoryDAL : ICrud<AssetCategory>
    {
        IEnumerable<AssetCategory> GetByNamesCategory(string name);
        int GetCountCategory(string name);
        IEnumerable<AssetCategory> GetWithPagingCategory(int pageNumber, int pageSize, string name);
    }
}
