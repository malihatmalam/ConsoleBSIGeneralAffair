using BSIGeneralAffair.API.BLL.DTOs;
using BSIGeneralAffair.API.BLL.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestAPIBSIGeneralAffair.Helpers;
using RestAPIBSIGeneralAffair.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPIBSIGeneralAffair.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        private readonly IValidator<LoginDTO> _validatorLoginDTO;
        private readonly AppSettings _appSettings;

        public UserController(IUserBLL userBLL, IValidator<LoginDTO> validator, IOptions<AppSettings> appSettings)
        {
            _userBLL = userBLL;
            _validatorLoginDTO = validator;
            _appSettings = appSettings.Value;
        }

        [Authorize]
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var result = await _userBLL.GetAll();
            return Ok(result);
        }

        [Authorize]
        // GET api/<UserController>/5
        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            var result = await _userBLL.GetByUsername(username);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginData)
        {
            var validationResult = _validatorLoginDTO.Validate(loginData);
            if (!validationResult.IsValid)
            {
                Helpers.Extensions.AddToModelState(validationResult, ModelState);
                return BadRequest(ModelState);
            }

            var user = await _userBLL.Login(loginData);
            if (user.UserUsername != string.Empty)
            {
                List<Claim> claims = new List<Claim>();
                var employeeData = new EmployeeDTO();
                foreach (var employee in user.Employees)
                {
                    employeeData = employee; 
                }
                claims.Add(new Claim(ClaimTypes.Name, employeeData.EmployeeIdnumber));
                claims.Add(new Claim(ClaimTypes.Role, user.UserRole));
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var userWithToken = new UserWithToken
                {
                    Username = loginData.UserUsername,
                    Password = loginData.UserPassword,
                    Token = tokenHandler.WriteToken(token)
                };
                return Ok(userWithToken);
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }
    }
}

