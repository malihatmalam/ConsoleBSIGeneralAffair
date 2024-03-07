using BSIGeneralAffairBLL.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL.Interfaces
{
    public interface IUserBLL
    {
        UserDTO Login(string username, string password);
        UserDTO GetByUsername(string username);
    }
}
