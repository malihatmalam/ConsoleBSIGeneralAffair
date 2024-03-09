using BSIGeneralAffairBLL.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.Interfaces
{
    public interface IUserBLL
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO Login(string username, string password);
        UserDTO GetByUsername(string username);
    }
}
