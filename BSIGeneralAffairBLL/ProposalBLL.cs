using BSIGeneralAffairBLL.DTO.Asset;
using BSIGeneralAffairBLL.DTO.Departement;
using BSIGeneralAffairBLL.DTO.Employee;
using BSIGeneralAffairBLL.DTO.Proposal;
using BSIGeneralAffairBLL.DTO.User;
using BSIGeneralAffairBLL.DTO.Vendor;
using BSIGeneralAffairBLL.Interfaces;
using BSIGeneralAffairBO_C;
using BSIGeneralAffairDAL_C;
using BSIGeneralAffairDAL_C.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace BSIGeneralAffairBLL
{
    public class ProposalBLL : IProposalBLL
    {
        private readonly IProposalDAL _proposalDAL;

        public ProposalBLL()
        {
            _proposalDAL = new DALProposal();
        }

        public ProposalDTO GetByProposalToken(string proposalToken)
        {
            ProposalDTO proposalDTO = new ProposalDTO();
            var proposal = _proposalDAL.GetByProposalToken(proposalToken);
            if (proposal != null)
            {
                
                proposalDTO.ProposalToken = proposal.ProposalToken;
                proposalDTO.DepartementName = proposal.Department.DepartementName;
                proposalDTO.UserFullName = proposal.User.UserFullName;
                proposalDTO.EmployeePosition = proposal.Employee.EmployeePosition;
                proposalDTO.VendorName = proposal.Vendor.VendorName;
                proposalDTO.VendorAddress = proposal.Vendor.VendorAddress;
                if (proposal.VendorID != null )
                {
                proposalDTO.VendorID = proposal.VendorID;
                }
                proposalDTO.ProposalObjective = proposal.ProposalObjective;
                proposalDTO.ProposalDescription = proposal.ProposalDescription;
                proposalDTO.ProposalRequireDate = proposal.ProposalRequireDate;
                proposalDTO.ProposalBudget = proposal.ProposalBudget;
                proposalDTO.ProposalNote = proposal.ProposalNote;
                proposalDTO.ProposalType = proposal.ProposalType;
                proposalDTO.ProposalStatus = proposal.ProposalStatus;
                proposalDTO.ProposalApproveLevel = proposal.ProposalApproveLevel;
                proposalDTO.ProposalNegotiationNote = proposal.ProposalNegotiationNote;
            }
            else
            {
                throw new ArgumentException($"Proposal {proposalToken} not found");
            }
            return proposalDTO;
        }

        public IEnumerable<ProposalDTO> GetHistoryProposal(string typeProposal, int pageNumber, int pageSize, string search)
        {
            List<ProposalDTO> listProposalDTOs = new List<ProposalDTO>();
            var proposals = _proposalDAL.GetHistoryProposal(typeProposal, pageNumber, pageSize, search);
            foreach (var proposal in proposals)
            {
                ProposalDTO proposalDTO = new ProposalDTO();
                proposalDTO.ProposalToken = proposal.ProposalToken;
                proposalDTO.DepartementName = proposal.Department.DepartementName;
                proposalDTO.UserFullName = proposal.User.UserFullName;
                proposalDTO.EmployeePosition = proposal.Employee.EmployeePosition;
                proposalDTO.VendorName = proposal.Vendor.VendorName;
                proposalDTO.VendorAddress = proposal.Vendor.VendorAddress;
                proposalDTO.ProposalObjective = proposal.ProposalObjective;
                proposalDTO.ProposalDescription = proposal.ProposalDescription;
                proposalDTO.ProposalRequireDate = proposal.ProposalRequireDate;
                proposalDTO.ProposalBudget = proposal.ProposalBudget;
                proposalDTO.ProposalNote = proposal.ProposalNote;
                proposalDTO.ProposalType = proposal.ProposalType;
                proposalDTO.ProposalStatus = proposal.ProposalStatus;
                proposalDTO.ProposalApproveLevel = proposal.ProposalApproveLevel;
                proposalDTO.ProposalNegotiationNote = proposal.ProposalNegotiationNote;

                listProposalDTOs.Add(proposalDTO);
            }
            return listProposalDTOs;
        }

        public IEnumerable<ProposalDTO> GetWaitingProposal(string employeeNumber)
        {
            List<ProposalDTO> listProposalDTOs = new List<ProposalDTO>();
            var proposals = _proposalDAL.GetWaitingProposal(employeeNumber);
            foreach (var proposal in proposals)
            {
                ProposalDTO proposalDTO = new ProposalDTO();
                proposalDTO.ProposalToken = proposal.ProposalToken;
                proposalDTO.DepartementName = proposal.Department.DepartementName;
                proposalDTO.UserFullName = proposal.User.UserFullName;
                proposalDTO.EmployeePosition = proposal.Employee.EmployeePosition;
                proposalDTO.VendorName = proposal.Vendor.VendorName;
                proposalDTO.VendorAddress = proposal.Vendor.VendorAddress;
                proposalDTO.ProposalObjective = proposal.ProposalObjective;
                proposalDTO.ProposalDescription = proposal.ProposalDescription;
                proposalDTO.ProposalRequireDate = proposal.ProposalRequireDate;
                proposalDTO.ProposalBudget = proposal.ProposalBudget;
                proposalDTO.ProposalNote = proposal.ProposalNote;
                proposalDTO.ProposalType = proposal.ProposalType;
                proposalDTO.ProposalStatus = proposal.ProposalStatus;
                proposalDTO.ProposalApproveLevel = proposal.ProposalApproveLevel;
                proposalDTO.ProposalNegotiationNote = proposal.ProposalNegotiationNote;

                listProposalDTOs.Add(proposalDTO);
            }
            return listProposalDTOs;
        }

        public void Update(ProposalUpdateDTO updateProposal)
        {
            if (string.IsNullOrEmpty(updateProposal.ProposalToken.ToString()))
            {
                throw new ArgumentException("Proposal token is required");
            }
            if (string.IsNullOrEmpty(updateProposal.ProposalObjective.ToString()))
            {
                throw new ArgumentException("Objective is required");
            }
            if (string.IsNullOrEmpty(updateProposal.ProposalRequireDate.ToString()))
            {
                throw new ArgumentException("Proposal Require Date is required");
            }

            try
            {

                var proposalDTO = new BSIGeneralAffairBO_C.Proposal
                {
                    ProposalToken = updateProposal.ProposalToken,
                    VendorID = (short?)updateProposal.VendorID,
                    ProposalObjective = updateProposal.ProposalObjective,
                    ProposalDescription = updateProposal.ProposalDescription,
                    ProposalRequireDate = updateProposal.ProposalRequireDate,
                    ProposalBudget = updateProposal.ProposalBudget,
                    ProposalNote = updateProposal.ProposalNote,
                    ProposalNegotiationNote = updateProposal.ProposalNegotiationNote,
                };
                _proposalDAL.Update(proposalDTO);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void UploadFileProposal(ProposalFileDTO file)
        {
            throw new NotImplementedException();
        }

        public int GetCount(string typeProposal, string search) 
        {
            return _proposalDAL.GetCount(typeProposal, search);
        }
    }
}
