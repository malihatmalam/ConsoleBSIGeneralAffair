using AutoMapper;
using BSIGeneralAffair.API.BLL.DTOs;
using BSIGeneralAffair.API.BLL.Interfaces;
using BSIGeneralAffair.API.Data.Interfaces;
using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL
{
    public class ProposalBLL : IProposalBLL
    {
        private readonly IProposalData _proposalData;
        private readonly IMapper _mapper;
        public ProposalBLL(IProposalData proposalData, IMapper mapper) {
            _proposalData = proposalData;
            _mapper = mapper;
        }

        public async Task<bool> Cancel(string proposalToken)
        {
            try
            {
                var proposal = await _proposalData.GetByProposalToken(proposalToken);
                if (proposal == null) 
                {
                    throw new ArgumentException("Proposal not found");
                }
                return await _proposalData.Cancel(proposalToken);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<ProposalDTO> GetByProposalToken(string proposalToken)
        {
            try
            {
                var proposal = _mapper.Map<ProposalDTO>(await _proposalData.GetByProposalToken(proposalToken));
                return proposal;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"BLL - {ex.Message}");
            }
        }

        public async Task<IEnumerable<ProposalDTO>> GetHistoryProposal(string employeeNumber, string typeProposal)
        {
            try
            {
                var proposals = _mapper.Map<IEnumerable<ProposalDTO>>(await _proposalData.GetHistoryProposal(employeeNumber,typeProposal));
                return proposals;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"BLL - {ex.Message}");
            }
        }

        public async Task<IEnumerable<ProposalDTO>> GetWaitingProposal(string employeeNumber)
        {
            try
            {
                var proposals = _mapper.Map<IEnumerable<ProposalDTO>>( await _proposalData.GetWaitingProposal(employeeNumber));
                return proposals;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"BLL - {ex.Message}");
            }
        }

        public async Task<Task> Insert(ProposalCreateDTO createProposal)
        {
            try
            {
                var _createProposal = _mapper.Map<Proposal>(createProposal);
                var createdProposal = await _proposalData.Create(_createProposal, createProposal.EmployeeIdnumber, createProposal.ProposalType, createProposal.AssetNumber);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"BLL - {ex.Message}");
            }
        }

        public async Task<Task> Update(ProposalUpdateDTO updateProposal)
        {
            try
            {
                var proposal = await _proposalData.GetByProposalToken(updateProposal.ProposalToken);
                if (proposal == null)
                {
                    throw new ArgumentException("Proposal not found");
                }
                var _updateProposal = _mapper.Map<Proposal>(updateProposal);
                var updatedProposal = await _proposalData.Update(_updateProposal);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"BLL - {ex.Message}");
            }
        }
    }
}
