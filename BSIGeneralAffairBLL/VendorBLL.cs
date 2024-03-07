using BSIGeneralAffairBLL.DTO.Brand;
using BSIGeneralAffairBLL.DTO.Vendor;
using BSIGeneralAffairBLL.Interfaces;
using BSIGeneralAffairBO_C;
using BSIGeneralAffairDAL_C;
using BSIGeneralAffairDAL_C.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL
{
    public class VendorBLL : IVendorBLL
    {
        private readonly IVendorDAL _vendorDAL;
 
        public VendorBLL() {
            _vendorDAL = new DALVendor(); 
        }

        public void Delete(int vendorID)
        {
            if (vendorID <= 0)
            {
                throw new ArgumentException("Vendor ID is required");
            }

            try
            {
                _vendorDAL.Delete(vendorID);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            
        }

        public IEnumerable<VendorDTO> GetAll()
        {
            List<VendorDTO> listVendorsDTO = new List<VendorDTO>();
            var vendors = _vendorDAL.GetAll();
            foreach (var vendor in vendors)
            {
                listVendorsDTO.Add(new VendorDTO
                {
                    VendorID = (int)vendor.VendorID,
                    VendorName = vendor.VendorName,
                    VendorAddress = vendor.VendorAddress,
                    CreatedAt = vendor.CreatedAt,
                    UpdatedAt = vendor.UpdatedAt
                });
            }
            return listVendorsDTO;
        }

        public IEnumerable<VendorDTO> GetByName(string name)
        {
            var vendors = _vendorDAL.GetByName(name);

            List<VendorDTO> listVendorDTOs = new List<VendorDTO>();
            foreach (var vendor in vendors)
            {
                listVendorDTOs.Add(new VendorDTO
                {
                    VendorID = (int)vendor.VendorID,
                    VendorName = vendor.VendorName,
                    UpdatedAt = vendor.UpdatedAt
                });
            }
            return listVendorDTOs;
        }


        public VendorDTO GetByVendorID(int vendorId)
        {
            VendorDTO vendorDTO = new VendorDTO();
            var vendor = _vendorDAL.GetById(vendorId);
            if (vendor!= null)
            {
                vendorDTO.VendorName = vendor.VendorName;
                vendorDTO.VendorAddress = vendor.VendorAddress;
                vendorDTO.CreatedAt = vendor.CreatedAt;
                vendorDTO.UpdatedAt = vendor.UpdatedAt;
            }
            else
            {
                throw new ArgumentException($"Brand {vendorId} not found");
            }
            return vendorDTO;
        }

        public int GetCountVendor(string name)
        {
            return _vendorDAL.GetCountVendors(name);
        }

        public IEnumerable<VendorDTO> GetWithPaging(int pageNumber, int pageSize, string name)
        {

            List<VendorDTO> listVendorsDTO = new List<VendorDTO>();
            var vendors = _vendorDAL.GetWithPaging(pageNumber, pageSize, name);
            foreach (var vendor in vendors)
            {
                listVendorsDTO.Add(new VendorDTO
                {
                    VendorID = (int)vendor.VendorID,
                    VendorName = vendor.VendorName,
                });

            }
            return listVendorsDTO;
        }

        public void Insert(VendorCreateDTO newVendor)
        {
            if (string.IsNullOrEmpty(newVendor.VendorName))
            {
                throw new ArgumentException("Vendor name is required");
            }
            if (string.IsNullOrEmpty(newVendor.VendorAddress))
            {
                throw new ArgumentException("Vendor address is required");
            }
            else if (newVendor.VendorName.Length > 50)
            {
                throw new ArgumentException("Vendor name max length is 50");
            }
            else if (newVendor.VendorAddress.Length > 50)
            {
                throw new ArgumentException("Vendor address max length is 50");
            }

            try
            {
                var vendorDTO = new Vendor
                {
                    VendorName = newVendor.VendorName,
                    VendorAddress = newVendor.VendorAddress,
                };
                _vendorDAL.Insert(vendorDTO);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Update(VendorUpdateDTO updateVendor)
        {
            if (updateVendor.VendorID <= 0)
            {
                throw new ArgumentException("Vendor ID is required");
            }
            if (string.IsNullOrEmpty(updateVendor.VendorName))
            {
                throw new ArgumentException("Vendor name is required");
            }
            if (string.IsNullOrEmpty(updateVendor.VendorAddress))
            {
                throw new ArgumentException("Vendor address is required");
            }
            else if (updateVendor.VendorName.Length > 50)
            {
                throw new ArgumentException("Vendor name max length is 50");
            }
            else if (updateVendor.VendorAddress.Length > 50)
            {
                throw new ArgumentException("Vendor address max length is 50");
            }

            try
            {
                var vendor = new Vendor
                {
                    VendorID = (int)updateVendor.VendorID,
                    VendorName = updateVendor.VendorName,
                    VendorAddress = updateVendor.VendorAddress,
                };
                _vendorDAL.Update(vendor);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
