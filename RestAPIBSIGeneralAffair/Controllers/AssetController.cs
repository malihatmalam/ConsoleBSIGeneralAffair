using BSIGeneralAffair.API.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPIBSIGeneralAffair.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetBLL _assetBLL;

        public AssetController(IAssetBLL assetBLL)
        {
            _assetBLL = assetBLL;
        }

        [Authorize]
        // GET: api/<AssetController>
        [HttpGet("detail/{numberAsset}")]
        public async Task<IActionResult> GetByNumber(string numberAsset)
        {
            var result = await _assetBLL.GetByNumber(numberAsset);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
        // GET api/<AssetController>/5
        [HttpPost("myAsset")]
        public async Task<IActionResult> GetMyAsset([FromForm]string employeeNumber)
        {
            var result = await _assetBLL.GetByUser(employeeNumber);
            return Ok(result);
        }

        [Authorize]
        // GET api/<AssetController>/5
        [HttpPost("handsoverHistory")]
        public async Task<IActionResult> GetHandsoverHistory([FromForm] int assetID)
        {
            var result = await _assetBLL.GetHandsoverHistory(assetID);
            return Ok(result);
        }
    }
}
