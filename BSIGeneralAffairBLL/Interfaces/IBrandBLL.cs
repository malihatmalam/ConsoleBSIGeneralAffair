using BSIGeneralAffairBLL.DTO.Brand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BSIGeneralAffairBLL.Interfaces
{
    public interface IBrandBLL
    {
        IEnumerable<BrandDTO> GetAll();
        void Insert(BrandCreateDTO newBrand);
        void Update(BrandUpdateDTO updateBrand);
        void Delete(int brandID);
        BrandDTO GetByBrandID(int brandID);
        IEnumerable<BrandDTO> GetByName(string name);
        IEnumerable<BrandDTO> GetWithPaging(int pageNumber, int pageSize, string name);
        int GetCountBrand(string name);
    }
}
