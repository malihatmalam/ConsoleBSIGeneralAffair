using BSIGeneralAffair.API.BLL.DTOs;
using BSIGeneralAffair.API.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPIBSIGeneralAffair.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomepageController : ControllerBase
    {
        private readonly IHomepageBLL _homepageBLL;
        public HomepageController(IHomepageBLL homepageBLL)
        {
            _homepageBLL = homepageBLL;
        }

        [HttpGet("{employeeNumber}")]
        public async Task<HomepageDTO> Get(string employeeNumber) 
        {
            var result = await _homepageBLL.Get(employeeNumber);
            return result;
        }
    }
}
