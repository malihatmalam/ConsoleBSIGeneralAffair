using BSIGeneralAffairBO_C;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairDAL_C.Interfaces
{
    public interface IUserDAL
    {
        IEnumerable<User> GetAll(); 
        User GetByUsername(string username);
        User Login(string username, string password);
    }
}
