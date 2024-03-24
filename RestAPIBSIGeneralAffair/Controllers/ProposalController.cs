using BSIGeneralAffair.API.BLL.DTOs;
using BSIGeneralAffair.API.BLL.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPIBSIGeneralAffair.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        private readonly IProposalBLL _proposalBLL;
        private readonly IValidator<ProposalCreateDTO> _validatorProposalCreateDTO;
        private readonly IValidator<ProposalUpdateDTO> _validatorProposalUpdateDTO;

        public ProposalController(IProposalBLL proposalBLL,
            IValidator<ProposalCreateDTO> validatorProposalCreateDTO,
            IValidator<ProposalUpdateDTO> validatorProposalUpdateDTO)
        {
            _proposalBLL = proposalBLL;
            _validatorProposalCreateDTO = validatorProposalCreateDTO;
            _validatorProposalUpdateDTO = validatorProposalUpdateDTO;
        }

        [Authorize]
        // GET: api/<ProposalController>
        [HttpPost("/waiting")]
        public async Task<IEnumerable<ProposalDTO>> GetWaiting([FromForm] string emplyeeNumber)
        {
            var result = await _proposalBLL.GetWaitingProposal(emplyeeNumber);
            return result;
        }

        [Authorize]
        // GET: api/<ProposalController>
        [HttpPost("/history")]
        public async Task<IEnumerable<ProposalDTO>> GetHistory([FromForm] string emplyeeNumber, [FromForm] string typeProposal)
        {
            var result = await _proposalBLL.GetHistoryProposal(emplyeeNumber,typeProposal);
            return result;
        }

        [Authorize]
        // GET api/<ProposalController>/5
        [HttpGet("{proposalToken}")]
        public async Task<ProposalDTO> GetByProposalToken(string proposalToken)
        {
            var result = await _proposalBLL.GetByProposalToken(proposalToken);
            return result;
        }

        [Authorize]
        // POST api/<ProposalController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProposalCreateDTO proposalCreateDTO)
        {
            var validationResult = _validatorProposalCreateDTO.Validate(proposalCreateDTO);
            if (!validationResult.IsValid)
            {
                Helpers.Extensions.AddToModelState(validationResult, ModelState);
                return BadRequest(ModelState);
            }

            var proposal = await _proposalBLL.Insert(proposalCreateDTO);
            return Ok("Proposal create successfull");
        }

        [Authorize]
        // PUT api/<ProposalController>/5
        [HttpPut("{proposalToken}")]
        public async Task<IActionResult> Put(string proposalToken, [FromBody] ProposalUpdateDTO proposalUpdateDTO)
        {
            var validationResult = _validatorProposalUpdateDTO.Validate(proposalUpdateDTO);
            if (!validationResult.IsValid)
            {
                Helpers.Extensions.AddToModelState(validationResult, ModelState);
                return BadRequest(ModelState);
            }

            if (proposalUpdateDTO.ProposalToken != proposalToken) 
            {
                return BadRequest("Proposal Token not consistency");
            }

            var proposal = await _proposalBLL.Update(proposalUpdateDTO);
            return Ok("Proposal update successfull");
        }

        [Authorize]
        // DELETE api/<ProposalController>/5
        [HttpDelete("{proposalToken}")]
        public async Task<IActionResult> Delete(string proposalToken)
        {
            var result = await _proposalBLL.Cancel(proposalToken);
            if (result)
            {
                return Ok("Proposal cancel successfull");
            }
            return NotFound();

        }
    }
}
