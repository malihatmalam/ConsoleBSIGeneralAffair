using BSIGeneralAffairBLL.DTO.Departement;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.Interfaces
{
    public interface IDepartementBLL
    {
        IEnumerable<DepartementDTO> GetAll();
        void Insert(DepartementCreateDTO newDepartement);
        void Update(DepartementUpdateDTO updateDepartement);
        void Delete(int departementId);
        DepartementDTO GetByDepartementID(int departementId);
        IEnumerable<DepartementDTO> GetByName(string name);
        IEnumerable<DepartementDTO> GetWithPaging(int pageNumber, int pageSize, string name);
        int GetCountDepartement(string name);
    }
}
