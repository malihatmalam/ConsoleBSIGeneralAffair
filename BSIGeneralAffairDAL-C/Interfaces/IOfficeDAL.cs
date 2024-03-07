using BSIGeneralAffairBO_C;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairDAL_C.Interfaces
{
    public interface IOfficeDAL : ICrud<Office>
    {
        IEnumerable<Office> GetByName(string name);
        int GetCountOffices(string name);
        IEnumerable<Office> GetWithPaging(int pageNumber, int pageSize, string name);
    }
}
