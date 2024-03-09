using BSIGeneralAffairBLL.DTO.User;
using BSIGeneralAffairBLL.Interfaces;
using BSIGeneralAffairDAL_C;
using BSIGeneralAffairDAL_C.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL _userDAL; 

        public UserBLL()
        {
            _userDAL = new DALUser();
        }

        public UserDTO GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public UserDTO Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username is required");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password is required");
            }
            try
            {
                var result = _userDAL.Login(username.ToString(), password.ToString());
                if (result == null)
                {
                    throw new ArgumentException("Username or Password is wrong");
                }

                UserDTO userDTO = new UserDTO
                {
                    UserID = result.UserID,
                    UserFirstName = result.UserFirstName,
                    UserLastName = result.UserLastName,
                    UserToken = result.UserToken,
                    UserRole = result.UserRole,
                };
                userDTO.Employee = new DTO.Employee.EmployeeDTO();
                userDTO.Employee.EmployeeIDNumber = result.Employee.EmployeeIDNumber;
                userDTO.Employee.EmployeePositionLevel = result.Employee.EmployeePositionLevel; 
                userDTO.Employee.EmployeeJobTitle = result.Employee.EmployeeJobTitle;

                return userDTO;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<UserDTO> GetAll() 
        {
            List<UserDTO> listUserDTO = new List<UserDTO>();
            var users = _userDAL.GetAll();
            foreach ( var user in users ) 
            {
                listUserDTO.Add(new UserDTO 
                {
                    UserID = user.UserID,
                    UserFirstName= user.UserFirstName,
                    UserLastName= user.UserLastName,
                    UserToken = user.UserToken,
                    UserRole = user.UserRole,
                    UserUsername = user.UserUsername,
                    UserFullName = user.UserFirstName + " " + user.UserLastName,
                });
            }
            return listUserDTO;
        }
    }
}
