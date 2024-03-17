using BSIGeneralAffairBLL.DTO.User;
using BSIGeneralAffairBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MVCBSIGeneralAffairCosmetic.Models;
using System.Text.Json;

namespace MVCBSIGeneralAffairCosmetic.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBLL _userBLL;

        public UserController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginData)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var user = _userBLL.Login(loginData.Username.ToString(), loginData.Password.ToString());
                if (user != null)
                {
                    if (user.UserRole != "Other")
                    {
                        var userDtoSerialize = JsonSerializer.Serialize(user);
                        HttpContext.Session.SetString("user", userDtoSerialize);
                        //TempData["Message"] = "Welcome " + user.UserFirstName;
                        return RedirectToAction("Index", "Brand");
                    }
                    else
                    {
                        ViewBag.Message = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong> Akun anda tidak memiliki akses.</div>";
                        return View();
                    }
                }
                else {
                    ViewBag.Message = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong> Username / Password anda tidak valid.</div>";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong>" + ex.Message + "</div>";
                return View();
            }
        }

        [Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            TempData["message"] = String.Empty;
            return RedirectToAction("Login");

        }
    }
}
