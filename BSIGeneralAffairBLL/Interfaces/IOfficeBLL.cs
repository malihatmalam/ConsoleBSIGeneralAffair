using BSIGeneralAffairBLL.DTO.Office;
using System;
using System.Collections.Generic;

namespace BSIGeneralAffairBLL.Interfaces
{
    public interface IOfficeBLL
    {
        IEnumerable<OfficeDTO> GetAll();
        void Insert(OfficeCreateDTO newOffice);
        void Update(OfficeUpdateDTO updateOffice);
        void Delete(int officeID);
        OfficeDTO GetByOfficeID(int officeID);
        IEnumerable<OfficeDTO> GetByName(string name);
        IEnumerable<OfficeDTO> GetWithPaging(int pageNumber, int pageSize, string name);
        int GetCountOffice(string name);
    }
}
