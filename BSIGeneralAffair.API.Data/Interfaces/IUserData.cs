using BSIGeneralAffair.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.Data.Interfaces
{
    public interface IUserData
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetByUsername(string username);
        Task<User> Login(string username, string password);
        Task<User> Update(User entity);
        Task<Task> ChangePassword(string username, string newPassword);
    }
}
