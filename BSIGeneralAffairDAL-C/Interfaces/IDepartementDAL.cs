using BSIGeneralAffairBO_C;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairDAL_C.Interfaces
{
    public interface IDepartementDAL : ICrud<Departement>
    {
        IEnumerable<Departement> GetByName(string name);
        int GetCountDepartment(string name);
        IEnumerable<Departement> GetWithPaging(int pageNumber, int pageSize, string name);
    }
}
