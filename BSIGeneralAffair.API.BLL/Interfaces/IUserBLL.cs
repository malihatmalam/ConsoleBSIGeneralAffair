using BSIGeneralAffair.API.BLL.DTOs;
using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL.Interfaces
{
    public interface IUserBLL
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetByUsername(string username);
        Task<UserDTO> Login(LoginDTO loginDTO);
        Task<UserDTO> Update(User entity);
        Task<Task> ChangePassword(string username, string newPassword);
    }
}
