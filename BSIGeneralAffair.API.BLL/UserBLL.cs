using AutoMapper;
using BSIGeneralAffair.API.BLL.DTOs;
using BSIGeneralAffair.API.BLL.Interfaces;
using BSIGeneralAffair.API.Data;
using BSIGeneralAffair.API.Data.Interfaces;
using BSIGeneralAffair.API.Domain.Models;

namespace BSIGeneralAffair.API.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserData _userData;
        private readonly IMapper _mapper;
        public UserBLL(IUserData userData, IMapper mapper)
        {
            _userData = userData;
            _mapper = mapper;
        }

        public Task<Task> ChangePassword(string username, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            try
            {
                var userData = _mapper.Map<IEnumerable<UserDTO>>(await _userData.GetAll());
                return userData;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"BLL - {ex.Message}");
            }
        }

        public async Task<UserDTO> GetByUsername(string username)
        {
            try
            {
                var userData = _mapper.Map<UserDTO>(await _userData.GetByUsername(username) );
                return userData;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"BLL - {ex.Message}");
            }
        }

        public async Task<UserDTO> Login(LoginDTO loginDTO)
        {
            try
            {

                var user = await _userData.Login(loginDTO.UserUsername, loginDTO.UserPassword);
                if (user == null)
                {
                    throw new ArgumentException("Invalid username or password");
                }
                var userDTO = _mapper.Map<UserDTO>(user);
                return userDTO;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"BLL - {ex.Message}");
            }
        }

        public Task<UserDTO> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
