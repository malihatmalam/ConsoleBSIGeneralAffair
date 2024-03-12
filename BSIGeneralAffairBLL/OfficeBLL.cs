using BSIGeneralAffairBLL.DTO.Office;
using BSIGeneralAffairBLL.Interfaces;
using BSIGeneralAffairBO_C;
using BSIGeneralAffairDAL_C;
using BSIGeneralAffairDAL_C.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL
{
    public class OfficeBLL : IOfficeBLL
    {
        private readonly IOfficeDAL _officeDAL;

        public OfficeBLL()
        {
            _officeDAL = new DALOffice();
        }

        public void Delete(int officeID)
        {
            if (officeID <= 0)
            {
                throw new ArgumentException("Office ID is required");
            }

            try
            {
                _officeDAL.Delete(officeID);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<OfficeDTO> GetAll()
        {
            List<OfficeDTO> listOfficesDTO = new List<OfficeDTO>();
            var offices = _officeDAL.GetAll();
            foreach (var office in offices)
            {
                listOfficesDTO.Add(new OfficeDTO
                {
                    OfficeID = (int)office.OfficeID,
                    OfficeName = office.OfficeName,
                    OfficeAddress = office.OfficeAddress,
                    UpdateAt = office.UpdateAt
                });
            }
            return listOfficesDTO;
        }

        public IEnumerable<OfficeDTO> GetByName(string name)
        {
            var offices = _officeDAL.GetByName(name);

            List<OfficeDTO> listOfficeDTOs = new List<OfficeDTO>();
            foreach (var office in offices)
            {
                listOfficeDTOs.Add(new OfficeDTO
                {
                    OfficeID = (int)office.OfficeID,
                    OfficeName = office.OfficeName,
                    OfficeAddress = office.OfficeAddress,
                    UpdateAt = office.UpdateAt
                });
            }
            return listOfficeDTOs;
        }

        public OfficeDTO GetByOfficeID(int officeID)
        {
            OfficeDTO officeDTO = new OfficeDTO();
            var office = _officeDAL.GetById(officeID);
            if (office != null)
            {
                officeDTO.OfficeName = office.OfficeName;
                officeDTO.OfficeAddress = office.OfficeAddress;
                officeDTO.UpdateAt = office.UpdateAt;
            }
            else
            {
                throw new ArgumentException($"Office {officeID} not found");
            }
            return officeDTO;
        }

        public int GetCountOffice(string name)
        {
            return _officeDAL.GetCountOffices(name);
        }

        public IEnumerable<OfficeDTO> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            List<OfficeDTO> listOfficesDTO = new List<OfficeDTO>();
            var offices = _officeDAL.GetWithPaging(pageNumber, pageSize, name);
            foreach (var office in offices)
            {
                listOfficesDTO.Add(new OfficeDTO
                {
                    OfficeID = (int)office.OfficeID,
                    OfficeName = office.OfficeName,
                    OfficeAddress = office.OfficeAddress
                });

            }
            return listOfficesDTO;
        }

        public void Insert(OfficeCreateDTO newOffice)
        {
            if (string.IsNullOrEmpty(newOffice.OfficeName))
            {
                throw new ArgumentException("Office name is required");
            }
            if (string.IsNullOrEmpty(newOffice.OfficeAddress))
            {
                throw new ArgumentException("Office address is required");
            }
            else if (newOffice.OfficeName.Length > 50)
            {
                throw new ArgumentException("Office name max length is 50");
            }
            else if (newOffice.OfficeAddress.Length > 50)
            {
                throw new ArgumentException("Office address max length is 50");
            }

            try
            {
                var officeDTO = new Office
                {
                    OfficeName = newOffice.OfficeName,
                    OfficeAddress = newOffice.OfficeAddress,
                    OfficeFlagActive = true
                };
                _officeDAL.Insert(officeDTO);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Update(OfficeUpdateDTO updateOffice)
        {
            if (updateOffice.OfficeID <= 0)
            {
                throw new ArgumentException("Office ID is required");
            }
            else if (string.IsNullOrEmpty(updateOffice.OfficeName))
            {
                throw new ArgumentException("Office name is required");
            }
            else if (updateOffice.OfficeName.Length > 50)
            {
                throw new ArgumentException("Office name max length is 50");
            }

            try
            {
                var office = new Office
                {
                    OfficeID = (int)updateOffice.OfficeID,
                    OfficeName = updateOffice.OfficeName,
                    OfficeAddress = updateOffice.OfficeAddress,
                    OfficeFlagActive = true
                };
                _officeDAL.Update(office);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
