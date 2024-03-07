using BSIGeneralAffairBLL.DTO.Vendor;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.Interfaces
{
    public interface IVendorBLL
    {
        IEnumerable<VendorDTO> GetAll();
        void Insert(VendorCreateDTO newVendor);
        void Update(VendorUpdateDTO updateVendor);
        void Delete(int vendorId);
        VendorDTO GetByVendorID(int vendorId);
        IEnumerable<VendorDTO> GetByName(string name);
        IEnumerable<VendorDTO> GetWithPaging(int pageNumber, int pageSize, string name);
        int GetCountVendor(string name);
    }
}
