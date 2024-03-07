using BSIGeneralAffairBLL.DTO.Departement;
using BSIGeneralAffairBLL.Interfaces;
using BSIGeneralAffairBO_C;
using BSIGeneralAffairDAL_C;
using BSIGeneralAffairDAL_C.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL
{
    public class DepartementBLL : IDepartementBLL
    {
        private readonly IDepartementDAL _departementDAL;

        public DepartementBLL()
        {
            _departementDAL = new DALDepartement();
        }

        public void Delete(int departementId)
        {
            if (departementId <= 0)
            {
                throw new ArgumentException("Departement ID is required");
            }

            try
            {
                _departementDAL.Delete(departementId);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<DepartementDTO> GetAll()
        {
            List<DepartementDTO> listDepartementsDTO = new List<DepartementDTO>();
            var departements = _departementDAL.GetAll();
            foreach (var departement in departements)
            {
                listDepartementsDTO.Add(new DepartementDTO
                {
                    DepartementID = (int)departement.DepartementID,
                    DepartementName = departement.DepartementName,
                    UpdatedAt = departement.UpdatedAt
                });
            }
            return listDepartementsDTO;
        }

        public DepartementDTO GetByDepartementID(int departementId)
        {
            DepartementDTO departementDTO = new DepartementDTO();
            var departement = _departementDAL.GetById(departementId);
            if (departement != null)
            {
                departementDTO.DepartementName = departement.DepartementName;
                departementDTO.UpdatedAt = departement.UpdatedAt;
            }
            else
            {
                throw new ArgumentException($"Departement {departementId} not found");
            }
            return departementDTO;
        }

        public IEnumerable<DepartementDTO> GetByName(string name)
        {
            var departements = _departementDAL.GetByName(name);

            List<DepartementDTO> listDepartementDTOs = new List<DepartementDTO>();
            foreach (var departement in departements)
            {
                listDepartementDTOs.Add(new DepartementDTO
                {
                    DepartementID = (int)departement.DepartementID,
                    DepartementName = departement.DepartementName,
                    UpdatedAt = departement.UpdatedAt
                });
            }
            return listDepartementDTOs;
        }

        public int GetCountDepartement(string name)
        {
            return _departementDAL.GetCountDepartment(name);
        }

        public IEnumerable<DepartementDTO> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            List<DepartementDTO> listDepartementsDTO = new List<DepartementDTO>();
            var departements = _departementDAL.GetWithPaging(pageNumber, pageSize, name);
            foreach (var departement in departements)
            {
                listDepartementsDTO.Add(new DepartementDTO
                {
                    DepartementID = (int)departement.DepartementID,
                    DepartementName = departement.DepartementName,
                });

            }
            return listDepartementsDTO;
        }

        public void Insert(DepartementCreateDTO newDepartement)
        {
            if (string.IsNullOrEmpty(newDepartement.DepartementName))
            {
                throw new ArgumentException("Departement name is required");
            }
            else if (newDepartement.DepartementName.Length > 50)
            {
                throw new ArgumentException("Departement name max length is 50");
            }

            try
            {
                var departementDTO = new Departement()
                {
                    DepartementName = newDepartement.DepartementName,
                };
                _departementDAL.Insert(departementDTO);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Update(DepartementUpdateDTO updateDepartement)
        {
            if (updateDepartement.DepartementID <= 0)
            {
                throw new ArgumentException("Departement ID is required");
            }
            else if (string.IsNullOrEmpty(updateDepartement.DepartementName))
            {
                throw new ArgumentException("Departement name is required");
            }
            else if (updateDepartement.DepartementName.Length > 50)
            {
                throw new ArgumentException("Departement name max length is 50");
            }

            try
            {
                var departement = new Departement
                {
                    DepartementID = (int)updateDepartement.DepartementID,
                    DepartementName = updateDepartement.DepartementName,
                };
                _departementDAL.Update(departement);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
