using AutoMapper;
using BSIGeneralAffair.API.BLL.DTOs;
using BSIGeneralAffair.API.BLL.Interfaces;
using BSIGeneralAffair.API.Data;
using BSIGeneralAffair.API.Data.Interfaces;
using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL
{
    public class ApprovalBLL : IApprovalBLL
    {
        private readonly IApprovalData _approvalData;
        private readonly IMapper _mapper;

        public ApprovalBLL(IApprovalData approvalData, IMapper mapper) 
        {
            _approvalData = approvalData;
            _mapper = mapper;  
        }

        public async Task<Task> Approval(ApprovalCreateDTO approval)
        {
            try
            {
                var _createApproval = _mapper.Map<Approval>(approval);
                var createdApproval = await _approvalData.Approval(_createApproval);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"BLL - {ex.Message}");
            }
        }

        public async Task<IEnumerable<ApprovalDTO>> GetHistoryApproval(string proposalToken)
        {
            try
            {
                var approvalData = _mapper.Map<IEnumerable<ApprovalDTO>>(await _approvalData.GetHistoryApproval(proposalToken));
                return approvalData;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"BLL - {ex.Message}");
            }
        }
    }
}
