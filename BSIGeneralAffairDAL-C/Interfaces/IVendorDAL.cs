using BSIGeneralAffairBO_C;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairDAL_C.Interfaces
{
    public interface IVendorDAL : ICrud<Vendor>
    {
        IEnumerable<Vendor> GetByName(String name);
        int GetCountVendors(string name);
        IEnumerable<Vendor> GetWithPaging(int pageNumber, int pageSize, string name);
    }
}
