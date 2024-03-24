using BSIGeneralAffair.API.BLL.DTOs;
using BSIGeneralAffair.API.BLL.DTOs.Validation;
using BSIGeneralAffair.API.BLL.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPIBSIGeneralAffair.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ApprovalController : ControllerBase
    {
        private readonly IApprovalBLL _approvalBLL;
        private readonly IValidator<ApprovalCreateDTO> _validatorApprovalCreateDTO;

        public ApprovalController(IApprovalBLL approvalBLL, IValidator<ApprovalCreateDTO> validator)
        {
            _approvalBLL = approvalBLL;
            _validatorApprovalCreateDTO = validator;
        }

        [Authorize]
        // GET: api/<ApprovalController>
        [HttpGet("{proposalToken}")]
        public async Task<IActionResult> GetHistory(string proposalToken)
        {
            var result = await _approvalBLL.GetHistoryApproval(proposalToken);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize(Roles = "Manager GA")]
        // POST api/<ApprovalController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApprovalCreateDTO createApproval)
        {
            var validationResult = _validatorApprovalCreateDTO.Validate(createApproval);
            if (!validationResult.IsValid)
            {
                Helpers.Extensions.AddToModelState(validationResult, ModelState);
                return BadRequest(ModelState);
            }
            var result = await _approvalBLL.Approval(createApproval);
            return Ok("Approval successfull");
        }
    }
}
