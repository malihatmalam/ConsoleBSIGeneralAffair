using BSIGeneralAffairBLL.DTO.Brand;
using BSIGeneralAffairBLL.Interfaces;
using BSIGeneralAffairBO;
using BSIGeneralAffairDAL_C;
using BSIGeneralAffairDAL_C.Interfaces;
using GeneralAffairInterface;
using System;
using System.Collections.Generic;
using System.Text;
using static Dapper.SqlMapper;

namespace BSIGeneralAffairBLL
{
    public class BrandBLL : IBrandBLL
    {
        private readonly IBrandDAL _brandDAL;

        public BrandBLL() {
            _brandDAL = new DALBrand();
        }

        public void Delete(int brandID)
        {
            if (brandID <= 0) {
                throw new ArgumentException("Brand ID is required");
            }

            try
            {
                _brandDAL.Delete(brandID);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<BrandDTO> GetAll()
        {
            List<BrandDTO> listBrandsDTO = new List<BrandDTO>();
            var brands = _brandDAL.GetAll();
            foreach (var brand in brands) {
                listBrandsDTO.Add(new BrandDTO
                {
                    BrandID = (int)brand.BrandID,
                    BrandName = brand.BrandName,
                    UpdatedAt = brand.UpdatedAt
                });
            }
            return listBrandsDTO;
        }

        public BrandDTO GetByBrandID(int brandID)
        {
            BrandDTO brandDTO = new BrandDTO();
            var brand = _brandDAL.GetById(brandID);
            if (brand != null)
            {
                brandDTO.BrandName = brand.BrandName;
                brandDTO.UpdatedAt = brand.UpdatedAt;
            }
            else {
                throw new ArgumentException($"Brand {brandID} not found");
            }
            return brandDTO;
        }

        public int GetCountBrand(string name)
        {
            return _brandDAL.GetCountBrands(name);
        }

        public IEnumerable<BrandDTO> GetByName(string name)
        {
            var brands = _brandDAL.GetByName(name);

            List<BrandDTO> listBrandDTOs = new List<BrandDTO>();
            foreach (var brand in brands)
            {
                listBrandDTOs.Add(new BrandDTO
                {
                    BrandID = (int)brand.BrandID,
                    BrandName = brand.BrandName,
                    UpdatedAt = brand.UpdatedAt
                });
            }
            return listBrandDTOs;
        }

        public IEnumerable<BrandDTO> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            List<BrandDTO> listBrandsDTO = new List<BrandDTO>();
            var brands = _brandDAL.GetWithPaging(pageNumber, pageSize, name);
            foreach (var brand in brands)
            {
                listBrandsDTO.Add(new BrandDTO
                {
                    BrandID = (int)brand.BrandID,
                    BrandName = brand.BrandName,
                });
                
            }
            return listBrandsDTO;
        }

        public void Insert(BrandCreateDTO newBrand)
        {
            if (string.IsNullOrEmpty(newBrand.BrandName))
            {
                throw new ArgumentException("Brand name is required");
            }
            else if (newBrand.BrandName.Length > 50)
            {
                throw new ArgumentException("Brand name max length is 50");
            }

            try
            {
                var brandDTO = new Brand
                {
                    BrandName = newBrand.BrandName,
                };
                _brandDAL.Insert(brandDTO);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Update(BrandUpdateDTO updateBrand)
        {
            if (updateBrand.BrandId <= 0)
            {
                throw new ArgumentException("Brand ID is required");
            }
            else if (string.IsNullOrEmpty(updateBrand.BrandName))
            {
                throw new ArgumentException("Brand name is required");
            }
            else if (updateBrand.BrandName.Length > 50)
            {
                throw new ArgumentException("Brand name max length is 50");
            }

            try
            {
                var brand = new Brand
                {
                    BrandID = (short?)updateBrand.BrandId,
                    BrandName = updateBrand.BrandName,
                };
                _brandDAL.Update(brand);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
